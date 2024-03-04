<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FanRegister.aspx.cs" Inherits="db_M3.FanRegister" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            Please fill the following cells:
            <br />
            Name: 
            <asp:TextBox ID="name" runat="server"></asp:TextBox>
            <br />
            Username:
             <asp:TextBox ID="username1" runat="server"></asp:TextBox>
            <br />
            Password:
             <asp:TextBox ID="password1" runat="server"></asp:TextBox>
            <br />
            National Id:
             <asp:TextBox ID="nationalid" runat="server"></asp:TextBox>
            <br />
            Phone Number:
             <asp:TextBox ID="phonenumber" runat="server"></asp:TextBox>
            <br />
            Birth Date:
             <asp:TextBox ID="birthdate" runat="server"></asp:TextBox>
            <br />
            Address:
             <asp:TextBox ID="address1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" onclick="register" Text="Register" />
            <br />
            
        </div>
    </form>
</body>
</html>
