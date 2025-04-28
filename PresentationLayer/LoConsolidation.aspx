<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="LoConsolidation.aspx.cs" Inherits="PresentationLayer_LoConsolidation"
    Theme="BlueTheme" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true">
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

                .gvloconsolidation-wrapper {
                    /*width: 600px;*/
                    height: 400px;
                    overflow: scroll;
                    border: 1px solid #777777;
                }

                .gvLO_C_TeacherList-wrapper {
                    /*width: 600px;*/
                    height: 400px;
                    overflow: scroll;
                    border: 1px solid #777777;
                }

                    .gvLO_C_TeacherList-wrapper th {
                        position: sticky;
                        top: 0;
                        background-color: white;
                        font-size: 14px;
                    }

                .gvloconsolidation-wrapper table {
                    border-spacing: 0;
                }

                .gvloconsolidation-wrapper th {
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

                    .gvloconsolidation-wrapper th:nth-child(1),
                    .gvloconsolidation-wrapper td:nth-child(1) {
                        position: sticky;
                        left: 0;
                        width: 90px;
                        min-width: 90px;
                    }

                    .gvloconsolidation-wrapper th:nth-child(2),
                    .gvloconsolidation-wrapper td:nth-child(2) {
                        position: sticky;
                        /* 1st cell left/right padding + 1st cell width + 1st cell left/right border width */
                        /* 0 + 5 + 150 + 5 + 1 */
                        left: 90px;
                        width: 90px;
                        min-width: 90px;
                    }

                    .gvloconsolidation-wrapper th:nth-child(3),
                    .gvloconsolidation-wrapper td:nth-child(3) {
                        position: sticky;
                        /* 1st cell left/right padding + 1st cell width + 1st cell left/right border width */
                        /* 0 + 5 + 150 + 5 + 1 */
                        left: 180px;
                        width: 180px;
                        min-width: 180px;
                    }

                    .gvloconsolidation-wrapper th:nth-child(4),
                    .gvloconsolidation-wrapper td:nth-child(4) {
                        position: sticky;
                        /* 1st cell left/right padding + 1st cell width + 1st cell left/right border width */
                        /* 0 + 5 + 150 + 5 + 1 */
                        left: 360px;
                        width: 90px;
                        min-width: 90px;
                    }

                    .gvloconsolidation-wrapper th:nth-child(5),
                    .gvloconsolidation-wrapper td:nth-child(5) {
                        position: sticky;
                        /* 1st cell left/right padding + 1st cell width + 1st cell left/right border width */
                        /* 0 + 5 + 150 + 5 + 1 */
                        left: 450px;
                        width: 130px;
                        min-width: 130px;
                    }

                .gvloconsolidation-wrapper td:nth-child(1),
                .gvloconsolidation-wrapper td:nth-child(2),
                .gvloconsolidation-wrapper td:nth-child(3),
                .gvloconsolidation-wrapper td:nth-child(4),
                .gvloconsolidation-wrapper td:nth-child(5) {
                    background: #fff;
                }

                .gvloconsolidation-wrapper th:nth-child(1),
                .gvloconsolidation-wrapper th:nth-child(2),
                .gvloconsolidation-wrapper th:nth-child(3),
                .gvloconsolidation-wrapper th:nth-child(4),
                .gvloconsolidation-wrapper th:nth-child(5) {
                    z-index: 2;
                }

                /*.table-wrapper {
                 overflow-y: auto;
                     max-height: 400px;   
                 margin-top: 20px;
                 }

       .frozen-column {
            position: sticky;
            background: white;
            z-index: 1;
            left: 0;
        }

        .frozen-column-1 {
            left: 0px;
            width: 90px;
        }

        .frozen-column-2 {
            left: 90px;
            width: 90px; 
        }

        .frozen-column-3 {
            left: 155px;
            width: 180px;
        }

        .frozen-column-4 {
            left: 220px;
            width: 180px;
        }

        .frozen-column-5 {
            left: 285px;
             width: 180px;
        }
        .table-wrapper th:nth-child(1){
            z-index: 2;
        }*/
            </style>
            <script type="text/javascript">
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
            <h2>Lesson Observations Data</h2>
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
                                                            <label class="TextLabelLeft">Region ::</label>
                                                            <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                                OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" Width="100%" OnClientClick="saveActiveTab()">
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
                                                            <asp:DropDownList ID="ddlteacher" runat="server" CssClass="dropdownlist select2  form-control"
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
                                                        <div class="form-group">
                                                            <%--  <label class="TextLabelLeft">Subject :</label>
                                                            <asp:DropDownList ID="ddlsubjects" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlsubjects_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>--%>
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
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Subject :</label>
                                                            <asp:DropDownList ID="ddlsubjects" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlsubjects_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>
                                                            <%--<label class="TextLabelLeft">Class :</label>
                                                            <asp:DropDownList ID="ddlclass" runat="server" AutoPostBack="True"
                                                                CssClass="dropdownlist form-control" OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"
                                                                Width="100%">
                                                            </asp:DropDownList>--%>
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

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="pbarnew">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%"
                    Width="100%" />
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
            <div class="vh-100 tabs">
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

                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0" <%--main_table col-lg-8 col-md-8 col-xs-8 col-sm-8--%>
                                            border="0">
                                            <tr class="row">

                                                <%--  <td class="col-lg-4">

                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Region :</label>
                                                        <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>

                                                </td>

                                                <td class="col-lg-4">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">School :</label>
                                                        <asp:DropDownList ID="ddl_center" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                            OnSelectedIndexChanged="ddl_center_SelectedIndexChanged" Width="100%">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                               

                                                <td class="col-lg-4">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Term Group :</label>

                                                        <asp:DropDownList ID="ddl_grouphead" runat="server" CssClass="dropdownlist form-control" Width="100%" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>--%>
                                            </tr>

                                        </table>
                                    </td>
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
                                                        <%--<asp:DropDownList ID="DropDownList5" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                Width="100%">
                                            </asp:DropDownList>--%>
                                                        <%--<label>Issuance Date</label>--%>
                                                        <asp:TextBox ID="txtIssuanceDate" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                                                        <%--       <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Date is required."
                                                ControlToValidate="txtIssuanceDate" ForeColor="red" ValidationGroup="test"></asp:RequiredFieldValidator>--%>
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
                                            Visible="true" Font-Overline="False" Class="formheading">Lesson Planning</asp:Label>
                                    </td>
                                </tr>

                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">



                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Format :</label>
                                                        <asp:DropDownList
                                                            ID="ddlformat" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Objectives/Outcomes :</label>
                                                        <asp:DropDownList
                                                            ID="ddlobjectiveoutcome" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Act & Learning Outcomes :</label>
                                                        <asp:DropDownList
                                                            ID="ddlactivitieslearningoutcome" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Curr Adapted :</label>
                                                        <asp:DropDownList
                                                            ID="ddlcurrentaddapted" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Cross Curricular Links :</label>
                                                        <asp:DropDownList
                                                            ID="ddlcrosscurricularlinks" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Lesson Eval :</label>
                                                        <asp:DropDownList
                                                            ID="ddllessoneva" CssClass="dropdownlist form-control" runat="server">
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
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Grade :</label>
                                                        <asp:DropDownList
                                                            ID="ddlgrade" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlgrade_SelectedIndexChanged" runat="server">
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
                                        <asp:Label ID="Label3" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Teaching</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft" style="font-weight: bold;">Subject Knowledge:</label>
                                                        <asp:DropDownList OnSelectedIndexChanged="ddlTeachingLov_SelectedIndexChanged" AutoPostBack="true"
                                                            ID="ddlsubjectknowledge" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Clear LO :</label>
                                                        <asp:DropDownList
                                                            ID="ddlclearlo" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft" style="font-weight: bold;">Act & Learning Outcomes:</label>
                                                        <asp:DropDownList OnSelectedIndexChanged="ddlTeachingLov_SelectedIndexChanged" AutoPostBack="true"
                                                            ID="ddltecactlearnoutcom" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft" style="font-weight: bold;">Need of Ability Group:</label>
                                                        <asp:DropDownList OnSelectedIndexChanged="ddlTeachingLov_SelectedIndexChanged" AutoPostBack="true"
                                                            ID="ddlabilitygroup" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Collaboration :</label>
                                                        <asp:DropDownList
                                                            ID="ddlCollaboration" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">HOT and reflection :</label>
                                                        <asp:DropDownList
                                                            ID="ddlhotandreflection" CssClass="dropdownlist form-control" runat="server">
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
                                            <%--     <tr class="row">
                                    <td class="col-lg-2">
                                        <div class="form-group">
                                            <label class="TextLabelLeft">Grade :</label>
                                            <asp:DropDownList ID="DropDownList19" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term"
                                                Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>--%>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top" colspan="3">
                                        <%--Grid was here--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Clear Instruction :</label>
                                                        <asp:DropDownList
                                                            ID="ddlclearinst" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Cross-curricular links :</label>
                                                        <asp:DropDownList
                                                            ID="ddlcclinks" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft" style="font-weight: bold;">AFL:</label>
                                                        <asp:DropDownList OnSelectedIndexChanged="ddlTeachingLov_SelectedIndexChanged"
                                                            ID="dddafl" CssClass="dropdownlist form-control" runat="server" AutoPostBack="true">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Self/Peer Assess :</label>
                                                        <asp:DropDownList
                                                            ID="ddlselfpeeraccess" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Support & Feedback :</label>
                                                        <asp:DropDownList
                                                            ID="ddlsupportandfb" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Time Management :</label>
                                                        <asp:DropDownList
                                                            ID="ddltimemanagement" CssClass="dropdownlist form-control" runat="server">
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

                                            <%--                                *****************************--%>

                                            <tr class="row">
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Learning env :</label>
                                                        <asp:DropDownList
                                                            ID="ddlLearningEnv" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Grade :</label>
                                                        <asp:DropDownList Enabled="false"
                                                            ID="ddltechgrade" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddltechgrade_SelectedIndexChanged" runat="server">
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
                                            Visible="true" Font-Overline="False" Class="formheading">Student Learning Skills</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft" style="font-weight: bold;">Interaction:</label>
                                                        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlStudentLearningSkillsLov_SelectedIndexChanged"
                                                            ID="ddlinteraction" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Make Connections :</label>
                                                        <asp:DropDownList
                                                            ID="ddlmarkconnections" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft" style="font-weight: bold;">Actively Engaged:</label>
                                                        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlStudentLearningSkillsLov_SelectedIndexChanged"
                                                            ID="ddlactivityengaged" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Collaborate :</label>
                                                        <asp:DropDownList
                                                            ID="ddlCollaborate" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft" style="font-weight: bold;">Reflect:</label>
                                                        <asp:DropDownList AutoPostBack="true" OnSelectedIndexChanged="ddlStudentLearningSkillsLov_SelectedIndexChanged"
                                                            ID="ddlReflect" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">HOT :</label>
                                                        <asp:DropDownList
                                                            ID="ddlhot" CssClass="dropdownlist form-control" runat="server">
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

                                            <%--                                *****************************--%>

                                            <tr class="row">
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Communicate Effectively :</label>
                                                        <asp:DropDownList
                                                            ID="ddlceffectively" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Grade :</label>
                                                        <asp:DropDownList Enabled="false"
                                                            ID="ddgradestudentlearningskills" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddgradestudentlearningskills_SelectedIndexChanged" runat="server">
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
                                        <asp:Label ID="Label5" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Attitudes Relationships</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-3">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Self-Disciplined :</label>
                                                        <asp:DropDownList
                                                            ID="ddlselfdisciplined" CssClass="dropdownlist form-control" runat="server">
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
                                                        <label class="TextLabelLeft">Positive Relations Students :</label>
                                                        <asp:DropDownList
                                                            ID="ddlpositiverelationstudents" CssClass="dropdownlist form-control" runat="server">
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
                                                        <label class="TextLabelLeft">Positive Relations Adults :</label>
                                                        <asp:DropDownList
                                                            ID="ddlpositiverelationadults" CssClass="dropdownlist form-control" runat="server">
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
                                                            ID="ddlgradeattituderelationship" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlgradeattituderelationship_SelectedIndexChanged" runat="server">
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

                                            <%--                                *****************************--%>

                                            <%--     <tr class="row">
                                    <td class="col-lg-2">
                                        <div class="form-group">
                                            <label class="TextLabelLeft">Communicate Effectively :</label>
                                            <asp:DropDownList
                                                ID="DropDownList7" CssClass="dropdownlist form-control" runat="server">
                                                <asp:ListItem Selected="True" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                        <td class="col-lg-2">
                                        <div class="form-group">
                                            <label class="TextLabelLeft">Grade :</label>
                                            <asp:DropDownList
                                                ID="DropDownList8" CssClass="dropdownlist form-control" runat="server">
                                                <asp:ListItem Selected="True" Text="--Select--"></asp:ListItem>
                                                <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                </tr>--%>
                                        </table>
                                    </td>
                                </tr>
                                <tr align="center" runat="server" id="HideDiv">
                                    <td style="height: 22px" class="titlesection" colspan="3">
                                        <asp:Label ID="Label6" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                            Visible="true" Font-Overline="False" Class="formheading">Care and Classroom Routines (EYFS and KS1) </asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" id="HideDiv1">
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Positive Relations Peers :</label>
                                                        <asp:DropDownList
                                                            ID="ddlpositiverelationpeers" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Positive Relations Adults :</label>
                                                        <asp:DropDownList
                                                            ID="ddlpositiverelfamiliaradults" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft" style="font-weight: 600">Settled Well :</label>
                                                        <asp:DropDownList
                                                            ID="ddlsettledwell" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Caring/ Sharing :</label>
                                                        <asp:DropDownList
                                                            ID="ddlcaringsharing" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Listen Follow Instructions :</label>
                                                        <asp:DropDownList
                                                            ID="ddllistenfollowinstructions" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td class="col-lg-2">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Teacher Childrens Needs :</label>
                                                        <asp:DropDownList
                                                            ID="ddlteachersenstowardschild" CssClass="dropdownlist form-control" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <tr class="row">
                                                    <td class="col-lg-2">
                                                        <div class="form-group">
                                                            <label class="TextLabelLeft">Grade :</label>
                                                            <asp:DropDownList
                                                                ID="ddlgradecareandclassromroutine" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlgradecareandclassromroutine_SelectedIndexChanged" runat="server">
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

                                                <%--                                *****************************--%>
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
                                                <td class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Students' Progress :</label>
                                                        <asp:DropDownList
                                                            ID="ddlstudentprogress" CssClass="dropdownlist form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlstudentprogress_SelectedIndexChanged" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>
                                                </td>
                                                <td class="col-lg-6">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">Overall Lesson Grade :</label>
                                                        <asp:DropDownList
                                                            ID="ddloveralllesssongrade" CssClass="dropdownlist form-control" Enabled="false" runat="server">
                                                            <asp:ListItem Selected="True" Value="" Text="--Select--"></asp:ListItem>
                                                            <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                            <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                            <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                            <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                            <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                        </table>
                                    </td>
                                </tr>
                                <%--     <tr>
                                    <td>
                                        <table class="main_table col-lg-12" cellspacing="0" cellpadding="0"
                                            border="0">
                                            <tr class="row">

                                                <td class="col-lg-4">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">EBI1 :</label>
                                                        <asp:TextBox ID="txtEBI1" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td class="col-lg-4">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">EBI2 :</label>
                                                        <asp:TextBox ID="txtEBI2" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>
                                                <td class="col-lg-4">
                                                    <div class="form-group">
                                                        <label class="TextLabelLeft">EBI3 :</label>
                                                        <asp:TextBox ID="txtEBI3" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </td>
                                        </table>
                                    </td>
                                </tr>--%>
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
                        <h3>LO Consolidation Report</h3>

                        <div class="container horizontal-scrollable ">
                            <%--  <section>--%>
                            <table class="table">
                                <tr>
                                    <th class="text-center" colspan="10">Information</th>
                                </tr>
                                <tr>
                                    <td style="background-color: #e3f2f7;">&nbsp;</td>
                                    <td>Lesson Planning</td>
                                    <td style="background-color: lightgray;">&nbsp;</td>
                                    <td>Teaching</td>
                                    <td style="background-color: #c4f2c4;">&nbsp;</td>
                                    <td>Student Learning Skills</td>
                                    <td style="background-color: #f7d2c3;">&nbsp;</td>
                                    <td>Attitudes, relationships</td>
                                    <td style="background-color: #f7f7cd;">&nbsp;</td>
                                    <td>Care and Classroom Routines (EYFS and KS1)</td>
                                    <td></td>
                                    <td></td>

                                </tr>
                                <tr>
                                    <td colspan="10"></td>
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

                                            <asp:Button runat="server" ID="btnUpdateAllLoConsolidationData"
                                                Text="Update All" CssClass="btn btn-sm btn-warning"
                                                OnClick="btnUpdateAllLoConsolidationData_Click" />

                                            

                                           
                                        </td>
                                    </div>
                                </tr>
                            </table>
                            <div style="display: flex; justify-content: flex-end; align-items: flex-end; height: 100%;">
                                 <asp:Button runat="server" ID="btnloconsolidationexport"
                                                Text="Export View Report" CssClass="btn btn-sm btn-success"
                                                OnClick="btnloconsolidationexport_Click" />
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
                                <div class="table-wrapper gvloconsolidation-wrapper">
                                    <asp:GridView ID="gvloconsolidation" runat="server" CssClass="datatable table table-striped table-bordered table-hover  "
                                        OnPreRender="gvloconsolidation_PreRender" AutoGenerateColumns="False" OnRowDataBound="gvloconsolidation_RowDataBound">
                                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                        <AlternatingRowStyle BackColor="#F2F2F2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Campus Head.">
                                                <HeaderStyle HorizontalAlign="Center" CssClass="frozen-column frozen-column-1" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="frozen-column frozen-column-1" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="gv_chkbx_campus_head" OnCheckedChanged="gv_chkbx_campus_head_CheckedChanged"
                                                        runat="server" AutoPostBack="true" Checked='<%#Convert.ToBoolean(Eval("ch_verify")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Document_Date" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}">
                                                <ItemStyle HorizontalAlign="Left" CssClass="frozen-column frozen-column-2" />
                                                <FooterStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Teacher_Name" HeaderText="Teacher">
                                                <ItemStyle HorizontalAlign="Left" Width="180px" CssClass="frozen-column frozen-column-3" />
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                                <ItemStyle CssClass="frozen-column frozen-column-4" />
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                                <ItemStyle CssClass="frozen-column frozen-column-5" />
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
                                            <%--<asp:BoundField DataField="Format" HeaderText="Format">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightBlue" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Format">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlFormatValue" runat="server"
                                                        SelectedValue='<%# Bind("Format") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Obj_Outcoms" HeaderText="Objectives/Outcomes">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightBlue" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Objectives/Outcomes">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlObj_OutcomsValue" runat="server"
                                                        SelectedValue='<%# Bind("Obj_Outcoms") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="LP_Learning_Outcomes" HeaderText="Act & Learning Outcomes">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightBlue" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Act & Learning Outcomes">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlLP_Learning_OutcomesValue" runat="server"
                                                        SelectedValue='<%# Bind("LP_Learning_Outcomes") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Cur_Adapted" HeaderText="Curr. Adapted">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightBlue" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Curr. Adapted">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCur_AdaptedValue" runat="server"
                                                        SelectedValue='<%# Bind("Cur_Adapted") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Cross_Curricular_Links" HeaderText="Cross Curricular Links">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightBlue" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Cross Curricular Links">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCross_Curricular_LinksValue" runat="server"
                                                        SelectedValue='<%# Bind("Cross_Curricular_Links") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Lesson_Evaluation" HeaderText="Lesson Eval">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightBlue" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Lesson Eval">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlLesson_EvaluationValue" runat="server"
                                                        SelectedValue='<%# Bind("Lesson_Evaluation") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Lesson_Grade" HeaderText="Grade">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightBlue" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlLesson_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Lesson_Grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Subject_Knowledge" HeaderText="Subject Knowledge">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Subject Knowledge">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSubject_KnowledgeValue" runat="server"
                                                        SelectedValue='<%# Bind("Subject_Knowledge") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Clear_Lo" HeaderText="Clear LO">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Clear LO">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlClear_LoValue" runat="server"
                                                        SelectedValue='<%# Bind("Clear_Lo") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Teaching_Learning_Outcomes" HeaderText="Act & Learning Outcomes">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Act & Learning Outcomes">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlTeaching_Learning_OutcomesValue" runat="server"
                                                        SelectedValue='<%# Bind("Teaching_Learning_Outcomes") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Need_Ability_Group" HeaderText="Need of Ability Group">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Need of Ability Group">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlNeed_Ability_GroupValue" runat="server"
                                                        SelectedValue='<%# Bind("Need_Ability_Group") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Collaboration" HeaderText="Collaboration">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Collaboration">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCollaborationValue" runat="server"
                                                        SelectedValue='<%# Bind("Collaboration") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Hot_and_Reflection" HeaderText="HOT and reflection">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="HOT and reflection">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlHot_and_ReflectionValue" runat="server"
                                                        SelectedValue='<%# Bind("Hot_and_Reflection") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Clear_Instruction" HeaderText="Clear Instruction">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Clear Instruction">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlClear_InstructionValue" runat="server"
                                                        SelectedValue='<%# Bind("Clear_Instruction") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Tech_Cross_Curricular_Links" HeaderText="Cross-curricular links">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Cross-curricular links">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlTech_Cross_Curricular_LinksValue" runat="server"
                                                        SelectedValue='<%# Bind("Tech_Cross_Curricular_Links") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="AFL" HeaderText="AFL">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="AFL">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlAFLValue" runat="server"
                                                        SelectedValue='<%# Bind("AFL") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Peer_Address" HeaderText="Self/Peer Assess">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Self/Peer Assess">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlPeer_AddressValue" runat="server"
                                                        SelectedValue='<%# Bind("Peer_Address") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Suppor_Feedback" HeaderText="Support & Feedback">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Support & Feedback">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSuppor_FeedbackValue" runat="server"
                                                        SelectedValue='<%# Bind("Suppor_Feedback") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Time_Management" HeaderText="Time Management">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Time Management">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlTime_ManagementValue" runat="server"
                                                        SelectedValue='<%# Bind("Time_Management") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Teaching_Grade" HeaderText="Grade">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlTeaching_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Teaching_Grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Interaction" HeaderText="Interaction">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGreen" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Interaction">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlInteractionValue" runat="server"
                                                        SelectedValue='<%# Bind("Interaction") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Make_Connection" HeaderText="Make Connections">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGreen" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Make Connections">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlMake_ConnectionValue" runat="server"
                                                        SelectedValue='<%# Bind("Make_Connection") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Actively_Engaged" HeaderText="Actively Engaged">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGreen" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Actively Engaged">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlActively_EngagedValue" runat="server"
                                                        SelectedValue='<%# Bind("Actively_Engaged") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Collaborate" HeaderText="Collaborate">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGreen" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Collaborate">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCollaborateValue" runat="server"
                                                        SelectedValue='<%# Bind("Collaborate") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Reflect" HeaderText="Reflect">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGreen" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Reflect">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlReflectValue" runat="server"
                                                        SelectedValue='<%# Bind("Reflect") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="HOT" HeaderText="HOT">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGreen" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="HOT">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlHOTValue" runat="server"
                                                        SelectedValue='<%# Bind("HOT") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Communicate_Effectively" HeaderText="Communicate Effectively">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGreen" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Communicate Effectively">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCommunicate_EffectivelyValue" runat="server"
                                                        SelectedValue='<%# Bind("Communicate_Effectively") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Student_Grade" HeaderText="Grade">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightGreen" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlStudent_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Student_Grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Self_Disciplined" HeaderText="Self-Disciplined">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightSalmon" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Self-Disciplined">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSelf_DisciplinedValue" runat="server"
                                                        SelectedValue='<%# Bind("Self_Disciplined") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Positive_Relation_Student" HeaderText="Positive Relations Students">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightSalmon" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Positive Relations Students">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlPositive_Relation_StudentValue" runat="server"
                                                        SelectedValue='<%# Bind("Positive_Relation_Student") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Positive_Relation_Adult" HeaderText="Positive Relations Adults">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightSalmon" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Positive Relations Adults">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlPositive_Relation_AdultValue" runat="server"
                                                        SelectedValue='<%# Bind("Positive_Relation_Adult") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Attitude_Relationship_Grade" HeaderText="Grade">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="LightSalmon" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlAttitude_Relationship_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Attitude_Relationship_Grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Care_Classroom_Positive_Relationship_Peers" HeaderText="Positive Relations Peers">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="DarkGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Positive Relations Peers">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCare_Classroom_Positive_Relationship_PeersValue" runat="server"
                                                        SelectedValue='<%# Bind("Care_Classroom_Positive_Relationship_Peers") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Care_Classroom_Relation_Adult" HeaderText="Positive Relations Adults">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="DarkGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Positive Relations Adults">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCare_Classroom_Relation_AdultValue" runat="server"
                                                        SelectedValue='<%# Bind("Care_Classroom_Relation_Adult") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Settled_Well" HeaderText="Settled Well">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="DarkGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Settled Well">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSettled_WellValue" runat="server"
                                                        SelectedValue='<%# Bind("Settled_Well") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Caring_Sharing" HeaderText="Caring/ Sharing">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="DarkGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Caring/ Sharing">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCaring_SharingValue" runat="server"
                                                        SelectedValue='<%# Bind("Caring_Sharing") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Listen_Follow_Instruction" HeaderText="Listen Follow Instructions">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="DarkGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Listen Follow Instructions">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlListen_Follow_InstructionValue" runat="server"
                                                        SelectedValue='<%# Bind("Listen_Follow_Instruction") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Teacher_Children_Needs" HeaderText="Teacher Sen Childrens Needs">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="DarkGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Teacher Sen Childrens Needs">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlTeacher_Children_NeedsValue" runat="server"
                                                        SelectedValue='<%# Bind("Teacher_Children_Needs") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Care_Classroom_Grade" HeaderText="Grade">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="DarkGray" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCare_Classroom_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Care_Classroom_Grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Student_Progress" HeaderText="Students Progress">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Students Progress">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallProgress_Student_Progress" runat="server"
                                                        SelectedValue='<%# Bind("Student_Progress") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="Overall_Lesson_Grade" HeaderText="Overall Lesson Grade">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="Overall Lesson Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallProgress_overall_lesson_grade" runat="server"
                                                        SelectedValue='<%# Bind("Overall_Lesson_Grade") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="EBI1" HeaderText="EBI1">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gvDdlOverallProgress_EBI1" runat="server" Text='<%#Eval("EBI1") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="EBI2" HeaderText="EBI2">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gvDdlOverallProgress_EBI2" runat="server" Text='<%#Eval("EBI2") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:BoundField DataField="EBI3" HeaderText="EBI3">
                                            <ItemStyle HorizontalAlign="Left" />
                                            <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                        </asp:BoundField>--%>
                                            <asp:TemplateField HeaderText="">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gvDdlOverallProgress_EBI3" runat="server" Text='<%#Eval("EBI3") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="SIQA Endorsed">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="DarkCyan" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSiqa_EndorsedValue" runat="server"
                                                        SelectedValue='<%# Bind("Siqa_Endorsed") %>' AutoPostBack="false" CssClass="dropdownlist">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                                        <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--    <asp:BoundField  DataField="Region_Id" HeaderText="">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>
                                          <asp:BoundField DataField="Center_Id" HeaderText="">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>
                                           <asp:BoundField DataField="Keystage_id" HeaderText="">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>--%>
                                            <%--     <asp:TemplateField HeaderText="">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="RegionId" Value='<%#Eval("Region_Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                            <%--    <asp:TemplateField HeaderText="">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="CenterId" Value='<%#Eval("Center_Id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                            <%--   <asp:TemplateField HeaderText="">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                            <ItemTemplate>
                                                <asp:HiddenField runat="server" ID="Keystageid" Value='<%#Eval("Keystage_id")%>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Options">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="DarkCyan" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:Button runat="server" ID="btnUpdateLoConsolidationData"
                                                        Text="Update" CssClass="btn btn-sm btn-warning"
                                                        OnClick="btnUpdateLoConsolidationData_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Consolidation ID">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" ID="gvHfConsolidatio_IdValue" Value='<%#Eval("Consolidatio_Id")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                        </Columns>
                                        <SelectedRowStyle ForeColor="SlateGray" />
                                        <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                        <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                        <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                    </asp:GridView>
                                </div>
                                <%--</td></tr></tbody></table>--%>

                                <%--***********************************************************SIQA_Lo_Consolidation_TeacherList  **********--%>
                            </div>
                            <br />
                            <div class="table-wrapper gvLO_C_TeacherList-wrapper">

                                <asp:GridView runat="server" ID="gvLO_C_TeacherList" CssClass="table table-bordered" AutoGenerateColumns="false">
                                    <Columns>
                                        <asp:BoundField ItemStyle-Width="20%" DataField="TeacherFullName" HeaderText="Teachers" />

                                    </Columns>
                                </asp:GridView>

                            </div>

                            <%--</section>--%>
                        </div>


                    </div>

                    <%--LO History--%>
                    <div id="menu2" class="tab-pane fade">
                        <h3>LO Consolidation History</h3>

                        <div class="container horizontal-scrollable ">
                            <%--  <section>--%>
                            <table class="table">
                                <tr>
                                    <th class="text-center" colspan="10">Information</th>
                                </tr>
                                <tr>
                                    <td style="background-color: #e3f2f7;">&nbsp;</td>
                                    <td>Lesson Planning</td>
                                    <td style="background-color: lightgray;">&nbsp;</td>
                                    <td>Teaching</td>
                                    <td style="background-color: #c4f2c4;">&nbsp;</td>
                                    <td>Student Learning Skills</td>
                                    <td style="background-color: #f7d2c3;">&nbsp;</td>
                                    <td>Attitudes, relationships</td>
                                    <td style="background-color: #f7f7cd;">&nbsp;</td>
                                    <td>Care and Classroom Routines (EYFS and KS1)</td>
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
                           
                            <div class="table-wrapper">
                                <div class="table-responsive text-nowrap gvloconsolidation-wrapper">

                                    <asp:GridView ID="gvloconsolidationhistory" runat="server" CssClass="datatable table table-striped table-bordered table-hover"
                                        OnPreRender="gvloconsolidationhistory_PreRender" AutoGenerateColumns="False">
                                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                                        <AlternatingRowStyle BackColor="#F2F2F2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Campus Head">
                                                <HeaderStyle HorizontalAlign="Center" CssClass="frozen-column frozen-column-1" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="frozen-column frozen-column-1" />
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="gv_chkbx_campus_head_History" 
                                                        runat="server" AutoPostBack="true" Checked='<%#Convert.ToBoolean(Eval("ch_verify")) %>' Enabled="false"/>
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

                                            <asp:TemplateField HeaderText="Format">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlFormatValue" runat="server"
                                                        SelectedValue='<%# Bind("Format") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Objectives/Outcomes">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlObj_OutcomsValue" runat="server"
                                                        SelectedValue='<%# Bind("Obj_Outcoms") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Act & Learning Outcomes">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlLP_Learning_OutcomesValue" runat="server"
                                                        SelectedValue='<%# Bind("LP_Learning_Outcomes") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Curr. Adapted">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCur_AdaptedValue" runat="server"
                                                        SelectedValue='<%# Bind("Cur_Adapted") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cross Curricular Links">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCross_Curricular_LinksValue" runat="server"
                                                        SelectedValue='<%# Bind("Cross_Curricular_Links") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Lesson Eval">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#e3f2f7" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlLesson_EvaluationValue" runat="server"
                                                        SelectedValue='<%# Bind("Lesson_Evaluation") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
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
                                                    <asp:DropDownList ID="gvDdlLesson_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Lesson_Grade") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Subject Knowledge">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSubject_KnowledgeValue" runat="server"
                                                        SelectedValue='<%# Bind("Subject_Knowledge") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Clear LO">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlClear_LoValue" runat="server"
                                                        SelectedValue='<%# Bind("Clear_Lo") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Act & Learning Outcomes">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlTeaching_Learning_OutcomesValue" runat="server"
                                                        SelectedValue='<%# Bind("Teaching_Learning_Outcomes") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Need of Ability Group">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlNeed_Ability_GroupValue" runat="server"
                                                        SelectedValue='<%# Bind("Need_Ability_Group") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Need Ability Group Grade Final">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#20B2AA" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" BackColor="#20B2AA" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallNeed_Ability_Group_Grade_Final" runat="server"
                                                        SelectedValue='<%# Bind("Need_Ability_Group_Grade_Final") %>' CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Collaboration">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCollaborationValue" runat="server"
                                                        SelectedValue='<%# Bind("Collaboration") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HOT and reflection">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlHot_and_ReflectionValue" runat="server"
                                                        SelectedValue='<%# Bind("Hot_and_Reflection") %>' AutoPostBack="false" CssClass="dropdownlist" Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Clear Instruction">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlClear_InstructionValue" runat="server"
                                                        SelectedValue='<%# Bind("Clear_Instruction") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Cross-curricular links">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlTech_Cross_Curricular_LinksValue" runat="server"
                                                        SelectedValue='<%# Bind("Tech_Cross_Curricular_Links") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="AFL">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlAFLValue" runat="server"
                                                        SelectedValue='<%# Bind("AFL") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Self/Peer Assess">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlPeer_AddressValue" runat="server"
                                                        SelectedValue='<%# Bind("Peer_Address") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Support & Feedback">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSuppor_FeedbackValue" runat="server"
                                                        SelectedValue='<%# Bind("Suppor_Feedback") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Time Management">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="LightGray" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlTime_ManagementValue" runat="server"
                                                        SelectedValue='<%# Bind("Time_Management") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
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
                                                    <asp:DropDownList ID="gvDdlTeaching_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Teaching_Grade") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Teaching Grade Final">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#20B2AA" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" BackColor="#20B2AA" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallTeaching_Grade_Final" runat="server"
                                                        SelectedValue='<%# Bind("Teaching_Grade_Final") %>' CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Interaction">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlInteractionValue" runat="server"
                                                        SelectedValue='<%# Bind("Interaction") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Make Connections">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlMake_ConnectionValue" runat="server"
                                                        SelectedValue='<%# Bind("Make_Connection") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Actively Engaged">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlActively_EngagedValue" runat="server"
                                                        SelectedValue='<%# Bind("Actively_Engaged") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Collaborate">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCollaborateValue" runat="server"
                                                        SelectedValue='<%# Bind("Collaborate") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Reflect">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlReflectValue" runat="server"
                                                        SelectedValue='<%# Bind("Reflect") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="HOT">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlHOTValue" runat="server"
                                                        SelectedValue='<%# Bind("HOT") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Communicate Effectively">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#c4f2c4" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCommunicate_EffectivelyValue" runat="server"
                                                        SelectedValue='<%# Bind("Communicate_Effectively") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
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
                                                    <asp:DropDownList ID="gvDdlStudent_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Student_Grade") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Learning Skills Grade Final">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#20B2AA" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" BackColor="#20B2AA" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallStudent_Learning_Skills_Grade_Final" runat="server"
                                                        SelectedValue='<%# Bind("Student_Learning_Skills_Grade_Final") %>' CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Self-Disciplined">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSelf_DisciplinedValue" runat="server"
                                                        SelectedValue='<%# Bind("Self_Disciplined") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Positive Relations Students">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlPositive_Relation_StudentValue" runat="server"
                                                        SelectedValue='<%# Bind("Positive_Relation_Student") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Positive Relations Adults">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7d2c3" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlPositive_Relation_AdultValue" runat="server"
                                                        SelectedValue='<%# Bind("Positive_Relation_Adult") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
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
                                                    <asp:DropDownList ID="gvDdlAttitude_Relationship_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Attitude_Relationship_Grade") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Attitudes Relationships Grade Final">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#20B2AA" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" BackColor="#20B2AA" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallAttitudes_Relationships_Grade_Final" runat="server"
                                                        SelectedValue='<%# Bind("Attitudes_Relationships_Grade_Final") %>' CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Positive Relations Peers">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCare_Classroom_Positive_Relationship_PeersValue" runat="server"
                                                        SelectedValue='<%# Bind("Care_Classroom_Positive_Relationship_Peers") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Positive Relations Adults">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCare_Classroom_Relation_AdultValue" runat="server"
                                                        SelectedValue='<%# Bind("Care_Classroom_Relation_Adult") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Settled Well">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSettled_WellValue" runat="server"
                                                        SelectedValue='<%# Bind("Settled_Well") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Caring/ Sharing">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCaring_SharingValue" runat="server"
                                                        SelectedValue='<%# Bind("Caring_Sharing") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Listen Follow Instructions">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlListen_Follow_InstructionValue" runat="server"
                                                        SelectedValue='<%# Bind("Listen_Follow_Instruction") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Teacher Sen Childrens Needs">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlTeacher_Children_NeedsValue" runat="server"
                                                        SelectedValue='<%# Bind("Teacher_Children_Needs") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
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
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#f7f7cd" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlCare_Classroom_GradeValue" runat="server"
                                                        SelectedValue='<%# Bind("Care_Classroom_Grade") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Care And Classroom Routines Grade Final">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#20B2AA" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" BackColor="#20B2AA" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallCare_And_Classroom_Routines_Grade_Final" runat="server"
                                                        SelectedValue='<%# Bind("Care_And_Classroom_Routines_Grade_Final") %>' CssClass="dropdownlist"  Enabled="false"> 
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Students Progress">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallProgress_Student_Progress" runat="server"
                                                        SelectedValue='<%# Bind("Student_Progress") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Overall Lesson Grade">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallProgress_overall_lesson_grade" runat="server"
                                                        SelectedValue='<%# Bind("Overall_Lesson_Grade") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Student Progress Grade Final">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#20B2AA" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" BackColor="#20B2AA" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallStudent_Progress_Grade_Final" runat="server"
                                                        SelectedValue='<%# Bind("Student_Progress_Grade_Final") %>' CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="OS" Value="OS"></asp:ListItem>
                                                        <asp:ListItem Text="G" Value="G"></asp:ListItem>
                                                        <asp:ListItem Text="A" Value="A"></asp:ListItem>
                                                        <asp:ListItem Text="UA" Value="UA"></asp:ListItem>
                                                        <asp:ListItem Text="NA" Value="NA"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lesson Planning Grade Final">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#20B2AA" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" BackColor="#20B2AA" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlOverallLesson_Planning_Grade_Final" runat="server"
                                                        SelectedValue='<%# Bind("Lesson_Planning_Grade_Final") %>' CssClass="dropdownlist"  Enabled="false">
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
                                                    <asp:TextBox ID="gvDdlOverallProgress_EBI1" runat="server" Text='<%#Eval("EBI1") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gvDdlOverallProgress_EBI2" runat="server" Text='<%#Eval("EBI2") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" CssClass="hide" />
                                                <ItemStyle HorizontalAlign="Left" CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:TextBox ID="gvDdlOverallProgress_EBI3" runat="server" Text='<%#Eval("EBI3") %>' CssClass="form-control" Style="min-width: 150px;"></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="SIQA Endorsed">
                                                <HeaderStyle HorizontalAlign="Center" BackColor="#ffffff" ForeColor="#000000" Font-Size="Smaller" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemTemplate>
                                                    <asp:DropDownList ID="gvDdlSiqa_EndorsedValue" runat="server"
                                                        SelectedValue='<%# Bind("Siqa_Endorsed") %>' AutoPostBack="false" CssClass="dropdownlist"  Enabled="false">
                                                        <asp:ListItem Text="--Select--" Value=""></asp:ListItem>
                                                        <asp:ListItem Text="YES" Value="YES"></asp:ListItem>
                                                        <asp:ListItem Text="NO" Value="NO"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Consolidation ID">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                                <ItemTemplate>
                                                    <asp:HiddenField runat="server" ID="gvHfConsolidatio_IdValue" Value='<%#Eval("Consolidatio_Id")%>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--------------------%>













                                            <%--------------------%>
                                        </Columns>
                                        <SelectedRowStyle ForeColor="SlateGray" />
                                        <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                        <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                        <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                    </asp:GridView>


                                </div>
                            </div>

                        </div>
                    </div>
                    <%--LO History End--%>
                </div>
        </ContentTemplate>

    </asp:UpdatePanel>



    <!-- Include Select2 CSS -->
    <link href="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/css/select2.min.css" rel="stylesheet" />

    <!-- Include jQuery (necessary for Select2) -->
    <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js"></script>

    <!-- Include Select2 JS -->
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/select2@4.1.0-rc.0/dist/js/select2.min.js"></script>
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

        .pbarnew {
            position: fixed;
            top: 50%;
            left: 50%;
            transform: translate(-50%, -50%);
            z-index: 10000; /* Ensure it's on top of other elements */
            display: none;
        }
    </style>

    <script type="text/javascript">
        function SetActiveTab() {

            event.preventDefault();
            //$(".saved").fadeIn(500).fadeOut(500);
            $('a[href="#menu1"]').click()
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



