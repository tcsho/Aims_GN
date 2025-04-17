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
/// Summary description for BLLSection_Subject_Tool
/// </summary>



public class BLLSection_Subject_Tool
    {
    public BLLSection_Subject_Tool()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALSection_Subject_Tool objdal = new DALSection_Subject_Tool();



    #region 'Start Properties Declaration'
    public int WrkTool_ID { get; set; }
    public int Section_Subject_Id { get; set; }
    public int ProjectTool_ID { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int Section_Subject_ToolAdd(BLLSection_Subject_Tool _obj)
        {
        return objdal.Section_Subject_ToolAdd(_obj);
        }
    public int Section_Subject_ToolUpdate(BLLSection_Subject_Tool _obj)
        {
        return objdal.Section_Subject_ToolUpdate(_obj);
        }
    public int Section_Subject_ToolDelete(BLLSection_Subject_Tool _obj)
        {
        return objdal.Section_Subject_ToolDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable Section_Subject_ToolFetch(BLLSection_Subject_Tool _obj)
        {
        return objdal.Section_Subject_ToolSelect(_obj);
        }

    public DataTable Section_Subject_ToolFetchByStatusID(BLLSection_Subject_Tool _obj)
    {
        return objdal.Section_Subject_ToolSelectByStatusID(_obj);
    }



    public DataTable Section_Subject_ToolFetch(int _id)
      {
        return objdal.Section_Subject_ToolSelect(_id);
      }



    public DataTable Section_Subject_ToolSelectWorkSiteBySectionSubjectId(BLLSection_Subject_Tool _obj)
    {
        return objdal.Section_Subject_ToolSelectWorkSiteBySectionSubjectId(_obj);
    }

    public DataTable Section_Subject_ToolSelectWorkSiteBySectionSubjectIdForStudent(BLLSection_Subject_Tool _obj)
    {
        return objdal.Section_Subject_ToolSelectWorkSiteBySectionSubjectIdForStudent(_obj);
    }



    #endregion

    }
