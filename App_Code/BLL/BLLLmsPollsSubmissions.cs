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
/// Summary description for BLLLmsPollsSubmissions
/// </summary>



public class BLLLmsPollsSubmissions
    {
    public BLLLmsPollsSubmissions()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsPollsSubmissions objdal = new DALLmsPollsSubmissions();



    #region 'Start Properties Declaration'
    public int PollSubmission_ID { get; set; }
    public int Poll_ID { get; set; }
    public int PollDetail_ID { get; set; }
    public int Participant_ID { get; set; }
    public int QuestionDetailOption_Id { get; set; }
    public string QuestionDetailOption { get; set; }
    public int LmsPollsSubmissionsUser_ID { get; set; }
    public int User_Id { get; set; }





    #endregion

    #region 'Start Executaion Methods'

    public int LmsPollsSubmissionsAdd(BLLLmsPollsSubmissions _obj)
        {
        return objdal.LmsPollsSubmissionsAdd(_obj);
        }
    public int LmsPollsSubmissionsUpdate(BLLLmsPollsSubmissions _obj)
        {
        return objdal.LmsPollsSubmissionsUpdate(_obj);
        }
    public int LmsPollsSubmissionsDelete(BLLLmsPollsSubmissions _obj)
        {
        return objdal.LmsPollsSubmissionsDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsPollsSubmissionsFetch(BLLLmsPollsSubmissions _obj)
        {
        return objdal.LmsPollsSubmissionsSelect(_obj);
        }

    public DataTable LmsPollsSubmissionsFetchByStatusID(BLLLmsPollsSubmissions _obj)
    {
        return objdal.LmsPollsSubmissionsSelectByStatusID(_obj);
    }



    public DataTable LmsPollsSubmissionsFetch(int _id)
      {
        return objdal.LmsPollsSubmissionsSelect(_id);
      }


    public DataTable LmsPollsSubmissionSelectAllbyPollId(BLLLmsPollsSubmissions _obj)
    {
        return objdal.LmsPollsSubmissionSelectAllbyPollId(_obj);
    }



    #endregion

    }
