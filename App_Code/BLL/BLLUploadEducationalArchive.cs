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
/// Summary description for BLLSearchStudent
/// </summary>



public class BLLUploadEducationalArchive
{
    public BLLUploadEducationalArchive()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    DALUploadEducationalArchive objdal = new DALUploadEducationalArchive();



    #region 'Start Properties Declaration'

    public int Student_Id { get; set; }
    public int Class_Id { get; set; }
    public int Section_ID { get; set; }
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
    public string Region_Id { get; set; }
    public string Center_Id { get; set; }
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


    //**************************************************
    public int Us_ID { get; set; }
    public int Us_Uni_Fk { get; set; }
    public int Us_Std_Id { get; set; }
    public int Us_Center_Id { get; set; }
    public int Us_Session { get; set; }
    public string Us_Status { get; set; }
    public String Us_AddTag { get; set; }

    public String Us_Remarks { get; set; }

    


    public int Ad_Id { get; set; }
    public int Ad_Std_Id { get; set; }
    public string Ad_Doc_Name { get; set; }
    public string Ad_Doc_Path { get; set; }
    public string Ad_AddTag { get; set; }

    public int Ad_Uni_Fk { get; set; }




    #endregion

    #region 'Start Executaion Methods'

    public int SearchStudentAdd(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudentAdd(_obj);
    }
    public int SearchStudentUpdate(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudentUpdate(_obj);
    }
    public int SearchStudentDelete(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudentDelete(_obj);

    }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SearchStudentFetch(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudentSelect(_obj);
    }
    public DataTable SearchStudent_UnassignSubject(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudent_UnassignSubject(_obj);
    }

    public DataTable SearchStudentResultCard(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudentResultCard(_obj);
    }

    public DataTable SearchStudentSubjectData(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudentSubjectData(_obj);
    }



    public DataTable SearchStudentFetchExport(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudentSelectExport(_obj);
    }
    public DataTable SearchStudentFetchCount(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudentSelectCount(_obj);
    }

    public DataTable SearchStudentFetchByStatusID(BLLUploadEducationalArchive _obj)
    {
        return objdal.SearchStudentSelectByStatusID(_obj);
    }



    public DataTable SearchStudentFetch(int _id)
    {
        return objdal.SearchStudentSelect(_id);
    }

    public DataTable Class_CenterSelect_For_Alumni_students(BLLUploadEducationalArchive _obj)
    {
        return objdal.Class_CenterSelect_For_Alumni_students(_obj);
    }

    public DataTable CenterSelectByCounselor(int User_Id,int Rgion_Id)
    {
        return objdal.CenterSelectByCounselor(User_Id, Rgion_Id);
    }

    public DataTable SelectAllUniNames()
    {
        return objdal.SelectAllUniNames();
    }

    public int Uni_Student_Placement_Insert(BLLUploadEducationalArchive _obj)
    {
        return objdal.Uni_Student_Placement_Insert(_obj);
    }

    public DataTable Get_University_student_Placement_List(int Student_id)
    {
        return objdal.Get_University_student_Placement_List(Student_id);
    }

    public int Alumni_Student_Documents_Insert(BLLUploadEducationalArchive _obj)
    {
        return objdal.Alumni_Student_Documents_Insert(_obj);
    }

    public void Updatestatus(int Us_ID, string Status, string Remarks)
    {
        objdal.Updatestatus(Us_ID, Status, Remarks);
    }

    public DataTable Get_Uploaded_Docs_List(int Student_id, int Uni_Id)
    {
        return objdal.Get_Uploaded_Docs_List(Student_id, Uni_Id);
    }

    public DataTable CenterSelectByRegionIDfor_Alumni(int Region_Id)
    {
        return objdal.CenterSelectByRegionIDfor_Alumni(Region_Id);
    }


    public DataTable CounselorsSelectByCenterIDfor_Alumni(int Center_Id)
    {
        return objdal.CounselorsSelectByCenterIDfor_Alumni(Center_Id);
    }

    public DataTable TrackAlumni(BLLUploadEducationalArchive _obj)
    {
        return objdal.TrackAlumni(_obj);
    }

    #endregion

}
