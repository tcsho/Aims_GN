using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALClass_Section_Welcome
/// </summary>
public class DALClass_Section_Welcome
{
    DALBase dalobj = new DALBase();


    public DALClass_Section_Welcome()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Class_Section_WelcomeAdd(BLLClass_Section_Welcome objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int); 
        param[0].Value = objbll.Section_Id;
        
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int); 
        param[1].Value = objbll.Session_Id;
        
        param[2] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[2].Value = objbll.CreatedOn;
        
        param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[3].Value = objbll.CreatedBy;

        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_Section_WelcomeInsert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int Class_Section_WelcomeUpdate(BLLClass_Section_Welcome objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Class_Section_WelcomeUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Class_Section_WelcomeDelete(BLLClass_Section_Welcome objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_Section_Welcome_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Class_Section_Welcome_Id;


        int k = dalobj.sqlcmdExecute("Class_Section_WelcomeDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Class_Section_WelcomeSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Class_Section_WelcomeSelectById", param);
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
    
    public DataTable Class_Section_WelcomeSelect(BLLClass_Section_Welcome objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Class_Section_WelcomeSelectAll", param);
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



    public DataTable Class_Section_WelcomeSelectByStatusID(BLLClass_Section_Welcome objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Class_Section_WelcomeSelectByStatusID");
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



        public DataTable Class_Section_WelcomeSelectBySectionSession(BLLClass_Section_Welcome objbll)
    {
        DataTable dt = new DataTable();
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        
            try
        {

            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Class_Section_WelcomeSelectBySectionSession",param);
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
