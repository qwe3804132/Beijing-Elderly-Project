<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChangePWD.aspx.cs" Inherits="卢沟桥项目.ChangePWD" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        
        .input {
            margin-left:50px;
            margin-top:30px;
        }
        .btn {
            margin-left:100px;
            margin-top:30px;
            width:155px;
            height:30px;
            border:1px solid #41b4ef;
            background-color:#3d8cce;
            font-size:15px;
        }
    </style>
</head>
<body>
    <div style="background-color:#3d8cce; background-size:cover; height:60px" >
     <div style="float:left; font-size:40px; margin-left:50px; margin-top:10px; color:white; font-family:'Arial','Microsoft YaHei','黑体','宋体',sans-serif;">
            密码找回
     </div>
            <a href="Login.aspx" style="float:right; margin-top:20px; margin-right:50px; font-size:20px; text-decoration:none"></a>
        
    </div>
    <%--<form id="form1" runat="server";  >--%>
    <form id="form1" runat="server" style="background-color:#d8edff; height:500px">
        <div style="height:100px;"></div>
    <div style="margin: auto; width:600px;height:300px; background-color:white" >
        <div style="height:10px;"></div>
     <div style="width:300px;  height:200px; margin:0px auto;">
      <div class="input">
          <a style="color:#b1b1b1">旧密码：</a>&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="tb_old" BorderColor="#99CCFF" BorderStyle="Solid" TextMode="Password"></asp:TextBox>
      </div>
       <div class="input">
            <a style="color:#b1b1b1">新密码：</a>&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="tb_p1" BorderColor="#99CCFF" BorderStyle="Solid" TextMode="Password" ></asp:TextBox>
        </div>
         <div class="input">
            <a style="color:#b1b1b1">再一次：</a>&nbsp;&nbsp;&nbsp;<asp:TextBox runat="server" ID="tb_p2" BorderColor="#99CCFF" BorderStyle="Solid" TextMode="Password" ></asp:TextBox>
        </div>
        <div >
             &nbsp;&nbsp;&nbsp;<asp:Button class="btn" runat="server" ID="btn_Change" Text="修改" style="color:#b1b1b1" OnClick="btn_Change_Click" />
        </div>
     </div>                
     </div>
    </form>
</body>
</html>
