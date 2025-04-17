using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DalAttendance
/// </summary>
public class DalAttendance
{
    DALBase dalobj = new DALBase();

    internal DataTable GetCenterClasses(int centerId)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CenterId", SqlDbType.Int);
        param[0].Value = centerId;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCenterClasses", param);
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
    }
}