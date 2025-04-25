using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;



/// <summary>
/// Summary description for _DALStudent_Conditionally_Promoted_Request
/// </summary>
public class DALStudent_Conditionally_Promoted_Request
{
    DALBase dalobj = new DALBase();


    public DALStudent_Conditionally_Promoted_Request()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Student_Conditionally_Promoted_RequestAdd(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[16];

        //////param[0] = new SqlParameter("@SCPReq_Id", SqlDbType.Int);
        //////param[0].Value = objbll.SCPReq_Id;
        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Student_No", SqlDbType.Int);
        param[1].Value = objbll.Student_No;
        param[2] = new SqlParameter("@StudentName", SqlDbType.NVarChar);
        param[2].Value = objbll.StudentName;
        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;
        param[4] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[4].Value = objbll.Region_Id;
        param[5] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[5].Value = objbll.Center_Id;
        param[6] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[6].Value = objbll.Class_Id;
        param[7] = new SqlParameter("@Class_Name", SqlDbType.NVarChar);
        param[7].Value = objbll.Class_Name;
        param[8] = new SqlParameter("@Section_Name", SqlDbType.NVarChar);
        param[8].Value = objbll.Section_Name;
        param[9] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
        param[9].Value = objbll.Remarks;
        param[10] = new SqlParameter("@ClassRequest", SqlDbType.Int);
        param[10].Value = objbll.ClassRequest;
        param[11] = new SqlParameter("@TermGroupID", SqlDbType.Int);
        param[11].Value = objbll.TermGroupID;

        param[12] = new SqlParameter("@Submit_RD", SqlDbType.Bit);
        param[12].Value = objbll.Submit_RD;
        param[13] = new SqlParameter("@Submit_RD_By", SqlDbType.Int);
        param[13].Value = objbll.Submit_RD_By;
        param[14] = new SqlParameter("@Submit_RD_On", SqlDbType.DateTime);
        param[14].Value = objbll.Submit_RD_On;

        param[15] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[15].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Student_Conditionally_Promoted_RequestInsert", param);
        int k = (int)param[15].Value;
        return k;

    }
    public int Student_Conditionally_Promoted_RequestUpdate(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Remarks", SqlDbType.NVarChar);
        param[2].Value = objbll.RD_Remarks;
        
        param[3] = new SqlParameter("@RD_Approval", SqlDbType.Bit);
        param[3].Value = objbll.RD_Approval;
        param[4] = new SqlParameter("@RD_Approval_By", SqlDbType.Int);
        param[4].Value = objbll.RD_Approval_By;


        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;


        dalobj.sqlcmdExecute("Student_Conditionally_Promoted_RequestUpdate", param);
        int k = (int)param[5].Value;
        return k;
    }

    public int Student_Conditionally_Promoted_RequestUpdateEmailSent(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_IdList", SqlDbType.NVarChar);
        param[0].Value = objbll.studentist;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;


        dalobj.sqlcmdExecute("Student_Conditionally_Promoted_RequestDailyEmailUpdate", param);
        int k = (int)param[1].Value;
        return k;
    }

    public int Student_BifurcationMatricStream(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Student_Name", SqlDbType.NVarChar);
        param[1].Value = objbll.StudentName;
        param[2] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[2].Value = objbll.Region_Id;


        param[3] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[3].Value = objbll.Center_Id;


        param[4] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[4].Value = objbll.Session_Id;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[5].Value = objbll.CreatedBy;
        param[6] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[6].Value = objbll.Class_Id;

        param[7] = new SqlParameter("@PromotionStatus", SqlDbType.NVarChar);
        param[7].Value = objbll.PromotionStatus;

        param[8] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[8].Value = objbll.Section_Id;

        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("TCS_ERP_StudentPromotionStatusInsert", param);
        int k = (int)param[9].Value;
        return k;


    }
    public int Student_Conditionally_Promoted_RequestDelete(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        int k = dalobj.sqlcmdExecute("Student_Conditionally_Promoted_RequestDelete", param);

        return k;
    }

    public int Student_Conditionally_Promoted_RequestRevert(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;
        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;
        param[2] = new SqlParameter("@TermGroupID", SqlDbType.Int);
        param[2].Value = objbll.TermGroupID;
        
        int k = dalobj.sqlcmdExecute("Student_Conditionally_Promoted_RequestRevert", param);

        return k;
    }
    public int Student_PrivatiseCenterWise(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;
        dalobj.sqlcmdExecute("Student_PrivatisationCenter_Id", param);
        int k = (int)param[2].Value;
        return k;

    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Student_Expelled(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        if (objbll.Class_Id == null)
            param[3].Value = DBNull.Value;
        else
            param[3].Value = objbll.Class_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_ExpelledSelect", param);
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

    public DataTable Student_Bifurcation(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_BifurcationSelect", param);
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
    public DataTable Student_Privatisation(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        if (objbll.Class_Id == 0)
            param[3].Value = DBNull.Value;
        else
            param[3].Value = objbll.Class_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_PrivatisationSelect", param);
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
    public DataTable Student_Conditionally_Promoted_RequestSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectById", param);
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
    public DataTable Student_Conditionally_Promoted_RequestCheckStatus(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestCheckStatus", param);
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
    public DataTable Student_Conditionally_Promoted_RequestEmailSummary(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestDailyEmailSummary",param);
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
    public DataTable Student_Conditionally_Promoted_RequestSelect(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectAll", param);
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


    public DataTable Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        if (objbll.Class_Id == null)
            param[4].Value = DBNull.Value;
        else
            param[4].Value = objbll.Class_Id;

        param[5] = new SqlParameter("@RD_Approval", SqlDbType.Bit);
        if (objbll.RD_Approval == null)
            param[5].Value = DBNull.Value;
        else
            param[5].Value = objbll.RD_Approval;

        param[6] = new SqlParameter("@Submit_RD", SqlDbType.Bit);
        if (objbll.Submit_RD == null)
            param[6].Value = DBNull.Value;
        else
            param[6].Value = objbll.Submit_RD;
    
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
             _dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId", param);
            //_dt = dalobj.sqlcmdFetch("sp_bifurcation_process_MIdYearBK", param);
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

    public DataTable Student_Bifurcation_RequestSelectAllByOrgRegionCenterId(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        if (objbll.Class_Id == null)
            param[4].Value = DBNull.Value;
        else
            param[4].Value = objbll.Class_Id;

        param[5] = new SqlParameter("@RD_Approval", SqlDbType.Bit);
        if (objbll.RD_Approval == null)
            param[5].Value = DBNull.Value;
        else
            param[5].Value = objbll.RD_Approval;

        param[6] = new SqlParameter("@Submit_RD", SqlDbType.Bit);
        if (objbll.Submit_RD == null)
            param[6].Value = DBNull.Value;
        else
            param[6].Value = objbll.Submit_RD;
        param[7] = new SqlParameter("@Student_id", SqlDbType.VarChar);
        param[7].Value = objbll.Student_Id;
        param[8] = new SqlParameter("@Term", SqlDbType.VarChar);
        param[8].Value = objbll.TermGroupID;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId", param);
            _dt = dalobj.sqlcmdFetch("sp_bifurcation_process_MIdYearbk", param);
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
    public DataTable Student_Bifurcation_UndertakingNotRecieve(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        if (objbll.Class_Id == null)
            param[4].Value = DBNull.Value;
        else
            param[4].Value = objbll.Class_Id;

        param[5] = new SqlParameter("@RD_Approval", SqlDbType.Bit);
        if (objbll.RD_Approval == null)
            param[5].Value = DBNull.Value;
        else
            param[5].Value = objbll.RD_Approval;

        param[6] = new SqlParameter("@Submit_RD", SqlDbType.Bit);
        if (objbll.Submit_RD == null)
            param[6].Value = DBNull.Value;
        else
            param[6].Value = objbll.Submit_RD;
        param[7] = new SqlParameter("@Student_id", SqlDbType.VarChar);
        param[7].Value = objbll.Student_Id;
        param[8] = new SqlParameter("@Term", SqlDbType.VarChar);
        param[8].Value = objbll.TermGroupID;
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId", param);
            _dt = dalobj.sqlcmdFetch("sp_bifurcation_process_UndertakingNotRecieve", param);
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

    public string Student_Bifurcation_RequestSynWithErp(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        string returnOutput = "";
        OracleParameter[] param = new OracleParameter[9];

        param[0] = new OracleParameter("p_Student_No", OracleDbType.Double);
        param[0].Value = objbll.Student_No;
        param[1] = new OracleParameter("p_Student_Name", OracleDbType.Varchar2);
        param[1].Value = objbll.StudentName;
        param[2] = new OracleParameter("p_Region_Id", OracleDbType.Double);
        param[2].Value = objbll.Region_Id;
        param[3] = new OracleParameter("p_Grade_Id", OracleDbType.Double);
        param[3].Value = objbll.Grade_Id;

        param[4] = new OracleParameter("p_Center_Id", OracleDbType.Double);
        param[4].Value = objbll.Center_Id;
        param[5] = new OracleParameter("p_Creation_Date", OracleDbType.Date);
        param[5].Value = objbll.CreatedOn;

        param[6] = new OracleParameter("p_Section_Term", OracleDbType.NVarchar2);
        param[6].Value = objbll.TermGroupID;
        // Assuming that p_Section_Term is of type Byte, adjust the DbType accordingly

        param[7] = new OracleParameter("p_Updated_Flag", OracleDbType.Varchar2);
        param[7].Value = 0;
        //new OracleParameter("p_Updated_Flag", OracleDbType.Varchar2);
        param[8] = new OracleParameter("p_status", OracleDbType.Varchar2, 255);
        param[8].Direction = ParameterDirection.Output;


        DataTable _dt = new DataTable();

        try
        {
            using (OracleConnection cnx = new OracleConnection(ConfigurationManager.ConnectionStrings["ERPDB"].ConnectionString))
            {
                using (OracleCommand commProc = new OracleCommand())
                {
                    commProc.Connection = cnx;
                    commProc.CommandText = "AIMS_INSERT_BIFURCATION_DATA";
                    commProc.CommandType = CommandType.StoredProcedure;
                    commProc.Parameters.AddRange(param);

                    cnx.Open();
                    //commProc.ExecuteNonQuery();
                    commProc.ExecuteReader();
                    string outputV1 = commProc.Parameters["p_status"].Value.ToString();
                    returnOutput = outputV1;
                    cnx.Close();
                }
            }

            //var test = dalobj._cn;
            //DataTable table = new DataTable("Table");
            //using (SqlConnection connection = new SqlConnection(test.ConnectionString))
            //{
            //    var command = new SqlCommand
            //    {
            //        Connection = connection,
            //        CommandType = CommandType.Text,
            //        CommandText = "UPDATE Setup_BifurcationLetter SET isSync = 1 WHERE StudentID = @StudentID"
            //    };

            //    // Add parameter for StudentID
            //    command.Parameters.Add(new SqlParameter("@StudentID", objbll.Student_No));

            //    connection.Open();
            //    command.ExecuteNonQuery();
            //    connection.Close();
            //}
            try
            {
                Student_Conditionally_Setup_BifurcationLetter(objbll);
            }
            catch (Exception _exception)
            {
                throw _exception;
            }
            finally
            {
                dalobj.CloseConnection();
            }
            return returnOutput;
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    public int Student_Conditionally_Setup_BifurcationLetter(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        int k;
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@StudentID", SqlDbType.Int);
        param[0].Value = objbll.Student_No;

        param[1] = new SqlParameter("@StudentName", SqlDbType.NVarChar, 500);
        param[1].Value = objbll.StudentName;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        param[3] = new SqlParameter("@SessionID", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;

        param[4] = new SqlParameter("@ClassID", SqlDbType.Int);
        param[4].Value = objbll.Class_Id;

        param[5] = new SqlParameter("@PrintUserID", SqlDbType.Int);
        param[5].Value = objbll.CreatedBy;

        param[6] = new SqlParameter("@Term", SqlDbType.Int);
        param[6].Value = objbll.TermGroupID;

        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int)
        { Direction = ParameterDirection.Output };

        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            dalobj.sqlcmdExecute("Setup_BifurcationLetter_insert_Update", param);
            k = (int)param[7].Value;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return k;
    }

    public string Student_Bifurcation_BIFURCATION_CLASS_CHANGE(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        //string returnOutput = "";
        OracleParameter[] param = new OracleParameter[1];

        param[0] = new OracleParameter("p_Region_Id", OracleDbType.Double);
        param[0].Value = objbll.Region_Id;

        //param[8] = new OracleParameter("p_status", OracleDbType.Varchar2, 255);
        //param[8].Direction = ParameterDirection.Output;


        DataTable _dt = new DataTable();

        try
        {
            using (OracleConnection cnx = new OracleConnection(ConfigurationManager.ConnectionStrings["ERPDB"].ConnectionString))
            {
                using (OracleCommand commProc = new OracleCommand())
                {
                    commProc.Connection = cnx;
                    commProc.CommandText = "APPS.BIFURCATION_CLASS_CHANGE";
                    commProc.CommandType = CommandType.StoredProcedure;
                    commProc.Parameters.AddRange(param);
                    cnx.Open();
                    // commProc.ExecuteReader();
                    OracleDataReader reader = commProc.ExecuteReader();
                    cnx.Close();
                }
            }
            return "Success";
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }



    public DataTable Student_Conditionally_Promoted_RequestForApproval(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;
        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        if (objbll.Class_Id == null)
            param[4].Value = DBNull.Value;
        else
            param[4].Value = objbll.Class_Id;
        param[5] = new SqlParameter("@RD_Approval", SqlDbType.Bit);
        if (objbll.RD_Approval == null)
            param[5].Value = DBNull.Value;
        else
            param[5].Value = objbll.RD_Approval;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestForApproval", param);
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

    public DataTable Student_Conditionally_Promoted_RequestSelectByStatusID(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectByStatusID");
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
    
	public DataTable New_Student_Bifurcation_RequestSelectAllByOrgRegionCenterId(BLLStudent_Conditionally_Promoted_Request objbll)
	{
    		SqlParameter[] param = new SqlParameter[9];

    		param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
    		param[0].Value = objbll.Main_Organisation_Id;
    		param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
    		param[1].Value = objbll.Region_Id;
    		param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
    		param[2].Value = objbll.Center_Id;
   		 param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
    		param[3].Value = objbll.Session_Id;
    		param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
    		if (objbll.Class_Id == null)
        	param[4].Value = DBNull.Value;
   		 else
      		param[4].Value = objbll.Class_Id;

    		param[5] = new SqlParameter("@RD_Approval", SqlDbType.Bit);
    		if (objbll.RD_Approval == null)
        	param[5].Value = DBNull.Value;
    		else
        	param[5].Value = objbll.RD_Approval;

   		 param[6] = new SqlParameter("@Submit_RD", SqlDbType.Bit);
    if (objbll.Submit_RD == null)
        param[6].Value = DBNull.Value;
    else
        param[6].Value = objbll.Submit_RD;
    param[7] = new SqlParameter("@Student_id", SqlDbType.VarChar);
    param[7].Value = objbll.Student_Id;
    param[8] = new SqlParameter("@Term", SqlDbType.VarChar);
    param[8].Value = objbll.TermGroupID;
    DataTable _dt = new DataTable();

    try
    {
        dalobj.OpenConnection();
        //_dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId", param);
        _dt = dalobj.sqlcmdFetch("sp_New_bifurcation_process_MIdYearbk", param);
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
    public DataTable Bifuration_Process_Setup_Add(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroupID;
        param[3] = new SqlParameter("@BifurcationProcessDate", SqlDbType.DateTime);
        param[3].Value = objbll.BifurcationProcessDate;
        param[4] = new SqlParameter("@isActive", SqlDbType.Bit);
        param[4].Value = objbll.isActive;
        param[5] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[5].Value = objbll.Center_Id;
        param[6] = new SqlParameter("@Center_Name", SqlDbType.NVarChar);
        param[6].Value = objbll.Center_Name;
        param[7] = new SqlParameter("@UserID", SqlDbType.Int);
        param[7].Value = objbll.CreatedBy;


        
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId", param);
            _dt = dalobj.sqlcmdFetch("BifurcationProcessByCenter_InsertUPDATE", param);
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

    public DataTable GetCenterFromRegionBifurcationProces(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@pv_region_id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroupID;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCenterFromRegion_BifurcationProces", param);
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

    public DataTable GetCenterFromRegionBifurcationProces_NotFound(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@pv_region_id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[1].Value = objbll.TermGroupID;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCenterFromRegion_BifurcationProces_Not_Found", param);
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

public DataTable Student_AutomatedEmailStatus_SelectAllByOrgRegionCenterId(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[5];
 
        //param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        //param[0].Value = objbll.Main_Organisation_Id;
        param[0] = new SqlParameter("@region_id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@center_id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@session_id", SqlDbType.Int);
        param[2].Value = objbll.Session_Id;
        param[3] = new SqlParameter("@Termid", SqlDbType.VarChar);
        param[3].Value = objbll.TermGroupID;
 
        param[4] = new SqlParameter("@classid", SqlDbType.Int);
        if (objbll.Class_Id == null)
            param[4].Value = DBNull.Value;
        else
            param[4].Value = objbll.Class_Id;
 
        
        DataTable _dt = new DataTable();
 
        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId", param);
            _dt = dalobj.sqlcmdFetch("NEW_Automated_Email_Status", param);
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
    public DataTable Student_AutomatedEmailStatus_SelectAllByOrgRegionCenterId_SyncERP(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        //param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        //param[0].Value = objbll.Main_Organisation_Id;
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;
        param[2] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[2].Value = objbll.Session_Id;
        param[3] = new SqlParameter("@Term", SqlDbType.VarChar);
        param[3].Value = objbll.TermGroupID;

        param[4] = new SqlParameter("@Class_Id", SqlDbType.Int);
        if (objbll.Class_Id == null)
            param[4].Value = DBNull.Value;
        else
            param[4].Value = objbll.Class_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            //_dt = dalobj.sqlcmdFetch("Student_Conditionally_Promoted_RequestSelectAllByOrgRegionCenterId", param);
            _dt = dalobj.sqlcmdFetch("sp_bifurcation_process_UndertakingNotRecieve", param);
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

    public DataTable GetBifurcationProcesReport(BLLStudent_Conditionally_Promoted_Request objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@region_id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroupID;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Get_Bifurcation_Data", param);
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
