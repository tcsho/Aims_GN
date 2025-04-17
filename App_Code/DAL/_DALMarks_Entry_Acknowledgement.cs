using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALMarks_Entry_Acknowledgement
/// </summary>
public class DALMarks_Entry_Acknowledgement
{
    DALBase dalobj = new DALBase();


    public DALMarks_Entry_Acknowledgement()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Marks_Entry_AcknowledgementAdd(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[0].Value = objbll.Evaluation_Criteria_Type_Id;

        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[1].Value = objbll.Section_Subject_Id;

        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = objbll.Session_Id;

        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[3].Value = objbll.CreatedOn;

        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[4].Value = objbll.CreatedBy;


        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Marks_Entry_AcknowledgementInsert", param);
        int k = (int)param[5].Value;
        return k;

    }
    public int Marks_Entry_AcknowledgementUpdate(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Marks_Entry_AcknowledgementUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Marks_Entry_AcknowledgementDelete(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Marks_Entry_Acknowledgement_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Marks_Entry_Acknowledgement_Id;


        int k = dalobj.sqlcmdExecute("Marks_Entry_AcknowledgementDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Marks_Entry_AcknowledgementSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Marks_Entry_AcknowledgementSelectById", param);
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




    public DataTable Marks_Entry_AcknowledgementSelect(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Marks_Entry_AcknowledgementSelectAll", param);
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



    public DataTable Marks_Entry_DataFetchResultPerformance(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;

        param[3] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_Id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("TCS_Result_StudentPerformanceGradeSection", param);
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


    public DataTable Marks_Entry_DataFetchResultStudentInformation(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;

        param[3] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_Id;
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("TCS_Result_StudentInformation", param);
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



    public DataTable Marks_Entry_DataFetchResultStudentPerformanceGradeSection(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;
        param[3] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_Id;
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("TCS_Result_StudentPerformanceSection", param);
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


    public DataTable Marks_Entry_DataFetchResult(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;

        param[3] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_Id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("TCS_Result_SectionResultAllPOPULATE", param);
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

    public DataTable Marks_Entry_DataFetchResult_OA(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;

        param[3] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_Id;
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("TCS_Result_SectionResultAll_OAPOPULATE", param);
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
    public DataTable Marks_Entry_AcknowledgementSelectByEmployeeSession(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        //param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        //param[0].Value = objbll.Section_Id;

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Employee_Id", SqlDbType.Int);
        param[1].Value = objbll.Employee_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Marks_Entry_AcknowledgementSelectByEmployeeSession", param, 120);
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


    public DataTable Marks_Entry_AcknowledgementSelectBySectionSessionId(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;



        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Marks_Entry_AcknowledgementSelectBySectionSessionID", param);
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

    public DataTable Marks_Entry_AcknowledgementSelectByStatusID(BLLMarks_Entry_Acknowledgement objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("Marks_Entry_AcknowledgementSelectByStatusID");
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

    public int Marks_Entry_AcknowledgementSelectBySectionSessionVerify(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[2].Value = objbll.Evaluation_Criteria_Type_Id;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Marks_Entry_AcknowledgementSelectBySectionSessionVerify", param);
        int k = (int)param[3].Value;
        return k;

    }


    #endregion




    public DataTable Marks_Entry_DataFetchResultStudentInformation_New(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;

        param[3] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_Id;
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("TCS_Result_StudentInformation_Class1_And_2", param);
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

    public DataTable Marks_Entry_DataFetchResultStudentPerformanceGradeSection_CLASS1_2(BLLMarks_Entry_Acknowledgement objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;
        param[3] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[3].Value = objbll.Student_Id;
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("TCS_Result_StudentPerformanceSection_NEW_CLASS1_2", param);
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


}
