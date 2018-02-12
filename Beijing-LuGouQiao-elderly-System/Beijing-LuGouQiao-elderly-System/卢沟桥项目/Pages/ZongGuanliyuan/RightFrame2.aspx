<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightFrame2.aspx.cs" Inherits="卢沟桥项目.Pages.ZongGuanliyuan.RightFrame2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form12" runat="server">
    <div>
    
    </div>
        <asp:GridView ID="searchAdmin" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" DataSourceID="SqlDataSource22" ForeColor="Black" GridLines="None" Height="184px" Width="1015px" >
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Number" HeaderText="用户名" SortExpression="Number" >
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" >
                </asp:BoundField>
                <asp:BoundField DataField="PWD" HeaderText="密码" SortExpression="PWD" >
                </asp:BoundField>
                <asp:BoundField DataField="CommunityID" HeaderText="社区ID" SortExpression="CommunityID" >
                </asp:BoundField>
                <asp:BoundField DataField="types" HeaderText="管理员类别" SortExpression="types" >
                </asp:BoundField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
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
        <asp:SqlDataSource ID="SqlDataSource22" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [AdminInfo] WHERE [ID] = @original_ID" InsertCommand="INSERT INTO [AdminInfo] ([Number], [Name], [PWD], [CommunityID], [types]) VALUES (@Number, @Name, @PWD, @CommunityID, @types)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [AdminInfo] WHERE ([types] &lt; @types)" UpdateCommand="UPDATE [AdminInfo] SET [Number] = @Number, [Name] = @Name, [PWD] = @PWD, [CommunityID] = @CommunityID, [types] = @types WHERE [ID] = @original_ID">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Number" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="PWD" Type="String" />
                <asp:Parameter Name="CommunityID" Type="Int32" />
                <asp:Parameter Name="types" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="2" Name="types" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Number" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="PWD" Type="String" />
                <asp:Parameter Name="CommunityID" Type="Int32" />
                <asp:Parameter Name="types" Type="Int32" />
                <asp:Parameter Name="original_ID" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:Panel ID="Panel11" runat="server" Height="188px" Width="1015px"  BackColor="#dee1e2">
            <div style="margin-left:20px;color:#784848">
                <div style="height:20px;"></div>
            用户名<asp:TextBox ID="TextBox21" runat="server"></asp:TextBox>
            <br />
            姓&nbsp;&nbsp;名<asp:TextBox ID="TextBox22" runat="server"></asp:TextBox>
            <br />
            密&nbsp;&nbsp;码<asp:TextBox ID="TextBox23" runat="server"></asp:TextBox>
            <br />
            社区ID<asp:DropDownList ID="DropDownList1"  runat="server" DataSourceID="SqlDataSource1" DataTextField="CommunityName" DataValueField="ID" Height="20px" Width="93px">
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [CommunityName], [ID] FROM [Community]"></asp:SqlDataSource>
            <br />
            <asp:RadioButtonList ID="RadioButtonList11" RepeatLayout="Flow" runat="server" Height="16px" RepeatDirection="Horizontal" Width="232px" AutoPostBack="True" OnSelectedIndexChanged="RadioButtonList11_SelectedIndexChanged">
                <asp:ListItem Value="0">社区管理员</asp:ListItem>
                <asp:ListItem Value="1">街道管理员</asp:ListItem>
            </asp:RadioButtonList>
            <br />
            <br />
            <asp:Button ID="Button21" runat="server" Text="添加用户" Width="62px" OnClick="Button21_Click" BackColor="#3399FF" BorderColor="#3399FF" BorderStyle="None" ForeColor="White" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button22" runat="server" Text="清  空" Width="62px" OnClick="Button22_Click" BackColor="#3399FF" BorderColor="#3399FF" BorderStyle="None" ForeColor="White" />
                </div>
        </asp:Panel>
            
    </form>
</body>
</html>
