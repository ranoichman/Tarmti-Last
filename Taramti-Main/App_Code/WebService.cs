using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

/// <summary>
/// Summary description for WebService
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
        Voluntary_association V = new Voluntary_association();
        DataTable DT = new DataTable();
        DT = V.GetAssociationByCode(code);
        if (DT.Rows.Count > 0)
        {
           return V = new Voluntary_association(DT.Rows[0][0].ToString(), DT.Rows[0][1].ToString(), DT.Rows[0][2].ToString());
        }
        else
        {
            return V;
        }
    }

    // מתודה להחזרת כלל העמותות
    [WebMethod]
    public Voluntary_association GetAllAssociations()
    {
        Voluntary_association V = new Voluntary_association();
        DataTable DT = new DataTable();
        DT = V.GetAllAssociations();
        if (DT.Rows.Count > 0)
        {
            return V = new Voluntary_association(DT.Rows[0][0].ToString(), DT.Rows[0][1].ToString(), DT.Rows[0][2].ToString());
        }
        else
        {
            return V;
        }
    }

    [WebMethod]
    public string CheckValidUser(string id, string mail)
    {
        User temp_user = new User();
        temp_user.Mail = mail;
        temp_user.UserId = id;
        if (temp_user.CheckForResetPass())
        {
            temp_user.SendMail();//שליחת מייל
            return "true";
        }
        return "true";
    }
}
