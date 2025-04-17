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
/// Summary description for BLLAdmTestQuestionsType
/// </summary>



public class BLLAdmTestQuestionsType
    {
    public BLLAdmTestQuestionsType()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALAdmTestQuestionsType objdal = new DALAdmTestQuestionsType();



    #region 'Start Properties Declaration'
    public string QuestionTypeDesc { get; set; }
    public int Status_Id { get; set; }
    public int CraetedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public int ModifiedBy { get; set; }
    public DateTime ModifiedOn { get; set; }




    #endregion

    #region 'Start Executaion Methods'

    public int AdmTestQuestionsTypeAdd(BLLAdmTestQuestionsType _obj)
        {
        return objdal.AdmTestQuestionsTypeAdd(_obj);
        }
    public int AdmTestQuestionsTypeUpdate(BLLAdmTestQuestionsType _obj)
        {
        return objdal.AdmTestQuestionsTypeUpdate(_obj);
        }
    public int AdmTestQuestionsTypeDelete(BLLAdmTestQuestionsType _obj)
        {
        return objdal.AdmTestQuestionsTypeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable AdmTestQuestionsTypeFetch(BLLAdmTestQuestionsType _obj)
        {
        return objdal.AdmTestQuestionsTypeSelect(_obj);
        }

    public DataTable AdmTestQuestionsTypeFetchByStatusID(BLLAdmTestQuestionsType _obj)
    {
        return objdal.AdmTestQuestionsTypeSelectByStatusID(_obj);
    }



    public DataTable AdmTestQuestionsTypeFetch(int _id)
      {
        return objdal.AdmTestQuestionsTypeSelect(_id);
      }


    #endregion

    }
