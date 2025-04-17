using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Collections.Generic;

/// <summary>
/// Summary description for _DALSeatPlanRoomAllocateToStudent
/// </summary>
public class _DALSeatPlanRoomAllocateToStudent
{
    DALBase dalobj = new DALBase();
    public _DALSeatPlanRoomAllocateToStudent()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public int SeatPlanAssignRoomsToStudents(BLLSeatPlanRoomAllocateToStudent objbll)
    {
        SqlParameter[] param = new SqlParameter[9];

        param[0] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[0].Value = objbll.Center_Id;

        param[1] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[1].Value = objbll.Session_Id;

        param[2] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[2].Value = objbll.TermGroup_Id;

        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;

        param[4] = new SqlParameter("@Room_Id", SqlDbType.Int);
        param[4].Value = objbll.Room_Id;

        param[5] = new SqlParameter("@Students", SqlDbType.Int);
        param[5].Value = objbll.Students;

        param[6] = new SqlParameter("@Gender_Id", SqlDbType.Int);
        param[6].Value = objbll.Gender_Id;

        param[7] = new SqlParameter("@Block_Id", SqlDbType.Int);
        param[7].Value = objbll.Block_Id;

        param[8] = new SqlParameter("@Result", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("SeatPlanAssignRoomsToStudents", param);
        int k = (int)param[7].Value;
        return k;

    }
}