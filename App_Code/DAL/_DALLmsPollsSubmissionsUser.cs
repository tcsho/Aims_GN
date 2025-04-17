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
/// Summary description for _DALLmsPollsSubmissionsUser
/// </summary>
public class DALLmsPollsSubmissionsUser
{
    DALBase dalobj = new DALBase();


    public DALLmsPollsSubmissionsUser()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsPollsSubmissionsUserAdd(BLLLmsPollsSubmissionsUser objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        ////////param[0] = new SqlParameter("@LmsPollsSubmissionsUser_ID", SqlDbType.Int);
        ////////param[0].Value = objbll.LmsPollsSubmissionsUser_ID;
        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;
        param[1] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        param[1].Value = objbll.Poll_ID;



        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsSubmissionsUserInsert", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int LmsPollsSubmissionsUserUpdate(BLLLmsPollsSubmissionsUser objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@LmsPollsSubmissionsUser_ID", SqlDbType.Int);
        param[0].Value = objbll.LmsPollsSubmissionsUser_ID;
        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;
        param[1] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        param[1].Value = objbll.Poll_ID;

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsPollsSubmissionsUserUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsPollsSubmissionsUserDelete(BLLLmsPollsSubmissionsUser objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsPollsSubmissionsUser_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsPollsSubmissionsUser_Id;


        int k = dalobj.sqlcmdExecute("LmsPollsSubmissionsUserDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsPollsSubmissionsUserSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsSubmissionsUserSelectById", param);
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


    public DataTable LmsPollsSubmissionsUserSelectPollIdUserId(BLLLmsPollsSubmissionsUser objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;

        param[1] = new SqlParameter("@Poll_ID", SqlDbType.Int);
        param[1].Value = objbll.Poll_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsPollsSubmissionsUserSelectPollIdUserId", param);
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


    public DataTable LmsPollsSubmissionsUserSelect(BLLLmsPollsSubmissionsUser objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsPollsSubmissionsUserSelectAll", param);
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

    public DataTable LmsPollsSubmissionsUserSelectByStatusID(BLLLmsPollsSubmissionsUser objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsPollsSubmissionsUserSelectByStatusID");
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
