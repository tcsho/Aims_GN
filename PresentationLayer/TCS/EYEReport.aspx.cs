
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;
using System.Configuration;

public partial class PresentationLayer_EYEReport : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Session_Id"] == null)
        {
            Response.Redirect("~/login.aspx", false);
        }
    }

    [WebMethod]
    public static string testHeader(int sectionId, int sessionId, int TermGroupId, int StudentId)//int Session_Id, int TermGroup_Id, int Section_Id, int Student_Id = 0
    {


        string connectionString = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;
        BLLStudent_Performance_ClassAchvRating objClsSec = new BLLStudent_Performance_ClassAchvRating();
        DataTable dtsub = new DataTable();

       


        using (SqlConnection conn = new SqlConnection(connectionString))
        {

            conn.Open();

            SqlCommand comm = new SqlCommand("exec TCS_Result_StudentInformation_Class1_And_2 '" + sectionId + "','" + sessionId + "','" + TermGroupId + "','" + StudentId + "'", conn);

            try
            {
                SqlDataAdapter data = new SqlDataAdapter(comm);
                DataTable dt = new DataTable();
                data.Fill(dt);

                string JSONString = string.Empty;
                JSONString = JsonConvert.SerializeObject(dt);


                objClsSec.Main_Organistion_Id = 1;
                objClsSec.Class_Id = Convert.ToInt32(dt.Rows[0]["Class_Id"].ToString());
           
                dtsub = (DataTable)objClsSec.Student_Performance_ClassAchvRatingSelectAllByOrgId(objClsSec);

                string JSONStringRating = string.Empty;
                JSONStringRating = JsonConvert.SerializeObject(dtsub);

                SqlCommand commD = new SqlCommand("exec TCS_Result_StudentPerformanceSection_NEW_CLASS1_2 '" + sectionId + "','" + sessionId + "','" + TermGroupId + "','" + StudentId + "'", conn);

                SqlDataAdapter dataD = new SqlDataAdapter(commD);
                DataTable dtD = new DataTable();
                dataD.Fill(dtD);


                // Grouping the DataTable by subjectName
                var groupedDataD = dtD.AsEnumerable()
                    .GroupBy(rowD => new
                    {
                        subjectId = rowD.Field<int>("subject_Id"),
                        subjectName = rowD.Field<string>("Subject_Name")
                    })
                    .Select(groupD => new
                    {
                        subjectName = groupD.Key.subjectName,
                        subjectid = groupD.Key.subjectId,

                        Items = groupD.Select(rowD => dtD.Columns.Cast<DataColumn>()
                         .ToDictionary(colD => colD.ColumnName, colD => rowD[colD]))
                    });



                string JSONStringD = string.Empty;

                JSONStringD = JsonConvert.SerializeObject(groupedDataD);

                var result = new
                {
                    Indicator = JsonConvert.DeserializeObject(JSONStringRating),
                    Header = JsonConvert.DeserializeObject(JSONString),
                    Detail = JsonConvert.DeserializeObject(JSONStringD)
                };


                return JsonConvert.SerializeObject(result);



            }
            catch (Exception)
            {
                return "Not Found";
            }
            finally
            {
                conn.Close();
            }
        }
    }

}