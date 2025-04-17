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
/// Summary description for _DALLmsDpb
/// </summary>
public class DALLmsDpb
{
    DALBase dalobj = new DALBase();


    public DALLmsDpb()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsDpbAdd(BLLLmsDpb objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        //param[0] = new SqlParameter("@DropBox_ID", SqlDbType.Int);
        //param[0].Value = objbll.DropBox_ID;
        param[0] = new SqlParameter("@DropBoxTitle", SqlDbType.NVarChar);
        param[0].Value = objbll.DropBoxTitle;
        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;
        param[2] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[2].Value = objbll.WrkTool_ID;
        param[3] = new SqlParameter("@FolderPath", SqlDbType.NVarChar);
        param[3].Value = objbll.FolderPath;
        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[4].Value = objbll.Status_Id;
        param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[5].Value = objbll.CreatedOn;
        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[6].Value = objbll.CreatedBy;
        ////////param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        ////////param[7].Value = objbll.ModifiedOn;
        ////////param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        ////////param[8].Value = objbll.ModifiedBy;



        ////param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        ////param[14].Direction = ParameterDirection.Output;

        ////dalobj.sqlcmdExecute("LmsDpbInsert", param);
        ////int k = (int)param[14].Value;
        ////return k;


        int k = dalobj.sqlcmdExecute("LmsDpbInsert", param);
        return k;


    }
    public int LmsDpbUpdate(BLLLmsDpb objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@DropBox_ID", SqlDbType.Int); param[0].Value = objbll.DropBox_ID;
        param[0] = new SqlParameter("@DropBoxTitle", SqlDbType.NVarChar); param[0].Value = objbll.DropBoxTitle;
        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); param[1].Value = objbll.Section_Subject_Id;
        param[2] = new SqlParameter("@WrkTool_ID", SqlDbType.Int); param[2].Value = objbll.WrkTool_ID;
        param[3] = new SqlParameter("@FolderPath", SqlDbType.NVarChar); param[3].Value = objbll.FolderPath;
        param[4] = new SqlParameter("@Status_Id", SqlDbType.Int); param[4].Value = objbll.Status_Id;
        param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[5].Value = objbll.CreatedOn;
        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[6].Value = objbll.CreatedBy;
        param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[7].Value = objbll.ModifiedOn;
        param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[8].Value = objbll.ModifiedBy;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsDpbUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsDpbDelete(BLLLmsDpb objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsDpb_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsDpb_Id;


        int k = dalobj.sqlcmdExecute("LmsDpbDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsDpbSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsDpbSelectById", param);
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
    
    public DataTable LmsDpbSelect(BLLLmsDpb objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsDpbSelectAll", param);
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

    public DataTable LmsDpbSelectByStatusID(BLLLmsDpb objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsDpbSelectByStatusID");
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

    public DataTable LmsDpbSelectAllBySectionSubjectIdWrkToolId(BLLLmsDpb objbll)
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
            _dt = dalobj.sqlcmdFetch("LmsDpbSelectAllBySectionSubjectIdWrkToolId", param);
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
