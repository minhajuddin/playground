using System.Web.Mvc;
using System.IO;
using System.Text.RegularExpressions;

namespace Scratch.MVC.ViewEngine {
    public class SimpleView : IView {

        private string _viewPhysicalPath;

        public SimpleView(string viewPhysicalPath) {
            _viewPhysicalPath = viewPhysicalPath;
        }

        public void Render(ViewContext viewContext, System.IO.TextWriter writer) {
            string rawContents = File.ReadAllText(_viewPhysicalPath);

            string parsedContents = ParseContents(rawContents, viewContext.ViewData);

            writer.Write(parsedContents);
        }

        private string ParseContents(string rawContents, ViewDataDictionary viewDataDictionary) {
            return Regex.Replace(rawContents, "\\{(.+)\\}", m => GetMatch(m, viewDataDictionary));
        }

        protected virtual string GetMatch(Match m, ViewDataDictionary viewDataDictionary) {
            if (m.Success) {
                string key = m.Result("$1");
                if (viewDataDictionary.ContainsKey(key)) {
                    return viewDataDictionary[key].ToString();
                }
            }
            return string.Empty;
        }
    }
}
