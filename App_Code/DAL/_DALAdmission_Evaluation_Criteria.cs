using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALAdmission_Evaluation_Criteria
/// </summary>
public class DALAdmission_Evaluation_Criteria
{
    DALBase dalobj = new DALBase();


    public DALAdmission_Evaluation_Criteria()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Admission_Evaluation_CriteriaAdd(BLLAdmission_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[0].Value = objbll.Subject_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int); 
        param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@Criteria", SqlDbType.NVarChar); 
        param[2].Value = (objbll.Criteria != null) ? objbll.Criteria : "";
        param[3] = new SqlParameter("@Total_Marks", SqlDbType.Decimal); 
        param[3].Value = objbll.Total_Marks;
        param[4] = new SqlParameter("@Weightage", SqlDbType.Decimal); 
        param[4].Value = objbll.Weightage;
        param[5] = new SqlParameter("@Session_Id", SqlDbType.Int); 
        param[5].Value = objbll.Session_Id;
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Admission_Evaluation_CriteriaInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int Admission_Evaluation_CriteriaUpdate(BLLAdmission_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@AEC_Id", SqlDbType.Int);
        param[0].Value = objbll.AEC_Id;
        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int); 
        param[1].Value = objbll.Subject_Id;
        param[2] = new SqlParameter("@Criteria", SqlDbType.NVarChar); 
        param[2].Value = (objbll.Criteria != null) ? objbll.Criteria : "";
        param[3] = new SqlParameter("@Total_Marks", SqlDbType.Decimal); 
        param[3].Value = objbll.Total_Marks;
        param[4] = new SqlParameter("@Weightage", SqlDbType.Decimal); 
        param[4].Value = objbll.Weightage;
        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Admission_Evaluation_CriteriaUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }
    public int Admission_Evaluation_CriteriaDelete(BLLAdmission_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@AEC_Id", SqlDbType.Int);
        param[0].Value = objbll.AEC_Id;
        int k = dalobj.sqlcmdExecute("Admission_Evaluation_CriteriaDelete", param);
        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Admission_Evaluation_CriteriaSelect(BLLAdmission_Evaluation_Criteria obj)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = obj.Session_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = obj.Class_Id;
        DataTable dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Evaluation_CriteriaSelect", param);
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
    
     

    public DataTable Admission_Evaluation_CriteriaSelectByStatusID(BLLAdmission_Evaluation_Criteria objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Evaluation_CriteriaSelectByStatusID");
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
