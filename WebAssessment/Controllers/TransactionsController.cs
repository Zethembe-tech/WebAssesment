using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessLogicDLL.BusinessRepo;
using CommonDLL.DTO;
using WebAssessment.Controllers.Cache;
using WebAssessment.Models;

namespace WebAssessment.Controllers
{
    public class TransactionsController : ClientControllerBase
    {
        readonly private TransactionsLogic transLogic = new TransactionsLogic();
        readonly private PersonsLogic perLogic = new PersonsLogic();


        #region Class Instantiation

        public TransactionsController()
            : base(new CacheProvider())
        {

        }

        protected TransactionsController(ICacheProvider cacheProvider)
            : base(cacheProvider)
        {

        }

        #endregion

        public ActionResult Index()
        {
            try
            {
                var transactions = transLogic.ListAllTransactions();

                return View(transactions);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while retrieving transactions: " + e.Message;
                return View(new TransactionsViewModel());
            }
        }



        public ActionResult Details(int id)
        {
            try
            {
                var transactions = transLogic.GetTransactionsById(id);
                return View(transactions);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while retrievingd transactions details: " + e.Message;
                return View(new TransactionsViewModel());
            }
        }

        public ActionResult Create()
        {
            var viewModel = new TransactionsViewModel
            {
                AccountList = transLogic.ListCodeTransactions().Select(a => new SelectListItem { Value = a.Code.ToString(), Text = a.Account.AccountNumber }).ToList()
            };

            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Transactions transactions)
        {
            try
            {
                if (transactions.CaptureDate > DateTime.Today || transactions.TransactionDate > DateTime.Today)
                {
                    throw new Exception("Date cannot be in the future");
                }

                if (transactions.Amount == 0 )
                {
                    throw new Exception("Transactions amount cannot be zero");
                }
                var results = transLogic.AddNewTransactions( transactions.AccountCode, transactions.TransactionDate, transactions.CaptureDate, transactions.Amount,  transactions.Description );

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while adding new transactions: " + e.Message;
                return View(new TransactionsViewModel());
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            var transaction = transLogic.GetTransactionsById(id); 

            if (transaction == null)
            {
                return HttpNotFound();
            }

            var viewModel = new TransactionsViewModel
            {
                Code = transaction.Code,
                AccountCode = transaction.AccountCode, 
                TransactionDate = transaction.TransactionDate,
                CaptureDate = transaction.CaptureDate,
                Amount = transaction.Amount,
                Description = transaction.Description,

                AccountList = transLogic.ListTransactionsByCode(transaction.Code)
                    .Where(a => a.Account != null)
                    .Select(a => new SelectListItem
                    {
                        Value = a.Code.ToString(),
                        Text = a.Account.AccountNumber ?? "N/A",
                        Selected = a.Code == transaction.AccountCode 
            })
                    .ToList()
            };

            return View(viewModel);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransactionsViewModel transactions)
        {
            try
            {
                transactions.CaptureDate = DateTime.Now;

                var results = transLogic.EditTransactions(transactions.Code, transactions.AccountCode, transactions.TransactionDate, transactions.CaptureDate, transactions.Amount, transactions.Description);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while editing the transactions: " + e.Message;
                return View(new TransactionsViewModel());
            }
        }



    }
}
