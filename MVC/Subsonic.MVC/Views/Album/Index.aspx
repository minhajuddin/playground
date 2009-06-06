<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<PagedList<Subsonic.Web.Models.Album>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

<script type="text/javascript" src="/scripts/jquery-1.3.2.min.js"></script>
<script type="text/javascript" src="/scripts/jquery.autocomplete.js"></script>
<link rel=Stylesheet href="/scripts/jquery.autocomplete.css" />
<script type="text/javascript">
    $(document).ready(function() {
    $('#search').autocomplete("/Album/list/", {
            minChars: 2
        });

    }); 
    
    function submitPager() {
        $('#pagerForm').submit();
    }

    
</script>
<form action="<%=Url.Action("index") %>" method="post">
    <input type="text" size="40" id="search" name="q" /><input type="submit" value="go" />
</form>
    <table>
        <tr>
            <th></th>
            <th>
                <a href="<%=Url.CreateSortLink("Index","AlbumId") %>"> AlbumId</a>
            </th>
            <th>
                <a href="<%=Url.CreateSortLink("Index","Title") %>"> Title</a>
            </th>
            <th>
                <a href="<%=Url.CreateSortLink("Index","ArtistId") %>"> ArtistId</a>
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td style="width:70px">
                <span style="padding:8px">
                    <a href="<%=Url.Action("Details", new { id = item.KeyValue() })%>"><img src="/content/images/magnifier.png" border="0"/></a>
                </span>
                <span style="padding:8px">
                    <a href="<%=Url.Action("Edit",  new {  id=item.KeyValue()  })%>"><img src="/content/images/pencil_go.png" border="0"/></a>  
                </span>          
            </td>
            <td>
                <%= Html.Encode(item.AlbumId) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.ArtistId) %>
            </td>
        </tr>
    
    <% } %>

        <tr>
            <td colspan="3" class="pager">
                <%
                int currentPage = Model.PageIndex;
                int totalPages=Model.TotalPages;
                %>
                <form action="<%=Url.Action("index") %>" method="post" id="pagerForm">
                    
                    <input type="hidden" name="pg" value="<%=currentPage %>" />
                    <%if (currentPage == 1) { %>
                    <img src="/content/images/control_start.png" style="cursor:hand" />
                    <img src="/content/images/control_rewind.png" style="cursor:hand"/>
                    <%} else { %>
                    <img src="/content/images/control_start_blue.png" style="cursor:hand" onclick="pg.value='1';submitPager();"/>
                    <img src="/content/images/control_rewind_blue.png" style="cursor:hand" onclick="pg.value='<%=currentPage-1%>';submitPager();""/>
                    <%} %>
                    
                    <select onchange="pg.value=this.options[this.selectedIndex].value;submitPager();"" name="ddpager">
                        <%for (int i = 1; i <= totalPages; i++) { %>
                            <option <%if(currentPage==i){ %>selected="true"<%}%> value="<%=i%>"><%=i%></option>
                        <%} %>
                    </select>

                    <%if (currentPage == totalPages) { %>
                    <img src="/content/images/control_fastforward.png" style="cursor:hand" />
                    <img src="/content/images/control_end.png" style="cursor:hand" />
                    <%} else { %>
                    <img src="/content/images/control_fastforward_blue.png" style="cursor:hand" onclick="pg.value='<%=currentPage+1%>';submitPager();""/>
                    <img src="/content/images/control_end_blue.png" style="cursor:hand" onclick="pg.value='<%=totalPages%>';submitPager();""/>
                    <%} %>
               </form>          
            </td>
        </tr>



    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

