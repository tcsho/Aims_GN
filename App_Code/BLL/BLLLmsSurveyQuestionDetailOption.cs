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
/// Summary description for BLLLmsSurveyQuestionDetailOption
/// </summary>



public class BLLLmsSurveyQuestionDetailOption
    {
    public BLLLmsSurveyQuestionDetailOption()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSurveyQuestionDetailOption objdal = new DALLmsSurveyQuestionDetailOption();



    #region 'Start Properties Declaration'
    public int QuestionDetailOption_Id { get; set; }
    public string QuestionDetailOption { get; set; }
    public int Status_Id { get; set; }
    public int Score { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsSurveyQuestionDetailOptionAdd(BLLLmsSurveyQuestionDetailOption _obj)
        {
        return objdal.LmsSurveyQuestionDetailOptionAdd(_obj);
        }
    public int LmsSurveyQuestionDetailOptionUpdate(BLLLmsSurveyQuestionDetailOption _obj)
        {
        return objdal.LmsSurveyQuestionDetailOptionUpdate(_obj);
        }
    public int LmsSurveyQuestionDetailOptionDelete(BLLLmsSurveyQuestionDetailOption _obj)
        {
        return objdal.LmsSurveyQuestionDetailOptionDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSurveyQuestionDetailOptionFetch(BLLLmsSurveyQuestionDetailOption _obj)
        {
        return objdal.LmsSurveyQuestionDetailOptionSelect(_obj);
        }

    public DataTable LmsSurveyQuestionDetailOptionFetchByStatusID(BLLLmsSurveyQuestionDetailOption _obj)
    {
        return objdal.LmsSurveyQuestionDetailOptionSelectByStatusID(_obj);
    }



    public DataTable LmsSurveyQuestionDetailOptionFetch(int _id)
      {
        return objdal.LmsSurveyQuestionDetailOptionSelect(_id);
      }


    #endregion

    }
