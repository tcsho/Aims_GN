using System;
using System.Data;


/// <summary>
/// Summary description for BLLTCS_HlpDskComplaintBox
/// </summary>
public class BLLTCS_HlpDskComplaintBox
{
    _DALTCS_HlpDskComplaintBox objDAL = new _DALTCS_HlpDskComplaintBox();

    private int hDComplaint_ID;
    private int hDSubCat_ID;
    private string hDComplaintDesc;
    private int hD_Resource_ID;
    private int hD_Complaint_Status_ID;
    private int status_Id;
    private int priorityType_ID;
    private DateTime createdOn;
    private int createdBy;
    private DateTime modifiedOn;
    private int modifiedBy;
    private int region_ID;
    private int center_ID;

    private DateTime dueDate;
    private DateTime closeDate;
    private string complaintTitle;
    private string assignerRemarks;

    //Cluster_ID
    private int cluster_ID;


    public int HDComplaint_ID { get { return hDComplaint_ID; } set { hDComplaint_ID = value; } }
    public int HDSubCat_ID { get { return hDSubCat_ID; } set { hDSubCat_ID = value; } }
    public string HDComplaintDesc { get { return hDComplaintDesc; } set { hDComplaintDesc = value; } }
    public int HD_Resource_ID { get { return hD_Resource_ID; } set { hD_Resource_ID = value; } }
    public int HD_Complaint_Status_ID { get { return hD_Complaint_Status_ID; } set { hD_Complaint_Status_ID = value; } }
    public int Status_Id { get { return status_Id; } set { status_Id = value; } }
    public int PriorityType_ID { get { return priorityType_ID; } set { priorityType_ID = value; } }
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }
    public int Region_ID { get { return region_ID; } set { region_ID = value; } }
    public int Center_ID { get { return center_ID; } set { center_ID = value; } }

    public DateTime DueDate { get { return dueDate; } set { dueDate = value; } }
    public DateTime CloseDate { get { return closeDate; } set { closeDate = value; } }
    public string ComplaintTitle { get { return complaintTitle; } set { complaintTitle = value; } }
    public int Cluster_ID { get { return cluster_ID; } set { cluster_ID = value; } }

    public string AssignerRemarks { get { return assignerRemarks; } set { assignerRemarks = value; } }




    public DataTable TCS_HlpDskComplaintBoxSelectAll()
    {
        return objDAL.TCS_HlpDskComplaintBoxSelectAll();
    }

	public BLLTCS_HlpDskComplaintBox()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int TCS_HlpDskComplaintBoxInsert(BLLTCS_HlpDskComplaintBox objbll)
    {
        return objDAL.TCS_HlpDskComplaintBoxInsert(objbll);
    }

    public int TCS_HlpDskComplaintBoxUpdate(BLLTCS_HlpDskComplaintBox objbll)
    {
        return objDAL.TCS_HlpDskComplaintBoxUpdate(objbll);
    }

    public DataTable TCS_HlpDskComplaintBoxSelectById(BLLTCS_HlpDskComplaintBox objbll)
    {
        return objDAL.TCS_HlpDskComplaintBoxSelectById(objbll);
    }

    public int TCS_HlpDskComplaintBoxDelete(BLLTCS_HlpDskComplaintBox objbll)
    {
        return objDAL.TCS_HlpDskComplaintBoxDelete(objbll);
    }

    public DataTable TCS_HlpDskComplaintBoxSelectByCenterId(BLLTCS_HlpDskComplaintBox objbll)
    {
        return objDAL.TCS_HlpDskComplaintBoxSelectByCenterId(objbll);
    }

    public DataTable TCS_HlpDskComplaintBoxSelectResourceCenterIDROType(BLLTCS_HlpDskComplaintBox objbll)
    {
        return objDAL.TCS_HlpDskComplaintBoxSelectResourceCenterIDROType(objbll);
    }


    /*public DataTable TCS_HlpDskComplaintBoxSelectByCenterId(BLLTCS_HlpDskComplaintBox objbll)
    {
        return objDAL.TCS_HlpDskComplaintBoxSelectByCenterId(objbll);
    }*/

    public DataTable TCS_HlpDskComplaintBoxSelectByResourceID(BLLTCS_HlpDskComplaintBox objbll)
    {
        return objDAL.TCS_HlpDskComplaintBoxSelectByResourceID(objbll);
    }

    public int TCS_HlpDskComplaintBoxUpdateResource(BLLTCS_HlpDskComplaintBox objbll)
    {
        return objDAL.TCS_HlpDskComplaintBoxUpdateResource(objbll);
    }
}
