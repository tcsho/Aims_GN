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
/// Summary description for _DALAdmTest
/// </summary>
public class DALAdmTest
{
    DALBase dalobj = new DALBase();


    public DALAdmTest()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int AdmTestAdd(BLLAdmTest objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[0].Value = objbll.CreatedBy;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[2].Value = objbll.Class_Id;
        param[3] = new SqlParameter("@AdmTestType_Id", SqlDbType.Int);
        param[3].Value = objbll.AdmTestType_Id;
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestInsert", param);
        int k = (int)param[4].Value;
        return k;

    }
    public int AdmTestUpdate(BLLAdmTest objbll, BLLAdmTestDetail obj)
    {
        SqlParameter[] param = new SqlParameter[7];


        param[0] = new SqlParameter("@AdmTest_Id", SqlDbType.Int);
        param[0].Value = objbll.AdmTest_Id;
        param[1] = new SqlParameter("@Title", SqlDbType.NVarChar);
        param[1].Value = objbll.Title;
        param[2] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[2].Value = objbll.ModifiedBy;
        
        param[3] = new SqlParameter("@TestDesc", SqlDbType.NVarChar);
        param[3].Value = obj.TestDesc;
        param[4] = new SqlParameter("@AdmTestDetail_Id", SqlDbType.Int);
        param[4].Value = obj.AdmTestDetail_Id;
        param[5] = new SqlParameter("@TotalMarks", SqlDbType.Decimal);
        param[5].Value = obj.TotalMarks;
      
  
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestUpdate", param);
        int k = (int)param[6].Value;
        return k;
    }
    public int AdmTestDelete(BLLAdmTest objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@AdmTestType_Id", SqlDbType.Int);
        param[2].Value = objbll.AdmTestType_Id;
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("AdmTestDelete", param);
        int k = (int)param[3].Value;
        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable AdmTestSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestSelectById", param);
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

    public DataTable AdmTestSelect(BLLAdmTest objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_Id;

        param[2] = new SqlParameter("@AdmTestType_Id", SqlDbType.Int);
        param[2].Value = objbll.AdmTestType_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestSelectAll",param);
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

    public DataTable AdmTestSelectByStatusID(BLLAdmTest objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestSelectByStatusID");
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


    public DataTable AdmTestSelectTestType(BLLAdmTest objbll)
    {
        DataTable _dt = new DataTable();
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AdmTestTypeSelectAll",param);
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
