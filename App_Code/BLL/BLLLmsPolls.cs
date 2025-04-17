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
/// Summary description for BLLLmsPolls
/// </summary>



public class BLLLmsPolls
    {
    public BLLLmsPolls()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsPolls objdal = new DALLmsPolls();



    #region 'Start Properties Declaration'

    public int Poll_ID { get; set; }
    public string QstText { get; set; }
    public string AddInstructions { get; set; }
    public DateTime OpningDate { get; set; }
    public DateTime ClosingDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public int WrkTool_ID { get; set; }
    public bool PublishStatus_ID { get; set; }
    public bool GblAccessType_ID { get; set; }
    public int Participant_ID { get; set; }
    public int Section_Subject_Id { get; set; }
    public int Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsPollsAdd(BLLLmsPolls _obj)
        {
        return objdal.LmsPollsAdd(_obj);
        }
    public int LmsPollsUpdate(BLLLmsPolls _obj)
        {
        return objdal.LmsPollsUpdate(_obj);
        }
    public int LmsPollsDelete(BLLLmsPolls _obj)
        {
        return objdal.LmsPollsDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsPollsFetch(BLLLmsPolls _obj)
        {
        return objdal.LmsPollsSelect(_obj);
        }

    public DataTable LmsPollsFetchByStatusID(BLLLmsPolls _obj)
    {
        return objdal.LmsPollsSelectByStatusID(_obj);
    }

    public DataTable LmsPollsSelectAllByPollId(BLLLmsPolls _obj)
    {
        return objdal.LmsPollsSelectAllByPollId(_obj);
    }




    public DataTable LmsPollsSelectAllBySectionSubjectIdWrkToolId(BLLLmsPolls _obj)
    {
        return objdal.LmsPollsSelectAllBySectionSubjectIdWrkToolId(_obj);
    }


    public DataTable LmsPollsSelectAllForSubmission(BLLLmsPolls _obj)
    {
        return objdal.LmsPollsSelectAllForSubmission(_obj);
    }


    public DataTable LmsPollsFetch(int _id)
      {
        return objdal.LmsPollsSelect(_id);
      }


    #endregion

    }
