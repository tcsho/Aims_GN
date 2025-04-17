using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for _DALStudent_Verification_Status
/// </summary>
public class DALStudent_Verification_Status
{
    DALBase dalobj = new DALBase();
    public DALStudent_Verification_Status()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable CenterWiseUnReconciledStudents(BLLStudentVerificationStatus objbll)
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
            _dt = dalobj.sqlcmdFetch("CenterWiseUnReconciledStudents", param);
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

    public DataTable CenterWiseUnidentifiedStudents(BLLStudentVerificationStatus objbll)
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
            _dt = dalobj.sqlcmdFetch("CenterWiseUnidentifiedStudents", param);
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

    public DataTable AddStudentVerificationRemarks(BLLStudentVerificationStatus objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Id", SqlDbType.Int);
        param[0].Value = objbll.Id;
        param[1] = new SqlParameter("@StudentId", SqlDbType.Int);
        param[1].Value = objbll.StudentId;
        param[2] = new SqlParameter("@Student_Verification_Id", SqlDbType.Int);
        param[2].Value = objbll.Student_Verification_Id; 
        param[3] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
        param[3].Value = objbll.Remarks;
        param[4] = new SqlParameter("@Description", SqlDbType.NVarChar);
        param[4].Value = objbll.Description;
        param[5] = new SqlParameter("@ChangeMadeERP", SqlDbType.NVarChar);
        param[5].Value = objbll.ChangeMadeERP; 
        param[6] = new SqlParameter("@ModifiedBy", SqlDbType.NVarChar);
        param[6].Value = objbll.ModifiedBy;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Verification_Remarks_Update", param);
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