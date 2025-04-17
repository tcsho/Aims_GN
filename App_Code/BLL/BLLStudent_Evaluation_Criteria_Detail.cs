using System;
using System.Data;

/// <summary>
/// Summary description for BLLStudent_Evaluation_Criteria_Detail
/// </summary>



public class BLLStudent_Evaluation_Criteria_Detail
    {
    public BLLStudent_Evaluation_Criteria_Detail()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALStudent_Evaluation_Criteria_Detail objdal = new DALStudent_Evaluation_Criteria_Detail();



    #region 'Start Properties Declaration'
    public int Student_Section_Subject_Id { get; set; }
    public int SSEC_Id { get; set; }
    public decimal Marks_Obtained { get; set; }
    public bool Lock_Mark { get; set; }
    public bool isAbsent { get; set; }
    public int Status_Id { get; set; }

    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Student_Id { get; set; }
    public int Section_Id { get; set; }
    public int TermGroup_Id { get; set; }

    public int Session_Id { get; set; }
    public int @Center_Id { get; set; }
    public int Employee_Id { get; set; }

    public string XMLData { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int Student_Evaluation_Criteria_DetailAdd(BLLStudent_Evaluation_Criteria_Detail _obj)
        {
        return objdal.Student_Evaluation_Criteria_DetailAdd(_obj);
        }
    public int Student_Evaluation_Criteria_DetailUpdate(BLLStudent_Evaluation_Criteria_Detail _obj)
        {
        return objdal.Student_Evaluation_Criteria_DetailUpdate(_obj);
        }
    public int Student_Evaluation_Criteria_DetailDelete(BLLStudent_Evaluation_Criteria_Detail _obj)
        {
        return objdal.Student_Evaluation_Criteria_DetailDelete(_obj);

        }

    public int Student_Evaluation_Criteria_DetailIsAbsentUpdate(BLLStudent_Evaluation_Criteria_Detail _obj)
    {
        return objdal.Student_Evaluation_Criteria_DetailIsAbsentUpdate(_obj);

    }



    #endregion
    #region 'Start Fetch Methods'


    public DataTable Student_Evaluation_Criteria_DetailFetch(BLLStudent_Evaluation_Criteria_Detail _obj)
        {
        return objdal.Student_Evaluation_Criteria_DetailSelect(_obj);
        }

    public DataTable Student_Evaluation_Criteria_DetailFetchByStatusID(BLLStudent_Evaluation_Criteria_Detail _obj)
    {
        return objdal.Student_Evaluation_Criteria_DetailSelectByStatusID(_obj);
    }


    public int Student_Evaluation_Criteria_DetailInsertMissingStudent(BLLStudent_Evaluation_Criteria_Detail _obj)
    {
        return objdal.Student_Evaluation_Criteria_DetailInsertMissingStudent(_obj);
    }
    
    public DataTable Student_Evaluation_Criteria_DetailFetch(int _id)
      {
        return objdal.Student_Evaluation_Criteria_DetailSelect(_id);
      }
    public int Student_Evaluation_Criteria_DetailUpdateXML(BLLStudent_Evaluation_Criteria_Detail _obj)
    {
        return objdal.Student_Evaluation_Criteria_DetailUpdateXML(_obj);
    }

    public DataTable Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfo(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        return objdal.Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfo(objbll);
    }


    public DataTable Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoByCenterId(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        return objdal.Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoByCenterId(objbll);
    }


    public DataTable Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoBySSEDTID(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        return objdal.Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoBySSEDTID(objbll);
    }


    public DataTable Student_Evaluation_Criteria_Detail_ScheduleTestAttendance(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        return objdal.Student_Evaluation_Criteria_Detail_ScheduleTestAttendance(objbll);
    }


    public DataTable Student_TermDaysSelectAllByCenterSessionId(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        return objdal.Student_TermDaysSelectAllByCenterSessionId(objbll);
    }


    #endregion

    }
