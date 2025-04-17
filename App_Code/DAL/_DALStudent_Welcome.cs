using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALStudent_Welcome
/// </summary>
public class DALStudent_Welcome
{
    DALBase dalobj = new DALBase();


    public DALStudent_Welcome()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_WelcomeAdd(BLLStudent_Welcome objbll)
    {
        SqlParameter[] param = new SqlParameter[3];


        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int); 
        param[0].Value = objbll.Student_Id;
              
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int); 
        param[1].Value = objbll.Class_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_WelcomeInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int Student_WelcomeUpdate(BLLStudent_Welcome objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_WelcomeUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Student_WelcomeDelete(BLLStudent_Welcome objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Welcome_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Welcome_Id;


        int k = dalobj.sqlcmdExecute("Student_WelcomeDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_WelcomeSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Student_WelcomeSelectById", param);
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
    
    public DataTable Student_WelcomeSelect(BLLStudent_Welcome objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Student_WelcomeSelectAll", param);
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

    public DataTable Student_WelcomeSelectByStatusID(BLLStudent_Welcome objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Student_WelcomeSelectByStatusID");
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
