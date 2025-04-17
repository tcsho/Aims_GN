using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALEvaluation_Criteria
/// </summary>
public class DALEvaluation_Criteria
{
    DALBase dalobj = new DALBase();


    public DALEvaluation_Criteria()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Evaluation_CriteriaAdd(BLLEvaluation_Criteria objbll)
    {
        

        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Id;
        param[1] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organisation_Id;
        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[2].Value = objbll.Subject_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;
        param[4] = new SqlParameter("@Criteria", SqlDbType.NVarChar);
        param[4].Value = objbll.Criteria;
        param[5] = new SqlParameter("@Total_Marks", SqlDbType.Decimal);
        param[5].Value = objbll.Total_Marks;
        param[6] = new SqlParameter("@Weightage", SqlDbType.Decimal);
        param[6].Value = objbll.Weightage;
        param[7] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[7].Value = objbll.Evaluation_Criteria_Type_Id;
        param[8] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[8].Value = objbll.Evaluation_Type_Id;



        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_CriteriaInsert", param);
        int k = (int)param[9].Value;
        return k;

    }
    public int Evaluation_CriteriaUpdate(BLLEvaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Id;
        param[1] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[1].Value = objbll.Main_Organisation_Id;
        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[2].Value = objbll.Subject_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;
        param[4] = new SqlParameter("@Criteria", SqlDbType.NVarChar);
        param[4].Value = objbll.Criteria;
        param[5] = new SqlParameter("@Total_Marks", SqlDbType.Decimal);
        param[5].Value = objbll.Total_Marks;
        param[6] = new SqlParameter("@Weightage", SqlDbType.Decimal);
        param[6].Value = objbll.Weightage;
        param[7] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[7].Value = objbll.Evaluation_Criteria_Type_Id;
        param[8] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[8].Value = objbll.Evaluation_Type_Id;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_CriteriaUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }

    public int Evaluation_CriteriaApplyAllChangesUpdate(BLLEvaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Id;
        param[1] = new SqlParameter("@Total_Marks", SqlDbType.Decimal);
        param[1].Value = objbll.Total_Marks;
        param[2] = new SqlParameter("@Weightage", SqlDbType.Decimal);
        param[2].Value = objbll.Weightage;
        
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_CriteriaApplyAllChangesUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }

    public int Evaluation_CriteriaDelete(BLLEvaluation_Criteria objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Id;


        int k = dalobj.sqlcmdExecute("Evaluation_CriteriaDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Evaluation_CriteriaSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_CriteriaSelectById", param);
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
    
    public DataTable Evaluation_CriteriaSelect(BLLEvaluation_Criteria objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_CriteriaSelectAll", param);
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

    public DataTable Evaluation_CriteriaSelectByStatusID(BLLEvaluation_Criteria objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_CriteriaSelectByStatusID");
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

    public DataTable Evaluation_Criteria_SelectAllByClassSubjectEvlTypeId(BLLEvaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        ////////////param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        ////////////param[2].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@Eval_Type_Id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Criteria_Type_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_SelectAllByClassSubjectEvlTypeId", param);
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
    public DataTable Evaluation_Criteria_SelectAllByClassSubject(BLLEvaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_SelectAllByClassSubject", param);
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

    public DataTable Evaluation_CriteriaSelectBYClassSubjectEvlID(BLLEvaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = _obj.Class_Id;

        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Criteria_Type_Id;

      

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_CriteriaSelectBYClassSubjectEvlID", param);
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


    public DataTable Evaluation_Criteria_SelectAllByEvlCriteriaId(BLLEvaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@Eval_Critria_Id", SqlDbType.Int);
        param[1].Value = _obj.Evaluation_Criteria_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_SelectAllByEvlCriteriaId", param);
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


    public DataTable GetCurrentWeightagePercentage(BLLEvaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_class_id", SqlDbType.Int);
        param[0].Value = _obj.Class_Id;

        param[1] = new SqlParameter("@sp_subject_id", SqlDbType.Int);
        param[1].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@sp_term_id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Criteria_Type_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCurrentWeightagePercentage", param);
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

    public DataTable GetCurrentWeightage(BLLEvaluation_Criteria _obj)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@sp_class_id", SqlDbType.Int);
        param[0].Value = _obj.Class_Id;

        param[1] = new SqlParameter("@sp_subject_id", SqlDbType.Int);
        param[1].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@sp_evalType_id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Type_Id;

        param[3] = new SqlParameter("@sp_term_id", SqlDbType.Int);
        param[3].Value = _obj.Evaluation_Criteria_Type_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCurrentWeightage", param);
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
