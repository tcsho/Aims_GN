using System;
using System.Data;

/// <summary>
/// Summary description for BLLClass_Center
/// </summary>



public class BLLClass_Center
    {
    public BLLClass_Center()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALClass_Center objdal = new DALClass_Center();



    #region 'Start Properties Declaration'
    public int Class_Center_ID { get; set; }
    public int Class_ID { get; set; }
    public int Center_ID { get; set; }
    public int Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Class_CenterAdd(BLLClass_Center _obj)
        {
        return objdal.Class_CenterAdd(_obj);
        }
    public int Class_CenterUpdate(BLLClass_Center _obj)
        {
        return objdal.Class_CenterUpdate(_obj);
        }
    public int Class_CenterDelete(BLLClass_Center _obj)
        {
        return objdal.Class_CenterDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Class_CenterFetch(BLLClass_Center _obj)
        {
        return objdal.Class_CenterSelect(_obj);
        }

    public DataTable Class_CenterSelect_OA_Level(BLLClass_Center _obj)
        {
            return objdal.Class_CenterSelect_OA_Level(_obj);
        }
    

    public DataTable Class_CenterFetchByStatusID(BLLClass_Center _obj)
    {
        return objdal.Class_CenterSelectByStatusID(_obj);
    }



    public DataTable Class_CenterFetch(int _id)
      {
        return objdal.Class_CenterSelect(_id);
      }


    #endregion

    }
