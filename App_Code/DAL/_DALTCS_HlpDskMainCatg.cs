using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALTCS_HlpDskMainCatg
/// </summary>
public class _DALTCS_HlpDskMainCatg
{
    DALBase dalobj = new DALBase();

    public _DALTCS_HlpDskMainCatg()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TCS_HlpDskMainCatgSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskMainCatgSelectAll");
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

    public int TCS_HlpDskMainCatgInsert(BLLTCS_HlpDskMainCatg objbll)
    {
        SqlParameter[] param = new SqlParameter[3];


        
        param[0] = new SqlParameter("@MCatDesc",SqlDbType.NVarChar);	param[0].Value = objbll.MCatDesc;
        param[1] = new SqlParameter("@Main_Organisation_Id",SqlDbType.Int);	param[1].Value = objbll.Main_Organisation_Id;
        param[2] = new SqlParameter("@alreadyExists", SqlDbType.Int); param[2].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("TCS_HlpDskMainCatgInsert", param);
        k = Convert.ToInt32(param[2].Value);
        return k;

    }

    public int TCS_HlpDskMainCatgUpdate(BLLTCS_HlpDskMainCatg objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@MCatg_ID",SqlDbType.Int);	param[0].Value = objbll.MCatg_ID;
        param[1] = new SqlParameter("@MCatDesc",SqlDbType.NVarChar);	param[1].Value = objbll.MCatDesc;



        int k = dalobj.sqlcmdExecute("TCS_HlpDskMainCatgUpdate", param);

        return k;

    }

    public DataTable TCS_HlpDskMainCatgSelectById(BLLTCS_HlpDskMainCatg objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@MCatg_ID", SqlDbType.Int); param[0].Value = objbll.MCatg_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskMainCatgSelectById", param);
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

    public int TCS_HlpDskMainCatgDelete(BLLTCS_HlpDskMainCatg objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@MCatg_ID", SqlDbType.Int); param[0].Value = objbll.MCatg_ID;
        int k = dalobj.sqlcmdExecute("TCS_HlpDskMainCatgDelete", param);

        return k;

    }

    /*public DataTable TCS_HlpDskMainCatgSelectByCenterId(BLLTCS_HlpDskMainCatg objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int); param[0].Value = objbll.Center_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskMainCatgSelectByCenterId", param);
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


    public DataTable TCS_HlpDskMainCatgSelectByMainOrgID(BLLTCS_HlpDskMainCatg objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int); param[0].Value = objbll.Main_Organisation_Id;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskMainCatgSelectByMainOrgID", param);
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
