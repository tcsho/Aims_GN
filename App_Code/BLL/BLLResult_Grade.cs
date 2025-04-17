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
/// Summary description for BLLResult_Grade
/// </summary>



public class BLLResult_Grade
{
    public BLLResult_Grade()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALResult_Grade objdal = new DALResult_Grade();



    #region 'Start Properties Declaration'

    public int Result_Grade_Id { get; set; }
    public string Grade { get; set; }
    public decimal Upper_Limit { get; set; }
    public decimal Lower_Limit { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Class_Id { get; set; }
    public decimal KPI { get; set; }

    public int User_Id { get; set; }
    public int Center_Id { get; set; }
    public int Session_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int Section_Id { get; set; }
    public string lstSection_Id { get; set; }
    public int Region_Id { get; set; }
    public int Student_Id { get; set; }
    public int Evaluation_Type_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Result_GradeAdd(BLLResult_Grade _obj)
    {
        return objdal.Result_GradeAdd(_obj);
    }
    public int Result_GradeUpdate(BLLResult_Grade _obj)
    {
        return objdal.Result_GradeUpdate(_obj);
    }
    public int Result_GradeDelete(BLLResult_Grade _obj)
    {
        return objdal.Result_GradeDelete(_obj);

    }
    
    public int MarksLockUnlockCompileLog_Insert(BLLResult_Grade _obj)
    {
        return objdal.MarksLockUnlockCompileLog_Insert(_obj);

    }


    public int Result_GradeUnlockedSectionsBySection_Id(BLLResult_Grade _obj, bool flag)
    {
        return objdal.Result_GradeUnlockedSectionsBySection_Id(_obj, flag);

    }
    #endregion
    #region 'Start Fetch Methods'

    public DataTable _AimsMarkslockUnlock(BLLResult_Grade obj)
    {
        return objdal._AimsMarkslockUnlock(obj);
    }
    public DataTable Result_Grade_AimsResultCompileStatus(BLLResult_Grade obj)
    {
        return objdal.Result_Grade_AimsResultCompileStatus(obj);
    }
    public DataTable Result_GradeFetch(BLLResult_Grade _obj)
    {
        return objdal.Result_GradeSelect(_obj);
    }

    public DataTable StudentResultMarksViewbyStudentId(BLLResult_Grade _obj)
    {
        return objdal.StudentResultMarksViewbyStudentId(_obj);
    }


    public DataTable Result_GradeSelectAllWithoutClassId(BLLResult_Grade _obj)
    {
        return objdal.Result_GradeSelectAllWithoutClassId(_obj);
    }


    public DataTable Result_GradeFetchByStatusID(BLLResult_Grade _obj)
    {
        return objdal.Result_GradeSelectByStatusID(_obj);
    }

    public DataTable Result_GradeFetch(int _id)
    {
        return objdal.Result_GradeSelect(_id);
    }


    //public DataTable ClassByOrgId(int _id)
    //{
    //    return objdal.ClassByOrgId(_id);
    //}

    public DataTable Class_SelectByOrgId(BLLResult_Grade _obj)
    {
        return objdal.Class_SelectByOrgId(_obj);
    }



    public DataTable Result_GradeSelectAll(BLLResult_Grade _obj)
    {
        return objdal.Result_GradeSelectAll(_obj);
    }

    public int TCS_Result_GenerateResultAllByCenter_Id(BLLResult_Grade _obj)
    {
        return objdal.TCS_Result_GenerateResultAllByCenter_Id(_obj);
    }

    public int TCS_Result_GenerateResultAllBySection_Id(BLLResult_Grade _obj)
    {
        return objdal.TCS_Result_GenerateResultAllBySection_Id(_obj);
    }

    public int TCS_Result_GenerateResultAllBySection_Id_New(BLLResult_Grade _obj)
    {
        return objdal.TCS_Result_GenerateResultAllBySection_Id_New(_obj);
    }

    public int TCS_Assign_Student_By_Subject_Id(BLLResult_Grade _obj)

    {

        return objdal.TCS_Assign_Student_By_Subject_Id(_obj);

    }

    public int TCS_Assign_Student_By_Update_Subject_Id(BLLResult_Grade _obj)

    {

        return objdal.TCS_Assign_Student_By_Update_Subject_Id(_obj);

    }
    public DataTable HO_ResultCompilationRegionalComparisonClassWise(BLLResult_Grade _obj)
    {
        return objdal.HO_ResultCompilationRegionalComparisonClassWise(_obj);
    }

    public DataTable HO_PromotionalRegionalComparisonClassWise(BLLResult_Grade _obj)
    {
        return objdal.HO_PromotionalRegionalComparisonClassWise(_obj);
    }


    public DataTable Result_GradeSelectAllByResultGradeId(BLLResult_Grade _obj)
    {
        return objdal.Result_GradeSelectAllByResultGradeId(_obj);
    }


    public DataTable Result_GradeSelectAllByGradeDescription(BLLResult_Grade _obj)
    {
        return objdal.Result_GradeSelectAllByGradeDescription(_obj);
    }

    #endregion

}
