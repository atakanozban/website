using System.Linq;
using System.Web.Mvc;
using atakanozbancomtr.Models.classes;

namespace atakanozbancomtr.Controllers
{
    public class adminController : Controller
    {
        // GET: admin
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var value = c.MyProjects.ToList();
            return View(value);
        }

        public ActionResult myprojectsget(int id)
        {
            var mg = c.MyProjects.Find(id); // mg = myprojectsget
            return View("myprojectsget", mg);
        }

        public ActionResult myprojectsupdate(myprojects x)
        {
            var ag = c.MyProjects.Find(x.id);
            ag.description = x.description;
            ag.title = x.title;
            ag.image = x.image;
            ag.iframe = x.iframe;
            c.SaveChanges();
            return RedirectToAction("index");
        }

        [HttpGet]
        public ActionResult newmppost() // newmppost = New My Projects Post
        {
            return View();
        }
        [HttpPost]
        public ActionResult newmppost(myprojects p)
        {
            c.MyProjects.Add(p);
            c.SaveChanges();
            return RedirectToAction("index");
        }

        public ActionResult myprojectsdelete(int id)
        {
            var mpd = c.MyProjects.Find(id); // mpd = my projects delete
            c.MyProjects.Remove(mpd);
            c.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
