<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Subsonic.Web.Models.Album>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

<link type="text/css" href="/scripts/ui-lightness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
<script type="text/javascript" src="/scripts/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/scripts/jquery-ui-1.7.1.min.js"></script>


<script type="text/javascript">
$(function() {
    $(".datepicker").datepicker();
});
</script>
   
    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="AlbumId">AlbumId:</label>
                <%=Html.ControlFor("Album", "AlbumId", "")%>
                <%= Html.ValidationMessage("AlbumId", "*") %>
            </p>
            <p>
                <label for="Title">Title:</label>
                <%=Html.ControlFor("Album", "Title", "")%>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="ArtistId">ArtistId:</label>
                <%=Html.ControlFor("Album", "ArtistId", "")%>
                <%= Html.ValidationMessage("ArtistId", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

