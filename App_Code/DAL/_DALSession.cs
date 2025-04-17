using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALSession
/// </summary>
public class _DALSession
{
    DALBase dalobj = new DALBase();

    public _DALSession()
    {
        //
        // TODO: Add constructor logic here
        //

    }

    public DataTable SessionSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SessionSelectAll");
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public DataTable SessionSelectActiveByCenter(BLLSession bllSes)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[0].Value = bllSes.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Session_CenterByActive", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;
    }

    public DataTable SessionSelectAllActive()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SessionSelectAllActive");
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }


    #region 'Start of Execution Methods'
    public int SessionAdd(BLLSession objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        //////////param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        //////////param[0].Value = objbll.Session_Id;
        param[0] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[0].Value = objbll.Description;
        param[1] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organisation_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@GSessionStartDate", SqlDbType.DateTime);
        param[3].Value = objbll.GSessionStartDate;
        param[4] = new SqlParameter("@GSessionEndDate", SqlDbType.DateTime);
        param[4].Value = objbll.GSessionEndDate;
        param[5] = new SqlParameter("@isShown", SqlDbType.Bit);
        param[5].Value = objbll.isShown;




        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SessionInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int SessionUpdate(BLLSession objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[0].Value = objbll.Description;
        param[1] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organisation_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@GSessionStartDate", SqlDbType.DateTime);
        param[3].Value = objbll.GSessionStartDate;
        param[4] = new SqlParameter("@GSessionEndDate", SqlDbType.DateTime);
        param[4].Value = objbll.GSessionEndDate;
        param[5] = new SqlParameter("@isShown", SqlDbType.Bit);
        param[5].Value = objbll.isShown;


        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SessionUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int SessionDelete(BLLSession objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Session_Id;


        int k = dalobj.sqlcmdExecute("SessionDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable SessionSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SessionSelectById", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;
    }

    public DataTable SessionSelect(BLLSession objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SessionSelectAll", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable SessionSelectByStatusID(BLLSession objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SessionSelectByStatusID");
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable SessionSelectAllActiveArchieve()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SessionSelectAllActiveArchive");
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }


    #endregion
}
