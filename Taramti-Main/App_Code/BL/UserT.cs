using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for Class1
/// </summary>
public class UserT
{
    string userId, firstName, lastName, address, mail, password;
    bool active;
    Rank rank;
    City city;
    Item[] items;
    Bid[] bids;

    //props
    #region
    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string UserId
    {
        get { return userId; }
        set { userId = value; }
    }

    public Rank Rank
    {
        get
        {
            return rank;
        }

        set
        {
            rank = value;
        }
    }

    public City City
    {
        get
        {
            return city;
        }

        set
        {
            city = value;
        }
    }

    public Item[] Items
    {
        get
        {
            return items;
        }

        set
        {
            items = value;
        }
    }

    public Bid[] Bids
    {
        get
        {
            return bids;
        }

        set
        {
            bids = value;
        }
    }

    public string Mail
    {
        get
        {
            return mail;
        }

        set
        {
            mail = value;
        }
    }

    public string Password
    {
        get
        {
            return password;
        }

        set
        {
            password = value;
        }
    }

    public bool Active
    {
        get
        {
            return active;
        }

        set
        {
            active = value;
        }
    }
    #endregion

    //ctor
    public UserT()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    public UserT(string userId, string firstName, string lastName, bool active, Rank tempRank)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Active = active;
        Rank = tempRank;
    }

    public UserT(string userId, string firstName, string lastName, bool active)
    {
        UserId = userId;
        FirstName = firstName;
        LastName = lastName;
        Active = active;
    }

    public UserT(string mail, string pass)
    {
        Mail = mail;
        Password = pass;
    }

    public UserT(string id, bool active)
    {

    }

    //methods
    #region

    //מתודה לבדיקה האם המשתמש קיים
    public bool CheckLogin()
    {
        string sqlSelect = @"SELECT [user_id]
                            FROM [dbo].[users]
                            where (email = @email) and ([password] = @password)";
        DbService db = new DbService();
        SqlParameter parEmail = new SqlParameter("@email", Mail);
        SqlParameter parPass = new SqlParameter("@password", Password);
        try
        {
            UserId = db.GetScalarByQuery(sqlSelect, CommandType.Text, parEmail, parPass).ToString();
            if (UserId != "0")
            {
                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    /// <summary>
    /// מתודה לבדיקת ההרשאות של המשתמש
    /// </summary>
    /// <returns>תחזיר 1 במידה והמשתמש מנהל מערכת, 2 במידה ומורשה גישה לעמותות ומינוס 1 (1-) אם המשתמש משתמש רגיל</returns>
    public int CheckAuthDesktop()
    {
        string sqlSelect = @"SELECT count([user_id])
                            FROM [dbo].[admin]
                            where (user_id = @user_id)";
        DbService db = new DbService();
        SqlParameter parUser = new SqlParameter("@user_id", UserId);
        int auth = -1;
        auth = db.GetScalarByQuery(sqlSelect, CommandType.Text, parUser); //בדיקה האם אדמין
        if (auth != 1)
        {
            sqlSelect = @"SELECT count([association_code])
                        FROM [dbo].[association_access]
                        where user_id=@user_id";
            auth = db.GetScalarByQuery(sqlSelect, CommandType.Text, parUser);
            if (auth >= 1)
            {
                auth = 2;
            }
            else
            {
                auth = -1;
            }
        }
        return auth;
    }

    /// <summary>
    /// מתודה לבדיקה האם ת.ז ומייל המשתמש מופיעים
    /// </summary>
    /// <returns>מחזירה אמת במידה וכן ושקר אחרת</returns>
    public bool CheckForResetPass()
    {
        string sqlSelect = @"SELECT count([user_id])
                            FROM [dbo].[users]
                            where (email = @email) and ([user_id] = @user_id)";
        DbService db = new DbService();
        SqlParameter parEmail = new SqlParameter("@email", Mail);
        SqlParameter parUser = new SqlParameter("@user_id", UserId);
        int res = 0;
        try
        {
            res = db.GetScalarByQuery(sqlSelect, CommandType.Text, parEmail, parUser);
            if (res != 0)
            {
                return true;
            }
            else
                return false;
        }
        catch (Exception ex)
        {
            return false;
        }

    }

    //מתודה לשינוי סיסמה במסד הנתונים
    public void UpdatePassword()
    {
        string sqlUpdate = "UPDATE [dbo].[users] SET [password]=@password WHERE user_id = @userID";
        SqlParameter parUser = new SqlParameter("@userID", UserId);
        SqlParameter parPass = new SqlParameter("@password", Password);
        DbService db = new DbService();
        db.ExecuteQuery(sqlUpdate, CommandType.Text, parPass, parUser);
    }

    //מתודה לשליחת מייל
    // פונקציה לשליחת מיילים
    public void SendMail()
    {
        // עדכון סיסמא
        Password = "000000";
        UpdatePassword();

        string Sbjct = "איפוס סיסמא למשתמש " + FirstName + " " + LastName + ".";
        string MyHdr = "";
        string StrHtml = "";

        MyHdr += "<div dir='rtl'>" + "שלום" + ",";
        MyHdr += "<BR>";
        MyHdr += "<BR>";
        MyHdr += "בקשתך לאיפוס סיסמא התקבלה וסיסמתך שונתה בהצלחה.  ";
        MyHdr += "<BR>";
        //MyHdr += "<BR dir='ltr'>";
        MyHdr += " סיסמתך החדשה הינה: " + "000000";
        MyHdr += "</DIV>";
        MyHdr += "<DIV align=right>";

        MyHdr += "<BR align=right>";

        MailMessage message = new MailMessage();
        // To 
        message.To.Add(new MailAddress("heregteam@gmail.com"));
        // From Query
        message.From = new MailAddress("recoverpass@taramti.co.il");

        message.Subject = Sbjct;
        message.IsBodyHtml = true;

        message.Body = MyHdr + "\n\r\n\r" + StrHtml;
        AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message.Body, null, "text/html");
        message.AlternateViews.Add(htmlView);


        SmtpClient client = new SmtpClient();
        client.Host = "smtp.gmail.com";
        client.Port = 587;
        client.EnableSsl = true;
        client.DeliveryMethod = SmtpDeliveryMethod.Network;
        client.UseDefaultCredentials = false;
        //client.Credentials = new NetworkCredential("heregteam@gmail.com", "teamhereg!1");
        //(1)
        client.UseDefaultCredentials = true;
        //(2) 
        client.Credentials = new System.Net.NetworkCredential("heregteam@gmail.com", "teamhereg");
        client.Send(message);
    }

    //מתודה להבאת פרטי יוזרים לטבלת ניהול משתמשים בדף אדמין
    internal static List<UserT> GetAllUsers()
    {
        List<UserT> li_rtn = new List<UserT>();
        string sqlSelect = @"SELECT dbo.users.user_id, dbo.users.first_name ,dbo.users.last_name, dbo.users.active, SUM(dbo.auction.score) AS rank
                              FROM dbo.auction RIGHT OUTER JOIN dbo.users ON
                              dbo.auction.buyer_id = dbo.users.user_id OR dbo.auction.seller_id = dbo.users.user_id
                             GROUP BY dbo.users.user_id, dbo.users.first_name, dbo.users.last_name, dbo.users.active";
        DbService db = new DbService();
        DataTable usersDT = db.GetDataSetByQuery(sqlSelect).Tables[0];
        List<Rank> ranksList = Rank.GetAllRanks();
        foreach (DataRow row in usersDT.Rows)
        {
            string id = row["user_id"].Equals(DBNull.Value) ? "" : row["user_id"].ToString();
            string fName = row["first_name"].Equals(DBNull.Value) ? "" : row["first_name"].ToString();
            string lName = row["last_name"].Equals(DBNull.Value) ? "" : row["last_name"].ToString();
            bool active = row["active"].Equals(DBNull.Value) ? false : bool.Parse(row["active"].ToString());
            int rankSum = row["rank"].Equals(DBNull.Value) ? 0 : int.Parse(row["rank"].ToString());
            Rank tempRank = new Rank();
            foreach (Rank item in ranksList)
            {

                if ((rankSum >= item.Minimum) && (rankSum <= item.Max))
                {
                    tempRank = item;
                    break;
                }
            }

            li_rtn.Add(new UserT(id, fName, lName, active, tempRank));
        }

        return li_rtn;
    }

    /// <summary>
    /// מתודה המביאה שם משתמש המלא לפי המייל שלו
    /// </summary>
    /// <returns>מחזירה שם מלא של משתמש</returns>
    public void GetUserName()
    {
        string sqlSelect = @"Select [first_name], [last_name] 
                            from [dbo].[users]
                            Where [email] = @email";
        DbService db = new DbService();
        SqlParameter parEmail = new SqlParameter("@email", Mail);
        DataTable dt = new DataTable();
        try
        {
            dt = db.GetDataSetByQuery(sqlSelect, CommandType.Text, parEmail).Tables[0];
            FirstName = dt.Rows[0][0].ToString();
            LastName = dt.Rows[0][1].ToString();
        }
        catch (Exception ex)
        {
            throw ex;
        }

    }

    public void ChangeActive()
    {
        string sqlDelete = "UPDATE [dbo].[users] SET active = @active WHERE user_id = @userID";
        SqlParameter parUser = new SqlParameter("@userID", UserId);
        SqlParameter parActive = new SqlParameter("@active", Active ? 1 : 0);
        DbService db = new DbService();
        db.ExecuteQuery(sqlDelete, CommandType.Text, parUser, parActive);
    }

    /// <summary>
    /// מתודה להבאת רשימת העמותות אליהם משוייך המשתמש
    /// </summary>
    public List<Voluntary_association> GetUserAssociations()
    {
        List<Voluntary_association> li_rtn = new List<Voluntary_association>();
        string StrSql = "SELECT dbo.association_access.association_code, dbo.association.association_name, dbo.association.association_desc, dbo.association.website, dbo.association.year, dbo.association.image " +
                         "FROM dbo.association_access " +
                         "INNER JOIN dbo.association ON dbo.association_access.association_code = dbo.association.association_code " +
                         "LEFT OUTER JOIN dbo.users ON dbo.association_access.user_id = dbo.users.user_id " +
                         "WHERE(dbo.users.user_id = N'" + userId + "') ";
        DbService db = new DbService();
        DataTable DT = db.GetDataSetByQuery(StrSql).Tables[0];
        foreach (DataRow row in DT.Rows)
        {
            Voluntary_association assoc = new Voluntary_association();
            assoc.Association_Code = row[0].ToString();
            assoc.Association_Name = row[1].ToString();
            assoc.Association_Desc = row[2].ToString();
            assoc.Association_WebSite = row[3].ToString(); 
            assoc.Association_Year = row[4].ToString(); 
            assoc.Association_Image = row[5].ToString();
            li_rtn.Add(assoc);
        }
        return li_rtn;
    }

    public void GetUsersAuctions() { }

    public void ShowAvgRank() { }

    public void Subscribe() { }

    public void UpdateUser() { }

    public void GetUserDetails() { }

    public void GetUserBids() { }

    public void GetUserProducts() { }

    public void SendPushToUsers() { }




    #endregion

}
