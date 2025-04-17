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
/// Summary description for BLLSeatPlanTeacherExamAllocation
/// </summary>
public class BLLSeatPlanTeacherExamAllocation
{
    public BLLSeatPlanTeacherExamAllocation()
    {
        //
        // TODO: Add constructor logic here
        //
    }


    _DALSeatPlanTeacherExamAllocation objdal = new _DALSeatPlanTeacherExamAllocation();

    public int Id { get; set; }
    public int Center_Id { get; set; }
    public int Session_Id { get; set; }
    public int TermId { get; set; }
    public int Block_Id { get; set; }
    public int Gender_Id { get; set; }
    public int TeacherId { get; set; }
    public int RoomAllot_Id { get; set; }
    public int SubjectId { get; set; }
    public int Status { get; set; }
    public int Class_Id { get; set; }
    public int AllocationMasterId { get; set; }
    public DateTime CreatedDate { get; set; }

    public DataTable TeacherExamAllocationActiveSchools(BLLSeatPlanTeacherExamAllocation _obj)
    {
        return objdal.TeacherExamAllocationActiveSchools(_obj);
    }

    public DataTable TeacherExamAllocationActiveTeachers(BLLSeatPlanTeacherExamAllocation _obj)
    {
        return objdal.TeacherExamAllocationActiveTeachers(_obj);
    }

    public DataTable StudentsCountBaseOnSubject(BLLSeatPlanTeacherExamAllocation _obj)
    {
        return objdal.StudentsCountBaseOnSubject(_obj);
    }


    public DataTable GetRooms(BLLSeatPlanTeacherExamAllocation _obj)
    {
        return objdal.GetRooms(_obj);
    }

    public int TeacherExamAllocationAssignedRoomToTeacherDetail(BLLSeatPlanTeacherExamAllocation _obj)
    {
        return objdal.TeacherExamAllocationAssignedRoomToTeacherDetail(_obj);
    }

    public int TeacherExamAllocationAssignedRoomToTeacherDetailMaster(BLLSeatPlanTeacherExamAllocation _obj)
    {
        return objdal.TeacherExamAllocationAssignedRoomToTeacherDetailMaster(_obj);
    }

    public int TeacherExamAllocationAssignedRoomToTeacherDetailUpdate(BLLSeatPlanTeacherExamAllocation _obj)
    {
        return objdal.TeacherExamAllocationAssignedRoomToTeacherDetailUpdate(_obj);
    }


    public DataTable SeatPlanShowAssignedTeacherRooms(BLLSeatPlanTeacherExamAllocation _obj)
    {
        return objdal.SeatPlanShowAssignedTeacherRooms(_obj);
    }

}