using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALLoginLog
/// </summary>
public class _DALLoginLog
{
    DALBase dalobj = new DALBase();


    public _DALLoginLog()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LoginLogAdd(BLLLoginLog objbll)
    {
        SqlParameter[] param = new SqlParameter[6];


        param[0] = new SqlParameter("@User_Name", SqlDbType.NVarChar); 
        param[0].Value = objbll.User_Name;

        param[1] = new SqlParameter("@Password", SqlDbType.NVarChar); 
        param[1].Value = objbll.Password;
        
        param[2] = new SqlParameter("@CreatedOn", SqlDbType.DateTime); 
        param[2].Value = objbll.CreatedOn;
        
        param[3] = new SqlParameter("@isSuccess", SqlDbType.Bit); 
        param[3].Value = objbll.IsSuccess;

        param[4] = new SqlParameter("@MO_Id", SqlDbType.Int);

        if (objbll.MO_Id==0)
            {
            param[4].Value = DBNull.Value;
            }
        else
            {
            param[4].Value = objbll.MO_Id;
            }

        param[5] = new SqlParameter("@Ip_Add", SqlDbType.NVarChar);
        param[5].Value = objbll.IP_Add;
        


        int k = dalobj.sqlcmdExecute("LoginLogInsert", param);

        return k;

    }
    public int LoginLogUpdate(BLLLoginLog objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LoginLogUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LoginLogDelete(BLLLoginLog objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LoginLog_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LoginLog_Id;


        int k = dalobj.sqlcmdExecute("LoginLogDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LoginLogSelect(int _id)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
    param[0].Value = _id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LoginLogSelect", param);
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
    
    public DataTable LoginLogSelect(BLLLoginLog objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LoginLogSelect", param);
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


    public int LoginLogSelectField(int _Id)
        {
        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@Section_Id", SqlDbType.Int);
        param[0].Value = _Id;

        param[1] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[1].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("", param);
        int k = (int)param[1].Value;
        return k;

        }


    #endregion


}
