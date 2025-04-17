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
/// Summary description for _DALLmsSchEvent
/// </summary>
public class DALLmsSchEvent
{
    DALBase dalobj = new DALBase();


    public DALLmsSchEvent()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsSchEventAdd(BLLLmsSchEvent objbll)
    {
        SqlParameter[] param = new SqlParameter[14];

        ////////////param[0] = new SqlParameter("@Event_ID", SqlDbType.Int); 
        ////////////param[0].Value = objbll.Event_ID;
        //////////param[0] = new SqlParameter("@Schedule_ID", SqlDbType.Int); 
        //////////param[0].Value = objbll.Schedule_ID;
        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;
        param[1] = new SqlParameter("@EventType_ID", SqlDbType.Int); 
        param[1].Value = objbll.EventType_ID;
        param[2] = new SqlParameter("@EFrequency_ID", SqlDbType.Int);
        param[2].Value = objbll.EFrequency_ID;
        param[3] = new SqlParameter("@EventTitle", SqlDbType.NVarChar); 
        param[3].Value = objbll.EventTitle;
        param[4] = new SqlParameter("@EventDate", SqlDbType.DateTime);
        param[4].Value = objbll.EventDate;
        param[5] = new SqlParameter("@StartTime", SqlDbType.DateTime);
        param[5].Value = objbll.StartTime;
        ////////param[7] = new SqlParameter("@Duration", SqlDbType.NVarChar);
        ////////param[7].Value = objbll.Duration;
        param[6] = new SqlParameter("@EndTime", SqlDbType.DateTime);
        param[6].Value = objbll.EndTime;
        param[7] = new SqlParameter("@Message", SqlDbType.NVarChar); 
        param[7].Value = objbll.Message;
        param[8] = new SqlParameter("@EGroup_ID", SqlDbType.Int); 
        param[8].Value = objbll.EGroup_ID;
        param[9] = new SqlParameter("@EventLocation", SqlDbType.NVarChar);
        param[9].Value = objbll.EventLocation;
        param[10] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[10].Value = objbll.CreatedOn;
        param[11] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[11].Value = objbll.CreatedBy;
        ////////////////param[14] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        ////////////////param[14].Value = objbll.ModifiedOn;
        ////////////////param[15] = new SqlParameter("@ModifiedBy", SqlDbType.Int); 
        ////////////////param[15].Value = objbll.ModifiedBy;
        param[12] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[12].Value = objbll.Status_Id;




        param[13] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[13].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSchEventInsert", param);
        int k = (int)param[13].Value;
        return k;

    }
    public int LmsSchEventUpdate(BLLLmsSchEvent objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@Event_ID", SqlDbType.Int); param[0].Value = objbll.Event_ID;
        param[0] = new SqlParameter("@Schedule_ID", SqlDbType.Int); param[0].Value = objbll.Schedule_ID;
        param[1] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int); param[1].Value = objbll.Section_Subject_Id;
        param[2] = new SqlParameter("@EventType_ID", SqlDbType.Int); param[2].Value = objbll.EventType_ID;
        param[3] = new SqlParameter("@EFrequency_ID", SqlDbType.Int); param[3].Value = objbll.EFrequency_ID;
        param[4] = new SqlParameter("@EventTitle", SqlDbType.NVarChar); param[4].Value = objbll.EventTitle;
        param[5] = new SqlParameter("@EventDate", SqlDbType.DateTime); param[5].Value = objbll.EventDate;
        param[6] = new SqlParameter("@StartTime", SqlDbType.DateTime); param[6].Value = objbll.StartTime;
        param[7] = new SqlParameter("@Duration", SqlDbType.NVarChar); param[7].Value = objbll.Duration;
        param[8] = new SqlParameter("@EndTime", SqlDbType.DateTime); param[8].Value = objbll.EndTime;
        param[9] = new SqlParameter("@Message", SqlDbType.NVarChar); param[9].Value = objbll.Message;
        param[10] = new SqlParameter("@EGroup_ID", SqlDbType.Int); param[10].Value = objbll.EGroup_ID;
        param[11] = new SqlParameter("@EventLocation", SqlDbType.NVarChar); param[11].Value = objbll.EventLocation;
        param[12] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[12].Value = objbll.CreatedOn;
        param[13] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[13].Value = objbll.CreatedBy;
        param[14] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime); param[14].Value = objbll.ModifiedOn;
        param[15] = new SqlParameter("@ModifiedBy", SqlDbType.Int); param[15].Value = objbll.ModifiedBy;
        param[13] = new SqlParameter("@Status_Id", SqlDbType.Int); param[13].Value = objbll.Status_Id;



 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSchEventUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsSchEventDelete(BLLLmsSchEvent objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Event_ID", SqlDbType.Int);
        param[0].Value = objbll.Event_ID;


        int k = dalobj.sqlcmdExecute("LmsSchEventDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsSchEventSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSchEventSelectById", param);
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
    
    public DataTable LmsSchEventSelect(BLLLmsSchEvent objbll)
    {
  //////////  SqlParameter[] param = new SqlParameter[3];

  //////////  param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  ////////////  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSchEventSelectAll");
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

    public DataTable LmsSchEventSelectByStatusID(BLLLmsSchEvent objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSchEventSelectByStatusID");
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


    public DataTable LmsSchEventSelectAllBySectionSubjectIdWrkToolId(BLLLmsSchEvent objbll)
    {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Subject_Id", SqlDbType.Int);
        param[0].Value = objbll.Section_Subject_Id;


        param[1] = new SqlParameter("@WrkTool_ID", SqlDbType.Int);
        param[1].Value = objbll.WrkTool_ID;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSchEventSelectAllBySectionSubjectIdWrkToolId", param);
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


    public DataTable LmsSchEventSelectAllByEventID(BLLLmsSchEvent objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Event_ID", SqlDbType.Int);
        param[0].Value = objbll.Event_ID;






        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSchEventSelectAllByEventID", param);
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
