using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Loads rows for the HTML EYE Classwise Analysis from the same database view/table as the Crystal report (LmsAppReports.Rpt_View).
/// </summary>
public class DALEYEClassWiseAnalysis
{
    private static readonly Regex SafeIdentifier = new Regex(@"^[a-zA-Z][a-zA-Z0-9_]{0,127}$", RegexOptions.Compiled);

    public static bool IsSafeViewName(string name)
    {
        return !string.IsNullOrWhiteSpace(name) && SafeIdentifier.IsMatch(name.Trim());
    }

    public DataTable GetReportData(BLLEYEClassWiseAnalysis p)
    {
        string view = (p.RptViewName ?? string.Empty).Trim();
        if (!IsSafeViewName(view))
            throw new ArgumentException("Invalid or missing report view name (rv).");

        var where = new StringBuilder();
        var prms = new List<SqlParameter>();
        where.Append(" WHERE 1=1 ");

        AppendSessionFilter(where, prms, p);

        if (p.MainOrganisationId.HasValue)
        {
            where.Append(" AND Main_Organisation_Id=@moid ");
            prms.Add(new SqlParameter("@moid", SqlDbType.Int) { Value = p.MainOrganisationId.Value });
        }

        AppendIntListOrSingle(where, "Region_Id", p.RegionIdsCsv, p.RegionId, "@rid", prms);
        AppendIntListOrSingle(where, "Center_Id", p.CenterIdsCsv, p.CenterId, "@cid", prms);
        AppendIntListOrSingle(where, "Class_Id", p.ClassIdsCsv, p.ClassId, "@clid", prms);

        if (p.ResultSeriesId.HasValue)
        {
            where.Append(" AND ResultSeries_Id=@rsid ");
            prms.Add(new SqlParameter("@rsid", SqlDbType.Int) { Value = p.ResultSeriesId.Value });
        }

        if (!string.IsNullOrWhiteSpace(p.GradeLevel))
        {
            where.Append(" AND Glevel=@glvl ");
            prms.Add(new SqlParameter("@glvl", SqlDbType.VarChar, 50) { Value = p.GradeLevel.Trim() });
        }

        if (p.TermGroupId.HasValue)
        {
            where.Append(" AND TermGroup_Id=@tgid ");
            prms.Add(new SqlParameter("@tgid", SqlDbType.Int) { Value = p.TermGroupId.Value });
        }

        AppendIntListOrSingle(where, "TermId", p.TermIdsCsv, p.TermId, "@termid", prms);

        AppendIntListOrSingle(where, "[G]", p.ResultGradeIdsCsv, p.ResultGradeId, "@rgid", prms);

        if (p.SectionId.HasValue)
        {
            where.Append(" AND Section_Id=@secid ");
            prms.Add(new SqlParameter("@secid", SqlDbType.Int) { Value = p.SectionId.Value });
        }

        if (p.StudentId.HasValue)
        {
            where.Append(" AND Student_Id=@stuid ");
            prms.Add(new SqlParameter("@stuid", SqlDbType.Int) { Value = p.StudentId.Value });
        }

        if (p.ClassTeacherEmployeeId.HasValue)
        {
            where.Append(" AND Employee_Id=@cemp ");
            prms.Add(new SqlParameter("@cemp", SqlDbType.Int) { Value = p.ClassTeacherEmployeeId.Value });
        }

        if (p.UserTeacherRestrictionId.HasValue)
        {
            where.Append(" AND Teacher_Id=@utid ");
            prms.Add(new SqlParameter("@utid", SqlDbType.Int) { Value = p.UserTeacherRestrictionId.Value });
        }

        if (p.GenderId.HasValue)
        {
            where.Append(" AND Gender_Id=@genid ");
            prms.Add(new SqlParameter("@genid", SqlDbType.Int) { Value = p.GenderId.Value });
        }

        AppendIntListOrSingle(where, "Subject_Id", p.SubjectIdsCsv, p.SubjectId, "@subid", prms);

        string sql = "SELECT * FROM dbo.[" + view + "]" + where.ToString();

        string cs = ConfigurationManager.ConnectionStrings["isl_amsoConnectionString"].ConnectionString;
        using (var cn = new SqlConnection(cs))
        using (var cmd = new SqlCommand(sql, cn))
        {
            cmd.CommandType = CommandType.Text;
            cmd.CommandTimeout = ResolveEYECommandTimeoutSeconds();
            foreach (var par in prms)
                cmd.Parameters.Add(par);

            using (var da = new SqlDataAdapter(cmd))
            {
                var dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }
    }

    private static void AppendSessionFilter(StringBuilder where, List<SqlParameter> prms, BLLEYEClassWiseAnalysis p)
    {
        List<int> multi = ParseIntList(p.SessionIdsCsv);
        if (multi.Count > 0)
        {
            where.Append(" AND Session_Id IN (").Append(string.Join(",", multi)).Append(") ");
            return;
        }

        int sid = p.DdlSessionId ?? p.SingleSessionId ?? 0;
        if (sid <= 0)
            return;

        int rptId = p.RptId;
        if (rptId == 358 || rptId == 359 || rptId == 360)
            where.AppendFormat(" AND Session_Id>={0} AND Session_Id<={1} ", sid - 2, sid);
        else if (rptId == 361)
            where.AppendFormat(" AND Session_Id>={0} AND Session_Id<={1} ", sid - 1, sid);
        else
        {
            where.Append(" AND Session_Id=@sess ");
            prms.Add(new SqlParameter("@sess", SqlDbType.Int) { Value = sid });
        }
    }

    private static void AppendIntListOrSingle(StringBuilder where, string columnName, string csv, int? singleId, string singleParam, List<SqlParameter> prms)
    {
        List<int> ids = ParseIntList(csv);
        if (ids.Count > 0)
            where.AppendFormat(" AND {0} IN ({1}) ", columnName, string.Join(",", ids));
        else if (singleId.HasValue)
        {
            where.AppendFormat(" AND {0}={1} ", columnName, singleParam);
            prms.Add(new SqlParameter(singleParam, SqlDbType.Int) { Value = singleId.Value });
        }
    }

    private static int ResolveEYECommandTimeoutSeconds()
    {
        string s = ConfigurationManager.AppSettings["EYEClassWiseAnalysisSqlCommandSeconds"];
        int sec;
        if (int.TryParse(s, NumberStyles.Integer, CultureInfo.InvariantCulture, out sec) && sec >= 30 && sec <= 3600)
            return sec;
        return 600;
    }

    private static List<int> ParseIntList(string csv)
    {
        var list = new List<int>();
        if (string.IsNullOrWhiteSpace(csv))
            return list;
        foreach (string part in csv.Split(new[] { ',', ';' }, StringSplitOptions.RemoveEmptyEntries))
        {
            int v;
            if (int.TryParse(part.Trim(), out v))
                list.Add(v);
        }
        return list.Distinct().ToList();
    }
}
