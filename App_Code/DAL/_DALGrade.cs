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
/// Summary description for _DALGrade
/// </summary>
public class DALGrade
{
    DALBase dalobj = new DALBase();


    public DALGrade()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int GradeAdd(BLLGrade objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("GradeInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int GradeUpdate(BLLGrade objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("GradeUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int GradeDelete(BLLGrade objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Grade_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Grade_Id;


        int k = dalobj.sqlcmdExecute("GradeDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable GradeSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("GradeSelectById", param);
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

    public DataTable GradeSelectBymoID(BLLGrade objbll)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@sp_moID", SqlDbType.Int);
    param[0].Value = objbll.Main_Organisation_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("GradeSelectBymoID", param);
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

    public DataTable GradeSelectByStatusID(BLLGrade objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GradeSelectByStatusID");
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
