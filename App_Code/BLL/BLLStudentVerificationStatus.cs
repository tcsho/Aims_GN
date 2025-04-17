using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLStudentVerificationStatus
/// </summary>
public class BLLStudentVerificationStatus
{
    public BLLStudentVerificationStatus()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALStudent_Verification_Status objdal = new DALStudent_Verification_Status();

    #region 'Start Properties Declaration'

    public int Id { get; set; }
    public int? StudentId { get; set; }
    public string StudentName { get; set; }
    public int Student_Verification_Id { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public int SectionId { get; set; }
    public string SectionName { get; set; }
    public int CenterId { get; set; }
    public string CenterName { get; set; }
    public int RegionId { get; set; }
    public string RegionName { get; set; }
    public string Remarks { get; set; }
    public string PMonth { get; set; }
    public int StatusId { get; set; }
    public DateTime CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public string ModifiedBy { get; set; }
    public string Status { get; set; }
    public string Description { get; set; }
    public string ChangeMadeERP { get; set; }
    public string ClassSection { get; set; }
    public int SrNo { get; set; }
    public string TeacherRemraks { get; set; }
    public int? ClassTeacher_Id { get; set; }
    public string TeacherName { get; set; }
    public string CORemarks { get; set; }
    public string RORemarks { get; set; }

    #endregion

    public DataTable CenterWiseUnReconciledStudents(BLLStudentVerificationStatus _obj)
    {
        return objdal.CenterWiseUnReconciledStudents(_obj);
    }

    public DataTable CenterWiseUnidentifiedStudents(BLLStudentVerificationStatus _obj)
    {
        return objdal.CenterWiseUnidentifiedStudents(_obj);
    }

    public DataTable AddStudentVerificationRemarks(BLLStudentVerificationStatus _obj)
    {
        return objdal.AddStudentVerificationRemarks(_obj);
    }
}