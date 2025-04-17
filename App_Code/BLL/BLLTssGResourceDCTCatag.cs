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
/// Summary description for BLLTssGResourceDCTCatag
/// </summary>
public class BLLTssGResourceDCTCatag
{
    _DALTssGResourceDCTCatag objDAL = new _DALTssGResourceDCTCatag();

    private int gResourceCat_ID;
    private string gResourceCatDesc;
    private int region_Id;
    private int center_Id;
    private int status_Id;
    private DateTime createdOn;
    private int createdBy;
    private DateTime modifiedOn;
    private int modifiedBy;
    private int main_Organisation_ID;


    public int GResourceCat_ID { get { return gResourceCat_ID; } set { gResourceCat_ID = value; } }
    public string GResourceCatDesc { get { return gResourceCatDesc; } set { gResourceCatDesc = value; } }
    public int Region_Id { get { return region_Id; } set { region_Id = value; } }
    public int Center_Id { get { return center_Id; } set { center_Id = value; } }
    public int Status_Id { get { return status_Id; } set { status_Id = value; } }
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }
    public int Main_Organisation_ID { get { return main_Organisation_ID; } set { main_Organisation_ID = value; } }

    public DataTable TssGResourceDCTCatagSelectAll()
    {
        return objDAL.TssGResourceDCTCatagSelectAll();
    }

	public BLLTssGResourceDCTCatag()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int TssGResourceDCTCatagInsert(BLLTssGResourceDCTCatag objbll)
    {
        return objDAL.TssGResourceDCTCatagInsert(objbll);
    }

    public int TssGResourceDCTCatagUpdate(BLLTssGResourceDCTCatag objbll)
    {
        return objDAL.TssGResourceDCTCatagUpdate(objbll);
    }

    public DataTable TssGResourceDCTCatagSelectById(BLLTssGResourceDCTCatag objbll)
    {
        return objDAL.TssGResourceDCTCatagSelectById(objbll);
    }

    public int TssGResourceDCTCatagDelete(BLLTssGResourceDCTCatag objbll)
    {
        return objDAL.TssGResourceDCTCatagDelete(objbll);
    }
}
