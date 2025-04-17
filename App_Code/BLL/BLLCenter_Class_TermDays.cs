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
/// Summary description for BLLCenter_Class_TermDays
/// </summary>



public class BLLCenter_Class_TermDays
{
    public BLLCenter_Class_TermDays()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALCenter_Class_TermDays objdal = new DALCenter_Class_TermDays();



    #region 'Start Properties Declaration'
    public int CenterClassTermDayId { get; set; }
    public int Session_Id { get; set; }
    public int Region_Id { get; set; }
    public int Center_Id { get; set; }
    public int Class_Id { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int TotalTermDays { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int FirstTermDays { get; set; }
    public int SecondTermDays { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Center_Class_TermDaysAdd(BLLCenter_Class_TermDays _obj)
    {
        return objdal.Center_Class_TermDaysAdd(_obj);
    }
    public int Center_TermDaysAdd(BLLCenter_Class_TermDays _obj)
    {
        return objdal.Center_TermDaysAdd(_obj);
    }
    public int Center_Class_TermDaysUpdate(BLLCenter_Class_TermDays _obj)
    {
        return objdal.Center_Class_TermDaysUpdate(_obj);
    }
    public int Center_Class_TermDaysDelete(BLLCenter_Class_TermDays _obj)
    {
        return objdal.Center_Class_TermDaysDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Center_Class_TermDaysFetch(BLLCenter_Class_TermDays _obj)
    {
        return objdal.Center_Class_TermDaysSelect(_obj);
    }

    public DataTable Center_Class_TermDaysFetchByStatusID(BLLCenter_Class_TermDays _obj)
    {
        return objdal.Center_Class_TermDaysSelectByStatusID(_obj);
    }


    public DataTable Center_Class_TermDaysSelectAllByregionIdCenterId(BLLCenter_Class_TermDays _obj)
    {
        return objdal.Center_Class_TermDaysSelectAllByregionIdCenterId(_obj);
    }

    public DataTable Center_Class_TermDaysFetch(int _id)
    {
        return objdal.Center_Class_TermDaysSelect(_id);
    }

    public int UpdateRegionTermDays(BLLCenter_Class_TermDays objBll)
    {
        return objdal.UpdateRegionTermDays(objBll);
    }

    public int RegionTermDaysCopyToCenter(BLLCenter_Class_TermDays objBll)
    {
        return objdal.RegionTermDaysCopyToCenter(objBll);
    }

    public int RegionSecondTermDaysCopyToCenter(BLLCenter_Class_TermDays objBll)
    {
        return objdal.RegionSecondTermDaysCopyToCenter(objBll);
    }


    #endregion

}
