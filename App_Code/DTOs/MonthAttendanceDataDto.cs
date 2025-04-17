using System;
using System.Collections.Generic;

public class MonthAttendanceDataDto
{
    public int SectionId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public int AttendanceMonth { get; set; }
    public bool IsOldData { get; set; }
    public List<StudentInfo> StudentInfo { get; set;}
}

public class WeekAttendanceDataDto
{
    public int? WeekNo { get; set; }
    public string Mon { get; set; }
    public string Tue { get; set; }
    public string Wed { get; set; }
    public string Thu { get; set; }
    public string Fri { get; set; }
    public string Sat { get; set; }
    public string Sun { get; set; }

    public DateTime MonDate { get; set; }
    public DateTime TueDate { get; set; }
    public DateTime WedDate { get; set; }
    public DateTime ThurDate { get; set; }
    public DateTime FriDate { get; set; }
    public DateTime SatDate { get; set; }
    public DateTime SunDate { get; set; }
}

public class StudentInfo
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public List<WeekAttendanceDataDto> Week { get; set; }
}

