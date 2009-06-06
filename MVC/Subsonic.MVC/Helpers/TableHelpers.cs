using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

    public static class TableHelpers {

        public static string CreateSortLink(this UrlHelper url, string action, string columnName) {

            string result = "";

            //read the current request to see if there's a sort value
            string currentDirection = url.RequestContext.HttpContext.Request.QueryString["dir"];
            string currentSort = url.RequestContext.HttpContext.Request.QueryString["s"];
            
            if (string.IsNullOrEmpty(currentDirection) &! string.IsNullOrEmpty(currentSort)) {
                result = url.Action(action, new { s = columnName, dir = "desc" });
            } else {
                result = url.Action(action, new { s = columnName});
            }
            return result;

        }

    }
