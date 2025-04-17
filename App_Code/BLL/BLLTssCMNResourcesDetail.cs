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
/// Summary description for BLLTssGResourcesDetail
/// </summary>
public class BLLTssCMNResourcesDetail
{
    _DALTssCMNResourcesDetail objdal = new _DALTssCMNResourcesDetail(); 
    private int cmnResDetail_ID;
    private int cmnResource_ID;
    private int region_ID;
    private int center_ID;
    private string folderName;
    private string gResourcePath;
    private bool isAllow;
    private int status_ID;


    public int CMNResDetail_ID { get { return cmnResDetail_ID; } set { cmnResDetail_ID = value; } }
    public int CMNResource_ID { get { return cmnResource_ID; } set { cmnResource_ID = value; } }
    public int Region_ID { get { return region_ID; } set { region_ID = value; } }
    public int Center_ID { get { return center_ID; } set { center_ID = value; } }
    public string FolderName { get { return folderName; } set { folderName = value; } }
    public string GResourcePath { get { return gResourcePath; } set { gResourcePath = value; } }
    public bool IsAllow { get { return isAllow; } set { isAllow = value; } }
    public int Status_ID { get { return status_ID; } set { status_ID = value; } }



    public BLLTssCMNResourcesDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TssCMNResourcesDetailSelectAll()
    {
        return objdal.TssCMNResourcesDetailSelectAll();
    }

    public int TssCMNResourcesDetailInsert(BLLTssCMNResourcesDetail objbll)
    {
        return objdal.TssCMNResourcesDetailInsert(objbll);
    }

    public int TssCMNResourcesDetailUpdate(BLLTssCMNResourcesDetail objbll)
    {
        return objdal.TssCMNResourcesDetailUpdate(objbll);
    }

    public DataTable TssCMNResourcesDetailSelectById(BLLTssCMNResourcesDetail objbll)
    {
        return objdal.TssCMNResourcesDetailSelectById(objbll);
    }

    public int TssCMNResourcesDetailDelete(BLLTssCMNResourcesDetail objbll)
    {
        return objdal.TssCMNResourcesDetailDelete(objbll);
    }

    public DataTable TssCMNResourcesDetailSelectByGResourceId(BLLTssCMNResourcesDetail objbll)
    {
        return objdal.TssCMNResourcesDetailSelectByGResourceId(objbll);
    }

    public int TssCMNResourcesDetailUpdateAccess(BLLTssCMNResourcesDetail objbll)
    {
        return objdal.TssCMNResourcesDetailUpdateAccess(objbll);
    }

    public DataTable TssCMNResourcesDetailSelectByCenterIDAndPath(BLLTssCMNResourcesDetail objbll)
    {
        return objdal.TssCMNResourcesDetailSelectByCenterIDAndPath(objbll);
    }

   


}
