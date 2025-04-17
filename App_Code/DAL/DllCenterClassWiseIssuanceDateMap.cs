using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DllCenterClassWiseIssuanceDateMap
/// </summary>
public class DllCenterClassWiseIssuanceDateMap
{
    DALBase dalobj = new DALBase();

    //public int AddCenterIssuanceDate(BllCenterClassWiseIssuanceDateMap bllcenterIssuanceDate)
    //{
    //    try
    //    {
    //        var connection = dalobj._cn;
    //        SqlConnection con = new SqlConnection(connection.ConnectionString);
    //        SqlCommand cmd = new SqlCommand("AddCenterClassIssuanceDate", con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("ReportCardIssuanceId", bllcenterIssuanceDate.ReportCardIssuanceId);
    //        cmd.Parameters.AddWithValue("CenterId", bllcenterIssuanceDate.CenterId);
    //        cmd.Parameters.AddWithValue("ClassId", bllcenterIssuanceDate.ClassId);
    //        cmd.Parameters.AddWithValue("StatusId", bllcenterIssuanceDate.StatusId);
    //        cmd.Parameters.AddWithValue("SessionId", bllcenterIssuanceDate.Session_Id);
    //        cmd.Parameters.AddWithValue("Evaluation_Criteria_Type_Id", bllcenterIssuanceDate.Evaluation_Criteria_Type_Id);
    //        con.Open();
    //        int k = cmd.ExecuteNonQuery();
    //        con.Close();
    //        return k;

    //    }
    //    catch (Exception e)
    //    {
    //        throw e;
    //    }
    //}

    internal void DeleteCenterAppliedDate(int deleteR)
    {
        var test = dalobj._cn;
        DataTable table = new DataTable("Table");
        using (SqlConnection connection = new SqlConnection(test.ConnectionString))
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = "delete FROM CenterClassWiseIssuanceDateMap WHERE  Id = " + deleteR
            };

            connection.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            
        }
    }

    //internal DataTable getAllDatAppliedCneterClasses(BllCenterClassWiseIssuanceDateMap obj)
    //{
    //    SqlParameter[] param = new SqlParameter[1];

    //    param[0] = new SqlParameter("@Evaluation_Criteria_Type_Id", SqlDbType.Int);
    //    param[0].Value = obj.Evaluation_Criteria_Type_Id;

    //    DataTable dt = new DataTable();
    //    try
    //    {
    //        dalobj.OpenConnection();
    //        dt = dalobj.sqlcmdFetch("GetDateAppliedAllCenterClasses", param);
    //        return dt;
    //    }
    //    catch (Exception _exception)
    //    {
    //        throw _exception;
    //    }
    //    finally
    //    {
    //        dalobj.CloseConnection();
    //    }
    //}
}