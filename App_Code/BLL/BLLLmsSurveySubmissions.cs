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
/// Summary description for BLLLmsSurveySubmissions
/// </summary>



public class BLLLmsSurveySubmissions
    {
    public BLLLmsSurveySubmissions()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSurveySubmissions objdal = new DALLmsSurveySubmissions();



    #region 'Start Properties Declaration'
    public int SurveySubmission_ID { get; set; }
    public int Survey_ID { get; set; }
    public int SurveyDetail_ID { get; set; }
    public int Participant_ID { get; set; }
    public int QuestionDetailOption_Id { get; set; }
    public string QuestionDetailOption { get; set; }
    public int LmsSurveySubmissionsUser_ID { get; set; }
    public int User_Id { get; set; }





    #endregion

    #region 'Start Executaion Methods'

    public int LmsSurveySubmissionsAdd(BLLLmsSurveySubmissions _obj)
        {
        return objdal.LmsSurveySubmissionsAdd(_obj);
        }
    public int LmsSurveySubmissionsUpdate(BLLLmsSurveySubmissions _obj)
        {
        return objdal.LmsSurveySubmissionsUpdate(_obj);
        }
    public int LmsSurveySubmissionsDelete(BLLLmsSurveySubmissions _obj)
        {
        return objdal.LmsSurveySubmissionsDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSurveySubmissionsFetch(BLLLmsSurveySubmissions _obj)
        {
        return objdal.LmsSurveySubmissionsSelect(_obj);
        }

    public DataTable LmsSurveySubmissionsFetchByStatusID(BLLLmsSurveySubmissions _obj)
    {
        return objdal.LmsSurveySubmissionsSelectByStatusID(_obj);
    }



    public DataTable LmsSurveySubmissionsFetch(int _id)
      {
        return objdal.LmsSurveySubmissionsSelect(_id);
      }


    public DataTable LmsSurveySubmissionselectAllbySurveyId(BLLLmsSurveySubmissions _obj)
    {
        return objdal.LmsSurveySubmissionselectAllbySurveyId(_obj);
    }



    #endregion

    }
