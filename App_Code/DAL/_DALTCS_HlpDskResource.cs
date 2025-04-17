using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALTCS_HlpDskResource
/// </summary>
public class _DALTCS_HlpDskResource
{
    DALBase dalobj = new DALBase();

    public _DALTCS_HlpDskResource()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TCS_HlpDskResourceSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskResourceSelectAll");
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

    public int TCS_HlpDskResourceInsert(BLLTCS_HlpDskResource objbll)
    {
        SqlParameter[] param = new SqlParameter[2];
        
        param[0] = new SqlParameter("@EmployeeCode",SqlDbType.NVarChar);	param[0].Value = objbll.EmployeeCode;
        param[1] = new SqlParameter("@alreadyExists", SqlDbType.Int); param[1].Direction = ParameterDirection.Output;




        int k = dalobj.sqlcmdExecute("TCS_HlpDskResourceInsert", param);
        k = Convert.ToInt32(param[1].Value);
        return k;

    }

    public int TCS_HlpDskResourceUpdate(BLLTCS_HlpDskResource objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@HD_Resource_ID",SqlDbType.Int);	param[0].Value = objbll.HD_Resource_ID;
        param[1] = new SqlParameter("@EmployeeCode",SqlDbType.NVarChar);	param[1].Value = objbll.EmployeeCode;




        int k = dalobj.sqlcmdExecute("TCS_HlpDskResourceUpdate", param);

        return k;

    }

    public DataTable TCS_HlpDskResourceSelectById(BLLTCS_HlpDskResource objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@HD_Resource_ID", SqlDbType.Int); param[0].Value = objbll.HD_Resource_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskResourceSelectById", param);
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

    public int TCS_HlpDskResourceDelete(BLLTCS_HlpDskResource objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@HD_Resource_ID", SqlDbType.Int); param[0].Value = objbll.HD_Resource_ID;

        int k = dalobj.sqlcmdExecute("TCS_HlpDskResourceDelete", param);

        return k;

    }

    public DataTable TCS_HlpDskResourceIDSelectByEmployeeCode(BLLTCS_HlpDskResource objbll)
    {
        DataTable _dt = new DataTable();
        
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@EmployeeCode", SqlDbType.NVarChar);
        param[0].Value = objbll.EmployeeCode;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskResourceIDSelectByEmployeeCode", param);
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

    
}
