using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALLmsAppPages
/// </summary>
public class DALLmsAppPages
{
    DALBase dalobj = new DALBase();


    public DALLmsAppPages()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    #region 'Start of Execution Methods'
    public int LmsAppPagesAdd(BLLLmsAppPages objbll)
    {
        SqlParameter[] param = new SqlParameter[15];

        param[14] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[14].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAppPagesInsert", param);
        int k = (int)param[14].Value;
        return k;

    }
    public int LmsAppPagesUpdate(BLLLmsAppPages objbll)
    {
        SqlParameter[] param = new SqlParameter[10];


        param[9] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[9].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAppPagesUpdate", param);
        int k = (int)param[9].Value;
        return k;
    }
    public int LmsAppPagesDelete(BLLLmsAppPages objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@LmsAppPages_Id", SqlDbType.Int);
        //   param[0].Value = objbll.LmsAppPages_Id;


        int k = dalobj.sqlcmdExecute("LmsAppPagesDelete", param);

        return k;
    }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsAppPagesSelect(int _id)
    {
        SqlParameter[] param = new SqlParameter[3];

        param[0] = new SqlParameter("@sp_student_id", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPagesSelectById", param);
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

    public DataTable LmsAppPagesSelect(BLLLmsAppPages objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Page_ID", SqlDbType.Int);
        param[0].Value = objbll.Page_ID;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPagesSelectByID", param);
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
    public DataTable LmsAppPagesSelectByPageName(BLLLmsAppPages objbll)
    {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@PageName", SqlDbType.NVarChar);
        param[0].Value = objbll.PageName;


        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPagesSelectByPageName", param);
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
    public DataTable LmsAppPagesSelectByStatusID(BLLLmsAppPages objbll)
    {
        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPagesSelectByStatusID");
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
