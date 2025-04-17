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
/// Summary description for _DALLmsPollsSubmissions
/// </summary>
public class DALLmsPollsSubmissions
{
    DALBase dalobj = new DALBase();


    public DALLmsPollsSubmissions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsPollsSubmissionsAdd(BLLLmsPollsSubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[7];
        //////param[0] = new SqlParameter("@PollSubmission_ID", SqlDbType.Int); 
        //////param[0].Value = objbll.PollSubmission_ID;
        param[0] = new SqlParameter("@Poll_ID", SqlDbType.Int); 
        param[0].Value = objbll.Poll_ID;
        param[1] = new SqlParameter("@PollDetail_ID", SqlDbType.Int); 
        param[1].Value = objbll.PollDetail_ID;
        param[2] = new SqlParameter("@Participant_ID", SqlDbType.Int); 
        param[2].Value = objbll.Participant_ID;
        param[3] = new SqlParameter("@QuestionDetailOption_Id", SqlDbType.Int);
        param[3].Value = objbll.QuestionDetailOption_Id;
        param[4] = new SqlParameter("@QuestionDetailOption", SqlDbType.NVarChar);
        param[4].Value = objbll.QuestionDetailOption;
        param[5] = new SqlParameter("@LmsPollsSubmissionsUser_ID", SqlDbType.NVarChar);
        param[5].Value = objbll.LmsPollsSubmissionsUser_ID;


        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsSubmissionsInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int LmsPollsSubmissionsUpdate(BLLLmsPollsSubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[0] = new SqlParameter("@PollSubmission_ID", SqlDbType.Int);
        param[0].Value = objbll.PollSubmission_ID;
        param[0] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        param[0].Value = objbll.Poll_ID;
        param[1] = new SqlParameter("@PollDetail_ID", SqlDbType.Int);
        param[1].Value = objbll.PollDetail_ID;
        param[2] = new SqlParameter("@Participant_ID", SqlDbType.Int);
        param[2].Value = objbll.Participant_ID;

        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsSubmissionsUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsPollsSubmissionsDelete(BLLLmsPollsSubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        param[0].Value = objbll.Poll_ID;

        param[1] = new SqlParameter("@Participant_ID", SqlDbType.Int);
        param[1].Value = objbll.Participant_ID;




        int k = dalobj.sqlcmdExecute("LmsPollsSubmissionsDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsPollsSubmissionsSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsSubmissionsSelectById", param);
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


    public DataTable LmsPollsSubmissionSelectAllbyPollId(BLLLmsPollsSubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        param[0].Value = objbll.Poll_ID;

        param[1] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[1].Value = objbll.User_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsPollsSubmissionSelectAllbyPollId", param);
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


    public DataTable LmsPollsSubmissionsSelect(BLLLmsPollsSubmissions objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsSubmissionsSelectAll", param);
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

    public DataTable LmsPollsSubmissionsSelectByStatusID(BLLLmsPollsSubmissions objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsPollsSubmissionsSelectByStatusID");
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
