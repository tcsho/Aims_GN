using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALMain_Organisation_Country
/// </summary>
public class DALMain_Organisation_Country
{
    DALBase dalobj = new DALBase();


    public DALMain_Organisation_Country()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Main_Organisation_CountryAdd(BLLMain_Organisation_Country objbll)
    {
        SqlParameter[] param = new SqlParameter[3];
        //param[0] = new SqlParameter("@Main_Organisation_Country_Id", SqlDbType.Int);
        //param[0].Value = objbll.Main_Organisation_Country_Id;
        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Country_Id", SqlDbType.Int);
        param[1].Value = objbll.Country_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[2].Value = objbll.Status_Id;


        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Main_Organisation_CountryInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int Main_Organisation_CountryUpdate(BLLMain_Organisation_Country objbll)
    {
        SqlParameter[] param = new SqlParameter[3];
        //param[0] = new SqlParameter("@Main_Organisation_Country_Id", SqlDbType.Int);
        //param[0].Value = objbll.Main_Organisation_Country_Id;
        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Country_Id", SqlDbType.Int);
        param[1].Value = objbll.Country_Id;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[2].Value = objbll.Status_Id;


 
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[3].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Main_Organisation_CountryUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Main_Organisation_CountryDelete(BLLMain_Organisation_Country objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Main_Organisation_Country_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Main_Organisation_Country_Id;


        int k = dalobj.sqlcmdExecute("Main_Organisation_CountryDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Main_Organisation_CountrySelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Main_Organisation_Country_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Main_Organisation_CountrySelectById", param);
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
    
    public DataTable Main_Organisation_CountrySelect(BLLMain_Organisation_Country objbll)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
    param[0].Value = objbll.Main_Organisation_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("Main_Organisation_CountrySelectByMainOrg_Id", param);
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

    public DataTable Main_Organisation_CountrySelectByStatusID(BLLMain_Organisation_Country objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Main_Organisation_CountrySelectByStatusID");
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
