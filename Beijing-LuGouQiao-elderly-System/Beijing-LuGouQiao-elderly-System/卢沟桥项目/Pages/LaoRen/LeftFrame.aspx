<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LeftFrame.aspx.cs" Inherits="卢沟桥项目.Pages.LaoRen.LeftFrame" %>

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

                     <div style="width:165px;position:fixed">
                     <div class="lab">申请业务</div>
                     <asp:Button ID="btn_CardApply" runat="server" Height="40px" Text="优待卡" Width="160px" OnClick="btn_CardApply_Click" class="btn" />                      
                     <asp:Button ID="btn_MoneyApply" runat="server" Height="40px" Text="老年津贴" Width="160px" OnClick="btn_MoneyApply_Click" class="btn" />
                    <%-- <asp:Label ID="lb_Query" runat="server" Text="查询服务" Width="160px"></asp:Label>--%>
                          <div class="lab">查询服务</div>
                     <asp:Button ID="btn_CatdStatus" runat="server" Height="40px" Text="优待卡状态" Width="160px" OnClick="btn_CatdStatus_Click" class="btn" />
                     <asp:Button ID="btn_MoneyStatus" runat="server" Height="40px" Text="老年津贴状态" Width="160px" OnClick="btn_MoneyStatus_Click" class="btn" />
                     <asp:Button ID="btn_MoneyRecord" runat="server" Height="40px" Text="津贴领取记录" Width="160px" OnClick="btn_MoneyRecord_Click" class="btn"  />
                     <asp:Button ID="btn_SearchUInfo" runat="server" Height="40px" Text="查看个人信息" Width="160px" OnClick="btn_SearchUInfo_Click" class="btn" />
                     </div > 
                     <div style="width:89%;margin-left:160px">
                         <iframe id="r_info" runat="server" width="100%" height="478px"></iframe>
                     </div>
    
      </form>
</body>
</html>
