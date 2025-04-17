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
/// Summary description for BLLAdmTest
/// </summary>



public class BLLAdmTest
{
    public BLLAdmTest()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmTest objdal = new DALAdmTest();
    #region 'Start Properties Declaration'

    public int AdmTest_Id { get; set; }
    public string Title { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public int Status_ID { get; set; }
    public int PublishStatus_ID { get; set; }
    public DateTime OpeningDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public int Session_Id { get; set; }
    public int Class_Id { get; set; }
    public int TotalQuestions { get; set; }
    public int AdmTestType_Id { get; set; }

    public bool IsAdaptive { get; set; }


    #endregion
    #region 'Start Executaion Methods'

    public int AdmTestAdd(BLLAdmTest _obj)
    {
        return objdal.AdmTestAdd(_obj);
    }
    public int AdmTestUpdate(BLLAdmTest _obj, BLLAdmTestDetail objdet)
    {
        return objdal.AdmTestUpdate(_obj, objdet);
    }
    public int AdmTestDelete(BLLAdmTest _obj)
    {
        return objdal.AdmTestDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'

    public DataTable AdmTestFetch(BLLAdmTest _obj)
    {
        return objdal.AdmTestSelect(_obj);
    }

    public DataTable AdmTestFetchByStatusID(BLLAdmTest _obj)
    {
        return objdal.AdmTestSelectByStatusID(_obj);
    }

    public DataTable AdmTestFetchTestType(BLLAdmTest _obj)
    {
        return objdal.AdmTestSelectTestType(_obj);
    }


    public DataTable AdmTestFetch(int _id)
    {
        return objdal.AdmTestSelect(_id);
    }
    #endregion
}
