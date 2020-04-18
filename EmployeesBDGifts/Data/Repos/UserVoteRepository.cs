using EmployeesBDGifts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Data.Repos
{
    public class UserVoteRepository : IUserVoteRepository
    {
        ApplicationDbContext _dbContext;

        public UserVoteRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public void Create(UserVote userVote)
        {
            _dbContext.UserVotes.Add(userVote);
            _dbContext.SaveChanges();
        }

        public UserVote GetByUserIdAndVoteId(int userId, int voteId)
        {
            return _dbContext.UserVotes.SingleOrDefault(x => x.UserId == userId && x.VoteId == voteId);
        }

        public UserVote GetByVoteIdsAndUserId(List<int> voteIds, int userId)
        {
            return _dbContext.UserVotes.FirstOrDefault(x => voteIds.Contains(x.VoteId) && x.UserId == userId);
        }

        public List<UserVote> GetByVoteIds(List<int> voteIds)
        {
            return _dbContext.UserVotes.Where(x => voteIds.Contains(x.VoteId)).ToList();
        }

        public void Delete(UserVote userVote)
        {
            _dbContext.UserVotes.Remove(userVote);
            _dbContext.SaveChanges();

        }
    }
}
