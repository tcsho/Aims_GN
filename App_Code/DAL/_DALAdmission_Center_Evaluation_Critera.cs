using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALAdmission_Center_Evaluation_Criteria
/// </summary>
public class DALAdmission_Center_Evaluation_Criteria
{
    DALBase dalobj = new DALBase();


    public DALAdmission_Center_Evaluation_Criteria()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Admission_Center_Evaluation_CriteriaAdd(BLLAdmission_Center_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@AdmTestType_Id", SqlDbType.Int);
        param[1].Value = objbll.TestType_Id;

        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[3].Value = objbll.Center_Id;
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;
        int k = dalobj.sqlcmdExecute("Admission_Center_Evaluation_CriteriaInsert", param);
        
        return k;

    }
    public int Admission_Center_Evaluation_CriteriaUpdate(BLLAdmission_Center_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@ACEC_Id", SqlDbType.Int);
        param[0].Value = objbll.ACEC_Id;
        param[1] = new SqlParameter("@AEC_Id", SqlDbType.Int);
        param[1].Value = objbll.AEC_Id;
        param[2] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[2].Value = objbll.Main_Organisation_Id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[3].Value = objbll.Subject_Id;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[4].Value = objbll.Class_Id;
        param[5] = new SqlParameter("@Criteria", SqlDbType.NVarChar);
        param[5].Value = (objbll.Criteria != null) ? objbll.Criteria : "";
        param[6] = new SqlParameter("@Total_Marks", SqlDbType.NVarChar);
        param[6].Value = objbll.Total_Marks;
        param[7] = new SqlParameter("@Weightage", SqlDbType.NVarChar);
        param[7].Value = objbll.Weightage;
        param[8] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[8].Value = objbll.Status_Id;
        param[9] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[9].Value = objbll.Session_Id;
        param[10] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[10].Value = objbll.Center_Id;
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Admission_Center_Evaluation_CriteriaUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Admission_Center_Evaluation_CriteriaDelete(BLLAdmission_Center_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@ACEC_Id", SqlDbType.Int);
        param[0].Value = objbll.ACEC_Id;

        int k = dalobj.sqlcmdExecute("Admission_Center_Evaluation_CriteriaDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Admission_Center_Evaluation_CriteriaSelectACEC(BLLAdmission_Center_Evaluation_Criteria obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = obj.Center_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = obj.Class_Id;
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Center_Evaluation_CriteriaSelectACEC", param);
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
    public DataTable Admission_Center_Evaluation_CriteriaSelectAllCenters(BLLAdmission_Center_Evaluation_Criteria obj)
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
            dt = dalobj.sqlcmdFetch("Admission_Center_Evaluation_CriteriaSelectAllCenters", param);
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
    public DataTable Admission_Center_Evaluation_CriteriaSelect(BLLAdmission_Center_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Center_Evaluation_CriteriaSelectAll", param);
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

    public DataTable Admission_Center_Evaluation_CriteriaSelectByCenterId(BLLAdmission_Center_Evaluation_Criteria objbll)
    {
        DataTable dt = new DataTable();
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[2].Value = objbll.Registeration_Id;


        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Center_Evaluation_CriteriaSelectByCenterId", param);
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
