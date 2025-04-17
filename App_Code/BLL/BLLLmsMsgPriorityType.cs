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
/// Summary description for BLLLmsMsgPriorityType
/// </summary>
public class BLLLmsMsgPriorityType
{

    _DALLmsMsgPriorityType objdal = new _DALLmsMsgPriorityType();

	public BLLLmsMsgPriorityType()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private int priorityType_ID;
    private string priorityTypeDesc;

    public int PriorityType_ID { get { return priorityType_ID; } set { priorityType_ID = value; } }
    public string PriorityTypeDesc { get { return priorityTypeDesc; } set { priorityTypeDesc = value; } }

    public DataTable LmsMsgPriorityTypeSelectAll()
    {
        return objdal.LmsMsgPriorityTypeSelectAll();
    }

}
