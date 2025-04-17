using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALSession_Center
/// </summary>
public class DALSession_Center
{
    DALBase dalobj = new DALBase();


    public DALSession_Center()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Session_CenterAdd(BLLSession_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        ////param[0] = new SqlParameter("@Session_Center_ID", SqlDbType.Int);
        ////param[0].Value = objbll.Session_Center_ID;
        param[0] = new SqlParameter("@Session_ID", SqlDbType.Int); 
        param[0].Value = objbll.Session_ID;
        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = objbll.Center_ID;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;


        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Session_CenterInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int Session_CenterUpdate(BLLSession_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_ID", SqlDbType.Int);
        param[0].Value = objbll.Session_ID;
        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = objbll.Center_ID;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;

 
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Session_CenterUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Session_CenterDelete(BLLSession_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Session_Center_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Session_Center_Id;


        int k = dalobj.sqlcmdExecute("Session_CenterDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Session_CenterSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Session_CenterSelectById", param);
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
    
    public DataTable Session_CenterSelect(BLLSession_Center objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Session_CenterSelectAll", param);
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

    public DataTable Session_CenterSelectByStatusID(BLLSession_Center objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Session_CenterSelectByStatusID");
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




    #endregion


}
