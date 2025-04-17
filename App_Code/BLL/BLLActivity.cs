using System;
using System.Data;

/// <summary>
/// Summary description for BLLActivity
/// </summary>



public class BLLActivity
    {
    public BLLActivity()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALActivity objdal = new DALActivity();



    #region 'Start Properties Declaration'
    public int Activity_Id { get; set; }
    public string Activity { get; set; }
    public int Class_Id { get; set; }
    public int Subject_Id { get; set; }
    public decimal Weightage { get; set; }
    public int Main_Organisation_Id { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Evaluation_Type_Id { get; set; }
    public int Section_Subject_Id { get; set; }



    #endregion



    #region 'Start Executaion Methods'

    public int ActivityAdd(BLLActivity _obj)
        {
        return objdal.ActivityAdd(_obj);
        }
    public int ActivityUpdate(BLLActivity _obj)
        {
        return objdal.ActivityUpdate(_obj);
        }
    public int ActivityDelete(BLLActivity _obj)
        {
        return objdal.ActivityDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable ActivityFetch(BLLActivity _obj)
        {
        return objdal.ActivitySelect(_obj);
        }

    public DataTable ActivityFetchByStatusID(BLLActivity _obj)
    {
        return objdal.ActivitySelectByStatusID(_obj);
    }


    public DataTable ActivityFetchBySectionSubjectTerm(BLLActivity _obj)
    {
        return objdal.ActivitySelectBySectionSubjectTerm(_obj);
    }

    public DataTable ActivityFetch(int _id)
      {
        return objdal.ActivitySelect(_id);
      }

    public DataTable Activity_SelectAllByClassSubjectEvlCriteriaTypeId(BLLActivity _obj)
    {
        return objdal.Activity_SelectAllByClassSubjectEvlCriteriaTypeId(_obj);
    }

    public DataTable Activity_SelectAllByClassIdSubjectIdActivityId(BLLActivity _obj)
    {
        return objdal.Activity_SelectAllByClassIdSubjectIdActivityId(_obj);
    }

    public DataTable Activity_CheckExistingValue(BLLActivity _obj)
    {
        return objdal.Activity_CheckExistingValue(_obj);
    }

    #endregion

    }
