using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Country
/// </summary>
public class DALHomePageStats:DALBase
{
    public DALHomePageStats()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public DataTable get_HomePageStats(int ID)
        {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("HomePageStatics_All", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter para_ID = new SqlParameter("@UserId", SqlDbType.Int, 4);
        para_ID.Value = ID;
        oCommand.Parameters.Add(para_ID);


        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataTable oDataSet = new DataTable();

        try
            {
            oConnection.Open();
            oAdapter.Fill(oDataSet);
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

    public DataTable get_HomePageContactInfo(int ID)
    {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("HomePageContactInfo_All", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter para_ID = new SqlParameter("@UserId", SqlDbType.Int, 4);
        para_ID.Value = ID;
        oCommand.Parameters.Add(para_ID);


        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataTable oDataSet = new DataTable();

        try
        {
            oConnection.Open();
            oAdapter.Fill(oDataSet);
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

    public DataTable get_HomePageStatsBarChart(int ID)
        {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("HomePageStatics_All2Columns", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter para_ID = new SqlParameter("@UserId", SqlDbType.Int, 4);
        para_ID.Value = ID;
        oCommand.Parameters.Add(para_ID);


        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataTable oDataSet = new DataTable();

        try
            {
            oConnection.Open();
            oAdapter.Fill(oDataSet);
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
    public DataTable get_HomePagePromotionStats(int ID,int session_Id)
    {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("HomePagePromotionStatics", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter para_ID = new SqlParameter("@UserId", SqlDbType.Int, 4);
        para_ID.Value = ID;
        oCommand.Parameters.Add(para_ID);


        SqlParameter sess_ID = new SqlParameter("@Session_Id", SqlDbType.Int, 4);
        sess_ID.Value = session_Id;
        oCommand.Parameters.Add(sess_ID);

        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataTable oDataSet = new DataTable();

        try
        {
            oConnection.Open();
            oAdapter.Fill(oDataSet);
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

    public DataTable get_HomePageStatsBarChartAdmissions(int ID)
    {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("HomePageStatics_AllAdmissions", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter para_ID = new SqlParameter("@UserId", SqlDbType.Int, 4);
        para_ID.Value = ID;
        oCommand.Parameters.Add(para_ID);


        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataTable oDataSet = new DataTable();

        try
        {
            oConnection.Open();
            oAdapter.Fill(oDataSet);
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

    public DataTable get_OgrUserLevel(int ID)
        {
        SqlConnection oConnection = GetConnection();

        // build the command
        SqlCommand oCommand = new SqlCommand("GetOrganizationUserLevel", oConnection);
        oCommand.CommandType = CommandType.StoredProcedure;

        SqlParameter para_ID = new SqlParameter("@UserTypeId", SqlDbType.Int, 4);
        para_ID.Value = ID;
        oCommand.Parameters.Add(para_ID);


        // Adapter and DataSet
        SqlDataAdapter oAdapter = new SqlDataAdapter();
        oAdapter.SelectCommand = oCommand;
        DataTable oDataSet = new DataTable();

        try
            {
            oConnection.Open();
            oAdapter.Fill(oDataSet);
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
    }
