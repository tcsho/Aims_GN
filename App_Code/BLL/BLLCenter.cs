using System;
using System.Data;


/// <summary>
/// Summary description for BLLCenter
/// </summary>



public class BLLCenter
{
    public BLLCenter()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    _DALCenter objdal = new _DALCenter();



    #region 'Start Properties Declaration'

    public int Center_Id { get; set; }
    public string Center_Name { get; set; }
    public string Center_String_Id { get; set; }
    public int Region_Id { get; set; }
    public int Session_Id { get; set; }
    public int Status_Id { get; set; }
    public string Address { get; set; }
    public string Telephone_No { get; set; }
    public string Email { get; set; }
    public string Website { get; set; }
    public string Academic_Year_Start_Month { get; set; }
    public string Academic_Year_End_Month { get; set; }
    public int Cluster_Id { get; set; }
    public int Bank_Id { get; set; }
    public int Program_Id { get; set; }
    public string SMSCell { get; set; }
    public decimal RoyalityFee { get; set; }
    public int City_id { get; set; }
    public int StrengthToBe { get; set; }





    #endregion

    #region 'Start Executaion Methods'

    public int CenterAdd(BLLCenter _obj)
    {
        return objdal.CenterAdd(_obj);
    }
    public int CenterUpdate(BLLCenter _obj)
    {
        return objdal.CenterUpdate(_obj);
    }
    public int CenterDelete(BLLCenter _obj)
    {
        return objdal.CenterDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable CenterFetch(BLLCenter _obj)
    {
        return objdal.CenterSelect(_obj);
    }

    public DataTable CenterFetchByStatusID(BLLCenter _obj)
    {
        return objdal.CenterSelectByStatusID(_obj);
    }

    public DataTable CenterFetchByRegionID(BLLCenter _obj)
    {
        return objdal.CenterSelectByRegionID(_obj);
    }

    public DataTable CenterFetchByRegionIDSeatPlan(BLLCenter _obj)
    {
        return objdal.CenterSelectByRegionIDSeatPlan(_obj);
    }

    public DataTable CentersList(BLLCenter _obj)
    {
        return objdal.CentersList(_obj);
    }

    public DataTable CenterFetchByRegionID_CIE(BLLCenter _obj)
    {
        return objdal.CenterSelectByRegionID_CIE(_obj);
    }


    public DataTable CenterFetch(int _id)
    {
        return objdal.CenterSelect(_id);
    }

    public DataTable CenterFetchByCenterID(BLLCenter _obj)
    {
        return objdal.CenterSelectByCenterID(_obj);
    }
    public DataTable CenterSelectByRegionSessionID(BLLCenter _obj)
    {
        return objdal.CenterSelectByRegionSessionID(_obj);
    }
    public DataTable CenterSelectByRegionSessionOALevelID(BLLCenter _obj)
    {
        return objdal.CenterSelectByRegionSessionOALevelID(_obj);
    }

    public DataTable GetRegionByRegionId(BLLCenter_Class_TermDays objClsSec)
    {
        return objdal.GetRegionByRegionId(objClsSec);
    }



    #endregion

}
