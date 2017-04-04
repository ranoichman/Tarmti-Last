using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Auction
/// </summary>
public abstract class Auction
{
    //fields
    int auctionID;
    DateTime start_Date;
    DateTime end_Date;
    Voluntary_association vol_asc;
    UserT seller, buyer;
    int score;

    //props
    #region
    public DateTime Start_Date
    {
        get
        {
            return start_Date;
        }

        set
        {
            start_Date = value;
        }
    }

    public DateTime End_Date
    {
        get
        {
            return end_Date;
        }

        set
        {
            end_Date = value;
        }
    }

    public Voluntary_association Vol_asc
    {
        get
        {
            return vol_asc;
        }

        set
        {
            vol_asc = value;
        }
    }

    public UserT Seller
    {
        get
        {
            return seller;
        }

        set
        {
            seller = value;
        }
    }

    public UserT Buyer
    {
        get
        {
            return buyer;
        }

        set
        {
            buyer = value;
        }
    }

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    public int AuctionID
    {
        get
        {
            return auctionID;
        }

        set
        {
            auctionID = value;
        }
    }

    #endregion

    //ctor
    public Auction()
    {

    }

    /// <summary>
    /// הבאת כל המכרזים הפעילים
    /// </summary>
    /// <param name="date"></param>
    /// <returns>תחזיר את כל הקודים של המכרזים הפעילים ואת סכום הביד הנוכחי הגבוה ביותר</returns>
    public static int[] GetAllAuctionsByDates(DateTime date)
    {
        int[] li_rtn = new int[2];
        string sql = @"SELECT ISNULL(dbo.auction.auction_code, - 1) AS auction_code, MAX(ISNULL(dbo.bid.price, 0)) * dbo.auction.donation_percentage / 100 AS maxBid
                        FROM dbo.auction  LEFT OUTER JOIN
                         dbo.bid ON dbo.auction.auction_code = dbo.bid.auction_code
                        GROUP BY dbo.auction.auction_code, dbo.auction.start_date, dbo.auction.end_date, dbo.auction.donation_percentage
                        HAVING        (dbo.auction.start_date <= CONVERT(DATETIME, @date, 102)) AND (dbo.auction.end_date >= CONVERT(DATETIME, @date, 102))";
        SqlParameter parDate = new SqlParameter("@date", date);
        DbService db = new DbService();
        DataTable dt = db.GetDataSetByQuery(sql, CommandType.Text, parDate).Tables[0];

        int count = 0;
        int sum = 0;
        foreach (DataRow row in dt.Rows)
        {
            string code = row["auction_code"].ToString();
            if (code != "-1")
            {
                count++;
                sum += int.Parse(row["maxBid"].ToString());
            }
            
        }
        li_rtn[0] = count;
        li_rtn[1] = sum;
        return li_rtn;
    }



    //methods
    #region
    public void CalculateAuctionTime()
    {
        
    }

    public void updateScore()
    {



    }




    public void ShowAuctionQa()
    {
        throw new System.Exception("Not implemented");
    }
    public abstract int CalculateUserScore();

    public void GetAuctionBids()
    {
        throw new System.Exception("Not implemented");
    }
    public virtual void PostBid()
    {
        throw new System.Exception("Not implemented");
    }
    public void GetAuctionUsers()
    {
        throw new System.Exception("Not implemented");
    }
    public void ShowAuction()
    {
        throw new System.Exception("Not implemented");
    }
    public void ShowSellerScore()
    {
        throw new System.Exception("Not implemented");
    }
    public void SendPush()
    {
        throw new System.Exception("Not implemented");
    }
    public void CreateAuction()
    {
        throw new System.Exception("Not implemented");
    }
    public void GetAuctionCode()
    {
        throw new System.Exception("Not implemented");
    }
    public void ShowHighBids()
    {
        throw new System.Exception("Not implemented");
    }
    public void ShowAuctionDetails()
    {
        throw new System.Exception("Not implemented");
    }
    public void ShowAuctionIMG()
    {
        throw new System.Exception("Not implemented");
    }
    public void ShowFAQ()
    {
        throw new System.Exception("Not implemented");
    }
    #endregion



}