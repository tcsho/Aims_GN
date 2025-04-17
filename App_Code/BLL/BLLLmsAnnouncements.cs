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
/// Summary description for BLLLmsAnnouncements
/// </summary>



public class BLLLmsAnnouncements
    {
    public BLLLmsAnnouncements()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsAnnouncements objdal = new DALLmsAnnouncements();



    #region 'Start Properties Declaration'
    public int Announcement_ID { get; set; }
    public int Section_Subject_Id { get; set; }
    public int WrkTool_ID { get; set; }
    public string AncmtTitle { get; set; }
    public string AncmtBody { get; set; }
    public bool IsPublished { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime PublishStartDate { get; set; }
    public DateTime PublishEndDate { get; set; }




    #endregion

    #region 'Start Executaion Methods'

    public int LmsAnnouncementsAdd(BLLLmsAnnouncements _obj)
        {
        return objdal.LmsAnnouncementsAdd(_obj);
        }
    public int LmsAnnouncementsUpdate(BLLLmsAnnouncements _obj)
        {
        return objdal.LmsAnnouncementsUpdate(_obj);
        }
    public int LmsAnnouncementsDelete(BLLLmsAnnouncements _obj)
        {
        return objdal.LmsAnnouncementsDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsAnnouncementsFetch(BLLLmsAnnouncements _obj)
        {
        return objdal.LmsAnnouncementsSelect(_obj);
        }

    public DataTable LmsAnnouncementsFetchByStatusID(BLLLmsAnnouncements _obj)
    {
        return objdal.LmsAnnouncementsSelectByStatusID(_obj);
    }



    public DataTable LmsAnnouncementSelectAllBySectionSubjectIdWrkToolId(BLLLmsAnnouncements _obj)
    {
        return objdal.LmsAnnouncementSelectAllBySectionSubjectIdWrkToolId(_obj);
    }



    public DataTable LmsAnnouncementSelectAllByAnnouncementId(BLLLmsAnnouncements _obj)
    {
        return objdal.LmsAnnouncementSelectAllByAnnouncementId(_obj);
    }




    public DataTable LmsAnnouncementsFetch(int _id)
      {
        return objdal.LmsAnnouncementsSelect(_id);
      }


    #endregion

    }
