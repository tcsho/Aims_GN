using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.Http;
using System.Windows.Forms;

public class AmsController : ApiController
{
    private readonly object row;

    [HttpPost]
    public IHttpActionResult GetAllClasses()
    {
        List<ClassSectionDto> classSections = new List<ClassSectionDto>();

        if (MySession.UserTypeId == (int)UserTypesEnum.TR)
        {
            string teacherId = MySession.LoginId;
            BLLTCS_StdAttnType obj = new BLLTCS_StdAttnType();
            DataTable dt = obj.GetSectionClassByTeacher(Convert.ToInt32( teacherId));

            foreach (DataRow row in dt.Rows)
            {
                var section = new ClassSectionDto
                {
                    ClassSectionId = Convert.ToInt32(row["Class_Section_Id"]),
                    Name = row["Name"].ToString()
                };
                classSections.Add(section);
            }
        }
        else
        {
            BLLTCS_StdAttn stdAttn = new BLLTCS_StdAttn
            {
                Center_Id = Convert.ToInt32(MySession.CenterId)
            };
            DataTable dt = stdAttn.TssSelectClassSectionByCenter(stdAttn);
            foreach (DataRow row in dt.Rows)
            {
                var section = new ClassSectionDto
                {
                    ClassSectionId = Convert.ToInt32(row["Class_Section_Id"]),
                    Name = row["Name"].ToString()
                };
                classSections.Add(section);
            }
        }
        return Ok(classSections);
    }

   

    [HttpPost]
    public IHttpActionResult GetWeeklyStudentsAttendance([FromBody] WeeklyAttendanceRequestDto request)
    {
        try
        {
            var response = new List<WeeklyAttendanceListDto>();
            var objbll = new BLLTCS_StdAttn
            {
                Center_Id = Convert.ToInt32(MySession.CenterId)
            };
            objbll.Week = objbll.GetIso8601WeekOfYear(request.Date);
            var currentWeek = objbll.GetIso8601WeekOfYear(DateTime.Now);
            objbll.Month = Convert.ToInt32(request.Date.ToString("MM"));
            objbll.Year = Convert.ToInt32(request.Date.ToString().Substring(request.Date.ToString().LastIndexOf("/") + 1, 4));
            objbll.Section_Id = request.ClassSectionId;
            var dt = objbll.TSSWeeklyStudentAttnSummery(objbll);
            if (objbll.Week == currentWeek && MySession.UserTypeId == (int)UserTypesEnum.CO ||
                objbll.Month == Convert.ToInt32(DateTime.Now.ToString("MM")) && MySession.UserTypeId == (int)UserTypesEnum.CH)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var list = new WeeklyAttendanceListDto();
                    var date = objbll.FirstDayofWeek(objbll.Year, objbll.Week, Application.CurrentCulture);
                    var dates = objbll.DaysInAweek(date);
                    list.WeekNo = objbll.Week;
                    list.StudentId = Convert.ToInt32(dr["Student_Id"].ToString());
                    list.Name = dr["fullname"].ToString();
                    list.Mon = dr["MonAttnTypeId"].ToString() == "" ? "P" : dr["MonAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["MonAttnTypeId"].ToString()));
                    list.Tue = dr["TueAttnTypeId"].ToString() == "" ? "P" : dr["TueAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["TueAttnTypeId"].ToString()));
                    list.Wed = dr["WedAttnTypeId"].ToString() == "" ? "P" : dr["WedAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["WedAttnTypeId"].ToString()));
                    list.Thu = dr["ThurAttnTypeId"].ToString() == "" ? "P" : dr["ThurAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["ThurAttnTypeId"].ToString()));
                    list.Fri = dr["FriAttnTypeId"].ToString() == "" ? "P" : dr["FriAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["FriAttnTypeId"].ToString()));
                    list.Sat = "-";
                    list.Sun = "-";
                    list.MonDate = dates.ToArray()[0];
                    list.TueDate = dates.ToArray()[1];
                    list.WedDate = dates.ToArray()[2];
                    list.ThurDate = dates.ToArray()[3];
                    list.FriDate = dates.ToArray()[4];
                    list.SatDate = dates.ToArray()[5];
                    list.SunDate = dates.ToArray()[6];
                    response.Add(list);
                }
            }
            else
            {
                foreach (DataRow dr in dt.Rows)
                {
                    var list = new WeeklyAttendanceListDto();
                    var date = objbll.FirstDayofWeek(objbll.Year, objbll.Week, Application.CurrentCulture);
                    var dates = objbll.DaysInAweek(date);
                    list.WeekNo = objbll.Week;
                    list.StudentId = Convert.ToInt32(dr["Student_Id"].ToString());
                    list.Name = dr["fullname"].ToString();
                    list.Mon = dr["MonAttnTypeId"].ToString() == "" ? "-" : dr["MonAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["MonAttnTypeId"].ToString()));
                    list.Tue = dr["TueAttnTypeId"].ToString() == "" ? "-" : dr["TueAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["TueAttnTypeId"].ToString()));
                    list.Wed = dr["WedAttnTypeId"].ToString() == "" ? "-" : dr["WedAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["WedAttnTypeId"].ToString()));
                    list.Thu = dr["ThurAttnTypeId"].ToString() == "" ? "-" : dr["ThurAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["ThurAttnTypeId"].ToString()));
                    list.Fri = dr["FriAttnTypeId"].ToString() == "" ? "-" : dr["FriAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(dr["FriAttnTypeId"].ToString()));
                    list.Sat = "-";
                    list.Sun = "-";
                    list.MonDate = dates.ToArray()[0];
                    list.TueDate = dates.ToArray()[1];
                    list.WedDate = dates.ToArray()[2];
                    list.ThurDate = dates.ToArray()[3];
                    list.FriDate = dates.ToArray()[4];
                    list.SatDate = dates.ToArray()[5];
                    list.SunDate = dates.ToArray()[6];
                    list.IsCurrentWeek = true;
                    response.Add(list);
                }
            }
            return Ok(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpPost]
    public IHttpActionResult GetMonthlyStudentsAttendance([FromBody] WeeklyAttendanceRequestDto request)
    {
        try
        {

            MonthAttendanceDataDto response = new MonthAttendanceDataDto();
            List<StudentInfo> students = new List<StudentInfo>();
            var objbll = new BLLTCS_StdAttn
            {
                Center_Id = Convert.ToInt32(MySession.CenterId)
            };


            objbll.Week = objbll.GetIso8601WeekOfYear(request.Date);
            objbll.NumberOfWeek = objbll.GetWeekNumberOfMonth(request.Date);
            objbll.Year = Convert.ToInt32(request.Date.ToString().Substring(request.Date.ToString().LastIndexOf("/") + 1, 4));
            objbll.Month = Convert.ToInt32(request.Date.ToString("MM"));
            objbll.Section_Id = request.ClassSectionId;
            var info = objbll.TSSWeeklyStudentAttnSummery(objbll);
            var monthWeeks = objbll.GetListOfWeeksOfTheMonth(objbll.Month, objbll.Year);
            var weeksOfTheMonth = monthWeeks.Select(w => w.Item1);
            objbll.weekOne = 0;
            objbll.weekTwo = 0;
            objbll.weekThre = 0;
            objbll.weekFour = 0;
            objbll.weekFive = 0;
            if (monthWeeks.Count >= 5)
            {
                objbll.weekOne = weeksOfTheMonth.ToArray()[0];
                objbll.weekTwo = weeksOfTheMonth.ToArray()[1];
                objbll.weekThre = weeksOfTheMonth.ToArray()[2];
                objbll.weekFour = weeksOfTheMonth.ToArray()[3];
                objbll.weekFive = weeksOfTheMonth.ToArray()[4];
            }
            else
            {
                objbll.weekOne = weeksOfTheMonth.ToArray()[0];
                objbll.weekTwo = weeksOfTheMonth.ToArray()[1];
                objbll.weekThre = weeksOfTheMonth.ToArray()[2];
                objbll.weekFour = weeksOfTheMonth.ToArray()[3];
            }
            response.AttendanceMonth = objbll.Month;
            var infoDetail = new DataTable();
            foreach (DataRow row in info.Rows)
            {
                StudentInfo student = new StudentInfo();
                student.StudentId = Convert.ToInt32(row["Student_Id"].ToString());
                student.Name = row["fullName"].ToString();
                objbll.Student_Id = student.StudentId;

                infoDetail = objbll.TSSMonthlyStudentAttnDetail(objbll);

                student.Week = new List<WeekAttendanceDataDto>();
                IEnumerable<DataRow> studentData = infoDetail.AsEnumerable();

                var result = weeksOfTheMonth.Where(p => !studentData.Any(p2 => Convert.ToInt32(p2["WeekNo"].ToString()) == p));

                var currentMonth = Convert.ToInt32(DateTime.Now.ToString("MM"));
                var currentYear = Convert.ToInt32(DateTime.Now.ToString("yyyy"));
                foreach (DataRow row2 in infoDetail.Rows)
                {

                    if (objbll.Month == currentMonth && objbll.Year == currentYear && MySession.UserTypeId == (int)UserTypesEnum.CH)
                    {
                        var date = objbll.FirstDayofWeek(objbll.Year, Convert.ToInt32(row2["WeekNo"].ToString()), Application.CurrentCulture);
                        var dates = objbll.DaysInAweek(date);

                        WeekAttendanceDataDto list = new WeekAttendanceDataDto();
                        list.WeekNo = Convert.ToInt32(row2["WeekNo"].ToString());
                        list.Mon = row2["MonAttnTypeId"].ToString() == "" ? "P" : row2["MonAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["MonAttnTypeId"].ToString()));
                        list.Tue = row2["TueAttnTypeId"].ToString() == "" ? "P" : row2["TueAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["TueAttnTypeId"].ToString()));
                        list.Wed = row2["WedAttnTypeId"].ToString() == "" ? "P" : row2["WedAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["WedAttnTypeId"].ToString()));
                        list.Thu = row2["ThurAttnTypeId"].ToString() == "" ? "P" : row2["ThurAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["ThurAttnTypeId"].ToString()));
                        list.Fri = row2["FriAttnTypeId"].ToString() == "" ? "P" : row2["FriAttnTypeId"].ToString() == "0" ? "P" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["FriAttnTypeId"].ToString()));
                        list.Sat = "-";
                        list.Sun = "-";
                        list.MonDate = dates.ToArray()[0];
                        list.TueDate = dates.ToArray()[1];
                        list.WedDate = dates.ToArray()[2];
                        list.ThurDate = dates.ToArray()[3];
                        list.FriDate = dates.ToArray()[4];
                        list.SatDate = dates.ToArray()[5];
                        list.SunDate = dates.ToArray()[6];
                        student.Week.Add(list);
                    }
                    else
                    {
                        var date = objbll.FirstDayofWeek(objbll.Year, Convert.ToInt32(row2["WeekNo"].ToString()), Application.CurrentCulture);
                        var dates = objbll.DaysInAweek(date);
                        WeekAttendanceDataDto list = new WeekAttendanceDataDto();
                        list.WeekNo = Convert.ToInt32(row2["WeekNo"].ToString());
                        list.Mon = row2["MonAttnTypeId"].ToString() == "" ? "P" : row2["MonAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["MonAttnTypeId"].ToString()));
                        list.Tue = row2["TueAttnTypeId"].ToString() == "" ? "P" : row2["TueAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["TueAttnTypeId"].ToString()));
                        list.Wed = row2["WedAttnTypeId"].ToString() == "" ? "P" : row2["WedAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["WedAttnTypeId"].ToString()));
                        list.Thu = row2["ThurAttnTypeId"].ToString() == "" ? "P" : row2["ThurAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["ThurAttnTypeId"].ToString()));
                        list.Fri = row2["FriAttnTypeId"].ToString() == "" ? "P" : row2["FriAttnTypeId"].ToString() == "0" ? "-" : AmsDictionary.GetAttendanceTypeToDisplay(Convert.ToInt32(row2["FriAttnTypeId"].ToString()));
                        list.Sat = "-";
                        list.Sun = "-";
                        list.MonDate = dates.ToArray()[0];
                        list.TueDate = dates.ToArray()[1];
                        list.WedDate = dates.ToArray()[2];
                        list.ThurDate = dates.ToArray()[3];
                        list.FriDate = dates.ToArray()[4];
                        list.SatDate = dates.ToArray()[5];
                        list.SunDate = dates.ToArray()[6];
                        response.IsOldData = true;
                        student.Week.Add(list);
                    }
                }

                for (var i = 0; i < result.Count(); i++)
                {
                    if (objbll.Month == currentMonth && objbll.Year == currentYear && MySession.UserTypeId == (int)UserTypesEnum.CH)
                    {
                        var date = objbll.FirstDayofWeek(objbll.Year, result.ToArray()[i], Application.CurrentCulture);
                        var dates = objbll.DaysInAweek(date);
                        WeekAttendanceDataDto list = new WeekAttendanceDataDto();
                        list.WeekNo = result.ToArray()[i];
                        list.Mon = "P";
                        list.Tue = "P";
                        list.Wed = "P";
                        list.Thu = "P";
                        list.Fri = "P";
                        list.Sat = "-";
                        list.Sun = "-";
                        list.MonDate = dates.ToArray()[0];
                        list.TueDate = dates.ToArray()[1];
                        list.WedDate = dates.ToArray()[2];
                        list.ThurDate = dates.ToArray()[3];
                        list.FriDate = dates.ToArray()[4];
                        list.SatDate = dates.ToArray()[5];
                        list.SunDate = dates.ToArray()[6];
                        response.IsOldData = false;
                        student.Week.Add(list);
                        student.Week.OrderBy(x => x.WeekNo);
                    }
                    else
                    {
                        var date = objbll.FirstDayofWeek(objbll.Year, result.ToArray()[i], Application.CurrentCulture);
                        var dates = objbll.DaysInAweek(date);
                        WeekAttendanceDataDto list = new WeekAttendanceDataDto();
                        list.WeekNo = result.ToArray()[i];
                        list.Mon = "-";
                        list.Tue = "-";
                        list.Wed = "-";
                        list.Thu = "-";
                        list.Fri = "-";
                        list.Sat = "-";
                        list.Sun = "-";
                        list.MonDate = dates.ToArray()[0];
                        list.TueDate = dates.ToArray()[1];
                        list.WedDate = dates.ToArray()[2];
                        list.ThurDate = dates.ToArray()[3];
                        list.FriDate = dates.ToArray()[4];
                        list.SatDate = dates.ToArray()[5];
                        list.SunDate = dates.ToArray()[6];
                        response.IsOldData = true;
                        student.Week.Add(list);
                        student.Week.OrderBy(x => x.WeekNo);
                    }
                }
                var test = student.Week.OrderBy(x => x.WeekNo).ToList();
                student.Week = test;
                students.Add(student);
            }
            students.ForEach(w => w.Week.OrderBy(e => e.WeekNo));
            response.StudentInfo = students;
            return Json(response);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }

    [HttpPost]
    public IHttpActionResult SaveMonthlyData([FromBody]MonthAttendanceDataDto request)
    {
        SuccessDto success = new SuccessDto();
        try
        {
            if (MySession.UserTypeId == (int)UserTypesEnum.CH)
            {
                const string type = "Monthly";
                AttendanceDto attendance = new AttendanceDto
                {
                    InfoDetail = new List<StudentAttendanceDataDetail>(),
                    AttendanceDate = request.AttendanceDate
                };
                foreach (var req in request.StudentInfo)
                {
                    attendance.InfoDetail = req.Week.Select(x => new StudentAttendanceDataDetail()
                    {
                        RollNumber = req.StudentId,
                        SectionId = request.SectionId,
                        WeekNo = x.WeekNo.Value,
                        Mon = x.Mon,
                        Tue = x.Tue,
                        Wed = x.Wed,
                        Thu = x.Thu,
                        Fri = x.Fri,
                        Sat = x.Sat,
                        Sun = x.Sun
                    }).ToList();
                    success = SaveAttendance(type, attendance);
                }
            }
            else
            {
                success.IsSuccess = false;
                success.Message = "You are not authorized to modify this data.";
                return Ok(success);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Something went wrong! Go to your server administrator.", ex);
        }
        success.IsSuccess = true;
        return Ok(success);
    }

    [HttpPost]
    public IHttpActionResult SaveStudentAttendanceWeekly(AttendanceDto request)
    {
        SuccessDto success = new SuccessDto();
        try
        {

            if (MySession.UserTypeId == (int)UserTypesEnum.CO || MySession.UserTypeId == (int)UserTypesEnum.CH)
            {
                const string type = "Weekly";
                success = SaveAttendance(type, request);

            }
            else
            {
                success.IsSuccess = false;
                success.Message = "You are not authorized to modify this data";
                return Ok(success);
            }

        }
        catch (Exception ex)
        {
            throw new Exception("Something went wrong! Go to your server administrator.", ex);
        }
        success.IsSuccess = true;
        return Ok(success);
    }

    public SuccessDto SaveAttendance(string saveType, AttendanceDto attendance)
    {
        SuccessDto success = new SuccessDto();
        DataTable dtfill = new DataTable();
        DataRow userrow = MySession.Row;
        BLLTCS_StdAttn objbll = new BLLTCS_StdAttn();
        BLLTCS_StdAttnCalender bll = new BLLTCS_StdAttnCalender();
        DataTable dtbll = new DataTable();
        bll.CalDate = attendance.AttendanceDate.ToString().Trim().Replace("'", "");
        bll.Center_Id = Convert.ToInt32(MySession.CenterId);
        dtbll = bll.TCS_StdAttnCalenderSelectCal_IDByDateCenter(bll);
        if (dtbll.Rows.Count > 0)
        {
            attendance.Cal_Id = int.Parse(dtbll.Rows[0]["Cal_ID"].ToString());
            attendance.CalDayType_Id = dtbll.Rows[0]["CalDayType_Id"].ToString();
            attendance.CalDayDesc = dtbll.Rows[0]["CalTypeDesc"].ToString();
        }
        else
        {
            success.IsWarning = true;
            success.Message = "Please add Academic Calendar First for this Center";
        }

        if (attendance.CalDayType_Id == "")
        {
            if (saveType == "Weekly")
            {
                attendance.InfoDetail = new List<StudentAttendanceDataDetail>();
            }
            if (attendance.InfoDetail.Count <= 0)
            {
                attendance.InfoDetail = attendance.Info.Select(x => new StudentAttendanceDataDetail()
                {
                    RollNumber = x.StudentId,
                    Mon = x.Mon,
                    Tue = x.Tue,
                    Wed = x.Wed,
                    Thu = x.Thu,
                    Fri = x.Fri,
                    Sat = x.Sat,
                    Sun = x.Sun

                }).ToList();
            }
            foreach (var info in attendance.InfoDetail)
            {
                if (saveType == "Daily")
                {
                    if (attendance.AttendanceDate.ToString("ddd") == "Mon")
                    {
                        info.MonAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Mon);
                    }

                    if (attendance.AttendanceDate.ToString("ddd") == "Tue")
                    {
                        info.TueAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Tue);
                    }
                    if (attendance.AttendanceDate.ToString("ddd") == "Wed")
                    {
                        info.WedAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Wed);
                    }
                    if (attendance.AttendanceDate.ToString("ddd") == "Thu")
                    {
                        info.ThurAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Thu);
                    }
                    if (attendance.AttendanceDate.ToString("ddd") == "Fri")
                    {
                        info.FriAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Fri);
                    }

                }
                else
                {
                    info.MonAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Mon);
                    info.TueAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Tue);
                    info.WedAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Wed);
                    info.ThurAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Thu);
                    info.FriAttnTypeId = AmsDictionary.GetAttandanceTypeIdToDisplay(info.Fri);
                }
                if (attendance.SectionId != 0)
                {
                    info.SectionId = attendance.SectionId;
                }
                BLLSession objSes = new BLLSession
                {
                    Center_Id = Convert.ToInt32(MySession.CenterId)
                };
                DataTable dtSes = objSes.SessionSelectActiveByCenter(objSes);
                if (dtSes.Rows.Count > 0)
                {
                    info.Session_Id = Convert.ToInt32(dtSes.Rows[0]["Session_Id"].ToString());
                }
                info.Cal_ID = attendance.Cal_Id;
                info.AttendaneDate = attendance.AttendanceDate;
                if (info.WeekNo == 0)
                {
                    info.WeekNo = objbll.GetIso8601WeekOfYear(attendance.AttendanceDate);
                }
                info.Year = Convert.ToInt32(attendance.AttendanceDate.ToString().Substring(attendance.AttendanceDate.ToString().LastIndexOf("/") + 1, 4));
                info.Month = Convert.ToInt32(attendance.AttendanceDate.ToString("MM"));
                info.CreatedBy = MySession.ContactId;
                info.AttnTypeId = 1;
                DataTable check = bll.CheckAttendanceAlreadyExist(info.RollNumber, info.Year, info.WeekNo, info.Month, info.Session_Id);
                if (check.Rows.Count <= 0)
                {
                    bll.AddStudentAttendanceDataWeekly(info);
                }
                else
                {
                    if (saveType == "Daily")
                    {
                        bll.UpdateStudentAttendanceDaily(info);
                    }
                    else
                    {
                        bll.UpdateStudentAttendanceDataWeekly(info);
                    }
                }
            }
        }
        success.IsSuccess = true;
        success.IsWarning = false;
        success.IsError = false;
        success.Message = "Data has been saved successfully!";
        return success;
    }

    [HttpPost]
    public IHttpActionResult GetAttnTypeMonthly() //SFA
    {
        BLLTCS_StdAttnType obj = new BLLTCS_StdAttnType();
        DataTable dt = obj.TCS_StdAttnTypeSelectAll();
        return Json(dt);
    }

    [HttpPost]
    public IHttpActionResult GetUserTypeId() //SFA
    {
        return Ok(MySession.UserTypeId);
    }

    [HttpPost]
    public IHttpActionResult GetAttendanceType() //SFA
    {
        BLLTCS_StdAttnType obj = new BLLTCS_StdAttnType();
        DataTable dt = obj.TCS_StdAttnTypeSelectAll();
        StringBuilder strHTMLBuilder = new StringBuilder();
        strHTMLBuilder.Append("<select>");
        foreach (DataRow row in dt.Rows)
        {
            strHTMLBuilder.Append("<option value=");
            strHTMLBuilder.Append(row["AttnType_ID"].ToString());
            strHTMLBuilder.Append(">");
            strHTMLBuilder.Append(row["AttnDesc"].ToString());
            strHTMLBuilder.Append("</option>");
        }
        strHTMLBuilder.Append("</select>");
        string Htmltext = strHTMLBuilder.ToString();
        return Json(Htmltext);
    }

    [HttpPost]
    public IHttpActionResult GetDailyAttendance([FromBody] DailyAttandanceListRequestDto request)
    {
        var objbll = new BLLTCS_StdAttn();
        var response = new List<DailyAttandanceListDto>();
        try
        {
            objbll.Week = objbll.GetIso8601WeekOfYear(request.AttendanceDate);
            objbll.Year = Convert.ToInt32(request.AttendanceDate.ToString().Substring(request.AttendanceDate.ToString().LastIndexOf("/") + 1, 4));
            objbll.Month = Convert.ToInt32(request.AttendanceDate.ToString("MM"));
            objbll.Section_Id = request.ClassSectionId;
            var today = DateTime.Now.ToString("MM-dd-yyyy");
            var requestDate = request.AttendanceDate.ToString("MM-dd-yyyy");
            if (requestDate == today) //&& MySession.UserTypeId == (int)UserTypesEnum.TR
            {
                var date = request.AttendanceDate.ToString("ddd");
                DataTable dt = objbll.TSSWeeklyStudentAttnSummery(objbll);
                if (date == "Thu")
                {
                    date = date + "r";
                }
                date = date + "AttnTypeId";
                if (date == "Sun" || date == "Sat")
                {
                    var dailyAttendace = (from studentAttendance in dt.AsEnumerable()
                                          select new DailyAttandanceListDto
                                          {
                                              StudentId = studentAttendance.Field<int>("Student_Id"),
                                              Name = studentAttendance.Field<string>("fullname"),
                                              Day = "-"
                                          }).ToList();
                    response = dailyAttendace;
                }
                else
                {

                    var dailyAttendace = (from studentAttendance in dt.AsEnumerable()
                                          select new DailyAttandanceListDto
                                          {
                                              StudentId = studentAttendance.Field<int>("Student_Id"),
                                              Name = studentAttendance.Field<string>("fullname"),
                                              Day = studentAttendance.Field<int?>(date) == null ? "P"
                                              : AmsDictionary.GetAttendanceTypeToDisplay(studentAttendance.Field<int>(date))
                                          }).ToList();
                    response = dailyAttendace;
                }

            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return Ok(response);
    }

    [HttpPost]
    public IHttpActionResult SaveStudentAttendaceDailyData([FromBody]DailyAttendanceSaveDto request)
    {
        SuccessDto success = new SuccessDto();
        try
        {
            const string type = "Daily";
            AttendanceDto attendance = new AttendanceDto
            {
                InfoDetail = new List<StudentAttendanceDataDetail>(),
                AttendanceDate = request.AttendanceDate
            };
            var objbll = new BLLTCS_StdAttn();
            var day = request.AttendanceDate.ToString("ddd");
            if (day == "Mon")
            {
                foreach (var req in request.AttendanceList)
                {
                    var detial = new StudentAttendanceDataDetail
                    {
                        RollNumber = req.StudentId,
                        SectionId = request.ClassSectionId,
                        WeekNo = objbll.GetIso8601WeekOfYear(request.AttendanceDate),
                        Mon = req.Day
                    };
                    attendance.InfoDetail.Add(detial);
                }
                success = SaveAttendance(type, attendance);

            }
            if (day == "Tue")
            {
                foreach (var req in request.AttendanceList)
                {
                    var detial = new StudentAttendanceDataDetail
                    {
                        RollNumber = req.StudentId,
                        SectionId = request.ClassSectionId,
                        WeekNo = objbll.GetIso8601WeekOfYear(request.AttendanceDate),
                        Tue = req.Day
                    };
                    attendance.InfoDetail.Add(detial);
                }
                success = SaveAttendance(type, attendance);
            }

            if (day == "Wed")
            {
                foreach (var req in request.AttendanceList)
                {
                    var detial = new StudentAttendanceDataDetail
                    {
                        RollNumber = req.StudentId,
                        SectionId = request.ClassSectionId,
                        WeekNo = objbll.GetIso8601WeekOfYear(request.AttendanceDate),
                        Wed = req.Day
                    };
                    attendance.InfoDetail.Add(detial);
                }
                success = SaveAttendance(type, attendance);
            }
            if (day == "Thu")
            {
                foreach (var req in request.AttendanceList)
                {
                    var detial = new StudentAttendanceDataDetail
                    {
                        RollNumber = req.StudentId,
                        SectionId = request.ClassSectionId,
                        WeekNo = objbll.GetIso8601WeekOfYear(request.AttendanceDate),
                        Thu = req.Day
                    };
                    attendance.InfoDetail.Add(detial);
                }
                success = SaveAttendance(type, attendance);
            }
            if (day == "Fri")
            {
                foreach (var req in request.AttendanceList)
                {
                    var detial = new StudentAttendanceDataDetail
                    {
                        RollNumber = req.StudentId,
                        SectionId = request.ClassSectionId,
                        WeekNo = objbll.GetIso8601WeekOfYear(request.AttendanceDate),
                        Wed = req.Day
                    };
                    attendance.InfoDetail.Add(detial);
                }
                success = SaveAttendance(type, attendance);
            }
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to save Data go to your server administrator.", ex);
        }
        return Ok(success);
    }

}