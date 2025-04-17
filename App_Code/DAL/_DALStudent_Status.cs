using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent_Status
/// </summary>
public class DALStudent_Status
{
    DALBase dalobj = new DALBase();


    public DALStudent_Status()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_StatusAdd(BLLStudent_Status objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Status_Id", SqlDbType.Int); 
        param[0].Value = objbll.Student_Status_Id;
        param[1] = new SqlParameter("@Student_Status", SqlDbType.NVarChar); 
        param[1].Value = objbll.Student_Status;


        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_StatusInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int Student_StatusUpdate(BLLStudent_Status objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Status_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Status_Id;
        param[1] = new SqlParameter("@Student_Status", SqlDbType.NVarChar);
        param[1].Value = objbll.Student_Status;
 
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_StatusUpdate", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int Student_StatusDelete(BLLStudent_Status objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Status_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Status_Id;


        int k = dalobj.sqlcmdExecute("Student_StatusDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_StatusSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_StatusSelectById", param);
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
    
    public DataTable Student_StatusSelect(BLLStudent_Status objbll)
    {

    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Student_StatusSelectAll");
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

    public DataTable Student_StatusSelectByStatusID(BLLStudent_Status objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_StatusSelectByStatusID");
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
