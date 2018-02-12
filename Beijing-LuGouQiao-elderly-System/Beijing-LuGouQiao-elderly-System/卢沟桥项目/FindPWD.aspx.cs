using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目
{
    public partial class FindPWD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Find_Click(object sender, EventArgs e)
        {
            if (tb_Name.Text.Trim() == "" || tb_Number.Text.Trim() == "")
            {
                webclass.Show(this, "请填写完整信息");

            }
            else
            {
                BLL.B_AdminInfo b_admin = new BLL.B_AdminInfo();
                Model.AdminInfo model=new Model.AdminInfo();
                try
                {
                     model= b_admin.GetAdminInfo(tb_Name.Text, Convert.ToInt32(tb_Number.Text).ToString());
                    
                }
                catch(Exception err)
                {
                    webclass.Show(this, err.Message);
                }
                if (model != null)
                    {
                       
                        webclass.Show(this, "您的密码是：" + model.PWD);
                        
                    }
                    else
                    {
                        webclass.Show(this, "未找到该管理员信息");
                    }
            }
        }
    }
}