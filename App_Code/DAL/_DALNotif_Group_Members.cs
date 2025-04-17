using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALNotif_Group_Members
/// </summary>
public class DALNotif_Group_Members
{
    DALBase dalobj = new DALBase();


    public DALNotif_Group_Members()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Notif_Group_MembersAdd(BLLNotif_Group_Members objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@User_Id", SqlDbType.NVarChar);
        param[0].Value = objbll.User_List;

        param[1] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[1].Value = objbll.CreatedBy;

        int k = dalobj.sqlcmdExecute("Notif_Group_MembersInsert", param);

        return k;

    }
    public int Notif_Group_MembersUpdate(BLLNotif_Group_Members objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Nt_Grp_Member_id", SqlDbType.Int); param[0].Value = objbll.Nt_Grp_Member_id;
        param[1] = new SqlParameter("@NtGrp_Id", SqlDbType.Int); param[1].Value = objbll.NtGrp_Id;
        param[2] = new SqlParameter("@User_Id", SqlDbType.Int); param[2].Value = objbll.User_Id;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int); param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[5].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[6].Value = objbll.ModifiedOn;
        param[7] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[7].Value = objbll.ModifiedBy;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Notif_Group_MembersUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int Notif_Group_MembersDelete(BLLNotif_Group_Members objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Notif_Group_Members_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Notif_Group_Members_Id;


        int k = dalobj.sqlcmdExecute("Notif_Group_MembersDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Notif_Group_MembersSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Notif_Group_MembersSelectById", param);
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

    public DataTable Notif_Group_MembersSelect(BLLNotif_Group_Members objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@NtGrp_Id", SqlDbType.Int);
        param[0].Value = objbll.NtGrp_Id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Notif_Group_MembersSelectAll", param);
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

    public DataTable Notif_Group_MembersSelectByStatusID(BLLNotif_Group_Members objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Notif_Group_MembersSelectByStatusID");
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
