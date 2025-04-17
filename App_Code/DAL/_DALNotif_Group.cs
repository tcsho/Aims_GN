using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALNotif_Group
/// </summary>
public class DALNotif_Group
{
    DALBase dalobj = new DALBase();


    public DALNotif_Group()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Notif_GroupAdd(BLLNotif_Group objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Group_Name", SqlDbType.NVarChar);
        param[0].Value = (objbll.Group_Name != null) ? objbll.Group_Name : "";
        param[1] = new SqlParameter("@Group_Description", SqlDbType.NVarChar);
        param[1].Value = (objbll.Group_Description != null) ? objbll.Group_Description : "";
        param[2] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[2].Value = objbll.CreatedBy;
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Notif_GroupInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int Notif_GroupUpdate(BLLNotif_Group objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@NtGrp_Id", SqlDbType.Int); param[0].Value = objbll.NtGrp_Id;
        param[1] = new SqlParameter("@Group_Name", SqlDbType.NVarChar); param[1].Value = (objbll.Group_Name != null) ? objbll.Group_Name : "";
        param[2] = new SqlParameter("@Group_Description", SqlDbType.NVarChar); param[2].Value = (objbll.Group_Description != null) ? objbll.Group_Description : "";
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int); param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[5].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[6].Value = objbll.ModifiedOn;
        param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[7].Value = objbll.ModifiedBy;



        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Notif_GroupUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Notif_GroupDelete(BLLNotif_Group objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Notif_Group_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Notif_Group_Id;


        int k = dalobj.sqlcmdExecute("Notif_GroupDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Notif_GroupSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Notif_GroupSelectById", param);
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;
    }

    public DataTable Notif_GroupSelect()
    {



        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Notif_GroupSelectAll");
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }

    public DataTable Notif_GroupSelectByStatusID(BLLNotif_Group objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Notif_GroupSelectByStatusID");
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }




    #endregion


}
