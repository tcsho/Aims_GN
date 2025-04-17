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
/// Summary description for BLLLmsSurvey
/// </summary>



public class BLLLmsSurvey
    {
    public BLLLmsSurvey()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSurvey objdal = new DALLmsSurvey();



    #region 'Start Properties Declaration'

    public int Survey_ID { get; set; }
    public string QstText { get; set; }
    public string AddInstructions { get; set; }
    public DateTime OpningDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public int WrkTool_ID { get; set; }
    public bool PublishStatus_ID { get; set; }
    public bool GblAccessType_ID { get; set; }
    public int Participant_ID { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsSurveyAdd(BLLLmsSurvey _obj)
        {
        return objdal.LmsSurveyAdd(_obj);
        }
    public int LmsSurveyUpdate(BLLLmsSurvey _obj)
        {
        return objdal.LmsSurveyUpdate(_obj);
        }
    public int LmsSurveyDelete(BLLLmsSurvey _obj)
        {
        return objdal.LmsSurveyDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSurveyFetch(BLLLmsSurvey _obj)
        {
        return objdal.LmsSurveySelect(_obj);
        }

    public DataTable LmsSurveyFetchByStatusID(BLLLmsSurvey _obj)
    {
        return objdal.LmsSurveySelectByStatusID(_obj);
    }

    public DataTable LmsSurveySelectAllBySurveyId(BLLLmsSurvey _obj)
    {
        return objdal.LmsSurveySelectAllBySurveyId(_obj);
    }




    public DataTable LmsSurveySelectAllBySectionSubjectIdWrkToolId(BLLLmsSurvey _obj)
    {
        return objdal.LmsSurveySelectAllBySectionSubjectIdWrkToolId(_obj);
    }


    public DataTable LmsSurveySelectAllForSubmission(BLLLmsSurvey _obj)
    {
        return objdal.LmsSurveySelectAllForSubmission(_obj);
    }


    public DataTable LmsSurveyFetch(int _id)
      {
        return objdal.LmsSurveySelect(_id);
      }


    #endregion

    }
