using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for _DALNonCompliantTeacher
/// </summary>
public class DALNonCompliantTeacher
{
    DALBase dalobj = new DALBase();
    public DALNonCompliantTeacher()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable CenterWiseNonCompliantTeachers(BLLNonCompliantTeacher objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@CenterId", SqlDbType.Int);
        param[0].Value = objbll.CenterId;
        param[1] = new SqlParameter("@RegionId", SqlDbType.Int);
        if (objbll.RegionId == 0)
            param[1].Value = DBNull.Value;
        else
            param[1].Value = objbll.RegionId;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CenterWiseNonCompliantTeachers", param);
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

    public DataTable AddStudentVerificationRemarks(BLLNonCompliantTeacher objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Id", SqlDbType.Int);
        param[0].Value = objbll.Id;
        param[1] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
        param[1].Value = objbll.Remarks;
        param[2] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[2].Value = objbll.Description;
        param[3] = new SqlParameter("@ChangeMadeERP", SqlDbType.NVarChar);
        param[3].Value = objbll.ChangeMadeERP; 
        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.NVarChar);
        param[4].Value = objbll.ModifiedBy;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Non_Compliant_Teacher_Remarks_Update", param);
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