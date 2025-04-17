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
/// Summary description for BLLLmsSchEventGroup
/// </summary>



public class BLLLmsSchEventGroup
    {
    public BLLLmsSchEventGroup()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSchEventGroup objdal = new DALLmsSchEventGroup();



    #region 'Start Properties Declaration'

    public int EGroup_ID { get; set; }
    public string GroupTitle { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public int ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int LmsSchEventGroupAdd(BLLLmsSchEventGroup _obj)
        {
        return objdal.LmsSchEventGroupAdd(_obj);
        }
    public int LmsSchEventGroupUpdate(BLLLmsSchEventGroup _obj)
        {
        return objdal.LmsSchEventGroupUpdate(_obj);
        }
    public int LmsSchEventGroupDelete(BLLLmsSchEventGroup _obj)
        {
        return objdal.LmsSchEventGroupDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSchEventGroupFetch(BLLLmsSchEventGroup _obj)
        {
        return objdal.LmsSchEventGroupSelect(_obj);
        }

    public DataTable LmsSchEventGroupFetchByStatusID(BLLLmsSchEventGroup _obj)
    {
        return objdal.LmsSchEventGroupSelectByStatusID(_obj);
    }



    public DataTable LmsSchEventGroupFetch(int _id)
      {
        return objdal.LmsSchEventGroupSelect(_id);
      }


    #endregion

    }
