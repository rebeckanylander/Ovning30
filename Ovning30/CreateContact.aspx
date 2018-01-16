<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateContact.aspx.cs" Inherits="Ovning30.CreateContact" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 793px">
            <asp:Label runat="server">Name</asp:Label>
            <br />
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
            <br />
            <asp:Label runat="server">Phone number</asp:Label>
            <br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <asp:Label runat="server">SSN</asp:Label>
            <br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button runat="server" Text="Create contact" OnClick="Unnamed4_Click"/>
        </div>
    </form>
</body>
</html>
