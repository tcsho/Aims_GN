using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLNonCompliantTeacher
/// </summary>
public class BLLNonCompliantTeacher
{
    public BLLNonCompliantTeacher()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALNonCompliantTeacher objdal = new DALNonCompliantTeacher();

    #region 'Start Properties Declaration'

    public int Id { get; set; }
    public int? TeacherId { get; set; }
    public string TeacherName { get; set; }
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
    public string CORemarks { get; set; }
    public string RORemarks { get; set; }
    #endregion

    public DataTable AddNonCompliantTeachersRemarks(BLLNonCompliantTeacher _obj)
    {
        return objdal.AddStudentVerificationRemarks(_obj);
    }

    public DataTable CenterWiseNonCompliantTeachers(BLLNonCompliantTeacher _obj)
    {
        return objdal.CenterWiseNonCompliantTeachers(_obj);
    }
}