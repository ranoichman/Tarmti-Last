﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Picture
{
    //fields
     string path;
     string pic_Description;
     Item item;

    //props
    #region
    public string Path
    {
        get
        {
            return path;
        }

        set
        {
            path = value;
        }
    }

    public string Pic_Description
    {
        get
        {
            return pic_Description;
        }

        set
        {
            pic_Description = value;
        }
    }

    public Item Item
    {
        get
        {
            return item;
        }

        set
        {
            item = value;
        }
    }
    #endregion


    //ctor
    public Picture()
    {

    }

    //methods
    #region
    public void TakePic()
    {
        throw new System.Exception("Not implemented");
    }
    public void AddPic()
    {
        throw new System.Exception("Not implemented");
    }
    public void ShowIMG()
    {
        throw new System.Exception("Not implemented");
    }
    #endregion



   
}
