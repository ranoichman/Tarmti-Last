using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.Script.Serialization;

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
        return "true";
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

}
