using System;
using System.Web.UI;
//Download by http://www.codefans.net
public partial class UserValidator_CheckCode : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CheckCode.DrawImage();
    }
}