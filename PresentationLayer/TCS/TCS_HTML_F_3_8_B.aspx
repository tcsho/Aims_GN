<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCS_HTML_F_3_8_B.aspx.cs" Inherits="PresentationLayer_TCS_TCS_HTML_F_3_8_B" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html>
<head>
    <title>The City School</title>
    <meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
    <link rel="stylesheet" type="text/css" href="../../Styles/css/smoothness/jquery-ui-1.8.17.custom.css" />
    <link rel="stylesheet" type="text/css" href="../../Styles/css/main.css" />
    <script type="text/javascript" src="../../Scripts/js/jquery/jquery-1.7.1.min.js"></script>
    <script type="text/javascript" src="../../Scripts/js/jquery/jquery-ui-1.8.17.custom.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/html2canvas/0.4.1/html2canvas.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jspdf/1.0.272/jspdf.debug.js"></script>
    <style>
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
<body style="padding:0px;">
    <form id="Form1" runat="server">
    <asp:Repeater ID="Reptr_Student" runat="server" OnItemDataBound="Reptr_Student_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID='Student_No' runat="server" Value='<%#Eval("Student_Id") %>' />
            <!--This div is for outer blue boundary. height should be changed manualy according to requirement-->
            <div id="blue_border" style=" width:900px;height:1295px;padding:10px;border:1px solid blue;display: inline-block;">
                <!--//////////////////////////////////////-->
                <!-- This div is for main logo and header tilte-->
                <div id="main_header" style="width: 100%;">
                    <div id="city-school-logo" align="right" style="float: right;" width='100' height="75">
                        <img src="../../images/city_school_logo.png" width="90" height="100" >
                    </div>
                    <div id="city_school_title_info" style="float: center">
                        <div id="city-school-name" style="padding-left: 125px;">
                            <center>
                                <img src="../../images/city_06.png" width="253" height="53"></center>
                        </div>
                        <div id="city-school-header-text" style="font-family: Arial; line-height: 0.5; padding-left: 125px;">
                            <h3 style="font-weight: lighter;">
                                <br>
                                <center>
                                    Mid-year Examination 2015-2016</center>
                            </h3>
                            <p style="font-weight: lighter; margin-top: 10px;padding-left: 125px;">
                                <center>
                                 <%#Eval("Center_Name") %></center>
                            </p>
                            <p style="font-weight: lighter; margin-top: 10px;padding-left: 125px;">
                                <center>
                                 Progress Report for <%#Eval("Class_Name") %></center>
                            </p>


                        </div>
                            <br>
                    </div>
                </div>
                <!--//////////////////////////////////////-->
                <!-- Main body -->
                <div id="student-credentials" style="width: 100%;">
                            <div id="Div1" style="width: 100%;">
                    <div id="student-credentials-column-left" style="width: 46%; float: left; padding-left: 20px;">
                        <div id="column1-left" style="float: left;width: 42%;">
                            <p>
                                Name:</p>
                            <p>
                                Section:</p>
                            <p>
                                Total No.of Students:</p>
                            <p>
                                Term:</p>
                        </div>
                        <div id="column2-left" style="float: right; width: 56%; padding-left:5px;">
                            <p>
                                <%#Eval("StudentName") %></p>
                            <p>
                                <%#Eval("Section_Name") %></p>
                            <p>
                                <%#Eval("Strength") %></p>
                            <p>
                                <%#Eval("Evaluation_Criteria_Type_Name") %></p>
                        </div>
                    </div>
                    <div id="student-credentials-column-right" style="width: 50%; float: right; padding-right: 10px;">
                        <div id="column1-right" style="float: right;text-align:left">
                            <p>
                                <%#Eval("Student_No") %></p>
                            <p>
                                <%#Eval("Student_age") %></p>
                            <p>
                                <%#Eval("Class_Avg_Age") %></p>
                            <p style="text-align: Left;">
                                <%#Eval("DaysPresent") %>/<%#Eval("FirstTermDaysCH") %></p>
                        </div>
                        <div id="column2-right" style="float: left;">
                            <p>
                                ERP No:</p>
                            <p>
                                Student's Age:</p>
                            <p>
                                Average Age of class:</p>
                            <p>
                                Days Present/Total No. of Term Days:</p>
                        </div>
                    </div>
                </div>

                </div>
                <div id="academic-performance" style="padding-top: 140px; padding-bottom: 10px; text-align: center;
                    width: 100%;">
                    <p>
                        <strong>ACADEMIC PERFORMANCE</strong></p>
                </div>
                <asp:Repeater ID="SubjectMarks" runat="server">
                    <HeaderTemplate>
                        <table style="width: 97%; margin-left: 10px;">
                            <tr style="height: 2px; white-space: nowrap;">
                                <td width="42%" style="padding: 10px; text-align: left;">
                                    <strong>Subject</strong>
                                </td>
                                <td width="17%">
                                    <strong>
                                        <center>
                                            Coursework%</center>
                                    </strong>
                                </td>
                                <td width="16%">
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
                                <td width="11%">
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
                <br>
                <table style="width: 97%; margin-left: 10px;">
                    <tr>
                        <td width="38%" style="padding: 10px; widht: 25%; text-align: left">
                            Overall %
                        </td>
                        <td width="15%">
                            <%#Eval("Overall_P") %>
                        </td>
                        <td width="28%" style="padding: 10px; text-align: left">
                            Overall Grade
                        </td>
                        <td width="10%">
                            <%#Eval("Overall_G") %>
                        </td>
                    </tr>
                    <tr>
                        <td style="padding: 10px; text-align: left;">
                            Class Highest %
                        </td>
                        <td>
                            <%#Eval("Class_Heighest") %>
                        </td>
                        <td style="padding: 10px; text-align: left;">
                            Class Average %
                        </td>
                        <td>
                            <%#Eval("Class_Average") %>
                        </td>
                    </tr>
                </table>
                <div id="general-performance" style="padding-top: 30px; padding-bottom: 10px; text-align: center;
                    width: 100%;">
                    <p>
                        <strong>GENERAL PERFORMANCE</strong></p>
                </div>
                <asp:Repeater ID="GenPer" runat="server" >
                <HeaderTemplate>
                <table style="width: 97%; margin-left: 10px; border: none">
                    <tr>
                        <td width="38%" style="text-align: left; padding-left: 10px;">
                            <strong>Activity</strong>
                        </td>
                        <td width="15%">
                            <center>
                                <strong>Grade</strong></center>
                        </td>
                        <td width="29%">
                            <center>
                                <strong>Activity</strong></center>
                        </td>
                        <td width="10%">
                            <center>
                                <strong>Grade</strong></center>
                        </td>
                    </tr>
                </HeaderTemplate>
                <ItemTemplate>
                <tr>
                        <td style="text-align: left; padding-left: 10px;">
                              <%#Eval("Activity1")%>
                        </td>
                        <td>
                              <%#Eval("Perf1")%>
                        </td>
                        <td style="padding: 10px; text-align: left;">
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
                
                <div id="performance-indicators" style="padding-top: 30px; padding-bottom: 10px;
                    text-align: center; width: 100%;">
                    <p>
                        <strong>PERFORMANCE INDICATORS</strong></p>
                </div>
                <div id="performance-indicators-table" style="margin-left: 10px; padding-top: 10px;
                    padding-bottom: 15px; padding-left: 20px; padding-right: 20px; width: 91.5%;
                    height: 50px; border: 2px solid black; display: inline-block;">
                    <!--&nbsp is used to add space between text-->
                    <p style="margin-top: 0.5px;">
                        <strong>Academic Grade</strong><span class="bottompara">A*=90-100,</span><span class="bottompara">A=80-90,</span><span
                            class="bottompara">B=70-79,</span><span class="bottompara">C=60-69,</span><span class="bottompara">D=50-59,</span><span
                                class="bottompara">E=40-49,</span><span class="bottompara">U=39 or less</span></p>
                    <p style="margin-top: 0.5px;">
                        <strong>General Performance</strong><span class="bottompara">EX=Excellent</span><span
                            class="bottompara">G=Good Progress</span><span class="bottompara">ST=Satisfactory</span><span
                                class="bottompara">NI=Needs Improvement</span></p>
                </div>
                <br>
                <br />
                <div id="class-teacher-comment" style="margin-left:10px">
                    <p style="padding-left: 10px; margin-top: 0.5px;">
                        <h5>
                            <strong>Class Teacher's Comments:</strong></h5>
                        <span style="text-decoration: underline;line-height:150%;text-align:justify">
                            <%#Eval("ClassTeacher_Comments") %></span></p>
                </div>
                <p>
                </p>
                <p style="padding-top: 130px; bottom: 0;">
                    *This is a system generated report and does not require any signature and stamp.</p>
                <!--//////////////////////////////////////-->
            </div>
        </ItemTemplate>
    </asp:Repeater>
  
    </form>
</body>
</html>
