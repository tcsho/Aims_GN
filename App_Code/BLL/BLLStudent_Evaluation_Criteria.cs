using System;
using System.Data;

/// <summary>
/// Summary description for BLLStudent_Evaluation_Criteria
/// </summary>



public class BLLStudent_Evaluation_Criteria
    {
    public BLLStudent_Evaluation_Criteria()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Evaluation_Criteria objdal = new DALStudent_Evaluation_Criteria();



    #region 'Start Properties Declaration'

    public int Student_Section_Subject_Id { get; set; }
    public int SSEC_Id { get; set; }
    public decimal Marks_Obtained { get; set; }
    public bool Lock_Mark { get; set; }
    public int Status_Id { get; set; }

    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Student_Id { get; set; }
    public int Section_Id { get; set; }



    public int Session_Id { get; set; }
    public int Employee_Id { get; set; }

    public string XMLData { get; set; }
    #endregion

    #region 'Start Executaion Methods'

    public int Student_Evaluation_CriteriaAdd(BLLStudent_Evaluation_Criteria _obj)
        {
        return objdal.Student_Evaluation_CriteriaAdd(_obj);
        }
    public int Student_Evaluation_CriteriaUpdate(BLLStudent_Evaluation_Criteria _obj)
        {
        return objdal.Student_Evaluation_CriteriaUpdate(_obj);
        }

    public int Student_Evaluation_CriteriaUpdateXML(BLLStudent_Evaluation_Criteria _obj)
    {
        return objdal.Student_Evaluation_CriteriaUpdateXML(_obj);
    }
    public int Student_Evaluation_CriteriaDelete(BLLStudent_Evaluation_Criteria _obj)
        {
        return objdal.Student_Evaluation_CriteriaDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Evaluation_CriteriaFetch(BLLStudent_Evaluation_Criteria _obj)
        {
        return objdal.Student_Evaluation_CriteriaSelect(_obj);
        }

    public DataTable Student_Evaluation_CriteriaFetchByStatusID(BLLStudent_Evaluation_Criteria _obj)
    {
        return objdal.Student_Evaluation_CriteriaSelectByStatusID(_obj);
    }



    public DataTable Student_Evaluation_CriteriaFetch(int _id)
      {
        return objdal.Student_Evaluation_CriteriaSelect(_id);
      }

    public DataTable Student_Evaluation_CriteriaBySectionSubjectId(BLLStudent_Evaluation_Criteria _obj)
    {
        return objdal.Student_Evaluation_CriteriaBySectionSubjectId(_obj);
    }

    public DataTable Student_Evaluation_CriteriaByMissingStudent(BLLStudent_Evaluation_Criteria _obj)
    {
        return objdal.Student_Evaluation_CriteriaByMissingStudent(_obj);
    }

    public int Student_Evaluation_CriteriaInsertMissingStudent(BLLStudent_Evaluation_Criteria _obj)
    {
        return objdal.Student_Evaluation_CriteriaInsertMissingStudent(_obj);
    }


    public DataTable Result_ByEmployeeSubjectWise(BLLStudent_Evaluation_Criteria _obj)
    {
        return objdal.Result_ByEmployeeSubjectWise(_obj);
    }

    public DataTable Result_ByEmployeeCenterWise(BLLStudent_Evaluation_Criteria _obj)
    {
        return objdal.Result_ByEmployeeCenterWise(_obj);
    }

    #endregion

    }
