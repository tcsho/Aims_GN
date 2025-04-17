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
/// Summary description for BLLAdmTestSubmissionDetail
/// </summary>



public class BLLAdmTestSubmissionDetail
{
    public BLLAdmTestSubmissionDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmTestSubmissionDetail objdal = new DALAdmTestSubmissionDetail();



    #region 'Start Properties Declaration'

    public int AdmTestSubmDetail_ID { get; set; }
    public int AdmTest_ID { get; set; }
    public bool isCorrect { get; set; }
    public int Quest_ID { get; set; }
    public string TeacherComments { get; set; }
    public int AdmTestSubm_ID { get; set; }
    public int? QuestDetail_ID { get; set; }
    public int AnswerInSeconds { get; set; }
    public bool IsNotAnswered { get; set; }



    public int User_ID { get; set; }




    #endregion

    #region 'Start Executaion Methods'

    public int AdmTestSubmissionAdd(BLLAdmTestSubmissionDetail _obj)
    {
        return objdal.AdmTestSubmissionAdd(_obj);
    }
    public int AdmTestSubmissionDetailUpdate(BLLAdmTestSubmissionDetail _obj)
    {
        return objdal.AdmTestSubmissionDetailUpdate(_obj);
    }
    public int AdmTestSubmissionDetailUpdateTimeOnly(BLLAdmTestSubmissionDetail _obj)
    {
        return objdal.AdmTestSubmissionDetailUpdateTimeOnly(_obj);
    }
    public int AdmTestAnswersDelete(BLLAdmTestSubmissionDetail _obj)
    {
        return objdal.AdmTestAnswersDelete(_obj);

    }


    public DataTable AdmTestSubmissionDetailSelectAllQuestionsByUserId(BLLAdmTestSubmissionDetail _obj)
    {
        return objdal.AdmTestSubmissionDetailSelectAllQuestionsByUserId(_obj);
    }



    public DataTable AdmTestSubmissionDetailSelectAllQuestionsByUserIdOneByOne(BLLAdmTestSubmissionDetail _obj)
    {
        return objdal.AdmTestSubmissionDetailSelectAllQuestionsByUserIdOneByOne(_obj);
    }






    #endregion
    #region 'Start Fetch Methods'


    public DataTable AdmTestAnswersFetch(BLLAdmTestSubmissionDetail _obj)
    {
        return objdal.AdmTestAnswersSelect(_obj);
    }

    public DataTable AdmTestAnswersFetchByStatusID(BLLAdmTestSubmissionDetail _obj)
    {
        return objdal.AdmTestAnswersSelectByStatusID(_obj);
    }



    public DataTable AdmTestAnswersFetch(int _id)
    {
        return objdal.AdmTestAnswersSelect(_id);
    }


    #endregion

}
