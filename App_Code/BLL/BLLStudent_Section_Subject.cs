using System;
using System.Data;


/// <summary>
/// Summary description for BLLStudent_Section_Subject
/// </summary>



public class BLLStudent_Section_Subject
    {
    public BLLStudent_Section_Subject()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Section_Subject objdal = new DALStudent_Section_Subject();



    #region 'Start Properties Declaration'

    public int Student_Section_Subject_Id { get; set; }
    public int Student_Id { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Session_Id { get; set; }
    public bool isAssignedToWrk { get; set; }
    public int Student_Status_Id { get; set; }
    public int Main_Organisation_id { get; set; }
    public int Section_Id { get; set; }
    

    public int Evaluation_Criteria_Type_Id { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int Student_Section_SubjectAdd(BLLStudent_Section_Subject _obj)
    {
        return objdal.Student_Section_SubjectAdd(_obj);
    }


    public int Student_Secttion_Subject_UnAssign(BLLStudent_Section_Subject _obj)
    {
        return objdal.Student_Secttion_Subject_UnAssign(_obj);
    }
    public int Student_Secttion_Subject_AssignUpdate(BLLStudent_Section_Subject _obj)
    {
        return objdal.Student_Secttion_Subject_AssignUpdate(_obj);
    }
    public int Student_Section_SubjectDelete(BLLStudent_Section_Subject _obj)
    {
        return objdal.Student_Section_SubjectDelete(_obj);

    }
    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Section_SubjectFetch(BLLStudent_Section_Subject _obj)
        {
        return objdal.Student_Section_SubjectSelect(_obj);
        }

    public DataTable Student_Section_SubjectFetchByStatusID(BLLStudent_Section_Subject _obj)
    {
        return objdal.Student_Section_SubjectSelectByStatusID(_obj);
    }
    public DataTable Student_Section_SubjectFetchBySectionID(BLLStudent_Section_Subject _obj)
    {
        return objdal.Student_Section_SubjectSelectBySectionID(_obj);
    }

    public DataTable Student_Section_SubjectSelectBySessionSectionID(BLLStudent_Section_Subject _obj)
    {
        return objdal.Student_Section_SubjectSelectBySessionSectionID(_obj);
    }

    
    public DataTable student_section_subjectSelectBySectionSubjectStudent_Id(BLLStudent_Section_Subject _obj)
    {
        return objdal.student_section_subjectSelectBySectionSubjectStudent_Id(_obj);
    }

    public DataTable StudentByCenterEvaluationId(BLLStudent_Section_Subject _obj)
    {
        return objdal.StudentByCenterEvaluationId(_obj);
    }
    

    public DataTable Student_Section_SubjectFetch(int _id)
      {
        return objdal.Student_Section_SubjectSelect(_id);
      }
    public DataTable student_section_subjectSelectBySectionStudent_Id(BLLStudent_Section_Subject _obj)
    {
        return objdal.student_section_subjectSelectBySectionStudent_Id(_obj);
    }


    public DataTable Student_Section_SubjectSelectStudentWorkSpace(BLLStudent_Section_Subject _obj)
    {
        return objdal.Student_Section_SubjectSelectStudentWorkSpace(_obj);
    }



    #endregion

    }
