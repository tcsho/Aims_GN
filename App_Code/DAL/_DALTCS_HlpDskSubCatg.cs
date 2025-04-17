using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALTCS_HlpDskSubCatg
/// </summary>
public class _DALTCS_HlpDskSubCatg
{
    DALBase dalobj = new DALBase();

    public _DALTCS_HlpDskSubCatg()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TCS_HlpDskSubCatgSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskSubCatgSelectAll");
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

    public int TCS_HlpDskSubCatgInsert(BLLTCS_HlpDskSubCatg objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@MCatg_ID", SqlDbType.Int);
        param[0].Value = objbll.MCatg_ID;
        param[1] = new SqlParameter("@HDSubDesc", SqlDbType.NVarChar);
        param[1].Value = objbll.HDSubDesc;
        param[2] = new SqlParameter("@alreadyExists", SqlDbType.Int); 
        param[2].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("TCS_HlpDskSubCatgInsert", param);
        k = Convert.ToInt32(param[2].Value);
        return k;

    }

    public int TCS_HlpDskSubCatgUpdate(BLLTCS_HlpDskSubCatg objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@HDSubCat_ID", SqlDbType.Int); 
        param[0].Value = objbll.HDSubCat_ID;
        param[1] = new SqlParameter("@MCatg_ID", SqlDbType.Int);
        param[1].Value = objbll.MCatg_ID;
        param[2] = new SqlParameter("@HDSubDesc", SqlDbType.NVarChar); 
        param[2].Value = objbll.HDSubDesc;
        




        int k = dalobj.sqlcmdExecute("TCS_HlpDskSubCatgUpdate", param);

        return k;

    }

    public DataTable TCS_HlpDskSubCatgSelectByMCatgId(BLLTCS_HlpDskSubCatg objbll)
    {

        DataTable _dt = new DataTable();

        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@MCatg_ID", SqlDbType.Int);
        param[0].Value = objbll.MCatg_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskSubCatgSelectByMCatgId", param);
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

    public DataTable TCS_HlpDskSubCatgSelectById(BLLTCS_HlpDskSubCatg objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@HDSubCat_ID", SqlDbType.Int); 
        param[0].Value = objbll.HDSubCat_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskSubCatgSelectById", param);
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

    public int TCS_HlpDskSubCatgDelete(BLLTCS_HlpDskSubCatg objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@HDSubCat_ID", SqlDbType.Int);
        param[0].Value = objbll.HDSubCat_ID;
        int k = dalobj.sqlcmdExecute("TCS_HlpDskSubCatgDelete", param);

        return k;

    }

    /*public DataTable TCS_HlpDskSubCatgSelectByCenterId(BLLTCS_HlpDskSubCatg objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int); param[0].Value = objbll.Center_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskSubCatgSelectByCenterId", param);
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
    }*/
}
