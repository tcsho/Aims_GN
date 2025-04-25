using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALClass_Center
/// </summary>
public class DALClass_Center
{
    DALBase dalobj = new DALBase();


    public DALClass_Center()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Class_CenterAdd(BLLClass_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        ////param[0] = new SqlParameter("@Class_Center_ID", SqlDbType.Int); 
        ////param[0].Value = objbll.Class_Center_ID;
        param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[0].Value = objbll.Class_ID;
        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = objbll.Center_ID;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;


        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_CenterInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int Class_CenterUpdate(BLLClass_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        ////param[0] = new SqlParameter("@Class_Center_ID", SqlDbType.Int); 
        ////param[0].Value = objbll.Class_Center_ID;
        param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[0].Value = objbll.Class_ID;
        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = objbll.Center_ID;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;


 
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_CenterUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int Class_CenterDelete(BLLClass_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_Center_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Class_Center_Id;


        int k = dalobj.sqlcmdExecute("Class_CenterDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Class_CenterSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Class_CenterSelectByCenter_Id", param);
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

    public DataTable Class_CenterSelect(BLLClass_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_CenterSelectByCenter_Id", param);
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
    public DataTable Class_CenterSelect_OA_Level(BLLClass_Center objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_CenterSelectByCenter_Id_OALevel", param);
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
    public DataTable Class_CenterSelectByStatusID(BLLClass_Center objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_CenterSelectByStatusID");
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
