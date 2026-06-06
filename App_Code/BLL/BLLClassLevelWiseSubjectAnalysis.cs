using System;

/// <summary>
/// Filter parameters for the HTML Class Level Wise Subject Analysis report (replaces CO_ClasslevelwiseSubjectAnalysis.rpt).
/// </summary>
public class BLLClassLevelWiseSubjectAnalysis
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
    public int? ResultGradeId { get; set; }
    public string ResultGradeIdsCsv { get; set; }

    public int? SectionId { get; set; }
    public int? StudentId { get; set; }
    public int? ClassTeacherEmployeeId { get; set; }
    public int? UserTeacherRestrictionId { get; set; }
    public int? GenderId { get; set; }
    public int? SubjectId { get; set; }
    public string SubjectIdsCsv { get; set; }
}
