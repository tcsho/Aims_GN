<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="NBConsolidation.aspx.cs" Inherits="PresentationLayer_LoConsolidation"
    Theme="BlueTheme" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--Bootstrap tabs--%>
            <asp:ScriptReference Path="https://maxcdn.bootstrapcdn.com/bootstrap/3.4.1/js/bootstrap.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>

    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <style>
                .calGradeTable td {
                    border: 1px solid #000;
                    font-size: 16px !important;
                    text-align: center;
                    border-top: 1px solid #000 !important;
                }

                .calGradeTableValue {
                    font-size: 14px !important;
                }

                .gvNB_C_TeacherList-wrapper {
                    /*width: 600px;*/
                    height: 400px;
                    overflow: scroll;
                    border: 1px solid #777777;
                }

                    .gvNB_C_TeacherList-wrapper th {
                        position: sticky;
                        top: 0;
                        background-color: white;
                        font-size: 14px;
                    }

                .gvnbconsolidation-wrapper {
                    /*width: 600px;*/
                    height: 400px;
                    overflow: scroll;
                    border: 1px solid #777777;
                }

                .gvloconsolidation-wrapper table {
                    border-spacing: 0;
                }

                .gvnbconsolidation-wrapper th {
                    /*border-left: none;*/
                    /*border-right: 1px solid #000;*/
                    /*padding: 5px;*/
                    /*width: 80px;*/
                    /*min-width: 80px;*/
                    position: sticky;
                    top: 0;
                    /*background: #0c4da2;*/
                    /*color: #e0e0e0;*/
                    /*font-weight: normal;*/
                }

                    .gvnbconsolidation-wrapper th:nth-child(1),
                    .gvnbconsolidation-wrapper td:nth-child(1) {
                        position: sticky;
                        left: 0;
                        width: 90px;
                        min-width: 90px;
                    }

                    .gvnbconsolidation-wrapper th:nth-child(2),
                    .gvnbconsolidation-wrapper td:nth-child(2) {
                        position: sticky;
                        /* 1st cell left/right padding + 1st cell width + 1st cell left/right border width */
                        /* 0 + 5 + 150 + 5 + 1 */
                        left: 90px;
                        width: 90px;
                        min-width: 90px;
                    }

                    .gvnbconsolidation-wrapper th:nth-child(3),
                    .gvnbconsolidation-wrapper td:nth-child(3) {
                        position: sticky;
                        /* 1st cell left/right padding + 1st cell width + 1st cell left/right border width */
                        /* 0 + 5 + 150 + 5 + 1 */
                        left: 180px;
                        width: 180px;
                        min-width: 180px;
                    }

                    .gvnbconsolidation-wrapper th:nth-child(4),
                    .gvnbconsolidation-wrapper td:nth-child(4) {
                        position: sticky;
                        /* 1st cell left/right padding + 1st cell width + 1st cell left/right border width */
                        /* 0 + 5 + 150 + 5 + 1 */
                        left: 360px;
                        width: 90px;
                        min-width: 90px;
                    }

                    .gvnbconsolidation-wrapper th:nth-child(5),
                    .gvnbconsolidation-wrapper td:nth-child(5) {
                        position: sticky;
                        /* 1st cell left/right padding + 1st cell width + 1st cell left/right border width */
                        /* 0 + 5 + 150 + 5 + 1 */
                        left: 450px;
                        width: 130px;
                        min-width: 130px;
                    }

                .gvnbconsolidation-wrapper td:nth-child(1),
                .gvnbconsolidation-wrapper td:nth-child(2),
                .gvnbconsolidation-wrapper td:nth-child(3),
                .gvnbconsolidation-wrapper td:nth-child(4),
                .gvnbconsolidation-wrapper td:nth-child(5) {
                    background: #fff;
                }

                .gvnbconsolidation-wrapper th:nth-child(1),
                .gvnbconsolidation-wrapper th:nth-child(2),
                .gvnbconsolidation-wrapper th:nth-child(3),
                .gvnbconsolidation-wrapper th:nth-child(4),
                .gvnbconsolidation-wrapper th:nth-child(5) {
                    z-index: 2;
                }
            </style>
            <script>
                function initializeScrolling() {
                    //$(".table-wrapper").on("scroll", function () {
                    //    var translate = "translate(0," + this.scrollTop + "px)";
                    //    $(this).find("thead").css("transform", translate);
                    //});
                }

                $(document).ready(function () {
                    initializeScrolling();

                    // Handle partial postbacks
                    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
                        initializeScrolling();
                    });
                });
            </script>
            <asp:HiddenField ID="hfActiveTab" runat="server" />
            <asp:HiddenField ID="PositionScrollBar" runat="server" />
            <h2>Notebook Scrutiny Data</h2>
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>

                                        <td id="tdFrmHeading" class="formheading">
                                            <%--<asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="LO Consolidation"></asp:Label>--%>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 13px" class="leftlink" align="right" colspan="3"></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <table class="main_table col-lg-12" cellspacing="0" cellpadding="0" <%--main_table col-lg-8 col-md-8 col-xs-8 col-sm-8--%>
                                                border="0">
                                                <tr class="row">

                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Region :</label>
                                                            <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                                OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>

                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">School :</label>
                                                            <asp:DropDownList ID="ddl_center" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control"
                                                                OnSelectedIndexChanged="ddl_center_SelectedIndexChanged" Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>

                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Teacher :</label>
                                                            <asp:DropDownList ID="ddlteacher" runat="server" CssClass="dropdownlist form-control"
                                                                Width="100%" AutoPostBack="True" OnSelectedIndexChanged="ddlteacher_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>

                                                    <td class="col-lg-3">

                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Key Stage :</label>
                                                            <asp:DropDownList OnSelectedIndexChanged="ddlkeystage_SelectedIndexChanged"
                                                                ID="ddlkeystage" CssClass="dropdownlist form-control" runat="server" AutoPostBack="true">
                                                                <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                                <asp:ListItem Text="EYFS" Value="EYFS"></asp:ListItem>
                                                                <asp:ListItem Text="KS1" Value="KS1"></asp:ListItem>
                                                                <asp:ListItem Text="KS2" Value="KS2"></asp:ListItem>
                                                                <asp:ListItem Text="KS3" Value="KS3"></asp:ListItem>
                                                                <asp:ListItem Text="KS4" Value="KS4"></asp:ListItem>
                                                                <asp:ListItem Text="KS5" Value="KS5"></asp:ListItem>
                                                                <asp:ListItem Text="Matric" Value="Matric"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>

                                                    </td>
                                                </tr>
                                                <tr class="row">
                                                    <td class="col-lg-3">
                                                        <%--  <div class="form-group">
                                                            <label class="TextLabelLeft">Subject :</label>
                                                            <asp:DropDownList ID="ddlsubjects" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlsubjects_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </div>--%>

                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Class :</label>
                                                            <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>

                                                    <td class="col-lg-3">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Term Group :</label>
                                                            <asp:DropDownList ID="ddl_grouphead" runat="server" CssClass="dropdownlist form-control"
                                                                Width="100%" AutoPostBack="true" OnSelectedIndexChanged="ddl_grouphead_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td class="col-lg-3">

                                                        <%--   <div class="form-group">
                                                            <label class="TextLabelLeft">Class :</label>
                                                            <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </div>--%>
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Subject :</label>
                                                            <asp:DropDownList ID="ddlsubjects" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlsubjects_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </td>
                                                    <td class="col-lg-3"></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>

            <div class="vh-100">
                <%-- <h2>LO Consolidation</h2>--%>
                <ul class="nav nav-tabs">
                    <%--<li class="active"><a data-toggle="tab" href="#home">Home</a></li>--%>
                    <li class="active"><a data-toggle="tab" onclick="saveActiveTab1()" href="#home">Home</a></li>
                    <li><a data-toggle="tab" onclick="saveActiveTab2()" href="#menu1">View Report Data</a></li>
                    <li><a data-toggle="tab" onclick="saveActiveTab3()" href="#menu2">SIQA Endorsed Grades</a></li>

                </ul>

                <div class="tab-content">
                    <div id="home" class="tab-pane fade in active">
                        <h3>HOME</h3>
                        <%--<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.</p>--%>

                        <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                            border="0">
                            <tbody>
                                <tr>
                                    <td style="height: 6px" colspan="3">
                                        <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                            border="0">
                                            <tbody>
                                                <tr>

                                                    <td id="tdFrmHeading" class="formheading">
                                                        <%--<asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="LO Consolidation"></asp:Label>--%>
                                                        <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                            border="0" />
                                                    </td>
                                                </tr>


                                            </tbody>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 13px" class="leftlink" align="right" colspan="3"></td>
                                </tr>

                                <tr align="center">
                                    <td style="height: 22px" class="titlesection" colspan="3">
                                        <asp:Label ID="msg" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Please fill data in proided fields.</asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Date :</label>
                                                        <asp:TextBox ID="txtIssuanceDate" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                                                    </div>
                                                </td>

                                                <td class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Section :</label>
                                                        <asp:DropDownList ID="ddlsections" runat="server" CssClass="dropdownlist form-control"
                                                            Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>

                                            </tr>

                                        </table>
                                    </td>
                                </tr>

                                <tr align="center">
                                    <td style="height: 22px" class="titlesection" colspan="3">
                                        <asp:Label ID="Label2" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Quality of Tasks</asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Challenging Tasks :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_QOT_challenging_tasks" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Variety of tasks :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_QOT_Variety_of_tasks" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Regular independent study :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_QOT_regular_independent_study" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Regularly assigned :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_QOT_regularly_assigned" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="row">
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Grade :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_QOT_grade" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_QOT_grade_SelectedIndexChanged" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td></td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr align="center">
                                    <td style="height: 22px" class="titlesection" colspan="3">
                                        <asp:Label ID="Label3" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Assessment</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Work checked promptly :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_Assessment_work_checked_promptly" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Errors identified :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_Assessment_errors_identified" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Dev. comments :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_Assessment_dev_comments" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Assessment criteria :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_Assessment_assessment_criteria" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="row">
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Apprec. Remarks :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_Assessment_apprec_remarks" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Self/Peer assessment :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_Assessment_self_peer_assessment" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Follow up :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_Assessment_follow_up" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Grade :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_Assessment_grade" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_Assessment_grade_SelectedIndexChanged" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="height: 22px" class="titlesection" colspan="3">
                                        <asp:Label ID="Label4" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Students Progress</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Impr. in work :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_SP_impr_in_work" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Responded to feedback :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_SP_responded_to_feedback" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Suff. gains :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_SP_suff_gains" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Age-appropriate vocab :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_SP_age_appropriate_vocab" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="row">
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Independence :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_SP_independence" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Grade :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_SP_grade" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_SP_grade_SelectedIndexChanged" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td></td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr align="center">
                                    <td style="height: 22px" class="titlesection" colspan="3">
                                        <asp:Label ID="Label5" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Work Presentation</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Organised :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_WP_organised" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Neat :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_WP_neat" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Legible handwriting :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_WP_legible_handwriting" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Indices filled :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_WP_indices_filled" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                            </tr>
                                            <tr class="row">
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Indices signed: Teachers</label>
                                                        <asp:DropDownList
                                                            ID="ddl_WP_indices_signed_teachers" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Indices signed: Parents</label>
                                                        <asp:DropDownList
                                                            ID="ddl_WP_indices_signed_parents" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Grade :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_WP_grade" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddl_WP_grade_SelectedIndexChanged" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>

                                <tr align="center">
                                    <td style="height: 22px" class="titlesection" colspan="3">
                                        <asp:Label ID="Label7" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Overall Grade </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td>
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Overall Grade :</label>
                                                        <asp:DropDownList
                                                            ID="ddl_overall_grade" Enabled="false" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <%--      <td class="col-lg-1" style="display:none;">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">EBI1 :</label>
                                                        <asp:TextBox ID="txtEBI1" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td class="col-lg-1" style="display:none;">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">EBI2 :</label>
                                                        <asp:TextBox ID="txtEBI2" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td class="col-lg-1" style="display:none;">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">EBI3 :</label>
                                                        <asp:TextBox ID="txtEBI3" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>--%>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Button ID="btn_save" runat="server" CssClass="btn btn-primary savebtn" OnClick="btnSave_Click" Text="Save" CausesValidation="false" />&nbsp;&nbsp;
                            <asp:Button ID="btncancel" runat="server" CssClass="btn btn-primary savebtn" OnClick="btncancel_Click" Text="Cancel" ValidationGroup="valSave" />
                                        <%--<asp:Button ID="Button1" runat="server" OnClick="btnSave_Click" Text="Button" />--%>
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <div id="savearea" runat="server">
                        </div>
                        <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender2"
                            runat="server"
                            TargetControlID="savearea"
                            VerticalSide="Top"
                            HorizontalSide="Right">
                        </cc1:AlwaysVisibleControlExtender>

                    </div>
                    <div id="menu1" class="tab-pane fade">
                        <h3>NB Consolidation Report</h3>

                        <div class="container horizontal-scrollable ">
                            <%--  <section>--%>
                            <table class="table">
                                <tr>
                                    <th class="text-center" colspan="10">Information</th>
                                </tr>
                                <tr>
                                    <td style="background-color: #e3f2f7;">&nbsp;</td>
                                    <td>Quality of Tasks</td>
                                    <td style="background-color: lightgray;">&nbsp;</td>
                                    <td>Assessment</td>
                                    <td style="background-color: #c4f2c4;">&nbsp;</td>
                                    <td>Students Progress</td>
                                    <td style="background-color: #f7d2c3;">&nbsp;</td>
                                    <td>Work Presentation</td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                    <td></td>
                                </tr>
                                <tr>
                                    <div id="SiqaEndDiv" runat="server">
                                        <td colspan="8"></td>
                                        <td style="font-weight: bold; text-align: right; padding-top: 15px;">SIQA Endorsed:</td>
                                        <td colspan="3">
                                            <asp:DropDownList ID="ddlSiqaEndorsed" runat="server"
                                                AutoPostBack="false" CssClass="dropdownlist">
                                                <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                                <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button runat="server" ID="btnUpdateSIQAEndorsed"
                                                Text="Apply" CssClass="btn btn-sm btn-warning"
                                                OnClick="btnUpdateSIQAEndorsed_Click" />

                                            <asp:Button runat="server" ID="btnUpdateAllNbConsolidationData"
                                                Text="Update All" CssClass="btn btn-sm btn-warning"
                                                OnClick="btnUpdateAllNbConsolidationData_Click" />
                                        </td>
                                    </div>
                                </tr>
                            </table>
                            <div style="display: flex; justify-content: flex-end; align-items: flex-end; height: 100%;">
                                <asp:Button runat="server" ID="btnNbconsolidationexport"
                                    Text="Export View Report" CssClass="btn btn-sm btn-success"
                                    OnClick="btnNbconsolidationexport_Click" />
                            </div>
                            <table class="table calGradeTable">

                                <tr>
                                    <td style="font-weight: bold; background: #dfdfdf">UA</td>
                                    <td>
                                        <asp:Label CssClass="calGradeTableValue" ID="lblUA_Center" runat="server" Text="0"></asp:Label></td>
                                    <td style="font-weight: bold; background: #dfdfdf">Acc</td>
                                    <td>
                                        <asp:Label CssClass="calGradeTableValue" ID="lblAcc_Center" runat="server" Text="0"></asp:Label></td>
                                    <td style="font-weight: bold; background: #dfdfdf">Good</td>
                                    <td>
                                        <asp:Label CssClass="calGradeTableValue" ID="lblGood_Center" runat="server" Text="0"></asp:Label></td>
                                    <td style="font-weight: bold; background: #dfdfdf">OS</td>
                                    <td>
                                        <asp:Label CssClass="calGradeTableValue" ID="lblOS_Center" runat="server" Text="0"></asp:Label></td>
                                    <td style="font-weight: bold; background: #dfdfdf" hidden="hidden">Total</td>
                                    <td hidden="hidden" colspan="3">
                                        <asp:Label CssClass="calGradeTableValue" ID="lblTotal_Center" runat="server" Text="0"></asp:Label></td>
                                </tr>

                            </table>
                            <div class="table-responsive text-nowrap grid-container">
                                <%--********************************CssClass="datatable table table-striped table-bordered table-hover"*************************************--%>
                                <%--<table class="table table-striped><tbody><tr><td>--%>
                                <div class="table-wrapper gvnbconsolidation-wrapper" id="scrollbarright">
                                    <asp:GridView ID="gvNbConsolidation" runat="server" CssClass="datatable table table-striped table-bordered table-hover"
                                        OnPreRender="gvNbConsolidation_PreRender" AutoGenerateColumns="False" OnRowDataBound="gvNbConsolidation_RowDataBound">
                                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                        <AlternatingRowStyle BackColor="#F2F2F2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Campus Head">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="gv_chkbx_campus_head" OnCheckedChanged="gv_chkbx_campus_head_CheckedChanged"
                                                        runat="server" AutoPostBack="true" Checked='<%#Convert.ToBoolean(Eval("ch_verify")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Document_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <FooterStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Teacher_Name" HeaderText="Teacher">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                                <ItemStyle CssClass="Left" />
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                                <ItemStyle CssClass="Left" />
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Keystage_id" HeaderText="Key Stage">
                                                <ItemStyle HorizontalAlign="Left" />
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            </asp:BoundField>
                                            <%-- 							Quality of Tasks 							--%>
                                            <asp:TemplateField HeaderText="Challenging tasks">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_QOT_challenging_tasks" runat="server"
                                                        SelectedValue='<%# Bind("QOT_challenging_tasks") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Variety of tasks">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_QOT_Variety_of_tasks" runat="server"
                                                        SelectedValue='<%# Bind("QOT_Variety_of_tasks") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Regular independent study">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_QOT_regular_independent_study" runat="server"
                                                        SelectedValue='<%# Bind("QOT_regular_independent_study") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Regularly assigned">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_QOT_regularly_assigned" runat="server"
                                                        SelectedValue='<%# Bind("QOT_regularly_assigned") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_QOT_grade" runat="server"
                                                        SelectedValue='<%# Bind("QOT_grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%-- 							Assessment 							--%>
                                            <asp:TemplateField HeaderText="Work checked promptly">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_Assessment_work_checked_promptly" runat="server"
                                                        SelectedValue='<%# Bind("Assessment_work_checked_promptly") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Errors identified">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_Assessment_errors_identified" runat="server"
                                                        SelectedValue='<%# Bind("Assessment_errors_identified") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Dev. comments">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_Assessment_dev_comments" runat="server"
                                                        SelectedValue='<%# Bind("Assessment_dev_comments") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Assessment criteria">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_Assessment_assessment_criteria" runat="server"
                                                        SelectedValue='<%# Bind("Assessment_assessment_criteria") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Apprec. Remarks">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_Assessment_apprec_remarks" runat="server"
                                                        SelectedValue='<%# Bind("Assessment_apprec_remarks") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Self/Peer assessment">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_Assessment_self_peer_assessment" runat="server"
                                                        SelectedValue='<%# Bind("Assessment_self_peer_assessment") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Follow up">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_Assessment_follow_up" runat="server"
                                                        SelectedValue='<%# Bind("Assessment_follow_up") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_Assessment_grade" runat="server"
                                                        SelectedValue='<%# Bind("Assessment_grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--					Students Progress					--%>
                                            <asp:TemplateField HeaderText="Impr. in work">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_SP_impr_in_work" runat="server"
                                                        SelectedValue='<%# Bind("SP_impr_in_work") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Responded to feedback">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_SP_responded_to_feedback" runat="server"
                                                        SelectedValue='<%# Bind("SP_responded_to_feedback") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Suff. gains">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_SP_suff_gains" runat="server"
                                                        SelectedValue='<%# Bind("SP_suff_gains") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Age-appropriate vocab">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_SP_age_appropriate_vocab" runat="server"
                                                        SelectedValue='<%# Bind("SP_age_appropriate_vocab") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Independence">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_SP_independence" runat="server"
                                                        SelectedValue='<%# Bind("SP_independence") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_SP_grade" runat="server"
                                                        SelectedValue='<%# Bind("SP_grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--						Work Presentation						--%>
                                            <asp:TemplateField HeaderText="Organised">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_WP_organised" runat="server"
                                                        SelectedValue='<%# Bind("WP_organised") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Neat">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_WP_neat" runat="server"
                                                        SelectedValue='<%# Bind("WP_neat") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Legible handwriting">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_WP_legible_handwriting" runat="server"
                                                        SelectedValue='<%# Bind("WP_legible_handwriting") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Indices filled">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_WP_indices_filled" runat="server"
                                                        SelectedValue='<%# Bind("WP_indices_filled") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Indices signed: teachers">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_WP_indices_signed_teachers" runat="server"
                                                        SelectedValue='<%# Bind("WP_indices_signed_teachers") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Indices signed: parents">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_WP_indices_signed_parents" runat="server"
                                                        SelectedValue='<%# Bind("WP_indices_signed_parents") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_WP_grade" runat="server"
                                                        SelectedValue='<%# Bind("WP_grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--Overall Grade--%>
                                            <asp:TemplateField HeaderText="Overall Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_overall_grade" runat="server"
                                                        SelectedValue='<%# Bind("overall_grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gv_txtbx_EBI1" runat="server" Text='<%#Eval("EBI1") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gv_txtbx_EBI2" runat="server" Text='<%#Eval("EBI2") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gv_txtbx_EBI3" runat="server" Text='<%#Eval("EBI3") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SIQA Endorsed">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="DarkCyan" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gv_ddl_Siqa_EndorsedValue" runat="server" onChange="updateHiddenField(this)"
                                                        SelectedValue='<%# Bind("Siqa_Endorsed") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                                        <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <asp:HiddenField ID="HiddenField1" runat="server" Value="false" />
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <%-- <asp:TemplateField HeaderText="Region ID">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="gvHfConsolidation_region" Value='<%#Eval("Region_Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                            <%--  <asp:BoundField  DataField="Region_Id" HeaderText="">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>--%>
                                            <%-- <asp:BoundField DataField="Center_Id" HeaderText="">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>
                                           <asp:BoundField DataField="Keystage_id" HeaderText="">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Options">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="DarkCyan" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Button runat="server" ID="btnUpdateNbConsolidationData"
                                                        Text="Update" CssClass="btn btn-sm btn-warning"
                                                        OnClick="btnUpdateNbConsolidationData_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Consolidation ID">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" ID="gvHfConsolidation_IdValue" Value='<%#Eval("NB_Consolidation_Id")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <SelectedRowStyle ForeColor="SlateGray" />
                                        <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                        <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                        <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>


                                <br />
                                <div class="table-wrapper gvNB_C_TeacherList-wrapper">

                                    <asp:GridView runat="server" ID="gvNB_C_TeacherList" CssClass="table table-bordered" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField ItemStyle-Width="20%" DataField="TeacherFullName" HeaderText="Teachers" />

                                        </Columns>
                                    </asp:GridView>

                                </div>
                                <%--</td></tr></tbody></table>--%>

                                <%--*********************************************************************--%>
                            </div>

                            <%--</section>--%>
                        </div>
                    </div>


                    <%--Nb History--%>
                    <div id="menu2" class="tab-pane fade">
                        <h3>NB Consolidation History</h3>

                        <div class="container horizontal-scrollable ">
                            <%--  <section>--%>
                            <table class="table">
                                <tr>
                                    <th class="text-center" colspan="10">Information</th>
                                </tr>
                                <tr>
                                    <td style="background-color: #e3f2f7;">&nbsp;</td>
                                    <td>Quality of Tasks</td>
                                    <td style="background-color: lightgray;">&nbsp;</td>
                                    <td>Assessment</td>
                                    <td style="background-color: #c4f2c4;">&nbsp;</td>
                                    <td>Students Progress</td>
                                    <td style="background-color: #f7d2c3;">&nbsp;</td>
                                    <td>Work Presentation</td>
                                </tr>
                                <tr>
                                    <td colspan="10"></td>
                                </tr>
                            </table>
                            <div style="display: flex; justify-content: flex-end; align-items: flex-end; height: 100%;">
                                <asp:Button runat="server" ID="btnexportsiqaendorsedgrades"
                                    Text="Export Siqa Endorsed Grades" CssClass="btn btn-sm btn-success"
                                    OnClick="btnexportsiqaendorsedgrades_Click" />
                            </div>
                            <table class="table calGradeTable">

                                <tr>
                                    <td style="font-weight: bold; background: #dfdfdf">UA</td>
                                    <td>
                                        <asp:Label CssClass="calGradeTableValue" ID="lblUA" runat="server" Text="0"></asp:Label></td>
                                    <td style="font-weight: bold; background: #dfdfdf">Acc</td>
                                    <td>
                                        <asp:Label CssClass="calGradeTableValue" ID="lblAcc" runat="server" Text="0"></asp:Label></td>
                                    <td style="font-weight: bold; background: #dfdfdf">Good</td>
                                    <td>
                                        <asp:Label CssClass="calGradeTableValue" ID="lblGood" runat="server" Text="0"></asp:Label></td>
                                    <td style="font-weight: bold; background: #dfdfdf">OS</td>
                                    <td>
                                        <asp:Label CssClass="calGradeTableValue" ID="lblOS" runat="server" Text="0"></asp:Label></td>
                                    <td style="font-weight: bold; background: #dfdfdf" hidden="hidden">Total</td>
                                    <td hidden="hidden">
                                        <asp:Label CssClass="calGradeTableValue" ID="lblTotal" runat="server" Text="0"></asp:Label></td>
                                </tr>

                            </table>
                            <div class="table-responsive text-nowrap gvnbconsolidation-wrapper">


                                <asp:GridView ID="gvnbconsolidationhistory" runat="server" CssClass="datatable table table-striped table-bordered table-hover"
                                    OnPreRender="gvnbconsolidationhistory_PreRender" AutoGenerateColumns="False">
                                    <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                    <AlternatingRowStyle BackColor="#F2F2F2" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Campus Head">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:CheckBox ID="gv_chkbx_campus_head" OnCheckedChanged="gv_chkbx_campus_head_CheckedChanged"
                                                    runat="server" AutoPostBack="true" Checked='<%#Convert.ToBoolean(Eval("ch_verify")) %>' Enabled="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Document_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <FooterStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Teacher_Name" HeaderText="Teacher">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                            <ItemStyle CssClass="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                            <ItemStyle CssClass="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Keystage_id" HeaderText="Key Stage">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <%-- 							Quality of Tasks 							--%>
                                        <asp:TemplateField HeaderText="Challenging tasks">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_QOT_challenging_tasks" runat="server"
                                                    SelectedValue='<%# Bind("QOT_challenging_tasks") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Variety of tasks">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_QOT_Variety_of_tasks" runat="server"
                                                    SelectedValue='<%# Bind("QOT_Variety_of_tasks") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Regular independent study">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_QOT_regular_independent_study" runat="server"
                                                    SelectedValue='<%# Bind("QOT_regular_independent_study") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Regularly assigned">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_QOT_regularly_assigned" runat="server"
                                                    SelectedValue='<%# Bind("QOT_regularly_assigned") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_QOT_grade" runat="server"
                                                    SelectedValue='<%# Bind("QOT_grade") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%-- 							Assessment 							--%>
                                        <asp:TemplateField HeaderText="Work checked promptly">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_Assessment_work_checked_promptly" runat="server"
                                                    SelectedValue='<%# Bind("Assessment_work_checked_promptly") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Errors identified">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_Assessment_errors_identified" runat="server"
                                                    SelectedValue='<%# Bind("Assessment_errors_identified") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Dev. comments">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_Assessment_dev_comments" runat="server"
                                                    SelectedValue='<%# Bind("Assessment_dev_comments") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Assessment criteria">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_Assessment_assessment_criteria" runat="server"
                                                    SelectedValue='<%# Bind("Assessment_assessment_criteria") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Apprec. Remarks">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_Assessment_apprec_remarks" runat="server"
                                                    SelectedValue='<%# Bind("Assessment_apprec_remarks") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Self/Peer assessment">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_Assessment_self_peer_assessment" runat="server"
                                                    SelectedValue='<%# Bind("Assessment_self_peer_assessment") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Follow up">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_Assessment_follow_up" runat="server"
                                                    SelectedValue='<%# Bind("Assessment_follow_up") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_Assessment_grade" runat="server"
                                                    SelectedValue='<%# Bind("Assessment_grade") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--					Students Progress					--%>
                                        <asp:TemplateField HeaderText="Impr. in work">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_SP_impr_in_work" runat="server"
                                                    SelectedValue='<%# Bind("SP_impr_in_work") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Responded to feedback">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_SP_responded_to_feedback" runat="server"
                                                    SelectedValue='<%# Bind("SP_responded_to_feedback") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Suff. gains">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_SP_suff_gains" runat="server"
                                                    SelectedValue='<%# Bind("SP_suff_gains") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Age-appropriate vocab">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_SP_age_appropriate_vocab" runat="server"
                                                    SelectedValue='<%# Bind("SP_age_appropriate_vocab") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Independence">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_SP_independence" runat="server"
                                                    SelectedValue='<%# Bind("SP_independence") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_SP_grade" runat="server"
                                                    SelectedValue='<%# Bind("SP_grade") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--						Work Presentation (Presentation (3.2.3))						--%>
                                        <asp:TemplateField HeaderText="Organised">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_WP_organised" runat="server"
                                                    SelectedValue='<%# Bind("WP_organised") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Neat">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_WP_neat" runat="server"
                                                    SelectedValue='<%# Bind("WP_neat") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Legible handwriting">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_WP_legible_handwriting" runat="server"
                                                    SelectedValue='<%# Bind("WP_legible_handwriting") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Indices filled">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_WP_indices_filled" runat="server"
                                                    SelectedValue='<%# Bind("WP_indices_filled") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Indices signed: teachers">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_WP_indices_signed_teachers" runat="server"
                                                    SelectedValue='<%# Bind("WP_indices_signed_teachers") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Indices signed: parents">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_WP_indices_signed_parents" runat="server"
                                                    SelectedValue='<%# Bind("WP_indices_signed_parents") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Grade">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_WP_grade" runat="server"
                                                    SelectedValue='<%# Bind("WP_grade") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--Overall Grade--%>
                                        <asp:TemplateField HeaderText="Overall Grade">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <asp:DropDownList ID="gv_ddl_overall_grade" runat="server"
                                                    SelectedValue='<%# Bind("overall_grade") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                    <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                    <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                    <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                    <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                            <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="gv_txtbx_EBI1" runat="server" Text='<%#Eval("EBI1") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                            <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="gv_txtbx_EBI2" runat="server" Text='<%#Eval("EBI2") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                            <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                            <ItemTemplate>
                                                <asp:TextBox ID="gv_txtbx_EBI3" runat="server" Text='<%#Eval("EBI3") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="SIQA Endorsed">
                                            <HeaderStyle HorizontalAlign="Center" BackColor="DarkCyan" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemTemplate>
                                                <%-- <asp:DropDownList ID="gv_ddl_Siqa_EndorsedValue" runat="server" onChange="updateHiddenField(this)"
                                                    SelectedValue='<%# Bind("Siqa_Endorsed") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                    <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                    <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                                    <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                                </asp:DropDownList>--%>
                                                <asp:Label runat="server" ID="gv_ddl_Siqa_EndorsedValue" Text='<%# Bind("Siqa_Endorsed") %>'></asp:Label>
                                                <asp:HiddenField ID="HiddenField1" runat="server" Value="false" />
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                        <asp:TemplateField HeaderText="Consolidation ID">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="gvHfConsolidation_IdValue" Value='<%#Eval("NB_Consolidation_Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <SelectedRowStyle ForeColor="SlateGray" />
                                    <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                    <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                    <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                </asp:GridView>

                                <%--</td></tr></tbody></table>--%>

                                <%--*********************************************************************--%>
                            </div>

                            <%--</section>--%>
                        </div>
                    </div>
                    <%--Nb History End--%>
                </div>



                <%--**************Test tabs Area*************--%>
                <%--      <div class="panel panel-default" style="width: 500px; padding: 10px; margin: 10px">
                    <div id="Tabs" role="tabpanel">
                        <!-- Nav tabs -->
                        <ul class="nav nav-tabs" role="tablist">
                            <li><a href="#personal" aria-controls="personal" role="tab" data-toggle="tab">Personal
                            </a></li>
                            <li><a href="#employment" aria-controls="employment" role="tab" data-toggle="tab">Employment</a></li>
                        </ul>
                        <!-- Tab panes -->
                        <div class="tab-content" style="padding-top: 20px">
                            <div role="tabpanel" class="tab-pane active" id="personal">
                                This is Personal Information Tab
                            </div>
                            <div role="tabpanel" class="tab-pane" id="employment">
                                This is Employment Information Tab
                            </div>
                        </div>
                    </div>
                    <asp:Button ID="Button1" Text="Submit" runat="server" CssClass="btn btn-primary" />
                    <asp:HiddenField ID="TabName" runat="server" />
                </div>--%>
                <%--**************Test tabs Area End*************--%>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%"
                    Width="100%" />
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>

    <style type="text/css">
        .TextLabelMandatory40 {
            font-size: 12px !important;
            font-weight: bold;
            color: black;
            width: 100% !important;
            text-align: left !important;
        }

        .gridchildheading {
            margin-bottom: 10px;
            padding-left: 0px;
            font-size: 15px !important;
        }

        .studentgrid {
            padding: 1% !important;
        }

        .absent_checkbox input {
            position: relative;
            top: 4px;
            margin-right: 10px !important;
        }

        .savearea {
            /*position: unset !important;*/
            padding: 10px 0px;
        }

        .andp {
            margin-bottom: 0px !important;
            line-height: 30px;
            font-size: 14px;
        }

        .gridtxt {
            font-size: 14px !important;
        }

        .stuname, .rollno, .gendername {
            font-weight: 700;
        }

        .upperheading {
            background: #0c4da2;
            padding: 10px;
            /* margin: 10px !important; */
            border: 1px solid #fff;
            border-radius: 10px;
        }

            .upperheading span {
                color: #fff;
            }

        .right-align.form-control {
            direction: rtl !important;
        }

        .left-align.form-control {
            direction: ltr !important;
        }

        .urdutxtright {
            /*direction: rtl !important;*/
            /*float:right !important;*/
            display: flex;
            justify-content: flex-end;
        }

        .urdutxtleft {
            /*direction:ltr !important;*/
            /*display: flex;*/
            justify-content: end;
        }

        .hidetxt {
            display: none;
        }

        .showtxt {
            display: block;
        }

        .ufloat_right {
            float: right;
        }

        .text-right {
            text-align: right;
        }

        .no_padding {
            padding-left: 0px !important;
            padding-right: 0px !important
        }

        .gridtxt {
            margin: 5px 0px !important;
        }

        .hidebtn {
            display: none !important;
        }


        .maiproblemabsent span:nth-child(1) span::after {
            content: " میں";
        }

        .absentdiv span:nth-child(1) {
            float: right;
            color: red;
            margin-left: 3px;
        }



        .absentdiv {
            text-align: right !important;
        }

        .lbltxtabsent {
            float: right;
            margin-left: 8px;
        }
    </style>
    <%-- <script>
        // var objsts = $('#listG1 option').length;
        function myddFunction(itemdd) {
        //$('.dropdownlist1').change(function () {
            //var list1 = $("#listG1 option:selected").text();
            //var len = $("option", itemdd).length);
            //for (var i = 0; i < len; i++) {
            $("option", itemdd).each(function () {
                    //$("#container").append(this.value + ' ');        // or $(this).val()
              
                var list1 = $(this).text();// $("option:selected", itemdd).text();
                var english = /^[A-Za-z0-9]*$/;

                //$.each(objsts, function () {
                //var $this = $(this);
                //if (!english.test($this.html()))
                if (!english.test(list1))
                    //$this.addClass('active');
                    //$("option:selected", itemdd).addClass('active');
                    $("option", itemdd).addClass('active');
                //});
                });
            //}
            //$("html[lang=ar]").attr("dir", "rtl")
        }

       
    </script>--%>



    <%--   <script type="text/javascript">
        $(function () {
            var tabName = $("[id*=TabName]").val() != "" ? $("[id*=TabName]").val() : "personal";
            $('#Tabs a[href="#' + tabName + '"]').tab('show');
            $("#Tabs a").click(function () {
                $("[id*=TabName]").val($(this).attr("href").replace("#", ""));
            });
        });
    </script>--%>
    <script type="text/javascript">
        function SetActiveTab() {
            event.preventDefault();
            //$(".saved").fadeIn(500).fadeOut(500);
            $('a[href="#menu1"]').click()
        }
        function scrollToRight() {
            //  alert('aaa');

            var container = document.getElementById('scrollbarright');
            container.scrollLeft = container.scrollWidth;
        }
        function updateHiddenField(dropDownList) {
            var hiddenField = dropDownList.parentNode.querySelector("[id*=HiddenField1]");
            hiddenField.value = "true";
        }

        function SetActiveTabForHistory() {
            event.preventDefault();
            //$(".saved").fadeIn(500).fadeOut(500);
            $('a[href="#menu2"]').click()
        }

        function hideMenu2() {
            var menu2 = document.querySelector('a[href="#menu2"]').parentNode;
            menu2.style.display = 'none';
        }
    </script>
    <script type="text/javascript">

        $(document).ready(function () {

            // Restore the active tab after postback
            var activeTab = $('#<%= hfActiveTab.ClientID %>').val();
            if (activeTab) {
                $('.nav-tabs a[href="' + activeTab + '"]').tab('show');
            }

            // Update hidden field with active tab ID before postback
            $('#<%= ddl_region.ClientID %>').change(function () {
                var activeTab = $('.nav-tabs li.active a').attr('href');
                $('#<%= hfActiveTab.ClientID %>').val(activeTab);

                $("#<%=ddlteacher.ClientID%>").select2();
            });


            $('#<%= ddlteacher.ClientID %>').change(function () {
                $("#<%=ddlteacher.ClientID%>").select2();
            });

            // Update hidden field with active tab ID when tab is changed
            $('a[data-toggle="tab"]').on('shown.bs.tab', function (e) {
                var activeTab = $(e.target).attr('href');
                $('#<%= hfActiveTab.ClientID %>').val(activeTab);
            });

            $('.select2').select2({
                placeholder: 'Select a teacher',
                allowClear: true
            });
        });
        function SetPositionScrollBar() {

            var container = document.getElementById('scrollbarright');
            container.scrollLeft = container.scrollWidth;
                <%--var container = document.getElementById('scrollbarright');
                var scrollLeft = container.scrollLeft();
                $('#<%= PositionScrollBar.ClientID %>').val(scrollLeft);--%>
        }

        function saveActiveTab1() {
            // $('a[href="#home"]').click()
            $('#<%= hfActiveTab.ClientID %>').val('#home');
        }
        function saveActiveTab2() {
            // $('a[href="#menu1"]').click()
            $('#<%= hfActiveTab.ClientID %>').val('#menu1');
        }
        function saveActiveTab3() {
            // $('a[href="#menu1"]').click()
            $('#<%= hfActiveTab.ClientID %>').val('#menu2');
        }
    </script>


</asp:Content>



