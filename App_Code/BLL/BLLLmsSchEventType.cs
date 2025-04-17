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
/// Summary description for BLLLmsSchEventType
/// </summary>



public class BLLLmsSchEventType
    {
    public BLLLmsSchEventType()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSchEventType objdal = new DALLmsSchEventType();



    #region 'Start Properties Declaration'

    public int EventType_ID { get; set; }
    public string EventType { get; set; }
    public int EventImage { get; set; }
    public string Status_Id { get; set; }
    public int CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public string ModifiedOn { get; set; }
    public string ModifiedBy { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsSchEventTypeAdd(BLLLmsSchEventType _obj)
        {
        return objdal.LmsSchEventTypeAdd(_obj);
        }
    public int LmsSchEventTypeUpdate(BLLLmsSchEventType _obj)
        {
        return objdal.LmsSchEventTypeUpdate(_obj);
        }
    public int LmsSchEventTypeDelete(BLLLmsSchEventType _obj)
        {
        return objdal.LmsSchEventTypeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSchEventTypeFetch(BLLLmsSchEventType _obj)
        {
        return objdal.LmsSchEventTypeSelect(_obj);
        }

    public DataTable LmsSchEventTypeFetchByStatusID(BLLLmsSchEventType _obj)
    {
        return objdal.LmsSchEventTypeSelectByStatusID(_obj);
    }



    public DataTable LmsSchEventTypeFetch(int _id)
      {
        return objdal.LmsSchEventTypeSelect(_id);
      }


    #endregion

    }
