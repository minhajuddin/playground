<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
  TestError
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <h2>
    TestError</h2>
  <div style="border: solid 1px #f00; background-color: #8ff; color: #f00; font-weight: bold;padding:10px;">
    <%=Html.ValidationMessage("_FORM") %>
  </div>
</asp:Content>
