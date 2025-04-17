using System;

public class WeeklyAttendanceListDto
{
    public int StudentId { get; set; }
    public string Name { get; set; }

    public int? WeekNo { get; set; }
    public string Mon { get; set; }
    public string Tue { get; set; }
    public string Wed { get; set; }
    public string Thu { get; set; }
    public string Fri { get; set; }
    public string Sat { get; set; }
    public string Sun { get; set; }

    public int? MonAttnTypeId { get; set; }
    public int? TueAttnTypeId { get; set; }
    public int? WedAttnTypeId { get; set; }
    public int? ThurAttnTypeId { get; set; }
    public int? FriAttnTypeId { get; set; }

    public bool IsCurrentWeek { get; set; }

    public DateTime MonDate { get; set; }
    public DateTime TueDate { get; set; }
    public DateTime WedDate { get; set; }
    public DateTime ThurDate { get; set; }
    public DateTime FriDate { get; set; }
    public DateTime SatDate { get; set; }
    public DateTime SunDate { get; set; }
}