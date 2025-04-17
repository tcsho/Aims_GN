using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class DailyAttendanceSaveDto
{
    public int ClassSectionId { get; set; }
    public DateTime AttendanceDate { get; set; }
    public List<DailyAttandanceListDto> AttendanceList { get; set; }
}