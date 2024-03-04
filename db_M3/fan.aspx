<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fan.aspx.cs" Inherits="db_M3.fan" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    
    <form id="form1" runat="server">
        <div>
            All Matches:
            <asp:TextBox ID="matchdate" runat="server"></asp:TextBox> 
            <asp:GridView ID="matches1Info" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            
            <Columns>
            <asp:BoundField DataField="hostClubName" HeaderText="Host Club"/>
            <asp:BoundField DataField="guestClubName" HeaderText="Guest Club"/>
            <asp:BoundField DataField="start_time" HeaderText="Start Time"/>
            <asp:BoundField DataField="Stadiumname" HeaderText="Stadium Name"/>
            <asp:BoundField DataField="Stadiumlocation" HeaderText="Stadium Location"/>
                <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Button ID="Button1" runat="server" Text="Buy a Ticket" 
                    OnClick="MyButtonClick" />
                         </ItemTemplate>
                     </asp:TemplateField>
             
        </Columns>
                </asp:GridView>
                <p>




            <p>

           
        </div>
    </form>
</body>
</html>
