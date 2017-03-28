using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_pages_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void login_BTN_Click(object sender, EventArgs e)
    {
        User temp = new User(mail_TB.Text, pass_TB.Text);
        if (temp.CheckLogin())
        {

        }
    }
}