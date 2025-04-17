using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for _DALResultHidingCode
/// </summary>
public class _DALResultHidingCode
{
    DALBase dalobj = new DALBase();
    public _DALResultHidingCode()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable GETResultHideCodingAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("ResultHideCodingSelectAll");
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

    

}