using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Association_Tag
{
    //fields
    string tag_Name;
    Voluntary_association[] vol_asc;

    //props
    #region
    public string Tag_Name
    {
        get
        {
            return tag_Name;
        }

        set
        {
            tag_Name = value;
        }
    }

    public Voluntary_association[] Vol_asc
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
    #endregion

    //ctor
    public Association_Tag()
    {

    }

    //methods
    #region
    public void GetAssociationTags()
    {

    }
    #endregion


}
