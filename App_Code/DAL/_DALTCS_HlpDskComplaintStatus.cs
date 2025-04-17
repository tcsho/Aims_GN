using System;
using System.Data;

/// <summary>
/// Summary description for _DALTCS_HlpDskComplaintStatus
/// </summary>
public class _DALTCS_HlpDskComplaintStatus
{
    DALBase dalobj = new DALBase();

	public _DALTCS_HlpDskComplaintStatus()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable TCS_HlpDskComplaintStatusSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("TCS_HlpDskComplaintStatusSelectAll");
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
