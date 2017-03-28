using System;
using System.Collections.Generic;
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
    User seller, buyer;
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

    public User Seller
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

    public User Buyer
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