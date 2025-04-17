using System;
using System.Data;
using System.Data.SqlClient;


/// <summary>
/// Summary description for _DALLmsAppMenu
/// </summary>
public class _DALLmsAppMenu
    {
    DALBase dalobj = new DALBase();


    public _DALLmsAppMenu()
        {
        //
        // TODO: Add constructor logic here
        //
        }
    #region 'Start of Execution Methods'
    public int LmsAppMenuAdd(BLLLmsAppMenu objbll)
        {
        SqlParameter[] param = new SqlParameter[5];

        param[0] = new SqlParameter("@MenuName", SqlDbType.NVarChar);
        param[0].Value = objbll.MenuName;

        param[1] = new SqlParameter("@MenuText", SqlDbType.NVarChar);
        param[1].Value = objbll.MenuText;

        param[2] = new SqlParameter("@PageID", SqlDbType.Int);
        param[2].Value = objbll.PageID;

        param[3] = new SqlParameter("@PrntMenu_ID", SqlDbType.Int);
        param[3].Value = objbll.PrntMenu_ID;

        param[4] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[4].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAppMenuInsert", param);
        int k = (int)param[4].Value;
        return k;

        }
    public int LmsAppMenuUpdate(BLLLmsAppMenu objbll)
        {
        SqlParameter[] param = new SqlParameter[6];

        param[0] = new SqlParameter("@Menu_ID", SqlDbType.Int);
        param[0].Value = objbll.Menu_ID;

        param[1] = new SqlParameter("@MenuName", SqlDbType.NVarChar);
        param[1].Value = objbll.MenuName;

        param[2] = new SqlParameter("@MenuText", SqlDbType.NVarChar);
        param[2].Value = objbll.MenuText;

        param[3] = new SqlParameter("@PageID", SqlDbType.Int);
        param[3].Value = objbll.PageID;

        param[4] = new SqlParameter("@PrntMenu_ID", SqlDbType.Int);
        param[4].Value = objbll.PrntMenu_ID;

        param[5] = new SqlParameter("@AlreadyIn", SqlDbType.Int);
        param[5].Direction = ParameterDirection.Output;

        dalobj.sqlcmdExecute("LmsAppMenuUpdate", param);
        int k = (int)param[5].Value;
        return k;
        }
    public int LmsAppMenuDelete(BLLLmsAppMenu objbll)
        {
        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Menu_ID", SqlDbType.Int);
        param[0].Value = objbll.Menu_ID;

        int k = dalobj.sqlcmdExecute("LmsAppMenuDelete", param);

        return k;
        }
    #endregion

    #region 'Start of Fetch Methods'
    public DataTable LmsAppMenuSelect(int _id)
        {

        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Menu_ID", SqlDbType.Int);
        param[0].Value = _id;


        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppMenuSelectByID", param);
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

    public DataTable LmsAppMenuSelect(BLLLmsAppMenu objbll)
        {

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@User_Type_Id", SqlDbType.Int);
        param[0].Value = objbll.User_Type_Id;

        param[1] = new SqlParameter("@PrntMenu_ID", SqlDbType.Int);
        param[1].Value = objbll.PrntMenu_ID;



        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppMenuSelectByPrntMenu", param);
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

    public DataTable LmsAppMenuSelect()
        {

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppMenuSelectAll");
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


    public DataTable LmsAppMenuSelectByStatusId(BLLLmsAppMenu objbll)
        {

        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@Status_Id", SqlDbType.Int);
        param[0].Value = objbll.Status_id;



        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppMenuSelectByStatusId", param);
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

    public DataTable LmsAppPageSelect()
        {

        DataTable _dt = new DataTable();

        try
            {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPageSelectAll");
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


    public DataTable LmsAppPagesSelectForFAQ()
    {

        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPagesSelectForFAQ");
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


    public int LmsAppMenuSelectField(int _Id)
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


    public DataTable LmsAppMenuSelectByPrntMenuID(BLLLmsAppMenu objbll)
    {

        SqlParameter[] param = new SqlParameter[2];      

        param[0] = new SqlParameter("@PrntMenu_ID", SqlDbType.Int);
        param[0].Value = objbll.PrntMenu_ID;

        param[1] = new SqlParameter("@User_Type_ID", SqlDbType.Int);
        param[1].Value = objbll.User_Type_Id;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppMenuSelectByPrntMenuID", param);
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

    public DataTable LmsAppPagesSelectPageByPageName(BLLLmsAppMenu objbll)
    {

        SqlParameter[] param = new SqlParameter[1];

        param[0] = new SqlParameter("@PageName", SqlDbType.NVarChar);
        param[0].Value = objbll.PageName;




        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppPagesSelectPageByPageName", param);
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

    public DataTable LmsAppMenuSelectByUserType_Id(BLLLmsAppMenu objbll)
    {

        SqlParameter[] param = new SqlParameter[2];

        param[0] = new SqlParameter("@User_Type_Id", SqlDbType.Int);
        param[0].Value = objbll.User_Type_Id;

        param[1] = new SqlParameter("@Menu_ID", SqlDbType.Int);
        param[1].Value = objbll.Menu_ID;



        DataTable _dt = new DataTable();

        try
        {
            dalobj.OpenConnection();
            _dt = dalobj.sqlcmdFetch("LmsAppMenuSelectByUserType_ID", param);
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
    
    }
