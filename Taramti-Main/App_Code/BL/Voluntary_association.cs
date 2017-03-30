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
     public string association_Code;
     public string association_Name;
     public string association_Desc;
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

     
    // הפיכה לסטטי כדי להיקרא מאג'קס
    public static List<string> GetAssociationByCode(string code)
    {
        DbService db = new DbService();
        DataSet DS = new DataSet();
        List<string> Lists = new List<string>();
        string sql = "select * from association  " +
                     "where association_code='" + code + "' ";
        DS = db.GetDataSetByQuery(sql);
        foreach (DataRow row in DS.Tables[0].Rows)
        {
            Lists.Add(row[0].ToString());
        }

        return Lists;
    }

    // הפיכה לסטטי כדי להיקרא מאג'קס
    public static List<Voluntary_association> GetAllAssociations()
    {
        DataSet DS = new DataSet();
        DbService db = new DbService();
        Voluntary_association VA = new Voluntary_association();
        List<Voluntary_association> Lists = new List<Voluntary_association>();

        DS = db.GetDataSetByQuery(@"select* from dbo.association ");

        foreach (DataRow row in DS.Tables[0].Rows)
        {
            Voluntary_association A = new Voluntary_association();
            A.Association_Code = row[0].ToString();
            A.Association_Name = row[1].ToString();
            A.Association_Desc = row[2].ToString();
            Lists.Add(A);
            //Lists.Add(row[0].ToString());
            //Lists.Add(row[1].ToString());
            //Lists.Add(row[2].ToString());
            //Lists.Add(row[3].ToString());
            //Lists.Add(row[4].ToString());
        }

        return Lists;
    }


}
