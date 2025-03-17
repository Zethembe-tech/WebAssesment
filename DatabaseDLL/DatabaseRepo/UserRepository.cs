using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDLL.DTO;
using Dapper;
using System.Configuration;

namespace DatabaseDLL.DatabaseRepo
{
    public class UserRepository
    {
        public List<Users> GetAllUsers()
        {

            var returnList = new List<Users>();
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Users_ListAll"
                })
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            returnList.Add(new Users
                            {
                                Id = rdr.GetInt32(0),
                                PersonCode = rdr.GetInt32(1),
                                Username = rdr.IsDBNull(2) ? "" : rdr.GetString(2),
                                CreatedAt = rdr.GetDateTime(3),
                                IsActive = rdr.GetBoolean(4),

                            });
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return returnList;
        }

        public List<Users> GetUsersById(int UserId)
        {

            var returnList = new List<Users>();
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Users_ListById"
                })
                {
                    cmd.Parameters.AddWithValue("@UserId", UserId);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            returnList.Add(new Users
                            {
                                Id = rdr.GetInt32(0),
                                PersonCode = rdr.GetInt32(1),
                                Username = rdr.IsDBNull(2) ? "" : rdr.GetString(2),
                                CreatedAt = rdr.GetDateTime(3),
                                IsActive = rdr.GetBoolean(4),

                            });
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return returnList;
        }

        public Users GetUserByUsername(string Username)
        {
            var model = new Users();
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_User_GetDetailsByUsername"
                })
                {
                    cmd.Parameters.AddWithValue("@Username", Username);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            model.Id = rdr.GetInt32(0);
                            model.PersonCode = rdr.GetInt32(1);
                            model.Username = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                            model.CreatedAt = rdr.GetDateTime(3);
                            model.IsActive = rdr.GetBoolean(4);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return model;
        }
        public string AddUsers( string Username, DateTime CreatedAt, bool IsActive)
        {
            string result = "";
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Users_Add"
                })
                {
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@CreatedAt", CreatedAt);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
  
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            result = rdr.IsDBNull(0) ? "" : rdr.GetString(0);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return result;
        }
        public string EditUsers(int id, string Username, DateTime CreatedAt, bool IsActive)
        {
            string result = "";
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Users_Update"
                })
                {
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.Parameters.AddWithValue("@Username", Username);
                    cmd.Parameters.AddWithValue("@CreatedAt", CreatedAt);
                    cmd.Parameters.AddWithValue("@IsActive", IsActive);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            result = rdr.IsDBNull(0) ? "" : rdr.GetString(0);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return result;
        }

        public string DeleteUsers(int id)
        {
            string result = "";
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Users_Delete"
                })
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            result = rdr.IsDBNull(0) ? "" : rdr.GetString(0);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return result;
        }
       
    }
}
