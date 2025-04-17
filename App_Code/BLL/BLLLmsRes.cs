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
/// Summary description for BLLLmsRes
/// </summary>



public class BLLLmsRes
    {
    public BLLLmsRes()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsRes objdal = new DALLmsRes();



    #region 'Start Properties Declaration'

    public int Resource_ID { get; set; }
    public string ResourceTitle { get; set; }
    public int Section_Subject_Id { get; set; }
    public int WrkTool_ID { get; set; }
    public string FolderPath { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int LmsResAdd(BLLLmsRes _obj)
        {
        return objdal.LmsResAdd(_obj);
        }
    public int LmsResUpdate(BLLLmsRes _obj)
        {
        return objdal.LmsResUpdate(_obj);
        }
    public int LmsResDelete(BLLLmsRes _obj)
        {
        return objdal.LmsResDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsResFetch(BLLLmsRes _obj)
        {
        return objdal.LmsResSelect(_obj);
        }

    public DataTable LmsResFetchByStatusID(BLLLmsRes _obj)
    {
        return objdal.LmsResSelectByStatusID(_obj);
    }



    public DataTable LmsResFetch(int _id)
      {
        return objdal.LmsResSelect(_id);
      }



    public DataTable LmsResSelectAllBySectionSubjectIdWrkToolId(BLLLmsRes _obj)
    {
        return objdal.LmsResSelectAllBySectionSubjectIdWrkToolId(_obj);
    }


    #endregion

    }
