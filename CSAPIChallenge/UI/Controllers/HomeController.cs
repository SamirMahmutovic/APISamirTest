using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers {
    public class HomeController : Controller 
    {
        ISiteRepository repository = new SQLSiteRepository();

        protected override void Dispose(bool disposing)
        {
            repository?.Dispose();
            base.Dispose(disposing);
        }

        // GET: CSUser
        [OverrideAuthorization()]

        public ActionResult Index() 
        {
            ViewBag.Message = "All Users";
            var csusers = repository.GetAllCSUsers();
            return View(csusers);
        }

        public ActionResult About() 
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact() 
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}