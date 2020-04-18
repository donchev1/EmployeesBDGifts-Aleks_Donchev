using EmployeesBDGifts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Data.Repos
{
    public interface IVoteRepository
    {
        void Create(Vote vote);
        List<Vote> GetVoteByUserIdAndYear(int userId, int year);
        void Update(Vote vote);
        void Delete(Vote vote);
        Vote GetById(int voteId);
    }
}
