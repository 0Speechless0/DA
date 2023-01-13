using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DA.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LogOut()
        {
            HttpContext.Session.RemoveAll();
            return Redirect(ConfigurationManager.AppSettings["web_demo_url"]+"/logout.php");
        }
    }
}