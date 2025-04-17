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
/// Summary description for _DALSection_Subject_Tool
/// </summary>
public class DALSection_Subject_Tool
{
    DALBase dalobj = new DALBase();


    public DALSection_Subject_Tool()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Section_Subject_ToolAdd(BLLSection_Subject_Tool objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        ////param[0] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        ////param[0].Value = objbll.WrkTool_ID;
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@ProjectTool_ID", SqlDbType.Int); 
        param[1].Value = objbll.ProjectTool_ID;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[4].Value = objbll.CreatedBy;
        //////////////param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        //////////////param[5].Value = objbll.ModifiedOn;
        //////////////param[6] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        //////////////param[6].Value = objbll.ModifiedBy;



        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_ToolInsert", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int Section_Subject_ToolUpdate(BLLSection_Subject_Tool objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Section_Subject_ToolUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Section_Subject_ToolDelete(BLLSection_Subject_Tool objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Tool_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Section_Subject_Tool_Id;


        int k = dalobj.sqlcmdExecute("Section_Subject_ToolDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Section_Subject_ToolSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_ToolSelectById", param);
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
    
    public DataTable Section_Subject_ToolSelect(BLLSection_Subject_Tool objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Section_Subject_ToolSelectAll", param);
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


    public DataTable Section_Subject_ToolSelectWorkSiteBySectionSubjectId(BLLSection_Subject_Tool objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_Subject_ToolSelectWorkSiteBySectionSubjectId", param);
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


    public DataTable Section_Subject_ToolSelectWorkSiteBySectionSubjectIdForStudent(BLLSection_Subject_Tool objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_Subject_ToolSelectWorkSiteBySectionSubjectIdForStudent", param);
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




    public DataTable Section_Subject_ToolSelectByStatusID(BLLSection_Subject_Tool objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Section_Subject_ToolSelectByStatusID");
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
