using System;
using System.Data;

/// <summary>
/// Summary description for BLLSection_Subject_Evaluation_Criteria_Detail
/// </summary>



public class BLLSection_Subject_Evaluation_Criteria_Detail
    {
    public BLLSection_Subject_Evaluation_Criteria_Detail()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSection_Subject_Evaluation_Criteria_Detail objdal = new DALSection_Subject_Evaluation_Criteria_Detail();



    #region 'Start Properties Declaration'



    #endregion

    #region 'Start Executaion Methods'

    public int Section_Subject_Evaluation_Criteria_DetailAdd(BLLSection_Subject_Evaluation_Criteria_Detail _obj)
        {
        return objdal.Section_Subject_Evaluation_Criteria_DetailAdd(_obj);
        }
    public int Section_Subject_Evaluation_Criteria_DetailUpdate(BLLSection_Subject_Evaluation_Criteria_Detail _obj)
        {
        return objdal.Section_Subject_Evaluation_Criteria_DetailUpdate(_obj);
        }
    public int Section_Subject_Evaluation_Criteria_DetailDelete(BLLSection_Subject_Evaluation_Criteria_Detail _obj)
        {
        return objdal.Section_Subject_Evaluation_Criteria_DetailDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Section_Subject_Evaluation_Criteria_DetailFetch(BLLSection_Subject_Evaluation_Criteria_Detail _obj)
        {
        return objdal.Section_Subject_Evaluation_Criteria_DetailSelect(_obj);
        }

    public DataTable Section_Subject_Evaluation_Criteria_DetailFetchByStatusID(BLLSection_Subject_Evaluation_Criteria_Detail _obj)
    {
        return objdal.Section_Subject_Evaluation_Criteria_DetailSelectByStatusID(_obj);
    }



    public DataTable Section_Subject_Evaluation_Criteria_DetailFetch(int _id)
      {
        return objdal.Section_Subject_Evaluation_Criteria_DetailSelect(_id);
      }




    #endregion

    }
