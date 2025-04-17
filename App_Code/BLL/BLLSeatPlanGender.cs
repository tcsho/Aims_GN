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
/// Summary description for BLLSeatPlanGender
/// </summary>



public class BLLSeatPlanGender
    {
    public BLLSeatPlanGender()
        {
        //
        // TODO: Add constructor logic here
        //
        }

    _DALSeatPlanGender objdal = new _DALSeatPlanGender();



    #region 'Start Properties Declaration'

    public int Gender_Id { get; set; }
    public string GenderName { get; set; }
    public int Status_Id { get; set; }


    #endregion

    #region 'Start Executaion Methods'

    public int SeatPlanGenderAdd(BLLSeatPlanGender _obj)
        {
        return objdal.SeatPlanGenderAdd(_obj);
        }
    public int SeatPlanGenderUpdate(BLLSeatPlanGender _obj)
        {
        return objdal.SeatPlanGenderUpdate(_obj);
        }
    public int SeatPlanGenderDelete(BLLSeatPlanGender _obj)
        {
        return objdal.SeatPlanGenderDelete(_obj);

        }

    #endregion
    #region 'Start Fetch Methods'


    public DataTable SeatPlanGenderFetchAll()
        {
        return objdal.SeatPlanGenderSelectAll();
        }

    public DataTable SeatPlanGenderFetch(int _id)
      {
        return objdal.SeatPlanGenderSelect(_id);
      }
    public int SeatPlanGenderFetchField(int _Id)
        {
        return objdal.SeatPlanGenderSelectField(_Id);
        }


    #endregion

    }
