using EmployeesBDGifts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.ViewModels
{
    public class ShowInfoViewModel
    {
        public Gift Gift { get; set; }
        public List<User> Users { get; set; }
    }

}
