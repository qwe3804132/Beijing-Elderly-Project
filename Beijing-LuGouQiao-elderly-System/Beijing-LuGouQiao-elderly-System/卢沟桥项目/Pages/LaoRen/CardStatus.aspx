<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CardStatus.aspx.cs" Inherits="卢沟桥项目.Pages.LaoRen.CardStatus" %>

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
    <form id="form1" runat="server">
        <div style="background-color:#61c1e5;height:200px; width:100%">
            <div class="title" style="height:50px;"><h3>优待卡审核状态</h3></div>
            <div style="height:100%; width:100%; background-color:#b1b1b1">
             <div style="margin-left:200px;">
                 <div style="height:20px;"></div>
                 <div class="onerow">
                     <b>申请状态：</b> <asp:Label runat="server" ID="lb_Status"></asp:Label>
                 </div>
                  <div class="onerow">
                     <b>二级审核员工号：</b> <asp:Label runat="server" ID="lb_ANumber1" ></asp:Label>
                 </div>
                  <div class="onerow">
                     <b>三级审核员工号：</b> <asp:Label runat="server" ID="lb_ANumber2" ></asp:Label>
                 </div>
                  <div class="onerow">
                      <b>
                      <asp:Label  ID="lb_Reason0" runat="server" Text="审核失败原因：" Visible="false"></asp:Label>
                      </b>
                 </div>
                 <div class="onerow" style="margin-left:50px;">
                     <asp:Label runat="server" ID="lb_Reason"></asp:Label>
                 </div>  
             </div>
            </div>
            <div style="background-color:#61c1e5;height:200px; width:100%">
                 <div class="title" style="height:50px;"><h3>优待卡状态</h3></div>
                <div style="height:100%; width:100%; background-color:#b1b1b1">
             <div style="margin-left:200px;">
                 <div style="height:20px;"></div>
                 <div class="onerow">
                          <asp:Label runat="server" ID="lb_zktypes"></asp:Label>
                 </div>  
             </div>
            </div>
        </div>
    </form>
</body>
</html>
