using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALCIE_Student_Mapping
/// </summary>
public class DALCIE_Student_Mapping
{
    DALBase dalobj = new DALBase();


    public DALCIE_Student_Mapping()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int CIE_Student_MappingAdd(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[7];


        param[0] = new SqlParameter("@CIE_Can_Id", SqlDbType.Int);
        param[0].Value = objbll.CIE_Can_Id;

        param[1] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Id;

        param[2] = new SqlParameter("@StudentName", SqlDbType.NVarChar);
        param[2].Value = objbll.StudentName;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;

        param[4] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[4].Value = objbll.Center_Id;

        param[5] = new SqlParameter("@RegisteredAs", SqlDbType.Int);
        param[5].Value = objbll.RegisteredAs;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_Student_MappingInsert", param);
        int k = (int)param[6].Value;
        return k;

    }

    public int CIE_Student_MappingAddAllInOne(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[4];


        param[0] = new SqlParameter("@CIE_Can_Id", SqlDbType.Int);
        param[0].Value = objbll.CIE_Can_Id;

        param[1] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[1].Value = objbll.Student_Id;

        param[2] = new SqlParameter("@RegisteredAs", SqlDbType.Int);
        param[2].Value = objbll.RegisteredAs;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_Student_MappingInsertAllInOne", param);
        int k = (int)param[3].Value;
        return k;

    }

    public int CIE_FileUploadHistoryInsert(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[7];


        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        param[2] = new SqlParameter("@Glevel", SqlDbType.NVarChar);
        param[2].Value = objbll.Glevel;

        param[3] = new SqlParameter("@FileName", SqlDbType.NVarChar);
        param[3].Value = objbll.FileName;

        param[4] = new SqlParameter("@Records", SqlDbType.Int);
        param[4].Value = objbll.Records;

        param[5] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[5].Value = objbll.ResultSeries_Id;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_FileUploadHistoryInsert", param);
        int k = (int)param[6].Value;
        return k;

    }

    public int CIE_FileUploadHistoryAllInOneInsert(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[5];


        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@FileName", SqlDbType.NVarChar);
        param[1].Value = objbll.FileName;

        param[2] = new SqlParameter("@Records", SqlDbType.Int);
        param[2].Value = objbll.Records;

        param[3] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[3].Value = objbll.ResultSeries_Id;

        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_FileUploadHistoryAllInOneInsert", param);
        int k = (int)param[4].Value;
        return k;

    }

    //2023-Aug-8 hasan
    public int CIE_FileHighAchieversProcess(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[3];


        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[1].Value = objbll.ResultSeries_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_CompileHighAchieversStudent", param);
        int k = (int)param[1].Value;
        return k;

    }
    //public int CIE_FileUploadProcess(BLLCIE_Student_Mapping objbll)
    //{
    //    SqlParameter[] param = new SqlParameter[3];

    //    param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
    //    param[0].Value = objbll.Session_Id;

    //    param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
    //    param[1].Value = objbll.ResultSeries_Id;

    //    param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
    //    param[2].Direction = ParameterDirection.Output;

    //    dalobj.sqlcmdExecuteTimeOutMin("CIE_Student_MatchingProcess", param, 10000); //5
    //    int k = (int)param[2].Value;
    //    return k;

    //}


    public int CIE_FileUploadProcess(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[1].Value = objbll.ResultSeries_Id;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;
        dalobj.sqlcmdExecuteTimeOutMin("CIE_Student_MatchingProcess", param, 10000); //5
        //dalobj.sqlcmdExecuteTimeOutMin("CIE_Student_MapingRunJob", param, 10000); //5
        int k = (int)param[2].Value;
        return k;

    }


    public int CIE_Student_MappingAllAdd(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[6];


        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        param[2] = new SqlParameter("@Glevel", SqlDbType.NVarChar);
        param[2].Value = objbll.Glevel;

        param[3] = new SqlParameter("@CIE_FileUp_Id", SqlDbType.Int);
        param[3].Value = objbll.CIE_FileUp_Id;

        param[4] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[4].Value = objbll.ResultSeries_Id;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_Student_MappingAllAdd", param);
        int k = (int)param[5].Value;
        return k;

    }


    public int CIE_Student_MappingAllInOneAdd(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[4];


        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@CIE_FileUp_Id", SqlDbType.Int);
        param[1].Value = objbll.CIE_FileUp_Id;

        param[2] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[2].Value = objbll.ResultSeries_Id;

        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_Student_Mapping_AllInOneAllAdd", param);
        int k = (int)param[3].Value;
        return k;

    }


    public int CIE_Student_MappingUpdate(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@CIE_Can_Id", SqlDbType.Int);
        param[0].Value = objbll.CIE_Can_Id;

        param[1] = new SqlParameter("@CandidateNo", SqlDbType.NVarChar);
        param[1].Value = objbll.CandidateNo;

        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CIE_Student_MappingUpdate", param);
        int k = (int)param[2].Value;
        return k;
    }
    public int CIE_Student_MappingDelete(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@CIE_Can_Id", SqlDbType.Int);
        param[0].Value = objbll.CIE_Can_Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("CIE_Student_MappingDelete", param);

        return k;
    }

    public int CIE_Student_MappingDeleteAllRecords(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@CIE_FileUp_Id", SqlDbType.Int);
        param[0].Value = objbll.CIE_FileUp_Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("CIE_Student_MappingDeleteAllRecords", param);

        return k;
    }




    #endregion

    #region 'Start of Fetch Methods'
    public DataTable CIE_Student_MappingSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_Student_MappingSelectById", param);
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

    public DataTable CIE_ResultSeriesSelectAll()
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_ResultSeriesSelectAll");
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


    public DataTable CIE_ClassLevelSelect(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[1].Value = objbll.ResultSeries_Id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIEClassLevelSelect", param);
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




    public DataTable CIE_HighAchieversSelectByCenter(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        //2023-Aug-08
        param[3] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[3].Value = objbll.ResultSeries_Id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_HighAchieversSelectByCenter", param);
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


    public DataTable CIE_Student_MappingSelect(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[1].Value = objbll.ResultSeries_Id;


        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_Student_MappingSelectAll", param);
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

    public DataTable CIE_Student_MappingUploadedDataSelectByCenter_Id(BLLCIE_Student_Mapping objbll)
    {
        DataTable dt = new DataTable();

        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Glevel", SqlDbType.NVarChar);
        param[2].Value = objbll.Glevel;

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_Student_MappingUploadedDataSelectByCenter_Id", param);
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


    public DataTable CIE_FileUploadAllInDataSelectById(BLLCIE_Student_Mapping objbll)
    {
        DataTable dt = new DataTable();

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@CIE_FileUp_Id", SqlDbType.Int);
        param[0].Value = objbll.CIE_FileUp_Id;


        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_FileUploadAllInDataSelectById", param);
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


    public DataTable CIE_Student_MappingSelectBySession_Id(BLLCIE_Student_Mapping objbll)
    {
        DataTable dt = new DataTable();

        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        //param[1] = new SqlParameter("@Glevel", SqlDbType.NVarChar);
        //param[1].Value = objbll.Glevel;

        param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[1].Value = objbll.ResultSeries_Id;

        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_Student_MappingSelectBySession", param);
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

    public DataTable CIE_FileUploadHistorySelectByRecord(BLLCIE_Student_Mapping objbll)
    {
        DataTable dt = new DataTable();

        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@Glevel", SqlDbType.NVarChar);
        param[2].Value = objbll.Glevel;

        param[3] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[3].Value = objbll.ResultSeries_Id;

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_FileUploadHistorySelectByRecord", param);
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

    public DataTable CIE_FileUploadHistoryAllInOneSelectByRecord(BLLCIE_Student_Mapping objbll)
    {
        DataTable dt = new DataTable();

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[1].Value = objbll.ResultSeries_Id;

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_FileUploadHistoryAllInOneSelectByRecord", param);
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

    public DataTable CIE_StudentMappingSelectByCenter_Id(BLLCIE_Student_Mapping objbll)
    {
        DataTable dt = new DataTable();

        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;
        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_Student_MappingSelectByCenter_Id", param);
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

    public DataTable CIE_StudentMappingSelectByStudent_Id(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Student_Id", SqlDbType.Int);
        param[0].Value = objbll.Student_Id;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CIE_Student_MappingSelectByStudent_Id", param);
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

    public DataTable CIE_CenterMappingSelectByCenter_Id(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CIE_CenterPKMappingSelectByCenter_Id", param);
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

    //2023-Aug-08
    public DataTable CIE_Check_File_Duplication(string File_Name)
    {
        DataTable dt = new DataTable();

        SqlParameter[] param = new SqlParameter[1];
        param[0] = new SqlParameter("@File_Name", SqlDbType.NVarChar);
        param[0].Value = File_Name;

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_Check_File_Duplication", param);
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
    //2023-Aug-08
    //public int CIE_Check_status_For_Compilation(BLLCIE_Student_Mapping objbll)
    //{
    //    SqlParameter[] param = new SqlParameter[2];


    //    param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
    //    param[0].Value = objbll.Session_Id;

    //    param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
    //    param[1].Value = objbll.ResultSeries_Id;


    //    dalobj.sqlcmdExecute("CIE_Check_status_For_Compilation", param);
    //    int k = (int)param[1].Value;
    //    return k;

    //}

    public DataTable CIE_Check_status_For_Compilation(BLLCIE_Student_Mapping objbll)
    {
        DataTable dt = new DataTable();

        SqlParameter[] param = new SqlParameter[2];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[1].Value = objbll.ResultSeries_Id;

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("CIE_Check_status_For_Compilation", param);
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


    //2023-08-21
    public int CIE_Delete_Forecasted_Grade_Data(BLLCIE_Student_Mapping objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Session_id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        param[1] = new SqlParameter("@ResultSeries_Id", SqlDbType.Int);
        param[1].Value = objbll.ResultSeries_Id;

        int k = dalobj.sqlcmdExecute("CIE_Delete_Forecasted_Grade_Data", param);

        return k;
    }

    #endregion


}
