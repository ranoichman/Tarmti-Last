using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class User
{
    string userId, firstName, lastName, address, mail, password;
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
    #endregion

    //ctor
    public User()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public User(string mail, string pass)
    {
        Mail = mail;
        Password = pass;
    }


    //methods
    #region

    //מתודה לבדיקה האם המשתמש קיים
    public bool CheckLogin()
    {
        string sqlSelect = @"SELECT [user_id]
                            FROM [dbo].[users]
                            where (email = '@email') and ([password] = '@password')";
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
                            where (user_id = '@user_id')";
        DbService db = new DbService();
        SqlParameter parUser = new SqlParameter("@user_id", UserId);
        int auth = -1;
        auth = db.GetScalarByQuery(sqlSelect, CommandType.Text, parUser); //בדיקה האם אדמין
        if (auth !=1)
        {
            sqlSelect = @"SELECT count([association_code])
                        FROM [dbo].[association_access]
                        where user_id='@user_id'";
            auth = db.GetScalarByQuery(sqlSelect, CommandType.Text, parUser);
            if (auth>=1)
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
        string sqlSelect = @"SELECT [user_id]
                            FROM [dbo].[users]
                            where (email = '@email') and ([user_id] = '@user_id')";
        DbService db = new DbService();
        SqlParameter parEmail = new SqlParameter("@email", Mail);
        SqlParameter parUser = new SqlParameter("@user_id", UserId);
        try
        {
            UserId = db.GetScalarByQuery(sqlSelect, CommandType.Text, parEmail, parUser).ToString();
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

    //מתודה לשינוי סיסמה במסד הנתונים
    public void UpdatePassword()
    {
        string sqlUpdate = "UPDATE [dbo].[users] SET [password]=@password WHERE user_id = '@userID'";
        SqlParameter parUser = new SqlParameter("@userID", UserId);
        SqlParameter parPass = new SqlParameter("@password", Password);
        DbService db = new DbService();
        db.ExecuteQuery(sqlUpdate, CommandType.Text, parPass, parUser);
    }

    public void GetUsersAuctions() { }

    public void ShowAvgRank() { }

    public void Subscribe() { }

    public void UpdateUser() { }

    public void DeleteUser()
    {
        string sqlDelete = "UPDATE [dbo].[users] SET active = 0 WHERE user_id = '@userID'";
        SqlParameter parUser = new SqlParameter("@userID", UserId);
        DbService db = new DbService();
        db.ExecuteQuery(sqlDelete, CommandType.Text, parUser);
    }

    public void GetUserDetails() { }

    public void GetUserBids() { }

    public void GetUserProducts() { }

    public void SendPushToUsers() { }
    #endregion

}
