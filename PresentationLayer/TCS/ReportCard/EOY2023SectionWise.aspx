<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EOY2023SectionWise.aspx.cs" Inherits="PresentationLayer_TCS_ReportCard_EOY2023SectionWise" %>

<!DOCTYPE html>
<html>
<head>
    <!--PWA-->
    <link rel="manifest" href="./Content/manifest.json">
    <link rel="shortcut icon" href="./Content/favicon.png">
    <link rel="icon" type="image/png" sizes="16x16" href="./Content/images/icons/favicon-16x16.png">
    <link rel="icon" type="image/png" sizes="32x32" href="./Content/images/icons/favicon-32x32.png">
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="default">
    <meta name="apple-mobile-web-app-title" content="PWA Splash">
    <link rel="apple-touch-startup-image" href="./Content/images/splash/launch-640x1136.png" media="(device-width: 320px) and (device-height: 568px) and (-webkit-device-pixel-ratio: 2) and (orientation: portrait)">
    <link rel="apple-touch-startup-image" href="./Content/images/splash/launch-750x1294.png" media="(device-width: 375px) and (device-height: 667px) and (-webkit-device-pixel-ratio: 2) and (orientation: portrait)">
    <link rel="apple-touch-startup-image" href="./Content/images/splash/launch-1242x2148.png" media="(device-width: 414px) and (device-height: 736px) and (-webkit-device-pixel-ratio: 3) and (orientation: portrait)">
    <link rel="apple-touch-startup-image" href="./Content/images/splash/launch-1125x2436.png" media="(device-width: 375px) and (device-height: 812px) and (-webkit-device-pixel-ratio: 3) and (orientation: portrait)">
    <link rel="apple-touch-startup-image" href="./Content/images/splash/launch-1536x2048.png" media="(min-device-width: 768px) and (max-device-width: 1024px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: portrait)">
    <link rel="apple-touch-startup-image" href="./Content/images/splash/launch-1668x2224.png" media="(min-device-width: 834px) and (max-device-width: 834px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: portrait)">
    <link rel="apple-touch-startup-image" href="./Content/images/splash/launch-2048x2732.png" media="(min-device-width: 1024px) and (max-device-width: 1024px) and (-webkit-min-device-pixel-ratio: 2) and (orientation: portrait)">
    <link rel="apple-touch-icon" sizes="180x180" href="./Content/images/icons/apple-touch-icon.png">
    <link rel="mask-icon" href="./Content/images/icons/safari-pinned-tab.svg" color="#6F6F6F">
    <!--PWA-->

    <script src="jquery-3.3.1.min.js" type="text/JavaScript" language="javascript"></script>
    <script src="jquery-ui-1.10.4.custom.js"></script>
    <script src="jquery.PrintArea.js" type="text/JavaScript" language="javascript"></script>

    <script src="popper.min.js"></script>
    <script src="bootstrap.min.js"></script>

    <link type="text/css" rel="stylesheet" href="jquery-ui-1.10.4.custom.css" />

    <link type="text/css" rel="stylesheet" href="PrintArea3MYE.css" />                <!-- Y : rel is stylesheet and media is in [all,print,empty,undefined] -->
    <link type="text/css" rel="stylesheet" href="media_all.css" media="all" />   <!-- Y : rel is stylesheet and media is in [all,print,empty,undefined] -->
    <link type="text/css" rel="" href="empty.css" />                    <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="noPrint" href="noPrint.css" />                  <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="stylesheet" href="media_none.css" media="xyz" />   <!-- N : media not in [all,print,empty,undefined] -->
    <link type="text/css" href="no_rel.css" media="print" /> <!-- N : no rel attribute -->
    <link type="text/css" href="no_rel_no_media.css" /> <!-- N : no rel, no media attributes -->
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css">

    <link rel="stylesheet" type="text/css" href="font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="sweetalert2.min.css">
    <script type="text/javascript" src="sweetalert2.min.js"></script>
    <script type="text/javascript" src="qr-code.js"></script>
</head>
<body>
    <div class="container">
        <div class="overlay"></div>
        <div class="row printview">
            <div class="button b1 btn btn-primary  tooltip "><i class="fa fa-print" data-toggle="tooltip" data-placement="bottom" title="Print"></i><span class="tooltiptext">Print</span></div>
        </div>
        <div class="PrintArea area1 all" id="Retain">
            <!--boostrap-->

            <div class="container serachprinttable">
                <!--container-->

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 no-padding">

                    <!--section 1--->
                    <!--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex">
                        <p><span class="headerstudentname"></span><span class="floatright headerstudentcenter"></span></p>
                    </div>-->
                    <!--remove sec---->
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 no-padding uppersec">
                    </div>

                    <!--section 1--->
                    <!--section 2--->
                    <!--section 2--->
                    <!--remove sec-->
                    <!--section 3--->
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 no-padding">
                        <div class="reporttable article">
                            <div class="firstthreetable"></div>
                            <div class="remainingtable"></div>
                        </div>
                    </div>
                    <!--section 3--->
                </div>
            </div>
            <!--bootsrap-->
        </div>
    </div>
    <div style="border: solid 2px #999fff; float: left; margin-left: 20px;" class="SettingsBox">
        <div style="width: 400px; padding: 20px;">
            <div style="padding: 0 10px 10px;" class="buttonBar">
                <div class="button b1">Print</div>
                <div class="toggleDialog">open dialog</div>
            </div>
            <div style="font-weight: bold; border-top: solid 1px #999fff; padding-top: 10px;">Settings</div>
            <table>
                <tbody>
                    <tr>
                        <td><input value="popup" name="mode" id="popup" checked="" type="radio"> Popup</td>
                    </tr>
                    <tr>
                        <td style="padding-left: 20px;"><input value="popup" name="popup" id="closePop" type="checkbox"> Close popup</td>
                    </tr>
                    <tr>
                        <td><input value="iframe" name="mode" id="iFrame" type="radio"> IFrame</td>
                    </tr>
                    <tr>
                        <td>Extra css: <input type="text" name="extraCss" size="50" /></td>
                    </tr>
                    <tr>
                        <td>
                            <div class="settingName">Print area:</div>
                            <div class="settingVals">
                                <input type="checkbox" class="selPA" value="area1" checked /> Area 1<br>
                                <input type="checkbox" class="selPA" value="area2" checked /> Area 2<br>
                                <input type="checkbox" class="selPA" value="area3" checked /> Area 3<br>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="settingName">Retain Attributes:</div>
                            <div class="settingVals">
                                <input type="checkbox" checked name="retainCss" id="retainCss" class="chkAttr" value="class" /> Class
                                <br>
                                <input type="checkbox" checked name="retainId" id="retainId" class="chkAttr" value="id" /> ID
                                <br>
                                <input type="checkbox" checked name="retainStyle" id="retainId" class="chkAttr" value="style" /> Style
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="padding: 3px; border: solid 1px #ddd;">
                                Add to head :
                                <input type="checkbox" checked name="addElements" id="addElements" class="chkAttr" />
                                <pre>&lt;meta charset="utf-8" /&gt;<br>&lt;http-equiv="X-UA-Compatible" content="IE=edge"/&gt;</pre>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <footer>okss</footer>
    </div>
    <script>
        /****Disabled f12 and right click key***/

        $(document).keydown(function (event) {
            if (event.keyCode == 123) {
                return false;
            }
            else if (event.ctrlKey && event.shiftKey && event.keyCode == 73) {
                return false;
            }
        });

        $(document).on("contextmenu", function (e) {
            e.preventDefault();
        });
        /****Disabled f12 and right click key***/

        $(document).ready(function () {
            $(".overlay").show();
            $('[data-toggle="tooltip"]').tooltip();
            var dialog = $("div.testDialog").dialog({ position: { my: "left top", at: "left bottom+50", of: ".SettingsBox" }, width: "1000", title: "Print Dialog Box Contents" });

            $(".toggleDialog").click(function () {
                dialog.dialog("open");
            });

            $("div.b1").click(function () {

                var mode = $("input[name='mode']:checked").val();
                var close = mode == "popup" && $("input#closePop").is(":checked");
                var extraCss = $("input[name='extraCss']").val();

                var print = "";
                $("input.selPA:checked").each(function () {
                    print += (print.length > 0 ? "," : "") + "div.PrintArea." + $(this).val();
                });

                var keepAttr = [];
                $(".chkAttr").each(function () {
                    if ($(this).is(":checked") == false)
                        return;

                    keepAttr.push($(this).val());
                });

                var headElements = $("input#addElements").is(":checked") ? '<meta charset="utf-8" />,<meta http-equiv="X-UA-Compatible" content="IE=edge"/>' : '';

                var options = { mode: mode, popClose: close, extraCss: extraCss, retainAttr: keepAttr, extraHead: headElements };

                $(print).printArea(options);

                $('#qrcode').empty();

                // Set Size to Match User Input
                $('#qrcode').css({
                    'width': $('.qr-size').val(),
                    'height': $('.qr-size').val()
                })

                // Generate and Output QR Code
                $('#qrcode').qrcode({ width: $('.qr-size').val(), height: $('.qr-size').val(), text: "https://www.codegrepper.com/code-examples/javascript/jquery+get+url+parameter" });//$('.qr-url').val()

                //});
                /****QR CODE***/
            });

            const months = ["January", "February", "March", "April", "May", "June",
                "July", "August", "September", "October", "November", "December"
            ];

            /**Format Date**/
            function formatdate(datevalue) {
                var date = new Date(datevalue);
                var datess = date.getDate();
                var monthss = months[date.getMonth()];
                var fullyear = date.getFullYear();
                var hours = date.getHours();
                var minutes = date.getMinutes();
                var mili = date.getMilliseconds();

                var strdate = monthss + "  " + datess + ", " + fullyear;
                return strdate;
            }

            //const value = encodeURIComponent(value).replace('%20','+');

            var reportcard = "";
            var reportcard2 = "";
            var uppersec = "";
            var already = "";
            //var Roll_Number="189570";
            //var Session_Id="11";
            //var Class_Id=13;
            //var count =1;
            var first_time = 1;
            var icount = 1;
            var incomplete_already = 0;

            /*****************************************DECRYPT************************************/

            var uri = window.location.href;
            var enc = encodeURIComponent(uri).replace('%20', '+');
            var dec = decodeURIComponent(enc);
            var res = "Encoded URI: " + enc + "<br>" + "Decoded URI: " + dec;
            console.log("LINKS:" + res);
            var sURLVariableswithurl = "";
            function GetUrlParameter(sParam) {
                var sPageURL = dec;//window.location.search.substring(1);

                sURLVariableswithurl = sPageURL.split('?');
                var sURLVariables = sURLVariableswithurl[1].split('&');

                for (var i = 0; i < sURLVariables.length; i++) {
                    var sParameterName = sURLVariables[i].split('=');

                    if (sParameterName[0] == sParam) {
                        // return sParameterName[1];
                        /*******************************DECRPT in Function*******************/
                        var scids = sParameterName[1];

                        scids = scids.replace(/Z|z/g, '');//replace("Z",'');
                        var scidss = "";

                        var i = "";
                        for (i = 0; i < scids.length; i += 2) {
                            var res = scids.substr(i, 2);
                            if (res == "KL") {
                                scidss += "0"
                            }
                            else if (res == "JK") {
                                scidss += "1"
                            }
                            else if (res == "HJ") {
                                scidss += "2"
                            }
                            else if (res == "GH") {
                                scidss += "3"
                            }
                            else if (res == "NM") {
                                scidss += "4"
                            }
                            else if (res == "BN") {
                                scidss += "5"
                            }
                            else if (res == "VB") {
                                scidss += "6"
                            }
                            else if (res == "TY") {
                                scidss += "7"
                            }
                            else if (res == "ER") {
                                scidss += "8"
                            }
                            else if (res == "WE") {
                                scidss += "9"
                            }

                        }
                        //console.log("SessionID Decode-----"+scidss);
                        //ScId=scidss;
                        return scidss;
                        /*****************************DECRTPT IN FUNCTION********************/
                    }
                }
            }

            //var ScId = GetUrlParameter('Section_Id');
            //var Sd = GetUrlParameter('Session_Id');
            //var Ty = GetUrlParameter('Term');

            //console.log("ScId" + ScId + "------" + "Sd" + Sd + "------" + "Ty" + Ty );

            var Roll_Number = GetUrlParameter('d');
            var Session_Id = GetUrlParameter('b');
            var Term_Id = GetUrlParameter('c');
            var Sec_Id = GetUrlParameter('a');
            console.log("Roll NUmber" + Roll_Number + "------" + "Session_Id" + Session_Id + "Term_Id" + Term_Id + "Section" + Sec_Id);

            /****DECREPT CODE***/

            /*****************************************DECRYPT************************************/

            $('.container').off('scroll touchmove mousewheel');

            var alreadyt = "";

            var Student_array = [];
            Student_array.length = 0;
            var datademo = [];
            datademo.length = 0;

            $.ajax({
                
                url: "EOY2023SectionWise.aspx/test",
                // data: "{querytype: '1'}",
                data: "{ Session_Id:" + Session_Id + ", TermGroup_Id :" + Term_Id + ", Section_Id:" + Sec_Id + ", Student_Id: " + Roll_Number + " }",
                type: "POST",
                dataType: "json",
                contentType: "application/json; charset=utf-8",
                success: function (result) {
                    
                    var result = JSON.parse(result.d);
                    for (var i = 0; i < result.length; i++) {//result.length

                        var effort;
                        var remarks;
                        var comments;
                        var fullname;
                        var course_work;
                        var grade;
                        if (alreadyt != result[i].Student_Id) {
                            /**FIRST tIME USER**/
                            if (alreadyt == "") {
                                Student_array.push({
                                    Subject_Id: result[i].Subject_Id,
                                    Subject_Name: result[i].Subject_Name,
                                    Term1: result[i].Term1,
                                    Course_Work: result[i].Course_Work,
                                    Theory_Exam: result[i].Theory_Exam,
                                    Marks: result[i].Marks,
                                    Grade: result[i].Grade,
                                    Strength: result[i].Strength,
                                    Student_Age: result[i].Student_Age,
                                    Overall_P: result[i].Overall_P,
                                    Class_Heighest: result[i].Class_Heighest,
                                    Class_Average: result[i].Class_Average,
                                    ClassTeacher_Comments: result[i].ClassTeacher_Comments,
                                    Main_Organisation_Name: result[i].Main_Organisation_Name,
                                    Region_Name: result[i].Region_Name,
                                    Remarks: result[i].Remarks,
                                    Effort: result[i].Effort,
                                    isAbsent: result[i].isAbsent,
                                    is_comment: result[i].is_comment,
                                    Isabsent_FirstTem: result[i].Isabsent_FirstTem,
                                    Employee_Id: result[i].Employee_Id,
                                    FullName: result[i].FullName,
                                    Comments: result[i].Comments,
                                    FirstName: result[i].FirstName,
                                    /**change on 20 sep by aqil**/
                                    Criteria: result[i].Criteria,
                                    /**change on 20 sep by aqil**/
                                    Improve1: result[i].Improve1,
                                    Improve2: result[i].Improve2,
                                    Strength1: result[i].Strength1,
                                    Strength2: result[i].Strength2,
                                });

                                datademo.push({
                                    StudentName: result[i].StudentName,
                                    Student_Id: result[i].Student_Id,
                                    Class_Id: result[i].Class_Id,
                                    Session_Id: result[i].Session_Id,
                                    Class_Name: result[i].Class_Name,
                                    HeadName: result[i].HeadName,
                                    Description: result[i].Description,
                                    Evaluation_Criteria_Type_Name: result[i].Evaluation_Criteria_Type_Name,
                                    Section_Name: result[i].Section_Name,
                                    Date_Of_Birth: result[i].Date_Of_Birth,
                                    DaysPresent: result[i].DaysPresent,
                                    FirstTermDaysCH: result[i].FirstTermDaysCH,
                                    Center_Name: result[i].Center_Name,
                                    isPromoted: result[i].isPromoted,
                                    Cond_Prom: result[i].Cond_Prom,
                                    PromotedToClass: result[i].PromotedToClass,
                                    RequestedClass: result[i].RequestedClass,
                                    IsComplete: result[i].IsComplete,
                                    Region_Name: result[i].Region_Name,
                                    StudentWise: Student_array
                                });
                                alreadyt = result[i].Student_Id;
                            }
                            /**FIRST tIME USER**/

                            else {
                                Student_array = [];
                                Student_array.push({

                                    Subject_Id: result[i].Subject_Id,
                                    Subject_Name: result[i].Subject_Name,
                                    Term1: result[i].Term1,
                                    Course_Work: result[i].Course_Work,
                                    Term1: result[i].Term1,
                                    Theory_Exam: result[i].Theory_Exam,
                                    Marks: result[i].Marks,
                                    Grade: result[i].Grade,
                                    Strength: result[i].Strength,
                                    Student_Age: result[i].Student_Age,
                                    Overall_P: result[i].Overall_P,
                                    Class_Heighest: result[i].Class_Heighest,
                                    Class_Average: result[i].Class_Average,
                                    ClassTeacher_Comments: result[i].ClassTeacher_Comments,
                                    Main_Organisation_Name: result[i].Main_Organisation_Name,
                                    Region_Name: result[i].Region_Name,
                                    Remarks: result[i].Remarks,
                                    Effort: result[i].Effort,
                                    isAbsent: result[i].isAbsent,
                                    is_comment: result[i].is_comment,
                                    Isabsent_FirstTem: result[i].Isabsent_FirstTem,
                                    Employee_Id: result[i].Employee_Id,
                                    FullName: result[i].FullName,
                                    Comments: result[i].Comments,
                                    FirstName: result[i].FirstName,
                                    /**change on 20 sep by aqil**/
                                    Criteria: result[i].Criteria,
                                    /**change on 20 sep by aqil**/
                                    Improve1: result[i].Improve1,
                                    Improve2: result[i].Improve2,
                                    Strength1: result[i].Strength1,
                                    Strength2: result[i].Strength2,
                                });

                                datademo.push({
                                    StudentName: result[i].StudentName,
                                    Student_Id: result[i].Student_Id,
                                    Class_Id: result[i].Class_Id,
                                    Session_Id: result[i].Session_Id,
                                    Class_Name: result[i].Class_Name,
                                    HeadName: result[i].HeadName,
                                    Description: result[i].Description,
                                    Evaluation_Criteria_Type_Name: result[i].Evaluation_Criteria_Type_Name,
                                    Section_Name: result[i].Section_Name,
                                    Date_Of_Birth: result[i].Date_Of_Birth,
                                    DaysPresent: result[i].DaysPresent,
                                    FirstTermDaysCH: result[i].FirstTermDaysCH,
                                    Center_Name: result[i].Center_Name,
                                    isPromoted: result[i].isPromoted,
                                    Cond_Prom: result[i].Cond_Prom,
                                    PromotedToClass: result[i].PromotedToClass,
                                    RequestedClass: result[i].RequestedClass,
                                    IsComplete: result[i].IsComplete,
                                    Region_Name: result[i].Region_Name,
                                    StudentWise: Student_array
                                });
                                alreadyt = result[i].Student_Id;
                            }
                        }
                        else {
                            Student_array.push({
                                Subject_Id: result[i].Subject_Id,
                                Subject_Name: result[i].Subject_Name,
                                Term1: result[i].Term1,
                                Course_Work: result[i].Course_Work,
                                Theory_Exam: result[i].Theory_Exam,
                                Marks: result[i].Marks,
                                Grade: result[i].Grade,
                                Strength: result[i].Strength,
                                Student_Age: result[i].Student_Age,
                                Overall_P: result[i].Overall_P,
                                Class_Heighest: result[i].Class_Heighest,
                                Class_Average: result[i].Class_Average,
                                ClassTeacher_Comments: result[i].ClassTeacher_Comments,
                                Main_Organisation_Name: result[i].Main_Organisation_Name,
                                Region_Name: result[i].Region_Name,
                                Center_Name: result[i].Center_Name,
                                Remarks: result[i].Remarks,
                                Effort: result[i].Effort,
                                isAbsent: result[i].isAbsent,
                                is_comment: result[i].is_comment,
                                Employee_Id: result[i].Employee_Id,
                                FullName: result[i].FullName,
                                Comments: result[i].Comments,
                                FirstName: result[i].FirstName,
                                /**change on 20 sep by aqil**/
                                Criteria: result[i].Criteria,
                                /**change on 20 sep by aqil**/
                                Improve1: result[i].Improve1,
                                Improve2: result[i].Improve2,
                                Strength1: result[i].Strength1,
                                Strength2: result[i].Strength2,
                            });
                        }
                    }//For loop end

                    console.log("demo" + JSON.stringify(datademo));
                    // console.log("ander" + JSON.stringify(datademo[0].StudentWise[0].Subject_Name)); //datademo[t].StudentWise[r].Subject_Name
                    for (var t = 0; t < datademo.length; t++) {
                        var count = 0;
                        reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex printmediabordertopafter3">';
                        reportcard += '<p><span>' + datademo[t].StudentName + "-" + datademo[t].Student_Id + '</span><span class="floatright">' + datademo[t].Center_Name + '</span></p>';
                        reportcard += '</div>';
                        /*****HEADER SEC1 *********/
                        reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 sec1 article">';
                        //reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">';
                        //reportcard += '<h2 class="text-right schoolname">The City School</h2>';
                        //reportcard += '</div>';

                        reportcard += '<div class="row rowdisplayflex headerwithlogo margintoponlogo">';
                        reportcard += '<div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass">';

                        reportcard += '</div>';
                        reportcard += '<div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign">';
                        reportcard += '<h4 class="uppertxtinnewreportmargin"><span class="termname">' + datademo[t].Evaluation_Criteria_Type_Name + '</span> Report Card <span class="yearname">' + datademo[t].Description.replace("AY", '') + '</span></h4>';
                        reportcard += '<h4 class="fullnamestudent">' + datademo[t].StudentName + '</h4>';
                        reportcard += '<h4><span class="classname">' + datademo[t].Class_Name + '</span> - <span class="classsec">' + datademo[t].Section_Name + '</span></h4>';
                        reportcard += '</div>';
                        reportcard += '<div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-mediaalignright schoollogoNew">';
                        reportcard += '<img src="newlogonewr.png" />';
                        reportcard += '</div>';
                        reportcard += '</div>';

                        reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 dobtable">';
                        reportcard += '<table>';
                        reportcard += '<tr><td><strong>Date of Birth:</strong>  </td><td class="dobclass">' + formatdate(datademo[t].Date_Of_Birth) + '</td></tr>';

                        var attendenceperc = (datademo[t].DaysPresent / datademo[t].FirstTermDaysCH) * 100;
                        var attendence;

                        if (attendenceperc < 25) {
                            attendence = "Low";
                        }
                        else {
                            attendence = datademo[t].DaysPresent;
                        }

                        reportcard += '<tr><td><strong>Attendance:</strong> </td><td><span class="attendenceclass">' + attendence + '</span> (Out of <span class="attendencetotal">' + datademo[t].FirstTermDaysCH + " days" + '</span>)</td></tr>';
                        reportcard += '</table>';
                        reportcard += '</div>';
                        reportcard += '</div>';
                        /****HEADER SEC1 ********/

                        /*****HEADER SEC2 *********/
                        reportcard += '<div class="row sec2 article">';
                        reportcard += '<div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 floatleft mediawidth">';
                        reportcard += '<h4>Understanding your child' + "'" + '<span class="fontchange"></span>s report</h4>';
                        reportcard += '<ul>';
                        if (datademo[t].Class_Id != 13) {
                            reportcard += '<li class="exm_9"><strong>Final result:</strong> 10% of Term 1 result+90% of Term 2 result.</li>';
                        }
                        else {
                            reportcard += '<li class="exm_3-8"><strong>Exam:</strong> Percentage achieved in the final results.</li>';
                        }
                        reportcard += '<li>';
                        reportcard += '<strong>CA:</strong> Continuous Assessment marks given during regular classes.';

                        reportcard += '</li>';
                        reportcard += '<li><strong>Grade:</strong> A*- E or U (Ungraded) is given based on the final results.</li>';

                        reportcard += '<table class="table-bordered graphtable"><tr><td>A*</td><td>A</td><td>B</td><td>C</td><td>D</td><td>E</td><td>U</td></tr><tr><td class="greaterthanequalto"> 90%</td><td>80-89</td><td>70-79</td><td>60-69</td><td>50-59</td><td>40-49</td><td>< 40%</td></tr></table>';

                        reportcard += '<li><strong>Effort:</strong> A teacher judgement describing how much effort your child puts into his/her studies.</li>';

                        if (attendenceperc < 25) {
                            reportcard += "<li>Due to student's low attendance, we are unable to comment on any progress made through this term.</li>";
                        }
                        else {
                            reportcard += "<li>Student's strengths and areas for improvement are mentioned below each subject.</li>";
                        }

                        reportcard += '</ul>';
                        reportcard += '</div>';

                        reportcard += '<div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 floatleft ">';

                        reportcard += '<table class="table-bordered effort-table">';
                        reportcard += '<tr class="text-center"><td colspan="2" style=" background:#e4e4e4 !important;">Effort</td></tr>';
                        reportcard += '<tr><td>Excellent</td><td>1</td></tr>';
                        reportcard += '<tr><td>Good</td><td>2</td></tr>';
                        reportcard += '<tr><td>Satisfactory</td><td>3</td></tr>';
                        reportcard += '<tr><td>Needs improvement</td><td>4</td></tr>';
                        reportcard += '</table>';
                        reportcard += '</div>';

                        //reportcard += '<div class="headsigndiv">';
                        //reportcard += '<div class="col-lg-9 col-md-6 col-sm-6 col-xs-6 floatleft mediawidthlg8">';
                        //reportcard += '<p style="width: 100%" class="visiblity-hidden_class">p</p>';
                        //reportcard += '</div>';
                        //reportcard += '<div class="col-lg-3 col-md-6 col-sm-6 col-xs-6 floatleft mediawidthlg4">';
                        //reportcard += '<label class="headsign form-control text-center">' + result[t].HeadName + '</label>';

                        //reportcard += '<label class="label-100 ">Head of School</label>';
                        //reportcard += '</div>';
                        reportcard += '</div>';
                        reportcard += '</div>';

                        /****HEADER SEC2 ********/
                        //reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 incomplete text-center"></div>';

                        if (datademo[t].IsComplete == 0) {

                            reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-center">';
                            reportcard += '<div class=""><img src="images/warning.png"/><h4 class="redcolor">InComplete Result</h4></div>';
                            reportcard += '</div>';
                            reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom pehlewala">';/*<p>ok</p>*/
                            reportcard += '</div>';
                            continue;
                        }
                        else {
                            /**TABLE**/

                            for (var r = 0; r < datademo[t].StudentWise.length; r++) {

                                if (datademo[t].StudentWise[r].isAbsent == true) {
                                    effort = "-";
                                }
                                else {
                                    effort = datademo[t].StudentWise[r].Effort;
                                }

                                if (datademo[t].StudentWise[r].Comments == null || datademo[t].StudentWise[r].Comments == "" || datademo[t].StudentWise[r].Comments == " ") {
                                    comments = "";
                                }
                                else {
                                    comments = datademo[t].StudentWise[r].Comments;
                                }

                                //if (datademo[t].StudentWise[r].Remarks == null || datademo[t].StudentWise[r].Remarks == "" || datademo[t].StudentWise[r].Remarks == " ") {
                                //    remarks = "";
                                //}
                                //else {
                                //    remarks = datademo[t].StudentWise[r].Remarks;
                                //}

                                //if (datademo[t].StudentWise[r].FullName == null || datademo[t].StudentWise[r].FullName == "" || datademo[t].StudentWise[r].FullName == " ") {
                                //    fullname = "";
                                //}
                                //else {
                                //    fullname = datademo[t].StudentWise[r].FullName;
                                //}

                                if (datademo[t].StudentWise[r].isAbsent == true) {
                                    course_work = "-";
                                    //course_work = datademo[t].StudentWise[r].Course_Work;
                                }
                                else if (datademo[t].StudentWise[r].Course_Work == "-") {
                                    course_work = datademo[t].StudentWise[r].Course_Work;
                                }
                                else if (datademo[t].StudentWise[r].Course_Work == 0) {
                                    //if (datademo[t].Class_Id == 13) {

                                    //    course_work = datademo[t].StudentWise[r].Course_Work + " %";
                                    //}
                                    //else {

                                    //    var cour = roundfun(datademo[t].StudentWise[r].Course_Work);
                                    //    course_work = cour + " %";
                                    //}

                                    /**change in 24march2022 by Raja**/
                                    course_work = "-";
                                    /**change in 24march2022 by Raja**/

                                }
                                else {
                                    if (datademo[t].Class_Id == 13) {

                                        course_work = datademo[t].StudentWise[r].Course_Work + " %";
                                    }
                                    else {

                                        /*** NAZRA CONDTION***/
                                        if (datademo[t].StudentWise[r].Subject_Id == 18) {
                                            var cour = roundfun(datademo[t].StudentWise[r].Course_Work / 2);
                                            course_work = cour + " / 50";
                                        }
                                        else {
                                            var cour = roundfun(datademo[t].StudentWise[r].Course_Work);
                                            course_work = cour + " %";
                                        }
                                        /*** NAZRA CONDTION***/


                                        //var cour = roundfun(datademo[t].StudentWise[r].Course_Work);
                                        //course_work = cour + " %";
                                    }
                                    //var cour=roundfun(datademo[t].StudentWise[r].Course_Work);
                                    // course_work = cour+ " %";
                                }

                                var exammark;
                                var MYE_Percent;
                                var EOY_Percent;
                                var MYE;
                                var EOY;
                                if (datademo[t].StudentWise[r].Term1 != '-')
                                    MYE_Percent = datademo[t].StudentWise[r].Term1 * 0.1;//parseInt(MYE_Percent_Key);
                                else
                                    MYE_Percent = datademo[t].StudentWise[r].Term1;

                                if (datademo[t].StudentWise[r].Theory_Exam != '-')
                                    EOY_Percent = datademo[t].StudentWise[r].Theory_Exam * 0.9;//parseInt(EOY_Percent_Key);
                                else
                                    EOY_Percent = datademo[t].StudentWise[r].Theory_Exam;


                                if (datademo[t].StudentWise[r].Theory_Exam == "-" || datademo[t].StudentWise[r].Theory_Exam == "" || datademo[t].StudentWise[r].Theory_Exam == null) {
                                    grade = "-";
                                    exammark = datademo[t].StudentWise[r].Theory_Exam;
                                    EOY = datademo[t].StudentWise[r].Theory_Exam;
                                }
                                else if (datademo[t].StudentWise[r].Theory_Exam == 0) {
                                    grade = datademo[t].StudentWise[r].Grade;
                                    if (datademo[t].Class_Id == 13) {
                                        //exammark = datademo[t].StudentWise[r].Theory_Exam;
                                        /**RajaChange**/
                                        EOY = datademo[t].StudentWise[r].Theory_Exam + " %";
                                        /**edit yesterday**/
                                        exammark = EOY;//datademo[t].StudentWise[r].Theory_Exam + " %";//RajaChange
                                    }
                                    /**RajaChange**/
                                    else if (datademo[t].Class_Id >= 7 && datademo[t].Class_Id <= 12) {
                                        EOY = roundfun(datademo[t].StudentWise[r].Theory_Exam);
                                        EOY = EOY + " %";
                                        if (MYE_Percent != 0 && MYE_Percent != '-')
                                            exammark = roundfun(MYE_Percent + EOY_Percent) + "%";
                                        else {
                                            /**change on 20 sep by aqil***/
                                            if (datademo[t].StudentWise[r].Criteria == null) {
                                                EOY = "-";
                                                exammark = "-";
                                            }
                                            else {
                                                exammark = EOY;
                                            }
                                            /**change on 20 sep by aqil***/
                                            //exammark = EOY;
                                        }
                                    }
                                    /**RajaChange**/

                                    else {

                                        //exammark = roundfun(datademo[t].StudentWise[r].Theory_Exam);
                                        //exammark = exammark + " %";
                                        /**RajaChange**/
                                        EOY = roundfun(datademo[t].StudentWise[r].Theory_Exam);
                                        EOY = EOY + " %";
                                        /**RajaChange**/
                                    }
                                    //exammark = roundfun(datademo[t].StudentWise[r].Theory_Exam);
                                }
                                else {
                                    grade = datademo[t].StudentWise[r].Grade;
                                    if (datademo[t].Class_Id == 13) {
                                        /**RajaChange**/
                                        EOY = roundfun(datademo[t].StudentWise[r].Theory_Exam);
                                        EOY = EOY + " %";
                                        exammark = EOY;
                                        /**RajaChange**/
                                        //exammark = datademo[t].StudentWise[r].Theory_Exam + " %";
                                    }
                                    else if (datademo[t].Class_Id >= 7 && datademo[t].Class_Id <= 12) {
                                        //EOY = datademo[t].StudentWise[r].Theory_Exam + " %";

                                        //if (MYE_Percent != 0 && MYE_Percent != '-')
                                        //    exammark = roundfun(MYE_Percent + EOY_Percent) + "%";
                                        //else {
                                        //    exammark = EOY;
                                        //}
                                        /**RajaChange**/
                                        EOY = roundfun(datademo[t].StudentWise[r].Theory_Exam);
                                        EOY = EOY + " %";
                                        if (MYE_Percent != 0 && MYE_Percent != '-')
                                            exammark = roundfun(MYE_Percent + EOY_Percent) + "%";
                                        else {
                                            exammark = EOY;
                                        }
                                        /**RajaChange**/
                                    }
                                    else {
                                        //exammark = roundfun(datademo[t].StudentWise[r].Theory_Exam);
                                        //exammark = exammark + " %";
                                        /**RajaChange**/
                                        EOY = roundfun(datademo[t].StudentWise[r].Theory_Exam);
                                        EOY = EOY + " %";
                                        /**RajaChange**/
                                    }
                                    //exammark = roundfun(datademo[t].StudentWise[r].Theory_Exam);
                                    //exammark = exammark + " %";
                                }

                                if (MYE_Percent == '-')
                                    MYE = MYE_Percent;
                                else {
                                    MYE = roundfun(datademo[t].StudentWise[r].Term1);
                                    MYE = MYE + "%";
                                }

                                /**change by raja 8apr2022**/
                                if (datademo[t].StudentWise[r].isAbsent == true) {
                                    grade = "-";
                                    EOY = "-";

                                }
                                if (datademo[t].StudentWise[r].Isabsent_FirstTem == true && MYE_Percent == '-') {
                                    MYE = "-";
                                }
                                /**Change by raja 6jun2022**/
                                if (datademo[t].StudentWise[r].Term1 == null) {
                                    MYE = "-";
                                }
                                /**Change by raja 6jun2022**/
                                if (datademo[t].StudentWise[r].isAbsent == true && datademo[t].StudentWise[r].Isabsent_FirstTem == true) {
                                    exammark = "-";
                                }

                                /**change by raja 8apr2022**/
                                reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 sec3">';
                                reportcard += '<table class="table  subjecttable">';
                                reportcard += '<tr class="text-center">';
                                reportcard += '<td rowspan="2"  class="centertd">' + datademo[t].StudentWise[r].Subject_Name + '</td>';
                                reportcard += '<td class="text-center">CA</td>';
                                reportcard += '<td class="text-center">Exam (Term 1)</td>';
                                reportcard += '<td class="text-center">Exam (Term 2)</td>';
                                reportcard += '<td class="text-center">Final Result</td>';

                                reportcard += '<td class="text-center">Grade</td>';
                                reportcard += '<td class="text-center norightborder">Effort</td>';
                                reportcard += '</tr>';
                                reportcard += '<tr>';
                                reportcard += '<td class="text-center">' + course_work + '</td>';
                                reportcard += '<td class="text-center">' + MYE + '</td>';
                                reportcard += '<td class="text-center">' + EOY + '</td>';
                                reportcard += '<td class="text-center">' + exammark + '</td>';//datademo[t].StudentWise[r].Theory_Exam

                                reportcard += '<td class="text-center">' + grade + '</td>';
                                reportcard += '<td class="text-center norightborder">' + effort + '</td>';
                                reportcard += '</tr>';
                                reportcard += '</table>';
                                reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 commentsec">';


                                if (datademo[t].StudentWise[r].Subject_Id == 17 || datademo[t].StudentWise[r].Subject_Id == 12 || datademo[t].StudentWise[r].Subject_Id == 133 || datademo[t].StudentWise[r].Subject_Id == 18) {
                                    reportcard += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                }
                                else {
                                    reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                }

                                //if (Session_Id == 12 && Term_Id == 1) {


                                //    reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                //}
                                //else {

                                //    if (datademo[t].Class_Id >= 7 && datademo[t].Class_Id <= 12) {

                                //        if (datademo[t].StudentWise[r].Subject_Id == 17 || datademo[t].StudentWise[r].Subject_Id == 12 || datademo[t].StudentWise[r].Subject_Id == 18) {



                                //            if (datademo[t].StudentWise[r].isAbsent == true) {
                                //                reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                //            }
                                //            else {
                                //                /**change by raja 10 may2021***/
                                //                if (datademo[t].StudentWise[r].is_comment == "0") {
                                //                    reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                //                }
                                //                else {


                                //                    reportcard += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + datademo[t].StudentWise[r].FirstName + '</span></span>' + remarks + '</p>';
                                //                }
                                //                /**change by raja 10 may2021***/

                                //                //reportcard += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + datademo[t].StudentWise[r].FirstName + '</span></span>' + remarks + '</p>';
                                //            }

                                //        }
                                //        else {

                                //            reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                //        }
                                //    }
                                //    else if (datademo[t].Class_Id == 13 && datademo[t].StudentWise[r].Subject_Id == 133) {


                                //        if (datademo[t].StudentWise[r].isAbsent == true) {
                                //            reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                //        }
                                //        else {
                                //            /**change by raja 10 may2021***/
                                //            if (datademo[t].StudentWise[r].is_comment == "0") {
                                //                reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                //            }
                                //            else {


                                //                reportcard += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + datademo[t].StudentWise[r].FirstName + '</span></span>' + remarks + '</p>';
                                //            }
                                //            /**change by raja 10 may2021***/
                                //            //reportcard += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + datademo[t].StudentWise[r].FirstName + '</span></span>' + remarks + '</p>';
                                //        }
                                //    }
                                //    else {

                                //        reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                //    }
                                //}

                                if (attendenceperc > 25) {
                                    if (datademo[t].Class_Id >= 7 && datademo[t].Class_Id <= 12) {

                                        if (datademo[t].StudentWise[r].Subject_Id == 17 || datademo[t].StudentWise[r].Subject_Id == 12 || datademo[t].StudentWise[r].Subject_Id == 18 || datademo[t].StudentWise[r].Subject_Id == 405) {

                                            if (datademo[t].StudentWise[r].isAbsent == true) {
                                                reportcard += '<div class="commentsec1 row rowdisplayflex  secondcommnetbox">';
                                                reportcard += '<table class="table-bordered table text-right">';
                                                reportcard += '<thead>';
                                                reportcard += '<tr>';
                                                reportcard += '<td class="text-center">قابلِ توجہ موضوعات</td>';
                                                reportcard += '<td class="text-center">مہارات</td>';

                                                reportcard += '</tr>';
                                                reportcard += '</thead>';
                                                reportcard += '<tbody>';
                                                reportcard += '<tr>';

                                                reportcard += '<td>';
                                                reportcard += '<ol class="nostylelist">';
                                                reportcard += '<li><span class="urdulisno">.۱</span>' + datademo[t].StudentWise[r].Improve1 + '</li>';
                                                reportcard += '<li><span class="urdulisno">.۲</span>' + datademo[t].StudentWise[r].Improve2 + '</li>';
                                                reportcard += '</ol>';
                                                reportcard += '</td>';
                                                reportcard += '<td>';
                                                reportcard += '<ol class="nostylelist">';
                                                reportcard += '<li><span class="urdulisno">.۱</span>' + datademo[t].StudentWise[r].Strength1 + '</li>';
                                                reportcard += '<li><span class="urdulisno">.۲</span>' + datademo[t].StudentWise[r].Strength2 + '</li>';
                                                reportcard += '</ol>';
                                                reportcard += '</td>';
                                                reportcard += '</tr>';

                                                reportcard += '</tbody>';
                                                reportcard += '</table>';
                                                reportcard += '</div>';
                                            }
                                            else {
                                                reportcard += '<div class="commentsec1 row rowdisplayflex secondcommnetbox">';
                                                reportcard += '<table class="table-bordered table text-right">';
                                                reportcard += '<thead>';
                                                reportcard += '<tr>';
                                                reportcard += '<td class="text-center">قابلِ توجہ موضوعات</td>';
                                                reportcard += '<td class="text-center">مہارات</td>';

                                                reportcard += '</tr>';
                                                reportcard += '</thead>';
                                                reportcard += '<tbody>';
                                                reportcard += '<tr>';
                                                reportcard += '<td>';
                                                reportcard += '<ol class="nostylelist">';
                                                reportcard += '<li><span class="urdulisno">.۱</span>' + datademo[t].StudentWise[r].Improve1 + '</li>';
                                                reportcard += '<li><span class="urdulisno">.۲</span>' + datademo[t].StudentWise[r].Improve2 + '</li>';
                                                reportcard += '</ol>';
                                                reportcard += '</td>';
                                                reportcard += '<td>';
                                                reportcard += '<ol class="nostylelist">';
                                                reportcard += '<li><span class="urdulisno">.۱</span>' + datademo[t].StudentWise[r].Strength1 + '</li>';
                                                reportcard += '<li><span class="urdulisno">.۲</span>' + datademo[t].StudentWise[r].Strength2 + '</li>';
                                                reportcard += '</ol>';
                                                reportcard += '</td>';
                                                reportcard += '</tr>';

                                                reportcard += '</tbody>';
                                                reportcard += '</table>';
                                                reportcard += '</div>';
                                            }
                                        }
                                        else {

                                            reportcard += '<div class="commentsec1 row rowdisplayflex secondcommnetbox">';
                                            reportcard += '<table class="table-bordered table">';
                                            reportcard += '<thead>';
                                            reportcard += '<tr>';
                                            reportcard += '<td class="text-center">Strengths</td>';
                                            reportcard += '<td class="text-center">Areas for Improvement</td>';
                                            reportcard += '</tr>';
                                            reportcard += '</thead>';
                                            reportcard += '<tbody>';
                                            reportcard += '<tr>';
                                            reportcard += '<td>';
                                            reportcard += '<ol>';
                                            reportcard += '<li>' + datademo[t].StudentWise[r].Strength1 + '</li>';
                                            reportcard += '<li>' + datademo[t].StudentWise[r].Strength2 + '</li>';
                                            reportcard += '</ol>';
                                            reportcard += '</td>';
                                            reportcard += '<td>';
                                            reportcard += '<ol>';
                                            reportcard += '<li>' + datademo[t].StudentWise[r].Improve1 + '</li>';
                                            reportcard += '<li>' + datademo[t].StudentWise[r].Improve2 + '</li>';
                                            reportcard += '</ol>';
                                            reportcard += '</td>';
                                            reportcard += '</tr>';

                                            reportcard += '</tbody>';
                                            reportcard += '</table>';
                                            reportcard += '</div>';
                                        }
                                    }
                                    else if ((datademo[t].Class_Id == 13 || datademo[t].Class_Id == 14) && datademo[t].StudentWise[r].Subject_Id == 133) {
                                        if (datademo[t].StudentWise[r].isAbsent == true) {
                                            reportcard += '<div class="commentsec1 row rowdisplayflex secondcommnetbox">';
                                            reportcard += '<table class="table-bordered table text-right">';
                                            reportcard += '<thead>';
                                            reportcard += '<tr>';
                                            reportcard += '<td class="text-center">قابلِ توجہ موضوعات</td>';
                                            reportcard += '<td class="text-center">مہارات</td>';

                                            reportcard += '</tr>';
                                            reportcard += '</thead>';
                                            reportcard += '<tbody>';
                                            reportcard += '<tr>';
                                            reportcard += '<td>';
                                            reportcard += '<ol class="nostylelist">';
                                            reportcard += '<li><span class="urdulisno">.۱</span>' + datademo[t].StudentWise[r].Improve1 + '</li>';
                                            reportcard += '<li><span class="urdulisno">.۲</span>' + datademo[t].StudentWise[r].Improve2 + '</li>';
                                            reportcard += '</ol>';
                                            reportcard += '</td>';
                                            reportcard += '<td>';
                                            reportcard += '<ol class="nostylelist">';
                                            reportcard += '<li><span class="urdulisno">.۱</span>' + datademo[t].StudentWise[r].Strength1 + '</li>';
                                            reportcard += '<li><span class="urdulisno">.۲</span>' + datademo[t].StudentWise[r].Strength2 + '</li>';
                                            reportcard += '</ol>';
                                            reportcard += '</td>';
                                            reportcard += '</tr>';

                                            reportcard += '</tbody>';
                                            reportcard += '</table>';
                                            reportcard += '</div>';
                                        }
                                        else {
                                            reportcard += '<div class="commentsec1 row rowdisplayflex secondcommnetbox">';
                                            reportcard += '<table class="table-bordered table text-right">';
                                            reportcard += '<thead>';
                                            reportcard += '<tr>';
                                            reportcard += '<td class="text-center">قابلِ توجہ موضوعات</td>';
                                            reportcard += '<td class="text-center">مہارات</td>';

                                            reportcard += '</tr>';
                                            reportcard += '</thead>';
                                            reportcard += '<tbody>';
                                            reportcard += '<tr>';
                                            reportcard += '<td>';
                                            reportcard += '<ol class="nostylelist">';
                                            reportcard += '<li><span class="urdulisno">.۱</span>' + datademo[t].StudentWise[r].Improve1 + '</li>';
                                            reportcard += '<li><span class="urdulisno">.۲</span>' + datademo[t].StudentWise[r].Improve2 + '</li>';
                                            reportcard += '</ol>';
                                            reportcard += '</td>';
                                            reportcard += '<td>';
                                            reportcard += '<ol class="nostylelist">';
                                            reportcard += '<li><span class="urdulisno">.۱</span>' + datademo[t].StudentWise[r].Strength1 + '</li>';
                                            reportcard += '<li><span class="urdulisno">.۲</span>' + datademo[t].StudentWise[r].Strength2 + '</li>';
                                            reportcard += '</ol>';
                                            reportcard += '</td>';
                                            reportcard += '</tr>';

                                            reportcard += '</tbody>';
                                            reportcard += '</table>';
                                            reportcard += '</div>';
                                        }
                                    }
                                    else {

                                        reportcard += '<div class="commentsec1 row rowdisplayflex  secondcommnetbox">';
                                        reportcard += '<table class="table-bordered table">';
                                        reportcard += '<thead>';
                                        reportcard += '<tr>';
                                        reportcard += '<td class="text-center">Strengths</td>';
                                        reportcard += '<td class="text-center">Areas for Improvement</td>';
                                        reportcard += '</tr>';
                                        reportcard += '</thead>';
                                        reportcard += '<tbody>';
                                        reportcard += '<tr>';
                                        reportcard += '<td>';
                                        reportcard += '<ol>';
                                        reportcard += '<li>' + datademo[t].StudentWise[r].Strength1 + '</li>';
                                        reportcard += '<li>' + datademo[t].StudentWise[r].Strength2 + '</li>';
                                        reportcard += '</ol>';
                                        reportcard += '</td>';
                                        reportcard += '<td>';
                                        reportcard += '<ol>';
                                        reportcard += '<li>' + datademo[t].StudentWise[r].Improve1 + '</li>';
                                        reportcard += '<li>' + datademo[t].StudentWise[r].Improve2 + '</li>';
                                        reportcard += '</ol>';
                                        reportcard += '</td>';
                                        reportcard += '</tr>';

                                        reportcard += '</tbody>';
                                        reportcard += '</table>';
                                        reportcard += '</div>';
                                    }
                                }

                                //reportcard += '<p class="text-right commentsectec captilizetext"><strong class="teachername">Teacher:</strong>' + fullname + '</p>';
                                reportcard += '</div>';
                                reportcard += '</div>';

                                /***3 boxes on every student first page**/
                                if (r == 2) {
                                    reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom pehlewala">';/*<p>ok</p>*/
                                    reportcard += '</div>';
                                    reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex printmediabordertopafter3">';
                                    reportcard += '<p><span>' + datademo[t].StudentName + "-" + datademo[t].Student_Id + '</span><span class="floatright">' + datademo[t].Center_Name + '</span></p>';
                                    reportcard += '</div>';
                                    count = 0;
                                }

                                /***3 boxes on every student first page**/
                                /***5 boxes on every student page**///count == 5
                                //if (count > 5) {
                                //    reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom pehlewala 5wla">';/*<p>ok</p>*/
                                //    reportcard += '</div>';

                                //    reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex printmediabordertopafter3">';
                                //    reportcard += '<p><span>' + datademo[t].StudentName + "-" + datademo[t].Student_Id + '</span><span class="floatright">' + datademo[t].Center_Name + '</span></p>';
                                //    reportcard += '</div>';
                                //    count = 0;
                                //}
                                if (count == 5 && r == datademo[t].StudentWise.length - 1) {
                                    //reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom pehlewala 5wla">';/*<p>ok</p>*/
                                    //reportcard += '</div>';

                                    //reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex printmediabordertopafter3">';
                                    //reportcard += '<p><span>' + datademo[t].StudentName + "-" + datademo[t].Student_Id + '</span><span class="floatright">' + datademo[t].Center_Name + '</span></p>';
                                    //reportcard += '</div>';
                                    count = 0;
                                }
                                if (count == 5) {
                                    reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom pehlewala 5wla">';/*<p>ok</p>*/
                                    reportcard += '</div>';

                                    reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex printmediabordertopafter3">';
                                    reportcard += '<p><span>' + datademo[t].StudentName + "-" + datademo[t].Student_Id + '</span><span class="floatright">' + datademo[t].Center_Name + '</span></p>';
                                    reportcard += '</div>';
                                    count = 0;
                                }

                                /***5 boxes on every student page**/
                                count++;
                            }
                            /**IS PROMOTED**/

                            if (datademo[t].isPromoted == false && datademo[t].Cond_Prom == false) {
                                if ((datademo[t].Region_Name == "(TCS)-Central Region" || datademo[t].Region_Name == "(TCS) Northern Region") && datademo[t].Class_Id == 12) {
                                    reportcard += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 notpromoted">Contact school management for promotion</div>';
                                }
                                else if (datademo[t].Region_Name == "(TCS)-Southern Region" && datademo[t].Class_Id == 12) {
                                    reportcard += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 notpromoted">Bifurcated to Class 9 (Matric)</div>';
                                } else {
                                    reportcard += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 notpromoted">Not Promoted</div>';
                                }
                            }

                            if (datademo[t].isPromoted == false && datademo[t].Cond_Prom == true) {
                                reportcard += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 ispromoted">Discretionarily Promoted  to ' + datademo[t].RequestedClass + '</div>';

                            }
                            if (datademo[t].isPromoted == true && datademo[t].Cond_Prom == false) {
                                reportcard += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 ispromoted">Promoted to ' + datademo[t].PromotedToClass + '</div>';
                            }
                                                        
                            if (datademo[t].isPromoted == true && datademo[t].Cond_Prom == true) {
                                reportcard += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 ispromoted">Discretionarily Promoted  to ' + datademo[t].RequestedClass + '</div>';
                            }
                             
                            /**IS PROMOTED**/

                            if (t != datademo.length - 1) {//this condition is for last page of pdf no page break after that
                                reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom pehlewala">';/*<p>ok</p>*/
                                reportcard += '</div>';
                            }

                        }//iscomplete end
                    }

                    $(".firstthreetable").html(reportcard);
                    //$(".remainingtable").html(reportcard3);

                    //$(".attendenceclass").text(attendence);
                    //$(".attendencetotal").text(result[0].FirstTermDaysCH+" days");
                    //$(".dobclass").text(formatdate(result[0].Date_Of_Birth));
                    //$(".fullnamestudent").text(result[0].StudentName);
                    //$(".classname").text(result[0].Class_Name);
                    //$(".classsec").text(result[0].Section_Name);
                    //$(".termname").text(result[0].Evaluation_Criteria_Type_Name);

                    //$(".yearname").text(result[0].Description.replace("AY", ''));
                    //$(".headerstudentname").text(result[0].StudentName+"-"+result[0].Student_Id);
                    //$(".headerstudentcenter").text(result[0].Center_Name);
                }, complete: function () {
                    /*$('.costgraph').css({
                        'cssText': 'background:none !important'
                    });*/
                    $(".overlay").hide();
                    $('.container').on('scroll touchmove mousewheel');
                }, error: function (err) {
                    console.log(JSON.stringify(err));
                }
            });

            //***PWA****/
            if ('serviceWorker' in navigator) {
                navigator.serviceWorker.register('./Content/service-worker.js').then(res => {
                    //alert('SW register');
                }).catch(err => {
                    // alert("Error SW", err);
                })
            }
            else {
                console.log('SW Not supported');
            }
            //***PWA****/
            /****QR CODE***/
            $('#qrcode').empty();

            // Set Size to Match User Input
            $('#qrcode').css({
                'width': $('.qr-size').val(),
                'height': $('.qr-size').val()
            })

            // Generate and Output QR Code
            $('#qrcode').qrcode({ width: $('.qr-size').val(), height: $('.qr-size').val(), text: "https://www.codegrepper.com/code-examples/javascript/jquery+get+url+parameter" });//$('.qr-url').val()

            //});
            /****QR CODE***/
        });

        function roundfun(item) {
            return Math.round(item);
        }
    </script>
    <style>
        /*.overlay {
            background: url('./images/loader.gif') no-repeat center center;
            background-size: cover;
            position: fixed;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            z-index: 9999999;
            background-color: rgba(0,0,0,0.5);
            display: none;
        }*/
        .overlay {
            background: url('logo2.gif') no-repeat center center; /*loader.gif*/
            position: fixed;
            top: 0;
            left: 0;
            height: 100%;
            width: 100%;
            z-index: 9999999;
            background-color: rgba(0,0,0,0.5);
        }
    </style>
</body>
</html>
