﻿using System;
using System.Collections.Generic;
using System.Data;
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

    }

    public Rank(int code, int min, int max, string desc, string path)
    {
        RankCode = code;
        Minimum = min;
        Max = max;
        RankDesc = desc;
        PicPath = path;
    }

    //methods
    #region
    public void GetUserPerRank() { }
    
    //מתודה להבאת נתוני כל הדירוגים
    internal static List<Rank> GetAllRanks()
    {
        List<Rank> li_rtn = new List<Rank>();

        string sqlSelect = @"SELECT * FROM [dbo].[rank]";
        DbService db = new DbService();
        DataTable rankDT = db.GetDataSetByQuery(sqlSelect).Tables[0];
        foreach (DataRow row in rankDT.Rows)
        {
            int code = row["rank_code"].Equals(DBNull.Value) ? int.Parse(row["rank_code"].ToString()) : -1;
            string desc = row["rank_desc"].Equals(DBNull.Value) ? row["rank_desc"].ToString() : "";
            int min = row["minimum"].Equals(DBNull.Value) ? int.Parse(row["minimum"].ToString()) : -1;
            int max = row["max"].Equals(DBNull.Value) ? int.Parse(row["max"].ToString()) : -1;
            string path = row["pic_path"].Equals(DBNull.Value) ? row["pic_path"].ToString() : "";
            if (code != -1)
            {
                li_rtn.Add(new Rank(code, min, max, desc, path));
            }

        }

        return li_rtn;
    }
    #endregion

}
