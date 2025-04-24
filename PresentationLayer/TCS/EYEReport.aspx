<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EYEReport.aspx.cs" Inherits="PresentationLayer_EYEReport" %>

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
    <meta name="mobile-web-app-capable" content="yes">
    <meta charset="utf-8" />
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

    <script src="ReportCard/jquery-3.3.1.min.js" type="text/JavaScript" language="javascript"></script>
    <script src="ReportCard/jquery-ui-1.10.4.custom.js"></script>
    <script src="ReportCard/jquery.PrintArea.js" type="text/JavaScript" language="javascript"></script>

    <link type="text/css" rel="stylesheet" href="ReportCard/jquery-ui-1.10.4.custom.css" />

    <link type="text/css" rel="stylesheet" href="ReportCard/PrintArea3MYE.css" />                <!-- Y : rel is stylesheet and media is in [all,print,empty,undefined] -->
    <link type="text/css" rel="stylesheet" href="ReportCard/media_all.css" media="all" />   <!-- Y : rel is stylesheet and media is in [all,print,empty,undefined] -->
    <link type="text/css" rel="" href="empty.css" />                    <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="noPrint" href="ReportCard/noPrint.css" />                  <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="stylesheet" href="ReportCard/media_none.css" media="xyz" />   <!-- N : media not in [all,print,empty,undefined] -->
    <link type="text/css" href="ReportCard/no_rel.css" media="print" /> <!-- N : no rel attribute -->
    <link type="text/css" href="ReportCard/no_rel_no_media.css" /> <!-- N : no rel, no media attributes -->
    <link rel="stylesheet" type="text/css" href="ReportCard/bootstrap.min.css">
    <!--<link rel="stylesheet" type="text/css"  href="bootstrap/css/bootstrap.css.map">-->
    <script src="popper.min.js"></script>
    <script src="bootstrap.min.js"></script>
    <link rel="stylesheet" type="text/css" href="font-awesome.min.css">
    <link rel="stylesheet" type="text/css" href="sweetalert2.min.css">
    <script type="text/javascript" src="sweetalert2.min.js"></script>
    <script type="text/javascript" src="qr-code.js"></script>
    



          <style>
        *{
            font-size:14px;
        }
        .overlay {
    background: url('./ReportCard/logo2.gif') no-repeat center center; /*loader.gif*/
    position: fixed;
    top: 0;
    left: 0;
    height: 100%;
    width: 100%;
    z-index: 9999999;
    background-color: rgba(0,0,0,0.5);
}  .modal-header {
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
.custom-container {
        border: 15px solid #69bcff;
        border-radius: 55px;
        padding: 20px;
        margin-top: 30px;
        width: 100%;
        background:
            linear-gradient(to bottom, #E9F5F2 0%, #E9F5F2 10%, transparent 0%),
            url('../../../images/EYEReport_header.png'); /* Image URL */
        background-size: 100% 10%; /* Ensure the image fits the gradient area */
        background-repeat: no-repeat; /* Prevent the image from repeating */
        background-position: top; /* Position the image at the top */  }
 
.top-row {
            display: flex;
            justify-content: space-between;
            align-items: center;
            position: relative;
            width: 100%;
        }
 
        .left, .right {
            position: absolute;
            top: 0;
            font-weight: bold;
        }
 
        .left {
            left: 0;
        }
 
        .right {
            right: 0;
            text-align: right;
        }
/* Responsive adjustments */
@media (max-width: 768px) {
.custom-container {
    border-width: 10px; /* Reduce border thickness for smaller screens */
    border-radius: 30px; /* Adjust border radius */
    padding: 15px; /* Reduce padding */
    background-size: 100% 15%; /* Adjust background size for mobile view */
}
}
 
@media (max-width: 480px) {
.custom-container {
    border-width: 8px; /* Further reduce border thickness */
    border-radius: 20px; /* Smaller border radius for very small screens */
    padding: 10px; /* Minimal padding */
    background-size: 100% 20%; /* Adjust background size further */
}
}
 
        .user-image {
            width: 90px;border: 2px solid black;
            height: 120px;
           
        }
        .performance-list {
            list-style-type: none;
   
            padding-left: 20px;
        }
 
 
        .performance-list li {
    position: relative; /* Allows for custom bullet positioning */
    padding-left: 20px; /* Space for custom bullet */
}
 
.performance-list li::before {
    content: "■"; /* Unicode character for a square */
    font-size: 20px; /* Adjust the size of the square */
    color: inherit; /* Matches the color of the list item */
    position: absolute; /* Position it on the left */
    left: 0; /* Align it properly */
    top: 0; /* Center it vertically */
    line-height: 1.2; /* Adjust to match text spacing */
}
        .performance-list li.green { color: #00B050;
       
        }
        .performance-list li.purple { color: #7030A0; }
        .performance-list li.orange { color:#FF5F1F; }
        .performance-list li.blue { color: #0070C0; }
        .section-heading {
            font-weight: bold;
            margin-top: 20px;
            margin-left: 10px;
        }
        .pi{
            text-align: center;
	    font-weight: bold;
        }
        .cons{
            display: flex;
justify-content: space-between;
align-items: center;
        }
        .left {
            margin-left: 20px;
text-align: left;
}
 
.middle {
flex-grow: 1;
text-align: center; /* Optional: Aligns text in the middle */
}
 
.right {
    margin-right: 20px;
text-align: right;
}
 
 
/* Default Styles */
.user-image {
height: auto;
max-height: 150px;
width: auto;
max-width: 200px;
border: 2px solid black;
}
 
.school-logo {
margin-top: 30px;
height: auto;
max-height: 90px;
width: auto;
max-width: 120px;
}
 
/* Print Styles */
@media print {
    footer, .navbar, .top-row {
                display: none;
            }
         
 
            h3{
               
                margin-top: 30px; /* Add some space above the title */
            }
            h4{
                
            }
 
            @page {
                margin: 20px;
                padding: 0;
                size: Auto;
           
                border: 15px solid #69bcff !important;
                border-radius: 55px !important;
                padding: 20px;
            }
 
 
            /* Border styling for custom container */
            .custom-container {
                border: none !important;
             
                padding: 20px !important;
                  background:
        linear-gradient(to bottom, #E9F5F2 0%, #E9F5F2 10%, transparent 0%),
        url('../../../images/EYEReport_header.png'); /* Image URL */
    background-size: 100% 10%; /* Ensure the image fits the gradient area */
    background-repeat: no-repeat; /* Prevent the image from repeating */
    background-position: top; /* Position the image at the top */ 
             
                width: 100%;
            }
 
            /* Prevent breaking inside the container */
            .custom-container * {
                page-break-inside: auto !important;
            }
 
 
 
.cons {
    display: flex; /* Flexbox layout for print */
    justify-content: space-between; /* Space images evenly */
    align-items: center; /* Align images vertically */
}
.top-row {
                display: flex;
                /* justify-content: space-between;
                align-items: center;
                position: relative; */
            }
.user-image,
.school-logo {
    max-width: 100px; /* Adjust image size for print */
    max-height: 100px;
    margin: 0; /* Remove extra margins for print */
    border: none; /* Optional: Remove borders for print */
}
.user-image{
    border: 4px solid black;
}
 
.school-logo {
    margin-top: 0; /* Remove margin for better alignment in print */
}
 
 
body {
                margin: 0;
            }
 
            /* Hide browser-specific print info like page number */
            .no-print {
                display: none;
            }
}       



    </style>
</head>
<body>

        
        <div class="overlay"></div>
     
                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 no-padding">
    <div class="reporttable article">
        <div class="firstthreetable"></div>
        <div class="remainingtable"></div>
    </div>
</div>

            <!--bootsrap-->
       


 






   

    <script>


        $(document).ready(function () {

           

            $(".overlay").show();
           
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


            //var Roll_Number = GetUrlParameter('d');
            //var Session_Id = GetUrlParameter('b');
            //var Term_Id = GetUrlParameter('c');
            //var Sec_Id = GetUrlParameter('a');
            var Roll_Number = GetUrlParameter('st');
            var Session_Id = GetUrlParameter('se');
            var Term_Id = GetUrlParameter('tr');
            var Sec_Id = GetUrlParameter('sc');
            console.log("Roll NUmber" + Roll_Number + "------" + "Session_Id" + Session_Id + "Term_Id" + Term_Id + "Section" + Sec_Id);




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
                
                var reportcard = "";
                var obtainedMarks = "0";
                $.ajax({
                    url: "EYEReport.aspx/testHeader",
                    // data: "{querytype: '1'}",
                    data: "{ sessionId: " + Session_Id +", TermGroupId :" + Term_Id +", sectionId: " + Sec_Id +", StudentId: " + Roll_Number +" }",
                  //  data: "{ sessionId: 15, TermGroupId : 2, sectionId: 3099, StudentId: 594390 }",
                  //  data: "{ sessionId: 16, TermGroupId : 1, sectionId: 3099, StudentId: 592940 }",
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    success: function (result) {
                        //console.log(JSON.stringify(result));
                        var resultstr = JSON.parse(result.d);
                        console.log(JSON.stringify(resultstr));



                       
                        reportcard += '                   <div class="container top-row">';
                        reportcard += '                       <span class="left">' + resultstr.Header[0].First_Name + ' ' + resultstr.Header[0].Student_Id + '</span>';
                        reportcard += '                       <span class="right">' + resultstr.Header[0].Center_Name + '</span>';
                        reportcard += '                   </div>';
                        reportcard += '                   <div class="container custom-container">';

                        reportcard += '                       <div class="cons">';
                        reportcard += '                           <!-- User Image -->';
                        reportcard += '                           <div>';
                        reportcard += '                               <img src="' + resultstr.Header[0].Image_Path.replace('~', '') + '" class="user-image">';
                        reportcard += '                           </div>';
                        reportcard += '                           <!-- School Logo -->';
                        reportcard += '   <div class="text-center" style="margin-top: 5%">';
                        reportcard += '                               <h3 style="color:#69b2ff;">' + resultstr.Header[0].Type + ' Report Card ' + resultstr.Header[0].SessionCode + '</h3>';
                        reportcard += '                               <p><h4>' + resultstr.Header[0].First_Name + '</h4></p>';
                        reportcard += '                               <p><h4>' + resultstr.Header[0].Class_Name + '-' + resultstr.Header[0].Section_Name + '</h4></p>';
                        reportcard += ' </div>';
                        reportcard += '                           <div>';
                        reportcard += '                               <img src="ReportCard/newlogo.png" alt="School Logo" class="school-logo">';
                        reportcard += '                           </div>';
                        reportcard += '                       </div>';

                      

                        reportcard += '                       <!-- Date of Birth and Attendance below the left-side image -->';
                        reportcard += '                       <div class="row">';
                        reportcard += '                           <div class="row">';
                        reportcard += '                               <div class="col-md-12" style="margin-left: 35px">';
                        reportcard += '                                   <p> <span style="text-decoration: underline;" > <strong style="text-decoration: none;">Date of Birth: </strong>' + formatdate(resultstr.Header[0].Date_Of_Birth) + '</span></p>';
                        reportcard += '                               </div>';
                        reportcard += '                           </div>';

                        reportcard += '                       </div>';
                        reportcard += '                       <div class="row">';
                        reportcard += '                           <div class="row">';
                        reportcard += '                               <div class="col-md-12" style="margin-left: 35px">';
                        reportcard += '                                   <p><span style="text-decoration: underline;"><strong style="text-decoration: underline;">Attendance: </strong> ' + resultstr.Header[0].DaysAttend + ' (out of ' + resultstr.Header[0].FirstTermDays + ' days)</span></p>';
                        reportcard += '                               </div>';
                        reportcard += '                           </div>';

                        reportcard += '                       </div>';

                        reportcard += '                       <!-- Understanding your child’s report -->';
                        reportcard += '                       <div class="row">';
                        reportcard += '                       <div class="container mt-2">';
                        reportcard += '                           <div class="section-heading">Understanding your child’s report</div>';
                        reportcard += '                           <div class="table mt-4" style="border:1px solid black; border-collapse: collapse;">';
                        reportcard += '                               <strong style="margin-left: 10px;">Colour coded performance indicators (PI):</strong>';
                        reportcard += '                               <ul class="performance-list" style="margin-top: 10px">';

                        if (Session_Id == 16 && Term_Id == 1) {
                            reportcard += '                                   <li class="green"><div style="color:black !important">Exceeding Development:Performs above the expected level, showing advanced skills. (<span style="color: #00B050; font-weight: bold;">EXC</span>)</div></li>';
                            reportcard += '                                   <li class="purple"><div style="color:black !important">Expected Development: Consistently meets the learning objective independently. (<span style="color: #7030A0; font-weight: bold;">EXP</span>)</div></li>';
                            reportcard += '                                   <li class="blue"><div style="color:black !important">Emerging Development: Performs below the expected level, requiring support and guidance.  (<span style="color: #0070C0; font-weight: bold;">EME</span>)</div></li>';

                        }
                        else if (Session_Id >= 16) {

                            for (var i = 0; i < resultstr.Indicator.length; i++) {
                                if (resultstr.Indicator[i].RateCode === "EXC") {
                                    reportcard += '  <li class="green"><div style="color:black !important">  ' + resultstr.Indicator[i].Description + ' (<span style="color: #00B050; font-weight: bold;">' + resultstr.Indicator[i].RateCode + ' </span>)</div></li>';

                                }
                                else if (resultstr.Indicator[i].RateCode === "EXP") {
                                    reportcard += '  <li class="purple"><div style="color:black !important">  ' + resultstr.Indicator[i].Description + ' (<span style="color: #7030A0; font-weight: bold;">' + resultstr.Indicator[i].RateCode + ' </span>)</div></li>';

                                }
                                else if (resultstr.Indicator[i].RateCode === "EME") {
                                    reportcard += '  <li class="blue"><div style="color:black !important">  ' + resultstr.Indicator[i].Description + ' (<span style="color: #0070C0; font-weight: bold;">' + resultstr.Indicator[i].RateCode + ' </span>)</div></li>';

                                }
                                else {
                                    reportcard += '  <li class="orange"><div style="color:black !important">  ' + resultstr.Indicator[i].Description + ' (<span style="color: #FF5F1F; font-weight: bold;">' + resultstr.Indicator[i].RateCode + ' </span>)</div></li>';

                                }
                            }
                        }
                        else {
                            reportcard += '  <li class="green"><div style="color:black !important">Exceeding Development:Performs above the expected level, showing advanced skills. (<span style="color: #00B050; font-weight: bold;">EXC</span>)</div></li>';
                            reportcard += '  <li class="purple"><div style="color:black !important">Expected Development: Consistently meets the learning objective independently. (<span style="color: #7030A0; font-weight: bold;">EXP</span>)</div></li>';
                            reportcard += '   <li class="blue"><div style="color:black !important">Emerging Development: Performs below the expected level, requiring support and guidance.  (<span style="color: #0070C0; font-weight: bold;">EME</span>)</div></li>';

                        }
                      
                        reportcard += '                               </ul>';
                        reportcard += '                           </div>';
                        reportcard += '                       </div>';
                        reportcard += '                       <!-- Performance Indicators Section -->';
                        reportcard += '                       <div class="container mt-4">';
                        reportcard += '                           <!-- Performance Indicators -->';








                        reportcard += '                           <!-- Table for ENGLISH and PI -->';
                        reportcard += '                           <table class="table mt-4" style="border:1px solid black; border-collapse: collapse;">';
                        reportcard += '                               <tbody>';
                        for (var i = 0; i < resultstr.Detail.length; i++) {
                            reportcard += '                                   <tr>';

                            if (resultstr.Detail[i].subjectid === 11) {
 
     reportcard += '      <th style="height: 40px; background-color: #E0EECB; border: 1px solid black; text-align: center" class="text-success">' + resultstr.Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #E0EECB; border: 1px solid black; text-align: center" class="text-success">PI</th>';
 
}

if (resultstr.Detail[i].subjectid === 13) {
 
     reportcard += '      <th style="height: 40px; background-color: #DED2E8; border: 1px solid black; text-align: center; color: purple;">' + resultstr.Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #DED2E8; border: 1px solid black; text-align: center; color: purple;">PI</th>';
 
}

if (resultstr.Detail[i].subjectid === 170) {
 
     reportcard += '      <th style="height: 40px; background-color: #FFE3B8; border: 1px solid black; text-align: center; color: orange;">' + resultstr.Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #FFE3B8; border: 1px solid black; text-align: center; color: orange;">PI</th>';
 
}

if (resultstr.Detail[i].subjectid === 12) {
 
     reportcard += '      <th style="height: 40px; background-color: #E5B8B7; border: 1px solid black; text-align: center; color: rgb(141, 64, 64);">' + resultstr.Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #E5B8B7; border: 1px solid black; text-align: center; color: rgb(141, 64, 64);">PI</th>';
 
}

if (resultstr.Detail[i].subjectid === 64) {
 
     reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">' + resultstr.Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">PI</th>';
 
}

//if (resultstr.Detail[i].subjectid === "Art") {
 
//    reportcard += '      <th style="height: 40px; background-color: lightgray; border: 1px solid black; text-align: center; color: purple;">' + resultstr.Detail[i].subjectName + '</th>';

//    reportcard += '      <th style="height: 40px; background-color: lightgray; border: 1px solid black; text-align: center; color: purple;">PI</th>';
 
//}

if (resultstr.Detail[i].subjectid === 163) {
 
     reportcard += '      <th style="height: 40px; background-color: #CDECFC; border: 1px solid black; text-align: center; color: rgb(44, 160, 206);">' + resultstr.Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #CDECFC; border: 1px solid black; text-align: center; color: rgb(44, 160, 206);">PI</th>';
 
}

if (resultstr.Detail[i].subjectid === 65) {
 
     reportcard += '      <th style="height: 40px; background-color: #B2A1C7; border: 1px solid black; text-align: center; color: purple;">' + resultstr.Detail[i].subjectName + '</th>';


     reportcard += '      <th style="height: 40px; background-color: #B2A1C7; border: 1px solid black; text-align: center; color: purple;">PI</th>';
 
}

             if (resultstr.Detail[i].subjectid === 14) {
 
     reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">' + resultstr.Detail[i].subjectName + '</th>';
     reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">PI</th>';
}
if (resultstr.Detail[i].subjectid === 21) {
 
     reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">' + resultstr.Detail[i].subjectName + '</th>';
     reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">PI</th>';
}
if (resultstr.Detail[i].subjectid === 17) {
 
     reportcard += '      <th style="height: 40px; background-color: #C6D9F1; border: 1px solid black; text-align: center" class="text-primary">' + resultstr.Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #C6D9F1; border: 1px solid black; text-align: center" class="text-primary">PI</th>';
 
}

if (resultstr.Detail[i].subjectid === 18) {
 
     reportcard += '      <th style="height: 40px; background-color: #F0F371; border: 1px solid black; text-align: center; color: rgb(155, 72, 6);">' + resultstr.Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #F0F371; border: 1px solid black; text-align: center; color: rgb(155, 72, 6);">PI</th>';
 
}
 

                            for (var j = 0; j < resultstr.Detail[i].Items.length; j++) {
                                reportcard += '                                       <tr>';

                                if (resultstr.Detail[i].subjectid === 12) {
                                    reportcard += ' <td dir="rtl" style="border: 1px solid black; text-align:right">' + resultstr.Detail[i].Items[j].KLO + '</td>';
                                }
                                else if (resultstr.Detail[i].subjectid === 17) {
                                    reportcard += ' <td dir="rtl" style="border: 1px solid black; text-align:right">' + resultstr.Detail[i].Items[j].KLO + '</td>';
                                }
                                else if (resultstr.Detail[i].subjectid === 18) {
                                    obtainedMarks = resultstr.Detail[i].Items[j].Marks_Obtained;
                                    reportcard += ' <td dir="rtl" style="border: 1px solid black;text-align:right;">' + resultstr.Detail[i].Items[j].KLO + '</td>';
                                   
                                }
                                else {
                                    reportcard += ' <td style="border: 1px solid black;">' + resultstr.Detail[i].Items[j].KLO + '</td>';
                                }




                                if (Session_Id == 16 && Term_Id == 1) {

                                    if (resultstr.Detail[i].Items[j].RateCode === "EXC") {
                                        reportcard += ' <td style="border: 1px solid black; color:#00B050" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Detail[i].Items[j].RateCode === "EXP") {
                                        reportcard += '  <td style="border: 1px solid black; color:#7030A0" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Detail[i].Items[j].RateCode === "EME") {
                                        reportcard += '  <td style="border: 1px solid black; color:#0070C0" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                }
                                else if (Session_Id >= 16) {


                                    if (resultstr.Detail[i].Items[j].RateCode === "EXC") {
                                        reportcard += ' <td style="border: 1px solid black; color:#00B050" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Detail[i].Items[j].RateCode === "EXP") {
                                        reportcard += '  <td style="border: 1px solid black; color:#7030A0" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Detail[i].Items[j].RateCode === "EME") {
                                        reportcard += '  <td style="border: 1px solid black; color:#0070C0" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Detail[i].Items[j].RateCode === "N.I") {
                                        reportcard += '  <td style="border: 1px solid black; color:#FF5F1F" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                }
                                else {

                                    if (resultstr.Detail[i].Items[j].RateCode === "EXC") {
                                        reportcard += ' <td style="border: 1px solid black; color:#00B050" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Detail[i].Items[j].RateCode === "EXP") {
                                        reportcard += '  <td style="border: 1px solid black; color:#7030A0" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Detail[i].Items[j].RateCode === "EME") {
                                        reportcard += '  <td style="border: 1px solid black; color:#0070C0" class="pi">' + resultstr.Detail[i].Items[j].RateCode + '</td>';

                                    }
                                }






                                reportcard += '                                       </tr>';
                            }

                            reportcard += '                                   </tr>';
                            if (resultstr.Detail[i].subjectid === 18) {
      reportcard += ' <td style="border: 1px solid black; font-weight:bold">Nazra: ' + obtainedMarks + ' /50</td>';
  }
                        }
                        







                        reportcard += '                               </tr>';

                        reportcard += '                           </tbody>';
                        reportcard += '                       </table>';
                        reportcard += '                       <h5 style="font-weight: bolder;">Teacher’s Comments:</h5>';
                        reportcard += '                       <p>' + resultstr.Header[0].ClassTeacherComments + '</p>';

                        reportcard += '                   </div>';

                        reportcard += '               </div>';

                        reportcard += '</div >';

                        reportcard += '                       </div>';

                        $(".firstthreetable").html(reportcard);


















                    },
                    complete: function () {
                        $(".overlay").hide();
                    }, error: function (err) {

                        console.log(err);


                    }

                });
          
            });
    </script>


</body>

   
</html>

