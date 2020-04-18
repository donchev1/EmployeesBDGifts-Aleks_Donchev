using EmployeesBDGifts.Data.Repos;
using EmployeesBDGifts.Models;
using EmployeesBDGifts.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Controllers
{
    public class VoteController : Controller
    {
        IVoteRepository _voteRepository;
        IUserRepository _userRepository;
        IGiftRepository _giftRepository;
        IUserVoteRepository _userVoteRepository;

        public VoteController(IVoteRepository voteRepo,
            IUserRepository userRepository,
            IGiftRepository giftRepo,
            IUserVoteRepository userVoteRepository)
        {
            _voteRepository = voteRepo;
            _userRepository = userRepository;
            _giftRepository = giftRepo;
            _userVoteRepository = userVoteRepository;
        }

        [Authorize]
        public ActionResult Index()
        {
            var userList = _userRepository.GetUsers().ToList();
            var currentUser = userList.SingleOrDefault(x => x.UserName == User.Identity.Name);
            //users can't vote for themselves.
            userList.Remove(currentUser);
            return View(userList);
        }

        public ActionResult EndVote(int voteId)
        {
            var vote = _voteRepository.GetById(voteId);
            var allVotesForThatUserAndYear = _voteRepository.GetVoteByUserIdAndYear(vote.UserId, vote.Year);
            foreach(var item in allVotesForThatUserAndYear)
            {
                item.VoteEnded = true;
                _voteRepository.Update(item);
            }
            TempData["SuccessMessage"] = "Vote Ended.";
            return RedirectToAction("ShowVoteInfo", new { userId = vote.UserId, year = vote.Year });
        }

        public ActionResult ShowVoteInfo(int userId, int year)
        {
            List<ShowInfoViewModel> model = new List<ShowInfoViewModel>();
            var voteInfoList = _voteRepository.GetVoteByUserIdAndYear(userId, year);
            var userVotes = _userVoteRepository.GetByVoteIds(voteInfoList.Select(x => x.Id).ToList());
            var users = _userRepository.GetAllByIds(userVotes.Select(x=> x.UserId).ToList());
            var gifts = _giftRepository.GetAll();
            var giftsVotedFor = gifts.Where(x => voteInfoList.Select(y => y.GiftId).Contains(x.Id));
            foreach (var gift in giftsVotedFor)
            {
                var currentVote = voteInfoList.SingleOrDefault(x => x.GiftId == gift.Id);
                var userIdsVotedForThisGift = userVotes.Where(x=> x.VoteId == currentVote.Id)
                    .Select(y=>y.UserId).ToList();

                model.Add(new ShowInfoViewModel
                {
                    Gift = gift,
                    Users = users.Where(u => userIdsVotedForThisGift.Contains(u.Id)).ToList()
                });
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult VoteOptions(int userId, int year = 0)
        {
            year = year == 0 ? DateTime.Now.Year : year;
            var selectedUser = _userRepository.GetUserById(userId);
            var voteInfoList = _voteRepository.GetVoteByUserIdAndYear(userId, year);
            var ownerId = voteInfoList.Count() > 0 ? voteInfoList[0].OwnerId : 0;
            
            if (voteInfoList.Count() >0)
            {
                if (voteInfoList[0].VoteEnded)
                {
                    TempData["SuccessMessage"] = "This Vote Has Already Ended.";
                    return RedirectToAction("ShowVoteInfo", new { userId = userId, year = year });
                }
            }

            bool voteHasStarted = voteInfoList.Count() > 0;
            var currentUser = _userRepository.GetUserByUserName(User.Identity.Name);
            bool userIsOwner = currentUser.Id == ownerId;
            var giftList = _giftRepository.GetAll();

            VoteOptionsViewModel model = new VoteOptionsViewModel()
            {
                VoteInfoList = voteInfoList,
                userIsOwner = userIsOwner,
                Year = year,
                VoteHasStarted = voteHasStarted,
                Gifts = giftList,
                BDUser = selectedUser

            };
            return View(model);
        }


        public ActionResult CastVote(int userId, int giftId, int year)
        {
            var currentUser = _userRepository.GetUserByUserName(User.Identity.Name);
            var voteInfoList = _voteRepository.GetVoteByUserIdAndYear(userId, year);
            
            var ownerId = voteInfoList.Count() > 0 ? voteInfoList[0].OwnerId : 0;
            var existingVote = voteInfoList.SingleOrDefault(x => x.GiftId == giftId);
            Vote _vote = new Vote();
            bool userHasAlreadyVotedForThatGift = false;

            if (existingVote == null)
            {
                _vote = new Vote
                {
                    GiftId = giftId,
                    UserId = userId,
                    Year = year,
                    OwnerId = ownerId == 0 ? currentUser.Id : ownerId,
                    Quantity = 1
                };
                _voteRepository.Create(_vote);
            }
            else
            {
                userHasAlreadyVotedForThatGift = _userVoteRepository.GetByUserIdAndVoteId(currentUser.Id, existingVote.Id) != null;
                if (!userHasAlreadyVotedForThatGift)
                {
                    existingVote.Quantity++;
                }
            }

            if(!userHasAlreadyVotedForThatGift)
            {
                //Delete any previous votes that this user has made.
                if (voteInfoList.Count() > 0)
                {
                    //viteInfoList contains all votes for that person for that year
                    //if the current user has already voted for his colleague for that year
                    // we must delete the previous vote and create a new one
                    var userVote = _userVoteRepository.GetByVoteIdsAndUserId(voteInfoList.Select(x => x.Id).ToList(), currentUser.Id);
                    if (userVote != null)
                    {
                        var previousVote = voteInfoList.SingleOrDefault(x => x.Id == userVote.VoteId);
                        //we either subtract 1 from the current vote record
                        //or delete it entirely if it is only one
                        if (previousVote.Quantity == 1)
                        {
                            _voteRepository.Delete(previousVote);
                        }
                        else
                        {
                            previousVote.Quantity--;
                            _voteRepository.Update(previousVote);
                        }
                        
                        _userVoteRepository.Delete(userVote);
                    }
                }

                //make a userVote record
                var voteId = (existingVote == null ? _vote.Id : existingVote.Id);
                _userVoteRepository.Create(new UserVote { UserId = currentUser.Id, VoteId = voteId });
                TempData["SuccessMessage"] = "Successful vote.";
            }
            else
            {
                TempData["ErrorMessage"] = "You have already voted for this gift.";
            }

            return RedirectToAction("VoteOptions", new { userId = userId, year = year });
        }
    }
}
