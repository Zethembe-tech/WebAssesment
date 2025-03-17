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
    public class LoginLogic
    {
        readonly LoginRepo logRepo = new LoginRepo();

        public LoginDTO UserLogin(string Username, string Password)
        {

            return logRepo.UserLogin(Username, Password);

        }
    }
}
