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
        /*
     * ********************************************************
     * ********************************************************
     * להוסיף בדיקת קוקיס וסשנים
     * ********************************************************
     * ********************************************************
    */

    }

    protected void login_BTN_Click(object sender, EventArgs e)
    {
        User temp = new User(mail_TB.Text, pass_TB.Text);
        if (temp.CheckLogin())
        {
            int auth = temp.CheckAuthDesktop();
            Session["User"] = temp;
            if (remember_CB.Checked && auth!=-1)
            {
                SaveCookies();
            }
            switch (auth)
            {
                case 1:
                    Response.Redirect(""); //דף אדמין
                    break;
                case 2:
                    Response.Redirect(""); //דף עמותות
                    break;
                case -1:
                    //הצגת הודעה
                    break;
                default:
                    break;
            }
        }
    }

    private void SaveCookies()
    {
        
    }
}