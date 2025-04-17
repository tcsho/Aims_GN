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
/// Summary description for BLLLmsAncmtAttachments
/// </summary>



public class BLLLmsAncmtAttachments
    {
    public BLLLmsAncmtAttachments()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsAncmtAttachments objdal = new DALLmsAncmtAttachments();



    #region 'Start Properties Declaration'

    public int AncmtAttach_ID { get; set; }
    public int Announcement_ID { get; set; }
    public string AncmtPath { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public string WebURL { get; set; }
    public int AttachType_ID { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int LmsAncmtAttachmentsAdd(BLLLmsAncmtAttachments _obj)
        {
        return objdal.LmsAncmtAttachmentsAdd(_obj);
        }
    public int LmsAncmtAttachmentsUpdate(BLLLmsAncmtAttachments _obj)
        {
        return objdal.LmsAncmtAttachmentsUpdate(_obj);
        }
    public int LmsAncmtAttachmentsDelete(BLLLmsAncmtAttachments _obj)
        {
        return objdal.LmsAncmtAttachmentsDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsAncmtAttachmentsFetch(BLLLmsAncmtAttachments _obj)
        {
        return objdal.LmsAncmtAttachmentsSelect(_obj);
        }

    public DataTable LmsAncmtAttachmentsFetchByStatusID(BLLLmsAncmtAttachments _obj)
    {
        return objdal.LmsAncmtAttachmentsSelectByStatusID(_obj);
    }



    public DataTable LmsAncmtAttachmentsFetch(int _id)
      {
        return objdal.LmsAncmtAttachmentsSelect(_id);
      }


    #endregion

    }
