<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardApplyNext.aspx.cs" Inherits="卢沟桥项目.Pages.LaoRen.CardApplyNext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:Label ID="lb_Age" runat="server" Text="年龄"></asp:Label>
        <br />
        <asp:TextBox ID="tb_Age" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lb_Gender" runat="server" Text="性别"></asp:Label>
        <asp:RadioButtonList ID="rbl_Gender" runat="server" RepeatDirection="Horizontal">
            <asp:ListItem>男</asp:ListItem>
            <asp:ListItem>女</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="lb_Addr" runat="server" Text="家庭住址"></asp:Label>
        <br />
        <asp:TextBox ID="tb_Addr" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lb_Tel" runat="server" Text="联系电话"></asp:Label>
        <br />
        <asp:TextBox ID="tb_Tel" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lb_Job" runat="server" Text="退休前岗位"></asp:Label>
        <br />
        <asp:TextBox ID="tb_Job" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="lb_Money" runat="server" Text="退休金"></asp:Label>
        <br />
        <asp:TextBox ID="tb_Money" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="btn_Submit" runat="server" Text="提交" OnClick="btn_Submit_Click" />
    </form>
</body>
</html>
