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
/// Summary description for BLLSection_Subject_Diag_Prog_Detail
/// </summary>



public class BLLSection_Subject_Diag_Prog_Detail
    {
    public BLLSection_Subject_Diag_Prog_Detail()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSection_Subject_Diag_Prog_Detail objdal = new DALSection_Subject_Diag_Prog_Detail();



    #region 'Start Properties Declaration'

    public int SSDPD_Id { get; set; }
    public int DPD_Id { get; set; }
    public int SSDP_Id { get; set; }
    public string Question_Name { get; set; }
    public decimal Total_Marks { get; set; }
    public int Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Section_Subject_Diag_Prog_DetailAdd(BLLSection_Subject_Diag_Prog_Detail _obj)
        {
        return objdal.Section_Subject_Diag_Prog_DetailAdd(_obj);
        }
    public int Section_Subject_Diag_Prog_DetailUpdate(BLLSection_Subject_Diag_Prog_Detail _obj)
        {
        return objdal.Section_Subject_Diag_Prog_DetailUpdate(_obj);
        }
    public int Section_Subject_Diag_Prog_DetailDelete(BLLSection_Subject_Diag_Prog_Detail _obj)
        {
        return objdal.Section_Subject_Diag_Prog_DetailDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Section_Subject_Diag_Prog_DetailFetch(BLLSection_Subject_Diag_Prog_Detail _obj)
        {
        return objdal.Section_Subject_Diag_Prog_DetailSelect(_obj);
        }

    public DataTable Section_Subject_Diag_Prog_DetailFetchByStatusID(BLLSection_Subject_Diag_Prog_Detail _obj)
    {
        return objdal.Section_Subject_Diag_Prog_DetailSelectByStatusID(_obj);
    }



    public DataTable Section_Subject_Diag_Prog_DetailFetch(int _id)
      {
        return objdal.Section_Subject_Diag_Prog_DetailSelect(_id);
      }


    #endregion

    }
