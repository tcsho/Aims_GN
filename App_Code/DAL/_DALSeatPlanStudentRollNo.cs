using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;

/// <summary>
/// Summary description for SeatPlanStudentRollNo
/// </summary>
public class _DALSeatPlanStudentRollNo
{
    DALBase dalobj = new DALBase();

    public _DALSeatPlanStudentRollNo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int SeatPlanStudentRollNo_Insert(BLLSeatPlanStudentRollNo objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int); param[0].Value = objbll.Center_Id;
        param[1] = new SqlParameter("@Class_Id", SqlDbType.Int); param[1].Value = objbll.Class_Id;
        param[2] = new SqlParameter("@SessionId", SqlDbType.Int); param[2].Value = objbll.SessionId;
        param[3] = new SqlParameter("@TermId", SqlDbType.Int); param[3].Value = objbll.TermId;
        param[4] = new SqlParameter("@StudentERPNo", SqlDbType.Int); param[4].Value = objbll.StudentERPNo;
        param[5] = new SqlParameter("@StudentMaskNo", SqlDbType.VarChar); param[5].Value = objbll.StudentMaskNo;

        param[6] = new SqlParameter("@Result", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SeatPlanStudentRollNo_Insert", param);
        int k = (int)param[6].Value;
        return k;

    }

}