using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALRegion
/// </summary>
public class DALRegion
{
    DALBase dalobj = new DALBase();


    public DALRegion()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int RegionAdd(BLLRegion objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        //param[0] = new SqlParameter("@Region_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Region_Id;
        param[0] = new SqlParameter("@Region_String_ID", SqlDbType.NVarChar); 
        param[0].Value = objbll.Region_String_ID;
        param[1] = new SqlParameter("@Region_Name", SqlDbType.NVarChar); 
        param[1].Value = objbll.Region_Name;
        param[2] = new SqlParameter("@Main_Organisation_Country_Id", SqlDbType.Int); 
        param[2].Value = objbll.Main_Organisation_Country_Id;
        param[3] = new SqlParameter("@Address", SqlDbType.NVarChar);
        param[3].Value = objbll.Address;
        param[4] = new SqlParameter("@Telephone_No", SqlDbType.NVarChar);
        param[4].Value = objbll.Telephone_No;
        param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
        param[5].Value = objbll.Email;
        param[6] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[6].Value = objbll.Status_Id;


        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("RegionInsert", param);
        int k = (int)param[7].Value;
        return k;

    }
    public int RegionUpdate(BLLRegion objbll)
    {
        SqlParameter[] param = new SqlParameter[7];


        //param[0] = new SqlParameter("@Region_Id", SqlDbType.Int); 
        //param[0].Value = objbll.Region_Id;
        param[0] = new SqlParameter("@Region_String_ID", SqlDbType.NVarChar);
        param[0].Value = objbll.Region_String_ID;
        param[1] = new SqlParameter("@Region_Name", SqlDbType.NVarChar);
        param[1].Value = objbll.Region_Name;
        param[2] = new SqlParameter("@Main_Organisation_Country_Id", SqlDbType.Int);
        param[2].Value = objbll.Main_Organisation_Country_Id;
        param[3] = new SqlParameter("@Address", SqlDbType.NVarChar);
        param[3].Value = objbll.Address;
        param[4] = new SqlParameter("@Telephone_No", SqlDbType.NVarChar);
        param[4].Value = objbll.Telephone_No;
        param[5] = new SqlParameter("@Email", SqlDbType.NVarChar);
        param[5].Value = objbll.Email;
        param[6] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[6].Value = objbll.Status_Id;


 
        param[7] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[7].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("RegionUpdate", param);
        int k = (int)param[7].Value;
        return k;
    }
    public int RegionDelete(BLLRegion objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
     //   param[0].Value = objbll.Region_Id;


        int k = dalobj.sqlcmdExecute("RegionDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable RegionSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("RegionSelectById", param);
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
    
    public DataTable RegionSelect(BLLRegion objbll)
    {
    SqlParameter[] param = new SqlParameter[1];

    param[0] = new SqlParameter("@Main_Organisation_Country_Id", SqlDbType.Int);
    param[0].Value = objbll.Main_Organisation_Country_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("RegionSelectAll", param);
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

    public DataTable RegionSelectByStatusID(BLLRegion objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("RegionSelectByStatusID");
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
