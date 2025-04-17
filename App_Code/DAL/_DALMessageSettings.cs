using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALMessageSettings
/// </summary>
public class _DALMessageSettings
{
    DALBase dalobj = new DALBase();
    public _DALMessageSettings()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public DataTable GetMessageSettings()
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetMessageSettings");
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
     
    public DataTable GetMessageSettingsById(BLLMessageSettings _obj)
    {
        SqlParameter[] param = new SqlParameter[1]; 

        param[0] = new SqlParameter("@Message_Id", SqlDbType.Int);
        param[0].Value = _obj.Message_Id;

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("GetMessageSettingsById", param);
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
    public int MessageSettingsAdd(BLLMessageSettings objbll)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Session_Id", SqlDbType.Int);
        param[0].Value = objbll.Session_Id;
        param[1] = new SqlParameter("@Message", SqlDbType.NVarChar);
        param[1].Value = objbll.Message;
        param[2] = new SqlParameter("@FeeDefaultMessage", SqlDbType.NVarChar);
        param[2].Value = objbll.FeeDefaultMessage;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@CreatedOn", SqlDbType.DateTime);
        param[4].Value = objbll.CreatedOn;
        param[5] = new SqlParameter("@CreatedBy", SqlDbType.Int);
        param[5].Value = objbll.CreatedBy;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("MessageSettingsInsert", param);
        int k = (int)param[6].Value;
        return k;

    }
    public int MessageSettingsUpdate(BLLMessageSettings objbll)
    {
        SqlParameter[] param = new SqlParameter[7];
        param[0] = new SqlParameter("@Message_Id", SqlDbType.Int);
        param[0].Value = objbll.Message_Id;
        param[1] = new SqlParameter("@Message", SqlDbType.NVarChar);
        param[1].Value = objbll.Message;
        param[2] = new SqlParameter("@FeeDefaultMessage", SqlDbType.NVarChar);
        param[2].Value = objbll.FeeDefaultMessage;
        param[3] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[3].Value = objbll.Status_Id;
        param[4] = new SqlParameter("@ModifiedOn", SqlDbType.DateTime);
        param[4].Value = objbll.ModifiedOn;
        param[5] = new SqlParameter("@ModifiedBy", SqlDbType.Int);
        param[5].Value = objbll.ModifiedBy;

        param[6] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[6].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("MessageSettingsUpdate", param);
        int k = (int)param[6].Value;
        return k;
    }
}