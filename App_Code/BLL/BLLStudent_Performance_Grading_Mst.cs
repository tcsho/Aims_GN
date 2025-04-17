using System;
using System.Data;


/// <summary>
/// Summary description for BLLStudent_Performance_Grading_Mst
/// </summary>



public class BLLStudent_Performance_Grading_Mst
    {
    public BLLStudent_Performance_Grading_Mst()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Performance_Grading_Mst objdal = new DALStudent_Performance_Grading_Mst();



    #region 'Start Properties Declaration'

    public int KindSubStdMst_Id { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Student_Id { get; set; }
    public string IslamyatComments { get; set; }
    public decimal ICTPercentage { get; set; }
    public string ICTRemarks { get; set; }
    public string ClassTeacherComments { get; set; }
    public bool isPromoted { get; set; }
    public int PromotedTo { get; set; }
    public int Main_Organistion_Id { get; set; }
    public int Status_Id { get; set; }
    public string WorkingDays { get; set; }
    public string DaysAttend { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public int Section_subject_Id { get; set; }
    public DateTime JoiningDate { get; set; }
    public int Session_Id { get; set; }
    public int Section_Id { get; set; }
    public int Employee_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public string DatSet {get;set; }
    public int Center_Id { get; set; }
    public int Grade_Id { get; set; } 
    #endregion

    #region 'Start Executaion Methods'

    public int Student_Performance_Grading_MstAdd(BLLStudent_Performance_Grading_Mst _obj)
        {
        return objdal.Student_Performance_Grading_MstAdd(_obj);
        }
    public int Student_Performance_Grading_MstUpdate(BLLStudent_Performance_Grading_Mst _obj)
        {
        return objdal.Student_Performance_Grading_MstUpdate(_obj);
        }

    public int Student_Performance_Grading_MstUpdateMarks(BLLStudent_Performance_Grading_Mst _obj)
        {
            return objdal.Student_Performance_Grading_MstUpdateMarks(_obj);
        }

    public int Student_Performance_Grading_MstUpdateLetterOfUndertakingAcknowledge(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstUpdateLetterOfUndertakingAcknowledge(_obj);
    }



    public int Student_Performance_Grading_MstAddAttenDaysComments(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstAddAttenDaysComments(_obj);
    }

    public int Student_Performance_Grading_MstAddAttenDaysCommentsNew(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstAddAttenDaysCommentsNew(_obj);
    }


    public int Student_Performance_Grading_MstUpdatePromotion_3_6(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstUpdatePromotion_3_6(_obj);
    }

    public int Student_Performance_Grading_MstUpdatePromotion_7(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstUpdatePromotion_7(_obj);
    }

    public int Student_Performance_Grading_MstUpdatePromotion_8(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstUpdatePromotion_8(_obj);
    }

    public int Student_Performance_Grading_MstUpdatePromotion_9(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstUpdatePromotion_9(_obj);
    }

    public int Student_Performance_Grading_MstUpdatePromotion_10(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstUpdatePromotion_10(_obj);
    }

    public int Student_Performance_Grading_MstUpdatePromotion_11(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstUpdatePromotion_11(_obj);
    }
    public int Student_Performance_Grading_MstUpdatePromotion_AS(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstUpdatePromotion_AS(_obj);
    }


    public int Student_Performance_Grading_MstDelete(BLLStudent_Performance_Grading_Mst _obj)
        {
        return objdal.Student_Performance_Grading_MstDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Performance_Grading_MstFetch(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstSelect(_obj);
    }

    public DataTable Student_Performance_Grading_MstSelectAllClass(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstSelectAllClass(_obj);
    }
    public DataTable Student_Performance_Grading_MstFetchByStudent(BLLStudent_Performance_Grading_Mst _obj)
        {
            return objdal.Student_Performance_Grading_MstSelectByStudent(_obj);
        }
    public DataTable Student_Performance_Grading_MstFetchByStudentSection(BLLStudent_Performance_Grading_Mst _obj)
        {
            return objdal.Student_Performance_Grading_MstSelectByStudentSection(_obj);
        }
    public DataTable Student_Performance_Grading_MstFetchByStudentSectionNew(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstSelectByStudentSectionNew(_obj);
    }
        
    
    public DataTable Student_Performance_Grading_MstFetchByStatusID(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstSelectByStatusID(_obj);
    }



    public DataTable Student_Performance_Grading_MstLetterOfUndertakingAcknowledge(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstLetterOfUndertakingAcknowledge(_obj);
    }



    public DataTable Student_Performance_Grading_MstLetterOfUndTkCheck(BLLStudent_Performance_Grading_Mst _obj)
    {
        return objdal.Student_Performance_Grading_MstLetterOfUndTkCheck(_obj);
    }

    public DataTable Student_Performance_Grading_MstFetch(int _id)
      {
        return objdal.Student_Performance_Grading_MstSelect(_id);
      }


    #endregion

    }
