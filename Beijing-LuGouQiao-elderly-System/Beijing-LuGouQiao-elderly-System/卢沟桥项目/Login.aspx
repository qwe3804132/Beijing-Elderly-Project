<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="卢沟桥项目.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image:url(Images/login.jpg);background-repeat:no-repeat;background-size:cover; font-family:arial, 'Microsoft Yahei', '微软雅黑';">
    <div style="margin-top:18%;margin-left:40%;font-size:25px;color:#3fa1cc;text-shadow:1px 1px 1px #3fa1cc;">卢沟桥街道居家养老服务管理系统</div>
    <form id="form1" runat="server" style="width:236px; height:200px;margin-left:50%;margin-top:5%">
        
        <div style="color:#a0a0a0">
            用户名:
            <asp:TextBox ID="tb_Name" runat="server" BorderColor="#97C5DA" BorderStyle="Solid"></asp:TextBox>
        </div>
        <br />
    
        <div style="color:#a0a0a0">
            密&nbsp;&nbsp;&nbsp;&nbsp;码:
            
            <asp:TextBox ID="tb_Password" runat="server" BorderColor="#97C5DA" BorderStyle="Solid" TextMode="Password"></asp:TextBox>
        </div>
      
     
      <div style="margin-left:65px;color:#a0a0a0" >
        <asp:RadioButtonList ID="rbl_UserType" runat="server"  RepeatDirection="Horizontal">
            <asp:ListItem>申请者</asp:ListItem>
            <asp:ListItem>管理员</asp:ListItem>
        </asp:RadioButtonList>
      </div>
          <br />
        <div style="margin-left:140px;" >
        <asp:Button ID="btn_login" runat="server"  Text="登陆" OnClick="btn_login_Click" style="width: 70px" BackColor="#1E91C4" BorderStyle="None" Height="20px" ForeColor="White" />
           <br /> <div><a href="FindPWD.aspx" style="text-decoration:none; color:#b1b1b1; font-size:12px;">忘记密码</a></div> 
        </div>
    </form>
</body>
</html>
