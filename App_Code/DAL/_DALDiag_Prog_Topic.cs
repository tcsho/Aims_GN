using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALDiag_Prog_Topic
/// </summary>
public class DALDiag_Prog_Topic
{
    DALBase dalobj = new DALBase();


    public DALDiag_Prog_Topic()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Diag_Prog_TopicAdd(BLLDiag_Prog_Topic objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

     
	    param[0] = new SqlParameter("@DP_ID",SqlDbType.NVarChar);	param[0].Value = objbll.DP_ID;
	    param[1] = new SqlParameter("@Topic_Id",SqlDbType.NVarChar);	param[1].Value = objbll.Topic_Id;


        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_TopicInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int Diag_Prog_TopicUpdate(BLLDiag_Prog_Topic objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@DP_Topic_ID",SqlDbType.NVarChar);	
        param[0].Value = objbll.DP_Topic_ID;
	
        param[1] = new SqlParameter("@Topic_Id",SqlDbType.NVarChar);	
        param[1].Value = objbll.Topic_Id;
        
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Diag_Prog_TopicUpdate", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int Diag_Prog_TopicDelete(BLLDiag_Prog_Topic objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@DP_Topic_Id", SqlDbType.Int);
        param[0].Value = objbll.DP_Topic_ID;


        int k = dalobj.sqlcmdExecute("Diag_Prog_TopicDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Diag_Prog_TopicSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Diag_Prog_TopicSelectById", param);
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
    public DataTable Diag_Prog_TopicCheckLockMarks(BLLDiag_Prog_Topic obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@DP_Topic_Id", SqlDbType.Int);
        param[0].Value = obj.DP_Topic_ID;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Diag_Prog_TopicCheckLockMarks", param);
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
    
    public DataTable Diag_Prog_TopicSelect(BLLDiag_Prog_Topic objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Diag_Prog_TopicSelectAll", param);
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

    public DataTable Diag_Prog_TopicSelectByStatusID(BLLDiag_Prog_Topic objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Diag_Prog_TopicSelectByStatusID");
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


    public DataTable Diag_Prog_TopicSelectTopicDetails(BLLDiag_Prog_Topic obj)
    {

        DataTable dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@DP_Id", SqlDbType.Int);
        param[0].Value = obj.DP_ID;
        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Diag_Prog_TopicSelectTopicDetails", param);
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
    public DataTable Diag_Prog_TopicSelectTopic(BLLDiag_Prog_Topic obj)
    {

        DataTable dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@DP_Topic_Id", SqlDbType.Int);
        param[0].Value = obj.DP_Topic_ID;
        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Diag_Prog_TopicSelectTopic", param);
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
