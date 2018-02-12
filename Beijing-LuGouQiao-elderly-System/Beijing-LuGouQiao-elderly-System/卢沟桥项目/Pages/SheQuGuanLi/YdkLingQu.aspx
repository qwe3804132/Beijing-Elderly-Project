<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="YdkLingQu.aspx.cs" Inherits="卢沟桥项目.Pages.SheQuGuanLi.YdkLingQu" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            text-align: center;
            color: #FF0066;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" CellPadding="2" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="None" OnRowCommand="GridView2_RowCommand" OnRowDataBound="GridView2_RowDataBound" ShowHeaderWhenEmpty="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" Width="733px" AllowPaging="True" AllowSorting="True">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                <asp:BoundField DataField="UID" HeaderText="申请者ID" SortExpression="UID" />
                <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                <asp:BoundField DataField="Status" HeaderText="申请状态" SortExpression="Status" />
                <asp:BoundField DataField="CardStatus" HeaderText="优待卡状态" SortExpression="CardStatus" />
                <asp:BoundField DataField="GetTimes" HeaderText="申请时间" SortExpression="GetTimes" />
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>制作完成，待领取</asp:ListItem>
                            <asp:ListItem>已领取</asp:ListItem>
                            <asp:ListItem>待制作</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" BackColor="#66CCFF" BorderStyle="None" CommandName="queding" Text="确定" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="auto-style1">
                    没有人要领取优待卡</div>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Card.ID, Card.UID, Card.Status, Card.ANumber1, Card.ANumber2, Card.Reason, Card.CardStatus, Card.GetTimes, UInfo.CommunityID, UInfo.Name FROM Card INNER JOIN UInfo ON Card.UID = UInfo.ID WHERE (UInfo.CommunityID = @CommunityID)">
            <SelectParameters>
                <asp:SessionParameter DefaultValue="2" Name="CommunityID" SessionField="CommunityID" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
