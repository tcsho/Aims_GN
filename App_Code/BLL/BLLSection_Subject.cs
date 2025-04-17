using System;
using System.Data;


/// <summary>
/// Summary description for BLLSection_Subject
/// </summary>



public class BLLSection_Subject
    {
    public BLLSection_Subject()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSection_Subject objdal = new DALSection_Subject();



    #region 'Start Properties Declaration'

    public int Section_Subject_Id { get; set; }
    public int Section_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Session_Id { get; set; }
    public int Employee_Id { get; set; }
    public int AlreadyIn { get; set; }
    public int Center_Id { get; set; }
    public int @Org_Id { get; set; }
    public int @Class_Id { get; set; }

    public int Student_Id { get; set; }



    public string Title { get; set; }
    public string Description { get; set; }
    public string SpecialInstructions { get; set; }



    public int Evaluation_Criteria_Type_Id { get; set; }

    public int Evaluation_Type_Id { get; set; }
   


    #endregion

    #region 'Start Executaion Methods'

    public int Section_SubjectAdd(BLLSection_Subject _obj)
        {
        return objdal.Section_SubjectAdd(_obj);
        }
    public int Section_SubjectUpdate(BLLSection_Subject _obj)
        {
        return objdal.Section_SubjectUpdate(_obj);
        }
    public int Section_SubjectDelete(BLLSection_Subject _obj)
        {
        return objdal.Section_SubjectDelete(_obj);

        }

    public int Section_SubjectWorkSiteUpdate(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectWorkSiteUpdate(_obj);
    }


    #endregion
    #region 'Start Fetch Methods'


    public DataTable Section_SubjectFetch(BLLSection_Subject _obj)
        {
        return objdal.Section_SubjectSelect(_obj);
        }

    public DataTable Section_SubjectFetchByStatusID(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectByStatusID(_obj);
    }


    public DataTable Section_SubjectByEmployeeIdSectionId(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectByEmployeeIdSectionId(_obj);
    }

    public DataTable Section_SubjectSelectSubjectBySectionId(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectSubjectBySectionId(_obj);
    }

    public DataTable Section_SubjectSelectSubjectBySectionIdSubjectId(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectSubjectBySectionIdSubjectId(_obj);
    }

    public DataTable GetStudents_AssignedForSubjectWiseAllocation(BLLSection_Subject _obj)
    {
        return objdal.GetStudents_AssignedForSubjectWiseAllocation(_obj);
    }

    public DataTable Section_SubjectByEmployeeIdSessionSectionId(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectByEmployeeIdSessionSectionId(_obj);
    }
    

    public DataTable Evaluation_Criteria_TypeByClassId(BLLSection_Subject _obj)
    {
        return objdal.Evaluation_Criteria_TypeByClassId(_obj);
    }
    public DataTable Evaluation_Criteria_TypeBySectionId(BLLSection_Subject _obj)
    {
        return objdal.Evaluation_Criteria_TypeBySectionId(_obj);
    }

    public DataTable Evaluation_Criteria_BySectionIdSubjectEvlId(BLLSection_Subject _obj)
    {
        return objdal.Evaluation_Criteria_BySectionIdSubjectEvlId(_obj);
    }

    public DataTable Evaluation_TypeSelect(int _id)
    {
        return objdal.Evaluation_TypeSelect(_id);
    }

    public DataTable Section_SubjectFetch(int _id)
      {
        return objdal.Section_SubjectSelect(_id);
      }
    public DataTable Section_SubjectSelectBySectionTeacherPerformance(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectBySectionTeacherPerformance(_obj);
    }

    public DataTable Section_SubjectSelectBySectionTeacherActivity(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectBySectionTeacherActivity(_obj);
    }

    public DataTable Section_SubjectSelectBySectionTeacherEvaluation(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectBySectionTeacherEvaluation(_obj);
    }

    public DataTable SectionSubjectSelectWithoutEvaluationCriteria(BLLSection_Subject _obj)
    {
        return objdal.SectionSubjectSelectWithoutEvaluationCriteria(_obj);
    }


    public DataTable Section_SubjectSelectTeacherByCenter_Id(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectTeacherByCenter_Id(_obj);
    }

public DataTable Techer_SubjectSelectByClassId(BLLSection_Subject _obj)
    {
        return objdal.Techer_SubjectSelectByClassId(_obj);
    }

    public DataTable Section_SubjectSelectWorkSiteBySection_Id(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectWorkSiteBySection_Id(_obj);
    }


    public DataTable Section_SubjectSelectWorkSiteALLBySection_Id(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectWorkSiteALLBySection_Id(_obj);
    }


    public DataTable Section_SubjectSelectWorkSiteBySection_Subject_Id(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectWorkSiteBySection_Subject_Id(_obj);
    }


    public DataTable Section_SubjectSelectTeacherWorkSpace(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectTeacherWorkSpace(_obj);
    }


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherId(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllWorkSiteByTeacherId(_obj);
    }

    public DataTable Section_SubjectSelectAllWorkSiteByStudentId(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllWorkSiteByStudentId(_obj);
    }


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForAnnouncement(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllWorkSiteByTeacherIdForAnnouncement(_obj);
    }


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForNews(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllWorkSiteByTeacherIdForNews(_obj);
    }


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForPolls(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllWorkSiteByTeacherIdForPolls(_obj);
    }


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForResources(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllWorkSiteByTeacherIdForResources(_obj);
    }


    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdForDropBox(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllWorkSiteByTeacherIdForDropBox(_obj);
    }

    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdSectionSubIdForResources(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllWorkSiteByTeacherIdSectionSubIdForResources(_obj);
    }

    public DataTable Section_SubjectSelectAllWorkSiteByTeacherIdSectionSubIdForDropBox(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllWorkSiteByTeacherIdSectionSubIdForDropBox(_obj);
    }


    public DataTable Section_SubjectSelectAllStudentByTeacherIdForDropBox(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectAllStudentByTeacherIdForDropBox(_obj);
    }



    public DataTable Section_SubjectSelectWorkSiteByTeacherIdSSIDForAnnouncement(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectWorkSiteByTeacherIdSSIDForAnnouncement(_obj);
    }


    public DataTable Section_SubjectSelectWorkSiteByTeacherIdSSIDForNews(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectWorkSiteByTeacherIdSSIDForNews(_obj);
    }


    public DataTable Section_SubjectSelectWorkSiteByTeacherIdSSIDForPolls(BLLSection_Subject _obj)
    {
        return objdal.Section_SubjectSelectWorkSiteByTeacherIdSSIDForPolls(_obj);
    }




    public DataTable StudentBySectionSubjectId(int _id)
    {
        return objdal.StudentBySectionSubjectId(_id);
    }
    #endregion

    }
