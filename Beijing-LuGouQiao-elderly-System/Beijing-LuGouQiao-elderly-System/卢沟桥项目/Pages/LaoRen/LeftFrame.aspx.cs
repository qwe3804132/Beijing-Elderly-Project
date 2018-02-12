using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目.Pages.LaoRen
{
    public partial class LeftFrame : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 优待卡申请
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btn_CardApply_Click(object sender, EventArgs e)
        {
            //创建Session
            Session["ApplyTypes"] = 0;//申请类型为优待卡
            r_info.Src = " CardApply.aspx";
        }

        protected void btn_MoneyApply_Click(object sender, EventArgs e)
        {
            //创建Session
            Session["ApplyTypes"] = 1;//申请类型为老年津贴
            r_info.Src = " MoneyApply.aspx";
        }

        protected void btn_CatdStatus_Click(object sender, EventArgs e)
        {
            r_info.Src = " CardStatus.aspx";
        }

        protected void btn_MoneyStatus_Click(object sender, EventArgs e)
        {
            r_info.Src = " MoneyStatus.aspx";
        }

        protected void btn_MoneyRecord_Click(object sender, EventArgs e)
        {
            r_info.Src = "MoneyRecord.aspx";
        }

        protected void btn_SearchUInfo_Click(object sender, EventArgs e)
        {
            r_info.Src = "SearchUInfo.aspx";
        }


    }
}