using System;
using System.Data;


/// <summary>
/// Summary description for BLLStdAttnType
/// </summary>
public class BLLTCS_StdAttnType
{
    _DALTCS_StdAttnType objdal = new _DALTCS_StdAttnType();

    public BLLTCS_StdAttnType()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int AttnType_ID { get { return attnType_ID; } set { attnType_ID = value; } }	private int attnType_ID;
    public string AttnDesc { get { return attnDesc; } set { attnDesc = value; } }	private string attnDesc;
    public int Status_Id { get { return status_Id; } set { status_Id = value; } }	private int status_Id;
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }	private int createdBy;
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }	private DateTime createdOn;
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }	private int modifiedBy;
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }	private DateTime modifiedOn;
    public string AttCode { get; set; }

    internal DataTable GetSectionClassByTeacher(int teacherId)
    {
        return objdal.GetSectionClassByTeacher(teacherId);
    }

    public int TCS_StdAttnTypeInsert(BLLTCS_StdAttnType objbll)
    {
        return objdal.TCS_StdAttnTypeInsert(objbll);
    }
    public int TCS_StdAttnTypeUpdate(BLLTCS_StdAttnType objbll)
    {
        return objdal.TCS_StdAttnTypeUpdate(objbll);
    }
    public DataTable TCS_StdAttnTypeSelectAll()
    {
        return objdal.TCS_StdAttnTypeSelectAll();
    }
    public DataTable TCS_StdAttnTypeSelectByAttnType_ID(BLLTCS_StdAttnType objbll)
    {
        return objdal.TCS_StdAttnTypeSelectByAttnType_ID(objbll);
    }
    public int TCS_StdAttnTypeDelete(BLLTCS_StdAttnType objbll)
    {
        return objdal.TCS_StdAttnTypeDelete(objbll);
    }
}
