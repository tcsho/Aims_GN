using System;
using System.Data;


/// <summary>
/// Summary description for BLLStudent
/// </summary>



public class BLLStudent
{
    public BLLStudent()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALStudent objdal = new DALStudent();



    #region 'Start Properties Declaration'
    public int Employee_Id { get; set; }
    public int? Student_Id { get; set; }
    public string Aims_Id { get; set; }
    public int Student_Status_Id { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Student_No { get; set; }
    public string First_Name { get; set; }
    public string Middle_Name { get; set; }
    public string Last_Name { get; set; }
    public DateTime Date_Of_Birth { get; set; }
    public string Address { get; set; }
    public string Telephone_No { get; set; }
    public int Gender_Id { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Postal_Code { get; set; }
    public string Comments { get; set; }
    public int Region_Id { get; set; }
    public int Center_Id { get; set; }
    public int Center_IdOld { get; set; }
    public int Grade_Id { get; set; }
    public DateTime Approval_Date { get; set; }
    public DateTime Application_Date { get; set; }
    public DateTime Transfer_Date { get; set; }
    public DateTime Drop_Date { get; set; }
    public string FatherEmail { get; set; }
    public int Student_noI { get; set; }
    public string fullname { get; set; }
    public int Class_ID { get; set; }
    public int Section_Id { get; set; }
    public int Session_Id { get; set; }
    public int Term_Id { get; set; }
    public int TermGroup_Id { get; set; }

    public int Subject_Id { get; set; }
    public bool IsGrace { get; set; }
    public int Student_Prom_Id { get; set; }
    public string section_name { get; set; }
    public int MonthId { get; set; }
    public string BranchPromotionRemarks { get; set; }
    public int Student_VerificationMst_Id { get; set; }
    public int Status_Id { get; set; }
    public int Student_Verification_Id  {get;set;}
    public string SchoolVerificationRemarks { get; set; }
    public string CORemarks { get; set; }
    public string ChangeMadeERP { get; set; }

    public bool IsAdded { get; set; }
    public bool IsVerify { get; set; }
    public int ModifiedBy { get; set; }

    public string TeacherRemarks { get; set; }
    public int AddReasonId { get; set; }

    public bool isDeleteRequest { get; set; }
    public bool isDeleted { get; set; }

    public int DeleteRequestBy { get; set; }
    public int DeletedBy { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int StudentAdd(BLLStudent _obj)
    {
        return objdal.StudentAdd(_obj);
    }
    public int StudentUpdate(BLLStudent _obj)
    {
        return objdal.StudentUpdate(_obj);
    }
    public int StudentDelete(BLLStudent _obj)
    {
        return objdal.StudentDelete(_obj);

    }
    public int StudentTransfer(BLLStudent _obj, string mode)
    {
        return objdal.StudentTransfer(_obj, mode);

    }
    public int StudentSectionChange(BLLStudent _obj)
    {
        return objdal.StudentSectionChange(_obj);

    }
    public int StudentUnassign(BLLStudent _obj)
    {
        return objdal.StudentUnassign(_obj);

    }
    public int StudentVerificationInsert(BLLStudent _obj)
    {
        return objdal.StudentVerificationInsert(_obj);

    }

    public int StudentVerificationUpdate(BLLStudent _obj)
    {
        return objdal.StudentVerificationUpdate(_obj);
    }

    public int StudentVerificationUpdateSchool(BLLStudent _obj)
    {
        return objdal.StudentVerificationUpdateSchool(_obj);
    }

    public int StudentVerificationDeleteRequestApproval(BLLStudent _obj)
    {
        return objdal.StudentVerificationDeleteRequestApproval(_obj);
    }

    public int StudentVerificationDeleteRequest(BLLStudent _obj)
    {
        return objdal.StudentVerificationDeleteRequest(_obj);
    }

    public int StudentVerificationMstInsert(BLLStudent _obj, bool flag)
    {
        return objdal.StudentVerificationMstInsert(_obj, flag);
    }


    #endregion
    #region 'Start Fetch Methods'

    public DataTable PendingStudentSectionTransferFetch(BLLStudent _obj)
    {
        return objdal.PendingStudentSectionTransferFetch(_obj);
    }
    public DataTable PendingStudentCenterTransferFetch(BLLStudent _obj)
    {
        return objdal.PendingStudentCenterTransferFetch(_obj);
    }

    public DataTable StudentFetch(BLLStudent _obj)
    {
        return objdal.StudentSelect(_obj);
    }

    public DataTable StudentFetchByStatusID(BLLStudent _obj)
    {
        return objdal.StudentSelectByStatusID(_obj);
    }

    public DataTable GetStudents_Unassigned(BLLStudent bllStd)
    {
        return objdal.GetStudents_Unassigned(bllStd);
    }

    public DataTable GetStudents_Assigned(BLLStudent bllStd)
    {
        return objdal.GetStudents_Assigned(bllStd);
    }

    public DataTable StudentFetch(int _id)
    {
        return objdal.StudentSelect(_id);
    }

    public DataTable StudentSelectByClassID(BLLStudent bllStd)
    {
        return objdal.StudentSelectByClassID(bllStd);
    }
    public DataTable StudentSelectBySectionID(BLLStudent bllStd)
    {
        return objdal.StudentSelectBySectionID(bllStd);
    }
    public DataTable StudentSelectBySection_IdForSubjectComments(BLLStudent bllStd)
    {
        return objdal.StudentSelectBySection_IdForSubjectComments(bllStd);
    }

    public DataTable StudentSelectBySection_IdForSubjectCommentsCorrection(BLLStudent bllStd)
    {
        return objdal.StudentSelectBySection_IdForSubjectCommentsCorrection(bllStd);
    }
    

    public DataTable StudentSelectBySection_IdForSubjectCommentsReview(BLLStudent bllStd)
    {
        return objdal.StudentSelectBySection_IdForSubjectCommentsReview(bllStd);
    }

    
    public DataTable StudentSelectByStudentID(BLLStudent bllStd)
    {
        return objdal.StudentSelectByStudentID(bllStd);
    }
    public DataTable StudentSelectBySectionIDTerm(BLLStudent bllStd)
    {
        return objdal.StudentSelectBySectionIDTerm(bllStd);
    }

    public DataTable StudentSelectWelcomeByClassID(BLLStudent bllStd)
    {
        return objdal.StudentSelectWelcomeByClassID(bllStd);
    }
    public DataTable SelectStudentsByPerformanceDeclineEmail(BLLStudent bllStd)
    {
        return objdal.SelectStudentsByPerformanceDeclineEmail(bllStd);
    }
    public DataTable SelectStudentsByParentsEmail(BLLStudent bllStd)
    {
        return objdal.SelectStudentsByParentsEmail(bllStd);
    }
    public int Student_Evaluation_Criteria_GraceMarksUpdate(BLLStudent bllStd)
    {
        return objdal.Student_Evaluation_Criteria_GraceMarksUpdate(bllStd);
    }
    public DataTable SelectStudent_Evaluation_Criteria_GraceMarks(BLLStudent bllStd)
    {
        return objdal.SelectStudent_Evaluation_Criteria_GraceMarks(bllStd);
    }

    public DataSet Student_VerificatioSelectDS(BLLStudent bllStd)
    {
        return objdal.Student_VerificatioSelectDS(bllStd);
    }
    public DataTable Student_VerificatioSelect(BLLStudent bllStd)
    {
        return objdal.Student_VerificatioSelect(bllStd);
    }
    public DataTable StudentVerificationMonth(BLLStudent _obj)
    {
        return objdal.StudentVerificationMonthSelect(_obj);

    }

    public DataTable StudentVerificationReasonSelect(BLLStudent _obj)
    {
        return objdal.StudentVerificationReasonSelect(_obj);

    }
    
    #endregion 
}
