using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALAdmSession_Dates
/// </summary>
public class DALEvaluation_Criteria_Type_CUTTOFF
{
    DALBase dalobj = new DALBase();


    public DALEvaluation_Criteria_Type_CUTTOFF()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Evaluation_Criteria_Type_CUTTOFFCRUD(BLLEvaluation_Criteria_Type_CUTTOFF objbll)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@ECT_CUTTOFF_Id", SqlDbType.Int); 
        param[0].Value = objbll.ECT_CUTTOFF_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int); 
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@FromDate", SqlDbType.DateTime); 
        param[2].Value = objbll.FromDate;
       
        param[3] = new SqlParameter("@Status", SqlDbType.Int);
        param[3].Value = objbll.Status;
        param[4] = new SqlParameter("@TermGroup_Id", SqlDbType.Int); 
        param[4].Value = objbll.TermGroup_Id;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_Type_CUTTOFFCRUD", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int Evaluation_Criteria_Type_CUTTOFFSyncStudents(BLLEvaluation_Criteria_Type_CUTTOFF objbll)
    {
        //int k = dalobj.sqlcmdExecute("Evaluation_Criteria_Type_CUTTOFFSyncStudents");
        int k = 0; 
        return k;
    }
    public int Evaluation_Criteria_Type_CUTTOFFDelete(BLLEvaluation_Criteria_Type_CUTTOFF objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmSession_Dates_Id", SqlDbType.Int);
        //   param[0].Value = objbll.AdmSession_Dates_Id;


        int k = dalobj.sqlcmdExecute("AdmSession_DatesDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Evaluation_Criteria_Type_CUTTOFFSelectAll(BLLEvaluation_Criteria_Type_CUTTOFF objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        DataTable dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Evaluation_Criteria_Type_CUTTOFFSelectAll", param);
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

    public DataTable Evaluation_Criteria_Type_CUTTOFFSelect(BLLEvaluation_Criteria_Type_CUTTOFF objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Evaluation_Criteria_Type_CUTTOFFSelectAll", param);
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

    public DataTable Evaluation_Criteria_Type_CUTTOFFByStatusID(BLLEvaluation_Criteria_Type_CUTTOFF objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Evaluation_Criteria_Type_CUTTOFFSelectByStatusID");
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
