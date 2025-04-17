using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALLibLibrary
/// </summary>
public class _DALBLLTCS_StdYears
{
    DALBase dalobj = new DALBase();

    public _DALBLLTCS_StdYears()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TCS_StdYearsSelectAll()
    {   
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_StdYearsSelectAll");
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
    public DataTable TCS_StdDaysByYearMonth(int year, int month)
    {

    SqlParameter[] param = new SqlParameter[2];

    param[0] = new SqlParameter("@year", SqlDbType.Int);
    param[0].Value = year;

    param[1] = new SqlParameter("@month", SqlDbType.Int);
    param[1].Value = month;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("GetDaysByYearMonth", param);
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