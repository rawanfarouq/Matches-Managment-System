<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="db_M3.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
 
    <form id="form1" runat="server">
        <div>
           Please Login In <br />
           UserName: <br />
             <asp:TextBox ID="Username1" runat="server"></asp:TextBox>
            <br />
            Password: <br />
            <asp:TextBox ID="Password1" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="signin" runat="server" OnClick="login" Text="Log in"></asp:Button>
            <br />
            <br />
                <asp:Button runat="server" OnClick="Fan" Text="Register As Fan"></asp:Button>  
            <asp:Button runat="server" OnClick="AssociationManager" Text="Register As Association Manager"></asp:Button> 
            <asp:Button runat="server" OnClick="ClubRepresentative" Text="Register As Club Representative"></asp:Button> 
            <asp:Button runat="server" OnClick="StadiumManager" Text="Register As Stadium Manager"></asp:Button> 
            <br />

        </div>
    </form>
</body>
</html>
