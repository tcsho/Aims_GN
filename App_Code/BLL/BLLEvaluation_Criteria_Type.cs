using System;
using System.Data;


/// <summary>
/// Summary description for BLLEvaluation_Criteria_Type
/// </summary>



public class BLLEvaluation_Criteria_Type
    {
    public BLLEvaluation_Criteria_Type()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALEvaluation_Criteria_Type objdal = new DALEvaluation_Criteria_Type();



    #region 'Start Properties Declaration'

    public int Evaluation_Criteria_Type_Id { get; set; }
    public string Type { get; set; }
    public string Type_Code { get; set; }
    public int Status_Id { get; set; }
    public int Main_Organistion_Id { get; set; }
    public int Class_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int Section_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Evaluation_Criteria_TypeAdd(BLLEvaluation_Criteria_Type _obj)
        {
        return objdal.Evaluation_Criteria_TypeAdd(_obj);
        }
    public int Evaluation_Criteria_TypeUpdate(BLLEvaluation_Criteria_Type _obj)
        {
        return objdal.Evaluation_Criteria_TypeUpdate(_obj);
        }
    public int Evaluation_Criteria_TypeDelete(BLLEvaluation_Criteria_Type _obj)
        {
        return objdal.Evaluation_Criteria_TypeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Evaluation_Criteria_TypeFetch(BLLEvaluation_Criteria_Type _obj)
        {
        return objdal.Evaluation_Criteria_TypeSelect(_obj);
        }

    public DataTable Evaluation_Criteria_TypeFetchByStatusID(BLLEvaluation_Criteria_Type _obj)
    {
        return objdal.Evaluation_Criteria_TypeSelectByStatusID(_obj);
    }

    public DataTable Evaluation_Criteria_TypeFetchBySectionID(BLLEvaluation_Criteria_Type _obj)
    {
        return objdal.Evaluation_Criteria_TypeSelectBySectionID(_obj);
    }

    public DataTable Evaluation_Criteria_TypeFetchBySectionIDReports(BLLEvaluation_Criteria_Type _obj)
    {
        return objdal.Evaluation_Criteria_TypeSelectBySectionIDReports(_obj);
    }    

    public DataTable Evaluation_Criteria_TypeSelectByNewClassID(BLLEvaluation_Criteria_Type _obj)
    {
        return objdal.Evaluation_Criteria_TypeSelectByNewClassID(_obj);
    }


    public DataTable Evaluation_Criteria_TypeFetch(int _id)
      {
        return objdal.Evaluation_Criteria_TypeSelect(_id);
      }
    public DataTable Evaluation_Criteria_TypeSelectWeeks(int id)
    {
        return objdal.Evaluation_Criteria_TypeSelectWeeks(id);
    }

    #endregion

    }
