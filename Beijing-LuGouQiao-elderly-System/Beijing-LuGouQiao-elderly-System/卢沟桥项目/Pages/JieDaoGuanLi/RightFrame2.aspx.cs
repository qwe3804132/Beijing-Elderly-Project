using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.JieDaoGuanLi
{
    public partial class RightFrame2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox2.Text = null;
            TextBox3.Text = null;
            TextBox4.Text = null;
            ddlshequID.SelectedIndex = 0;
            //RadioButtonList1.SelectedValue = null;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            String realname, password;
            int kind=0, username, community;
            username = int.Parse(TextBox2.Text);
            realname = TextBox3.Text;
            password = TextBox4.Text;
            community = int.Parse(ddlshequID.SelectedValue);
            //kind = int.Parse(RadioButtonList1.SelectedValue);
            Model.AdminInfo admin = new Model.AdminInfo();
            admin.Name = realname;
            admin.PWD = password;
            admin.Types = kind;
            admin.Number = username;
            admin.CommunityID = community;
            BLL.B_AdminInfo b_admin = new BLL.B_AdminInfo();
            bool result = b_admin.InsertAdmin(admin);
            if (result == true)
            {
                webclass.Show(this, "插入成功");
                GridView1.DataBind();
            }
            else
            {
                webclass.Show(this, "插入失败");
                
            }
        }

    }
}