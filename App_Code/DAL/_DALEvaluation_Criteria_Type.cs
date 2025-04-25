using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALEvaluation_Criteria_Type
/// </summary>
public class DALEvaluation_Criteria_Type
{
    DALBase dalobj = new DALBase();


    public DALEvaluation_Criteria_Type()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Evaluation_Criteria_TypeAdd(BLLEvaluation_Criteria_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        //param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //param[0].Value = objbll.Evaluation_Criteria_Type_Id;
        param[0] = new SqlParameter("@Type", SqlDbType.NVarChar);
        param[0].Value = objbll.Type;
        param[1] = new SqlParameter("@Type_Code", SqlDbType.NVarChar);
        param[1].Value = objbll.Type_Code;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[3].Value = objbll.Main_Organistion_Id;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_TypeInsert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int Evaluation_Criteria_TypeUpdate(BLLEvaluation_Criteria_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        //param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //param[0].Value = objbll.Evaluation_Criteria_Type_Id;
        param[0] = new SqlParameter("@Type", SqlDbType.NVarChar);
        param[0].Value = objbll.Type;
        param[1] = new SqlParameter("@Type_Code", SqlDbType.NVarChar);
        param[1].Value = objbll.Type_Code;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@Main_Organistion_Id", SqlDbType.Int);
        param[3].Value = objbll.Main_Organistion_Id;

 
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_Criteria_TypeUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Evaluation_Criteria_TypeDelete(BLLEvaluation_Criteria_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        int k = dalobj.sqlcmdExecute("Evaluation_Criteria_TypeDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Evaluation_Criteria_TypeSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeSelectById", param);
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
    public DataTable Evaluation_Criteria_TypeSelectWeeks(int _id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeSelectWeeks", param);
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
    public DataTable Evaluation_Criteria_TypeSelect(BLLEvaluation_Criteria_Type objbll)
    {
   

    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeSelectAll");
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
    public DataTable Evaluation_Criteria_TypeSelectBySectionID(BLLEvaluation_Criteria_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeSelectBySectionID", param);
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

    public DataTable Evaluation_Criteria_TypeSelectBySectionIDReports(BLLEvaluation_Criteria_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeSelectBySectionIDReports", param);
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
    public DataTable Evaluation_Criteria_TypeSelectByNewClassID(BLLEvaluation_Criteria_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeSelectByNewClassID", param);
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

    public DataTable Evaluation_Criteria_TypeSelectByStatusID(BLLEvaluation_Criteria_Type objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_Criteria_TypeSelectByStatusID");
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
