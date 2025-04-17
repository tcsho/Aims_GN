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
/// Summary description for BLLTssCMNResource
/// </summary>
public class BLLTssCMNResources
{
    _DALTssCMNResources objdal = new _DALTssCMNResources();
    

    private int cmnResource_ID;
    private int cmnResourceCat_ID;
    private string resourceTitle;
    private int main_Organisation_ID;
   
    private string folderPath;
    private int status_ID;
    private DateTime createdOn;
    private int createdBy;
    private DateTime modifiedOn;
    private int modifiedBy;
    private int main_Organisation_Country_ID;
    private int region_ID;
    private int center_ID;


    public int CMNResource_ID { get { return cmnResource_ID; } set { cmnResource_ID = value; } }
    public int CMNResourceCat_ID { get { return cmnResourceCat_ID; } set { cmnResourceCat_ID = value; } }
    public string ResourceTitle { get { return resourceTitle; } set { resourceTitle = value; } }
    public int Main_Organisation_ID { get { return main_Organisation_ID; } set { main_Organisation_ID = value; } }
    public string FolderPath { get { return folderPath; } set { folderPath = value; } }
    public int Status_ID { get { return status_ID; } set { status_ID = value; } }
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }
    public int Main_Organisation_Country_ID { get { return main_Organisation_Country_ID; } set { main_Organisation_Country_ID = value; } }
    public int Region_ID { get { return region_ID; } set { region_ID = value; } }
    public int Center_ID { get { return center_ID; } set { center_ID = value; } }


    public BLLTssCMNResources()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TssCMNResourcesSelectAll()
    {
        return objdal.TssCMNResourcesSelectAll();
    }

    public int TssCMNResourcesInsert(BLLTssCMNResources objbll)
    {
        return objdal.TssCMNResourcesInsert(objbll);
    }

    public int TssCMNResourcesUpdate(BLLTssCMNResources objbll)
    {
        return objdal.TssCMNResourcesUpdate(objbll);
    }

    public DataTable TssCMNResourcesSelectById(BLLTssCMNResources objbll)
    {
        return objdal.TssCMNResourcesSelectById(objbll);
    }

    public int TssCMNResourcesDelete(BLLTssCMNResources objbll)
    {
        return objdal.TssCMNResourcesDelete(objbll);
    }

    public DataTable TssCMNResourcesSelectByMoId(BLLTssCMNResources objbll)
    {
    return objdal.TssCMNResourcesSelectByMoId(objbll);
    }

    public DataTable TssCMNResourcesSelectByMoIdCId(BLLTssCMNResources objbll)
    {
    return objdal.TssCMNResourcesSelectByMoIdCId(objbll);
    }

    



    public DataTable TssCMNResourcesDetailSelectByCatagory(BLLTssCMNResources objbll)
    {
        return objdal.TssCMNResourcesDetailSelectByCatagory(objbll);
    }

    public DataTable TssGResourcesDCTCatagSelectByParam(BLLTssCMNResources objbll)
    {
        return objdal.TssGResourcesDCTCatagSelectByParam(objbll);
    }

    public DataTable TssGResourcesDCTCatagSelectBySubject(BLLTssCMNResources objbll)
        {
        return objdal.TssGResourcesDCTCatagSelectBySubject(objbll);
        }

}
