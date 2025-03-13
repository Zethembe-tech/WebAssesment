using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using AspireClient.Controllers.Cache;
using BusinessLogicDLL.BusinessRepo;
using CommonDLL.DTO;
using CommonDLL.Object;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebAssessment.Models;

namespace WebAssessment.Controllers
{
    //[Authorize]
    public class AccountsController : ClientControllerBase
    {
        readonly private AccountsLogic AccLogic = new AccountsLogic();


        #region Class Instantiation

        public AccountsController()
            : base(new CacheProvider())
        {

        }

        protected AccountsController(ICacheProvider cacheProvider)
            : base(cacheProvider)
        {

        }

        #endregion
        public ActionResult Index()
        {
            try
            {
                var accounts = AccLogic.ListAllAccounts();
                return View(accounts);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while retrieving accounts: " + e.Message;
                return View(new List<Accounts>());
            }
        }

        public ActionResult Details(int id)
        {
            try 
            {
                var accounts = AccLogic.GetAccountById(id);
                return View(accounts);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while retrievingd account details: " + e.Message;
                return View(new List<Accounts>());
            }
        }

        public ActionResult Create(Accounts acc)
        {
            try
            {
                var results = AccLogic.AddNewAccount(acc.AccountNumber,acc.PersonCode, acc.OutstandingBalance);
                return View(results);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while adding new accounts: " + e.Message;
                return View(new List<Accounts>());
            }
        }

        public ActionResult Edit(int id)
        {

            var account = AccLogic.GetAccountById(id);

            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Accounts acc)
        {
            try
            {
                var results = AccLogic.EditAccount(acc.Code, acc.AccountNumber, acc.PersonCode, acc.OutstandingBalance);
                return View(results);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while editing the account: " + e.Message;
                return View(new List<Accounts>());
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    throw new Exception("Invalid ID");
                }

                var transactionResult = AccLogic.DeleteTransactionAccount(id);

                if (transactionResult.Contains("DELETED"))
                {
                    var accountResult = AccLogic.DeleteAccount(id);
                    TempData["SuccessMessage"] = "Account deleted successfully.";
                    return RedirectToAction("Index"); 
                }

                TempData["ErrorMessage"] = "Failed to delete account.";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the account: " + e.Message;
                return RedirectToAction("Index");
            }
        }

    }
}
