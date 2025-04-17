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
/// Summary description for BLLLmsPollsQuestionDetail
/// </summary>



public class BLLLmsPollsQuestionDetail
    {
    public BLLLmsPollsQuestionDetail()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsPollsQuestionDetail objdal = new DALLmsPollsQuestionDetail();



    #region 'Start Properties Declaration'
    public int LmsPollsQuestionDetail_Id { get; set; }
    public int PollDetail_ID { get; set; }
    public int QuestionDetailOption_Id { get; set; }
    public string QuestionDetailOption { get; set; }
    public int Status_Id { get; set; }
    public int Score { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsPollsQuestionDetailAdd(BLLLmsPollsQuestionDetail _obj)
        {
        return objdal.LmsPollsQuestionDetailAdd(_obj);
        }
    public int LmsPollsQuestionDetailUpdate(BLLLmsPollsQuestionDetail _obj)
        {
        return objdal.LmsPollsQuestionDetailUpdate(_obj);
        }
    public int LmsPollsQuestionDetailDelete(BLLLmsPollsQuestionDetail _obj)
        {
        return objdal.LmsPollsQuestionDetailDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsPollsQuestionDetailFetch(BLLLmsPollsQuestionDetail _obj)
        {
        return objdal.LmsPollsQuestionDetailSelect(_obj);
        }

    public DataTable LmsPollsQuestionDetailFetchByStatusID(BLLLmsPollsQuestionDetail _obj)
    {
        return objdal.LmsPollsQuestionDetailSelectByStatusID(_obj);
    }



    public DataTable LmsPollsQuestionDetailFetch(int _id)
      {
        return objdal.LmsPollsQuestionDetailSelect(_id);
      }


    #endregion

    }
