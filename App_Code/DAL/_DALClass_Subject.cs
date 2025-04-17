using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALClass_Subject
/// </summary>
public class DALClass_Subject
{
    DALBase dalobj = new DALBase();


    public DALClass_Subject()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Class_SubjectAdd(BLLClass_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        //param[0] = new SqlParameter("@Class_Subject_ID", SqlDbType.Int); 
        //param[0].Value = objbll.Class_Subject_ID;
        param[0] = new SqlParameter("@Class_ID", SqlDbType.Int); 
        param[0].Value = objbll.Class_ID;
        param[1] = new SqlParameter("@Subject_ID", SqlDbType.Int); 
        param[1].Value = objbll.Subject_ID;
        param[2] = new SqlParameter("@Status_ID", SqlDbType.Int); 
        param[2].Value = objbll.Status_ID;


        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_SubjectInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int Class_SubjectUpdate(BLLClass_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        //param[0] = new SqlParameter("@Class_Subject_ID", SqlDbType.Int); 
        //param[0].Value = objbll.Class_Subject_ID;
        param[0] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[0].Value = objbll.Class_ID;
        param[1] = new SqlParameter("@Subject_ID", SqlDbType.Int);
        param[1].Value = objbll.Subject_ID;
        param[2] = new SqlParameter("@Status_ID", SqlDbType.Int);
        param[2].Value = objbll.Status_ID;

 
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_SubjectUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int Class_SubjectDelete(BLLClass_Subject objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_Subject_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Class_Subject_Id;


        int k = dalobj.sqlcmdExecute("Class_SubjectDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Class_SubjectSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Class_Subject_ID", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Class_SubjectSelectById", param);
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

    public DataTable Class_SelectByOrgId(BLLClass_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@OrgId", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SelectByOrgId", param);
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

    public DataTable Class_SubjectSelectAllByClassId(BLLClass_Subject _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@OrgId", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_ID;
        param[2] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[2].Value = _obj.Region_Id;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SubjectSelectAllByClassId", param);
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
    public DataTable Class_SubjectFetchOlevelsSubjects(BLLClass_Subject obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = obj.Class_ID;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SubjectFetchOlevelsSubjects",param);
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
    public DataTable Class_SubjectSelect(BLLClass_Subject objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Class_Subject_ID", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Class_SubjectSelectAll", param);
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

    public DataTable Class_SubjectSelectByStatusID(BLLClass_Subject objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Class_SubjectSelectByStatusID");
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
