using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace 卢沟桥项目.Pages.JieDaoGuanLi
{
    public partial class RightFrame4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                for (int i = DateTime.Now.Year; i > 2000; i--)
                {
                    ddl_year.Items.Add(i.ToString());
                    ddl_year2.Items.Add(i.ToString());
                }
                //if (GridView1.Rows.Count > 0)
                //{
                //    Button1.Visible = true;
                //}
                //else
                //{
                //    Button1.Visible = false;
                //}
            }
           
        }
        //SELECT ApplyInfo.ID, ApplyInfo.UID, ApplyInfo.ApplyTime, ApplyInfo.Age, ApplyInfo.Gender, ApplyInfo.Address, ApplyInfo.Tel, ApplyInfo.Job, ApplyInfo.Money, ApplyInfo.Types FROM ApplyInfo INNER JOIN Card ON ApplyInfo.UID = Card.UID WHERE (Card.Status = 5) AND (ApplyInfo.Types = 0)
        protected void Button1_Click(object sender, EventArgs e)
        {
            BLL.B_Card b_card = new BLL.B_Card();
            bool ok=b_card.UpdateByStatusAndType(5, 2);
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "gb2312";
            Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            Response.AppendHeader("content-disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode("数据导出", System.Text.Encoding.UTF8) + ".xls\"");
            Response.ContentType = "Application/ms-excel";
            System.IO.StringWriter StringWriter = new System.IO.StringWriter();
            System.Web.UI.HtmlTextWriter HtmlTextWriter = new System.Web.UI.HtmlTextWriter(StringWriter);
            this.GridView1.RenderControl(HtmlTextWriter);
            Response.Output.Write(StringWriter.ToString());
            Response.Flush();
            Response.End();
        }
        //protected void Button1_Click(object sender, EventArgs e)
        //{
        //    ExcelOut(this.GridView1);
        //}

        public override void VerifyRenderingInServerForm(Control control)
        {
            // Confirms that an HtmlForm control is rendered for
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
         
        }

        protected void btn_select_Click(object sender, EventArgs e)
        {

            DateTime dt1 = DateTime.ParseExact(ddl_year.SelectedValue+ddl_month.SelectedValue+"01", "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            DateTime dt2 = DateTime.ParseExact(ddl_year2.SelectedValue + ddl_month2.SelectedValue + "01", "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
            string sql = " SELECT ApplyInfo.*, UInfo.Name FROM ApplyInfo INNER JOIN Card ON ApplyInfo.UID = Card.UID INNER JOIN UInfo ON ApplyInfo.UID = UInfo.ID WHERE (Card.Status = 5) AND (ApplyInfo.Types = 0) AND (Card.CardStatus = 1) AND Card.GetTimes > '" + dt1.ToString() + "' AND Card.GetTimes < '" + dt2.ToString()+"'";
            SqlDataSource1.SelectCommand = sql;
                
            //SqlDataSource2.SelectCommand = "SELECT moneyRecord.* FROM UInfo INNER JOIN moneyRecord ON UInfo.ID = moneyRecord.UID INNER JOIN Community ON Community.ID = UInfo.CommunityID where Community.ID=" + ID;
            GridView1.DataBind();
        }

    

 
    }
}