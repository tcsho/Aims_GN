using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALClass_Section
/// </summary>
public class DALClass_Section
{
    DALBase dalobj = new DALBase();


    public DALClass_Section()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Class_SectionAdd(BLLClass_Section objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        //param[0] = new SqlParameter("@Class_Section_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Class_Section_Id;
        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;
        param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Id;


        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_SectionInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int Class_SectionUpdate(BLLClass_Section objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        //param[0] = new SqlParameter("@Class_Section_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Class_Section_Id;
        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;
        param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Id;


        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_SectionUpdate", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int Class_SectionDelete(BLLClass_Section objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_Section_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Class_Section_Id;


        int k = dalobj.sqlcmdExecute("Class_SectionDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Class_SectionSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Class_Section_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionSelectById", param);
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


    public DataTable Class_SectionByCenterId(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionByCenterId", param);
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

    public DataTable Class_SectionByEmployeeId(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionByEmployeeId", param);
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

    public DataTable Class_SectionByEmployeeIdForDiag_Prog(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionByEmployeeIdForDiag_Prog", param);
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

    public DataTable Class_SectionByClassTeacherId(BLLClass_Section obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = obj.Employee_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionByClassTeacherId", param);
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


    public DataTable Class_SectionWelcomeByClassTeacherId(BLLClass_Section obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = obj.Employee_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = obj.Session_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_Section_WelcomeByClassTeacherId", param);
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
    public DataTable Class_SectionByCenterSectionId(BLLClass_Section _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = _obj.Center_Id;

        param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[1].Value = _obj.Section_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionByCenterSectionId", param);
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



    public DataTable Employee_ProfileByCenterId(BLLClass_Section _obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = _obj.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Employee_ProfileByCenterId", param);
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


    public DataTable Employee_ProfileByEmployeeId(BLLClass_Section _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = _obj.Employee_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = _obj.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Employee_ProfileByEmployeeId", param);
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

    public DataTable Class_SectionByTeacherId(BLLClass_Section _obj)
    {
        SqlParameter[] param = new SqlParameter[2];


        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = _obj.Center_Id;

        param[1] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[1].Value = _obj.Employee_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionSelectByEmployee_ID", param);
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
    public DataTable Class_SectionBySessionTeacherId(BLLClass_Section _obj)
    {
        SqlParameter[] param = new SqlParameter[3];


        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = _obj.Center_Id;

        param[1] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[1].Value = _obj.Employee_Id;

        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = _obj.Session_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionSelectBySessionEmployee_ID", param);
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



    public DataTable Class_SectionSubjectsValues(BLLClass_Section _obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _obj.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionSubjectsValues", param);
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

    public DataTable Class_SectionSelect(BLLClass_Section objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@pv_class_id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;


        param[1] = new SqlParameter("@pv_center_id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetSectionFromClass", param);
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


    public DataTable Class_SectionSelectByStatusID(BLLClass_Section objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SectionSelectByStatusID");
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
