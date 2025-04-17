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
/// Summary description for BLLSeatPlanRoomAllocateToStudent
/// </summary>
public class BLLSeatPlanRoomAllocateToStudent
{
    public BLLSeatPlanRoomAllocateToStudent()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    _DALSeatPlanRoomAllocateToStudent objdal = new _DALSeatPlanRoomAllocateToStudent();

    public int Center_Id { get; set; }
    public int Session_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int Class_Id { get; set; }
    public int Room_Id { get; set; }
    public int Students { get; set; }
    public int Gender_Id { get; set; }
    public int Block_Id { get; set; }

    public int SeatPlanAssignRoomsToStudents(BLLSeatPlanRoomAllocateToStudent _obj)
    {
        return objdal.SeatPlanAssignRoomsToStudents(_obj);
    }

}