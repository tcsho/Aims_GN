using System;
using System.Data;


/// <summary>
/// Summary description for BLLStdAttnCalenderScreen
/// </summary>
public class BLLTCS_StdAttnCalenderHolidays
{
    _DALTCS_StdAttnCalenderHolidays objdal = new _DALTCS_StdAttnCalenderHolidays();


    public BLLTCS_StdAttnCalenderHolidays()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    private int call_ID;
    private string callDate;
    private string remarks;
    private string year;
    private int center_Id;
    private int calDayType_Id;
    private int region_Id;
    private int main_Organisation_Id;
    private int status_Id;
    private int createdBy;
    private DateTime createdOn;
    private int modifiedBy;
    private DateTime modifiedOn;

    public int Call_ID { get { return call_ID; } set { call_ID = value; } }
    public string CallDate { get { return callDate; } set { callDate = value; } }
    public string Remarks { get { return remarks; } set { remarks = value; } }
    public string Year { get { return year; } set { year= value; } }
    public int Center_Id { get { return center_Id; } set { center_Id = value; } }
    public int CalDayType_Id { get { return calDayType_Id; } set { calDayType_Id = value; } }
    public int Region_Id { get { return region_Id; } set { region_Id = value; } }
    public int Status_Id { get { return status_Id; } set { status_Id = value; } }
    public int Main_Organisation_Id { get { return main_Organisation_Id; } set { main_Organisation_Id = value; } }
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }

    public int TCS_StdAttnCalenderHolidaysInsert(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        return objdal.TCS_StdAttnCalenderHolidaysInsert(objbll);
    }

    public int TCS_StdAttnCalenderHolidaysUpdate(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        return objdal.TCS_StdAttnCalenderHolidaysUpdate(objbll);
    }

    public DataTable TCS_StdAttnCalenderHolidaysSelectAll(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        return objdal.TCS_StdAttnCalenderHolidaysSelectAll(objbll);
    }

    public DataTable TCS_StdAttnCalenderHolidaysSelectByCall_ID(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        return objdal.TCS_StdAttnCalenderHolidaysSelectByCall_ID(objbll);
    }

    public int TCS_StdAttnCalenderHolidaysDelete(BLLTCS_StdAttnCalenderHolidays objbll)
    {
        return objdal.TCS_StdAttnCalenderHolidaysDelete(objbll);
    }
}
