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
/// Summary description for BLLLmsSchFrequencyType
/// </summary>



public class BLLLmsSchFrequencyType
    {
    public BLLLmsSchFrequencyType()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSchFrequencyType objdal = new DALLmsSchFrequencyType();



    #region 'Start Properties Declaration'
    public int Frequency_ID { get; set; }
    public string FrequencyType { get; set; }
    public int CreatedOn { get; set; }
    public string CreatedBy { get; set; }
    public int ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public string Status_Id { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsSchFrequencyTypeAdd(BLLLmsSchFrequencyType _obj)
        {
        return objdal.LmsSchFrequencyTypeAdd(_obj);
        }
    public int LmsSchFrequencyTypeUpdate(BLLLmsSchFrequencyType _obj)
        {
        return objdal.LmsSchFrequencyTypeUpdate(_obj);
        }
    public int LmsSchFrequencyTypeDelete(BLLLmsSchFrequencyType _obj)
        {
        return objdal.LmsSchFrequencyTypeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSchFrequencyTypeFetch(BLLLmsSchFrequencyType _obj)
        {
        return objdal.LmsSchFrequencyTypeSelect(_obj);
        }

    public DataTable LmsSchFrequencyTypeFetchByStatusID(BLLLmsSchFrequencyType _obj)
    {
        return objdal.LmsSchFrequencyTypeSelectByStatusID(_obj);
    }



    public DataTable LmsSchFrequencyTypeFetch(int _id)
      {
        return objdal.LmsSchFrequencyTypeSelect(_id);
      }


    #endregion

    }
