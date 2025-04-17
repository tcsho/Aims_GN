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
/// Summary description for BLLLmsFormTopic
/// </summary>



public class BLLLmsFormTopic
    {
    public BLLLmsFormTopic()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsFormTopic objdal = new DALLmsFormTopic();



    #region 'Start Properties Declaration'

    public int Topic_ID { get; set; }
    public int Forum_ID { get; set; }
    public string TopicTitle { get; set; }
    public string ShortDescription { get; set; }
    public string LongDescription { get; set; }
    public bool isLock { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public bool isGradeBook { get; set; }
    public int TotalPoints { get; set; }
    public int PostingType_ID { get; set; }
    public int ThreadType_ID { get; set; }
    public int PublishStatus_ID { get; set; }
    public int GblAccessType_ID { get; set; }
    public int Status_Id { get; set; }

    public int Section_Subject_Id { get; set; }
    public int WrkTool_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int LmsFormTopicAdd(BLLLmsFormTopic _obj)
        {
        return objdal.LmsFormTopicAdd(_obj);
        }
    public int LmsFormTopicUpdate(BLLLmsFormTopic _obj)
        {
        return objdal.LmsFormTopicUpdate(_obj);
        }
    public int LmsFormTopicDelete(BLLLmsFormTopic _obj)
        {
        return objdal.LmsFormTopicDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsFormTopicFetch(BLLLmsFormTopic _obj)
        {
        return objdal.LmsFormTopicSelect(_obj);
        }

    public DataTable LmsFormTopicFetchByStatusID(BLLLmsFormTopic _obj)
    {
        return objdal.LmsFormTopicSelectByStatusID(_obj);
    }


    public DataTable LmsFormTopicSlectAllBySectionSubjectIdWrkToolId(BLLLmsFormTopic _obj)
    {
        return objdal.LmsFormTopicSlectAllBySectionSubjectIdWrkToolId(_obj);
    }


    public DataTable LmsFormTopicSlectAllByTopicId(BLLLmsFormTopic _obj)
    {
        return objdal.LmsFormTopicSlectAllByTopicId(_obj);
    }


    public DataTable LmsFormTopicSelectAllByTopicId(BLLLmsFormTopic _obj)
    {
        return objdal.LmsFormTopicSelectAllByTopicId(_obj);
    }


    public DataTable LmsFormTopicFetch(int _id)
      {
        return objdal.LmsFormTopicSelect(_id);
      }


    #endregion

    }
