using System;
using System.Data;


/// <summary>
/// Summary description for BLLSession
/// </summary>
public class BLLSession
{
    _DALSession objDAL = new _DALSession();


    private int status_Id;

    public int Status_Id
    {
        get { return status_Id; }
        set { status_Id = value; }
    }

    private int center_Id;

    public int Center_Id
    {
        get { return center_Id; }
        set { center_Id = value; }
    }

    private string status;

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    public int Session_Id { get; set; }
    public string Description { get; set; }
    public int Main_Organisation_Id { get; set; }
    //public int Status_Id { get; set; }
    public DateTime GSessionStartDate { get; set; }
    public DateTime GSessionEndDate { get; set; }
    public bool isShown { get; set; }

    public DataTable SessionSelectAll()
    {
        return objDAL.SessionSelectAll();
    }
    public DataTable SessionSelectActiveByCenter(BLLSession bllSes)
    {
        return objDAL.SessionSelectActiveByCenter(bllSes);
    }
    public DataTable SessionSelectAllActive()
    {
        return objDAL.SessionSelectAllActive();
    }

    public BLLSession()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    #region 'Start Executaion Methods'

    public int SessionAdd(BLLSession _obj)
    {
        return objDAL.SessionAdd(_obj);
    }
    public int SessionUpdate(BLLSession _obj)
    {
        return objDAL.SessionUpdate(_obj);
    }
    public int SessionDelete(BLLSession _obj)
    {
        return objDAL.SessionDelete(_obj);

    }

    #endregion


    #region 'Start Fetch Methods'


    public DataTable SessionFetch(BLLSession _obj)
    {
        return objDAL.SessionSelect(_obj);
    }

    public DataTable SessionFetchByStatusID(BLLSession _obj)
    {
        return objDAL.SessionSelectByStatusID(_obj);
    }

    public DataTable SessionSelectAllActiveArchieve()
    {
        return objDAL.SessionSelectAllActiveArchieve();
    }

    public DataTable SessionFetch(int _id)
    {
        return objDAL.SessionSelect(_id);
    }


    #endregion
}
