using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for BLLBifurcationProcessByCenter_Vu
/// </summary>
public class BLLBifurcationProcessByCenter_Vu
{
    public BLLBifurcationProcessByCenter_Vu()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    _DALBifurcationProcessByCenterVu objdal = new _DALBifurcationProcessByCenterVu();
    #region 'Start Properties Declaration'

    public int Session_Id { get; set; }
    public string Description { get; set; }
    
    public int TermGroup_Id { get; set; }
    public string Type { get; set; }
    public int Region_Id { get; set; }
    public string Region_Name { get; set; }
    public bool Active { get; set; }

    public int Center_Id { get; set; }
    public string Center_Name { get; set; }
    #endregion

    #region 'Start Executaion Methods'

    
    #endregion
    #region 'Start Fetch Methods'


    public DataTable RegionFetchByStatusID(BLLBifurcationProcessByCenter_Vu _obj)
    {
        return objdal.RegionSelectByStatusID(_obj);
    }



    public DataTable CenterFetch(BLLBifurcationProcessByCenter_Vu _obj)
    {
        return objdal.RegionSelect(_obj);
    }

    public DataTable NewRegionFetch(BLLBifurcationProcessByCenter_Vu _obj)
    {
        return objdal.NewRegionSelect(_obj);
    }

    public DataTable TermFetch(BLLBifurcationProcessByCenter_Vu _obj)
    {
        return objdal.NewTermSelect(_obj);
    }
    #endregion

}