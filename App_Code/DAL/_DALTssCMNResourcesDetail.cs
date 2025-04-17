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
/// Summary description for _DALTssCMNResourcesDetail
/// </summary>
public class _DALTssCMNResourcesDetail
{
    DALBase dalobj = new DALBase();

    public _DALTssCMNResourcesDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TssCMNResourcesDetailSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourcesDetailSelectAll");
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

    public int TssCMNResourcesDetailInsert(BLLTssCMNResourcesDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[8];

        param[0] = new SqlParameter("@CMNResource_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResource_ID;
        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int); 
        param[1].Value = objbll.Region_ID;
        param[2] = new SqlParameter("@Center_ID", SqlDbType.Int); 
        param[2].Value = objbll.Center_ID;
        param[5] = new SqlParameter("@FolderName", SqlDbType.NVarChar);
        param[5].Value = objbll.FolderName;
        param[6] = new SqlParameter("@GResourcePath", SqlDbType.NVarChar); 
        param[6].Value = objbll.GResourcePath;
        param[7] = new SqlParameter("@isAllow", SqlDbType.Bit);
        param[7].Value = objbll.IsAllow;


        int k = dalobj.sqlcmdExecute("TssCMNResourcesDetailInsert", param);
        return k;

    }

    public int TssCMNResourcesDetailUpdate(BLLTssCMNResourcesDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@CMNResDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResDetail_ID;
        param[1] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[1].Value = objbll.Region_ID;
        param[2] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[2].Value = objbll.Center_ID;
        param[5] = new SqlParameter("@FolderName", SqlDbType.NVarChar);
        param[5].Value = objbll.FolderName;
        param[6] = new SqlParameter("@GResourcePath", SqlDbType.NVarChar);
        param[6].Value = objbll.GResourcePath;
        param[7] = new SqlParameter("@isAllow", SqlDbType.Bit);
        param[7].Value = objbll.IsAllow;

        int k = dalobj.sqlcmdExecute("TssCMNResourcesDetailUpdate", param);

        return k;

    }

    public DataTable TssCMNResourcesDetailSelectById(BLLTssCMNResourcesDetail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CMNResDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResDetail_ID;

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourcesDetailSelectById", param);
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

    public int TssCMNResourcesDetailDelete(BLLTssCMNResourcesDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CMNResDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResDetail_ID;

        int k = dalobj.sqlcmdExecute("TssCMNResourcesDetailDelete", param);

        return k;

    }

    public DataTable TssCMNResourcesDetailSelectByGResourceId(BLLTssCMNResourcesDetail objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@CMNResource_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResource_ID;

        param[1] = new SqlParameter("@Region_id", SqlDbType.Int);
        param[1].Value = objbll.Region_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourcesDetailSelectByGResourceId", param);
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

    public int TssCMNResourcesDetailUpdateAccess(BLLTssCMNResourcesDetail objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@CMNResDetail_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResDetail_ID;        
        param[1] = new SqlParameter("@isAllow", SqlDbType.Bit);
        param[1].Value = objbll.IsAllow;

        int k = dalobj.sqlcmdExecute("TssCMNResourcesDetailUpdateAccess", param);

        return k;

    }

    public DataTable TssCMNResourcesDetailSelectByCenterIDAndPath(BLLTssCMNResourcesDetail objbll)
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
            _dt = dalobj.sqlcmdFetch("TssCMNResourcesDetailSelectByCenterIDAndPath", param);
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
