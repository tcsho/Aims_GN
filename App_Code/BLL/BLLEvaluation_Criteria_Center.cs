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
/// Summary description for BLLEvaluation_Criteria_Center
/// </summary>



public class BLLEvaluation_Criteria_Center
{
    public BLLEvaluation_Criteria_Center()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALEvaluation_Criteria_Center objdal = new DALEvaluation_Criteria_Center();



    #region 'Start Properties Declaration'

    public int ECC_Id { get; set; }
    public int Evaluation_Criteria_Id { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Subject_Id { get; set; }
    public int Class_Id { get; set; }
    public string Criteria { get; set; }
    public decimal Total_Marks { get; set; }
    public decimal Weightage { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Evaluation_Type_Id { get; set; }
    public int Status_Id { get; set; }
    public int Center_Id { get; set; }
    public int Session_Id { get; set; }
    public bool Lock { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Evaluation_Criteria_CenterAdd(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterAdd(_obj);
    }
    public int Evaluation_Criteria_CenterUpdate(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterUpdate(_obj);
    }
    public int Evaluation_Criteria_CenterDelete(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterDelete(_obj);

    }
    public int Evaluation_Criteria_CenterRevert(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterRevert(_obj);

    }
    public int Evaluation_Criteria_CenterLockUnlock(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterLockUnlock(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Evaluation_Criteria_CenterFetch(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterSelect(_obj);
    }

    public DataTable Evaluation_Criteria_CenterFetchByStatusID(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterSelectByStatusID(_obj);
    }



    public DataTable Evaluation_Criteria_CenterFetch(int _id)
    {
        return objdal.Evaluation_Criteria_CenterSelect(_id);
    }


    public DataTable Evaluation_Criteria_CenterSelectByClassSubjectCenterId(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterSelectByClassSubjectCenterId(_obj);
    }
    public DataTable Evaluation_Criteria_CenterSelectByClassSubjectCenterId_Delete(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterSelectByClassSubjectCenterId_Delete(_obj);
    }

    public DataTable Evaluation_Criteria_CenterSelectByClassSubjectCenterIdECC_Id(BLLEvaluation_Criteria_Center _obj)
    {
        return objdal.Evaluation_Criteria_CenterSelectByClassSubjectCenterIdECC_Id(_obj);
    }



    #endregion

}
