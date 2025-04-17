using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PresentationLayer_TCS_ReportCard_EOY2023SectionWise : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Session_Id"] == null)
        {
            Response.Redirect("~/login.aspx", false);
        }
    }

    [WebMethod]
    public static string test(int Session_Id, int TermGroup_Id, int Section_Id, int Student_Id = 0)//int Session_Id, int TermGroup_Id, int Section_Id, int Student_Id = 0
    {
        string connectionString = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connectionString))
        {

            conn.Open();

            SqlCommand comm = new SqlCommand("EXEC TCS_Result_SectionResultAllPOPULATEMYE2021 " + Session_Id + "," + TermGroup_Id + "," + Section_Id + " ," + Student_Id + "  ", conn);
	    comm.CommandTimeout = 5000;
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