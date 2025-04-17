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
/// Summary description for _DALLmsSurvey
/// </summary>
public class DALLmsSurvey
{
    DALBase dalobj = new DALBase();


    public DALLmsSurvey()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsSurveyAdd(BLLLmsSurvey objbll)
    {
        SqlParameter[] param = new SqlParameter[12];

        //param[0] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        //param[0].Value = objbll.Poll_ID;
        param[0] = new SqlParameter("@QstText", SqlDbType.NVarChar);
        param[0].Value = objbll.QstText;
        param[1] = new SqlParameter("@AddInstructions", SqlDbType.NVarChar);
        param[1].Value = objbll.AddInstructions;
        param[2] = new SqlParameter("@OpningDate", SqlDbType.DateTime);
        param[2].Value = objbll.OpningDate;
        param[3] = new SqlParameter("@ClosingDate", SqlDbType.DateTime);
        param[3].Value = objbll.ClosingDate;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[5].Value = objbll.CreatedBy;
        //////param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        //////param[6].Value = objbll.ModifiedOn;
        //////param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        //////param[7].Value = objbll.ModifiedBy;
        param[6] = new SqlParameter("@WrkTool_ID", SqlDbType.Int); 
        param[6].Value = objbll.WrkTool_ID;
        param[7] = new SqlParameter("@PublishStatus_ID", SqlDbType.Int);
        param[7].Value = objbll.PublishStatus_ID;
        param[8] = new SqlParameter("@GblAccessType_ID", SqlDbType.Int); 
        param[8].Value = objbll.GblAccessType_ID;
        ////////param[11] = new SqlParameter("@Participant_ID", SqlDbType.Int);
        ////////param[11].Value = objbll.Participant_ID;
        param[9] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[9].Value = objbll.Section_Subject_Id;
        param[10] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[10].Value = objbll.Status_Id;


        param[11] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[11].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSurveyInsert", param);
        int k = (int)param[11].Value;
        return k;

    }
    public int LmsSurveyUpdate(BLLLmsSurvey objbll)
    {
        SqlParameter[] param = new SqlParameter[13];

        param[0] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[0].Value = objbll.Survey_ID;
        param[1] = new SqlParameter("@QstText", SqlDbType.NVarChar);
        param[1].Value = objbll.QstText;
        param[2] = new SqlParameter("@AddInstructions", SqlDbType.NVarChar);
        param[2].Value = objbll.AddInstructions;
        param[3] = new SqlParameter("@OpningDate", SqlDbType.DateTime);
        param[3].Value = objbll.OpningDate;
        param[4] = new SqlParameter("@ClosingDate", SqlDbType.DateTime);
        param[4].Value = objbll.ClosingDate;
        //param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        //param[4].Value = objbll.CreatedOn;
        //param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        //param[5].Value = objbll.CreatedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[5].Value = objbll.ModifiedOn;
        param[6] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[6].Value = objbll.ModifiedBy;
        param[7] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[7].Value = objbll.WrkTool_ID;
        param[8] = new SqlParameter("@PublishStatus_ID", SqlDbType.Int);
        param[8].Value = objbll.PublishStatus_ID;
        param[9] = new SqlParameter("@GblAccessType_ID", SqlDbType.Int);
        param[9].Value = objbll.GblAccessType_ID;
        //param[9] = new SqlParameter("@Participant_ID", SqlDbType.Int);
        //param[9].Value = objbll.Participant_ID;
        param[10] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[10].Value = objbll.Section_Subject_Id;
        param[11] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[11].Value = objbll.Status_Id;


 
        param[12] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[12].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSurveyUpdate", param);
        int k = (int)param[12].Value;
        return k;
    }
    public int LmsSurveyDelete(BLLLmsSurvey objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[0].Value = objbll.Survey_ID;


        int k = dalobj.sqlcmdExecute("LmsSurveyDelete", param);

        return k;        
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsSurveySelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSurveySelectById", param);
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
    
    public DataTable LmsSurveySelect(BLLLmsSurvey objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSurveySelectAll", param);
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

    public DataTable LmsSurveySelectByStatusID(BLLLmsSurvey objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveySelectByStatusID");
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

    public DataTable LmsSurveySelectAllBySectionSubjectIdWrkToolId(BLLLmsSurvey objbll)
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
            _dt = dalobj.sqlcmdFetch("LmsSurveySelectAllBySectionSubjectIdWrkToolId", param);
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


    public DataTable LmsSurveySelectAllBySurveyId(BLLLmsSurvey objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[0].Value = objbll.Survey_ID;

        
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveySelectAllBySurveyId", param);
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


    public DataTable LmsSurveySelectAllForSubmission(BLLLmsSurvey objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveySelectAllForSubmission", param);
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
