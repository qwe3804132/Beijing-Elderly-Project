<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MakeTable.aspx.cs" Inherits="卢沟桥项目.Pages.JieDaoGuanLi.MakeTable" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1
        {
            color: #990033;
        }
        .auto-style2
        {
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataTextField="CommunityName" DataValueField="ID" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" >
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [CommunityName], [ID] FROM [Community]"></asp:SqlDataSource>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource2" AllowPaging="True" AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Height="183px" Width="1014px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="UID" HeaderText="用户ID" SortExpression="UID" />
                <asp:BoundField DataField="ANumber" HeaderText="社区管理员ID" SortExpression="ANumber" />
                <asp:BoundField DataField="Time" HeaderText="领取时间" SortExpression="Time" />
                <asp:BoundField DataField="Money" HeaderText="领取金额" SortExpression="Money" />
            </Columns>
            <EmptyDataTemplate>
                <div class="auto-style2">
                    没有数据</div>
            </EmptyDataTemplate>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT moneyRecord.* FROM UInfo INNER JOIN moneyRecord ON UInfo.ID = moneyRecord.UID INNER JOIN Community ON Community.ID = UInfo.CommunityID where Community.ID = 1"></asp:SqlDataSource>
    </form>
</body>
</html>
