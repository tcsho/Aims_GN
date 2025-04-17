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
/// Summary description for BLLLmsSurveySubmissionsUser
/// </summary>



public class BLLLmsSurveySubmissionsUser
    {
    public BLLLmsSurveySubmissionsUser()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSurveySubmissionsUser objdal = new DALLmsSurveySubmissionsUser();



    #region 'Start Properties Declaration'

    public int LmsSurveySubmissionsUser_ID { get; set; }
    public int User_ID { get; set; }
    public int Survey_ID { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsSurveySubmissionsUserAdd(BLLLmsSurveySubmissionsUser _obj)
        {
        return objdal.LmsSurveySubmissionsUserAdd(_obj);
        }
    public int LmsSurveySubmissionsUserUpdate(BLLLmsSurveySubmissionsUser _obj)
        {
        return objdal.LmsSurveySubmissionsUserUpdate(_obj);
        }
    public int LmsSurveySubmissionsUserDelete(BLLLmsSurveySubmissionsUser _obj)
        {
        return objdal.LmsSurveySubmissionsUserDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSurveySubmissionsUserFetch(BLLLmsSurveySubmissionsUser _obj)
        {
        return objdal.LmsSurveySubmissionsUserSelect(_obj);
        }

    public DataTable LmsSurveySubmissionsUserFetchByStatusID(BLLLmsSurveySubmissionsUser _obj)
    {
        return objdal.LmsSurveySubmissionsUserSelectByStatusID(_obj);
    }



    public DataTable LmsSurveySubmissionsUserFetch(int _id)
      {
        return objdal.LmsSurveySubmissionsUserSelect(_id);
      }


    public DataTable LmsSurveySubmissionsUserSelectSurveyIdUserId(BLLLmsSurveySubmissionsUser _obj)
    {
        return objdal.LmsSurveySubmissionsUserSelectSurveyIdUserId(_obj);
    }



    #endregion

    }
