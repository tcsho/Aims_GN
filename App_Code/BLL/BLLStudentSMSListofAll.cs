using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for BLLLmsMsgPriorityType
/// </summary>
public class BLLStudentSMSListofAll
{

    _DALStudentSMSListofAll objdal = new _DALStudentSMSListofAll();

	public BLLStudentSMSListofAll()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public long Region_Id { get; set; }
    public string Region_Name { get; set; }
    public long Center_Id { get; set; }
    public string Center_Name { get; set; }
    public long Class_Id { get; set; }
    public string Class_Name { get; set; }
    public int Section_Id { get; set; }
    public string Section_Name { get; set; }
    public int Student_Id { get; set; }
    public string fullname { get; set; }
    public bool isFeeDefaulter { get; set; }
    public int Subjects { get; set; }
    public int Absents { get; set; }
    public string StudentStatus { get; set; }
    public string MobileNo { get; set; }
    public string SMS { get; set; }
    public int isSMSSent { get; set; }
    public string URL { get; set; }
    public int Records { get; set; }
    public DateTime SMSDate { get; set; }
    public string FatherEmail { get; set; }
    public int Session_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public string Reason { get; set; }
    public string FeeDefaulter { get; set; }
    public string SMSSent { get; set; }

    public DataTable StudentSMSListofAll(BLLStudentSMSListofAll obj)
    {
        return objdal.StudentSMSListofAll(obj);
    }
}
