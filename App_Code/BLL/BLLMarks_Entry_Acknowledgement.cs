using System;
using System.Data;

/// <summary>
/// Summary description for BLLMarks_Entry_Acknowledgement
/// </summary>



public class BLLMarks_Entry_Acknowledgement
    {
    public BLLMarks_Entry_Acknowledgement()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALMarks_Entry_Acknowledgement objdal = new DALMarks_Entry_Acknowledgement();



    #region 'Start Properties Declaration'

    public int MarksAck_Id { get; set; }
    public int Evaluation_Criteria_Type_Id { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Session_Id { get; set; }
    public int Section_Id { get; set; }
    public int TermGroup_Id { get; set; }
    public int Employee_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public int Student_Id { get; set; }
    #endregion

    #region 'Start Executaion Methods'

    public int Marks_Entry_AcknowledgementAdd(BLLMarks_Entry_Acknowledgement _obj)
        {
        return objdal.Marks_Entry_AcknowledgementAdd(_obj);
        }
    public int Marks_Entry_AcknowledgementUpdate(BLLMarks_Entry_Acknowledgement _obj)
        {
        return objdal.Marks_Entry_AcknowledgementUpdate(_obj);
        }
    public int Marks_Entry_AcknowledgementDelete(BLLMarks_Entry_Acknowledgement _obj)
        {
        return objdal.Marks_Entry_AcknowledgementDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Marks_Entry_AcknowledgementFetch(BLLMarks_Entry_Acknowledgement _obj)
        {
        return objdal.Marks_Entry_AcknowledgementSelect(_obj);
        }
    public DataTable Marks_Entry_AcknowledgementSelectByEmployeeSession(BLLMarks_Entry_Acknowledgement _obj)
        {
            return objdal.Marks_Entry_AcknowledgementSelectByEmployeeSession(_obj);
        }

    public DataTable Marks_Entry_AcknowledgementSelectBySectionSessionId(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_AcknowledgementSelectBySectionSessionId(_obj);
    }   

    public DataTable Marks_Entry_AcknowledgementFetchByStatusID(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_AcknowledgementSelectByStatusID(_obj);
    }

    public int Marks_Entry_AcknowledgementSelectBySectionSessionVerify(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_AcknowledgementSelectBySectionSessionVerify(_obj);    
    }

    public DataTable Marks_Entry_AcknowledgementFetch(int _id)
      {
        return objdal.Marks_Entry_AcknowledgementSelect(_id);
      }

    public DataTable Marks_Entry_DataFetchResult(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_DataFetchResult(_obj);
    }
    public DataTable Marks_Entry_DataFetchResult_OA(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_DataFetchResult_OA(_obj);
    }
    public DataTable Marks_Entry_DataFetchResultStudentInformation(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_DataFetchResultStudentInformation(_obj);
    }



    public DataTable Marks_Entry_DataFetchResultStudentPerformanceGradeSection(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_DataFetchResultStudentPerformanceGradeSection(_obj);
    }

    public DataTable Marks_Entry_DataFetchResultPerformance(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_DataFetchResultPerformance(_obj);
    }
 //2024-10-23
    public DataTable Marks_Entry_DataFetchResultStudentInformation_New(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_DataFetchResultStudentInformation_New(_obj);
    }

    public DataTable Marks_Entry_DataFetchResultStudentPerformanceGradeSection_CLASS1_2(BLLMarks_Entry_Acknowledgement _obj)
    {
        return objdal.Marks_Entry_DataFetchResultStudentPerformanceGradeSection_CLASS1_2(_obj);
    }
    #endregion

    }
