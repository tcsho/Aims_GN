using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALStudent_Evaluation_Criteria_Detail
/// </summary>
public class DALStudent_Evaluation_Criteria_Detail
{
    DALBase dalobj = new DALBase();


    public DALStudent_Evaluation_Criteria_Detail()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Evaluation_Criteria_DetailAdd(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_Criteria_DetailInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int Student_Evaluation_Criteria_DetailUpdate(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_Criteria_DetailUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Student_Evaluation_Criteria_DetailDelete(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Evaluation_Criteria_Detail_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Student_Evaluation_Criteria_Detail_Id;


        int k = dalobj.sqlcmdExecute("Student_Evaluation_Criteria_DetailDelete", param);

        return k;
    }

    public int Student_Evaluation_Criteria_DetailIsAbsentUpdate(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[6];


        param[0] = new SqlParameter("@SSECDt_Id", SqlDbType.Int);
        param[0].Value = objbll.SSEC_Id;
        param[1] = new SqlParameter("@Student_Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Section_Subject_Id;
        param[2] = new SqlParameter("@Marks_Obtained", SqlDbType.Decimal);
        param[2].Value = objbll.Marks_Obtained;
        param[3] = new SqlParameter("@Lock_Mark", SqlDbType.Bit);
        param[3].Value = objbll.Lock_Mark;
        param[4] = new SqlParameter("@isAbsent", SqlDbType.Bit);
        param[4].Value = objbll.isAbsent;
        


        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_Criteria_DetailIsAbsentUpdate", param);
        int k = (int)param[5].Value;
        return k;

        
    }



    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Evaluation_Criteria_DetailSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Student_Evaluation_Criteria_DetailSelectById", param);
        return dt;
        }
    catch (Exception _exception)
        {
        throw _exception;
        }
    finally
        {
        dalobj.CloseConnection();
        }

    return dt;
    }
    
    public DataTable Student_Evaluation_Criteria_DetailSelect(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        dt = dalobj.sqlcmdFetch("Student_Evaluation_Criteria_DetailSelectAll", param);
        return dt;
        }
    catch (Exception _exception)
        {
        throw _exception;
        }
    finally
        {
        dalobj.CloseConnection();
        }

    return dt;
    
    }

    public DataTable Student_Evaluation_Criteria_DetailSelectByStatusID(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Student_Evaluation_Criteria_DetailSelectByStatusID");
            return dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return dt;

    }


    public DataTable Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfo(BLLStudent_Evaluation_Criteria_Detail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[2].Value = objbll.Employee_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfo", param);
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

    public DataTable Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoByCenterId(BLLStudent_Evaluation_Criteria_Detail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoByCenterId", param);
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



    public DataTable Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoBySSEDTID(BLLStudent_Evaluation_Criteria_Detail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[2].Value = objbll.Employee_Id;
        param[3] = new SqlParameter("@SSECDt_Id", SqlDbType.Int);
        param[3].Value = objbll.SSEC_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Evaluation_Criteria_Detail_ScheduleTestStudentInfoBySSEDTID", param);
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



    public DataTable Student_Evaluation_Criteria_Detail_ScheduleTestAttendance(BLLStudent_Evaluation_Criteria_Detail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;
        param[3] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[3].Value = objbll.Employee_Id;

        
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Evaluation_Criteria_Detail_ScheduleTestAttendance", param);
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

    public DataTable Student_TermDaysSelectAllByCenterSessionId(BLLStudent_Evaluation_Criteria_Detail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_TermDaysSelectAllByCenterSessionId", param);
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


    public int Student_Evaluation_Criteria_DetailInsertMissingStudent(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@StudentId", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Section_Id", SqlDbType.Decimal);
        param[1].Value = objbll.Section_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Evaluation_CriteriaDetailInsertMissingStudent", param);
        int k = (int)param[2].Value;
        return k;

    }
    public int Student_Evaluation_Criteria_DetailUpdateXML(BLLStudent_Evaluation_Criteria_Detail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@xmlStudentCriteriaMarks", SqlDbType.NText);
        param[0].Value = objbll.XMLData;

        dalobj.sqlcmdExecute("Student_Evaluation_Criteria_DetailUpdateXML", param);
        //int k = (int)param[1].Value;
        int k = 1;
        return k;
    }



    #endregion


}
