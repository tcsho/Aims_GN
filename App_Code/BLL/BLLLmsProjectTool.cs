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
/// Summary description for BLLLmsProjectTool
/// </summary>



public class BLLLmsProjectTool
    {
    public BLLLmsProjectTool()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsProjectTool objdal = new DALLmsProjectTool();



    #region 'Start Properties Declaration'
    public int ProjectTool_ID { get; set; }
    public string ProjectTool { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public string PagePath { get; set; }
    public string ToolImage { get; set; }
    public bool isDefault { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsProjectToolAdd(BLLLmsProjectTool _obj)
        {
        return objdal.LmsProjectToolAdd(_obj);
        }
    public int LmsProjectToolUpdate(BLLLmsProjectTool _obj)
        {
        return objdal.LmsProjectToolUpdate(_obj);
        }
    public int LmsProjectToolDelete(BLLLmsProjectTool _obj)
        {
        return objdal.LmsProjectToolDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsProjectToolFetch(BLLLmsProjectTool _obj)
        {
        return objdal.LmsProjectToolSelect(_obj);
        }

    public DataTable LmsProjectToolFetchByStatusID(BLLLmsProjectTool _obj)
    {
        return objdal.LmsProjectToolSelectByStatusID(_obj);
    }



    public DataTable LmsProjectToolFetch(int _id)
      {
        return objdal.LmsProjectToolSelect(_id);
      }


    #endregion

    }
