using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALArchieve
/// </summary>
public class DALArchieve
{
    DALBase dalobj = new DALBase();


    public DALArchieve()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int ArchieveAdd(BLLArchieve objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("ArchieveInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int ArchieveUpdate(BLLArchieve objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("ArchieveUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int ArchieveDelete(BLLArchieve objbll)
    {
        SqlParameter[] param = new SqlParameter[1];


        param[0] = new SqlParameter("@Archieve_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Archieve_Id;

        int k = dalobj.sqlcmdExecute("ArchieveDelete", param);

        return k;
    }

    public int Call_ArchiveProcedureNew(BLLArchieve objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0]=new SqlParameter("@MSession_id",SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@MTermId", SqlDbType.Int);
        param[1].Value = objbll.Term_Id;

        param[2] = new SqlParameter("@MmOrgId", SqlDbType.Int);
        param[2].Value = objbll.Mo_Id;

        param[3] = new SqlParameter("@Mcenter_Id", SqlDbType.Int);
        param[3].Value = objbll.Center_Id;

        int k = dalobj.sqlcmdExecute("sp_archice_proc_New", param);
        return k;
    }

    public int Call_PromotionProcedure(BLLArchieve objbll)
    { 
    SqlParameter[] param=new SqlParameter[3];

    param[0] = new SqlParameter("@ses_Id", SqlDbType.Int);
    param[0].Value = objbll.Session_Id;

    param[1] = new SqlParameter("@mo_Id", SqlDbType.Int);
    param[1].Value = objbll.Mo_Id;

    param[2] = new SqlParameter("@center_Id", SqlDbType.Int);
    param[2].Value = objbll.Center_Id;

    int k = dalobj.sqlcmdExecute("_ClassPromotionStudentWise_BranchWise", param);
    return k;

    
    
    
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable ArchieveSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("ArchieveSelectById", param);
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
    
    public DataTable ArchieveSelect(BLLArchieve objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("ArchieveSelectAll", param);
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

    public DataTable ArchieveSelectByStatusID(BLLArchieve objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("ArchieveSelectByStatusID");
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
