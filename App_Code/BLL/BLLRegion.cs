using System;
using System.Data;

/// <summary>
/// Summary description for BLLRegion
/// </summary>



public class BLLRegion
    {
    public BLLRegion()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALRegion objdal = new DALRegion();



    #region 'Start Properties Declaration'

    public int Region_Id { get; set; }
    public string Region_String_ID { get; set; }
    public string Region_Name { get; set; }
    public int Main_Organisation_Country_Id { get; set; }
    public string Address { get; set; }
    public string Telephone_No { get; set; }
    public string Email { get; set; }
    public int Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int RegionAdd(BLLRegion _obj)
        {
        return objdal.RegionAdd(_obj);
        }
    public int RegionUpdate(BLLRegion _obj)
        {
        return objdal.RegionUpdate(_obj);
        }
    public int RegionDelete(BLLRegion _obj)
        {
        return objdal.RegionDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable RegionFetch(BLLRegion _obj)
        {
        return objdal.RegionSelect(_obj);
        }

    public DataTable RegionFetchByStatusID(BLLRegion _obj)
    {
        return objdal.RegionSelectByStatusID(_obj);
    }



    public DataTable RegionFetch(int _id)
      {
        return objdal.RegionSelect(_id);
      }

//Add this method in BLLRegion.cs Class    
//=============================================
public DataTable NewRegionFetch(BLLRegion _obj)
    {
        return objdal.NewRegionSelect(_obj);
    }

    #endregion

    }
