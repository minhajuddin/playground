using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Scratch.MVC.Controllers {
    [HandleError]
    public class HomeController : Controller {
        public ActionResult Index() {
            ViewData["Message"] = "Welcome to ASP.NET MVC!!";

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

        public ActionResult ReturnTestError() {
            ModelState.AddModelError("_FORM", "This is some error");
            return View("TestError");
        }

        public ActionResult RedirectToTestError() {
            ModelState.AddModelError("_FORM", "This is some error");
            return RedirectToAction("TestError");
        }

        public ActionResult TestError() {
            return View();
        }

        //actions which use the SimpleViewEngine
        public ActionResult SV() {
            ViewData["message"] = "Hey there, We are using the Simple View Engine";
            return View();
        }
    }
}
