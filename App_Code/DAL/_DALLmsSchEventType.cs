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
/// Summary description for _DALLmsSchEventType
/// </summary>
public class DALLmsSchEventType
{
    DALBase dalobj = new DALBase();


    public DALLmsSchEventType()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsSchEventTypeAdd(BLLLmsSchEventType objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[0] = new SqlParameter("@EventType_ID", SqlDbType.Int); param[0].Value = objbll.EventType_ID;
        param[0] = new SqlParameter("@EventType", SqlDbType.NVarChar); param[0].Value = objbll.EventType;
        param[1] = new SqlParameter("@EventImage", SqlDbType.Int); param[1].Value = objbll.EventImage;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.NVarChar); param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.Int); param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[4].Value = objbll.CreatedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.NVarChar); param[5].Value = objbll.ModifiedOn;
        param[6] = new SqlParameter("@ModifiedBy", SqlDbType.NVarChar); param[6].Value = objbll.ModifiedBy;



        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSchEventTypeInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int LmsSchEventTypeUpdate(BLLLmsSchEventType objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@EventType_ID", SqlDbType.Int); param[0].Value = objbll.EventType_ID;
        param[0] = new SqlParameter("@EventType", SqlDbType.NVarChar); param[0].Value = objbll.EventType;
        param[1] = new SqlParameter("@EventImage", SqlDbType.Int); param[1].Value = objbll.EventImage;
        param[2] = new SqlParameter("@Status_Id", SqlDbType.NVarChar); param[2].Value = objbll.Status_Id;
        param[3] = new SqlParameter("@CreatedOn", SqlDbType.Int); param[3].Value = objbll.CreatedOn;
        param[4] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[4].Value = objbll.CreatedBy;
        param[5] = new SqlParameter("@ModifiedOn", SqlDbType.NVarChar); param[5].Value = objbll.ModifiedOn;
        param[6] = new SqlParameter("@ModifiedBy", SqlDbType.NVarChar); param[6].Value = objbll.ModifiedBy;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsSchEventTypeUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsSchEventTypeDelete(BLLLmsSchEventType objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsSchEventType_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsSchEventType_Id;


        int k = dalobj.sqlcmdExecute("LmsSchEventTypeDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsSchEventTypeSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSchEventTypeSelectById", param);
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
    
    public DataTable LmsSchEventTypeSelect(BLLLmsSchEventType objbll)
    {
  ////////  SqlParameter[] param = new SqlParameter[3];

  ////////  param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //////////  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsSchEventTypeSelectAll");
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

    public DataTable LmsSchEventTypeSelectByStatusID(BLLLmsSchEventType objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsSchEventTypeSelectByStatusID");
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
