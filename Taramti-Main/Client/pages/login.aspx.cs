using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_pages_login : System.Web.UI.Page
{
    
    /*
 * ********************************************************
 * ********************************************************
 אובייקטים שנוצרים:  Cookies["authCookie"] , Cookies["userCookie"] , Session["UserID"]
 סשן יוזר מכיל רק ת.ז!!!
 * ********************************************************
 * ********************************************************
*/
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.Cookies["userCookie"] != null)
        {
            if (Request.Cookies["authCookie"] != null)
            {
                if (Session["UserID"] == null)
                {
                    Session["UserID"] = Request.Cookies["userCookie"].Value;
                }
                DirectTo(int.Parse(Request.Cookies["authCookie"].Value));
            }
        }
    }

    //כפתור לוגין - להשלים הצגת הודעות
    protected void login_BTN_Click(object sender, EventArgs e)
    {
        if (Session["counter"] == null)
        {
            Session["counter"] = 0; //מונה לבדיקת מס' הפעמים שהמשתמש טעה - שליחה לדף איפוס אחרי 5 בדיקות
        }

        UserT temp = new UserT(mail_TB.Text, pass_TB.Text);
        if (temp.CheckLogin()) //בדיקה אם משתמש קיים ופרטים נכונים
        {
            // בדיקה האם המשתמש עם סיסמא זמנית. אם כן - נשלח אותו ליצירת סיסמא חדשה
            if (temp.Password == "000000")
            {
                Server.Transfer("RestorePass.html");
            }
            int auth = temp.CheckAuthDesktop(); //בדיקה אם יש הרשאה לדף ניהול
            Session["UserID"] = temp.UserId;
            if (remember_CB.Checked && auth!=-1)
            {
                SaveCookies(auth,temp.UserId);
            }
            DirectTo(auth);
        }
        else
        {
            int counter = int.Parse(Session["counter"].ToString());
            counter++;
            if (counter >= 5)
            {
                Session.Remove("counter");
                Response.Redirect("forgotPass.html");
                //שליחה לדף איפוס סיסמה
            }
            else
            {

                Session["counter"] = counter;
                //הצגת הודעת שגיאה למשתמש
            }
        }
    }
    
    //יצירת קוקיז - גמור
    private void SaveCookies(int auth, string userID)
    {
        //שמירת ת.ז משתמש בקוקי
        HttpCookie userCookie = new HttpCookie("userCookie", userID);
        userCookie.Expires = DateTime.Now.AddYears(150);
        Response.Cookies.Add(userCookie);

        //שמירת הרשאת המשתמש בקוקי
        HttpCookie authCookie = new HttpCookie("authCookie", auth.ToString());
        authCookie.Expires = DateTime.Now.AddYears(150);
        Response.Cookies.Add(authCookie);

    }

    // להשלים שליחה לדפים המתאימים
    private void DirectTo(int auth)
    {
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