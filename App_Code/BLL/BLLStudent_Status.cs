using System;
using System.Data;


/// <summary>
/// Summary description for BLLStudent_Status
/// </summary>



public class BLLStudent_Status
    {
    public BLLStudent_Status()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Status objdal = new DALStudent_Status();



    #region 'Start Properties Declaration'

    public int Student_Status_Id { get; set; }
    public string Student_Status { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Student_StatusAdd(BLLStudent_Status _obj)
        {
        return objdal.Student_StatusAdd(_obj);
        }
    public int Student_StatusUpdate(BLLStudent_Status _obj)
        {
        return objdal.Student_StatusUpdate(_obj);
        }
    public int Student_StatusDelete(BLLStudent_Status _obj)
        {
        return objdal.Student_StatusDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_StatusFetch(BLLStudent_Status _obj)
        {
        return objdal.Student_StatusSelect(_obj);
        }

    public DataTable Student_StatusFetchByStatusID(BLLStudent_Status _obj)
    {
        return objdal.Student_StatusSelectByStatusID(_obj);
    }



    public DataTable Student_StatusFetch(int _id)
      {
        return objdal.Student_StatusSelect(_id);
      }


    #endregion

    }
