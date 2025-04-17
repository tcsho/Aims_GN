<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="MarksLockingCriteriaReginAndCenterLevel.aspx.cs" Inherits="PresentationLayer_MarksLockingCriteriaReginAndCenterLevel"
    Theme="BlueTheme" %>

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

            <script type="text/javascript">

                Sys.Application.add_init(function () {
                    // Initialization code here, meant to run once.

                    jq(document).ready(document_Ready);


                    function document_Ready() {

                        jq(document).ready(function () {

                            //****************************************************************

                            try {
                                //                       jq('table.datatable').DataTable({
                                //                           destroy: true,
                                //                           // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                                //                           //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                //                           dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                //            "<'row'<'col-sm-12'tr>>" +
                                //                           //                     "<'row'<'col-sm-12'l>>" +
                                //             "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                //                           "columnDefs": [

                                //                           //{ orderable: false, targets: [8]} //disable sorting on toggle button
                                //                           ]

                                //                       ,
                                //                           tableTools:
                                //           { //Start of tableTools collection
                                //               "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                //               "aButtons":
                                //                [ //start of button main/master collection



                                //     { // ******************* Start of child collection for export button
                                //         "sExtends": "collection",
                                //         "sButtonText": "<span class='glyphicon glyphicon-export'></span>",
                                //         "sToolTip": "Export Data",
                                //         "aButtons":
                                //                [ //start of button export buttons collection

                                //         // ******************* Start of copy button
                                //           {
                                //               "sExtends": "copy",
                                //               "sButtonText": "<span class='glyphicon glyphicon-copy'></span> Copy Contents",
                                //               "sToolTip": "Copy Data"
                                //             , "mColumns": [1, 2, 3, 4, 5, 6]
                                //           } // ******************* end of copy button

                                //         // ******************* Start of csv button
                                //         , {
                                //             'sExtends': 'csv',
                                //             'bShowAll': false // ,'sFileName': "DataInCSVFormat.csv"
                                //             ,
                                //             "sFileName": "DataInCSVFormat - *.csv",
                                //             "sToolTip": "Save as CSV",
                                //             //'sButtonText': 'Save as CSV',
                                //             "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
                                //             "sNewLine": "auto"
                                //                , "mColumns": [1, 2, 3, 4, 5, 6]
                                //         }  // ******************* end of csv button

                                //         // ******************* Start of excel button
                                //          , {
                                //              'sExtends': 'xls',
                                //              'bShowAll': false,
                                //              "sFileName": "DataInExcelFormat.xls",
                                //              //'sButtonText': 'Save to Excel',
                                //              "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                                //              "sToolTip": "Save as Excel"
                                //               , "mColumns": [1, 2, 3, 4, 5, 6]
                                //          }  // ******************* End of excel button


                                //         // ******************* Start of PDF button
                                //         , {
                                //             'sExtends': "pdf",
                                //             'bShowAll': false,
                                //             "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                                //             //'sButtonText': 'Save to PDF',
                                //             "sFileName": "DataInPDFFormat.pdf",
                                //             "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                                //                , "mColumns": [1, 2, 3, 4, 5, 6]
                                //             //,"sPdfMessage": "Your custom message would go here."
                                //         } // *********************  End of PDF button 

                                //                ]// ******************* end of Export buttons collection
                                //     }    // ******************* end of child of export buttons collection
                                //                ] // ******************* end of button master Collection
                                //           } // ******************* end of tableTools
                                //, "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
                                //, "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": true
                                //, //--- Dynamic Language---------
                                //                           "oLanguage": {
                                //                               "sZeroRecords": "There are no Records that match your search critera",
                                //                               //                    "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
                                //                               "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                                //                               "sInfoEmpty": "Showing 0 to 0 of 0 records",
                                //                               "sInfoFiltered": "(filtered from _MAX_ total records)",
                                //                               "sEmptyTable": 'No Rows to Display.....!',
                                //                               "sSearch": "Search :"
                                //                           }
                                //                       }
                                //          );

                                $('table.datatable').DataTable({
                                    destroy: true,
                                    "dom": 'Blfrtip',
                                    //"retrieve": true,
                                    //"processing": true, //Optional, only useful for *large* tables
                                    //"serverSide": true,
                                    //"bPaginate": true,
                                    //"bLengthChange": true,
                                    //"bFilter": true,
                                    //"bInfo": true,
                                    //"buttons": [
                                    //    "copy", "excel"
                                    //],

                                    buttons: [
                                        {
                                            extend: 'excel',
                                            exportOptions: {
                                                columns: [2, 3, 4]
                                            }
                                        }
                                    ],
                                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                });
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
            <script type="text/javascript">
                function openModal() {
                    //                    $('#myModal').modal('show');
                    $('#PoolConfig').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModal() {

                    $('#PoolConfig').modal('hide');
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
                function openModalQuestion() {
                    $('#PoolQuestion').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalQuestion() {

                    $('#PoolQuestion').modal('hide');
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
                function openModalAnswer() {
                    $('#AnswerModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalAnswer() {

                    $('#AnswerModal').modal('hide');
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
            <div class="form-group">


                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Marks Locking Criteria"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <p>

                    <br />
                </p>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblsession" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Session: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                                </asp:DropDownList>
                            </div>
                        </div>
                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label1" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Region: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlRegion" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                                </asp:DropDownList>
                            </div>
                        </div>
                       <%--  <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label3" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Center: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                                </asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label8" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Term Group: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdownlist" Width="217px"></asp:DropDownList>
                            </div>
                        </div>



                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblType" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                                Text="*Type: "></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlType" runat="server" CssClass="dropdownlist" Width="218px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>

                    </div>
                    <div runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-12 form-group">
                        <div class="pull-right">
                            <asp:Button ID="btnAddTest" runat="server" CssClass="btn btn-primary" Font-Bold="False" OnClick="btnAddTest_Click" Text="Add New" Visible="false" />

                            <asp:Button ID="btnDeleteTest" runat="server" CssClass="btn btn-danger" Font-Bold="False"
                                OnClick="btnDeleteTest_Click" Text="Delete" Visible="false" />

                            <asp:Button ID="btnAssignCenters" runat="server" CssClass="btn btn-info "
                                Text="Assign To Centers" OnClick="btnAssignCenters_Click" Visible="false" />
                        </div>

                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridTestTitle" visible="false">
                    Test Details
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <br />
                    <asp:GridView ID="gvLocking" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        AllowSorting="true" CssClass=" table table-striped table-responsive" OnPreRender="gvTest_PreRender">
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                            <asp:BoundField DataField="MLCri_Id" HeaderText="Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Name" HeaderText="Class_Name" SortExpression="Class_Name">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Sr. #">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="LockingDate" HeaderText="Expiry">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("MLCri_Id") %>' ForeColor="#004999" OnClick="btnEdit_Click" CssClass="btn-lg"
                                        ToolTip="Edit Record">
                                    <i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="cb">
                                <EditItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </EditItemTemplate>
                                <HeaderTemplate>
                                    <asp:LinkButton ID="lbtnSelectChecked" runat="server" CausesValidation="False"
                                        CommandName="toggleCheck">Check</asp:LinkButton>
                                </HeaderTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                <ItemTemplate>
                                    <asp:CheckBox ID="chkSelect" runat="server" />
                                </ItemTemplate>
                                <ItemStyle />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Copy">
                                <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnCopy" runat="server" ForeColor="#004999" OnClick="btnCopy_Click"
                                        Style="text-align: center; font-weight: bold;" ToolTip="Copy" ImageUrl="~/images/edit.gif"
                                        CommandArgument='<%# Eval("LockingDate") %>'></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle />
                            </asp:TemplateField>


                        </Columns>
                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
                </div>

                <div runat="server" id="divTestButtons" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group text-uppercase" visible="false">

                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <p>
                                <br />
                            </p>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="Gridtitle" visible="false">
                        </div>


                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridTitleAns" visible="false">
                        </div>

                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-inline ">
                    <p>
                        <br />
                        <asp:Label ID="lblGridStatus" runat="server" Visible="false"
                            CssClass="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" Text="No Data to Display"> </asp:Label>
                    </p>
                </div>

                <div class="container">

                    <div class="modal fade" id="TestModal" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Edit Marks Locking</h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Label ID="lblTestName" runat="server" CssClass="TextLabelMandatory40" Text="Title: "></asp:Label>
                                        <asp:TextBox ID="txtTestName" runat="server" CssClass="form-control " Enabled="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestName" ErrorMessage="Date Required" ForeColor="Red" ValidationGroup="test" />

                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                        Text="Save" CausesValidation="true" ValidationGroup="test" />
                                    <%-- <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                    OnClick="btnCancel_Click" Text="Cancel" />--%>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
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
