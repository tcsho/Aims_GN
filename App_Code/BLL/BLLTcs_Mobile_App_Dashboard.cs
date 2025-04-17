using System;
using System.Data;


/// <summary>
/// Summary description for BLLStudent
/// </summary>



public class BLLTcs_Mobile_App_Dashboard
{
    public BLLTcs_Mobile_App_Dashboard()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALTcs_Mobile_App_Dashboard objdal = new DALTcs_Mobile_App_Dashboard();



    #region 'Start Properties Declaration'
    public int Employee_Id { get; set; }
    public int? Student_Id { get; set; }


    public int Student_No { get; set; }

    public int Region_Id { get; set; }
    public int Center_Id { get; set; }

    public int Grade_Id { get; set; }

    public int Class_ID { get; set; }
    public int Section_Id { get; set; }
    public int Session_Id { get; set; }
    public int Term_Id { get; set; }
    public int TermGroup_Id { get; set; }

    public int Subject_Id { get; set; }

    public string Current_Date { get; set; }



    #endregion

    #region 'Start Executaion Methods'


    public DataSet Get_Total_Registered_Parents(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        return objdal.Get_Total_Registered_Parents(bllStd);
    }
    public DataTable Student_VerificatioSelect(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        return objdal.Student_VerificatioSelect(bllStd);
    }

    public DataTable ClassSelect_ByCenter(BLLClass _obj)
    {
        return objdal.ClassSelect_ByCenter(_obj);
    }


    public DataSet Get_Student_Attendance_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        return objdal.Get_Student_Attendance_Detail(bllStd);
    }

    public DataSet Unregistered_Parents_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        return objdal.Unregistered_Parents_Detail(bllStd);
    }


    public DataSet Unregistered_Student_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        return objdal.Unregistered_Student_Detail(bllStd);
    }


    public DataSet Unmarked_HomeWork_Diary_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        return objdal.Unmarked_HomeWork_Diary_Detail(bllStd);
    }


    public DataSet sp_Dashboard_Classwork_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        return objdal.sp_Dashboard_Classwork_Detail(bllStd);
    }


    public DataSet Dashboard_ClassTestResult_Detail(BLLTcs_Mobile_App_Dashboard bllStd)
    {
        return objdal.Dashboard_ClassTestResult_Detail(bllStd);
    }

    #endregion
}
