using EmployeesBDGifts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Data.Repos
{
    public interface IUserVoteRepository
    {
        UserVote GetByUserIdAndVoteId(int userId, int voteId);
        void Create(UserVote userVote);
        UserVote GetByVoteIdsAndUserId(List<int> voteIds, int userId);
        void Delete(UserVote userVote);
        List<UserVote> GetByVoteIds(List<int> voteIds);
    }
}
