using CommonDLL.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseDLL.DatabaseRepo
{
    public class TransactionsRepo
    {
        public List<Transactions> ListAllTransactions()
        {
            var returnList = new List<Transactions>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Transactions_ListAll"
                })
                {
                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            returnList.Add(new Transactions
                            {
                                Code = rdr.GetInt32(0),
                                AccountCode = rdr.GetInt32(1),
                                TransactionDate = rdr.IsDBNull(2) ? DateTime.MinValue : rdr.GetDateTime(2),
                                CaptureDate = rdr.IsDBNull(3) ? DateTime.MinValue : rdr.GetDateTime(3),
                                Amount = rdr.IsDBNull(4) ? 0 : rdr.GetDecimal(4),
                                Description = rdr.IsDBNull(5) ? "" : rdr.GetString(5),

                                Account = new Accounts
                                {
                                    AccountNumber = rdr.IsDBNull(6) ? "" : rdr.GetString(6)
                                }
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


        public TransactionsViewModel GetTransactionsById(int Id)
        {
            var model = new TransactionsViewModel();
            using (
               var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString)
               )
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Transactions_GetDetailsById"
                })
                {
                    cmd.Parameters.AddWithValue("@Code", Id);
                    using (var rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            model.Code = rdr.GetInt32(0);
                            model.Account = new Accounts();

                            model.Account.AccountNumber = rdr.IsDBNull(1) ? "" : rdr.GetString(1);
                            model.TransactionDate = rdr.IsDBNull(2) ? DateTime.MinValue : rdr.GetDateTime(2);
                            model.CaptureDate = rdr.IsDBNull(3) ? DateTime.MinValue : rdr.GetDateTime(3);
                            model.Amount = rdr.IsDBNull(4) ? 0 : rdr.GetDecimal(4);
                            model.Description = rdr.IsDBNull(5) ? "" : rdr.GetString(5);
                        }

                        rdr.Close();
                    }
                }
                conn.Close();
                conn.Dispose();
            }
            return model;
        }

        public string AddNewTransactions(int AccountCode, DateTime TransactionDate, DateTime CaptureDate, decimal Amount, string Description)
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
                    CommandText = "stp_Transactions_Add"
                })
                {
                    cmd.Parameters.AddWithValue("@AccountCode", AccountCode);
                    cmd.Parameters.AddWithValue("@TransactionDate ", TransactionDate);
                    cmd.Parameters.AddWithValue("@CaptureDate ", CaptureDate);
                    cmd.Parameters.AddWithValue("@Amount ", Amount);
                    cmd.Parameters.AddWithValue("@Description ", Description);


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

        public string EditTransactions(int code, int AccountCode, DateTime TransactionDate, DateTime CaptureDate, decimal Amount, string Description)
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
                    CommandText = "stp_Transactions_Update"
                })
                {
                    cmd.Parameters.AddWithValue("@Code ", code);
                    cmd.Parameters.AddWithValue("@AccountCode", AccountCode);
                    cmd.Parameters.AddWithValue("@TransactionDate ", TransactionDate);
                    cmd.Parameters.AddWithValue("@CaptureDate ", CaptureDate);
                    cmd.Parameters.AddWithValue("@Amount ", Amount);
                    cmd.Parameters.AddWithValue("@Description ", Description);

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
 
        public List<Transactions> ListCodeTransactions( )
        {
            var returnList = new List<Transactions>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Transactions_ListAll"
                })
                {

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            returnList.Add(new Transactions
                            {
                                Code = rdr.GetInt32(0),
                                AccountCode = rdr.GetInt32(1),
                                TransactionDate = rdr.GetDateTime(2),
                                CaptureDate = rdr.GetDateTime(3),
                                Amount = rdr.GetDecimal(4),
                                Description = rdr.IsDBNull(5) ? "" : rdr.GetString(5),

                                Account = new Accounts
                                {
                                   AccountNumber = rdr.IsDBNull(6) ? "" : rdr.GetString(6)

                                }
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

        public List<Transactions> ListTransactionsByCode(int code)
        {
            var returnList = new List<Transactions>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
            {
                conn.Open();
                using (var cmd = new SqlCommand
                {
                    Connection = conn,
                    CommandType = CommandType.StoredProcedure,
                    CommandText = "stp_Transactions_ListAllByCode"
                })
                {
                    cmd.Parameters.AddWithValue("@Code ", code);

                    using (var rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            returnList.Add(new Transactions
                            {
                                Code = rdr.GetInt32(0),
                                AccountCode = rdr.GetInt32(1),
                                TransactionDate = rdr.GetDateTime(2),
                                CaptureDate = rdr.GetDateTime(3),
                                Amount = rdr.GetDecimal(4),
                                Description = rdr.IsDBNull(5) ? "" : rdr.GetString(5),

                                Account = new Accounts
                                {
                                    AccountNumber = rdr.IsDBNull(6) ? "" : rdr.GetString(6)

                                }
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

        public string DeleteTransactions(int code)
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
                    CommandText = "stp_Transactions_Delete"
                })
                {
                    cmd.Parameters.AddWithValue("@Code ", code);

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
