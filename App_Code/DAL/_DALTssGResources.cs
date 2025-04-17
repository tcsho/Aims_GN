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
/// Summary description for _DALTssGResources
/// </summary>
public class _DALTssGResources
{
    DALBase dalobj = new DALBase();

    public _DALTssGResources()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TssGResourcesSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourcesSelectAll");
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

    public int TssGResourcesInsert(BLLTssGResources objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[0] = new SqlParameter("@GResourceCat_ID", SqlDbType.Int);
        param[0].Value = objbll.GResourceCat_ID;
        param[1] = new SqlParameter("@ResourceTitle", SqlDbType.NVarChar); 
        param[1].Value = objbll.ResourceTitle;
        param[2] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int);
        param[2].Value = objbll.Main_Organisation_ID;
        param[3] = new SqlParameter("@Session_ID", SqlDbType.Int); 
        param[3].Value = objbll.Session_ID;
        param[4] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[4].Value = objbll.Class_ID;
        param[5] = new SqlParameter("@Subject_ID", SqlDbType.Int);
        param[5].Value = objbll.Subject_ID;
        param[6] = new SqlParameter("@FolderPath", SqlDbType.NVarChar);
        param[6].Value = objbll.FolderPath;
        param[7] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[7].Value = objbll.CreatedOn;
        param[8] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[8].Value = objbll.CreatedBy;
        //param[9] = new SqlParameter("@Main_Organisation_Country_ID", SqlDbType.Int); param[9].Value = objbll.Main_Organisation_Country_ID;
        //param[10] = new SqlParameter("@Region_ID", SqlDbType.Int); param[10].Value = objbll.Region_ID;
        param[9] = new SqlParameter("@lastID", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        int k = dalobj.sqlcmdExecute("TssGResourcesInsert", param);
        if(k != -1)
        k = Convert.ToInt32(param[9].Value);
        return k;

    }

    public int TssGResourcesUpdate(BLLTssGResources objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@GResource_ID", SqlDbType.Int);
        param[0].Value = objbll.GResource_ID;
        param[1] = new SqlParameter("@GResourceCat_ID", SqlDbType.Int);
        param[1].Value = objbll.GResourceCat_ID;
        param[2] = new SqlParameter("@ResourceTitle", SqlDbType.NVarChar);
        param[2].Value = objbll.ResourceTitle;
        //param[3] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int); param[3].Value = objbll.Main_Organisation_ID;
        param[3] = new SqlParameter("@Session_ID", SqlDbType.Int);
        param[3].Value = objbll.Session_ID;
        param[4] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[4].Value = objbll.Class_ID;
        param[5] = new SqlParameter("@Subject_ID", SqlDbType.Int); 
        param[5].Value = objbll.Subject_ID;
        param[6] = new SqlParameter("@FolderPath", SqlDbType.NVarChar); 
        param[6].Value = objbll.FolderPath;        
        param[7] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); 
        param[7].Value = objbll.ModifiedOn;
        param[8] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        param[8].Value = objbll.ModifiedBy;

        int k = dalobj.sqlcmdExecute("TssGResourcesUpdate", param);

        return k;

    }

    public DataTable TssGResourcesSelectById(BLLTssGResources objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@GResource_ID", SqlDbType.Int);
        param[0].Value = objbll.GResource_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourcesSelectById", param);
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

    public int TssGResourcesDelete(BLLTssGResources objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@GResource_ID", SqlDbType.Int);
        param[0].Value = objbll.GResource_ID;       

        int k = dalobj.sqlcmdExecute("TssGResourcesDelete", param);

        return k;

    }

    public DataTable TssGResourcesSelectByRegionAndCat(BLLTssGResources objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[2];

        
        param[0] = new SqlParameter("@Region_ID", SqlDbType.Int);
        param[0].Value = objbll.Region_ID;
        param[1] = new SqlParameter("@GResourceCat_ID", SqlDbType.Int);
        param[1].Value = objbll.GResourceCat_ID;        


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourcesSelectByRegionAndCat", param);
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

    public DataTable TssGResourcesDetailSelectByCatagory(BLLTssGResources objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[6];
        
        param[0] = new SqlParameter("@Center_ID", SqlDbType.Int);
        param[0].Value = objbll.Center_ID;
        param[1] = new SqlParameter("@Session_ID", SqlDbType.Int);
        param[1].Value = objbll.Session_ID;
        param[2] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int);
        param[2].Value = objbll.Main_Organisation_ID;
        param[3] = new SqlParameter("@GResourceCat_ID", SqlDbType.Int);
        param[3].Value = objbll.GResourceCat_ID;
        param[4] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[4].Value = objbll.Class_ID;
        param[5] = new SqlParameter("@Subject_ID", SqlDbType.Int);
        param[5].Value = objbll.Subject_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourcesDetailSelectByCatagory", param);
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

    public DataTable TssGResourceDCTCatagSelectByParam(BLLTssGResources objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_ID;
        param[1] = new SqlParameter("@Session_ID", SqlDbType.Int);
        param[1].Value = objbll.Session_ID;
        param[2] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[2].Value = objbll.Class_ID;
        param[3] = new SqlParameter("@Subject_ID", SqlDbType.Int);
        param[3].Value = objbll.Subject_ID;


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


    public DataTable TssGResourceDCTCatagSelectBySubject(BLLTssGResources objbll)
        {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_ID;
        param[1] = new SqlParameter("@Session_ID", SqlDbType.Int); 
        param[1].Value = objbll.Session_ID;
        param[2] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[2].Value = objbll.Class_ID;
        param[3] = new SqlParameter("@Subject_ID", SqlDbType.Int); 
        param[3].Value = objbll.Subject_ID;


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


    public DataTable TssGResourceDCTCatagSelectBySubjectWOSession(BLLTssGResources objbll)
        {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_ID;
        param[1] = new SqlParameter("@Class_ID", SqlDbType.Int);
        param[1].Value = objbll.Class_ID;
        param[2] = new SqlParameter("@Subject_ID", SqlDbType.Int);
        param[2].Value = objbll.Subject_ID;



        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssGResourceDCTCatagSelectBySubjectWOSession", param);
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
