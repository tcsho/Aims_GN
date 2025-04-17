using System;
using System.Data;


/// <summary>
/// Summary description for BLLCountry
/// </summary>



public class BLLCountry
    {
    public BLLCountry()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALCountry objdal = new DALCountry();



    #region 'Start Properties Declaration'
    public int Country_Id { get; set; }
    public string Country_Name { get; set; }
    public string Country_String_Id { get; set; }
    public int Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int CountryAdd(BLLCountry _obj)
        {
        return objdal.CountryAdd(_obj);
        }
    public int CountryUpdate(BLLCountry _obj)
        {
        return objdal.CountryUpdate(_obj);
        }
    public int CountryDelete(BLLCountry _obj)
        {
        return objdal.CountryDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable CountryFetch(BLLCountry _obj)
        {
        return objdal.CountrySelect(_obj);
        }

    public DataTable CountryFetchByStatusID(BLLCountry _obj)
    {
        return objdal.CountrySelectByStatusID(_obj);
    }



    public DataTable CountryFetch(int _id)
      {
        return objdal.CountrySelect(_id);
      }


    #endregion

    }
