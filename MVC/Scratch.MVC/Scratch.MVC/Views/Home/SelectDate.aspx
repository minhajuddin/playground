<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  SelectDate -- Model Binder Test
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <%using (Html.BeginForm()) %>
  <%{%>
  Date:<input name="Date" type="text" /><br />
  Time:<input name="Time" type="text" /><br />
  <%=Html.ValidationMessage("DateTime") %>
  <%if (ViewData["IpDate"] != null) { %>
  You entered
  <%=((DateTime)ViewData["IpDate"]).ToString()%>
  <%} %>
  <input type='submit' value="Submit" />
  <%} %>
</asp:Content>
