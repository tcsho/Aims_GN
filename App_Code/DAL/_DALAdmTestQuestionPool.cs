using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALAdmTestQuestionPool
/// </summary>
public class DALAdmTestQuestionPool
{
    DALBase dalobj = new DALBase();


    public DALAdmTestQuestionPool()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmTestQuestionPoolAdd(BLLAdmTestQuestionPool objbll)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Pool_Id", SqlDbType.Int); param[0].Value = objbll.Pool_Id;
        param[1] = new SqlParameter("@Description", SqlDbType.NVarChar); param[1].Value = (objbll.Description != null) ? objbll.Description : "";
        param[2] = new SqlParameter("@AdmTestDetail_Id", SqlDbType.Int); param[2].Value = objbll.AdmTestDetail_Id;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int); param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@TimeInSeconds", SqlDbType.Int); param[4].Value = objbll.TimeInSeconds;
        param[5] = new SqlParameter("@MarksPerQuestion", SqlDbType.Int); param[5].Value = objbll.MarksPerQuestion;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestQuestionPoolInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int AdmTestQuestionPoolUpdate(BLLAdmTestQuestionPool objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Pool_Id", SqlDbType.Int); 
        param[0].Value = objbll.Pool_Id;
       
        param[1] = new SqlParameter("@TimeInSeconds", SqlDbType.Int); 
        param[1].Value = objbll.TimeInSeconds;
        param[2] = new SqlParameter("@MinQuest", SqlDbType.Int);
        param[2].Value = objbll.MinQuest;
        param[3] = new SqlParameter("@MarksPerQuestion", SqlDbType.Decimal); 
        param[3].Value = objbll.MarksPerQuestion;

        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestQuestionPoolUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int AdmTestQuestionPoolDelete(BLLAdmTestQuestionPool objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmTestQuestionPool_Id", SqlDbType.Int);
     //   param[0].Value = objbll.AdmTestQuestionPool_Id;


        int k = dalobj.sqlcmdExecute("AdmTestQuestionPoolDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
  
    public DataTable AdmTestQuestionsPoolSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmTestDetail_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionPoolSelect", param);
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
    public DataTable AdmTestQuestionPoolSelectAll(BLLAdmTestQuestionPool objbll)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@AdmTestDetail_Id", SqlDbType.Int);
    param[0].Value = objbll.AdmTestDetail_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("AdmTestQuestionPoolSelectAll", param);
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

    public DataTable AdmTestQuestionPoolSelectByStatusID(BLLAdmTestQuestionPool objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("AdmTestQuestionPoolSelectByStatusID");
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
