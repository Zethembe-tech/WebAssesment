using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommonDLL.DTO
{
    public class LoginDTO
    {

        public string Password { get; set; }
 
        public string Username { get; set; }
  
        public bool RememberMe { get; set; }

        public int Code { get; set; }

    }
}
