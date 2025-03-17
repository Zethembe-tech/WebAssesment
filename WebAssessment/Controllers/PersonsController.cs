using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAssessment.Controllers.Cache;
using BusinessLogicDLL.BusinessRepo;
using CommonDLL.DTO;
using WebAssessment.Models;

namespace WebAssessment.Controllers
{
    public class PersonsController : ClientControllerBase
    {
        readonly private PersonsLogic PersonLogic = new PersonsLogic();
        readonly private AccountsLogic accLogic = new AccountsLogic();
        readonly private TransactionsLogic transLogic = new TransactionsLogic();


        #region Class Instantiation

        public PersonsController()
            : base(new CacheProvider())
        {

        }

        protected PersonsController(ICacheProvider cacheProvider)
            : base(cacheProvider)
        {

        }

        #endregion

        public ActionResult Index(string searchTerm, string searchAccountNumber, string searchIdNumber)
        {
            try
            {
                var persons = PersonLogic.ListAllPersons();

                if (!string.IsNullOrEmpty(searchTerm) || !string.IsNullOrEmpty(searchAccountNumber) || !string.IsNullOrEmpty(searchIdNumber))
                {
                    persons = persons.Where(a =>
                        (!string.IsNullOrEmpty(searchTerm) && a.Surname.Contains(searchTerm)) ||
                        (!string.IsNullOrEmpty(searchAccountNumber) && a.Accounts.Any(acc => acc.AccountNumber.Contains(searchAccountNumber))) ||
                        (!string.IsNullOrEmpty(searchIdNumber) && a.IdNumber.Contains(searchIdNumber))
                    ).ToList();
                }

                ViewBag.SearchTerm = searchTerm;
                ViewBag.SearchAccountNumber = searchAccountNumber;
                ViewBag.SearchIdNumber = searchIdNumber;

                return View(persons);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while retrieving accounts: " + e.Message;
                return View(new List<Persons>());
            }
        }



        public ActionResult Details(int id)
        {
            try
            {
                var accounts = PersonLogic.GetPersonsById(id);
                return View(accounts);
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while retrievingd account details: " + e.Message;
                return View(new List<Persons>());
            }
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persons acc)
        {
            try
            {
                var results = PersonLogic.AddNewPersons(acc.Name, acc.Surname, acc.IdNumber);
                return RedirectToAction("Index");

            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while adding new Persons: " + e.Message;
                return View(new List<Persons>());
            }
        }

        public ActionResult Edit(int id)
        {

            var account = PersonLogic.GetPersonsById(id);

            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persons ppl)
        {
            try
            {
                var results = PersonLogic.EditPersons(ppl.Code, ppl.Name, ppl.Surname, ppl.IdNumber);
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ViewData["EditError"] = "An error occurred while editing the account: " + e.Message;
                return View(new List<Persons>());
            }
        }
        [HttpGet]
        public ActionResult Delete()
        {
            return View(); 
        }

        [HttpPost]

        public ActionResult Delete(int id)
        {
            try
            {
                var result = accLogic.GetAccountById(id);  

                if (result == null)
                {
                    TempData["ErrorMessage"] = "Account or associated person not found.";
                    return RedirectToAction("Index");
                }

                var person = result.Person;

                if (person != null)
                {
                    bool allAccountsClosed = person.Accounts == null || person.Accounts.All(a => a.Status == "Closed");

                    if (allAccountsClosed)
                    {
                        transLogic.DeleteTransactions(id);  
                        accLogic.DeleteAccount(id);           

                        var deleteResult = PersonLogic.DeletePerson(person.Code);  

                        if (deleteResult.Contains("DELETED"))
                        {
                            TempData["SuccessMessage"] = "Person and associated account deleted successfully.";
                        }
                        else
                        {
                            TempData["ErrorMessage"] = "Failed to delete the person.";
                        }
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "Cannot delete the person. They still have active accounts.";
                    }
                }
                else
                {
                    TempData["ErrorMessage"] = "Person not found for this account.";
                }

                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                // Log the exception (optional)
                // Logger.LogError(e);

                // Display a user-friendly error message
                TempData["ErrorMessage"] = "An error occurred while deleting the account: " + e.Message;
                return RedirectToAction("Index");
            }
        }




    }
}
