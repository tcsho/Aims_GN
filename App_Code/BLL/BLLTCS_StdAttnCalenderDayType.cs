using System;
using System.Data;


/// <summary>
/// Summary description for BLLStdAttnCalenderDayType
/// </summary>
public class BLLTCS_StdAttnCalenderDayType
{
    _DALTCS_StdAttnCalenderDayType objdal = new _DALTCS_StdAttnCalenderDayType();

    public BLLTCS_StdAttnCalenderDayType()
    {
        //
        // TODO: Add constructor logic here
        //
    }



    public int CalDayType_Id { get { return calDayType_Id; } set { calDayType_Id = value; } }	private int calDayType_Id;
    public string CalTypeDesc { get { return calTypeDesc; } set { calTypeDesc = value; } }	private string calTypeDesc;
    public int Status_Id { get { return status_Id; } set { status_Id = value; } }	private int status_Id;
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }	private int createdBy;
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }	private DateTime createdOn;
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }	private int modifiedBy;
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }	private DateTime modifiedOn;




    public int TCS_StdAttnCalenderDayTypeInsert(BLLTCS_StdAttnCalenderDayType objbll)
    {
        return objdal.TCS_StdAttnCalenderDayTypeInsert(objbll);
    }
    public int TCS_StdAttnCalenderDayTypeUpdate(BLLTCS_StdAttnCalenderDayType objbll)
    {
        return objdal.TCS_StdAttnCalenderDayTypeUpdate(objbll);
    }
    public DataTable TCS_StdAttnCalenderDayTypeSelectAll()
    {
        return objdal.TCS_StdAttnCalenderDayTypeSelectAll();
    }
    public DataTable TCS_StdAttnCalenderDayTypeSelectByCalDayType_Id(BLLTCS_StdAttnCalenderDayType objbll)
    {
        return objdal.TCS_StdAttnCalenderDayTypeSelectByCalDayType_Id(objbll);
    }
    public int TCS_StdAttnCalenderDayTypeDelete(BLLTCS_StdAttnCalenderDayType objbll)
    {
        return objdal.TCS_StdAttnCalenderDayTypeDelete(objbll);
    }
}
