using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.SheQuGuanLi
{
    public partial class LeftFrame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            r_info.Src = "YdkShenPin.aspx";
        }

        protected void Button7_Click(object sender, EventArgs e)
        {
            r_info.Src = "JtShenpi.aspx";
        }
        protected void Button8_Click(object sender, EventArgs e)
        {
            r_info.Src = "YdkLingQu.aspx";
        }
        protected void Button9_Click(object sender, EventArgs e)
        {
            r_info.Src = "JtLingQu.aspx";
        }

        protected void btn_change_Click(object sender, EventArgs e)
        {
            r_info.Src = "~/ChangePWD.aspx";
        }
    }
}