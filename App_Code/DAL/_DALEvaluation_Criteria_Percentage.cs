using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALEvaluation_Criteria_Percentage
/// </summary>
public class DALEvaluation_Criteria_Percentage
{
    DALBase dalobj = new DALBase();


    public DALEvaluation_Criteria_Percentage()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Evaluation_Criteria_PercentageAdd(BLLEvaluation_Criteria_Percentage objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        //param[0] = new SqlParameter("@Evaluation_Criteria_Percentage_Id", SqlDbType.Int);
        //param[0].Value = objbll.Evaluation_Criteria_Percentage_Id;
        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Type_Id;
        param[1] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Type_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[3].Value = objbll.Subject_Id;
        param[4] = new SqlParameter("@Percentage", SqlDbType.Decimal);
        param[4].Value = objbll.Percentage;


        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_PercentageInsert", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int Evaluation_Criteria_PercentageUpdate(BLLEvaluation_Criteria_Percentage objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Evaluation_Criteria_Percentage_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Percentage_Id;
        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;
        param[2] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Type_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;
        param[4] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[4].Value = objbll.Subject_Id;
        param[5] = new SqlParameter("@Percentage", SqlDbType.Decimal);
        param[5].Value = objbll.Percentage;

 
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_PercentageUpdate", param);
        int k = (int)param[6].Value;
        return k;
    }

    public int Evaluation_Criteria_PercentageApplyAllChangesUpdate(BLLEvaluation_Criteria_Percentage objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Percentage_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Percentage_Id;
        param[1] = new SqlParameter("@Percentage", SqlDbType.Decimal);
        param[1].Value = objbll.Percentage;


        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_PercentageApplyAllChangesUpdate", param);
        int k = (int)param[2].Value;
        return k;
    }

    public int Evaluation_Criteria_PercentageDelete(BLLEvaluation_Criteria_Percentage objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Evaluation_Criteria_Percentage_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Percentage_Id;


        int k = dalobj.sqlcmdExecute("Evaluation_Criteria_PercentageDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Evaluation_Criteria_PercentageSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Percentage_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_PercentageSelectById", param);
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
    
    public DataTable Evaluation_Criteria_PercentageSelect(BLLEvaluation_Criteria_Percentage objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Percentage_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_PercentageSelectAll", param);
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

    public DataTable Evaluation_Criteria_PercentageSelectByStatusID(BLLEvaluation_Criteria_Percentage objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_PercentageSelectByStatusID");
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


    //public DataTable Subject_ByOrgId(int _id)
    //{
    //    SqlParameter[] param = new SqlParameter[1];

    //    param[0] = new SqlParameter("@OrgId", SqlDbType.Int);
    //    param[0].Value = _id;


    //    DataTable _dt = new DataTable();

    //    try
    //    {
    //        dalobj.OpenConnection();
    //        _dt = dalobj.sqlcmdFetch("Subject_ByOrgId", param);
    //        return _dt;
    //    }
    //    catch (Exception _exception)
    //    {
    //        throw _exception;
    //    }
    //    finally
    //    {
    //        dalobj.CloseConnection();
    //    }

    //    return _dt;
    //}


    public DataTable Class_SubjectSelectAllByClassId(BLLEvaluation_Criteria_Percentage _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@OrgId", SqlDbType.Int);
        param[0].Value = _obj.Main_Organisation_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = _obj.Class_Id;

        

        

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

    public DataTable Evaluation_Criteria_PercentageSelectAllByClassIdSubjectId(BLLEvaluation_Criteria_Percentage _obj)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = _obj.Class_Id;

        ////////param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        ////////param[1].Value = _obj.Subject_Id;

        param[1] = new SqlParameter("@Eval_Type_Id", SqlDbType.Int);
        param[1].Value = _obj.Evaluation_Criteria_Type_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_PercentageSelectAllByClassIdSubjectId", param);
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


    public DataTable GetCurrentWeightagePercentage(BLLEvaluation_Criteria_Percentage _obj)
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


    public DataTable Evaluation_Criteria_PercentageSelectAllByClassIdSubjectIdEvlPerctId(BLLEvaluation_Criteria_Percentage _obj)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = _obj.Class_Id;

        //////////param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        //////////param[1].Value = _obj.Subject_Id;

        param[1] = new SqlParameter("@Eval_Type_Id", SqlDbType.Int);
        param[1].Value = _obj.Evaluation_Criteria_Type_Id;

        param[2] = new SqlParameter("@Eval_Percentage_Id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Criteria_Percentage_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_PercentageSelectAllByClassIdSubjectIdEvlPerctId", param);
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

    public DataTable Evaluation_Criteria_PercentageSelectAllByEvlTypeId(BLLEvaluation_Criteria_Percentage _obj)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = _obj.Class_Id;

        param[1] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[1].Value = _obj.Subject_Id;

        param[2] = new SqlParameter("@Eval_Type_Id", SqlDbType.Int);
        param[2].Value = _obj.Evaluation_Criteria_Type_Id;

        param[3] = new SqlParameter("@Eval_Id", SqlDbType.Int);
        param[3].Value = _obj.Evaluation_Type_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_PercentageSelectAllByEvlTypeId", param);
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
