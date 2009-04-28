using System.Web.Mvc;
namespace Scratch.MVC.ViewEngine {
    public class SimpleViewEngine : VirtualPathProviderViewEngine {


        public SimpleViewEngine() {
            ViewLocationFormats = new[] { "~/Views/{1}/{0}.simple", "~/Shared/{1}/{0}.simple" };
            PartialViewLocationFormats = new[] { "~/Views/{1}/{0}.simple", "~/Shared/{1}/{0}.simple" };
        }

        protected override IView CreatePartialView(ControllerContext controllerContext, string partialPath) {
            var physicalPath = controllerContext.HttpContext.Server.MapPath(partialPath);
            return new SimpleView(physicalPath);
        }

        protected override IView CreateView(ControllerContext controllerContext, string viewPath, string masterPath) {
            var physicalPath = controllerContext.HttpContext.Server.MapPath(viewPath);
            return new SimpleView(physicalPath);
        }
    }
}
