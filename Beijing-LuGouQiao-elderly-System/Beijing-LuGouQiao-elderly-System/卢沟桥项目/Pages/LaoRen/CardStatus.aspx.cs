using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.LaoRen
{
    public partial class CardStatus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int uid = (int)Session["UID"];
                BLL.B_Card b_card = new BLL.B_Card();
                Model.Card model= b_card.GetMoney(uid);//获取审核信息
                if (model != null)
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
                            //查看制卡状态
                            switch (model.CardStatus)
                            { 
                                case 0:
                                case 1:
                                    lb_zktypes.Text = "";
                                    break;
                                case 2:
                                    lb_zktypes.Text = "优待卡制作中...";
                                    break;
                                case 3:
                                    lb_zktypes.Text = "优待卡已制作完成，待领取！";
                                    break;
                                case 4:
                                    lb_zktypes.Text = "已领取！";
                                    lb_zktypes.ForeColor = System.Drawing.Color.Red;
                                    break;
                                default:
                                    break;

                            }

                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    webclass.Show(this, "您还未申请优待卡，快去申请吧！");
                }
            }
        }
    }
}