using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Models
{
    //this table signifies one user vote
    //where UserId is the id of the user who voted
    //VoteId is the id of the vote from the VoteTable
    public class UserVote
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int VoteId { get; set; }
    }
}
