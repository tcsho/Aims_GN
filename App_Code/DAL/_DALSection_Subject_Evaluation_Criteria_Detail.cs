using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALSection_Subject_Evaluation_Criteria_Detail
/// </summary>
public class DALSection_Subject_Evaluation_Criteria_Detail
{
    DALBase dalobj = new DALBase();


    public DALSection_Subject_Evaluation_Criteria_Detail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Section_Subject_Evaluation_Criteria_DetailAdd(BLLSection_Subject_Evaluation_Criteria_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Evaluation_Criteria_DetailInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int Section_Subject_Evaluation_Criteria_DetailUpdate(BLLSection_Subject_Evaluation_Criteria_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_Evaluation_Criteria_DetailUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Section_Subject_Evaluation_Criteria_DetailDelete(BLLSection_Subject_Evaluation_Criteria_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Evaluation_Criteria_Detail_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Section_Subject_Evaluation_Criteria_Detail_Id;


        int k = dalobj.sqlcmdExecute("Section_Subject_Evaluation_Criteria_DetailDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Section_Subject_Evaluation_Criteria_DetailSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Section_Subject_Evaluation_Criteria_DetailSelectById", param);
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
    
    public DataTable Section_Subject_Evaluation_Criteria_DetailSelect(BLLSection_Subject_Evaluation_Criteria_Detail objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Section_Subject_Evaluation_Criteria_DetailSelectAll", param);
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

    public DataTable Section_Subject_Evaluation_Criteria_DetailSelectByStatusID(BLLSection_Subject_Evaluation_Criteria_Detail objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Section_Subject_Evaluation_Criteria_DetailSelectByStatusID");
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
