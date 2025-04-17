using System;
using System.Data;


/// <summary>
/// Summary description for BLLEvaluation_Criteria_Percentage
/// </summary>



public class BLLEvaluation_Criteria_Percentage
    {
    public BLLEvaluation_Criteria_Percentage()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALEvaluation_Criteria_Percentage objdal = new DALEvaluation_Criteria_Percentage();



    #region 'Start Properties Declaration'
    public int Evaluation_Criteria_Percentage_Id { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Evaluation_Type_Id { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Class_Id { get; set; }
 public int Region_Id { get; set; }
    public int Subject_Id { get; set; }
    public decimal Percentage { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Evaluation_Criteria_PercentageAdd(BLLEvaluation_Criteria_Percentage _obj)
        {
        return objdal.Evaluation_Criteria_PercentageAdd(_obj);
        }
    public int Evaluation_Criteria_PercentageUpdate(BLLEvaluation_Criteria_Percentage _obj)
        {
        return objdal.Evaluation_Criteria_PercentageUpdate(_obj);
        }

    public int Evaluation_Criteria_PercentageApplyAllChangesUpdate(BLLEvaluation_Criteria_Percentage _obj)
    {
        return objdal.Evaluation_Criteria_PercentageApplyAllChangesUpdate(_obj);
    }

    public int Evaluation_Criteria_PercentageDelete(BLLEvaluation_Criteria_Percentage _obj)
        {
        return objdal.Evaluation_Criteria_PercentageDelete(_obj);

        }

    

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Evaluation_Criteria_PercentageFetch(BLLEvaluation_Criteria_Percentage _obj)
        {
        return objdal.Evaluation_Criteria_PercentageSelect(_obj);
        }

    public DataTable Evaluation_Criteria_PercentageFetchByStatusID(BLLEvaluation_Criteria_Percentage _obj)
    {
        return objdal.Evaluation_Criteria_PercentageSelectByStatusID(_obj);
    }



    public DataTable Evaluation_Criteria_PercentageFetch(int _id)
      {
        return objdal.Evaluation_Criteria_PercentageSelect(_id);
      }

    //public DataTable Subject_ByOrgId(int _id)
    //{
    //    return objdal.Subject_ByOrgId(_id);
    //}

    public DataTable Class_SubjectSelectAllByClassId(BLLEvaluation_Criteria_Percentage _obj)
    {
        return objdal.Class_SubjectSelectAllByClassId(_obj);
    }


    public DataTable Evaluation_Criteria_PercentageSelectAllByClassIdSubjectId(BLLEvaluation_Criteria_Percentage _obj)
    {
        return objdal.Evaluation_Criteria_PercentageSelectAllByClassIdSubjectId(_obj);
    }


    public DataTable GetCurrentWeightagePercentage(BLLEvaluation_Criteria_Percentage _obj)
    {
        return objdal.GetCurrentWeightagePercentage(_obj);
    }


    public DataTable Evaluation_Criteria_PercentageSelectAllByClassIdSubjectIdEvlPerctId(BLLEvaluation_Criteria_Percentage _obj)
    {
        return objdal.Evaluation_Criteria_PercentageSelectAllByClassIdSubjectIdEvlPerctId(_obj);
    }

    public DataTable Evaluation_Criteria_PercentageSelectAllByEvlTypeId(BLLEvaluation_Criteria_Percentage _obj)
    {
        return objdal.Evaluation_Criteria_PercentageSelectAllByEvlTypeId(_obj);
    }

    #endregion

    }
