using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SubSonic;
using SubSonic.Schema;
using System.Data;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using SubSonic.Query;
using Subsonic.Web.Models;

public static class HtmlExtensions {

    public static string ControlFor(this HtmlHelper helper, string table, string column,object value){

        string result = "";

        //look the table up
        DB db = DB.CreateDB();
        
        ITable tbl = db.FindTableByClassName(table);
        
        if (tbl != null) {
            IColumn col = tbl.GetColumn(column);
            
            if (col != null) {
                //yay - let's work some magic
                if (col.IsPrimaryKey) {
                    //label
                    result = string.Format("<input type=hidden name='{0}' value='{1}' />{1}", column, value.ToString());
                } else if (col.IsForeignKey) {
                    //dropdown
                    //HACK: Work the Controller T4 file to be data aware or create a list of custom controls
                    //TODO: I'm fully aware of the mess this is :) and I need to fix it
                    var fk = db.FindByPrimaryKey(col.Name);
                    List<SelectListItem> items = new List<SelectListItem>();
                    if (fk != null) {
                        using (var rdr = db.SelectColumns(fk.PrimaryKey.Name,fk.Descriptor.Name).From(fk.Name).OrderAsc(fk.Descriptor.Name).ExecuteReader()) {
                            while (rdr.Read()) {
                                var item = new SelectListItem();
                                item.Text = rdr[fk.Descriptor.Name].ToString();
                                item.Value = rdr[fk.PrimaryKey.Name].ToString();
                                
                                item.Selected = item.Value.Equals(value.ToString(), StringComparison.InvariantCultureIgnoreCase);
                                items.Add(item);
                            }
                        }
                        
                    }

                    result = helper.DropDownList(column, items);
                } else if (col.IsNumeric) {
                    //max-length enabled textbox
                    result = helper.TextBox(column, value, new { maxlength = col.MaxLength, size=col.MaxLength });
                } else if (col.IsDateTime) {
                    //jquery date
                    result = helper.TextBox(column, value, new { @class = "datepicker" });
                } else if (col.IsReadOnly) {
                    //disabled textbox
                    result = helper.TextBox(column, value, new { disabled = "disabled" });
                } else if (col.DataType == DbType.Boolean) {
                    //checkbox
                    bool isChecked = false;
                    bool.TryParse(value.ToString(), out isChecked);
                    result = helper.CheckBox(column, isChecked);
                } else if (col.MaxLength > 500) {
                    result = helper.TextArea(column, value.ToString(), new { style = "width:100%;height:50px" });

                } else {
                    result = helper.TextBox(column, value, new { size = col.MaxLength == 0 ? 40 : col.MaxLength });
                }
            }
            

        }

        return result;
    }

}
