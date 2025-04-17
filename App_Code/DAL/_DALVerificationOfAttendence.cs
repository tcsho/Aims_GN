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
/// Summary description for __DALVerificationOfAttendence
/// </summary>
public class _DALVerificationOfAttendence
{
    DALBase dalobj = new DALBase();


    public _DALVerificationOfAttendence()
    {
       
    }
    #region 'Start of Execution Methods'
    public DataTable VerificationOfAttendence_Get(BLLVerificationOfAttendence objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[0].Value = objbll.Class_Id;

        param[1] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[1].Value = objbll.Evaluation_Criteria_Type_Id;

        param[2] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[2].Value = objbll.Region_Id;
        param[3] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[3].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("sp_StudentAttendance_TermDays_EOY", param);
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
