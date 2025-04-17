using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for DALTimeTableDataExport
/// </summary>
public class DALTimeTableDataExport
{

    DALBase dalobj = new DALBase();

    public DALTimeTableDataExport()
    {
        //
        // TODO: Add constructor logic here
        //
    }






    public DataTable TimeTableDataExport(BLLTimeTableDataExport objbll)
    {
        SqlParameter[] param = new SqlParameter[4];

        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.SessionId;

        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[1].Value = objbll.CenterId;

        param[2] = new SqlParameter("@FromClass_Id", SqlDbType.Int);
        param[2].Value = objbll.FromClassId;

        param[3] = new SqlParameter("@ToClass_Id", SqlDbType.Int);
        param[3].Value = objbll.ToClassId;
               
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("AscTimeTableDataExportXML", param);
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