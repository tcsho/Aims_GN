using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALTssGResourcesDetail
/// </summary>
public class _DALTssGResourcesDetail
{
    DALBase dalobj = new DALBase();

    public _DALTssGResourcesDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TssGResourcesDetailSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourcesDetailSelectAll");
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

    public int TssGResourcesDetailInsert(BLLTssGResourcesDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@GResource_ID", SqlDbType.Int);
        param[0].Value = objbll.GResource_ID;
        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = objbll.Region_ID;
        param[2] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[2].Value = objbll.Center_ID;
        param[3] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[3].Value = objbll.Class_ID;
        param[4] = new SqlParameter("@Subject_ID", SqlDbType.Int);
        param[4].Value = objbll.Subject_ID;
        param[5] = new SqlParameter("@FolderName", SqlDbType.NVarChar);
        param[5].Value = objbll.FolderName;
        param[6] = new SqlParameter("@GResourcePath", SqlDbType.NVarChar);
        param[6].Value = objbll.GResourcePath;
        param[7] = new SqlParameter("@isAllow", SqlDbType.Bit);
        param[7].Value = objbll.IsAllow;


        int k = dalobj.sqlcmdExecute("TssGResourcesDetailInsert", param);
        return k;

    }

    public int TssGResourcesDetailUpdate(BLLTssGResourcesDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@GResDetail_ID", SqlDbType.Int); 
        param[0].Value = objbll.GResDetail_ID;
        //param[1] = new SqlParameter("@GResource_ID", SqlDbType.Int); param[1].Value = objbll.GResource_ID;
        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = objbll.Region_ID;
        param[2] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[2].Value = objbll.Center_ID;
        param[3] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[3].Value = objbll.Class_ID;
        param[4] = new SqlParameter("@Subject_ID", SqlDbType.Int);
        param[4].Value = objbll.Subject_ID;
        param[5] = new SqlParameter("@FolderName", SqlDbType.NVarChar);
        param[5].Value = objbll.FolderName;
        param[6] = new SqlParameter("@GResourcePath", SqlDbType.NVarChar);
        param[6].Value = objbll.GResourcePath;
        param[7] = new SqlParameter("@isAllow", SqlDbType.Bit);
        param[7].Value = objbll.IsAllow;

        int k = dalobj.sqlcmdExecute("TssGResourcesDetailUpdate", param);

        return k;

    }

    public DataTable TssGResourcesDetailSelectById(BLLTssGResourcesDetail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@GResDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.GResDetail_ID;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourcesDetailSelectById", param);
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

    public int TssGResourcesDetailDelete(BLLTssGResourcesDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@GResDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.GResDetail_ID;

        int k = dalobj.sqlcmdExecute("TssGResourcesDetailDelete", param);

        return k;

    }

    public DataTable TssGResourcesDetailSelectByGResourceId(BLLTssGResourcesDetail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@GResource_ID", SqlDbType.Int);
        param[0].Value = objbll.GResource_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourcesDetailSelectByGResourceId", param);
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

    public DataTable TssGResourcesDetailSelectByGResourceIdCampusType(BLLTssGResourcesDetail objbll)
        {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@GResource_ID", SqlDbType.Int); 
        param[0].Value = objbll.GResource_ID;
        param[1] = new SqlParameter("@Program_Id", SqlDbType.Int);
        param[1].Value = objbll.Program_ID;


        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourcesDetailSelectByGResourceIDPRogramId", param);
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


    public int TssGResourcesDetailUpdateAccess(BLLTssGResourcesDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@GResDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.GResDetail_ID;        
        param[1] = new SqlParameter("@isAllow", SqlDbType.Bit);
        param[1].Value = objbll.IsAllow;

        int k = dalobj.sqlcmdExecute("TssGResourcesDetailUpdateAccess", param);

        return k;

    }

    public DataTable TssGResourcesDetailSelectByCenterIDAndPath(BLLTssGResourcesDetail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[0].Value = objbll.Center_ID;
        param[1] = new SqlParameter("@GResourcePath", SqlDbType.NVarChar);
        param[1].Value = objbll.GResourcePath;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourcesDetailSelectByCenterIDAndPath", param);
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
