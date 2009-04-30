using MbUnit.Framework;
using Scratch.MVC.Controllers;
using System.Web.Mvc;
using Scratch.MVC.Models;

namespace Scratch.Tests {
    [TestFixture]
    public class HomeControllerTests {
        [Test]
        public void IndexReturnsAViewResult() {
            var homeController = new HomeController();
            ViewResult result = homeController.Index() as ViewResult;
            ViewDataDictionary data = result.ViewData;
            Assert.IsNotNull(result);
            Assert.AreEqual("Welcome to ASP.NET MVC!!", data["Message"]);
        }

        [Test]
        [Row(15)]
        public void DayTimeViewRendersDayTimeViewWhenTimeHourIsBetween6And20(int hour) {
            var homeController = new HomeController();
            var result = homeController.DayTime(hour) as ViewResult;
            var time = result.ViewData.Model as Time;
            Assert.AreEqual("DayTimeView", result.ViewName);
            Assert.AreEqual(hour, time.Hour);
        }

        [Test]
        [Row(6)]
        [Row(1)]
        [Row(21)]
        [Row(20)]
        public void DayTimeViewRendersNightTimeViewWhenTimeHourIsNotBetween6AND20(int hour) {
            var homeController = new HomeController();
            var result = homeController.DayTime(hour) as ViewResult;
            var time = result.ViewData.Model as Time;
            Assert.AreEqual("NightTimeView", result.ViewName);
            Assert.AreEqual(hour, time.Hour);
        }

        [Test]
        public void RedirectActionRedirectsToTheIndexPage() {
            var homeController = new HomeController();
            var result = homeController.Redirect() as RedirectResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("/Home/Index", result.Url);
        }
    }
}