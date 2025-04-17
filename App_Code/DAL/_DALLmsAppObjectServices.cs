using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALLmsAppObjectServices
/// </summary>
public class _DALLmsAppObjectServices
{
    DALBase dalobj = new DALBase();


    public _DALLmsAppObjectServices()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsAppObjectServicesAdd(BLLLmsAppObjectServices objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAppObjectServicesInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int LmsAppObjectServicesUpdate(BLLLmsAppObjectServices objbll)
    {
        SqlParameter[] param = new SqlParameter[10];

 
        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAppObjectServicesUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsAppObjectServicesDelete(BLLLmsAppObjectServices objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsAppObjectServices_Id", SqlDbType.Int);
     //   param[0].Value = objbll.LmsAppObjectServices_Id;


        int k = dalobj.sqlcmdExecute("LmsAppObjectServicesDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsAppObjectServicesSelect(string _pagename, int _partType)
    {
    SqlParameter[] param = new SqlParameter[2];

    param[0] = new SqlParameter("@pagename", SqlDbType.NVarChar);
    param[0].Value = _pagename;

    param[1] = new SqlParameter("@PartType", SqlDbType.Int);
    param[1].Value = _partType;

    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsAppObjectServicesGetPriviliges", param);
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
    
    public DataTable LmsAppObjectServicesSelect(BLLLmsAppObjectServices objbll)
    {
    SqlParameter[] param = new SqlParameter[3];

    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
  //  param[0].Value = objbll.Evaluation_Criteria_Type_Id;


    DataTable _dt = new DataTable();

    try
        {
        dalobj.OpenConnection();
        _dt = dalobj.sqlcmdFetch("LmsAppObjectServicesSelect", param);
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


    public int LmsAppObjectServicesSelectField(int _Id)
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
