<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Log On
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
 	<!-- Simple OpenID Selector -->
	<link rel="stylesheet" href="/content/openid.css" />
	<script type="text/javascript" src="/scripts/jquery-1.3.2.min.js"></script>
	<script type="text/javascript" src="/scripts/openid-jquery.js"></script>
	<script type="text/javascript">
	$(document).ready(function() {
	    openid.init('openid_identifier');
	});
	</script>
	<!-- /Simple OpenID Selector -->
	
	<style type="text/css">
		/* Basic page formatting. */
		body {
			font-family:"Helvetica Neue", Helvetica, Arial, sans-serif;
		}
	</style>
 
 
 
    <h2>Log On</h2>
    <p>
    <!-- Simple OpenID Selector -->
    <form action="<%=Url.Action("OpenIdLogin","Account") %>" method="get" id="openid_form">
	    <input type="hidden" name="action" value="verify" />

	    <fieldset style="width:500px">
    		    <legend>Sign-in or Create New Account</legend>
        		
    		    <div id="openid_choice">
	    		    <p>Please click your account provider:</p>
	    		    <div id="openid_btns"></div>
			    </div>
    			
			    <div id="openid_input_area">
				    <input id="openid_identifier" name="openid_identifier" type="text" value="http://" />
				    <input id="openid_submit" type="submit" value="Sign-In"/>
			    </div>
			    <noscript>
			    <p>OpenID is service that allows you to log-on to many different websites using a single indentity.
			    Find out <a href="http://openid.net/what/">more about OpenID</a> and <a href="http://openid.net/get/">how to get an OpenID enabled account</a>.</p>
			    </noscript>
	    </fieldset>
    </form>
    
    
    </p>
    <p>
        Please enter your username and password. <%= Html.ActionLink("Register", "Register") %> if you don't have an account.
    </p>
    <%= Html.ValidationSummary("Login was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) { %>
        <div>
            <fieldset>
                <legend>Account Information</legend>
                <p>
                    <label for="username">Username:</label>
                    <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username") %>
                </p>
                <p>
                    <label for="password">Password:</label>
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Remember me?</label>
                </p>
                <p>
                    <input type="submit" value="Log On" />
                </p>
            </fieldset>
        </div>
    <% } %>
</asp:Content>
