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
/// Summary description for BLLLmsFormResponse
/// </summary>



public class BLLLmsFormResponse
    {
    public BLLLmsFormResponse()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsFormResponse objdal = new DALLmsFormResponse();



    #region 'Start Properties Declaration'

    public int Response_ID { get; set; }
    public int Topic_ID { get; set; }
    public string Message { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public int ObtainePoints { get; set; }
    public int ParentResponse_ID { get; set; }
    public int Participant_ID { get; set; }
    public int Status_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int LmsFormResponseAdd(BLLLmsFormResponse _obj)
        {
        return objdal.LmsFormResponseAdd(_obj);
        }
    public int LmsFormResponseUpdate(BLLLmsFormResponse _obj)
        {
        return objdal.LmsFormResponseUpdate(_obj);
        }

    public int LmsFormResponseUpdateObtainPoint(BLLLmsFormResponse _obj)
    {
        return objdal.LmsFormResponseUpdateObtainPoint(_obj);
    }


    public int LmsFormResponseDelete(BLLLmsFormResponse _obj)
        {
        return objdal.LmsFormResponseDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsFormResponseFetch(BLLLmsFormResponse _obj)
        {
        return objdal.LmsFormResponseSelect(_obj);
        }

    public DataTable LmsFormResponseFetchByStatusID(BLLLmsFormResponse _obj)
    {
        return objdal.LmsFormResponseSelectByStatusID(_obj);
    }



    public DataTable LmsFormResponseFetch(int _id)
      {
        return objdal.LmsFormResponseSelect(_id);
      }


    #endregion

    }
