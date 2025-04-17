using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for _DALLmsMsgPriorityType
/// </summary>
public class _DALLmsMsgPriorityType
{
    DALBase dalobj = new DALBase();
	public _DALLmsMsgPriorityType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public DataTable LmsMsgPriorityTypeSelectAll()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsMsgPriorityTypeSelectAll");
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
