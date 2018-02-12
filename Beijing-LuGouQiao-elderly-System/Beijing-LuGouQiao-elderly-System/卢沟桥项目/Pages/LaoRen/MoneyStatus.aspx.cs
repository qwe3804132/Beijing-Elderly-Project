using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.LaoRen
{
    public partial class MoneyStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uid = (int)Session["UID"];
                BLL.B_Money b_money = new BLL.B_Money();
                Model.Money model= b_money.GetMoney(uid);//获取审核信息
                if (model != null)//如果存在审核信息
                {
                    switch (model.Status)
                    {
                        case 0://一级审核失败
                            lb_Status.Text = "数据不全，一级审核失败，请填写完善资料";
                            break;
                        case 1://一级审核成功等待二级审核
                            lb_Status.Text = "一级审核成功，正在等待二级审核";
                            break;
                        case 2://二级审核失败
                            lb_Status.Text = "二级审核失败...";
                            lb_Reason.Text = model.Reason;
                            lb_ANumber1.Text = model.ANumber1.ToString();
                            lb_Reason0.Visible = true;
                            break;
                        case 3://二级审核成功等待三级审核
                            lb_Status.Text = "二级审核成功，正在等待三级审核";
                            lb_ANumber1.Text = model.ANumber1.ToString();
                            break;
                        case 4://三级审核失败
                            lb_Status.Text = "三级审核失败...";
                            lb_ANumber1.Text = model.ANumber1.ToString();
                            lb_ANumber2.Text = model.ANumber2.ToString();
                            lb_Reason.Text = model.Reason;
                            lb_Reason0.Visible = true;
                            break;
                        case 5://审核成功
                            lb_Status.Text = "恭喜你，审核通过！";
                            lb_ANumber1.Text = model.ANumber1.ToString();
                            lb_ANumber2.Text = model.ANumber2.ToString();
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    
                    webclass.Show(this, "您还未申请老年津贴，快去申请吧！");
                    
                }
                
            }
        }
    }
}