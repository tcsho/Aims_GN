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
   <%-- <link rel="stylesheet" type="text/css" href="font-awesome.min.css">--%>
    <link rel="stylesheet" type="text/css" href="../Component_Marks/ReportCard/fonts/font-awesome-4.7.0/css/font-awesome.min.css">

    <link rel="stylesheet" type="text/css" href="../Component_Marks/ReportCard/sweetalert2.min.css">
    <script type="text/javascript" src="../Component_Marks/ReportCard/sweetalert2.min.js"></script>
    <script type="text/javascript" src="../Component_Marks/ReportCard/qr-code.js"></script>
    



          <style>
       /* *{
            font-size:14px;
        }*/
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
           
              /*  border: 15px solid #69bcff !important;*/
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
/*.top-row {
                display: flex;*/
                /* justify-content: space-between;
                align-items: center;
                position: relative; */
            /*}*/
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
 
 
/*body {
                margin: 0;
            }*/
 
            /* Hide browser-specific print info like page number */
            .no-print {
                display: none;
            }
}       



 
      
        * {
      font-size: 14px;
  }

  body {
      font-family: Arial, sans-serif;
      padding: 20px;
      background: gainsboro;
      
  }

  .bg-green {
      background: #c1ff72;
  }


  /* Make sure tables look good */
  .table td,
  .table th {
      padding: 8px;
  }

  /* Make sure background colors print */
  .subject-header td {
      background-color: #ffebcd !important;
      -webkit-print-color-adjust: exact;
      print-color-adjust: exact;
  }

  * {
      -webkit-print-color-adjust: exact !important;
      print-color-adjust: exact !important;
  }

  .report-card-container {
      max-width: 750px;
      margin: 0 auto;
      position: relative;
  }

  .school-supplies {
      position: absolute;
      width: 100%;
      height: 100%;
      pointer-events: none;
      z-index: 1;
  }

  .report-card {
      overflow: hidden;
      position: relative;
      z-index: 2;
      margin-bottom: 30px;
      background: url('../../images/EYE_mainbg.png');
      background-size: 100% 100%;
      background-repeat: no-repeat;
      min-height: 950px;
      height: auto;
  }

  .learning-area {
      background: url('../../images/learning-area-bg.png');
      background-size: 100% 100%;

    /*  background: 
        linear-gradient(rgba(255, 255, 255, 0.8), rgba(255, 255, 255, 0.5)), 
        url(../../images/learning-area-bg.png);
    background-size: 100% 100%;
    background-repeat: no-repeat;*/
  }

  .other-subjects {
      background: none;
      position: relative; /* Needed for positioning pseudo-element */
    /*  background: url('../../images/EYE_mainbg.png');*/
      background: url('../../images/comment-bg.png');
    

  }

  .other-subjects::before {
      content: "";
      position: absolute;
      top: 0;
      left: 0;
      width: 100%;
      height: 100%;
      background: url('../../images/subjects-bg-1.png');
      background-size: contain;
      background-repeat: repeat;
      
      z-index: -1; /* Place behind content */
  }

  .header {
      padding: 20px;
      padding-bottom: 10px;
      text-align: center;
      position: relative;
  }

  .header .branch-name {
      font-size: 15px;
      font-weight: 600;
      text-transform: capitalize;
  }

  .page-header {
      display: none;
  }

  @font-face {
     font-family: 'Arenski';
     src: url('../Component_Marks/ReportCard/arenski/ARENSKI.ttf') format('truetype'), url('../Component_Marks/ReportCard/arenski/arenskiregular.ttf') format('truetype');
  }

  @font-face {
      font-family: 'jameel';
      src: url('../Component_Marks/ReportCard/fonts/Jameel-Noori-Nastaleeq/Jameel-Noori-Nastaleeq.ttf') format('truetype'), url('../Component_Marks/ReportCard/fonts/Jameel-Noori-Nastaleeq/Jameel-Noori-Nastaleeq.ttf') format('truetype');
  }

  .school-label {
      color: #4169e1;
      font-size: 4rem;
      font-family: 'Arenski', sans-serif !important;
      margin-bottom: 20px;
  }

  .school-name {
      font-family: 'Brush Script MT', cursive;
      color: #4169e1;
      font-size: 36px;
      margin-bottom: 10px;
      text-align: left;
      padding-left: 20px;
  }

  .report-title {
      color: black;
      font-weight: bold;
      padding: 3px;
      font-size: 30px;
      text-align: center;
  }

  .student-info {
      padding: 0 15px 15px 15px;
  }

  .student-info-content {
      max-width: 90%;
      margin: auto;
      margin-bottom: 15px;
      margin-top: 35px;
  }

  .student-class {
      max-width: 95%;
      margin: auto;
      padding-right: 40px;
  }

  .student-info-content p {
      margin-bottom: 8px;
  }

  .logo {
      width: 100px;
      height: 100px;
  }

  .student-photo {
      width: 175px;
      height: 140px;
      border: 1px solid #ccc;
      object-fit: cover;
  }

  .student-class-name {
      height: fit-content;
      padding: 41px 0;
      font-size: 23px;
  }

  .section-title {
      background-color: #ffebcd;
      color: #333;
      padding: 8px 15px;
      font-weight: bold;
      text-align: center;
      margin-bottom: 0;
  }

  .learning-title {
      text-align: center;
      font-weight: bold;
      margin-bottom: 15px;
      margin-top: 20px;
      font-size: 22px;
  }
  .content-section hr {
      width: 80%;
      opacity: 1;
      border: 1px solid #c1c1c1;
      margin-top: 30px;
  }

  .learning-objects {
      width: 83%;
      margin-bottom: 180px;
  }

  .hexagon-container {
      margin-bottom: 180px;
  }


  .subject-row:last-child {
      border-bottom: none;
  }

  .grade-cell {
      text-align: center;
      font-weight: bold;
      width: 80px;
  }

  .learning-areas {
      padding: 20px;
      text-align: center;
      border-bottom: 2px solid #fdd177;
  }

  .area-box {
      font-size: 16px;
      font-weight: 700;
      margin-bottom: 60px;
  }

  .development-section {
      padding: 15px 15px;
      background: #c8dff7b5;
      max-width: 92%;
      margin: auto;
      margin-bottom: 160px;
  }

  .development-item {
      font-size: 14px;
  }

  .subject-section {
      margin: 30px 25px 20px 25px;
  }

  .subject-header {
      background-color: #ffebcd;
      color: black;
      padding: 32px 15px;
      text-align: center;
      border: 2px solid #fed89e;
      border-bottom: 0;
  }

  .subject-header td {
      font-size: 22px !important;
      font-weight: 700;
  }

  .subject-content {
      overflow: hidden;
  }

  .table {
      margin-bottom: 0;
      border: 2px solid #fed89e;
  }

  .table td,
  th {
      background: none;
      border: 2px solid black !important;
      font-weight: 600;
      font-size: 13px;
      vertical-align: middle;
  }

  
  .urdu-subject .subjects-elo {
      font-size: 14px;
      font-family: jameel;
      text-align: right;
  }
  
  .islamiyat-subject .subjects-elo {
      font-family: jameel;
      font-size: 14px !important;
      text-align: right;
  }
  .comments-section{
      padding: 30px 25px 260px 25px;
      background-size: 100% 100%;
      margin-bottom: 30px;
  }

  /* Hexagon Learning Areas Styles */
  .hexagon-container {
      display: flex;
      flex-direction: column;
      justify-content: center;
      padding: 20px 10%;
      gap: 23px;
      margin: 0 auto;
      max-width: 1000px;
      position: relative;
  }

  .hex-row {
      display: flex;
      align-items: center;
      margin: -24px 0;
      position: relative;
  }

  .hex-row:nth-child(1) {
      margin-left: 60px;
  }

  .hex-row:nth-child(3) {
      margin-left: 60px;
  }

  .hex-row:nth-child(4) {
      margin-left: 354px;
  }

  .hex-row:nth-child(5) {
      margin-left: 296px;
  }

  .hexagon {
      width: 110px;
      height: 126px;
      position: relative;
      margin: 0 4px;
      display: flex;
      flex-direction: column;
      align-items: center;
      justify-content: center;
      clip-path: polygon(50% 0%, 100% 25%, 100% 75%, 50% 100%, 0% 75%, 0% 25%);
      background-clip: padding-box;
      box-sizing: border-box;
  }

  .hexagon-content {
      text-align: center;
      padding: 20px 3px;
      width: 100%;
  }

  .hexagon-title {
      font-size: 13px;
      font-weight: bold;
      margin-bottom: 2px;
      margin-top: 10px;
      text-transform: uppercase;
      line-height: 1.3;
  }

  .hex-science .hexagon-title {
      font-size: 12px;
      line-height: 1.3;
  }

  .hexagon-line {
      width: 80%;
      height: 2px;
      background: #000;
      margin: 2px auto;
  }

  .hexagon-number {
      font-size: 28px;
      font-weight: 500;
      margin-top: 8px;
      line-height: 1;
  }

  .hex-english {
      background: 
      linear-gradient(210deg, #82d384 66%, #81c39c 61%), 
      linear-gradient(149deg, #82d384 67%, #81c39c 58%), 
      linear-gradient(152deg, #81c39c 34%, #64bea6 26%), 
      linear-gradient(209deg, #80c39c 33%, #64bea6 27%);
      background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }

  .hex-math {
      background: 
      linear-gradient(210deg, #e2df5c 66%, #dbd953 61%), 
      linear-gradient(149deg, #e2df5c 67%, #dbd953 58%), 
      linear-gradient(152deg, #dbd953 34%, #c9cf64 26%), 
      linear-gradient(209deg, #dbd953 33%, #c9cf64 27%);
      background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }

  .hex-science {
      background: 
      linear-gradient(210deg, #f4d681 66%, #efc96e 61%), 
      linear-gradient(149deg, #f4d681 67%, #efc96e 58%), 
      linear-gradient(152deg, #efc96e 34%, #f49a6d 26%), 
      linear-gradient(209deg, #efc96e 33%, #f49a6d 27%);
      background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }

  .hex-computing {
      background:
       linear-gradient(210deg, #f47e6d 66%, #f1786b 61%), 
       linear-gradient(149deg, #f47e6d 67%, #f1786b 58%), 
       linear-gradient(152deg, #f1786b 34%, #eb6c67 26%), 
       linear-gradient(209deg, #f1786b 33%, #eb6c67 27%);
      background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }

  .hex-music {
      background:
       linear-gradient(210deg, #f46ac0 66%, #e562b1 61%), 
       linear-gradient(149deg, #f46ac0 67%, #e562b1 58%), 
       linear-gradient(152deg, #e562b1 34%, #d96fb2 26%), 
       linear-gradient(209deg, #e562b1 33%, #d96fb2 27%);
     background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }

  .hex-physical {
      background:
       linear-gradient(210deg, #e8b1f4 66%, #d3a2e7 61%),
        linear-gradient(149deg, #e8b1f4 67%, #d3a2e7 58%),
         linear-gradient(152deg, #d3a2e7 34%, #bb8ed5 26%),
          linear-gradient(209deg, #d3a2e7 33%, #bb8ed5 27%);
      background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }

  .hex-urdu {
      background:
       linear-gradient(210deg, #5ce1de 66%, #5cccc8 61%),
        linear-gradient(149deg, #5ce1de 67%, #5cccc8 58%), 
        linear-gradient(152deg, #5cccc8 34%, #5cbbc0 26%), 
        linear-gradient(209deg, #5cccc8 33%, #5cbbc0 27%);
      background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }

  .hex-islamiyat {
      background:
       linear-gradient(210deg, #8597ed 66%, #8493eb 61%), 
       linear-gradient(149deg, #8597ed 67%, #8493eb 58%), 
       linear-gradient(152deg, #8493eb 34%, #7e7cd1 26%), 
       linear-gradient(209deg, #8493eb 33%, #7e7cd1 27%);
      background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }

  .hex-comments {
      background:
       linear-gradient(210deg, #8d88d5 66%, #967fd0 61%), 
       linear-gradient(149deg, #8d88d5 67%, #967fd0 58%), 
       linear-gradient(152deg, #967fd0 34%, #8579b7 26%), 
       linear-gradient(209deg, #967fd0 33%, #8579b7 27%);
      background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }

  .hex-empty {
      background: #e5e5e5;
      background-size: 50% 51%, 51% 51%, 51% 50%, 50% 50%;
      background-position: top left, top right, bottom left, bottom right;
      background-repeat: no-repeat;
  }
  .hex-empty-dark{
      background: #bebebd;
  }

  /* Set up page for printing with minimal margins */
  @page {
      width: 210mm;
      height: 297mm;
      margin: 0;
  }

  @media print {

      html,
      body {
          width: 210mm;
          height: 297mm;
          margin: 0;
          padding: 0;
          background: white;
      }

      .learning-area {
          height: auto; /* Allow height to adjust dynamically */
      }

      .other-subjects::before {
          height: 100% !important; /* Ensure pseudo-element covers entire section */
      }

      /* Make report-card-container full width in print */
      .report-card-container {
          max-width: 100% !important;
          width: 100% !important;
          margin: 0 !important;
          padding: 0 !important;
      }

      /* Force each report-card section to start on a new page */
      .report-card {
          page-break-before: auto;
          page-break-after: auto; /* Allow subjects to flow */
          page-break-inside: avoid;
          break-before: auto;
          break-after: auto;
          break-inside: avoid;
          margin: 0 !important;
          padding: 0.2cm 0.3cm !important;
          width: 100% !important;
          max-width: 100% !important;
          box-shadow: none !important;
          min-height: 297mm !important; /* Allow height to adjust dynamically */
          height: auto; /* Allow height to adjust dynamically */
          display: flex;
          flex-direction: column;
          box-sizing: border-box;
      }

      .report-card:nth-child(1), /* Student Info */
      .report-card:nth-child(2) { /* Learning Areas */
          page-break-after: always; /* Force a page break after these */
          break-after: page; /* For newer browsers */
      }

      .other-subjects.comments-section {
          page-break-before: always; /* Ensure teacher comments start on a new page */
          break-before: page; /* For newer browsers */
      }

      /* Remove page break after the last report card */
      .report-card:last-child {
          page-break-after: auto;
          break-after: auto;
      }

      /* Handle table page breaks */
      table {
          page-break-inside: auto;
      }

      /* Make headers repeat on each page */
      thead.repeat-header {
          display: table-header-group;
      }

      /* Make sure the header row doesn't break */
      tr {
          page-break-inside: avoid;
      }

      /* Make sure tables fit properly */
      .table {
          width: 100%;
          margin-bottom: 1rem;
      }

      /* Adjust header padding for print */
      .header {
          padding: 15px 15px 8px 15px !important;
      }

      /* Adjust student info sections */
      .student-info {
          padding: 0 15px 15px 15px !important;
      }

      .student-info-content {
          margin-top: 25px !important;
          margin-bottom: 20px !important;
      }

      /* Adjust subject sections */
      .subject-section {
          margin: 25px 20px 20px 20px !important;
      }

      /* Adjust development section */
      .development-section {
          margin-bottom: 120px !important;
      }

      /* Adjust learning objects */
      .learning-objects {
          margin-bottom: 140px !important;
      }

      /* Adjust hexagon container for print */
      .hexagon-container {
          margin-bottom: 140px !important;
      }

      .hexagon {
          -webkit-print-color-adjust: exact !important;
          print-color-adjust: exact !important;
          box-shadow: 0 0 0 4px #000 !important;
      }

      /* Adjust learning title */
      .learning-title {
          margin-top: 50px !important;
          margin-bottom: 20px !important;
      }

      /* Adjust report title */
      .report-title {
          padding: 5px !important;
          margin-bottom: 8px !important;
      }

      /* Adjust school label */
      .school-label {
          margin-bottom: 15px !important;
      }

      /* Adjust table spacing */
      .table {
          margin-bottom: 1.5rem !important;
      }

      /* Adjust subject header */
      .subject-header td {
          padding: 25px 15px !important;
      }

      /* Adjust table cells */
      .table td,
      .table th {
          padding: 10px !important;
      }

      /* Keep mb-5 and pb-5 classes with proper spacing */
      .mb-5 {
          margin-bottom: 2rem !important;
      }

      .pb-5 {
          padding-bottom: 2rem !important;
      }

      /* Print color adjustments */
      * {
          -webkit-print-color-adjust: exact !important;
          print-color-adjust: exact !important;
      }
  }

  .back-to-top {
      position: fixed;
      bottom: 20px;
      right: 20px;
      background-color: #007bff;
      color: white !important;
      width: 50px;
      height: 50px;
      border-radius: 50%;
      display: flex;
      align-items: center;
      justify-content: center;
      font-size: 24px;
      text-decoration: none;
      box-shadow: 0 2px 10px rgba(0, 0, 0, 0.2);
      z-index: 1000;
      transition: background-color 0.3s ease;
  }

  .back-to-top:hover {
      background-color: #0056b3;
  }
   </style>
</head>
<body id="bodyOldsess">

        
        <div class="overlay"></div>
     
                                  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 no-padding">
    <div class="reporttable article">
        <div class="firstthreetable"></div>
        <div class="remainingtable"></div>
    </div>
</div>

            <!--bootsrap-->
       



   

    <script>
        function scrollToSection(sectionId) {
            const section = document.getElementById(sectionId);
            if (section) {
                $('html, body').animate({
                    scrollTop: $(section).offset().top
                }, 800);
            }
        }

        function scrolltoTop() {
            $('html, body').animate({
                scrollTop: $('#reportCon').offset().top
            }, 800);
        }

        //$('#backToTop').click(function (e) {
        //    e.preventDefault();
          
        //});

        $(document).ready(function () {

           

            $(".overlay").show();

            // Back to top button functionality
            $(window).scroll(function () {
                if ($(this).scrollTop() > 1000) {
                    $('#backToTop').fadeIn();
                } else {
                    $('#backToTop').fadeOut();
                }
            });

           
           
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


            function mapClassName(className) {
                const classMap = {
                    "Class 1": "Junior I",
                    "Class 2": "Junior II",
                    "Class 3": "Junior III",
                    "Class 4": "Junior IV",
                    "Class 5": "Junior V",
                    "Class 6": "Prep I",
                    "Class 7": "Prep II",
                    "Class 8": "Prep III",
                    "Class 9": "Senior I",
                    "Class 10": "Senior II",
                    "Class 11": "Senior III"
                };
                return classMap[className] || className; // If not found, return as is
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
                      //  console.log(JSON.parse(resultstr));
                        

                        for (var k = 0; k < resultstr.Header.length; k++) {
                           
                            var originalClass = resultstr.Header[k].Header[0].Class_Name;
                        var displayClass = mapClassName(originalClass);
                        
                            //if (Session_Id == 16 && Term_Id == 2) {
                            if ((Session_Id >= 17 && (Term_Id == 1 || Term_Id == 2)) || (Session_Id == 16 && Term_Id == 2)) {
                        //if (Session_Id >= 17) {
                           
                            reportcard += ' <div class="report-container" >';
                            reportcard += '    <div class="report-card-container" >';
                            reportcard += '        <div class="report-card">';
                            reportcard += '            <div class="header d-flex justify-content-between pb-0">';
                            reportcard += '                <div class="text-left">';
                            reportcard += '                    <div class="text-start branch-name centerName">';
                            reportcard += '                    ' + resultstr.Header[k].Header[0].Center_Name + '</div>';
                            reportcard += '                    <strong class="ml-4 studentId">' + resultstr.Header[k].Header[0].Student_Id + '</strong>';
                            reportcard += '                </div>';
                            reportcard += '                <img src="https://backend.csn.edu.pk/email_template/img/logo.png" alt="School Logo" class="logo" />';
                            reportcard += '            </div>';
                            reportcard += '            <h1 class="text-center school-label">The City School</h1>';

                            if (Term_Id == 1) {
                                reportcard += '            <div class="report-title">FIRST TERM REPORT CARD ' + resultstr.Header[k].Header[0].SessionCode + '</div>';

                            }
                            else {
                                reportcard += '            <div class="report-title">SECOND TERM REPORT CARD ' + resultstr.Header[k].Header[0].SessionCode + '</div>';
                            }                            
                            reportcard += '            <div class="student-info">';
                            reportcard += '                <div class="d-flex student-class">';
                            reportcard += '                    <img id="studentImage_' + resultstr.Header[k].Header[0].Student_Id + '" class="student-photo" src="" alt="Student Photo" width="100">';
                            reportcard += '                        <div id="studentClass"';
                            reportcard += '                            class="border-top border-bottom border-dark w-100 d-flex align-items-center justify-content-center font-weight-bold student-class-name"> ' + displayClass + '';
                            reportcard += '                        </div>';
                            reportcard += '                </div>';
                            reportcard += '                <div class="row student-info-content">';
                            reportcard += '                    <div class="col">';
                            reportcard += '                        <p><strong>Student:</strong> <span id="studentName">' + resultstr.Header[k].Header[0].First_Name + '</span></p>';
                            reportcard += '                        <p><strong>School:</strong> <span id="schoolName">' + resultstr.Header[k].Header[0].Center_Name.split("-")[1] + '</span></p>';
                            reportcard += '                        <p><strong>Attendance:</strong>';
                            reportcard += '                            <spna id="attendance">' + resultstr.Header[k].Header[0].DaysAttend + ' (out of ' + resultstr.Header[k].Header[0].SecondTermDays + ' days)</span>';
                            reportcard += '                        </p>';
                            reportcard += '                    </div>';
                            reportcard += '                    <div class="col pl-4">';
                            reportcard += '                        <p><strong>Date of Birth:</strong> <span id="dob">' + formatdate(resultstr.Header[k].Header[0].Date_Of_Birth) + '</span></p>';
                            reportcard += '                        <p><strong>Section:</strong> <span id="studentSection">' + resultstr.Header[k].Header[0].Section_Name + '</span></p>';
                            reportcard += '                        <p><strong>Level:</strong> <span id="studentLevel">' + displayClass + '</span></p>';
                            reportcard += '                    </div>';
                            reportcard += '                </div>';
                            reportcard += '            </div>';


                            reportcard += '              <h4 class="font-weight-bold text-center mb-3">UNDERSTANDING YOUR CHILD\'S REPORT</h4 >';
                            reportcard += '     <div class="development-section">';
                            reportcard += '  <div class="card border-0 p-2 px-3">';
                            reportcard += '     <strong class="mb-1">Performance Indicators (PI)</strong>';
                            reportcard += '    <ul class="development-item pl-4 mb-0" id="performanceList_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '    </ul>';
                            reportcard += '   </div>';
                            reportcard += '  </div>';
                            reportcard += '    </div >';


                           


                            reportcard += '     <div class="report-card learning-area" id="reportCon">';
                            reportcard += '         <div class="header print-hide d-flex justify-content-between pb-0">';
                            reportcard += '             <div class="text-left">';
                            reportcard += '                 <div class="text-start branch-name centerName">';
                            reportcard += '                 ' + resultstr.Header[k].Header[0].Center_Name + '</div>';
                            reportcard += '                 <strong class="ml-4 studentId">' + resultstr.Header[k].Header[0].Student_Id + '</strong>';
                            reportcard += '             </div>';
                            reportcard += '             <img src="https://backend.csn.edu.pk/email_template/img/logo.png" alt="School Logo" class="logo" />';
                            reportcard += '         </div>';
                        
                            reportcard += '         <h1 class="text-center school-label">The City School</h1>';
                            
                            reportcard += '         <div class="content-section position-relative">';
                            reportcard += '             <hr />';
                            reportcard += '             <div class="learning-title">CLICK TO VIEW</div>';
                            reportcard += '             <div class="d-flex justify-content-center w-100">';
                            reportcard += '                 <div class="hexagon-container hexagon-container_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                     <!-- Row 1: English at top -->';
                            reportcard += '                     <div class="hex-row">';
                            reportcard += '                         <div class="hexagon hex-english hex-english_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                             <div class="hexagon-content hexagon-content_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                 <div class="hexagon-title">ENGLISH</div>';
                            reportcard += '                                 <div class="hexagon-line"></div>';
                            reportcard += '                                 <div class="hexagon-number">01</div>';
                            reportcard += '                             </div>';
                            reportcard += '                         </div>';
                            reportcard += '                     </div>';
                            reportcard += '                     <!-- Row 2: Math and Empty (offset left) -->';
                            reportcard += '                     <div class="hex-row">';
                            reportcard += '                         <div class="hexagon hex-math hex-math_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                             <div class="hexagon-content hexagon-content_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                 <div class="hexagon-title">MATHEMATICS</div>';
                            reportcard += '                                 <div class="hexagon-line"></div>';
                            reportcard += '                                 <div class="hexagon-number">02</div>';
                            reportcard += '                             </div>';
                            reportcard += '                         </div>';
                            reportcard += '                         <div class="hexagon hex-empty">';
                            reportcard += '                             <div class="hexagon-content"></div>';
                            reportcard += '                         </div>';
                            reportcard += '                         <div class="hexagon hex-music hex-music_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                             <div class="hexagon-content hexagon-content_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                 <div class="hexagon-title">MUSIC AND ART</div>';
                            reportcard += '                                 <div class="hexagon-line"></div>';
                            reportcard += '                                 <div class="hexagon-number">05</div>';
                            reportcard += '                             </div>';
                            reportcard += '                         </div>';

                            reportcard += '                             <div class="hexagon hex-computing hex-computing_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                 <div class="hexagon-content hexagon-content_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                     <div class="hexagon-title">COMPUTING</div>';
                            reportcard += '                                     <div class="hexagon-line"></div>';
                            reportcard += '                                     <div class="hexagon-number">06</div>';
                            reportcard += '                                 </div>';
                            reportcard += '                             </div>';

                           
                            reportcard += '                     </div>';
                            reportcard += '                     <!-- Row 3: Science, Computing, Music -->';
                            reportcard += '                     <div class="hex-row">';
                            reportcard += '                         <div class="hexagon hex-science hex-science_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                             <div class="hexagon-content hexagon-content_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                 <div class="hexagon-title">GENERAL KNOWLEDGE/<br>SCIENCE/<br>SOCIAL STUDIES';
                            reportcard += '                                 </div>';
                            reportcard += '                                     <div class="hexagon-line"></div>';
                            reportcard += '                                     <div class="hexagon-number">03</div>';
                            reportcard += '                                 </div>';
                            reportcard += '                             </div>';
                            reportcard += '                             <div class="hexagon hex-urdu hex-urdu_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                 <div class="hexagon-content hexagon-content_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                     <div class="hexagon-title">URDU</div>';
                            reportcard += '                                     <div class="hexagon-line"></div>';
                            reportcard += '                                     <div class="hexagon-number">04</div>';
                            reportcard += '                                 </div>';
                            reportcard += '                             </div>';
                            reportcard += '                             <div class="hexagon hex-empty-dark">';
                            reportcard += '                                 <div class="hexagon-content"></div>';
                            reportcard += '                             </div>';

                            reportcard += '                         <div class="hexagon hex-physical hex-physical_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                             <div class="hexagon-content hexagon-content_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                 <div class="hexagon-title">PHYSICAL<br>EDUCATION</div>';
                            reportcard += '                                 <div class="hexagon-line"></div>';
                            reportcard += '                                 <div class="hexagon-number">07</div>';
                            reportcard += '                             </div>';
                            reportcard += '                         </div>';
                           
                            reportcard += '                         </div>';
                            reportcard += '                         <!-- Row 4: Empty, Empty, Physical (offset right) -->';
                            reportcard += '                         <div class="hex-row">';
                            reportcard += '                             <div class="hexagon hex-islamiyat hex-islamiyat_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                 <div class="hexagon-content hexagon-content_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                     <div class="hexagon-title">ISLAMIYAT</div>';
                            reportcard += '                                     <div class="hexagon-line"></div>';
                            reportcard += '                                     <div class="hexagon-number">08</div>';
                            reportcard += '                                 </div>';
                            reportcard += '                             </div>';
                           
                            reportcard += '                             <div class="hexagon hex-empty">';
                            reportcard += '                                 <div class="hexagon-content"></div>';
                            reportcard += '                             </div>';
                            reportcard += '                         </div>';
                            reportcard += '                         <!-- Row 5: Empty, Urdu, Empty -->';
                            reportcard += '                         <div class="hex-row">';
                            
                            reportcard += '                             <div class="hexagon hex-empty-dark">';
                            reportcard += '                                 <div class="hexagon-content"></div>';
                            reportcard += '                             </div>';
                            reportcard += '                             <div class="hexagon hex-comments hex-comments_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                                 <div class="hexagon-content">';
                            reportcard += '                                     <div class="hexagon-title">TEACHER\'S COMMENTS</div > ';
                            reportcard += '                                     <div class="hexagon-line"></div>';
                            reportcard += '                                     <div class="hexagon-number">09</div>';
                            reportcard += '                                 </div>';
                            reportcard += '                             </div>';
                            reportcard += '                         </div>';
                            reportcard += '                     </div>';
                            reportcard += '                 </div>';
                            reportcard += '             </div>';
                            reportcard += '         </div>';
                            reportcard += '         <div class="report-card other-subjects mb-0">';
                            reportcard += '             <div class="header d-flex justify-content-between">';
                            reportcard += '                 <div class="text-left">';
                            reportcard += '                     <div class="text-start branch-name centerName">';
                            reportcard += '                     ' + resultstr.Header[k].Header[0].Center_Name + '</div>';
                            reportcard += '                     <strong class="ml-4 studentId">' + resultstr.Header[k].Header[0].Student_Id + '</strong>';
                            reportcard += '                 </div>';
                            reportcard += '                 <img src="https://backend.csn.edu.pk/email_template/img/logo.png" alt="School Logo" class="logo" />';
                            reportcard += '             </div>';


                            reportcard += '              <div id="dynamicSubjectsContainer_' + resultstr.Header[k].Header[0].Student_Id + '"></div>';
                            reportcard += '              </div>';
                           
                            reportcard += '             <div class="other-subjects comments-section" id="teacherCommentsSection_' + resultstr.Header[k].Header[0].Student_Id + '">';
                            reportcard += '                 <div class="subject-content">';
                            reportcard += '                     <table class="table table-bordered">';
                            reportcard += '                         <thead>';
                            reportcard += '                             <tr class="subject-header">';
                            reportcard += '                                 <td';
                            reportcard += '                                     style="background: linear-gradient(270deg,#deeff6,#aec1d4) !important; padding: 30px 0 !important;">';
                            reportcard += '                                     TEACHER\'S COMMENTS</td>';
                            reportcard += '                             </tr>';
                            reportcard += '                         </thead>';
                            reportcard += '                         <tbody style="height:300px;">';
                            reportcard += '                             <tr>';
                            reportcard += '                                 <td id="teacherComments" style="vertical-align:top;">' + resultstr.Header[k].Header[0].ClassTeacherComments+'</td>';
                            reportcard += '                             </tr>';
                            reportcard += '                         </tbody>';
                            reportcard += '                     </table>';
                            reportcard += '                     <div class="d-flex align-items-center justify-content-center mt-4 pt-2">';
                            reportcard += '                         <p class="text-center mr-5 font-italic mb-0">';
                            reportcard += '                             This is a system generated report and does not require a signature';
                            reportcard += '                         </p>';
                            reportcard += '                         <img src="../../images/badge.png" width="120" class="img-fluid" />';
                            reportcard += '                     </div>';
                            reportcard += '                 </div>';
                            reportcard += '             </div>';
                           // reportcard += '         </div>';
                            reportcard += '         <!--<div class="report-card other-subjects">';
                            reportcard += '             <table id="subjectsTable" class="table">';
                            reportcard += '                 <tbody></tbody>';
                            reportcard += '             </table>';
                            reportcard += '         </div>-->';
                            reportcard += '     </div>';
                            reportcard += '</div>';
                           
                            reportcard += '<a id="backToTop" href="#" onclick="scrolltoTop()" class="back-to-top"  style="display: none;">';
                            reportcard += '   <i class="fa fa-arrow-up"></i>';
                            reportcard += '</a>';





                            //scrolltoTop()


                        }
                        else {

                       
                        reportcard += '                   <div class="container top-row">';
                            reportcard += '                       <span class="left">' + resultstr.Header[k].Header[0].First_Name + ' ' + resultstr.Header[k].Header[0].Student_Id + '</span>';
                            reportcard += '                       <span class="right">' + resultstr.Header[k].Header[0].Center_Name + '</span>';
                        reportcard += '                   </div>';
                        reportcard += '                   <div class="container custom-container">';

                        reportcard += '                       <div class="cons">';
                        reportcard += '                           <!-- User Image -->';
                        reportcard += '                           <div>';
                            reportcard += '                               <img src="' + resultstr.Header[k].Header[0].Image_Path.replace('~', '') + '" class="user-image">';
                        reportcard += '                           </div>';
                        reportcard += '                           <!-- School Logo -->';
                        reportcard += '   <div class="text-center" style="margin-top: 5%">';
                            reportcard += '                               <h3 style="color:#69b2ff;">' + resultstr.Header[k].Header[0].Type + ' Report Card ' + resultstr.Header[k].Header[0].SessionCode + '</h3>';
                            reportcard += '                               <p><h4>' + resultstr.Header[k].Header[0].First_Name + '</h4></p>';

                        if (Session_Id == 16 && Term_Id == 1) {
                            reportcard += ' <p><h4>' + resultstr.Header[k].Header[0].Class_Name + '-' + resultstr.Header[k].Header[0].Section_Name + '</h4></p>';
                        }
                        else if (Session_Id >= 16) {
                            reportcard += ' <p><h4>' + displayClass + '-' + resultstr.Header[k].Header[0].Section_Name + '</h4></p>';
                        }
                        else {
                            reportcard += ' <p><h4>' + resultstr.Header[k].Header[0].Class_Name + '-' + resultstr.Header[k].Header[0].Section_Name + '</h4></p>';
                        }


                       



                        reportcard += ' </div>';
                        reportcard += '                           <div>';
                        reportcard += '                               <img src="ReportCard/newlogo.png" alt="School Logo" class="school-logo">';
                        reportcard += '                           </div>';
                        reportcard += '                       </div>';

                      

                        reportcard += '                       <!-- Date of Birth and Attendance below the left-side image -->';
                        reportcard += '                       <div class="row">';
                        reportcard += '                           <div class="row">';
                        reportcard += '                               <div class="col-md-12" style="margin-left: 35px">';
                            reportcard += '                                   <p> <span style="text-decoration: underline;" > <strong style="text-decoration: none;">Date of Birth: </strong>' + formatdate(resultstr.Header[k].Header[0].Date_Of_Birth) + '</span></p>';
                        reportcard += '                               </div>';
                        reportcard += '                           </div>';

                        reportcard += '                       </div>';
                        reportcard += '                       <div class="row">';
                        reportcard += '                           <div class="row">';
                        reportcard += '                               <div class="col-md-12" style="margin-left: 35px">';
                            reportcard += '                                   <p><span style="text-decoration: underline;"><strong style="text-decoration: underline;">Attendance: </strong> ' + resultstr.Header[k].Header[0].DaysAttend + ' (out of ' + resultstr.Header[k].Header[0].FirstTermDays + ' days)</span></p>';
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
                            for (var i = 0; i < resultstr.Header[k].Detail.length; i++) {
                            reportcard += '                                   <tr>';

                                if (resultstr.Header[k].Detail[i].subjectid === 11) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #E0EECB; border: 1px solid black; text-align: center" class="text-success">' + resultstr.Header[k].Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #E0EECB; border: 1px solid black; text-align: center" class="text-success">PI</th>';
 
}

                                if (resultstr.Header[k].Detail[i].subjectid === 13) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #DED2E8; border: 1px solid black; text-align: center; color: purple;">' + resultstr.Header[k].Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #DED2E8; border: 1px solid black; text-align: center; color: purple;">PI</th>';
 
}

                                if (resultstr.Header[k].Detail[i].subjectid === 170) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #FFE3B8; border: 1px solid black; text-align: center; color: orange;">' + resultstr.Header[k].Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #FFE3B8; border: 1px solid black; text-align: center; color: orange;">PI</th>';
 
}

                                if (resultstr.Header[k].Detail[i].subjectid === 12) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #E5B8B7; border: 1px solid black; text-align: center; color: rgb(141, 64, 64);">' + resultstr.Header[k].Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #E5B8B7; border: 1px solid black; text-align: center; color: rgb(141, 64, 64);">PI</th>';
 
}

                                if (resultstr.Header[k].Detail[i].subjectid === 64) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">' + resultstr.Header[k].Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">PI</th>';
 
}

//if (resultstr.Detail[i].subjectid === "Art") {
 
//    reportcard += '      <th style="height: 40px; background-color: lightgray; border: 1px solid black; text-align: center; color: purple;">' + resultstr.Detail[i].subjectName + '</th>';

//    reportcard += '      <th style="height: 40px; background-color: lightgray; border: 1px solid black; text-align: center; color: purple;">PI</th>';
 
//}

                                if (resultstr.Header[k].Detail[i].subjectid === 163) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #CDECFC; border: 1px solid black; text-align: center; color: rgb(44, 160, 206);">' + resultstr.Header[k].Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #CDECFC; border: 1px solid black; text-align: center; color: rgb(44, 160, 206);">PI</th>';
 
}

                                if (resultstr.Header[k].Detail[i].subjectid === 65) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #B2A1C7; border: 1px solid black; text-align: center; color: purple;">' + resultstr.Header[k].Detail[i].subjectName + '</th>';


     reportcard += '      <th style="height: 40px; background-color: #B2A1C7; border: 1px solid black; text-align: center; color: purple;">PI</th>';
 
}

                                if (resultstr.Header[k].Detail[i].subjectid === 14) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">' + resultstr.Header[k].Detail[i].subjectName + '</th>';
     reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">PI</th>';
}
                                if (resultstr.Header[k].Detail[i].subjectid === 21) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">' + resultstr.Header[k].Detail[i].subjectName + '</th>';
     reportcard += '      <th style="height: 40px; background-color: #F9C7DD; border: 1px solid black; text-align: center; color: rgb(238, 52, 83);">PI</th>';
                            }
                                if (resultstr.Header[k].Detail[i].subjectid === 17 && resultstr.Header[k].Detail[i].Items[0].RateCode !== null) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #C6D9F1; border: 1px solid black; text-align: center" class="text-primary">' + resultstr.Header[k].Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #C6D9F1; border: 1px solid black; text-align: center" class="text-primary">PI</th>';
 
}

                                if (resultstr.Header[k].Detail[i].subjectid === 18) {
 
                                    reportcard += '      <th style="height: 40px; background-color: #F0F371; border: 1px solid black; text-align: center; color: rgb(155, 72, 6);">' + resultstr.Header[k].Detail[i].subjectName + '</th>';

     reportcard += '      <th style="height: 40px; background-color: #F0F371; border: 1px solid black; text-align: center; color: rgb(155, 72, 6);">PI</th>';
 
}
 

                                for (var j = 0; j < resultstr.Header[k].Detail[i].Items.length; j++) {
                                reportcard += '                                       <tr>';

                                    if (resultstr.Header[k].Detail[i].subjectid === 12) {
                                        reportcard += ' <td dir="rtl" style="border: 1px solid black; text-align:right">' + resultstr.Header[k].Detail[i].Items[j].KLO + '</td>';
                                }
                                    else if (resultstr.Header[k].Detail[i].subjectid === 17 && resultstr.Header[k].Detail[i].Items[j].RateCode !== null) {
                                        obtainedMarks = resultstr.Header[k].Detail[i].Items[j].Marks_Obtained;
                                        reportcard += ' <td dir="rtl" style="border: 1px solid black; text-align:right">' + resultstr.Header[k].Detail[i].Items[j].KLO + '</td>';
                                }
                                    else if (resultstr.Header[k].Detail[i].subjectid === 18) {
                                   
                                        reportcard += ' <td dir="rtl" style="border: 1px solid black;text-align:right;">' + resultstr.Header[k].Detail[i].Items[j].KLO + '</td>';
                                   
                                }
                                else {
                                        if (resultstr.Header[k].Detail[i].subjectid === 17 && resultstr.Header[k].Detail[i].Items[j].RateCode == null) {

                                    }
                                    else {
                                            reportcard += ' <td style="border: 1px solid black;">' + resultstr.Header[k].Detail[i].Items[j].KLO + '</td>';

                                    }
                                }




                                if (Session_Id == 16 && Term_Id == 1) {

                                    if (resultstr.Header[k].Detail[i].Items[j].RateCode === "EXC") {
                                        reportcard += ' <td style="border: 1px solid black; color:#00B050" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Header[k].Detail[i].Items[j].RateCode === "EXP") {
                                        reportcard += '  <td style="border: 1px solid black; color:#7030A0" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Header[k].Detail[i].Items[j].RateCode === "EME") {
                                        reportcard += '  <td style="border: 1px solid black; color:#0070C0" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                }
                                else if (Session_Id >= 16) {


                                    if (resultstr.Header[k].Detail[i].Items[j].RateCode === "EXC") {
                                        reportcard += ' <td style="border: 1px solid black; color:#00B050" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Header[k].Detail[i].Items[j].RateCode === "EXP") {
                                        reportcard += '  <td style="border: 1px solid black; color:#7030A0" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Header[k].Detail[i].Items[j].RateCode === "EME") {
                                        reportcard += '  <td style="border: 1px solid black; color:#0070C0" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Header[k].Detail[i].Items[j].RateCode === "N.I") {
                                        reportcard += '  <td style="border: 1px solid black; color:#FF5F1F" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                }
                                else {

                                    if (resultstr.Header[k].Detail[i].Items[j].RateCode === "EXC") {
                                        reportcard += ' <td style="border: 1px solid black; color:#00B050" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Header[k].Detail[i].Items[j].RateCode === "EXP") {
                                        reportcard += '  <td style="border: 1px solid black; color:#7030A0" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                    else if (resultstr.Header[k].Detail[i].Items[j].RateCode === "EME") {
                                        reportcard += '  <td style="border: 1px solid black; color:#0070C0" class="pi">' + resultstr.Header[k].Detail[i].Items[j].RateCode + '</td>';

                                    }
                                }






                                reportcard += '                                       </tr>';
                            }

                            reportcard += '                                   </tr>';

                            if (Session_Id == 16 && Term_Id == 1) {
                                if (resultstr.Header[k].Detail[i].subjectid === 18 && (resultstr.Header[k].Detail[i].Items[0].RateCode !== null && resultstr.Header[k].Detail[i].Items[0].Marks_Obtained !== null)) {
                                    reportcard += ' <td style="border: 1px solid black; font-weight:bold">Nazra: ' + obtainedMarks + ' /50</td>';
                                }
                            }
                            else if (Session_Id >= 16) {
                                if (resultstr.Header[k].Detail[i].subjectid === 17 && (resultstr.Header[k].Detail[i].Items[0].RateCode !== null && resultstr.Header[k].Detail[i].Items[0].Marks_Obtained !== null)) {
                                    reportcard += ' <td style="border: 1px solid black; font-weight:bold">Nazra: ' + obtainedMarks + ' /50</td>';
                                }
                            }
                            else {
                                if (resultstr.Header[k].Detail[i].subjectid === 18 && (resultstr.Header[k].Detail[i].Items[0].RateCode !== null && resultstr.Header[k].Detail[i].Items[0].Marks_Obtained !== null)) {
                                    reportcard += ' <td style="border: 1px solid black; font-weight:bold">Nazra: ' + obtainedMarks + ' /50</td>';
                                }
                            }


                           
                        }
                        







                        reportcard += '                               </tr>';

                        reportcard += '                           </tbody>';
                        reportcard += '                       </table>';
                        reportcard += '                       <h5 style="font-weight: bolder;">Teacher’s Comments:</h5>';
                            reportcard += '                       <p>' + resultstr.Header[k].Header[0].ClassTeacherComments + '</p>';

                        reportcard += '                   </div>';

                        reportcard += '               </div>';

                        reportcard += '</div >';

                            reportcard += '                       </div>';

                            $("#bodyOldsess").attr("style", 'background-color : #fff');


                            }

                            

                        $(".firstthreetable").html(reportcard);


                           

                          
//                        const $list = $("#performanceList").empty();
//                        (data.Indicator || []).forEach(ind => {
//                            const colorMap = { EXC: '#8c52ff', EXP: '#00bf63', EME: '#e47c01', 'N.I': '#e40125' };
//                            const color = colorMap[ind.RateCode] || 'black';
//                            $list.append(`
//    <li><strong>${ind.Description.split(':')[0]}</strong> (<strong style="color:${color}">${ind.RateCode}</strong>)</li>
//    <li class='list-unstyled' >${ind.Description.split(':')[1]} </li>
//`);
//                        });


                        // Performance indicators
                      

                     
                        }
                        for (var k = 0; k < resultstr.Header.length; k++) {

                            const data = resultstr.Header[k];
                            const dataIndicator = resultstr;

                            const $list = $("#performanceList_" + resultstr.Header[k].Header[0].Student_Id).empty();
                            (dataIndicator.Indicator || []).forEach(ind => {
                                const colorMap = { EXC: '#8c52ff', EXP: '#00bf63', EME: '#e47c01', 'N.I': '#e40125' };
                                const color = colorMap[ind.RateCode] || 'black';
                                $list.append(`
    <li><strong>${ind.Description.split(':')[0]}</strong> (<strong style="color:${color}">${ind.RateCode}</strong>)</li>
    <li class='list-unstyled' >${ind.Description.split(':')[1]} </li>
`);
                            });

                            $("#studentImage_" + resultstr.Header[k].Header[0].Student_Id).attr("src", resultstr.Header[k].Header[0].Image_Path.replace('~', 'http://tcsaims.csn.edu.pk'));

                            // Helper function to check if subject has valid data
                            function hasValidRateCode(items) {
                                return items && items.some(item => item.RateCode && item.RateCode.trim() !== '');
                            }

                            // Helper function to render subject items
                            function renderSubjectItems(items, $tbody, subjectName) {
                                (items || []).forEach(item => {
                                    const rate = item.RateCode || '';
                                    const colorMap = { "EXC": "#8c52ff", "EXP": "#00bf63", "EME": "#e47c01", "N.I": "#e40125" };
                                    const color = colorMap[rate] || "black";

                                    // Apply special styling for Urdu and Islamiyat
                                    let kloStyle = '';
                                    if (subjectName.includes('urdu') || subjectName.includes('islam')) {
                                        kloStyle = 'font-family: jameel; text-align: right;';
                                    }
                                    let kloCell = '';
                                    if (subjectName.includes('urdu') || subjectName.includes('islam')) {
                                        kloCell = `<td dir="rtl" class='subjects-elo' style='${kloStyle}'>${item.KLO}</td>`
                                    }
                                    else {
                                        kloCell = `<td class='subjects-elo' style='${kloStyle}'>${item.KLO}</td>`
                                    }

                                    const piCell = `<td style="text-align:center;color:${color};font-weight:bold;">${rate}</td>`;
                                    $tbody.append(`<tr>${kloCell}${piCell}</tr>`);
                                });
                            }

                            // Function to get subject styling based on name
                            function getSubjectStyle(subjectName) {
                                const name = subjectName.toLowerCase();

                                if (name.includes('english')) {
                                    return {
                                        bg: '#c1ff72',
                                        hexClass: 'hex-english_' + resultstr.Header[k].Header[0].Student_Id,
                                        hexTitle: subjectName.toUpperCase()
                                    };
                                } else if (name.includes('math')) {
                                    return {
                                        bg: 'linear-gradient(270deg,#9ac0fb,#c8f9db)',
                                        hexClass: 'hex-math_' + resultstr.Header[k].Header[0].Student_Id,
                                        hexTitle: subjectName.toUpperCase()
                                    };
                                } else if (name.includes('general knowledge') || name.includes('general science') ||
                                    name.includes('social studies') || name.includes('science')) {
                                    // Special formatting for Science/Social Studies - add combined format
                                    let hexTitle = subjectName.toUpperCase();
                                    if (name.includes('social studies') || name.includes('science')) {
                                        hexTitle = 'SCIENCE/<br>SOCIAL STUDIES';
                                    }
                                    return {
                                        bg: 'linear-gradient(270deg,#deeff6,#aec1d4)',
                                        hexClass: 'hex-science_' + resultstr.Header[k].Header[0].Student_Id,
                                        hexTitle: hexTitle
                                    };
                                } else if (name.includes('urdu')) {
                                    return {
                                        bg: '#e1a8f0',
                                        hexClass: 'hex-urdu_' + resultstr.Header[k].Header[0].Student_Id,
                                        hexTitle: subjectName.toUpperCase()
                                    };
                                } else if (name.includes('music') || name.includes('art')) {
                                    return {
                                        bg: 'linear-gradient(#95db87,#d0fbc7)',
                                        hexClass: 'hex-music_' + resultstr.Header[k].Header[0].Student_Id,
                                        hexTitle: subjectName.toUpperCase()
                                    };
                                } else if (name.includes('computing') || name.includes('computer')) {
                                    return {
                                        bg: '#c1ff72',
                                        hexClass: 'hex-computing_' + resultstr.Header[k].Header[0].Student_Id,
                                        hexTitle: subjectName.toUpperCase()
                                    };
                                } else if (name.includes('physical')) {
                                    return {
                                        bg: '#d9f4cd',
                                        hexClass: 'hex-physical_' + resultstr.Header[k].Header[0].Student_Id,
                                        hexTitle: subjectName.toUpperCase()
                                    };
                                } else if (name.includes('islam')) {
                                    return {
                                        bg: 'linear-gradient(270deg,#deeff6,#aec1d4)',
                                        hexClass: 'hex-islamiyat_' + resultstr.Header[k].Header[0].Student_Id,
                                        hexTitle: subjectName.toUpperCase()
                                    };
                                }

                                // Default styling
                                return {
                                    bg: '#ffebcd',
                                    hexClass: 'hex-empty',
                                    hexTitle: subjectName.toUpperCase()
                                };
                            }

                            // Track available subjects for hexagon display
                            const availableSubjects = [];
                            const $container = $('#dynamicSubjectsContainer_' + resultstr.Header[k].Header[0].Student_Id);

                            // Process subjects in the order they appear in the response
                            (data.Detail || []).forEach((subject, index) => {
                                const subjectName = (subject.subjectName || '').trim();
                                const subjectNameLower = subjectName.toLowerCase();

                                // Skip subject if no valid RateCode
                                if (!hasValidRateCode(subject.Items)) {
                                    return;
                                }

                                // Get styling for this subject
                                const style = getSubjectStyle(subjectName);

                                // Add to available subjects for hexagon
                                availableSubjects.push({
                                    name: subjectName,
                                    hexClass: style.hexClass,
                                    hexTitle: style.hexTitle
                                });

                                // Create subject section dynamically
                                const subjectId = `Subject_${ resultstr.Header[k].Header[0].Student_Id}_${index}`;
                                const displayName = subjectName.toUpperCase();

                                // Add special class for Urdu and Islamiyat subjects
                                let tableClass = 'table table-bordered';
                                if (subjectNameLower.includes('urdu')) {
                                    tableClass += ' urdu-subject';
                                } else if (subjectNameLower.includes('islam')) {
                                    tableClass += ' islamiyat-subject';
                                }

                                let subjectHtml = `
<div class="subject-section mb-5" id="${subjectId}_section">
    <div class="subject-content">
        <table class="${tableClass}" id="${subjectId}">
            <thead>
                <tr class="subject-header">
                    <td style="background: ${style.bg} !important; padding: 30px 0 !important;">
                        ${displayName}
                    </td>
                    <td style="background: ${style.bg} !important; padding: 30px 0; width: 120px">
                        PI
                    </td>
                </tr>
            </thead>
            <tbody></tbody>
        </table>`;

                                // Add Nazra marks for Islamiyat if needed
                                if (subjectNameLower.includes('islam')) {
                                    const firstItem = subject.Items && subject.Items[0];
                                    if (firstItem && firstItem.Marks_Obtained != null) {
                                        let showNazra = false;
                                        if (Session_Id == 16 && Term_Id == 1 && subject.subjectid == 18) showNazra = true;
                                        else if (Session_Id >= 16 && subject.subjectid == 17) showNazra = true;
                                        else if (Session_Id < 16 && subject.subjectid == 18) showNazra = true;

                                        if (showNazra) {
                                            subjectHtml += `<p class='mb-0' style="font-size: 16px; font-weight: bold; margin-top: 10px;"><strong>Nazra: ${firstItem.Marks_Obtained} / 50</strong></p>`;
                                        }
                                    }
                                }

                                subjectHtml += `
    </div>
</div>`;

                                // Append to container
                                $container.append(subjectHtml);

                                // Render subject items
                                const $tbody = $(`#${subjectId} tbody`);
                                renderSubjectItems(subject.Items, $tbody, subjectNameLower);
                            });

                            // Define hexagon position mapping - ordered by numbering sequence
                            // This array MUST match the exact order in HTML for proper sequential numbering
                            const hexagonPositions = [
                                { row: 1, col: 1, type: 'english', number: 1 },      // 01 - English

                                { row: 2, col: 1, type: 'math', number: 2 },         // 02 - Math
                                { row: 2, col: 2, type: 'empty', number: null },     // ALWAYS EMPTY
                                { row: 2, col: 3, type: 'music', number: 5 },        // 05 - Music
                                { row: 2, col: 4, type: 'computing', number: 6 },    // 04 - Computing

                                { row: 3, col: 1, type: 'science', number: 3 },      // 03 - Science
                                { row: 3, col: 2, type: 'urdu', number: 4 },         // 07 - Urdu
                                { row: 3, col: 3, type: 'empty-dark', number: null }, // ALWAYS EMPTY
                                { row: 3, col: 4, type: 'physical', number: 7 },     // 06 - Physical
                                
                                { row: 4, col: 1, type: 'islamiyat', number: 8 },    // 08 - Islamiyat
                                { row: 4, col: 2, type: 'empty', number: null },     // ALWAYS EMPTY

                                { row: 5, col: 1, type: 'empty-dark', number: null },  // ALWAYS EMPTY
                                { row: 5, col: 2, type: 'comments', number: 9 }     // 09 - Teacher's Comments
                                // Empty hexagons (no numbering)
                                
                                
                                
                                
                            ];

                            // Create a map of available subjects by their type
                            // Priority: Science > Social Studies > General Knowledge/General Science
                            const subjectsByType = {};

                            availableSubjects.forEach((subject) => {
                                const name = subject.name.toLowerCase();
                                let type = '';

                                if (name.includes('english')) type = 'english';
                                else if (name.includes('math')) type = 'math';
                                else if (name.includes('general knowledge') || name.includes('general science') ||
                                    name.includes('social studies') || name.includes('science')) type = 'science';
                                else if (name.includes('computing') || name.includes('computer')) type = 'computing';
                                else if (name.includes('music') || name.includes('art')) type = 'music';
                                else if (name.includes('physical')) type = 'physical';
                                else if (name.includes('urdu')) type = 'urdu';
                                else if (name.includes('islam')) type = 'islamiyat';

                                if (type) {
                                    // For science type, prioritize "Science" over "Social Studies"
                                    if (type === 'science') {
                                        if (!subjectsByType[type]) {
                                            subjectsByType[type] = subject;
                                        } else {
                                            // Replace if current subject is "Science" (higher priority)
                                            const currentName = subjectsByType[type].name.toLowerCase();
                                            if (name.includes('science') && !name.includes('social') && !name.includes('general')) {
                                                subjectsByType[type] = subject;
                                            }
                                        }
                                    } else {
                                        subjectsByType[type] = subject;
                                    }
                                }
                            });

                            // Create HTML position index mapping (matches exact HTML order)
                            const htmlOrderMapping = [
                                'english',      // Index 0 - Row 1, Col 1
                                'math',         // Index 1 - Row 2, Col 1
                                'empty',        // Index 2 - Row 2, Col 2
                                'music',        // Index 3 - Row 2, Col 3
                                'computing',  // Index 4 - Row 2, Col 4
                                'science',      // Index 5 - Row 3, Col 1
                                'urdu',     // Index 6 - Row 3, Col 2
                                'empty-dark',   // Index 7 - Row 3, Col 3
                                'physical',           // Index 8 - Row 3, Col 4
                                'islamiyat',    // Index 9 - Row 4, Col 1
                                'empty',        // Index 10 - Row 4, Col 2
                                'empty-dark',   // Index 11 - Row 5, Col 1
                                'comments'      // Index 12 - Row 5, Col 2
                            ];

                            // Clear all hexagons first
                            $('.hexagon-container_ '+ resultstr.Header[k].Header[0].Student_Id + ' .hexagon').each(function () {
                                const $hex = $(this);
                                if (!$hex.hasClass('hex-comments')) {
                                    $hex.removeClass('hex-english hex-math hex-science hex-computing hex-music hex-physical hex-urdu hex-islamiyat');
                                    $hex.addClass('hex-empty-dark');
                                    $hex.find('.hexagon-content_' + resultstr.Header[k].Header[0].Student_Id).empty();
                                    $hex.removeAttr('onclick');
                                    $hex.css('cursor', 'default');
                                }
                            });

                            // Now update hexagons based on HTML order
                            const $allHexagons = $('.hexagon-container_' + resultstr.Header[k].Header[0].Student_Id + ' .hexagon');
                            let actualSubjectsCount = 0; // Count how many subjects are actually showing

                            htmlOrderMapping.forEach((type, htmlIndex) => {
                                const $hex = $allHexagons.eq(htmlIndex);

                                if (type === 'empty') {
                                    // Keep as empty (light gray)
                                    $hex.removeClass('hex-empty-dark');
                                    $hex.addClass('hex-empty');
                                    return;
                                } else if (type === 'empty-dark') {
                                    // Keep as empty-dark
                                    $hex.addClass('hex-empty-dark');
                                    return;
                                } else if (type === 'comments') {
                                    // Teacher's comments - handle separately
                                    return;
                                }

                                // Find the position config for this type to get the number
                                const positionConfig = hexagonPositions.find(p => p.type === type);
                                if (!positionConfig || positionConfig.number === null) {
                                    $hex.addClass('hex-empty-dark');
                                    return;
                                }

                                // Check if we have this subject type in our data
                                const subject = subjectsByType[type];

                                if (subject) {
                                    // Found the subject, populate the hexagon
                                    actualSubjectsCount++; // Increment count for actual subjects
                                    const subjectIndex = availableSubjects.indexOf(subject);
                                    const subjectNumber = String(positionConfig.number).padStart(2, '0');
                                    const subjectId = `Subject_${resultstr.Header[k].Header[0].Student_Id}_${subjectIndex}_section`;

                                    $hex.removeClass('hex-empty hex-empty-dark');
                                    $hex.addClass(subject.hexClass);
                                    $hex.attr('onclick', `scrollToSection('${subjectId}')`);
                                    $hex.css('cursor', 'pointer');
                                    $hex.find('.hexagon-content_' + resultstr.Header[k].Header[0].Student_Id).html(`
                                     <div class="hexagon-title">${subject.hexTitle}</div>
                                        <div class="hexagon-line"></div>
                                      <div class="hexagon-number">${subjectNumber}</div>
    `);
                                } else {
                                    // Subject not found in data, keep empty
                                    $hex.addClass('hex-empty-dark');
                                }
                            });

                            // Add "Teacher's Comments" - dynamic number based on actual subjects count
                            const teacherCommentNumber = String(actualSubjectsCount + 1).padStart(2, '0');
                            const teacherCommentsSectionId = 'teacherCommentsSection_' + resultstr.Header[k].Header[0].Student_Id ;
                            $('.hex-comments_' + resultstr.Header[k].Header[0].Student_Id).attr('onclick', `scrollToSection('${teacherCommentsSectionId}')`);
                            $('.hex-comments_' + resultstr.Header[k].Header[0].Student_Id).css('cursor', 'pointer');
                            $('.hex-comments_' + resultstr.Header[k].Header[0].Student_Id +' .hexagon-number').text(teacherCommentNumber);





                        }

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

