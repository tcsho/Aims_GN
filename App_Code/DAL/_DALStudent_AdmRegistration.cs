using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALStudent_AdmRegistration
/// </summary>
public class DALStudent_AdmRegistration
{
    DALBase dalobj = new DALBase();


    public DALStudent_AdmRegistration()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_AdmRegistrationAdd(BLLStudent_AdmRegistration objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Regisration_Id", SqlDbType.Int); 
        param[0].Value = objbll.Regisration_Id;
        param[1] = new SqlParameter("@StudentName", SqlDbType.NVarChar); 
        param[1].Value = (objbll.StudentName != null) ? objbll.StudentName : "";
        param[2] = new SqlParameter("@FatherName", SqlDbType.NVarChar); 
        param[2].Value = (objbll.FatherName != null) ? objbll.FatherName : "";
        param[3] = new SqlParameter("@Region_Id", SqlDbType.Int); 
        param[3].Value = objbll.Region_Id;
        param[4] = new SqlParameter("@Center_Id", SqlDbType.Int); 
        param[4].Value = objbll.Center_Id;
        param[5] = new SqlParameter("@Grade_Id", SqlDbType.Int); 
        param[5].Value = objbll.Grade_Id;
        param[6] = new SqlParameter("@Admission_Date", SqlDbType.DateTime); 
        param[6].Value = objbll.Admission_Date;
        param[7] = new SqlParameter("@User_Id", SqlDbType.Int); param[7].Value = objbll.User_Id;
        param[8] = new SqlParameter("@Gender_Id", SqlDbType.NVarChar); 
        param[8].Value = (objbll.Gender_Id != null) ? objbll.Gender_Id : "";

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_AdmRegistrationInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int Student_AdmRegistrationUpdate(BLLStudent_AdmRegistration objbll)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@Regisration_Id", SqlDbType.Int); 
        param[0].Value = objbll.Regisration_Id;
        param[1] = new SqlParameter("@StudentName", SqlDbType.NVarChar); 
        param[1].Value = (objbll.StudentName != null) ? objbll.StudentName : "";
        param[2] = new SqlParameter("@FatherName", SqlDbType.NVarChar); 
        param[2].Value = (objbll.FatherName != null) ? objbll.FatherName : "";
        param[3] = new SqlParameter("@Region_Id", SqlDbType.Int); 
        param[3].Value = objbll.Region_Id;
        param[4] = new SqlParameter("@Center_Id", SqlDbType.Int); 
        param[4].Value = objbll.Center_Id;
        param[5] = new SqlParameter("@Grade_Id", SqlDbType.Int); 
        param[5].Value = objbll.Grade_Id;
        param[6] = new SqlParameter("@Admission_Date", SqlDbType.DateTime); 
        param[6].Value = objbll.Admission_Date;
        param[7] = new SqlParameter("@User_Id", SqlDbType.Int); 
        param[7].Value = objbll.User_Id;
        param[8] = new SqlParameter("@Gender_Id", SqlDbType.NVarChar);
        param[8].Value = (objbll.Gender_Id != null) ? objbll.Gender_Id : "";


 
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_AdmRegistrationUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Student_AdmRegistrationDelete(BLLStudent_AdmRegistration objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Regisration_Id", SqlDbType.Int); 
        param[0].Value = objbll.Regisration_Id;

        int k = dalobj.sqlcmdExecute("Student_AdmRegistrationDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_AdmRegistrationSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Student_AdmRegistrationSelectById", param);
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
    
    public DataTable Student_AdmRegistrationSelect(BLLStudent_AdmRegistration objbll)
    {
    SqlParameter[] param = new SqlParameter[2];

    param[0] = new SqlParameter("@Registration_Id", SqlDbType.Int);
    param[0].Value = objbll.Regisration_Id;
    param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
    param[1].Value = objbll.Center_Id;
    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Student_AdmRegistrationSelectByRegId", param);
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

    public DataTable Student_AdmRegistrationSelectByStatusID(BLLStudent_AdmRegistration objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Student_AdmRegistrationSelectByStatusID");
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
