using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel;


namespace EmployeesBDGifts.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }
        public UserViewModel UserDetails { get; set; }
        public List<string> UserRoles { get; set; }
    }

    public class UserViewModel
    {
        public int UserId { get; set; }

        [DisplayName("User Name")]
        public string Email { get; set; }

        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

    }
}
