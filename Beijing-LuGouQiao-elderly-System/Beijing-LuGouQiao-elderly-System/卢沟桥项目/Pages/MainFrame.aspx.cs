using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages
{
    public partial class MainFrame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //leftFrame.Attributes.Add("src", "http://www.baidu.com"); 
            // 0社区  1街道  2总管理 3用户
            if ((int)Session["UTypes"] == 3)//用户
            {
                leftFrame.Attributes.Add("src", "../Pages/LaoRen/LeftFrame.aspx"); 
            }
            if ((int)Session["UTypes"] == 1)//街道
            {
                leftFrame.Attributes.Add("src", "../Pages/JieDaoGuanLi/LeftFrame.aspx");
            }
            if ((int)Session["UTypes"] == 0)//社区
            {
                leftFrame.Attributes.Add("src", "../Pages/SheQuGuanLi/LeftFrame.aspx");
            }
            if ((int)Session["UTypes"] == 2)//管理员
            {
                leftFrame.Attributes.Add("src", "../Pages/ZongGuanliyuan/LeftFrame.aspx");
            }
        }
    }
}