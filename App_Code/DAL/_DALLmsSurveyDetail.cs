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
/// Summary description for _DALLmsSurveyDetail
/// </summary>
public class DALLmsSurveyDetail
{
    DALBase dalobj = new DALBase();


    public DALLmsSurveyDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsSurveyDetailAdd(BLLLmsSurveyDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        //////param[0] = new SqlParameter("@PollDetail_ID", SqlDbType.Int);
        //////param[0].Value = objbll.PollDetail_ID;
        param[0] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[0].Value = objbll.Survey_ID;
        param[1] = new SqlParameter("@QstDetails", SqlDbType.NVarChar);
        param[1].Value = objbll.QstDetails;



        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSurveyDetailInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int LmsSurveyDetailUpdate(BLLLmsSurveyDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@SurveyDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.SurveyDetail_ID;
        param[1] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[1].Value = objbll.Survey_ID;
        param[2] = new SqlParameter("@QstDetails", SqlDbType.NVarChar);
        param[2].Value = objbll.QstDetails;

 
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSurveyDetailUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int LmsSurveyDetailDelete(BLLLmsSurveyDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsSurveyDetail_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsSurveyDetail_Id;


        int k = dalobj.sqlcmdExecute("LmsSurveyDetailDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsSurveyDetailSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSurveyDetailSelectById", param);
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
    
    public DataTable LmsSurveyDetailSelect(BLLLmsSurveyDetail objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSurveyDetailSelectAll", param);
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



    public DataTable LmsSurveyDetailSelectAllBySurveyId(BLLLmsSurveyDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Survey_ID", SqlDbType.Int);
        param[0].Value = objbll.Survey_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveyDetailSelectAllBySurveyId", param);
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


    public DataTable LmsSurveyDetailSelectAllBySurveyDetailID(BLLLmsSurveyDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@SurveyDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.SurveyDetail_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveyDetailSelectAllBySurveyDetailID", param);
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





    public DataTable LmsSurveyDetailSelectByStatusID(BLLLmsSurveyDetail objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSurveyDetailSelectByStatusID");
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
