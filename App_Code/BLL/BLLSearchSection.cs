using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for BLLSearchSection
/// </summary>



public class BLLSearchSection
    {
    public BLLSearchSection()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSearchSection objdal = new DALSearchSection();



    #region 'Start Properties Declaration'

    public string Class_Name{get;set;}
    public string Class_Id{get;set;}
    public string Region_Id{get;set;}
    public string Center_Id{get;set;}
    public string Secton_Id{get;set;}
    public string Subject_Id{get;set;}
    public string Mo_Id{get;set;}
    public string Teacer_Id{get;set;}
    

    #endregion

    #region 'Start Executaion Methods'

    public int SearchSectionAdd(BLLSearchSection _obj)
        {
        return objdal.SearchSectionAdd(_obj);
        }
    public int SearchSectionUpdate(BLLSearchSection _obj)
        {
        return objdal.SearchSectionUpdate(_obj);
        }
    public int SearchSectionDelete(BLLSearchSection _obj)
        {
        return objdal.SearchSectionDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SearchSectionFetch(BLLSearchSection _obj)
        {
        return objdal.SearchSectionSelect(_obj);
        }

    public DataTable SearchSectionFetchByStatusID(BLLSearchSection _obj)
    {
        return objdal.SearchSectionSelectByStatusID(_obj);
    }



    public DataTable SearchSectionFetch(int _id)
      {
        return objdal.SearchSectionSelect(_id);
      }


    #endregion

    }
