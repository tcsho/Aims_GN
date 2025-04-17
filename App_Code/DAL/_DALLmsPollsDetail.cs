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
/// Summary description for _DALLmsPollsDetail
/// </summary>
public class DALLmsPollsDetail
{
    DALBase dalobj = new DALBase();


    public DALLmsPollsDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsPollsDetailAdd(BLLLmsPollsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        //////param[0] = new SqlParameter("@PollDetail_ID", SqlDbType.Int);
        //////param[0].Value = objbll.PollDetail_ID;
        param[0] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        param[0].Value = objbll.Poll_ID;
        param[1] = new SqlParameter("@QstDetails", SqlDbType.NVarChar);
        param[1].Value = objbll.QstDetails;



        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsDetailInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int LmsPollsDetailUpdate(BLLLmsPollsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@PollDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.PollDetail_ID;
        param[1] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        param[1].Value = objbll.Poll_ID;
        param[2] = new SqlParameter("@QstDetails", SqlDbType.NVarChar);
        param[2].Value = objbll.QstDetails;

 
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsDetailUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int LmsPollsDetailDelete(BLLLmsPollsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsPollsDetail_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsPollsDetail_Id;


        int k = dalobj.sqlcmdExecute("LmsPollsDetailDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsPollsDetailSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsDetailSelectById", param);
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
    
    public DataTable LmsPollsDetailSelect(BLLLmsPollsDetail objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsDetailSelectAll", param);
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



    public DataTable LmsPollsDetailSelectAllByPollId(BLLLmsPollsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        param[0].Value = objbll.Poll_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsPollsDetailSelectAllByPollId", param);
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


    public DataTable LmsPollsDetailSelectAllByPollDetailID(BLLLmsPollsDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@PollDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.PollDetail_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsPollsDetailSelectAllByPollDetailID", param);
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





    public DataTable LmsPollsDetailSelectByStatusID(BLLLmsPollsDetail objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsPollsDetailSelectByStatusID");
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
