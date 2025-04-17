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
/// Summary description for BLLSeatPlanBlock
/// </summary>



public class BLLSeatPlanBlock
    {
    public BLLSeatPlanBlock()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALSeatPlanBlock objdal = new _DALSeatPlanBlock();



    #region 'Start Properties Declaration'

    public int Block_Id { get; set; }
    public string BlockName { get; set; }
    public int Status_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int SeatPlanBlockAdd(BLLSeatPlanBlock _obj)
        {
        return objdal.SeatPlanBlockAdd(_obj);
        }
    public int SeatPlanBlockUpdate(BLLSeatPlanBlock _obj)
        {
        return objdal.SeatPlanBlockUpdate(_obj);
        }
    public int SeatPlanBlockDelete(BLLSeatPlanBlock _obj)
        {
        return objdal.SeatPlanBlockDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SeatPlanBlockFetchAll()
        {
        return objdal.SeatPlanBlockSelectAll();
        }

    public DataTable SeatPlanBlockFetch(int _id)
      {
        return objdal.SeatPlanBlockSelect(_id);
      }
    public int SeatPlanBlockFetchField(int _Id)
        {
        return objdal.SeatPlanBlockSelectField(_Id);
        }


    #endregion

    }
