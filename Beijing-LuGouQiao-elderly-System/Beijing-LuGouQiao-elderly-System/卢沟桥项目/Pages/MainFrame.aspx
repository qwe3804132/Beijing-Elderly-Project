<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainFrame.aspx.cs" Inherits="卢沟桥项目.Pages.MainFrame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
   <frameset runat="server" rows="15%,68%,17%" style="border:0px" frameborder="NO" border="0" framespacing="0">
   <frame runat="server" src="TopFrame.aspx" />
       <frameset runat="server" cols="100%" frameborder="NO" border="0" framespacing="0">
           <frame id="leftFrame" runat="server"/>

          
       </frameset>
   <frame src="BottomFrame.aspx" />
</frameset>
</html>
