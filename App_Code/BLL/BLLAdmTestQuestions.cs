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
/// Summary description for BLLAdmTestQuestions
/// </summary>



public class BLLAdmTestQuestions
{
    public BLLAdmTestQuestions()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmTestQuestions objdal = new DALAdmTestQuestions();



    #region 'Start Properties Declaration'
    public int Quest_ID { get; set; }
    
    public decimal AnsPointValue { get; set; }
    public string QuesText { get; set; }
    public decimal NegtvPointValue { get; set; }
    public int Sequence_ID { get; set; }
    public string Comments { get; set; }
    public int QuestType_ID { get; set; }
    public int Status_ID { get; set; }
    public int TimeInSeconds { get; set; }
    public int Pool_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int AdmTestQuestionsAdd(BLLAdmTestQuestions _obj)
    {
        return objdal.AdmTestQuestionsAdd(_obj);
    }
    public int AdmTestQuestionsUpdate(BLLAdmTestQuestions _obj)
    {
        return objdal.AdmTestQuestionsUpdate(_obj);
    }
    public int AdmTestQuestionsDelete(BLLAdmTestQuestions _obj)
    {
        return objdal.AdmTestQuestionsDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable AdmTestQuestionsFetch(BLLAdmTestQuestions _obj)
    {
        return objdal.AdmTestQuestionsSelect(_obj);
    }



    public DataTable AdmTestQuestionsSelectAllByAdmTestDetailId(BLLAdmTestQuestions _obj)
    {
        return objdal.AdmTestQuestionsSelectAllByAdmTestDetailId(_obj);
    }


    public DataTable AdmTestQuestionsSelectAllByAdmTestDetailIdQuestId(BLLAdmTestQuestions _obj)
    {
        return objdal.AdmTestQuestionsSelectAllByAdmTestDetailIdQuestId(_obj);
    }



    public DataTable AdmTestQuestionsFetchByStatusID(BLLAdmTestQuestions _obj)
    {
        return objdal.AdmTestQuestionsSelectByStatusID(_obj);
    }



    public DataTable AdmTestQuestionsFetch(int _id)
    {
        return objdal.AdmTestQuestionsSelect(_id);
    }

    #endregion

}
