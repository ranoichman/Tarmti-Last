using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Rank
{
    //fields
    int rankCode, minimum, max;
    string rankDesc, picPath;
    User[] user;
    // YaTahat

    //props
    #region
    public string PicPath
    {
        get { return picPath; }
        set { picPath = value; }
    }

    public string RankDesc
    {
        get { return rankDesc; }
        set { rankDesc = value; }
    }
    public int Max
    {
        get { return max; }
        set { max = value; }
    }

    public int Minimum
    {
        get { return minimum; }
        set { minimum = value; }
    }

    public int RankCode
    {
        get { return rankCode; }
        set { rankCode = value; }
    }

    public User[] User
    {
        get
        {
            return user;
        }

        set
        {
            user = value;
        }
    }
    #endregion



    //ctor
    public Rank()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    //methods
    #region
    public void GetUserPerRank() { }
    #endregion

}
