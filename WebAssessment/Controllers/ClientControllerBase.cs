using WebAssessment.Controllers.Cache;
using BusinessLogicDLL;
using BusinessLogicDLL.BusinessRepo;
using CommonDLL.DTO;
using System;
using System.IO;
using System.Linq;
using System.Web.Mvc;


namespace WebAssessment.Controllers
{
    public class ClientControllerBase : Controller
    {
        #region Methods
        UsersLogic userlogic = new UsersLogic();

        protected ClientControllerBase(ICacheProvider cacheProvider)
        {

            Cache = cacheProvider;
        }

        protected ICacheProvider Cache { get; set; }

        public string GetUserName()
        {
            var username = System.Web.HttpContext.Current.User.Identity.Name;
            if (username == null)
            {
                throw new Exception("User name does not exist");
            }
            else
            {
                return username;
            }

        }

        public int GetUserIdIfLoggedIn() 
        {
            try
            {

                return GetUserDetailInfo().Id;

            }
            catch (Exception)
            {
                return 0;
            }
             

        }

        public Users GetUserDetailInfo()
        {

            if (Session["UserDetail"] != null)
            {
                return (Users)Session["UserDetail"];
            }
            else
            {
                var customer = userlogic.GetUserByUsername(GetUserName());
                Session["UserDetail"] = customer;
                return customer;
            }
                       

        }

        protected void CreateCookie(string userName, string CookieName)
        {
            System.Web.HttpCookie rememberMeUserNameCookie = Request.Cookies[CookieName];
            if (null == rememberMeUserNameCookie)
            {
                System.Web.HttpCookie rememberMeCookie = new System.Web.HttpCookie(CookieName, userName);
                rememberMeCookie.Expires = DateTime.Now.AddDays(30);
                Response.SetCookie(rememberMeCookie);
            }
        }

        protected void RemoveCookie(string CookieName)
        {
            System.Web.HttpCookie rememberMeUserNameCookie = Request.Cookies[CookieName];
            if (null != rememberMeUserNameCookie)
            {
                Response.Cookies.Remove(CookieName);
                rememberMeUserNameCookie.Expires = DateTime.Now.AddYears(-1);
                rememberMeUserNameCookie.Value = null;
                Response.SetCookie(rememberMeUserNameCookie);
            }
        }


        protected string CheckForCookie(string CookieName)
        {
            string returnValue = string.Empty;
            System.Web.HttpCookie rememberMeUserNameCookie = Request.Cookies.Get(CookieName);
            if (null != rememberMeUserNameCookie)
            {
                returnValue = rememberMeUserNameCookie.Value;
            }

            return returnValue;
        }
        #endregion
    }
}