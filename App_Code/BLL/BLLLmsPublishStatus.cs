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
/// Summary description for BLLLmsPublishStatus
/// </summary>



public class BLLLmsPublishStatus
    {
    public BLLLmsPublishStatus()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsPublishStatus objdal = new DALLmsPublishStatus();



    #region 'Start Properties Declaration'

    public int PublishStatus_ID { get; set; }
    public string PublishStatus { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsPublishStatusAdd(BLLLmsPublishStatus _obj)
        {
        return objdal.LmsPublishStatusAdd(_obj);
        }
    public int LmsPublishStatusUpdate(BLLLmsPublishStatus _obj)
        {
        return objdal.LmsPublishStatusUpdate(_obj);
        }
    public int LmsPublishStatusDelete(BLLLmsPublishStatus _obj)
        {
        return objdal.LmsPublishStatusDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsPublishStatusFetch(BLLLmsPublishStatus _obj)
        {
        return objdal.LmsPublishStatusSelect(_obj);
        }

    public DataTable LmsPublishStatusFetchByStatusID(BLLLmsPublishStatus _obj)
    {
        return objdal.LmsPublishStatusSelectByStatusID(_obj);
    }



    public DataTable LmsPublishStatusFetch(int _id)
      {
        return objdal.LmsPublishStatusSelect(_id);
      }


    #endregion

    }
