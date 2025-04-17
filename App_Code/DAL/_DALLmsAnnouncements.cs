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
/// Summary description for _DALLmsAnnouncements
/// </summary>
public class DALLmsAnnouncements
{
    DALBase dalobj = new DALBase();


    public DALLmsAnnouncements()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsAnnouncementsAdd(BLLLmsAnnouncements objbll)
    {
        SqlParameter[] param = new SqlParameter[11];

        //////param[0] = new SqlParameter("@Announcement_ID", SqlDbType.Int); 
        //////param[0].Value = objbll.Announcement_ID;
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); 
        param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[1].Value = objbll.WrkTool_ID;
        param[2] = new SqlParameter("@AncmtTitle", SqlDbType.NVarChar); 
        param[2].Value = objbll.AncmtTitle;
        param[3] = new SqlParameter("@AncmtBody", SqlDbType.NVarChar);
        param[3].Value = objbll.AncmtBody;
        param[4] = new SqlParameter("@IsPublished", SqlDbType.Bit);
        param[4].Value = objbll.IsPublished;
        param[5] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[5].Value = objbll.Status_Id;
        param[6] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[6].Value = objbll.CreatedOn;
        param[7] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[7].Value = objbll.CreatedBy;
        param[8] = new SqlParameter("@PublishStartDate", SqlDbType.DateTime);
        param[8].Value = objbll.PublishStartDate;
        param[9] = new SqlParameter("@PublishEndDate", SqlDbType.DateTime);
        param[9].Value = objbll.PublishEndDate;





        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAnnouncementsInsert", param);
        int k = (int)param[10].Value;
        return k;

    }
    public int LmsAnnouncementsUpdate(BLLLmsAnnouncements objbll)
    {
        SqlParameter[] param = new SqlParameter[12];


        param[0] = new SqlParameter("@Announcement_ID", SqlDbType.Int);
        param[0].Value = objbll.Announcement_ID;
        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;
        param[2] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[2].Value = objbll.WrkTool_ID;
        param[3] = new SqlParameter("@AncmtTitle", SqlDbType.NVarChar);
        param[3].Value = objbll.AncmtTitle;
        param[4] = new SqlParameter("@AncmtBody", SqlDbType.NVarChar);
        param[4].Value = objbll.AncmtBody;
        param[5] = new SqlParameter("@IsPublished", SqlDbType.Bit);
        param[5].Value = objbll.IsPublished;
        param[6] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[6].Value = objbll.Status_Id;
        param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[7].Value = objbll.ModifiedOn;
        param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[8].Value = objbll.ModifiedBy;
        param[9] = new SqlParameter("@PublishStartDate", SqlDbType.DateTime);
        param[9].Value = objbll.PublishStartDate;
        param[10] = new SqlParameter("@PublishEndDate", SqlDbType.DateTime);
        param[10].Value = objbll.PublishEndDate;
 
        param[11] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[11].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAnnouncementsUpdate", param);
        int k = (int)param[11].Value;
        return k;
    }
    public int LmsAnnouncementsDelete(BLLLmsAnnouncements objbll)
    {

        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Announcement_ID", SqlDbType.Int);
        param[0].Value = objbll.Announcement_ID;


        int k = dalobj.sqlcmdExecute("LmsAnnouncementsDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsAnnouncementsSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsAnnouncementsSelectById", param);
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
    
    public DataTable LmsAnnouncementsSelect(BLLLmsAnnouncements objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsAnnouncementsSelectAll", param);
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




    public DataTable LmsAnnouncementSelectAllBySectionSubjectIdWrkToolId(BLLLmsAnnouncements objbll)
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
            _dt = dalobj.sqlcmdFetch("LmsAnnouncementSelectAllBySectionSubjectIdWrkToolId", param);
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


    public DataTable LmsAnnouncementSelectAllByAnnouncementId(BLLLmsAnnouncements objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Announcement_ID", SqlDbType.Int);
        param[0].Value = objbll.Announcement_ID;


        




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAnnouncementSelectAllByAnnouncementId", param);
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




    public DataTable LmsAnnouncementsSelectByStatusID(BLLLmsAnnouncements objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAnnouncementsSelectByStatusID");
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
