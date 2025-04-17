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
/// Summary description for BLLLmsFormThreadType
/// </summary>



public class BLLLmsFormThreadType
    {
    public BLLLmsFormThreadType()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    DALLmsFormThreadType objdal = new DALLmsFormThreadType();



    #region 'Start Properties Declaration'

    public int ThreadType_ID { get; set; }
    public string ThreadType { get; set; }
    public int Status_Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public int CreatedBy { get; set; }
    public DateTime ModifiedOn { get; set; }
    public int ModifiedBy { get; set; }
    public string Description { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int LmsFormThreadTypeAdd(BLLLmsFormThreadType _obj)
        {
        return objdal.LmsFormThreadTypeAdd(_obj);
        }
    public int LmsFormThreadTypeUpdate(BLLLmsFormThreadType _obj)
        {
        return objdal.LmsFormThreadTypeUpdate(_obj);
        }
    public int LmsFormThreadTypeDelete(BLLLmsFormThreadType _obj)
        {
        return objdal.LmsFormThreadTypeDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable LmsFormThreadTypeFetch(BLLLmsFormThreadType _obj)
        {
        return objdal.LmsFormThreadTypeSelect(_obj);
        }

    public DataTable LmsFormThreadTypeFetchByStatusID(BLLLmsFormThreadType _obj)
    {
        return objdal.LmsFormThreadTypeSelectByStatusID(_obj);
    }



    public DataTable LmsFormThreadTypeFetch(int _id)
      {
        return objdal.LmsFormThreadTypeSelect(_id);
      }


    #endregion

    }
