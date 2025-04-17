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
using System.Collections.Generic;

/// <summary>
/// Summary description for _DALSearchSection
/// </summary>
public class DALSearchSection
{
    DALBase dalobj = new DALBase();


    public DALSearchSection()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int SearchSectionAdd(BLLSearchSection objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SearchSectionInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int SearchSectionUpdate(BLLSearchSection objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SearchSectionUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int SearchSectionDelete(BLLSearchSection objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@SearchSection_Id", SqlDbType.Int);
     //   param[0].Value = objbll.SearchSection_Id;


        int k = dalobj.sqlcmdExecute("SearchSectionDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable SearchSectionSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("SearchSectionSelectById", param);
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
    
    public DataTable SearchSectionSelect(BLLSearchSection objbll)
    {
    SqlParameter[] param = new SqlParameter[7];

    
        param[0] = new SqlParameter("@sp_className", SqlDbType.NVarChar);
        param[0].Value = objbll.Class_Name;

        param[1] = new SqlParameter("@sp_class", SqlDbType.NVarChar);
        param[1].Value = objbll.Class_Id;

        param[2] = new SqlParameter("@sp_region", SqlDbType.NVarChar);
        param[2].Value = objbll.Region_Id;

        param[3] = new SqlParameter("@sp_center", SqlDbType.NVarChar);
        param[3].Value = objbll.Center_Id;

        param[4] = new SqlParameter("@sp_subject", SqlDbType.NVarChar);
        param[4].Value = objbll.Subject_Id;

        param[5] = new SqlParameter("@sp_moID", SqlDbType.NVarChar);
        param[5].Value = objbll.Mo_Id;

        param[6] = new SqlParameter("@sp_teacher", SqlDbType.NVarChar);
        param[6].Value = objbll.Teacer_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("SearchSection", param);
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

    public DataTable SearchSectionSelectByStatusID(BLLSearchSection objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("SearchSectionSelectByStatusID");
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
