using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.LaoRen
{
    public partial class SearchUInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BLL.B_UInfo b_uinfo = new BLL.B_UInfo();
                Model.UInfo model = b_uinfo.GetUInfo((int)Session["UID"]);
                if (model != null)
                {
                    BLL.B_Community b_com = new BLL.B_Community();
                    string CommunityName = b_com.GetCommunityName(model.CommunityID);
                    //给页面赋值
                    tb_Name.Text = model.Name;
                    tb_Number.Text = model.Number;
                    tb_Birthday.Text = model.Birthday.ToShortDateString().ToString();
                    tb_Community.Text = CommunityName;
                }
            }
        }
    }
}