using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.JieDaoGuanLi
{
    public partial class MakeTable : System.Web.UI.Page
    {

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            int ID = int.Parse(((DropDownList)sender).SelectedValue);

            SqlDataSource2.SelectCommand = "SELECT moneyRecord.* FROM UInfo INNER JOIN moneyRecord ON UInfo.ID = moneyRecord.UID INNER JOIN Community ON Community.ID = UInfo.CommunityID where Community.ID=" + ID;
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DropDownList1.SelectedIndex = -1;
            }
        }
    }
}