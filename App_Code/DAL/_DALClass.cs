using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALClass
/// </summary>
public class DALClass
{
    DALBase dalobj = new DALBase();


    public DALClass()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int ClassAdd(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        //param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        //param[0].Value = objbll.Class_Id;
        param[0] = new SqlParameter("@Class_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Class_Name;
        param[1] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organisation_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@Grade_Id", SqlDbType.Int);
        param[3].Value = objbll.Grade_Id;
        param[4] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[4].Value = objbll.Comments;
        param[5] = new SqlParameter("@isKPI", SqlDbType.Bit);
        param[5].Value = objbll.isKPI;
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("ClassInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int ClassUpdate(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        //param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        //param[0].Value = objbll.Class_Id;
        param[0] = new SqlParameter("@Class_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Class_Name;
        param[1] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organisation_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@Grade_Id", SqlDbType.Int);
        param[3].Value = objbll.Grade_Id;
        param[4] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[4].Value = objbll.Comments;
        param[5] = new SqlParameter("@OrderOfClass", SqlDbType.Int);
        param[5].Value = objbll.OrderOfClass;
        param[6] = new SqlParameter("@isKPI", SqlDbType.Bit);
        param[6].Value = objbll.isKPI;


        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("ClassUpdate", param);
        int k = (int)param[7].Value;
        return k;
    }
    public int ClassDelete(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;


        int k = dalobj.sqlcmdExecute("ClassDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable ClassSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ClassSelectById", param);
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

    public DataTable ClassSelectForAlumni(BLLClass objbll)
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ClassSelectForAlumni");
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

    public DataTable ClassSelect(BLLClass objbll)
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ClassSelectAll");
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

    public DataTable ClassSelectByStatusID(BLLClass objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ClassSelectByStatusID");
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
    public DataTable ClassSelectByCenterIDSeatPlan(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TcsSelectClassByCenterSeatPlan", param);
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
    public DataTable ClassSelectByCenterID(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TcsSelectClassByCenter", param);
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
    public DataTable ClassSelectByCenterTeacherID(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[1].Value = objbll.Teacher_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TcsSelectClassByCenterTeacher", param);
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


    public DataTable ClassSelectSearch(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[3];


        param[0] = new SqlParameter("@sp_className", SqlDbType.NVarChar);
        param[0].Value = objbll.Class_Name;

        param[1] = new SqlParameter("@sp_grade", SqlDbType.NVarChar);
        param[1].Value = objbll.Grade_IdS;

        param[2] = new SqlParameter("@sp_moID", SqlDbType.NVarChar);
        param[2].Value = objbll.Main_Organisation_IdS;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchClass", param);
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

    public DataTable GetClassesByMOId(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];


        param[0] = new SqlParameter("@sp_moID", SqlDbType.NVarChar);
        param[0].Value = _id;

        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchClassByMoId", param);
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
    public int ClassNameAvailability(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Class_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Class_Name;
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("ClassNameAvailibility", param);
        int k = (int)param[1].Value;
        return k;

    }
    public DataTable Class_SubjectSelectByClassID(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[2];


        param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;
        param[1] = new SqlParameter("@Region_id", SqlDbType.Int);
        param[1].Value = objbll.Region_id;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SubjectFetchByClassID", param);
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
    public int Class_SubjectAssign(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        //param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        //param[0].Value = objbll.Class_Id;
        param[0] = new SqlParameter("@Class_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Class_Name;
        param[1] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organisation_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@Grade_Id", SqlDbType.Int);
        param[3].Value = objbll.Grade_Id;
        param[4] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[4].Value = objbll.Comments;
        param[5] = new SqlParameter("@OrderOfClass", SqlDbType.Int);
        param[5].Value = objbll.OrderOfClass;
        param[6] = new SqlParameter("@isKPI", SqlDbType.Bit);
        param[6].Value = objbll.isKPI;


        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("ClassInsert", param);
        int k = (int)param[7].Value;
        return k;

    }
    public void Class_SubjectUnAssign(BLLClass objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;
        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Subject_Id;
        param[2] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[2].Value = objbll.Region_id;
        dalobj.sqlcmdExecute("UnassignClass_Subject", param);
    }
    #endregion


    public DataTable Fetch_ClassesBasedonCenter_Dashboard(BLLClass objbll)
    {

        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[1];


        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ClassesBasedonCenter_Dashboard", param);
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


}
