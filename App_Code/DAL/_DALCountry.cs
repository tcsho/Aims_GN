using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALCountry
/// </summary>
public class DALCountry
{
    DALBase dalobj = new DALBase();


    public DALCountry()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int CountryAdd(BLLCountry objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        ////param[0] = new SqlParameter("@Country_Id", SqlDbType.Int); param[0].Value = objbll.Country_Id;
        param[0] = new SqlParameter("@Country_Name", SqlDbType.NVarChar); param[0].Value = objbll.Country_Name;
        param[1] = new SqlParameter("@Country_String_Id", SqlDbType.NVarChar); param[1].Value = objbll.Country_String_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int); param[2].Value = objbll.Status_Id;


        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CountryInsert", param);
        int k = (int)param[3].Value;
        return k;

    }
    public int CountryUpdate(BLLCountry objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        ////param[0] = new SqlParameter("@Country_Id", SqlDbType.Int); param[0].Value = objbll.Country_Id;
        param[0] = new SqlParameter("@Country_Name", SqlDbType.NVarChar); param[0].Value = objbll.Country_Name;
        param[1] = new SqlParameter("@Country_String_Id", SqlDbType.NVarChar); param[1].Value = objbll.Country_String_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int); param[2].Value = objbll.Status_Id;


 
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("CountryUpdate", param);
        int k = (int)param[3].Value;
        return k;
    }
    public int CountryDelete(BLLCountry objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Country_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Country_Id;


        int k = dalobj.sqlcmdExecute("CountryDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable CountrySelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("CountrySelectById", param);
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
    
    public DataTable CountrySelect(BLLCountry objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("CountrySelectAll", param);
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

    public DataTable CountrySelectByStatusID(BLLCountry objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CountrySelectByStatusID");
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
