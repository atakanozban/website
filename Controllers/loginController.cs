using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using atakanozbancomtr.Models.classes;

namespace atakanozbancomtr.Controllers
{
    public class loginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(admin ad) 
        {
            var bilgiler = c.admins.FirstOrDefault(x => x.username == ad.username && x.password == ad.password);
            if (bilgiler != null) 
            {
                FormsAuthentication.SetAuthCookie(bilgiler.username, false);
                Session["username"] = bilgiler.username.ToString();
                return RedirectToAction("Index", "admin");
            }
            else
            {
                return View();
            }
        }

        public ActionResult logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("index", "login");
        }
    }
}