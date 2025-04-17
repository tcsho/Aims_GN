using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StudentAttendanceDataDto
/// </summary>
public class StudentAttendanceDataDto
{
    public int StudendId { get; set; }
    public string Name { get; set; }
    public DateTime AdmReqDate { get; set; }
    public int ClassId { get; set; }
    public string ClassName { get; set; }
    public int SectionId { get; set; }
    public string SectionName { get; set; }
    public int MyProperty { get; set; }
    public int ClassSectionId { get; set; }
    public int StudentStatusId { get; set; }
    public int RegionId { get; set; }
    public int? AttnTypeId { get; set; }


}