using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Caching;
using System.Web.Mvc;
using WebAssessment.Controllers.Cache;
using BusinessLogicDLL.BusinessRepo;
using CommonDLL.DTO;
using CommonDLL.Object;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using WebAssessment.Models;
using AccountViewModel = CommonDLL.DTO.AccountViewModel;

namespace WebAssessment.Controllers
{
    public class AccountsController : ClientControllerBase
    {
        readonly private AccountsLogic AccLogic = new AccountsLogic();
        readonly private PersonsLogic perLogic = new PersonsLogic();


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

        public ActionResult Index(string searchTerm, string searchAccountNumber, string searchIdNumber)
        {
            try
            {
                var accounts = AccLogic.ListAllAccounts();

                if (!string.IsNullOrEmpty(searchTerm) || !string.IsNullOrEmpty(searchAccountNumber) || !string.IsNullOrEmpty(searchIdNumber))
                {
                    accounts = accounts.Where(a =>
                        (!string.IsNullOrEmpty(searchTerm) && a.Person.Name.Contains(searchTerm)) ||
                        (!string.IsNullOrEmpty(searchAccountNumber) && a.AccountNumber.Contains(searchAccountNumber)) ||
                        (!string.IsNullOrEmpty(searchIdNumber) && a.Person.IdNumber.Contains(searchIdNumber))
                    ).ToList();
                }

                ViewBag.SearchTerm = searchTerm;
                ViewBag.SearchAccountNumber = searchAccountNumber;
                ViewBag.SearchIdNumber = searchIdNumber;

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
                Cache.CacheObject(new CacheObject { Key = "cacheOutstandingBalance", Value = accounts.OutstandingBalance.ToString() });
                return View(accounts);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while retrievingd account details: " + e.Message;
                return View(new List<Accounts>());
            }
        }

        public ActionResult Create()
        {
            var personList = perLogic.ListAllPersonNames();

            var viewModel = new CommonDLL.DTO.AccountViewModel
            {
                PersonList = new SelectList(personList, "Code", "Name")
            };

            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Accounts acc)
        {
            try
            {
                var results = AccLogic.AddNewAccount(acc.AccountNumber, acc.PersonCode, acc.OutstandingBalance);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while adding new accounts: " + e.Message;
                return View(new List<Accounts>());
            }
        }
        public ActionResult Edit(int id)
        {
            var model = new AccountViewModel();
            var account = AccLogic.GetAccountById(id);
            if (account == null)
            {
                TempData["ErrorMessage"] = "Account not found.";
                return RedirectToAction("Index");
            }
            var AccountNumberList = AccLogic.ListAllAccounts();

            if (!AccountNumberList.Any(a => a.AccountNumber == account.AccountNumber))
            {
                TempData["ErrorMessage"] = "Account number is not valid.";
                return RedirectToAction("Index");
            }

            string balance = Cache.GetObjectByKey("cacheOutstandingBalance").Value;
            decimal outstandingBalance = Decimal.TryParse(balance, out decimal result) ? result : 0;

            var personList = perLogic.GetPersonDetails(id);

            var viewModel = new AccountViewModel
            {
                Code = account.Code,
                PersonCode = account.PersonCode,
                AccountNumber = account.AccountNumber,  
                OutstandingBalance = outstandingBalance,
                PersonList = new SelectList(personList, "Code", "Name", account.PersonCode),
                AccountList = new SelectList(AccountNumberList, "AccountNumber", "AccountNumber", account.AccountNumber)
            };

            return View(viewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AccountViewModel acc)
        {
            try
            {
                var results = AccLogic.EditAccount(acc.Code, acc.AccountNumber, acc.PersonCode, acc.OutstandingBalance);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while editing the account: " + e.Message;
                return View(new List<Accounts>());
            }
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = AccLogic.DeleteAccount(id);
                if (result == "Closed")
                {
                    TempData["Message"] = "Account already closed.";
                }
         
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                TempData["ErrorMessage"] = "An error occurred while deleting the account: " + e.Message;
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        public ActionResult Close(int id)
        {
            try
            {
                var result = AccLogic.CheckStatus(id);
                if (result == "Closed")
                {
                    TempData["Message"] = "Account already closed.";
                    TempData.Keep("Message"); 
                    return RedirectToAction("Index");
                }
                else
                {
                    string status = "Closed";
                    var results = AccLogic.UpdateStatus(id, status);
                    TempData["Message"] = "Account closed successfully.";
                    TempData.Keep("Message"); 

                }

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
