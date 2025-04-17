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
/// Summary description for BLLTssGResources
/// </summary>
public class BLLTssGResources
{
    _DALTssGResources objdal = new _DALTssGResources();

    private int gResource_ID;
    private int gResourceCat_ID;
    private string resourceTitle;
    private int main_Organisation_ID;
    private int session_ID;
    private int class_ID;
    private int subject_ID;
    private string folderPath;
    private int status_ID;
    private DateTime createdOn;
    private int createdBy;
    private DateTime modifiedOn;
    private int modifiedBy;
    private int main_Organisation_Country_ID;
    private int region_ID;
    private int center_ID;


    public int GResource_ID { get { return gResource_ID; } set { gResource_ID = value; } }
    public int GResourceCat_ID { get { return gResourceCat_ID; } set { gResourceCat_ID = value; } }
    public string ResourceTitle { get { return resourceTitle; } set { resourceTitle = value; } }
    public int Main_Organisation_ID { get { return main_Organisation_ID; } set { main_Organisation_ID = value; } }
    public int Session_ID { get { return session_ID; } set { session_ID = value; } }
    public int Class_ID { get { return class_ID; } set { class_ID = value; } }
    public int Subject_ID { get { return subject_ID; } set { subject_ID = value; } }
    public string FolderPath { get { return folderPath; } set { folderPath = value; } }
    public int Status_ID { get { return status_ID; } set { status_ID = value; } }
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }
    public int Main_Organisation_Country_ID { get { return main_Organisation_Country_ID; } set { main_Organisation_Country_ID = value; } }
    public int Region_ID { get { return region_ID; } set { region_ID = value; } }
    public int Center_ID { get { return center_ID; } set { center_ID = value; } }


    public BLLTssGResources()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TssGResourcesSelectAll()
    {
        return objdal.TssGResourcesSelectAll();
    }

    public int TssGResourcesInsert(BLLTssGResources objbll)
    {
        return objdal.TssGResourcesInsert(objbll);
    }

    public int TssGResourcesUpdate(BLLTssGResources objbll)
    {
        return objdal.TssGResourcesUpdate(objbll);
    }

    public DataTable TssGResourcesSelectById(BLLTssGResources objbll)
    {
        return objdal.TssGResourcesSelectById(objbll);
    }

    public int TssGResourcesDelete(BLLTssGResources objbll)
    {
        return objdal.TssGResourcesDelete(objbll);
    }

    public DataTable TssGResourcesSelectByRegionAndCat(BLLTssGResources objbll)
    {
        return objdal.TssGResourcesSelectByRegionAndCat(objbll);
    }
    public DataTable TssGResourcesDetailSelectByCatagory(BLLTssGResources objbll)
    {
        return objdal.TssGResourcesDetailSelectByCatagory(objbll);
    }

    public DataTable TssGResourceDCTCatagSelectByParam(BLLTssGResources objbll)
    {
        return objdal.TssGResourceDCTCatagSelectByParam(objbll);
    }

    public DataTable TssGResourceDCTCatagSelectBySubject(BLLTssGResources objbll)
        {
        return objdal.TssGResourceDCTCatagSelectBySubject(objbll);
        }

    public DataTable TssGResourceDCTCatagSelectBySubjectWOSession(BLLTssGResources objbll)
        {
        return objdal.TssGResourceDCTCatagSelectBySubjectWOSession(objbll);
        }


}
