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
/// Summary description for BLLLmsDpb
/// </summary>



public class BLLLmsDpb
    {
    public BLLLmsDpb()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsDpb objdal = new DALLmsDpb();



    #region 'Start Properties Declaration'

    public int DropBox_ID { get; set; }
    public string DropBoxTitle { get; set; }
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

    public int LmsDpbAdd(BLLLmsDpb _obj)
        {
        return objdal.LmsDpbAdd(_obj);
        }
    public int LmsDpbUpdate(BLLLmsDpb _obj)
        {
        return objdal.LmsDpbUpdate(_obj);
        }
    public int LmsDpbDelete(BLLLmsDpb _obj)
        {
        return objdal.LmsDpbDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsDpbFetch(BLLLmsDpb _obj)
        {
        return objdal.LmsDpbSelect(_obj);
        }

    public DataTable LmsDpbFetchByStatusID(BLLLmsDpb _obj)
    {
        return objdal.LmsDpbSelectByStatusID(_obj);
    }


    public DataTable LmsDpbSelectAllBySectionSubjectIdWrkToolId(BLLLmsDpb _obj)
    {
        return objdal.LmsDpbSelectAllBySectionSubjectIdWrkToolId(_obj);
    }






    public DataTable LmsDpbFetch(int _id)
      {
        return objdal.LmsDpbSelect(_id);
      }


    #endregion

    }
