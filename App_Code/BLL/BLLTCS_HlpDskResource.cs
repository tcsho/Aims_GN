using System;
using System.Data;

/// <summary>
/// Summary description for BLLTCS_HlpDskResource
/// </summary>
public class BLLTCS_HlpDskResource
{
    _DALTCS_HlpDskResource objDAL = new _DALTCS_HlpDskResource();

    private int hD_Resource_ID;
    private string employeeCode;


    public int HD_Resource_ID { get { return hD_Resource_ID; } set { hD_Resource_ID = value; } }
    public string EmployeeCode { get { return employeeCode; } set { employeeCode = value; } }



    public DataTable TCS_HlpDskResourceSelectAll()
    {
        return objDAL.TCS_HlpDskResourceSelectAll();
    }

	public BLLTCS_HlpDskResource()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int TCS_HlpDskResourceInsert(BLLTCS_HlpDskResource objbll)
    {
        return objDAL.TCS_HlpDskResourceInsert(objbll);
    }

    public int TCS_HlpDskResourceUpdate(BLLTCS_HlpDskResource objbll)
    {
        return objDAL.TCS_HlpDskResourceUpdate(objbll);
    }

    public DataTable TCS_HlpDskResourceSelectById(BLLTCS_HlpDskResource objbll)
    {
        return objDAL.TCS_HlpDskResourceSelectById(objbll);
    }

    public int TCS_HlpDskResourceDelete(BLLTCS_HlpDskResource objbll)
    {
        return objDAL.TCS_HlpDskResourceDelete(objbll);
    }

    public DataTable TCS_HlpDskResourceIDSelectByEmployeeCode(BLLTCS_HlpDskResource objbll)
    {
        return objDAL.TCS_HlpDskResourceIDSelectByEmployeeCode(objbll);
    }

    
}
