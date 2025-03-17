using CommonDLL.DTO;
using DatabaseDLL.DatabaseRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicDLL.BusinessRepo
{
    public class AccountsLogic
    {
        readonly AccountsRepo acc = new AccountsRepo();

        public List<Accounts> ListAllAccounts()
        {
            return acc.ListAllAccounts();

        }

        public Accounts GetAccountById(int Id)
        {
            return acc.GetAccountById(Id);

        }

        public string AddNewAccount(string AccountNumber, int PersonCode, decimal OutstandingBalance)
        {
            return acc.AddNewAccount(AccountNumber, PersonCode, OutstandingBalance);

        }

        public string EditAccount(int Code, string AccountNumber, int PersonCode, decimal OutstandingBalance)
        {
            return acc.EditAccount(Code, AccountNumber, PersonCode, OutstandingBalance);

        }

        public string DeleteAccount(int Code)
        {
            return acc.DeleteAccount(Code);

        }
        public string DeleteTransactionAccount(int Code)
        {
            return acc.DeleteAccount(Code);

        }
        public string UpdateStatus(int Code, string Status)
        {
            return acc.UpdateStatus(Code, Status);

        }
        public string CheckStatus(int Code)
        {
            return acc.CheckStatus(Code);

        }
    }
}
