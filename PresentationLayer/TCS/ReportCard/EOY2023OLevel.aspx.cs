using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

public partial class PresentationLayer_TCS_ReportCard_EOY2023OLevel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Session_Id"] == null)
        {
            Response.Redirect("~/login.aspx", false);
        }
    }

    [WebMethod]
    public static string test(int TermGroup_Id,int Student_Id, int Class_Id, int Session_Id)//int Session_Id, int TermGroup_Id, int Section_Id, int Student_Id = 0
    {
        string connectionString = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {

            conn.Open();

            SqlCommand comm = new SqlCommand("EXEC sp_OALevel_Result_Card_New_Test " + TermGroup_Id + "," + Student_Id + "," + Class_Id + " ," + Session_Id + "  ", conn);
            comm.CommandTimeout = 300;
            try
            {
                SqlDataAdapter data = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                data.Fill(dt);

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dt);

                return JSONString;
            }
            catch (Exception)
            {
                return "Not Saved";
            }
            finally
            {
                conn.Close();
            }
        } 
    }
}