<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PresentationLayer/MasterPage.master"
    CodeFile="AttendanceManagementSystem.aspx.cs" Inherits="PresentationLayer_AMS_AttendanceManagementSystem" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <!DOCTYPE html>
    <html>
    <head>
        <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
        <title>AMS</title>
        <link href="../AMSScripts/css/jm.spinner.css" rel="stylesheet" />
        <link href="../AMSScripts/css/datatables.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="../AMSScripts/css/datatables.min.css" />
        <link rel="stylesheet" href="../AMSScripts/css/fixedColumns.dataTables.min.css" />
        <link rel="stylesheet" href="../AMSScripts/css/animate.min.css" />
        <link rel="stylesheet" href="../AMSScripts/css/colors.min.css" />
        <link rel="stylesheet" href="../AMSScripts/css/components.min.css" />
        <link rel="stylesheet" href="../AMSScripts/css/layout.min.css" />
        <link rel="stylesheet" href="../AMSScripts/plugin/datepicker/dist/css/default/zebra_datepicker.min.css" />
        <link rel="stylesheet" href="../AMSScripts/css/bootstrap.min.css" />
        <link href="../../content/toastr.min.css" rel="stylesheet" />
        <link rel="stylesheet" href="../AMSScripts/css/ams.css" />
    </head>

    <body>

        <div class="page-content">
            <div class="content-wrapper">
                <div class="content">

                    <!-- Inner container -->
                    <div class="d-flex align-items-start flex-column flex-md-row">

                        <!-- Left content -->
                        <div class="w-100 overflow-auto order-2 order-md-1">
                            <div class="">
                                <div class="custom_card">
                                    <div class="card_panel">
                                        <div class="card_panel_head">
                                            <div class="panel_head_caption">
                                                <h4>AMS</h4>
                                            </div>
                                        </div>
                                        <div class="card_panel_body">
                                            <div class="panel_body_content">
                                                <div class="row">
                                                    <div class="col-md-12 pull-left">
                                                        <div class="col-md-4 pull-left">
                                                            <div class="form-group">
                                                                <label class="control-label pull-left text-left">View As</label>
                                                                <div class="col-md-9">
                                                                    <select id="view_as" name="" class=" form-control form-control-inline">
                                                                        <option value="select">Select View</option>
                                                                        <option value="daily">Daily</option>
                                                                        <option value="weekly">Weekly</option>
                                                                        <option value="monthly">Monthly</option>
                                                                    </select>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 pull-left">
                                                            <div class="form-group">
                                                                <div class="col-md-12">
                                                                    <label class="control-label pull-left text-left">Class</label>
                                                                    <div class="col-md-10">
                                                                        <select name="" class=" form-control form-control-inline" id="select_class">
                                                                        </select>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 pull-left datepicker_selection datepickerweekly daily">
                                                            <div class="form-group">
                                                                <label class="control-label pull-left text-left">Date</label>
                                                                <div class="col-md-7">
                                                                    <input id="dailyDate" type="text" class="form-control datePicker_input" data-zdp_readonly_element="false" disabled>
                                                                </div>
                                                                <div class="col-md-1 pull-right">
                                                                    <button class="showTable btn green hide pull-right" id="dailyButton" type="submit">Show</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 pull-left datepicker_selection datepickerweekly weekly">
                                                            <div class="form-group">
                                                                <label class="control-label pull-left text-left">Date</label>
                                                                <div class="col-md-7">
                                                                    <input id="datepicker" type="text" class="form-control datePicker_input" data-zdp_readonly_element="false">
                                                                </div>
                                                                <div class="col-md-1 pull-right">
                                                                    <button class="showTable btn green hide pull-right" id="showButton" type="submit">Show</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4 pull-left datepicker_selection datepickermonthly monthly">
                                                            <div class="form-group">
                                                                <label class="control-label pull-left text-left">Month</label>
                                                                <div class="col-md-7">
                                                                    <input id="monthChange" type="text" class="form-control datePicker_input" data-zdp_readonly_element="false" placeholder="Please select month">
                                                                </div>
                                                                <div class="col-md-1 pull-right">
                                                                    <button class="showTable btn green hide pull-right" id="monthButton" type="submit">Show</button>
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-12 pull-left">
                                                        <div class="col-md-4 pull-left">
                                                            <label style="font-size: 13px">Current Month:</label>
                                                            <span style="font-size: 13px" id="output"></span>
                                                            <span class="selected_dateFrom"></span>
                                                            <span class="selected_dateTo"></span>
                                                        </div>
                                                        <div class="col-md-4 pull-left" style="padding-left: 29px">
                                                            <label style="font-size: 13px">Current Week No: </label>
                                                            <span style="font-size: 13px" class="" id="currentWeekNo"></span>
                                                            <label>-</label>
                                                            <span class="" id="selectedWeek"></span>
                                                        </div>
                                                        <div class="col-md-2 pull-left">
                                                        </div>
                                                        <div class="col-md-2 pull-right" style="margin-bottom: 10px; padding-right: 0px">
                                                            <button class="btn btn-primary hide  pull-right " style="background-color: #0C4DA2" id="btnSaveDailyData">Save</button>
                                                            <button class="btn btn-primary hide pull-right" onclick="savedata()" style="background-color: #0C4DA2" id="btnSave">Save</button>
                                                            <button class="btn btn-primary hide pull-right" style="background-color: #0C4DA2" id="btnMonthlySave">Save</button>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div id="" class="newTable daily_table">
                                                    <div class="block_head" id="">
                                                    </div>
                                                    <div class="attendance_body" id="dailyAttendance_body" style="font-size: 12px">
                                                    </div>
                                                </div>
                                                <div id="" class="newTable weekly_table">
                                                    <div class="week_name1">
                                                    </div>
                                                    <div class="block_head" id="">
                                                    </div>
                                                    <div class="attendance_body" id="weekAttendance_body" style="font-size: 12px">
                                                    </div>
                                                </div>
                                                <div id="" class="newTable monthly_table">
                                                    <div class="week_name">
                                                    </div>
                                                    <div class="week_days">
                                                    </div>
                                                    <div class="block_head" id="blockHead">
                                                    </div>
                                                    <div class="attendance_body" id="attendance_body" style="font-size: 12px">
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="loading" class="hide">
            <div class="loadingDiv"></div>
        </div>
    </body>
    </html>
    <script type="text/javascript">
        var attnData = '';
        var existingData = '';
        var weeklyNewData = '';
        var newWeekHtmlDdl = '';
        var UserTypeId = '';
        var dailyData = '';
        window.onload = function () {
            $(document).on('click', '.attendance_body .block_body .body_column .attendence_block', function () {
                $(this).parent().css('box-shadow', 'inset 1px 1px 1px 2px rgba(12, 77, 162, 0.14)');
            });

            //Current Month of the year
            var months = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August', 'September', 'October', 'November', 'December'];;
            var date = new Date();
            document.getElementById('output').innerHTML = months[date.getMonth()] + ' ' + date.getFullYear();

            //Load Attendance Types
            $.ajax({
                type: "POST",
                url: "/api/Ams/GetAttnTypeMonthly",
                dataType: "json",
                success: function (ddl) {
                    newWeekHtmlDdl = '';
                    for (i in ddl) {
                        newWeekHtmlDdl += "<option value='" + ddl[i].AttCode + "'>" + ddl[i].AttCode + "</option>"
                    }
                }
            });

            //Get All Classes and sections of the current campus
            $.ajax({
                type: "POST",
                url: "/api/Ams/GetAllClasses",
                dataType: "json",
                success: function (data) {
                    $.each(data, function (i, obj) {
                        var div_data = "<option value=" + obj.classSectionId + ">" + obj.name + "</option>";
                        $("#select_class").append(div_data);
                    });
                }
            });         

            // Get Current User Type Id
            $.ajax({
                type: "POST",
                url: "/api/Ams/GetUserTypeId",
                dataType: "json",
                success: function (data) {
                    UserTypeId = data;
                }
            });
        };

        var data;
        $("#monthButton").click(function () {
            console.log(UserTypeId);
            $('#loading .loadingDiv').addClass('loader').parent().removeClass('hide');
            $('#btnSave').addClass('hide');
            $('.monthly_table').removeClass('hide');
            $('.head_columns').removeClass('hide');
            var today = $('#datepicker').val();
            var currentMonth = today.substr(5, 2);
            var currentYear = today.substr(0, 4);
            var currentFull = currentMonth + '-' + currentYear;
            var monthDate = $('#monthChange').val();
            var existingMon = monthDate.substr(0, 2);
            var existingYear = monthDate.substr(3, 5);
            var existingFull = existingMon + '-' + existingYear;
            if (UserTypeId == userTypeEnum.CO || UserTypeId == userTypeEnum.TR) {
                existingMonth();
                return;
            }
            if (existingFull != '-' && UserTypeId) {
                if (currentFull != existingFull) {
                    existingMonth();
                    return;
                }
            }
            var object = {
                ClassSectionId: $('#select_class').val(),
                Date: $('#datepicker').val()
            }
            $.ajax({
                type: 'POST',
                url: '/api/Ams/GetMonthlyStudentsAttendance',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(object),
                success: function (newData) {
                    existingData = newData;
                    data = newData;
                    if (data.IsOldData == false) {
                        $('#btnMonthlySave').removeClass('hide');
                    }
                    var html = '';
                    $('#attendance_body').empty();
                    $('.block_head').empty();
                    $('.week_name:nth-child(2)').empty();
                    $('.week_name').empty();
                    $('.week_name').append('<div class="week_head"></div><div class="week_head"></div>');
                    $('.block_head').append('<div class="head_column">Name</div><div class="head_column">Id</div>');
                    for (var i = 0; i < data.StudentInfo.length; i++) {
                        html += '<div class="block_body"><div class="body_column"><div class="attendence_block">' + data.StudentInfo[i].Name + '</div></div><div class="body_column"><div class="attendence_block">' +
                            data.StudentInfo[i].StudentId +
                            '</div></div>';
                        for (var j = 0; j < data.StudentInfo[i].Week.length; j++) {
                            if (i == 0) {
                                var from = '';
                                var to = '';
                                for (k in data.StudentInfo[i].Week[j]) {
                                    if (k != 'WeekNo') {
                                        if (k == 'Sun') {
                                            k = k.fontcolor("red");
                                        }
                                        if (k == 'Sat') {
                                            k = k.fontcolor("red");
                                        }
                                        if (k != 'MonDate' && k != 'TueDate' && k != 'WedDate' && k != 'ThurDate' && k != 'FriDate' && k != 'SatDate' && k != 'SunDate') {
                                            $('.block_head').append('<div class="head_column">' + k + '</div></div>');
                                        }
                                    } else {
                                        $('.week_name').append('<div class="week_head" style="color:green;"><b>Week # - </b> ' + data.StudentInfo[i].Week[j][k] + '</div>');
                                    }
                                }
                            }
                            var fullDate = new Date();
                            var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : '0' + (fullDate.getMonth() + 1);
                            var monDate = data.StudentInfo[i].Week[j].MonDate;
                            var subMonDate = monDate.substr(5, 2);
                            if (subMonDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Mon + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "changedata(' + i + ',' + j + ',1, this, null);">' + data.StudentInfo[i].Week[j].Mon + '</div></div>';
                            }
                            var tueDate = data.StudentInfo[i].Week[j].TueDate.substr(5, 2);
                            if (tueDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Tue + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "changedata(' + i + ',' + j + ',2, this, null);">' + data.StudentInfo[i].Week[j].Tue + '</div></div>';
                            }
                            var wedDate = data.StudentInfo[i].Week[j].WedDate.substr(5, 2);
                            if (wedDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Wed + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "changedata(' + i + ',' + j + ',3, this, null);">' + data.StudentInfo[i].Week[j].Wed + '</div></div>';
                            }
                            var thurDate = data.StudentInfo[i].Week[j].ThurDate.substr(5, 2);
                            if (thurDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Thu + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "changedata(' + i + ',' + j + ',4, this, null);">' + data.StudentInfo[i].Week[j].Thu + '</div></div>';
                            }
                            var friDate = data.StudentInfo[i].Week[j].FriDate.substr(5, 2);
                            if (friDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Fri + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "changedata(' + i + ',' + j + ',5, this, null);">' + data.StudentInfo[i].Week[j].Fri + '</div></div>';
                            }
                            var satDate = data.StudentInfo[i].Week[j].SatDate.substr(5, 2);
                            if (satDate != twoDigitMonth) {
                                html += '<div class="body_column" style="color:red; background-color: #dddddd" >' + data.StudentInfo[i].Week[j].Sat + '</div>';
                            } else {
                                html += '<div class="body_column" style="color:red" >' + data.StudentInfo[i].Week[j].Sat + '</div>';
                            }
                            var sunDate = data.StudentInfo[i].Week[j].SatDate.substr(5, 2);
                            if (sunDate != twoDigitMonth) {
                                html += '<div class="body_column" style="color:red; background-color: #dddddd">' + data.StudentInfo[i].Week[j].Sun + '</div>';
                            } else {
                                html += '<div class="body_column" style="color:red">' + data.StudentInfo[i].Week[j].Sun + '</div>';
                            }
                        }
                        html += "</div>"
                    }
                    $('#attendance_body').append(html);
                    $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                },
                error: function (xhr, ajaxOptions, error) {
                    alert(xhr.status);
                    alert('Error: ' + xhr.responseText);
                }
            });
        });

        function existingMonth() {
            var data;
            $('#btnMonthlySave').removeClass('hide');
            $('#btnSave').addClass('hide');
            $('.monthly_table').removeClass('hide');
            $('.head_columns').removeClass('hide');
            var monthDate = $('#monthChange').val();
            if (monthDate != '') {
                var first = monthDate.substr(0, 2);
                var second = monthDate.substr(2, 5);
                monthDate = second + '-' + first + '-' + '01';
            }
            else {
                var monthDate = $('#datepicker').val();
            }
            var object = {
                ClassSectionId: $('#select_class').val(),
                Date: monthDate
            }
            $.ajax({
                type: 'POST',
                url: '/api/Ams/GetMonthlyStudentsAttendance',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(object),
                success: function (newData) {
                    existingData = newData;
                    data = newData;
                    if (data.IsOldData == true) {

                        $('#btnMonthlySave').addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.warning("This table data is readnoly. you are not authorized to modify the content of this table.");
                    }
                    var html = '';
                    $('#attendance_body').empty();
                    $('.block_head').empty();
                    $('.week_days').empty();
                    $('.week_name:nth-child(2)').empty();
                    $('.week_name').empty();
                    $('.week_name').append('<div class="week_head"></div><div class="week_head"></div>');
                    $('.block_head').append('<div class="head_column">Name</div><div class="head_column">Id</div>');
                    for (var i = 0; i < data.StudentInfo.length; i++) {
                        html += '<div class="block_body"><div class="body_column"><div class="attendence_block">' + data.StudentInfo[i].Name + '</div></div><div class="body_column"><div class="attendence_block">' +
                            data.StudentInfo[i].StudentId +
                            '</div></div>';
                        for (var j = 0; j < data.StudentInfo[i].Week.length; j++) {
                            if (i == 0) {
                                for (k in data.StudentInfo[i].Week[j]) {
                                    if (k != 'WeekNo') {
                                        if (k == 'Sun') {
                                            k = k.fontcolor("red");
                                        }
                                        if (k == 'Sat') {
                                            k = k.fontcolor("red");
                                        }
                                        if (k != 'MonDate' && k != 'TueDate' && k != 'WedDate' && k != 'ThurDate' && k != 'FriDate' && k != 'SatDate' && k != 'SunDate') {
                                            $('.block_head').append('<div class="head_column">' + k + '</div></div>');
                                        }
                                    } else {
                                        $('.week_name').append('<div class="week_head" style="color:green;"><b>Week # - </b> ' + data.StudentInfo[i].Week[j][k] + '</div>');
                                    }
                                }
                            }
                            var Monday = 'Mon';
                            var fullDate = $('#monthChange').val().substr(0, 2);
                            if (fullDate == "") {
                                fullDate = $('#datepicker').val().substr(5, 2);
                            }
                            var twoDigitMonth = fullDate;
                            var monDate = data.StudentInfo[i].Week[j].MonDate;
                            var subMonDate = monDate.substr(5, 2);
                            if (subMonDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Mon + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Mon + '</div></div>';
                            }
                            var tueDate = data.StudentInfo[i].Week[j].TueDate.substr(5, 2);
                            if (tueDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Tue + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Tue + '</div></div>';
                            }
                            var wedDate = data.StudentInfo[i].Week[j].WedDate.substr(5, 2);
                            if (wedDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Wed + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Wed + '</div></div>';
                            }
                            var thurDate = data.StudentInfo[i].Week[j].ThurDate.substr(5, 2);
                            if (thurDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Thu + '</div></div>';
                            }
                            else {
                                html += '<div class="body_column"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Thu + '</div></div>';
                            }
                            var friDate = data.StudentInfo[i].Week[j].FriDate.substr(5, 2);
                            if (friDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Fri + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block">' + data.StudentInfo[i].Week[j].Fri + '</div></div>';
                            }
                            var satDate = data.StudentInfo[i].Week[j].SatDate.substr(5, 2);
                            if (satDate != twoDigitMonth) {
                                html += '<div class="body_column" style="color:red; background-color: #dddddd">' + data.StudentInfo[i].Week[j].Sat + '</div>';
                            } else {
                                html += '<div class="body_column" style="color:red">' + data.StudentInfo[i].Week[j].Sat + '</div>';
                            }
                            var sunDate = data.StudentInfo[i].Week[j].SunDate.substr(5, 2);
                            if (sunDate != twoDigitMonth) {
                                html += '<div class="body_column" style="color:red; background-color: #dddddd">' + data.StudentInfo[i].Week[j].Sun + '</div>';
                            } else {
                                html += '<div class="body_column" style="color:red">' + data.StudentInfo[i].Week[j].Sun + '</div>';
                            }
                        }
                        html += "</div>"
                    }
                    $('#attendance_body').append(html);
                    $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                },
                error: function (xhr, ajaxOptions, error) {
                    $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                    toastr.options.positionClass = 'toast-bottom-right';
                    toastr.error(xhr.status);
                    toastr.error('Error: ' + xhr.responseText);
                }
            });
        }

        $("#showButton").click(function () {
            $('#loading .loadingDiv').addClass('loader').parent().removeClass('hide');
            $('#btnMonthlySave').addClass('hide');
            $('.weekly_table').removeClass('hide');
            var object = {
                ClassSectionId: $('#select_class').val(),
                Date: $('#datepicker').val()
            }
            $.ajax({
                type: 'POST',
                url: '/api/Ams/GetWeeklyStudentsAttendance',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                data: JSON.stringify(object),
                success: function (weeklyData) {
                    data = weeklyData;
                    var html = '';
                    $('#weekAttendance_body').empty();
                    $('.block_head').empty();
                    $('.week_name').append('<div class="week_head"></div><div class="week_head"></div>');
                    $('.block_head').append('<div class="head_column">Name</div><div class="head_column">Id</div>' +
                        '<div class="head_column">Mon</div><div class="head_column">Tue</div>' +
                        '<div class="head_column">Wed</div><div class="head_column">Thur</div>' +
                        '<div class="head_column">Fri</div><div class="head_column" style="color:red">Sat</div>' +
                        '<div class="head_column" style="color:red">Sun</div>');
                    for (var i = 0; i < data.length; i++) {
                        if (data[i].isCurrentWeek != true) {
                            html += '<div class="block_body"><div class="body_column"><div class="attendence_name">' + data[i].name + '</div></div><div class="body_column"><div class="attendence_id">' +
                                data[i].studentId +
                                '</div></div>';
                            var fullDate = new Date();
                            var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : '0' + (fullDate.getMonth() + 1);
                            var monDate = data[i].monDate;
                            var subMonDate = monDate.substr(5, 2);
                            if (subMonDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block" >' + data[i].mon + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "weekChangedata(' + i + ',null,1, this, null);">' + data[i].mon + '</div></div>';
                            }
                            var subTueDate = data[i].tueDate.substr(5, 2);
                            if (subTueDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block" >' + data[i].tue + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "weekChangedata(' + i + ',null,2, this, null);">' + data[i].tue + '</div></div>';
                            }
                            var subWedDate = data[i].wedDate.substr(5, 2);
                            if (subWedDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block" >' + data[i].wed + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "weekChangedata(' + i + ',null,3, this, null);">' + data[i].wed + '</div></div>';
                            }
                            var subThurDate = data[i].thurDate.substr(5, 2);
                            if (subThurDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block" >' + data[i].thu + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "weekChangedata(' + i + ',null,4, this, null);">' + data[i].thu + '</div></div>';
                            }
                            var subFriDate = data[i].friDate.substr(5, 2);
                            if (subFriDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block" >' + data[i].fri + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block" onClick = "weekChangedata(' + i + ',null,5, this, null);">' + data[i].fri + '</div></div>';
                            }
                            var subSatDate = data[i].satDate.substr(5, 2);
                            if (subSatDate != twoDigitMonth) {
                                html += '<div class="body_column" style="color:red; background-color: #dddddd" >' + data[i].sat + '</div>';
                            } else {
                                html += '<div class="body_column" style="color:red">' + data[i].sat + '</div>';
                            }
                            var subSunDate = data[i].sunDate.substr(5, 2);
                            if (subSunDate != twoDigitMonth) {
                                html += '<div class="body_column" style="color:red; background-color: #dddddd" >' + data[i].sun + '</div>';
                            }
                            else {
                                html += '<div class="body_column" style="color:red">' + data[i].sun + '</div>';
                            }
                            html += "</div>"
                            $('#btnSave').removeClass('hide');
                        }
                        else {
                            html += '<div class="block_body"><div class="body_column"><div class="attendence_name">' + data[i].name + '</div></div><div class="body_column"><div class="attendence_id">' +
                                data[i].studentId +
                                '</div></div>';
                            var fullDate = new Date();
                            var twoDigitMonth = ((fullDate.getMonth().length + 1) === 1) ? (fullDate.getMonth() + 1) : '0' + (fullDate.getMonth() + 1);
                            var monDate = data[i].monDate;
                            var subMonDate = monDate.substr(5, 2);
                            if (subMonDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data[i].mon + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block">' + data[i].mon + '</div></div>';
                            }
                            var subTueDate = data[i].tueDate.substr(5, 2);
                            if (subTueDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data[i].tue + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block">' + data[i].tue + '</div></div>';
                            }
                            var subWedDate = data[i].wedDate.substr(5, 2);
                            if (subWedDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data[i].wed + '</div></div>';
                            }
                            else {
                                html += '<div class="body_column"><div class="attendence_block">' + data[i].wed + '</div></div>';
                            }
                            var subThurDate = data[i].thurDate.substr(5, 2);
                            if (subThurDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data[i].thu + '</div></div>';
                            } else {
                                html += '<div class="body_column"><div class="attendence_block">' + data[i].thu + '</div></div>';
                            }
                            var subFriDate = data[i].friDate.substr(5, 2);
                            if (subFriDate != twoDigitMonth) {
                                html += '<div class="body_column" style=" background-color: #dddddd"><div class="attendence_block">' + data[i].fri + '</div></div>';
                            }
                            else {
                                html += '<div class="body_column"><div class="attendence_block">' + data[i].fri + '</div></div>';
                            }
                            var subSatDate = data[i].satDate.substr(5, 2);
                            if (subSatDate != twoDigitMonth) {
                                html += '<div class="body_column" style="color:red;  background-color: #dddddd">' + data[i].sat + '</div>';
                            }
                            else {
                                html += '<div class="body_column" style="color:red">' + data[i].sat + '</div>';
                            }
                            var subSatDate = data[i].satDate.substr(5, 2);
                            if (subSatDate != twoDigitMonth) {

                                html += '<div class="body_column" style="color:red; background-color: #dddddd">' + data[i].sun + '</div>';
                            }
                            else {
                                html += '<div class="body_column" style="color:red">' + data[i].sun + '</div>';
                            }
                            html += "</div>"
                            $('#btnSave').addClass('hide');
                        }
                    }
                    $('#weekAttendance_body').append(html);
                    $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                    if (data[0].isCurrentWeek == true) {
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.warning('This table data is readnoly. you are not authorized to modify the content of this table.', { timeOut: 9500 });
                    }
                    weeklyNewData = data;
                },
                error: function (xhr, ajaxOptions, error) {
                    $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                    toastr.options.positionClass = 'toast-bottom-right';
                    toastr.error(xhr.status);
                    toastr.error('Error: ' + xhr.responseText);
                }
            });
        });

        $(document).on('click', '#weeklyBody tr td', function () {
            var textId = $(this);
            var textTd = $(textId).find('.attendence_block').text();
            if (textTd === 'P') {
                $(textId).find('.attendence_block').text('A').css('color', 'red');
            }
            else if (textTd === '') {

            }
            else {
                var div_data = '';
                $(textId).find('.attendence_block').text('');
                $.ajax({
                    type: "POST",
                    url: "/api/Ams/GetAttendanceType",
                    dataType: "json",
                    success: function (data) {
                        $(textId).html(data);
                    }
                });
                $(this).append(div_data);
            }
        });

        $('#btnSaveDailyData').on('click', function () {
            debugger;
            request = { ClassSectionId: $('#select_class').val(), AttendanceDate: $('#dailyDate').val(), AttendanceList: dailyData };
            $.ajax({
                type: "POST",
                url: "/api/Ams/SaveStudentAttendaceDailyData",
                data: JSON.stringify(request),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    if (data.isSuccess == true) {
                        $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.success(data.message);
                    }
                    else if (data.isWarning == true) {
                        $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.warning(data.message);
                    }
                    else {
                        $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.error("", data.message);
                    }

                }
            });

        });

        function savedata() {
            $('#loading .loadingDiv').addClass('loader').parent().removeClass('hide');
            obj = {
                AttendanceDate: $('#datepicker').val(),
                SectionId: $('#select_class').val(),
                Info: weeklyNewData
            }
            $.ajax({
                type: "POST",
                url: "/api/Ams/SaveStudentAttendanceWeekly",
                data: JSON.stringify(obj),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    console.log(data);
                    if (data.isSuccess == true) {
                        $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.success(data.message);
                    }
                    else if (data.isWarning == true) {
                        $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.warning(data.message);
                    }
                    else {
                        $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.error("", data.message);
                    }
                }
            });
        }

        function changedata(i, j, day, inp, selectVaue) {
            var html = '<select onClick="changedata(' + i + ', ' + j + ',' + day + ',null,this.value)">' +
                '' + newWeekHtmlDdl + '</select>';
            if (inp != null) {
                if (inp.innerHTML == 'A') {
                    inp.innerHTML = '';
                    $(inp).parent().append(html);
                    $(inp).css("color", "Green");
                } else if (inp.innerHTML == 'P') {
                    $(inp).css("color", "Red");
                    inp.innerHTML = 'A';
                }
                else {
                    inp.innerHTML = '';
                    $(inp).parent().append(html);
                }
            }

            if (day == 1) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data.StudentInfo[i].Week[j].Mon = selectVaue != null ? selectVaue : inp.innerHTML;
            } else if (day == 2) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data.StudentInfo[i].Week[j].Tue = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 3) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data.StudentInfo[i].Week[j].Wed = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 4) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data.StudentInfo[i].Week[j].Thu = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 5) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data.StudentInfo[i].Week[j].Fri = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 6) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data.StudentInfo[i].Week[j].Sat = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 7) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data.StudentInfo[i].Week[j].Sun = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            data.SectionId = $('#select_class').val();
            data.AttendanceDate = $('#datepicker').val();
            attnData = data;
        };
        function dailyChangedata(i, j, day, inp, selectVaue) {
            debugger;
            var html = '<select onClick="dailyChangedata(' + i + ', ' + j + ',' + day + ',null,this.value)">' +
                '' + newWeekHtmlDdl + '</select>';
            if (inp != null) {
                if (inp.innerHTML == 'A') {
                    inp.innerHTML = '';
                    $(inp).parent().append(html);
                    $(inp).css("color", "Green");
                } else if (inp.innerHTML == 'P') {
                    $(inp).css("color", "Red");
                    inp.innerHTML = 'A';
                }
                else {
                    inp.innerHTML = '';
                    $(inp).parent().append(html);
                }
            }
            if (day == 1) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                dailyData[i].day = selectVaue != null ? selectVaue : inp.innerHTML;
            } else if (day == 2) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                dailyData[i].day = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 3) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                dailyData[i].day = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 4) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                dailyData[i].day = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 5) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                dailyData[i].day = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 6) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                dailyData[i].day = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 7) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                dailyData[i].day = selectVaue != null ? selectVaue : inp.innerHTML;
            }
        };


        function weekChangedata(i, j, day, inp, selectVaue) {
            debugger;
            var html = '<select onClick="weekChangedata(' + i + ', ' + j + ',' + day + ',null,this.value)">' +
                '' + newWeekHtmlDdl + '</select>';
            if (inp != null) {
                if (inp.innerHTML == 'A') {
                    inp.innerHTML = '';
                    $(inp).parent().append(html);
                    $(inp).css("color", "Green");
                } else if (inp.innerHTML == 'P') {
                    $(inp).css("color", "Red");
                    inp.innerHTML = 'A';
                }
                else {
                    inp.innerHTML = '';
                    $(inp).parent().append(html);
                }
            }
            if (day == 1) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data[i].mon = selectVaue != null ? selectVaue : inp.innerHTML;
            } else if (day == 2) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data[i].tue = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 3) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data[i].wed = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 4) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data[i].thu = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 5) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data[i].fri = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 6) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data[i].sat = selectVaue != null ? selectVaue : inp.innerHTML;
            }
            else if (day == 7) {
                if (selectVaue == null) {
                    if (inp.innerHTML == "") {
                        selectVaue = "P";
                    }
                }
                data[i].sun = selectVaue != null ? selectVaue : inp.innerHTML;
            }
        };

        $('#btnMonthlySave').click(function () {
            $('#loading .loadingDiv').addClass('loader').parent().removeClass('hide');
            if (attnData == '') {
                existingData.SectionId = $('#select_class').val();
                existingData.AttendanceDate = $('#datepicker').val();
                student = existingData;
            }
            else {
                student = attnData;
            }

            $.ajax({
                type: "POST",
                url: "/api/Ams/SaveMonthlyData",
                data: JSON.stringify(student),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    if (data.isSuccess == true) {
                        $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.success(data.message);
                    }
                    else if (data.isWarning == true) {
                        $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.warning(data.message);
                    }
                    else {
                        $('#loading .loadingDiv').removeClass('loader').parent().addClass('hide');
                        toastr.options.positionClass = 'toast-bottom-right';
                        toastr.error("", data.message);
                    }
                }
            });
        });

        $('#view_as').on('change', function () {
            if ($('#view_as').val() == "select") {
                $('#showButton').addClass('hide');
                $('#btnSave').addClass('hide');
                $('#monthButton').addClass('hide');
                $('#btnMonthlySave').addClass('hide');
                $('.weekly_table').addClass('hide');
                $('.monthly_table').addClass('hide');
                $('.daily_table').addClass('hide');
                $('#btnSaveDailyData').addClass('hide');
            }
            if ($('#view_as').val() == "weekly") {
                $('#showButton').removeClass('hide');
                $('#monthButton').addClass('hide');
                $('.monthly_table').addClass('hide');
                $('#btnMonthlySave').addClass('hide');
                $('.daily_table').addClass('hide');
                $('#btnSaveDailyData').addClass('hide');
            }
            if ($('#view_as').val() == "monthly") {
                $('#monthButton').removeClass('hide');
                $('.weekly_table').addClass('hide');
                $('#showButton').addClass('hide');
                $('#btnSave').addClass('hide');
                $('.daily_table').addClass('hide');
                $('#btnSaveDailyData').addClass('hide');
            }
            if ($('#view_as').val() == "daily") {
                $('.weekly').show();
                $('#dailyButton').removeClass('hide');
                $('.weekly_table').addClass('hide');
                $('.daily_table').removeClass('hide');
                 $('.monthly_table').addClass('hide');
            }
        });

        function getMonday(d) {
            d = new Date(d);
            var day = d.getDay(),
                diff = d.getDate() - day + (day == 0 ? -6 : 1);
            return new Date(d.setDate(diff));
        }

        function getSunday(d) {
            d = new Date(d);
            var day = d.getDay(),
                diff = d.getDate() - day;
            return new Date(d.setDate(diff));
        }

        function startAndEndOfWeek(date) {
            var now = date ? new Date(date) : new Date();
            now.setHours(0, 0, 0, 0);
            var monday = new Date(now);
            monday.setDate(monday.getDate() - monday.getDay() + 1);
            var subMon = "<b style='font-size:13px'> From : </b>" + monday.toString().substr(0, 10) + "<b style='font-size:13px'> To: </b> ";
            var sunday = new Date(now);
            sunday.setDate(sunday.getDate() - sunday.getDay() + 7);
            var subSun = sunday.toString().substr(0, 10);
            return [subMon, subSun];
        }
        var currentWeeks = startAndEndOfWeek(new Date()).join('\n');
        $('#selectedWeek').html('<span style="font-size:13px">' + currentWeeks + '</span>');

        Date.prototype.getWeek = function () {
            var onejan = new Date(this.getFullYear(), 0, 1);
            return Math.ceil((((this - onejan) / 86400000) + onejan.getDay() + 1) / 7);
        };

        var myDate = new Date();
        $('#currentWeekNo').html(myDate.getWeek());
        $("button").click(function (event) {
            event.preventDefault();
        });

        $('#select_class').change(function () {
            $('#btnSave').addClass('hide');
            $('#btnMonthlySave').addClass('hide');
            $('.weekly_table').addClass('hide');
            $('.monthly_table').addClass('hide');
        });

        $('#dailyButton').on('click', function () {
            $('#btnSaveDailyData').removeClass('hide');

            var data = {
                AttendanceDate: $('#dailyDate').val(),
                ClassSectionId: $('#select_class').val()
            }
            // Get Current day attendance
            $.ajax({
                type: "POST",
                url: "/api/Ams/GetDailyAttendance",
                data: JSON.stringify(data),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                    debugger;
                    var html = '';
                    $('#dailyAttendance_body').empty();
                    $('.block_head').empty();
                    $('.block_head').append('<div class="head_column">Name</div><div class="head_column">Id</div>' +
                        '<div class="head_column">Attendance</div>');
                    for (var i = 0; i < data.length; i++) {
                        html += '<div class="block_body"><div class="body_column"><div class="attendence_name">' + data[i].name + '</div></div><div class="body_column"><div class="attendence_id">' +
                            data[i].studentId +
                            '</div></div>';
                        html += '<div class="body_column"><div class="attendence_block" onClick = "dailyChangedata(' + i + ',null,1, this, null);">' + data[i].day + '</div></div>';
                        html += "</div>"
                    }
                    $('#dailyAttendance_body').append(html);

                    dailyData = data;
                }
            });
        });

        var userTypeEnum =
        {
            TR: 1,
            Admin: 2,
            CO: 3,
            RO: 4,
            HO: 5,
            APG: 8,
            ML: 11,
            SAdmin: 16,
            OT: 17,
            LIB: 19,
            RD: 20,
            ST: 21,
            HOA: 22,
            HOI: 23,
            HOET: 24,
            ROA: 25,
            ROI: 26,
            AT: 27,
            CH: 28,
            S_HO: 29,
            Ro_Academic: 30,
            NO: 31
        }
    </script>
</asp:Content>
