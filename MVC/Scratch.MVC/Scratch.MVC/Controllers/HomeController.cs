using System;
using System.Web.Mvc;
using Scratch.MVC.Models;

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
            //ModelState.AddModelError("_FORM", "This is some error");
            TempData["_ERROR"] = "Here is some error";
            return RedirectToAction("TestError");
        }

        public ActionResult TestError() {
            if (TempData.ContainsKey("_ERROR")) {
                ModelState.AddModelError("_FORM", TempData["_ERROR"].ToString());
            }
            return View();
        }

        //actions which use the SimpleViewEngine
        public ActionResult SV() {
            ViewData["message"] = "Hey there, We are using the Simple View Engine";
            return View();
        }

        //Unit testing actions  
        public ActionResult DayTime(int hour) {

            Time time = new Time { Hour = hour };
            if (hour <= 6 || hour >= 20) {
                return View("NightTimeView", time);
            }
            if (hour > 6 && hour < 20) {
                return View("DayTimeView", time);
            }
            return View("Index");
        }

        public ActionResult Redirect() {
            return RedirectToAction("Index");
        }
    }
}
