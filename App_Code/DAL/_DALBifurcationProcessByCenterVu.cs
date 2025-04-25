using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for _DALBifurcationProcessByCenterVu
/// </summary>
public class _DALBifurcationProcessByCenterVu
{
    DALBase dalobj = new DALBase();


    public _DALBifurcationProcessByCenterVu()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public DataTable RegionSelect(BLLBifurcationProcessByCenter_Vu objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[0].Value = objbll.Region_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("CenterSelectAllProcessByCenter", param);
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

    public DataTable NewTermSelect(BLLBifurcationProcessByCenter_Vu objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TermSelectAllProcessByCenter");
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

    public DataTable RegionSelectByStatusID(BLLBifurcationProcessByCenter_Vu objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("RegionSelectByStatusID");
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

    public DataTable NewRegionSelect(BLLBifurcationProcessByCenter_Vu objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        //param[0] = new SqlParameter("@Main_Organisation_Country_Id", SqlDbType.Int);
        //param[0].Value = objbll.Main_Organisation_Country_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("RegionSelectAllProcessByCenter");
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