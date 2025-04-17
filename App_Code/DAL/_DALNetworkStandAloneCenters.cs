using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALNetworkStandAloneCenters
/// </summary>
public class DALNetworkStandAloneCenters
{
    DALBase dalobj = new DALBase();


    public DALNetworkStandAloneCenters()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int NetworkStandAloneCentersAdd(BLLNetworkStandAloneCenters objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.NVarChar);
        param[0].Value = objbll.Center_Id;
 
        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("NetworkStandAloneCentersInsert", param);
        int k = (int)param[1].Value;
        return k;

    }
    public int NetworkStandAloneCentersUpdate(BLLNetworkStandAloneCenters objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        //param[0] = new SqlParameter("@Id", SqlDbType.Int); param[0].Value = objbll.Id;
        //param[1] = new SqlParameter("@Firstname", SqlDbType.NVarChar); param[1].Value = objbll.Firstname;
        //param[2] = new SqlParameter("@Lastname", SqlDbType.NVarChar); param[2].Value = objbll.Lastname;
        //param[3] = new SqlParameter("@Details", SqlDbType.NVarChar); param[3].Value = objbll.Details;


        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("NetworkStandAloneCentersUpdate", param);
        int k = (int)param[4].Value;
        return k;
    }
    public int NetworkStandAloneCentersDelete(BLLNetworkStandAloneCenters objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Net_Cent_Id", SqlDbType.Int);
        param[0].Value = objbll.Net_Cent_Id;


        int k = dalobj.sqlcmdExecute("NetworkStandAloneCentersDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable NetworkStandAloneCentersSelectAllCenter(BLLNetworkStandAloneCenters obj)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Region_id", SqlDbType.Int);
        param[0].Value = obj.Region_Id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("NetworkStandAloneCentersSelectCenterRegionwise", param);
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

    public DataTable NetworkStandAloneCentersSelect(BLLNetworkStandAloneCenters objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;

        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("NetworkStandAloneCentersSelectAll", param);
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

    public DataTable NetworkStandAloneCentersSelectByStatusID(BLLNetworkStandAloneCenters objbll)
    {
        DataTable dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            dt = dalobj.sqlcmdFetch("NetworkStandAloneCentersSelectByStatusID");
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




    #endregion


}
