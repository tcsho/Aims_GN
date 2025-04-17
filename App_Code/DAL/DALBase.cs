using System;
using System.Data;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;

/// <summary>
/// Summary description for DALBase
/// </summary>
public class DALBase
{
    protected static string strConnect;

    public SqlConnection _cn = new SqlConnection();
    public DALBase()
    {
        //
        // TODO: Add constructor logic here
        //
        _cn = GetConnection();
    }

    static DALBase()
    {
        strConnect = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"]);
    }

    /// <summary>
    /// Gets a SqlConnection to the local sqlserver
    /// </summary>
    /// <returns>SqlConnection</returns> 

    protected SqlConnection GetConnection()
    {
        SqlConnection oConnection = new SqlConnection(strConnect);
        return oConnection;
    }

    public static DataSet getDataSetBySp(string spName, params SqlParameter[] commandParameters)
    {
        try
        {
            return SqlHelper.ExecuteDataset(strConnect, CommandType.StoredProcedure, spName, commandParameters);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public int exeTextQuery(System.Text.StringBuilder query)
    {
        try
        {
            int i = 0;

            i = SqlHelper.ExecuteNonQuery(strConnect, CommandType.Text, query.ToString());
            return i;
        }
        catch (Exception oException)
        {
            throw oException;
        }

    }


    public DataSet get_Gender()
    {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("GetGender", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataSet oDataSet = new DataSet();

        try
        {

            oConnection.Open();
            oAdapter.Fill(oDataSet, "obj");
            return oDataSet;
        }
        catch (Exception oException)
        {
            throw oException;
        }
        finally
        {
            oConnection.Close();
        }
    }

    #region 'LSM Base Code'

    ///////Generalized methods for LMS///////////////////////////////////////////////////


    public void OpenConnection()
    {
        //   SqlConnection oConnection = GetConnection();
        try
        {
            if (_cn.State != ConnectionState.Open)
            {
                _cn.Open();
            }
        }
        catch
        {
            throw;
        }

    }

    public void CloseConnection()
    {

        try
        {
            if (_cn.State != ConnectionState.Closed)
            {
                _cn.Close();
            }
        }
        catch
        {

            throw;
        }
    }

    public int sqlcmdExecute(string procedurename, SqlParameter[] param)
    {
        //SqlConnection oConnection = GetConnection();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = procedurename;
        sqlcmd.Connection = _cn;
        for (int i = 0; i < param.Length; i++)
        {
            sqlcmd.Parameters.Add(param[i]);
        }
        try
        {
            OpenConnection();
            return sqlcmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public int sqlcmdExecuteTimeOut2Min(string procedurename, SqlParameter[] param)
        {
        //SqlConnection oConnection = GetConnection();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = procedurename;
        sqlcmd.Connection = _cn;
        sqlcmd.CommandTimeout = 10000;
        for (int i = 0; i < param.Length; i++)
            {
            sqlcmd.Parameters.Add(param[i]);
            }
        try
            {
            OpenConnection();
            return sqlcmd.ExecuteNonQuery();
            }
        catch
            {
            throw;
            }
        finally
            {
            CloseConnection();
            }
        }
    public int sqlcmdExecuteTimeOutMin(string procedurename, SqlParameter[] param,int Mins)
    {
        //SqlConnection oConnection = GetConnection();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = procedurename;
        sqlcmd.Connection = _cn;
        sqlcmd.CommandTimeout = (Mins*60);
        for (int i = 0; i < param.Length; i++)
        {
            sqlcmd.Parameters.Add(param[i]);
        }
        try
        {
            OpenConnection();
            return sqlcmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            CloseConnection();
        }
    }

    public DataTable sqlcmdFetch(string procedurename, SqlParameter[] param)
    {
        //SqlConnection oConnection = GetConnection();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = procedurename;
        sqlcmd.Connection = _cn;
        sqlcmd.CommandTimeout = 12000000;

        SqlDataAdapter myAdapter = new SqlDataAdapter();

        DataTable dt = new DataTable();

        for (int i = 0; i < param.Length; i++)
        {
            sqlcmd.Parameters.Add(param[i]);
        }

        try
        {
            OpenConnection();

            myAdapter.SelectCommand = sqlcmd;
            myAdapter.Fill(dt);
        }

        catch (Exception ex)
        {
            string output;
            output = ex.Message.ToString();
        }
        CloseConnection();
        return dt;
    }
    public DataSet sqlcmdFetch_DS(string procedurename, SqlParameter[] param)
    {
        //SqlConnection oConnection = GetConnection();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = procedurename;
        sqlcmd.Connection = _cn;
        sqlcmd.CommandTimeout = 12000000;

        SqlDataAdapter myAdapter = new SqlDataAdapter();

        DataSet dt = new DataSet();

        for (int i = 0; i < param.Length; i++)
        {
            sqlcmd.Parameters.Add(param[i]);
        }

        try
        {
            OpenConnection();

            myAdapter.SelectCommand = sqlcmd;
            myAdapter.Fill(dt);
        }

        catch (Exception ex)
        {
            string output;
            output = ex.Message.ToString();
        }
        CloseConnection();
        return dt;
    }
    public DataTable sqlcmdFetch(string procedurename)
    {
        SqlConnection oConnection = GetConnection();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = procedurename;
        sqlcmd.Connection = oConnection;
        SqlDataAdapter myAdapter = new SqlDataAdapter();

        DataTable dt = new DataTable();
        try
        {
            OpenConnection();

            myAdapter.SelectCommand = sqlcmd;
            myAdapter.Fill(dt);
        }

        catch (Exception ex)
        {
            string output;
            output = ex.Message.ToString();
        }
        CloseConnection();
        return dt;
    }
    public DataTable sqlcmdFetch(string procedurename, SqlParameter[] param, int CommandTimeOut)
    {
        //SqlConnection oConnection = GetConnection();

        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = procedurename;
        sqlcmd.Connection = _cn;
        sqlcmd.CommandTimeout = CommandTimeOut;

        SqlDataAdapter myAdapter = new SqlDataAdapter();

        DataTable dt = new DataTable();

        for (int i = 0; i < param.Length; i++)
        {
            sqlcmd.Parameters.Add(param[i]);
        }

        try
        {
            OpenConnection();

            myAdapter.SelectCommand = sqlcmd;
            myAdapter.Fill(dt);
        }

        catch (Exception ex)
        {
            string output;
            output = ex.Message.ToString();
        }
        CloseConnection();
        return dt;
    }

    public SqlDataReader sqlcmdSelectByDR(string procedurename, SqlParameter[] param)
    {
        SqlCommand sqlcmd = new SqlCommand();
        sqlcmd.CommandType = CommandType.StoredProcedure;
        sqlcmd.CommandText = procedurename;
        sqlcmd.Connection = _cn;
        for (int i = 0; i < param.Length; i++)
        {
            sqlcmd.Parameters.Add(param[i]);
        }
        SqlDataReader dr;
        dr = sqlcmd.ExecuteReader();
        return dr;
    }




    ///////Generalized methods for LMS///////////////////////////////////////////////////
    #endregion


    #region Library Application Code
    public void FillDropDown(DataTable _dt, DropDownList _ddl, string _strcode, string _strdesc)
    {
        _ddl.DataSource = null;
        _ddl.DataBind();
        _ddl.Items.Clear();

        if (_dt != null && _dt.Rows.Count > 0)
        {
            _ddl.DataSource = _dt;
            _ddl.DataValueField = _dt.Columns[_strcode].ToString();
            _ddl.DataTextField = _dt.Columns[_strdesc].ToString();
            _ddl.DataBind();
        }
        if (_ddl.Items.FindByValue("0") == null)
            _ddl.Items.Insert(0, new ListItem("Select", "0"));
    }

    public void FillDropDown(DataTable _dt, RadioButtonList _ddl, string _strcode, string _strdesc)
    {
        if (_dt != null && _dt.Rows.Count > 0)
        {

            _ddl.DataSource = _dt;
            _ddl.DataValueField = _dt.Columns[_strcode].ToString();
            _ddl.DataTextField = _dt.Columns[_strdesc].ToString();
            _ddl.DataBind();

        }
    }
     
    #endregion

    //====================== Added by Misbah =====================================================
    public void SelectGridViewRow(object sender, GridView gv)
    {
        ImageButton imgBtn;
        LinkButton lnkBtn;
        GridViewRow gvr;
        if (sender.GetType().Name == "ImageButton")
        {
            imgBtn = (ImageButton)sender;
            gvr = (GridViewRow)imgBtn.NamingContainer;
            gv.SelectedIndex = gvr.RowIndex;
        }
        else if (sender.GetType().Name == "LinkButton")
        {
            lnkBtn = (LinkButton)sender;
            gvr = (GridViewRow)lnkBtn.NamingContainer;
            gv.SelectedIndex = gvr.RowIndex;
        }
    }

    public void ShowHidePanels(int mode, Panel pnl)
    {
        switch (mode)
        {
            case 0:
                {
                    pnl.Attributes.CssStyle.Add("display", "none");
                    break;
                }

            case 1:
                {
                    pnl.Attributes.CssStyle.Add("display", "inline");
                    break;
                }


        }
    }

    public bool ApplyPageAccessSettings(string strPageName, int userTypeID)
        {
            {
            DataTable _dt = new DataTable();
            bool isAllowed = false;

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@User_type_ID", SqlDbType.Int); param[0].Value = userTypeID;
            param[1] = new SqlParameter("@PageName", SqlDbType.NVarChar); param[1].Value = strPageName;

            try
                {
                OpenConnection();
                _dt = sqlcmdFetch("LmsAppMenuServicesSelectByPageAndUserType", param);
                if (_dt.Rows.Count > 0)
                    {
                    DataRow dr = _dt.Rows[0];
                    if (dr["isAllow"] != DBNull.Value)
                        {
                        isAllowed = Convert.ToBoolean(dr["isAllow"]);
                        }
                    }
                }
            catch (Exception oException)
                {
                throw oException;
                }
            finally
                {
                CloseConnection();
                }

            return isAllowed;
            }
        }

public DataTable ApplyPageAccessSettingsTable(string strPageName, int userTypeID)
    {
        {
            DataTable _dt = new DataTable();

            SqlParameter[] param = new SqlParameter[2];

            param[0] = new SqlParameter("@User_type_ID", SqlDbType.Int); param[0].Value = userTypeID;
            param[1] = new SqlParameter("@PageName", SqlDbType.NVarChar); param[1].Value = strPageName;
            
            try
            {
                OpenConnection();
                _dt = sqlcmdFetch("LmsAppMenuServicesSelectByPageAndUserType", param);
            }
            catch (Exception oException)
            {
                throw oException;
            }
            finally
            {
                CloseConnection();
            }

            return _dt;
        }


        //==============================================================================================
    }

public void FillRadioButtonList(DataTable _dt, RadioButtonList _ddl, string _strcode, string _strdesc)
{
    if (_dt != null && _dt.Rows.Count > 0)
    {

        _ddl.DataSource = _dt;
        _ddl.DataValueField = _dt.Columns[_strcode].ToString();
        _ddl.DataTextField = _dt.Columns[_strdesc].ToString();
        _ddl.DataBind();

    }

}


}