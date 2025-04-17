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
/// Summary description for BLLLmsGloballyVisibleTo
/// </summary>



public class BLLLmsGloballyVisibleTo
    {
    public BLLLmsGloballyVisibleTo()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsGloballyVisibleTo objdal = new DALLmsGloballyVisibleTo();



    #region 'Start Properties Declaration'

    public int GlobalVisibleTo_ID { get; set; }
    public string GloballyVisibleTo { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsGloballyVisibleToAdd(BLLLmsGloballyVisibleTo _obj)
        {
        return objdal.LmsGloballyVisibleToAdd(_obj);
        }
    public int LmsGloballyVisibleToUpdate(BLLLmsGloballyVisibleTo _obj)
        {
        return objdal.LmsGloballyVisibleToUpdate(_obj);
        }
    public int LmsGloballyVisibleToDelete(BLLLmsGloballyVisibleTo _obj)
        {
        return objdal.LmsGloballyVisibleToDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsGloballyVisibleToFetch(BLLLmsGloballyVisibleTo _obj)
        {
        return objdal.LmsGloballyVisibleToSelect(_obj);
        }

    public DataTable LmsGloballyVisibleToFetchByStatusID(BLLLmsGloballyVisibleTo _obj)
    {
        return objdal.LmsGloballyVisibleToSelectByStatusID(_obj);
    }



    public DataTable LmsGloballyVisibleToFetch(int _id)
      {
        return objdal.LmsGloballyVisibleToSelect(_id);
      }


    #endregion

    }
