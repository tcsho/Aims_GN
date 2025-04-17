using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALLibLibrary
/// </summary>
public class _DALTCS_StdAttn
{
    DALBase dalobj = new DALBase();

    public _DALTCS_StdAttn()
    {
        // 
        // TODO: Add constructor logic here
        //
    }
    public int TCS_StdAttnInsert(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@Cal_ID", SqlDbType.Int);
        param[0].Value = objbll.Cal_ID;
        param[1] = new SqlParameter("@AttnDate", SqlDbType.NVarChar);
        param[1].Value = objbll.AttnDate;
        param[2] = new SqlParameter("@AttnType_Id", SqlDbType.Int);
        param[2].Value = objbll.AttnType_Id;
        param[3] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_Id;
        param[4] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[4].Value = objbll.Section_Id;

        param[5] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[5].Value = objbll.Session_Id;
        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[6].Value = objbll.CreatedBy;
        param[7] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[7].Value = objbll.CreatedOn;


        int val = dalobj.sqlcmdExecute("TCS_StdAttnInsert", param);

        return val;
    }

    public int TCS_StdAttnUpdate(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Attn_Id", SqlDbType.Int); param[0].Value = objbll.Attn_ID;
        param[1] = new SqlParameter("@AttnType_Id", SqlDbType.Int); param[1].Value = objbll.AttnType_Id;
        param[2] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[2].Value = objbll.ModifiedBy;
        param[3] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[3].Value = objbll.ModifiedOn;

        int k = dalobj.sqlcmdExecute("TCS_StdAttnUpdate", param);

        return k;
    }
    public DataTable TSSMonthlyAttnSummery(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Year", SqlDbType.Int);
        param[1].Value = objbll.Year;

        param[2] = new SqlParameter("@Month", SqlDbType.Int);
        param[2].Value = objbll.Month;

        param[3] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[3].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TSSMonthlyAttnSummery", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    internal DataTable TSSMonthlyStudentAttnSummery(BLLTCS_StdAttn objbll)
    {

        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Year", SqlDbType.Int);
        param[0].Value = objbll.Year;

        param[1] = new SqlParameter("@Month", SqlDbType.Int);
        param[1].Value = objbll.Month;

        param[2] = new SqlParameter("@Sectionid", SqlDbType.Int);
        param[2].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TSSMonthlyStudentsAttnSummery", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public DataTable TssSelectClassSectionByCenter(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssSelectClassSectionByCenter", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }


    public DataTable TssStudentSelectByClassSectionIdForAttendance(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Class_Section_id", SqlDbType.Int);
        param[0].Value = objbll.Class_Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssStudentSelectByClassSectionIdForAttendance", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    internal DataTable TssStudentSelectByClassSectionIdForAttendanceExisting(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Class_Section_id", SqlDbType.Int);
        param[0].Value = objbll.Class_Section_Id;
        param[1] = new SqlParameter("@date", SqlDbType.DateTime);
        param[1].Value = objbll.AttnDate;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssStudentSelectByClassSectionIdForAttandanceExisting", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }


    public DataTable TCS_StdAttnDailyRptAttnTypeWise(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@date", SqlDbType.DateTime);
        param[1].Value = objbll.date;

        param[2] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[2].Value = objbll.Section_Id;

        param[3] = new SqlParameter("@parm", SqlDbType.Int);
        param[3].Value = objbll.parm;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_StdAttnDailyRptAttnTypeWise", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }
    internal DataTable TSSWeeklyStudentAttnSummery(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Year", SqlDbType.Int);
        param[0].Value = objbll.Year;

        param[1] = new SqlParameter("@Week", SqlDbType.Int);
        param[1].Value = objbll.Week;

        param[2] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[2].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TSSWeeklyStudentsAttnSummery", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }


    internal DataTable TSSWeeklyStudentAttnDetail(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[8];
        param[0] = new SqlParameter("@Year", SqlDbType.Int);
        param[0].Value = objbll.Year;        
        param[1] = new SqlParameter("@Sectionid", SqlDbType.Int);
        param[1].Value = objbll.Section_Id;
        param[2] = new SqlParameter("@StudentId", SqlDbType.Int);
        param[2].Value = objbll.Student_Id;

        param[3] = new SqlParameter("@WeekOne", SqlDbType.Int);
        param[3].Value = objbll.weekOne;

        param[4] = new SqlParameter("@WeekTwo", SqlDbType.Int);
        param[4].Value = objbll.weekTwo;

        param[5] = new SqlParameter("@WeekThree", SqlDbType.Int);
        param[5].Value = objbll.weekThre;

        param[6] = new SqlParameter("@WeekFour", SqlDbType.Int);
        param[6].Value = objbll.weekFour;

        param[7] = new SqlParameter("@WeekFive", SqlDbType.Int);
        param[7].Value = objbll.weekFive;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TSSWeeklyStudentAttnDetail", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }



    internal DataTable TSSWeeklyAttnSummery(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Year", SqlDbType.Int);
        param[1].Value = objbll.Year;

        param[2] = new SqlParameter("@Week", SqlDbType.Int);
        param[2].Value = objbll.Week;

        param[3] = new SqlParameter("@Section_id", SqlDbType.Int);
        param[3].Value = objbll.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TSSWeeklyAttnSummery", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public DataTable SendSMSByCenterClassDate(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@AttnDate", SqlDbType.NVarChar);
        param[1].Value = objbll.AttnDate;

        param[2] = new SqlParameter("@Section", SqlDbType.Int);
        param[2].Value = objbll.Section_Id;

        param[3] = new SqlParameter("@SentStatus", SqlDbType.Bit);
        param[3].Value = objbll.SentStatus;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SendSMSByCenterClassDate", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public int SendSMSUpdateStatus(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[3];


        param[0] = new SqlParameter("@Attn_Id", SqlDbType.Int);
        param[0].Value = objbll.Attn_ID;

        param[1] = new SqlParameter("@SmsSentOn", SqlDbType.DateTime);
        param[1].Value = objbll.SmsSentOn;

        param[2] = new SqlParameter("@SmsSentBy", SqlDbType.Int);
        param[2].Value = objbll.SmsSentBy;


        try
        {
            dalobj.OpenConnection();
            int k = dalobj.sqlcmdExecute("SendSMSUpdateStatus", param);

            return k;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public DataTable SendSMSByCenterDate(BLLTCS_StdAttn objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@AttnDate", SqlDbType.NVarChar);
        param[1].Value = objbll.AttnDate;

        param[2] = new SqlParameter("@SentStatus", SqlDbType.Bit);
        param[2].Value = objbll.SentStatus;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SendSMSByCenterDate", param);
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

}
