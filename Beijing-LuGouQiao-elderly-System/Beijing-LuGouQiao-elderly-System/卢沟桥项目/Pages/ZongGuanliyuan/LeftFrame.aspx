<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftFrame.aspx.cs" Inherits="卢沟桥项目.Pages.JieDaoGuanLi.LeftFrame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link rel="stylesheet" type="text/css" href="../../Content/jiedao.css"/>
    <link href="../../CSS/left.css" rel="stylesheet" />
</head>
<body>
    <form id="form31" runat="server">

                     <div style="width:165px;position:fixed">
                      <br />    
                      <br />                                                   
                     <asp:Button ID="Button11" runat="server" Height="40px" Text="管理员信息管理" Width="160px" OnClick="Button11_Click" class="btn" />
                     <asp:Button ID="Button12" runat="server" Height="40px" Text="用户信息管理" Width="160px" OnClick="Button11_Click" class="btn" />
                     <asp:Button ID="btn_change" runat="server" Height="40px" Text="修改密码" Width="160px" class="btn" OnClick="btn_change_Click" />
                      <br />
                      <br />
                      <br />
                     </div > 
                     <div style="width:89%;margin-left:159px">
                         <iframe id="r_info11" runat="server" width="100%" height="478px"></iframe>
                     </div>
    
      </form>
</body>
</html>
