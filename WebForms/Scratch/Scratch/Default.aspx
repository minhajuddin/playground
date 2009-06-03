<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Scratch._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <title></title>
  <style type="text/css">
    .red {
      color: #f00;
      background-color: #0f0;
    }
    .blue {
      color: #0f0;
      background-color: #f00;
    }
    .funky {
      color: #ff0;
      background-color: #f0f;
    }
  </style>
</head>
<body>
  <form id="form1" runat="server">
  <div>
    This is a test page
    <asp:GridView ID="grid" runat="server">
      <Columns>
        <asp:TemplateField>
          <ItemTemplate>
            <asp:Literal ID="name" runat="server" Text='<%# Eval("Name")%>' />
          </ItemTemplate>
        </asp:TemplateField>
      </Columns>
    </asp:GridView>
  </div>
  </form>
</body>
</html>
