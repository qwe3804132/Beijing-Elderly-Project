<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RightFrame2.aspx.cs" Inherits="卢沟桥项目.Pages.JieDaoGuanLi.RightFrame2" %>

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
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" DataSourceID="SqlDataSource2" ForeColor="Black" GridLines="None" Height="184px" Width="1015px" >
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="管理员ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" />
                <asp:BoundField DataField="Number" HeaderText="用户名" SortExpression="Number" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="PWD" HeaderText="密码" SortExpression="PWD" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="CommunityID" HeaderText="社区ID" SortExpression="CommunityID" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField DataField="types" HeaderText="管理员类型" SortExpression="types" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" >
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:CommandField>
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
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [AdminInfo] WHERE [ID] = @original_ID AND (([Number] = @original_Number) OR ([Number] IS NULL AND @original_Number IS NULL)) AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL)) AND (([PWD] = @original_PWD) OR ([PWD] IS NULL AND @original_PWD IS NULL)) AND (([CommunityID] = @original_CommunityID) OR ([CommunityID] IS NULL AND @original_CommunityID IS NULL)) AND (([types] = @original_types) OR ([types] IS NULL AND @original_types IS NULL))" InsertCommand="INSERT INTO [AdminInfo] ([Number], [Name], [PWD], [CommunityID], [types]) VALUES (@Number, @Name, @PWD, @CommunityID, @types)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [AdminInfo] WHERE ([types] = @types)" UpdateCommand="UPDATE [AdminInfo] SET [Number] = @Number, [Name] = @Name, [PWD] = @PWD, [CommunityID] = @CommunityID, [types] = @types WHERE [ID] = @original_ID AND (([Number] = @original_Number) OR ([Number] IS NULL AND @original_Number IS NULL)) AND (([Name] = @original_Name) OR ([Name] IS NULL AND @original_Name IS NULL)) AND (([PWD] = @original_PWD) OR ([PWD] IS NULL AND @original_PWD IS NULL)) AND (([CommunityID] = @original_CommunityID) OR ([CommunityID] IS NULL AND @original_CommunityID IS NULL)) AND (([types] = @original_types) OR ([types] IS NULL AND @original_types IS NULL))">
            <DeleteParameters>
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Number" Type="Int32" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_PWD" Type="String" />
                <asp:Parameter Name="original_CommunityID" Type="Int32" />
                <asp:Parameter Name="original_types" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="Number" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="PWD" Type="String" />
                <asp:Parameter Name="CommunityID" Type="Int32" />
                <asp:Parameter Name="types" Type="Int32" />
            </InsertParameters>
            <SelectParameters>
                <asp:Parameter DefaultValue="0" Name="types" Type="Int32" />
            </SelectParameters>
            <UpdateParameters>
                <asp:Parameter Name="Number" Type="Int32" />
                <asp:Parameter Name="Name" Type="String" />
                <asp:Parameter Name="PWD" Type="String" />
                <asp:Parameter Name="CommunityID" Type="Int32" />
                <asp:Parameter Name="types" Type="Int32" />
                <asp:Parameter Name="original_ID" Type="Int32" />
                <asp:Parameter Name="original_Number" Type="Int32" />
                <asp:Parameter Name="original_Name" Type="String" />
                <asp:Parameter Name="original_PWD" Type="String" />
                <asp:Parameter Name="original_CommunityID" Type="Int32" />
                <asp:Parameter Name="original_types" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        
        <asp:Panel ID="Panel1" runat="server" Height="125px" Width="222px"  BackColor="#dee1e2">
            用户名<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            姓&nbsp;&nbsp;名<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            密&nbsp;&nbsp;码<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            社区ID<asp:DropDownList ID="ddlshequID" runat="server" DataSourceID="SqlDataSource111" DataTextField="CommunityName" DataValueField="ID" Height="25px" Width="120px">
            </asp:DropDownList>
            <br />
            <asp:Button ID="Button1" runat="server" Text="添加用户" Width="62px" OnClick="Button1_Click" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button2" runat="server" Text="清空" Width="62px" OnClick="Button2_Click" />
            &nbsp;&nbsp;
        </asp:Panel>
         <asp:SqlDataSource ID="SqlDataSource111" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [CommunityName], [ID] FROM [Community]"></asp:SqlDataSource>
    </form>
</body>
</html>
