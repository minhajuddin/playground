using System;
using System.Web.UI.WebControls;
using System.Collections.Generic;

namespace Scratch {
    public partial class _Default : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            var list = new List<Emp> {
                new Emp {Name = "Jack"},
                new Emp {Name = "Jane"},
                new Emp {Name = "Jill"},
                new Emp {Name = "Joe"},
                new Emp {Name = "Jeff"}
            };
            grid.DataSource = list;
            grid.DataBind();

            bool temp = true;
            foreach (GridViewRow row in grid.Rows) {
                Literal literal = (Literal)row.FindControl("name");
                var currentItem = literal.Text;
                row.CssClass = currentItem == "Jack" ? "funky" : row.CssClass;
                temp = !temp;
            }
        }
    }

    public class Emp {
        public string Name { get; set; }
    }
}
