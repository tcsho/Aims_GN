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
/// Summary description for _DALSeatPlanTeacherExamAllocation
/// </summary>
public class _DALSeatPlanTeacherExamAllocation
{
    DALBase dalobj = new DALBase();
    public _DALSeatPlanTeacherExamAllocation()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public DataTable TeacherExamAllocationActiveSchools(BLLSeatPlanTeacherExamAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[0];

        //param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);

        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TeacherExamAllocationActiveSchools");
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


    public DataTable TeacherExamAllocationActiveTeachers(BLLSeatPlanTeacherExamAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TeacherExamAllocationActiveTeachers", param);
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


    public DataTable StudentsCountBaseOnSubject(BLLSeatPlanTeacherExamAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;



        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentsCountBaseOnSubject", param);
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

    public DataTable GetRooms(BLLSeatPlanTeacherExamAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermId;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;

        param[4] = new SqlParameter("@SubjectId", SqlDbType.Int);
        param[4].Value = objbll.SubjectId;

        param[5] = new SqlParameter("@Gender_Id", SqlDbType.Int);
        param[5].Value = objbll.Gender_Id;

        param[6] = new SqlParameter("@Block_Id", SqlDbType.Int);
        param[6].Value = objbll.Block_Id;

        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetRooms", param);
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


    public int TeacherExamAllocationAssignedRoomToTeacherDetail(BLLSeatPlanTeacherExamAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@RoomAllot_Id", SqlDbType.Int);
        param[0].Value = objbll.RoomAllot_Id;

        param[1] = new SqlParameter("@AllocationMasterId", SqlDbType.Int);
        param[1].Value = 900;

        param[2] = new SqlParameter("@Result", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("TeacherExamAllocationAssignedRoomToTeacherDetail", param);
        int k = (int)param[2].Value;
        return k;
    }

    public int TeacherExamAllocationAssignedRoomToTeacherDetailMaster(BLLSeatPlanTeacherExamAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermId;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;

        param[4] = new SqlParameter("@TeacherId", SqlDbType.Int);
        param[4].Value = objbll.TeacherId;

        param[5] = new SqlParameter("@SubjectId", SqlDbType.Int);
        param[5].Value = objbll.SubjectId;

        param[6] = new SqlParameter("@Result", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("TeacherExamAllocationAssignedRoomToTeacherDetailMaster", param);
        int k = (int)param[6].Value;
        return k;
    }

    public int TeacherExamAllocationAssignedRoomToTeacherDetailUpdate(BLLSeatPlanTeacherExamAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@AllocationMasterId ", SqlDbType.Int);
        param[0].Value = objbll.AllocationMasterId;

        param[1] = new SqlParameter("@Result", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("TeacherExamAllocationAssignedRoomToTeacherDetailUpdate", param);
        int k = (int)param[1].Value;
        return k;
    }


    public DataTable SeatPlanShowAssignedTeacherRooms(BLLSeatPlanTeacherExamAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermId;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanShowAssignedTeacherRooms", param);
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