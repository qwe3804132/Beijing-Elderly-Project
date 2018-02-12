<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SearchUInfo.aspx.cs" Inherits="卢沟桥项目.Pages.LaoRen.SearchUInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .onerow
        {
            margin-top:20px;
            color:blue;
        }
            .onerow b
            {
                color:#784848;
            }
        .title
        {
            color:#3593b7;
            line-height:50px;
            margin-left:60px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" style="height:400px;width:100%; background-color:#61c1e5">
    <div class="title" style="height:50px;"><h3>个人信息</h3></div>
    <div style="height:100%; width:100%; background-color:#b1b1b1">
         <div style="margin-left:200px;" >
             <div style="height:20px;"></div>
                 <div class="onerow">
                     <b>姓名：</b><asp:TextBox style="margin-left:44px" ID="tb_Name" runat="server" ReadOnly="True" BorderStyle="None"></asp:TextBox>
                 </div>
                 <div class="onerow">
                     <b>身份证号：</b><asp:TextBox style="margin-left:10px" ID="tb_Number" runat="server" ReadOnly="True" BorderStyle="None"></asp:TextBox>

                 </div >
                 <div class="onerow">
                     <b>出生日期：</b> <asp:TextBox ID="tb_Birthday" runat="server" ReadOnly="True" BorderStyle="None"></asp:TextBox>
                 </div>
                 <div class="onerow">
                     <b>所属社区：</b><asp:TextBox style="margin-left:10px" ID="tb_Community" runat="server" ReadOnly="True" BorderStyle="None"></asp:TextBox>
                 </div>
         </div>
    </div>
    </form>
</body>
</html>
