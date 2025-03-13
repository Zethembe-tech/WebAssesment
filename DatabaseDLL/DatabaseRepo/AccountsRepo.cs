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
    public class AccountsRepo
    {
        public List<Accounts> ListAllAccounts()
        {

            var returnList = new List<Accounts>();
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Accounts_ListAll"
                })
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            returnList.Add(new Accounts
                            {
                                Code = rdr.GetInt32(0),
                                PersonCode = rdr.GetInt32(1),
                                AccountNumber = rdr.IsDBNull(2) ? "" : rdr.GetString(2),
                                OutstandingBalance = rdr.IsDBNull(3) ? 0 : rdr.GetDecimal(3),
                                PersonName = rdr.IsDBNull(4) ? "" : rdr.GetString(4),

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

        public Accounts GetAccountById(int Id)
        {
            var model = new Accounts();
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Accounts_GetDetailsById"
                })
                {
                    cmd.Parameters.AddWithValue("@Code", Id);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            model.Code = rdr.GetInt32(0);
                            model.PersonCode = rdr.GetInt32(1);
                            model.AccountNumber = rdr.IsDBNull(2) ? "" : rdr.GetString(2);
                            model.OutstandingBalance = rdr.IsDBNull(3) ? 0 : rdr.GetDecimal(3);
                            model.PersonName = rdr.IsDBNull(4) ? "" : rdr.GetString(4);
                        }
                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return model;
        }

        public string AddNewAccount(string AccountNumber, int PersonCode, decimal OutstandingBalance)
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
                    CommandText = "stp_Accounts_Add"
                })
                {
                    cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                    cmd.Parameters.AddWithValue("@PersonCode ", PersonCode);
                    cmd.Parameters.AddWithValue("@OutstandingBalance ", OutstandingBalance);

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

        public string EditAccount(int Code, string AccountNumber, int PersonCode, decimal OutstandingBalance)
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
                    CommandText = "stp_Accounts_Update"
                })
                {
                    cmd.Parameters.AddWithValue("@Code ", Code);
                    cmd.Parameters.AddWithValue("@AccountNumber", AccountNumber);
                    cmd.Parameters.AddWithValue("@PersonCode ", PersonCode);
                    cmd.Parameters.AddWithValue("@OutstandingBalance ", OutstandingBalance);
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
        public string DeleteTransactionAccount(int Code)
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
                    CommandText = "stp_TransactionsAccount_Delete"
                })
                {
                    cmd.Parameters.AddWithValue("@Code ", Code);
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
        public string DeleteAccount(int Code)
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
                    CommandText = "stp_Accounts_Delete"
                })
                {
                    cmd.Parameters.AddWithValue("@Code ", Code);
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

    }
}
