<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainFrame.aspx.cs" Inherits="卢沟桥项目.Pages.JieDaoGuanLi.MainFrame" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
   <frameset runat="server" rows="15%,70%,15%" style="border:0px">
   <frame runat="server" src="TopFrame.aspx" />
       <frameset runat="server" cols="100%">
           <frame runat="server" src="LeftFrame.aspx" />

          
       </frameset>
   <frame src="BottomFrame.aspx" />
</frameset>

</html>
