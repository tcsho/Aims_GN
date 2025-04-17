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
/// Summary description for BLLLmsSch
/// </summary>



public class BLLLmsSch
    {
    public BLLLmsSch()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSch objdal = new DALLmsSch();



    #region 'Start Properties Declaration'

    public int Schedule_ID { get; set; }
    public int Section_Subject_Id { get; set; }
    public int WrkTool_ID { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int LmsSchAdd(BLLLmsSch _obj)
        {
        return objdal.LmsSchAdd(_obj);
        }
    public int LmsSchUpdate(BLLLmsSch _obj)
        {
        return objdal.LmsSchUpdate(_obj);
        }
    public int LmsSchDelete(BLLLmsSch _obj)
        {
        return objdal.LmsSchDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSchFetch(BLLLmsSch _obj)
        {
        return objdal.LmsSchSelect(_obj);
        }

    public DataTable LmsSchFetchByStatusID(BLLLmsSch _obj)
    {
        return objdal.LmsSchSelectByStatusID(_obj);
    }



    public DataTable LmsSchFetch(int _id)
      {
        return objdal.LmsSchSelect(_id);
      }


    public DataTable LmsSchSelectAllBySectionSubjectIdWrkToolId(BLLLmsSch _obj)
    {
        return objdal.LmsSchSelectAllBySectionSubjectIdWrkToolId(_obj);
    }



    #endregion

    }
