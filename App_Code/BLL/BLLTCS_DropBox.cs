using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;

/// <summary>
/// Summary description for BLLTCS_DropBox
/// </summary>



public class BLLTCS_DropBox
    {
    public BLLTCS_DropBox()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALTCS_DropBox objdal = new DALTCS_DropBox();



    #region 'Start Properties Declaration'

    public int TCS_DropBox_ID { get; set; }
    public int Main_Organisation_ID { get; set; }
    public int Region_ID { get; set; }
    public int Center_ID { get; set; }
    public string DropBoxResourcePath { get; set; }
    public int Status_ID { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int TCS_DropBoxAdd(BLLTCS_DropBox _obj)
        {
        return objdal.TCS_DropBoxAdd(_obj);
        }
    public int TCS_DropBoxUpdate(BLLTCS_DropBox _obj)
        {
        return objdal.TCS_DropBoxUpdate(_obj);
        }
    public int TCS_DropBoxDelete(BLLTCS_DropBox _obj)
        {
        return objdal.TCS_DropBoxDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable TCS_DropBoxFetch(BLLTCS_DropBox _obj)
        {
        return objdal.TCS_DropBoxSelect(_obj);
        }

    public DataTable TCS_DropBoxFetchByStatusID(BLLTCS_DropBox _obj)
    {
        return objdal.TCS_DropBoxSelectByStatusID(_obj);
    }



    public DataTable TCS_DropBoxFetch(int _id)
      {
        return objdal.TCS_DropBoxSelect(_id);
      }


    public DataTable TCS_DrobBoxSelectAllCenterByRegionId(BLLTCS_DropBox objbll)
    {
        return objdal.TCS_DrobBoxSelectAllCenterByRegionId(objbll);
    }

    public DataTable TCS_DrobBoxSelectCenterByCenterId(BLLTCS_DropBox objbll)
    {
        return objdal.TCS_DrobBoxSelectCenterByCenterId(objbll);
    }




    #endregion

    }
