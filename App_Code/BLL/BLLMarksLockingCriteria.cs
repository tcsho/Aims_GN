using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for BLLMarksLockingCriteria
/// </summary>



public class BLLMarksLockingCriteria
    {
    public BLLMarksLockingCriteria()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALMarksLockingCriteria objdal = new _DALMarksLockingCriteria();



    #region 'Start Properties Declaration'
    public int Session_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int MCL_Type_Id { get; set; }
    public int MLCri_Id { get; set; }
    public DateTime LockingDate { get; set; }
    public bool isLock { get; set; }

    public string Term_Name { get; set; }
 
    public string ML_Criteria { get; set; }
    public int MLC_Type_Id { get; set; }
   
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Evaluation_Type_Id { get; set; }
    public int Status_Id { get; set; }
    public int Class_Id { get; set; }
    public DateTime CreateDate { get; set; }
    public string Current_Status { get; set; }
    public bool IsProcessed { get; set; }
    #endregion

    #region 'Start Executaion Methods'

    public int MarksLockingCriteriaAdd(BLLMarksLockingCriteria _obj)
        {
        return objdal.MarksLockingCriteriaAdd(_obj);
        }
    public int MarksLockingCriteriaUpdate(BLLMarksLockingCriteria _obj)
        {
        return objdal.MarksLockingCriteriaUpdate(_obj);
        }
    public int MarksLockingCriteriaDelete(BLLMarksLockingCriteria _obj)
        {
        return objdal.MarksLockingCriteriaDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable MarksLockingCriteriaFetch(BLLMarksLockingCriteria _obj)
        {
        return objdal.MarksLockingCriteriaSelect(_obj);
        }
    public DataTable MarksLockingCriteriaTypesFetch(BLLMarksLockingCriteria _obj)
    {
        return objdal.MarksLockingCriteriaTypesSelect(_obj);
    }
    public DataTable MarksLockingCriteriaFetch(int _id)
      {
        return objdal.MarksLockingCriteriaSelect(_id);
      }
    public int MarksLockingCriteriaFetchField(int _Id)
        {
        return objdal.MarksLockingCriteriaSelectField(_Id);
        }


    #endregion

    }
