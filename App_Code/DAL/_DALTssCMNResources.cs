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
/// Summary description for _DALTssCMNResources
/// </summary>
public class _DALTssCMNResources
{
    DALBase dalobj = new DALBase();

    public _DALTssCMNResources()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TssCMNResourcesSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourcesSelectAll");
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

    public int TssCMNResourcesInsert(BLLTssCMNResources objbll)
    {
        SqlParameter[] param = new SqlParameter[6];


        param[0] = new SqlParameter("@ResourceTitle", SqlDbType.NVarChar); 
        param[0].Value = objbll.ResourceTitle;
        
        param[1] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int); 
        param[1].Value = objbll.Main_Organisation_ID;
        
        param[2] = new SqlParameter("@FolderPath", SqlDbType.NVarChar); 
        param[2].Value = objbll.FolderPath;
        
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[3].Value = objbll.CreatedOn;
        
        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[4].Value = objbll.CreatedBy;
        
        param[5] = new SqlParameter("@lastID", SqlDbType.Int); 
        param[5].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("TssCMNResourcesInsert", param);
        if(k != -1)
        k = Convert.ToInt32(param[5].Value);
        return k;

    }

    public int TssCMNResourcesUpdate(BLLTssCMNResources objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@CMNResource_ID", SqlDbType.Int); 
        param[0].Value = objbll.CMNResource_ID;
        param[1] = new SqlParameter("@CMNResourceCat_ID", SqlDbType.Int); 
        param[1].Value = objbll.CMNResourceCat_ID;
        param[2] = new SqlParameter("@ResourceTitle", SqlDbType.NVarChar); 
        param[2].Value = objbll.ResourceTitle;
        param[6] = new SqlParameter("@FolderPath", SqlDbType.NVarChar);
        param[6].Value = objbll.FolderPath;        
        param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[7].Value = objbll.ModifiedOn;
        param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[8].Value = objbll.ModifiedBy;

        int k = dalobj.sqlcmdExecute("TssCMNResourcesUpdate", param);

        return k;

    }

    public DataTable TssCMNResourcesSelectById(BLLTssCMNResources objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CMNResource_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResource_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourcesSelectById", param);
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

    public int TssCMNResourcesDelete(BLLTssCMNResources objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CMNResource_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResource_ID;       

        int k = dalobj.sqlcmdExecute("TssCMNResourcesDelete", param);

        return k;

    }

    public DataTable TssCMNResourcesSelectByMoId(BLLTssCMNResources objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];


        param[0] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int); 
        param[0].Value = objbll.Main_Organisation_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourcesSelectByMoId", param);
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


    public DataTable TssCMNResourcesSelectByMoIdCId(BLLTssCMNResources objbll)
        {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[2];


        param[0] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_ID;

        param[1] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[1].Value = objbll.Center_ID;

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourcesSelectByMoIdCId", param);
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

    public DataTable TssCMNResourcesDetailSelectByCatagory(BLLTssCMNResources objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[3];
        
        param[0] = new SqlParameter("@Center_ID", SqlDbType.Int); 
        param[0].Value = objbll.Center_ID;
        
        param[1] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int); 
        param[1].Value = objbll.Main_Organisation_ID;

        param[2] = new SqlParameter("@CMNResource_ID", SqlDbType.Int);
        param[2].Value=objbll.CMNResource_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourcesDetailSelectByCatagory", param);
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

    public DataTable TssGResourcesDCTCatagSelectByParam(BLLTssCMNResources objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourceDCTCatagSelectByParam", param);
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


    public DataTable TssGResourcesDCTCatagSelectBySubject(BLLTssCMNResources objbll)
        {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_ID;
      

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourceDCTCatagSelectBySubject", param);
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
