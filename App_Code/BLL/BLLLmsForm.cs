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
/// Summary description for BLLLmsForm
/// </summary>



public class BLLLmsForm
    {
    public BLLLmsForm()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsForm objdal = new DALLmsForm();



    #region 'Start Properties Declaration'
    public int Forum_ID { get; set; }
    public int Section_Subject_Id { get; set; }
    public string ForumTitle { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public bool isLock { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public int Status_Id { get; set; }
    public int PublishStatus_ID { get; set; }
    public int GblAccessType_ID { get; set; }
    public int WrkTool_Id { get; set; }




    #endregion

    #region 'Start Executaion Methods'

    public int LmsFormAdd(BLLLmsForm _obj)
        {
        return objdal.LmsFormAdd(_obj);
        }
    public int LmsFormUpdate(BLLLmsForm _obj)
        {
        return objdal.LmsFormUpdate(_obj);
        }
    public int LmsFormDelete(BLLLmsForm _obj)
        {
        return objdal.LmsFormDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsFormFetch(BLLLmsForm _obj)
        {
        return objdal.LmsFormSelect(_obj);
        }

    public DataTable LmsFormFetchByStatusID(BLLLmsForm _obj)
    {
        return objdal.LmsFormSelectByStatusID(_obj);
    }

    public DataTable LmsFormelectAllBySectionSubjectIdWrkToolId(BLLLmsForm _obj)
    {
        return objdal.LmsFormelectAllBySectionSubjectIdWrkToolId(_obj);
    }

    public DataTable LmsFormSelectAllByForumID(BLLLmsForm _obj)
    {
        return objdal.LmsFormSelectAllByForumID(_obj);
    }



    public DataTable LmsFormFetch(int _id)
      {
        return objdal.LmsFormSelect(_id);
      }


    #endregion

    }
