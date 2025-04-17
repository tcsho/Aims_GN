using System;
using System.Data;

/// <summary>
/// Summary description for BLLEvaluation_Criteria_Type_CUTTOFF
/// </summary>



public class BLLEvaluation_Criteria_Type_CUTTOFF
{
    public BLLEvaluation_Criteria_Type_CUTTOFF()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALEvaluation_Criteria_Type_CUTTOFF objdal = new DALEvaluation_Criteria_Type_CUTTOFF();



    #region 'Start Properties Declaration'


    public int ECT_CUTTOFF_Id { get; set; }
    public int Session_Id { get; set; }
    public DateTime? FromDate { get; set; }
    public DateTime? ToDate { get; set; }
    public int Status { get; set; }
    public int TermGroup_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Evaluation_Criteria_Type_CUTTOFFCRUD(BLLEvaluation_Criteria_Type_CUTTOFF _obj)
    {
        return objdal.Evaluation_Criteria_Type_CUTTOFFCRUD(_obj);
    }
    public int Evaluation_Criteria_Type_CUTTOFFSyncStudents(BLLEvaluation_Criteria_Type_CUTTOFF _obj)
    {
        return objdal.Evaluation_Criteria_Type_CUTTOFFSyncStudents(_obj);
    }
    public int AdmSession_DatesDelete(BLLEvaluation_Criteria_Type_CUTTOFF _obj)
    {
        return objdal.Evaluation_Criteria_Type_CUTTOFFDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Evaluation_Criteria_Type_CUTTOFFFetch(BLLEvaluation_Criteria_Type_CUTTOFF _obj)
    {
        return objdal.Evaluation_Criteria_Type_CUTTOFFSelect(_obj);
    }

    public DataTable Evaluation_Criteria_Type_CUTTOFFFetchByStatusID(BLLEvaluation_Criteria_Type_CUTTOFF _obj)
    {
        return objdal.Evaluation_Criteria_Type_CUTTOFFByStatusID(_obj);
    }



    public DataTable Evaluation_Criteria_Type_CUTTOFFSelectAll(BLLEvaluation_Criteria_Type_CUTTOFF obj)
    {
        return objdal.Evaluation_Criteria_Type_CUTTOFFSelectAll(obj);
    }


    #endregion

}
