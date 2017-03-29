using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Client_ASP_AmutaMain : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        WebService ws = new WebService();
        Voluntary_association V = ws.GetAssociationInfo(Session["associationCode"].ToString());

    }
}