using System;

/// <summary>
/// Filter parameters for the HTML EYE Classwise Analysis report (replaces CO_EYEClassWiseAnalysis.rpt).
/// </summary>
public class BLLEYEClassWiseAnalysis
{
    public string RptViewName { get; set; }
    public int RptId { get; set; }

    public string SessionIdsCsv { get; set; }
    public int? SingleSessionId { get; set; }
    public int? DdlSessionId { get; set; }

    public int? MainOrganisationId { get; set; }

    public string RegionIdsCsv { get; set; }
    public int? RegionId { get; set; }

    public string CenterIdsCsv { get; set; }
    public int? CenterId { get; set; }

    public string ClassIdsCsv { get; set; }
    public int? ClassId { get; set; }

    public int? ResultSeriesId { get; set; }
    public string GradeLevel { get; set; }
    public int? TermGroupId { get; set; }
    public int? TermId { get; set; }
    public string TermIdsCsv { get; set; }
    /// <summary>Result grade filter (Crystal field G).</summary>
    public int? ResultGradeId { get; set; }
    public string ResultGradeIdsCsv { get; set; }

    public int? SectionId { get; set; }
    public int? StudentId { get; set; }
    /// <summary>Teacher filter from List_ClassTeacher (Crystal Employee_Id).</summary>
    public int? ClassTeacherEmployeeId { get; set; }
    /// <summary>User level 5 restriction (Crystal Teacher_Id).</summary>
    public int? UserTeacherRestrictionId { get; set; }
    public int? GenderId { get; set; }
    public int? SubjectId { get; set; }
    public string SubjectIdsCsv { get; set; }
}
