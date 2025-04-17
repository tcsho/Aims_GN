using System;
using System.Data;

/// <summary>
/// Summary description for BLLAdmission_Registeration_Evaluation_Criteria
/// </summary>



public class BLLAdmission_Registeration_Evaluation_Criteria
{
    public BLLAdmission_Registeration_Evaluation_Criteria()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmission_Registeration_Evaluation_Criteria objdal = new DALAdmission_Registeration_Evaluation_Criteria();



    #region 'Start Properties Declaration'
    public int Center_Id { get; set; }
    public int Class_Id { get; set; }
    
    public int AREC_Id { get; set; }
    public int ACEC_Id { get; set; }
    public decimal Marks_Obtained { get; set; }
    public bool? Lock_Marks { get; set; }
    public int Status_Id { get; set; }
    public int Registeration_Id { get; set; }
    public int User_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Admission_Registeration_Evaluation_CriteriaAdd(BLLAdmission_Registeration_Evaluation_Criteria _obj,string s)
    {
        return objdal.Admission_Registeration_Evaluation_CriteriaAdd(_obj,s);
    }
    public int Admission_Registeration_Evaluation_CriteriaUpdate(BLLAdmission_Registeration_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Registeration_Evaluation_CriteriaUpdate(_obj);
    }
    public int Admission_Registeration_Evaluation_CriteriaDelete(BLLAdmission_Registeration_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Registeration_Evaluation_CriteriaDelete(_obj);

    }
    public int Admission_Registeration_ERPInsert(int id, string status, string detail, int user)
    {
        return objdal.Student_Registration_Result_ERPInsert(id, status, detail,user);

    }
    public int Admission_RegisterationTestMarksUpdate(BLLAdmission_Registeration_Evaluation_Criteria _obj)
    {
        return objdal.Admission_RegisterationTestMarksUpdate(_obj);
    }
    public int Admission_RegisterationTestSkipUrdu(BLLAdmission_Registeration_Evaluation_Criteria _obj)
    {
        return objdal.Admission_RegisterationTestSkipUrdu(_obj);
    }
    #endregion
    #region 'Start Fetch Methods'

   
    public DataTable Admission_Registeration_Evaluation_CriteriaFetch(BLLAdmission_Registeration_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Registeration_Evaluation_CriteriaSelect(_obj);
    }

    public DataTable Admission_Registeration_Evaluation_CriteriaFetchByStatusID(BLLAdmission_Registeration_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Registeration_Evaluation_CriteriaSelectByStatusID(_obj);
    }

    public DataTable Admission_Registeration_Evaluation_CriteriaEnglishPolicy(int _id)
    {
        return objdal.Admission_Registeration_Evaluation_CriteriaEnglishPolicy(_id);
    }
    public DataTable Admission_Registeration_Evaluation_CriteriaSciencePolicy(int _id)
    {
        return objdal.Admission_Registeration_Evaluation_CriteriaSciencePolicy(_id);
    }
    public DataTable Admission_Registeration_Evaluation_CriteriaOverallPolicy(int _id)
    {
        return objdal.Admission_Registeration_Evaluation_CriteriaOverallPolicy(_id);
    }
    public DataTable Admission_Registeration_AlevelRule3(int _id)
    {
        return objdal.Admission_Registeration_AlevelRule3(_id);
    }
    public DataTable Admission_Registeration_Evaluation_CriteriaFetch(int _id)
    {
        return objdal.Admission_Registeration_Evaluation_CriteriaSelect(_id);
    }


    #endregion

}
