using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALNotifications
/// </summary>
public class DALNotifications
{
    DALBase dalobj = new DALBase();


    public DALNotifications()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int NotificationsAdd(BLLNotifications objbll,string user)
    {
        SqlParameter[] param = new SqlParameter[6];
        param[0] = new SqlParameter("@NtType_Id", SqlDbType.Int); 
        param[0].Value = objbll.NtType_Id;
        param[1] = new SqlParameter("@Notif_Subject", SqlDbType.NVarChar); 
        param[1].Value = (objbll.Notif_Subject != null) ? objbll.Notif_Subject : "";
        param[2] = new SqlParameter("@Notif_Message", SqlDbType.NVarChar); 
        param[2].Value = (objbll.Notif_Message != null) ? objbll.Notif_Message : "";
        param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[3].Value = objbll.CreatedBy;
        param[4] = new SqlParameter("@User_List", SqlDbType.NVarChar);
        param[4].Value = user;
        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("NotificationsInsert", param);
        int k = (int)param[5        ].Value;
        return k;

    }
    public int NotificationsUpdate(BLLNotifications objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        //param[0] = new SqlParameter("@Id", SqlDbType.Int); param[0].Value = objbll.Id;
        //param[1] = new SqlParameter("@Firstname", SqlDbType.NVarChar); param[1].Value = objbll.Firstname;
        //param[2] = new SqlParameter("@Lastname", SqlDbType.NVarChar); param[2].Value = objbll.Lastname;
        //param[3] = new SqlParameter("@Details", SqlDbType.NVarChar); param[3].Value = objbll.Details;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("NotificationsUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int NotificationsDelete(BLLNotifications objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Notifications_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Notifications_Id;


        int k = dalobj.sqlcmdExecute("NotificationsDelete", param);

        return k;
    }
    public int Notification_DetailUpdate(BLLNotifications objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Notification_Id", SqlDbType.Int);
        param[0].Value = objbll.Notification_Id;
        param[1] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[1].Value = objbll.User_Id;


        int k = dalobj.sqlcmdExecute("Notification_DetailUpdate", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable NotificationsSelect(BLLNotifications obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[0].Value = obj.CreatedBy;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("NotificationSelectAll", param);
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


    public DataTable NotificationsLogicalGroups(  int user , string id, int page, int pageSize)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@User_Id", SqlDbType.Int);
        param[0].Value =user;
        param[1] = new SqlParameter("@id", SqlDbType.NVarChar);
        param[1].Value = id;
        param[2] = new SqlParameter("@PageSize", SqlDbType.Int);
        param[2].Value = pageSize;
        param[3] = new SqlParameter("@PageIndex", SqlDbType.Int);
        param[3].Value = page;
        
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Notif_LogicalGroupsSelect",param);
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


    public DataTable Notification_TypeSelectAll()
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Notification_TypeSelectAll");
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
    
    public DataTable NotificationsSelectByUserID(BLLNotifications objbll)
    {
        SqlParameter[] param = new SqlParameter[1];
        DataTable dt = new DataTable();
        param[0] = new SqlParameter("@User_Id", SqlDbType.NVarChar);
        param[0].Value = objbll.User_Id;

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("NotificationsSelectbyUserID", param);
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
