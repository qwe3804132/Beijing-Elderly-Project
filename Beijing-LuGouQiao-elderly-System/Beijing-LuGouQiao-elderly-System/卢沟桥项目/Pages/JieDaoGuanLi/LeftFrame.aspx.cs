using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.JieDaoGuanLi
{
    public partial class LeftFrame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (((Button)sender).ID == "Button1")
            {
                r_info.Src = " RightFrame.aspx";
            }
            if (((Button)sender).ID == "Button7")
            {
                r_info.Src = " RightFrame2.aspx";
            }
            if (((Button)sender).ID == "Button2")
            {
                r_info.Src = "RightFrame3.aspx";

            }
            if (((Button)sender).ID == "Button8")
            {
                r_info.Src = "RightFrame4.aspx";
            }
            if (((Button)sender).ID == "Button9")
            {
                r_info.Src = "MakeTable.aspx";
            }
            if (((Button)sender).ID == "Button10")
            {
                r_info.Src = "RightFrame6.aspx";
            }
        }

        protected void btn_changepwd_Click(object sender, EventArgs e)
        {
            r_info.Src = "~/ChangePWD.aspx";
        }


    }
}