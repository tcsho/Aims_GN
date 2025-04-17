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
/// Summary description for BLLSeatPlanRoomInfo
/// </summary>



public class BLLSeatPlanRoomInfo
    {
    public BLLSeatPlanRoomInfo()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALSeatPlanRoomInfo objdal = new _DALSeatPlanRoomInfo();



    #region 'Start Properties Declaration'
    public int Room_Id { get; set; }
    public string RoomName { get; set; }
    public int Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int SeatPlanRoomInfoAdd(BLLSeatPlanRoomInfo _obj)
        {
        return objdal.SeatPlanRoomInfoAdd(_obj);
        }
    public int SeatPlanRoomInfoUpdate(BLLSeatPlanRoomInfo _obj)
        {
        return objdal.SeatPlanRoomInfoUpdate(_obj);
        }
    public int SeatPlanRoomInfoDelete(BLLSeatPlanRoomInfo _obj)
        {
        return objdal.SeatPlanRoomInfoDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SeatPlanRoomInfoFetch(BLLSeatPlanRoomInfo _obj)
        {
        return objdal.SeatPlanRoomInfoSelect(_obj);
        }

    public DataTable SeatPlanRoomInfoFetch(int _id)
      {
        return objdal.SeatPlanRoomInfoSelect(_id);
      }

    
    public DataTable SeatPlanRoomInfoSelectAll()
    {
        return objdal.SeatPlanRoomInfoSelectAll();
    }

    public int SeatPlanRoomInfoFetchField(int _Id)
        {
        return objdal.SeatPlanRoomInfoSelectField(_Id);
        }


    #endregion

    }
