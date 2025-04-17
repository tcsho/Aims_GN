using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALActivity
/// </summary>
public class DALActivity
{
    DALBase dalobj = new DALBase();


    public DALActivity()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int ActivityAdd(BLLActivity objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        //param[0] = new SqlParameter("@Activity_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Activity_Id;
        param[0] = new SqlParameter("@Activity", SqlDbType.NVarChar);
        param[0].Value = objbll.Activity;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[2].Value = objbll.Subject_Id;
        param[3] = new SqlParameter("@Weightage", SqlDbType.Decimal);
        param[3].Value = objbll.Weightage;
        param[4] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[4].Value = objbll.Main_Organisation_Id;
        param[5] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[5].Value = objbll.Evaluation_Criteria_Type_Id;
        param[6] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[6].Value = objbll.Evaluation_Type_Id;


        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("ActivityInsert", param);
        int k = (int)param[7].Value;
        return k;

    }
    public int ActivityUpdate(BLLActivity objbll)
    {
        SqlParameter[] param = new SqlParameter[9];


        param[0] = new SqlParameter("@Activity_Id", SqlDbType.Int);
        param[0].Value = objbll.Activity_Id;
        param[1] = new SqlParameter("@Activity", SqlDbType.NVarChar);
        param[1].Value = objbll.Activity;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[3].Value = objbll.Subject_Id;
        param[4] = new SqlParameter("@Weightage", SqlDbType.Decimal);
        param[4].Value = objbll.Weightage;
        param[5] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[5].Value = objbll.Main_Organisation_Id;
        param[6] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[6].Value = objbll.Evaluation_Criteria_Type_Id;
        param[7] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[7].Value = objbll.Evaluation_Type_Id;


        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("ActivityUpdate", param);
        int k = (int)param[8].Value;
        return k;
    }
    public int ActivityDelete(BLLActivity objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Activity_Id", SqlDbType.Int);
        param[0].Value = objbll.Activity_Id;


        int k = dalobj.sqlcmdExecute("ActivityDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable ActivitySelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Activity_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ActivitySelectById", param);
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

    public DataTable ActivitySelect(BLLActivity objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Activity_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ActivitySelectAll", param);
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
    public DataTable ActivitySelectBySectionSubjectTerm(BLLActivity objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;

        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        param[2] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[2].Value = objbll.Section_Subject_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ActivitySelectBySectionSubjectTerm", param);
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

    public DataTable ActivitySelectByStatusID(BLLActivity objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ActivitySelectByStatusID");
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


    public DataTable Activity_SelectAllByClassSubjectEvlCriteriaTypeId(BLLActivity _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        //////////////////param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        //////////////////param[2].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Criteria_Type_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Activity_SelectAllByClassSubjectEvlCriteriaTypeId", param);
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


    public DataTable Activity_SelectAllByClassIdSubjectIdActivityId(BLLActivity _obj)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        ////////////param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        ////////////param[2].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Criteria_Type_Id;

        param[3] = new SqlParameter("@Activity_Id", SqlDbType.Int);
        param[3].Value = _obj.Activity_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Activity_SelectAllByClassIdSubjectIdActivityId", param);
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

    public DataTable Activity_CheckExistingValue(BLLActivity _obj)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = _obj.Class_Id;

        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@Activity", SqlDbType.Int);
        param[2].Value = _obj.Activity;

        param[3] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[3].Value = _obj.Main_Organisation_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Activity_CheckExistingValue", param);
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
