using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.LaoRen
{
    public partial class CardApplyNext : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            
            BLL.B_ApplyInfo b_apply = new BLL.B_ApplyInfo();

            //判断该用户是否可以申请
            string tishi = "";
            if (b_apply.CanApply((int)Session["UID"], (int)Session["ApplyTypes"],out tishi))
            {
                Model.ApplyInfo model = new Model.ApplyInfo();
                if (tb_Age.Text.Trim() != "")
                {
                    model.Age = Convert.ToInt32(tb_Age.Text);
                }
                model.Address = tb_Addr.Text;
                model.ApplyTime = DateTime.Now;
                model.Gender = rbl_Gender.SelectedItem.Value;
                model.Job = tb_Job.Text.Trim();
                if (tb_Money.Text.Trim() != "")
                {
                    model.Money = Convert.ToSingle(tb_Money.Text);
                }
                model.Tel = tb_Tel.Text.Trim();
                model.Types = (int)Session["ApplyTypes"];
                model.UID = (int)Session["UID"];
                if (tishi == "reapply")
                {
                    if (b_apply.UpdateInfo(model))
                    {
                        //修改对应card或money表
                        if (UpdateCardOrMoney(model))
                        {
                            webclass.Show(this, "更新成功");
                        }
                        else
                        {
                            webclass.Show(this,"更新Card或者Money表的时候出错");
                        }
                    }
                }
                else if (tishi == "apply")
                {
                    //直接申请

                    if (b_apply.WriteInfo(model))
                    {
                        //向card或money表插入数据

                        if (AddCardOrMoney(model))
                        {
                            webclass.Show(this, "提交申请成功");
                        }
                        else
                        {
                            webclass.Show(this, "向Card或者Money表添加数据的时候出错");
                        }
                    }
                }
                else
                {
                    webclass.Show(this, "错误");
                }
            }
            else//用户不可以申请
            { 
                //弹出提示框
                webclass.Show(this, tishi);
            }
        }

        /// <summary>
        /// 更新Card或者Money表格
        /// </summary>
        /// <param name="model"></param>
        protected bool UpdateCardOrMoney(Model.ApplyInfo model)
        {
            switch (model.Types)
            {
                case 0:
                    //更新Card表数据
                    BLL.B_Card b_card = new BLL.B_Card();

                    return b_card.UpdateStatus(model.UID, FirstJudge(model));
                case 1:
                    //更新Money表数据
                    BLL.B_Money b_money = new BLL.B_Money();
                    return b_money.UpdateStatus(model.UID, FirstJudge(model));

                default:
                    return false;
            }
        }

        /// <summary>
        /// 向Card或者Money表格插入新数据
        /// </summary>
        /// <param name="model"></param>
        protected bool AddCardOrMoney(Model.ApplyInfo model)
        {
            switch (model.Types)
            { 
                case 0:
                    //向card表添加数据
                    BLL.B_Card b_card = new BLL.B_Card();

                    return b_card.AddCard(model.UID, FirstJudge(model));
                case 1: 
                    //向Money表中添加数据
                    BLL.B_Money b_money = new BLL.B_Money();

                    return b_money.AddCard(model.UID, FirstJudge(model));
                 

                default:
                    return false;
            }
            
        }
        /// <summary>
        /// 一级审核
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        protected int FirstJudge(Model.ApplyInfo model)
        {
            if (model.Address == null || model.Address == "")
            {
                return 0;
            }
            if (model.Age == null || model.Age < 80)
            {
                return 0;
            }
            if (model.Gender == null || model.Gender == "")
            {
                return 0;
            }
            if (model.Job == null || model.Job == "")
            {
                return 0;
            }
            if (model.Money == null )
            {
                return 0;
            }
            if (model.Tel == null || model.Tel == "")
            {
                return 0;
            }
            if (model.UID == null)
            {
                return 0;
            }
            //通过审核，返回一级审核通过的代码
            return 1;


        }
    }
}