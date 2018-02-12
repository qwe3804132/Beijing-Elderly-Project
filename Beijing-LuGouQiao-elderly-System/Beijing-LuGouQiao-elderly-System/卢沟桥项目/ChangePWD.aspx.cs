using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目
{
    public partial class ChangePWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Change_Click(object sender, EventArgs e)
        {
            BLL.B_AdminInfo b_admin = new BLL.B_AdminInfo();

            Model.AdminInfo ainfo = b_admin.GetAdminInfo((int)Session["UID"]);
            if (ainfo != null)
            {
                if (ainfo.PWD == tb_old.Text)
                {
                    if (tb_p1.Text.Trim() == tb_p1.Text.Trim())
                    {
                        bool result = b_admin.ChangePWD(tb_p1.Text.Trim(), (int)Session["UID"]);
                        if (result == true)
                        {
                            webclass.Show(this, "修改成功");
                        }
                        else
                        {
                            webclass.Show(this, "修改失败");
                        }
                    }
                    else
                    {
                        webclass.Show(this, "密码不一致");
                    }
                }
                else
                {
                    webclass.Show(this, "密码错误");
                }
            }
            else
            {
                webclass.Show(this, "用户信息不存在，请重新登陆");
            }
           
        }
    }
}