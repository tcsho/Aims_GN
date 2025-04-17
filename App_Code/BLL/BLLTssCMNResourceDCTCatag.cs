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
/// Summary description for BLLTssCMNResourceDCTCatag
/// </summary>
public class BLLTssCMNResourceDCTCatag
{
    _DALTssCMNResourceDCTCatag objDAL = new _DALTssCMNResourceDCTCatag();

    private int cmnResourceCat_ID;
    private string cmnResourceCatDesc;
    private int region_Id;
    private int center_Id;
    private int status_Id;
    private DateTime createdOn;
    private int createdBy;
    private DateTime modifiedOn;
    private int modifiedBy;
    private int main_Organisation_ID;


    public int CMNResourceCat_ID { get { return cmnResourceCat_ID; } set { cmnResourceCat_ID = value; } }
    public string CMNResourceCatDesc { get { return cmnResourceCatDesc; } set { cmnResourceCatDesc = value; } }
    public int Region_Id { get { return region_Id; } set { region_Id = value; } }
    public int Center_Id { get { return center_Id; } set { center_Id = value; } }
    public int Status_Id { get { return status_Id; } set { status_Id = value; } }
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }
    public int Main_Organisation_ID { get { return main_Organisation_ID; } set { main_Organisation_ID = value; } }

    public DataTable TssCMNResourceDCTCatagSelectAll()
    {
        return objDAL.TssCMNResourceDCTCatagSelectAll();
    }

	public BLLTssCMNResourceDCTCatag()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public int TssCMNResourceDCTCatagInsert(BLLTssCMNResourceDCTCatag objbll)
    {
        return objDAL.TssCMNResourceDCTCatagInsert(objbll);
    }

    public int TssCMNResourceDCTCatagUpdate(BLLTssCMNResourceDCTCatag objbll)
    {
        return objDAL.TssCMNResourceDCTCatagUpdate(objbll);
    }

    public DataTable TssCMNResourceDCTCatagSelectById(BLLTssCMNResourceDCTCatag objbll)
    {
        return objDAL.TssCMNResourceDCTCatagSelectById(objbll);
    }

    public int TssCMNResourceDCTCatagDelete(BLLTssCMNResourceDCTCatag objbll)
    {
        return objDAL.TssCMNResourceDCTCatagDelete(objbll);
    }
}
