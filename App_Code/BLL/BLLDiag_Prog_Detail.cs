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
/// Summary description for BLLDiag_Prog_Detail
/// </summary>



public class BLLDiag_Prog_Detail
    {
    public BLLDiag_Prog_Detail()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALDiag_Prog_Detail objdal = new DALDiag_Prog_Detail();



    #region 'Start Properties Declaration'

    public int DPD_Id { get; set; }
    public int DP_Id { get; set; }
    public string Question_Name { get; set; }
    public decimal Total_Marks { get; set; }
    public decimal Marks_Percentage { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public int Diag_Prog_Question_Type_Id { get; set; }
    public int Topic_Id { get; set; }
    public int Seq_Id { get; set; }

    #endregion

    #region 'Start Executaion Methods'

    public int Diag_Prog_DetailAdd(BLLDiag_Prog_Detail _obj)
        {
        return objdal.Diag_Prog_DetailAdd(_obj);
        }
    public int Diag_Prog_DetailUpdate(BLLDiag_Prog_Detail _obj)
        {
        return objdal.Diag_Prog_DetailUpdate(_obj);
        }
    public int Diag_Prog_DetailDelete(BLLDiag_Prog_Detail _obj)
        {
        return objdal.Diag_Prog_DetailDelete(_obj);

        }
    public int Diag_Prog_DetailLockMarks(BLLDiag_Prog_Detail obj)
    {
        return objdal.Diag_Prog_DetailLockMarks(obj);
    }


    #endregion
    #region 'Start Fetch Methods'

    public DataTable  Diag_Prog_DetailSelectLockMarks(BLLDiag_Prog_Detail obj)
    {
     return objdal.Diag_Prog_DetailSelectLockMarks(obj);
    }
    public DataTable Diag_Prog_DetailFetch( BLLDiag_Prog_Detail _obj)
        {
        return objdal.Diag_Prog_DetailSelect(_obj);
        }

    public DataTable Diag_Prog_DetailFetchByStatusID(BLLDiag_Prog_Detail _obj)
    {
        return objdal.Diag_Prog_DetailSelectByStatusID(_obj);
    }



    public DataTable Diag_Prog_DetailFetch(int _id)
      {
        return objdal.Diag_Prog_DetailSelect(_id);
      }


    public DataTable Diag_Prog_DetailSelectAllByDPId(BLLDiag_Prog_Detail _obj)
    {
        return objdal.Diag_Prog_DetailSelectAllByDPId(_obj);
    }

    public DataTable Diag_Prog_DetailSelectAllByDPDId(BLLDiag_Prog_Detail _obj)
    {
        return objdal.Diag_Prog_DetailSelectAllByDPDId(_obj);
    }

   

    #endregion

    }
