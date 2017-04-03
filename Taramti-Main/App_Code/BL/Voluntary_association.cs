using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 
public class Voluntary_association
{
    public string association_Code;
    public string association_Name;
    public string association_Desc;
    public string association_Account;
    public string association_WebSite;
    public string association_Year;
    List<Association_Tag> association_Tags;
    List<UserT> permittedUsers;
    List<Auction> auctions;

    /// <summary>
    ///  להוסיף שליפה אחר כך של האוקשנים גם וגם של התגים
    /// </summary>


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

    public List<Association_Tag> Association_Tags
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

    public List<Auction> Auctions
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

    public string Association_Account
    {
        get
        {
            return association_Account;
        }

        set
        {
            association_Account = value;
        }
    }

    public string Association_WebSite
    {
        get
        {
            return association_WebSite;
        }

        set
        {
            association_WebSite = value;
        }
    }

    public string Association_Year
    {
        get
        {
            return association_Year;
        }

        set
        {
            association_Year = value;
        }
    }

    public List<UserT> PermittedUsers
    {
        get
        {
            return permittedUsers;
        }

        set
        {
            permittedUsers = value;
        }
    }
    #endregion

    //Ctor
    public Voluntary_association(string association_Code, string association_Name, string association_Desc)
    {
        Association_Code = association_Code;
        Association_Name = association_Name;
        Association_Desc = association_Desc;
        //this.Association_Tags = association_Tags;
    }

    public Voluntary_association(string association_Code, string association_Name, string association_Desc, string account, string website, string year, List<UserT> permitted)
    {
        Association_Code = association_Code;
        Association_Name = association_Name;
        Association_Desc = association_Desc;
        association_Account = account;
        Association_WebSite = website;
        Association_Year = year;
        PermittedUsers = permitted;
    }

    public Voluntary_association()
    {
        PermittedUsers = new List<UserT>();
        Association_Tags = new List<Association_Tag>();
        Auctions = new List<Auction>();
    }

    public void ShowAssocDetails()
    {
        
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
        List<Voluntary_association> Lists = new List<Voluntary_association>();

        DS = db.GetDataSetByQuery(@"select* from dbo.association ");

        foreach (DataRow row in DS.Tables[0].Rows)
        {
            Voluntary_association A = new Voluntary_association();
            A.Association_Code = row[0].ToString();
            A.Association_Name = row[1].ToString();
            A.Association_Desc = row[2].ToString();
            Lists.Add(A);
        }

        return Lists;
    }

    public void GetAssociationByCodeAmuta()
    {
        DbService db = new DbService();
        DataSet DS = new DataSet();
        //Voluntary_association A = new Voluntary_association();
        string sql1 = "select * from association  " +
                     "where association_code= @code";
        string sql2 = @" SELECT dbo.users.user_id,dbo.users.first_name, dbo.users.last_name,dbo.users.active 
                        FROM dbo.association_access LEFT JOIN 
                        dbo.users ON dbo.association_access.user_id = dbo.users.user_id 
                        WHERE(dbo.association_access.association_code = @code )";
        string sql3 = @" SELECT dbo.tags.tage_code, dbo.tags.tag_desc
                        FROM  dbo.tag_of_association INNER JOIN
                        dbo.tags ON dbo.tag_of_association.tag_code = dbo.tags.tage_code
                        WHERE        (dbo.tag_of_association.association_code = @code)";


        SqlParameter parCode = new SqlParameter("@code", Association_Code);
        DS = db.GetDataSetByQuery(sql1 + sql2 + sql3,CommandType.Text,parCode);

        //מילוי פרטים
        foreach (DataRow row in DS.Tables[0].Rows)
        {

            Association_Code = row[0].ToString();
            Association_Name = row[1].ToString();
            Association_Desc = row[2].ToString();
            Association_Account = row[3].ToString();
            Association_WebSite = row[4].ToString();
            Association_Year = row[6].ToString();
        }


        //DS.Tables.Add();
        //DS = db.GetDataSetByQuery(sql, CommandType.Text, parCode);

        //מילוי רשימת מורשי גישה
        foreach (DataRow row in DS.Tables[1].Rows)
        {
            UserT permitted = new UserT(row[0].ToString(), row[1].ToString(), row[2].ToString(), bool.Parse(row[3].ToString()));
            PermittedUsers.Add(permitted);
        }

        //מילוי רשימת תגיות
        foreach (DataRow row in DS.Tables[2].Rows)
        {
            Association_Tag tag = new Association_Tag(int.Parse(row[0].ToString()),row[1].ToString());
            Association_Tags.Add(tag);
        }
    }

    //public void GetAssociationByCodeAmuta()
    //{
    //    DbService db = new DbService();
    //    DataSet DS = new DataSet();
    //    //Voluntary_association A = new Voluntary_association();
    //    string sql = "select * from association  " +
    //                 "where association_code= @code )";
    //    SqlParameter parCode = new SqlParameter("@code", Association_Code);
    //    DS = db.GetDataSetByQuery(sql, CommandType.Text, parCode);
    //    foreach (DataRow row in DS.Tables[0].Rows)
    //    {

    //        Association_Code = row[0].ToString();
    //        Association_Name = row[1].ToString();
    //        Association_Desc = row[2].ToString();
    //        Association_Account = row[3].ToString();
    //        Association_WebSite = row[4].ToString();
    //        Association_Year = row[6].ToString();
    //    }

    //    sql = "SELECT dbo.users.user_id,dbo.users.first_name, dbo.users.last_name,dbo.users.active " +
    //          "FROM dbo.association_access LEFT JOIN " +
    //          "dbo.users ON dbo.association_access.user_id = dbo.users.user_id " +
    //          "WHERE(dbo.association_access.association_code = @code )";
    //    DS.Tables.Add();
    //    DS = db.GetDataSetByQuery(sql, CommandType.Text, parCode);

    //    foreach (DataRow row in DS.Tables[0].Rows)
    //    {
    //        UserT permitted = new UserT(row[0].ToString(), row[1].ToString(), row[2].ToString(), bool.Parse(row[3].ToString()));
    //        PermittedUsers.Add(permitted);
    //    }
    //}




    //public static List<Voluntary_association> GetAssociationByUser(string userID)
    //{
    //    DataSet DS = new DataSet();
    //    DbService db = new DbService();
    //    List<Voluntary_association> Lists = new List<Voluntary_association>();

    //    string StrSql = "SELECT dbo.association_access.user_id, dbo.association_access.association_code, dbo.association.association_name, dbo.association.association_desc, " +
    //                     "dbo.association.account, dbo.association.website, dbo.association.image, dbo.association.year " +
    //                     "FROM dbo.association INNER JOIN dbo.association_access ON dbo.association.association_code = dbo.association_access.association_code " +
    //                     "WHERE(dbo.association_access.user_id =" + userID + ")";
    //    DS = db.GetDataSetByQuery(StrSql);
    //    if (DS.Tables[0].Rows.Count > 0)
    //    {
    //        Voluntary_association A = new Voluntary_association();
    //        A.Association_Code = DS.Tables[0].Rows[0][1].ToString();
    //        A.Association_Name = DS.Tables[0].Rows[0][2].ToString();
    //        A.Association_Desc = DS.Tables[0].Rows[0][3].ToString();
    //        Lists.Add(A);
    //    }
    //    return Lists;
    //}


}
