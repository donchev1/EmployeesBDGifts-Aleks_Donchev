using EmployeesBDGifts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.ViewModels
{
    public class VoteOptionsViewModel
    {
        public User BDUser { get; set; }
        public List<Vote> VoteInfoList { get; set; }
        public bool userIsOwner { get; set; }
        public List<Gift> Gifts { get; set; }
        public int Year { get; set; }
        public bool VoteHasStarted { get; set; }
    }
}
