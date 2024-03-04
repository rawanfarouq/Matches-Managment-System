<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AssociationManager.aspx.cs" Inherits="db_M3.AssociationManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             <asp:Label ID="Label3" runat="server" Text="ADD MATCH"></asp:Label>
            <ul>
                <li>
                Host_CLub name: 
                <asp:TextBox runat="server" ID="hostname" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                <li>
                Guest_Club name :
                <asp:TextBox runat="server" ID="guestname" Width="213px"></asp:TextBox>
                <br />
                <li>
                Start Time:
                <asp:TextBox runat="server" ID="startime" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                </li>
                End Time:
                <asp:TextBox runat="server" ID="endtime" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                </li>
           </ul>
        <p>
            <asp:Button ID="Button3" runat="server" onclick="addmatch" Text="ADD" Width="145px" />
            </p>
            <asp:Label ID="Label1" runat="server" Text="DELETE MATCH"></asp:Label>
            <ul>
                <li>
                Host_CLub name: 
                <asp:TextBox runat="server" ID="host1" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                <li>
                Guest_Club name :
                <asp:TextBox runat="server" ID="guest1" Width="213px"></asp:TextBox>
                <br />
                <li>
                Start Time:
                <asp:TextBox runat="server" ID="start1" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                </li>
                End Time:
                <asp:TextBox runat="server" ID="end1" style="margin-left: 33px" Width="213px"></asp:TextBox>
                <br />
                </li>
           </ul>
        <p>
            <asp:Button ID="Button1" runat="server" onclick="deletematch" Text="DELETE" Width="145px" />
            </p>
           
        <p>
           UpcomingMatches:
            <p>
            <asp:GridView ID="UpcomingMatches1" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Host_Club" HeaderText="Host Club" />
                    <asp:BoundField DataField="Guest_Club" HeaderText="Guest Club" />
                    <asp:BoundField DataField="Start_Time" HeaderText="Start Time" />
                    <asp:BoundField DataField="End_Time" HeaderText="End Time" />
                    
                </Columns>
            </asp:GridView>
            <p>
            Played Matches:
            <p>
            <asp:GridView ID="playedmatches" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Host_Club" HeaderText="Host Club" />
                    <asp:BoundField DataField="Guest_Club" HeaderText="Guest Club" />
                    <asp:BoundField DataField="Start_Time" HeaderText="Start Time" />
                    <asp:BoundField DataField="End_Time" HeaderText="End Time" />
                    
                </Columns>
            </asp:GridView>
             <p>
           CLubs Never Matched:
            <p>
            <asp:GridView ID="clubsnever" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Club1" HeaderText="Club 1" />
                    <asp:BoundField DataField="Club2" HeaderText="Club 2" />
                     </Columns>
            </asp:GridView>
        </div>
       
    </form>
</body>
</html>
