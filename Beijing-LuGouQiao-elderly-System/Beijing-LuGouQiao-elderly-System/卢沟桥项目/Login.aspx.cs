using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rbl_UserType.SelectedIndex = 0;
            }
        }

        protected void btn_login_Click(object sender, EventArgs e)
        {
        #region 申请者登陆
            if (rbl_UserType.SelectedIndex == 0)
            {
                if (tb_Name.Text.Trim() != "" && tb_Password.Text.Trim() != "")
                {
                    BLL.B_UInfo b_uinfo = new BLL.B_UInfo();
                    int id = b_uinfo.login(tb_Name.Text.Trim(), tb_Password.Text.Trim());
                    if (id == -1)//姓名不存在
                    {
                        webclass.Show(this, "用户不存在");
                    }
                    else if (id == 0)//密码错误
                    {
                        webclass.Show(this, "密码错误");
                    }
                    else//登陆成功
                    {
                        //创建Session
                        Session["UID"] = id;
                        Session["UTypes"] =3;
                        //跳转页面
                        Response.Redirect("./Pages/MainFrame.aspx");
                    }
                }
            }
        #endregion
        #region 管理员登陆
            else
            {
                //管理员登陆
                if (tb_Name.Text.Trim() != "" && tb_Password.Text.Trim() != "")
                {
                    BLL.B_AdminInfo b_admin = new BLL.B_AdminInfo();
                    try
                    {
                        int[] idAndTypes = b_admin.login(tb_Name.Text, tb_Password.Text);
                        if (idAndTypes[0] == -1)//姓名不存在
                        {
                            webclass.Show(this, "用户不存在");
                        }
                        else if (idAndTypes[0] == 0)//密码错误
                        {
                            webclass.Show(this, "密码错误");
                        }
                        else//登陆成功
                        {
                            //创建Session
                            Session["UID"] = idAndTypes[0];
                            Session["UTypes"] = idAndTypes[1];
                            Session["CommunityID"] = b_admin.GetAdminInfo(idAndTypes[0]).CommunityID;//创建所属社区ID的Session
                            //跳转页面
                            Response.Redirect("./Pages/MainFrame.aspx");
                            //if (idAndTypes[1] == 0)//社区管理员
                            //{
                            //    Response.Redirect("http://www.qq.com");
                            //}
                            //else if (idAndTypes[1] == 1)//街道管理员
                            //{

                            //}
                            //else//总管理员
                            //{

                            //}
                        }
                    }
                    catch (Exception err)
                    {
                            webclass.Show(this, err.Message);
                    }
                }
            }
            #endregion
        }

        

    }
}