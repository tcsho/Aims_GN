<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="UploadStudentForecastedGrade.aspx.cs" Inherits="PresentationLayer_TCS_UploadStudentForecastedGrade" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <style type="text/css">
                .btn-custom {
                    padding: 10px 16px;
                    font-size: 11px;
                    height: 34px;
                }

                .lable-danger {
                    font-size: 14px !important
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
            <script type="text/javascript">
                function openModal() {

                    //$('#myModal').modal('show');
                    $('#myModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModal() {

                    $('#myModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
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
                                                <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Upload Student Forecasted Grade"></asp:Label>
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
                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                    <%--                <tr style="width: 100%">
                    <td class="titlesection" align="left" colspan="2">
                        CIE Data Upload
                    </td>
                </tr>--%>

                    <tr id="UplodDesc" runat="server" visible="true">
                        <td style="font-size: x-large" colspan="2">Step 1: Select "Session", "Result Month" and "GLevel".
                            <br />
                            Step 2: Click "Choose File" and browse the forecasted grades excel file to upload. If there are more than 10,000 records, divide them into separate sheets and name them "result1," "result2," etc.
                            <br />
                            Step 3: Click "Upload File."
                            <br />
                            Step 4: Once the data has been uploaded, select "Mapping" to begin mapping with actual result file.
                            <br />
                            Step 5: Click "Save" to save the data.
                        </td>

                    </tr>
                </table>
               <%--   <div class="row" style="padding: 10px 0px">
                    <div class="col-lg-12">--%>
                        <p runat="server" id="showerror" >
                            <asp:Label runat="server" ID="lblerror" style="font-size: x-large; color:green" ></asp:Label>
                        </p>
                 <%--   </div>
                </div>--%>
                <div class="row" style="padding: 10px 0 0 0">
                    <div class="col-lg-4">
                        <label>
                            <asp:RequiredFieldValidator ID="rfddlSession" ValidationGroup="validate" CssClass="label label-danger" ControlToValidate="ddlSession" InitialValue="0" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator></label>
                        <div class="input-group">
                            <label class="input-group-addon">
                                Session
                            </label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSession" AutoPostBack="true" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <label>
                            <asp:RequiredFieldValidator ID="rfddlResultMonth" ValidationGroup="validate" CssClass="label label-danger" ControlToValidate="ddlResultMonth" InitialValue="0" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator></label>
                        <div class="input-group">
                            <label class="input-group-addon">
                                Result Month
                            </label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlResultMonth">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <label>
                            <asp:RequiredFieldValidator ID="rfddlGlevel" ValidationGroup="validate" CssClass="label label-danger" ControlToValidate="ddlGlevel" InitialValue="0" runat="server" ErrorMessage="Required"></asp:RequiredFieldValidator></label>
                        <div class="input-group">
                            <label class="input-group-addon">GLevel</label>
                            <asp:DropDownList runat="server" CssClass="form-control" ID="ddlGlevel">
                                <asp:ListItem Value="0">Select</asp:ListItem>
                                <asp:ListItem Value="GCE AS & A Level">GCE AS & A Level</asp:ListItem>
                                <asp:ListItem Value="GCE O Level">GCE O Level</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                </div>
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <label>
                            <asp:RequiredFieldValidator ID="rf1" runat="server" CssClass="label label-danger" ControlToValidate="FileUpload1" ValidationGroup="validate">Required</asp:RequiredFieldValidator>
                        </label>
                        <div class="input-group" style="margin-bottom: 0px; width: 100%">
                            <asp:FileUpload runat="server" CssClass="form-control" ID="FileUpload1" />
                            <asp:LinkButton runat="server" ID="btnValidate" ValidationGroup="validate" CssClass="btn btn-info btn-custom input-group-addon" OnClick="btnValidate_Click"><i class="fa fa-upload"></i>&nbsp;&nbsp;&nbsp;Upload File</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnmapping"  CssClass="btn btn-info btn-custom input-group-addon" OnClick="btnmapping_Click"><i class="fa fa-upload"></i>&nbsp;&nbsp;&nbsp;Mapping</asp:LinkButton>
                            <%--<asp:LinkButton runat="server" ID="btnSave" CssClass="btn btn-info btn-custom input-group-addon" Enabled="false" OnClick="btnSave_Click"><i class="fa fa-save"></i>&nbsp;&nbsp;&nbsp;Save</asp:LinkButton>--%>
                            <asp:LinkButton runat="server" ID="btnSave" CssClass="btn btn-info btn-custom input-group-addon"  OnClick="btnSave_Click"><i class="fa fa-save"></i>&nbsp;&nbsp;&nbsp;Save</asp:LinkButton>
                            <asp:LinkButton runat="server" ID="btnReset" CssClass="btn btn-info btn-custom input-group-addon" OnClick="btnReset_Click"><i class="fa fa-refresh"></i>&nbsp;&nbsp;&nbsp;Reset</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4">
                        <div class="input-group">
                            <asp:RadioButtonList ID="rdbtn"  runat="server" CssClass="RadioButtonWidth" OnSelectedIndexChanged="rdbtn_SelectedIndexChanged" AutoPostBack="true" RepeatDirection="Horizontal">
                                <%--<asp:ListItem Value="1">Mapped Students</asp:ListItem>--%>
                                <asp:ListItem Value="2" Selected="True">Unmapped Students</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>
              <%--  <div class="row" style="padding: 10px 0px">
                    <div class="col-lg-12">
                        <p runat="server" id="showerror" class="text-center">
                            <asp:Label runat="server" ID="lblerror" class="label label-danger text-center" Style="font-size: 18px"></asp:Label>
                        </p>
                    </div>
                </div>--%>
                <br />
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label style="">Student(s) List</label>
                                <asp:GridView ID="gv_details" AutoGenerateColumns="False" OnPreRender="gv_details_PreRender" OnRowDataBound="gv_details_RowDataBound" CssClass="datatable table table-bordered table-condensed table-responsive" runat="server"
                                    EmptyDataText="No row found" ShowHeader="true" EmptyDataRowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true">
                                    <Columns>
                                        <asp:BoundField DataField="School Group" HeaderText="School Group" />
                                        <asp:BoundField DataField="Centre" HeaderText="Centre" />
                                        <asp:BoundField DataField="Cand" HeaderText="Cand" />
                                        <asp:BoundField DataField="Centre Name" HeaderText="Centre Name" />
                                        <asp:BoundField DataField="Region" HeaderText="Region" />
                                        <asp:BoundField DataField="Candidate Name" HeaderText="Candidate Name(CIE)" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                        <asp:BoundField DataField="DOB" HeaderText="DOB" />
                                        <asp:BoundField DataField="Citzenship No" HeaderText="Citzenship No" />
                                        <asp:TemplateField HeaderText="Student ERP No">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="gv_hfUP_Id" runat="server" Value='<%# Eval("UP_Id")%>' />
                                                <span style="display: none"><%# Eval("Student Id") %></span>
                                                <asp:TextBox runat="server" Style="width: 100%; font-size: 11px; padding: 0 2px; margin: 0" Enabled="false" ID="txtStudentID" OnTextChanged="txtStudentID_TextChanged" CausesValidation="true" AutoPostBack="true" CssClass="form-control" Text='<%# Eval("Student Id") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="StudentName" HeaderText="Student Name(ERP)" />
                                        <asp:BoundField DataField="Series" HeaderText="Series" />
                                        <asp:BoundField DataField="Qual" HeaderText="Qual" />
                                        <%--<asp:BoundField DataField="Syllabus" HeaderText="Syllabus" />
                                        <asp:BoundField DataField="Title" HeaderText="Title" />
                                        <asp:BoundField DataField="Result" HeaderText="Result" />--%>
                                        <asp:BoundField DataField="Private Cand" HeaderText="Private Cand" />
                                        <asp:BoundField DataField="Oral Endorsement" HeaderText="Oral Endorsement" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                    </Columns>
                                    <HeaderStyle CssClass="tableheader" />
                                </asp:GridView>
                                <asp:GridView ID="GridView1" AutoGenerateColumns="False" Visible="false" OnPreRender="GridView1_PreRender" CssClass="datatable table table-bordered table-condensed table-responsive" runat="server"
                                    EmptyDataText="No row found" ShowHeader="true" EmptyDataRowStyle-HorizontalAlign="Center" ShowHeaderWhenEmpty="true">
                                    <Columns>
                                        <asp:BoundField DataField="School Group" HeaderText="School Group" />
                                        <asp:BoundField DataField="Centre" HeaderText="Centre" />
                                        <asp:BoundField DataField="Cand" HeaderText="Cand" />
                                        <asp:BoundField DataField="Centre Name" HeaderText="Centre Name" />
                                        <asp:BoundField DataField="Region" HeaderText="Region" />
                                        <asp:BoundField DataField="Candidate Name" HeaderText="Candidate Name(CIE)" />
                                        <asp:BoundField DataField="Gender" HeaderText="Gender" />
                                        <asp:BoundField DataField="DOB" HeaderText="DOB" />
                                        <asp:BoundField DataField="Citzenship No" HeaderText="Citzenship No" />
                                        <asp:TemplateField HeaderText="Student ERP No">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="gv_hfUP_Id" runat="server" Value='<%# Eval("UP_Id")%>' />
                                                <span style="display: none"><%# Eval("Student Id") %></span>
                                                <%--<asp:TextBox runat="server" Style="width: 100%; font-size: 11px; padding: 0 2px; margin: 0" Enabled="true" ID="txtStudentID" OnTextChanged="txtStudentID_TextChanged" CausesValidation="true" AutoPostBack="true" CssClass="form-control" Text='<%# Eval("Student Id") %>'></asp:TextBox>--%>
                                           <asp:TextBox runat="server" Style="width: 100%; font-size: 11px; padding: 0 2px; margin: 0"  ID="txtStudentID" OnTextChanged="txtStudentID_TextChanged"  AutoPostBack="true" CssClass="form-control" Text='<%# Eval("Student Id") %>'></asp:TextBox>
                                                </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="StudentName" HeaderText="Student Name(ERP)" />
                                        <asp:BoundField DataField="Series" HeaderText="Series" />
                                        <asp:BoundField DataField="Qual" HeaderText="Qual" />
                                        <%--<asp:BoundField DataField="Syllabus" HeaderText="Syllabus" />
                                        <asp:BoundField DataField="Title" HeaderText="Title" />
                                        <asp:BoundField DataField="Result" HeaderText="Result" />--%>
                                        <asp:BoundField DataField="Private Cand" HeaderText="Private Cand" />
                                        <asp:BoundField DataField="Oral Endorsement" HeaderText="Oral Endorsement" />
                                        <asp:BoundField DataField="Status" HeaderText="Status" />
                                    </Columns>
                                    <HeaderStyle CssClass="tableheader" />
                                </asp:GridView>
                            
                        </div>
                    </div>
                </div>
            </div>

            <div class="modal fade" id="myModal" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                &times;</button>
                            <h4 class="modal-title">Student Varify</h4>
                        </div>
                        <div class="modal-body">

                            <div class="row">
                                <div class="col-xs-12 text-center">
                                    <h2><u>STUDENT NAME</u></h2>
                                    <br />
                                    <asp:HiddenField ID="hfUP_Id" runat="server" />
                                    <asp:HiddenField ID="hpStdID" runat="server" />
                                    <asp:Label ID="lblStudentName1" runat="server" CssClass="h2"></asp:Label><br />
                                    <br />
                                    <asp:Label ID="lblStudentName2" runat="server" CssClass="h2"></asp:Label>
                                </div>
                                <div class="col-xs-12 text-center">
                                    <i runat="server" id="iconSuccess" visible="false" class="fa fa-check-circle-o text-success fa-5x"></i>
                                    <i runat="server" id="iconFailed" visible="false" class="fa fa-close text-danger fa-5x"></i>
                                </div>
                            </div>


                            <div class="row">
                                <br />
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnMapped" Text="Mapped" CssClass="btn btn-primary"
                                    CausesValidation="true" ValidationGroup="Mapped" />
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnValidate" />
            <asp:PostBackTrigger ControlID="btnSave" />
            <asp:PostBackTrigger ControlID="btnReset" />
            <asp:PostBackTrigger ControlID="btnMapped" />
            <asp:PostBackTrigger ControlID="rdbtn" />
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
