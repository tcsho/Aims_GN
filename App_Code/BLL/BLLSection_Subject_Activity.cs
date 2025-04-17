using System;
using System.Data;

/// <summary>
/// Summary description for BLLSection_Subject_Activity
/// </summary>



public class BLLSection_Subject_Activity
    {
    public BLLSection_Subject_Activity()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSection_Subject_Activity objdal = new DALSection_Subject_Activity();



    #region 'Start Properties Declaration'

    public int SSA_Id { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Activity_Id { get; set; }
    public string Activity { get; set; }
    public int Class_Id { get; set; }
    public int Subject_Id { get; set; }
    public decimal Weightage { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Evaluation_Type_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Section_Subject_ActivityAdd(BLLSection_Subject_Activity _obj)
        {
        return objdal.Section_Subject_ActivityAdd(_obj);
        }
    public int Section_Subject_ActivityUpdate(BLLSection_Subject_Activity _obj)
        {
        return objdal.Section_Subject_ActivityUpdate(_obj);
        }
    public int Section_Subject_ActivityDelete(BLLSection_Subject_Activity _obj)
        {
        return objdal.Section_Subject_ActivityDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Section_Subject_ActivityFetch(BLLSection_Subject_Activity _obj)
        {
        return objdal.Section_Subject_ActivitySelect(_obj);
        }

    public DataTable Section_Subject_ActivityFetchByStatusID(BLLSection_Subject_Activity _obj)
    {
        return objdal.Section_Subject_ActivitySelectByStatusID(_obj);
    }



    public DataTable Section_Subject_ActivityFetch(int _id)
      {
        return objdal.Section_Subject_ActivitySelect(_id);
      }


    #endregion

    }
