<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCS_HTML_S_A.aspx.cs" Inherits="PresentationLayer_TCS_TCS_HTML_S_A" %>

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
<body style="">


    <form id="Form1" runat="server">
    <asp:Repeater ID="Reptr_Student" runat="server" OnItemDataBound="Reptr_Student_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID='Student_No' runat="server" Value='<%#Eval("Student_Id") %>' />
            <!--This div is for outer blue boundary. height should be changed manualy according to requirement-->
            <div id="blue_border" style="width: 900px; height: 1310px; padding: 10px; border: 0px solid blue;
                display: inline-block;position:relative;">
                <%-- <div id="blue_border" style="background-color: white; width: 900px; height: 1340px;
                padding: 10px; border: 4px solid #275797; display: inline-block;">--%>
                <!--//////////////////////////////////////-->
                <!-- This div is for main logo and header tilte-->
                <div id="main_header" style="width: 100%;">
                    <div id="city-school-logo" align="right" style="float: right;" width='100' height="75">
                        <img src="../../images/city_02.png" width="90" height="100">
                    </div>
                    <div id="city_school_title_info" style="float: center">
                        <div id="city-school-name" style="padding-left: 90px;padding-right:90px;text-align:center;">
                                <img src="../../images/city_01.png" width="253" height="53">
                        </div>
                        <div id="city-school-header-text" style="font-family: Arial; line-height: 0.5; padding-left: 90px; padding-right:90px;">
                            <p style="font-weight: lighter; margin-top: 10px; text-align:center;">
                                <%#Eval("Center_Name") %>
                            </p>
                            <h3 style="font-weight: lighter;padding-top:5px;text-align:center;">
                                <br>Mock Examination 2017
                            </h3>
                            <p style="font-weight: lighter; margin-top: 10px; text-align:center;padding-top:5px;">
                                    Progress Report for <%#Eval("Class_Name") %>
                            </p>
                        </div>
                        <br>
                    </div>
                </div>

                <div id="MyId" runat="server" style="font-size:larger; color: Red" visible='<%#(Eval("DaysPresent").ToString() == "")?true:false%>'>
                    *Student Attendned Days are missing.
                </div>
                <div id="Div2" runat="server" style="font-size:larger; color: Red" visible='<%#(Eval("TtlAct").ToString()== "0")?true:false%>'>
                    *General Performance Grading is missing.
                </div>

                <!--//////////////////////////////////////-->
                <!-- Main body -->
                  <div id="student-credentials" style="width: 97%;">
                    <div id="Div1" style="width: 100%;">
                        <div id="student-credentials-column-left" style="width: 50%; float: left; padding-left: 32px;">
                            <div id="column1-left" style="float: left; width: 100%;">
                                <p><strong  style="font-weight:bold;">ERP No:</strong>&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("Student_No") %></p>
                                <p><strong  style="font-weight:bold;">Name:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("StudentName") %></p>
                                <p><strong  style="font-weight:bold;">Section:</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("Section_Name") %></p>
                                <p><strong  style="font-weight:bold;">Days Present/Total No. of Term Days: </strong>&nbsp;<%#Eval("DaysPresent") %>/<%#Eval("SecondTermDaysCH")%></p>
                            </div>
                        </div>
                        <div id="student-credentials-column-right" style="width: 45%; float: right; padding-right: 00px;">
                            <div id="column1-right" style="float: right; text-align: left;width: 55%;">
                                <p>Second Term</p>
                                <p><%#Eval("Strength") %></p>
                                <p><%#Eval("Class_Avg_Age") %></p>
                                <p><%#Eval("Student_age") %></p>
                                
                                
                            </div>
                            <div id="column2-right" style="float: left;width: 45%;">
                                <p style="font-weight:bold;">Term:</p>
                                <p style="font-weight:bold;">Total No.of Students:</p>
                                <p style="font-weight:bold;">Average Age of Class:</p>
                                <p style="font-weight:bold;">Student's Age:</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="academic-performance" style="padding-top: 100px; padding-bottom: 10px; text-align: center;
                    width: 100%;">
                    <p>
                        <strong>ACADEMIC PERFORMANCE</strong></p>
                </div>
                 <asp:Repeater ID="SubjectMarks" runat="server" OnItemDataBound="Reptr_Subject_ItemDataBound">
                    <HeaderTemplate>
                        <table style="width: 97%; margin-left: 10px;">
                            <tr style="height: 2px; white-space: nowrap;">
                                <td width="40%" style="padding: 10px; text-align: left;">
                                    <strong>Subject</strong>
                                </td>
                                 <td width="16%" style="padding: 10px; text-align: center;">
                                    <strong>Component/ Paper </strong>
                                    <br>
                                    <strong>Code</strong>
                                </td>
                                
                                <td width="16%">
                                    <strong>
                                        <center>
                                            Component/ Paper %</center>
                                    </strong>
                                </td>
                                 <td width="11%" style="padding: 10px; text-align: center;">
                                    <strong>Total Exam %</strong>
                                                                </td>
                                <td width="16%">
                                    <strong>
                                        <center>
                                            Grade</center>
                                    </strong>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID='Subject_Id' runat="server" Value='<%#Eval("Subject_Id") %>' />
                        <tr style="height: 2px;">
                            <td style="padding-left:10px; text-align: left">
                                <%#Eval("Subject_Name") %>
                            </td>
                             <td>
                                <asp:Repeater ID="ComName" runat="server" OnItemDataBound="Reptr_ComName_ItemDataBound">
                                    <HeaderTemplate>
                                        <table style="width: 100%;height:100%;border:0px">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr style="border:0px">
                                            <td id="listitem" runat="server" style="border-top-width:0px;border-left-width:0px;border-right-width:0px;">
                                             <%#Eval("comp") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </td>
                            <td>
                                <asp:Repeater ID="RptrComponent" runat="server" OnItemDataBound="Reptr_RptrComponent_ItemDataBound">
                                    <HeaderTemplate>
                                        <table style="width: 100%;height:100%;border:0px">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr style="border:0px">
                                            <td id="pecrItem" runat="server"  style="border-top-width:0px;border-left-width:0px;border-right-width:0px;">
                                             <%#Eval("Percent_Marks") %>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
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
<%--                    <tr>
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
                    </tr>--%>
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
                                <td width="15%">
                                    <center>
                                        <strong>Grade</strong></center>
                                </td>
                                <td width="35%">
                                    <center>
                                        <strong>Activity</strong></center>
                                </td>
                                <td width="15%">
                                    <center>
                                        <strong>Grade</strong></center>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr style="height:25px;">
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
<%--                <div id="Div1" style="margin-left: 10px; padding-top: 10px; padding-bottom: 15px;
                    padding-left: 20px; padding-right: 20px; width: 92%; height: 160px; border: 2px solid black;
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
                </div>--%>
                <div id="performance-indicators" style="padding-top: 20px; padding-bottom: 5px;
                    text-align: center; width: 100%;">
                    <p>
                        <strong>PERFORMANCE INDICATORS</strong></p>
                </div>
                <div id="performance-indicators-table" style="margin-left: 10px; padding-top: 10px;
                    padding-bottom: 5px; padding-left: 20px; padding-right: 20px; width: 92%; height: 50px;
                    border: 2px solid black; display: inline-block;">
                    <!--&nbsp is used to add space between text-->
                    <p style="margin-top: 0.5px;">
                        <strong>Academic Grade</strong><span class="bottompara"><strong>A*</strong>=90-100,</span><span
                            class="bottompara"><strong>A</strong>=80-89,</span><span class="bottompara"><strong>B</strong>=70-79,</span><span
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
<div style="position:absolute; bottom:0px;left:0px;">

               <div id="Div3" style="margin-left:70px;padding-top:100px">
                <p style="padding-right:100px">
                  <strong style="border-top-width:2px;border-top-style:solid;padding-top:10px;">Head of School</strong>
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                  
                  <strong style="border-top-width:2px;border-top-style:solid;padding-top:10px;">Parent / Guardian</strong></p>
                   <p><strong>Date:</strong> 14<sup>th</sup> April 2017.</p>
               </div>
                <%--<script type="text/javascript">
                    now = new Date();
                    localtime = now.toDateString().toString();
                    localtime = localtime + ' ' + now.getHours().toString() + ':' + now.getMinutes().toString();
                    document.write("<p style=\"padding-left: 15px; padding-top: 20px; bottom: 0;\"><strong>Date:</strong> " + localtime +
"</p>");

   </script>--%>
</div>

            </div>
        </ItemTemplate>
    </asp:Repeater>
    <asp:HiddenField ID="OuerHF" runat="server" />
    </form>
</body>
</html>