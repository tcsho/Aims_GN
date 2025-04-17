<%@ Page Title="Discretionary Promotion Approval" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentConditionallyPromotedApproval.aspx.cs"
    Inherits="PresentationLayer_StudentConditionallyPromotedApproval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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

                                    //{ orderable: false, targets: [8]} //disable sorting on toggle button
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
                  , "mColumns": [9]
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
                     , "mColumns": [9]
              }  // ******************* end of csv button

              // ******************* Start of excel button
               , {
                   'sExtends': 'xls',
                   'bShowAll': false,
                   "sFileName": "DataInExcelFormat.xls",
                   //'sButtonText': 'Save to Excel',
                   "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                   "sToolTip": "Save as Excel"
                    , "mColumns": [9]
               }  // ******************* End of excel button


              // ******************* Start of PDF button
              , {
                  'sExtends': "pdf",
                  'bShowAll': false,
                  "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                  //'sButtonText': 'Save to PDF',
                  "sFileName": "DataInPDFFormat.pdf",
                  "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                     , "mColumns": [9]
                  //,"sPdfMessage": "Your custom message would go here."
              } // *********************  End of PDF button 

               ]// ******************* end of Export buttons collection
          }    // ******************* end of child of export buttons collection
            ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 100, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
         , "order": [[0, "asc"]], "paging": true, "ordering": false, "searching": true, "info": true, "scrollX": false, "stateSave": true
         , //--- Dynamic Language---------
                                    "oLanguage": {
                                        "sZeroRecords": "There are no Records that match your search critera",
                                        //                    "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
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
                                alert('datatable ' + err);
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
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Student Driscretionary Promotion Approval"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <p>
                <br />
            </p>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                    <asp:Label ID="Label5" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="Session : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="Label6" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="Region : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="218px"
                            OnSelectedIndexChanged="ddl_region_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="Label8" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabel40"
                        Text="Center : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="218px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="Label1" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabel40"
                        Text="Class : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdownlist" Width="218px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div runat="server" id="divBifurcation" class="col-lg-4 col-md-4 col-sm-4 col-xs-12 form-group">
                    <div class="pull-right">
                        <asp:Button ID="btnPending" runat="server" CssClass="btn btn-primary" OnClick="btnPending_Click"
                            Text="Pending"></asp:Button>
                        <asp:Button ID="btnShowApproved" runat="server" CssClass="btn btn-success" OnClick="btnShowApproved_Click"
                            Text="Approved"></asp:Button>
                        <asp:Button ID="btnShowDisapproved" runat="server" CssClass="btn btn-danger" OnClick="btnShowDisApproved_Click"
                            Text="Disapproved"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblGridStatus" CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 TextLabelMandatory40 text-left"
                    ForeRD_ApprovalColor="Red" Text="">    </asp:Label>
            </div>
            <p>
                <br />
            </p>
            <div class=" form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection"
                    colspan="7" visible="false">
                    &nbsp; List of Discretionary Students
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gv_details" runat="server" AutoGenerateColumns="False" OnPreRender="gv_details_PreRender"
                    CssClass="datatable table table-hover table-responsive">
                    <Columns>
                        <asp:BoundField DataField="Student_No" HeaderText="Student No">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Id" HeaderText="Class_Id" ItemStyle-CssClass="hide"
                            HeaderStyle-CssClass="hide">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Name" HeaderText="Section ">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RD_Approval" HeaderText="Submit_RD">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="RDStatus" HeaderText="Status">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ResultStatus" HeaderText="ResultStatus">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Id" HeaderText="Section Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DaysPresent" HeaderText="DaysPresent">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ClassRequest" HeaderText="ClassRequest">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="List of Students">
                            <ItemStyle HorizontalAlign="Center" Width="100%" />
                            <ItemTemplate>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Student # :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval("Student_No")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Student Name :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval("StudentName")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Class-Section:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval("Class_Name")%>-
                                        <%# Eval("Section_Name")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Session:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval(" Description")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Days Attended :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval(" DaysPresent")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                    School:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"  
                                    style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval("Center_Name")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Request Status :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <span id="Span5" class="glyphicon glyphicon-minus-sign" runat="server" visible='<%# (int)( Eval("RD_Approval"))==2 %>'
                                            style="color: Navy;"></span><span id="Span12" style="color: Green;" class="glyphicon glyphicon-ok"
                                                runat="server" visible='<%# (int)( Eval("RD_Approval"))==1 %>'></span><span id="Span10"
                                                    style="color: Red;" class="glyphicon glyphicon-remove" runat="server" visible='<%# (int)( Eval("RD_Approval"))==0%>'>
                                                </span>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        RD Decision Status:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <span id="Span1" class="glyphicon glyphicon-ok" runat="server" visible='<%# (int)( Eval("RD_Approval"))==1 %>'
                                            style="color: Green;"></span><span id="Span2" class="glyphicon glyphicon-remove"
                                                runat="server" visible='<%# (int)( Eval("RD_Approval"))==0 %>' style="color: Red;">
                                            </span><span id="Span3" class="glyphicon glyphicon-minus-sign" runat="server" visible='<%# (int)( Eval("RD_Approval"))==2 %>'
                                                style="color: Navy;"></span>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        School Head Remarks:
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval("Remarks")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Requested Class:
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval("ClassRequest")%>
                                    </div>
                                </div>

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Regional Director Remarks :
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval("RD_Remarks")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Procedure/ Promotion Criteria:
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("RD_ApprovalColor") %>;">
                                        <%# Eval("ResultStatus")%>
                                    </div>
                                </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40 text-left">
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 TextLabelMandatory40 text-left"
                                        style="rd_approvalcolor: <%# Eval("RD_ApprovalColor") %>;">
                                        <div class="pull-right">
                                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-primary" CommandArgument='<%# Eval("Student_No") %>'
                                                Text="Proceed " ToolTip="Process" OnClick="btnProcess_Click" Visible='<%# (int)( Eval("RD_Approval"))==2 %>' />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" runat="server">
                                    <p>
                                        <br />
                                    </p>
                                    <div class="pull-right">
                                        <asp:CheckBox ID="ChkSys" runat="server" CssClass="checkbox" Text="E-Result format" />
                                        <asp:Button runat="server" ID="btnViewReport" OnClick="btnViewReport_Click" CssClass="btn btn-info"
                                            Text='<%# "" + Eval("Description") + " Result Card" %>' CommandArgument='<%# Eval("Student_No") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Wrap="true" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr2" />
                    <HeaderStyle CssClass="tableheader" />
                </asp:GridView>
            </div>
            <div class="container">
                <!-- Modal -->
                <div class="modal fade" id="myModal" role="dialog">
                    <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">
                                    &times;</button>
                                <h4 class="modal-title">
                                    Regional Director Approval
                                </h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <asp:Label ID="Label3" CssClass="TextLabelMandatory40" runat="server" Text="Student No:"></asp:Label>
                                    <asp:Label ID="lblStdId" CssClass="TextLabel" runat="server" Text=""></asp:Label></p>
                                <p>
                                    <asp:Label ID="Label4" CssClass="TextLabelMandatory40" runat="server" Text="Student Name: "></asp:Label>
                                    <asp:Label ID="lblStdName" CssClass="TextLabel" runat="server" Text=""></asp:Label></p>
                                <p>
                                    <asp:Label ID="Label10" CssClass="TextLabelMandatory40" runat="server" Text="Class:"></asp:Label>
                                    <asp:Label ID="lblClassSec" CssClass="TextLabel" runat="server" Text=""></asp:Label></p>
                                <p>
                                     <p>
                                    <asp:Label ID="Label7" CssClass="TextLabelMandatory40" runat="server" Text="Requested Class:"></asp:Label>
                                    <asp:Label ID="lblRequestedClass" CssClass="TextLabel" runat="server" Text=""></asp:Label></p>
                                <p>
                                    <div class="form-check form-check-inline">
                                    <asp:RadioButtonList runat="server" ID="rdApproval" CssClass="form-check-input" RepeatDirection="Vertical"
                                        ValidationGroup="test">
                                        <asp:ListItem Value="0"> Disapprove</asp:ListItem>
                                        <asp:ListItem Value="1"> Approve</asp:ListItem>
                                    </asp:RadioButtonList>
                                        </div>
                                    <asp:RequiredFieldValidator runat="server" ID="status" Display="Dynamic" ForeRD_ApprovalColor="Red"
                                        ControlToValidate="rdApproval" ErrorMessage="Status Required" ValidationGroup="test"></asp:RequiredFieldValidator>
                                    <p>
                                    </p>
                                    <p>
                                        <asp:Label ID="Label11" runat="server" CssClass="TextLabelMandatory40" Text="Remarks:"></asp:Label>
                                        <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control texbox" Rows="3" Text="" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRemarks" ErrorMessage="Remarks are Compulsory" ForeRD_ApprovalColor="Red" ValidationGroup="test" />
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                    <p>
                                    </p>
                                </p>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnSave" CssClass="btn btn-primary" Text="Save" OnClick="btnSubmit_Click"
                                    CausesValidation="true" ValidationGroup="test" />
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                                <%--<asp:Button runat="server" ID="btnClose" CssClass="btn btn-danger" Text="Close" OnClick="btnClose_Click"
                                                                CausesValidation="false" />--%>
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
