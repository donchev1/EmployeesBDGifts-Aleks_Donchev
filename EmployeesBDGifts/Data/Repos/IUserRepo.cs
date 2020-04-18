using EmployeesBDGifts.Models;
using System.Collections.Generic;

namespace EmployeesBDGifts.Data.Repos
{
    public interface IUserRepository
    {
        bool UserExists(int id);
        IEnumerable<User> GetUsers();
        User GetUserById(int UserId);
        User GetUserByUserName(string email);
        User GetUserByUserNameAndPassword(string email, string password);
        void CreateUser(User user);
        void CreateUsers(List<User> userList);
        void SaveChanges();
        bool UserExistsByUserName(string userName);
        List<User> GetAllByIds(List<int> idList);
    }
}
