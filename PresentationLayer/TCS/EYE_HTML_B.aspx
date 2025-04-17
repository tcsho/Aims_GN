<%@ Page Language="C#" AutoEventWireup="true" CodeFile="EYE_HTML_B.aspx.cs" Inherits="PresentationLayer_TCS_EYE_HTML_B" %>

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
        .testClass
        {
            border-bottom-width: 0px;
        }
    </style>
    <style type="text/css" media="print">
        div.page
        {
            page-break-after: always;
        }

    </style>
</head>
<body style="">
    <form id="Form1" runat="server">
     <asp:Repeater ID="Reptr_Student" runat="server" OnItemDataBound="Reptr_Student_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID='Student_No' runat="server" Value='<%#Eval("Student_Id") %>' />
            <!--This div is for outer blue boundary. height should be changed manualy according to requirement-->
            <div id="blue_border" style="background-color: white; width: 900px; height: 1340;
                padding: 10px; border: 4px solid #fff; display: inline-block; page-break-after: always;
                page-break-inside: avoid;">
                <!--//////////////////////////////////////-->
                <!-- This div is for main logo and header tilte-->
                <div id="main_header" style="width: 100%;">
                    <div id="city-school-logo" align="right" style="float: right;" width='100' height="75">
                        <img src="../../images/city_school_logo.png" width="90" height="100">
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
                            <p style="font-weight: lighter; margin-top: 10px; padding-left: 125px;">
                                <center>
                                    <%#Eval("Center_Name") %></center>
                            </p>
                            <p style="font-weight: lighter; margin-top: 10px; padding-left: 125px;">
                                <center>
                                    Progress Report for
                                    <%#Eval("Class_Name") %></center>
                            </p>
                        </div>
                        <br>
                    </div>
                </div>
                <!--//////////////////////////////////////-->
                <!-- Main body -->
                <div id="student-credentials" style="width: 100%;">
                    <div id="Div1" style="width: 100%;">
                        <div id="student-credentials-column-left" style="width: 40%; float: left; padding-left: 20px;">
                            <div id="column1-left" style="float: left; width: 42%;">
                                <p>
                                    Name:</p>
                                <p>
                                    Section:</p>
                                <p>
                                    Total No.of Students:</p>
                                <p>
                                    Term:</p>
                            </div>
                            <div id="column2-left" style="float: right; width: 56%; padding-left: 5px;">
                                <p>
                                    <%#Eval("first_Name") %></p>
                                <p>
                                    <%#Eval("Section_Name") %></p>
                                <p>
                                    <%#Eval("Strength") %></p>
                                <p>
                                    <%#Eval("Type") %></p>
                            </div>
                        </div>
                        <div id="student-credentials-column-right" style="width: 50%; float: right; padding-right: 10px;">
                            <div id="column1-right" style="float: right; text-align: left">
                                <p>
                                    <%#Eval("Student_No") %></p>
                                <p>
                                    <%#Eval("Date_of_Birth") %></p>
                                <p>
                                    <%#Eval("AverageAge") %></p>
                                <p style="text-align: Left;">
                                    <%#Eval("DaysAttend") %>/<%#Eval("FirstTermDaysCH") %></p>
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
                <div id="city-school-Kyes" style="padding-top: 90px; padding-left: 10px; padding-bottom: 10px">
                    <p>
                        <strong>Key for the performance Indicators: </strong>
                    </p>
                    <p>
                        <strong>Emerging Development: Attainment is at the progression level, but has not yet
                            reached the expected level. </strong>
                    </p>
                    <p>
                        <strong>Expected Development: Attainment is at the expected level. </strong>
                    </p>
                    <p>
                        <strong>Exceeding Development: Attainment is beyond the expected level. </strong>
                    </p>
                </div>
                <asp:Repeater ID="GenPer" runat="server" OnItemDataBound="Reptr_Subject_ItemDataBound">
                    <HeaderTemplate>
                        <table style="width: 97%; height: auto; margin-left: 10px; border: none">
                            <tr>
                                <td width="18%" style="text-align: left; padding-left: 10px;">
                                    <strong>Areas of Learning</strong>
                                </td>
                                <td width="42%">
                                    <center>
                                        <strong>Key Learning Objectives</strong></center>
                                </td>
                                <td width="4%">
                                    <center>
                                        <strong>Emerging Development</strong></center>
                                </td>
                                <td width="4%">
                                    <center>
                                        <strong>Expected Development</strong></center>
                                </td>
                                <td width="4%">
                                    <center>
                                        <strong>Exceeding Development</strong></center>
                                </td>
                            </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID='Subject_Id' runat="server" Value='<%#Eval("Subject_Id") %>' />
                        <tr id="pagebreak" runat="server" >
                            <td style="text-align: left; padding-left: 10px;">
                   
                                <%#Eval("Subject_Name")%>
                            </td>
                            <td colspan="4" style="border-bottom-width: 0">
                                <asp:Repeater ID="GenPerKeys" runat="server" OnItemDataBound="Reptr_GenPerKey_ItemDataBound">
                                    <HeaderTemplate>
                                        <table style="width: 100%; height: auto; border-width: 0">
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <tr  id="pecrItem" runat="server" style="width: 100%; height: 30px; border-top-width: 0; border-left-width: 0;
                                            border-right-width: 0;">
                                            <td  style="text-align: left; width: 394px; padding-left: 5px; border-width: 0">
                                                <%#Eval("KLO")%>
                                            </td>
                                            <td style="text-align: center; width: 95px; border-top-width: 0; border-right-width: 0;border-bottom-width:0;">
                                                <%#Eval("Key1").ToString()=="True" ?"&#10004;":""%>
                                            </td>
                                            <td style="text-align: center; width: 95px; border-top-width: 0; border-right-width: 0;border-bottom-width:0;">
                                                <%#Eval("Key2").ToString()=="True" ?"&#10004;":""%>
                                            </td>
                                            <td  style="text-align: center; width: 95px; border-top-width: 0; border-right-width: 0;border-bottom-width:0;">
                                                <%#Eval("Key3").ToString()=="True" ?"&#10004;":""%>
                                            </td>
                                        </tr>
                                    </ItemTemplate>
                                    <FooterTemplate>
                                        </table>
                                    </FooterTemplate>
                                </asp:Repeater>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>

                <br>
                <br /> 
                <div id="class-teacher-comment" style="margin-left: 10px">
                    <p style="padding-left: 10px; margin-top: 0.5px;">
                        <h5>
                            <strong>Class Teacher's Comments:</strong></h5>
                        <span style="text-decoration: underline; line-height: 150%; text-align: justify">
                            <%#Eval("ClassTeacherComments") %></span></p>
                </div>
                <p>
                </p>
                <p style="padding-top: 130px; bottom: 0;">
                    *This is a system generated report and does not require any signature and stamp.</p>
                <!--//////////////////////////////////////-->
            </div>
            <div class="page"></div>
        </ItemTemplate>
    </asp:Repeater>

    
    </form>
</body>
</html>
