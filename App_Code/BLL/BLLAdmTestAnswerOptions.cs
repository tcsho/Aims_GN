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
/// Summary description for BLLAdmTestAnswerOptions
/// </summary>



public class BLLAdmTestAnswerOptions
    {
    public BLLAdmTestAnswerOptions()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALAdmTestAnswerOptions objdal = new DALAdmTestAnswerOptions();



    #region 'Start Properties Declaration'

    public int AnswerOption_ID { get; set; }
    public string AnswerOptionDesc { get; set; }
    public int Status_ID { get; set; }
    public int CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int AdmTestAnswerOptionsAdd(BLLAdmTestAnswerOptions _obj)
        {
        return objdal.AdmTestAnswerOptionsAdd(_obj);
        }
    public int AdmTestAnswerOptionsUpdate(BLLAdmTestAnswerOptions _obj)
        {
        return objdal.AdmTestAnswerOptionsUpdate(_obj);
        }
    public int AdmTestAnswerOptionsDelete(BLLAdmTestAnswerOptions _obj)
        {
        return objdal.AdmTestAnswerOptionsDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable AdmTestAnswerOptionsFetch(BLLAdmTestAnswerOptions _obj)
        {
        return objdal.AdmTestAnswerOptionsSelect(_obj);
        }

    public DataTable AdmTestAnswerOptionsFetchByStatusID(BLLAdmTestAnswerOptions _obj)
    {
        return objdal.AdmTestAnswerOptionsSelectByStatusID(_obj);
    }



    public DataTable AdmTestAnswerOptionsFetch(int _id)
      {
        return objdal.AdmTestAnswerOptionsSelect(_id);
      }


    #endregion

    }
