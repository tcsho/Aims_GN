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
/// Summary description for BLLSearchUser
/// </summary>



public class BLLSearchUser
    {
    public BLLSearchUser()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSearchUser objdal = new DALSearchUser();



    #region 'Start Properties Declaration'

    public string FirstName{get;set;}
    public string LastName{get;set;}
    public string MiddleName{get;set;}
    public string Gender_Id{get;set;}
    public string Region_Id{get;set;}
    public string User_Type_Id{get;set;}
    public string Cetnter_Id{get;set;}
        public string Mo_Id{get;set;}

        public string User_Name { get; set; }
        public string EmployeeCode { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int SearchUserAdd(BLLSearchUser _obj)
        {
        return objdal.SearchUserAdd(_obj);
        }
    public int SearchUserUpdate(BLLSearchUser _obj)
        {
        return objdal.SearchUserUpdate(_obj);
        }
    public int SearchUserDelete(BLLSearchUser _obj)
        {
        return objdal.SearchUserDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SearchUserFetch(BLLSearchUser _obj)
        {
        return objdal.SearchUserSelect(_obj);
        }

    public DataTable SearchUserWithPassword(BLLSearchUser _obj)
    {
        return objdal.SearchUserWithPassword(_obj);
    }

    public DataTable SearchUserFetchByStatusID(BLLSearchUser _obj)
    {
        return objdal.SearchUserSelectByStatusID(_obj);
    }



    public DataTable SearchUserFetch(int _id)
      {
        return objdal.SearchUserSelect(_id);
      }


    #endregion

    }
