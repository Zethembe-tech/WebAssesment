using CommonDLL.DTO;
using CommonDLL.Helper;
using DatabaseDLL.DatabaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicDLL.BusinessRepo
{
    public class UsersLogic
    {
        readonly UserRepository userRepo = new UserRepository();
        public List<Users> GetAllUsers()
        {
            return userRepo.GetAllUsers();
        }

        public List<Users> GetUsersById(int UserId)
        {
            return userRepo.GetUsersById(UserId);

        }
        public Users GetUserByUsername(string Username)
        {
   
            return userRepo.GetUserByUsername(Username);

        }
        public string AddUsers(string Username, DateTime CreatedAt, bool IsActive)
        {
            return userRepo.AddUsers(Username, CreatedAt, IsActive);
        }

        public void DeleteUsers(int Id)
        {
            userRepo.DeleteUsers(Id);
        }

        public string EditUsers(int id, string Username, DateTime CreatedAt, bool IsActive)
        {
            return userRepo.EditUsers(id, Username, CreatedAt, IsActive);
        }
    }
}
