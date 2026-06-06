using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;

/// <summary>
/// Rolls up detail rows (e.g. multiple rows per class) into one row per class plus a weighted Total row,
/// matching the classic EYE Classwise Analysis layout.
/// </summary>
public static class EYEClassWiseAnalysisAggregator
{
    private static readonly string[] ClassDisplayOrder =
    {
        "Playgroup", "Nursery", "Kindergarten", "Class 1", "Class 2", "Class 3", "Class 4", "Class 5",
        "Class 6", "Class 7", "Class 8", "Class 9 (O Level)", "Class 10 (O Level)", "Class 11 (O Level)",
        "A-1 (A Level)", "A-2 (A Level)"
    };

    public static DataTable BuildClassSummary(DataTable raw)
    {
        if (raw == null || raw.Rows.Count == 0)
            return CreateOutputSchema();

        string classCol = ResolveClassColumn(raw);
        if (string.IsNullOrEmpty(classCol))
            return PassThroughUnchanged(raw);

        // Roll up all rows for the same class; prefer Class_Id as key when the view exposes it.
        string classIdCol = FindColumn(raw, "Class_Id", "class_id", "ClassID");
        string groupCol = !string.IsNullOrEmpty(classIdCol) ? classIdCol : classCol;

        var eligible = raw.AsEnumerable().Where(r => !IsSourceTotalRow(r, classCol)).ToList();
        if (eligible.Count == 0)
            return CreateOutputSchema();

        var groups = eligible.GroupBy(r => ClassKey(r[groupCol])).ToList();

        bool siqaPerfShape = IsResultsSessionStudentPerformanceShape(raw);

        var summaries = new List<ClassAgg>();
        foreach (var g in groups)
        {
            List<DataRow> rows = g.ToList();
            string name = ResolveClassDisplayName(rows, classCol);
            summaries.Add(new ClassAgg
            {
                DisplayClass = name,
                OrderOfClass = ReadOrderOfClass(rows, raw),
                ExcPct = AggregatePct(rows, raw, MetricSlot.Exc),
                ExpPct = AggregatePct(rows, raw, MetricSlot.Exp),
                EmePct = AggregatePct(rows, raw, MetricSlot.Eme),
                NiPct = AggregatePct(rows, raw, MetricSlot.Ni),
                WeightForTotal = ComputeClassWeight(rows, raw, siqaPerfShape),
                TotalStudents = ComputeTotalStudentsForClass(rows, raw),
                TotalLos = CountTotalLosForClass(rows, raw)
            });
        }

        SortClasses(summaries);

        ClassAgg total = BuildTotalRow(summaries);
        summaries.Add(total);

        return ToOutputTable(summaries);
    }

    /// <summary>
    /// Rolls up detail rows into one row per class and subject plus a weighted Total row
    /// (CO_ClasslevelwiseSubjectAnalysis.rpt HTML replacement).
    /// </summary>
    public static DataTable BuildClassSubjectSummary(DataTable raw)
    {
        if (raw == null || raw.Rows.Count == 0)
            return CreateClassSubjectOutputSchema();

        string classCol = ResolveClassColumn(raw);
        string subjectCol = ResolveSubjectColumn(raw);
        if (string.IsNullOrEmpty(classCol) || string.IsNullOrEmpty(subjectCol))
            return PassThroughClassSubjectUnchanged(raw);

        string classIdCol = FindColumn(raw, "Class_Id", "class_id", "ClassID");
        string subjectIdCol = FindColumn(raw, "Subject_Id", "subject_id", "SubjectID");
        string classGroupCol = !string.IsNullOrEmpty(classIdCol) ? classIdCol : classCol;
        string subjectGroupCol = !string.IsNullOrEmpty(subjectIdCol) ? subjectIdCol : subjectCol;

        var eligible = raw.AsEnumerable().Where(r => !IsSourceTotalRow(r, classCol)).ToList();
        if (eligible.Count == 0)
            return CreateClassSubjectOutputSchema();

        var groups = eligible.GroupBy(r => ClassSubjectGroupKey(r, classGroupCol, subjectGroupCol)).ToList();
        bool siqaPerfShape = IsResultsSessionStudentPerformanceShape(raw);

        var summaries = new List<ClassSubjectAgg>();
        foreach (var g in groups)
        {
            List<DataRow> rows = g.ToList();
            summaries.Add(new ClassSubjectAgg
            {
                DisplayClass = ResolveClassDisplayName(rows, classCol),
                DisplaySubject = ResolveSubjectDisplayName(rows, subjectCol),
                OrderOfClass = ReadOrderOfClass(rows, raw),
                ExcPct = AggregatePct(rows, raw, MetricSlot.Exc),
                ExpPct = AggregatePct(rows, raw, MetricSlot.Exp),
                EmePct = AggregatePct(rows, raw, MetricSlot.Eme),
                NiPct = AggregatePct(rows, raw, MetricSlot.Ni),
                WeightForTotal = ComputeClassWeight(rows, raw, siqaPerfShape),
                TotalStudents = ComputeTotalStudentsForClass(rows, raw),
                TotalLos = CountTotalLosForClass(rows, raw)
            });
        }

        SortClassSubjects(summaries);

        var result = new List<ClassSubjectAgg>();
        foreach (IGrouping<string, ClassSubjectAgg> classGroup in summaries
            .GroupBy(s => ClassKey(s.DisplayClass))
            .OrderBy(g => ClassOrderIndex(g.First().DisplayClass))
            .ThenBy(g => g.First().DisplayClass, StringComparer.OrdinalIgnoreCase))
        {
            List<ClassSubjectAgg> classRows = classGroup
                .OrderBy(s => s.DisplaySubject, StringComparer.OrdinalIgnoreCase)
                .ToList();
            result.AddRange(classRows);
            ClassSubjectAgg total = BuildClassSubjectTotalRow(classRows);
            total.DisplayClass = classRows[0].DisplayClass;
            total.DisplaySubject = "Total";
            result.Add(total);
        }

        return ToClassSubjectOutputTable(result);
    }

    private enum MetricSlot { Exc, Exp, Eme, Ni }

    private sealed class ClassAgg
    {
        public string DisplayClass;
        public int? OrderOfClass;
        public decimal TotalStudents;
        public decimal TotalLos;
        public decimal? ExcPct, ExpPct, EmePct, NiPct;
        public decimal WeightForTotal;
    }

    private sealed class ClassSubjectAgg
    {
        public string DisplayClass;
        public string DisplaySubject;
        public int? OrderOfClass;
        public decimal TotalStudents;
        public decimal TotalLos;
        public decimal? ExcPct, ExpPct, EmePct, NiPct;
        public decimal WeightForTotal;
    }

    private static DataTable CreateOutputSchema()
    {
        var t = new DataTable();
        t.Columns.Add("DisplayClass", typeof(string));
        t.Columns.Add("DisplayTotalStudents", typeof(string));
        t.Columns.Add("DisplayTotalLos", typeof(string));
        t.Columns.Add("DisplayExc", typeof(string));
        t.Columns.Add("DisplayExp", typeof(string));
        t.Columns.Add("DisplayEme", typeof(string));
        t.Columns.Add("DisplayNi", typeof(string));
        t.Columns.Add("IsTotal", typeof(bool));
        return t;
    }

    private static DataTable PassThroughUnchanged(DataTable raw)
    {
        var t = CreateOutputSchema();
        foreach (DataRow r in raw.Rows)
        {
            DataRow nr = t.NewRow();
            nr["DisplayClass"] = GetFirst(r, "Class_Name", "Classes", "Class_Label", "Label", "Class");
            nr["DisplayTotalStudents"] = FormatStudentCountCell(GetFirst(r, "Student_count", "StudentCount", "Students", "Student_Count"));
            decimal losRaw = ResolvePassThroughTotalLos(r, raw);
            decimal studRaw = ReadStudentCountOnRow(r);
            nr["DisplayTotalLos"] = FormatLosPerStudentCell(losRaw, studRaw);
            nr["DisplayExc"] = FormatPctString(GetFirst(r, "EXC", "Exc"));
            nr["DisplayExp"] = FormatPctString(GetFirst(r, "EXP", "Exp"));
            nr["DisplayEme"] = FormatPctString(GetFirst(r, "EME", "Eme"));
            nr["DisplayNi"] = FormatPctString(GetFirst(r, "NI", "N_I", "N.I", "Ni"));
            nr["IsTotal"] = string.Equals(nr["DisplayClass"].ToString(), "Total", StringComparison.OrdinalIgnoreCase);
            t.Rows.Add(nr);
        }
        return t;
    }

    private static DataTable ToOutputTable(List<ClassAgg> list)
    {
        var t = CreateOutputSchema();
        foreach (ClassAgg c in list)
        {
            if (c == null)
                continue;
            DataRow nr = t.NewRow();
            nr["DisplayClass"] = c.DisplayClass;
            nr["DisplayTotalStudents"] = FormatStudentCountCell(c.TotalStudents);
            nr["DisplayTotalLos"] = FormatLosPerStudentCell(c.TotalLos, c.TotalStudents);
            nr["DisplayExc"] = FormatNullablePct(c.ExcPct);
            nr["DisplayExp"] = FormatNullablePct(c.ExpPct);
            nr["DisplayEme"] = FormatNullablePct(c.EmePct);
            nr["DisplayNi"] = FormatNullablePct(c.NiPct);
            nr["IsTotal"] = c.DisplayClass != null && c.DisplayClass.Equals("Total", StringComparison.OrdinalIgnoreCase);
            t.Rows.Add(nr);
        }
        return t;
    }

    private static void SortClasses(List<ClassAgg> summaries)
    {
        summaries.Sort((a, b) =>
        {
            if (a.OrderOfClass.HasValue && b.OrderOfClass.HasValue)
            {
                int oc = a.OrderOfClass.Value.CompareTo(b.OrderOfClass.Value);
                if (oc != 0)
                    return oc;
            }
            else if (a.OrderOfClass.HasValue != b.OrderOfClass.HasValue)
                return a.OrderOfClass.HasValue ? -1 : 1;

            int ia = ClassOrderIndex(a.DisplayClass);
            int ib = ClassOrderIndex(b.DisplayClass);
            int c = ia.CompareTo(ib);
            return c != 0 ? c : string.Compare(a.DisplayClass, b.DisplayClass, StringComparison.OrdinalIgnoreCase);
        });
    }

    private static int? ReadOrderOfClass(List<DataRow> rows, DataTable table)
    {
        if (rows == null || rows.Count == 0)
            return null;
        string col = FindColumn(table, "OrderOfClass", "OrderofClass", "Class_Order");
        if (col == null)
            return null;
        decimal? d = ParseDecimalCell(rows[0][col]);
        if (!d.HasValue)
            return null;
        return (int)Math.Round(d.Value, MidpointRounding.AwayFromZero);
    }

    private static int ClassOrderIndex(string name)
    {
        if (string.IsNullOrEmpty(name))
            return 9999;
        for (int i = 0; i < ClassDisplayOrder.Length; i++)
        {
            if (name.Equals(ClassDisplayOrder[i], StringComparison.OrdinalIgnoreCase))
                return i;
        }
        return 5000;
    }

    private static ClassAgg BuildTotalRow(List<ClassAgg> classes)
    {
        var nonTotal = classes.Where(c => c != null && !c.DisplayClass.Equals("Total", StringComparison.OrdinalIgnoreCase)).ToList();
        decimal sumW = nonTotal.Sum(c => c.WeightForTotal);
        if (sumW <= 0m)
            sumW = nonTotal.Count;

        return new ClassAgg
        {
            DisplayClass = "Total",
            TotalStudents = nonTotal.Sum(c => c.TotalStudents),
            TotalLos = nonTotal.Sum(c => c.TotalLos),
            ExcPct = WeightedAvg(nonTotal, c => c.ExcPct, sumW),
            ExpPct = WeightedAvg(nonTotal, c => c.ExpPct, sumW),
            EmePct = WeightedAvg(nonTotal, c => c.EmePct, sumW),
            NiPct = WeightedAvg(nonTotal, c => c.NiPct, sumW),
            WeightForTotal = sumW
        };
    }

    private static decimal? WeightedAvg(List<ClassAgg> items, Func<ClassAgg, decimal?> metric, decimal sumW)
    {
        if (items == null || items.Count == 0 || sumW <= 0m)
            return null;
        decimal acc = 0m;
        decimal wsum = 0m;
        foreach (ClassAgg c in items)
        {
            decimal? p = metric(c);
            if (!p.HasValue)
                continue;
            decimal w = c.WeightForTotal > 0m ? c.WeightForTotal : 1m;
            acc += p.Value * w;
            wsum += w;
        }
        if (wsum <= 0m)
            return null;
        return acc / wsum;
    }

    /// <summary>
    /// True when the dataset matches dbo.Results_SessionStudentPerformanceGrading (EYE / SIQA grading lines).
    /// </summary>
    private static bool IsResultsSessionStudentPerformanceShape(DataTable table)
    {
        if (table == null)
            return false;
        return FindColumn(table, "SIQAGradeGroupingExc", "SIQAGradeGrouping_Exc") != null
            || FindColumn(table, "RateCode", "ratecode", "Rate_Code") != null;
    }

    private static decimal ComputeClassWeight(List<DataRow> rows, DataTable table, bool siqaPerfShape)
    {
        if (siqaPerfShape && rows != null && rows.Count > 0)
            return rows.Count;

        string wCol = FindColumn(table, "Student_count", "StudentCount", "Students", "Student_Count");
        if (wCol == null)
            return rows.Count;

        decimal maxW = 0m;
        foreach (DataRow r in rows)
        {
            decimal? v = ParseDecimalCell(r[wCol]);
            if (v.HasValue && v.Value > maxW)
                maxW = v.Value;
        }
        if (maxW > 0m)
            return maxW;

        decimal sumW = 0m;
        foreach (DataRow r in rows)
        {
            decimal? v = ParseDecimalCell(r[wCol]);
            sumW += v ?? 1m;
        }
        return sumW > 0m ? sumW : rows.Count;
    }

    /// <summary>
    /// Distinct students in this class: prefer counting unique Student_Id across all detail rows
    /// (one combined count per class). Falls back to Student_count by section when Student_Id is absent.
    /// </summary>
    private static decimal ComputeTotalStudentsForClass(List<DataRow> rows, DataTable table)
    {
        if (rows == null || rows.Count == 0)
            return 0m;

        string idCol = FindColumn(table, "Student_Id", "student_id", "StudentId", "StudentID");
        if (!string.IsNullOrEmpty(idCol))
        {
            var distinctIds = new HashSet<string>(StringComparer.Ordinal);
            foreach (DataRow r in rows)
            {
                if (r.Table == null || !r.Table.Columns.Contains(idCol))
                    continue;
                object v = r[idCol];
                if (v == null || v == DBNull.Value)
                    continue;
                string key = Convert.ToString(v, CultureInfo.InvariantCulture).Trim();
                if (key.Length == 0)
                    continue;
                distinctIds.Add(key);
            }
            if (distinctIds.Count > 0)
                return distinctIds.Count;
        }

        string studCol = FindColumn(table, "Student_count", "StudentCount", "Students", "Student_Count");
        if (string.IsNullOrEmpty(studCol))
            return rows.Count;

        string secSubjectCol = FindColumn(table, "Section_Subject_Id", "Section_Subject_id");
        string secCol = !string.IsNullOrEmpty(secSubjectCol)
            ? secSubjectCol
            : FindColumn(table, "Section_Id");

        if (!string.IsNullOrEmpty(secCol))
        {
            decimal sum = 0m;
            foreach (IGrouping<string, DataRow> grp in rows.GroupBy(r => SectionKey(r, secCol)))
            {
                decimal maxInSec = 0m;
                foreach (DataRow r in grp)
                {
                    decimal? v = ParseDecimalCell(r[studCol]);
                    if (v.HasValue && v.Value > maxInSec)
                        maxInSec = v.Value;
                }
                sum += maxInSec > 0m ? maxInSec : 0m;
            }
            return sum > 0m ? sum : rows.Count;
        }

        decimal max = 0m;
        foreach (DataRow r in rows)
        {
            decimal? v = ParseDecimalCell(r[studCol]);
            if (v.HasValue && v.Value > max)
                max = v.Value;
        }
        return max > 0m ? max : rows.Count;
    }

    /// <summary>
    /// Count of LO / grading lines for the class, aligned with how <see cref="AggregatePct"/> builds denominators:
    /// SIQA RateCode or bucket rows first, else non-blank PerformanceGrading (and aliases), else sum of Total_LOs-style columns, else row count.
    /// </summary>
    private static decimal CountTotalLosForClass(List<DataRow> rows, DataTable table)
    {
        if (rows == null || rows.Count == 0 || table == null)
            return 0m;

        string rateCol = FindColumn(table, "RateCode", "ratecode", "Rate_Code");
        string bucketCol = FindColumn(table, "SIQAGradeGroupingExc", "SIQAGradeGrouping_Exc");
        if (!string.IsNullOrEmpty(rateCol) || !string.IsNullOrEmpty(bucketCol))
            return CountSiqaGradingLines(rows, rateCol, bucketCol);

        string gcol = FindColumn(table, "PerformanceGrading", "Rating", "Grade", "SIQA_Grade", "Outcome", "Band", "Performance", "Grade_Name", "GradeName");
        if (!string.IsNullOrEmpty(gcol))
            return CountPerformanceGradingLines(rows, gcol);

        string totalCol = FindColumn(table, "Total_LOs", "TotalLOs", "Total_Los", "TotalLos", "Total_LO", "LOs", "Lo_Count", "LO_Count");
        if (!string.IsNullOrEmpty(totalCol))
        {
            decimal sum = 0m;
            foreach (DataRow r in rows)
            {
                decimal? d = ParseDecimalCell(r[totalCol]);
                if (d.HasValue && d.Value > 0m)
                    sum += d.Value;
            }
            if (sum > 0m)
                return sum;
        }

        return rows.Count;
    }

    private static decimal ResolvePassThroughTotalLos(DataRow r, DataTable table)
    {
        if (r == null)
            return 0m;
        return CountTotalLosForClass(new List<DataRow> { r }, table);
    }

    /// <summary>Same inclusion as <see cref="AggregateFromSiqaPerformanceGrading"/> (one count per graded line).</summary>
    private static decimal CountSiqaGradingLines(List<DataRow> rows, string rateCol, string bucketCol)
    {
        int n = 0;
        foreach (DataRow r in rows)
        {
            if (r == null || r.Table == null)
                continue;

            if (!string.IsNullOrEmpty(rateCol) && r.Table.Columns.Contains(rateCol) && r[rateCol] != DBNull.Value)
            {
                string rc = Convert.ToString(r[rateCol], CultureInfo.InvariantCulture).Trim();
                if (rc.Length > 0)
                {
                    n++;
                    continue;
                }
            }

            if (!string.IsNullOrEmpty(bucketCol) && r.Table.Columns.Contains(bucketCol) && r[bucketCol] != DBNull.Value)
            {
                string b = Convert.ToString(r[bucketCol], CultureInfo.InvariantCulture).Trim();
                if (b.Length > 0)
                    n++;
            }
        }
        return n;
    }

    private static decimal CountPerformanceGradingLines(List<DataRow> rows, string gcol)
    {
        int n = 0;
        foreach (DataRow r in rows)
        {
            if (r == null || r.Table == null || !r.Table.Columns.Contains(gcol))
                continue;
            object v = r[gcol];
            if (v == null || v == DBNull.Value)
                continue;
            string g = Convert.ToString(v, CultureInfo.InvariantCulture).Trim();
            if (g.Length == 0 || g == "-")
                continue;
            n++;
        }
        return n;
    }

    private static string SectionKey(DataRow r, string secCol)
    {
        if (r == null || r.Table == null || string.IsNullOrEmpty(secCol) || !r.Table.Columns.Contains(secCol))
            return "_";
        object v = r[secCol];
        return v == DBNull.Value ? "_" : Convert.ToString(v, CultureInfo.InvariantCulture);
    }

    /// <summary>Raw total LO lines ÷ class headcount — rounded to whole number (≥0.5 rounds up, &lt;0.5 rounds down).</summary>
    private static string FormatLosPerStudentCell(decimal losCount, decimal studentCount)
    {
        if (studentCount <= 0m || losCount <= 0m)
            return string.Empty;
        decimal ratio = losCount / studentCount;
        long rounded = (long)Math.Round(ratio, 0, MidpointRounding.AwayFromZero);
        if (rounded <= 0L)
            return string.Empty;
        return rounded.ToString(CultureInfo.InvariantCulture);
    }

    private static decimal ReadStudentCountOnRow(DataRow r)
    {
        if (r == null || r.Table == null)
            return 0m;
        string col = FindColumn(r.Table, "Student_count", "StudentCount", "Students", "Student_Count");
        if (string.IsNullOrEmpty(col))
            return 0m;
        return ParseDecimalCell(r[col]) ?? 0m;
    }

    private static string FormatStudentCountCell(decimal value)
    {
        if (value <= 0m)
            return string.Empty;
        return Math.Round(value, 0, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
    }

    private static string FormatStudentCountCell(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return string.Empty;
        decimal d;
        if (!decimal.TryParse(raw.Trim(), NumberStyles.Any, CultureInfo.InvariantCulture, out d))
            return string.Empty;
        return FormatStudentCountCell(d);
    }

    /// <summary>
    /// Percent of grading lines in each bucket — matches dbo.Results_SessionStudentPerformanceGrading
    /// (RateCode / SIQAGradeGroupingExc from Student_Performance_AchvmntRating).
    /// </summary>
    private static decimal? AggregateFromSiqaPerformanceGrading(List<DataRow> rows, DataTable table, MetricSlot slot)
    {
        if (rows == null || rows.Count == 0)
            return null;

        string rateCol = FindColumn(table, "RateCode", "ratecode", "Rate_Code");
        string bucketCol = FindColumn(table, "SIQAGradeGroupingExc", "SIQAGradeGrouping_Exc");

        if (string.IsNullOrEmpty(rateCol) && string.IsNullOrEmpty(bucketCol))
            return null;

        int total = 0;
        int hit = 0;
        foreach (DataRow r in rows)
        {
            if (!string.IsNullOrEmpty(rateCol) && r.Table.Columns.Contains(rateCol) && r[rateCol] != DBNull.Value)
            {
                string rc = Convert.ToString(r[rateCol], CultureInfo.InvariantCulture).Trim();
                if (rc.Length == 0)
                    continue;
                total++;
                if (RateCodeMatchesSiqa(rc, slot))
                    hit++;
                continue;
            }

            if (!string.IsNullOrEmpty(bucketCol) && r.Table.Columns.Contains(bucketCol) && r[bucketCol] != DBNull.Value)
            {
                string b = Convert.ToString(r[bucketCol], CultureInfo.InvariantCulture).Trim().ToUpperInvariant();
                if (b.Length == 0)
                    continue;
                total++;
                if (SiqaBucketCodeMatches(b, slot))
                    hit++;
            }
        }

        if (total == 0)
            return null;
        return 100m * hit / total;
    }

    private static bool RateCodeMatchesSiqa(string rateCode, MetricSlot slot)
    {
        string u = rateCode.Trim().ToUpperInvariant();
        if (u.Length == 0)
            return false;

        if (slot == MetricSlot.Exc)
            return u == "EXC" || u == "EX" || u.StartsWith("EXC", StringComparison.Ordinal) || u.Contains("EXCEED");
        if (slot == MetricSlot.Exp)
            return u == "EXP" || u.StartsWith("EXP", StringComparison.Ordinal) || (u.Contains("EXPECT") && !u.Contains("BELOW"));
        if (slot == MetricSlot.Eme)
            return u == "EME" || u == "EMG" || u.StartsWith("EME", StringComparison.Ordinal) || u.StartsWith("EMG", StringComparison.Ordinal) || u.Contains("EMERG");
        if (slot == MetricSlot.Ni)
            return u == "NI" || u == "N.I" || u.StartsWith("NI", StringComparison.Ordinal) || u.Contains("NEED");

        return false;
    }

    private static bool SiqaBucketCodeMatches(string bucketUpper, MetricSlot slot)
    {
        switch (bucketUpper)
        {
            case "EXC":
                return slot == MetricSlot.Exc;
            case "EXP":
                return slot == MetricSlot.Exp;
            case "EME":
            case "EMG":
                return slot == MetricSlot.Eme;
            case "NI":
            case "N.I":
                return slot == MetricSlot.Ni;
            default:
                if (bucketUpper.StartsWith("NEED", StringComparison.Ordinal))
                    return slot == MetricSlot.Ni;
                return false;
        }
    }

    private static decimal? AggregatePct(List<DataRow> rows, DataTable table, MetricSlot slot)
    {
        decimal? fromSiqa = AggregateFromSiqaPerformanceGrading(rows, table, slot);
        if (fromSiqa.HasValue)
            return fromSiqa;

        decimal? fromPct = WeightedRowPercentages(rows, table, slot);
        if (fromPct.HasValue)
            return fromPct;

        decimal? fromCounts = RatioFromCounts(rows, table, slot);
        if (fromCounts.HasValue)
            return fromCounts;

        decimal? fromGrade = HistogramFromGradeColumn(rows, table, slot);
        return fromGrade;
    }

    private static decimal? WeightedRowPercentages(List<DataRow> rows, DataTable table, MetricSlot slot)
    {
        string col = FindColumnForSlot(table, slot);
        if (col == null)
            return null;

        decimal wSum = 0m;
        decimal acc = 0m;
        foreach (DataRow r in rows)
        {
            decimal? p = ParsePercentCell(r[col]);
            if (!p.HasValue)
                continue;
            decimal w = RowWeight(r, table);
            acc += p.Value * w;
            wSum += w;
        }
        if (wSum <= 0m)
            return null;
        return acc / wSum;
    }

    private static decimal RowWeight(DataRow r, DataTable table)
    {
        string wCol = FindColumn(table, "Student_count", "StudentCount", "Students", "Student_Count");
        if (wCol == null)
            return 1m;
        decimal? v = ParseDecimalCell(r[wCol]);
        return v.HasValue && v.Value > 0m ? v.Value : 1m;
    }

    private static decimal? RatioFromCounts(List<DataRow> rows, DataTable table, MetricSlot slot)
    {
        string totalCol = FindColumn(table, "Total_LOs", "TotalLOs", "Total_Los", "TotalLos", "Total_LO", "LOs", "Lo_Count", "LO_Count");
        if (string.IsNullOrEmpty(totalCol))
            return null;

        string numCol = FindCountColumnForSlot(table, slot);
        if (string.IsNullOrEmpty(numCol))
            return null;

        decimal sumNum = 0m, sumDen = 0m;
        foreach (DataRow r in rows)
        {
            decimal? n = ParseDecimalCell(r[numCol]);
            decimal? d = ParseDecimalCell(r[totalCol]);
            if (!d.HasValue || d.Value <= 0m)
                continue;
            sumDen += d.Value;
            sumNum += n ?? 0m;
        }
        if (sumDen <= 0m)
            return null;
        return sumNum * 100m / sumDen;
    }

    private static string FindCountColumnForSlot(DataTable table, MetricSlot slot)
    {
        switch (slot)
        {
            case MetricSlot.Exc:
                return FindColumn(table, "EXC_Count", "Exc_Count", "Exceeding_Count", "Exceeding_LO", "EXC_LO", "Exc_LO", "ExceedingLO", "EXC_LOs", "Exc_Los", "EXC_LO_Count");
            case MetricSlot.Exp:
                return FindColumn(table, "EXP_Count", "Exp_Count", "Expected_Count", "Expected_LO", "EXP_LO", "ExpectedLO");
            case MetricSlot.Eme:
                return FindColumn(table, "EME_Count", "Eme_Count", "Emerging_Count", "Emerging_LO", "EME_LO", "EmergingLO");
            case MetricSlot.Ni:
                return FindColumn(table, "NI_Count", "Ni_Count", "N_I_Count", "Needs_Improvement_Count", "NI_LO", "NILO");
            default:
                return null;
        }
    }

    private static string FindColumnForSlot(DataTable table, MetricSlot slot)
    {
        switch (slot)
        {
            case MetricSlot.Exc:
                return FindColumn(table, "EXC", "Exc", "Exceeding_Pct", "EXC_Pct");
            case MetricSlot.Exp:
                return FindColumn(table, "EXP", "Exp", "Expected_Pct", "EXP_Pct");
            case MetricSlot.Eme:
                return FindColumn(table, "EME", "Eme", "Emerging_Pct", "EME_Pct");
            case MetricSlot.Ni:
                return FindColumn(table, "NI", "Ni", "N_I", "N.I", "NI_Pct", "N_I_Pct");
            default:
                return null;
        }
    }

    private static decimal? HistogramFromGradeColumn(List<DataRow> rows, DataTable table, MetricSlot slot)
    {
        string gcol = FindColumn(table, "PerformanceGrading", "Rating", "Grade", "SIQA_Grade", "Outcome", "Band", "Performance", "Grade_Name", "GradeName");
        if (gcol == null)
            return null;

        int hit = 0, total = 0;
        foreach (DataRow r in rows)
        {
            object v = r[gcol];
            if (v == null || v == DBNull.Value)
                continue;
            string g = Convert.ToString(v, CultureInfo.InvariantCulture).Trim();
            if (g.Length == 0 || g == "-")
                continue;
            total++;
            if (MatchesSlot(g, slot))
                hit++;
        }
        if (total == 0)
            return null;
        return hit * 100m / total;
    }

    private static bool MatchesSlot(string grade, MetricSlot slot)
    {
        string g = grade.ToLowerInvariant();
        if (g.Contains("exceed"))
            return slot == MetricSlot.Exc;
        if (g.Contains("need") || g.Contains("not on track"))
            return slot == MetricSlot.Ni;
        if (g.Contains("below") && g.Contains("expect"))
            return slot == MetricSlot.Eme;
        if (g.Contains("emerg") || g.Contains("develop") || g.Contains("toward"))
            return slot == MetricSlot.Eme;
        if (g.Contains("expect"))
            return slot == MetricSlot.Exp;
        return false;
    }

    private static bool IsSourceTotalRow(DataRow r, string classCol)
    {
        try
        {
            string cls = r[classCol] == DBNull.Value ? string.Empty : Convert.ToString(r[classCol], CultureInfo.InvariantCulture).Trim();
            if (cls.Equals("Total", StringComparison.OrdinalIgnoreCase))
                return true;
        }
        catch
        {
            // ignore
        }

        string isTot = GetFirst(r, "IsTotal", "RowType");
        if (isTot == "1" || isTot.Equals("true", StringComparison.OrdinalIgnoreCase) || isTot.Equals("Total", StringComparison.OrdinalIgnoreCase))
            return true;
        return false;
    }

    /// <summary>
    /// First column label: prefer explicit class name columns from the grouped rows, then fall back to the class column used for filtering/rollup.
    /// </summary>
    private static string ResolveClassDisplayName(List<DataRow> rows, string fallbackColumn)
    {
        if (rows == null || rows.Count == 0)
            return string.Empty;

        foreach (DataRow r in rows)
        {
            string n = GetFirst(r, "Class_Name", "ClassName", "ClassDescription", "Class_Description", "ClassTitle", "Class_Title");
            if (!string.IsNullOrWhiteSpace(n))
                return n.Trim();
        }

        foreach (DataRow r in rows)
        {
            string n = GetFirst(r, "Classes", "Class_Label", "Label", "Glevel", "Grade_Level", "GradeLevel");
            if (!string.IsNullOrWhiteSpace(n))
                return n.Trim();
        }

        if (string.IsNullOrEmpty(fallbackColumn) || rows[0].Table == null || !rows[0].Table.Columns.Contains(fallbackColumn))
            return string.Empty;

        object v = rows[0][fallbackColumn];
        return v == null || v == DBNull.Value ? string.Empty : Convert.ToString(v, CultureInfo.InvariantCulture).Trim();
    }

    private static string ClassKey(object cell)
    {
        if (cell == null || cell == DBNull.Value)
            return "\u0001";
        return Convert.ToString(cell, CultureInfo.InvariantCulture).Trim().ToUpperInvariant();
    }

    private static string ResolveClassColumn(DataTable raw)
    {
        return FindColumn(raw, "Class_Name", "Classes", "Class_Label", "Label", "Class", "ClassName", "Class_Id");
    }

    private static string FindColumn(DataTable table, params string[] candidates)
    {
        if (table == null)
            return null;
        foreach (string want in candidates)
        {
            foreach (DataColumn c in table.Columns)
            {
                if (string.Equals(c.ColumnName, want, StringComparison.OrdinalIgnoreCase))
                    return c.ColumnName;
            }
        }
        return null;
    }

    private static string GetFirst(DataRow r, params string[] names)
    {
        foreach (string n in names)
        {
            string col = FindColumn(r.Table, n);
            if (col == null)
                continue;
            object v = r[col];
            return v == DBNull.Value ? string.Empty : Convert.ToString(v, CultureInfo.InvariantCulture);
        }
        return string.Empty;
    }

    private static decimal? ParseDecimalCell(object cell)
    {
        if (cell == null || cell == DBNull.Value)
            return null;
        decimal d;
        if (decimal.TryParse(Convert.ToString(cell, CultureInfo.InvariantCulture), NumberStyles.Any, CultureInfo.InvariantCulture, out d))
            return d;
        return null;
    }

    private static decimal? ParsePercentCell(object cell)
    {
        if (cell == null || cell == DBNull.Value)
            return null;
        string s = Convert.ToString(cell, CultureInfo.InvariantCulture).Trim();
        if (s.Length == 0)
            return null;
        if (s.EndsWith("%", StringComparison.Ordinal))
            s = s.Substring(0, s.Length - 1).Trim();
        decimal d;
        if (!decimal.TryParse(s, NumberStyles.Any, CultureInfo.InvariantCulture, out d))
            return null;
        if (d >= 0m && d <= 1m)
            d *= 100m;
        return d;
    }

    private static string FormatLoCountCell(decimal value)
    {
        if (value <= 0m)
            return string.Empty;
        return Math.Round(value, 0, MidpointRounding.AwayFromZero).ToString(CultureInfo.InvariantCulture);
    }

    private static string FormatNullablePctTwoDecimals(decimal? p)
    {
        if (!p.HasValue)
            return "0.00%";
        decimal rounded = Math.Round(p.Value, 2, MidpointRounding.AwayFromZero);
        return rounded.ToString("0.00", CultureInfo.InvariantCulture) + "%";
    }

    private static string FormatNullablePctInteger(decimal? p)
    {
        if (!p.HasValue)
            return "0%";
        decimal rounded = Math.Round(p.Value, 0, MidpointRounding.AwayFromZero);
        return rounded.ToString("0", CultureInfo.InvariantCulture) + "%";
    }

    private static string FormatNullablePct(decimal? p)
    {
        if (!p.HasValue)
            return "0.0%";
        decimal rounded = Math.Round(p.Value, 1, MidpointRounding.AwayFromZero);
        return rounded.ToString("0.0", CultureInfo.InvariantCulture) + "%";
    }

    private static string FormatPctString(string raw)
    {
        if (string.IsNullOrWhiteSpace(raw))
            return "0%";
        decimal? p = ParsePercentCell(raw);
        return FormatNullablePct(p);
    }

    private static DataTable CreateClassSubjectOutputSchema()
    {
        var t = new DataTable();
        t.Columns.Add("DisplayClass", typeof(string));
        t.Columns.Add("DisplaySubject", typeof(string));
        t.Columns.Add("DisplayTotalStudents", typeof(string));
        t.Columns.Add("DisplayTotalLos", typeof(string));
        t.Columns.Add("DisplayExc", typeof(string));
        t.Columns.Add("DisplayExp", typeof(string));
        t.Columns.Add("DisplayEme", typeof(string));
        t.Columns.Add("DisplayNi", typeof(string));
        t.Columns.Add("IsTotal", typeof(bool));
        return t;
    }

    private static DataTable PassThroughClassSubjectUnchanged(DataTable raw)
    {
        var t = CreateClassSubjectOutputSchema();
        foreach (DataRow r in raw.Rows)
        {
            DataRow nr = t.NewRow();
            nr["DisplayClass"] = GetFirst(r, "Class_Name", "Classes", "Class_Label", "Label", "Class");
            nr["DisplaySubject"] = GetFirst(r, "Subject_Name", "SubjectName", "Subject", "SIQASubjectGroup");
            nr["DisplayTotalStudents"] = FormatStudentCountCell(GetFirst(r, "Student_count", "StudentCount", "Students", "Student_Count"));
            decimal losRaw = ResolvePassThroughTotalLos(r, raw);
            nr["DisplayTotalLos"] = FormatLoCountCell(losRaw);
            nr["DisplayExc"] = FormatPctString(GetFirst(r, "EXC", "Exc"));
            nr["DisplayExp"] = FormatPctString(GetFirst(r, "EXP", "Exp"));
            nr["DisplayEme"] = FormatPctString(GetFirst(r, "EME", "Eme"));
            nr["DisplayNi"] = FormatPctString(GetFirst(r, "NI", "N_I", "N.I", "Ni"));
            nr["IsTotal"] = string.Equals(nr["DisplaySubject"].ToString(), "Total", StringComparison.OrdinalIgnoreCase);
            t.Rows.Add(nr);
        }
        return t;
    }

    private static DataTable ToClassSubjectOutputTable(List<ClassSubjectAgg> list)
    {
        var t = CreateClassSubjectOutputSchema();
        foreach (ClassSubjectAgg c in list)
        {
            if (c == null)
                continue;
            DataRow nr = t.NewRow();
            nr["DisplayClass"] = c.DisplayClass;
            nr["DisplaySubject"] = c.DisplaySubject;
            nr["DisplayTotalStudents"] = FormatStudentCountCell(c.TotalStudents);
            nr["DisplayTotalLos"] = FormatLoCountCell(c.TotalLos);
            bool isTotal = string.Equals(c.DisplaySubject, "Total", StringComparison.OrdinalIgnoreCase);
            nr["DisplayExc"] = isTotal ? FormatNullablePctInteger(c.ExcPct) : FormatNullablePctTwoDecimals(c.ExcPct);
            nr["DisplayExp"] = isTotal ? FormatNullablePctInteger(c.ExpPct) : FormatNullablePctTwoDecimals(c.ExpPct);
            nr["DisplayEme"] = isTotal ? FormatNullablePctInteger(c.EmePct) : FormatNullablePctTwoDecimals(c.EmePct);
            nr["DisplayNi"] = isTotal ? FormatNullablePctInteger(c.NiPct) : FormatNullablePctTwoDecimals(c.NiPct);
            nr["IsTotal"] = isTotal;
            t.Rows.Add(nr);
        }
        return t;
    }

    private static void SortClassSubjects(List<ClassSubjectAgg> summaries)
    {
        summaries.Sort((a, b) =>
        {
            if (a.OrderOfClass.HasValue && b.OrderOfClass.HasValue)
            {
                int oc = a.OrderOfClass.Value.CompareTo(b.OrderOfClass.Value);
                if (oc != 0)
                    return oc;
            }
            else if (a.OrderOfClass.HasValue != b.OrderOfClass.HasValue)
                return a.OrderOfClass.HasValue ? -1 : 1;

            int ia = ClassOrderIndex(a.DisplayClass);
            int ib = ClassOrderIndex(b.DisplayClass);
            int c = ia.CompareTo(ib);
            if (c != 0)
                return c;

            return string.Compare(a.DisplaySubject, b.DisplaySubject, StringComparison.OrdinalIgnoreCase);
        });
    }

    private static ClassSubjectAgg BuildClassSubjectTotalRow(List<ClassSubjectAgg> rows)
    {
        var nonTotal = rows.Where(c => c != null && !string.Equals(c.DisplayClass, "Total", StringComparison.OrdinalIgnoreCase)).ToList();
        decimal sumW = nonTotal.Sum(c => c.WeightForTotal);
        if (sumW <= 0m)
            sumW = nonTotal.Count;

        return new ClassSubjectAgg
        {
            DisplayClass = "Total",
            DisplaySubject = string.Empty,
            TotalStudents = nonTotal.Count > 0 ? nonTotal[0].TotalStudents : 0m,
            TotalLos = nonTotal.Sum(c => c.TotalLos),
            ExcPct = WeightedAvgSubject(nonTotal, c => c.ExcPct, sumW),
            ExpPct = WeightedAvgSubject(nonTotal, c => c.ExpPct, sumW),
            EmePct = WeightedAvgSubject(nonTotal, c => c.EmePct, sumW),
            NiPct = WeightedAvgSubject(nonTotal, c => c.NiPct, sumW),
            WeightForTotal = sumW
        };
    }

    private static decimal? WeightedAvgSubject(List<ClassSubjectAgg> items, Func<ClassSubjectAgg, decimal?> metric, decimal sumW)
    {
        if (items == null || items.Count == 0 || sumW <= 0m)
            return null;
        decimal acc = 0m;
        decimal wsum = 0m;
        foreach (ClassSubjectAgg c in items)
        {
            decimal? p = metric(c);
            if (!p.HasValue)
                continue;
            decimal w = c.WeightForTotal > 0m ? c.WeightForTotal : 1m;
            acc += p.Value * w;
            wsum += w;
        }
        if (wsum <= 0m)
            return null;
        return acc / wsum;
    }

    private static string ClassSubjectGroupKey(DataRow row, string classCol, string subjectCol)
    {
        return ClassKey(row[classCol]) + "\u0002" + ClassKey(row[subjectCol]);
    }

    private static string ResolveSubjectColumn(DataTable raw)
    {
        return FindColumn(raw, "Subject_Name", "SubjectName", "Subject", "Subject_Description", "SIQASubjectGroup");
    }

    private static string ResolveSubjectDisplayName(List<DataRow> rows, string fallbackColumn)
    {
        if (rows == null || rows.Count == 0)
            return string.Empty;

        foreach (DataRow r in rows)
        {
            string n = GetFirst(r, "Subject_Name", "SubjectName", "Subject_Description", "SIQASubjectGroup");
            if (!string.IsNullOrWhiteSpace(n))
                return n.Trim();
        }

        if (string.IsNullOrEmpty(fallbackColumn) || rows[0].Table == null || !rows[0].Table.Columns.Contains(fallbackColumn))
            return string.Empty;

        object v = rows[0][fallbackColumn];
        return v == null || v == DBNull.Value ? string.Empty : Convert.ToString(v, CultureInfo.InvariantCulture).Trim();
    }
}
