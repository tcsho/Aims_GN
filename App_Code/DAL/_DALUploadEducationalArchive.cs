using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for _DALSearchStudent
/// </summary>
public class DALUploadEducationalArchive
{
    DALBase dalobj = new DALBase();


    public DALUploadEducationalArchive()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int SearchStudentAdd(BLLUploadEducationalArchive objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SearchStudentInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int SearchStudentUpdate(BLLUploadEducationalArchive objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SearchStudentUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int SearchStudentDelete(BLLUploadEducationalArchive objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@SearchStudent_Id", SqlDbType.Int);
        //   param[0].Value = objbll.SearchStudent_Id;


        int k = dalobj.sqlcmdExecute("SearchStudentDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable SearchStudentSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchStudentSelectById", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;
    }
    public DataTable SearchStudent_UnassignSubject(BLLUploadEducationalArchive objbll)
    {

        SqlParameter[] param = new SqlParameter[15];


        param[0] = new SqlParameter("@sp_firstName", SqlDbType.NVarChar);
        param[0].Value = objbll.First_Name;

        param[1] = new SqlParameter("@sp_lastName", SqlDbType.NVarChar);
        param[1].Value = objbll.Last_Name;

        param[2] = new SqlParameter("@sp_middleName", SqlDbType.NVarChar);
        param[2].Value = objbll.Middle_Name;

        param[3] = new SqlParameter("@sp_dateOfBirth", SqlDbType.NChar);
        param[3].Value = objbll.Date_Of_Birth;

        param[4] = new SqlParameter("@sp_gender", SqlDbType.NChar);
        param[4].Value = objbll.Gender_Id;

        param[5] = new SqlParameter("@sp_studentNo", SqlDbType.NVarChar);
        param[5].Value = objbll.Student_No;

        param[6] = new SqlParameter("@sp_region", SqlDbType.NChar);
        param[6].Value = objbll.Region_Id;

        param[7] = new SqlParameter("@sp_studentStatus", SqlDbType.NChar);
        param[7].Value = objbll.Student_Status_Id;

        param[8] = new SqlParameter("@sp_center", SqlDbType.NChar);
        param[8].Value = objbll.Center_Id;

        param[9] = new SqlParameter("@sp_class", SqlDbType.NVarChar);
        param[9].Value = objbll.Grade_Id;


        param[10] = new SqlParameter("@sp_section", SqlDbType.NChar);
        param[10].Value = objbll.Section_Id;

        param[11] = new SqlParameter("@sp_mainOrganisationID", SqlDbType.NChar);
        param[11].Value = objbll.Main_Organisation_Id;

        param[12] = new SqlParameter("@sp_teacher", SqlDbType.NChar);
        param[12].Value = objbll.Teacher_Id;

        param[13] = new SqlParameter("@sp_end_index", SqlDbType.NChar);
        param[13].Value = objbll.EndIndex;

        param[14] = new SqlParameter("@sp_start_index", SqlDbType.NChar);
        param[14].Value = objbll.StartIndex;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchStudent_UnassignSubject", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable SearchStudentSelect(BLLUploadEducationalArchive objbll)
    {

        SqlParameter[] param = new SqlParameter[15];


        param[0] = new SqlParameter("@sp_firstName", SqlDbType.NVarChar);
        param[0].Value = objbll.First_Name;

        param[1] = new SqlParameter("@sp_lastName", SqlDbType.NVarChar);
        param[1].Value = objbll.Last_Name;

        param[2] = new SqlParameter("@sp_middleName", SqlDbType.NVarChar);
        param[2].Value = objbll.Middle_Name;

        param[3] = new SqlParameter("@sp_dateOfBirth", SqlDbType.NChar);
        param[3].Value = objbll.Date_Of_Birth;

        param[4] = new SqlParameter("@sp_gender", SqlDbType.NChar);
        param[4].Value = objbll.Gender_Id;

        param[5] = new SqlParameter("@sp_studentNo", SqlDbType.NVarChar);
        param[5].Value = objbll.Student_No;

        param[6] = new SqlParameter("@sp_region", SqlDbType.NChar);
        param[6].Value = objbll.Region_Id;

        param[7] = new SqlParameter("@sp_studentStatus", SqlDbType.NChar);
        param[7].Value = objbll.Student_Status_Id;

        param[8] = new SqlParameter("@sp_center", SqlDbType.NChar);
        param[8].Value = objbll.Center_Id;

        param[9] = new SqlParameter("@sp_class", SqlDbType.NVarChar);
        param[9].Value = objbll.Grade_Id;


        param[10] = new SqlParameter("@sp_section", SqlDbType.NChar);
        param[10].Value = objbll.Section_Id;

        param[11] = new SqlParameter("@sp_mainOrganisationID", SqlDbType.NChar);
        param[11].Value = objbll.Main_Organisation_Id;

        param[12] = new SqlParameter("@sp_teacher", SqlDbType.NChar);
        param[12].Value = objbll.Teacher_Id;

        param[13] = new SqlParameter("@sp_end_index", SqlDbType.NChar);
        param[13].Value = objbll.EndIndex;

        param[14] = new SqlParameter("@sp_start_index", SqlDbType.NChar);
        param[14].Value = objbll.StartIndex;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchStudent_New_For_Alumni", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }
    public DataTable SearchStudentResultCard(BLLUploadEducationalArchive objbll)
    {

        SqlParameter[] param = new SqlParameter[1];


        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchStudentResultCard", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable SearchStudentSubjectData(BLLUploadEducationalArchive objbll)
    {

        SqlParameter[] param = new SqlParameter[2];


        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;



        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchStudentSubjectList", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable SearchStudentSelectExport(BLLUploadEducationalArchive objbll)
    {

        SqlParameter[] param = new SqlParameter[13];


        param[0] = new SqlParameter("@sp_firstName", SqlDbType.NVarChar);
        param[0].Value = objbll.First_Name;

        param[1] = new SqlParameter("@sp_lastName", SqlDbType.NVarChar);
        param[1].Value = objbll.Last_Name;

        param[2] = new SqlParameter("@sp_middleName", SqlDbType.NVarChar);
        param[2].Value = objbll.Middle_Name;

        param[3] = new SqlParameter("@sp_dateOfBirth", SqlDbType.NChar);
        param[3].Value = objbll.Date_Of_Birth;

        param[4] = new SqlParameter("@sp_gender", SqlDbType.NChar);
        param[4].Value = objbll.Gender_Id;

        param[5] = new SqlParameter("@sp_studentNo", SqlDbType.NVarChar);
        param[5].Value = objbll.Student_No;

        param[6] = new SqlParameter("@sp_region", SqlDbType.NChar);
        param[6].Value = objbll.Region_Id;

        param[7] = new SqlParameter("@sp_studentStatus", SqlDbType.NChar);
        param[7].Value = objbll.Student_Status_Id;

        param[8] = new SqlParameter("@sp_center", SqlDbType.NChar);
        param[8].Value = objbll.Center_Id;

        param[9] = new SqlParameter("@sp_class", SqlDbType.NVarChar);
        param[9].Value = objbll.Grade_Id;


        param[10] = new SqlParameter("@sp_section", SqlDbType.NChar);
        param[10].Value = objbll.Section_Id;

        param[11] = new SqlParameter("@sp_mainOrganisationID", SqlDbType.NChar);
        param[11].Value = objbll.Main_Organisation_Id;

        param[12] = new SqlParameter("@sp_teacher", SqlDbType.NChar);
        param[12].Value = objbll.Teacher_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchStudent_Export", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable SearchStudentSelectCount(BLLUploadEducationalArchive objbll)
    {



        SqlParameter[] param = new SqlParameter[13];


        param[0] = new SqlParameter("@sp_firstName", SqlDbType.NVarChar);
        param[0].Value = objbll.First_Name;

        param[1] = new SqlParameter("@sp_lastName", SqlDbType.NVarChar);
        param[1].Value = objbll.Last_Name;

        param[2] = new SqlParameter("@sp_middleName", SqlDbType.NVarChar);
        param[2].Value = objbll.Middle_Name;

        param[3] = new SqlParameter("@sp_dateOfBirth", SqlDbType.NChar);
        param[3].Value = objbll.Date_Of_Birth;

        param[4] = new SqlParameter("@sp_gender", SqlDbType.NChar);
        param[4].Value = objbll.Gender_Id;

        param[5] = new SqlParameter("@sp_studentNo", SqlDbType.NVarChar);
        param[5].Value = objbll.Student_No;

        param[6] = new SqlParameter("@sp_region", SqlDbType.NChar);
        param[6].Value = objbll.Region_Id;

        param[7] = new SqlParameter("@sp_studentStatus", SqlDbType.NChar);
        param[7].Value = objbll.Student_Status_Id;

        param[8] = new SqlParameter("@sp_center", SqlDbType.NChar);
        param[8].Value = objbll.Center_Id;

        param[9] = new SqlParameter("@sp_class", SqlDbType.NVarChar);
        param[9].Value = objbll.Grade_Id;


        param[10] = new SqlParameter("@sp_section", SqlDbType.NChar);
        param[10].Value = objbll.Section_Id;

        param[11] = new SqlParameter("@sp_mainOrganisationID", SqlDbType.NChar);
        param[11].Value = objbll.Main_Organisation_Id;

        param[12] = new SqlParameter("@sp_teacher", SqlDbType.NChar);
        param[12].Value = objbll.Teacher_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchStudentCount_New", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }
    public DataTable SearchStudentSelectByStatusID(BLLUploadEducationalArchive objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchStudentSelectByStatusID");
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable Class_CenterSelect_For_Alumni_students(BLLUploadEducationalArchive objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[0].Value = objbll.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[Class_CenterSelectByCenter_Id_For_Alumni]", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable CenterSelectByCounselor(int User_Id, int Rgion_Id)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@User_ID", SqlDbType.Int);
        param[0].Value = User_Id;
        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = Rgion_Id;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[CenterSelectByCounselor]", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }
    public DataTable SelectAllUniNames()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[SelectAllUniName]");
            return _dt;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            dalobj.CloseConnection();
        }
    }

    public int Uni_Student_Placement_Insert(BLLUploadEducationalArchive objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Us_Uni_Fk", SqlDbType.Int);
        param[0].Value = objbll.Us_Uni_Fk;

        param[1] = new SqlParameter("@Us_Std_Id", SqlDbType.Int);
        param[1].Value = objbll.Us_Std_Id;

        param[2] = new SqlParameter("@Us_Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Us_Center_Id;

        param[3] = new SqlParameter("@Us_Status", SqlDbType.NVarChar);
        param[3].Value = objbll.Us_Status;

        param[4] = new SqlParameter("@AddTag", SqlDbType.NVarChar);
        param[4].Value = objbll.Us_AddTag;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("University_Student_Placement_Insert", param);
        int k = (int)param[5].Value;
        return k;
    }

    public DataTable Get_University_student_Placement_List(int Student_id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = Student_id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Get_All_Universities", param);
            _dt = dalobj.sqlcmdFetch("Get_Uni_student_Placement_Lst", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;
    }


    public int Alumni_Student_Documents_Insert(BLLUploadEducationalArchive objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Ad_Std_Id", SqlDbType.Int);
        param[0].Value = objbll.Ad_Std_Id;

        param[1] = new SqlParameter("@Ad_Doc_Name", SqlDbType.NVarChar);
        param[1].Value = objbll.Ad_Doc_Name;

        param[2] = new SqlParameter("@Ad_Doc_Path", SqlDbType.NVarChar);
        param[2].Value = objbll.Ad_Doc_Path;



        param[3] = new SqlParameter("@AddTag", SqlDbType.NVarChar);
        param[3].Value = objbll.Ad_AddTag;

        param[4] = new SqlParameter("@Ad_Uni_Fk", SqlDbType.Int);
        param[4].Value = objbll.Ad_Uni_Fk;




        dalobj.sqlcmdExecute("Alumni_Student_Doc_Insert", param);
        //int k = (int)param[5].Value;
        return 1;
    }


    public void Updatestatus(int Us_ID, string Status, string Remarks)
    {
        var test = dalobj._cn;
        DataTable table = new DataTable("Table");
        using (SqlConnection connection = new SqlConnection(test.ConnectionString))
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "UPDATE University_student_Placement SET Us_Status = '" + Status + "',Us_Remarks='" + Remarks + "' WHERE Us_ID=" + Us_ID
            };
            connection.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }
    }



    public DataTable Get_Uploaded_Docs_List(int Student_id, int Uni_Id)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = Student_id;
        param[1] = new SqlParameter("@Uni_Id", SqlDbType.Int);
        param[1].Value = Uni_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Get_All_Universities", param);
            _dt = dalobj.sqlcmdFetch("Get_Upload_Docs_List", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;
    }



    public DataTable CenterSelectByRegionIDfor_Alumni(int Region_Id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@pv_region_id", SqlDbType.Int);
        param[0].Value = Region_Id;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCenterFromRegion_ForAlumni", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    public DataTable CounselorsSelectByCenterIDfor_Alumni(int Center_Id)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[0].Value = Center_Id;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("[CounselorsSelectByCenterid]", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }



    public DataTable TrackAlumni(BLLUploadEducationalArchive objbll)
    {

        SqlParameter[] param = new SqlParameter[14];


        param[0] = new SqlParameter("@sp_firstName", SqlDbType.NVarChar);
        param[0].Value = objbll.First_Name;

        param[1] = new SqlParameter("@sp_lastName", SqlDbType.NVarChar);
        param[1].Value = objbll.Last_Name;

        param[2] = new SqlParameter("@sp_middleName", SqlDbType.NVarChar);
        param[2].Value = objbll.Middle_Name;

        param[3] = new SqlParameter("@sp_dateOfBirth", SqlDbType.NChar);
        param[3].Value = objbll.Date_Of_Birth;

        param[4] = new SqlParameter("@sp_gender", SqlDbType.NChar);
        param[4].Value = objbll.Gender_Id;

        param[5] = new SqlParameter("@sp_studentNo", SqlDbType.NVarChar);
        param[5].Value = objbll.Student_No;

        param[6] = new SqlParameter("@sp_region", SqlDbType.NChar);
        param[6].Value = objbll.Region_Id;

        param[7] = new SqlParameter("@sp_studentStatus", SqlDbType.NChar);
        param[7].Value = objbll.Student_Status_Id;

        param[8] = new SqlParameter("@sp_center", SqlDbType.NChar);
        param[8].Value = objbll.Center_Id;

        param[9] = new SqlParameter("@sp_class", SqlDbType.NVarChar);
        param[9].Value = objbll.Grade_Id;


        //param[10] = new SqlParameter("@sp_section", SqlDbType.NChar);
        //param[10].Value = objbll.Section_Id;

        param[10] = new SqlParameter("@sp_mainOrganisationID", SqlDbType.NChar);
        param[10].Value = objbll.Main_Organisation_Id;


        param[11] = new SqlParameter("@sp_counselor", SqlDbType.NChar);
        param[11].Value = objbll.Us_AddTag;

        //@sp_counselor

        //param[12] = new SqlParameter("@sp_teacher", SqlDbType.NChar);
        //param[12].Value = objbll.Teacher_Id;

        param[12] = new SqlParameter("@sp_end_index", SqlDbType.NChar);
        param[12].Value = objbll.EndIndex;

        param[13] = new SqlParameter("@sp_start_index", SqlDbType.NChar);
        param[13].Value = objbll.StartIndex;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Track_Alumni", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }
    #endregion


}
