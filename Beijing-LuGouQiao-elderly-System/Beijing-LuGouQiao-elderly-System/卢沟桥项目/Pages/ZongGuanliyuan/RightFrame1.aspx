<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightFrame1.aspx.cs" Inherits="卢沟桥项目.Pages.ZongGuanliyuan.RightFrame1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form12" runat="server">
    <div>
    
    </div>
        
      
            
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" DataSourceID="sUinfo" ForeColor="Black" GridLines="None" Height="246px" Width="1020px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="CommunityName" HeaderText="所属社区" SortExpression="CommunityName" />
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                <asp:BoundField DataField="Number" HeaderText="身份证号" SortExpression="Number" />
                <asp:BoundField DataField="Birthday" HeaderText="生日" SortExpression="Birthday" />
                <asp:BoundField DataField="PWD" HeaderText="密码" SortExpression="PWD" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:SqlDataSource ID="sUinfo" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Community.CommunityName, UInfo.ID, UInfo.Name, UInfo.Number, UInfo.Birthday, UInfo.CommunityID, UInfo.PWD FROM UInfo INNER JOIN Community ON UInfo.CommunityID = Community.ID" UpdateCommand="UPDATE UInfo SET Name =, Number =, Birthday =, PWD ="></asp:SqlDataSource>
        
      
            
    </form>
</body>
</html>
