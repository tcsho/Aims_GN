using System;
using System.Data;

/// <summary>
/// Summary description for BLLAdmission_Center_Evaluation_Criteria
/// </summary>



public class BLLAdmission_Center_Evaluation_Criteria
{
    public BLLAdmission_Center_Evaluation_Criteria()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmission_Center_Evaluation_Criteria objdal = new DALAdmission_Center_Evaluation_Criteria();



    #region 'Start Properties Declaration'

    public int ACEC_Id { get; set; }
    public int AEC_Id { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Class_Id { get; set; }
    public string Criteria { get; set; }
    public Decimal Total_Marks { get; set; }
    public Decimal? Weightage { get; set; }
    public int? Status_Id { get; set; }
    public int Session_Id { get; set; }
    public int Center_Id { get; set; }
    public int Registeration_Id { get; set; }
    public int TestType_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Admission_Center_Evaluation_CriteriaAdd(BLLAdmission_Center_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Center_Evaluation_CriteriaAdd(_obj);
    }
    public int Admission_Center_Evaluation_CriteriaUpdate(BLLAdmission_Center_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Center_Evaluation_CriteriaUpdate(_obj);
    }
    public int Admission_Center_Evaluation_CriteriaDelete(BLLAdmission_Center_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Center_Evaluation_CriteriaDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Admission_Center_Evaluation_CriteriaFetch(BLLAdmission_Center_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Center_Evaluation_CriteriaSelect(_obj);
    }

    public DataTable Admission_Center_Evaluation_CriteriaSelectByCenterId(BLLAdmission_Center_Evaluation_Criteria _obj)
    {
        return objdal.Admission_Center_Evaluation_CriteriaSelectByCenterId(_obj);
    }



    public DataTable Admission_Center_Evaluation_CriteriaSelectACEC(BLLAdmission_Center_Evaluation_Criteria _id)
    {
        return objdal.Admission_Center_Evaluation_CriteriaSelectACEC(_id);
    }

    public DataTable Admission_Center_Evaluation_CriteriaSelectAllCenters(BLLAdmission_Center_Evaluation_Criteria _id)
    {
        return objdal.Admission_Center_Evaluation_CriteriaSelectAllCenters(_id);
    }


    #endregion

}
