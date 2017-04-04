using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for AssociationsWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AssociationsWebService : System.Web.Services.WebService
{

    public AssociationsWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod (Description = "Gets associations information for the Associations page")]
    public string GetAmutaDetails()
    {
        //string userID = HttpContext.Current.Session["AmutaCode"].ToString();
        string code = "100";
        JavaScriptSerializer j = new JavaScriptSerializer();
        Voluntary_association Assoc = new Voluntary_association();
        Assoc.Association_Code = code;
        Assoc.GetAssociationByCodeAmuta();
        return j.Serialize(Assoc);
    }


















    [WebMethod (Description = "Gets the logged in user's associated associations ")]
    public string GetUserAmutot()
    {
        string id = "302921481";
        JavaScriptSerializer j = new JavaScriptSerializer();
        List<Voluntary_association> List = new List<Voluntary_association>();
        UserT temp = new UserT();
        temp.UserId = id;
        List = temp.GetUserAssociations();
        return j.Serialize(List);
    }
}
