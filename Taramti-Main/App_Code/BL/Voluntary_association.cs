using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Voluntary_association
{
    string association_Code;
     string association_Name;
     string association_Desc;
     Association_Tag[] association_Tags;
     Auction[] auctions;

    //props
    #region
    public string Association_Name
    {
        get
        {
            return association_Name;
        }

        set
        {
            association_Name = value;
        }
    }

    public string Association_Desc
    {
        get
        {
            return association_Desc;
        }

        set
        {
            association_Desc = value;
        }
    }

    public Association_Tag[] Association_Tags
    {
        get
        {
            return association_Tags;
        }

        set
        {
            association_Tags = value;
        }
    }

    public Auction[] Auctions
    {
        get
        {
            return auctions;
        }

        set
        {
            auctions = value;
        }
    }

    public string Association_Code
    {
        get
        {
            return association_Code;
        }

        set
        {
            association_Code = value;
        }
    }
    #endregion

    //Ctor
    public Voluntary_association(string association_Code,string association_Name, string association_Desc)
    {
        this.Association_Code = association_Code;
        this.Association_Name = association_Name;
        this.Association_Desc = association_Desc;
        //this.Association_Tags = association_Tags;
    }

    public Voluntary_association()
    {

    }



    public void ShowAssocDetails()
    {
        throw new System.Exception("Not implemented");
    }

     

    public DataTable GetAssociationByCode(string code)
    {
        DbService db = new DbService();
        DataSet projects = new DataSet();
        string sql = "select * from association  " +
                     "where association_code='" + code + "' ";
        projects = db.GetDataSetByQuery(sql);
        return projects.Tables[0];
    }

    public DataTable GetAllAssociations()
    {
        DataTable DT = new DataTable();
        return DT;
    }
}
