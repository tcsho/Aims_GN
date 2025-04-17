using System;
using System.Data;

/// <summary>
/// Summary description for BLLMain_Organisation_Country
/// </summary>



public class BLLMain_Organisation_Country
    {
    public BLLMain_Organisation_Country()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALMain_Organisation_Country objdal = new DALMain_Organisation_Country();



    #region 'Start Properties Declaration'

    public int Main_Organisation_Country_Id { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Country_Id { get; set; }
    public int Status_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Main_Organisation_CountryAdd(BLLMain_Organisation_Country _obj)
        {
        return objdal.Main_Organisation_CountryAdd(_obj);
        }
    public int Main_Organisation_CountryUpdate(BLLMain_Organisation_Country _obj)
        {
        return objdal.Main_Organisation_CountryUpdate(_obj);
        }
    public int Main_Organisation_CountryDelete(BLLMain_Organisation_Country _obj)
        {
        return objdal.Main_Organisation_CountryDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Main_Organisation_CountryFetch(BLLMain_Organisation_Country _obj)
        {
        return objdal.Main_Organisation_CountrySelect(_obj);
        }

    public DataTable Main_Organisation_CountryFetchByStatusID(BLLMain_Organisation_Country _obj)
    {
        return objdal.Main_Organisation_CountrySelectByStatusID(_obj);
    }



    public DataTable Main_Organisation_CountryFetch(int _id)
      {
        return objdal.Main_Organisation_CountrySelect(_id);
      }


    #endregion

    }
