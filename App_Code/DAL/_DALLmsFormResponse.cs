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
/// Summary description for _DALLmsFormResponse
/// </summary>
public class DALLmsFormResponse
{
    DALBase dalobj = new DALBase();


    public DALLmsFormResponse()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsFormResponseAdd(BLLLmsFormResponse objbll)
    {
        SqlParameter[] param = new SqlParameter[9];

        //////param[0] = new SqlParameter("@Response_ID", SqlDbType.Int); 
        //////param[0].Value = objbll.Response_ID;
        param[0] = new SqlParameter("@Topic_ID", SqlDbType.Int); 
        param[0].Value = objbll.Topic_ID;
        param[1] = new SqlParameter("@Message", SqlDbType.NVarChar); 
        param[1].Value = objbll.Message;
        param[2] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[2].Value = objbll.CreatedOn;
        param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[3].Value = objbll.CreatedBy;
        param[4] = new SqlParameter("@ObtainePoints", SqlDbType.Int); 
        param[4].Value = objbll.ObtainePoints;
        param[5] = new SqlParameter("@ParentResponse_ID", SqlDbType.Int); 
        param[5].Value = objbll.ParentResponse_ID;
        param[6] = new SqlParameter("@Participant_ID", SqlDbType.Int); 
        param[6].Value = objbll.Participant_ID;
        param[7] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[7].Value = objbll.Status_Id;




        param[8] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[8].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsFormResponseInsert", param);
        int k = (int)param[8].Value;
        return k;

    }
    public int LmsFormResponseUpdate(BLLLmsFormResponse objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

        param[0] = new SqlParameter("@Response_ID", SqlDbType.Int); 
        param[0].Value = objbll.Response_ID;
        param[0] = new SqlParameter("@Topic_ID", SqlDbType.Int); 
        param[0].Value = objbll.Topic_ID;
        param[1] = new SqlParameter("@Message", SqlDbType.NVarChar); 
        param[1].Value = objbll.Message;
        param[2] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[2].Value = objbll.CreatedOn;
        param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int); 
        param[3].Value = objbll.CreatedBy;
        param[4] = new SqlParameter("@ObtainePoints", SqlDbType.Int); 
        param[4].Value = objbll.ObtainePoints;
        param[5] = new SqlParameter("@ParentResponse_ID", SqlDbType.Int); 
        param[5].Value = objbll.ParentResponse_ID;
        param[6] = new SqlParameter("@Participant_ID", SqlDbType.Int); 
        param[6].Value = objbll.Participant_ID;
        param[7] = new SqlParameter("@Status_Id", SqlDbType.Int); 
        param[7].Value = objbll.Status_Id;


 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsFormResponseUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }

    public int LmsFormResponseUpdateObtainPoint(BLLLmsFormResponse objbll)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@Response_ID", SqlDbType.Int); 
        param[0].Value = objbll.Response_ID;
        //////////param[0] = new SqlParameter("@Topic_ID", SqlDbType.Int); param[0].Value = objbll.Topic_ID;
        //////////param[1] = new SqlParameter("@Message", SqlDbType.NVarChar); param[1].Value = objbll.Message;
        //////////param[2] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); param[2].Value = objbll.CreatedOn;
        //////////param[3] = new SqlParameter("@CreatedBy", SqlDbType.Int); param[3].Value = objbll.CreatedBy;
        param[1] = new SqlParameter("@ObtainePoints", SqlDbType.Int); 
        param[1].Value = objbll.ObtainePoints;
        //////param[5] = new SqlParameter("@ParentResponse_ID", SqlDbType.Int); param[5].Value = objbll.ParentResponse_ID;
        //////param[6] = new SqlParameter("@Participant_ID", SqlDbType.Int); param[6].Value = objbll.Participant_ID;
        //////param[7] = new SqlParameter("@Status_Id", SqlDbType.Int); param[7].Value = objbll.Status_Id;



        param[2] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[2].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsFormResponseUpdateObtainPoint", param);
        int k = (int)param[2].Value;
        return k;
    }


    public int LmsFormResponseDelete(BLLLmsFormResponse objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Response_ID", SqlDbType.Int);
        param[0].Value = objbll.Response_ID;


        int k = dalobj.sqlcmdExecute("LmsFormResponseDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsFormResponseSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsFormResponseSelectById", param);
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
    
    public DataTable LmsFormResponseSelect(BLLLmsFormResponse objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Topic_ID", SqlDbType.Int);
        param[0].Value = objbll.Topic_ID;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsFormResponseSelectAll", param);
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

    public DataTable LmsFormResponseSelectByStatusID(BLLLmsFormResponse objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsFormResponseSelectByStatusID");
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
