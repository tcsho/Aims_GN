using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for _DALStudentNameFixedUpsert
/// </summary>
public class _DALStudentNameFixedUpsert
{
    DALBase dalobj = new DALBase();


    public _DALStudentNameFixedUpsert()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int StudentNameFixedUpsertAdd(BLLStudentNameFixedUpsert objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("StudentNameFixedUpsertInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int StudentNameFixedUpsertUpdate(BLLStudentNameFixedUpsert objbll)
    {
        SqlParameter[] param = new SqlParameter[4];
        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = Convert.ToInt32( objbll.Student_Id);
        param[1] = new SqlParameter("@First_Name", SqlDbType.NVarChar);
        param[1].Value = objbll.First_Name;
        param[2] = new SqlParameter("@Last_Name", SqlDbType.NVarChar);
        param[2].Value = objbll.Last_Name;
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;
        dalobj.sqlcmdExecute("StudentNameFixedUpsert", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int StudentNameFixedUpsertDelete(BLLStudentNameFixedUpsert objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@StudentNameFixedUpsert_Id", SqlDbType.Int);
     //   param[0].Value = objbll.StudentNameFixedUpsert_Id;


        int k = dalobj.sqlcmdExecute("StudentNameFixedUpsertDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable StudentNameFixedUpsertSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("StudentNameFixedUpsertSelect", param);
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
    
    public DataTable StudentNameFixedUpsertSelect(BLLStudentNameFixedUpsert objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("StudentNameFixedUpsertSelect", param);
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


    public int StudentNameFixedUpsertSelectField(int _Id)
        {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("", param);
        int k = (int)param[1].Value;
        return k;

        }


    #endregion


}
