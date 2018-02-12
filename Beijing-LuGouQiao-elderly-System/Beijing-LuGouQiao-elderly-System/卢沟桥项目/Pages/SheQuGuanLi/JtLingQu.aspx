<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JtLingQu.aspx.cs" Inherits="卢沟桥项目.Pages.SheQuGuanLi.JtLingQu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            color: #FF0066;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="color: #FF0066">
    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" OnRowCommand="GridView1_RowCommand" OnRowDataBound="GridView1_RowDataBound" ShowHeaderWhenEmpty="True" style="text-align: center" Width="737px" AllowPaging="True" AllowSorting="True">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="UID" HeaderText="用户ID" SortExpression="UID" />
                <asp:BoundField DataField="Name" HeaderText="用户姓名" SortExpression="Name" />
                <asp:BoundField DataField="MID" HeaderText="津贴类别" SortExpression="MID" />
                <asp:BoundField DataField="Money" HeaderText="津贴数量" SortExpression="Money" />
                <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" Visible="False" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="lingqu" Text="领取"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
            </Columns>
            <EmptyDataTemplate>
                <span class="auto-style1">没有要领取津贴的人</span>
            </EmptyDataTemplate>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Money.MID, moneyStandard.Money, Money.UID, UInfo.Name, Money.Status, Money.ID, UInfo.CommunityID FROM Money INNER JOIN moneyStandard ON Money.MID = moneyStandard.ID INNER JOIN UInfo ON Money.UID = UInfo.ID WHERE (Money.Status = 5) AND (UInfo.CommunityID = @CommunityID)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="2" Name="CommunityID" SessionField="CommunityID" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
