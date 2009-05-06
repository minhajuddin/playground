using System.Web.Mvc;

namespace Scratch.MVC.ModelBinders {
    public class RecipeModelBinder : IModelBinder {

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext) {
            var form = controllerContext.HttpContext.Request.Form;
            var rName = form["rName"];
            var rContent = form["rContent"];

            var recipe = new Recipe { Name = rName, Content = rContent };
            return recipe;
        }
    }

    public class Recipe {
        public string Name { get; set; }
        public string Content { get; set; }
    }
}
