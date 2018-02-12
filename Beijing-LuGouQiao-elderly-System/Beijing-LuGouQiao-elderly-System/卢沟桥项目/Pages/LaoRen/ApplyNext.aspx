<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ApplyNext.aspx.cs" Inherits="卢沟桥项目.Pages.LaoRen.ApplyNext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <script src="../../Scripts/jquery-1.7.1.min.js"></script>
    <script src="../../Scripts/jquery-ui-1.8.20.min.js"></script> 
    <style type="text/css">
        body
        {
            color:#3e4e62;
        }
        .onerow
        {
            margin:20px auto;
            
        }
            .onerow b
            {
                width:100px;
            }
        .auto-style1
        {
            width: 78px;
            height: 128px;
        }
    </style>       
</head>
<body>
    <form id="form1" runat="server"  >
        <div style="background-color:#61c1e5;height:590px;width:100%;">
        <div style="height:30px;">
            <asp:ImageButton style="float:right;margin-right:40px;margin-top:20px;" runat="server" ID="ibtn_kefu" ImageUrl="~/Images/QQ.png" OnClick="ibtn_kefu_Click"  BorderColor="#FFCC66" BorderStyle="Solid" BorderWidth="2px" />
            </div>
        <div style="width:500px;height:300px;margin-left:300px; ">
             <div class="onerow">
                <b>姓名：</b><asp:TextBox ID="tb_Name" runat="server" style="margin-left:50px;" Enabled="False"></asp:TextBox>
            </div>
             <div class="onerow">
                <b>身份证号：</b><asp:TextBox ID="tb_Number" runat="server" style="margin-left:20px;" Enabled="False"></asp:TextBox>
            </div>
            <div class="onerow">
               <b>年龄：</b><asp:DropDownList ID="ddl_Age" runat="server" style="width:150px;margin-left:50px;"></asp:DropDownList>
            </div>

                

            <div class="onerow">
                <b>性别：</b><asp:RadioButtonList ID="rbl_Gender" RepeatLayout="Flow"  runat="server" RepeatDirection="Horizontal" style="margin-left:45px;">
                        <asp:ListItem>男</asp:ListItem>
                        <asp:ListItem>女</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <div class="onerow">
                <b>住址：</b><asp:TextBox ID="tb_Addr" runat="server" style="margin-left:52px;"></asp:TextBox>
            </div>
            <div class="onerow">
                <b>电话：</b><asp:TextBox ID="tb_Tel" runat="server" style="margin-left:52px;"></asp:TextBox>
            </div>
            <div class="onerow">
                <b>退休金：</b><asp:TextBox ID="tb_Money" runat="server" style="margin-left:35px;"></asp:TextBox>
            </div>
            <div class="onerow">
                <b>退休前岗位：</b><asp:TextBox ID="tb_Job" runat="server"></asp:TextBox>
            </div>
            
            <div class="onerow">
                <asp:Button ID="btn_Submit" runat="server" Text="提交" OnClick="btn_Submit_Click" style="width:150px;height:25px; margin-left:101px;" BackColor="#3399FF" BorderColor="#3399FF" BorderStyle="Solid" />
                <%--<a  target="_blank" href="http://wpa.qq.com/msgrd?v=3&uin=&site=qq&menu=yes"><img border="0" src="../../Images/QQ.png" alt="您好，请问有什么可以帮助您的吗？" title="您好，请问有什么可以帮助您的吗？"/></a>--%>
                
            </div>
        </div>  
       </div>    
    </form>
</body>
</html>
