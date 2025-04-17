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
public class BLLTssGResourcesDetail
{
    _DALTssGResourcesDetail objdal = new _DALTssGResourcesDetail();

    private int gResDetail_ID;
    private int gResource_ID;
    private int region_ID;
    private int center_ID;
    private int class_ID;
    private int subject_ID;
    private string folderName;
    private string gResourcePath;
    private bool isAllow;
    private int status_ID;
    private int program_ID;


    public int GResDetail_ID { get { return gResDetail_ID; } set { gResDetail_ID = value; } }
    public int GResource_ID { get { return gResource_ID; } set { gResource_ID = value; } }
    public int Region_ID { get { return region_ID; } set { region_ID = value; } }
    public int Center_ID { get { return center_ID; } set { center_ID = value; } }
    public int Class_ID { get { return class_ID; } set { class_ID = value; } }
    public int Subject_ID { get { return subject_ID; } set { subject_ID = value; } }
    public string FolderName { get { return folderName; } set { folderName = value; } }
    public string GResourcePath { get { return gResourcePath; } set { gResourcePath = value; } }
    public bool IsAllow { get { return isAllow; } set { isAllow = value; } }
    public int Status_ID { get { return status_ID; } set { status_ID = value; } }
    public int Program_ID { get { return program_ID; } set { program_ID = value; } }



    public BLLTssGResourcesDetail()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public DataTable TssGResourcesDetailSelectAll()
    {
        return objdal.TssGResourcesDetailSelectAll();
    }

    public int TssGResourcesDetailInsert(BLLTssGResourcesDetail objbll)
    {
        return objdal.TssGResourcesDetailInsert(objbll);
    }

    public int TssGResourcesDetailUpdate(BLLTssGResourcesDetail objbll)
    {
        return objdal.TssGResourcesDetailUpdate(objbll);
    }

    public DataTable TssGResourcesDetailSelectById(BLLTssGResourcesDetail objbll)
    {
        return objdal.TssGResourcesDetailSelectById(objbll);
    }

    public int TssGResourcesDetailDelete(BLLTssGResourcesDetail objbll)
    {
        return objdal.TssGResourcesDetailDelete(objbll);
    }

    public DataTable TssGResourcesDetailSelectByGResourceId(BLLTssGResourcesDetail objbll)
    {
        return objdal.TssGResourcesDetailSelectByGResourceId(objbll);
    }

    public DataTable TssGResourcesDetailSelectByGResourceIdCampusType(BLLTssGResourcesDetail objbll)
    {
    return objdal.TssGResourcesDetailSelectByGResourceIdCampusType(objbll);
    }

    public int TssGResourcesDetailUpdateAccess(BLLTssGResourcesDetail objbll)
    {
        return objdal.TssGResourcesDetailUpdateAccess(objbll);
    }

    public DataTable TssGResourcesDetailSelectByCenterIDAndPath(BLLTssGResourcesDetail objbll)
    {
        return objdal.TssGResourcesDetailSelectByCenterIDAndPath(objbll);
    }

   


}
