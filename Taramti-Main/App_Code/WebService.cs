using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

/// <summary>
/// Summary description for WebService
/// 
/// 
/// NOCOOKIE במידה ואין קוקיז, נחזיר 
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService
{

    public WebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    // מתודה להחזרת פרטי עמותה ספציפים ע"פ קוד עמותה
    [WebMethod]
    public Voluntary_association GetAssociationInfo(string code)
    {
        // Voluntary_association V = new Voluntary_association();
        DataTable DT = new DataTable();
        List<string> L = Voluntary_association.GetAssociationByCode(code);

        if (DT.Rows.Count > 0)
        {
            return new Voluntary_association(DT.Rows[0][0].ToString(), DT.Rows[0][1].ToString(), DT.Rows[0][2].ToString());
        }
        else
        {
            return new Voluntary_association();
        }
    }

    // מתודה להחזרת כלל העמותות
    [WebMethod]
    public List<Voluntary_association> GetAllAssociations()
    {
        // Voluntary_association V = new Voluntary_association();
        DataTable DT = new DataTable();
        List<Voluntary_association> L = Voluntary_association.GetAllAssociations();
        if (DT.Rows.Count > 0)
        {
            //return  new Voluntary_association(DT.Rows[0][0].ToString(), DT.Rows[0][1].ToString(), DT.Rows[0][2].ToString());
            return L;
        }
        else
        {
            return L;
        }
    }

    [WebMethod]
    public string CheckValidUser(string id, string mail)
    {
        UserT temp_user = new UserT();
        temp_user.Mail = mail;
        temp_user.UserId = id;
        if (temp_user.CheckForResetPass())
        {
            temp_user.SendMail();//שליחת מייל
            return "true";
        }
        return "false";
    }

    [WebMethod]
    public string CheckInDatabase(string id, string mail)
    {
        JavaScriptSerializer j = new JavaScriptSerializer();
        UserT temp_user = new UserT();
        temp_user.Mail = mail;
        temp_user.UserId = id;
        if (temp_user.CheckForResetPass())
        {
            temp_user.GetUserName();
            return j.Serialize(temp_user);
            //return temp_user.FirstName + " " + temp_user.LastName;
        }
        return "false";
    }

    [WebMethod]
    public string AddMursheAssoc(string id, int assocCode)
    {
        if (!CheckMursheAssoc(id, assocCode))
        {
            if (Voluntary_association.AddMursheAssoc(id, assocCode))
            {
                return "true";
            }
            else
            {
                return "קיימת בעיה עם הוספת המורשה יש לפנות למנהלי המערכת, תודה";
            }
        }
        //return "vvv";
        return "המשתמש הוגדר כבר בעבר כמורשה לעמותה זו";
    }

    /// <summary>
    /// מתודה שבודקת אם למשתמש יש הרשאה לעמותה לפי קוד עמותה ות.ז משתמש
    /// </summary>
    /// <returns>מחזירה נכון או לא</returns>
    [WebMethod]
    public bool CheckMursheAssoc(string id, int assocCode)
    {
        List<string> MurshimId = new List<string>();
        MurshimId = Voluntary_association.GetAssociationMurshimByCodeAmuta(assocCode);

        foreach (string MursheId in MurshimId)
        {
            while (MursheId == id)
            {
                return true;
            }
        }

        return false;
    }

    [WebMethod]
    public string ChangePass(string id, string newPass)
    {
        UserT temp_user = new UserT();
        temp_user.UserId = id;
        temp_user.Password = newPass;
        temp_user.UpdatePassword();
        return "true";
        
    }

    //(Description ="WebService to return the logged in user ID and info ")
    [WebMethod(EnableSession = true)]
    public string GetUserDetails()
    {
        JavaScriptSerializer j = new JavaScriptSerializer();
        UserT temp_user = new UserT();

        HttpContext context = HttpContext.Current;
        
        if (context.Session["UserID"] == null)
        {
            //Context.Response.AddHeader("Location", "<www.walla.co.il>");
            //HttpContext.Current.Response.Redirect(System.IO.Path.GetFileNameWithoutExtension(HttpContext.Current.Request.PhysicalPath));
            return j.Serialize("NOCOOKIE");
        }

        temp_user.UserId = (string)(context.Session["UserID"]);


        //temp_user.UserId = HttpContext.Current.Session["UserID"].ToString();
        temp_user.GetUserDetails();
        return j.Serialize(temp_user);
    }
}
