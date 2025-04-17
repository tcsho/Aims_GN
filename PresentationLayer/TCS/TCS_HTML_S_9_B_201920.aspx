<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCS_HTML_S_9_B_201920.aspx.cs" Inherits="PresentationLayer_TCS_TCS_HTML_S_9_B_201920" %>

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
            padding-left: 10px;
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

        
        <div style="text-align:center" >
            <asp:ImageButton id="imgBtn" runat="server"
           AlternateText="Download"
           ImageUrl="/images/downloadbutton.png"
 
           OnClick="Button1_Click"/>
        </div>

    <asp:Repeater ID="Reptr_Student" runat="server" OnItemDataBound="Reptr_Student_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID='Student_No' runat="server" Value='<%#Eval("Student_Id") %>' />
            <!--This div is for outer blue boundary. height should be changed manualy according to requirement-->
            <div id="blue_border" style="width: 900px; height: 1295px; padding: 10px; border: 2px solid blue;
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
                                    <strong style="font-weight: bold;">Total No. of Term Days: </strong>
                                    &nbsp;<%#Eval("SecondTermDaysCH")%></p>
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
                <asp:Repeater ID="SubjectMarks" runat="server" >
                    <HeaderTemplate>
                        <table style="width: 97%; margin-left: 10px;">
                            <tr style="height: 2px; white-space: nowrap;">
                                <td width="23%" style="padding: 5px; text-align: left;">
                                    <strong>Subject</strong>
                                </td>
                                <td width="10%" style="padding: 5px; text-align: center;">
                                    <strong>Mid-year</strong>
                                    <br>
                                    <strong>Exam %</strong>
                                </td>
                                <td width="10%" style="padding: 5px; text-align: center;">
                                    <strong>End of Year</strong>
                                    <br>
                                    <strong>Class Learning %</strong>
                                </td>
 
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID='Subject_Id' runat="server" Value='<%#Eval("Subject_Id") %>' />
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
 
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br>
 
                <div id="general-performance" style="padding-top: 30px; padding-bottom: 10px; text-align: center;
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
                <div id="performance-indicators" style="padding-top: 30px; padding-bottom: 10px;
                    text-align: center; width: 100%;">
                    <p>
                        <strong>PERFORMANCE INDICATORS</strong></p>
                </div>
                <div id="performance-indicators-table" style="margin-left: 10px; padding-top: 10px;
                    padding-bottom: 5px; padding-left: 20px; padding-right: 20px; width: 92%; border: 2px solid black;
                    display: inline-block;">
                    <!--&nbsp is used to add space between text-->
<%--                    <p style="margin-top: 0.5px;">
                        <strong>Academic Grade</strong><span class="bottompara"><strong>A*</strong> = 90-100,</span><span
                            class="bottompara"><strong>A</strong> = 80-89,</span><span class="bottompara"><strong>B</strong>
                                = 70-79,</span><span class="bottompara"><strong>C</strong> = 60-69,</span><span class="bottompara"><strong>D</strong>
                                    = 50-59,</span><span class="bottompara"><strong>E</strong> = 40-49,</span><span class="bottompara"><strong>U</strong>
                                        =39 or less</span></p>--%>
                                        <p style="margin-top: 0.5px;">
                        <strong>General Performance</strong>
                        <span class="bottompara"><strong>A*</strong> = Outstanding,</span>
                        <span class="bottompara"><strong>A</strong> = Very Good,</span>
                        <span class="bottompara"><strong>B</strong> = Good</span>
                        <span class="bottompara"><strong>C</strong>= Acceptable,</span>
                        <span class="bottompara"><strong>D</strong> = Needs Improvement</span></p>
                </div>
                <br>
                <br />
                <div style="position: absolute; bottom: 20px; left: 0px;">
                <p id="P3" runat="server" style="padding-left: 25px;bottom: 0;"  visible='<%#(Eval("isPromoted").ToString()== "True")?true:false%>'>
                    Promoted To: <strong style="text-decoration: underline;">
                        <%#Eval("PromotedToClass")%></strong>

                </p>

                <p id="P4" runat="server" style="padding-left: 25px; bottom: 0;" visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Cond_Prom").ToString().Length < 1)?true:false%>'>
                    <strong style="text-decoration: underline;">
                        Not Promoted</strong>
                        
                </p>

                <p id="P5" runat="server" style="padding-left: 25px; bottom: 0;"  visible='<%#(Eval("isPromoted").ToString() == "False" && Eval("Cond_Prom").ToString().Length >= 1 )?true:false%>'>
                     <strong style="text-decoration: underline;">
                       Discretionarily Promoted </strong>                        
                </p>
                    <div id="Div1" style="margin-left: 70px; padding-top: 100px">

                        <p style="padding-left: 25px; padding-top: 20px; padding-bottom: 10px;">
                            This is a system generated report and does not require any signature or stamp.
                        </p>

                    </div>
 
                   <p id="P6" runat="server" style="padding-left: 25px;margin-left: 44px;padding-top: 20px; bottom: 0;">
                    <asp:Label ID="lblResultDate" runat="server"></asp:Label>
                  </p>
 
                </div>
                <!--//////////////////////////////////////-->
            </div>

        </ItemTemplate>
    </asp:Repeater>
    <asp:HiddenField ID="OuerHF" runat="server" />
    </form>
</body>
</html>
