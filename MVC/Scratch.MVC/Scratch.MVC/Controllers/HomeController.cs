using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scratch.MVC.Controllers {
    [HandleError]
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewData["Message"] = "Welcome to ASP.NET MVC!";

            return View();
        }

        public ActionResult About() {
            return View();
        }

        public ActionResult SelectDate() {
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult SelectDate(DateTime? ipDate) {
            ViewData["IpDate"] = ipDate;
            return View();
        }
    }
}
