using System;
using System.Data;

/// <summary>
/// Summary description for BLLClass_Change_Request
/// </summary>



public class BLLClass_Change_Request
{
    public BLLClass_Change_Request()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALClass_Change_Request objdal = new DALClass_Change_Request();



    #region 'Start Properties Declaration'

    public int CCReq_Id { get; set; }
    public int Student_Id { get; set; }
    public string  StudentName { get; set; }
    public int Region_Id { get; set; }
    public int Center_Id { get; set; }
    public int FromClass_Id { get; set; }
    public int ToClass_Id { get; set; }
    public int? FromSection_Id { get; set; }
    public int? ToSection_Id { get; set; }
    public int CCReason_Id { get; set; }
    public int Submit_By { get; set; }
    public DateTime Submitted_On { get; set; }
    public int? Approved_By { get; set; }
    public DateTime? Approved_On { get; set; }
    public bool? isApproved { get; set; }
    public int Class_Id { get; set; }



    public int Session_Id { get; set; }
    public string Aims_Id { get; set; }
    public string Student_Status_Id { get; set; }
    public string Main_Organisation_Id { get; set; }
    public string Student_No { get; set; }
    public string First_Name { get; set; }
    public string Middle_Name { get; set; }
    public string Last_Name { get; set; }
    public string Date_Of_Birth { get; set; }
    public string Address { get; set; }
    public string Telephone_No { get; set; }
    public string Gender_Id { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
    public string Postal_Code { get; set; }
    public string Comments { get; set; }
  
    public string Grade_Id { get; set; }
    public DateTime Approval_Date { get; set; }
    public DateTime Application_Date { get; set; }
    public DateTime Transfer_Date { get; set; }
    public DateTime Drop_Date { get; set; }
    public bool isChaProcess { get; set; }
    public string Section_Id { get; set; }
    public string Teacher_Id { get; set; }
    public string EndIndex { get; set; }
    public string StartIndex { get; set; }
    #endregion

    #region 'Start Executaion Methods'

    public int Class_Change_RequestAdd(BLLClass_Change_Request _obj)
    {
        return objdal.Class_Change_RequestAdd(_obj);
    }
    public int Class_Change_RequestUpdate(BLLClass_Change_Request _obj)
    {
        return objdal.Class_Change_RequestUpdate(_obj);
    }
    public int Class_Change_RequestAction(BLLClass_Change_Request _obj)
    {
        return objdal.Class_Change_RequestAction(_obj);
    }
    public int Class_Change_RequestDelete(BLLClass_Change_Request _obj)
    {
        return objdal.Class_Change_RequestDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'
    public DataTable Class_Change_RequestNotification(BLLClass_Change_Request _obj)
    {
        return objdal.Class_Change_RequestNotification(_obj);
    }

    public DataTable Class_Change_RequestFetch(BLLClass_Change_Request _obj)
    {
        return objdal.Class_Change_RequestSelect(_obj);
    }

    public DataTable Class_Change_RequestFetchforApproval(BLLClass_Change_Request _obj)
    {
        return objdal.Class_Change_RequestFetchforApproval(_obj);
    }



    public DataTable Class_Change_RequestFetch(int _id)
    {
        return objdal.Class_Change_RequestSelect(_id);
    }


    #endregion

}
