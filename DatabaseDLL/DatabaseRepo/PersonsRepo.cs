using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonDLL.DTO;
using System.Configuration;


namespace DatabaseDLL.DatabaseRepo
{
    public class PersonsRepo
    {
        public List<Persons> ListAllPersons()
        {

            var returnList = new List<Persons>();
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Persons_ListAll"
                })
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            returnList.Add(new Persons
                            {
                                Code = rdr.GetInt32(0),
                                Name = rdr.IsDBNull(1) ? "" : rdr.GetString(1),
                                Surname = rdr.IsDBNull(2) ? "" : rdr.GetString(2),
                                IdNumber = rdr.IsDBNull(3) ? "" : rdr.GetString(3),

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

        public Persons GetPersonsById(int Id)
        {
            var model = new Persons();
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Persons_GetDetailsById"
                })
                {
                    cmd.Parameters.AddWithValue("@Code", Id);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            model.Code = rdr.GetInt32(0);
                            model.Name = rdr.IsDBNull(1) ? "" : rdr.GetString(1);
                            model.Surname = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                            model.IdNumber = rdr.IsDBNull(3) ? "" : rdr.GetString(3);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return model;
        }

        public string AddNewPersons(string name, string surname, string idNumber)
        {

            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Persons_Add"
                })
                {
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname ", surname);
                    cmd.Parameters.AddWithValue("@idNumber ", idNumber);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return rdr.IsDBNull(0) ? "" : rdr.GetString(0);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }

            return string.Empty;
        }

        public string EditPersons(int code, string name, string surname, string idNumber)
        {

            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Persons_Update"
                })
                {
                    cmd.Parameters.AddWithValue("@code ", code);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@surname ", surname);
                    cmd.Parameters.AddWithValue("@IdNumber ", idNumber);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return rdr.IsDBNull(0) ? "" : rdr.GetString(0);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }

            return string.Empty;
        }

        public List<Persons> ListAllPersonNames()
        {

            var returnList = new List<Persons>();
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Persons_GetNameList"
                })
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            returnList.Add(new Persons
                            {
                                Code = rdr.GetInt32(0),
                                Name = rdr.IsDBNull(1) ? "" : rdr.GetString(1),

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
        public string DeletePerson(int code)
        {

            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Persons_Delete"
                })
                {
                    cmd.Parameters.AddWithValue("@code ", code);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return rdr.IsDBNull(0) ? "" : rdr.GetString(0);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }

            return string.Empty;
        }

        public List<Persons> GetPersonDetails(int id)
        {
            var returnList = new List<Persons>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Persons_GetDetails"
                })
                {
                    cmd.Parameters.AddWithValue("@code ", id);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        var personsDict = new Dictionary<int, Persons>();

                        while (rdr.Read())
                        {
                            int personCode = rdr.GetInt32(0);

                            if (!personsDict.ContainsKey(personCode))
                            {
                                personsDict[personCode] = new Persons
                                {
                                    Code = personCode,
                                    Name = rdr.IsDBNull(1) ? "" : rdr.GetString(1),
                                    Accounts = new List<Accounts>()
                                };
                            }

                            var account = new Accounts
                            {
                                AccountNumber = rdr.IsDBNull(2) ? "" : rdr.GetString(2),
                                OutstandingBalance = rdr.IsDBNull(3) ? 0 : rdr.GetDecimal(3),
                            };

                            personsDict[personCode].Accounts.Add(account);
                        }

                        returnList = personsDict.Values.ToList();
                    }
                }

                conn.Close();
                conn.Dispose();
            }

            return returnList;
        }
    }
}
