﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepresentativeRegister.aspx.cs" Inherits="db_M3.ClubRepresentativeRegister" %>

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
            <asp:TextBox ID="name1" runat="server"></asp:TextBox>
            <br />
            Username:
             <asp:TextBox ID="username1" runat="server"></asp:TextBox>
            <br />
            Password:
             <asp:TextBox ID="password1" runat="server"></asp:TextBox>
            <br />
            Club Name:
            <asp:TextBox ID="club" runat="server"></asp:TextBox>
            <br />
             <asp:Button ID="Button1" runat="server" onclick="register" Text="Register" />
            <br />
        </div>
    </form>
</body>
</html>
