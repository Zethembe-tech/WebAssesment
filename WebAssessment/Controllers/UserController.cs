#region Using Declare

using BusinessLogicDLL;
using CommonDLL.DTO;
using CommonDLL.Helper;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Security;
using CommonDLL.Object;
using WebAssessment.Controllers.Cache;
using BusinessLogicDLL.BusinessRepo;
using System.Web;
using System.Diagnostics;
#endregion

namespace WebAssessment.Controllers
{
    public class UserController : ClientControllerBase
    {
        readonly private LoginLogic logLogic = new LoginLogic();
        private const string RememberMeCookieName = "WebRememberMe";

        public UserController(ICacheProvider cacheProvider)
    : base(cacheProvider)
        {

        }

        public UserController()
            :
            base(new CacheProvider())
        {

        }

        public ActionResult Index()
        {

            return View();

        }

        public ActionResult PasswordEncrypt()
        {

            return View("_PasswordEncrypt");

        }

        public ActionResult LoggedInUser()
        {

            return PartialView("_LoggedInUser", GetUserDetailInfo());

        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl; 
            return View();
        }
        private ActionResult AuthorizeUser(string username)
        {

            return RedirectToAction("Index", "Home");

        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginDTO model, string returnUrl)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var loginModel = logLogic.UserLogin(model.Username, CryptoHelper.Encrypt(model.Password));
                    if (loginModel == null)
                    {
                        ModelState.AddModelError("InvalidLogin", "Email or password is incorrect");
                        return View(model); 
                    }

                    if (model.RememberMe)
                    {
                        CreateCookie(model.Username, RememberMeCookieName);
                    }
                    else
                    {
                        RemoveCookie(RememberMeCookieName);
                    }

                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    if (Url.IsLocalUrl(returnUrl) && !string.IsNullOrEmpty(returnUrl))
                    {
                        AuthorizeUser(model.Username);
                    }
                    else
                    {
                        AuthorizeUser(model.Username);
                    }
                }

                return View(model);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("ServerError", ex.Message);
                return View(model);  
            }
        }




        public ActionResult ForgotPassword()
        {
            return View("_ForgotPassword");
        }
        public ActionResult Register()
        {
            return View("Register");
        }
    }
}