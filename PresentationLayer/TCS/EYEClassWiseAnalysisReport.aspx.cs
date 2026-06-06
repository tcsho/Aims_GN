using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;

public partial class PresentationLayer_TCS_EYEClassWiseAnalysisReport : Page
{
    private sealed class ReportHeader
    {
        public string TitleLine;
        public string Region;
        public string Center;
        public string Term;
        public string Session;
    }

    private bool IsExportRequest
    {
        get { return !string.IsNullOrEmpty(Request.QueryString["export"]); }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        if (IsExportRequest)
            return;
        base.Render(writer);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ContactID"] == null)
        {
            Response.Redirect("~/Login.aspx", false);
            return;
        }

        Title = "EYE Classwise Analysis";

        string export = Request.QueryString["export"];
        if (!string.IsNullOrEmpty(export))
        {
            try
            {
                DataTable display = LoadReportDisplayTable();
                if (display == null || display.Rows.Count == 0)
                {
                    WritePlainExportMessage("No data to export for the current filters.");
                    return;
                }

                ReportHeader hdr = GetReportHeaderForScreen();
                if (export.Equals("pdf", StringComparison.OrdinalIgnoreCase))
                    ExportPdf(display, hdr);
                else if (export.Equals("excel", StringComparison.OrdinalIgnoreCase))
                    ExportExcelHtml(display, GetReportHeaderPlain());
                else
                    WritePlainExportMessage("Unknown export format.");
            }
            catch (Exception ex)
            {
                WritePlainExportMessage("Export failed: " + ex.Message);
            }
            return;
        }

        WireExportLinks();
        // Same asset as MasterPage.master (City School header logo)
        imgLogo.ImageUrl = ResolveUrl("~/images/lgo1.png");
        imgLogo.Visible = true;

        if (!IsPostBack)
        {
            BindTitlesFromQuery();

            string pid = Request.QueryString["pid"];
            if (!string.IsNullOrEmpty(pid))
            {
                lnkBack.NavigateUrl = ResolveUrl("~/PresentationLayer/TCS/TCSReports.aspx?id=" + HttpUtility.UrlEncode(pid));
                lnkBack.Visible = true;
            }

            try
            {
                DataTable display = LoadReportDisplayTable();
                if (display.Rows.Count == 0)
                {
                    litError.Text = "<p class='err'>No rows returned for the selected filters. Check that LmsAppReports.Rpt_View matches a database object and that filter values are correct.</p>";
                    pnlTable.Visible = false;
                    return;
                }

                rptRows.DataSource = display;
                rptRows.DataBind();
                pnlTable.Visible = true;
            }
            catch (Exception ex)
            {
                litError.Text = "<p class='err'>" + HttpUtility.HtmlEncode(ex.Message) + "</p>";
                pnlTable.Visible = false;
            }
        }
    }

    private void WireExportLinks()
    {
        if (string.IsNullOrWhiteSpace(Request.QueryString["rv"]))
        {
            lnkPdf.Visible = false;
            lnkExcel.Visible = false;
            return;
        }

        string q = BuildQueryWithoutExport();
        string path = ResolveUrl("~/PresentationLayer/TCS/EYEClassWiseAnalysisReport.aspx");
        lnkPdf.NavigateUrl = string.IsNullOrEmpty(q) ? path + "?export=pdf" : path + "?" + q + "&export=pdf";
        lnkExcel.NavigateUrl = string.IsNullOrEmpty(q) ? path + "?export=excel" : path + "?" + q + "&export=excel";
        lnkPdf.Visible = true;
        lnkExcel.Visible = true;
    }

    private static string BuildQueryWithoutExport()
    {
        var parts = new StringBuilder();
        foreach (string key in HttpContext.Current.Request.QueryString.AllKeys)
        {
            if (string.IsNullOrEmpty(key) || key.Equals("export", StringComparison.OrdinalIgnoreCase))
                continue;
            string[] values = HttpContext.Current.Request.QueryString.GetValues(key);
            if (values == null)
                continue;
            foreach (string val in values)
            {
                if (parts.Length > 0)
                    parts.Append("&");
                parts.Append(HttpUtility.UrlEncode(key));
                parts.Append("=");
                parts.Append(HttpUtility.UrlEncode(val ?? string.Empty));
            }
        }
        return parts.ToString();
    }

    private DataTable LoadReportDisplayTable()
    {
        var model = BuildModelFromQuery();
        ApplyEYERightsRowDefaults(model);
        ApplyDefaultClassIdsWhenUnset(model);
        ValidateEYEQueryScopeOrThrow(model);
        var dal = new DALEYEClassWiseAnalysis();
        DataTable raw = dal.GetReportData(model);
        return EYEClassWiseAnalysisAggregator.BuildClassSummary(raw);
    }

    /// <summary>
    /// Fills optional organisation context from the signed-in user when the query string omitted it.
    /// Region must still be chosen on the Reports screen (validated separately).
    /// </summary>
    private void ApplyEYERightsRowDefaults(BLLEYEClassWiseAnalysis model)
    {
        var row = Session["rightsRow"] as DataRow;
        if (row == null || row.Table == null)
            return;

        try
        {
            if (!model.MainOrganisationId.HasValue && row.Table.Columns.Contains("Main_Organisation_Id") && row["Main_Organisation_Id"] != DBNull.Value)
            {
                int m = Convert.ToInt32(row["Main_Organisation_Id"], CultureInfo.InvariantCulture);
                if (m > 0)
                    model.MainOrganisationId = m;
            }
        }
        catch
        {
            // ignore invalid profile values
        }
    }

    private static bool HasPositiveIntCsv(string csv)
    {
        if (string.IsNullOrWhiteSpace(csv))
            return false;
        foreach (string part in csv.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
        {
            int v;
            if (int.TryParse(part.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out v) && v > 0)
                return true;
        }
        return false;
    }

    private static bool HasRegionFilter(BLLEYEClassWiseAnalysis p)
    {
        if (p.RegionId.HasValue && p.RegionId.Value > 0)
            return true;
        return HasPositiveIntCsv(p.RegionIdsCsv);
    }

    private static bool HasClassFilter(BLLEYEClassWiseAnalysis p)
    {
        if (p.ClassId.HasValue && p.ClassId.Value > 0)
            return true;
        return HasPositiveIntCsv(p.ClassIdsCsv);
    }

    /// <summary>
    /// When the Reports screen did not select a class, limit to EYE classes 2–6 (same as Crystal default scope).
    /// </summary>
    private static void ApplyDefaultClassIdsWhenUnset(BLLEYEClassWiseAnalysis model)
    {
        if (HasClassFilter(model))
            return;
        model.ClassIdsCsv = "2,3,4,5,6";
        model.ClassId = null;
    }

    private static void ValidateEYEQueryScopeOrThrow(BLLEYEClassWiseAnalysis model)
    {
        if (HasRegionFilter(model))
            return;

        throw new InvalidOperationException(
            "Region is required for this report. On the Reports screen, select a Region (or multiple regions), then run the report again. "
            + "All other filters are optional.");
    }

    private ReportHeader GetReportHeaderPlain()
    {
        var h = new ReportHeader();
        string rreg = Request.QueryString["rreg"];
        if (string.IsNullOrWhiteSpace(rreg))
            h.TitleLine = "The City School (TCS)-Regional";
        else
        {
            string t = rreg.Trim();
            if (t.StartsWith("(TCS)", StringComparison.OrdinalIgnoreCase))
                h.TitleLine = "The City School " + t;
            else
                h.TitleLine = "The City School (TCS)-" + t;
        }

        h.Region = string.IsNullOrWhiteSpace(rreg) ? string.Empty : rreg.Trim();
        h.Center = Request.QueryString["cname"] ?? string.Empty;
        h.Term = Request.QueryString["term"] ?? string.Empty;
        h.Session = Request.QueryString["sessdesc"] ?? string.Empty;
        return h;
    }

    /// <summary>Header values as shown on the report page (empty fields display as —).</summary>
    private ReportHeader GetReportHeaderForScreen()
    {
        ReportHeader h = GetReportHeaderPlain();
        h.Center = DisplayOrDash(h.Center);
        h.Term = DisplayOrDash(h.Term);
        h.Session = DisplayOrDash(h.Session);
        return h;
    }

    private static string DisplayOrDash(string value)
    {
        return string.IsNullOrWhiteSpace(value) ? "—" : value.Trim();
    }

    private static void WritePlainExportMessage(string message)
    {
        HttpResponse response = HttpContext.Current.Response;
        response.Clear();
        response.ClearContent();
        response.ClearHeaders();
        response.ContentType = "text/plain; charset=utf-8";
        response.Write(message ?? string.Empty);
        response.Flush();
        response.SuppressContent = true;
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    private void ExportPdf(DataTable dt, ReportHeader hdr)
    {
        PrepareBinaryDownloadResponse();

        using (var ms = new MemoryStream())
        {
            var doc = new Document(PageSize.A4, 40f, 40f, 40f, 40f);
            PdfWriter.GetInstance(doc, ms);
            doc.Open();

            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13f);
            Font subFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11f);
            Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 9f);
            Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9f);

            doc.Add(new Paragraph(hdr.TitleLine ?? string.Empty, titleFont));
            doc.Add(new Paragraph("EYE Classwise Analysis", subFont));
            doc.Add(new Paragraph(" ", normalFont));
            doc.Add(new Paragraph(
                "Center: " + (hdr.Center ?? string.Empty) + "     Term: " + (hdr.Term ?? string.Empty) + "     Session: " + (hdr.Session ?? string.Empty),
                normalFont));
            doc.Add(new Paragraph(" ", normalFont));

            var table = new PdfPTable(7)
            {
                WidthPercentage = 100f
            };
            table.SetWidths(new float[] { 2.0f, 1.0f, 1.0f, 1.25f, 1.25f, 1.25f, 1.25f });

            AddPdfHeaderCell(table, "Class name", boldFont);
            AddPdfHeaderCell(table, "Students", boldFont);
            AddPdfHeaderCell(table, "Total LOs", boldFont);
            AddPdfHeaderCell(table, "EXC", boldFont);
            AddPdfHeaderCell(table, "EXP", boldFont);
            AddPdfHeaderCell(table, "EME", boldFont);
            AddPdfHeaderCell(table, "N.I", boldFont);

            foreach (DataRow row in dt.Rows)
            {
                bool isTotal = row.Table.Columns.Contains("IsTotal") && row["IsTotal"] != DBNull.Value && (bool)row["IsTotal"];
                Font cellFont = isTotal ? boldFont : normalFont;

                AddPdfBodyCell(table, CellText(row, "DisplayClass"), cellFont, Element.ALIGN_LEFT);
                AddPdfBodyCell(table, CellText(row, "DisplayTotalStudents"), cellFont, Element.ALIGN_CENTER);
                AddPdfBodyCell(table, CellText(row, "DisplayTotalLos"), cellFont, Element.ALIGN_CENTER);
                AddPdfBodyCell(table, CellText(row, "DisplayExc"), cellFont, Element.ALIGN_CENTER);
                AddPdfBodyCell(table, CellText(row, "DisplayExp"), cellFont, Element.ALIGN_CENTER);
                AddPdfBodyCell(table, CellText(row, "DisplayEme"), cellFont, Element.ALIGN_CENTER);
                AddPdfBodyCell(table, CellText(row, "DisplayNi"), cellFont, Element.ALIGN_CENTER);
            }

            doc.Add(table);
            doc.Close();

            string fileName = "EYEClassWiseAnalysis_" + DateTime.Now.ToString("yyyyMMdd_HHmm", CultureInfo.InvariantCulture) + ".pdf";
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");
            byte[] pdfBytes = ms.ToArray();
            Response.AddHeader("Content-Length", pdfBytes.Length.ToString(CultureInfo.InvariantCulture));
            Response.BinaryWrite(pdfBytes);
        }

        FinishBinaryDownloadResponse();
    }

    private static void AddPdfHeaderCell(PdfPTable table, string text, Font font)
    {
        var cell = new PdfPCell(new Phrase(text ?? string.Empty, font))
        {
            BackgroundColor = new BaseColor(220, 220, 220),
            HorizontalAlignment = Element.ALIGN_CENTER,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            Padding = 4f
        };
        table.AddCell(cell);
    }

    private static void AddPdfBodyCell(PdfPTable table, string text, Font font, int horizontalAlign)
    {
        var cell = new PdfPCell(new Phrase(text ?? string.Empty, font))
        {
            HorizontalAlignment = horizontalAlign,
            VerticalAlignment = Element.ALIGN_MIDDLE,
            Padding = 3f
        };
        table.AddCell(cell);
    }

    private static string CellText(DataRow row, string column)
    {
        if (row == null || row.Table == null || !row.Table.Columns.Contains(column))
            return string.Empty;
        object v = row[column];
        return v == DBNull.Value ? string.Empty : Convert.ToString(v, CultureInfo.InvariantCulture);
    }

    private void ExportExcelHtml(DataTable dt, ReportHeader hdr)
    {
        string region = FormatRegionForExport(hdr != null ? hdr.Region : string.Empty);
        string center = hdr != null ? (hdr.Center ?? string.Empty).Trim() : string.Empty;
        string session = hdr != null ? (hdr.Session ?? string.Empty).Trim() : string.Empty;

        PrepareBinaryDownloadResponse();
        string fileName = "EYEClassWiseAnalysis_" + DateTime.Now.ToString("yyyyMMdd_HHmm", CultureInfo.InvariantCulture) + ".xls";
        Response.ContentType = "application/vnd.ms-excel";
        Response.ContentEncoding = Encoding.UTF8;
        Response.Charset = "utf-8";
        Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");

        var sb = new StringBuilder(16384);
        sb.Append("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");
        sb.Append("<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /></head>");
        sb.Append("<body><table border=\"1\" cellspacing=\"0\" cellpadding=\"4\">");

        sb.Append("<tr style=\"font-weight:bold;background-color:#f0f0f0;\">");
        sb.Append("<th>Region</th><th>Center</th><th>Session</th>");
        sb.Append("<th>Class name</th><th>Total students</th><th>LOs per student</th>");
        sb.Append("<th>EXC</th><th>EXP</th><th>EME</th><th>N.I</th>");
        sb.Append("</tr>");

        foreach (DataRow row in dt.Rows)
        {
            bool isTotal = row.Table.Columns.Contains("IsTotal") && row["IsTotal"] != DBNull.Value && (bool)row["IsTotal"];
            string rowStyle = isTotal ? "font-weight:bold;" : string.Empty;

            sb.Append("<tr style=\"").Append(rowStyle).Append("\">");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(region)).Append("</td>");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(center)).Append("</td>");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(session)).Append("</td>");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayClass"))).Append("</td>");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayTotalStudents"))).Append("</td>");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayTotalLos"))).Append("</td>");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayExc"))).Append("</td>");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayExp"))).Append("</td>");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayEme"))).Append("</td>");
            sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayNi"))).Append("</td>");
            sb.Append("</tr>");
        }

        sb.Append("</table></body></html>");
        Response.Write(sb.ToString());
        FinishBinaryDownloadResponse();
    }

    private static string FormatRegionForExport(string rreg)
    {
        if (string.IsNullOrWhiteSpace(rreg))
            return string.Empty;
        string t = rreg.Trim();
        if (t.StartsWith("(TCS)", StringComparison.OrdinalIgnoreCase))
            return t;
        return "(TCS)-" + t;
    }

    private void PrepareBinaryDownloadResponse()
    {
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Buffer = true;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetNoStore();
    }

    private void FinishBinaryDownloadResponse()
    {
        Response.Flush();
        Response.SuppressContent = true;
        HttpContext.Current.ApplicationInstance.CompleteRequest();
    }

    private void BindTitlesFromQuery()
    {
        ReportHeader h = GetReportHeaderForScreen();
        litTitleMain.Text = HttpUtility.HtmlEncode(h.TitleLine ?? string.Empty);
        litCenter.Text = HttpUtility.HtmlEncode(h.Center);
        litTerm.Text = HttpUtility.HtmlEncode(h.Term);
        litSession.Text = HttpUtility.HtmlEncode(h.Session);
    }

    private BLLEYEClassWiseAnalysis BuildModelFromQuery()
    {
        string rv = Request.QueryString["rv"];
        if (string.IsNullOrWhiteSpace(rv))
            throw new ArgumentException("Missing report view key (rv). Open this report from Reports, or pass the same Rpt_View value the Crystal report uses.");

        int rptId = 0;
        int.TryParse(Request.QueryString["rptid"], NumberStyles.Integer, CultureInfo.InvariantCulture, out rptId);

        return new BLLEYEClassWiseAnalysis
        {
            RptViewName = rv.Trim(),
            RptId = rptId,
            SessionIdsCsv = Request.QueryString["sessions"],
            SingleSessionId = TryParseInt(Request.QueryString["session"]),
            DdlSessionId = TryParseInt(Request.QueryString["ddlsession"]),
            MainOrganisationId = TryParseInt(Request.QueryString["moid"]),
            RegionIdsCsv = Request.QueryString["regions"],
            RegionId = TryParseInt(Request.QueryString["rid"]),
            CenterIdsCsv = Request.QueryString["centers"],
            CenterId = TryParseInt(Request.QueryString["cid"]),
            ClassIdsCsv = Request.QueryString["classes"],
            ClassId = TryParseInt(Request.QueryString["clid"]),
            ResultSeriesId = TryParseInt(Request.QueryString["rs"]),
            GradeLevel = Request.QueryString["glvl"],
            TermGroupId = TryParseInt(Request.QueryString["tg"]),
            TermId = TryParseInt(Request.QueryString["tid"]),
            TermIdsCsv = Request.QueryString["termids"],
            ResultGradeId = TryParseInt(Request.QueryString["rgid"]),
            ResultGradeIdsCsv = Request.QueryString["rgids"],
            SectionId = TryParseInt(Request.QueryString["secid"]),
            StudentId = TryParseInt(Request.QueryString["stid"]),
            ClassTeacherEmployeeId = TryParseInt(Request.QueryString["cemp"]),
            UserTeacherRestrictionId = TryParseInt(Request.QueryString["utid"]),
            GenderId = TryParseInt(Request.QueryString["gen"]),
            SubjectId = TryParseInt(Request.QueryString["subid"]),
            SubjectIdsCsv = Request.QueryString["subids"]
        };
    }

    private static int? TryParseInt(string s)
    {
        int v;
        if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out v))
            return v;
        return null;
    }

    protected void rptRows_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)
            return;

        var drv = (DataRowView)e.Item.DataItem;
        bool isTotal = drv["IsTotal"] != DBNull.Value && (bool)drv["IsTotal"];
        var tr = (HtmlTableRow)e.Item.FindControl("trRow");
        if (tr != null && isTotal)
            tr.Attributes["class"] = "total";
    }
}
