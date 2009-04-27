using System.Web.Mvc;
using System;

namespace Scratch.MVC.Binders {
    public class DateTimeModelBinder : DefaultModelBinder {
        
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            if (controllerContext == null) {
                throw new ArgumentNullException("Controller Context");
            }
            if (bindingContext == null) {
                throw new ArgumentNullException("Binding Context");
            }

            var Date = controllerContext.HttpContext.Request.Form["Date"];
            var Time = controllerContext.HttpContext.Request.Form["Time"];

            try {
                DateTime dateTime = DateTime.ParseExact(Date + " " + Time, "MM-dd-yyyy hh:mm:ss", null);
                return dateTime;
            } catch (Exception ex) {
                bindingContext.ModelState.AddModelError("DateTime", ex.Message);
                return null;
            }
        }

    }
}
