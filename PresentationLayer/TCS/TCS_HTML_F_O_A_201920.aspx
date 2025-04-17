<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCS_HTML_F_O_A_201920.aspx.cs"
    Inherits="PresentationLayer_TCS_TCS_HTML_F_O_A_201920" %>

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
        p {
            margin: 0 0 2px;
        }

        table, th, tr, td {
            border: 2px solid #000000;
            border-collapse: collapse;
            text-align: center;
            font-family: Arial, Helvetica, sans-serif;
            font-size: 15px;
        }

        .bottompara {
            padding-left: 7px;
        }

        .button-link {
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

            .button-link:hover {
                background: #356094;
                border: solid 1px #2A4E77;
                text-decoration: none;
            }

        .testClass {
            border-bottom-width: 0px;
        }
    </style>
</head>
<body style="">
    <form id="Form1" runat="server">
        <asp:Repeater ID="Reptr_Student" runat="server" OnItemDataBound="Reptr_Student_ItemDataBound">
            <ItemTemplate>
                <asp:HiddenField ID='Student_No' runat="server" Value='<%#Eval("Student_Id") %>' />
                <!--This div is for outer blue boundary. height should be changed manualy according to requirement-->
                <div id="blue_border" style="width: 900px; height: 1295px; padding: 10px; border: 0px solid blue; display: inline-block; position: relative; margin-top: 15px;">
                    <%-- <div id="blue_border" style="background-color: white; width: 900px; height: 1340px;
                padding: 10px; border: 4px solid #275797; display: inline-block;">--%>
                    <!--//////////////////////////////////////-->
                    <!-- This div is for main logo and header tilte-->
                    <div id="main_header" style="width: 100%;">
                        <div id="city-school-logo" align="right" style="float: right;" width='100' height="75">
                            <img src="../../images/city_01.png" width="90" height="100">
                        </div>
                        <div id="city_school_title_info" style="float: center">
                            <div id="city-school-name" style="padding-left: 90px; padding-right: 90px;">
                                <center>
                                    <img src="../../images/city_01.png" width="253" height="53"></center>
                            </div>
                            <div id="city-school-header-text" style="font-family: Arial; line-height: 0.5; text-align: center; padding-left: 90px; padding-right: 90px;">
                                <h3 style="font-weight: lighter;">
                                    <br>
                                    Mid-Year Examination
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
                                        <strong style="font-weight: bold;">ERP No:</strong>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("Student_No") %>
                                    </p>
                                    <p>
                                        <strong style="font-weight: bold;">Name:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("StudentName") %>
                                    </p>
                                    <p>
                                        <strong style="font-weight: bold;">Section:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("Section_Name") %>
                                    </p>
                                    <p>
                                        <strong style="font-weight: bold;">Days Present/Total No. of Term Days: </strong>
                                        &nbsp;<%#Eval("DaysPresent") %>/<%#Eval("FirstTermDaysCH")%>
                                    </p>
                                </div>
                            </div>
                            <div id="student-credentials-column-right" style="width: 45%; float: right; padding-right: 00px;">
                                <div id="column1-right" style="float: right; text-align: left; width: 55%;">
                                    <p>
                                        <%#Eval("Evaluation_Criteria_Type_Name") %>
                                    </p>
                                    <p>
                                        <%#Eval("Strength") %>
                                    </p>
                                    <p>
                                        <%#Eval("Class_Avg_Age") %>
                                    </p>
                                    <p>
                                        <%#Eval("Student_age") %>
                                    </p>
                                </div>
                                <div id="column2-right" style="float: left; width: 45%;">
                                    <p style="font-weight: bold;">
                                        Term:
                                    </p>
                                    <p style="font-weight: bold;">
                                        Total No.of Students:
                                    </p>
                                    <p style="font-weight: bold;">
                                        Average Age of Class:
                                    </p>
                                    <p style="font-weight: bold;">
                                        Student's Age:
                                    </p>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div id="academic-performance" style="padding-top: 100px; padding-bottom: 10px; text-align: center; width: 100%;">
                        <p>
                            <strong>ACADEMIC PERFORMANCE</strong>
                        </p>
                    </div>
                    <asp:Repeater ID="SubjectMarks" runat="server" OnItemDataBound="Reptr_Subject_ItemDataBound">
                        <HeaderTemplate>
                            <table style="width: 97%; margin-left: 10px;">
                                <tr style="height: 2px; white-space: nowrap;">
                                    <td style="padding: 10px; text-align: left; width: 35%">
                                        <strong>Subject</strong>
                                    </td>

                                    <td colspan="6" style="border-width: 2px; width: 65%">
                                        <table style="width: 100%;" cellspacing="0" cellpadding="0">
                                            <tr>
                                                <td style="border-top-color: White; border-bottom-color: white; border-width: 2px;">
                                                    <strong></strong>
                                                </td>
                                                <td colspan="4" style="border-top-color: White; border-width: 2px;">
                                                    <strong>Examination</strong>
                                                </td>
                                            </tr>
                                            <tr>

                                                <td style="border-bottom-color: White; border-width: 2px; width: 22.8%; white-space: initial;">

                                                    <strong>
                                                        <center>
                                                            Continuous Assessment %</center>
                                                    </strong>
                                                </td>
                                                <%--                                          <td style="border-bottom-color: White; border-width: 2px; width: 18.6%;">
                                                    <strong>
                                                        <center>
                                                            Coursework
                                          <br />
                                                            Grade</center>
                                                    </strong>
                                                </td>--%>
                                                <td style="text-align: left; border-bottom-color: White; border-width: 2px; width: 22.7%;">

                                                    <strong>
                                                        <center>
                                                            Component/
                                   <br />
                                                            Paper Code</center>
                                                    </strong>

                                                </td>
                                                <td style="border-bottom-color: White; border-width: 2px; width: 21.4%;">
                                                    <strong>
                                                        <center>
                                                            Component
                                           <br />
                                                            Marks</center>
                                                    </strong>
                                                </td>
                                                <td style="border-bottom-color: White; border-width: 2px; width: 19.0%;">
                                                    <strong>
                                                        <center>
                                                            Exam %</center>
                                                    </strong>
                                                </td>
                                                <td style="border-bottom-color: White; border-width: 2px;">
                                                    <strong>
                                                        <center>
                                                            Exam 
                                           <br />
                                                            Grade</center>
                                                    </strong>
                                                </td>

                                            </tr>
                                        </table>


                                    </td>

                                </tr>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <asp:HiddenField ID='Subject_Id' runat="server" Value='<%#Eval("Subject_Id") %>' />
                            <tr style="height: 2px; width: 100%;">
                                <td style="padding-left: 10px; text-align: left; width: 30%">
                                    <%#Eval("Subject_Name") %>
                                </td>
                                <td colspan="6" style="border-top-color: White; border-width: 0px; width: 70%">
                                    <table style="width: 100%;" cellspacing="0" cellpadding="0">
                                        <tr>

                                            <td style="border-bottom-color: White; border-top-color: White; border-width: 2px; width: 16%;">

                                                <center>
                                                    <%#Eval("Course_Work") %></center>

                                            </td>
                                            <%--<td style="border-bottom-color: White; border-top-color: White; border-width: 2px; width: 16%;">

                                                <center>
                                                    <center>
                                                        <%#Eval("CourseworkGrade")%></center>
                                                </center>

                                            </td>--%>
                                            <td style="padding: 0px; text-align: left; border-bottom-color: White; border-top-color: White; border-width: 2px; width: 15.9%;">
                                                <asp:Repeater ID="ComName" runat="server" OnItemDataBound="Reptr_ComName_ItemDataBound">
                                                    <HeaderTemplate>
                                                        <table style="width: 100%; height: 100%; border: 0px">
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <tr style="border: 0px">
                                                            <td id="listitem" runat="server" style="border-top-width: 0px; border-left-width: 0px; border-right-width: 0px;">
                                                                <%#Eval("comp") %>
                                                            </td>
                                                        </tr>
                                                    </ItemTemplate>
                                                    <FooterTemplate>
                                                        </table>
                                                    </FooterTemplate>
                                                </asp:Repeater>
                                            </td>
                                            <td style="border-bottom-color: White; border-top-color: White; border-width: 2px; width: 15%;">

                                                <center>
                                                    <asp:Repeater ID="RptrComponent" runat="server" OnItemDataBound="Reptr_RptrComponent_ItemDataBound">
                                                        <HeaderTemplate>
                                                            <table style="width: 100%; height: 100%; border: 0px">
                                                        </HeaderTemplate>
                                                        <ItemTemplate>
                                                            <tr style="border: 0px">
                                                                <td id="pecrItem" runat="server" style="border-top-width: 0px; border-left-width: 0px; border-right-width: 0px;">
                                                                    <%#Eval("Percent_Marks") %>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                        <FooterTemplate>
                                                            </table>
                                                        </FooterTemplate>
                                                    </asp:Repeater>
                                                </center>

                                            </td>
                                            <td style="border-bottom-color: White; border-top-color: White; border-width: 2px; width: 13.2%;">
                                                <center>
                                                    <%#Eval("Marks") %></center>
                                            </td>
                                            <td style="border-bottom-color: White; border-top-color: White; border-width: 2px; width: 10.2%;">
                                                <center>
                                                    <%#Eval("Grade") %></center>
                                            </td>

                                        </tr>
                                    </table>


                                </td>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                    <br>
                    <table style="width: 97%; margin-left: 10px;">
                        <tr>
                            <td style="padding: 5px; text-align: left; width: 35%">Overall Exam %
                            </td>
                            <td style="width: 15%">
                                <%#Eval("Overall_P") %>
                            </td>
                            <td style="padding: 5px; text-align: left; width: 40%">Overall Exam Grade
                            </td>
                            <td style="width: 10%">
                                <%#Eval("Overall_G") %>
                            </td>
                        </tr>
                    </table>
                    <table style="width: 97%; margin-left: 10px;">
                        <tr>
                            <td style="padding: 5px; text-align: left; width: 20%; border-top-width: 2px; border-top-color: White;">Class Highest Exam %
                            </td>
                            <td style="width: 10.2%; border-top-width: 2px; border-top-color: White;">
                                <%#Eval("Class_Heighest") %>
                            </td>
                            <td style="padding: 5px; text-align: left; width: 20%; border-top-width: 2px; border-top-color: White;">Class Lowest Exam %
                            </td>
                            <td style="width: 10.1%; border-top-width: 2px; border-top-color: White;">
                                <%#Eval("ClassMinimum")%>
                            </td>
                            <td style="padding: 5px; text-align: left; width: 25.1%; border-top-width: 2px; border-top-color: White;">Class Average Exam %
                            </td>
                            <td style="border-top-width: 2px; border-top-color: White;">
                                <%#Eval("Class_Average") %>
                            </td>
                        </tr>
                    </table>
                    <div id="general-performance" style="padding-top: 30px; padding-bottom: 10px; text-align: center; width: 100%;">
                        <p>
                            <strong>GENERAL PERFORMANCE</strong>
                        </p>
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
                    <div id="performance-indicators" style="padding-top: 30px; padding-bottom: 10px; text-align: center; width: 100%;">
                        <p>
                            <strong>PERFORMANCE INDICATORS</strong>
                        </p>
                    </div>
                    <div id="performance-indicators-table" style="margin-left: 10px; padding-top: 10px; padding-bottom: 5px; padding-left: 20px; padding-right: 20px; width: 92%; border: 2px solid black; display: inline-block;">
                        <!--&nbsp is used to add space between text-->

                        <p style="margin-top: 0.5px;">
                            <div runat="server" id="AG1" visible='<%# Eval("Class_Id").ToString()!="19"?true:(Eval("Class_Id").ToString()=="19"?(System.Convert.ToInt16(Eval("Session_id"))<13?true:false):false) %>'>
                                <strong>Academic Grade</strong>
                                <span class="bottompara" style="padding-left: 42px"><strong>A*</strong> = 90-100,</span>
                                <span class="bottompara"><strong>A</strong> = 80-89,</span>
                                <span class="bottompara"><strong>B</strong> = 70-79,</span>
                                <span class="bottompara"><strong>C</strong> = 60-69,</span>
                                <span class="bottompara"><strong>D</strong> = 50-59,</span>
                                <span class="bottompara"><strong>E</strong> = 40-49,</span>
                                <span class="bottompara"><strong>U</strong> = 39 or less</span>
                            </div>
                            <div runat="server" id="AG2" visible='<%# Eval("Class_Id").ToString()=="19"?(System.Convert.ToInt16(Eval("Session_id"))>=13?true:false):false %>'>
                                <strong>Academic Grade</strong>
                                <span class="bottompara" style="padding-left: 42px"><strong>a</strong> = 80-100,</span>
                                <span class="bottompara"><strong>b</strong> = 70-79,</span>
                                <span class="bottompara"><strong>c</strong> = 60-69,</span>
                                <span class="bottompara"><strong>d</strong> = 50-59,</span>
                                <span class="bottompara"><strong>e</strong> = 40-49,</span>
                                <span class="bottompara"><strong>u</strong> = 39 or less</span>
                            </div>
                        </p>


                        <p style="margin-top: 0.5px;">
                            <strong>General Performance</strong>
                            <span class="bottompara"><strong>A*</strong> = Outstanding,</span>
                            <span class="bottompara"><strong>A</strong> = Very Good,</span>
                            <span class="bottompara"><strong>B</strong> = Good</span>
                            <span class="bottompara"><strong>C</strong>= Acceptable,</span>
                            <span class="bottompara"><strong>D</strong> = Needs Improvement</span>
                        </p>
                    </div>
                    <br>
                    <br />
                    <div style="position: absolute; bottom: 40px; margin-left: 10px;">



                        <div id="Div26" style="margin-left: 70px; padding-top: 130px">
                            <p style="padding-right: 100px">
                                <strong style="border-top-width: 2px; border-top-style: solid; padding-top: 10px;">Head of School</strong>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  
                  <strong style="border-top-width: 2px; border-top-style: solid; padding-top: 10px;">Parent / Guardian</strong>
                            </p>



                        </div>



                        <div id="Ses2018" runat="server" visible='<%#(Convert.ToInt32(Eval("Session_Id").ToString()) >= 9 && Convert.ToInt32(Eval("Session_Id").ToString()) <= 12 )?true:false%>'>
                            <p id="P10" runat="server" style="padding-left: 25px;"
                                visible='<%#(Eval("Class_Id").ToString() == "13" || Eval("Class_Id").ToString() == "14" || Eval("Class_Id").ToString() == "15" )?true:false%>'>
                                <strong>Date:</strong> 24<sup>th</sup> December 2019.
                            </p>
                            <p id="P11" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Class_Id").ToString() == "19" || Eval("Class_Id").ToString() == "20" )?true:false%>'>
                                <strong>Date:</strong> 30<sup>th</sup> December 2019.
                            </p>
                        </div>

                        <div id="Ses2021" runat="server" visible='<%#(Convert.ToInt32(Eval("Session_Id").ToString()) >= 13)?true:false%>'>
                            <p id="P1" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Class_Id").ToString() == "19"  )?true:false%>'>
                                <strong>Date:</strong> 03<sup>rd</sup> January 2022.
                            </p>
                            <p id="P2" runat="server" style="padding-left: 25px;" visible='<%#(Eval("Class_Id").ToString() == "20" )?true:false%>'>
                                <strong>Date:</strong> 25<sup>rd</sup>
                                January 2022.
                            </p>
                        </div>



                    </div>
                    <!--//////////////////////////////////////-->
                </div>

            </ItemTemplate>
        </asp:Repeater>
        <asp:HiddenField ID="OuerHF" runat="server" />
    </form>
</body>
</html>


