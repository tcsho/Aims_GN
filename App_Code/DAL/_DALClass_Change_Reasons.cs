using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALClass_Change_Reasons
/// </summary>
public class DALClass_Change_Reasons
{
    DALBase dalobj = new DALBase();


    public DALClass_Change_Reasons()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Class_Change_ReasonsAdd(BLLClass_Change_Reasons objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@CCReason_Id", SqlDbType.Int); param[0].Value = objbll.CCReason_Id;
        param[1] = new SqlParameter("@Reason_Description", SqlDbType.NVarChar); param[1].Value = (objbll.Reason_Description != null) ? objbll.Reason_Description : "";
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int); param[2].Value = objbll.Status_Id;


        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_Change_ReasonsInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int Class_Change_ReasonsUpdate(BLLClass_Change_Reasons objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@CCReason_Id", SqlDbType.Int); param[0].Value = objbll.CCReason_Id;
        param[1] = new SqlParameter("@Reason_Description", SqlDbType.NVarChar); param[1].Value = (objbll.Reason_Description != null) ? objbll.Reason_Description : "";
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int); param[2].Value = objbll.Status_Id;

        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_Change_ReasonsUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Class_Change_ReasonsDelete(BLLClass_Change_Reasons objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_Change_Reasons_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Class_Change_Reasons_Id;


        int k = dalobj.sqlcmdExecute("Class_Change_ReasonsDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Class_Change_ReasonsSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Class_Change_ReasonsSelectById", param);
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;
    }

    public DataTable Class_Change_ReasonsSelect()
    {

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Class_Change_ReasonsSelectAll");
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }

    public DataTable Class_Change_ReasonsSelectByStatusID(BLLClass_Change_Reasons objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Class_Change_ReasonsSelectByStatusID");
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }




    #endregion


}
