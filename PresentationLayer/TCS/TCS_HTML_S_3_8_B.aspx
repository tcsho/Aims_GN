﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCS_HTML_S_3_8_B.aspx.cs"
    Inherits="PresentationLayer_TCS_TCS_HTML_S_3_8_B" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head>
    <title>The City School</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="stylesheet" type="text/css" href="../../Styles/css/smoothness/jquery-ui-1.8.17.custom.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/css/main.css" />
    <script type="text/javascript" src="../../Scripts/js/jquery/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/js/jquery/jquery-ui-1.8.17.custom.min.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.js"></script>
    <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.0.272/jspdf.debug.js"></script>
    <style type="text/css">
        p
        {
            margin: 0 0 2px;
        }
        table, th, tr, td
        {
            border: 2px solid #000000;
            border-collapse: collapse;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
        }
        
        .bottompara
        {
            padding-left: 20px;
        }
        
        .button-link
        {
            height: 60px;
            padding: 10px 15px;
            background: #4479BA;
            color: #FFF;
            -webkit-border-radius: 4px;
            -moz-border-radius: 4px;
            border-radius: 4px;
            border: solid 1px #20538D;
            text-shadow: 0 -1px 0 rgba(0, 0, 0, 0.4);
            -webkit-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.4), 0 1px 1px rgba(0, 0, 0, 0.2);
            -moz-box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.4), 0 1px 1px rgba(0, 0, 0, 0.2);
            box-shadow: inset 0 1px 0 rgba(255, 255, 255, 0.4), 0 1px 1px rgba(0, 0, 0, 0.2);
        }
        .button-link:hover
        {
            background: #356094;
            border: solid 1px #2A4E77;
            text-decoration: none;
        }
    </style>
</head>
<body style="">
    <form id="Form1" runat="server">
    <asp:Repeater ID="Reptr_Student" runat="server" OnItemDataBound="Reptr_Student_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID='Student_No' runat="server" Value='<%#Eval("Student_Id") %>' />
            <!--This div is for outer blue boundary. height should be changed manualy according to requirement-->
            <div id="blue_border" style="width: 880px; height: 1310px; padding: 10px; border: 1px solid blue;
                display: inline-block; position: relative;margin-top:15px;">
                <%-- <div id="blue_border" style="background-color: white; width: 900px; height: 1340px;
                padding: 10px; border: 4px solid #275797; display: inline-block;">--%>
                <!--//////////////////////////////////////-->
                <!-- This div is for main logo and header tilte-->
                <div id="main_header" style="width: 100%;">
                    <div id="city-school-logo" align="right" style="float: right;" width='100' height="75">
                        <img src="../../images/city_school_logo.png" width="90" height="100">
                    </div>
                    <div id="city_school_title_info" style="float: center">
                        <div id="city-school-name" style="padding-left: 90px; padding-right: 90px;">
                            <center>
                                <img src="../../images/city_06.png" width="253" height="53"></center>
                        </div>
                        <div id="city-school-header-text" style="font-family: Arial; line-height: 0.5; text-align: center;
                            padding-left: 90px; padding-right: 90px;">
                            <h3 style="font-weight: lighter;">
                                <br>
                                End of Year Examination
                                <%#Eval("SessionCode") %>
                            </h3>
                            <p style="font-weight: lighter; margin-top: 10px; text-align: center; padding-top: 5px;">
                                <%#Eval("Center_Name") %>
                            </p>
                            <p style="font-weight: lighter; margin-top: 10px; text-align: center; padding-top: 5px;">
                                Progress Report for
                                <%#Eval("Class_Name") %>
                            </p>
                        </div>
                        <br>
                    </div>
                </div>
                <!--//////////////////////////////////////-->
                <!-- Main body -->
                <div id="MyId" runat="server" style="font-size: larger; color: Red" visible='<%#(Eval("DaysPresent").ToString() == "")?true:false%>'>
                    *Student Attendned Days are missing.
                </div>
                <div id="Div5" runat="server" style="font-size: larger; color: Red" visible='<%#(Eval("TtlAct").ToString()== "0")?true:false%>'>
                    *General Performance Grading is missing.
                </div>
                <div id="student-credentials" style="width: 97%;">
                    <div id="Div3" style="width: 100%;">
                        <div id="student-credentials-column-left" style="width: 50%; float: left; padding-left: 32px;">
                            <div id="column1-left" style="float: left; width: 100%;">
                                <p>
                                    <strong style="font-weight: bold;">ERP No:</strong>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("Student_No") %></p>
                                <p>
                                    <strong style="font-weight: bold;">Name:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("StudentName") %></p>
                                <p>
                                    <strong style="font-weight: bold;">Section:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("Section_Name") %></p>
                                <p>
                                    <strong style="font-weight: bold;">Days Present/Total No. of Term Days: </strong>
                                    &nbsp;<%#Eval("DaysPresent") %>/<%#Eval("SecondTermDaysCH")%></p>
                            </div>
                        </div>
                        <div id="student-credentials-column-right" style="width: 45%; float: right; padding-right: 00px;">
                            <div id="column1-right" style="float: right; text-align: left; width: 55%;">
                                <p>
                                    <%#Eval("Evaluation_Criteria_Type_Name") %></p>
                                <p>
                                    <%#Eval("Strength") %></p>
                                <p>
                                    <%#Eval("Class_Avg_Age") %></p>
                                <p>
                                    <%#Eval("Student_age") %></p>
                            </div>
                            <div id="column2-right" style="float: left; width: 45%;">
                                <p style="font-weight: bold;">
                                    Term:</p>
                                <p style="font-weight: bold;">
                                    Total No.of Students:</p>
                                <p style="font-weight: bold;">
                                    Average Age of Class:</p>
                                <p style="font-weight: bold;">
                                    Student's Age:</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="academic-performance" style="padding-top: 100px; padding-bottom: 10px; text-align: center;
                    width: 100%;">
                    <p>
                        <strong>ACADEMIC PERFORMANCE</strong></p>
                </div>
                <asp:Repeater ID="SubjectMarks" runat="server">
                    <HeaderTemplate>
                        <table style="width: 97%; margin-left: 10px;">
                            <tr style="height: 2px; white-space: nowrap;">
                                <td width="25%" style="padding: 10px; text-align: left;">
                                    <strong>Subject</strong>
                                </td>
                                <td width="12%">
                                    <strong>
                                        <center>
                                            Mid-year Result %</center>
                                    </strong>
                                </td>
                                <td width="12%">
                                    <strong>
                                        <center>
                                            <strong>Second Term</strong>
                                            <br>
                                            <strong>Coursework %</strong></center>
                                    </strong>
                                </td>
                                <td width="12%">
                                    <strong>
                                        <center>
                                            <strong>End of Year</strong>
                                            <br>
                                            <strong>Exam %</strong></center>
                                    </strong>
                                </td>
                                <td width="12%">
                                    <strong>
                                        <center>
                                            Average %</center>
                                    </strong>
                                </td>
                                <td width="13%">
                                    <strong>
                                        <center>
                                            Grade</center>
                                    </strong>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="height: 2px;">
                            <td style="padding: 10px; text-align: left">
                                <%#Eval("Subject_Name") %>
                            </td>
                            <td>
                                <%#Eval("Mid_Year") %>
                            </td>
                            <td>
                                <%#Eval("Course_Work") %>
                            </td>
                            <td>
                                <%#Eval("Theory_Exam") %>
                            </td>
                            <td>
                                <%#Eval("Marks") %>
                            </td>
                            <td>
                                <%#Eval("Grade") %>
                            </td>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br>
                <table style="width: 97%; margin-left: 10px;">
                    <tr>
                        <td width="35%" style="padding: 5px; widht: 25%; text-align: left">
                            Overall %
                        </td>
                        <td width="15%">
                            <%#Eval("Overall_P") %>
                        </td>
                        <td width="35%" style="padding: 5px; text-align: left">
                            Overall Grade
                        </td>
                        <td width="15%">
                            <%#Eval("Overall_G") %>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 5px; text-align: left;">
                            Class Highest %
                        </td>
                        <td>
                            <%#Eval("Class_Heighest") %>
                        </td>
                        <td style="padding: 5px; text-align: left;">
                            Class Average %
                        </td>
                        <td>
                            <%#Eval("Class_Average") %>
                        </td>
                    </tr>
                </table>
                <div id="general-performance" style="padding-top: 20px; padding-bottom: 5px; text-align: center;
                    width: 100%;">
                    <p>
                        <strong>GENERAL PERFORMANCE</strong></p>
                </div>
                <asp:Repeater ID="GenPer" runat="server">
                    <HeaderTemplate>
                        <table style="width: 97%; margin-left: 10px; border: none">
                            <tr>
                                <td width="35%" style="text-align: left; padding-left: 10px;">
                                    <strong>Activity</strong>
                                </td>
                                <td width="15%" style="text-align: left; padding-left: 10px;">
                                    <center>
                                        <strong>Grade</strong></center>
                                </td>
                                <td width="35%" style="text-align: left; padding-left: 10px;">
                                    <strong>Activity</strong>
                                </td>
                                <td width="15%" style="text-align: left; padding-left: 10px;">
                                    <center>
                                        <strong>Grade</strong></center>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="height: 25px;">
                            <td style="text-align: left; padding-left: 10px;">
                                <%#Eval("Activity1")%>
                            </td>
                            <td>
                                <%#Eval("Perf1")%>
                            </td>
                            <td style="padding-left: 10px; text-align: left;">
                                <%#Eval("Activity2") %>
                            </td>
                            <td>
                                <%#Eval("Perf2")%>
                            </td>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <div id="Div1" style="margin-left: 10px; padding-top: 10px; padding-bottom: 15px;
                    padding-left: 0px; padding-right: 0px; width: 96.45%; height: 140px; border: 2px solid black;
                    margin-top: 20px;">
                    <div id="Div2" style="padding-top: 0px; padding-bottom: 10px; text-align: center;
                        width: 100%;">
                        <p>
                            <strong>Clubs / Societies / Co-Curricular Activities</strong></p>
                    </div>
                    <div id="class-teacher-comment" style="margin-left: 10px">
                        <p style="padding-left: 10px; margin-top: 0.5px;">
                            <span style="text-decoration: underline; line-height: 150%; text-align: justify">
                                <%#Eval("ClassTeacher_Comments") %></span></p>
                    </div>
                </div>
                <div id="performance-indicators" style="padding-top: 15px; padding-bottom: 5px; text-align: center;
                    width: 100%;">
                    <p>
                        <strong>PERFORMANCE INDICATORS</strong></p>
                </div>
                <div id="performance-indicators-table" style="margin-left: 10px; padding-top: 10px;
                    padding-bottom: 5px; padding-left: 20px; padding-right: 20px; width: 92%; border: 2px solid black;
                    display: inline-block;">
                    <!--&nbsp is used to add space between text-->
                    <p style="margin-top: 0.5px;">
                        <strong>Academic Grade</strong><span class="bottompara"><strong>A*</strong>=90-100,</span><span
                            class="bottompara"><strong>A</strong>=80-90,</span><span class="bottompara"><strong>B</strong>=70-79,</span><span
                                class="bottompara"><strong>C</strong>=60-69,</span><span class="bottompara"><strong>D</strong>=50-59,</span><span
                                    class="bottompara"><strong>E</strong>=40-49,</span><span class="bottompara"><strong>U</strong>=39
                                        or less</span></p>
                    <p style="margin-top: 0.5px;">
                        <strong>General Performance</strong><span class="bottompara"><strong>EX</strong>=Excellent</span><span
                            class="bottompara"><strong>G</strong>=Good Progress</span><span class="bottompara"><strong>ST</strong>=Satisfactory</span><span
                                class="bottompara"><strong>NI</strong>=Needs Improvement</span></p>
                </div>
                <br>
                <br>
                <p>
                </p>
                <div style="position: absolute; bottom: 80px; margin-left: 10px;">
                    <p id="P1" runat="server" style="padding-left: 25px; bottom: 0;" visible='<%#(Eval("isPromoted").ToString()== "True")?true:false%>'>
                        Promoted To: <strong style="text-decoration: underline;">
                            <%#Eval("PromotedToClass")%></strong>
                    </p>
                    <p id="P2" runat="server" style="padding-left: 25px; bottom: 0;" visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Cond_Prom").ToString().Length < 1)?true:false%>'>
                        <strong style="text-decoration: underline;">Not Promoted</strong>
                    </p>
                    <p id="P3" runat="server" style="padding-left: 25px; bottom: 0;" visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Cond_Prom").ToString().Length >= 1 )?true:false%>'>
                        <strong style="text-decoration: underline;">Discretionarily Promoted </strong>
                        
                    </p>
                    <p style="padding-left: 25px; padding-top: 40px; bottom: 10;">
                        *This is a system generated report and does not require any signature and stamp.</p>
                    <p runat="server" style="padding-left: 25px; padding-top: 20px; bottom: 0;" visible='<%#(Eval("Region_Id").ToString() == "2000000")?false:true%>'>
                        <strong>Date: 2<sup>nd</sup> June 2017.</strong>
                    </p>
                    <p runat="server" style="padding-left: 25px; padding-top: 20px; bottom: 0;" visible='<%#(Eval("Region_Id").ToString() == "2000000")?true:false%>'>
                        <strong>Date: 2<sup>nd</sup> June 2017.</strong>
                    </p>
                </div>
            </div>
<%--            <div id="UnderTakingSimple" runat="server" style="width: 900px; height: 1310px; padding: 10px;
                border: 1px solid blue; display: inline-block; position: relative;" visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Cond_Prom").ToString().Length < 1)?true:false%>'>
                <!--//////////////////////////////////////-->
                <!-- This div is for main logo and header tilte-->
                <div id="Div12" style="width: 100%;">
                    <div id="Div13" align="right" style="float: right;" width='100' height="75">
                        <img src="../../images/city_school_logo.png" width="90" height="100">
                    </div>
                    <div id="Div14" style="float: center">
                        <div id="Div15" style="padding-left: 90px; padding-right: 90px;">
                            <center>
                                <img src="../../images/city_06.png" width="253" height="53"></center>
                        </div>
                        <div id="Div16" style="font-family: Arial; line-height: 0.5; text-align: center;
                            padding-left: 90px; padding-right: 90px;">
                        </div>
                        <br>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <div id="Div17" style="padding-left: 50px; padding-right: 60px; text-align: justify;
                    font-size: 18px;">
                    <br />
                    <div id="Div18" style="float: left;">
                        <p id="P4" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Region_Id").ToString() == "2000000")?false:true%>'>
                            <strong>Date:</strong> 6<sup>th</sup> June 2017.
                        </p>
                        <p id="P5" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Region_Id").ToString() == "2000000")?true:false%>'>
                            <strong>Date:</strong> 3<sup>rd</sup> June 2017.
                        </p>
                    </div>
                    <div style="float: right">
                        Campus: <span style='font-size: 12.0pt; line-height: 150%; text-decoration: underline;'>
                            <%#Eval("Center_Name") %></span>
                    </div>
                    <br />
                    <p align="center" style='text-align: center'>
                        <b><span style='font-size: 18.0pt; font-family: "Calibri",sans-serif; color: #990000'>
                            LETTER OF UNDERTAKING</span></b></p>
                    <p align="center" style='text-align: center'>
                        <b><span style='font-size: 18.0pt; font-family: "Calibri",sans-serif; color: #990000'>
                            <%#Eval("Class_Name") %></span></b></p>
                    <br />
                    <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                        <span style='color: black'>I, the undersigned, as parent/ guardian of <strong style="text-decoration: underline;">
                            <%#Eval("StudentName")%>
                        </strong></span><span style='color: black'>of
                            <%#Eval("Class_Name") %>
                            <%#Eval("Section_Name") %>,</span> <span style='color: black'>confirm that I have understood
                                the circumstances set out hereunder and I have signed in agreement below:</span></p>
                    <br />
                    <div id="Div19" style="padding-left: 50px;">
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal;'>
                            <b><span style='color: black'>1)<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span></span></b><span style='color: black'>That my son/daughter/ward name above has
                                not attained the minimum result that was required for him/her to pass the Annual
                                Examination.</span></p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>2)<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span></span></b><span style='color: black'>That it is essential for him/her to improve
                                his/her performance and show the minimum required standards in the next academic
                                year. I understand that the Annual Result includes result of the Mid-year exams
                                and the End-of-year exams.</span></p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>3)<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span></span></b><span style='color: black'>I have received information from the school
                                regarding the minimum standards required for promotion to next class.</span></p>
                        <br />
                        <br />
                    </div>
                    <p style='text-align: justify; line-height: 150%'>
                        <b><span style='font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif;
                            color: #990000'>Parent/Guardian’s Name & Signature</span> <span style='padding-left: 28%;
                                font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif; color: #990000'>
                                Student’s Name & Signature </span></b>
                    </p>
                    <br />
                    <br />
                    <p style='text-align: justify; line-height: 150%'>
                        <span style='font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif;
                            color: black'>__________________________________ </span><span style='padding-left: 25%;
                                font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif; color: black'>
                                __________________________ </span>
                    </p>
                    <p style='text-align: justify; line-height: 150%;'>
                        <b><span style='padding-left: 18%; font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif;
                            color: #990000'>Head</span> <span style='padding-left: 55%; font-size: 14.0pt; line-height: 150%;
                                font-family: "Calibri",sans-serif; color: #990000'>Date </span></b>
                    </p>
                    </span></p>
                </div>
            </div>--%>
<%--            <div id="UnertakingLetterPromotion" runat="server" style="width: 900px; height: 1310px;
                padding: 10px; border: 1px solid blue; display: inline-block; position: relative;"
                visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Cond_Prom").ToString().Length >= 1 )?true:false%>'>
                <!--//////////////////////////////////////-->
                <!-- This div is for main logo and header tilte-->
                <div id="Div6" style="width: 100%;">
                    <div id="Div8" align="right" style="float: right;" width='100' height="75">
                        <img src="../../images/city_school_logo.png" width="90" height="100">
                    </div>
                    <div id="Div9" style="float: center">
                        <div id="Div10" style="padding-left: 90px; padding-right: 90px;">
                            <center>
                                <img src="../../images/city_06.png" width="253" height="53"></center>
                        </div>
                        <div id="Div11" style="font-family: Arial; line-height: 0.5; text-align: center;
                            padding-left: 90px; padding-right: 90px;">
                        </div>
                        <br>
                    </div>
                </div>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <div id="div7" style="padding-left: 50px; padding-right: 60px; text-align: justify;
                    font-size: 18px;">
                    <br />
                    <div id="Header_Date" style="float: left;">
                        <p id="P6" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Region_Id").ToString() == "2000000")?false:true%>'>
                            <strong>Date:</strong> 6<sup>th</sup> June 2017.
                        </p>
                        <p id="P7" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Region_Id").ToString() == "2000000")?true:false%>'>
                            <strong>Date:</strong> 3<sup>rd</sup> June 2017.
                        </p>
                    </div>
                    <div style="float: right">
                        Campus: <span style='font-size: 12.0pt; line-height: 150%; text-decoration: underline;'>
                            <%#Eval("Center_Name") %></span>
                    </div>
                    <br />
                    <p align="center" style='text-align: center'>
                        <b><span style='font-size: 18.0pt; font-family: "Calibri",sans-serif; color: #990000'>
                            LETTER OF UNDERTAKING</span></b></p>
                    <p align="center" style='text-align: center'>
                        <b><span style='font-size: 18.0pt; font-family: "Calibri",sans-serif; color: #990000'>
                            Discretionary Promotion</span></b></p>
                    <br />
                    <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                        <span style='color: black'>I, the undersigned, as parent/ guardian of <strong style="text-decoration: underline;">
                            <%#Eval("StudentName")%>
                        </strong></span><span style='color: black'>of
                            <%#Eval("Class_Name") %>
                            <%#Eval("Section_Name") %>,</span> <span style='color: black'>confirm that I have understood
                                the circumstances set out hereunder and I have signed in agreement below:</span></p>
                    <br />
                    <div id="Points" style="padding-left: 50px;">
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal;'>
                            <b><span style='color: black'>1)<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span></span></b><span style='color: black'>That my son/daughter/ward name above has
                                not attained the minimum result that was required for him/her to pass the Annual
                                Examination.</span></p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>2)<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span></span></b><span style='color: black'>However, I have shown cause for this below-par
                                achievement and, on my assertion and persistent request, the school has conditionally
                                allowed my child promotion to the next class. I understand that this provision is
                                available only once and I will not be able to seek it again.</span></p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>3)<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span></span></b><span style='color: black'>That it is essential for him/her to improve
                                his/her performance and show the minimum required standards in the next academic
                                year. I understand that the Annual Result includes result of the Mid-year exams
                                and the End-of-year exams.</span></p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>4)<span style='font: 7.0pt "Times New Roman"'>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </span></span></b><span style='color: black'>I have received information from the school
                                regarding the minimum standards required for passing.</span></p>
                        <br />
                        <br />
                    </div>
                    <p style='text-align: justify; line-height: 150%'>
                        <b><span style='font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif;
                            color: #990000'>Parent/Guardian’s Name & Signature</span> <span style='padding-left: 28%;
                                font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif; color: #990000'>
                                Student’s Name & Signature </span></b>
                    </p>
                    <br />
                    <br />
                    <p style='text-align: justify; line-height: 150%'>
                        <span style='font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif;
                            color: black'>__________________________________ </span><span style='padding-left: 25%;
                                font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif; color: black'>
                                __________________________ </span>
                    </p>
                    <p style='text-align: justify; line-height: 150%;'>
                        <b><span style='padding-left: 18%; font-size: 14.0pt; line-height: 150%; font-family: "Calibri",sans-serif;
                            color: #990000'>Head</span> <span style='padding-left: 55%; font-size: 14.0pt; line-height: 150%;
                                font-family: "Calibri",sans-serif; color: #990000'>Date </span></b>
                    </p>
                    </span></p>
                </div>
            </div>--%>
        </ItemTemplate>
    </asp:Repeater>
    </form>
</body>
</html>
