using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class City
{
    //fields
    int cityCode;
    string cityName;
    User[] users;

    //props
    #region
    public string CityName
    {
        get { return cityName; }
        set { cityName = value; }
    }

    public int CityCode
    {
        get { return cityCode; }
        set { cityCode = value; }
    }

    public User[] Users
    {
        get
        {
            return users;
        }

        set
        {
            users = value;
        }
    }
    #endregion

    //ctor
    public City()
    {

    }

    //methods
    #region
    public void ShowAuctionByCity() { }
    #endregion

}
