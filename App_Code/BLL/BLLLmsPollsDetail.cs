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
/// Summary description for BLLLmsPollsDetail
/// </summary>



public class BLLLmsPollsDetail
    {
    public BLLLmsPollsDetail()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsPollsDetail objdal = new DALLmsPollsDetail();



    #region 'Start Properties Declaration'

    public int PollDetail_ID { get; set; }
    public int Poll_ID { get; set; }
    public string QstDetails { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsPollsDetailAdd(BLLLmsPollsDetail _obj)
        {
        return objdal.LmsPollsDetailAdd(_obj);
        }
    public int LmsPollsDetailUpdate(BLLLmsPollsDetail _obj)
        {
        return objdal.LmsPollsDetailUpdate(_obj);
        }
    public int LmsPollsDetailDelete(BLLLmsPollsDetail _obj)
        {
        return objdal.LmsPollsDetailDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsPollsDetailFetch(BLLLmsPollsDetail _obj)
        {
        return objdal.LmsPollsDetailSelect(_obj);
        }

    public DataTable LmsPollsDetailFetchByStatusID(BLLLmsPollsDetail _obj)
    {
        return objdal.LmsPollsDetailSelectByStatusID(_obj);
    }


    public DataTable LmsPollsDetailSelectAllByPollId(BLLLmsPollsDetail _obj)
    {
        return objdal.LmsPollsDetailSelectAllByPollId(_obj);
    }


    public DataTable LmsPollsDetailSelectAllByPollDetailID(BLLLmsPollsDetail _obj)
    {
        return objdal.LmsPollsDetailSelectAllByPollDetailID(_obj);
    }





    public DataTable LmsPollsDetailFetch(int _id)
      {
        return objdal.LmsPollsDetailSelect(_id);
      }


    #endregion

    }
