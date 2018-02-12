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
  

        protected void Button11_Click(object sender, EventArgs e)
        {
            if (((Button)sender).ID == "Button11")
            {
                r_info11.Src = " RightFrame2.aspx";
            }
            if (((Button)sender).ID == "Button12")
            {
                r_info11.Src = " RightFrame1.aspx";
            }
          
        }

        protected void btn_change_Click(object sender, EventArgs e)
        {
            r_info11.Src = "~/ChangePWD.aspx";
        }

     


    }
}