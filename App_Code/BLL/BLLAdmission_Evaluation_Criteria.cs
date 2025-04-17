using System;
using System.Data;

/// <summary>
/// Summary description for BLLAdmission_Evaluation_Criteria
/// </summary>



public class BLLAdmission_Evaluation_Criteria
{
    public BLLAdmission_Evaluation_Criteria()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmission_Evaluation_Criteria objdal = new DALAdmission_Evaluation_Criteria();



    #region 'Start Properties Declaration'

    public int AEC_Id { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Class_Id { get; set; }
    public string Criteria { get; set; }
    public decimal Total_Marks { get; set; }
    public decimal? Weightage { get; set; }
    public int? Status_Id { get; set; }
    public int Session_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Admission_Evaluation_CriteriaAdd(BLLAdmission_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Evaluation_CriteriaAdd(_obj);
    }
    public int Admission_Evaluation_CriteriaUpdate(BLLAdmission_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Evaluation_CriteriaUpdate(_obj);
    }
    public int Admission_Evaluation_CriteriaDelete(BLLAdmission_Evaluation_Criteria _obj)
    {
      return objdal.Admission_Evaluation_CriteriaDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Admission_Evaluation_CriteriaFetch(BLLAdmission_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Evaluation_CriteriaSelect(_obj);
    }

    public DataTable Admission_Evaluation_CriteriaFetchByStatusID(BLLAdmission_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Evaluation_CriteriaSelectByStatusID(_obj);
    }

    #endregion

}
