using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent
/// </summary>
public class DALTcs_Mobile_App_Dashboard
{
    DALBase dalobj = new DALBase();


    public DALTcs_Mobile_App_Dashboard()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
   
    public DataSet Get_Total_Registered_Parents(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Session_id", SqlDbType.Int);
        param[0].Value = bllStd.Session_Id;

        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = bllStd.Region_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = bllStd.Center_Id;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = bllStd.Class_ID;

        param[4] = new SqlParameter("@Current_Date", SqlDbType.NVarChar);
        param[4].Value = bllStd.Current_Date;

        param[5] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[5].Value = bllStd.Subject_Id;

        DataSet _dt = new DataSet();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch_DS("sp_Dashboard_Registration", param);
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
    public DataTable Student_VerificatioSelect(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = bllStd.Employee_Id;

        param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[1].Value = bllStd.Section_Id;

        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = bllStd.Session_Id;

        
        param[4] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[4].Value = bllStd.Center_Id;

        param[5] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[5].Value = bllStd.Region_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_VerificationSelect", param);
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


    public DataTable ClassSelect_ByCenter(BLLClass objbll)
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_CenterSelectByCenter_Id");
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



    public DataSet Get_Student_Attendance_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Session_id", SqlDbType.Int);
        param[0].Value = bllStd.Session_Id;

        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = bllStd.Region_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = bllStd.Center_Id;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = bllStd.Class_ID;

        param[4] = new SqlParameter("@Current_Date", SqlDbType.NVarChar);
        param[4].Value = bllStd.Current_Date;

        DataSet _dt = new DataSet();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch_DS("sp_Dashboard_Attendance_Detail", param);
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



    public DataSet Unregistered_Parents_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Session_id", SqlDbType.Int);
        param[0].Value = bllStd.Session_Id;

        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = bllStd.Region_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = bllStd.Center_Id;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = bllStd.Class_ID;

        param[4] = new SqlParameter("@Current_Date", SqlDbType.NVarChar);
        param[4].Value = bllStd.Current_Date;

        DataSet _dt = new DataSet();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch_DS("sp_Dashboard_Un_Registered_Parents__Detail", param);
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



    public DataSet Unregistered_Student_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Session_id", SqlDbType.Int);
        param[0].Value = bllStd.Session_Id;

        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = bllStd.Region_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = bllStd.Center_Id;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = bllStd.Class_ID;

        param[4] = new SqlParameter("@Current_Date", SqlDbType.NVarChar);
        param[4].Value = bllStd.Current_Date;

        DataSet _dt = new DataSet();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch_DS("sp_Dashboard_Unregistered_student_Detail", param);
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



    public DataSet Unmarked_HomeWork_Diary_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Session_id", SqlDbType.Int);
        param[0].Value = bllStd.Session_Id;

        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = bllStd.Region_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = bllStd.Center_Id;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = bllStd.Class_ID;

        param[4] = new SqlParameter("@Current_Date", SqlDbType.NVarChar);
        param[4].Value = bllStd.Current_Date;

        param[5] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[5].Value = bllStd.Subject_Id;

        DataSet _dt = new DataSet();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch_DS("sp_Dashboard_Unmarked_HomeworkDiary_Detail", param);
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



    public DataSet sp_Dashboard_Classwork_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Session_id", SqlDbType.Int);
        param[0].Value = bllStd.Session_Id;

        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = bllStd.Region_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = bllStd.Center_Id;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = bllStd.Class_ID;

        param[4] = new SqlParameter("@Current_Date", SqlDbType.NVarChar);
        param[4].Value = bllStd.Current_Date;

        param[5] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[5].Value = bllStd.Subject_Id;

        DataSet _dt = new DataSet();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch_DS("sp_Dashboard_Classwork_Detail", param);
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




    public DataSet Dashboard_ClassTestResult_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Session_id", SqlDbType.Int);
        param[0].Value = bllStd.Session_Id;

        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = bllStd.Region_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = bllStd.Center_Id;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = bllStd.Class_ID;

        param[4] = new SqlParameter("@Current_Date", SqlDbType.NVarChar);
        param[4].Value = bllStd.Current_Date;

        param[5] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[5].Value = bllStd.Subject_Id;

        DataSet _dt = new DataSet();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch_DS("sp_Dashboard_ClassTestResult_Detail", param);
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
    #endregion


}
