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
/// Summary description for _DALLmsSch
/// </summary>
public class DALLmsSch
{
    DALBase dalobj = new DALBase();


    public DALLmsSch()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsSchAdd(BLLLmsSch objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        ////////////param[0] = new SqlParameter("@Schedule_ID", SqlDbType.Int);
        ////////////param[0].Value = objbll.Schedule_ID;
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[1].Value = objbll.WrkTool_ID;


        param[2] = new SqlParameter("@ScheduleID", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSchInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int LmsSchUpdate(BLLLmsSch objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@Schedule_ID", SqlDbType.Int); param[0].Value = objbll.Schedule_ID;
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@WrkTool_ID", SqlDbType.Int); param[1].Value = objbll.WrkTool_ID;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSchUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsSchDelete(BLLLmsSch objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsSch_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsSch_Id;


        int k = dalobj.sqlcmdExecute("LmsSchDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsSchSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSchSelectById", param);
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
    
    public DataTable LmsSchSelect(BLLLmsSch objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSchSelectAll", param);
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

    public DataTable LmsSchSelectByStatusID(BLLLmsSch objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSchSelectByStatusID");
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


    public DataTable LmsSchSelectAllBySectionSubjectIdWrkToolId(BLLLmsSch objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


        param[1] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[1].Value = objbll.WrkTool_ID;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSchSelectAllBySectionSubjectIdWrkToolId", param);
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
