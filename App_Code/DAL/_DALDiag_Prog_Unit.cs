using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALDiag_Prog_Unit
/// </summary>
public class DALDiag_Prog_Unit
{
    DALBase dalobj = new DALBase();


    public DALDiag_Prog_Unit()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Diag_Prog_UnitAdd(BLLDiag_Prog_Unit objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[0].Value = objbll.Subject_Id;
        
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int); 
        param[1].Value = objbll.Class_Id;
        
        param[2] = new SqlParameter("@Unit_Description", SqlDbType.NVarChar); 
        param[2].Value = objbll.Unit_Description;

        param[3] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[3].Value = objbll.Evaluation_Criteria_Id;

        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[4].Value = objbll.CreatedBy;
        
        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_UnitInsert", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int Diag_Prog_UnitUpdate(BLLDiag_Prog_Unit objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Unit_Id", SqlDbType.Int); 
        param[0].Value = objbll.Unit_Id;
        
        param[1] = new SqlParameter("@Unit_Description", SqlDbType.NVarChar); 
        param[1].Value = objbll.Unit_Description;

        param[2] = new SqlParameter("@Percentage", SqlDbType.Int);
        param[2].Value = objbll.Percentage;
       
        param[3] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[3].Value = objbll.Evaluation_Criteria_Id;

        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        param[4].Value = objbll.ModifiedBy;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_UnitUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }
    public int Diag_Prog_UnitUpdatePercentage(BLLDiag_Prog_Unit objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Unit_Id", SqlDbType.Int);
        param[0].Value = objbll.Unit_Id;
        param[1] = new SqlParameter("@Percentage", SqlDbType.Decimal);
        param[1].Value = objbll.Percentage;
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_UnitUpdatePercentage", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int Diag_Prog_UnitDelete(BLLDiag_Prog_Unit objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Unit_Id", SqlDbType.Int); 
        param[0].Value = objbll.Unit_Id;

        int k = dalobj.sqlcmdExecute("Diag_Prog_UnitDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Diag_Prog_UnitSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Diag_Prog_UnitSelectById", param);
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

    public DataTable Diag_Prog_UnitSelectSubjectByUser_Id(int user_id)
    {

        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[0].Value = user_id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Subject_HODSelectByUserId", param);
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
    public DataTable Diag_Prog_UnitSelect(BLLDiag_Prog_Unit objbll)
    {
    
    DataTable dt = new DataTable();
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
    param[0].Value = objbll.Class_Id;
    param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
    param[1].Value = objbll.Subject_Id;
    param[2] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
    param[2].Value = objbll.Evaluation_Criteria_Id;
    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Diag_Prog_UnitSelectAll",param);
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


    public DataTable Diag_Prog_UnitSelectClassBySubject_Id(BLLDiag_Prog_Unit objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[0].Value = objbll.Subject_Id;
        
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Diag_Prog_UnitSelectClassBySubject_Id", param);
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
        
        public DataTable Diag_Prog_UnitSelectByClassSubject(BLLDiag_Prog_Unit objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[0].Value = objbll.Subject_Id;
        
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int); 
        param[1].Value = objbll.Class_Id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Diag_Prog_UnitSelectByClassSubject", param);
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
    public DataTable Diag_Prog_UnitSelectByStatusID(BLLDiag_Prog_Unit objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Diag_Prog_UnitSelectByStatusID");
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
