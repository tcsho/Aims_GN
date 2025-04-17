<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="Student_ReportCard_Detail.aspx.cs" Inherits="PresentationLayer_TCS_Student_ReportCard_Detail" %>


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

                $(function () {
                    initdropdown();
                })
                function initdropdown() {
                    $('.selectpicker').selectpicker();

                    $('table.datatable').DataTable({
                        destroy: true,
                        dom: 'Blfrtip'
                    });

                }
                function pageLoad(sender, args) {
                    initdropdown();
                }
                Sys.Application.add_load(initdropdown);


            </script>
            <style type="text/css">
                .input-group-btn {
                    width: 70px !important;
                    max-width: 70px
                }

                .input-group-btn, .bootstrap-select > .dropdown-toggle {
                    width: 250px !important;
                    max-width: 250px
                }

                .bootstrap-select.btn-group .dropdown-toggle .filter-option {
                    text-align: center;
                }

                .btn {
                    padding: 2px 12px;
                }

                .custom-btn {
                    width: 100px;
                    height: 28.5px;
                    background: linear-gradient(to bottom,#fff 0,#e0e0e0 100%) !important;
                    padding-top: 5px;
                }

                    .custom-btn:hover {
                        background: linear-gradient(to bottom,#e0e0e0 0,#e4e4e4 100%) !important;
                    }

                .cursor-pointer {
                    cursor: pointer;
                }

                .input-group-addon, .btn {
                    padding: 0px 12px;
                }

                .bootstrap-select.btn-group .dropdown-toggle .filter-option {
                    font-size: 14px;
                }
                .custom-btn {
                    height: auto;
                }
            </style>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-xs-12">
                        <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                            border="0">
                            <tbody>
                                <tr>
                                    <td style="height: 100%" width=".5%"></td>
                                    <td id="tdFrmHeading" class="formheading">
                                        <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Student Report Card Detail"></asp:Label>
                                        <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                            border="0" />
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </div>
                </div>
            </div>
            <br />
            <div class="container bg-primary" style="padding: 10px">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="col-xs-4" align="left">
                            <div class="input-group">
                                <label class="input-group-addon" style="width: 90px">Region*:</label>
                                <asp:DropDownList ID="ddl_region" runat="server" CssClass="selectpicker" data-live-search="true" OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>

                            <div class="input-group" style="margin-top: 2px">
                                <label class="input-group-addon" style="width: 90px">Center*:</label>
                                <asp:DropDownList ID="ddl_center" runat="server" CssClass="selectpicker" data-live-search="true" AutoPostBack="true" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xs-4" align="center">
                            <div class="input-group">
                                <label class="input-group-addon" style="width: 90px">Session*:</label>
                                <asp:DropDownList ID="ddl_session" runat="server" CssClass="selectpicker" data-live-search="true" AutoPostBack="true" OnSelectedIndexChanged="ddl_session_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>

                            <div class="input-group" style="margin-top: 2px">
                                <label class="input-group-addon" style="width: 90px">Class:</label>
                                <asp:DropDownList ID="ddl_class" runat="server" CssClass="selectpicker" data-live-search="true" AutoPostBack="true" OnSelectedIndexChanged="ddl_class_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-xs-4" align="right">
                            <asp:LinkButton runat="server" ID="btnSearch" OnClick="btnSearch_Click" Style="margin-bottom: 2px; padding:2px;" CssClass="btn btn-info custom-btn">Search <i class="fa fa-search"></i></asp:LinkButton><br />
                            <asp:LinkButton runat="server" ID="btnReset" OnClick="btnReset_Click" CssClass="btn btn-info custom-btn" Style="padding:2px;">Reset <i class="fa fa-refresh"></i></asp:LinkButton>
                        </div>
                    </div>

                </div>
            </div>
            <div class="container" style="padding: 10px">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="table-responsive" style="width: 100%; overflow: auto">
                            <asp:GridView ID="gv_details" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" EmptyDataText="No Record Found!" runat="server" CssClass="datatable table table-hover table-responsive"
                                OnPreRender="gv_details_PreRender">
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <Columns>

                                    <asp:BoundField DataField="Region" HeaderText="Region" />
                                    <asp:BoundField DataField="Center" HeaderText="Center" />
                                    <asp:BoundField DataField="Class" HeaderText="Class" />
                                    <asp:BoundField DataField="Section" HeaderText="Section" />
                                    <asp:BoundField DataField="TermGroup_Id" HeaderText="Term" />
                                    <asp:BoundField DataField="Student ID" HeaderText="Student ID" />
                                    <asp:BoundField DataField="Name" HeaderText="Student Name" />
                                    <asp:BoundField DataField="Status" HeaderText="Status" />
                                    <asp:TemplateField HeaderText="URL">
                                        <ItemTemplate>
                                            <a href="<%# Eval("URL") %>" target="_blank"><%# Eval("URL") %></a>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                </Columns>
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
            <asp:PostBackTrigger ControlID="btnReset" />
            <asp:PostBackTrigger ControlID="ddl_region" />
            <asp:PostBackTrigger ControlID="ddl_center" />
            <asp:PostBackTrigger ControlID="ddl_session" />
            <asp:PostBackTrigger ControlID="ddl_class" />

        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%"
                    Width="100%" Style="z-index: 1000" />
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>

