using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALStdAttnCalenderDayType
/// </summary>
public class _DALTCS_StdAttnCalenderDayType
{
    DALBase dalobj = new DALBase();

    public _DALTCS_StdAttnCalenderDayType()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int TCS_StdAttnCalenderDayTypeInsert(BLLTCS_StdAttnCalenderDayType objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@CalTypeDesc", SqlDbType.NVarChar); param[0].Value = objbll.CalTypeDesc;
        param[1] = new SqlParameter("@Status_Id", SqlDbType.Int); param[1].Value = objbll.Status_Id;
        param[2] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[2].Value = objbll.CreatedBy;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[3].Value = objbll.CreatedOn;
        
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        int val = dalobj.sqlcmdExecute("TCS_StdAttnCalenderDayTypeInsert", param);

        val = Convert.ToInt32(param[4].Value);
        return val;
    }
    public int TCS_StdAttnCalenderDayTypeUpdate(BLLTCS_StdAttnCalenderDayType objbll)
    {
        SqlParameter[] param = new SqlParameter[5];


        param[0] = new SqlParameter("@CalDayType_Id", SqlDbType.Int);
        param[0].Value = objbll.CalDayType_Id;   
        param[1] = new SqlParameter("@CalTypeDesc", SqlDbType.NVarChar); 
        param[1].Value = objbll.CalTypeDesc;       
        param[2] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        param[2].Value = objbll.ModifiedBy;
        param[3] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        param[3].Value = objbll.ModifiedOn;

        ////param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        ////param[4].Direction = ParameterDirection.Output;

        //dalobj.sqlcmdExecute("TCS_StdAttnCalenderDayTypeUpdate", param);
        //int k = (int)param[4].Value;
        //return k;

        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("TCS_StdAttnCalenderDayTypeUpdate", param);
        int k = (int)param[4].Value;
        return k;


    }
    public DataTable TCS_StdAttnCalenderDayTypeSelectAll()
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_StdAttnCalenderDayTypeSelectAll");
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
    public DataTable TCS_StdAttnCalenderDayTypeSelectByCalDayType_Id(BLLTCS_StdAttnCalenderDayType objbll)
        {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CalDayType_Id", SqlDbType.Int);
        param[0].Value = objbll.CalDayType_Id;

       
        DataTable _dt = new DataTable();


        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_StdAttnCalenderDayTypeSelectByCalDayType_Id", param);
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
    public int TCS_StdAttnCalenderDayTypeDelete(BLLTCS_StdAttnCalenderDayType objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@CalDayType_Id", SqlDbType.Int);
        param[0].Value = objbll.CalDayType_Id;
        param[1] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[1].Value = objbll.ModifiedBy;
        param[2] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[2].Value = objbll.ModifiedOn;


        int k = dalobj.sqlcmdExecute("TCS_StdAttnCalenderDayTypeDelete", param);

        return k;
    }
}
