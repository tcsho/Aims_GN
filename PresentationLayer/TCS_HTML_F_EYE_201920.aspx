<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCS_HTML_F_EYE_201920.aspx.cs" Inherits="PresentationLayer_TCS_TCS_HTML_F_EYE_201920" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
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
            padding-left: 20px;
        }

        .KLO {
            text-align: left;
            width: 36.6%;
            padding-left: 5px;
            padding-right: 3px;
            border-width: 0;
            text-align: left;
            font-size: 13px;
            overflow-wrap: anywhere;
            /*            word-wrap: break-word;
*/ /*            word-break: break-all;
   
*/
        }

        .Key1 {
            text-align: center;
            width: 9%;
            border-top-width: 0;
            border-right-width: 0;
            border-bottom-width: 0;
        }

        .Key2 {
        }

        .Key3 {
        }

        .Subject {
            text-align: left;
            padding-left: 10px;
            width: 10%
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
    <style id="Style1" type="text/css" media="print" runat="server">
        div.page {
            page-break-after: always;
        }
    </style>
</head>
<body style="">
    <form id="Form1" runat="server">
        <asp:Repeater ID="Reptr_Student" runat="server" OnItemDataBound="Reptr_Student_ItemDataBound">
            <ItemTemplate>
                <asp:HiddenField ID='Student_No' runat="server" Value='<%#Eval("Student_Id") %>' />
                <asp:HiddenField ID='Class_Id' runat="server" Value='<%#Eval("Class_Id") %>' />
                <!--This div is for outer blue boundary. height should be changed manualy according to requirement-->
                <div id="blue_border" style="background-color: white; width: 900px; padding: 10px; border: 4px solid #fff; display: inline-block;">
                    <!--//////////////////////////////////////-->
                    <!-- This div is for main logo and header tilte-->
                    <div id="main_header" style="width: 100%;">
                        <div id="city-school-logo" align="right" style="float: right;" width='100' height="75">
                            <img src="../../images/city_school_logo.png" width="90" height="100">
                        </div>
                        <div id="city_school_title_info" style="float: center">
                            <div id="city-school-name" style="padding-left: 0px;">
                                <center>
                                    <img src="../../images/city_06.png" width="253" height="53"></center>
                            </div>
                            <div id="city-school-header-text" style="font-family: Arial; line-height: 0.5; padding-left: 0px;">
                                <h3 style="font-weight: lighter;">
                                    <br>
                                    <center>
                                        Academic Session <%#Eval("SessionCode") %></center>
                                </h3>
                                <p style="font-weight: lighter; margin-top: 10px; padding-left: 125px;">
                                    <center>
                                        <%#Eval("Center_Name") %></center>
                                </p>
                                <p style="font-weight: lighter; margin-top: 10px; padding-left: 125px;">
                                    <center>
                                        Report Card for
                                    <%#Eval("Class_Name") %>
                                    (<%#Eval("Type") %>)
                                    </center>
                                </p>
                                <%--         <p style="font-weight: lighter; margin-top: 10px; text-align:center;">
                                    <%#Eval("Type") %>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            </p>
                                --%>
                            </div>
                        </div>
                    </div>
                    <!--//////////////////////////////////////-->
                    <!-- Main body -->
                    <div id="student-credentials" style="width: 100%;">
                        <div id="Div1" style="width: 100%;">
                            <div id="student-credentials-column-left" style="width: 40%; float: left; padding-left: 20px;">
                                <div id="column1-left" style="float: left; width: 100%;">
                                    <p>
                                        Name:&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("first_Name") %>
                                    </p>
                                    <p>
                                        Class Average Age:&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("AverageAge") %>
                                    </p>
                                    <p>
                                        <%-- <p>
                                    Total No.of Students:</p>--%>
                                        <p>
                                            Total working days:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<%#Eval("FirstTermDaysCH")%>
                                        </p>
                                </div>
                            </div>
                            <div id="student-credentials-column-right" style="width: 50%; float: right; padding-right: 10px;">
                                <div id="column1-right" style="float: right; text-align: left; padding-right: 90px;">
                                    <%--   <p>
                                    <%#Eval("Student_No") %></p>--%>
                                    <p>
                                        <%#Eval("Section_Name") %>
                                    </p>
                                    <p>
                                        <%#Eval("Agev") %>
                                    </p>
                                    <p style="text-align: Left;">
                                        <%#Eval("DaysAttend") %>
                                    </p>
                                </div>
                                <div id="column2-right" style="float: left; padding-left: 65px;">
                                    <%--              <p>
                                    ERP No:</p>--%>
                                    <p>
                                        Section:
                                    </p>
                                    Student's Age:</p>
                                <p>
                                    Days attended:
                                </p>
                                </div>
                            </div>
                           <%--<div>
                                <p id="msg" runat="server" visible='<%#(Convert.ToInt32(Eval("verify")) == 2)?true:false%>' style="color: red; font-size: xx-large;">
                                    Error : Please input the correct data, your duplicate records must be identical.
                                </p>

                            </div>--%>
                        </div>
                    </div>
                    <div id="cityschoolKyes" runat="server" style="padding-top: 90px; padding-left: 10px; padding-bottom: 5px; color: White">
                        <p>
                            <strong></strong><span style="margin-left: 42px;"></span>
                        </p>
                    </div>
                    <div>
                        <asp:Repeater ID="GenPer" runat="server" OnItemDataBound="Reptr_Subject_ItemDataBound">
                            <HeaderTemplate>
                                <table style="width: 100%; height: auto; margin-left: 10px; border: none">
                                    <tr>
                                        <td width="13%" style="text-align: left; padding-left: 10px;">
                                            <strong>Area of Learning</strong>
                                        </td>
                                        <td width="39.9%">
                                            <center>
                                                <strong>Key Learning Objectives</strong></center>
                                        </td>
                                        <td width="4.9%">
                                            <center>
                                                <strong>Exceeding Development</strong></center>
                                        </td>
                                        <td width="5.1%">
                                            <center>
                                                <strong>Expected Development</strong></center>
                                        </td>
                                        <td width="5.1%">
                                            <center>
                                                <strong>Emerging Development</strong></center>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID='Subject_Id' runat="server" Value='<%#Eval("Subject_Id") %>' />
                                <tr id="pagebreak" runat="server" style="width: 100%">
                                    <td class="Subject">
                                        <%#Eval("Subject_Name")%>
                                    </td>
                                    <td colspan="5" style="border-bottom-width: 0; width: 67%">
                                        <asp:Repeater ID="GenPerKeys" runat="server" OnItemDataBound="Reptr_GP_ItemDataBound">
                                            <HeaderTemplate>
                                                <table style="width: 100%; height: auto; border-width: 0">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr id="pecrItem" runat="server" style="width: 100%; height: 28px; border-top-width: 0; border-left-width: 0; border-right-width: 0;">
                                                    <td id="GKLO" runat="server" class="KLO">
                                                        <%#Eval("KLO")%>
                                                    </td>
                                                    <td class="Key1">
                                                        <%#Eval("Key3").ToString()=="True" ?"&#10004;":""%>
                                                    </td>
                                                    <td class="Key1">
                                                        <%#Eval("Key2").ToString()=="True" ?"&#10004;":""%>
                                                    </td>
                                                    <td class="Key1">
                                                        <%#Eval("Key1").ToString()=="True" ?"&#10004;":""%>
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
                    </div>
                    <div id="divPage2" runat="server">
                        <asp:Repeater ID="GenPer1" runat="server" OnItemDataBound="Reptr_Subject1_ItemDataBound">
                            <HeaderTemplate>
                                <table style="width: 100%; height: auto; margin-left: 10px; border: none;">
                                    <tr>
                                        <td width="13%" style="text-align: left; padding-left: 10px;">
                                            <strong>Area of Learning</strong>
                                        </td>
                                        <td width="39.9%">
                                            <center>
                                                <strong>Key Learning Objectives</strong></center>
                                        </td>
                                        <td width="4.9%">
                                            <center>
                                                <strong>Exceeding Development</strong></center>
                                        </td>
                                        <td width="5.1%">
                                            <center>
                                                <strong>Expected Development</strong></center>
                                        </td>
                                        <td width="5.1%">
                                            <center>
                                                <strong>Emerging Development</strong></center>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID='Subject_Id' runat="server" Value='<%#Eval("Subject_Id") %>' />
                                <tr id="pagebreak" runat="server">
                                    <td style="text-align: left; padding-left: 10px; width: 20px;">
                                        <%#Eval("Subject_Name")%>
                                    </td>
                                    <td colspan="5" style="border-bottom-width: 0">
                                        <asp:Repeater ID="GenPerKeys1" runat="server" OnItemDataBound="Reptr_GP1_ItemDataBound">
                                            <HeaderTemplate>
                                                <table style="width: 100%; height: auto; border-width: 0">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr id="pecrItem" runat="server" style="width: 100%; height: 28px; border-top-width: 0; border-left-width: 0; border-right-width: 0;">
                                                    <td id="GKLO" runat="server" class="KLO">
                                                        <%#Eval("KLO")%>
                                                    </td>
                                                    <td class="Key1">
                                                        <%#Eval("Key3").ToString()=="True" ?"&#10004;":""%>
                                                    </td>
                                                    <td class="Key1">
                                                        <%#Eval("Key2").ToString()=="True" ?"&#10004;":""%>
                                                    </td>
                                                    <td class="Key1">
                                                        <%#Eval("Key1").ToString()=="True" ?"&#10004;":""%>
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
                    </div>
                    <div id="divPage3" runat="server">
                        <asp:Repeater ID="GenPer2" runat="server" OnItemDataBound="Reptr_Subject2_ItemDataBound">
                            <HeaderTemplate>
                                <table style="width: 100%; height: auto; margin-left: 10px; border: none;">
                                    <tr>
                                        <td width="13%" style="text-align: left; padding-left: 10px;">
                                            <strong>Area of Learning</strong>
                                        </td>
                                        <td width="39.9%">
                                            <center>
                                                <strong>Key Learning Objectives</strong></center>
                                        </td>
                                        <td width="4.9%">
                                            <center>
                                                <strong>Exceeding Development</strong></center>
                                        </td>
                                        <td width="5.1%">
                                            <center>
                                                <strong>Expected Development</strong></center>
                                        </td>
                                        <td width="5.1%">
                                            <center>
                                                <strong>Emerging Development</strong></center>
                                        </td>
                                    </tr>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:HiddenField ID='Subject_Id' runat="server" Value='<%#Eval("Subject_Id") %>' />
                                <tr id="pagebreak" runat="server">
                                    <td style="text-align: left; padding-left: 10px; width: 20px;">
                                        <%#Eval("Subject_Name")%>
                                    </td>
                                    <td colspan="5" style="border-bottom-width: 0">
                                        <asp:Repeater ID="GenPerKeys2" runat="server" OnItemDataBound="Reptr_GP2_ItemDataBound">
                                            <HeaderTemplate>
                                                <table style="width: 100%; height: auto; border-width: 0">
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <tr id="pecrItem" runat="server" style="width: 100%; height: 28px; border-top-width: 0; border-left-width: 0; border-right-width: 0;">
                                                    <td id="GKLO" runat="server" class="KLO">
                                                        <%#Eval("KLO")%>
                                                    </td>
                                                    <td class="Key1">
                                                        <%#Eval("Key3").ToString()=="True" ?"&#10004;":""%>
                                                    </td>
                                                    <td class="Key1">
                                                        <%#Eval("Key2").ToString()=="True" ?"&#10004;":""%>
                                                    </td>
                                                    <td class="Key1">
                                                        <%#Eval("Key1").ToString()=="True" ?"&#10004;":""%>
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
                    </div>
                    <br />
                    <div id="classteachercomment" runat="server" style="margin-left: 10px;">
                        <p style="padding-left: 10px; margin-top: 0.5px;">
                            <h5>
                                <strong>Class Teacher's Comments:</strong></h5>
                            <span style="text-decoration: underline; line-height: 150%; text-align: justify">
                                <%#Eval("ClassTeacherComments") %></span>
                        </p>
                    </div>
                    <p style="padding-top: 90px; bottom: 0;">
                        <strong>Teacher's Signature: _____________________</strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>Headmistress'
                        Signature: ______________________ </strong>
                    </p>
                    <p id="P1" runat="server" style="padding-top: 15px; bottom: 0;">
                        <strong><asp:Label ID="lblResultDate" runat="server" Text='<%#Eval("ResultDate") %>'></asp:Label></strong>
                         
                        <%--<strong>Date: 23<sup>rd</sup> December 2022.</strong>--%>
                    </p>

                    <div id="Div2" runat="server" style="padding-top: 10px; padding-left: 10px; padding-bottom: 0px;" visible='<%#(Convert.ToInt32(Eval("Session_Id").ToString()) > 10 && Convert.ToInt32(Eval("Session_Id").ToString()) <= 12 )?true:false%>'>
                        <p>
                            <strong>PERFORMANCE INDICATORS</strong>
                        </p>
                        <p>
                            <strong>Exceeding Development: </strong><span style="margin-left: 10px;">Working above the expected level.</span>
                        </p>
                        <p>
                            <strong>Expected Development: </strong><span style="margin-left: 19px;">Working at the expected level.</span>
                        </p>
                        <p>
                            <strong>Emerging Development:</strong><span style="margin-left: 17px;"> Working below the expected level.</span>
                        </p>
                    </div>
                    <div id="Div3" runat="server" style="padding-top: 10px; padding-left: 10px; padding-bottom: 0px;" visible='<%#(Convert.ToInt32(Eval("Session_Id").ToString()) >= 13)?true:false%>'>
                        <p>
                            <strong>PERFORMANCE INDICATORS</strong>
                        </p>
                        <p>
                            <strong>Exceeding Development: </strong><span style="margin-left: 10px;">Working above the expected level consistently and often independently.</span>
                        </p>
                        <p>
                            <strong>Expected Development: </strong><span style="margin-left: 19px;">Working at the expected level, meeting all learning objectives.</span>
                        </p>
                        <p>
                            <strong>Emerging Development:</strong><span style="margin-left: 17px;"> Working below the expected level.</span>
                        </p>
                    </div>

                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <div class="page">
                </div>
            </SeparatorTemplate>
        </asp:Repeater>
    </form>
</body>
</html>
