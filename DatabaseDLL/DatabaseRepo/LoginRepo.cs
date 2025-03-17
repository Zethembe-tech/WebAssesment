using CommonDLL.DTO;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDLL.DatabaseRepo
{
    public class LoginRepo
    {
        public LoginDTO UserLogin(string Username, string password)
        {
            using (IDbConnection connection = new SqlConnection(CommonDLL.Helper.Connection.ConnectionString()))
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Username", Username);
                parameters.Add("@PasswordHash", password);

                var user = connection.QuerySingleOrDefault<LoginDTO>(
                    "SELECT * FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash;",
                    parameters
                );

                if (user == null)
                {
                    return null;
                }           

                return user;
            }
        }

    }
}
