<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ClubRepresentative.aspx.cs" Inherits="db_M3.ClubRepresentative" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Club Information:
            <p>
            <asp:GridView ID="clubinfo" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Club Name" />
                    <asp:BoundField DataField="ID" HeaderText="Club ID" />
                    <asp:BoundField DataField="location" HeaderText="Club Location" />
                    
                </Columns>
            </asp:GridView>
            <p>
                Upcoming Matches:
            <p>
            <asp:GridView ID="matchesInfo" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Host_Club" HeaderText="Host Club" />
                    <asp:BoundField DataField="Guest_Club" HeaderText=" Guest Club" />
                    <asp:BoundField DataField="Start_Time" HeaderText="Start Time" />
                    <asp:BoundField DataField="End_Time" HeaderText="End Time" />
                    <asp:BoundField DataField="Stadium_Name" HeaderText="Stadium Name" />
                </Columns>
            </asp:GridView>
            <p>
                Available Stadiums:<br />
                Starting Date:
                <asp:TextBox ID="available" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button1" runat="server" onclick="stadium" Text="AvailableStadiums" />
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="name" HeaderText="Name" />
                    <asp:BoundField DataField="location" HeaderText="Location" />
                    <asp:BoundField DataField="capacity" HeaderText="Capacity" />
                      </Columns>
            </asp:GridView>
                <p>
                Send Hosting Request:<br />
                Stadium Name:
                <asp:TextBox ID="stadiumname" runat="server"></asp:TextBox>
                <br />
                Start Time:
                <asp:TextBox ID="start_time" runat="server"></asp:TextBox>
                <br />
                <asp:Button ID="Button2" runat="server" onclick="request" Text="Send_Request" />
                    <br />
        </div>
    </form>
</body>
</html>
