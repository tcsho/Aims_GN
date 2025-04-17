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
/// Summary description for BLLLmsSchEventFrequency
/// </summary>



public class BLLLmsSchEventFrequency
    {
    public BLLLmsSchEventFrequency()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsSchEventFrequency objdal = new DALLmsSchEventFrequency();



    #region 'Start Properties Declaration'

    public int EFrequency_ID { get; set; }
    public int Frequency_ID { get; set; }
    public int EFreqGap { get; set; }
    public int EndsAfter { get; set; }
    public DateTime EndDate { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }



    #endregion

    #region 'Start Executaion Methods'

    public int LmsSchEventFrequencyAdd(BLLLmsSchEventFrequency _obj)
        {
        return objdal.LmsSchEventFrequencyAdd(_obj);
        }
    public int LmsSchEventFrequencyUpdate(BLLLmsSchEventFrequency _obj)
        {
        return objdal.LmsSchEventFrequencyUpdate(_obj);
        }
    public int LmsSchEventFrequencyDelete(BLLLmsSchEventFrequency _obj)
        {
        return objdal.LmsSchEventFrequencyDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsSchEventFrequencyFetch(BLLLmsSchEventFrequency _obj)
        {
        return objdal.LmsSchEventFrequencySelect(_obj);
        }

    public DataTable LmsSchEventFrequencyFetchByStatusID(BLLLmsSchEventFrequency _obj)
    {
        return objdal.LmsSchEventFrequencySelectByStatusID(_obj);
    }



    public DataTable LmsSchEventFrequencyFetch(int _id)
      {
        return objdal.LmsSchEventFrequencySelect(_id);
      }


    #endregion

    }
