using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.SheQuGuanLi
{
    public partial class YdkShenPin : System.Web.UI.Page
    {
        private static int selectID;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            int row = ((GridViewRow)((Button)sender).NamingContainer).RowIndex;
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "tongyi")
            {
                //获取行号
                BLL.B_Card b_card = new BLL.B_Card();
                //webclass.Show(this, selectID.ToString());
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                int ID = Convert.ToInt32(GridView1.DataKeys[drv.RowIndex].Value);
                int AID=Convert.ToInt32(Session["UID"].ToString());
                bool result = b_card.updateReasonSHE("",ID,AID,3);
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
            if (e.CommandName == "reject")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                int ID = Convert.ToInt32(GridView1.DataKeys[drv.RowIndex].Value);//专家ID
                Panel1.Visible = true;
                selectID = ID;
                //webclass.Show(this,selectID.ToString());
            }
            if (e.CommandName == "search")
            {
                GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                int ID = Convert.ToInt32(GridView1.DataKeys[drv.RowIndex].Value);//专家ID
                int UID = Convert.ToInt32(GridView1.Rows[drv.RowIndex].Cells[1].Text);
                BLL.B_ApplyInfo b_apply = new BLL.B_ApplyInfo();
                //webclass.Show(this,ID.ToString());
                Model.ApplyInfo applyInfo = new Model.ApplyInfo();
                applyInfo = b_apply.getInfo(UID, 0);
                label1.Text = applyInfo.Id.ToString();
                label2.Text = applyInfo.UID.ToString();
                label3.Text = applyInfo.ApplyTime.ToString();
                label4.Text = applyInfo.Age.ToString();
                label5.Text = applyInfo.Gender.ToString();
                label6.Text = applyInfo.Address.ToString();
                label7.Text = applyInfo.Tel.ToString();
                label8.Text = applyInfo.Job.ToString();
                label9.Text = applyInfo.Money.ToString();
                label10.Text = applyInfo.Types.ToString();
                Panel2.Visible = true;
            }
        }
        protected void ok_Click(object sender, EventArgs e)
        {
            String text = TextBox1.Text;
            BLL.B_Card b_card = new BLL.B_Card();
            //webclass.Show(this, selectID.ToString());
            //bool result = b_card.updateReason(text, selectID, 2);
            int AID = Convert.ToInt32(Session["UID"].ToString());
            bool result = b_card.updateReasonSHE(text, selectID, AID, 2);
            if (result == true)
            {
                webclass.Show(this, "操作成功");
                GridView1.DataBind();
                Panel1.Visible = false;
            }
            else
            {
                webclass.Show(this, "操作失败");

            }

        }

        protected void cancel_Click(object sender, EventArgs e)
        {
            Panel1.Visible = false;
        }
        protected void click_Click(object sender, EventArgs e)
        {
            Panel2.Visible = false;
        }
    }
}