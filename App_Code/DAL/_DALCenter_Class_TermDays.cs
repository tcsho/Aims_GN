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
/// Summary description for _DALCenter_Class_TermDays
/// </summary>
public class DALCenter_Class_TermDays
{
    DALBase dalobj = new DALBase();


    public DALCenter_Class_TermDays()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int Center_Class_TermDaysAdd(BLLCenter_Class_TermDays objbll)
    {
        SqlParameter[] param = new SqlParameter[7];

        ////////////////param[0] = new SqlParameter("@CenterClassTermDayId", SqlDbType.Int);
        ////////////////param[0].Value = objbll.CenterClassTermDayId;
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;
        param[4] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[4].Value = objbll.Evaluation_Criteria_Type_Id;
        param[5] = new SqlParameter("@TotalTermDays", SqlDbType.Int);
        param[5].Value = objbll.TotalTermDays;
        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;
        dalobj.sqlcmdExecute("Center_Class_TermDaysInsert", param);
        int k = (int)param[6].Value;
        return k;

    }

    // update center terms days by Muhammad Ali

    public int Center_TermDaysAdd(BLLCenter_Class_TermDays objbll)
    {
        var param = new SqlParameter[5];
        param[0] = new SqlParameter("@Region_Id", SqlDbType.Int) {Value = objbll.Region_Id};
        param[1] = new SqlParameter("@Center_Id", SqlDbType.Int) {Value = objbll.Center_Id};
        param[2] = new SqlParameter("@FirstTermDays", SqlDbType.Int) {Value = objbll.FirstTermDays};
        param[3] = new SqlParameter("@SecondTermDays", SqlDbType.Int) {Value = objbll.SecondTermDays};
        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int) {Direction = ParameterDirection.Output};
        dalobj.sqlcmdExecute("Center_TermDaysInsert", param);
        var k = (int)param[4].Value;
        return k;
    }

    internal int UpdateRegionTermDays(BLLCenter_Class_TermDays objBll)
    {
        var param = new SqlParameter[4];
        param[0] = new SqlParameter("@RegionId", SqlDbType.Int) { Value = objBll.Region_Id };
        param[1] = new SqlParameter("@FirstTermDays", SqlDbType.Int) { Value = objBll.FirstTermDays };
        param[2] = new SqlParameter("@SecondTermDays", SqlDbType.Int) { Value = objBll.SecondTermDays };
        param[3] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("UpdateRegionTermDays", param);
        var k = (int)param[3].Value;
        return k;
    }

    internal int RegionTermDaysCopyToCenter(BLLCenter_Class_TermDays objBll)
    {
        var param = new SqlParameter[3];
        param[0] = new SqlParameter("@RegionId", SqlDbType.Int) { Value = objBll.Region_Id };
        param[1] = new SqlParameter("@FirstTermDays", SqlDbType.Int) { Value = objBll.FirstTermDays };       
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("CopyRegionFirstTermDaysToCenter", param);
        var k = (int)param[2].Value;
        return k;
    }

    internal int RegionSecondTermDaysCopyToCenter(BLLCenter_Class_TermDays objBll)
    {
        var param = new SqlParameter[3];
        param[0] = new SqlParameter("@RegionId", SqlDbType.Int) { Value = objBll.Region_Id };
        param[1] = new SqlParameter("@SecondTermDays", SqlDbType.Int) { Value = objBll.SecondTermDays };
        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int) { Direction = ParameterDirection.Output };
        dalobj.sqlcmdExecute("CopyRegionSecondTermDaysToCenter", param);
        var k = (int)param[2].Value;
        return k;
    }

    public int Center_Class_TermDaysUpdate(BLLCenter_Class_TermDays objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@CenterClassTermDayId", SqlDbType.Int);
        param[0].Value = objbll.CenterClassTermDayId;
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Class_Id", SqlDbType.Int);
        param[3].Value = objbll.Class_Id;
        param[4] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        param[4].Value = objbll.Evaluation_Criteria_Type_Id;
        param[5] = new SqlParameter("@TotalTermDays", SqlDbType.Int);
        param[5].Value = objbll.TotalTermDays;
        
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("Center_Class_TermDaysUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int Center_Class_TermDaysDelete(BLLCenter_Class_TermDays objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Center_Class_TermDays_Id", SqlDbType.Int);
        //   param[0].Value = objbll.Center_Class_TermDays_Id;


        int k = dalobj.sqlcmdExecute("Center_Class_TermDaysDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable Center_Class_TermDaysSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Center_Class_TermDaysSelectById", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;
    }

    public DataTable Center_Class_TermDaysSelect(BLLCenter_Class_TermDays objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
        //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Center_Class_TermDaysSelectAll", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable Center_Class_TermDaysSelectByStatusID(BLLCenter_Class_TermDays objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Center_Class_TermDaysSelectByStatusID");
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }

    public DataTable Center_Class_TermDaysSelectAllByregionIdCenterId(BLLCenter_Class_TermDays objbll)
    {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@Main_Organisation_Id", SqlDbType.Int);
        param[0].Value = objbll.Main_Organisation_Id;
        param[1] = new SqlParameter("@Region_Id", SqlDbType.Int);
        param[1].Value = objbll.Region_Id;
        param[2] = new SqlParameter("@Center_Id", SqlDbType.Int);
        param[2].Value = objbll.Center_Id;
        param[3] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[3].Value = objbll.Session_Id;
        param[4] = new SqlParameter("@TermGroup_Id", SqlDbType.Int);
        param[4].Value = objbll.TermGroup_Id;





        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("Center_Class_TermDaysSelectAllByregionIdCenterId", param);
            return _dt;
        }
        catch (Exception _exception)
        {
            throw _exception;
        }
        finally
        {
            dalobj.CloseConnection();
        }

        return _dt;

    }


    #endregion


}
