<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StadiumManager.aspx.cs" Inherits="db_M3.StadiumManager" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
             Stadium Information:
            <p>
            <asp:GridView ID="matchesInfo" runat="server" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" />
                    <asp:BoundField DataField="status" HeaderText="Status" />
                    <asp:BoundField DataField="location" HeaderText="Location" />
                    <asp:BoundField DataField="capacity" HeaderText="Capacity" />
                    <asp:BoundField DataField="name" HeaderText="Stadium Name" />
                </Columns>
            </asp:GridView>
                <p>
                 All Request Information:
            <p>
                <asp:GridView ID="requestinfo" runat="server" AutoGenerateColumns="false" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <Columns>
            <asp:BoundField DataField="Club_Representative" HeaderText="Club Representative"/>
            <asp:BoundField DataField="Host_Club" HeaderText="Host Club"/>
            <asp:BoundField DataField="Guest_Club" HeaderText="Guest Club"/>
            <asp:BoundField DataField="Start_Time" HeaderText="Start Time"/>
            <asp:BoundField DataField="End_Time" HeaderText="End Time"/>
             <asp:BoundField DataField="Status" HeaderText="Status"/>

                <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Button ID="accept" runat="server" Text="Accept" 
                    OnClick="accept" />
                         </ItemTemplate>
                     </asp:TemplateField>

                <asp:TemplateField>
                         <ItemTemplate>
                             <asp:Button ID="decline" runat="server" Text="Decline" 
                    OnClick="decline" />
                         </ItemTemplate>
                     </asp:TemplateField>
             
        </Columns>
                </asp:GridView>
                <p>
                  
        </div>
    </form>
</body>
</html>
