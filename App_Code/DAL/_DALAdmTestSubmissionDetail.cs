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
/// Summary description for _DALAdmTestSubmissionDetail
/// </summary>
public class DALAdmTestSubmissionDetail
{
    DALBase dalobj = new DALBase();


    public DALAdmTestSubmissionDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmTestSubmissionAdd(BLLAdmTestSubmissionDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        ////param[0] = new SqlParameter("@Answer_ID", SqlDbType.Int); 
        ////param[0].Value = objbll.Answer_ID;
        param[0] = new SqlParameter("@isCorrect", SqlDbType.Bit);
        param[0].Value = objbll.isCorrect;
        param[1] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[1].Value = objbll.Quest_ID;
        param[2] = new SqlParameter("@TeacherComments", SqlDbType.NVarChar);
        param[2].Value = objbll.TeacherComments;
        param[3] = new SqlParameter("@AdmTestSubm_ID", SqlDbType.Int);
        param[3].Value = objbll.AdmTestSubm_ID;
        param[4] = new SqlParameter("@QuestDetail_ID", SqlDbType.Int);
        param[4].Value = objbll.QuestDetail_ID;



        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestSubmissionDetailInsert", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int AdmTestSubmissionDetailUpdate(BLLAdmTestSubmissionDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[6];


        param[0] = new SqlParameter("@AdmTestSubmDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.AdmTestSubmDetail_ID;
        param[1] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[1].Value = objbll.Quest_ID;
        param[2] = new SqlParameter("@QuestDetail_ID", SqlDbType.Int);
        param[2].Value = objbll.QuestDetail_ID;
        if (objbll.QuestDetail_ID == null)
        {
            param[2].Value = DBNull.Value;
        }

        param[3] = new SqlParameter("@AnswerInSeconds", SqlDbType.Int);
        param[3].Value = objbll.AnswerInSeconds;
        
        param[4] = new SqlParameter("@IsNotAnswered", SqlDbType.Bit);
        param[4].Value = objbll.IsNotAnswered;
         
        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestSubmissionDetailUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }


    public int AdmTestSubmissionDetailUpdateTimeOnly(BLLAdmTestSubmissionDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[3];


        param[0] = new SqlParameter("@AdmTestSubmDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.AdmTestSubmDetail_ID;

        param[1] = new SqlParameter("@AnswerInSeconds", SqlDbType.Int);
        param[1].Value = objbll.AnswerInSeconds;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestSubmissionDetailUpdateTimeOnly", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int AdmTestAnswersDelete(BLLAdmTestSubmissionDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmTestAnswers_Id", SqlDbType.Int);
     //   param[0].Value = objbll.AdmTestAnswers_Id;


        int k = dalobj.sqlcmdExecute("AdmTestAnswersDelete", param);

        return k;
    }


    public DataTable AdmTestSubmissionDetailSelectAllQuestionsByUserId(BLLAdmTestSubmissionDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestSubmissionDetailSelectAllQuestionsByUserId", param);
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


    public DataTable AdmTestSubmissionDetailSelectAllQuestionsByUserIdOneByOne(BLLAdmTestSubmissionDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestSubmissionDetailSelectAllQuestionsByUserIdOneByOne", param);
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

    #region 'Start of Fetch Methods'
    public DataTable AdmTestAnswersSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestAnswersSelectById", param);
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
    
    public DataTable AdmTestAnswersSelect(BLLAdmTestSubmissionDetail objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestAnswersSelectAll", param);
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

    public DataTable AdmTestAnswersSelectByStatusID(BLLAdmTestSubmissionDetail objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestAnswersSelectByStatusID");
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
