using System;
using System.Data;

/// <summary>
/// Summary description for BLLNotifications
/// </summary>



public class BLLNotifications
{
    public BLLNotifications()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALNotifications objdal = new DALNotifications();



    #region 'Start Properties Declaration'

    public int Notification_Id { get; set; }
    public int NtType_Id { get; set; }
    public string Notif_Subject { get; set; }
    public string Notif_Message { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public bool Is_lock { get; set; }
    public bool Is_Visible { get; set; }
    public int User_Id { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int NotificationsAdd(BLLNotifications _obj,string user)
    {
        return objdal.NotificationsAdd(_obj,user);
    }
    public int NotificationsUpdate(BLLNotifications _obj)
    {
        return objdal.NotificationsUpdate(_obj);
    }
    public int NotificationsDelete(BLLNotifications _obj)
    {
        return objdal.NotificationsDelete(_obj);

    }
    public int Notification_DetailUpdate(BLLNotifications _obj)
    {
        return objdal.Notification_DetailUpdate(_obj);

    }
    

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Notification_TypeSelectAll()
    {
        return objdal.Notification_TypeSelectAll();
    }

    public DataTable NotificationsSelectByUserID(BLLNotifications _obj)
    {
        return objdal.NotificationsSelectByUserID(_obj);
    }
  

    public DataTable NotificationsFetch(BLLNotifications obj)
    {
        return objdal.NotificationsSelect(obj);
    }
    public DataTable NotificationsLogicalGroups(int mode, string id, int page, int pageSize)
    {
        return objdal.NotificationsLogicalGroups(mode, id,page, pageSize);
    }


    #endregion

}
