using System;
using System.Data;

/// <summary>
/// Summary description for BLLNetworkStandAloneCenters
/// </summary>



public class BLLNetworkStandAloneCenters
{
    public BLLNetworkStandAloneCenters()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALNetworkStandAloneCenters objdal = new DALNetworkStandAloneCenters();



    #region 'Start Properties Declaration'

    public int Net_Cent_Id { get; set; }
    public int? Center_Id { get; set; }
    public int? Region_Id { get; set; }
    public int? Status_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int NetworkStandAloneCentersAdd(BLLNetworkStandAloneCenters _obj)
    {
        return objdal.NetworkStandAloneCentersAdd(_obj);
    }
    public int NetworkStandAloneCentersUpdate(BLLNetworkStandAloneCenters _obj)
    {
        return objdal.NetworkStandAloneCentersUpdate(_obj);
    }
    public int NetworkStandAloneCentersDelete(BLLNetworkStandAloneCenters _obj)
    {
        return objdal.NetworkStandAloneCentersDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable NetworkStandAloneCentersFetch(BLLNetworkStandAloneCenters _obj)
    {
        return objdal.NetworkStandAloneCentersSelect(_obj);
    }

    public DataTable NetworkStandAloneCentersFetchByStatusID(BLLNetworkStandAloneCenters _obj)
    {
        return objdal.NetworkStandAloneCentersSelectByStatusID(_obj);
    }



    public DataTable NetworkStandAloneCentersFetchAllCenter(BLLNetworkStandAloneCenters obj)
    {
        return objdal.NetworkStandAloneCentersSelectAllCenter(obj);
    }


    #endregion

}
