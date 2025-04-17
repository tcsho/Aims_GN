using System;
using System.Data;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;
using System.Data.SqlClient;
using CrystalDecisions.Shared;
using System.IO;

public partial class PresentationLayer_TCS_TCS_resultCard : System.Web.UI.Page
{
    //BLLCrystalReports bllcry = new BLLCrystalReports();
    //public ReportDocument report = new ReportDocument();
    string reppath, criteria;

    protected void Page_Load(object sender, EventArgs e)
    {
         
        try
        {
            
            int class_Id=0;
            int section_Id=0;

            string[] reps = new string[2];
            if (Session["param"] != null)
            {
                int[] array = (int[])Session["param"];
                class_Id = array[3];
                section_Id = array[0];
            }
            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx",false);
            }


            //rptviewer.AllowedExportFormats = (int)(ViewerExportFormats.PdfFormat);

            if (Session["reps"]!=null)
            {

                reps = (string [])Session["reps"];
                reppath = reps[0];
                criteria = reps[1];
            }
            else
            {
                Session["error"] = "Can't load Report";
                Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
            }



            if (class_Id<7)
            {
                LoadReportSP(criteria, reppath);
            }
            else
            {
                //LoadReport(criteria, reppath);
                LoadReportSP(criteria, reppath);
            }
              
              BLLCrystalReports objCr = new BLLCrystalReports();


              objCr.SectionId = section_Id;

                objCr.critera = criteria;
                if (Session["StartTime"]!=null)
                {
                    objCr.StartTime = (DateTime)Session["StartTime"];
                    
                }
                else
                {
                    objCr.StartTime = DateTime.Now;

                }
                objCr.EndTime = DateTime.Now;
              
              objCr.CR_LogAdd(objCr);


        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {
        //try
        //{
        //    if (!IsPostBack)
        //    report.Database.Dispose();
        //    report.Close();
        //    report.Dispose();
        //    GC.Collect();
        //    GC.WaitForPendingFinalizers();
        //    GC.Collect();
        //}
        //catch (Exception ex)
        //{

        //    Session["error"] = ex.Message;
        //    Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        //}

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            CloseAll();
            Response.Redirect(Session["LastPage"].ToString());
        }
        catch (Exception)
        {
            
            throw;
        }
    }


    public void CloseAll()
    {
        //try
        //{
        //    report.Close();
        //    report.Dispose();

        //}
        //catch (Exception)
        //{
            
        //    throw;
        //}
    }


    public void BindReport()
    {
        //DataTable dt;
        //string sConstr = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;

        //SqlConnection conn = new SqlConnection(sConstr);
        //SqlCommand comm = new SqlCommand();
        //comm.Connection = conn;
        //comm.CommandText = "TSSStdAttnDailyRptAttnTypeWise";
        //comm.CommandType = CommandType.StoredProcedure;

        //SqlParameter Center_Id = new SqlParameter("@Center_Id", SqlDbType.Int);
        //SqlParameter date = new SqlParameter("@date", SqlDbType.DateTime);
        //SqlParameter Class_Section_id = new SqlParameter("@Class_Section_id", SqlDbType.Int);
        //SqlParameter parm = new SqlParameter("@parm", SqlDbType.Int);

        //Center_Id.Value = Int32.Parse(Session["Center_Id"].ToString());
        //date.Value = Convert.ToDateTime(Session["date"].ToString());
        //Class_Section_id.Value = Int32.Parse(Session["Class_Section_id"].ToString());
        //parm.Value = Int32.Parse(Session["parm"].ToString());

        //comm.Parameters.Add(Center_Id);
        //comm.Parameters.Add(date);
        //comm.Parameters.Add(Class_Section_id);
        //comm.Parameters.Add(parm);

        //conn.Open();
        //using (SqlDataAdapter da = new SqlDataAdapter(comm))
        //{
        //    dt = new DataTable("tbl");
        //    da.Fill(dt);
        //}

        ////ReportDocument objdocument = new ReportDocument();
        //string reportPath = Session["reppath"].ToString();

        //report.Load(reportPath);
        //report.SetDataSource(dt);
        //rptviewer.ReportSource = report;
        //report.SummaryInfo.ReportTitle = Session["RptTitle"].ToString();
        //report.SummaryInfo.ReportComments = Session["CenterName"].ToString();
    }

    //public void LoadReport(string criteria, string reportPath)
    //{
    //    try
    //    {
    //        string strConnect = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"]);
    //        SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(strConnect);

    //        string _username = builder.UserID;
    //        string _pass = builder.Password;
    //        string _server = builder.DataSource;
    //        string _database = builder.InitialCatalog;


    //        report.Load(reportPath);

    //        report.SetDatabaseLogon(_username, _pass, _server, _database);
    //        report.Refresh();

    //        report.RecordSelectionFormula = criteria;
    //        //report.SummaryInfo.ReportTitle = Session["RptTitle"].ToString();
    //        //if (Session["rptCmnt"] != null)
    //        //{
    //        //    report.SummaryInfo.ReportComments = Session["rptCmnt"].ToString();
    //        //}
    //    }
    //    catch (Exception ex)
    //    {
    //        Session["error"] = ex.Message;
    //        Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
    //    }
    //}

    public void LoadReportSP(string criteria, string reportpath)
    {
        string downloadAsFilename = "";
        BinaryReader stream;
        try
        {
            string strConnect = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"]);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(strConnect);

            string _username = builder.UserID;
            string _pass = builder.Password;
            string _server = builder.DataSource;
            string _database = builder.InitialCatalog;
            ReportDocument report = new ReportDocument();
            report.Load(reportpath);

            report.SetDatabaseLogon(_username, _pass, _server, _database);

            if (Session["param"]!=null)
            {

                int[] array = (int[])Session["param"];
                
                report.SetParameterValue("@Section_Id", array[0]);
                report.SetParameterValue("@Session_Id", array[1]);
                report.SetParameterValue("@TermGroup_Id", array[2]);
       
            }

            //if (Session["Sec_Id"] != null)
            //{
            //    report.SetParameterValue("@Section_Id", Convert.ToInt32(Session["Sec_Id"].ToString()));
            //}
            //if (Session["Se_Id"] != null)
            //{
            //    report.SetParameterValue("@Session_Id", Convert.ToInt32(Session["Se_Id"].ToString()));
            //}
            //if (Session["TermGroup_Id"] != null)
            //{
            //    report.SetParameterValue("@TermGroup_Id", Convert.ToInt32(Session["TermGroup_Id"].ToString()));
            //}
                report.RecordSelectionFormula = criteria;
                downloadAsFilename = "ResultCard";
                stream = new BinaryReader(report.ExportToStream(ExportFormatType.PortableDocFormat));
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "application/pdf";
                //below line if uncomment then user  save/open dialogue show
                //Response.AddHeader("content-disposition", "attachment; filename=" + downloadAsFilename+ ".pdf");
                Response.AddHeader("content-length", stream.BaseStream.Length.ToString());
                Response.BinaryWrite(stream.ReadBytes(Convert.ToInt32(stream.BaseStream.Length)));
                Response.Flush();
                Response.Close();

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/ErrorPage.aspx", false);
        }

    }
}