<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="BifurcationPromotedRequest.aspx.cs"
    Inherits="PresentationLayer_BifurcationPromotedRequest" %>

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

                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="List of Bifurcated Students"></asp:Label>
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
                                <tr id="trRegion" runat="server">
                                    <td class="TextLabelMandatory40" style="width: 37%;">Region*:
                                    </td>
                                    <td valign="top" style="width: 50%;">
                                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="218px"
                                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                       <%-- <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click"
                                            Text="Detained Students"></asp:Button>
                                        <asp:Button ID="btnShow" runat="server" CssClass="btn btn-warning" OnClick="btnShowSubmitted_Click"
                                            Text="Discretionary Requests"></asp:Button>
                                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" OnClick="btnProcessed_Click"
                                            Text="Action Taken By RD"></asp:Button>--%>
                                        <br />
                                    </td>
                                    <td valign="top" align="right"></td>
                                </tr>
                                <tr id="trCenter" runat="server" style="width: 50%;">
                                    <td align="right" class="TextLabelMandatory40" style="width: 37%">Center*:
                                    </td>
                                    <td valign="top" style="width: 50%;">
                                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="218px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnShowAll" runat="server" CssClass="btn btn-info" Text="Show All Records"
                                            Width="485px" OnClick="btnShowAll_Click"></asp:Button>
                                    </td>
                                    <td align="right" valign="top"></td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabelMandatory40" style="width: 37%">Session*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabel40" style="width: 37%">Class:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabel40" style="width: 37%">Term:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlterm" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlterm_SelectedIndexChanged" Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
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
                                        <asp:Button ID="btnViewReport" runat="server" class="button" OnClick="btnViewReport_Click"
                                            Text="View Report" ValidationGroup="s" Visible="False" Width="96px" />
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
                                    <td id="tdSearch" runat="server" class="titlesection" colspan="7" visible="false">&nbsp; List of Bifurcated Students [Class 8]
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="12">
                                        <p>
                                        </p>
                                    </td>
                                </tr>
                                <tr id="Tr3" runat="server" style="width: 100%">
                                    <td style="width: 100%">
                                        <asp:GridView ID="gv_details" runat="server" DataKeyNames="TermGroupID,PromotedTo" AutoGenerateColumns="False" CssClass="datatable table table-hover table-responsive"
                                            OnPreRender="gv_details_PreRender" OnRowDataBound="gv_details_RowDataBound">
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="YouText" visible="false">
                                                    <ItemTemplate>
                                                      
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Student_No" HeaderText="Student No">
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                                    <HeaderStyle CssClass="hide" />
                                                    <ItemStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Submit_RD" HeaderText="Submit_RD">
                                                    <HeaderStyle HorizontalAlign="Center" Width="75px" />
                                                    <ItemStyle HorizontalAlign="Left" Width="75px" />
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Section_Name" HeaderText="Section ">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Section_Id" HeaderText="Section ">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="RD_Approval" HeaderText="RD Approval ">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="List of Students ">
                                                    <ItemStyle HorizontalAlign="Center" Width="100%" />
                                                    <ItemTemplate>
                                                        <table cellpadding="0" cellspacing="0" style="table-layout: fixed; height: 92%; width: 100%; vertical-align: top;">
                                                            <tr id="Tr8" runat="server" style="width: 100%">
                                                                <td style="width: 35%; color: Black; font-size: medium; font-weight: bold;">
                                                                    <p>
                                                                    </p>
                                                                </td>
                                                            </tr>
                                                            <tr class="tr2" style="height: 72%">
                                                                <td align="left" style="word-wrap: break-word" valign="top">

                                                                    <table cellpadding="0" cellspacing="0" style="table-layout: fixed; height: 92%; width: 100%; vertical-align: top;">
                                                                        <tr style="width: 100%">
                                                                            <td style="width: 35%; font-size: medium; font-weight: bold">
                                                                                <asp:Label runat="server" ID="lblerror" class="label label-danger text-center" Style="font-size: 18px"></asp:Label>
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; font-weight: bold">Student # :
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold">
                                                                                <%# Eval("Student_No")%>
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; font-weight: bold">Student Name :
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold">
                                                                                <%# Eval("StudentName")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="width: 100%">
                                                                            <td style="width: 35%; font-size: medium; font-weight: bold">Class-Section:
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold;">
                                                                                <%# Eval("Class_Name")%>-
                                                                                <%# Eval("Section_Name")%>
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; font-weight: bold">Session:
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold;">
                                                                                <%# Eval("Description")%>
                                                                            </td>
                                                                        </tr>
                                                                        <tr style="width: 100%">
                                                                            <td style="width: 35%; font-size: medium; font-weight: bold">Days Attended:
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold;">
                                                                                <%# Eval("DaysPresent")%>
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; font-weight: bold"></td>
                                                                            <td style="width: 35%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold;"></td>
                                                                        </tr>
                                                                        <%--<tr style="width: 100%">
                                                                            <td style="width: 35%; font-size: medium; font-weight: bold;">Discretionary Request:
                                                                            </td>
                                                                            <td id="Td10" runat="server" visible='<%# (int)( Eval("RD_Approval"))==3 %>' style="width: 35%; font-size: medium; font-weight: bold;">
                                                                                <span id="Span11" class="glyphicon glyphicon-question-sign" style="color: Navy;"
                                                                                    runat="server"></span>
                                                                            </td>
                                                                            <td id="Td7" runat="server" visible='<%# (int)( Eval("RD_Approval"))==2 %>' style="width: 35%; font-size: medium; font-weight: bold;">
                                                                                <div runat="server">
                                                                                    <span id="Span5" style="color: Orange;" class="glyphicon glyphicon-ok" runat="server"
                                                                                        visible='<%# Convert.ToBoolean( Eval("Submit_RD"))==true %>'></span><span id="Span7"
                                                                                            style="color: Orange;" class="glyphicon glyphicon-remove" runat="server" visible='<%# Convert.ToBoolean( Eval("Submit_RD"))==false %>'></span>
                                                                                </div>
                                                                            </td>
                                                                            <td id="Td8" runat="server" visible='<%# (int)( Eval("RD_Approval"))==1 %>' style="width: 35%; font-size: medium; font-weight: bold;">
                                                                                <div id="Div1" runat="server">
                                                                                    <span id="Span6" style="color: Green;" class="glyphicon glyphicon-ok" runat="server"
                                                                                        visible='<%# Convert.ToBoolean( Eval("Submit_RD"))==true %>'></span><span id="Span8"
                                                                                            style="color: Green;" class="glyphicon glyphicon-remove" runat="server" visible='<%# Convert.ToBoolean( Eval("Submit_RD"))==false %>'></span>
                                                                                </div>
                                                                            </td>
                                                                            <td id="Td9" runat="server" visible='<%# (int)( Eval("RD_Approval"))==0%>' style="width: 35%; font-size: medium; font-weight: bold;">
                                                                                <div id="Div2" runat="server">
                                                                                    <span id="Span9" style="color: Red;" class="glyphicon glyphicon-ok" runat="server"
                                                                                        visible='<%# Convert.ToBoolean( Eval("Submit_RD"))==true %>'></span><span id="Span10"
                                                                                            style="color: Red;" class="glyphicon glyphicon-remove" runat="server" visible='<%# Convert.ToBoolean( Eval("Submit_RD"))==false %>'></span>
                                                                                </div>
                                                                            </td>
                                                                            <td style="width: 35%; font-size: medium; font-weight: bold;">RD Decision Status:
                                                                            </td>
                                                                            <td id="Td1" runat="server" visible='<%# (int)( Eval("RD_Approval"))==1 %>' style="width: 35%; font-size: medium; font-weight: bold;">
                                                                                <span id="Span1" class="glyphicon glyphicon-ok" runat="server" style="color: Green;"></span>
                                                                            </td>
                                                                            <td id="Td2" runat="server" visible='<%# (int)( Eval("RD_Approval"))==0 %>' style="width: 35%; font-size: medium; font-weight: bold;">
                                                                                <span id="Span2" class="glyphicon glyphicon-remove" runat="server" style="color: Red;"></span>
                                                                            </td>
                                                                            <td id="Td3" runat="server" visible='<%# (int)( Eval("RD_Approval"))==2 %>' style="width: 35%; font-size: medium; font-weight: bold;">
                                                                                <span id="Span3" class="glyphicon glyphicon-minus-sign" runat="server" style="color: Orange;"></span>
                                                                            </td>
                                                                            <td id="Td4" runat="server" visible='<%# (int)( Eval("RD_Approval"))==3 %>' style="width: 35%; font-size: medium; font-weight: bold;">
                                                                                <span id="Span4" class="glyphicon glyphicon-question-sign" runat="server" style="color: Navy;"></span>
                                                                            </td>
                                                                        </tr>--%>
                                                                        <%--                                                           <tr style="width: 100%">
                                                                            <td style="width: 25%; font-size: medium; font-weight: bold">Requested Class:
                                                                            </td>
                                                                            <td colspan="3" style="width: 75%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold;">
                                                                                <%# Eval("ClassRequest")%>

                                                                                <span id="Span12" visible='<%# (int)( Eval("RD_Approval"))==3 %>' class="glyphicon glyphicon-question-sign" style="color: Navy;"
                                                                                    runat="server"></span>
                                                                            </td>
                                                                        </tr>--%>
                                                                        <%--   <tr style="width: 100%">
                                                                            <td style="width: 25%; font-size: medium; font-weight: bold">School Head Remarks:
                                                                            </td>
                                                                            <td colspan="3" style="width: 75%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold;">
                                                                                <%# Eval("Remarks")%>
                                                                            </td>
                                                                        </tr>--%>
                                                                        <%--              <tr style="width: 100%">
                                                                            <td style="width: 25%; font-size: medium; font-weight: bold">Regional Director Remarks :
                                                                            </td>
                                                                            <td colspan="3" style="width: 75%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold;">
                                                                                <%# Eval("RD_Remarks")%>
                                                                            </td>
                                                                        </tr>--%>
                                                                        <tr style="width: 100%">
                                                                            <td style="width: 25%; font-size: medium; font-weight: bold">Procedure/ Promotion Criteria:
                                                                            </td>
                                                                            <td colspan="3" style="width: 75%; font-size: medium; color: <%# Eval("RD_ApprovalColor") %>; font-weight: bold;">
                                                                                <%# Eval("ResultStatus")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <%--  <tr id="Tr5" runat="server" class="tr2" visible='<%# Convert.ToBoolean( Eval("Flag"))==true %>' >
                                                                <td style="width: 100%; font-size: medium; font-weight: bold;">
                                                                    <div class="pull-right">
                                                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" CommandArgument='<%# Eval("Student_No") %>'
                                                                            OnClick="btnSubmit_Click" Text="Request for Bifurcation" ToolTip="Request for Bifurcation"
                                                                            Visible="true" />
                                                                        <%-- <button  ID="btnSubmit" runat="server" type="button" class="btn btn-info" data-toggle="modal" data-target="#myModal" 
                                                                        Visible='<%# Convert.ToBoolean( Eval("Submit_RD"))==false %>' causesvalidation="true" onclick="btnSubmit_Click" >
                                                                           Request for Bifurcation</button>--%>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                              <tr id="Tr2" runat="server" class="tr2" visible='<%# Convert.ToBoolean( Eval("Flag"))==true %>'>
                                                                  <td style="width: 100%; font-size: medium; font-weight: bold;">
                                                                      <div class="pull-right">
                                                                          <asp:Label ID="lblolevel"  visible="false" runat="server"  Text="If parent would like to continue the O Level route then press 'Send Undertaking' button."></asp:Label>

                                                                          <asp:Button ID="btn_bif_email" runat="server" class="btn btn-primary" CommandArgument='<%# Eval("Student_No") %>'
                                                                              OnClick="btn_bif_email_Click" Text="Send Undertaking " ToolTip="Send Undertaking"
                                                                              Visible="true" />
                                                                          <br />

                                                                          <asp:Label runat="server" ID="emailstatus" Text='<%#Convert.ToString(Eval("Email_Status")) %>' Style="float: right;"></asp:Label>
                                                                          <asp:Button ID="btn_view_Undertaking" runat="server" class="btn btn-primary" CommandArgument='<%# Eval("Student_No") %>'
                                                                              OnClick="btn_view_Undertkng_Click" Text="View Undertaking " ToolTip="Viw Undertaking"
                                                                              Visible='<%# Convert.ToBoolean( Eval("bifurcation")) %>' />

                                                                          <asp:Button ID="btnreminder"  runat="server" class="btn btn-primary" CommandArgument='<%# Eval("Student_No") %>'
                                                                              OnClick="btnreminder_Click" Text="Reminder" ToolTip="Reminder"
                                                                              Visible="false" />
                                                                          <br />

                                                                      </div>
                                                                  </td>
                                                              </tr>
                                                            <tr id="Tr1" runat="server" class="tr2" visible='<%# (int)( Eval("RD_Approval"))==2 || (int)( Eval("RD_Approval"))==0  %>'>
                                                                <td style="width: 100%; font-size: medium; font-weight: bold;">
                                                                    <div class="pull-right">
                                                                        <asp:Button ID="btnDelete" runat="server" class="btn btn-danger" CommandArgument='<%# Eval("Student_No") %>'
                                                                            OnClick="btnDelete_Click" Text="Delete Request" ToolTip="Delete" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                            <tr class="tr2">
                                                                <td>
                                                                    <div class="pull-right">
                                                                        <br />
                                                                        <asp:CheckBox ID="ChkSys" runat="server" CssClass="checkbox" Text="E-Result format" Visible="false" />
                                                                        <asp:Button runat="server" ID="btnViewReport" OnClick="btnViewReport_Click" CssClass="btn btn-info"
                                                                            Text="View Result Card" CommandArgument='<%# Eval("Student_No") %>' Visible="false" />
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" Width="30px" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="tr1" />
                                            <HeaderStyle CssClass="tableheader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
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
            <div class="container">

                <%--h2>
                    Modal Example</h2>--%><!-- Trigger the modal with a button --><!-- Modal --><div
                        class="modal fade" id="myModal" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">
                                        &times;</button>
                                    <h4 class="modal-title">Student Discretionary Promotion</h4>
                                </div>
                                <div class="modal-body">
                                    <table cellpadding="0" cellspacing="0" style="table-layout: fixed; height: 92%; width: 100%; vertical-align: top;">
                                        <tr class="tr2" style="height: 28%">
                                            <td align="right">
                                                <asp:Label ID="lblStdId" runat="server" CssClass="TextLabelMandatory40" Text="Student Id: "> </asp:Label>
                                            </td>
                                            <td style="width: 75%">
                                                <asp:TextBox ID="txtStdId" runat="server" CssClass="form-control textbox" Enabled="false"
                                                    Text="">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="tr2" style="height: 28%">
                                            <td>
                                                <p>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr class="tr2" style="height: 28%">
                                            <td align="right">
                                                <asp:Label ID="lblStdName" runat="server" CssClass="TextLabelMandatory40" Text="Student Name: "> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtStdName" runat="server" CssClass="form-control textbox" Enabled="false"
                                                    Text="">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="tr2" style="height: 28%">
                                            <td>
                                                <p>
                                                </p>
                                            </td>
                                        </tr>
                                        <tr class="tr2" style="height: 28%">
                                            <td align="right">
                                                <asp:Label ID="lblClassSec" runat="server" CssClass="TextLabelMandatory40" Text="Class: "> </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtClassSec" runat="server" CssClass="form-control textbox" Enabled="false"
                                                    Text="">
                                                </asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr class="tr2" style="height: 28%">
                                            <td>
                                                <p>
                                                </p>
                                            </td>
                                        </tr>

                                        <tr class="tr2" style="height: 28%">
                                            <td align="right">
                                                <asp:Label ID="lblPromotionClass" runat="server" CssClass=" TextLabelMandatory40" Text="Promote to: ">
                                                </asp:Label>
                                            </td>
                                            <td>
                                                <div class="form-check form-check-inline">
                                                    <asp:RadioButtonList runat="server" CssClass="form-check-input" ID="rdbPromotionClass" RepeatDirection="Horizontal">
                                                    </asp:RadioButtonList>

                                                </div>
                                            </td>
                                        </tr>

                                        <tr class="tr2" style="height: 28%">
                                            <td>
                                                <p>
                                                </p>
                                            </td>
                                        </tr>




                                        <tr class="tr2" style="height: 28%">
                                            <td align="right">
                                                <asp:Label ID="Label10" runat="server" CssClass=" TextLabelMandatory40" Text="Remarks: ">
                                                </asp:Label>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control textbox" Rows="3"
                                                    Text="" TextMode="MultiLine" MaxLength="500" placeholder="type here ..."></asp:TextBox>
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRemarks"
                                                    ErrorMessage="Remarks are Compulsory" ForeColor="Red" ValidationGroup="test" />
                                                <asp:Label CssClass="text-muted" runat="server" ID="remLen"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button runat="server" ID="btnSubmitReq" CssClass="btn btn-primary" Text="Save"
                                        data-toggle="hide" OnClick="btnSubmitReq_Click" CausesValidation="true" ValidationGroup="test" />
                                    <%--  <asp:Button runat="server" ID="btnClose" CssClass="btn btn-danger"  data-backdrop="false" Text="Close" OnClick="btnClose_Click" CausesValidation="false" />--%>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Close</button>
                                </div>
                            </div>
                        </div>
                    </div>
            </div>
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

