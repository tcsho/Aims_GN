using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALStudent_Registration_Result_ERP
/// </summary>
public class DALStudent_Registration_Result_ERP
{
    DALBase dalobj = new DALBase();


    public DALStudent_Registration_Result_ERP()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Registration_Result_ERPAdd(BLLStudent_Registration_Result_ERP objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Firstname", SqlDbType.NVarChar);
       // param[0].Value = objbll.Firstname;

        param[1] = new SqlParameter("@Lastname", SqlDbType.NVarChar);
        //param[1].Value = objbll.Lastname;

        param[2] = new SqlParameter("@Details", SqlDbType.NVarChar);
        //param[2].Value = objbll.Details;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
       // param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Registration_Result_ERPInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int Student_Registration_Result_ERPUpdate(BLLStudent_Registration_Result_ERP objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Registration_Result_ERPUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Student_Registration_Result_ERPDelete(BLLStudent_Registration_Result_ERP objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Registration_Id", SqlDbType.Int);
        param[0].Value = objbll.Registration_Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Admission_Registeration_Evaluation_CriteriaDelete", param);
        int k = (int)param[1].Value;
        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Registration_Result_ERPSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Student_Registration_Result_ERPSelectById", param);
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

    public DataTable Student_Registration_Result_ERPSelect(BLLStudent_Registration_Result_ERP objbll)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int); 
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[2].Value = objbll.Class_Id;
        DataTable dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("TCS_ERP_Registration_ResultSelectByClass", param);
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

    public DataTable Student_Registration_Result_ERPSelectByStatusID(BLLStudent_Registration_Result_ERP objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Student_Registration_Result_ERPSelectByStatusID");
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
