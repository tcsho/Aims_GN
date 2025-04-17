<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EOY2023OLevel.aspx.cs" Inherits="PresentationLayer_TCS_ReportCard_EOY2023OLevel" %>



<!DOCTYPE html>
<html>
<head>
    <!--<script src="jquery-1.10.2.js" type="text/JavaScript" language="javascript"></script>-->
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

    <link type="text/css" rel="stylesheet" href="jquery-ui-1.10.4.custom.css" />

    <link type="text/css" rel="stylesheet" href="Matricresult.css" />                <!-- Y : rel is stylesheet and media is in [all,print,empty,undefined] -->
    <link type="text/css" rel="stylesheet" href="media_all.css" media="all" />   <!-- Y : rel is stylesheet and media is in [all,print,empty,undefined] -->
    <link type="text/css" rel="" href="empty.css" />                    <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="noPrint" href="noPrint.css" />                  <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="stylesheet" href="media_none.css" media="xyz" />   <!-- N : media not in [all,print,empty,undefined] -->
    <link type="text/css" href="no_rel.css" media="print" /> <!-- N : no rel attribute -->
    <link type="text/css" href="no_rel_no_media.css" /> <!-- N : no rel, no media attributes -->
    <link rel="stylesheet" type="text/css" href="bootstrap.min.css">
    <!--<link rel="stylesheet" type="text/css"  href="bootstrap/css/bootstrap.css.map">-->
    <script src="popper.min.js"></script>
    <script src="bootstrap.min.js"></script>
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


            </div>

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

                        var zresult = scids.includes("Z" || "z");

                        if (zresult == true) {
                            zexists = true;
                        }

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


            var Roll_Number = GetUrlParameter('b');
            var Session_Id = GetUrlParameter('d');
            var Term_Id = GetUrlParameter('a');
            var Class_Id = GetUrlParameter('c');
            console.log("Roll NUmber" + Roll_Number + "------" + "Session_Id" + Session_Id + "Term_Id" + Term_Id + "Section" + Class_Id);

            /****DECREPT CODE***/

            reportfun();

            $('.container').off('scroll touchmove mousewheel');

            var alreadyt = "";

            var Student_array = [];
            Student_array.length = 0;
            var datademo = [];
            datademo.length = 0;
            var reportcard = "";
            var overall = "";

            function reportfun() {
                $.ajax({
                    url: "EOY2023OLevel.aspx/test",
                    // data: "{querytype: '1'}",
                    //data: "{ TermGroup_Id:" + Session_Id + ", TermGroup_Id :" + Term_Id + ", Section_Id:" + Class_Id + ", Student_Id: " + Roll_Number + " }",
                    data: "{TermGroup_Id: " + Term_Id + ", Student_Id:" + Roll_Number + ", Class_Id: " + Class_Id + ", Session_Id: " + Session_Id + "}",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        console.log(JSON.stringify(result));
                        var result = JSON.parse(result.d);

                        if (result.length == 0) {
                            reportcard = "<div class='alert error'>";
                            reportcard += "<span class='alertText'>"
                            reportcard += "For the report card, please get in touch with the school as some entries are missing. We are sorry for the inconvenience.";
                            reportcard += "<br class='clear' /></span>";
                            reportcard += "</div>";

                            $(".serachprinttable").append(reportcard);
                            return;
                        }

                        //if (result[0].isFeeDefaulter && Roll_Number != "0") {
                        //    let TermName = 'Second Term Report Card';
                        //    let SessionCode = '2022-2023';

                        //    reportcard = "<div class='alert error'>";
                        //    reportcard += "<span class='alertText'>"
                        //    reportcard += "Your child's " + TermName + " " + SessionCode + " is ready. After the payment of pending dues, the report card will be accessible via the link in two business days.";
                        //    reportcard += "<br class='clear' /></span>";
                        //    reportcard += "</div>";

                        //    $(".serachprinttable").append(reportcard);
                        //    return;
                        //}

                        let studentIds = [...new Set(result.map((p) => p.Student_Id))];
                        let lst = [];

                        studentIds.forEach((studentId, i) => {
                            let studentResults = result.filter((p) => p.Student_Id == studentId);
                            let student = {
                                Student_Id: studentId,
                                result: studentResults,
                            };
                            lst.push(student);
                        });


                        for (var i = 0; i < lst.length; i++) {

                            var effort;
                            var remarks;
                            var comments;
                            var fullname;
                            var course_work;
                            var grade;
                            datademo = [];
                            datademo.length = 0;

                            for (var j = 0; j < lst[i].result.length; j++) {
                                let itr = lst[i].result[j];
                                if (alreadyt != itr.Subject_Id) {
                                    /**FIRST tIME USER**/
                                    if (alreadyt == "") {
                                        Student_array.push({

                                            Percent_Marks: itr.Percent_Marks,

                                            Comp: itr.Comp,
                                            Weightage: itr.Weightage
                                        });

                                        datademo.push({

                                            First_Name: itr.First_Name,
                                            Class_name: itr.Class_name,
                                            Student_Id: itr.Student_Id,
                                            Subject: itr.SUBJECT,
                                            SubjectNameCom: itr.SubjectNameCom,
                                            CA: itr.CA,
                                            Center_Name: itr.Center_Name,
                                            Date_Of_Birth: itr.Date_Of_Birth,
                                            HeadName: itr.HeadName,
                                            Marks: itr.Marks,
                                            Overall_P: itr.Overall_P,
                                            Overall_G: itr.Overall_G,
                                            Grade: itr.Grade,
                                            DaysAttend: itr.DaysAttend,
                                            TotalTermDays: itr.TotalTermDays,
                                            HeadName: itr.HeadName,
                                            StudentWise: Student_array,
                                            Section_Name: itr.Section_Name,

                                        });
                                        alreadyt = itr.Subject_Id;
                                    }
                                    /**FIRST tIME USER**/

                                    else {
                                        Student_array = [];
                                        Student_array.push({

                                            Percent_Marks: itr.Percent_Marks,

                                            Comp: itr.Comp,
                                            Weightage: itr.Weightage
                                        });

                                        datademo.push({

                                            First_Name: itr.First_Name,
                                            Class_name: itr.Class_name,
                                            Student_Id: itr.Student_Id,
                                            Subject: itr.SUBJECT,
                                            SubjectNameCom: itr.SubjectNameCom,
                                            CA: itr.CA,
                                            Center_Name: itr.Center_Name,
                                            Date_Of_Birth: itr.Date_Of_Birth,
                                            HeadName: itr.HeadName,
                                            Marks: itr.Marks,
                                            Overall_P: itr.Overall_P,
                                            Overall_G: itr.Overall_G,
                                            Grade: itr.Grade,
                                            DaysAttend: itr.DaysAttend,
                                            TotalTermDays: itr.TotalTermDays,
                                            HeadName: itr.HeadName,
                                            StudentWise: Student_array,
                                            Section_Name: itr.Section_Name,
                                        });
                                        alreadyt = itr.Subject_Id;
                                    }
                                }
                                else {

                                    Student_array.push({

                                        Percent_Marks: itr.Percent_Marks,
                                        Comp: itr.Comp,
                                        Weightage: itr.Weightage

                                    });
                                }

                            }//For loop end
                            //console.log("demo" + JSON.stringify(datademo));

                            /**div**/
                            reportcard += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 no-padding'>";

                            reportcard += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex'>";
                            reportcard += "<p><span class='headerstudentname'>" + datademo[0].First_Name + "-" + datademo[0].Student_Id + "</span><span class='floatright headerstudentcenter'>" + datademo[0].Center_Name + "</span></p>";

                            reportcard += "</div>";
                            reportcard += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 sec1 article'>";


                            reportcard += "<div class='row rowdisplayflex headerwithlogo margintoponlogo'>";
                            reportcard += "<div class='col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass'>";

                            reportcard += "</div>";
                            reportcard += "<div class='col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign'>";
                            reportcard += "<h4 class='uppertxtinnewreportmargin'><span class='termname'></span><span class='yearname'>Second Term Report Card 2022-2023</span></h4>";

                            reportcard += "<h4 class='fullnamestudent'>" + datademo[0].First_Name + "</h4>";
                            reportcard += "<h4> <span class='classname'>" + datademo[0].Class_name + "-" + datademo[0].Section_Name + "</span></h4>";

                            reportcard += "</div>";
                            reportcard += "<div class='col-lg-3 col-md-3 col-sm-3 col-xs-3 text-mediaalignright schoollogoNew'>";

                            reportcard += "<img src='newlogonewr.png'/>";
                            reportcard += "</div>";
                            reportcard += "</div>";

                            reportcard += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 dobtable'>";
                            reportcard += "<table>";
                            reportcard += "<tr><td><strong>Date of Birth:</strong>  </td><td class='dobclass'>" + formatdate(datademo[0].Date_Of_Birth) + "</td></tr>";

                            var attendenceperc = (datademo[0].DaysAttend / datademo[0].TotalTermDays) * 100;
                            var attendence;

                            if (attendenceperc < 25) {
                                attendence = "Low";
                            }
                            else {
                                attendence = datademo[0].DaysAttend;
                            }

                            reportcard += '<tr><td><strong>Attendance:</strong> </td><td><span class="attendenceclass">' + attendence + '</span> (out of <span class="attendencetotal">' + datademo[0].TotalTermDays + " days" + '</span>)</td></tr>';

                            reportcard += "</table>";
                            reportcard += "</div>";

                            reportcard += "</div>";

                            reportcard += "<div class='row sec2 article'>";

                            reportcard += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 floatleft mediawidth'>";
                            reportcard += "<h4>Understanding your child<span class='fontchange'>'</span>s report</h4>";
                            reportcard += "<ul>";

                            reportcard += "<li class='exm_9'>";
                            reportcard += "<strong>Exam:</strong> Percentage achieved in the final results.";
                            reportcard += "</li>";
                            reportcard += "<li><strong> CA:</strong>Continuous Assessment marks given during regular classes.</li>";

                            reportcard += "<li><strong>Grade:</strong> A*-E or U (Ungraded) is given based on the final results.</li>";

                            reportcard += "<table id='id_olevel' class='table-bordered graphtable olevel'>";
                            reportcard += "<tr>";

                            reportcard += "<td>A*</td>";
                            reportcard += "<td>A</td>";
                            reportcard += "<td>B</td>";
                            reportcard += "<td>C</td>";
                            reportcard += "<td>D</td>";
                            reportcard += "<td>E</td>";
                            reportcard += "<td>U</td>";
                            reportcard += "</tr>";
                            reportcard += "<tr>";

                            reportcard += "<td>&#8805 90%</td>";
                            reportcard += "<td>80-89</td>";
                            reportcard += "<td>70-79</td>";
                            reportcard += "<td>60-69</td>";
                            reportcard += "<td>50-59</td>";
                            reportcard += "<td>40-49</td>";

                            reportcard += "<td>< 40%</td>";
                            reportcard += "</tr>";

                            reportcard += "</table>";

                            reportcard += "</ul>";
                            reportcard += "</div>";

                            //reportcard += "<div class='headsigndiv'>";
                            //reportcard += "<div class='col-lg-9 col-md-6 col-sm-6 col-xs-6 floatleft mediawidthlg8'>";
                            //reportcard += "<p style='width:100%' class='visiblity-hidden_class'>p</p>";
                            //reportcard += "</div>";
                            //reportcard += "<div class='col-lg-3 col-md-6 col-sm-6 col-xs-6 floatleft mediawidthlg4'>";
                            //reportcard += "<label class='headsign form-control text-center'>" + datademo[0].HeadName + "</label>";
                            //reportcard += "<label class='label-100'> Head of School</label > ";
                            //reportcard += "</div>";
                            //reportcard += "</div>";

                            reportcard += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 tabledivc'>";

                            reportcard += "<table class='table  subjecttable martictable marticsubjecttable'>";

                            reportcard += "<thead>";
                            reportcard += "<tr class='text-center'>";


                            reportcard += "<td rowspan='2' class='centertd font-weight-bold'>Subject</td>";

                            reportcard += "<td class='text-center centertd font-weight-bold' rowspan ='2'>CA</td>";


                            reportcard += "<td class='text-center font-weight-bold' colspan='5'>Exam</td>";


                            reportcard += "</tr>";

                            reportcard += "<tr>";

                            reportcard += "<td class='text-center font-weight-bold'>Component</td>";
                            reportcard += "<td class='text-center font-weight-bold'>Weightage %</td>";

                            reportcard += "<td class='text-center font-weight-bold'>Component Marks</td>";

                            reportcard += "<td class='text-center norightborder font-weight-bold'>Net %</td>";
                            reportcard += "<td class='text-center norightborder font-weight-bold'>Grade</td>";
                            reportcard += "</tr>";
                            reportcard += "</thead>";
                            reportcard += "<tbody>";

                            /**div**/

                            for (var t = 0; t < datademo.length; t++) {
                                var count = 0;

                                reportcard += "<tr>";
                                if (Session_Id == 14 && Term_Id == 2) {
                                    reportcard += "<td style='width: 20%!important;'>" + datademo[t].Subject + "</td>";
                                } else {
                                    reportcard += "<td style='width: 20%!important;'>" + datademo[t].SubjectNameCom + "</td>";
                                }
                                if (datademo[t].CA != "-") { reportcard += "<td style='width: 6% !important;'>" + roundfun(datademo[t].CA) + "</td>"; } else { reportcard += "<td style='width: 6% !important;'>" + datademo[t].CA + "</td>"; }
                                //reportcard += "<td>" + roundfun(datademo[t].CA) + "</td>";
                                reportcard += "<td style='width: 23%!important;'>";
                                for (var st = 0; st < datademo[t].StudentWise.length; st++) {
                                    reportcard += "<p style='margin-bottom:0px !important;'>" + datademo[t].StudentWise[st].Comp + "</p>";
                                }

                                reportcard += "</td>";
                                reportcard += "<td>";

                                for (var st = 0; st < datademo[t].StudentWise.length; st++) {
                                    reportcard += "<p style='margin-bottom:0px !important;'>" + datademo[t].StudentWise[st].Weightage + "</p>";
                                }
                                reportcard += "</td>";
                                reportcard += "<td>";
                                for (var st = 0; st < datademo[t].StudentWise.length; st++) {
                                    reportcard += "<p style='margin-bottom:0px !important;'>" + datademo[t].StudentWise[st].Percent_Marks + "</p>";
                                }
                                reportcard += "</td>";

                                if (datademo[t].Marks == 0) {
                                    reportcard += "<td>-</td>";
                                    reportcard += "<td>-</td>";
                                } else {
                                    reportcard += "<td>" + roundfun(datademo[t].Marks) + "</td>";
                                    reportcard += "<td>" + datademo[t].Grade + "</td>";
                                }

                                reportcard += "</tr>";

                            }

                            reportcard += "</tbody>";
                            reportcard += "</table>";

                            reportcard += "<table class='table  subjecttable martictable margintoptb marticoveralltable'>";
                            reportcard += "</table>";

                            reportcard += "</div>";

                            reportcard += "</div>";

                            reportcard += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 incomplete text-center'>";
                            reportcard += "</div>";

                            reportcard += "<div class='col-lg-12 col-md-12 col-sm-12 col-xs-12 no-padding'>";
                            reportcard += "<div class='reporttable article'>";

                            reportcard += "</div>";
                            reportcard += "</div>";

                            reportcard += "</div><div style='break-after: page'></div>";
                        }
                        $(".serachprinttable").append(reportcard);
                    }, complete: function () {
                        $(".overlay").hide();
                        $('.container').on('scroll touchmove mousewheel');
                    }, error: function (err) {
                        console.log(JSON.stringify(err));
                    }
                });
            }
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

        .alert {
            position: relative;
            top: 50px;
            left: 0;
            width: auto;
            height: auto;
            padding: 10px;
            margin: 10px;
            line-height: 1.8;
            border-radius: 5px;
            cursor: hand;
            cursor: pointer;
            font-family: sans-serif;
            font-weight: 400;
        }

        .error {
            background-color: #FEE;
            border: 1px solid #EDD;
            color: #A66;
        }

        .alertText {
            display: table;
            margin: 0 auto;
            text-align: center;
            font-size: 16px;
        }
    </style>
</body>
</html>
