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
/// Summary description for BLLLmsSchEvent
/// </summary>



public class BLLLmsSchEvent
    {
    public BLLLmsSchEvent()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSchEvent objdal = new DALLmsSchEvent();



    #region 'Start Properties Declaration'

    public int Event_ID { get; set; }
    public int Schedule_ID { get; set; }
    public int Section_Subject_Id { get; set; }
    public int WrkTool_ID { get; set; }
    public int EventType_ID { get; set; }
    public int EFrequency_ID { get; set; }
    public string EventTitle { get; set; }
    public DateTime EventDate { get; set; }
    public DateTime StartTime { get; set; }
    public string Duration { get; set; }
    public DateTime EndTime { get; set; }
    public string Message { get; set; }
    public int EGroup_ID { get; set; }
    public string EventLocation { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public int Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsSchEventAdd(BLLLmsSchEvent _obj)
        {
        return objdal.LmsSchEventAdd(_obj);
        }
    public int LmsSchEventUpdate(BLLLmsSchEvent _obj)
        {
        return objdal.LmsSchEventUpdate(_obj);
        }
    public int LmsSchEventDelete(BLLLmsSchEvent _obj)
        {
        return objdal.LmsSchEventDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSchEventFetch(BLLLmsSchEvent _obj)
        {
        return objdal.LmsSchEventSelect(_obj);
        }

    public DataTable LmsSchEventFetchByStatusID(BLLLmsSchEvent _obj)
    {
        return objdal.LmsSchEventSelectByStatusID(_obj);
    }



    public DataTable LmsSchEventFetch(int _id)
      {
        return objdal.LmsSchEventSelect(_id);
      }


    public DataTable LmsSchEventSelectAllBySectionSubjectIdWrkToolId(BLLLmsSchEvent _obj)
    {
        return objdal.LmsSchEventSelectAllBySectionSubjectIdWrkToolId(_obj);
    }


    public DataTable LmsSchEventSelectAllByEventID(BLLLmsSchEvent _obj)
    {
        return objdal.LmsSchEventSelectAllByEventID(_obj);
    }





    #endregion

    }
