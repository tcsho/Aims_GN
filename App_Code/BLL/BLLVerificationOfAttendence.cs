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



public class BLLVerificationOfAttendence
{
    public BLLVerificationOfAttendence()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    _DALVerificationOfAttendence objdal = new _DALVerificationOfAttendence();


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
    public int Region_Id { get; set; }
    public int Session_Id { get; set; }
    public bool Lock { get; set; }


    #endregion

    public DataTable VerificationOfAttendence_Get(BLLVerificationOfAttendence _obj)
    {
        return objdal.VerificationOfAttendence_Get(_obj);
    }

}
