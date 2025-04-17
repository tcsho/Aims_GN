using System;
using System.Data;

/// <summary>
/// Summary description for BLLNotif_Group
/// </summary>



public class BLLNotif_Group
{
    public BLLNotif_Group()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALNotif_Group objdal = new DALNotif_Group();



    #region 'Start Properties Declaration'

    public int NtGrp_Id { get; set; }
    public string Group_Name { get; set; }
    public string Group_Description { get; set; }
    public int? Status_Id { get; set; }
    public DateTime? CreatedOn { get; set; }
    public int? CreatedBy { get; set; }
    public DateTime? ModifiedOn { get; set; }
    public int? ModifiedBy { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Notif_GroupAdd(BLLNotif_Group _obj)
    {
        return objdal.Notif_GroupAdd(_obj);
    }
    public int Notif_GroupUpdate(BLLNotif_Group _obj)
    {
        return objdal.Notif_GroupUpdate(_obj);
    }
    public int Notif_GroupDelete(BLLNotif_Group _obj)
    {
        return objdal.Notif_GroupDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Notif_GroupFetch()
    {
        return objdal.Notif_GroupSelect();
    }

    public DataTable Notif_GroupFetchByStatusID(BLLNotif_Group _obj)
    {
        return objdal.Notif_GroupSelectByStatusID(_obj);
    }



    public DataTable Notif_GroupFetch(int _id)
    {
        return objdal.Notif_GroupSelect(_id);
    }


    #endregion

}
