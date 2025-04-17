using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALSubject
/// </summary>
public class DALSubject
{
    DALBase dalobj = new DALBase();


    public DALSubject()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int SubjectAdd(BLLSubject objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        //param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Subject_Id;
        param[0] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar); 
        param[0].Value = objbll.Subject_Name;
        param[1] = new SqlParameter("@Subject_Code", SqlDbType.NVarChar); 
        param[1].Value = objbll.Subject_Code;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.NVarChar); 
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@Comments", SqlDbType.NVarChar); 
        param[3].Value = objbll.Comments;
        param[4] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int); 
        param[4].Value = objbll.Main_Organisation_Id;
        param[5] = new SqlParameter("@isKPI", SqlDbType.NVarChar); 
        param[5].Value = objbll.isKPI;
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SubjectInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int SubjectUpdate(BLLSubject objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        //param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Subject_Id;
        param[0] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Subject_Name;
        param[1] = new SqlParameter("@Subject_Code", SqlDbType.Int);
        param[1].Value = objbll.Subject_Code;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.NVarChar);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@Comments", SqlDbType.Int);
        param[3].Value = objbll.Comments;
        param[4] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[4].Value = objbll.Main_Organisation_Id;
        param[5] = new SqlParameter("@isKPI", SqlDbType.NVarChar);
        param[5].Value = objbll.isKPI;
        param[6] = new SqlParameter("@SortOrder", SqlDbType.NVarChar);
        param[6].Value = objbll.SortOrder;


 
        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SubjectUpdate", param);
        int k = (int)param[7].Value;
        return k;
    }
    public int SubjectDelete(BLLSubject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Subject_Id;


        int k = dalobj.sqlcmdExecute("SubjectDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable SubjectSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("SubjectSelectById", param);
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
    
    public DataTable SubjectSelect(BLLSubject objbll)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
    param[0].Value = objbll.Main_Organisation_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("SubjectSelectAll", param);
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


    public DataTable SubjectSelectAllWithSubNameGroup(BLLSubject objbll)
    {
        
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SubjectSelectAllWithSubNameGroup");
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

    public DataTable SubjectFetchByClassIDSeatPlan(BLLSubject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[0].Value = objbll.Class_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SubjectFetchByClassIDSeatPlan", param);
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

    public DataTable SubjectFetchByClassID(BLLSubject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[0].Value = objbll.Class_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SubjectFetchByClassID", param);
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
    public DataTable SubjectSelectByStatusID(BLLSubject objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SubjectSelectByStatusID");
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

    public DataTable SubjectFetchByClassIDSeatPlan_(BLLSubject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[0].Value = objbll.Class_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SubjectFetchByClassIDSeatPlan_", param);
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
    public int AssignSubject(BLLSubject objbll)
    {
        try
        {
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
            param[0].Value = objbll.Class_ID;
            param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
            param[1].Value = objbll.Subject_Id;
            param[2] = new SqlParameter("@Region_id", SqlDbType.Int);
            param[2].Value = objbll.Region_id;
            param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
            param[3].Direction = ParameterDirection.Output;

            dalobj.sqlcmdExecute("Class_SubjectAssign", param);
            int k = (int)param[2].Value;
            return k;
        }
        catch (Exception ex)
        {
            throw ex;
        }


    }
    public DataTable SubjectFetchByMoId(int id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@MoId", SqlDbType.Int);
        param[0].Value = id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SubjectSelectByMoId", param);
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
    public int SubjectNameAvailability(BLLSubject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Subject_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Subject_Name;
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SubjectNameAvailibility", param);
        int k = (int)param[1].Value;
        return k;

    }
    public int SubjectCodeAvailability(BLLSubject objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Subject_Code", SqlDbType.NVarChar);
        param[0].Value = objbll.Subject_Code;
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SubjectCodeAvailibility", param);
        int k = (int)param[1].Value;
        return k;

    }
}
