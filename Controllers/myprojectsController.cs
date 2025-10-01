using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using atakanozbancomtr.Models.classes;

namespace atakanozbancomtr.Controllers
{
    public class myprojectsController : Controller
    {
        // GET: myprojects
        Context c = new Context();
        public ActionResult Index()
        {
            var value = c.MyProjects.ToList();
            return View(value);
        }

        public PartialViewResult projectposts()
        {
            var value = c.MyProjects.ToList();
            return PartialView(value);
        }
    }
}