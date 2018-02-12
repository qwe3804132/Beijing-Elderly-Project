<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightFrame6.aspx.cs" Inherits="卢沟桥项目.Pages.JieDaoGuanLi.RightFrame6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" Height="183px" Width="1015px">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="MinAge" HeaderText="最小年龄" SortExpression="MinAge" />
                <asp:BoundField DataField="MaxAge" HeaderText="最大年龄" SortExpression="MaxAge" />
                <asp:BoundField DataField="Money" HeaderText="金额" SortExpression="Money" />
                <asp:CommandField ShowEditButton="True" />
            </Columns>
            <EmptyDataTemplate>
                <div class="auto-style2">
                    没有数据</div>
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
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [moneyStandard] WHERE [ID] = @ID" InsertCommand="INSERT INTO [moneyStandard] ([MinAge], [MaxAge], [Money]) VALUES (@MinAge, @MaxAge, @Money)" SelectCommand="SELECT * FROM [moneyStandard]" UpdateCommand="UPDATE [moneyStandard] SET [MinAge] = @MinAge, [MaxAge] = @MaxAge, [Money] = @Money WHERE [ID] = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="MinAge" Type="Int32" />
                <asp:Parameter Name="MaxAge" Type="Int32" />
                <asp:Parameter Name="Money" Type="Double" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="MinAge" Type="Int32" />
                <asp:Parameter Name="MaxAge" Type="Int32" />
                <asp:Parameter Name="Money" Type="Double" />
                <asp:Parameter Name="ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    </form>
</body>
</html>
