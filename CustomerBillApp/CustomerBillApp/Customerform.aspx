<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customerform.aspx.cs" Inherits="CustomerBillApp.Customerform" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Name : <asp:TextBox ID="txtName" AutoPostBack="true" runat="server" OnTextChanged="txtName_TextChanged"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        Exixting Balance : <asp:TextBox ID="txtExbl" ReadOnly="true" runat="server"></asp:TextBox>  
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtExbl" ErrorMessage="RequiredFieldValidator"></asp:RequiredFieldValidator>
        <br />
        Activation Date : <asp:TextBox ID="txtaccdate" ReadOnly="true" runat="server"></asp:TextBox> <br />
        Recharge Amount : <asp:TextBox ID="txtRcrhamount" runat="server"></asp:TextBox><br />
        Commission : <asp:TextBox ID="txtcomission" ReadOnly="true" runat="server"></asp:TextBox><br />
        Total Balance : <asp:TextBox ID="txttotbl" ReadOnly="true" runat="server"></asp:TextBox><br />
        Recharge Date : <asp:TextBox ID="txtrcrgdate" runat="server" AutoPostBack="true" OnTextChanged="txtrcrgdate_TextChanged"></asp:TextBox><br />

        <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    </div>
    </form>
</body>
</html>
