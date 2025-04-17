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
/// Summary description for _DALLmsSurveySubmissionsUser
/// </summary>
public class DALLmsSurveySubmissionsUser
{
    DALBase dalobj = new DALBase();


    public DALLmsSurveySubmissionsUser()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsSurveySubmissionsUserAdd(BLLLmsSurveySubmissionsUser objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        ////////param[0] = new SqlParameter("@LmsSurveySubmissionsUser_ID", SqlDbType.Int);
        ////////param[0].Value = objbll.LmsSurveySubmissionsUser_ID;
        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;
        param[1] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[1].Value = objbll.Survey_ID;



        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSurveySubmissionsUserInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int LmsSurveySubmissionsUserUpdate(BLLLmsSurveySubmissionsUser objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@LmsSurveySubmissionsUser_ID", SqlDbType.Int);
        param[0].Value = objbll.LmsSurveySubmissionsUser_ID;
        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;
        param[1] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[1].Value = objbll.Survey_ID;

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSurveySubmissionsUserUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsSurveySubmissionsUserDelete(BLLLmsSurveySubmissionsUser objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsSurveySubmissionsUser_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsSurveySubmissionsUser_Id;


        int k = dalobj.sqlcmdExecute("LmsSurveySubmissionsUserDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsSurveySubmissionsUserSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSurveySubmissionsUserSelectById", param);
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


    public DataTable LmsSurveySubmissionsUserSelectSurveyIdUserId(BLLLmsSurveySubmissionsUser objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;

        param[1] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[1].Value = objbll.Survey_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveySubmissionsUserSelectSurveyIdUserId", param);
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


    public DataTable LmsSurveySubmissionsUserSelect(BLLLmsSurveySubmissionsUser objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSurveySubmissionsUserSelectAll", param);
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

    public DataTable LmsSurveySubmissionsUserSelectByStatusID(BLLLmsSurveySubmissionsUser objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveySubmissionsUserSelectByStatusID");
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
