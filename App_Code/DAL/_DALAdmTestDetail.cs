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
/// Summary description for _DALAdmTestDetail
/// </summary>
public class DALAdmTestDetail
{
    DALBase dalobj = new DALBase();


    public DALAdmTestDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmTestDetailAdd(BLLAdmTestDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[15];


        param[0] = new SqlParameter("@AdmTestDetail_Id", SqlDbType.Int);
        param[0].Value = objbll.AdmTestDetail_Id;
        param[0] = new SqlParameter("@AsmntPartName", SqlDbType.NVarChar);
        param[0].Value = objbll.AsmntPartName;
        param[1] = new SqlParameter("@AdmTest_Id", SqlDbType.Int);
        param[1].Value = objbll.AdmTest_Id;
        param[2] = new SqlParameter("@Sequence_ID", SqlDbType.Int);
        param[2].Value = objbll.Sequence_ID;
        param[3] = new SqlParameter("@AsmntPartDesc", SqlDbType.NVarChar);
        param[3].Value = objbll.AsmntPartDesc;
        param[4] = new SqlParameter("@Status_ID", SqlDbType.Int);
        param[4].Value = objbll.Status_ID;




        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestDetailInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int AdmTestDetailUpdate(BLLAdmTestDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[0] = new SqlParameter("@AdmTestDetail_Id", SqlDbType.Int);
        param[0].Value = objbll.AdmTestDetail_Id;
        param[0] = new SqlParameter("@AsmntPartName", SqlDbType.NVarChar);
        param[0].Value = objbll.AsmntPartName;
        param[1] = new SqlParameter("@AdmTest_Id", SqlDbType.Int);
        param[1].Value = objbll.AdmTest_Id;
        param[2] = new SqlParameter("@Sequence_ID", SqlDbType.Int);
        param[2].Value = objbll.Sequence_ID;
        param[3] = new SqlParameter("@AsmntPartDesc", SqlDbType.NVarChar);
        param[3].Value = objbll.AsmntPartDesc;
        param[4] = new SqlParameter("@Status_ID", SqlDbType.Int);
        param[4].Value = objbll.Status_ID;




        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestDetailUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int AdmTestDetailDelete(BLLAdmTestDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmTestDetail_Id", SqlDbType.Int);
        param[0].Value = objbll.AdmTestDetail_Id;


        int k = dalobj.sqlcmdExecute("AdmTestDetailDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable AdmTestDetailSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestDetailSelectById", param);
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

    public DataTable AdmTestDetailSelect(BLLAdmTestDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestDetailSelectAll", param);
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



    public DataTable AdmTestDetailSelectAllByAdmTest_Id(BLLAdmTestDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@AdmTest_Id", SqlDbType.Int);
        param[0].Value = objbll.AdmTest_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestDetailSelectAllByAdmTest_Id", param);
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



    public DataTable AdmTestDetailSelectByStatusID(BLLAdmTestDetail objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestDetailSelectByStatusID");
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
