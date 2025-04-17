<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EOY2021.aspx.cs" Inherits="PresentationLayer_TCS_ReportCard_EOY2021" %>


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

    <link type="text/css" rel="stylesheet" href="PrintArea3EOY.css" />                <!-- Y : rel is stylesheet and media is in [all,print,empty,undefined] -->
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

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 no-padding">

                    <!--section 1--->

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex">
                        <p><span class="headerstudentname"></span><span class="floatright headerstudentcenter"></span></p>

                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 sec1 article">
                        <!--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <h5 class="text-right">S013-GulshanABoysCampusKarachi</h5>
                        </div>-->
                        <!--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <h2 class="text-right schoolname">The City School</h2>

                        </div>-->

                        <div class="row rowdisplayflex headerwithlogo margintoponlogo">
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 visiblity-hidden_mediaclass">
                                <!--visiblity-hidden_mediaclass-->
                                <!--<div id="qrcode"></div>-->
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign">
                                <h4 class="uppertxtinnewreportmargin"><span class="termname"></span> Report Card <span class="yearname">2020-2021</span></h4>
                                <h4 class="fullnamestudent"></h4>
                                <h4><span class="classname"></span> - <span class="classsec"></span></h4>

                            </div>
                            <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-mediaalignright schoollogoNew">
                                <!--<img src="images/newlogo.png" />-->
                                <img src="newlogonewr.png" />
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 dobtable">
                            <table>
                                <tr><td><strong>Date of Birth:</strong>  </td><td class="dobclass"></td></tr>
                                <tr><td><strong>Attendance:</strong> </td><td><span class="attendenceclass"></span> (Out of <span class="attendencetotal"></span>)</td></tr>
                            </table>
                        </div>

                        <!--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 commentbox">
                             <div class="form-group">

                              <textarea class="form-control comments" rows="5" style="resize: none;"></textarea>
                            </div>
                        </div>-->
                    </div>

                    <!--section 1--->
                    <!--section 2--->


                    <div class="row sec2 article">

                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 floatleft mediawidth">
                            <h4>Understanding your child<span class="fontchange">'</span>s report</h4>
                            <ul>
                                <li class="exm_9">
                                    <strong>Exam:</strong> Percentage achieved in the final results.
                                </li>
                                <li class="exm_3-8">
                                    <strong> Final result:</strong> 10% of Term 1 result+90% of Term 2 result.
                                </li>
                                <li>
                                    <strong>CA:</strong>
                                    Continuous Assessment marks given during regular classes.
                                </li>
                                <li><strong>Grade:</strong> A*- E or U (Ungraded) is given based on the final results.</li>

                                <table class="table-bordered graphtable">
                                    <tr>
                                        <td>A*</td>
                                        <td>A</td>
                                        <td>B</td>
                                        <td>C</td>
                                        <td>D</td>
                                        <td>E</td>
                                        <td>U</td>
                                    </tr>
                                    <tr>
                                        <td>&#8805 90%</td>
                                        <td>80-89</td>
                                        <td>70-79</td>
                                        <td>60-69</td>
                                        <td>50-59</td>
                                        <td>40-49</td>
                                        <td>< 40%</td>
                                    </tr>


                                </table>
                                <!--<p class="grpgmsg">In some subjects, exams contributed to the Continuous Assessment percentage and so no exam grade is given.</p>-->
                                <li><strong>Effort:</strong> A teacher judgement describing how much effort your child puts into his/her studies.</li>


                            </ul>
                        </div>

                        <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 floatleft ">
                            <!-- efforttablediv -->
                            <table class="table-bordered effort-table">
                                <tr class="text-center"><td colspan="2" style=" background:#e4e4e4 !important;">Effort</td></tr>
                                <tr><td>Excellent</td><td>1</td></tr>
                                <tr><td>Good</td><td>2</td></tr>
                                <tr><td>Satisfactory</td><td>3</td></tr>
                                <tr><td>Needs improvement</td><td>4</td></tr>
                            </table>
                        </div>

                        <div class="headsigndiv">
                            <div class="col-lg-9 col-md-6 col-sm-6 col-xs-6 floatleft mediawidthlg8">
                                <p style="width: 100%" class="visiblity-hidden_class">p</p>
                            </div>
                            <div class="col-lg-3 col-md-6 col-sm-6 col-xs-6 floatleft mediawidthlg4">
                                <!--<input type="text" name="headsign" class="headsign form-control text-center" disabled>-->
                                <label class="headsign form-control text-center">Head of School</label>
                                <label class="label-100 ">Head of School</label>
                            </div>
                        </div>

                    </div>
                    <!--section 2--->
                    <!--incomplete-->
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 incomplete text-center"></div>
                    <!--incomplete-->
                    <!--section 3--->
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 no-padding">
                        <div class="reporttable article">
                            <div class="firstthreetable"></div>
                            <div class="remainingtable"></div>
                        </div>
                    </div>
                    <!--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 sec3">
                                <table class="table table-bordered subjecttable">
                                        <tr class="text-center">
                                            <td class="centertd">Mathematics</td>
                                        <td style="padding: 0px !important;">
                                            <table class="table no-table-border">
                                            <tr>
                                                <td>Exam</td>

                                                <td>CA</td>

                                                <td>Grade</td>

                                                <td>Effort</td>
                                            </tr>
                                            <tr>
                                                <td>72%</td>

                                                <td>68%</td>

                                                <td>A</td>

                                                <td>2</td>
                                            </tr>
                                        </table>
                                        </td>

                                        </tr>
                                    </table>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <p>During  this term, Ahmed did well in subtracting two 3-digit numbers and solving division word problems. Ahmedneeds to revise his work on comparing and ordering fractions and converting between dollars and cents.</p>
                    <p>I am really  pleased with Ahmed’sattitude during lessons and the way he asks questions when unsure of a concept. I would like to see an improvement in hispresentation by using a ruler to draw lines. Also, he should practise his work on adding fractions.</p>
                    <p class="text-right"><strong>Teacher:</strong> Shenal Irenga</p>
                                    </div>
                            </div>-->
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
            //var Roll_Number="189570";
            //var Session_Id="11";
            //var Class_Id=13;
            var count = 1;
            //const value = encodeURIComponent(Roll_Number)+"&"+encodeURIComponent(Session_Id)+"&"+encodeURIComponent(Class_Id);
            //const url = 'http://example.com?lang=en&key=' + value;
            //var uri_dec = decodeURIComponent(url);
           
            var uri = window.location.href;
            var enc = encodeURIComponent(uri).replace('%20', '+');
            var dec = decodeURIComponent(enc);
            var res = "Encoded URI: " + enc + "<br>" + "Decoded URI: " + dec;
            //console.log("LINKS:"+res);
            var sURLVariableswithurl = "";
            function GetUrlParameter(sParam) {
                var sPageURL = dec;//window.location.search.substring(1);

                sURLVariableswithurl = sPageURL.split('?');
                var sURLVariables = sURLVariableswithurl[1].split('&');

                for (var i = 0; i < sURLVariables.length; i++) {
                    var sParameterName = sURLVariables[i].split('=');

                    if (sParameterName[0] == sParam) {
                        //return sParameterName[1];
                        /*******************************DECRPT in Function*******************/
                        var scids = sParameterName[1];
                        /**Z Redirect for email */
                        
                        /**Z Redirect for email */


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



            // int SD, int TG, int SCID, int SDid = 0


            var Roll_Number = GetUrlParameter('d');
            var Session_Id = GetUrlParameter('b');
            var Term_Id = GetUrlParameter('c');
            var Sec_Id = GetUrlParameter('a');
            console.log("Roll NUmber" + Roll_Number + "------" + "Session_Id" + Session_Id + "Term_Id" + Term_Id + "Section" + Sec_Id);

            //alert("url"+sURLVariableswithurl[0]+"Roll_Number"+Roll_Number+"<br>"+"Session_Id"+Session_Id+"<br>"+"Class_Id"+Class_Id);
            /****DECREPT CODE***/

            
            $('.container').off('scroll touchmove mousewheel');
          
                $.ajax({
                    url: "EOY2021.aspx/test",
                   
                    data: "{ Session_Id:" + Session_Id + ", TermGroup_Id :" + Term_Id + ", Section_Id:" + Sec_Id + ", Student_Id: " + Roll_Number + " }",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        console.log(JSON.stringify(result));
                        var result = JSON.parse(result.d);
                        //var feedeafaulter = result[0].isFeeDefaulter;
                        //if (feedeafaulter==true)
                        //{
                        //    $(".overlay").hide();
                        //    Swal.fire(
                        //        'No Data',
                        //        '',
                        //        'error'
                        //    )
                        //    return;
                        //}

                        console.log("ss" + JSON.stringify(result));
                        //if (result[0].Class_Id == 13) {
                        //    $('.exm_3-8').hide();
                        //    $('.exm_9').show();
                        //}
                        //else {
                        //    $('.exm_3-8').show();
                        //    $('.exm_9').hide();
                        //}
                        //var IsComplete = result[0].IsComplete;
                        ///***COMPLETE AND UNCOMPLETE RESULT***/
                        //if (IsComplete == 0) {
                        //    var incomplete = "<div class='incom-child'><img src='images/warning.png'/><h4 class='redcolor'>InComplete Result</h4></div>"
                        //    $(".incomplete").html(incomplete);
                        //    $(".incomplete").show();
                        //    $(".overlay").hide();
                        //    //Swal.fire(
                        //    //    'No Data',
                        //    //    '',
                        //    //    'error'
                        //    //)
                        //    return;
                        //}


                        if (result == null || result == "" || result == " ") {
                            $(".overlay").hide();
                            Swal.fire(
                                'No Data',
                                '',
                                'error'
                            )
                            return;
                        }
                        else {

                            if (result[0].Class_Id == 13) {
                                $('.exm_3-8').hide();
                                $('.exm_9').show();
                            }
                            else {
                                $('.exm_3-8').show();
                                $('.exm_9').hide();
                            }
                            var IsComplete = result[0].IsComplete;
                            /***COMPLETE AND UNCOMPLETE RESULT***/
                            if (IsComplete == 0) {
                                var incomplete = "<div class='incom-child'><img src='images/warning.png'/><h4 class='redcolor'>InComplete Result</h4></div>"
                                $(".incomplete").html(incomplete);
                                $(".incomplete").show();
                                $(".overlay").hide();
                                //Swal.fire(
                                //    'No Data',
                                //    '',
                                //    'error'
                                //)
                                return;
                            }

                            $(".incomplete").hide();
                            for (var i = 0; i < result.length; i++) {
                                /*var numItems = $('.reporttable').length;
                                alert(numItems);*/
                                var effort;
                                var remarks;
                                var comments;
                                var fullname;
                                var course_work;
                                var bad1;
                                var bad2;
                                var good1;
                                var good2;
                                var classId;
                                var grade;
                                //console.log(result[i].isAbsent);
                                var MYE_Percent;
                                var EOY_Percent;
                                if (result[i].Term1 != '-')
                                    MYE_Percent = result[i].Term1 * 0.1;//parseInt(MYE_Percent_Key);
                                else
                                    MYE_Percent = result[i].Term1;

                                if (result[i].Theory_Exam != '-')
                                    EOY_Percent = result[i].Theory_Exam * 0.9;//parseInt(EOY_Percent_Key);
                                else
                                    EOY_Percent = result[i].Theory_Exam;

                                if (result[i].isAbsent == true) {
                                    effort = "-";
                                }
                                else {
                                    effort = result[i].Effort;
                                }
                                if (result[i].Comments == null || result[i].Comments == "" || result[i].Comments == " ") {
                                    comments = "";
                                }
                                else {
                                    comments = result[i].Comments;
                                }
                                if (result[i].Remarks == null || result[i].Remarks == "" || result[i].Remarks == " ") {
                                    remarks = "";
                                }
                                else {
                                    remarks = result[i].Remarks;
                                }
                                if (result[i].FullName == null || result[i].FullName == "" || result[i].FullName == " ") {
                                    fullname = "";
                                }
                                else {
                                    fullname = result[i].FullName;
                                }
                                if (result[i].isAbsent == true) {
                                    course_work = "-";

                                    //course_work = result[i].Course_Work;
                                }
                                else if (result[i].Course_Work == "-") {
                                    course_work = result[i].Course_Work;
                                }
                                else if (result[i].Course_Work == 0) {
                                    //course_work = roundfun(result[i].Course_Work);
                                    //if (result[i].Class_Id == 13) { course_work = result[i].Course_Work + " %"; }
                                    //else {
                                    //    var cour = roundfun(result[i].Course_Work);
                                    //    course_work = cour + " %";
                                    //    //course_work = roundfun(result[i].Course_Work);
                                    //}

                                    /**change in 24march2022 by Raja**/
                                    course_work = "-";
                                    /**change in 24march2022 by Raja**/
                                }
                                else {
                                    if (result[i].Class_Id == 13) {

                                        course_work = result[i].Course_Work + " %";
                                    }



                                    else {

                                        /*** NAZRA CONDTION***/
                                        if (result[i].Subject_Id == 18) {
                                            var cour = roundfun(result[i].Course_Work / 2);
                                            course_work = cour + " / 50";
                                        }
                                        else {
                                            var cour = roundfun(result[i].Course_Work);
                                            course_work = cour + " %";
                                        }
                                        /*** NAZRA CONDTION***/
                                    }
                                    //var cour=roundfun(result[i].Course_Work);
                                    // course_work = cour+ " %";

                                }
                                var exammark;
                                var MYE;
                                var EOY;



                                if (result[i].Theory_Exam == "-" || result[i].Theory_Exam == "" || result[i].Theory_Exam == null) {
                                    grade = "-";
                                    EOY = result[i].Theory_Exam;
                                    exammark = EOY;
                                }
                                else if (result[i].Theory_Exam == 0) {
                                    grade = result[i].Grade;
                                    if (result[i].Class_Id == 13) {
                                        //exammark = result[i].Theory_Exam;
                                        EOY = result[i].Theory_Exam + " %";
                                        exammark = EOY;

                                    }
                                    else if (result[i].Class_Id >= 7 && result[i].Class_Id <= 12) {
                                        EOY = roundfun(result[i].Theory_Exam);
                                        EOY = EOY + " %";
                                        if (MYE_Percent != 0 && MYE_Percent != '-')
                                            exammark = roundfun(MYE_Percent + EOY_Percent) + "%";
                                        else {
                                            /**change on 20 sep by aqil***/
                                            if (result[i].Criteria == null) {
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
                                    else {
                                        //exammark = roundfun(result[i].Theory_Exam);
                                        EOY = roundfun(result[i].Theory_Exam);
                                        EOY = EOY + " %";
                                        // exammark = EOY;
                                    }
                                    //exammark = roundfun(result[i].Theory_Exam);
                                }
                                else {
                                    grade = result[i].Grade;

                                    if (result[i].Class_Id == 13) {
                                        EOY = roundfun(result[i].Theory_Exam);
                                        EOY = EOY + " %";
                                        exammark = EOY;

                                    }
                                    else if (result[i].Class_Id >= 7 && result[i].Class_Id <= 12) {
                                        EOY = roundfun(result[i].Theory_Exam);
                                        EOY = EOY + " %";
                                        if (MYE_Percent != 0 && MYE_Percent != '-')
                                            exammark = roundfun(MYE_Percent + EOY_Percent) + "%";
                                        else {
                                            exammark = EOY;
                                        }
                                    }
                                    else {
                                        EOY = roundfun(result[i].Theory_Exam);
                                        EOY = EOY + " %";
                                        //exammark = EOY;
                                    }

                                    //exammark = roundfun(result[i].Theory_Exam);
                                    //exammark = exammark+ " %";
                                }
                                if (MYE_Percent == '-')
                                    MYE = MYE_Percent;
                                else {
                                    MYE = roundfun(result[i].Term1);
                                    MYE = MYE + "%";
                                }

                                /**change by raja 8apr2022**/
                                if (result[i].isAbsent == true) {
                                    grade = "-";
                                    EOY = "-";
                                }
                                if (result[i].Isabsent_FirstTem == true && MYE_Percent == '-') {
                                    MYE = "-";
                                }
                                /**Change by raja 6jun2022**/
                                if (result[i].Term1 == null) {
                                    MYE = "-";
                                }
                                /**Change by raja 6jun2022**/
                                if (result[i].isAbsent == true && result[i].Isabsent_FirstTem == true) {
                                    exammark = "-";
                                }


                                /**change by raja 8apr2022**/


                                // alert(result[i].Term1);

                                if (result[i].Objective_Bad_Comment1 == null || result[i].Objective_Bad_Comment1 == "" || result[i].Objective_Bad_Comment1 == " ") { bad1 = ""; }
                                else { bad1 = result[i].Objective_Bad_Comment1 }
                                if (result[i].Objective_Bad_Comment2 == null || result[i].Objective_Bad_Comment2 == "" || result[i].Objective_Bad_Comment2 == " ") { bad2 = ""; }
                                else { bad2 = result[i].Objective_Bad_Comment2 }

                                if (result[i].Objective_Good_Comment1 == null || result[i].Objective_Good_Comment1 == "" || result[i].Objective_Good_Comment1 == " ") { good1 = ""; }
                                else { good1 = result[i].Objective_Good_Comment1 }
                                if (result[i].Objective_Good_Comment2 == null || result[i].Objective_Good_Comment2 == "" || result[i].Objective_Good_Comment2 == " ") { good2 = ""; }
                                else { good2 = result[i].Objective_Good_Comment2 }

                                //console.log("bad1<br>" + bad1 + "bad2<br>" + bad2 + "good1<br>" + good1 + "good2<br>" + good2);
                                //var studnename = result[0].StudentName;
                                //var studetnameres = studnename.split(" ");


                                // var student_nam = studetnameres[0];
                                var student_nam = result[i].FirstName;
                                if (i < 3) {


                                    /*reportcard+='<tr class="text-center">';
                                                            reportcard+='<td class="centertd">'+result[i].Subject_Name+'</td>';
                                                        reportcard+='<td style="padding: 0px !important;">';

                                                            reportcard+='<tr>';
                                                                reportcard+='<td>Exam</td>';

                                                                reportcard+='<td>CA</td>';

                                                                reportcard+='<td>Grade</td>';

                                                                reportcard+='<td>Effort</td>';
                                                            reportcard+='</tr>';
                                                            reportcard+='<tr>';
                                                                reportcard+='<td>'+result[i].Theory_Exam+'</td>';

                                                                reportcard+='<td>'+result[i].Course_Work+" %"+'</td>';

                                                                reportcard+='<td>'+result[i].Grade+'</td>';

                                                                reportcard+='<td></td>';
                                                            reportcard+='</tr>';

                                                        reportcard+='</td>';

                                                        reportcard+='</tr>';
                                    */


                                    reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 sec3">';
                                    reportcard += '<table class="table  subjecttable">';
                                    reportcard += '<tr class="text-center">';
                                    reportcard += '<td rowspan="2"  class="centertd">' + result[i].Subject_Name + '</td>';
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
                                    reportcard += '<td class="text-center">' + exammark + '</td>';

                                    reportcard += '<td class="text-center">' + grade + '</td>';
                                    reportcard += '<td class="text-center norightborder">' + effort + '</td>';
                                    reportcard += '</tr>';
                                    reportcard += '</table>';
                                    reportcard += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 commentsec">';/*'+result[i].ClassTeacher_Comments+'*/

                                    if (result[i].Subject_Id == 17 || result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 18) {
                                        reportcard += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                    }
                                    else {
                                        reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                    }


                                    if (Session_Id == 12 && Term_Id == 1) {


                                        reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                    }
                                    else {

                                        if (result[i].Class_Id >= 7 && result[i].Class_Id <= 12) /*For Class 3 to Class 8*/ {

                                            if (result[i].Subject_Id == 17 || result[i].Subject_Id == 12 || result[i].Subject_Id == 18) {
                                                if (result[i].isAbsent == true) {
                                                    reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                }
                                                else {
                                                    /**change by raja 10 may2021***/
                                                    if (result[i].is_comment == "0") {
                                                        reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                    }
                                                    else {


                                                        reportcard += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    }
                                                    /**change by raja 10 may2021***/
                                                    // reportcard += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';

                                                }


                                            }
                                            else {

                                                reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                            }
                                        }
                                        else if (result[i].Class_Id == 13 && result[i].Subject_Id == 133) {

                                            //reportcard += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                            if (result[i].isAbsent == true) {
                                                reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                            }
                                            else {
                                                /**change by raja 10 may2021***/
                                                if (result[i].is_comment == "0") {
                                                    reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                }
                                                else {

                                                    reportcard += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                }
                                                /**change by raja 10 may2021***/
                                                //reportcard += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                            }
                                        }
                                        else {

                                            reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                        }
                                    }
                                    //if (result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 17 && result[i].Class_Id==7) {//Class 3
                                    //    reportcard += '<p class="commentsec1 text-right">' + comments + '</p>';
                                    //}
                                    //else if (result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 17 && result[i].Class_Id == 8) {//Class 4
                                    //    reportcard += '<p class="commentsec1 text-right">' + comments + '</p>';
                                    //}
                                    //else if (result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 17 && result[i].Class_Id == 9) {//Class 5
                                    //    reportcard += '<p class="commentsec1 text-right">' + comments + '</p>';
                                    //}
                                    //else if (result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 17 && result[i].Class_Id == 10) {//Class 6
                                    //    reportcard += '<p class="commentsec1 text-right">' + comments + '</p>';
                                    //}
                                    //else if (result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 17 && result[i].Class_Id == 11) {//Class 7
                                    //    reportcard += '<p class="commentsec1 text-right">' + comments + '</p>';
                                    //}
                                    //else if (result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 17 && result[i].Class_Id == 12) {//Class 8
                                    //    reportcard += '<p class="commentsec1 text-right">' + comments + '</p>';
                                    //}
                                    //else if (result[i].Subject_Id == 12 || result[i].Subject_Id == 133 && result[i].Class_Id == 13) {//Class 9
                                    //    reportcard += '<p class="commentsec1 text-right">' + comments + '</p>';
                                    //}
                                    //else {
                                    //    reportcard += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                    //}


                                    //reportcard += '<p class="commentsec1  col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                    //reportcard += '<p class="commentsec1  col-lg-12 col-md-12 col-sm-12 col-xs-12">' + bad1 +" "+bad2+""+good1+""+good2+'</p>';



                                    reportcard += '<p class="text-right commentsectec captilizetext"><strong class="teachername">Teacher:</strong>' + fullname + '</p>';
                                    reportcard += '</div>';
                                    reportcard += '</div>';



                                }
                                else {

                                    if (i == 3) {
                                        /**HARDCODED BOTTOM LINE**/
                                        //reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex pagecut printmediaborderbottomafter3 text-right">';
                                        //    reportcard2 += '<p>PB-6, NCEHS, Block-10-A, Gulshan-e-Iqbal Karachi</p><p>Tel: 0213-4824652, 0213-4979709</p>';

                                        //    reportcard2 += '</div>';
                                        /***HARDCODED BOTTOM LINE**/

                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom">';/*<p>ok</p>*/
                                        reportcard2 += '</div>';
                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex printmediabordertopafter3">';
                                        reportcard2 += '<p><span>' + result[0].StudentName + "-" + result[0].Student_Id + '</span><span class="floatright">' + result[0].Center_Name + '</span></p>';

                                        reportcard2 += '</div>';

                                        /*****4 table*****/

                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 sec3">';
                                        reportcard2 += '<table class="table  subjecttable">';
                                        reportcard2 += '<tr class="text-center">';
                                        reportcard2 += '<td rowspan="2"  class="centertd">' + result[i].Subject_Name + '</td>';
                                        reportcard2 += '<td class="text-center">CA</td>';
                                        reportcard2 += '<td class="text-center">Exam (Term 1)</td>';
                                        reportcard2 += '<td class="text-center">Exam (Term 2)</td>';
                                        reportcard2 += '<td class="text-center">Final Result</td>';

                                        reportcard2 += '<td class="text-center">Grade</td>';
                                        reportcard2 += '<td class="text-center norightborder">Effort</td>';
                                        reportcard2 += '</tr>';
                                        reportcard2 += '<tr>';
                                        reportcard2 += '<td class="text-center">' + course_work + '</td>';
                                        reportcard2 += '<td class="text-center">' + MYE + '</td>';
                                        reportcard2 += '<td class="text-center">' + EOY + '</td>';
                                        reportcard2 += '<td class="text-center">' + exammark + '</td>';

                                        reportcard2 += '<td class="text-center">' + grade + '</td>';
                                        reportcard2 += '<td class="text-center norightborder">' + effort + '</td>';
                                        reportcard2 += '</tr>';
                                        reportcard2 += '</table>';
                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 commentsec">';

                                        if (result[i].Subject_Id == 17 || result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 18) {
                                            reportcard2 += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                        }
                                        else {
                                            reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                        }


                                        if (Session_Id == 12 && Term_Id == 1) {


                                            reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                        }
                                        else {

                                            if (result[i].Class_Id >= 7 && result[i].Class_Id <= 12) /*For Class 3 to Class 8*/ {

                                                if (result[i].Subject_Id == 17 || result[i].Subject_Id == 12 || result[i].Subject_Id == 18) {

                                                    //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    if (result[i].isAbsent == true) {
                                                        reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                    }
                                                    else {
                                                        /**change by raja 10 may2021***/
                                                        if (result[i].is_comment == "0") {
                                                            reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                        }
                                                        else {

                                                            reportcard2 += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                        }
                                                        /**change by raja 10 may2021***/
                                                        //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    }
                                                }
                                                else {

                                                    reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                }
                                            }
                                            else if (result[i].Class_Id == 13 && result[i].Subject_Id == 133) {

                                                //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                if (result[i].isAbsent == true) {
                                                    reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                }
                                                else {
                                                    /**change by raja 10 may2021***/
                                                    if (result[i].is_comment == "0") {
                                                        reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                    }
                                                    else {

                                                        reportcard2 += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    }
                                                    /**change by raja 10 may2021***/
                                                    //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                }
                                            }
                                            else {

                                                reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                            }
                                        }

                                        //reportcard2 += '<p class=" commentsec1 coeq32  col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                        //reportcard += '<p class="commentsec1  coeq32 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + bad1 +" "+bad2+""+good1+""+good2+'</p>';
                                        reportcard2 += '<p class="text-right coeq32 commentsectec captilizetext"><strong class="teachername">Teacher:</strong>' + fullname + '</p>';
                                        reportcard2 += '</div>';
                                        reportcard2 += '</div>';
                                        /*****4 Table****/


                                    }
                                    else if (count % 5 == 0 && count != 0) {
                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 pagecut printmediaborderbottom">';
                                        reportcard2 += '</div>';
                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 displayflex printmediabordertopafter3">';
                                        reportcard2 += '<p><span>' + result[0].StudentName + "-" + result[0].Student_Id + '</span><span class="floatright">' + result[0].Center_Name + '</span></p>';

                                        reportcard2 += '</div>';

                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 sec3">';
                                        reportcard2 += '<table class="table  subjecttable">';
                                        reportcard2 += '<tr class="text-center">';
                                        reportcard2 += '<td rowspan="2"  class="centertd">' + result[i].Subject_Name + '</td>';
                                        reportcard2 += '<td class="text-center">CA</td>';
                                        reportcard2 += '<td class="text-center">Exam (Term 1)</td>';
                                        reportcard2 += '<td class="text-center">Exam (Term 2)</td>';
                                        reportcard2 += '<td class="text-center">Final Result</td>';

                                        reportcard2 += '<td class="text-center">Grade</td>';
                                        reportcard2 += '<td class="text-center norightborder">Effort</td>';
                                        reportcard2 += '</tr>';
                                        reportcard2 += '<tr>';
                                        reportcard2 += '<td class="text-center">' + course_work + '</td>';
                                        reportcard2 += '<td class="text-center">' + MYE + '</td>';
                                        reportcard2 += '<td class="text-center">' + EOY + '</td>';
                                        reportcard2 += '<td class="text-center">' + exammark + '</td>';

                                        reportcard2 += '<td class="text-center">' + grade + '</td>';
                                        reportcard2 += '<td class="text-center norightborder">' + effort + '</td>';
                                        reportcard2 += '</tr>';
                                        reportcard2 += '</table>';
                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 commentsec">';

                                        if (result[i].Subject_Id == 17 || result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 18) {
                                            reportcard2 += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                        }
                                        else {
                                            reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                        }


                                        if (Session_Id == 12 && Term_Id == 1) {


                                            reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                        }
                                        else {

                                            if (result[i].Class_Id >= 7 && result[i].Class_Id <= 12) /*For Class 3 to Class 8*/ {

                                                if (result[i].Subject_Id == 17 || result[i].Subject_Id == 12 || result[i].Subject_Id == 18) {

                                                    //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    if (result[i].isAbsent == true) {
                                                        reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                    }
                                                    else {
                                                        /**change by raja 10 may2021***/
                                                        if (result[i].is_comment == "0") {
                                                            reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                        }
                                                        else {

                                                            reportcard2 += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                        }
                                                        /**change by raja 10 may2021***/
                                                        //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    }
                                                }
                                                else {

                                                    reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                }
                                            }
                                            else if (result[i].Class_Id == 13 && result[i].Subject_Id == 133) {

                                                //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                if (result[i].isAbsent == true) {
                                                    reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                }
                                                else {
                                                    /**change by raja 10 may2021***/
                                                    if (result[i].is_comment == "0") {
                                                        reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                    }
                                                    else {

                                                        reportcard2 += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    }
                                                    /**change by raja 10 may2021***/
                                                    // reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                }
                                            }
                                            else {

                                                reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                            }
                                        }

                                        //reportcard2 += '<p class=" commentsec1 comod2 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                        //reportcard += '<p class="commentsec1  comod2 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + bad1 +" "+bad2+""+good1+""+good2+'</p>';
                                        reportcard2 += '<p class="text-right comod2 commentsectec captilizetext"><strong class="teachername">Teacher:</strong>' + fullname + '</p>';
                                        reportcard2 += '</div>';
                                        reportcard2 += '</div>';
                                        count += 1;
                                    }
                                    else {
                                        count += 1

                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 sec3">';
                                        reportcard2 += '<table class="table  subjecttable">';
                                        reportcard2 += '<tr class="text-center">';
                                        reportcard2 += '<td rowspan="2"  class="centertd">' + result[i].Subject_Name + '</td>';
                                        reportcard2 += '<td class="text-center">CA</td>';
                                        reportcard2 += '<td class="text-center">Exam (Term 1)</td>';
                                        reportcard2 += '<td class="text-center">Exam (Term 2)</td>';
                                        reportcard2 += '<td class="text-center">Final Result</td>';

                                        reportcard2 += '<td class="text-center">Grade</td>';
                                        reportcard2 += '<td class="text-center norightborder">Effort</td>';
                                        reportcard2 += '</tr>';
                                        reportcard2 += '<tr>';
                                        reportcard2 += '<td class="text-center">' + course_work + '</td>';
                                        reportcard2 += '<td class="text-center">' + MYE + '</td>';
                                        reportcard2 += '<td class="text-center">' + EOY + '</td>';
                                        reportcard2 += '<td class="text-center">' + exammark + '</td>';

                                        reportcard2 += '<td class="text-center">' + grade + '</td>';
                                        reportcard2 += '<td class="text-center norightborder">' + effort + '</td>';
                                        reportcard2 += '</tr>';
                                        reportcard2 += '</table>';
                                        reportcard2 += '<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 commentsec">';




                                        if (result[i].Subject_Id == 17 || result[i].Subject_Id == 12 || result[i].Subject_Id == 133 || result[i].Subject_Id == 18) {
                                            reportcard2 += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                        }
                                        else {
                                            reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + comments + '</p>';
                                        }


                                        if (Session_Id == 12 && Term_Id == 1) {


                                            reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                        }
                                        else {

                                            if (result[i].Class_Id >= 7 && result[i].Class_Id <= 12) /*For Class 3 to Class 8*/ {

                                                if (result[i].Subject_Id == 17 || result[i].Subject_Id == 12 || result[i].Subject_Id == 18) {

                                                    //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    if (result[i].isAbsent == true) {
                                                        reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                    }
                                                    else {
                                                        /**change by raja 10 may2021***/
                                                        if (result[i].is_comment == "0") {
                                                            reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                        }
                                                        else {

                                                            reportcard2 += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                        }
                                                        /**change by raja 10 may2021***/
                                                        //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    }
                                                }
                                                else {

                                                    reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                }
                                            }
                                            else if (result[i].Class_Id == 13 && result[i].Subject_Id == 133) {

                                                //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                if (result[i].isAbsent == true) {
                                                    reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                }
                                                else {
                                                    /**change by raja 10 may2021***/
                                                    if (result[i].is_comment == "0") {
                                                        reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                                    }
                                                    else {

                                                        reportcard2 += '<p class="commentsec1 text-right col-lg-12 col-md-12 col-sm-12 col-xs-12"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                    }
                                                    /**change by raja 10 may2021***/
                                                    //reportcard2 += '<p class="commentsec1 text-right"><span class="maiproblem"><span class="Maintxt">' + student_nam + '</span></span>' + remarks + '</p>';
                                                }
                                            }
                                            else {

                                                reportcard2 += '<p class="commentsec1 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                            }
                                        }

                                        //reportcard2 += '<p class=" commentsec1 coelse2 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + remarks + '</p>';
                                        //reportcard += '<p class="commentsec1  coelse2 col-lg-12 col-md-12 col-sm-12 col-xs-12">' + bad1 +" "+bad2+""+good1+""+good2+'</p>';
                                        reportcard2 += '<p class="text-right coelse2 commentsectec captilizetext"><strong class="teachername">Teacher:</strong>' + fullname + '</p>';
                                        reportcard2 += '</div>';
                                        reportcard2 += '</div>';


                                    }
                                }


                            }

                        }

                        //IsPromoted = 1 then Promoted to Class 7

                        //IsPromoted = 0 and Cond_Prom = 1 then Discretionarily promoted

                        //IsPromoted = 0 and Cond_Prom = 0 then Not promotted

                        /**IS PROMOTED**/
                        //if (result[0].Class_Id != 12) {
                        if (result[0].isPromoted == false && result[0].Cond_Prom == true) {
                            reportcard2 += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 ispromoted">Discretionarily Promoted  to ' + result[0].RequestedClass + '</div>';

                        }
                        if (result[0].isPromoted == true && result[0].Cond_Prom == false) {
                            reportcard2 += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 ispromoted">Promoted to ' + result[0].PromotedToClass + '</div>';
                        }

                        if (result[0].isPromoted == false && result[0].Cond_Prom == false) {
                            reportcard2 += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 notpromoted">Not Promoted</div>';
                        }
                        if (result[0].isPromoted == true && result[0].Cond_Prom == true) {
                            reportcard2 += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 ispromoted">Discretionarily Promoted  to ' + result[0].RequestedClass + '</div>';

                        }
                        //if (result[0].Class_Name == result[0].PromotedToClass) {
                        //    reportcard2 += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 notpromoted">Detained to ' + result[0].PromotedToClass + '</div>';

                        //}
                        //}
                        // else {
                        //if (result[0].Class_Name == result[0].PromotedToClass)
                        //{
                        //    reportcard2 += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 notpromoted">Detained to ' + result[0].PromotedToClass + '</div>';

                        //}
                        //else {
                        //    reportcard2 += '<div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 ispromoted">Promoted to ' + result[0].PromotedToClass + '</div>';
                        //}
                        //}
                        /**IS PROMOTED**/
                        /***COMPLETE AND UNCOMPLETE RESULT***/
                        var attendenceperc = (result[0].DaysPresent / result[0].FirstTermDaysCH) * 100;
                        var attendence;

                        if (attendenceperc < 25) {
                            attendence = "Low";
                        }
                        else {
                            attendence = result[0].DaysPresent;
                        }
                        $(".firstthreetable").html(reportcard);
                        $(".remainingtable").html(reportcard2);
                        $(".attendenceclass").text(attendence);
                        $(".attendencetotal").text(result[0].FirstTermDaysCH + " days");
                        $(".dobclass").text(formatdate(result[0].Date_Of_Birth));
                        $(".fullnamestudent").text(result[0].StudentName);
                        $(".classname").text(result[0].Class_Name);
                        $(".classsec").text(result[0].Section_Name);
                        $(".termname").text(result[0].Evaluation_Criteria_Type_Name);
                        $(".headsign").text(result[0].HeadName);
                        $(".yearname").text(result[0].Description.replace("AY", ''));
                        $(".headerstudentname").text(result[0].StudentName + "-" + result[0].Student_Id);
                        $(".headerstudentcenter").text(result[0].Center_Name);
                    }, complete: function () {
                        /*$('.costgraph').css({
                            'cssText': 'background:none !important'
                        });*/
                        $(".overlay").hide();
                        $('.container').on('scroll touchmove mousewheel');
                    }, error: function (err) {

                        console.log(err);
                       

                    }

                });


            



            //***PWA****/
            //if ('serviceWorker' in navigator) {
            //     navigator.serviceWorker.register('./Content/service-worker.js').then(res => {
            //         //alert('SW register');
            //     }).catch(err => {
            //        // alert("Error SW", err);
            //         })

            // }
            // else {
            //     console.log('SW Not supported');
            // }
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

        .modal-header {
            background: #2456a5 !important;
            text-align: center !important;
        }

        .modal-title {
            color: #fff !important;
        }

        .error-message {
            display: none;
        }

        .error-message {
            padding: 5px;
            background: #ed1313;
            width: 100% !important;
            font-size: 10px;
            color: #fff;
            border-radius: 3px;
            margin-bottom: 0px;
        }
    </style>
</body>
</html>
