using System;
using System.Data;

/// <summary>
/// Summary description for BLLArchieve
/// </summary>



public class BLLArchieve
    {
    public BLLArchieve()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALArchieve objdal = new DALArchieve();



    #region 'Start Properties Declaration'
    
    public int Center_Id {get;set;}
    public int Session_Id {get;set;}
    public int Term_Id {get;set;}
    public int Mo_Id {get;set;}




    #endregion

    #region 'Start Executaion Methods'

    public int ArchieveAdd(BLLArchieve _obj)
        {
        return objdal.ArchieveAdd(_obj);
        }
    public int ArchieveUpdate(BLLArchieve _obj)
        {
        return objdal.ArchieveUpdate(_obj);
        }
    public int ArchieveDelete(BLLArchieve _obj)
        {
        return objdal.ArchieveDelete(_obj);

        }
    public int Call_ArchiveProcedureNew(BLLArchieve _obj)
    {
    
    return objdal.Call_ArchiveProcedureNew(_obj);
    }

    public int Call_PromotionProcedure(BLLArchieve _obj)
    {
    
    return objdal.Call_PromotionProcedure(_obj);
    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable ArchieveFetch(BLLArchieve _obj)
        {
        return objdal.ArchieveSelect(_obj);
        }

    public DataTable ArchieveFetchByStatusID(BLLArchieve _obj)
    {
        return objdal.ArchieveSelectByStatusID(_obj);
    }



    public DataTable ArchieveFetch(int _id)
      {
        return objdal.ArchieveSelect(_id);
      }


    #endregion

    }
