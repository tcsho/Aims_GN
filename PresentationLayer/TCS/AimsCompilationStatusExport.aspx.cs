using System;
using System.Data;
using System.Globalization;
using System.Text;
using System.Web;
using System.Web.UI;

public partial class PresentationLayer_TCS_AimsCompilationStatusExport : Page
{
    private const string SpSuccessful = "Successful_Compilation_Aims";
    private const string SpUnsuccessful = "Un_Successful_Compilation_Aims";

    private static readonly string[] AllowedProcedures = { SpSuccessful, SpUnsuccessful };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ContactID"] == null)
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }

        if (!IsPostBack)
            Title = "Compilation Status (AIMS)";
    }

    protected void btnSuccessful_Click(object sender, EventArgs e)
    {
        ExportProcedureToExcel(SpSuccessful, "Successful_Compilation_Aims");
    }

    protected void btnUnsuccessful_Click(object sender, EventArgs e)
    {
        ExportProcedureToExcel(SpUnsuccessful, "Un_Successful_Compilation_Aims");
    }

    private void ExportProcedureToExcel(string procedureName, string fileNameBase)
    {
        lblMessage.Text = string.Empty;

        if (Array.IndexOf(AllowedProcedures, procedureName) < 0)
        {
            lblMessage.Text = "Invalid export.";
            return;
        }

        try
        {
            var dal = new DALBase();
            DataTable dt = dal.sqlcmdFetch(procedureName);
            if (dt == null || dt.Rows.Count == 0)
            {
                lblMessage.Text = "No rows returned from " + procedureName + ".";
                return;
            }

            string safe = SanitizeFileName(fileNameBase);
            WriteHtmlExcel(dt, safe + "_" + DateTime.Now.ToString("yyyyMMdd_HHmm", CultureInfo.InvariantCulture) + ".xls");
        }
        catch (Exception ex)
        {
            lblMessage.Text = HttpUtility.HtmlEncode(ex.Message);
        }
    }

    private static string SanitizeFileName(string name)
    {
        if (string.IsNullOrEmpty(name))
            return "export";
        var sb = new StringBuilder(name.Length);
        foreach (char c in name)
        {
            if (char.IsLetterOrDigit(c) || c == '_' || c == '-')
                sb.Append(c);
            else
                sb.Append('_');
        }
        return sb.Length > 0 ? sb.ToString() : "export";
    }

    private void WriteHtmlExcel(DataTable dt, string fileName)
    {
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.ContentEncoding = Encoding.UTF8;
        Response.Charset = "utf-8";
        Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");

        var sb = new StringBuilder(16384);
        sb.Append("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\"><head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /></head><body><table border='1' cellspacing='0' cellpadding='4'>");

        sb.Append("<tr style='font-weight:bold;background-color:#f0f0f0;'>");
        foreach (DataColumn col in dt.Columns)
        {
            sb.Append("<th>").Append(HttpUtility.HtmlEncode(col.ColumnName)).Append("</th>");
        }
        sb.Append("</tr>");

        foreach (DataRow row in dt.Rows)
        {
            sb.Append("<tr>");
            foreach (DataColumn col in dt.Columns)
            {
                object v = row[col];
                string text = v == null || v == DBNull.Value ? string.Empty : Convert.ToString(v, CultureInfo.InvariantCulture);
                sb.Append("<td>").Append(HttpUtility.HtmlEncode(text)).Append("</td>");
            }
            sb.Append("</tr>");
        }

        sb.Append("</table></body></html>");
        Response.Write(sb.ToString());
        Response.Flush();
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }
}
