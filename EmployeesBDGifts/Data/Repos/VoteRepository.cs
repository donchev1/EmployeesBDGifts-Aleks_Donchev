using EmployeesBDGifts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Data.Repos
{
    public class VoteRepository : IVoteRepository
    {
        ApplicationDbContext _dbContext;

        public VoteRepository(ApplicationDbContext context)
        {
            _dbContext = context;
        }

        public List<Vote> GetVoteByUserIdAndYear(int userId, int year)
        {
            return _dbContext.Votes.Where(x => x.UserId == userId && x.Year == year).ToList();
        }

        public Vote GetById(int voteId)
        {
            return _dbContext.Votes.SingleOrDefault(x => x.Id == voteId);
        }

        public void Create(Vote vote)
        {
            _dbContext.Votes.Add(vote);
            _dbContext.SaveChanges();

        }

        public void Update(Vote vote)
        {
            _dbContext.Votes.Update(vote);
            _dbContext.SaveChanges();
        }

        public void Delete(Vote vote)
        {
            _dbContext.Votes.Remove(vote);
            _dbContext.SaveChanges();
        }
    }
}
