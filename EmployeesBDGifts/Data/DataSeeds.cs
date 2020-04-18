using EmployeesBDGifts.Data.Repos;
using EmployeesBDGifts.Models;
using System;
using System.Collections.Generic;

namespace EmployeesBDGifts.Data
{
    public static class DataSeeds
    {
        public static void SeedUsers(IUserRepository userRepo)
        {
            List<User> userList = new List<User>();

            for (int i = 0; i < 20; i++)
            {
                User user = new User {
                    UserName = "UserName" + i.ToString(),
                    Name = "Employee" + i.ToString(),
                    Password = "password" + i.ToString(),
                    Bday = DateTime.Now.AddYears(-20).AddMonths(i)
                };

                userList.Add(user);
            }

            userRepo.CreateUsers(userList);
            userRepo.SaveChanges();
        }

        public static void SeedGifts(IGiftRepository giftRepo)
        {
            List<Gift> giftList = new List<Gift>();
            for (int i = 0; i < 20; i++)
            {
                Gift gift = new Gift { Name = "Gift" + i.ToString()};
                giftList.Add(gift);
            }

            giftRepo.CreateMultiple(giftList);
            giftRepo.SaveChanges();
        }
    }
}
