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
/// Summary description for _DALAdmTestSubmissions
/// </summary>
public class DALAdmTestSubmissions
{
    DALBase dalobj = new DALBase();


    public DALAdmTestSubmissions()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmTestSubmissionsAdd(BLLAdmTestSubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        //param[0] = new SqlParameter("@AdmTestSubm_ID", SqlDbType.Int); 
        //param[0].Value = objbll.AdmTestSubm_ID;
        param[0] = new SqlParameter("@User_ID", SqlDbType.Int); 
        param[0].Value = objbll.User_ID;
        param[1] = new SqlParameter("@SubmDateTime", SqlDbType.DateTime); 
        param[1].Value = objbll.SubmDateTime;
        param[2] = new SqlParameter("@Comments", SqlDbType.NVarChar); 
        param[2].Value = objbll.Comments;
        param[3] = new SqlParameter("@TotalScores", SqlDbType.Decimal);
        param[3].Value = objbll.TotalScores;
        param[4] = new SqlParameter("@AdmTest_Id", SqlDbType.Int);
        param[4].Value = objbll.AdmTest_Id;



        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestSubmissionsInsert", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int AdmTestSubmissionsUpdate(BLLAdmTestSubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@AdmTestSubm_ID", SqlDbType.Int);
        param[0].Value = objbll.AdmTestSubm_ID;
        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;
        param[1] = new SqlParameter("@SubmDateTime", SqlDbType.DateTime);
        param[1].Value = objbll.SubmDateTime;
        param[2] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[2].Value = objbll.Comments;
        param[3] = new SqlParameter("@TotalScores", SqlDbType.Decimal);
        param[3].Value = objbll.TotalScores;
        param[4] = new SqlParameter("@AsmntItem_ID", SqlDbType.Int);
        param[4].Value = objbll.AdmTest_Id;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestSubmissionsUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int AdmTestSubmissionsDelete(BLLAdmTestSubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmTestSubmissions_Id", SqlDbType.Int);
     //   param[0].Value = objbll.AdmTestSubmissions_Id;


        int k = dalobj.sqlcmdExecute("AdmTestSubmissionsDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable AdmTestSubmissionsSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestSubmissionsSelectById", param);
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


    public int AdmTestSubmissionsSelectAdminTestByUserId(BLLAdmTestSubmissions objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = objbll.User_ID;
        param[1] = new SqlParameter("@Group_Type", SqlDbType.Bit);
        param[1].Value = objbll.Group_Type != null ? objbll.Group_Type :Convert.DBNull;
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.sqlcmdExecute("AdmTestSubmissionsSelectAdminTestByUserId", param);
            int k = (int)param[2].Value;
            return k;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }



    }



    public DataTable AdmTestSubmissionsSelectInfromationByUserId(BLLAdmTestSubmissions objbll)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
    param[0].Value = objbll.User_ID;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestSubmissionsSelectInformatioByUser_Id", param);
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


    public DataTable AdmTestSubmissionsSelectResultByUserId(BLLAdmTestSubmissions objbll)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
    param[0].Value = objbll.User_ID;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestSubmissionsSelectResultByUserID", param);
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

    
    
    public DataTable AdmTestSubmissionsSelect(BLLAdmTestSubmissions objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("AdmTestSubmissionsSelectAll", param);
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

    public DataTable AdmTestSubmissionsSelectByStatusID(BLLAdmTestSubmissions objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestSubmissionsSelectByStatusID");
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
