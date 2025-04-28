<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="BifurcationProcessSetupReport.aspx.cs"
    Inherits="PresentationLayer_BifurcationProcessSetupReport" %>

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
          
        
          <%--  <script type="text/javascript">
                function openModalTest() {
                    //                    $('#myModal').modal('show');
                    $('#TestModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>

            <script type="text/javascript">
                function ViewPlacementsModal() {
                    //                    $('#myModal').modal('show');
                    $('#PlacementsModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>

            <script type="text/javascript">
                function ViewRejectionModal() {
                    //                    $('#myModal').modal('show');
                    $('#RejectionModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalTest() {

                    $('#TestModal').modal('hide');
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
                                    //            dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                    //"<'row'<'col-sm-12'tr>>" +
                                    //            //                     "<'row'<'col-sm-12'l>>" +
                                    // "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    //            "columnDefs": [

                                    //            //       { orderable: false, targets: [9, 11, 12] } //disable sorting on toggle button
                                    //            ]

                                    //           ,
                                    tableTools:
                                    { //Start of tableTools collection
                                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                        "aButtons":
                                            [ //start of button main/master collection

                                            ] // ******************* end of button master Collection
                                    } // ******************* end of tableTools
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true
                                    , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false //, fixedHeader: true , "stateSave": true
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
            </script>--%>






              <script type="text/javascript">

                Sys.Application.add_init(function () {
                    // Initialization code here, meant to run once.

                    jq(document).ready(document_Ready);


                    function document_Ready() {

                        jq(document).ready(function () {

                            //****************************************************************

                            try {
                                

                                //****************************************************************
                                $('table.datatable').DataTable({
                                    destroy: true,
                                    "dom": 'Blfrtip',

                                    buttons: [
                                        {
                                            extend: 'excel',
                                            exportOptions: {
                                                columns: [1, 2, 3, 4, 5, 6]
                                            }
                                        }
                                    ],
                                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                });
                            }
                            catch (err) {
                                alert('datatable ' + err);
                            }


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




            <table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="7">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Bifuration Process Report"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                       <%--     <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="text_dateOfBirth">
                            </cc1:CalendarExtender>--%>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">
                          <%--  <asp:Button ID="but_search" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                                Text="Search"></asp:Button>--%>
                            <asp:Button ID="but_Export" TabIndex="4" OnClick="but_Export_Click" runat="server" Visible="false"
                                CssClass="btn btn-primary" Text="Export"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right"></td>
                    </tr>
                 <%--   <tr>
                        <td class="titlesection" colspan="7" runat="server" id="trSearchCriteria">Search Criteria
                        </td>
                    </tr>--%>
                    <tr>
                        <td valign="top" colspan="7">
                            <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0" runat="server" id="tblSearch">
                                <tbody>
                                   <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabelMandatory40" style="width: 37%">Session:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px" Enabled="false">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabel40" style="width: 37%"><strong>Term:</strong>
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlterm" runat="server" CssClass="dropdownlist"
                                            Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="trRegion" runat="server">
                                    <td class="TextLabelMandatory40" style="width: 37%;">Region:
                                    </td>
                                    <td valign="top" style="width: 50%;">
                                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="218px"
                                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="false">
                                        </asp:DropDownList>


                                        <br />
                                    </td>
                                    <td valign="top" align="right"></td>
                                </tr>

                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server" visible="false" id="trSearch">
                        <td class="titlesection" colspan="7">&nbsp;Search Result
                        </td>
                    </tr>
                      <tr style="width: 100%">
                    <td>
                        <asp:Button ID="Button3" runat="server" class="button" OnClick="btnbifuration_Click" Text="Generate Report" Style="width: 228px; margin-left: 37%" />
                    </td>
                </tr>
                    <tr>
                        <td colspan="7">&nbsp;
                            <asp:GridView ID="gv_details" runat="server"  CssClass="datatable table table-striped table-bordered table-hover"
                                OnPreRender="gv_details_PreRender" AutoGenerateColumns="False" AllowPaging="false" >
                                <Columns>
                                    <asp:BoundField DataField="SESSION" HeaderText="Session">
                                    <HeaderStyle HorizontalAlign="left" Font-Size="14px" ForeColor="Black" />
                                    <ItemStyle HorizontalAlign="left" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TERM" HeaderText="Term">

                                    <HeaderStyle HorizontalAlign="left" Font-Size="14px" ForeColor="Black" />
                                    <ItemStyle HorizontalAlign="left" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Region_Name" HeaderText="Region">
                                    <HeaderStyle HorizontalAlign="left" Font-Size="14px" ForeColor="Black" />
                                    <ItemStyle HorizontalAlign="left" Font-Size="14px" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Center_Name" HeaderText="Campus">
                                    <HeaderStyle HorizontalAlign="left" Font-Size="14px" ForeColor="Black" />
                                    <ItemStyle HorizontalAlign="left" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="RESULT_DATE" HeaderText="Result Date">
                                    <HeaderStyle HorizontalAlign="left" Font-Size="14px" ForeColor="Black" />
                                    <ItemStyle HorizontalAlign="left" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="BifurcationProcessDate" HeaderText="Bifurcation Date">
                                    <HeaderStyle HorizontalAlign="left" Font-Size="14px" ForeColor="Black" />
                                    <ItemStyle HorizontalAlign="left" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField  DataField="Active" HeaderText="Active">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>











                                </Columns>
                                <SelectedRowStyle ForeColor="SlateGray" />
                                <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">
                            <%--<asp:Label ID="Span1" runat="server"></asp:Label>
                            <asp:Button ID="but_search2" TabIndex="1" OnClick="but_search_Click" runat="server"
                                CssClass="btn btn-primary" Text="Search"></asp:Button>
                            <asp:Button ID="but_Export2" TabIndex="5" OnClick="but_Export_Click" runat="server" Visible="false"
                                CssClass="btn btn-primary" Text="Export"></asp:Button>--%>

                        </td>
                    </tr>
                 






                  



                    <tr>
                        <td>
                            <div class="pull-right">
                                <%--<asp:Button ID="btnCancel" TabIndex="5" OnClick="btnCancel_Click" runat="server"
                                    Visible="false" CssClass="btn btn-danger" Text="Cancel"></asp:Button>--%>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="container">

                <div class="modal fade" id="TestModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Add Placement(s)</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <asp:Label ID="lblFirstName" runat="server" CssClass="TextLabelMandatory40" Text="Student Name"></asp:Label>
                                    <asp:TextBox ID="txtFirstName" ValidationGroup="modal" runat="server" CssClass="form-control " Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                                        ErrorMessage="First Name Required" ForeColor="Red" ValidationGroup="modal" />

                                </p>
                                <p>
                                    <asp:Label ID="lblLastName" runat="server" CssClass="TextLabelMandatory40" Text="University Name(s)"></asp:Label>
                                    <asp:DropDownList ID="ddluni" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddluni" InitialValue="select" ErrorMessage="Please select University " />
                                </p>

                            </div>
                            <div class="modal-footer">
                                <%--  <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                    Text="Save" CausesValidation="true" ValidationGroup="modal" />--%>
                                <%--<asp:Button ID="btnsaveplacement" runat="server" Text="Save Placement(s)" class="btn btn-default" OnClick="btnsaveplacement_Click" />--%>

                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>

                </div>
            </div>

            <%--**********************Modal for View Placements*********************--%>
            <div class="container">

                <div class="modal fade" id="PlacementsModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Upload Document(s)</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <asp:Label ID="Label2" runat="server" CssClass="TextLabelMandatory40" Text="Student Name"></asp:Label>
                                    <asp:TextBox ID="txtStdName" ValidationGroup="modal" runat="server" CssClass="form-control " Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtStdName"
                                        ErrorMessage="First Name Required" ForeColor="Red" ValidationGroup="modal" />

                                </p>
                                <p>
                                    <asp:Label ID="Label3" runat="server" CssClass="TextLabelMandatory40" Text="* For multiple files upload please select all files at once" ForeColor="Green"></asp:Label>
                                    <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
                                    <%--<asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="false" CssClass="form-control"></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddluni" InitialValue="select" ErrorMessage="Please select University " />--%>
                                </p>


                            </div>
                            <div class="modal-footer">

                                <%--    <asp:Button ID="btnuploaddocs" runat="server" CssClass="btn btn-primary" OnClick="btnuploaddocs_Click1"
                                    Text="Upload & Approve" CausesValidation="true" ValidationGroup="modal" />--%>
                                <%-- <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                    OnClick="btnCancel_Click" Text="Cancel" />--%>
                                <%--<asp:Button ID="btndocsupload" runat="server" class="btn btn-default" Text="Upload & Approve" OnClick="btndocsupload_Click" />--%>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>

                </div>
            </div>


            <%--****************************Rejection Modal**********************************--%>
            <div class="container">

                <div class="modal fade" id="RejectionModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Rejection Remarks</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <asp:Label ID="Label4" runat="server" CssClass="TextLabelMandatory40" Text="Student Name"></asp:Label>
                                    <asp:TextBox ID="txtrejstudent" ValidationGroup="modal" runat="server" CssClass="form-control " Enabled="false"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtrejstudent"
                                        ErrorMessage="First Name Required" ForeColor="Red" ValidationGroup="modal" />

                                </p>
                                <p>
                                    <asp:Label ID="Label5" runat="server" CssClass="TextLabelMandatory40" Text="Remarks"></asp:Label>
                                    <asp:TextBox ID="txtrejremarks" ValidationGroup="modal" runat="server" CssClass="form-control " Enabled="true" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtrejremarks"
                                        ErrorMessage="Rejection remarks Required" ForeColor="Red" ValidationGroup="modal" />
                                </p>


                            </div>
                            <div class="modal-footer">


                               <%-- <asp:Button ID="btnrejectaction" runat="server" class="btn btn-default" Text="Reject" OnClick="btnrejectaction_Click" />--%>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
      <%--  <Triggers>
            <asp:PostBackTrigger ControlID="btndocsupload" />
        </Triggers>--%>
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
