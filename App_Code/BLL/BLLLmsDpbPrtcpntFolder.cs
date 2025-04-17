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
/// Summary description for BLLLmsDpbPrtcpntFolder
/// </summary>



public class BLLLmsDpbPrtcpntFolder
    {
    public BLLLmsDpbPrtcpntFolder()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsDpbPrtcpntFolder objdal = new DALLmsDpbPrtcpntFolder();



    #region 'Start Properties Declaration'

    public int PrtcpnttDpb_ID { get; set; }
    public int DropBox_ID { get; set; }
    public string FolderName { get; set; }
    public string FolderPath { get; set; }
    public int Participant_ID { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int LmsDpbPrtcpntFolderAdd(BLLLmsDpbPrtcpntFolder _obj)
        {
        return objdal.LmsDpbPrtcpntFolderAdd(_obj);
        }
    public int LmsDpbPrtcpntFolderUpdate(BLLLmsDpbPrtcpntFolder _obj)
        {
        return objdal.LmsDpbPrtcpntFolderUpdate(_obj);
        }
    public int LmsDpbPrtcpntFolderDelete(BLLLmsDpbPrtcpntFolder _obj)
        {
        return objdal.LmsDpbPrtcpntFolderDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsDpbPrtcpntFolderFetch(BLLLmsDpbPrtcpntFolder _obj)
        {
        return objdal.LmsDpbPrtcpntFolderSelect(_obj);
        }

    public DataTable LmsDpbPrtcpntFolderFetchByStatusID(BLLLmsDpbPrtcpntFolder _obj)
    {
        return objdal.LmsDpbPrtcpntFolderSelectByStatusID(_obj);
    }



    public DataTable LmsDpbPrtcpntFolderFetch(int _id)
      {
        return objdal.LmsDpbPrtcpntFolderSelect(_id);
      }


    #endregion

    }
