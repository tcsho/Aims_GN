using System;
using System.Data;

/// <summary>
/// Summary description for BLLNotif_Group_Members
/// </summary>



public class BLLNotif_Group_Members
    {
    public BLLNotif_Group_Members()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALNotif_Group_Members objdal = new DALNotif_Group_Members();



    #region 'Start Properties Declaration'

    public int Nt_Grp_Member_id { get; set; }
    public int? NtGrp_Id { get; set; }
    public int? User_Id { get; set; }
    public string User_List { get; set; }
    public int? Status_Id { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? ModifiedBy { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Notif_Group_MembersAdd(BLLNotif_Group_Members _obj)
        {
        return objdal.Notif_Group_MembersAdd(_obj);
        }
    public int Notif_Group_MembersUpdate(BLLNotif_Group_Members _obj)
        {
        return objdal.Notif_Group_MembersUpdate(_obj);
        }
    public int Notif_Group_MembersDelete(BLLNotif_Group_Members _obj)
        {
        return objdal.Notif_Group_MembersDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Notif_Group_MembersFetch(BLLNotif_Group_Members _obj)
        {
        return objdal.Notif_Group_MembersSelect(_obj);
        }

    public DataTable Notif_Group_MembersFetchByStatusID(BLLNotif_Group_Members _obj)
    {
        return objdal.Notif_Group_MembersSelectByStatusID(_obj);
    }



    public DataTable Notif_Group_MembersFetch(int _id)
      {
        return objdal.Notif_Group_MembersSelect(_id);
      }


    #endregion

    }
