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
/// Summary description for BLLAdmTestSubmissions
/// </summary>



public class BLLAdmTestSubmissions
    {
    public BLLAdmTestSubmissions()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALAdmTestSubmissions objdal = new DALAdmTestSubmissions();



    #region 'Start Properties Declaration'

    public int AdmTestSubm_ID { get; set; }
    public int User_ID { get; set; }
    public DateTime SubmDateTime { get; set; }
    public string Comments { get; set; }
    public decimal TotalScores { get; set; }
    public int AdmTest_Id { get; set; }
    public Boolean? Group_Type{ get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int AdmTestSubmissionsAdd(BLLAdmTestSubmissions _obj)
        {
        return objdal.AdmTestSubmissionsAdd(_obj);
        }
    public int AdmTestSubmissionsUpdate(BLLAdmTestSubmissions _obj)
        {
        return objdal.AdmTestSubmissionsUpdate(_obj);
        }
    public int AdmTestSubmissionsDelete(BLLAdmTestSubmissions _obj)
        {
        return objdal.AdmTestSubmissionsDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable AdmTestSubmissionsFetch(BLLAdmTestSubmissions _obj)
        {
        return objdal.AdmTestSubmissionsSelect(_obj);
        }

    public DataTable AdmTestSubmissionsFetchByStatusID(BLLAdmTestSubmissions _obj)
    {
        return objdal.AdmTestSubmissionsSelectByStatusID(_obj);
    }



    public DataTable AdmTestSubmissionsFetch(int _id)
      {
        return objdal.AdmTestSubmissionsSelect(_id);
      }


    public int AdmTestSubmissionsSelectAdminTestByUserId(BLLAdmTestSubmissions _obj)
    {
        return objdal.AdmTestSubmissionsSelectAdminTestByUserId(_obj);
    }
    public DataTable AdmTestSubmissionsSelectInfromationByUserId(BLLAdmTestSubmissions _obj)
    {
        return objdal.AdmTestSubmissionsSelectInfromationByUserId(_obj);
    }
    public DataTable AdmTestSubmissionsSelectResultByUserId(BLLAdmTestSubmissions _obj)
    {
        return objdal.AdmTestSubmissionsSelectResultByUserId(_obj);
    }


    #endregion

    }
