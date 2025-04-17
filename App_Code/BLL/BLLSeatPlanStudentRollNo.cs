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
/// Summary description for BLLSeatPlanStudentRollNo
/// </summary>
public class BLLSeatPlanStudentRollNo
{

    _DALSeatPlanStudentRollNo ObjDal = new _DALSeatPlanStudentRollNo();
    public BLLSeatPlanStudentRollNo()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int Id { get; set; }
    public int Center_Id { get; set; }
    public int Class_Id { get; set; }
    public int SessionId { get; set; }
    public int TermId { get; set; }
    public int StudentERPNo { get; set; }
    public string StudentMaskNo { get; set; }
    public int Status { get; set; }
    public DateTime CreatedDate { get; set; }

    public int SeatPlanStudentRollNo_Insert(BLLSeatPlanStudentRollNo _Obj)
    {
        return ObjDal.SeatPlanStudentRollNo_Insert(_Obj);
    }

}