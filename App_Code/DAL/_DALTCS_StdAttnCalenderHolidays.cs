using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALStdAttnCalenderScreen 
/// </summary>
public class _DALTCS_StdAttnCalenderHolidays
{
    DALBase dalobj = new DALBase();

    public _DALTCS_StdAttnCalenderHolidays()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int TCS_StdAttnCalenderHolidaysInsert(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@CallDate", SqlDbType.NVarChar); param[0].Value = objbll.CallDate;
        param[1] = new SqlParameter("@Remarks", SqlDbType.NVarChar); param[1].Value = objbll.Remarks;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int); param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@CalDayType_Id", SqlDbType.Int); param[3].Value = objbll.CalDayType_Id;
        param[4] = new SqlParameter("@Region_Id", SqlDbType.Int); param[4].Value = objbll.Region_Id;
        param[5] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int); param[5].Value = objbll.Main_Organisation_Id;
        param[6] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[6].Value = objbll.CreatedBy;
        param[7] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[7].Value = objbll.CreatedOn;


        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        int val = dalobj.sqlcmdExecute("TCS_StdAttnCalenderHolidaysInsert", param);

        val = Convert.ToInt32(param[8].Value);
        return val;
    }
    public int TCS_StdAttnCalenderHolidaysUpdate(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Call_ID", SqlDbType.NVarChar);
        param[0].Value = objbll.Call_ID;
        param[1] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
        param[1].Value = objbll.Remarks;
        param[2] = new SqlParameter("@CalDayType_Id", SqlDbType.Int);
        param[2].Value = objbll.CalDayType_Id;
        param[3] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[3].Value = objbll.ModifiedOn;
        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[4].Value = objbll.ModifiedBy;


        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("TCS_StdAttnCalenderHolidaysUpdate", param);
        int k = (int)param[5].Value;
        return k;


        ////////////int k = dalobj.sqlcmdExecute("TCS_StdAttnCalenderHolidaysUpdate", param);

        ////////////return k;
    }
    public DataTable TCS_StdAttnCalenderHolidaysSelectAll(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        DataTable _dt = new DataTable();

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@year", SqlDbType.NVarChar); param[0].Value = objbll.Year;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int); param[1].Value = objbll.Center_Id;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_StdAttnCalenderHolidaysSelectAll", param);
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
    public DataTable TCS_StdAttnCalenderHolidaysSelectByCall_ID(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Call_ID", SqlDbType.Int);
        param[0].Value = objbll.Call_ID;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_StdAttnCalenderHolidaysSelectByCall_ID", param);
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
    public int TCS_StdAttnCalenderHolidaysDelete(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Call_ID", SqlDbType.Int);
        param[0].Value = objbll.Call_ID;
        param[1] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[1].Value = objbll.ModifiedOn;
        param[2] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[2].Value = objbll.ModifiedBy;

        int k = dalobj.sqlcmdExecute("TCS_StdAttnCalenderHolidaysDelete", param);

        return k;
    }
}
