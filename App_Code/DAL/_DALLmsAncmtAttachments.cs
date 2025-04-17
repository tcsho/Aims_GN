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
/// Summary description for _DALLmsAncmtAttachments
/// </summary>
public class DALLmsAncmtAttachments
{
    DALBase dalobj = new DALBase();


    public DALLmsAncmtAttachments()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsAncmtAttachmentsAdd(BLLLmsAncmtAttachments objbll)
    {
        SqlParameter[] param = new SqlParameter[15];


        param[0] = new SqlParameter("@AncmtAttach_ID", SqlDbType.Int); 
        param[0].Value = objbll.AncmtAttach_ID;
        param[0] = new SqlParameter("@Announcement_ID", SqlDbType.Int); 
        param[0].Value = objbll.Announcement_ID;
        param[1] = new SqlParameter("@AncmtPath", SqlDbType.NVarChar); 
        param[1].Value = objbll.AncmtPath;
        param[2] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[2].Value = objbll.CreatedOn;
        param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[3].Value = objbll.CreatedBy;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        param[4].Value = objbll.ModifiedOn;
        param[5] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        param[5].Value = objbll.ModifiedBy;
        param[6] = new SqlParameter("@WebURL", SqlDbType.NVarChar); 
        param[6].Value = objbll.WebURL;
        param[7] = new SqlParameter("@AttachType_ID", SqlDbType.Int); 
        param[7].Value = objbll.AttachType_ID;


        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAncmtAttachmentsInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int LmsAncmtAttachmentsUpdate(BLLLmsAncmtAttachments objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@AncmtAttach_ID", SqlDbType.Int);
        param[0].Value = objbll.AncmtAttach_ID;
        param[0] = new SqlParameter("@Announcement_ID", SqlDbType.Int);
        param[0].Value = objbll.Announcement_ID;
        param[1] = new SqlParameter("@AncmtPath", SqlDbType.NVarChar);
        param[1].Value = objbll.AncmtPath;
        param[2] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[2].Value = objbll.CreatedOn;
        param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[3].Value = objbll.CreatedBy;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[4].Value = objbll.ModifiedOn;
        param[5] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[5].Value = objbll.ModifiedBy;
        param[6] = new SqlParameter("@WebURL", SqlDbType.NVarChar);
        param[6].Value = objbll.WebURL;
        param[7] = new SqlParameter("@AttachType_ID", SqlDbType.Int);
        param[7].Value = objbll.AttachType_ID;

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAncmtAttachmentsUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsAncmtAttachmentsDelete(BLLLmsAncmtAttachments objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsAncmtAttachments_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsAncmtAttachments_Id;


        int k = dalobj.sqlcmdExecute("LmsAncmtAttachmentsDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsAncmtAttachmentsSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsAncmtAttachmentsSelectById", param);
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
    
    public DataTable LmsAncmtAttachmentsSelect(BLLLmsAncmtAttachments objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsAncmtAttachmentsSelectAll", param);
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

    public DataTable LmsAncmtAttachmentsSelectByStatusID(BLLLmsAncmtAttachments objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAncmtAttachmentsSelectByStatusID");
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
