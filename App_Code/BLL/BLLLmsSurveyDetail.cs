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
/// Summary description for BLLLmsSurveyDetail
/// </summary>



public class BLLLmsSurveyDetail
    {
    public BLLLmsSurveyDetail()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSurveyDetail objdal = new DALLmsSurveyDetail();



    #region 'Start Properties Declaration'

    public int SurveyDetail_ID { get; set; }
    public int Survey_ID { get; set; }
    public string QstDetails { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsSurveyDetailAdd(BLLLmsSurveyDetail _obj)
        {
        return objdal.LmsSurveyDetailAdd(_obj);
        }
    public int LmsSurveyDetailUpdate(BLLLmsSurveyDetail _obj)
        {
        return objdal.LmsSurveyDetailUpdate(_obj);
        }
    public int LmsSurveyDetailDelete(BLLLmsSurveyDetail _obj)
        {
        return objdal.LmsSurveyDetailDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSurveyDetailFetch(BLLLmsSurveyDetail _obj)
        {
        return objdal.LmsSurveyDetailSelect(_obj);
        }

    public DataTable LmsSurveyDetailFetchByStatusID(BLLLmsSurveyDetail _obj)
    {
        return objdal.LmsSurveyDetailSelectByStatusID(_obj);
    }


    public DataTable LmsSurveyDetailSelectAllBySurveyId(BLLLmsSurveyDetail _obj)
    {
        return objdal.LmsSurveyDetailSelectAllBySurveyId(_obj);
    }


    public DataTable LmsSurveyDetailSelectAllBySurveyDetailID(BLLLmsSurveyDetail _obj)
    {
        return objdal.LmsSurveyDetailSelectAllBySurveyDetailID(_obj);
    }





    public DataTable LmsSurveyDetailFetch(int _id)
      {
        return objdal.LmsSurveyDetailSelect(_id);
      }


    #endregion

    }
