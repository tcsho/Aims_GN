using System;

using System.Collections.Generic;

using System.Data;

using System.Globalization;

using System.IO;

using System.Linq;

using System.Text;

using System.Web;

using System.Web.UI;

using System.Web.UI.HtmlControls;

using System.Web.UI.WebControls;

using iTextSharp.text;

using iTextSharp.text.pdf;



public partial class PresentationLayer_TCS_ClassLevelWiseSubjectAnalysisReport : Page

{

    private sealed class ReportHeader

    {

        public string TitleLine;

        public string Region;

        public string Center;

        public string Term;

        public string Session;

    }



    private sealed class ClassSection
    {
        public string Region { get; set; }
        public string Session { get; set; }
        public string Center { get; set; }
        public string ClassName { get; set; }
        public string Term { get; set; }
        public DataTable Subjects { get; set; }
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



        Title = GetReportSubtitle();



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

                List<ClassSection> sections = BuildClassSections(display, hdr);

                if (sections.Count == 0)

                {

                    WritePlainExportMessage("No data to export for the current filters.");

                    return;

                }



                if (export.Equals("pdf", StringComparison.OrdinalIgnoreCase))

                    ExportPdf(sections, hdr);

                else if (export.Equals("excel", StringComparison.OrdinalIgnoreCase))

                    ExportExcelHtml(sections, hdr);

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

                    pnlSections.Visible = false;

                    return;

                }



                ReportHeader hdr = GetReportHeaderForScreen();

                List<ClassSection> sections = BuildClassSections(display, hdr);

                if (sections.Count == 0)

                {

                    litError.Text = "<p class='err'>No rows returned for the selected filters.</p>";

                    pnlSections.Visible = false;

                    return;

                }



                rptClasses.DataSource = sections;

                rptClasses.DataBind();

                pnlSections.Visible = true;

            }

            catch (Exception ex)

            {

                litError.Text = "<p class='err'>" + HttpUtility.HtmlEncode(ex.Message) + "</p>";

                pnlSections.Visible = false;

            }

        }

    }



    private static List<ClassSection> BuildClassSections(DataTable display, ReportHeader hdr)

    {

        var sections = new List<ClassSection>();

        if (display == null || display.Rows.Count == 0)

            return sections;



        string termDisplay = DisplayOrDash(hdr != null ? hdr.Term : null);
        string centerDisplay = DisplayOrDash(hdr != null ? hdr.Center : null);
        string regionDisplay = ResolveRegionDisplay(hdr);
        string sessionDisplay = DisplayOrDash(hdr != null ? hdr.Session : null);

        var classOrder = new List<string>();

        var rowsByClass = new Dictionary<string, List<DataRow>>(StringComparer.OrdinalIgnoreCase);



        foreach (DataRow row in display.Rows)

        {

            string className = CellText(row, "DisplayClass");

            if (string.IsNullOrWhiteSpace(className))

                continue;



            if (!rowsByClass.ContainsKey(className))

            {

                rowsByClass[className] = new List<DataRow>();

                classOrder.Add(className);

            }

            rowsByClass[className].Add(row);

        }



        foreach (string className in classOrder)

        {

            var subjectTable = display.Clone();

            foreach (DataRow row in rowsByClass[className])

                subjectTable.ImportRow(row);



            sections.Add(new ClassSection
            {
                Region = regionDisplay,
                Session = sessionDisplay,
                Center = centerDisplay,
                ClassName = className,
                Term = termDisplay,
                Subjects = subjectTable
            });

        }



        return sections;

    }



    protected void rptClasses_ItemDataBound(object sender, RepeaterItemEventArgs e)

    {

        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)

            return;



        var section = (ClassSection)e.Item.DataItem;

        var rptSubjects = (Repeater)e.Item.FindControl("rptSubjects");

        if (rptSubjects == null || section == null || section.Subjects == null)

            return;



        rptSubjects.DataSource = section.Subjects;

        rptSubjects.DataBind();

    }



    protected void rptSubjects_ItemDataBound(object sender, RepeaterItemEventArgs e)

    {

        if (e.Item.ItemType != ListItemType.Item && e.Item.ItemType != ListItemType.AlternatingItem)

            return;



        var drv = (DataRowView)e.Item.DataItem;

        bool isTotal = drv["IsTotal"] != DBNull.Value && (bool)drv["IsTotal"];

        var tr = (HtmlControl)e.Item.FindControl("trRow");

        if (tr != null && isTotal)

            tr.Attributes["class"] = "total";

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

        string path = ResolveUrl("~/PresentationLayer/TCS/ClassLevelWiseSubjectAnalysisReport.aspx");

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

        ApplyRightsRowDefaults(model);

        ApplyDefaultClassIdsWhenUnset(model);

        ValidateQueryScopeOrThrow(model);

        var dal = new DALClassLevelWiseSubjectAnalysis();

        DataTable raw = dal.GetReportData(model);

        return EYEClassWiseAnalysisAggregator.BuildClassSubjectSummary(raw);

    }



    private void ApplyRightsRowDefaults(BLLClassLevelWiseSubjectAnalysis model)

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



    private static bool HasRegionFilter(BLLClassLevelWiseSubjectAnalysis p)

    {

        if (p.RegionId.HasValue && p.RegionId.Value > 0)

            return true;

        return HasPositiveIntCsv(p.RegionIdsCsv);

    }



    private static bool HasClassFilter(BLLClassLevelWiseSubjectAnalysis p)

    {

        if (p.ClassId.HasValue && p.ClassId.Value > 0)

            return true;

        return HasPositiveIntCsv(p.ClassIdsCsv);

    }



    private static void ApplyDefaultClassIdsWhenUnset(BLLClassLevelWiseSubjectAnalysis model)

    {

        if (HasClassFilter(model))

            return;

        model.ClassIdsCsv = "2,3,4,5,6";

        model.ClassId = null;

    }



    private static void ValidateQueryScopeOrThrow(BLLClassLevelWiseSubjectAnalysis model)

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



    private ReportHeader GetReportHeaderForScreen()

    {

        ReportHeader h = GetReportHeaderPlain();

        h.Center = DisplayOrDash(h.Center);

        h.Term = DisplayOrDash(h.Term);

        h.Session = DisplayOrDash(h.Session);

        h.Region = ResolveRegionDisplay(h);

        return h;

    }

    private static string ResolveRegionDisplay(ReportHeader hdr)
    {
        if (hdr == null)
            return DisplayOrDash(null);
        string formatted = FormatRegionForExport(hdr.Region);
        if (!string.IsNullOrWhiteSpace(formatted))
            return formatted.Trim();
        return DisplayOrDash(hdr.Region);
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



    private void ExportPdf(List<ClassSection> sections, ReportHeader hdr)

    {

        PrepareBinaryDownloadResponse();



        using (var ms = new MemoryStream())

        {

            var doc = new Document(PageSize.A4, 36f, 36f, 36f, 36f);

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);

            doc.Open();



            Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 13f);

            Font subFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11f);

            Font normalFont = FontFactory.GetFont(FontFactory.HELVETICA, 9f);

            Font boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 9f);

            Font metaFont = FontFactory.GetFont(FontFactory.HELVETICA, 10f);



            bool firstPage = true;

            foreach (ClassSection section in sections)

            {

                if (!firstPage)

                    doc.NewPage();

                firstPage = false;



                doc.Add(new Paragraph(hdr.TitleLine ?? string.Empty, titleFont));

                doc.Add(new Paragraph(GetReportSubtitle(), subFont));

                doc.Add(new Paragraph(" ", normalFont));

                doc.Add(new Paragraph(
                    "Center: " + (section.Center ?? string.Empty)
                    + "     Region: " + (section.Region ?? string.Empty)
                    + "     Class: " + (section.ClassName ?? string.Empty)
                    + "     Term: " + (section.Term ?? string.Empty),
                    metaFont));

                doc.Add(new Paragraph("Session: " + (section.Session ?? string.Empty), metaFont));

                doc.Add(new Paragraph(" ", normalFont));



                var table = new PdfPTable(7) { WidthPercentage = 100f };

                table.SetWidths(new float[] { 2.4f, 0.8f, 0.9f, 0.8f, 0.8f, 0.8f, 0.8f });



                AddPdfHeaderCell(table, string.Empty, boldFont);

                AddPdfHeaderCell(table, "students", boldFont);

                AddPdfHeaderCell(table, "Total LOs", boldFont);

                AddPdfHeaderCell(table, "EME", boldFont);

                AddPdfHeaderCell(table, "EXC", boldFont);

                AddPdfHeaderCell(table, "EXP", boldFont);

                AddPdfHeaderCell(table, "N.I", boldFont);



                foreach (DataRow row in section.Subjects.Rows)

                {

                    bool isTotal = row.Table.Columns.Contains("IsTotal") && row["IsTotal"] != DBNull.Value && (bool)row["IsTotal"];

                    Font cellFont = isTotal ? boldFont : normalFont;



                    AddPdfBodyCell(table, CellText(row, "DisplaySubject"), cellFont, Element.ALIGN_LEFT);

                    AddPdfBodyCell(table, CellText(row, "DisplayTotalStudents"), cellFont, Element.ALIGN_CENTER);

                    AddPdfBodyCell(table, CellText(row, "DisplayTotalLos"), cellFont, Element.ALIGN_CENTER);

                    AddPdfBodyCell(table, CellText(row, "DisplayEme"), cellFont, Element.ALIGN_CENTER);

                    AddPdfBodyCell(table, CellText(row, "DisplayExc"), cellFont, Element.ALIGN_CENTER);

                    AddPdfBodyCell(table, CellText(row, "DisplayExp"), cellFont, Element.ALIGN_CENTER);

                    AddPdfBodyCell(table, CellText(row, "DisplayNi"), cellFont, Element.ALIGN_CENTER);

                }



                doc.Add(table);

            }



            doc.Close();



            string fileName = "ClassLevelWiseSubjectAnalysis_" + DateTime.Now.ToString("yyyyMMdd_HHmm", CultureInfo.InvariantCulture) + ".pdf";

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
            BackgroundColor = new BaseColor(240, 240, 240),
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



    private void ExportExcelHtml(List<ClassSection> sections, ReportHeader hdr)

    {

        PrepareBinaryDownloadResponse();

        string fileName = "ClassLevelWiseSubjectAnalysis_" + DateTime.Now.ToString("yyyyMMdd_HHmm", CultureInfo.InvariantCulture) + ".xls";

        Response.ContentType = "application/vnd.ms-excel";

        Response.ContentEncoding = Encoding.UTF8;

        Response.Charset = "utf-8";

        Response.AddHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\"");



        var sb = new StringBuilder(16384);

        sb.Append("<html xmlns:x=\"urn:schemas-microsoft-com:office:excel\">");

        sb.Append("<head><meta http-equiv=\"Content-Type\" content=\"text/html; charset=utf-8\" /></head>");

        sb.Append("<body><table border=\"1\" cellspacing=\"0\" cellpadding=\"4\">");



        sb.Append("<tr style=\"font-weight:bold;background-color:#f0f0f0;\">");

        sb.Append("<th>Region</th><th>Session</th><th>Class</th><th>Term</th><th>Subject</th>");

        sb.Append("<th>students</th>");

        sb.Append("<th>Total LOs</th>");

        sb.Append("<th>EME</th><th>EXC</th><th>EXP</th><th>N.I</th>");

        sb.Append("</tr>");



        foreach (ClassSection section in sections)

        {

            foreach (DataRow row in section.Subjects.Rows)

            {

                bool isTotal = row.Table.Columns.Contains("IsTotal") && row["IsTotal"] != DBNull.Value && (bool)row["IsTotal"];

                string rowStyle = isTotal ? "font-weight:bold;" : string.Empty;



                sb.Append("<tr style=\"").Append(rowStyle).Append("\">");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(section.Region ?? string.Empty)).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(section.Session ?? string.Empty)).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(section.ClassName ?? string.Empty)).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(section.Term ?? string.Empty)).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplaySubject"))).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayTotalStudents"))).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayTotalLos"))).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayEme"))).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayExc"))).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayExp"))).Append("</td>");

                sb.Append("<td>").Append(HttpUtility.HtmlEncode(CellText(row, "DisplayNi"))).Append("</td>");

                sb.Append("</tr>");

            }

        }



        sb.Append("</table></body></html>");

        Response.Write(sb.ToString());

        FinishBinaryDownloadResponse();

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

        litSubtitle.Text = HttpUtility.HtmlEncode(GetReportSubtitle());

    }

    private static string GetReportSubtitle()

    {

        string t = HttpContext.Current.Session["RptTitle"] as string;

        if (!string.IsNullOrWhiteSpace(t))

            return t.Trim();

        return "EYE Class Subjectwise Analysis";

    }



    private BLLClassLevelWiseSubjectAnalysis BuildModelFromQuery()

    {

        string rv = Request.QueryString["rv"];

        if (string.IsNullOrWhiteSpace(rv))

            throw new ArgumentException("Missing report view key (rv). Open this report from Reports, or pass the same Rpt_View value the Crystal report uses.");



        int rptId = 0;

        int.TryParse(Request.QueryString["rptid"], NumberStyles.Integer, CultureInfo.InvariantCulture, out rptId);



        return new BLLClassLevelWiseSubjectAnalysis

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

}

