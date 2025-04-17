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
/// Summary description for _DALLmsSurveySubmissions
/// </summary>
public class DALLmsSurveySubmissions
{
    DALBase dalobj = new DALBase();


    public DALLmsSurveySubmissions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsSurveySubmissionsAdd(BLLLmsSurveySubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[7];
        //////param[0] = new SqlParameter("@PollSubmission_ID", SqlDbType.Int); 
        //////param[0].Value = objbll.PollSubmission_ID;
        param[0] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[0].Value = objbll.Survey_ID;
        param[1] = new SqlParameter("@SurveyDetail_ID", SqlDbType.Int);
        param[1].Value = objbll.SurveyDetail_ID;
        param[2] = new SqlParameter("@Participant_ID", SqlDbType.Int); 
        param[2].Value = objbll.Participant_ID;
        param[3] = new SqlParameter("@QuestionDetailOption_Id", SqlDbType.Int);
        param[3].Value = objbll.QuestionDetailOption_Id;
        param[4] = new SqlParameter("@QuestionDetailOption", SqlDbType.NVarChar);
        param[4].Value = objbll.QuestionDetailOption;
        param[5] = new SqlParameter("@LmsSurveySubmissionsUser_ID", SqlDbType.NVarChar);
        param[5].Value = objbll.LmsSurveySubmissionsUser_ID;


        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSurveySubmissionsInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int LmsSurveySubmissionsUpdate(BLLLmsSurveySubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[0] = new SqlParameter("@SurveySubmission_ID", SqlDbType.Int);
        param[0].Value = objbll.SurveySubmission_ID;
        param[0] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[0].Value = objbll.Survey_ID;
        param[1] = new SqlParameter("@SurveyDetail_ID", SqlDbType.Int);
        param[1].Value = objbll.SurveyDetail_ID;
        param[2] = new SqlParameter("@Participant_ID", SqlDbType.Int);
        param[2].Value = objbll.Participant_ID;

        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSurveySubmissionsUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsSurveySubmissionsDelete(BLLLmsSurveySubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[0].Value = objbll.Survey_ID;

        param[1] = new SqlParameter("@Participant_ID", SqlDbType.Int);
        param[1].Value = objbll.Participant_ID;




        int k = dalobj.sqlcmdExecute("LmsSurveySubmissionsDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsSurveySubmissionsSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSurveySubmissionsSelectById", param);
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


    public DataTable LmsSurveySubmissionselectAllbySurveyId(BLLLmsSurveySubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[0].Value = objbll.Survey_ID;

        param[1] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[1].Value = objbll.User_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveySubmissionselectAllbySurveyId", param);
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


    public DataTable LmsSurveySubmissionsSelect(BLLLmsSurveySubmissions objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSurveySubmissionsSelectAll", param);
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

    public DataTable LmsSurveySubmissionsSelectByStatusID(BLLLmsSurveySubmissions objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveySubmissionsSelectByStatusID");
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
