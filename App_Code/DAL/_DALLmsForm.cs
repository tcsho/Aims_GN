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
/// Summary description for _DALLmsForm
/// </summary>
public class DALLmsForm
{
    DALBase dalobj = new DALBase();


    public DALLmsForm()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsFormAdd(BLLLmsForm objbll)
    {
        SqlParameter[] param = new SqlParameter[12];
        ////////////param[0] = new SqlParameter("@Forum_ID", SqlDbType.Int);
        ////////////param[0].Value = objbll.Forum_ID;
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@ForumTitle", SqlDbType.NVarChar);
        param[1].Value = objbll.ForumTitle;
        param[2] = new SqlParameter("@ShortDescription", SqlDbType.NVarChar); 
        param[2].Value = objbll.ShortDescription;
        param[3] = new SqlParameter("@LongDescription", SqlDbType.NVarChar);
        param[3].Value = objbll.LongDescription;
        param[4] = new SqlParameter("@isLock", SqlDbType.Bit);
        param[4].Value = objbll.isLock;
        param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[5].Value = objbll.CreatedOn;
        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[6].Value = objbll.CreatedBy;
        ////////////param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        ////////////param[7].Value = objbll.ModifiedOn;
        ////////////param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        ////////////param[8].Value = objbll.ModifiedBy;
        param[7] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[7].Value = objbll.Status_Id;
        param[8] = new SqlParameter("@PublishStatus_ID", SqlDbType.Int);
        param[8].Value = objbll.PublishStatus_ID;
        param[9] = new SqlParameter("@GblAccessType_ID", SqlDbType.Int);
        param[9].Value = objbll.GblAccessType_ID;
        param[10] = new SqlParameter("@WrkTool_Id", SqlDbType.Int); 
        param[10].Value = objbll.WrkTool_Id;




        param[11] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[11].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsFormInsert", param);
        int k = (int)param[11].Value;
        return k;

    }
    public int LmsFormUpdate(BLLLmsForm objbll)
    {
        SqlParameter[] param = new SqlParameter[13];
        param[0] = new SqlParameter("@Forum_ID", SqlDbType.Int);
        param[0].Value = objbll.Forum_ID;
        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;
        param[2] = new SqlParameter("@ForumTitle", SqlDbType.NVarChar);
        param[2].Value = objbll.ForumTitle;
        param[3] = new SqlParameter("@ShortDescription", SqlDbType.NVarChar);
        param[3].Value = objbll.ShortDescription;
        param[4] = new SqlParameter("@LongDescription", SqlDbType.NVarChar);
        param[4].Value = objbll.LongDescription;
        param[5] = new SqlParameter("@isLock", SqlDbType.Bit);
        param[5].Value = objbll.isLock;
        ////////param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        ////////param[5].Value = objbll.CreatedOn;
        ////////param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        ////////param[6].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[6].Value = objbll.ModifiedOn;
        param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[7].Value = objbll.ModifiedBy;
        param[8] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[8].Value = objbll.Status_Id;
        param[9] = new SqlParameter("@PublishStatus_ID", SqlDbType.Int);
        param[9].Value = objbll.PublishStatus_ID;
        param[10] = new SqlParameter("@GblAccessType_ID", SqlDbType.Int);
        param[10].Value = objbll.GblAccessType_ID;
        param[11] = new SqlParameter("@WrkTool_Id", SqlDbType.Int);
        param[11].Value = objbll.WrkTool_Id;



 
        param[12] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[12].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsFormUpdate", param);
        int k = (int)param[12].Value;
        return k;
    }
    public int LmsFormDelete(BLLLmsForm objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Forum_ID", SqlDbType.Int);
        param[0].Value = objbll.Forum_ID;


        int k = dalobj.sqlcmdExecute("LmsFormDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsFormSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsFormSelectById", param);
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
    
    public DataTable LmsFormSelect(BLLLmsForm objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsFormSelectAll", param);
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

    public DataTable LmsFormSelectByStatusID(BLLLmsForm objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsFormSelectByStatusID");
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


    public DataTable LmsFormelectAllBySectionSubjectIdWrkToolId(BLLLmsForm objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


        param[1] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[1].Value = objbll.WrkTool_Id;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsFormelectAllBySectionSubjectIdWrkToolId", param);
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


    public DataTable LmsFormSelectAllByForumID(BLLLmsForm objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Forum_ID", SqlDbType.Int);
        param[0].Value = objbll.Forum_ID;







        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsFormSelectAllByForumID", param);
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
