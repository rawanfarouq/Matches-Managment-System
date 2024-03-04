<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SystemAdmin.aspx.cs" Inherits="db_M3.SystemAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Text="ADD CLUB"></asp:Label>
            <ul>
                <li>
                Club name: 
                <asp:TextBox runat="server" ID="name1" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                <li>
                Club location :
                <asp:TextBox runat="server" ID="location1" Width="213px"></asp:TextBox>
           </ul>
        </div>
        <p>
            <asp:Button ID="Button1" runat="server" onclick="addclub" Text="ADD" Width="145px" />
            </p>
        <br />
        <asp:Label ID="Label2" runat="server" Text="DELETE CLUB"></asp:Label>
        <ul>
                <li>
                Club name: 
                <asp:TextBox runat="server" ID="name2" style="margin-left: 33px" Width="213px"></asp:TextBox>
                </li>
               
          </ul>
        <p>
        <asp:Button ID="Button2" runat="server" onclick="deleteclub" Text="DELETE" Width="145px" /></p>
        <br />
        <asp:Label ID="Label3" runat="server" Text="ADD STADIUM"></asp:Label>
            <ul>
                <li>
                Stadium name: 
                <asp:TextBox runat="server" ID="name3" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                <li>
                Stadium location :
                <asp:TextBox runat="server" ID="location2" Width="213px"></asp:TextBox>
                <br />
                <li>
                Stadium capacity:
                <asp:TextBox runat="server" ID="capacity1" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                </li>
           </ul>
        <p>
            <asp:Button ID="Button3" runat="server" onclick="addstadium" Text="ADD" Width="145px" />
            </p>
         <br />
        <asp:Label ID="Label4" runat="server" Text="DELETE STADIUM"></asp:Label>
        <ul>
                <li>
                Stadium name: 
                <asp:TextBox runat="server" ID="name4" style="margin-left: 33px" Width="213px"></asp:TextBox>
                </li>
               
          </ul>
        <p>
        <asp:Button ID="Button4" runat="server" onclick="deletestadium" Text="DELETE" Width="145px" /></p>
        <br />
        <asp:Label ID="Label5" runat="server" Text="BLOCK FAN"></asp:Label>
            <ul>
                <li>
                National ID: 
                <asp:TextBox runat="server" ID="national2" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                 <p>
            <asp:Button ID="Button5" runat="server" onclick="blockfan" Text="BLOCK" Width="145px" />
            </p>
    </form>
</body>
</html>
