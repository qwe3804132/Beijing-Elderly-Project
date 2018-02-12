using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace 卢沟桥项目.Pages.SheQuGuanLi
{
    public partial class YdkLingQu : System.Web.UI.Page
    {
        private static int selectID;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void GridView2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            
            if (e.CommandName == "queding")
            { 
                 //获取行号
                //webclass.Show(this, selectID.ToString());
                GridViewRow drv = ((GridViewRow)(((Button)(e.CommandSource)).Parent.Parent));
                DropDownList dd = (DropDownList)(GridView2.Rows[drv.RowIndex].FindControl("DropDownList1"));
                int index = dd.SelectedIndex;
                if (index == 1)
                {
                    //获取行号
                    BLL.B_Card b_card = new BLL.B_Card();
                    //webclass.Show(this, selectID.ToString());
                    //GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                    int ID = Convert.ToInt32(GridView2.DataKeys[drv.RowIndex].Value);
                    bool result = b_card.UpdateCard_lingqu(ID);
                    //webclass.Show(this,ID.ToString());
                    if (result == true)
                    {
                        webclass.Show(this, "操作成功");
                        GridView2.DataBind();
                    }
                    else
                    {
                        webclass.Show(this, "操作失败");

                    }
                }
                if (index == 0)
                {
                    //获取行号
                    BLL.B_Card b_card = new BLL.B_Card();
                    //webclass.Show(this, selectID.ToString());
                    //GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                    int ID = Convert.ToInt32(GridView2.DataKeys[drv.RowIndex].Value);
                    bool result = b_card.UpdateCard_dailingqu(ID);
                    //webclass.Show(this,ID.ToString());
                    if (result == true)
                    {
                        webclass.Show(this, "操作成功");
                        GridView2.DataBind();
                    }
                    else
                    {
                        webclass.Show(this, "操作失败");
                    }
                }
                if (index == 2)
                {
                    //获取行号
                    BLL.B_Card b_card = new BLL.B_Card();
                    //webclass.Show(this, selectID.ToString());
                    //GridViewRow drv = ((GridViewRow)(((LinkButton)(e.CommandSource)).Parent.Parent));
                    int ID = Convert.ToInt32(GridView2.DataKeys[drv.RowIndex].Value);
                    bool result = b_card.UpdateCard_daizhizuo(ID);
                    //webclass.Show(this,ID.ToString());
                    if (result == true)
                    {
                        webclass.Show(this, "操作成功");
                        GridView2.DataBind();
                    }
                    else
                    {
                        webclass.Show(this, "操作失败");
                    }
                }
            }
        }

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                //LinkButton lb;
                int CardStatus = Convert.ToInt32(e.Row.Cells[4].Text);
               
                /*if (CardStatus==2)
                {
                    //e.Row.Cells[4].Text = "待制作";
                    //return;
                    lb = (LinkButton)(e.Row.FindControl("LinkButton1"));
                    lb.Enabled =true;
                    lb.Text = "优待卡制作完成";
                    lb.ForeColor=Color.Blue;
                    lb.CommandName="dailingqu";
                    lb.Visible = true;
                    return;
                }*/
                if (CardStatus==3)
                {
                    e.Row.Cells[4].Text = "制作完成，待领取";
                    e.Row.Cells[4].ForeColor = Color.Green;
                    return;
                    /*lb = (LinkButton)(e.Row.FindControl("LinkButton1"));
                    lb.Enabled =true;
                    lb.Text = "领取";
                    lb.ForeColor=Color.Green;
                    lb.CommandName = "lingqu";
                    return;*/
                }
                if (CardStatus == 4) 
                {
                    e.Row.Cells[4].Text = "已领取";
                    e.Row.Cells[4].ForeColor = Color.Red;
                    return;
                    /*lb = (LinkButton)(e.Row.FindControl("LinkButton1"));
                    lb.Enabled = false;
                    lb.Text = "已领取";
                    lb.ForeColor=Color.Red;
                    return;*/
                }
                /*if (CardStatus == 1)
                {
                    lb = (LinkButton)(e.Row.FindControl("LinkButton1"));
                    lb.Enabled = false;
                    lb.Text = "审批完成";
                    lb.ForeColor = Color.Black;
                    return;
                }
                if (CardStatus == 2)
                {
                    lb = (LinkButton)(e.Row.FindControl("LinkButton1"));
                    lb.Enabled = false;
                    lb.Text = "审批中";
                    lb.ForeColor = Color.Black;
                    return;
                }*/
                else
                {
                    e.Row.Cells[4].Text = "待制作";
                    e.Row.Cells[4].ForeColor = Color.Black;
                    return;
                    /*lb = (LinkButton)(e.Row.FindControl("LinkButton1"));
                    lb.Visible = false;
                    return;*/
                }
            }
        }
    }
}