<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCS_HTML_F_3_8_B_201617.aspx.cs"
    Inherits="PresentationLayer_TCS_TCS_HTML_F_3_8_B_201617" %>

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
            padding-left: 18px;
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
    <asp:repeater id="Reptr_Student" runat="server" onitemdatabound="Reptr_Student_ItemDataBound">
        <itemtemplate>
            <asp:HiddenField ID='Student_No' runat="server" Value='<%#Eval("Student_Id") %>' />
            <!--This div is for outer blue boundary. height should be changed manualy according to requirement-->
            <div id="blue_border" style="width: 900px; height: 1295px; padding: 10px; border: 1px solid blue;
                display: inline-block; position: relative; margin-top: 15px;">
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
                                Mid-year Examination
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
                                    &nbsp;<%#Eval("DaysPresent") %>/<%#Eval("FirstTermDaysCH")%></p>
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
                                <td width="28.5%" style="padding: 10px; text-align: left;">
                                    <strong>Subject</strong>
                                </td>
                                <td width="12%">
                                    <strong>
                                        <center>
                                            Coursework%</center>
                                    </strong>
                                </td>
                                <td width="14%">
                                    <strong>
                                        <center>
                                            Mid-year Exam %</center>
                                    </strong>
                                </td>
                                <td width="14%">
                                    <strong>
                                        <center>
                                            Term %</center>
                                    </strong>
                                </td>
                                <td width="12%">
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
                        <td width="35%" style="padding: 5px; text-align: left">
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
                </table>
                <table style="width: 97%; margin-left: 10px;">
                    <tr>
                        <td style="padding: 5px; text-align: left; width: 25%; border-top-width: 2px; border-top-color: White;">
                            Class Highest %
                        </td>
                        <td style="width: 10.2%; border-top-width: 2px; border-top-color: White;">
                            <%#Eval("Class_Heighest") %>
                        </td>
                        <td style="padding: 5px; text-align: left; width: 15.1%; border-top-width: 2px; border-top-color: White;">
                            Class Lowest %
                        </td>
                        <td style="width: 10.1%; border-top-width: 2px; border-top-color: White;">
                            <%#Eval("ClassMinimum")%>
                        </td>
                        <td style="padding: 5px; text-align: left; width: 25.1%; border-top-width: 2px; border-top-color: White;">
                            Class Average %
                        </td>
                        <td style="border-top-width: 2px; border-top-color: White;">
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
                        <strong>Academic Grade</strong><span class="bottompara"><strong>A*</strong> = 90-100,</span><span
                            class="bottompara"><strong>A</strong> = 80-89,</span><span class="bottompara"><strong>B</strong> = 70-79,</span><span
                                class="bottompara"><strong>C</strong> = 60-69,</span><span class="bottompara"><strong>D</strong> = 50-59,</span><span
                                    class="bottompara"><strong>E</strong> = 40-49,</span><span class="bottompara"><strong>U</strong> = 39
                                        or less</span></p>
                    <p style="margin-top: 0.5px;">
                        <strong>General Performance</strong><span class="bottompara"><strong>EX</strong> = Excellent,</span><span
                            class="bottompara"><strong>G</strong> = Good Progress,</span><span class="bottompara"><strong>ST</strong> = Satisfactory,</span><span
                                class="bottompara"><strong>NI</strong> = Needs Improvement</span></p>
                </div>
                <br>
                <br>
                <p>
                </p>
                <div style="position: absolute; bottom: 40px; margin-left: 10px;">
                    <%--                    <p id="P1" runat="server" style="padding-left: 25px; bottom: 0;" visible='<%#(Eval("isPromoted").ToString()== "True")?true:false%>'>--%>
                    <p id="P8" runat="server" style="padding-left: 25px; bottom: 0;" visible='false'>
                        Promoted To: <strong style="text-decoration: underline;">
                            <%#Eval("PromotedToClass")%></strong>
                    </p>
                    <p id="P2" runat="server" style="padding-left: 25px; bottom: 0;" visible='<%#(Eval("isPromoted").ToString() == "False"   &&  Eval("Cond_Prom").ToString().Length < 1)?true:false%>'>
                        <strong style="font-size: x-large">&#9745;</strong> <strong>Letter of Undertaking Issued</strong>
                    </p>
                    <p id="P3" runat="server" style="padding-left: 25px; bottom: 0;" visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Cond_Prom").ToString().Length >= 1 )?true:false%>'>
                        <strong style="text-decoration: underline;">Conditionally Promoted: </strong>
                        <%#Eval("Cond_Prom")%>
                    </p>
                    <p style="padding-left: 25px; padding-top: 40px; bottom: 10;">
                        *This is a system generated report and does not require any signature and stamp.</p>
                    <p id="P14" runat="server" style="padding-left: 25px; padding-top: 5px; bottom: 0;"
                       visible='<%#(Convert.ToInt32(Eval("Session_Id").ToString()) == 9)?true:false%>'>
                        <strong>Date: 22<sup>nd</sup> December 2017.</strong>
                    </p>
                    <p id="P15" runat="server" style="padding-left: 25px; padding-top: 5px; bottom: 0;"
                        visible='<%#(Convert.ToInt32(Eval("Session_Id").ToString()) == 10)?true:false%>'>
                        <strong>Date: 24<sup>th</sup> December 2018.</strong>
                    </p>
                       <p id="P1" runat="server" style="padding-left: 25px; padding-top: 5px; bottom: 0;"
                        visible='<%#(Convert.ToInt32(Eval("Session_Id").ToString()) == 10)?true:false%>'>
                        <strong><asp:Label ID="lblResultDate" runat="server"></asp:Label></strong>
                    </p>
                    
                </div>
            </div>


            <div id="UnderTaking3_7" runat="server" style="width: 900px; height: 1295px; padding: 10px;
                font-family: Century; border: 0px solid blue; display: inline-block; position: relative;
                margin-top: 45px;" visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Class_Id").ToString()!="12"  && Eval("SessionCode").ToString()=="2017-2018")?true:false%>'>
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
                            <strong>Date:</strong> 22<sup>nd</sup> December 2017.
                        </p>
                        <p id="P5" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Region_Id").ToString() == "2000000")?true:false%>'>
                            <strong>Date:</strong> 22<sup>nd</sup> December 2017.
                        </p>
                    </div>
                    <div style="float: right">
                        <span style='font-size: 12.0pt; line-height: 150%; text-decoration: underline;'>
                            <%#Eval("Center_Name") %></span>
                    </div>
                    <br />
                    <br />
                    <br />
                    <p align="center" style='text-align: center'>
                        <b><span style='font-size: 14.0pt; color: #990000'>LETTER OF UNDERTAKING
                            <%#Eval("Class_Name") %></span></b></p>
                    <br />
                    <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                        <span style='color: black'>I, the undersigned, as parent/ guardian of
                            <%#Eval("StudentName")%>
                        </span><span style='color: black'>of
                            <%#Eval("Class_Name") %>
                            <%#Eval("Section_Name") %>,</span> <span style='color: black'>confirm that I have understood
                                the circumstances set out hereunder and I have signed in agreement below:</span></p>
                    <br />
                    <div id="Div19" style="padding-left: 10%;">
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal;'>
                            <b><span style='color: black'>1) <span style='font: 7.0pt'></span></span></b><span
                                style='color: black; font-family: Century'>That my son/daughter/ward name above
                                has not attained the minimum result that were required for him/her to pass the Mid-Year
                                Examination. </span>
                        </p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>2)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>That it has put him/her at risk of being detained in the same
                                class.</span></p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>3)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>That it is essential for him/her to markedly improve his/her
                                performance and show the minimum required standards in the End of Year Result, failing
                                which he/she will be detained in the same class. I understand that the results of
                                End of Year Examinations include result of the Mid-year exams and the End of year
                                exams.</span></p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>4)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>I have received information from the school regarding the minimum
                                standards required for passing.</span></p>
                        <br />
                        <br />
                    </div>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <p style='text-align: justify; line-height: 150%'>
                        <span style='font-size: 14.0pt; line-height: 150%; color: black'>__________________________________
                        </span><span style='padding-left: 25%; font-size: 14.0pt; line-height: 150%; color: black'>
                            __________________________ </span>
                    </p>
                    <p style='text-align: justify; line-height: 150%'>
                        <b><span style='font-size: 14.0pt; line-height: 150%; color: #990000'>Parent/Guardian’s
                            Name & Signature</span> <span style='padding-left: 22%; font-size: 14.0pt; line-height: 150%;
                                color: #990000'>Student’s Name & Signature </span></b>
                    </p>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <p style='text-align: justify; line-height: 150%'>
                        <span style='font-size: 14.0pt; line-height: 150%; color: black'>__________________________________
                        </span><span style='padding-left: 25%; font-size: 14.0pt; line-height: 150%; color: black'>
                            __________________________ </span>
                    </p>
                    <p style='text-align: justify; line-height: 150%;'>
                        <b><span style='padding-left: 11%; font-size: 14.0pt; line-height: 150%; color: #990000'>
                            Head of School</span> <span style='padding-left: 50%; font-size: 14.0pt; line-height: 150%;
                                color: #990000'>Date </span></b>
                    </p>
                   
                </div>
            </div>
            <div id="UnertakingLetterBifurcation" runat="server" style="width: 900px; height: 1295px;
                font-family: Century; padding: 10px; border: 0px solid blue; display: inline-block;
                margin-top: 15px; position: relative;" visible='<%#(Eval("isPromoted").ToString() == "False"  && Eval("Class_Id").ToString()=="12" && Eval("SessionCode").ToString()=="2016-2017")?true:false%>'>
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
                <div id="div7" style="padding-left: 50px; padding-right: 60px; text-align: justify;
                    font-size: 18px;">
                    <br />
                    <div id="Header_Date" style="float: left;">
                        <p id="P6" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Region_Id").ToString() == "2000000")?false:true%>'>
                            <strong>Date:</strong> 22<sup>nd</sup> December 2017.
                        </p>
                        <p id="P7" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Region_Id").ToString() == "2000000")?true:false%>'>
                            <strong>Date:</strong> 22<sup>nd</sup> December 2017.
                        </p>
                    </div>
                    <div style="float: right">
                        <span style='font-size: 12.0pt; line-height: 150%; text-decoration: underline;'>
                            <%#Eval("Center_Name") %></span>
                    </div>
                    <br />
                    <br />
                    <br />
                    <p align="center" style='text-align: center'>
                        <b><span style='font-size: 14.0pt; color: #990000'>LETTER OF UNDERTAKING Class 8 Bifurcation</span></b></p>
                    <p align="center" style='text-align: center'>
                        <b><span style='font-size: 14.0pt; color: #990000'></span></b>
                    </p>
                    <br />
                    <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                        <span style='color: black'>Dear Parents,<br />
                            <br />
                            I am writing to you with reference to your written request for your son/daughter/ward
                            <%#Eval("StudentName")%>
                            in <span style='color: black'>
                                <%#Eval("Class_Name") %>
                                <%#Eval("Section_Name") %>
                                to </span>proceed to the O-level stream against school advice even though he/she
                            has not yet attained our standard academic requirement for this stream.
                            <br />
                            <br />
                            <%-- It is clearly important that, before commencing on this course of studies, all students
                            have a sound and secure academic foundation.
                            <br />
                            <br />
                            We do not usually therefore recommend students who are under-achieving academically
                            to follow the O-level path.
                            <br />
                            <br />--%>
                            In view of the above your child will be offered a place in the O-level stream under
                            the following conditions:
                            <br />
                        </span>
                    </p>
                    <br />
                    <div id="Points" style="padding-left: 50px;">
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>1)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>That you have reviewed the options available and that you are
                                certain that you prefer your child follow the O-level path.</span></p>
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>2)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>That you accept that your child must in the end year examinations
                                of Class 8 attain the standard required for Class 9 or be detained in Class 8
                            </span>
                        </p>
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>3)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>That you accept the possibility that your child may not ultimately
                                attain The City School standard required for entry to the external examinations
                                and that, if so, your child must be privately entered for the O-level examinations.</span></p>
                        <%--                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>4)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>That you will encourage your child and will oversee his/her O-level studies at home.</span></p>
                        --%>
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>4)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>In case, if you decide to put your child in class 9 Matric
                                stream after the annual examinations of class 8th if that were possible, you will
                                take full responsibility of the taught course coverage.</span></p>
                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>5)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>You will also be responsible to register your child with the
                                relevant Matric Board paying additional fee if applicable.</span></p>
                    </div>
                    <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                        <span style='color: black'>If you accept the above conditions, please sign and return
                            the undertaking below to your child’s school. Should you require further information
                            on the CIE O-level programme or on any other matter, please do not hesitate to contact
                            the Head of your child’s school.
                            <br />
                            <br />
                            Yours sincerely,
                            <br />
                            <br />
                            <p style='text-align: justify; line-height: 150%'>
                                <span style='font-size: 14.0pt; line-height: 150%; color: black'>__________________________________
                                </span><span style='padding-left: 25%; font-size: 14.0pt; line-height: 150%; color: black'>
                                    __________________________ </span>
                            </p>
                            <p style='text-align: justify; line-height: 150%;'>
                                <b><span style='padding-left: 11%; font-size: 14.0pt; line-height: 150%; color: #990000'>
                                    Head of School</span> <span style='padding-left: 45%; font-size: 14.0pt; line-height: 150%;
                                        color: #990000'>Network Head </span></b>
                            </p>
                        </span>
                    </p>
                    <br />
                    <p align="center" style='text-align: center'>
                        <b><span style='font-size: 18.0pt; color: Black'>Undertaking</span></b></p>
                    <br />
                    <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                        <strong style='color: black'>I, -----------------------------------------------, father/mother/guardian
                            of <strong style="text-decoration: underline;">
                                <%#Eval("StudentName")%>
                            </strong>Of
                            <%#Eval("Class_Name") %>
                            <%#Eval("Section_Name") %>, understand and fully accept the special conditions under
                            which my child will enter the O-Level stream.
                            <br />
                        </strong>
                    </p>
                    <br />
                    <br />
                    <br />
                    <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                        <strong style='color: black'>Signed _________________________ (Parent / Guardian) &nbsp;&nbsp;&nbsp;
                            &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Date ___________________
                        </strong>
                    </p>
                    
                </div>
            </div>
            <div id="UnertakingLetterBifurcation201718" runat="server" style="width: 900px; height: 1295px; font-family: Century; padding: 10px; border: 1px solid blue; display: inline-block; margin-top: 15px; position: relative;"
                    visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Class_Id").ToString()== "12"  && Convert.ToInt32(Eval("Session_Id").ToString())>=9) ?true:false%>'>
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
                            <div id="Div11" style="font-family: Arial; line-height: 0.5; text-align: center; padding-left: 90px; padding-right: 90px;">
                            </div>
                            <br>
                        </div>
                    </div>
                     
                    <div id="div7" style="padding-left: 50px; padding-right: 60px; text-align: justify; font-size: 18px;">
                        <br />
                        <div id="Header_Date" style="float: left;">
                            <p id="P10" runat="server" style="padding-left: 25px;" visible='<%#(Convert.ToInt32(Eval("Session_Id").ToString()) == 9)?true:false%>'>
                                <strong>Date:</strong> 22<sup>nd</sup> December 2017.
                            </p>
                            <p id="P11" runat="server" style="padding-left: 25px;" visible='<%#(Convert.ToInt32(Eval("Session_Id").ToString()) == 10)?true:false%>'>
                                <strong>Date:</strong> 24<sup>th</sup> December 2018.
                            </p>
                        </div>
                        <div style="float: right">
                            <span style='font-size: 12.0pt; line-height: 150%; text-decoration: underline;'>
                                <%#Eval("Center_Name") %></span>
                        </div>
                        <br />
                        <br />
                        <br />
                        <p align="center" style='text-align: center'>
                            <b><span style='font-size: 14.0pt; color: #990000'>LETTER OF UNDERTAKING Class 8 Bifurcation</span></b>
                        </p>
                        <p align="center" style='text-align: center'>
                            <b><span style='font-size: 14.0pt; color: #990000'></span></b>
                        </p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                            <span style='color: black'>
                                <br />
                                <br />
                                I, the undersigned, as parent/guardian of 
                            <%#Eval("StudentName")%>
                            in <span style='color: black'>
                                <%#Eval("Class_Name") %> Section  
                                <%#Eval("Section_Name") %>
                            </span>Confirm that I have understood the circumstances set out hereunder and I have signed the agreement below:
                             
                                <%-- It is clearly important that, before commencing on this course of studies, all students
                            have a sound and secure academic foundation.
                            <br />
                            <br />
                            We do not usually therefore recommend students who are under-achieving academically
                            to follow the O-level path.
                            <br />
                            <br />--%>
                           
                            </span>
                        </p>
                        <br />
                        <div id="Points" style="padding-left: 50px;">
                            <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                                <b><span style='color: black'>1)<span style='font: 7.0pt'> </span></span></b><span
                                    style='color: black'>That the school, after careful consideration of Class 8 Bifurcation Examination Results, has advised me to transfer my child to the Matric system.</span>
                            </p>
                            <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                                <b><span style='color: black'>2)<span style='font: 7.0pt'> </span></span></b><span
                                    style='color: black'>However, at my insistence, the school has provisionally allowed my child to sit in Class 8 and take final examinations for the O Level stream.
                                </span>
                            </p>
                            <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                                <b><span style='color: black'>3)<span style='font: 7.0pt'> </span></span></b><span
                                    style='color: black'>I accept the responsibility that my child must pass the Class 8 Annual examinations with the minimum required attainment levels, failing which he/she may be detained in Class 8. However, if at that point I want my child to join Class 9M, I will take full responsibility for the missed taught course coverage.</span>
                            </p>
                            <%--                        <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                            <b><span style='color: black'>4)<span style='font: 7.0pt'> </span></span></b><span
                                style='color: black'>That you will encourage your child and will oversee his/her O-level studies at home.</span></p>
                            --%>
                            <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                                <b><span style='color: black'>4)<span style='font: 7.0pt'> </span></span></b><span
                                    style='color: black'>I understand that I will also be responsible to register my child with the relevant Matric Board paying an additional fee if applicable.</span>
                            </p>


                        </div>
                        <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                            <span style='color: black'>Parent/Guardian’s Name and Signature:	___________________________________	
                            <br />
                                <br />
                                Student’s Name and Signature:		___________________________________
                            <br />
                                <br />
                                Date: _____________________________

                            <div style="border:solid 3px; width: 800px; height:200px;">
                                <br />
                                <p style='text-align: justify; line-height: 150%'>&nbsp;&nbsp;
                                    <span style='font-size: 14.0pt; line-height: 150%; color: black'>
                                        Allowed to continue in Class 8 and will sit End of Year Exams with undertaking 
                                    </span>
                                    <br /> <br /> 
                                    <span style='padding-left: 25%; font-size: 14.0pt; line-height: 150%; color: black'>
                                       &nbsp;&nbsp; Yes
                                       <img alt="" src="https://www.shareicon.net/data/512x512/2015/12/19/690066_square_512x512.png" width="20px" height="20px" />
                                    </span>
                                    <span style='padding-left: 25%; font-size: 14.0pt; line-height: 150%; color: black'>No
                                        <img alt="" src="https://www.shareicon.net/data/512x512/2015/12/19/690066_square_512x512.png" width="20px" height="20px" />
                                    </span>
                                </p>
                                <p style='text-align: justify; line-height: 150%;'>
                                    <br /> 
                                    <b><span style='padding-left: 5%; font-size: 14.0pt; line-height: 150%; color: #990000'>____________________</span> 
                                        <span style='padding-left: 25%; font-size: 14.0pt; line-height: 150%; color: #990000'>____________________ </span></b>
                                    <br />
                                    <b><span style='padding-left: 5%; font-size: 14.0pt; line-height: 150%; color: #990000'> &nbsp;&nbsp;&nbsp; &nbsp; Head / Date	</span>
                                        <span style='padding-left: 25%; font-size: 14.0pt; line-height: 150%; color: #990000'> &nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;RD / Date </span></b>
                                </p>
                            </div>
                            </span>
                        </p>
                        <br />


                    </div>
                </div>


        </itemtemplate>
    </asp:repeater>
    </form>
</body>
</html>
