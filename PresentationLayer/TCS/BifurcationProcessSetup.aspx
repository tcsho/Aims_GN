<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="BifurcationProcessSetup.aspx.cs"
    Inherits="PresentationLayer_BifurcationProcessSetup" %>

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
                .form-check-input tbody tr td input[type=radio] {
                    margin: 4px 7px 0;
                    height: 15px;
                    width: 15px;
                }

                .form-check-input tbody tr td label {
                    position: relative;
                    top: -2px;
                }




                .checkbox .btn, .checkbox-inline .btn {
                    padding-left: 2em;
                    min-width: 8em;
                }

                .checkbox label, .checkbox-inline label {
                    text-align: left;
                    padding-left: 0.5em;
                }

                .checkbox input[type="checkbox"] {
                    float: none;
                }
            </style>

            <script type="text/javascript">
                function openModal() {
                    //                    $('#myModal').modal('show');
                    $('#myModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <%--<script type="text/javascript">
                function CheckAll(chk) {
                    debugger;
                    var gv = document.getElementById('<%= gv_details.ClientID %>');
                    var chkAll = chk.checked;
                    var checkboxes = gv.getElementsByTagName("input");
                    for (var i = 0; i < checkboxes.length; i++) {
                        if (checkboxes[i].type == "checkbox") {
                            checkboxes[i].checked = chkAll;
                        }
                    }
                }
            </script>--%>

            <script type="text/javascript">
                function CheckAll(chk) {
                    var gv = document.getElementById('<%= gv_details.ClientID %>');
                    var chkAll = chk.checked;
                    var checkboxes = gv.getElementsByTagName("input");

                    for (var i = 0; i < checkboxes.length; i++) {
                        if (checkboxes[i].type == "checkbox" && checkboxes[i].getAttribute("disabled") !== "disabled") {
                            checkboxes[i].checked = chkAll;
                        }
                    }
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
            <script type="text/javascript">

                Sys.Application.add_init(function () {
                    // Initialization code here, meant to run once.

                    jq(document).ready(document_Ready);

                    function document_Ready() {

                        jq(document).ready(function () {

                            //****************************************************************
                            try {
                                jq('table.datatable').DataTable({
                                    destroy: true,
                                    // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                                    //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                        "<'row'<'col-sm-12'tr>>" +
                                        //                     "<'row'<'col-sm-12'l>>" +
                                        "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    "columnDefs": [

                                        { orderable: false, targets: [0] } //disable sorting on toggle button
                                    ]

                                    ,
                                    tableTools:
                                    { //Start of tableTools collection
                                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                        "aButtons":
                                            [ //start of button main/master collection



                                                { // ******************* Start of child collection for export button
                                                    "sExtends": "collection",
                                                    "sButtonText": "<span class='glyphicon glyphicon-export'></span>",
                                                    "sToolTip": "Export Data",
                                                    "aButtons":
                                                        [ //start of button export buttons collection

                                                            // ******************* Start of copy button
                                                            {
                                                                "sExtends": "copy",
                                                                "sButtonText": "<span class='glyphicon glyphicon-copy'></span> Copy Contents",
                                                                "sToolTip": "Copy Data"
                                                                , "mColumns": [6]
                                                            } // ******************* end of copy button

                                                            // ******************* Start of csv button
                                                            , {
                                                                'sExtends': 'csv',
                                                                'bShowAll': false // ,'sFileName': "DataInCSVFormat.csv"
                                                                ,
                                                                "sFileName": "DataInCSVFormat - *.csv",
                                                                "sToolTip": "Save as CSV",
                                                                //'sButtonText': 'Save as CSV',
                                                                "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
                                                                "sNewLine": "auto"
                                                                , "mColumns": [6]
                                                            }  // ******************* end of csv button

                                                            // ******************* Start of excel button
                                                            , {
                                                                'sExtends': 'xls',
                                                                'bShowAll': false,
                                                                "sFileName": "DataInExcelFormat.xls",
                                                                //'sButtonText': 'Save to Excel',
                                                                "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                                                                "sToolTip": "Save as Excel"
                                                                , "mColumns": [6]
                                                            }  // ******************* End of excel button


                                                            // ******************* Start of PDF button
                                                            , {
                                                                'sExtends': "pdf",
                                                                'bShowAll': false,
                                                                "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                                                                //'sButtonText': 'Save to PDF',
                                                                "sFileName": "DataInPDFFormat.pdf",
                                                                "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                                                                , "mColumns": [6]
                                                                //,"sPdfMessage": "Your custom message would go here."
                                                            } // *********************  End of PDF button 

                                                        ]// ******************* end of Export buttons collection
                                                }    // ******************* end of child of export buttons collection
                                            ] // ******************* end of button master Collection
                                    } // ******************* end of tableTools
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 100, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true , "order": [[6, "asc"]]
                                    , "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": true
                                    , //--- Dynamic Language---------
                                    "oLanguage": {
                                        "sZeroRecords": "There are no Records that match your search critera",
                                        "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
                                        "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                                        "sInfoEmpty": "Showing 0 to 0 of 0 records",
                                        "sInfoFiltered": "(filtered from _MAX_ total records)",
                                        "sEmptyTable": 'No Rows to Display.....!',
                                        "sSearch": "Search :"
                                    }
                                }
                                );
                            }
                            catch (err) {
                                //alert('datatable ' + err);
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
                function ViewRejectionModal() {
                    $('#RejectionModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function ViewBifurcationcenterModal() {
                    $('#ViewBifurcationcenterModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>


            <script type="text/javascript">
                document.addEventListener('DOMContentLoaded', function () {
                    validate();
                     });
                function validate() {
                     
                    var dateControl = document.getElementById('<%= text_date.ClientID %>');
                    var today = new Date();
                    var tomorrow = new Date();
                    tomorrow.setDate(today.getDate() + 1);
                    var day = ("0" + tomorrow.getDate()).slice(-2);
                    var month = ("0" + (tomorrow.getMonth() + 1)).slice(-2);
                    var year = tomorrow.getFullYear();
                    var minDate = year + '-' + month + '-' + day;
                    dateControl.setAttribute('min', minDate);
                
                }
            </script>

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Bifuration Process Setup"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td>

                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr id="tr4" runat="server">
                                    <td style="width: 37%;"></td>
                                    <td style="width: 50%;"></td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabelMandatory40" style="width: 37%">Session:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="true" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr id="trRegion" runat="server">
                                    <td class="TextLabelMandatory40" style="width: 37%;">Region:
                                    </td>
                                    <td valign="top" style="width: 50%;">
                                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="218px"
                                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>


                                        <br />
                                    </td>
                                    <td valign="top" align="right"></td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabel40" style="width: 37%"><strong>Term:</strong>
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlterm" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="ddlterm_SelectedIndexChanged1" AutoPostBack="true"
                                            Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>


                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabel40" style="width: 37%"><strong>Bifurcation Process Date:</strong>
                                    </td>
                                    <td align="left" style="width: 50%">
                                        
                                         &nbsp;<asp:TextBox ID="text_date" runat="server" CssClass="textbox" MaxLength="50" Width="29%"></asp:TextBox>
                                       <%-- <asp:TextBox ID="text_date" runat="server" CssClass="textbox" MaxLength="50" Width="29%" type="date"></asp:TextBox>--%>
                                        <%--   <asp:TextBox ID="text_date" runat="server" CssClass="form-control" type="datetime-local" Style="width: 30%;"></asp:TextBox>--%>

                                          <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="text_date">
                                        </cc1:CalendarExtender>
                                    </td>
                                </tr>
                                <%--   <tr id="trCenter" runat="server" style="width: 50%;">
                                    <td align="right" class="TextLabelMandatory40" style="width: 37%">Center*:
                                    </td>
                                    <td valign="top" style="width: 50%;">
                                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="218px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnShowAll" runat="server" CssClass="btn btn-info" Text="Show All Records"
                                            Width="450px" OnClick="btnShowAll_Click"></asp:Button>
                                    </td>
                                    <td align="right" valign="top"></td>
                                </tr>--%>

                                <tr style="width: 50%">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 37%;">&nbsp;
                                    </td>
                                    <td align="left" style="width: 60%">&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%"></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="12">
                                        <%-- <asp:Button ID="btnViewReport" runat="server" class="button" OnClick="btnViewReport_Click"
                                            Text="View Report" ValidationGroup="s" Visible="False" Width="96px" />--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="12">
                                        <asp:Label runat="server" ID="lblGridStatus" CssClass="TextLabelMandatory40" ForeColor="Red"
                                            Text="">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td id="tdSearch" runat="server" class="titlesection" colspan="7" visible="false">&nbsp; List of Bifurcated Students
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="12">
                                        <p>
                                        </p>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td>
                                        <asp:Button ID="Button3" runat="server" class="button" OnClick="btnbifuration_Click" Text="Save" data-dismiss="modal" Style="width: 228px; margin-left: 37%" />
                                    </td>
                                </tr>



                                <tr id="Tr3" runat="server" style="width: 100%">
                                    <td style="width: 100%">
                                        <asp:GridView ID="gv_details" runat="server" CssClass="datatable table table-striped table-bordered table-hover" AutoGenerateColumns="False" OnRowDataBound="gv_details_RowDataBound">


                                            <Columns>
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkSelect" runat="server" ValidationGroup='<%# Eval("Active") %>' />
                                                    </ItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:CheckBox ID="chkSelectAll" Style="color: black;" runat="server" Text="Select All" onclick="CheckAll(this);" />
                                                    </HeaderTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                </asp:TemplateField>



                                                <asp:BoundField DataField="Center_ID" HeaderText="Center Id">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                                    <HeaderStyle HorizontalAlign="left" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="left" Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Term" HeaderText="Term">
                                                    <HeaderStyle HorizontalAlign="left" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="left" Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Active" HeaderText="status">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Is_Processed" HeaderText="IsProcessed">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <%--   <asp:BoundField DataField="Grade_Id" HeaderText="Grade_Id">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TermGroupID" HeaderText="TermGroupID">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>--%>

                                                <%-- <asp:BoundField DataField="Region_Name" HeaderText="Region">
                                                  
                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                                  
                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Class_Name1" HeaderText="Class">
                                                  
                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                                  
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>--%>



                                                <%--     <asp:BoundField DataField="DaysPresent" HeaderText="Days Present">

                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="EmailSent" HeaderText="Email Sent">

                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Acknowledgement" HeaderText="Parent Acknowledgement">

                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="IsSyncResult" HeaderText="Sync with Erp">

                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>--%>
                                            </Columns>
                                            <SelectedRowStyle ForeColor="SlateGray" />
                                            <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                            <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                            <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <%-- <tr>
                                    <td align="right" colspan="12">
                                        <asp:Button ID="Button3" runat="server" class="button" OnClick="btnbifuration_Click"  Text="Bifuration Process" style="width:245px" />
                                    </td>
                                </tr>--%>
                                <tr runat="server" style="width: 100%">
                                    <td style="width: 100%"></td>
                                </tr>
                                <tr id="btns" runat="server" visible="false">
                                    <td colspan="3" style="height: 6px; text-align: center;">&nbsp;
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr id="trButtons" runat="server" aliign="center" style="width: 100%">
                                    <td align="center" style="height: 19px; text-align: center">&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>


            <%--*************************************************************--%>
            <div class="container">

                <div class="modal fade" id="RejectionModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Bifurcation Executed For Centres List</h4>
                            </div>
                            <div class="modal-body">
                                <%-- <p>
                                    <asp:Label ID="Label4" runat="server" CssClass="TextLabelMandatory40" Text="Centre Name(s)"></asp:Label>
                                </p>--%>
                                <p>
                                    <asp:Label ID="lblbifcentre" runat="server" CssClass="TextLabelMandatory40" Text=""></asp:Label>
                                </p>


                            </div>
                            <div class="modal-footer">
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <%-- *************************************************************--%>

            <%--*************************************************************--%>
            <div class="container">

                <div class="modal fade" id="ViewBifurcationcenterModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Bifurcated data for Selected Region is already available, Would you like to proceed...?</h4>
                            </div>
                            <div class="modal-body">
                                <%-- <p>
                                    <asp:Label ID="Label4" runat="server" CssClass="TextLabelMandatory40" Text="Centre Name(s)"></asp:Label>
                                </p>--%>
                                <%-- <p>
                                    <asp:Label ID="Label2" runat="server" CssClass="TextLabelMandatory40" Text=""></asp:Label>
                                </p>--%>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnproceed" runat="server" class="btn btn-default" Text="Yes" OnClick="btnproceed_Click" />
                                <button type="button" class="btn btn-default" data-dismiss="modal">No</button>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <%-- *************************************************************--%>
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
</asp:Content>

