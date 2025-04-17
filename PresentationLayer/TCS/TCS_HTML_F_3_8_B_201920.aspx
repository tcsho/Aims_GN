<%@ Page Title="" Language="C#" 
    AutoEventWireup="true" CodeFile="TCS_HTML_F_3_8_B_201920.aspx.cs" 
    Inherits="PresentationLayer_TCS_TCS_HTML_F_3_8_B_201920" %>

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
            padding-left: 10px;
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
                                <td width="40.5%" style="padding: 10px;padding-left:20px; text-align: left;">
                                    <strong>Subject</strong>
                                </td>
                                <td width="12%">
                                    <strong>
                                        <center>
                                            Class Learning %</center>
                                    </strong>
                                </td>
                                <td width="14%">
                                    <strong>
                                        <center>
                                            Mid-year Exam %</center>
                                    </strong>
                                </td>
<%--                                <td width="14%">
                                    <strong>
                                        <center>
                                            Term %</center>
                                    </strong>
                                </td>--%>
                                <td width="12%">
                                    <strong>
                                        <center>
                                            Exam Grade</center>
                                    </strong>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="height: 2px;">
                            <td style="padding: 10px; padding-left:20px;text-align: left">
                                <%#Eval("Subject_Name") %>
                            </td>
                            <td>
                                <%#Eval("Course_Work") %>
                            </td>
                            <td>
                                <%#Eval("Theory_Exam") %>
                            </td>
<%--                            <td>
                                <%#Eval("Marks") %>
                            </td>--%>
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
                            Overall Exam %
                        </td>
                        <td width="15%">
                            <%#Eval("Overall_P") %>
                        </td>
                        <td width="35%" style="padding: 5px; text-align: left">
                            Overall Exam Grade
                        </td>
                        <td width="15%">
                            <%#Eval("Overall_G") %>
                        </td>
                    </tr>
                </table>
                <table style="width: 97%; margin-left: 10px;">
                    <tr>
                        <td style="padding: 5px; text-align: left; width: 20%; border-top-width: 2px; border-top-color: White;">
                            Class Highest Exam %
                        </td>
                        <td style="width: 10.2%; border-top-width: 2px; border-top-color: White;">
                            <%#Eval("Class_Heighest") %>
                        </td>
                        <td style="padding: 5px; text-align: left; width: 20.0%; border-top-width: 2px; border-top-color: White;">
                            Class Lowest Exam %
                        </td>
                        <td style="width: 10.1%; border-top-width: 2px; border-top-color: White;">
                            <%#Eval("ClassMinimum")%>
                        </td>
                        <td style="padding: 5px; text-align: left; width: 25.1%; border-top-width: 2px; border-top-color: White;">
                            Class Average Exam %
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
                        <strong>Academic Grade</strong><span class="bottompara" style="padding-left:50px"><strong>A*</strong> = 90-100,</span><span
                            class="bottompara"><strong>A</strong> = 80-89,</span><span class="bottompara"><strong>B</strong>
                                = 70-79,</span><span class="bottompara"><strong>C</strong> = 60-69,</span><span class="bottompara"><strong>D</strong>
                                    = 50-59,</span><span class="bottompara"><strong>E</strong> = 40-49,</span><span class="bottompara"><strong>U</strong>
                                        = 39 or less</span></p>
                    <p style="margin-top: 0.5px;">
                        <strong>General Performance</strong>
                        <span class="bottompara"><strong>A*</strong> = Outstanding,</span>
                        <span class="bottompara"><strong>A</strong> = Very Good,</span>
                        <span class="bottompara"><strong>B</strong> = Good</span>
                        <span class="bottompara"><strong>C</strong>= Acceptable,</span>
                        <span class="bottompara"><strong>D</strong> = Needs Improvement</span></p>
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
                            <p id="P233" runat="server" style="padding-left: 25px; bottom: 0; padding-bottom: 10px;"
                                visible='<%#(Eval("isPromoted").ToString() == "False" && (Eval("Class_Id").ToString()=="12" || Eval("Class_Id").ToString()=="11") && Eval("Cond_Prom").ToString().Length < 1)?true:false%>'>
                                <strong style="font-size: x-large">&#9745;</strong> <strong>Letter of Undertaking Issued</strong>
                            </p>

                        <p style="padding-left: 25px; padding-top: 40px; bottom: 10;">
                            *This is a system generated report and does not require any signature and stamp.
                        </p>
                 <p id="P1" runat="server" style="padding-left: 25px; padding-top: 5px; bottom: 0;">
                                        <%--<strong><asp:Label ID="lblResultDate" runat="server"></asp:Label></strong>--%>
                     <strong>Date: 24<sup>th</sup> December 2019.</strong>
                                    </p>
                    </div>


            </div>
                <div id="UnderTaking3_7" runat="server" style="width: 900px; height: 1255px; padding: 10px; ; border: 1px solid blue; display: inline-block; position: relative; margin-top: 45px;"
                    visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Class_Id").ToString()=="11"  && Eval("SessionCode").ToString()=="2019-2020")?true:false%>'>
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
                            <div id="Div16" style="font-family: Arial; line-height: 0.5; text-align: center; padding-left: 90px; padding-right: 90px;">
                            </div>
                            <br>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div id="Div17" style="padding-left: 50px; padding-right: 60px; text-align: justify; font-size: 18px;">
                        <br />
                        <div id="Div18" style="float: left;">
                            <p id="P4" runat="server">
                                <strong>Date:</strong>
                                <%--<strong><asp:Label ID="IntimateDate" runat="server"></asp:Label></strong>--%>
                                <strong> 24<sup>th</sup> December 2019.</strong>
                            </p>
                            
                        </div>
                        <div style="float: right">
                            <span style='font-size: 12.0pt; line-height: 150%; text-decoration: underline;'>
                                <%#Eval("Center_Name") %></span>
                        </div>
                        <br />
                        <br />
                        <p align="center" style='text-align: center'>
                            <b><span style='font-size: 14.0pt; color: black'>Academic Performance Intimation</span></b>
                        </p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                            <span style='color: black'>
                                Dear Parents,
                            
                            </span>
                        </p>
                        
                        <br />

                        <p><span style='color: black'>
                                Reference to our ‘Welcome Letter Class 7’ shared at start of this class, this letter is to inform you that your child,  <%#Eval("StudentName")%> of <%#Eval("Class_Name") %> <%#Eval("Section_Name") %> has been performing unsatisfactorily and needs to put in sustained effort to continue with the O Level stream. 
                        </span></p>
                        
                        <br />

                        <p><span style='color: black'>
                            Continued poor performance may result in not being able to progress into the O Level stream. It is essential that you become actively involved in working with the school in order to assist in the development of a plan that will hopefully bring about academic success.
                        </span></p>
                                                
                        <br />

                        <p><span style='color: black; font-weight:bold'>
                             For promotion from Classes 7 to 8, the following conditions must be met:
                        </span></p>   

                        
                            <p style='text-align: justify; text-indent: .25in; line-height: normal;'>
                                <span style='color: black'>1) <span style='font: 7.0pt'></span></span><span
                                    style='color: black; '>A minimum of  60% in English and two other core subjects </span>
                            </p>
                            <p style='text-align: justify; text-indent: .25in; line-height: normal'>
                                <span style='color: black'>2)<span style='font: 7.0pt'> </span></span><span
                                    style='color: black'>An overall average of at least 60%</span>
                            </p>
                            <br />

                        <p><span style='color: black; font-weight:bold'>
                             The implications of continued unsatisfactory performance are as follows:
                        </span></p>   


                            <p style='text-align: justify; text-indent: .25in; line-height: normal'>
                                <span style='color: black'>1)<span style='font: 7.0pt'> </span></span><span
                                    style='color: black'>Risk of being detained in the same class </span>
                            </p>
                            <p style='text-align: justify; text-indent: .25in; line-height: normal'>
                                <span style='color: black'>2)<span style='font: 7.0pt'> </span></span><span
                                    style='color: black'>	Student will be advised to follow the matric stream</span>
                            </p>
                            <br />


                        <p><span style='color: black'>
                            If you require further details or wish to arrange a parent/teacher conference, please feel free to contact the school by issuing the letter below, in person. Or telephone 111 444 123 in order to arrange a conference. 
                        </span></p>

                            <br />
                        <hr style="border-top: 2px dashed black;">
                         <br />
                         <p align="center" style='text-align: center'>
                            <b><span style='font-size: 14.0pt; color: black; text-decoration: underline;'>Parent’s Comments</span></b>
                        </p>
                        <br />
                        <p style="word-wrap: break-word;text-align:justify;"><span style='color: black;margin-bottom:20px;line-height:45px'>
                        I, ______________________________, father/mother/guardian of <%#Eval("StudentName")%> of Class 7,</span></p>
                        
                        <br />
                        <br />
                        <hr style="border-top: 1px solid black;">
                         <br /><br />
                        <hr style="border-top: 1px solid black;">
                         <br /><br />
                                                <hr style="border-top: 1px solid black;">
                         <br /><br />
                        <hr style="border-top: 1px solid black;">
                         <br /><br />

                        
                        <p style='line-height: 150%'>
                            <span style='font-size: 14.0pt; text-align:left'><b>Signature:</b>____________________________          </span> <span style='font-size: 14.0pt; text-align:right;padding-left:39px;'><b>Signature:</b>__________________________ </span>
                        </p>
                        <p style='line-height: 150%'>
                            <span style='font-size: 14.0pt;text-align:left;padding-left:150px'>(Parent/ Guardian)</span> 
                            <span style='font-size: 14.0pt;  text-align:right;padding-left:300px'>(School Head)</span>
                        </p>
                        <br />
                        <br />
                        <p style='text-align: justify; line-height: 150%'>
                            <span style='font-size: 14.0pt; line-height: 150%; color: black'><b>Date:</b>__________________________ </span>
                        </p>

                    </div>
                </div>
                <div id="UnertakingLetterBifurcation" runat="server" style="width: 900px; height: 1295px; ; padding: 10px; border: 1px solid blue; display: inline-block; margin-top: 15px; position: relative;"
                    visible='<%#(Eval("isPromoted").ToString() == "False"  && Eval("Class_Id").ToString()=="12" && Eval("SessionCode").ToString()=="2019-2020")?true:false%>'>
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
                    <br />
                    <br />
                    <div id="div7" style="padding-left: 50px; padding-right: 60px; text-align: justify; font-size: 18px;">
                        <br />
                        <div id="Header_Date" style="float: left;">
                                                       <p id="P5" runat="server">
                                <strong>Date:</strong>
                                                           <%--<strong><asp:Label ID="UndertakeDate" runat="server"></asp:Label></strong>--%>
                            <strong> 24<sup>th</sup> December 2019.</strong>
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
                            <b><span style='font-size: 14.0pt; color: black'>Class 8 Bifurcation Letter</span></b>
                        </p>
                        <p align="center" style='text-align: center'>
                            <b><span style='font-size: 14.0pt; color: black'></span></b>
                        </p>
                        <br />
                        <p style='margin-bottom: 12.0pt; text-align: justify; line-height: normal;'>
                            
                            
                            I, as a parent/guardian of <b Style="text-decoration:underline"> <%#Eval("StudentName")%> </b> studying in Class 8 Section <%#Eval("Section_Name") %> confirm that I have read and understood the circumstances set out hereunder and have signed the agreement as per my consent:

                        </p>
                        <br />
                        <div id="Points" style="padding-left: 50px;">
                            <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                                <b><span style='color: black'>1)<span style='font: 7.0pt'> </span></span></b><span
                                    style='color: black'>That the school, after careful deliberation and consideration of the Class 8 Results, has advised me to transfer my child to the Matric system.</span>
                            </p>
                            <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                                <b><span style='color: black'>2)<span style='font: 7.0pt'> </span></span></b><span
                                    style='color: black'>However, at my insistence, the school has provisionally allowed my child to sit in Class 8 and take final examinations for the O Level stream.
                                </span>
                            </p>
                            <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                                <b><span style='color: black'>3)<span style='font: 7.0pt'> </span></span></b><span
                                    style='color: black'>I accept the responsibility that my child must pass the Class 8 Annual examinations with the minimum required attainment levels. Failing to meet the minimum requirements may result in my child repeating Class 8 in the next year.</span>
                            </p>
                          
                            <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                                <b><span style='color: black'>4)<span style='font: 7.0pt'> </span></span></b><span
                                    style='color: black'>If at that point I want my child to join Class 9M, I will take full responsibility for the missed taught course.</span>
                            </p>
                            <p style='margin-bottom: 12.0pt; text-align: justify; text-indent: -.25in; line-height: normal'>
                                <b><span style='color: black'>5)<span style='font: 7.0pt'> </span></span></b><span
                                    style='color: black'>I understand that I will also be responsible to register my child with the relevant Matric Board paying an additional fee, if applicable.</span>
                            </p>
                        </div>

                            <br />
                        <hr style="border-top: 2px dashed black;">
                         <br />
                         <p align="center" style='text-align: center'>
                            <b><span style='font-size: 14.0pt; color: black; text-decoration: underline;'>Parent’s Remarks</span></b>
                        </p>
                        <br />
                        <p style="word-wrap: break-word;text-align:justify;"><span style='color: black;margin-bottom:20px;line-height:45px'>
                        I, ______________________________, father/mother/guardian of <%#Eval("StudentName")%> of Class 8,</span></p>
                        
                        <br />
                        <br />
                        <hr style="border-top: 1px solid black;">
                         <br /><br />
                        <hr style="border-top: 1px solid black;">
                         <br /><br />
                                                <hr style="border-top: 1px solid black;">
                         <br /><br />
                        <hr style="border-top: 1px solid black;">
                         <br /><br />

                        
                        <p style='line-height: 150%'>
                            <span style='font-size: 14.0pt; text-align:left'><b>Signature:</b>____________________________          </span> <span style='font-size: 14.0pt; text-align:right;padding-left:39px;'><b>Signature:</b>__________________________ </span>
                        </p>
                        <p style='line-height: 150%'>
                            <span style='font-size: 14.0pt;text-align:left;padding-left:150px'>(Parent/ Guardian)</span> 
                            <span style='font-size: 14.0pt;  text-align:right;padding-left:300px'>(School Head)</span>
                        </p>
                        <br />
                        <br />
                        <p style='text-align: justify; line-height: 150%'>
                            <span style='font-size: 14.0pt; line-height: 150%; color: black'><b>Date:</b>__________________________ </span>
                        </p>

                    </div>
                </div>
        </ItemTemplate>
    </asp:Repeater>
    </form>
</body>
</html>

