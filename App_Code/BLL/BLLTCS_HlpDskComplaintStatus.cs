using System;
using System.Data;


/// <summary>
/// Summary description for BLLTCS_HlpDskComplaintStatus
/// </summary>
public class BLLTCS_HlpDskComplaintStatus
{
    _DALTCS_HlpDskComplaintStatus objDAL = new _DALTCS_HlpDskComplaintStatus();

    private int status_Id;

    public int Status_Id
    {
        get { return status_Id; }
        set { status_Id = value; }
    }
    private string status;

    public string Status
    {
        get { return status; }
        set { status = value; }
    }

    public DataTable TCS_HlpDskComplaintStatusSelectAll()
    {
        return objDAL.TCS_HlpDskComplaintStatusSelectAll();
    }

	public BLLTCS_HlpDskComplaintStatus()
	{
		//
		// TODO: Add constructor logic here
		//
	}
}
