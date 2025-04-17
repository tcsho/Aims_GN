using System;
using System.Data;


/// <summary>
/// Summary description for BLLSession_Center
/// </summary>



public class BLLSession_Center
    {
    public BLLSession_Center()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSession_Center objdal = new DALSession_Center();



    #region 'Start Properties Declaration'
    public int Session_Center_ID { get; set; }
    public int Session_ID { get; set; }
    public int Center_ID { get; set; }
    public int Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Session_CenterAdd(BLLSession_Center _obj)
        {
        return objdal.Session_CenterAdd(_obj);
        }
    public int Session_CenterUpdate(BLLSession_Center _obj)
        {
        return objdal.Session_CenterUpdate(_obj);
        }
    public int Session_CenterDelete(BLLSession_Center _obj)
        {
        return objdal.Session_CenterDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Session_CenterFetch(BLLSession_Center _obj)
        {
        return objdal.Session_CenterSelect(_obj);
        }

    public DataTable Session_CenterFetchByStatusID(BLLSession_Center _obj)
    {
        return objdal.Session_CenterSelectByStatusID(_obj);
    }



    public DataTable Session_CenterFetch(int _id)
      {
        return objdal.Session_CenterSelect(_id);
      }


    #endregion

    }
