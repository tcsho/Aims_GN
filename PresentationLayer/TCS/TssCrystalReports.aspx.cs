using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;



public partial class PresentationLayer_TCS_TssCrystalReports : System.Web.UI.Page
{
    BLLCrystalReports bllcry = new BLLCrystalReports();
    public ReportDocument report = new ReportDocument();
    bool _isSys = false;
    bool t = false;
    int n = 0;
    int ter, sec, stu;
    string reppath, criteria;

    protected void Page_Init(object sender, EventArgs e)
    {
        try
        {

            rptviewer.AllowedExportFormats = (int)(ViewerExportFormats.CsvFormat | ViewerExportFormats.ExcelRecordFormat | ViewerExportFormats.ExcelFormat | ViewerExportFormats.PdfFormat);

            if (Session["ContactID"] == null)
            {
                Response.Redirect("~/login.aspx", false);
            }
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
        if (Session["parm"] != null)
        {
            if (Session["parm"].ToString() == "5" || Session["parm"].ToString() == "2")
            {
                BindReport();
            }
        }
        else
        {
            if (Session["CriteriaRpt"] != null)
                criteria = Session["CriteriaRpt"].ToString();
            if (Session["reppath"] != null)
                reppath = Session["reppath"].ToString();
            else
                return;
            LoadReport(criteria, reppath);
            rptviewer.Visible = true;

            rptviewer.ReportSource = report;
        }
    }

    protected void Page_Unload(object sender, EventArgs e)
    {

        report.Close();
        report.Dispose();

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        CloseAll();
        if (Session["LastPage"] != null)
            Response.Redirect(Session["LastPage"].ToString());
        else
            Response.Redirect("~/login.aspx", false);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]

    static public void MyMethod()
    {
        //report.Close();
        //report.Dispose();
    }

    public void CloseAll()
    {
        report.Close();
        report.Dispose();
    }

    protected void reportviewer_Navigate(object source, CrystalDecisions.Web.NavigateEventArgs e)
    {

    }

    public void SetNav()
    {
        t = true;
    }

    protected void rptviewer_Navigate(object source, CrystalDecisions.Web.NavigateEventArgs e)
    {
        t = true;
    }

    public void BindReport()
    {
        DataTable dt;
        string sConstr = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;

        SqlConnection conn = new SqlConnection(sConstr);
        SqlCommand comm = new SqlCommand();
        comm.Connection = conn;
        comm.CommandText = "TSSStdAttnDailyRptAttnTypeWise";
        comm.CommandType = CommandType.StoredProcedure;

        SqlParameter Center_Id = new SqlParameter("@Center_Id", SqlDbType.Int);
        SqlParameter date = new SqlParameter("@date", SqlDbType.DateTime);
        SqlParameter Class_Section_id = new SqlParameter("@Class_Section_id", SqlDbType.Int);
        SqlParameter parm = new SqlParameter("@parm", SqlDbType.Int);

        Center_Id.Value = Int32.Parse(Session["Center_Id"].ToString());
        date.Value = Convert.ToDateTime(Session["date"].ToString());
        Class_Section_id.Value = Int32.Parse(Session["Class_Section_id"].ToString());
        parm.Value = Int32.Parse(Session["parm"].ToString());

        comm.Parameters.Add(Center_Id);
        comm.Parameters.Add(date);
        comm.Parameters.Add(Class_Section_id);
        comm.Parameters.Add(parm);

        conn.Open();
        using (SqlDataAdapter da = new SqlDataAdapter(comm))
        {
            dt = new DataTable("tbl");
            da.Fill(dt);
        }

        //ReportDocument objdocument = new ReportDocument();
        string reportPath = Session["reppath"].ToString();

        report.Load(reportPath);
        report.SetDataSource(dt);
        rptviewer.ReportSource = report;
        report.SummaryInfo.ReportTitle = Session["RptTitle"].ToString();
        report.SummaryInfo.ReportComments = Session["CenterName"].ToString();
    }

     public void LoadReport(string criteria, string reportPath)
    {
        try
        {
            string strConnect = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"]);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(strConnect);

            string _username = builder.UserID;
            string _pass = builder.Password;
            string _server = builder.DataSource;
            string _database = builder.InitialCatalog;

            
                report.Load(reportPath);

                setDbInfo(report, _server, _database, _username, _pass);

                report.Refresh();

                report.RecordSelectionFormula = criteria;
                report.SummaryInfo.ReportTitle = Session["RptTitle"].ToString();
                rptviewer.ID = Session["RptTitle"].ToString();
                if (Session["rptCmnt"] != null)
                {
                    report.SummaryInfo.ReportComments = Session["rptCmnt"].ToString();
                }
           
        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/PresentationLayer/ErrorPage.aspx", false);
        }
    }


    protected void setDbInfo(ReportDocument rptDoc, string Server, string dbName, string UserId, string Pwd)
    {
        TableLogOnInfo logoninfo = new TableLogOnInfo();
        // connect multiple tabel    
        foreach (CrystalDecisions.CrystalReports.Engine.Table tbl in rptDoc.Database.Tables)
        {
            logoninfo = tbl.LogOnInfo;
            logoninfo.ReportName = rptDoc.Name;
            logoninfo.ConnectionInfo.ServerName = Server;
            logoninfo.ConnectionInfo.DatabaseName = dbName;
            logoninfo.ConnectionInfo.UserID = UserId;
            logoninfo.ConnectionInfo.Password = Pwd;
            logoninfo.TableName = tbl.Name;
            tbl.ApplyLogOnInfo(logoninfo);
            tbl.Location = tbl.Name;
        }
    }

     public void LoadReportSP(string criteria, string reportpath)
    {

        try
        {
            string reportp ="";
            string strConnect = Convert.ToString(System.Configuration.ConfigurationManager.ConnectionStrings["tcs_invConnectionString"]);
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(strConnect);

            string _username = builder.UserID;
            string _pass = builder.Password;
            string _server = builder.DataSource;
            string _database = builder.InitialCatalog;

           
                reportp = Server.MapPath("Reports\\ResultCard_ClassFirstTermB.rpt");
                report.Load(reportp);

                report.SetDatabaseLogon(_username, _pass, _server, _database);

                report.Refresh();

                report.SetParameterValue("@Section_Id", 49);
                report.SetParameterValue("@Session_Id", 7);
                report.SetParameterValue("@TermGroup_Id", 1);
            

        }
        catch (Exception ex)
        {
            Session["error"] = ex.Message;
            Response.Redirect("~/ErrorPage.aspx", false);
        }

    }
}
