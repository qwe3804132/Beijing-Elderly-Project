<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightFrame4.aspx.cs" Inherits="卢沟桥项目.Pages.JieDaoGuanLi.RightFrame4"  EnableEventValidation = "false"  %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    </head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:DropDownList ID="ddl_year" runat="server">
        </asp:DropDownList>
    
        <asp:DropDownList ID="ddl_month" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="01">一月</asp:ListItem>
            <asp:ListItem Value="02">二月</asp:ListItem>
            <asp:ListItem Value="03">三月</asp:ListItem>
            <asp:ListItem Value="04">四月</asp:ListItem>
            <asp:ListItem Value="05">五月</asp:ListItem>
            <asp:ListItem Value="06">六月</asp:ListItem>
            <asp:ListItem Value="07">七月</asp:ListItem>
            <asp:ListItem Value="08">八月</asp:ListItem>
            <asp:ListItem Value="09">九月</asp:ListItem>
            <asp:ListItem Value="10">十月</asp:ListItem>
            <asp:ListItem Value="11">十一月</asp:ListItem>
            <asp:ListItem Value="12">十二月</asp:ListItem>
        </asp:DropDownList>
    
        &nbsp;到
    
        <asp:DropDownList ID="ddl_year2" runat="server">
        </asp:DropDownList>
    
        <asp:DropDownList ID="ddl_month2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="01">一月</asp:ListItem>
            <asp:ListItem Value="02">二月</asp:ListItem>
            <asp:ListItem Value="03">三月</asp:ListItem>
            <asp:ListItem Value="04">四月</asp:ListItem>
            <asp:ListItem Value="05">五月</asp:ListItem>
            <asp:ListItem Value="06">六月</asp:ListItem>
            <asp:ListItem Value="07">七月</asp:ListItem>
            <asp:ListItem Value="08">八月</asp:ListItem>
            <asp:ListItem Value="09">九月</asp:ListItem>
            <asp:ListItem Value="10">十月</asp:ListItem>
            <asp:ListItem Value="11">十一月</asp:ListItem>
            <asp:ListItem Value="12">十二月</asp:ListItem>
        </asp:DropDownList>
    
            <asp:Button ID="btn_select" runat="server"  Text="查询" BackColor="#3366FF" BorderColor="#6600FF" BorderStyle="Solid" ForeColor="White" OnClick="btn_select_Click" />
    
    </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" Height="242px" Width="1015px">
                <AlternatingRowStyle BackColor="PaleGoldenrod" />
                <Columns>
                    <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                    <asp:BoundField DataField="UID" HeaderText="用户ID" SortExpression="UID" />
                    <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                    <asp:BoundField DataField="ApplyTime" HeaderText="申请时间" SortExpression="ApplyTime" />
                    <asp:BoundField DataField="Age" HeaderText="年龄" SortExpression="Age" />
                    <asp:BoundField DataField="Gender" HeaderText="性别" SortExpression="Gender" />
                    <asp:BoundField DataField="Address" HeaderText="地址" SortExpression="Address" />
                    <asp:BoundField DataField="Tel" HeaderText="电话" SortExpression="Tel" />
                    <asp:BoundField DataField="Job" HeaderText="退休前工作" SortExpression="Job" />
                    <asp:BoundField DataField="Money" HeaderText="退休金" SortExpression="Money" />
                    <asp:BoundField DataField="Types" HeaderText="津贴类别" SortExpression="Types" />
                    
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
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT ApplyInfo.ID, ApplyInfo.UID, ApplyInfo.ApplyTime, ApplyInfo.Age, ApplyInfo.Gender, ApplyInfo.Address, ApplyInfo.Tel, ApplyInfo.Job, ApplyInfo.Money, ApplyInfo.Types, ApplyInfo.Photo, UInfo.Name FROM ApplyInfo INNER JOIN Card ON ApplyInfo.UID = Card.UID INNER JOIN UInfo ON ApplyInfo.UID = UInfo.ID WHERE (Card.Status = 5) AND (ApplyInfo.Types = 0) AND (Card.CardStatus = 1)"></asp:SqlDataSource>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="确认制表" BackColor="#3366FF" BorderColor="#6600FF" BorderStyle="Solid" ForeColor="White" />
        </div>
    </form>
</body>
</html>
