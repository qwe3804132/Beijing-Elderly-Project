using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.LaoRen
{
    public partial class CardApply : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_ok_Click(object sender, EventArgs e)
        {
            if (!cbx_agree.Checked)
            {
                webclass.Show(this, "请确认已阅读并同意相关政策");
                return;
            }
            Response.Redirect("ApplyNext.aspx");
        }
    }
}