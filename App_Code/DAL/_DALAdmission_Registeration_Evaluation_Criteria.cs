using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALAdmission_Registeration_Evaluation_Criteria
/// </summary>
public class DALAdmission_Registeration_Evaluation_Criteria
{
    DALBase dalobj = new DALBase();


    public DALAdmission_Registeration_Evaluation_Criteria()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Admission_RegisterationTestSkipUrdu(BLLAdmission_Registeration_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[0].Value = objbll.Registeration_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[3].Value = objbll.Status_Id;

        int k = dalobj.sqlcmdExecute("Admission_Registeration_Evaluation_CriteriaSkipUrdu", param);
        return k;

    }
    public int Admission_RegisterationTestMarksUpdate(BLLAdmission_Registeration_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[0].Value = objbll.Registeration_Id;
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Admission_RegisterationTestMarksUpdate", param);
        int k = Convert.ToInt32(param[1].Value);
        return k;

    }
    public int  Admission_Registeration_Evaluation_CriteriaAdd(BLLAdmission_Registeration_Evaluation_Criteria objbll,string s)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@ACEC_Id", SqlDbType.Int); 
        param[0].Value = objbll.ACEC_Id;
        param[1] = new SqlParameter("@Marks_Obtained", SqlDbType.Decimal); 
        param[1].Value = objbll.Marks_Obtained;
        param[2] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[2].Value = objbll.Registeration_Id;
        param[3] = new SqlParameter("@Status", SqlDbType.NVarChar);
        param[3].Value = s;
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;
      
        dalobj.sqlcmdExecute("Admission_Registeration_Evaluation_CriteriaInsert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int Admission_Registeration_Evaluation_CriteriaUpdate(BLLAdmission_Registeration_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[0].Value = objbll.Registeration_Id;
        param[1] = new SqlParameter("@ACEC_Id", SqlDbType.Int); 
        param[1].Value = objbll.ACEC_Id;
        param[2] = new SqlParameter("@Marks_Obtained", SqlDbType.Decimal);
        param[2].Value = objbll.Marks_Obtained;
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Admission_Registeration_Evaluation_CriteriaUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int Admission_Registeration_Evaluation_CriteriaDelete(BLLAdmission_Registeration_Evaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AREC_Id", SqlDbType.Int); 
        param[0].Value = objbll.AREC_Id;
        int k = dalobj.sqlcmdExecute("Admission_Registeration_Evaluation_CriteriaDelete", param);

        return k;
    }
    public int Student_Registration_Result_ERPInsert(int id, string status, string detail,int user)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Registration_Id", SqlDbType.Int);
        param[0].Value = id;

        param[1] = new SqlParameter("@StudentStatus", SqlDbType.NVarChar);
        param[1].Value = status;

        param[2] = new SqlParameter("@StudentDetail", SqlDbType.NVarChar);
        param[2].Value = detail;

        param[3] = new SqlParameter("@UserId", SqlDbType.Int);
        param[3].Value = user;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;
        int k = dalobj.sqlcmdExecute("TCS_ERP_Registration_ResultInsert", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Admission_Registeration_Evaluation_CriteriaSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Admission_Registeration_Evaluation_CriteriaSelectById", param);
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
    public DataTable Admission_Registeration_Evaluation_CriteriaEnglishPolicy(int id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[0].Value = id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Registeration_Evaluation_CriteriaEnglishPolicy", param);
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
    public DataTable Admission_Registeration_Evaluation_CriteriaSciencePolicy(int id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[0].Value = id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Registeration_Evaluation_CriteriaSciencePolicy", param);
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
    public DataTable Admission_Registeration_AlevelRule3(int id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[0].Value = id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Registeration_AlevelRule3", param);
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
    public DataTable Admission_Registeration_Evaluation_CriteriaOverallPolicy(int id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Registeration_Id", SqlDbType.Int);
        param[0].Value = id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Registeration_Evaluation_CriteriaOverallPolicy", param);
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
  
    public DataTable Admission_Registeration_Evaluation_CriteriaSelect(BLLAdmission_Registeration_Evaluation_Criteria objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Admission_Registeration_Evaluation_CriteriaSelectAll", param);
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

    public DataTable Admission_Registeration_Evaluation_CriteriaSelectByStatusID(BLLAdmission_Registeration_Evaluation_Criteria objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Admission_Registeration_Evaluation_CriteriaSelectByStatusID");
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
