using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALLibLibrary
/// </summary>
public class _DALTCS_StdAttnCalender
{
    DALBase dalobj = new DALBase();

    public _DALTCS_StdAttnCalender()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int TCS_StdAttnCalenderInsert(BLLTCS_StdAttnCalender objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int); param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int); param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int); param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@year", SqlDbType.NVarChar); param[3].Value = objbll.Year;

        int val = dalobj.sqlcmdExecute("Center_CalenderInsert", param);

        return val;
    }

    public DataTable TCS_StdAttnCalenderSelectCal_IDByDateCenter(BLLTCS_StdAttnCalender objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@CalDate", SqlDbType.NVarChar);
        param[0].Value = objbll.CalDate;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_StdAttnCalenderSelectCal_IDByDateCenter", param);
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

    internal void AddStudentAttendanceDataWeekly(StudentAttendanceDataDetail info)
    {
        // define INSERT query with parameters
        string query = @"INSERT INTO [dbo].[TCS_StdAttn]
                                ([Cal_ID]
                                ,[AttnDate]
                               ,[AttnType_Id]
                               ,[Student_Id]
                               ,[Section_id]
                               ,[Year]
                               ,[WeekNo]
                                ,[Month]
                            
                               ,[MonAttnTypeId]
                               ,[TueAttnTypeId]
                               ,[WedAttnTypeId]
                               ,[ThurAttnTypeId]
                               ,[FriAttnTypeId]
                               ,[CreatedBy]
                               ,[CreatedOn]
                               ,[Session_Id])
                         VALUES
                               (@Cal_ID
                                ,@AttnDate
                               ,@AttnType_Id
                               ,@Student_Id
                               ,@Section_id
                               ,@Year
                               ,@WeekNo
                                ,@Month
                             
                                ,@MonAttnTypeId
                                ,@TueAttnTypeId
                                ,@WedAttnTypeId
                                ,@ThurAttnTypeId
                                ,@FriAttnTypeId
                               ,@CreatedBy
                               ,@CreatedOn                               
                               ,@Session_Id) ";

        // create connection and command
        using (SqlConnection cn = new SqlConnection(dalobj._cn.ConnectionString))
        using (SqlCommand cmd = new SqlCommand(query, cn))
        {
            //define parameters and their values
            cmd.Parameters.Add("@Cal_ID", SqlDbType.Int).Value = info.Cal_ID;
            cmd.Parameters.Add("@AttnDate", SqlDbType.DateTime).Value = info.AttendaneDate;
            cmd.Parameters.Add("@AttnType_Id", SqlDbType.Int).Value = info.AttnTypeId;
            cmd.Parameters.Add("@Student_Id", SqlDbType.Int).Value = info.RollNumber;
            cmd.Parameters.Add("@Section_id", SqlDbType.Int).Value = info.SectionId;
            cmd.Parameters.Add("@Year", SqlDbType.Int).Value = info.Year;
            cmd.Parameters.Add("@WeekNo", SqlDbType.Int).Value = info.WeekNo;
            cmd.Parameters.Add("@Month", SqlDbType.Int).Value = info.Month;
            cmd.Parameters.Add("@MonAttnTypeId", SqlDbType.Int).Value = info.MonAttnTypeId;
            cmd.Parameters.Add("@TueAttnTypeId", SqlDbType.Int).Value = info.TueAttnTypeId;
            cmd.Parameters.Add("@WedAttnTypeId", SqlDbType.Int).Value = info.WedAttnTypeId;
            cmd.Parameters.Add("@ThurAttnTypeId", SqlDbType.Int).Value = info.ThurAttnTypeId;
            cmd.Parameters.Add("@FriAttnTypeId", SqlDbType.Int).Value = info.FriAttnTypeId;
            cmd.Parameters.Add("@CreatedBy", SqlDbType.Int).Value = info.CreatedBy;
            cmd.Parameters.Add("@CreatedOn", SqlDbType.DateTime).Value = DateTime.Now;
            cmd.Parameters.Add("@Session_Id", SqlDbType.Int).Value = info.Session_Id;

            //open connection, execute INSERT, close connection
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }

    internal void UpdateStudentAttendanceDataDaily(StudentAttendanceDataDetail info)
    {
        string query = "";
        if (info.AttendaneDate.ToString("ddd") == "Mon")
        {
             query = "UPDATE [dbo].[TCS_StdAttn]" +
                        "                          SET" +
                        "                           [AttnDate] = '" + info.AttendaneDate + "'" +
                        "                          ,[MonAttnTypeId] = " + info.MonAttnTypeId +                   
                        "                          ,[ModifiedBy] = " + info.CreatedBy +
                        "                         ,[ModifiedOn] =  '" + DateTime.Now + "'" +
                        "                       WHERE Student_Id = " + info.RollNumber +
                        "                       and  WeekNo = " + info.WeekNo +
                        "                       and [Month] = " + info.Month +
                        "                       and Session_Id = " + info.Session_Id +
                        "                       and [Year] = " + info.Year;
        }
        if (info.AttendaneDate.ToString("ddd") == "Tue")
        {
             query = "UPDATE [dbo].[TCS_StdAttn]" +
                        "                          SET" +
                        "                           [AttnDate] = '" + info.AttendaneDate + "'" +
                        "                          ,[TueAttnTypeId] = " + info.TueAttnTypeId +
                        "                          ,[ModifiedBy] = " + info.CreatedBy +
                        "                         ,[ModifiedOn] =  '" + DateTime.Now + "'" +
                        "                       WHERE Student_Id = " + info.RollNumber +
                        "                       and  WeekNo = " + info.WeekNo +
                        "                       and [Month] = " + info.Month +
                        "                       and Session_Id = " + info.Session_Id +
                        "                       and [Year] = " + info.Year;
        }

        if (info.AttendaneDate.ToString("ddd") == "Wed")
        {
             query = "UPDATE [dbo].[TCS_StdAttn]" +
                        "                          SET" +
                        "                           [AttnDate] = '" + info.AttendaneDate + "'" +
                        "                          ,[WedAttnTypeId] = " + info.WedAttnTypeId +
                        "                          ,[ModifiedBy] = " + info.CreatedBy +
                        "                         ,[ModifiedOn] =  '" + DateTime.Now + "'" +
                        "                       WHERE Student_Id = " + info.RollNumber +
                        "                       and  WeekNo = " + info.WeekNo +
                        "                       and [Month] = " + info.Month +
                        "                       and Session_Id = " + info.Session_Id +
                        "                       and [Year] = " + info.Year;
        }
        if (info.AttendaneDate.ToString("ddd") == "Thu")
        {
             query = "UPDATE [dbo].[TCS_StdAttn]" +
                        "                          SET" +
                        "                           [AttnDate] = '" + info.AttendaneDate + "'" +
                        "                          ,[ThurAttnTypeId] = " + info.ThurAttnTypeId +
                        "                          ,[ModifiedBy] = " + info.CreatedBy +
                        "                         ,[ModifiedOn] =  '" + DateTime.Now + "'" +
                        "                       WHERE Student_Id = " + info.RollNumber +
                        "                       and  WeekNo = " + info.WeekNo +
                        "                       and [Month] = " + info.Month +
                        "                       and Session_Id = " + info.Session_Id +
                        "                       and [Year] = " + info.Year;
        }
        if (info.AttendaneDate.ToString("ddd") == "Fri")
        {
             query = "UPDATE [dbo].[TCS_StdAttn]" +
                        "                          SET" +
                        "                           [AttnDate] = '" + info.AttendaneDate + "'" +
                        "                          ,[FriAttnTypeId] = " + info.FriAttnTypeId +
                        "                          ,[ModifiedBy] = " + info.CreatedBy +
                        "                         ,[ModifiedOn] =  '" + DateTime.Now + "'" +
                        "                       WHERE Student_Id = " + info.RollNumber +
                        "                       and  WeekNo = " + info.WeekNo +
                        "                       and [Month] = " + info.Month +
                        "                       and Session_Id = " + info.Session_Id +
                        "                       and [Year] = " + info.Year;
        }
        using (SqlConnection cn = new SqlConnection(dalobj._cn.ConnectionString))
        using (SqlCommand cmd = new SqlCommand(query, cn))
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }

    }

    internal void UpdateStudentAttendanceDataWeekly(StudentAttendanceDataDetail info)
    {

        string query = "UPDATE [dbo].[TCS_StdAttn]" +
            "                          SET" +
            "                           [AttnDate] = '" + info.AttendaneDate + "'" +
            "                          ,[MonAttnTypeId] = " + info.MonAttnTypeId +
            "                          ,[TueAttnTypeId] = " + info.TueAttnTypeId +
            "                          ,[WedAttnTypeId] = " + info.WedAttnTypeId +
            "                          ,[ThurAttnTypeId] = " + info.ThurAttnTypeId +
            "                          ,[FriAttnTypeId] = " + info.FriAttnTypeId +
            "                          ,[ModifiedBy] = " + info.CreatedBy +
            "                         ,[ModifiedOn] =  '" + DateTime.Now + "'" +
            "                       WHERE Student_Id = " + info.RollNumber +
            "                       and  WeekNo = " + info.WeekNo +
            "                       and [Month] = " + info.Month +
            "                       and Session_Id = " + info.Session_Id +
            "                       and [Year] = " + info.Year;

        using (SqlConnection cn = new SqlConnection(dalobj._cn.ConnectionString))
        using (SqlCommand cmd = new SqlCommand(query, cn))
        {
            cn.Open();
            cmd.ExecuteNonQuery();
            cn.Close();
        }
    }

    internal string GetAttnType(int parm)
    {
        SqlConnection conn = new SqlConnection(dalobj._cn.ConnectionString);
        conn.Open();
        string query = "select * from TCS_StdAttnType where AttnType_ID=" + parm;
        SqlCommand cmd = new SqlCommand(query, conn);

        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        conn.Close();
        foreach (DataRow row in dt.Rows)
        {
            return row["AttCode"].ToString();
        }
        return null;
    }

    internal DataTable CheckAttendanceAlreadyExist(int rollNumber, int year, int weekNo, int month, int sessionId)
    {
        SqlConnection conn = new SqlConnection(dalobj._cn.ConnectionString);
        conn.Open();
        string query = "select * from TCS_StdAttn where [Year]=" + year + "and WeekNo=" + weekNo + " and Student_Id=" + rollNumber + " and Month=" + month + " and Session_Id=" + sessionId;
        SqlCommand cmd = new SqlCommand(query, conn);

        DataTable dt = new DataTable();
        dt.Load(cmd.ExecuteReader());
        conn.Close();
        return dt;
    }
}

