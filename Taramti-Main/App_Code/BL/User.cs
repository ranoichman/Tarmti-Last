using System;
using System.Collections.Generic;
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
                            where (email like @email) and ([password] like @password)";
        DbService db = new DbService();
        SqlParameter parEmail = new SqlParameter("@email", Mail);
        SqlParameter parPass = new SqlParameter("@password", Password);
        try
        {
            UserId = db.GetScalarByQuery2(sqlSelect, System.Data.CommandType.Text, parEmail, parPass).ToString(); // להחזיר למתודה המקורית
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
    /// תחזיר 1 במידה והמשתמש מנהל מערכת, 2 במידה ומורשה גישה לעמותות ומינוס 1 (1-) אם המשתמש משתמש רגיל
    /// </summary>
    public int CheckAuthDesktop()
    {


        return -1;
    }




    public void GetUsersAuctions() { }

    public void ShowAvgRank() { }

    public void Subscribe() { }

    public void UpdateUser() { }

    public void DeleteUser()
    {
        string sqlDelete = "UPDATE [dbo].[users] SET active = -0 WHERE user_id = @userID";
        SqlParameter param = new SqlParameter("@userID", UserId);
    }

    public void GetUserDetails() { }

    public void GetUserBids() { }

    public void GetUserProducts() { }

    public void SendPushToUsers() { }
    #endregion

}
