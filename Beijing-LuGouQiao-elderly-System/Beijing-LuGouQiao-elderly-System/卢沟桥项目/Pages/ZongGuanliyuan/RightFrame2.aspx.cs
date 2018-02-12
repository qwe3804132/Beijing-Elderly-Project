using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.ZongGuanliyuan
{
    public partial class RightFrame2 : System.Web.UI.Page
    {


        protected void Button22_Click(object sender, EventArgs e)
        {
            TextBox21.Text = null;
            TextBox22.Text = null;
            TextBox23.Text = null;
            DropDownList1.SelectedIndex = 0;
        }

        protected void Button21_Click(object sender, EventArgs e)
        {
            String realname, password;
            int kind, username, community;
            username = int.Parse(TextBox21.Text);
            realname = TextBox22.Text;
            password = TextBox23.Text;
            community = int.Parse(DropDownList1.SelectedValue);
            kind = int.Parse(RadioButtonList11.SelectedValue);
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
                searchAdmin.DataBind();
            }
            else
            {
                webclass.Show(this, "插入失败");
                
            }
        }

   

  

        protected void RadioButtonList11_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (int.Parse(RadioButtonList11.SelectedValue) == 1)
            {
                DropDownList1.SelectedIndex = 0;
                DropDownList1.Enabled = false;
            }
            if (int.Parse(RadioButtonList11.SelectedValue) == 0)
            {
                DropDownList1.Enabled = true;
            }
        }

       

    }
}