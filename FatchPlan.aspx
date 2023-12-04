<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FatchPlan.aspx.cs" Inherits="FatchPlan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblmsg" runat="server" Text=""></asp:Label>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                   <asp:DropDownList ID="DropDownList1" runat="server">
    <asp:ListItem>--Select --</asp:ListItem>
</asp:DropDownList>
                               <asp:DropDownList ID="DropDownList2" runat="server">
    <asp:ListItem>--Select --</asp:ListItem>
</asp:DropDownList>
     <%--       <asp:Label ID="lblmonth" runat="server" Text="Label"></asp:Label>--%>
           <%-- <asp:Label ID="lblyear" runat="server" Text="Label"></asp:Label>--%>
               <%--     <asp:DropDownList ID="ddlmonths" runat="server">
            <asp:ListItem>--Select Months--</asp:ListItem>
        </asp:DropDownList>
        <asp:DropDownList ID="ddlyear" runat="server">
            <asp:ListItem>--Select Year--</asp:ListItem>
        </asp:DropDownList>--%>
            
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
        </div>
    </form>
</body>
</html>
