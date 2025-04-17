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
/// Summary description for BLLLmsPollsSubmissionsUser
/// </summary>



public class BLLLmsPollsSubmissionsUser
    {
    public BLLLmsPollsSubmissionsUser()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsPollsSubmissionsUser objdal = new DALLmsPollsSubmissionsUser();



    #region 'Start Properties Declaration'

    public int LmsPollsSubmissionsUser_ID { get; set; }
    public int User_ID { get; set; }
    public int Poll_ID { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsPollsSubmissionsUserAdd(BLLLmsPollsSubmissionsUser _obj)
        {
        return objdal.LmsPollsSubmissionsUserAdd(_obj);
        }
    public int LmsPollsSubmissionsUserUpdate(BLLLmsPollsSubmissionsUser _obj)
        {
        return objdal.LmsPollsSubmissionsUserUpdate(_obj);
        }
    public int LmsPollsSubmissionsUserDelete(BLLLmsPollsSubmissionsUser _obj)
        {
        return objdal.LmsPollsSubmissionsUserDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsPollsSubmissionsUserFetch(BLLLmsPollsSubmissionsUser _obj)
        {
        return objdal.LmsPollsSubmissionsUserSelect(_obj);
        }

    public DataTable LmsPollsSubmissionsUserFetchByStatusID(BLLLmsPollsSubmissionsUser _obj)
    {
        return objdal.LmsPollsSubmissionsUserSelectByStatusID(_obj);
    }



    public DataTable LmsPollsSubmissionsUserFetch(int _id)
      {
        return objdal.LmsPollsSubmissionsUserSelect(_id);
      }


    public DataTable LmsPollsSubmissionsUserSelectPollIdUserId(BLLLmsPollsSubmissionsUser _obj)
    {
        return objdal.LmsPollsSubmissionsUserSelectPollIdUserId(_obj);
    }



    #endregion

    }
