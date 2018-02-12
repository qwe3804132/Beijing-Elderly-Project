<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoneyRecord.aspx.cs" Inherits="卢沟桥项目.Pages.LaoRen.MoneyRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style2
        {
            text-align: center;
            color: #CC0000;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="GridView1" runat="server"  AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" Height="184px" Width="1016px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                <asp:BoundField DataField="ANumber" HeaderText="操作员工号" SortExpression="ANumber"></asp:BoundField>
                <asp:BoundField DataField="Money" HeaderText="领取金额" SortExpression="Money" />
                <asp:BoundField DataField="Time" HeaderText="领取时间" SortExpression="Time" />
            </Columns>
            <EmptyDataTemplate>
                <div class="auto-style2">
                    没有领取记录</div>
            </EmptyDataTemplate>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [moneyRecord] WHERE ([UID] = @UID)">
            <SelectParameters>
                <asp:SessionParameter Name="UID" SessionField="UID" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
