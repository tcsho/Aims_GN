using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLCenterHeadName
/// </summary>
public class BLLCenterHeadName
{
    _DALCenterHeadName objDll = new _DALCenterHeadName();

    #region 'Properties Declaration'
    public int Center_Id { get; set; }
    public int HeadERP { get; set; }
    public string Center_Name { get; set; }    
    public string HeadName { get; set; } 
    #endregion

    public DataTable GetListofCentersHeadName()
    {
        return objDll.GetListofCentersHeadName();
    }
    public void UpdateCentersHeadName(BLLCenterHeadName bllCenterHeadName)
    {
        objDll.UpdateCentersHeadName(bllCenterHeadName);
    }
}