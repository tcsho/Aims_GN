using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALCenter
/// </summary>
public class _DALCenter
{
    DALBase dalobj = new DALBase();


    public _DALCenter()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int CenterAdd(BLLCenter objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        ////param[0] = new SqlParameter("@Center_Id", SqlDbType.Int); 
        ////param[0].Value = objbll.Center_Id;
        param[0] = new SqlParameter("@Center_Name", SqlDbType.NVarChar); 
        param[0].Value = objbll.Center_Name;
        param[1] = new SqlParameter("@Center_String_Id", SqlDbType.NVarChar); 
        param[1].Value = objbll.Center_String_Id;
        param[2] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[2].Value = objbll.Region_Id;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@Address", SqlDbType.NVarChar);
        param[4].Value = objbll.Address;
        param[5] = new SqlParameter("@Telephone_No", SqlDbType.NVarChar);
        param[5].Value = objbll.Telephone_No;
        param[6] = new SqlParameter("@Email", SqlDbType.NVarChar);
        param[6].Value = objbll.Email;
        param[7] = new SqlParameter("@Academic_Year_Start_Month", SqlDbType.NVarChar);
        param[7].Value = objbll.Academic_Year_Start_Month;
        param[8] = new SqlParameter("@Academic_Year_End_Month", SqlDbType.NVarChar);
        param[8].Value = objbll.Academic_Year_End_Month;
        param[9] = new SqlParameter("@City_id", SqlDbType.Int);
        param[9].Value = objbll.City_id;


        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CenterInsert", param);
        int k = (int)param[10].Value;
        return k;

    }
    public int CenterUpdate(BLLCenter objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        ////param[0] = new SqlParameter("@Center_Id", SqlDbType.Int); 
        ////param[0].Value = objbll.Center_Id;
        param[0] = new SqlParameter("@Center_Name", SqlDbType.NVarChar);
        param[0].Value = objbll.Center_Name;
        param[1] = new SqlParameter("@Center_String_Id", SqlDbType.NVarChar);
        param[1].Value = objbll.Center_String_Id;
        param[2] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[2].Value = objbll.Region_Id;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@Address", SqlDbType.NVarChar);
        param[4].Value = objbll.Address;
        param[5] = new SqlParameter("@Telephone_No", SqlDbType.NVarChar);
        param[5].Value = objbll.Telephone_No;
        param[6] = new SqlParameter("@Email", SqlDbType.NVarChar);
        param[6].Value = objbll.Email;
        param[7] = new SqlParameter("@Academic_Year_Start_Month", SqlDbType.NVarChar);
        param[7].Value = objbll.Academic_Year_Start_Month;
        param[8] = new SqlParameter("@Academic_Year_End_Month", SqlDbType.NVarChar);
        param[8].Value = objbll.Academic_Year_End_Month;
        param[9] = new SqlParameter("@City_id", SqlDbType.Int);
        param[9].Value = objbll.City_id;


 
        param[10] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[10].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CenterUpdate", param);
        int k = (int)param[10].Value;
        return k;
    }

    internal DataTable GetRegionByRegionId(BLLCenter_Class_TermDays objClsSec)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@RegionId", SqlDbType.Int);
        param[0].Value = objClsSec.Region_Id;
        DataTable _dt = new DataTable();
       try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetRegionByRegionId", param);
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

    public int CenterDelete(BLLCenter objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Center_Id;


        int k = dalobj.sqlcmdExecute("CenterDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable CenterSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@sp_user_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("GetCenter", param);
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
    
    public DataTable CenterSelect(BLLCenter objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("CenterSelectAll", param);
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
    public DataTable CenterSelectByStatusID(BLLCenter objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CenterSelectByStatusID");
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
    
public DataTable CenterSelectByRegionIDSeatPlan(BLLCenter objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@pv_region_id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCenterFromRegionSeatPlan", param);
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

    public DataTable CenterSelectByRegionID(BLLCenter objbll)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@pv_region_id", SqlDbType.Int);
    param[0].Value = objbll.Region_Id;
    DataTable _dt = new DataTable();
    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("GetCenterFromRegion", param);
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
    public DataTable CenterSelectByRegionSessionID(BLLCenter objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;


        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCenterFromRegionSession", param);
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

    
          public DataTable CenterSelectByRegionSessionOALevelID(BLLCenter objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;


        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;

        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCenterFromRegionSessionOALevel", param);
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
    public DataTable CenterSelectByRegionID_CIE(BLLCenter objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@pv_region_id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetCenterFromRegion_CIE", param);
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
    public DataTable CenterSelectByCenterID(BLLCenter objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CenterSelectById", param);
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

    public DataTable CentersList(BLLCenter objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@pv_region_id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;
        DataTable _dt = new DataTable();
        try
        {
            dalobj.OpenConnection();
            //.. Go Live 
            _dt = dalobj.sqlcmdFetch("CentersList");
            //..For Testing
             //_dt = dalobj.sqlcmdFetch("CentersList_");
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



    


}
