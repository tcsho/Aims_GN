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
/// Summary description for _DALLmsPollsQuestionDetailOption
/// </summary>
public class DALLmsPollsQuestionDetailOption
{
    DALBase dalobj = new DALBase();


    public DALLmsPollsQuestionDetailOption()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsPollsQuestionDetailOptionAdd(BLLLmsPollsQuestionDetailOption objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@QuestionDetailOption_Id", SqlDbType.Int); 
        param[0].Value = objbll.QuestionDetailOption_Id;
        param[0] = new SqlParameter("@QuestionDetailOption", SqlDbType.NVarChar); 
        param[0].Value = objbll.QuestionDetailOption;
        param[1] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[1].Value = objbll.Status_Id;
        param[2] = new SqlParameter("@Score", SqlDbType.Int); 
        param[2].Value = objbll.Score;


        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsQuestionDetailOptionInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int LmsPollsQuestionDetailOptionUpdate(BLLLmsPollsQuestionDetailOption objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@QuestionDetailOption_Id", SqlDbType.Int);
        param[0].Value = objbll.QuestionDetailOption_Id;
        param[0] = new SqlParameter("@QuestionDetailOption", SqlDbType.NVarChar);
        param[0].Value = objbll.QuestionDetailOption;
        param[1] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[1].Value = objbll.Status_Id;
        param[2] = new SqlParameter("@Score", SqlDbType.Int);
        param[2].Value = objbll.Score;

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsQuestionDetailOptionUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsPollsQuestionDetailOptionDelete(BLLLmsPollsQuestionDetailOption objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsPollsQuestionDetailOption_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsPollsQuestionDetailOption_Id;


        int k = dalobj.sqlcmdExecute("LmsPollsQuestionDetailOptionDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsPollsQuestionDetailOptionSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsQuestionDetailOptionSelectById", param);
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
    
    public DataTable LmsPollsQuestionDetailOptionSelect(BLLLmsPollsQuestionDetailOption objbll)
    {
  //  SqlParameter[] param = new SqlParameter[3];

  //  param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  ////  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsQuestionDetailOptionSelectAll");
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

    public DataTable LmsPollsQuestionDetailOptionSelectByStatusID(BLLLmsPollsQuestionDetailOption objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsPollsQuestionDetailOptionSelectByStatusID");
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
