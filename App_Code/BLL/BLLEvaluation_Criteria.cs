using System;
using System.Data;


/// <summary>
/// Summary description for BLLEvaluation_Criteria
/// </summary>



public class BLLEvaluation_Criteria
    {
    public BLLEvaluation_Criteria()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALEvaluation_Criteria objdal = new DALEvaluation_Criteria();



    #region 'Start Properties Declaration'

    public int Evaluation_Criteria_Id { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Class_Id { get; set; }
    public string Criteria { get; set; }
    public decimal Total_Marks { get; set; }
    public decimal Weightage { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Evaluation_Type_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Evaluation_CriteriaAdd(BLLEvaluation_Criteria _obj)
        {
        return objdal.Evaluation_CriteriaAdd(_obj);
        }
    public int Evaluation_CriteriaUpdate(BLLEvaluation_Criteria _obj)
        {
        return objdal.Evaluation_CriteriaUpdate(_obj);
        }

    public int Evaluation_CriteriaApplyAllChangesUpdate(BLLEvaluation_Criteria _obj)
    {
        return objdal.Evaluation_CriteriaApplyAllChangesUpdate(_obj);
    }

    public int Evaluation_CriteriaDelete(BLLEvaluation_Criteria _obj)
        {
        return objdal.Evaluation_CriteriaDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Evaluation_CriteriaFetch(BLLEvaluation_Criteria _obj)
        {
        return objdal.Evaluation_CriteriaSelect(_obj);
        }

    public DataTable Evaluation_CriteriaFetchByStatusID(BLLEvaluation_Criteria _obj)
    {
        return objdal.Evaluation_CriteriaSelectByStatusID(_obj);
    }



    public DataTable Evaluation_CriteriaFetch(int _id)
      {
        return objdal.Evaluation_CriteriaSelect(_id);
      }


    public DataTable Evaluation_Criteria_SelectAllByClassSubjectEvlTypeId(BLLEvaluation_Criteria _obj)
    {
        return objdal.Evaluation_Criteria_SelectAllByClassSubjectEvlTypeId(_obj);
    }


    public DataTable Evaluation_Criteria_SelectAllByClassSubject(BLLEvaluation_Criteria _obj)
    {
        return objdal.Evaluation_Criteria_SelectAllByClassSubject(_obj);
    }
    public DataTable Evaluation_CriteriaSelectBYClassSubjectEvlID(BLLEvaluation_Criteria _obj)
    {
        return objdal.Evaluation_CriteriaSelectBYClassSubjectEvlID(_obj);
    }



    public DataTable Evaluation_Criteria_SelectAllByEvlCriteriaId(BLLEvaluation_Criteria _obj)
    {
        return objdal.Evaluation_Criteria_SelectAllByEvlCriteriaId(_obj);
    }


    public DataTable GetCurrentWeightagePercentage(BLLEvaluation_Criteria _obj)
    {
        return objdal.GetCurrentWeightagePercentage(_obj);
    }

    public DataTable GetCurrentWeightage(BLLEvaluation_Criteria _obj)
    {
        return objdal.GetCurrentWeightage(_obj);
    }
    #endregion

    }
