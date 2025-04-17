using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for BLLSeatPlanRoomAllocation
/// </summary>



public class BLLSeatPlanRoomAllocation
    {
    public BLLSeatPlanRoomAllocation()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALSeatPlanRoomAllocation objdal = new _DALSeatPlanRoomAllocation();



    #region 'Start Properties Declaration'

    public int RoomAllot_Id { get; set; }
    public int Categ_Id { get; set; }
    public int Room_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Students { get; set; }
    public int Center_Id { get; set; }
    public int Session_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int Class_Id { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int SeatPlanRoomAllocationAdd(BLLSeatPlanRoomAllocation _obj)
        {
        return objdal.SeatPlanRoomAllocationAdd(_obj);
        }

    public int SeatPlanRoomAllocationLockUpdate(int Categ_Id, int IsLocked)
    {
        return objdal.SeatPlanRoomAllocationLockUpdate(Categ_Id, IsLocked);
    }
    public int SeatPlanRoomAllocationUpdate(BLLSeatPlanRoomAllocation _obj)
        {
        return objdal.SeatPlanRoomAllocationUpdate(_obj);
        }
    public int SeatPlanRoomAllocationDelete(BLLSeatPlanRoomAllocation _obj)
        {
        return objdal.SeatPlanRoomAllocationDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SeatPlanRoomAllocationSelectByCategoryId(BLLSeatPlanRoomAllocation _obj)
        {
        return objdal.SeatPlanRoomAllocationSelectByCategoryId(_obj);
        }

    public DataTable SeatPlanRoomAllocationFetch(int _id)
      {
        return objdal.SeatPlanRoomAllocationSelect(_id);
      }
    public int SeatPlanRoomAllocationFetchField(int _Id)
        {
        return objdal.SeatPlanRoomAllocationSelectField(_Id);
        }


    #endregion

    }
