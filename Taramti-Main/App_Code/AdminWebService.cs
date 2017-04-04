using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;

/// <summary>
/// Summary description for AdminWebService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class AdminWebService : System.Web.Services.WebService
{

    public AdminWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent();
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string GetAllAssociations()
    {
        JavaScriptSerializer j = new JavaScriptSerializer();

        return j.Serialize(Voluntary_association.GetAllAssociations());
    }

    // לשים מספר דינמי בדוק הנשלח 
    [WebMethod]
    public string GetAssociationByCode(string code)
    {
        JavaScriptSerializer j = new JavaScriptSerializer();
        return j.Serialize(Voluntary_association.GetAssociationByCode(code));
    }
    [WebMethod]
    public string GetAllUsers()
    {
        JavaScriptSerializer j = new JavaScriptSerializer();
        return j.Serialize(UserT.GetAllUsers());
    }

    [WebMethod]
    public void ChangeActive(string id, bool active)
    {
        UserT temp_user = new UserT(id, active);
        temp_user.ChangeActive();
    }

}
