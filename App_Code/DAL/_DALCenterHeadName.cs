using System;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for _DALCenterHeadName
/// </summary>
public class _DALCenterHeadName
{
    private readonly DALBase dalobj = new DALBase();
    public DataTable GetListofCentersHeadName()
    {
        var test = dalobj._cn;
        DataTable table = new DataTable("Table");
        using (SqlConnection connection = new SqlConnection(test.ConnectionString))
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = @"
                   SELECT cn.Center_Id, c.Center_Name, HeadERP, HeadName
                          FROM [Center_HeadName] cn INNER JOIN Center c on cn.Center_Id = c.Center_Id"
            };

            connection.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }
        return table;
    }
    public void UpdateCentersHeadName(BLLCenterHeadName bllCenterHeadName)
    {
        var test = dalobj._cn;
        DataTable table = new DataTable("Table");
        using (SqlConnection connection = new SqlConnection(test.ConnectionString))
        {
            var command = new SqlCommand
            {
                Connection = connection,
                CommandType = CommandType.Text,
                CommandText = @"
                   UPDATE [Center_HeadName] SET HeadERP = '" + bllCenterHeadName.HeadERP + "' , HeadName = '" + bllCenterHeadName.HeadName + "' WHERE Center_Id = " + bllCenterHeadName.Center_Id
            };

            connection.Open();
            var adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
        }
    }
}