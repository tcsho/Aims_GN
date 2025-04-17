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
/// Summary description for _DALSeatPlanRoomAllocation
/// </summary>
public class _DALSeatPlanRoomAllocation
{
    DALBase dalobj = new DALBase();


    public _DALSeatPlanRoomAllocation()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int SeatPlanRoomAllocationAdd(BLLSeatPlanRoomAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Categ_Id", SqlDbType.Int);
        param[0].Value = objbll.Categ_Id;

        param[1] = new SqlParameter("@Room_Id", SqlDbType.Int);
        param[1].Value = objbll.Room_Id;

        param[2] = new SqlParameter("@Students", SqlDbType.Int);
        param[2].Value = objbll.Students;

        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[3].Value = objbll.CreatedOn;

        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[4].Value = objbll.CreatedBy;

        param[5] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[5].Value = objbll.Class_Id;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SeatPlanRoomAllocationInsert", param);
        int k = (int)param[6].Value;
        return k;

    }

    public int SeatPlanRoomAllocationLockUpdate(int Categ_Id, int IsLocked)
    {
        SqlParameter[] param = new SqlParameter[3];
        param[0] = new SqlParameter("@Categ_Id", SqlDbType.Int);
        param[0].Value = Categ_Id;

        param[1] = new SqlParameter("@IsLocked", SqlDbType.Int);
        param[1].Value = IsLocked;

        param[2] = new SqlParameter("@Result", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SeatPlanRoomAllocationLockUpdate", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int SeatPlanRoomAllocationUpdate(BLLSeatPlanRoomAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@RoomAllot_Id", SqlDbType.Int);
        param[0].Value = objbll.RoomAllot_Id;

        param[1] = new SqlParameter("@Room_Id", SqlDbType.Int);
        param[1].Value = objbll.Room_Id;

        param[2] = new SqlParameter("@Students", SqlDbType.Int);
        param[2].Value = objbll.Students;

        param[3] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[3].Value = objbll.ModifiedOn;

        param[4] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[4].Value = objbll.ModifiedBy;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SeatPlanRoomAllocationUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }
    public int SeatPlanRoomAllocationDelete(BLLSeatPlanRoomAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@RoomAllot_Id", SqlDbType.Int);
        param[0].Value = objbll.RoomAllot_Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;


        dalobj.sqlcmdExecute("SeatPlanRoomAllocationDelete", param);
        int k = (int)param[1].Value;
        return k;

    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable SeatPlanRoomAllocationSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanRoomAllocationSelect", param);
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

    public DataTable SeatPlanRoomAllocationSelectByCategoryId(BLLSeatPlanRoomAllocation objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Categ_Id", SqlDbType.Int);
        param[0].Value = objbll.Categ_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SeatPlanRoomAllocationSelectByCategoryId", param);
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


    public int SeatPlanRoomAllocationSelectField(int _Id)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("", param);
        int k = (int)param[1].Value;
        return k;

    }


    #endregion


}
