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
/// Summary description for BLLAdmTestDetail
/// </summary>



public class BLLAdmTestDetail
{
    public BLLAdmTestDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALAdmTestDetail objdal = new DALAdmTestDetail();



    #region 'Start Properties Declaration'

    public int AdmTestDetail_Id { get; set; }
    public string AsmntPartName { get; set; }
    public int AdmTest_Id { get; set; }
    public int Sequence_ID { get; set; }
    public string AsmntPartDesc { get; set; }
    public int Status_ID { get; set; }
    public int Pool_Id { get; set; }
    public string TestDesc { get; set; }
    public decimal TotalMarks { get; set; }
    public decimal Weightage { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int AdmTestDetailAdd(BLLAdmTestDetail _obj)
    {
        return objdal.AdmTestDetailAdd(_obj);
    }
    public int AdmTestDetailUpdate(BLLAdmTestDetail _obj)
    {
        return objdal.AdmTestDetailUpdate(_obj);
    }
    public int AdmTestDetailDelete(BLLAdmTestDetail _obj)
    {
        return objdal.AdmTestDetailDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable AdmTestDetailFetch(BLLAdmTestDetail _obj)
    {
        return objdal.AdmTestDetailSelect(_obj);
    }


    public DataTable AdmTestDetailSelectAllByAdmTest_Id(BLLAdmTestDetail _obj)
    {
        return objdal.AdmTestDetailSelectAllByAdmTest_Id(_obj);
    }



    public DataTable AdmTestDetailFetchByStatusID(BLLAdmTestDetail _obj)
    {
        return objdal.AdmTestDetailSelectByStatusID(_obj);
    }



    public DataTable AdmTestDetailFetch(int _id)
    {
        return objdal.AdmTestDetailSelect(_id);
    }


    #endregion

}
