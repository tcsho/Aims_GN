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
/// Summary description for BLLSection_Subject_Diag_Prog
/// </summary>



public class BLLSection_Subject_Diag_Prog
    {
    public BLLSection_Subject_Diag_Prog()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSection_Subject_Diag_Prog objdal = new DALSection_Subject_Diag_Prog();



    #region 'Start Properties Declaration'

    public int SSDP_Id { get; set; }
    public int Section_Subject_Id { get; set; }
    public int DP_Id { get; set; }
    public string Section_Name { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public int Status_Id { get; set; }


    public int Diag_Prog_Manage_Center_Access_Id { get; set; }
    public int Region_Id { get; set; }
    public string Region_Name { get; set; }
    public int Center_Id { get; set; }
    public string Center_Name { get; set; }
    public bool isAllow { get; set; }
    public int Subject_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Section_Subject_Diag_ProgAdd(BLLSection_Subject_Diag_Prog _obj)
        {
        return objdal.Section_Subject_Diag_ProgAdd(_obj);
        }

    public int Diag_Prog_Manage_Center_AccessAdd(BLLSection_Subject_Diag_Prog _obj)
    {
        return objdal.Diag_Prog_Manage_Center_AccessAdd(_obj);
    }


    public int Section_Subject_Diag_ProgUpdate(BLLSection_Subject_Diag_Prog _obj)
        {
        return objdal.Section_Subject_Diag_ProgUpdate(_obj);
        }
    public int Section_Subject_Diag_ProgDelete(BLLSection_Subject_Diag_Prog _obj)
        {
        return objdal.Section_Subject_Diag_ProgDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Section_Subject_Diag_ProgFetch(BLLSection_Subject_Diag_Prog _obj)
        {
        return objdal.Section_Subject_Diag_ProgSelect(_obj);
        }


    public DataTable Diag_Prog_Manage_Center_AccessSelectAll(BLLSection_Subject_Diag_Prog _obj)
    {
        return objdal.Diag_Prog_Manage_Center_AccessSelectAll(_obj);
    }


    public int Section_Subject_Diag_Prog_GenerateMasterDetailValues(BLLSection_Subject_Diag_Prog _obj)
    {
        return objdal.Section_Subject_Diag_Prog_GenerateMasterDetailValues(_obj);
    }


    public DataTable Section_Subject_Diag_ProgFetchByStatusID(BLLSection_Subject_Diag_Prog _obj)
    {
        return objdal.Section_Subject_Diag_ProgSelectByStatusID(_obj);
    }



    public DataTable Section_Subject_Diag_ProgFetch(int _id)
      {
        return objdal.Section_Subject_Diag_ProgSelect(_id);
      }


    #endregion

    }
