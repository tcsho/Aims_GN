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
/// Summary description for _DALLmsRes
/// </summary>
public class DALLmsRes
{
    DALBase dalobj = new DALBase();


    public DALLmsRes()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsResAdd(BLLLmsRes objbll)
    {
        SqlParameter[] param = new SqlParameter[7];


        //param[0] = new SqlParameter("@Resource_ID", SqlDbType.Int);
        //param[0].Value = objbll.Resource_ID;
        param[0] = new SqlParameter("@ResourceTitle", SqlDbType.NVarChar);
        param[0].Value = objbll.ResourceTitle;
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
        //param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        //param[7].Value = objbll.ModifiedOn;
        //param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        //param[8].Value = objbll.ModifiedBy;



        ////param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        ////param[14].Direction = ParameterDirection.Output;

        ////dalobj.sqlcmdExecute("LmsResInsert", param);
        ////int k = (int)param[14].Value;
        ////return k;

        int k = dalobj.sqlcmdExecute("LmsResInsert", param);
        return k;


    }
    public int LmsResUpdate(BLLLmsRes objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@Resource_ID", SqlDbType.Int); param[0].Value = objbll.Resource_ID;
        param[0] = new SqlParameter("@ResourceTitle", SqlDbType.NVarChar); param[0].Value = objbll.ResourceTitle;
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

        dalobj.sqlcmdExecute("LmsResUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsResDelete(BLLLmsRes objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsRes_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsRes_Id;


        int k = dalobj.sqlcmdExecute("LmsResDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsResSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsResSelectById", param);
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
    
    public DataTable LmsResSelect(BLLLmsRes objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsResSelectAll", param);
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



    public DataTable LmsResSelectAllBySectionSubjectIdWrkToolId(BLLLmsRes objbll)
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
            _dt = dalobj.sqlcmdFetch("LmsResSelectAllBySectionSubjectIdWrkToolId", param);
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

    public DataTable LmsResSelectByStatusID(BLLLmsRes objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsResSelectByStatusID");
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
