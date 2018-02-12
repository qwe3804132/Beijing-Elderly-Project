<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftFrame.aspx.cs" Inherits="卢沟桥项目.Pages.SheQuGuanLi.LeftFrame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <link rel="stylesheet" type="text/css" href="../../Content/jiedao.css"/>
     <link href="../../CSS/left.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
      <div style="width:165px;position:fixed">
                     <asp:Button ID="Button1" runat="server" Height="40px" Text="优待卡审批" Width="160px" OnClick="Button1_Click" class="btn btn1"/>
                      <br />                                   
                     <asp:Button ID="Button7" runat="server" Height="40px" Text="高龄老年津贴审批" Width="160px"  OnClick="Button7_Click" class="btn btn1"/>
                      <br />
                     <asp:Button ID="Button8" runat="server" Height="40px" Text="优待卡领取管理" Width="160px" OnClick="Button8_Click" class="btn btn1"/>
                      <br />
                     <asp:Button ID="Button9" runat="server" Height="40px" Text="高龄津贴领取管理" Width="160px" OnClick="Button9_Click" class="btn btn1"/>
                      <br />
          <asp:Button ID="btn_change" runat="server" Height="40px" Text="修改密码" Width="160px"  class="btn btn1" OnClick="btn_change_Click"/>
                     </div > 
                     <div style="width:283%; margin-left:159px">
                          <iframe id="r_info" runat="server" width="100%" height="478px"></iframe>
                     </div>
    </div>
    </form>
</body>
</html>
