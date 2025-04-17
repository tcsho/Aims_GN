using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALStudent
/// </summary>
public class DLLTcs_Mobile_App_Dashboard
{
    DALBase dalobj = new DALBase();


    public DLLTcs_Mobile_App_Dashboard()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int StudentAdd(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[23];
        //param[0] = new SqlParameter("@Student_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Student_Id;
        param[0] = new SqlParameter("@Aims_Id", SqlDbType.NVarChar);
        param[0].Value = objbll.Aims_Id;
        param[1] = new SqlParameter("@Student_Status_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Status_Id;
        param[2] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[2].Value = objbll.Main_Organisation_Id;
        param[3] = new SqlParameter("@Student_No", SqlDbType.Int);
        param[3].Value = objbll.Student_No;
        param[4] = new SqlParameter("@First_Name", SqlDbType.NVarChar);
        param[4].Value = objbll.First_Name;
        param[5] = new SqlParameter("@Middle_Name", SqlDbType.NVarChar);
        param[5].Value = objbll.Middle_Name;
        param[6] = new SqlParameter("@Last_Name", SqlDbType.NVarChar);
        param[6].Value = objbll.Last_Name;
        param[7] = new SqlParameter("@Date_Of_Birth", SqlDbType.DateTime);
        param[7].Value = objbll.Date_Of_Birth;
        param[8] = new SqlParameter("@Address", SqlDbType.NVarChar);
        param[8].Value = objbll.Address;
        param[9] = new SqlParameter("@Telephone_No", SqlDbType.NVarChar);
        param[9].Value = objbll.Telephone_No;
        param[10] = new SqlParameter("@Gender_Id", SqlDbType.Int);
        param[10].Value = objbll.Gender_Id;
        param[11] = new SqlParameter("@City", SqlDbType.NVarChar);
        param[11].Value = objbll.City;
        param[12] = new SqlParameter("@State", SqlDbType.NVarChar);
        param[12].Value = objbll.State;
        param[13] = new SqlParameter("@Country", SqlDbType.NVarChar);
        param[13].Value = objbll.Country;
        param[14] = new SqlParameter("@Postal_Code", SqlDbType.NVarChar);
        param[14].Value = objbll.Postal_Code;
        param[15] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[15].Value = objbll.Comments;
        param[13] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[13].Value = objbll.Region_Id;
        param[14] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[14].Value = objbll.Center_Id;
        param[15] = new SqlParameter("@Grade_Id", SqlDbType.Int);
        param[15].Value = objbll.Grade_Id;
        param[16] = new SqlParameter("@Approval_Date", SqlDbType.DateTime);
        param[16].Value = objbll.Approval_Date;
        param[17] = new SqlParameter("@Application_Date", SqlDbType.DateTime);
        param[17].Value = objbll.Application_Date;
        param[18] = new SqlParameter("@Transfer_Date", SqlDbType.DateTime);
        param[18].Value = objbll.Transfer_Date;
        param[19] = new SqlParameter("@Drop_Date", SqlDbType.DateTime);
        param[19].Value = objbll.Drop_Date;
        param[20] = new SqlParameter("@FatherEmail", SqlDbType.NVarChar);
        param[20].Value = objbll.FatherEmail;
        param[21] = new SqlParameter("@Student_noI", SqlDbType.Int);
        param[21].Value = objbll.Student_noI;
        param[22] = new SqlParameter("@fullname", SqlDbType.NVarChar);
        param[22].Value = objbll.fullname;


        param[23] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[23].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("StudentInsert", param);
        int k = (int)param[23].Value;
        return k;

    }
    public int StudentUpdate(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[23];

        //param[0] = new SqlParameter("@Student_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Student_Id;
        param[0] = new SqlParameter("@Aims_Id", SqlDbType.NVarChar);
        param[0].Value = objbll.Aims_Id;
        param[1] = new SqlParameter("@Student_Status_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Status_Id;
        param[2] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[2].Value = objbll.Main_Organisation_Id;
        param[3] = new SqlParameter("@Student_No", SqlDbType.Int);
        param[3].Value = objbll.Student_No;
        param[4] = new SqlParameter("@First_Name", SqlDbType.NVarChar);
        param[4].Value = objbll.First_Name;
        param[5] = new SqlParameter("@Middle_Name", SqlDbType.NVarChar);
        param[5].Value = objbll.Middle_Name;
        param[6] = new SqlParameter("@Last_Name", SqlDbType.NVarChar);
        param[6].Value = objbll.Last_Name;
        param[7] = new SqlParameter("@Date_Of_Birth", SqlDbType.DateTime);
        param[7].Value = objbll.Date_Of_Birth;
        param[8] = new SqlParameter("@Address", SqlDbType.NVarChar);
        param[8].Value = objbll.Address;
        param[9] = new SqlParameter("@Telephone_No", SqlDbType.NVarChar);
        param[9].Value = objbll.Telephone_No;
        param[10] = new SqlParameter("@Gender_Id", SqlDbType.Int);
        param[10].Value = objbll.Gender_Id;
        param[11] = new SqlParameter("@City", SqlDbType.NVarChar);
        param[11].Value = objbll.City;
        param[12] = new SqlParameter("@State", SqlDbType.NVarChar);
        param[12].Value = objbll.State;
        param[13] = new SqlParameter("@Country", SqlDbType.NVarChar);
        param[13].Value = objbll.Country;
        param[14] = new SqlParameter("@Postal_Code", SqlDbType.NVarChar);
        param[14].Value = objbll.Postal_Code;
        param[15] = new SqlParameter("@Comments", SqlDbType.NVarChar);
        param[15].Value = objbll.Comments;
        param[13] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[13].Value = objbll.Region_Id;
        param[14] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[14].Value = objbll.Center_Id;
        param[15] = new SqlParameter("@Grade_Id", SqlDbType.Int);
        param[15].Value = objbll.Grade_Id;
        param[16] = new SqlParameter("@Approval_Date", SqlDbType.DateTime);
        param[16].Value = objbll.Approval_Date;
        param[17] = new SqlParameter("@Application_Date", SqlDbType.DateTime);
        param[17].Value = objbll.Application_Date;
        param[18] = new SqlParameter("@Transfer_Date", SqlDbType.DateTime);
        param[18].Value = objbll.Transfer_Date;
        param[19] = new SqlParameter("@Drop_Date", SqlDbType.DateTime);
        param[19].Value = objbll.Drop_Date;
        param[20] = new SqlParameter("@FatherEmail", SqlDbType.NVarChar);
        param[20].Value = objbll.FatherEmail;
        param[21] = new SqlParameter("@Student_noI", SqlDbType.Int);
        param[21].Value = objbll.Student_noI;
        param[22] = new SqlParameter("@fullname", SqlDbType.NVarChar);
        param[22].Value = objbll.fullname;



        param[23] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[23].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("StudentUpdate", param);
        int k = (int)param[23].Value;
        return k;
    }
    public int StudentDelete(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Student_Id;


        int k = dalobj.sqlcmdExecute("StudentDelete", param);

        return k;
    }
    public int StudentTransfer(BLLStudent objbll, string mode)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;
        param[1] = new SqlParameter("@Center_IdOld", SqlDbType.Int);
        param[1].Value = objbll.Center_IdOld;
        param[2] = new SqlParameter("@Section", SqlDbType.NVarChar);
        param[2].Value = objbll.section_name;
        param[3] = new SqlParameter("@Grade_Id", SqlDbType.Int);
        param[3].Value = objbll.Grade_Id;
        param[4] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[4].Value = objbll.Student_Id;
        param[5] = new SqlParameter("@Mode", SqlDbType.NVarChar);
        param[5].Value = mode;
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("StudentTransfer", param);
        int k = (int)param[6].Value;
        return k;
    }
    public int StudentSectionChange(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@ToSection_ID", SqlDbType.Int);
        param[1].Value = objbll.Section_Id;
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("_Aims_StudentSectionChange", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int StudentUnassign(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        int k = dalobj.sqlcmdExecute("_AIMSUnassignStudent", param);
        return k;
    }
    public int StudentVerificationInsert(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[11];

        param[0] = new SqlParameter("@Student_Verification_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Verification_Id;
        param[1] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Id;
        param[2] = new SqlParameter("@Student_Name", SqlDbType.NVarChar);
        param[2].Value = objbll.fullname;
        param[3] = new SqlParameter("@Student_VerificationMst_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_VerificationMst_Id;
        param[4] = new SqlParameter("@Created_By", SqlDbType.Int);
        param[4].Value = objbll.Employee_Id;
        param[5] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[5].Value = objbll.Status_Id;
        param[6] = new SqlParameter("@IsAdded", SqlDbType.Int);
        param[6].Value = objbll.IsAdded;
        param[7] = new SqlParameter("@isVerified", SqlDbType.Int);
        param[7].Value = objbll.IsVerify;


        param[8] = new SqlParameter("@TeacherRemraks", SqlDbType.NVarChar);
        param[8].Value = objbll.TeacherRemarks;


        param[9] = new SqlParameter("@AddReasonId", SqlDbType.Int);
        param[9].Value = objbll.AddReasonId;



        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_VerificationInsert", param);
        return k;
    }


    public int StudentVerificationUpdate(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Student_Verification_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Verification_Id;

        param[1] = new SqlParameter("@Modified_By", SqlDbType.Int);
        param[1].Value = objbll.ModifiedBy;

        param[2] = new SqlParameter("@isVerified", SqlDbType.Int);
        param[2].Value = objbll.IsVerify;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_VerificationUpdate", param);
        return k;
    }


    public int StudentVerificationUpdateSchool(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Student_Verification_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Verification_Id;

        param[1] = new SqlParameter("@StudentVerificationRemarks", SqlDbType.NVarChar);
        param[1].Value = objbll.SchoolVerificationRemarks;

        param[2] = new SqlParameter("@SchoolVerificationBy", SqlDbType.Int);
        param[2].Value = objbll.ModifiedBy;

        param[3] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_Id;

        param[4] = new SqlParameter("@CORemarks", SqlDbType.NVarChar);
        param[4].Value = objbll.CORemarks;

        param[5] = new SqlParameter("@ChangeMadeERP", SqlDbType.NVarChar);
        param[5].Value = objbll.ChangeMadeERP;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_VerificationUpdateSchool", param);
        return k;
    }

    public int StudentVerificationDeleteRequest(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Student_Verification_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Verification_Id;

        param[1] = new SqlParameter("@isDeleteRequest", SqlDbType.Bit);
        param[1].Value = objbll.isDeleteRequest;

        param[2] = new SqlParameter("@DeleteRequestBy", SqlDbType.Int);
        param[2].Value = objbll.DeleteRequestBy;

        param[3] = new SqlParameter("@StudentVerificationRemarks", SqlDbType.NVarChar);
        param[3].Value = objbll.SchoolVerificationRemarks;

        param[4] = new SqlParameter("@CORemarks", SqlDbType.NVarChar);
        param[4].Value = objbll.CORemarks;

        param[5] = new SqlParameter("@ChangeMadeERP", SqlDbType.NVarChar);
        param[5].Value = objbll.ChangeMadeERP;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_VerificationDeleteRequest", param);
        return k;
    }

    public int StudentVerificationDeleteRequestApproval(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Student_Verification_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Verification_Id;
        
        param[1] = new SqlParameter("@isDeleted", SqlDbType.Bit);
        param[1].Value = objbll.isDeleted;

        param[2] = new SqlParameter("@DeletedBy", SqlDbType.Int);
        param[2].Value = objbll.DeletedBy;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("Student_VerificationDeleteApproval", param);
        return k;
    }
    public int StudentVerificationMstInsert(BLLStudent objbll, bool flag)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@MonthId", SqlDbType.Int);
        param[1].Value = objbll.MonthId;

        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = objbll.Session_Id;

        param[3] = new SqlParameter("@isLock", SqlDbType.Bit);
        param[3].Value = flag;

        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[4].Value = objbll.Employee_Id;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_VerificationMstInsertUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }


    #endregion

    #region 'Start of Fetch Methods'
    public DataTable StudentSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectById", param);
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


    }
    public DataTable StudentVerificationMonthSelect(BLLStudent bllStd)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@EmployeeId", SqlDbType.Int);
        param[0].Value = bllStd.Employee_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_VerificationMSTMonths", param);
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

    public DataTable StudentVerificationReasonSelect(BLLStudent bllStd)
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_VerificationReasonSelectAll");
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
    public DataSet Student_VerificatioSelectDS(BLLStudent bllStd)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = bllStd.Employee_Id;

        param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[1].Value = bllStd.Section_Id;

        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = bllStd.Session_Id;

        param[3] = new SqlParameter("@MonthId", SqlDbType.Int);
        param[3].Value = bllStd.MonthId;

        param[4] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[4].Value = bllStd.Center_Id;

        param[5] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[5].Value = bllStd.Region_Id;

        DataSet _dt = new DataSet();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch_DS("Student_VerificationSelect", param);
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
    public DataTable Student_VerificatioSelect(BLLStudent bllStd)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[0].Value = bllStd.Employee_Id;

        param[1] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[1].Value = bllStd.Section_Id;

        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = bllStd.Session_Id;

        param[3] = new SqlParameter("@MonthId", SqlDbType.Int);
        param[3].Value = bllStd.MonthId;

        param[4] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[4].Value = bllStd.Center_Id;

        param[5] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[5].Value = bllStd.Region_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_VerificationSelect", param);
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
    public DataTable PendingStudentSectionTransferFetch(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("PendingSectionTransfer", param);
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
    public DataTable PendingStudentCenterTransferFetch(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("PendingTransferCasesList", param);
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
    public DataTable StudentSelect(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectAll", param);
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
    public DataTable GetStudents_Unassigned(BLLStudent bllStd)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@sp_mo_id", SqlDbType.Int);
        param[0].Value = bllStd.Main_Organisation_Id;

        param[1] = new SqlParameter("@sp_class_id", SqlDbType.Int);
        param[1].Value = bllStd.Class_ID;

        param[2] = new SqlParameter("@sp_center_id", SqlDbType.Int);
        param[2].Value = bllStd.Center_Id;

        param[3] = new SqlParameter("@sp_region_id", SqlDbType.Int);
        param[3].Value = bllStd.Region_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetStudents_Unassigned", param);
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

    public DataTable GetStudents_Assigned(BLLStudent bllStd)
    {

        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@sp_mo_id", SqlDbType.Int);
        param[0].Value = bllStd.Main_Organisation_Id;

        param[1] = new SqlParameter("@sp_class_id", SqlDbType.Int);
        param[1].Value = bllStd.Class_ID;

        param[2] = new SqlParameter("@sp_center_id", SqlDbType.Int);
        param[2].Value = bllStd.Center_Id;

        param[3] = new SqlParameter("@sp_region_id", SqlDbType.Int);
        param[3].Value = bllStd.Region_Id;

        param[4] = new SqlParameter("@sp_section_id", SqlDbType.Int);
        param[4].Value = bllStd.Section_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetStudents_Assigned", param);
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

    public DataTable StudentSelectByStatusID(BLLStudent objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectByStatusID");
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

    public DataTable StudentSelectByClassID(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@sp_center_id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[1].Value = objbll.Class_ID;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectByClassID", param);
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
    public DataTable StudentSelectBySectionID(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectBySection_Id", param);
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


    public DataTable StudentSelectBySection_IdForSubjectCommentsCorrection(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Term_Id", SqlDbType.Int);
        param[2].Value = objbll.Term_Id;

        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[3].Value = objbll.Subject_Id;

        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[4].Value = objbll.Class_ID;
        
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectBySection_IdForSubjectCommentsCorrection", param);
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

    public DataTable StudentSelectBySection_IdForSubjectComments(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Term_Id", SqlDbType.Int);
        param[2].Value = objbll.Term_Id;

        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[3].Value = objbll.Subject_Id;

        param[4] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[4].Value = objbll.Student_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectBySection_IdForSubjectComments", param);
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

    public DataTable StudentSelectBySection_IdForSubjectCommentsReview(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Term_Id", SqlDbType.Int);
        param[2].Value = objbll.Term_Id;

        param[3] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[3].Value = objbll.Subject_Id;
 

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectBySection_IdForSubjectCommentsReview", param);
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


    public DataTable StudentSelectByStudentID(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectByStudent_Id", param);
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
    public DataTable StudentSelectBySectionIDTerm(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Term_Id", SqlDbType.Int);
        param[2].Value = objbll.Term_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectBySection_IdTerm", param);
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


    public DataTable StudentSelectWelcomeByClassID(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@sp_center_id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[1].Value = objbll.Class_ID;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("StudentSelectWelcomeByClassID", param);
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

    public DataTable SelectStudentsByPerformanceDeclineEmail(BLLStudent bllStd)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@center_Id", SqlDbType.Int);
        param[0].Value = bllStd.Center_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = bllStd.Session_Id;

        param[2] = new SqlParameter("@Term_Id", SqlDbType.Int);
        param[2].Value = bllStd.Term_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetStudentPerformanceDecline", param);
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


    public DataTable SelectStudentsByParentsEmail(BLLStudent bllStd)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@center_Id", SqlDbType.Int);
        param[0].Value = bllStd.Center_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = bllStd.Session_Id;

        param[2] = new SqlParameter("@Term_Id", SqlDbType.Int);
        param[2].Value = bllStd.Term_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetStudentParentsEmail", param);
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


    public int Student_Evaluation_Criteria_GraceMarksUpdate(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = objbll.Class_ID;

        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[2].Value = objbll.Subject_Id;

        param[3] = new SqlParameter("@Term_Id", SqlDbType.Int);
        param[3].Value = objbll.Term_Id;

        param[4] = new SqlParameter("@isGrace", SqlDbType.Bit);
        param[4].Value = objbll.IsGrace;


        int val = dalobj.sqlcmdExecute("Student_Evaluation_Criteria_GraceMarksUpdate", param);

        return val;
    }

    public int StudentPromotion(BLLStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Prom_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Prom_Id;

        param[1] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Id;

        param[2] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
        param[2].Value = objbll.BranchPromotionRemarks;

        int val = dalobj.sqlcmdExecute("UpdateStudentsPromote", param);

        return val;
    }
    public DataTable SelectStudent_Evaluation_Criteria_GraceMarks(BLLStudent bllStd)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = bllStd.Student_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = bllStd.Class_ID;

        param[2] = new SqlParameter("@Subject_Id", SqlDbType.Int);
        param[2].Value = bllStd.Subject_Id;

        param[3] = new SqlParameter("@Term_Id", SqlDbType.Int);
        param[3].Value = bllStd.Term_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SELECTStudent_Evaluation_Criteria_GraceMarks", param);
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

    public DataTable SelectUnpromotedStudentsByClassId(BLLStudent bllStd)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = bllStd.Center_Id;

        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[1].Value = bllStd.Class_ID;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetUnpromotedStudentsByCenterClass", param);
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
