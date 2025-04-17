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
/// Summary description for BLLLmsPollsQuestionDetailOption
/// </summary>



public class BLLLmsPollsQuestionDetailOption
    {
    public BLLLmsPollsQuestionDetailOption()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsPollsQuestionDetailOption objdal = new DALLmsPollsQuestionDetailOption();



    #region 'Start Properties Declaration'
    public int QuestionDetailOption_Id { get; set; }
    public string QuestionDetailOption { get; set; }
    public int Status_Id { get; set; }
    public int Score { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsPollsQuestionDetailOptionAdd(BLLLmsPollsQuestionDetailOption _obj)
        {
        return objdal.LmsPollsQuestionDetailOptionAdd(_obj);
        }
    public int LmsPollsQuestionDetailOptionUpdate(BLLLmsPollsQuestionDetailOption _obj)
        {
        return objdal.LmsPollsQuestionDetailOptionUpdate(_obj);
        }
    public int LmsPollsQuestionDetailOptionDelete(BLLLmsPollsQuestionDetailOption _obj)
        {
        return objdal.LmsPollsQuestionDetailOptionDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsPollsQuestionDetailOptionFetch(BLLLmsPollsQuestionDetailOption _obj)
        {
        return objdal.LmsPollsQuestionDetailOptionSelect(_obj);
        }

    public DataTable LmsPollsQuestionDetailOptionFetchByStatusID(BLLLmsPollsQuestionDetailOption _obj)
    {
        return objdal.LmsPollsQuestionDetailOptionSelectByStatusID(_obj);
    }



    public DataTable LmsPollsQuestionDetailOptionFetch(int _id)
      {
        return objdal.LmsPollsQuestionDetailOptionSelect(_id);
      }


    #endregion

    }
