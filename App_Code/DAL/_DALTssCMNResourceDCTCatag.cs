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
/// Summary description for _DALTssCMNResourceDCTCatag
/// </summary>
public class _DALTssCMNResourceDCTCatag
{
    DALBase dalobj = new DALBase();

	public _DALTssCMNResourceDCTCatag()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable TssCMNResourceDCTCatagSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourceDCTCatagSelectAll");
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

    public int TssCMNResourceDCTCatagInsert(BLLTssCMNResourceDCTCatag objbll)
    {
        SqlParameter[] param = new SqlParameter[5];


        param[0] = new SqlParameter("@CMNResourceCatDesc", SqlDbType.NVarChar); 
        param[0].Value = objbll.CMNResourceCatDesc;       
        param[1] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[1].Value = objbll.CreatedOn;
        param[2] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[2].Value = objbll.CreatedBy;
        param[3] = new SqlParameter("@Main_Organisation_ID", SqlDbType.Int); 
        param[3].Value = objbll.Main_Organisation_ID;
        param[4] = new SqlParameter("@alreadyExists", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;



        int k = dalobj.sqlcmdExecute("TssCMNResourceDCTCatagInsert", param);
        k = Convert.ToInt32(param[4].Value);
        return k;

    }

    public int TssCMNResourceDCTCatagUpdate(BLLTssCMNResourceDCTCatag objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@CMNResourceCat_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResourceCat_ID;
        param[1] = new SqlParameter("@CMNResourceCatDesc", SqlDbType.NVarChar);
        param[1].Value = objbll.CMNResourceCatDesc;
        param[2] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[2].Value = objbll.ModifiedOn;
        param[3] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[3].Value = objbll.ModifiedBy;



        int k = dalobj.sqlcmdExecute("TssCMNResourceDCTCatagUpdate", param);

        return k;

    }

    public DataTable TssCMNResourceDCTCatagSelectById(BLLTssCMNResourceDCTCatag objbll)
    {

        DataTable _dt = new DataTable();


        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CMNResourceCat_ID", SqlDbType.Int); 
        param[0].Value = objbll.CMNResourceCat_ID;


        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TssCMNResourceDCTCatagSelectById", param);
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

    public int TssCMNResourceDCTCatagDelete(BLLTssCMNResourceDCTCatag objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@CMNResourceCat_ID", SqlDbType.Int);
        param[0].Value = objbll.CMNResourceCat_ID;        

        int k = dalobj.sqlcmdExecute("TssCMNResourceDCTCatagDelete", param);

        return k;

    }




}
