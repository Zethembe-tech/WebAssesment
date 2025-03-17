using CommonDLL.DTO;
using DatabaseDLL.DatabaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicDLL.BusinessRepo
{
    public class TransactionsLogic
    {
        readonly TransactionsRepo trans = new TransactionsRepo();

        public List<Transactions> ListAllTransactions()
        {
            return trans.ListAllTransactions();

        }

        public TransactionsViewModel GetTransactionsById(int Id)
        {
            return trans.GetTransactionsById(Id);

        }

        public string AddNewTransactions(int AccountCode, DateTime TransactionDate, DateTime CaptureDate, decimal Amount, string Description)
        {
            return trans.AddNewTransactions( AccountCode,  TransactionDate,  CaptureDate,  Amount,  Description);

        }

        public string EditTransactions(int code, int AccountCode, DateTime TransactionDate, DateTime CaptureDate, decimal Amount, string Description)
        {
            return trans.EditTransactions(code, AccountCode, TransactionDate, CaptureDate, Amount, Description);

        }

        public List<Transactions> ListCodeTransactions()
        {
            return trans.ListCodeTransactions();

        }
        public List<Transactions> ListTransactionsByCode(int code)
        {
            return trans.ListTransactionsByCode(code);

        }
        public string DeleteTransactions(int code)
        {
            return trans.DeleteTransactions(code);

        }

    }
}
