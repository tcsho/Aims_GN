using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for BLLStudent_Missing_Exam
/// </summary>



public class BLLStudent_Missing_Exam
{
    public BLLStudent_Missing_Exam()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALStudent_Missing_Exam objdal = new DALStudent_Missing_Exam();



    #region 'Start Properties Declaration'

    public int Student_Missing_Exam_Id { get; set; }
    public int Student_Id { get; set; }
    public int Region_Id { get; set; }
    public int Center_Id { get; set; }
    public int Evaluation_Type_Id { get; set; }
    public string Student_Name { get; set; }
    public int Class_Id { get; set; }
    public string Class_Name { get; set; }
    public int Section_Id { get; set; }
    public string Section_Name { get; set; }
    public int Session_Id { get; set; }
    public int Subject_Id { get; set; }
    public string Subject_Name { get; set; }
    public int TermGroup_Id { get; set; }
    public int SAbsent_Id { get; set; }
    public bool? IsMissingCoursework { get; set; }
    public bool? IsMissingExam { get; set; }
    public int SDash_Id { get; set; }

    public int Evaluation_Criteria_Id { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int Student_Missing_ExamAdd(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Student_Missing_ExamAdd(_obj);
    }
    public int Student_MissingExamOAAdd(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Student_MissingExamOAAdd(_obj);
    }
    public int Student_Missing_ExamUpdate(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Student_Missing_ExamUpdate(_obj);
    }
    public int Student_Missing_ExamDelete(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Student_Missing_ExamDelete(_obj);

    }
    public int Student_MissingExamOADelete(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Student_MissingExamOADelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Missing_ExamFetch(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Student_Missing_ExamSelect(_obj);
    }

    public DataTable Student_Missing_ExamFetchByStatusID(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Student_Missing_ExamSelectByStatusID(_obj);
    }

    public DataTable Evaluation_Criteria_TypeSelectByStudentId(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Evaluation_Criteria_TypeSelectByStudentId(_obj);
    }


    public DataTable Student_SelectAllByStudentNoForStudentMissingExam(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Student_SelectAllByStudentNoForStudentMissingExam(_obj);
    }

    public DataTable Student_MissingExamOASelectAll(BLLStudent_Missing_Exam _obj)
    {
        return objdal.Student_MissingExamOASelectAll(_obj);
    }



    public DataTable Student_Missing_ExamFetch(int _id)
    {
        return objdal.Student_Missing_ExamSelect(_id);
    }


    #endregion

}
