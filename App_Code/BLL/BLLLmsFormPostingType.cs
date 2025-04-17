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
/// Summary description for BLLLmsFormPostingType
/// </summary>



public class BLLLmsFormPostingType
    {
    public BLLLmsFormPostingType()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsFormPostingType objdal = new DALLmsFormPostingType();



    #region 'Start Properties Declaration'

    public int PostingType_ID { get; set; }
    public string PostType { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public string Description { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsFormPostingTypeAdd(BLLLmsFormPostingType _obj)
        {
        return objdal.LmsFormPostingTypeAdd(_obj);
        }
    public int LmsFormPostingTypeUpdate(BLLLmsFormPostingType _obj)
        {
        return objdal.LmsFormPostingTypeUpdate(_obj);
        }
    public int LmsFormPostingTypeDelete(BLLLmsFormPostingType _obj)
        {
        return objdal.LmsFormPostingTypeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsFormPostingTypeFetch(BLLLmsFormPostingType _obj)
        {
        return objdal.LmsFormPostingTypeSelect(_obj);
        }

    public DataTable LmsFormPostingTypeFetchByStatusID(BLLLmsFormPostingType _obj)
    {
        return objdal.LmsFormPostingTypeSelectByStatusID(_obj);
    }



    public DataTable LmsFormPostingTypeFetch(int _id)
      {
        return objdal.LmsFormPostingTypeSelect(_id);
      }


    #endregion

    }
