using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace 卢沟桥项目
{
    public static class webclass
    {
        #region 打开关闭窗体
        /// <summary>
        /// 打开新窗体
        /// 调用Response.Redirect("query_Detail.aspx", "_blank", "menubar=0,width=850,height=590");
        /// </summary>
        /// <param name="url"></param>
        /// <param name="target"></param>
        /// <param name="windowFeatures"></param>
        public static void opennewpage(string url, string target, string windowFeatures)
        {
            HttpContext context = HttpContext.Current;
            if ((String.IsNullOrEmpty(target) || target.Equals("_self", StringComparison.OrdinalIgnoreCase)) && String.IsNullOrEmpty(windowFeatures))
            {
                context.Response.Redirect(url);
            }
            else
            {
                Page page = (Page)context.Handler;
                if (page == null)
                {
                    throw new InvalidOperationException("Cannot redirect to new window outside Page context.");
                } url = page.ResolveClientUrl(url);
                string script;
                if (!String.IsNullOrEmpty(windowFeatures))
                {
                    script = @"window.open(""{0}"", ""{1}"", ""{2}"");";
                }
                else
                {
                    script = @"window.open(""{0}"", ""{1}"");";
                }
                script = String.Format(script, url, target, windowFeatures);
                ScriptManager.RegisterStartupScript(page, typeof(Page), "Redirect", script, true);
            }
        }

        /// <summary>
        /// 关闭页面
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        public static void closepage(System.Web.UI.Page thisPage)
        {
            thisPage.ClientScript.RegisterClientScriptBlock(typeof(string), "create", "<script>window.opener=null;window.close();</script>");

        }
        #endregion

        #region 消息提示框
        /// <summary>
        /// 显示消息提示对话框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void Show(System.Web.UI.Page thisPage, string msg)
        {
            thisPage.ClientScript.RegisterClientScriptBlock(typeof(string), "create", "<script>alert('" + msg + "')</script>");
            //  System.Web.HttpContext.Current.Response.Write("<script>alert('" + msg + "')</script>");

        }
        /// <summary>
        /// 控件点击 消息提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowUpdatePanel(System.Web.UI.UpdatePanel Control, string msg)
        {
            //Control.Attributes.Add("onClick","if (!window.confirm('"+msg+"')){return false;}");
            //Control.Attributes.Add("onclick", "return confirm('" + msg + "');");
            System.Web.UI.ScriptManager.RegisterStartupScript(Control, Control.GetType(), "unReport", "alert('" + msg + "');", true);
        }
        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowUpdatePanelConfirm(System.Web.UI.UpdatePanel Control, string msg)
        {
           
            System.Web.UI.ScriptManager.RegisterOnSubmitStatement(Control, Control.GetType(), "test", "return confirm('" + msg + "');");
            // ScriptManager.RegisterOnSubmitStatement(UpdatePanel1, this.GetType(),"test", "return window.confirm('test')");

        }
        /// <summary>
        /// 控件点击 消息确认提示框
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        public static void ShowConfirm(System.Web.UI.WebControls.WebControl Control, string msg)
        { Control.Attributes.Add("onclick", "return confirm('" + msg + "');"); }

        public static void ShowConfirm(string strMsg, string strUrl_Yes, string strUrl_No)
        {
            System.Web.HttpContext.Current.Response.Write("<Script Language='JavaScript'>if ( window.confirm('" + strMsg + "')) {  window.location.href='" + strUrl_Yes +
                              "' } else {window.location.href='" + strUrl_No + "' };</script>");
        }
        /// <summary>
        /// 显示消息提示对话框，并进行页面跳转
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="msg">提示信息</param>
        /// <param name="url">跳转的目标URL</param>
        public static void ShowAndRedirect(System.Web.UI.Page page, string msg, string url)
        {
            StringBuilder Builder = new StringBuilder();
            Builder.Append("<script language='javascript' defer>");
            Builder.AppendFormat("alert('{0}');", msg);
            Builder.AppendFormat("top.location.href='{0}'", url);
            Builder.Append("</script>");
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", Builder.ToString());
        }
        /// <summary>
        /// 输出自定义脚本信息
        /// </summary>
        /// <param name="page">当前页面指针，一般为this</param>
        /// <param name="script">输出脚本</param>
        public static void ResponseScript(System.Web.UI.Page page, string script)
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "message", "<script language='javascript' defer>" + script + "</script>");

        }
        #endregion

        #region CheckBoxList操作
        /// <summary>
        /// 返回CheckBoxList中选中项的SelectedItem
        /// </summary>
        /// <param name="cbl"></param>
        /// <returns></returns>
        public static string getCheckBoxListValue(CheckBoxList cbl)
        {
            string s = "";
            for (int i = 0; i < cbl.Items.Count; i++)
            {
                if (cbl.Items[i].Selected)
                {
                    s += i.ToString() + ",";
                }
            }
            return s.Substring(0, s.Length - 1);
        }
        #endregion

        #region URL传递参数
        /// <summary>
        /// 添加URL参数
        /// </summary>
        public static string AddParam(string url, string paramName, string value)
        {
            Uri uri = new Uri(url);
            if (string.IsNullOrEmpty(uri.Query))
            {
                string eval = HttpContext.Current.Server.UrlEncode(value);
                return String.Concat(url, "?" + paramName + "=" + eval);
            }
            else
            {
                string eval = HttpContext.Current.Server.UrlEncode(value);
                return String.Concat(url, "&" + paramName + "=" + eval);
            }
        }
        /// <summary>
        /// 更新URL参数
        /// </summary>
        public static string UpdateParam(string url, string paramName, string value)
        {
            string keyWord = paramName + "=";
            int index = url.IndexOf(keyWord) + keyWord.Length;
            int index1 = url.IndexOf("&", index);
            if (index1 == -1)
            {
                url = url.Remove(index, url.Length - index);
                url = string.Concat(url, value);
                return url;
            }
            url = url.Remove(index, index1 - index);
            url = url.Insert(index, value);
            return url;
        }
        #endregion
    }
}