using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALEvaluation_Type
/// </summary>
public class DALEvaluation_Type
{
    DALBase dalobj = new DALBase();


    public DALEvaluation_Type()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Evaluation_TypeAdd(BLLEvaluation_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        //param[0] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Evaluation_Type_Id;
        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int); 
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Name", SqlDbType.NVarChar); 
        param[1].Value = objbll.Name;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@IsExam", SqlDbType.Bit); 
        param[3].Value = objbll.IsExam;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_TypeInsert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int Evaluation_TypeUpdate(BLLEvaluation_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        //param[0] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Evaluation_Type_Id;
        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Name", SqlDbType.NVarChar);
        param[1].Value = objbll.Name;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@IsExam", SqlDbType.Bit);
        param[3].Value = objbll.IsExam;

 
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Evaluation_TypeUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Evaluation_TypeDelete(BLLEvaluation_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Evaluation_Type_Id;


        int k = dalobj.sqlcmdExecute("Evaluation_TypeDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Evaluation_TypeSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_TypeSelectById", param);
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
    
    public DataTable Evaluation_TypeSelect(BLLEvaluation_Type objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Evaluation_TypeSelectAll", param);
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

    public DataTable Evaluation_TypeSelectByStatusID(BLLEvaluation_Type objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_TypeSelectByStatusID");
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

  



    public DataTable Evaluation_TypeSelectByOrgId(BLLEvaluation_Type objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Org_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;

       


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Evaluation_TypeSelect", param);
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
