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
/// Summary description for _DALLmsFormTopic
/// </summary>
public class DALLmsFormTopic
{
    DALBase dalobj = new DALBase();


    public DALLmsFormTopic()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsFormTopicAdd(BLLLmsFormTopic objbll)
    {
        SqlParameter[] param = new SqlParameter[15];
        ////////param[0] = new SqlParameter("@Topic_ID", SqlDbType.Int);
        ////////param[0].Value = objbll.Topic_ID;
        param[0] = new SqlParameter("@Forum_ID", SqlDbType.Int);
        param[0].Value = objbll.Forum_ID;
        param[1] = new SqlParameter("@TopicTitle", SqlDbType.NVarChar);
        param[1].Value = objbll.TopicTitle;
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
        ////////////////param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        ////////////////param[7].Value = objbll.ModifiedOn;
        ////////////////param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        ////////////////param[8].Value = objbll.ModifiedBy;
        param[7] = new SqlParameter("@isGradeBook", SqlDbType.Bit);
        param[7].Value = objbll.isGradeBook;
        param[8] = new SqlParameter("@TotalPoints", SqlDbType.Int);
        param[8].Value = objbll.TotalPoints;
        param[9] = new SqlParameter("@PostingType_ID", SqlDbType.Int);
        param[9].Value = objbll.PostingType_ID;
        param[10] = new SqlParameter("@ThreadType_ID", SqlDbType.Int);
        param[10].Value = objbll.ThreadType_ID;
        param[11] = new SqlParameter("@PublishStatus_ID", SqlDbType.Int);
        param[11].Value = objbll.PublishStatus_ID;
        param[12] = new SqlParameter("@GblAccessType_ID", SqlDbType.Int);
        param[12].Value = objbll.GblAccessType_ID;
        param[13] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[13].Value = objbll.Status_Id;



        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsFormTopicInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int LmsFormTopicUpdate(BLLLmsFormTopic objbll)
    {
        SqlParameter[] param = new SqlParameter[16];

        param[0] = new SqlParameter("@Topic_ID", SqlDbType.Int);
        param[0].Value = objbll.Topic_ID;
        param[1] = new SqlParameter("@Forum_ID", SqlDbType.Int);
        param[1].Value = objbll.Forum_ID;
        param[2] = new SqlParameter("@TopicTitle", SqlDbType.NVarChar);
        param[2].Value = objbll.TopicTitle;
        param[3] = new SqlParameter("@ShortDescription", SqlDbType.NVarChar);
        param[3].Value = objbll.ShortDescription;
        param[4] = new SqlParameter("@LongDescription", SqlDbType.NVarChar); 
        param[4].Value = objbll.LongDescription;
        param[5] = new SqlParameter("@isLock", SqlDbType.Bit);
        param[5].Value = objbll.isLock;
        //////////param[5] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        //////////param[5].Value = objbll.CreatedOn;
        //////////param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        //////////param[6].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[6].Value = objbll.ModifiedOn;
        param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[7].Value = objbll.ModifiedBy;
        param[8] = new SqlParameter("@isGradeBook", SqlDbType.Bit); 
        param[8].Value = objbll.isGradeBook;
        param[9] = new SqlParameter("@TotalPoints", SqlDbType.Int); 
        param[9].Value = objbll.TotalPoints;
        param[10] = new SqlParameter("@PostingType_ID", SqlDbType.Int);
        param[10].Value = objbll.PostingType_ID;
        param[11] = new SqlParameter("@ThreadType_ID", SqlDbType.Int); 
        param[11].Value = objbll.ThreadType_ID;
        param[12] = new SqlParameter("@PublishStatus_ID", SqlDbType.Int);
        param[12].Value = objbll.PublishStatus_ID;
        param[13] = new SqlParameter("@GblAccessType_ID", SqlDbType.Int);
        param[13].Value = objbll.GblAccessType_ID;
        param[14] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[14].Value = objbll.Status_Id;


 
        param[15] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[15].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsFormTopicUpdate", param);
        int k = (int)param[15].Value;
        return k;
    }
    public int LmsFormTopicDelete(BLLLmsFormTopic objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Topic_ID", SqlDbType.Int);
        param[0].Value = objbll.Topic_ID;


        int k = dalobj.sqlcmdExecute("LmsFormTopicDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsFormTopicSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsFormTopicSelectById", param);
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
    
    public DataTable LmsFormTopicSelect(BLLLmsFormTopic objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsFormTopicSelectAll", param);
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


    public DataTable LmsFormTopicSlectAllBySectionSubjectIdWrkToolId(BLLLmsFormTopic objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


        param[1] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[1].Value = objbll.WrkTool_Id;

        param[2] = new SqlParameter("@Forum_ID", SqlDbType.Int);
        param[2].Value = objbll.Forum_ID;





        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsFormTopicSlectAllBySectionSubjectIdWrkToolId", param);
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


    public DataTable LmsFormTopicSlectAllByTopicId(BLLLmsFormTopic objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Topic_ID", SqlDbType.Int);
        param[0].Value = objbll.Topic_ID;
        
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsFormTopicSlectAllByTopicId", param);
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





    public DataTable LmsFormTopicSelectByStatusID(BLLLmsFormTopic objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsFormTopicSelectByStatusID");
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


    public DataTable LmsFormTopicSelectAllByTopicId(BLLLmsFormTopic objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Topic_ID", SqlDbType.Int);
        param[0].Value = objbll.Topic_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsFormTopicSelectAllByTopicId", param);
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
