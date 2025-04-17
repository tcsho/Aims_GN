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
/// Summary description for _DALLmsPollsQuestionDetail
/// </summary>
public class DALLmsPollsQuestionDetail
{
    DALBase dalobj = new DALBase();


    public DALLmsPollsQuestionDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsPollsQuestionDetailAdd(BLLLmsPollsQuestionDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@LmsPollsQuestionDetail_Id", SqlDbType.Int);
        param[0].Value = objbll.LmsPollsQuestionDetail_Id;
        param[0] = new SqlParameter("@PollDetail_ID", SqlDbType.Int); 
        param[0].Value = objbll.PollDetail_ID;
        param[1] = new SqlParameter("@QuestionDetailOption_Id", SqlDbType.Int); 
        param[1].Value = objbll.QuestionDetailOption_Id;
        param[2] = new SqlParameter("@QuestionDetailOption", SqlDbType.NVarChar); 
        param[2].Value = objbll.QuestionDetailOption;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@Score", SqlDbType.Int);
        param[4].Value = objbll.Score;



        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsQuestionDetailInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int LmsPollsQuestionDetailUpdate(BLLLmsPollsQuestionDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@LmsPollsQuestionDetail_Id", SqlDbType.Int);
        param[0].Value = objbll.LmsPollsQuestionDetail_Id;
        param[0] = new SqlParameter("@PollDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.PollDetail_ID;
        param[1] = new SqlParameter("@QuestionDetailOption_Id", SqlDbType.Int);
        param[1].Value = objbll.QuestionDetailOption_Id;
        param[2] = new SqlParameter("@QuestionDetailOption", SqlDbType.NVarChar);
        param[2].Value = objbll.QuestionDetailOption;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@Score", SqlDbType.Int);
        param[4].Value = objbll.Score;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsQuestionDetailUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsPollsQuestionDetailDelete(BLLLmsPollsQuestionDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsPollsQuestionDetail_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsPollsQuestionDetail_Id;


        int k = dalobj.sqlcmdExecute("LmsPollsQuestionDetailDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsPollsQuestionDetailSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsQuestionDetailSelectById", param);
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
    
    public DataTable LmsPollsQuestionDetailSelect(BLLLmsPollsQuestionDetail objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsQuestionDetailSelectAll", param);
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

    public DataTable LmsPollsQuestionDetailSelectByStatusID(BLLLmsPollsQuestionDetail objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsPollsQuestionDetailSelectByStatusID");
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
