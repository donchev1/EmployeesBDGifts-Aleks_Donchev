using EmployeesBDGifts.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeesBDGifts.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        public ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }

        public bool UserExistsByUserName(string userName)
        {
            return _context.Users.Any(e => e.UserName == userName);
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
        }

        public void CreateUsers(List<User> userList)
        {
            _context.Users.AddRange(userList);
        }

        public User GetUserById(int UserId)
        {
            return _context.Users.FirstOrDefault(u => u.Id == UserId);
        }

        public User GetUserByUserName(string name)
        {
            //returns null if it doesn't find any users
            return _context.Users.FirstOrDefault(u => u.UserName == name);
        }
        public User GetUserByUserNameAndPassword(string name, string password)
        {
            //returns null if it doesn't find any users
            return _context.Users.FirstOrDefault(u => u.UserName == name && u.Password == password);
        }

        public List<User> GetAllByIds(List<int> idList)
        {
            return _context.Users.Where(x => idList.Contains(x.Id)).ToList();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
