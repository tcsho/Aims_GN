using System;
using System.Data;
using System.Globalization;
using System.IO;
using System.Text;
using Ionic.Zip;

/// <summary>
/// Builds a minimal OOXML .xlsx grid export for EYE Classwise Analysis (Region, Center, Session, Term per row).
/// </summary>
public static class EYEClassWiseAnalysisXlsxExport
{
    private static readonly string[] GridHeaders =
    {
        "Region", "Center", "Session", "Term",
        "Class name", "Total students", "LOs per student", "EXC", "EXP", "EME", "N.I"
    };

    /// <summary>
    /// Grid layout matching the standard export: filter columns repeated on each data row.
    /// </summary>
    public static byte[] BuildWorkbook(
        DataTable display,
        string region,
        string center,
        string session,
        string term)
    {
        if (display == null)
            throw new ArgumentNullException("display");

        string r = region ?? string.Empty;
        string c = center ?? string.Empty;
        string s = session ?? string.Empty;
        string t = term ?? string.Empty;

        const int colCount = 11;
        int totalRows = 1 + display.Rows.Count;

        var sheet = new StringBuilder(16384);
        sheet.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>");
        sheet.Append("<worksheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\"");
        sheet.Append(" xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">");
        sheet.Append("<dimension ref=\"A1:").Append(GetColumnName(colCount)).Append(totalRows).Append("\"/>");
        sheet.Append("<sheetViews><sheetView workbookViewId=\"0\"/></sheetViews>");
        sheet.Append("<sheetFormatPr defaultRowHeight=\"15\"/>");
        sheet.Append("<cols>");
        sheet.Append("<col min=\"1\" max=\"1\" width=\"28\" customWidth=\"1\"/>");
        sheet.Append("<col min=\"2\" max=\"2\" width=\"42\" customWidth=\"1\"/>");
        sheet.Append("<col min=\"3\" max=\"3\" width=\"18\" customWidth=\"1\"/>");
        sheet.Append("<col min=\"4\" max=\"4\" width=\"14\" customWidth=\"1\"/>");
        sheet.Append("<col min=\"5\" max=\"5\" width=\"22\" customWidth=\"1\"/>");
        for (int i = 6; i <= colCount; i++)
            sheet.Append("<col min=\"").Append(i).Append("\" max=\"").Append(i).Append("\" width=\"14\" customWidth=\"1\"/>");
        sheet.Append("</cols>");
        sheet.Append("<sheetData>");

        int row = 1;
        AppendDataRow(sheet, row++, true, GridHeaders);

        foreach (DataRow dr in display.Rows)
        {
            bool isTotal = dr.Table.Columns.Contains("IsTotal") && dr["IsTotal"] != DBNull.Value && (bool)dr["IsTotal"];
            AppendDataRow(sheet, row++, isTotal,
                r, c, s, t,
                Cell(dr, "DisplayClass"),
                Cell(dr, "DisplayTotalStudents"),
                Cell(dr, "DisplayTotalLos"),
                Cell(dr, "DisplayExc"),
                Cell(dr, "DisplayExp"),
                Cell(dr, "DisplayEme"),
                Cell(dr, "DisplayNi"));
        }

        sheet.Append("</sheetData></worksheet>");

        using (var zip = new ZipFile())
        {
            AddEntry(zip, "[Content_Types].xml", BuildContentTypes());
            AddEntry(zip, "_rels/.rels", BuildRootRels());
            AddEntry(zip, "docProps/core.xml", BuildCoreXml());
            AddEntry(zip, "docProps/app.xml", BuildAppXml());
            AddEntry(zip, "xl/workbook.xml", BuildWorkbookXml());
            AddEntry(zip, "xl/_rels/workbook.xml.rels", BuildWorkbookRels());
            AddEntry(zip, "xl/styles.xml", BuildStylesXml());
            AddEntry(zip, "xl/worksheets/sheet1.xml", sheet.ToString());

            using (var ms = new MemoryStream())
            {
                zip.Save(ms);
                return ms.ToArray();
            }
        }
    }

    private static void AppendDataRow(StringBuilder sb, int rowIndex, bool bold, params string[] cells)
    {
        sb.Append("<row r=\"").Append(rowIndex).Append("\">");
        for (int i = 0; i < cells.Length; i++)
        {
            string col = GetColumnName(i + 1);
            string cellRef = col + rowIndex.ToString(CultureInfo.InvariantCulture);
            string text = XmlEscape(cells[i] ?? string.Empty);
            if (bold)
                sb.Append("<c r=\"").Append(cellRef).Append("\" s=\"1\" t=\"inlineStr\"><is><t xml:space=\"preserve\">").Append(text).Append("</t></is></c>");
            else
                sb.Append("<c r=\"").Append(cellRef).Append("\" t=\"inlineStr\"><is><t xml:space=\"preserve\">").Append(text).Append("</t></is></c>");
        }
        sb.Append("</row>");
    }

    private static string Cell(DataRow row, string column)
    {
        if (row == null || row.Table == null || !row.Table.Columns.Contains(column))
            return string.Empty;
        object v = row[column];
        return v == DBNull.Value ? string.Empty : Convert.ToString(v, CultureInfo.InvariantCulture);
    }

    private static string XmlEscape(string s)
    {
        if (string.IsNullOrEmpty(s))
            return string.Empty;
        return s
            .Replace("&", "&amp;")
            .Replace("<", "&lt;")
            .Replace(">", "&gt;")
            .Replace("\"", "&quot;");
    }

    private static string GetColumnName(int columnNumber)
    {
        int dividend = columnNumber;
        var columnName = new StringBuilder();
        while (dividend > 0)
        {
            int modulo = (dividend - 1) % 26;
            columnName.Insert(0, (char)(65 + modulo));
            dividend = (dividend - modulo) / 26;
        }
        return columnName.ToString();
    }

    private static void AddEntry(ZipFile zip, string fullName, string content)
    {
        zip.AddEntry(fullName.Replace('\\', '/'), content ?? string.Empty, new UTF8Encoding(false));
    }

    private static string BuildContentTypes()
    {
        return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"
            + "<Types xmlns=\"http://schemas.openxmlformats.org/package/2006/content-types\">"
            + "<Default Extension=\"rels\" ContentType=\"application/vnd.openxmlformats-package.relationships+xml\"/>"
            + "<Default Extension=\"xml\" ContentType=\"application/xml\"/>"
            + "<Override PartName=\"/xl/workbook.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml\"/>"
            + "<Override PartName=\"/xl/worksheets/sheet1.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml\"/>"
            + "<Override PartName=\"/xl/styles.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml\"/>"
            + "<Override PartName=\"/docProps/core.xml\" ContentType=\"application/vnd.openxmlformats-package.core-properties+xml\"/>"
            + "<Override PartName=\"/docProps/app.xml\" ContentType=\"application/vnd.openxmlformats-officedocument.extended-properties+xml\"/>"
            + "</Types>";
    }

    private static string BuildRootRels()
    {
        return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"
            + "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">"
            + "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument\" Target=\"xl/workbook.xml\"/>"
            + "<Relationship Id=\"rId2\" Type=\"http://schemas.openxmlformats.org/package/2006/relationships/metadata/core-properties\" Target=\"docProps/core.xml\"/>"
            + "<Relationship Id=\"rId3\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/extended-properties\" Target=\"docProps/app.xml\"/>"
            + "</Relationships>";
    }

    private static string BuildWorkbookXml()
    {
        return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"
            + "<workbook xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\" "
            + "xmlns:r=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships\">"
            + "<workbookPr date1904=\"false\"/>"
            + "<bookViews><workbookView xWindow=\"0\" yWindow=\"0\" windowWidth=\"25600\" windowHeight=\"16000\"/></bookViews>"
            + "<sheets><sheet name=\"EYE Classwise\" sheetId=\"1\" r:id=\"rId1\"/></sheets>"
            + "</workbook>";
    }

    private static string BuildWorkbookRels()
    {
        return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"
            + "<Relationships xmlns=\"http://schemas.openxmlformats.org/package/2006/relationships\">"
            + "<Relationship Id=\"rId1\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet\" Target=\"worksheets/sheet1.xml\"/>"
            + "<Relationship Id=\"rId2\" Type=\"http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles\" Target=\"styles.xml\"/>"
            + "</Relationships>";
    }

    private static string BuildStylesXml()
    {
        return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"
            + "<styleSheet xmlns=\"http://schemas.openxmlformats.org/spreadsheetml/2006/main\">"
            + "<fonts count=\"2\">"
            + "<font><sz val=\"11\"/><name val=\"Calibri\"/></font>"
            + "<font><b/><sz val=\"11\"/><name val=\"Calibri\"/></font>"
            + "</fonts>"
            + "<fills count=\"2\"><fill><patternFill patternType=\"none\"/></fill><fill><patternFill patternType=\"none\"/></fill></fills>"
            + "<borders count=\"1\"><border><left/><right/><top/><bottom/><diagonal/></border></borders>"
            + "<cellStyleXfs count=\"1\"><xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\"/></cellStyleXfs>"
            + "<cellXfs count=\"2\">"
            + "<xf numFmtId=\"0\" fontId=\"0\" fillId=\"0\" borderId=\"0\" xfId=\"0\"/>"
            + "<xf numFmtId=\"0\" fontId=\"1\" fillId=\"0\" borderId=\"0\" xfId=\"0\" applyFont=\"1\"/>"
            + "</cellXfs>"
            + "</styleSheet>";
    }

    private static string BuildCoreXml()
    {
        string now = DateTime.UtcNow.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'", CultureInfo.InvariantCulture);
        return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"
            + "<cp:coreProperties xmlns:cp=\"http://schemas.openxmlformats.org/package/2006/metadata/core-properties\" "
            + "xmlns:dc=\"http://purl.org/dc/elements/1.1/\" xmlns:dcterms=\"http://purl.org/dc/terms/\" "
            + "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\">"
            + "<dc:title>EYE Classwise Analysis</dc:title>"
            + "<dc:creator>AIMS+</dc:creator>"
            + "<cp:lastModifiedBy>AIMS+</cp:lastModifiedBy>"
            + "<dcterms:created xsi:type=\"dcterms:W3CDTF\">" + now + "</dcterms:created>"
            + "<dcterms:modified xsi:type=\"dcterms:W3CDTF\">" + now + "</dcterms:modified>"
            + "</cp:coreProperties>";
    }

    private static string BuildAppXml()
    {
        return "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>"
            + "<Properties xmlns=\"http://schemas.openxmlformats.org/officeDocument/2006/extended-properties\">"
            + "<Application>AIMS+</Application></Properties>";
    }
}
