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
/// Summary description for BLLAdmTestAnswers
/// </summary>



public class BLLAdmTestAnswers
    {
    public BLLAdmTestAnswers()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALAdmTestAnswers objdal = new DALAdmTestAnswers();



    #region 'Start Properties Declaration'

    public int Answer_ID { get; set; }
    public bool isCorrect { get; set; }
    public int Quest_ID { get; set; }
    public string TeacherComments { get; set; }
    public int AdmTestSubm_ID { get; set; }
    public int QuestDetail_ID { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int AdmTestAnswersAdd(BLLAdmTestAnswers _obj)
        {
        return objdal.AdmTestAnswersAdd(_obj);
        }
    public int AdmTestAnswersUpdate(BLLAdmTestAnswers _obj)
        {
        return objdal.AdmTestAnswersUpdate(_obj);
        }
    public int AdmTestAnswersDelete(BLLAdmTestAnswers _obj)
        {
        return objdal.AdmTestAnswersDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable AdmTestAnswersFetch(BLLAdmTestAnswers _obj)
        {
        return objdal.AdmTestAnswersSelect(_obj);
        }

    public DataTable AdmTestAnswersFetchByStatusID(BLLAdmTestAnswers _obj)
    {
        return objdal.AdmTestAnswersSelectByStatusID(_obj);
    }



    public DataTable AdmTestAnswersFetch(int _id)
      {
        return objdal.AdmTestAnswersSelect(_id);
      }


    #endregion

    }
