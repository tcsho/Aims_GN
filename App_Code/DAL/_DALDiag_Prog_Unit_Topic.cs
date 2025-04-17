using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALDiag_Prog_Unit_Topic
/// </summary>
public class DALDiag_Prog_Unit_Topic
{
    DALBase dalobj = new DALBase();


    public DALDiag_Prog_Unit_Topic()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Diag_Prog_Unit_TopicInsert(BLLDiag_Prog_Unit_Topic objbll)
    {
        SqlParameter[] param = new SqlParameter[6];
       
	
    param[0] = new SqlParameter("@Unit_Id", SqlDbType.Int);	
	param[0].Value = objbll.Unit_Id;

    param[1] = new SqlParameter("@Topic_Description", SqlDbType.NVarChar);	
	param[1].Value = (objbll.Topic_Description !=null) ? objbll.Topic_Description : "";
    param[2] = new SqlParameter("@Objective", SqlDbType.NVarChar);
    param[2].Value = (objbll.Objective != null) ? objbll.Objective : "";

    param[3] = new SqlParameter("@Duration", SqlDbType.Decimal);
    param[3].Value = objbll.Duration;
    param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
    param[4].Value = objbll.CreatedBy;


    param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
    param[5].Direction = ParameterDirection.Output;
    dalobj.sqlcmdExecute("Diag_Prog_Unit_TopicInsert", param);
    int k = (int)param[5].Value;
    return k;
    }
    public int Diag_Prog_Unit_TopicUpdate(BLLDiag_Prog_Unit_Topic objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Topic_Id", SqlDbType.Int);
        param[0].Value = objbll.Topic_Id;

        param[1] = new SqlParameter("@Topic_Description", SqlDbType.NVarChar);
        param[1].Value = (objbll.Topic_Description != null) ? objbll.Topic_Description : "";

        param[2] = new SqlParameter("@Objective", SqlDbType.NVarChar);
        param[2].Value = (objbll.Objective != null) ? objbll.Objective : "";

        param[3] = new SqlParameter("@Duration", SqlDbType.Decimal);
        param[3].Value =objbll.Duration;

        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        param[4].Value = objbll.ModifiedBy;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_Unit_TopicUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }
    public int Diag_Prog_Unit_TopicDelete(BLLDiag_Prog_Unit_Topic objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Topic_Id", SqlDbType.Int);
        param[0].Value = objbll.Topic_Id;


        int k = dalobj.sqlcmdExecute("Diag_Prog_Unit_TopicDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Diag_Prog_Unit_TopicSelectByUnitId(int _id)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@Unit_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Diag_Prog_Unit_TopicByUnitId", param);
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
    
    public DataTable Diag_Prog_Unit_TopicSelect(BLLDiag_Prog_Unit_Topic objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Diag_Prog_Unit_TopicSelectAll", param);
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

    public DataTable Diag_Prog_Unit_TopicSelectByStatusID(BLLDiag_Prog_Unit_Topic objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Diag_Prog_Unit_TopicSelectByStatusID");
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
