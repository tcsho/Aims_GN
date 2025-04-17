<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCS_EYE_E_REPORT_CARD.aspx.cs" Inherits="PresentationLayer_TCS_EYE_E_REPORT_CARD" %>

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


    <style type="text/css">
        @media print {
            body {
                margin: 0;
                padding: 0;
            }

            .no-page-break {
                page-break-inside: avoid;
            }
        }
    </style>

</head>
<body>



    <form id="Form1" runat="server">

        <asp:Repeater ID="Reptr_Student" runat="server" OnItemDataBound="Reptr_Student_ItemDataBound">
            <ItemTemplate>
                <asp:HiddenField ID="Student_No" runat="server" Value='<%#Eval("Student_Id") %>' />
                <asp:HiddenField ID="Class_Id" runat="server" Value='<%#Eval("Class_Id") %>' />



                <div class="no-page-break" style="display: flex; flex-direction: column; align-items: center; justify-content: center;">
                    <div style="display: flex; justify-content: space-between; align-items: center; color: #BBBBBB; font-family: Calibri; width: 100%; max-width: 550px; border: 0; margin: 0 auto; padding: 0;">
                        <p style="margin: 0; text-align: left;">
                            <%# Eval("first_Name").ToString() %> <%# Eval("Student_No").ToString() %>
                        </p>
                        <p style="margin: 0; text-align: right;">
                            <%# Eval("Center_Name").ToString() %>
                        </p>
                    </div>
                    <div class="no-page-break" style="display: flex; flex-direction: column; align-items: center; justify-content: center; background-image: url('ereport_bg.png'); background-size: 100% 100%; background-repeat: no-repeat; background-position: center; padding: 20px; width: 100%; max-width: 700px; margin-top: 0px;">

                        <table style="margin-top: 33px; border: 0px solid blue; max-width: 550px; width: 100%; height: auto;">
                            <tr>
                                <td style="padding-right: 20px; border: 0px solid; width: 150px" colspan="1">
                                    <img src='<%# string.IsNullOrEmpty(Eval("Image_Path").ToString()) ? ResolveUrl("~/PresentationLayer/TCS/dummy.png") : ResolveUrl(Eval("Image_Path").ToString()) %>'
                                        alt="No Preview" style="width: 125px; height: 140px; border: 4px solid #000; margin-right: 20px;" />
                                </td>
                                <td style="padding-left: 0px; padding-right: 50px; border: 0px solid; max-width: 100%;">
                                    <p style="color: #589BAE; font-weight: bold; width: 340px; border: 0px solid; font-family: Calibri;text-align:center;">
                                        <%#Eval("Type").ToString().ToUpper() %> REPORT CARD <%#Eval("SessionCode").ToString().ToUpper() %>
                                    </p>
                                    <p style="color: #000000; font-weight: bold; text-align: center; font-family: Calibri;">
                                        <%#Eval("first_Name").ToString().ToUpper() %>
                                    </p>
                                    <p style="color: #000000; font-weight: bold; text-align: center; font-family: Calibri;">
                                        <%#Eval("Class_Name").ToString() %> - <%#Eval("Section_Name").ToString().ToUpper() %>
                                    </p>
                                </td>
                                <td style="border: 0px solid;">
                                    <img src="../../images/ereportlogo.png" width="80" style="height:auto" alt="">
                                </td>
                            </tr>
                            <!-- Additional table rows as per your layout -->
                            <tr style="height: 10px;">
                                <td colspan="3"></td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <p style="color: #000; border: 0px solid; font-family: Calibri;">
                                        <b>Date of Birth:</b> <u><%#Eval("Student_FormattedDate").ToString() %></u>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <p style="color: #000; border: 0px solid; font-family: Calibri;">
                                        <b>Attendance: </b><u><%#Eval("DaysAttend").ToString() %> ( out of  <%#Eval("FirstTermDays").ToString() %> days )</u>
                                    </p>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3" style="font-family: Calibri; padding-left: 15px; padding-right: 15px; border: 0px solid">
                                    <h4 style="text-align: left; font-family: Calibri; font-weight: bold;">Understanding your child’s report</h4>
                                </td>
                            </tr>
                            <tr>
                                <td style="border: 1px solid #000; padding-left: 15px; padding-right: 15px;" colspan="3">
                                    <p style="font-weight: bold; font-family: Calibri">Colour coded performance indicators (PI):</p>
                                    <p>
                                        <%--<span style="display: inline-block; width: 12px; height: 10px; background-color: green; margin-right: 2px;"></span>--%>
                                        <span style="display: inline-block; width: 12px; height: 12px; background-color: green; margin-right: 5px; border-radius: 2px;"></span>
                                        <span style="color: green; font-family: Calibri">Exceeding Development: Performing above the expected level, consistently and often independently. (<span style="font-weight: normal;">EXC</span>)</span>
                                    </p>
                                    <p>
                                        <span style="display: inline-block; width: 12px; height: 12px; background-color: purple; margin-right: 5px; border-radius: 2px;"></span>
                                        <span style="color: purple; font-family: Calibri">Expected Development: Performing at the expected level, meeting all learning objectives. (<span style="font-weight: normal;">EXP</span>)</span>
                                    </p>
                                    <p>
                                        <span style="display: inline-block; width: 12px; height: 12px; background-color: blue; margin-right: 5px; border-radius: 2px;"></span>
                                        <span style="color: blue; font-family: Calibri">Emerging Development: Performing below the expected level. (<span style="font-weight: normal;">EME</span>)</span>
                                    </p>
                                </td>
                            </tr>

                        </table>


                        <div class="no-page-break" id="divPage0" style="margin-top: 10px; width: 100%; max-width: 650px;">
                            <asp:Repeater ID="GenPer" runat="server" OnItemDataBound="Reptr_Subject_ItemDataBound">
                                <HeaderTemplate>
                                    <table style="width: 100%; border-collapse: collapse; border: 1px solid black;">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="Subject_Id" runat="server" Value='<%#Eval("Subject_Id") %>' />
                                    <tr id="tr1" runat="server" style="height: 40px;">
                                        <td id="subid" style="text-align: center; font-weight: bold; font-size: 13px; border: 1px solid black;">
                                            <%#Eval("Subject_Name")%>
                                        </td>
                                        <td id="PI" style="text-align: center; font-weight: bold; font-size: 13px; border: 1px solid black; width: 60px;">PI</td>
                                    </tr>
                                    <!-- Inner Repeater for KLOs and PI -->
                                    <tr>
                                        <td colspan="3">
                                            <asp:Repeater ID="GenPerKeys" runat="server" OnItemDataBound="Reptr_GP_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table style="width: 100%; border-collapse: collapse; border: 0px solid black;">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr id="pecrItem" runat="server" style="width: 100%; height: 25px;">
                                                        <td id="GKLO" style="text-align: left; border: 1px solid black; padding-left: 8px; padding-right: 8px;">
                                                            <%#Eval("KLO")%>
                                                        </td>
                                                        <td id="pind" style="text-align: center; font-weight: bold; font-size: 12px; border: 1px solid black; width: 59px;">
                                                            <%#Eval("PerformanceInd").ToString()%>
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
                    </div>

                    <div class="no-page-break" style="display: flex; flex-direction: column; align-items: center; justify-content: center; background-image: url('ereport_bg.png'); background-size: 100% 100%; background-repeat: no-repeat; background-position: center; padding: 20px; width: 100%; max-width: 700px; margin-top: 10px;">
                        <div style="display: flex; justify-content: space-between; align-items: center; color: #BBBBBB; font-family: Calibri; width: 100%; max-width: 550px; border: 0; margin: 0 auto; padding: 0; margin-top: -21px;">
                            <p style="margin: 0; text-align: left;">
                                <%# Eval("first_Name").ToString() %> <%# Eval("Student_No").ToString() %>
                            </p>
                            <p style="margin: 0; text-align: right;">
                                <%# Eval("Center_Name").ToString() %>
                            </p>
                        </div>
                        <div class="no-page-break" id="divPage1" style="width: 100%; max-width: 650px; margin-top: 33px;">
                            <asp:Repeater ID="GenPer1" runat="server" OnItemDataBound="Reptr_Subject1_ItemDataBound">
                                <HeaderTemplate>
                                    <table style="width: 100%; border: 0px solid black;">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="Subject_Id" runat="server" Value='<%#Eval("Subject_Id") %>' />
                                    <tr id="tr2" runat="server" style="height: 40px;">
                                        <td id="subid" style="text-align: center; font-weight: bold; font-size: 13px; border: 1px solid black;">
                                            <%#Eval("Subject_Name")%>
                                        </td>
                                        <td id="PI" style="text-align: center; font-weight: bold; font-size: 13px; border: 1px solid black; width: 60px;">PI</td>
                                    </tr>
                                    <!-- Inner Repeater for KLOs and PI -->
                                    <tr>
                                        <td colspan="3" style="border: 1px solid black;">
                                            <asp:Repeater ID="GenPerKeys1" runat="server" OnItemDataBound="Reptr_GP1_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table style="width: 100%; border-collapse: collapse; border: 1px solid black;">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr id="pecrItem" runat="server" style="width: 100%; height: 25px; border-top-width: 0;">
                                                        <td id="GKLO" style="text-align: left; border: 1px solid black; padding-left: 8px; padding-right: 8px;">
                                                            <%#Eval("KLO")%>
                                                        </td>
                                                        <td id="pind" style="text-align: center; font-weight: bold; font-size: 12px; border: 1px solid black; width: 60px;">
                                                            <%#Eval("PerformanceInd").ToString()%>
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
                    </div>


                    <div class="no-page-break" style="display: flex; flex-direction: column; align-items: center; justify-content: center; background-image: url('ereport_bg.png'); background-size: 100% 100%; background-repeat: no-repeat; background-position: center; padding: 20px; width: 100%; max-width: 700px; margin-top: 10px;">
                        <div style="display: flex; justify-content: space-between; align-items: center; color: #BBBBBB; font-family: Calibri; width: 100%; max-width: 550px; border: 0; margin: 0 auto; padding: 0; margin-top: -21px;">
                            <p style="margin: 0; text-align: left;">
                                <%# Eval("first_Name").ToString() %> <%# Eval("Student_No").ToString() %>
                            </p>
                            <p style="margin: 0; text-align: right;">
                                <%# Eval("Center_Name").ToString() %>
                            </p>
                        </div>
                        <div class="no-page-break" id="divPage2" style="width: 100%; max-width: 650px; margin-top: 33px;">
                            <asp:Repeater ID="GenPer2" runat="server" OnItemDataBound="Reptr_Subject2_ItemDataBound">
                                <HeaderTemplate>
                                    <table style="width: 100%; border: 0px solid black;">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="Subject_Id" runat="server" Value='<%#Eval("Subject_Id") %>' />
                                    <tr id="tr3" runat="server" style="height: 40px;">
                                        <td id="subid" style="text-align: center; font-weight: bold; font-size: 13px; border: 1px solid black;">
                                            <%#Eval("Subject_Name")%>
                                        </td>
                                        <td id="PI" style="text-align: center; font-weight: bold; font-size: 13px; border: 1px solid black; width: 60px;">PI</td>
                                    </tr>
                                    <!-- Inner Repeater for KLOs and PI -->
                                    <tr>
                                        <td colspan="3" style="border: 1px solid black;">
                                            <asp:Repeater ID="GenPerKeys2" runat="server" OnItemDataBound="Reptr_GP2_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table style="width: 100%; border-collapse: collapse; border: 1px solid black;">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr id="pecrItem" runat="server" style="width: 100%; height: 25px; border-top-width: 0;">
                                                        <td id="GKLO" style="text-align: left; border: 1px solid black; padding-left: 8px; padding-right: 8px;">
                                                            <%#Eval("KLO")%>
                                                        </td>
                                                        <td id="pind" style="text-align: center; font-weight: bold; font-size: 12px; border: 1px solid black; width: 60px;">
                                                            <%#Eval("PerformanceInd").ToString()%>
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
                    </div>



                    <div class="no-page-break" style="display: flex; flex-direction: column; align-items: center; justify-content: center; background-image: url('ereport_bg.png'); background-size: 100% 100%; background-repeat: no-repeat; background-position: center; padding: 20px; width: 100%; max-width: 700px; margin-top: 10px;">
                        <div style="display: flex; justify-content: space-between; align-items: center; color: #BBBBBB; font-family: Calibri; width: 100%; max-width: 550px; border: 0; margin: 0 auto; padding: 0; margin-top: -31px;">
                            <p style="margin: 0; text-align: left;">
                                <%# Eval("first_Name").ToString() %> <%# Eval("Student_No").ToString() %>
                            </p>
                            <p style="margin: 0; text-align: right;">
                                <%# Eval("Center_Name").ToString() %>
                            </p>
                        </div>
                        <div class="no-page-break" id="divPage3" style="width: 100%; max-width: 650px; margin-top: 33px; margin-bottom: 33px;">
                            <asp:Repeater ID="GenPer3" runat="server" OnItemDataBound="Reptr_Subject3_ItemDataBound">
                                <HeaderTemplate>
                                    <table style="width: 100%; border: 0px solid black;">
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:HiddenField ID="Subject_Id" runat="server" Value='<%#Eval("Subject_Id") %>' />
                                    <tr id="tr4" runat="server" style="height: 40px;">
                                        <td id="subid" style="text-align: center; font-weight: bold; font-size: 13px; border: 1px solid black;">
                                            <%#Eval("Subject_Name")%>
                                        </td>
                                        <td id="PI" style="text-align: center; font-weight: bold; font-size: 13px; border: 1px solid black; width: 60px;">PI</td>
                                    </tr>
                                    <!-- Inner Repeater for KLOs and PI -->
                                    <tr>
                                        <td colspan="3">
                                            <asp:Repeater ID="GenPerKeys3" runat="server" OnItemDataBound="Reptr_GP3_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table style="width: 100%; border-collapse: collapse; border: 1px solid black;">
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr id="pecrItem" runat="server" style="width: 100%; height: 25px; border-top-width: 0;">
                                                        <td id="GKLO" style="text-align: left; border: 1px solid black; padding-left: 8px; padding-right: 8px;">
                                                            <%#Eval("KLO")%>
                                                        </td>
                                                        <td id="pind" style="text-align: center; font-weight: bold; font-size: 12px; border: 1px solid black; width: 60px;">
                                                            <%#Eval("PerformanceInd").ToString()%>
                                                        </td>
                                                    </tr>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    <tr  style="width: 100%; height: 25px; border-top-width: 0;" visible="false">
                                                        <td id="footerMarks" runat="server" style="text-align: left; border: 1px solid black; padding-left: 8px; padding-right: 8px;" visible="false">
                                                            <b><%# Eval("Marks_Obtained") %></b>
                                                        </td>
                                                        <%-- <td style="text-align: center; font-weight: bold; font-size: 12px; border: 1px solid black; width: 60px;"></td>--%>
                                                    </tr>
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
                            <%--  <div id="class-teacher-comment" style="margin-left: 10px; width: 100%; max-width: 750px;">--%>
                            <div class="no-page-break" style="margin: 20px; font-family: calibri, sans-serif; color: #333;">
                                <h5 style="margin-bottom: 8px; font-weight: bold; font-size: 13px;">Teacher’s Comments:
                                </h5>
                                <p style="margin: 0; line-height: 1.3; text-align: justify; font-size: 13px;">
                                    <%# Eval("ClassTeacherComments") %>
                                </p>
                            </div>
                            <%-- </div>--%>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <div style="page-break-after: always; border-top: 1px solid teal; margin: 10px 0;"></div>
            </SeparatorTemplate>
        </asp:Repeater>
        <%--  </div>--%>
    </form>
</body>

</html>
