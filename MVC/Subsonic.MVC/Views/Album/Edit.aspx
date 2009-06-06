<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Subsonic.Web.Models.Album>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

 
<link type="text/css" href="/scripts/ui-lightness/jquery-ui-1.7.1.custom.css" rel="stylesheet" />
<script type="text/javascript" src="/scripts/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/scripts/jquery-ui-1.7.1.min.js"></script>
<script type="text/javascript" src="/scripts/jquery.form.js"></script>


<script type="text/javascript">
    $(function() {
        
        //UI wiring
        $(".datepicker").datepicker();
        $('#editForm').ajaxForm({
            success:showResponse
        });
        
        //click events
        $('#btnSave').click( function(){
            $('#editForm').submit();
        });
        $('#btnDelete').click( function() {
            if(confirm("Are you sure you want to delete <%=Model.DescriptorValue() %>? This cannot be undone...")){
                $.post("<%=Url.Action("delete")%>",
                    { id: "<%=Model.KeyValue() %>" },
                    function(data){
                    showResponse(data);
                    $('#btnDelete').attr("disabled", true);
                    $('#btnSave').attr("disabled", true);
                });
            }
        });
        
        
        
    });

    function showResponse(responseText, statusText) {
        if (responseText.substring(5, 0) == "ERROR") {
            $('#error-message').append(responseText);
            $('#error').show("slide",{direction:"up"}, 500 );
            $('#error').effect("highlight");
        } else {
            $('#info-message').append(responseText);
            $('#info').show("slide", { direction: "up" }, 500);
            $('#info').effect("highlight");
        }
    }
</script>
 
   
	<div class="ui-widget" style="display:none" id="info"> 
	    <div class="ui-state-highlight ui-corner-all" style="margin-top: 20px; padding: 0 .7em;"> 
		    <p id="info-message"><span class="ui-icon ui-icon-info" style="float: left; margin-right: .3em;"></span> 
			    
		    </p> 
	    </div> 
    </div>
	<div class="ui-widget"  style="display:none" id="error"> 
		<div class="ui-state-error ui-corner-all" style="padding: 0 .7em;"> 
			<p id="error-message"><span class="ui-icon ui-icon-alert" style="float: left; margin-right: .3em;"></span> 
			</p> 
		</div> 
	</div>
    <form action="<%=Url.Action("Edit") %>" method="post" id="editForm">

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="AlbumId">AlbumId:</label>
                <%=Html.ControlFor("Album", "AlbumId", Model.AlbumId)%>
                <%= Html.ValidationMessage("AlbumId", "*") %>
            </p>
            <p>
                <label for="Title">Title:</label>
                <%=Html.ControlFor("Album", "Title", Model.Title)%>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="ArtistId">ArtistId:</label>
                <%=Html.ControlFor("Album", "ArtistId", Model.ArtistId)%>
                <%= Html.ValidationMessage("ArtistId", "*") %>
            </p>
        </fieldset>

    </form>
    <p>
        <input type="button" value="Save" id="btnSave"/>
        <input type="button" value="Delete" id="btnDelete"/>
    </p>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

