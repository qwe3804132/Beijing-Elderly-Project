using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace 卢沟桥项目.Pages.SheQuGuanLi
{
    public partial class JtLingQu : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "lingqu")
            {
                //获取行号
                BLL.B_Money b_money = new BLL.B_Money() ;
                //webclass.Show(this, selectID.ToString());
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                //int ID = Convert.ToInt32(GridView1.DataKeys[drv.RowIndex].Value);
                //bool result = b_money.updateReceived(ID); //等到添加津贴申请表中的津贴是否领取选项
                int UID = Convert.ToInt32(GridView1.Rows[drv.RowIndex].Cells[0].Text);
                int Money = Convert.ToInt32(GridView1.Rows[drv.RowIndex].Cells[3].Text);
                BLL.B_MoneyRecord b_moneyRecord= new BLL.B_MoneyRecord();
                int AID = Convert.ToInt32(Session["UID"].ToString());
                bool result = b_moneyRecord.AddRecord(UID, AID, Money);
                //webclass.Show(this,ID.ToString());
                if (result == true)
                {
                    webclass.Show(this, "操作成功");
                    GridView1.DataBind();
                }
                else
                {
                    webclass.Show(this, "操作失败");

                }
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                LinkButton lb;
                int UID = Convert.ToInt32(e.Row.Cells[0].Text);
                int mounth = Convert.ToInt32(DateTime.Now.Month.ToString());
                BLL.B_MoneyRecord b_moneyrecord = new BLL.B_MoneyRecord();
                bool result = b_moneyrecord.search(UID,mounth);
                if (result)
                {
                    lb = (LinkButton)(e.Row.FindControl("LinkButton1"));
                    lb.Enabled = false;
                    lb.Text = "已领取";
                    lb.ForeColor = Color.Red;
                }
                else 
                {
                    lb = (LinkButton)(e.Row.FindControl("LinkButton1"));
                    lb.Enabled = true;
                    lb.Text = "领取";
                    lb.ForeColor = Color.Green;
                }
            }
        }
    }
}