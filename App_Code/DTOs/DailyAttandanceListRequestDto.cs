    using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for DailyAttandanceListRequestDto
/// </summary>
public class DailyAttandanceListRequestDto
{
    public DateTime AttendanceDate { get; set; }
    public int ClassSectionId { get; set; }

}