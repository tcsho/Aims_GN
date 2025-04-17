using System;
using System.Collections.Generic;

public class AttendanceDto
{
    public DateTime AttendanceDate { get; set; }
    public int Cal_Id { get; set; }
    public string CalDayType_Id { get; set; }
    public string CalDayDesc { get; set; }
    public int SectionId { get; set; }
    public int Center_Id { get; set; }

    public List<StudentAttendanceData> Info { get; set; }
    public List<StudentAttendanceDataDetail> InfoDetail { get; set; }
}

public class StudentAttendanceData
{
    public int StudentId { get; set; }
    public string Mon { get; set; }
    public string Tue { get; set; }
    public string Wed { get; set; }
    public string Thu { get; set; }
    public string Fri { get; set; }
    public string Sat { get; set; }
    public string Sun { get; set; }
}

public class StudentAttendanceDataDetail
{
    public int RollNumber { get; set; }
    public string Mon { get; set; }
    public string Tue { get; set; }
    public string Wed { get; set; }
    public string Thu { get; set; }
    public string Fri { get; set; }
    public string Sat { get; set; }
    public string Sun { get; set; }


    public int MonAttnTypeId { get; set; }
    public int TueAttnTypeId { get; set; }
    public int WedAttnTypeId { get; set; }
    public int ThurAttnTypeId { get; set; }
    public int FriAttnTypeId { get; set; }

    public DateTime AttendaneDate { get; set; }
    public int? AttnTypeId { get; set; }
    public int SectionId { get; set; }
    public int Year { get; set; }
    public int WeekNo { get; set; }
    public int Month { get; set; }
    public int CreatedBy { get; set; }
    public int Center_Id { get; set; }
    public int Session_Id { get; set; }
    public int Cal_ID { get; set; }
}