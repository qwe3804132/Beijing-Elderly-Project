<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MoneyApply.aspx.cs" Inherits="卢沟桥项目.Pages.LaoRen.MoneyApply" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <link href="../../CSS/CardApply.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
    </div>
        <p class="title">老年津贴政策:</p>
        <textarea class="text">本市户籍老年人

1.享受对象：60周岁及以上的本市户籍老年人，持北京通-养老助残卡(未发放北京通-养老助残卡前可持北京市老年人优待卡或北京市老年人优待证)。

2.申请条件：凡具有本市户籍的60周岁(含60周岁)以上的老年人均可申请办理《优待卡》，凭此卡可以在全市范围内享受《办法》规定的各项优待内容。凡在北京行政区域内驻军且在北京行政区域内长期居住的军队离退休60周岁(含60周岁)以上的老年人可以办理《优待卡》，享受优待服务。

3.办理流程： 

日常办卡程序 
　　(一)凡符合条件的老年人凭本人身份证到户籍所在地或经常居住地居(村)委会提出个人申请，同时提交近期一寸白底彩色免冠标准照片一张及身份证复印件一份。照片背面用铅笔注明姓名及身份证号码，并与身份证复印件别在一起，填写北京市65周岁以下和65周岁以上(含65周岁)老年人信息登记表，报送街道(乡镇)。 

　　(二)经街道(乡镇)审核和区(县)老龄办核准，交市老龄办办理。 

　　(三)老年人在申请办理优待卡40个工作日后凭身份证原件到申请办理的居(村)委会领取《优待卡》。 

　　(四)部队离退休老年人办理。符合条件的部队离退休老年人需携带一寸白底彩色免冠标准照片一张及离退休证件复印件，到师级以上政治机关提出申请，并填写65周岁以下和65周岁以上(含65周岁)老年人信息登记表(Excel电子表格形式)。由师级以上政治部门审核汇总后出具符合办卡条件证明，统一到辖区区(县)老龄办核准，由区(县)老龄办随其他老年人一并到市老龄办办理。

常住本市的外埠户籍老年人 

1.享受对象：60周岁及以上的常住外埠老年人，持北京通-养老助残卡(未发放北京通-养老助残卡前可持北京市老年人优待卡或北京市老年人优待证)

2.申请条件：在本市行政区域内居住满6个月及以上的外埠60周岁及以上老年人。

3.办理流程：

    (一)符合条件的老年人自愿到经常居住地的社区居委会或村委会提出申请，60至64周岁老年人办理《北京市老年人优待证》，65周岁及以上老年人办理《北京市老年人优待卡》。

　　(二)符合条件的老年人办理《优待卡(证)》时须提交在本市行政区域内居住满6个月及以上的北京市公安局统一印制、在暂住地公安派出所办理的《暂住证》和复印件一份，其它办理程序和办理时间参照北京市户籍老年人办理《优待卡(证)》的程序和时间办理。

        </textarea><br />
<br />
        <div class="bottom">
        <asp:CheckBox  ID="cbx_agree" Text="我已阅读并同意" runat="server" Font-Size="12pt" ForeColor="#b1b1b1" Height="25px" />
        <asp:Button  ID="btn_ok" runat="server" Text="开始申请" OnClick="btn_ok_Click" BackColor="#3399FF" BorderColor="#3399FF" BorderStyle="Solid" ForeColor="White" />
        </div>
    </form>
</body>
</html>
