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
/// Summary description for BLLAdmTestQuestionsDetail
/// </summary>



public class BLLAdmTestQuestionsDetail
{
    public BLLAdmTestQuestionsDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmTestQuestionsDetail objdal = new DALAdmTestQuestionsDetail();



    #region 'Start Properties Declaration'

    public int QuestDetail_ID { get; set; }
    public int Quest_ID { get; set; }
    public string Options { get; set; }
    public bool IsCorrect { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int AdmTestQuestionsDetailAdd(BLLAdmTestQuestionsDetail _obj)
    {
        return objdal.AdmTestQuestionsDetailAdd(_obj);
    }
    public int AdmTestQuestionsDetailUpdate(BLLAdmTestQuestionsDetail _obj)
    {
        return objdal.AdmTestQuestionsDetailUpdate(_obj);
    }
    public int AdmTestQuestionsDetailDelete(BLLAdmTestQuestionsDetail _obj)
    {
        return objdal.AdmTestQuestionsDetailDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable AdmTestQuestionsDetailFetch(BLLAdmTestQuestionsDetail _obj)
    {
        return objdal.AdmTestQuestionsDetailSelect(_obj);
    }


    public DataTable AdmTestQuestionsDetailSelectAllByQuestId(BLLAdmTestQuestionsDetail _obj)
    {
        return objdal.AdmTestQuestionsDetailSelectAllByQuestId(_obj);
    }

    public DataTable AdmTestQuestionsDetailSelectAllByQuestIdDetailId(BLLAdmTestQuestionsDetail _obj)
    {
        return objdal.AdmTestQuestionsDetailSelectAllByQuestIdDetailId(_obj);
    }


    public DataTable AdmTestQuestionsDetailFetchByStatusID(BLLAdmTestQuestionsDetail _obj)
    {
        return objdal.AdmTestQuestionsDetailSelectByStatusID(_obj);
    }



    public DataTable AdmTestQuestionsDetailFetch(int _id)
    {
        return objdal.AdmTestQuestionsDetailSelect(_id);
    }


    public DataTable AdmTestQuestionsDetailSelectAllByQuestionId(BLLAdmTestQuestionsDetail _obj)
    {
        return objdal.AdmTestQuestionsDetailSelectAllByQuestionId(_obj);
    }


    public DataTable AdmTestQuestionsDetailSelectAllBySkipQuestionId(BLLAdmTestQuestionsDetail _obj)
    {
        return objdal.AdmTestQuestionsDetailSelectAllBySkipQuestionId(_obj);
    }




    #endregion

}
