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
/// Summary description for BLLLmsNews
/// </summary>



public class BLLLmsNews
    {
    public BLLLmsNews()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsNews objdal = new DALLmsNews();



    #region 'Start Properties Declaration'

    public int News_ID { get; set; }
    public int Section_Subject_Id { get; set; }
    public int WrkTool_ID { get; set; }
    public string NewsTitle { get; set; }
    public string NewsDetail { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public bool PublishStatus_ID { get; set; }
    public int Status_ID { get; set; }
    public int MainPageStatus_ID { get; set; }


    #endregion
    //

    #region 'Start Executaion Methods'

    public int LmsNewsAdd(BLLLmsNews _obj)
        {
        return objdal.LmsNewsAdd(_obj);
        }
    public int LmsNewsUpdate(BLLLmsNews _obj)
        {
        return objdal.LmsNewsUpdate(_obj);
        }
    public int LmsNewsDelete(BLLLmsNews _obj)
        {
        return objdal.LmsNewsDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsNewsFetch(BLLLmsNews _obj)
        {
        return objdal.LmsNewsSelect(_obj);
        }

    public DataTable LmsNewsFetchByStatusID(BLLLmsNews _obj)
    {
        return objdal.LmsNewsSelectByStatusID(_obj);
    }


    public DataTable LmsNewsSelectAllBySectionSubjectIdWrkToolId(BLLLmsNews _obj)
    {
        return objdal.LmsNewsSelectAllBySectionSubjectIdWrkToolId(_obj);
    }

    //aaa//
    //for test

    public DataTable LmsNewsSelectAllByNewsId(BLLLmsNews _obj)
    {
        return objdal.LmsNewsSelectAllByNewsId(_obj);
    }



    public DataTable LmsNewsFetch(int _id)
      {
        return objdal.LmsNewsSelect(_id);
      }


    #endregion

    }
