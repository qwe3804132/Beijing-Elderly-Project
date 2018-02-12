using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.LaoRen
{
    public partial class ApplyNext : System.Web.UI.Page
    {
        Model.ApplyInfo model = new Model.ApplyInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                ddl_Age.Items.Clear();
                ddl_Age.Items.Add(" ");
                for(int i=65;i<150;i++)
                {
                    ddl_Age.Items.Add(i.ToString());
                }
                BLL.B_ApplyInfo b_apply = new BLL.B_ApplyInfo();
                model = b_apply.getInfo((int)Session["UID"], (int)Session["ApplyTypes"]);
                if (model != null)
                {
                    for(int i=0;i<ddl_Age.Items.Count;i++)
                    {
                        if(ddl_Age.Items[i].Value==model.Age.ToString())
                        {
                            ddl_Age.SelectedIndex = i;
                        }
                    }
                    BLL.B_UInfo b_uinfo = new BLL.B_UInfo();
                    Model.UInfo uinfo = b_uinfo.GetUInfo(model.UID);
                    if (uinfo != null)
                    {
                        tb_Name.Text = uinfo.Name;
                        tb_Number.Text = uinfo.Number;
                    }
                    tb_Addr.Text = model.Address;
                    rbl_Gender.SelectedValue = model.Gender;
                    tb_Job.Text = model.Job;
                    tb_Money.Text = model.Money.ToString();
                    tb_Tel.Text = model.Tel;
                }
            }
        }

        protected void btn_Submit_Click(object sender, EventArgs e)
        {
            
            BLL.B_ApplyInfo b_apply = new BLL.B_ApplyInfo();

            //判断该用户是否可以申请
            string tishi = "";
            if (b_apply.CanApply((int)Session["UID"], (int)Session["ApplyTypes"],out tishi))
            {
                Model.ApplyInfo model = new Model.ApplyInfo();

                if (ddl_Age.SelectedIndex>0)
                {
                    model.Age = Convert.ToInt32(ddl_Age.SelectedItem.Value);
                }
                model.Address = tb_Addr.Text;
                model.ApplyTime = DateTime.Now;
                if (rbl_Gender.SelectedIndex > -1)
                {
                    model.Gender = rbl_Gender.SelectedItem.Value;
                }
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
                    return b_money.AddMoney(model, FirstJudge(model));
                   
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
            if (model.Age == null || model.Age < 65)
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

        protected void ibtn_kefu_Click(object sender, EventArgs e)
        {
            Response.Redirect("tencent://message/?uin=12345678");
        }
    }
}