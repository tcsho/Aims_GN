using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;

/// <summary>
/// Summary description for BLLStdAttn
/// </summary>
public class BLLTCS_StdAttn
{
    _DALTCS_StdAttn objdal = new _DALTCS_StdAttn();

    public BLLTCS_StdAttn()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public int weekOne { get; set; }
    public int weekTwo { get; set; }
    public int  weekThre { get; set; }
    public int weekFour { get; set; }
    public int weekFive { get; set; }

    public int Week { get; set; }
    public int Attn_ID { get { return attn_ID; } set { attn_ID = value; } }
    private int attn_ID;
    public int Cal_ID { get { return cal_ID; } set { cal_ID = value; } }
    private int cal_ID;
    public string AttnDate { get { return attnDate; } set { attnDate = value; } }
    private string attnDate;
    public int AttnType_Id { get { return attnType_Id; } set { attnType_Id = value; } }
    private int attnType_Id;
    public int Student_Id { get { return student_Id; } set { student_Id = value; } }
    private int student_Id;
    public int CreatedBy { get { return createdBy; } set { createdBy = value; } }
    private int createdBy;
    public DateTime CreatedOn { get { return createdOn; } set { createdOn = value; } }
    private DateTime createdOn;
    public int ModifiedBy { get { return modifiedBy; } set { modifiedBy = value; } }
    private int modifiedBy;
    public DateTime ModifiedOn { get { return modifiedOn; } set { modifiedOn = value; } }
    private DateTime modifiedOn;
    public int Center_Id { get { return center_Id; } set { center_Id = value; } }
    private int center_Id;
    public int Month { get { return month; } set { month = value; } }
    private int month;
    public int Section_Id { get { return section_Id; } set { section_Id = value; } }
    private int section_Id;
    public int Section_Subject_Id { get { return section_Subject_Id; } set { section_Subject_Id = value; } }
    private int section_Subject_Id;

    public int Session_Id { get { return session_Id; } set { session_Id = value; } }
    private int session_Id;
    public bool SentStatus { get { return sentStatus; } set { sentStatus = value; } }
    private bool sentStatus;

    public DateTime SmsSentOn { get { return smsSentOn; } set { smsSentOn = value; } }
    private DateTime smsSentOn;
    public int SmsSentBy { get { return smsSentBy; } set { smsSentBy = value; } }



    private int smsSentBy;
    public int Year { get; set; }

    public DateTime date { get; set; }
    public int parm { get; set; }


    public int Class_Section_Id { get; set; }
    public int NumberOfWeek { get; set; }

    public int TCS_StdAttnInsert(BLLTCS_StdAttn objbll)
    {
        return objdal.TCS_StdAttnInsert(objbll);
    }
    public int TCS_StdAttnUpdate(BLLTCS_StdAttn objbll)
    {
        return objdal.TCS_StdAttnUpdate(objbll);
    }
    public DataTable TSSMonthlyAttnSummery(BLLTCS_StdAttn objbll)
    {
        return objdal.TSSMonthlyAttnSummery(objbll);
    }


    internal DataTable TSSMonthlyStudentAttnSummery(BLLTCS_StdAttn objbll)
    {
        return objdal.TSSMonthlyStudentAttnSummery(objbll);
    }

    // This presumes that weeks start with Monday.
    // Week 1 is the 1st week of the year with a Thursday in it.
    public int GetIso8601WeekOfYear(DateTime time)
    {
        // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
        // be the same week# as whatever Thursday, Friday or Saturday are,
        // and we always get those right
        DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
        if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
        {
            time = time.AddDays(3);
        }

        // Return the week of our adjusted day
        return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
    }

    public int GetWeekNumberOfMonth(DateTime date)
    {
        DateTime today = date;
        //extract the month
        int daysInMonth = DateTime.DaysInMonth(today.Year, today.Month);
        DateTime firstOfMonth = new DateTime(today.Year, today.Month, 1);
        //days of week starts by default as Sunday = 0
        int firstDayOfMonth = (int)firstOfMonth.DayOfWeek;
        int weeksInMonth = (int)Math.Ceiling((firstDayOfMonth + daysInMonth) / 7.0);
        return weeksInMonth;
    }

    public List<DateTime> DaysInAweek(DateTime date)
    {
        DateTime today = date;
        int currentDayOfWeek = (int)today.DayOfWeek;
        DateTime sunday = today.AddDays(-currentDayOfWeek);
        DateTime monday = sunday.AddDays(1);
        // If we started on Sunday, we should actually have gone *back*
        // 6 days instead of forward 1...
        if (currentDayOfWeek == 0)
        {
            monday = monday.AddDays(-7);
        }
        var dates = Enumerable.Range(0, 7).Select(days => monday.AddDays(days)).ToList();
        return dates;
    }


    public DateTime FirstDayofWeek(int year, int weekNumber, System.Globalization.CultureInfo culture)
    {
        System.Globalization.Calendar calendar = culture.Calendar;
        DateTime firstOfYear = new DateTime(year, 1, 1, calendar);
        DateTime targetDay = calendar.AddWeeks(firstOfYear, weekNumber);
        DayOfWeek firstDayOfWeek = culture.DateTimeFormat.FirstDayOfWeek;

        while (targetDay.DayOfWeek != firstDayOfWeek)
        {
            targetDay = targetDay.AddDays(-1);
        }

        return targetDay;
    }


    public List<Tuple<int, DateTime, DateTime>> GetListOfWeeksOfTheMonth(int currentMonth, int currentYear)
    {
        //Get List of Weeks of the current Month.....
        int month = currentMonth;
        int year = currentYear;
        var cal = CultureInfo.CurrentCulture.Calendar;

        IEnumerable<int> daysInMonth = Enumerable.Range(1, cal.GetDaysInMonth(year, month));
        List<Tuple<int, DateTime, DateTime>> listOfWorkWeeks = daysInMonth.Select(day =>
        new DateTime(year, month, day)).GroupBy(d => cal.GetWeekOfYear(d, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday))
        .Select(g => Tuple.Create(g.Key, g.First(),
        g.Last(d => d.DayOfWeek != DayOfWeek.Saturday && d.DayOfWeek != DayOfWeek.Sunday))).ToList();
        // Item1 = week in year, Item2 = first day, Item3 = last working day int weekNum = 1;

        return listOfWorkWeeks;
    }


    public DataTable TssSelectClassSectionByCenter(BLLTCS_StdAttn objbll)
    {

        return objdal.TssSelectClassSectionByCenter(objbll);
    }


    public DataTable TssStudentSelectByClassSectionIdForAttendance(BLLTCS_StdAttn objbll)
    {
        return objdal.TssStudentSelectByClassSectionIdForAttendance(objbll);
    }

    public DataTable TssStudentSelectByClassSectionIdForAttendanceExisting(BLLTCS_StdAttn obj)
    {
        return objdal.TssStudentSelectByClassSectionIdForAttendanceExisting(obj);
    }

    public DataTable TCS_StdAttnDailyRptAttnTypeWise(BLLTCS_StdAttn objbll)
    {
        return objdal.TCS_StdAttnDailyRptAttnTypeWise(objbll);
    }


    public DataTable SendSMSByCenterClassDate(BLLTCS_StdAttn objbll)
    {
        return objdal.SendSMSByCenterClassDate(objbll);
    }

    public int SendSMSUpdateStatus(BLLTCS_StdAttn objbll)
    {
        return objdal.SendSMSUpdateStatus(objbll);
    }

    public DataTable SendSMSByCenterDate(BLLTCS_StdAttn objbll)
    {
        return objdal.SendSMSByCenterDate(objbll);
    }
    public DataTable TSSWeeklyStudentAttnSummery(BLLTCS_StdAttn objbll)
    {
        return objdal.TSSWeeklyStudentAttnSummery(objbll);
    }

    public DataTable TSSMonthlyStudentAttnDetail(BLLTCS_StdAttn objbll)
    {
        return objdal.TSSWeeklyStudentAttnDetail(objbll);
    }

    public DataTable TSSWeeklyAttnSummery(BLLTCS_StdAttn objbll)
    {
        return objdal.TSSWeeklyAttnSummery(objbll);
    }

    internal DataTable GetDailyAttendance(int attYear, int attMonth, int attWeek, string v)
    {
        throw new NotImplementedException();
    }
}
