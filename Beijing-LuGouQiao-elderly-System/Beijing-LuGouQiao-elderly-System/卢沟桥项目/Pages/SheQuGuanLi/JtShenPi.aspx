<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JtShenPi.aspx.cs" Inherits="卢沟桥项目.Pages.SheQuGuanLi.JtShenPi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style type="text/css">
        .btn {
            background-color:#b1babf;
            color:white;
            width:75px;
            height:30px;
            margin-left:75px;
        }
         .auto-style1 {
             text-align: center;
             color: #FF0066;
         }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="position:absolute">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" DataKeyNames="ID" DataSourceID="SqlDataSource1" ForeColor="Black" GridLines="None" OnRowCommand="GridView1_RowCommand" EmptyDataText="没有需要审批的内容" Height="128px" ShowHeaderWhenEmpty="True" Width="793px" AllowPaging="True" AllowSorting="True">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="ID" InsertVisible="False" ReadOnly="True" SortExpression="ID" Visible="False" />
                <asp:BoundField DataField="UID" HeaderText="申请者ID" SortExpression="UID" />
                <asp:BoundField DataField="Name" HeaderText="姓名" SortExpression="Name" />
                <asp:BoundField DataField="MID" HeaderText="津贴类别" SortExpression="MID" />
                <asp:BoundField DataField="Status" HeaderText="申请状态" SortExpression="Status" />
                <asp:BoundField DataField="ANumber1" HeaderText="社区审核员工号" SortExpression="ANumber1" />
                <asp:BoundField DataField="ANumber2" HeaderText="街道审核员工号" SortExpression="ANumber2" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="false" CommandName="tongyi" Text="同意申请"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" CommandName="reject" Text="拒绝申请"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="LinkButton3" runat="server" CausesValidation="false" CommandName="search" Text="查看信息"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div class="auto-style1">
                    没有需要审批的内容</div>
            </EmptyDataTemplate>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
            <RowStyle HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        </div>
        <div style="position:absolute; margin-top:10px;">
         <asp:Panel ID="Panel1" runat="server" Height="225px" style="margin-left: 168px;position:absolute;background-color:#dee1e2"  Visible="False" Width="450px">
            <asp:TextBox ID="TextBox1" runat="server" Height="170px" Width="445px" style="border:none" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="ok" runat="server" Text="确定" OnClick="ok_Click" class="btn" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="cancel" runat="server" Text="取消" OnClick="cancel_Click" class="btn" />
        </asp:Panel>
         </div>
         <div style="position:absolute">
           <asp:Panel ID="Panel2"  runat="server" Height="250px" style="margin-left: 168px;position:absolute; top: 47px; left: 91px; width: 300px; margin-top: 11px;" Visible="False">
            <table  border="1" style=" background-color:white;">
                <tr>
                    <td>
                         申请ID:
                    </td>
                    <td>
                        <asp:Label ID="label1" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        用户ID:
                    </td>
                    <td>
                        <asp:Label ID="label2" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        申请时间:
                    </td>
                    <td>
                         <asp:Label ID="label3" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>年龄:</td>
                    <td>
                        <asp:Label ID="label4" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        性别:
                    </td>
                    <td>
                        <asp:Label ID="label5" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                        住址:
                    </td>
                    <td>
                         <asp:Label ID="label6" runat="server"></asp:Label>
                    </td>
                </tr>
                 <tr>
                    <td>
                         电话号码:
                    </td>
                    <td>
                        <asp:Label ID="label7" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        工作:
                    </td>
                    <td>
                         <asp:Label ID="label8" runat="server"></asp:Label>
                    </td>
                </tr>
                  <tr>
                    <td>
                        退休金:
                    </td>
                    <td>
                        <asp:Label ID="label9" runat="server"></asp:Label>
                </tr>
                  <tr>
                    <td>
                        申请类别:
                    </td>
                    <td>
                         <asp:Label ID="label10" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr style="background-color:#dee1e2;">
                    <td colspan="2">
                        <asp:Button ID="click" runat="server" OnClick="click_Click" Text="确定" class="btn"/>
                    </td>
                </tr>
            </table>
           
         
            
        </asp:Panel>
             </div>
              <div style="position:absolute">
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT Money.ID, Money.UID, Money.MID, Money.Status, Money.ANumber1, Money.ANumber2, Money.Reason, UInfo.CommunityID, UInfo.Name FROM Money INNER JOIN UInfo ON Money.UID = UInfo.ID WHERE (Money.Status = @Status) AND (UInfo.CommunityID = @CommunityID)">
            <SelectParameters>
                <asp:Parameter DefaultValue="1" Name="Status" Type="Int32" />
                <asp:SessionParameter DefaultValue="2" Name="CommunityID" SessionField="CommunityID" />
            </SelectParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
