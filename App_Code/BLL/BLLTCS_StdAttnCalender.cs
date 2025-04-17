using System;
using System.Data;


/// <summary>
/// Summary description for BLLStdAttnCalender
/// </summary>
public class BLLTCS_StdAttnCalender
{
    _DALTCS_StdAttnCalender objdal = new _DALTCS_StdAttnCalender();

    public BLLTCS_StdAttnCalender()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int Cal_ID { get { return cal_ID; } set { cal_ID = value; } }	private int cal_ID;
    public int CalScrn_Id { get { return calScrn_Id; } set { calScrn_Id = value; } }	private int calScrn_Id;
    public string CalDate { get { return calDate; } set { calDate = value; } }	private string calDate;
    public string Remarks { get { return remarks; } set { remarks = value; } }	private string remarks;
    public string Year { get { return year; } set { year = value; } }	private string year;
    public int Center_Id { get { return center_Id; } set { center_Id = value; } }	private int center_Id;
    public int CalDayType_Id { get { return calDayType_Id; } set { calDayType_Id = value; } }	private int calDayType_Id;
    public int Region_Id { get { return region_Id; } set { region_Id = value; } }	private int region_Id;
    public int Main_Organisation_Id { get { return main_Organisation_Id; } set { main_Organisation_Id = value; } }	private int main_Organisation_Id;
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }	private int createdBy;
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }	private DateTime createdOn;
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }	private int modifiedBy;
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }	private DateTime modifiedOn;


    public int TCS_StdAttnCalenderInsert(BLLTCS_StdAttnCalender objbll)
    {
        return objdal.TCS_StdAttnCalenderInsert(objbll);
    }
    public DataTable TCS_StdAttnCalenderSelectCal_IDByDateCenter(BLLTCS_StdAttnCalender objbll)
    {
        return objdal.TCS_StdAttnCalenderSelectCal_IDByDateCenter(objbll);
    }

    internal void AddStudentAttendanceDataWeekly(StudentAttendanceDataDetail info)
    {
        objdal.AddStudentAttendanceDataWeekly(info);
    }

    internal DataTable CheckAttendanceAlreadyExist(int rollNumber, int year, int weekNo, int month, int sessionId)
    {
        return objdal.CheckAttendanceAlreadyExist(rollNumber, year, weekNo, month, sessionId);
    }

    internal void UpdateStudentAttendanceDataWeekly(StudentAttendanceDataDetail info)
    {
        objdal.UpdateStudentAttendanceDataWeekly(info);
    }

    internal string GetAttnType(int parm)
    {
        return objdal.GetAttnType(parm);
    }

    internal void UpdateStudentAttendanceDaily(StudentAttendanceDataDetail info)
    {
        objdal.UpdateStudentAttendanceDataDaily(info);
    }
    //public DataTable LibMembersSelectAll(BLLLibMembers objbll)
    //{
    //    return objdal.LibMembersSelectAll(objbll);
    //}
    //public DataTable LibMembersSelectAllByIsAcitve(BLLLibMembers objbll)
    //{
    //return objdal.LibMembersSelectAllByIsAcitve(objbll);
    //}
    //public DataTable LibMembersSelectByMember_ID(BLLLibMembers objbll)
    //{
    //    return objdal.LibMembersSelectByMember_ID(objbll);
    //}
    //public int LibMembersDelete(BLLLibMembers objbll)
    //{
    //    return objdal.LibMembersDelete(objbll);
    //}
    //public DataTable LibMembersSelectMaxMemberCode(BLLLibMembers objbll)
    //{
    //    return objdal.LibMembersSelectMaxMemberCode(objbll);
    //}
}
