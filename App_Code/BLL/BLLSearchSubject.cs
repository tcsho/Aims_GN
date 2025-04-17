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
/// Summary description for BLLSearchSubject
/// </summary>



public class BLLSearchSubject
    {
    public BLLSearchSubject()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSearchSubject objdal = new DALSearchSubject();



    #region 'Start Properties Declaration'

    		
    public string Class_Name{get;set;}
    public string Class_Id{get;set;}
    public string Region_Id{get;set;}
    public string Center_Id{get;set;}
    public string Subject_Id{get;set;}
    public string MO_Id{get;set;}
    public string Teacher_Id{get;set;}
    

    #endregion

    #region 'Start Executaion Methods'

    public int SearchSubjectAdd(BLLSearchSubject _obj)
        {
        return objdal.SearchSubjectAdd(_obj);
        }
    public int SearchSubjectUpdate(BLLSearchSubject _obj)
        {
        return objdal.SearchSubjectUpdate(_obj);
        }
    public int SearchSubjectDelete(BLLSearchSubject _obj)
        {
        return objdal.SearchSubjectDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SearchSubjectFetch(BLLSearchSubject _obj)
        {
        return objdal.SearchSubjectSelect(_obj);
        }

    public DataTable SearchSubjectFetchByStatusID(BLLSearchSubject _obj)
    {
        return objdal.SearchSubjectSelectByStatusID(_obj);
    }



    public DataTable SearchSubjectFetch(int _id)
      {
        return objdal.SearchSubjectSelect(_id);
      }


    #endregion

    }
