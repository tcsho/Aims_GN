using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

/// <summary>
/// Summary description for CaieStudentGradeRevision
/// </summary>
public class CaieStudentGradeRevision
{
    DllCaieStudentGradeRevision dllGrade = new DllCaieStudentGradeRevision();
    public int? Id { get; set; }
    public int SessionId { get; set; }
    public int RollNumber { get; set; }
    public string GradeLevel { get; set; }

    public int PuId { get; set; }
    public string Comments { get; set; }
    public string Result { get; set; }
    public int StudentId { get; set; }
    public int SeriesId { get; set; }
    

    public DataTable GetStudentGrade(CaieStudentGradeRevision grade)
    {
        return dllGrade.GetStudentGrade(grade);
    }

    public int UpdateCaieStudentResultGrade(CaieStudentGradeRevision grade)
    {
        return dllGrade.UpdateCaieStudentResultGrade(grade);
    }

    public void SaveComments(CaieStudentGradeRevision grade)
    {
        dllGrade.SaveComments(grade);
    }

    public DataTable BindComment(int rollNumber, int seriesId, int sessionId)
    {
       return dllGrade.BindComment(rollNumber, seriesId,sessionId);
    }

    public void UpdateComments(CaieStudentGradeRevision grade)
    {
        dllGrade.UpdateComments(grade);
    }

    public int GetLastAddedCommentId()
    {
       return dllGrade.GetLastAddedCommentId();
    }
}