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
/// Summary description for _DALAdmTestQuestionsDetail
/// </summary>
public class DALAdmTestQuestionsDetail
{
    DALBase dalobj = new DALBase();


    public DALAdmTestQuestionsDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmTestQuestionsDetailAdd(BLLAdmTestQuestionsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        //////param[0] = new SqlParameter("@QuestDetail_ID", SqlDbType.Int); 
        //////param[0].Value = objbll.QuestDetail_ID;
        param[0] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[0].Value = objbll.Quest_ID;
        param[1] = new SqlParameter("@Options", SqlDbType.NVarChar); 
        param[1].Value = objbll.Options;
        param[2] = new SqlParameter("@IsCorrect", SqlDbType.Bit); 
        param[2].Value = objbll.IsCorrect;



        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestQuestionsDetailInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int AdmTestQuestionsDetailUpdate(BLLAdmTestQuestionsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@QuestDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.QuestDetail_ID;
        param[1] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[1].Value = objbll.Quest_ID;
        param[2] = new SqlParameter("@Options", SqlDbType.NVarChar);
        param[2].Value = objbll.Options;
        param[3] = new SqlParameter("@IsCorrect", SqlDbType.Bit);
        param[3].Value = objbll.IsCorrect;

 
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestQuestionsDetailUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int AdmTestQuestionsDetailDelete(BLLAdmTestQuestionsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@QuestDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.QuestDetail_ID;
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("AdmTestQuestionsDetailDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable AdmTestQuestionsDetailSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestQuestionsDetailSelectById", param);
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
    
    public DataTable AdmTestQuestionsDetailSelect(BLLAdmTestQuestionsDetail objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestQuestionsDetailSelectAll", param);
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

    public DataTable AdmTestQuestionsDetailSelectAllByQuestId(BLLAdmTestQuestionsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[0].Value = objbll.Quest_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionsDetailSelectAllByQuestId", param);
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


    public DataTable AdmTestQuestionsDetailSelectAllByQuestIdDetailId(BLLAdmTestQuestionsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[0].Value = objbll.Quest_ID;

        param[1] = new SqlParameter("@QuestDetail_ID", SqlDbType.Int);
        param[1].Value = objbll.QuestDetail_ID;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionsDetailSelectAllByQuestIdDetailId", param);
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



    public DataTable AdmTestQuestionsDetailSelectByStatusID(BLLAdmTestQuestionsDetail objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionsDetailSelectByStatusID");
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


    public DataTable AdmTestQuestionsDetailSelectAllByQuestionId(BLLAdmTestQuestionsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[0].Value = objbll.Quest_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionsDetailSelectAllByQuestionId", param);
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


    public DataTable AdmTestQuestionsDetailSelectAllBySkipQuestionId(BLLAdmTestQuestionsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Quest_ID", SqlDbType.Int);
        param[0].Value = objbll.Quest_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestQuestionsDetailSelectAllBySkipQuestionId", param);
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
