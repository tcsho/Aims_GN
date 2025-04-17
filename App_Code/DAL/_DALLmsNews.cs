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
/// Summary description for _DALLmsNews
/// </summary>
public class DALLmsNews
{
    DALBase dalobj = new DALBase();


    public DALLmsNews()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsNewsAdd(BLLLmsNews objbll)
    {
        SqlParameter[] param = new SqlParameter[11];

        //////param[0] = new SqlParameter("@Announcement_ID", SqlDbType.Int); 
        //////param[0].Value = objbll.Announcement_ID;
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[1].Value = objbll.WrkTool_ID;
        param[2] = new SqlParameter("@NewsTitle", SqlDbType.NVarChar);
        param[2].Value = objbll.NewsTitle;
        param[3] = new SqlParameter("@NewsDetail", SqlDbType.NVarChar);
        param[3].Value = objbll.NewsDetail;
        param[4] = new SqlParameter("@PublishStatus_ID", SqlDbType.Bit);
        param[4].Value = objbll.PublishStatus_ID;
        param[5] = new SqlParameter("@Status_ID", SqlDbType.Int);
        param[5].Value = objbll.Status_ID;
        param[6] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[6].Value = objbll.CreatedOn;
        param[7] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[7].Value = objbll.CreatedBy;
        param[8] = new SqlParameter("@StartDateTime", SqlDbType.DateTime);
        param[8].Value = objbll.StartDateTime;
        param[9] = new SqlParameter("@EndDateTime", SqlDbType.DateTime);
        param[9].Value = objbll.EndDateTime;





        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsNewsInsert", param);
        int k = (int)param[10].Value;
        return k;


        

    }
    public int LmsNewsUpdate(BLLLmsNews objbll)
    {
        SqlParameter[] param = new SqlParameter[12];

        param[0] = new SqlParameter("@News_ID", SqlDbType.Int);
        param[0].Value = objbll.News_ID;
        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;
        param[2] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[2].Value = objbll.WrkTool_ID;
        param[3] = new SqlParameter("@NewsTitle", SqlDbType.NVarChar);
        param[3].Value = objbll.NewsTitle;
        param[4] = new SqlParameter("@NewsDetail", SqlDbType.NVarChar);
        param[4].Value = objbll.NewsDetail;
        param[5] = new SqlParameter("@PublishStatus_ID", SqlDbType.Bit);
        param[5].Value = objbll.PublishStatus_ID;
        param[6] = new SqlParameter("@Status_ID", SqlDbType.Int);
        param[6].Value = objbll.Status_ID;
        param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[7].Value = objbll.ModifiedOn;
        param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[8].Value = objbll.ModifiedBy;
        param[9] = new SqlParameter("@StartDateTime", SqlDbType.DateTime);
        param[9].Value = objbll.StartDateTime;
        param[10] = new SqlParameter("@EndDateTime", SqlDbType.DateTime);
        param[10].Value = objbll.EndDateTime;





        param[11] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[11].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsNewsUpdate", param);
        int k = (int)param[11].Value;
        return k;



       
    }
    public int LmsNewsDelete(BLLLmsNews objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@News_ID", SqlDbType.Int);
        param[0].Value = objbll.News_ID;


        int k = dalobj.sqlcmdExecute("LmsNewsDelete", param);

        return k;

     
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsNewsSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsNewsSelectById", param);
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
    
    public DataTable LmsNewsSelect(BLLLmsNews objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsNewsSelectAll", param);
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


    public DataTable LmsNewsSelectAllBySectionSubjectIdWrkToolId(BLLLmsNews objbll)
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
            _dt = dalobj.sqlcmdFetch("LmsNewsSelectAllBySectionSubjectIdWrkToolId", param);
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



    public DataTable LmsNewsSelectAllByNewsId(BLLLmsNews objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@News_ID", SqlDbType.Int);
        param[0].Value = objbll.News_ID;


        //// a////
        // for test
        ////param[1] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        ////param[1].Value = objbll.WrkTool_ID;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsNewsSelectAllByNewsId", param);
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



    public DataTable LmsNewsSelectByStatusID(BLLLmsNews objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsNewsSelectByStatusID");
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
