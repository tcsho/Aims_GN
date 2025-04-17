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
/// Summary description for _DALLmsMsgPriorityType
/// </summary>
public class _DALStudentSMSListofAll
{
    DALBase dalobj = new DALBase();
	public _DALStudentSMSListofAll()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable StudentSMSListofAll(BLLStudentSMSListofAll obj)
    {
        SqlParameter[] param = new SqlParameter[5];
        param[0] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[0].Value = obj.TermGroup_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = obj.Session_Id;
        param[2] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[2].Value = obj.Region_Id;
        param[3] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[3].Value = obj.Center_Id;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[4].Value = obj.Class_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetStudentSMSListofAll", param);
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
}
