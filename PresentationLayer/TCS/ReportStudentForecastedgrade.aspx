<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ReportStudentForecastedgrade.aspx.cs" Inherits="PresentationLayer_TCS_ReportStudentForecastedgrade" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <style type="text/css">
                .btn-custom {
                    padding: 10px 16px;
                    font-size: 11px;
                    height: 34px;
                }

                .table-responsive {
                    overflow-x: initial !important;
                }

                .aspNetDisabled {
                    background-image: -webkit-linear-gradient(top,rgb(213 213 213 / 0.80) 0,rgb(213 213 213 / 80%) 100%) !important;
                    color: #3B5998;
                    cursor: not-allowed !important;
                    pointer-events: none
                }

                .titlesection {
                    height: auto;
                }

                .table {
                    margin-bottom: 0px;
                }

                .RadioButtonWidth label {
                    margin-right: 30px;
                    margin-left: 5px
                }
            </style>
            <script type="text/javascript">

                Sys.Application.add_init(function () {
                    // Initialization code here, meant to run once.

                    jq(document).ready(document_Ready);

                    function document_Ready() {

                        jq(document).ready(function () {

                            //****************************************************************
                            try {
                                $('table.datatable').DataTable({
                                    destroy: true,
                                    "dom": 'Blfrtip',

                                    buttons: [

                                        {
                                            extend: 'excel',
                                            title: 'Student Forecasted Grade'
                                        }
                                    ],
                                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                });
                            }
                            catch (err) {
                                // alert('datatable ' + err);
                            }

                            //****************************************************************



                        }
                        );

                    } //end of documnet_ready()



                    //Re-bind for callbacks
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(function () {
                        jq(document).ready(document_Ready);
                        //            document_Ready();
                        //            alert('call back done');
                    }
                    );

                });

            </script>

            <div class="container-fluid">
                <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                    border="0">
                    <tbody>
                        <tr>
                            <td>
                                <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td style="height: 100%" width=".5%"></td>
                                            <td id="tdFrmHeading" class="formheading">
                                                <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Report Student Forecasted Grade"></asp:Label>
                                                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                    border="0" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>

                    </tbody>
                </table>
                <div class="row" style="padding: 10px 0 0 0">
                    <div class="col-lg-3">
                        <label>
                            <asp:RequiredFieldValidator ID="rfddlSession" ValidationGroup="search" CssClass="label label-danger" ControlToValidate="ddlSession" InitialValue="0" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator></label>
                        <div class="input-group">
                            <label class="input-group-addon">
                                Session
                            </label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSession">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <label>
                            <asp:RequiredFieldValidator ID="rfddlResultMonth" ValidationGroup="search" CssClass="label label-danger" ControlToValidate="ddlResultMonth" InitialValue="0" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator></label>
                        <div class="input-group">
                            <label class="input-group-addon">
                                Result Month
                            </label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlResultMonth">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-3">
                        <br />
                        <div class="input-group">
                            <label class="input-group-addon">GLevel</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlGlevel">
                                <asp:ListItem Value="All" Selected="True">All</asp:ListItem>
                                <asp:ListItem Value="GCE AS & A Level">GCE AS & A Level</asp:ListItem>
                                <asp:ListItem Value="GCE O Level">GCE O Level</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>


                    <div class="col-lg-3">
                        <br />
                        <asp:LinkButton runat="server" ID="btnSearch" ValidationGroup="search" CssClass="btn btn-custom btn-info" OnClick="btnSearch_Click"><i class="fa fa-search"></i>&nbsp;&nbsp;&nbsp;Search</asp:LinkButton>
                    </div>
                </div>
                <div class="row" style="border-bottom: solid 2px rgb(0 0 0 / 0.25); padding: 10px 0px">
                    <div class="col-lg-4">
                        <div class="input-group">
                            <asp:RadioButtonList ID="rdbtn" Visible="false" runat="server" CssClass="RadioButtonWidth" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                                <asp:ListItem Value="1" Selected="True">Student Wise</asp:ListItem>
                                <asp:ListItem Value="2">Campus Wise</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
                <%--  <div class="col-lg-4">
                        <div class="input-group">
                            <label class="input-group-addon">Center</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlCenter"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="btn-group">
                            <asp:LinkButton runat="server" ID="btnFetch" CssClass="btn btn-info btn-custom"><i class="fa fa-search"></i>&nbsp;&nbsp;&nbsp;Fetch</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnDownload" CssClass="btn btn-info btn-custom"><i class="fa fa-download"></i>&nbsp;&nbsp;&nbsp;Download</asp:LinkButton>
                        </div>
                    </div>
                </div>--%>
                <%-- <div class="row" style="padding: 10px 0px">
                    <div class="col-lg-12">
                        <div>
                            <asp:RequiredFieldValidator ID="rf1" runat="server" Font-Size="Small" CssClass="label label-danger" ControlToValidate="FileUpload1" ValidationGroup="Validate">Required</asp:RequiredFieldValidator>
                        </div>
                        <div class="input-group" style="margin-bottom: 0px; width: 100%">
                            <asp:FileUpload runat="server" CssClass="form-control" ID="FileUpload1" />
                            <asp:LinkButton runat="server" ID="btnValidate" ValidationGroup="Validate" CssClass="btn btn-info btn-custom input-group-addon" OnClick="btnValidate_Click"><i class="fa fa-upload"></i>&nbsp;&nbsp;&nbsp;Upload & Validate</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnSave" CssClass="btn btn-info btn-custom input-group-addon" Enabled="false" OnClick="btnSave_Click"><i class="fa fa-save"></i>&nbsp;&nbsp;&nbsp;Save</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnReset" CssClass="btn btn-info btn-custom input-group-addon" OnClick="btnReset_Click"><i class="fa fa-refresh"></i>&nbsp;&nbsp;&nbsp;Reset</asp:LinkButton>
                        </div>
                    </div>
                </div>--%>
                <div class="row" style="padding: 10px 0px">
                    <div class="col-lg-12">
                        <p runat="server" id="showerror" class="text-center">
                            <asp:Label runat="server" ID="lblerror" class="label label-danger text-center" Style="font-size: 18px"></asp:Label>
                        </p>
                    </div>
                </div>
            </div>
            <br />
            <div class="container-fluid" style="margin: 0; padding: 0">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label class="titlesection">List</label>
                            <div class="table-responsive">
                               <asp:GridView ID="gv_details" AutoGenerateColumns="False" OnPreRender="gv_details_PreRender" CssClass="datatable table table-bordered table-condensed" runat="server"
                                    EmptyDataText="No row found" EmptyDataRowStyle-HorizontalAlign="Center" >
                                    <Columns>
                                        <asp:BoundField HeaderText="Student ID" DataField="Student ID" />
                                        <asp:BoundField HeaderText="Student Name" DataField="Student Name" />
                                        <asp:BoundField HeaderText="CNIC" DataField="CNIC" />
 <asp:BoundField HeaderText="Gender" DataField="Gender" />
                                        <asp:BoundField HeaderText="Class Name" DataField="Class Name" />
                                        <asp:BoundField HeaderText="Center Name" DataField="Center Name" />
                                        <asp:BoundField HeaderText="Subject" DataField="Subject" />
                                        <asp:BoundField HeaderText="Achieved Grade" DataField="Achieved Grade" />
                                        <asp:BoundField HeaderText="Forcasted Grade" DataField="Forcasted Grade" />
                                    </Columns>
                                    <HeaderStyle CssClass="tableheader" />
                                </asp:GridView>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
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
</asp:Content>

