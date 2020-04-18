using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Models
{
    public class Vote
    {
        public int Id { get; set; }
        //This is the user that we are voting for.
        public int UserId { get; set; }
        public int GiftId { get; set; }
        public int Year { get; set; }
        //This is the user that started the vote
        public int OwnerId { get; set; }
        public int Quantity { get; set; }
        public bool VoteEnded { get; set; }
    }
}
