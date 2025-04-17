<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="MarksLockingCriteria.aspx.cs" Inherits="PresentationLayer_MarksLockingCriteria"
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
            <link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/flatpickr/dist/flatpickr.min.css">
            <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/flatpickr"></script>

            <%--  <script type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.min.js"></script>--%>
            <%--<script type="text/javascript" src="path/to/jquery.datetimepicker.js"></script>--%>


            <%--            <link rel="stylesheet" href="//code.jquery.com/ui/1.13.1/themes/base/jquery-ui.css">
 
  <script   type="text/javascript" src="https://code.jquery.com/jquery-3.6.0.js"></script>
  <script  type="text/javascript"  src="https://code.jquery.com/ui/1.13.1/jquery-ui.js"></script>--%>

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
                    debugger
                    $('#TestModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                    // Initialize Flatpickr after modal is shown
                    $('#TestModal').on('shown.bs.modal', function () {
                        initFlatpickr();
                    });
                }
                function initFlatpickr() {
                    debugger;
                    var test = 1;
                    console.log(test);

                    // Get the current date and time
                    var now = new Date();
                    var currentDate = now.toISOString().split('T')[0]; // yyyy-mm-dd
                    var currentTime = now.getHours() + ":00"; // hh:00

                    flatpickr('#txtDateTime', {
                        enableTime: true,
                        dateFormat: "Y-m-d H",
                        hourIncrement: 1,
                        minuteIncrement: 0,
                        minDate: currentDate, // Disable past dates
                        minTime: currentTime, // Disable past hours on the current date
                        onChange: function (selectedDates, dateStr, instance) {
                            // Disable past hours on the selected date
                            if (dateStr.split(' ')[0] === currentDate) {
                                instance.set('minTime', currentTime);
                            } else {
                                instance.set('minTime', '00:00');
                            }
                            document.getElementById('<%= hiddenDateTime.ClientID %>').value = dateStr;
                        }
                    });
                }

              //function initFlatpickr() {
              //    debugger;
              //    var test = 1
              //    console.log(test);
              //    flatpickr('#txtDateTime', {
              //        enableTime: true,
              //        dateFormat: "Y-m-d H",
              //        hourIncrement: 1,
              //        minuteIncrement: 0,
              //    });
              //}
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
                function toggleCheckboxes(changedCheckbox) {
                    console.log(changedCheckbox);
                    var chkLock = document.getElementById('<%= chkLock.ClientID %>');
                    var chkunlock = document.getElementById('<%= chkunlock.ClientID %>');

                    if (changedCheckbox.id === chkLock.id && chkLock.checked) {
                        chkunlock.checked = false;
                    }

                    if (changedCheckbox.id === chkunlock.id && chkunlock.checked) {
                    }
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
                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label8" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Term Group: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdownlist" Width="217px" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
                        <%--    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label4" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                                Text="*Time: "></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtstarttime" runat="server" TextMode="Time" CssClass="dropdownlist form-control" Width="100%"></asp:TextBox>
                            </div>
                        </div>--%>
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
                        AllowSorting="true" CssClass=" table table-striped table-responsive" OnRowDataBound="GridView1_RowDataBound" OnPreRender="gvTest_PreRender">
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
                            <asp:BoundField DataField="Current_Status" HeaderText="Current Status">
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
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("MLCri_Id") + "," + Eval("isLock")+"," + Eval("IsProcessed")+"," +Eval("ML_Criteria")+","+ Eval ("Evaluation_Criteria_Type_Id")+","+Eval("MLC_Type_Id")+","+Eval("Evaluation_Type_Id")+","+Eval("Class_Id") %>' ForeColor="#004999" OnClick="btnEdit_Click" CssClass="btn-lg" ToolTip="Edit Record">
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
                                        CommandArgument='<%# Eval("LockingDate") %>'
                                        CommandName='<%# Eval("isLock") %>'></asp:ImageButton>

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
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="col-lg-3" style="text-align: right">
                                                <asp:Label ID="Label1" Style="text-align: right" runat="server" CssClass=" checkbox" Text="Marks Lock: "></asp:Label>
                                            </div>
                                            <div class="col-lg-3 left">
                                                <asp:CheckBox ID="chkLock" runat="server" CssClass="form-check" Enabled="true" onclick="toggleCheckboxes(this)"></asp:CheckBox>
                                            </div>
                                            <div class="col-sm-3">
                                                <asp:Label ID="Label3" runat="server" CssClass=" checkbox" Text="Marks UnLock: "></asp:Label>
                                            </div>
                                            <div class="col-lg-3 left">
                                                <asp:CheckBox ID="chkunlock" runat="server" CssClass="form-check" Enabled="true" onclick="toggleCheckboxes(this)"></asp:CheckBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="col-lg-3 " style="text-align: right">
                                                <asp:Label ID="lblTestName" runat="server" CssClass="TextLabelMandatory40" Text="Start Date: "></asp:Label>
                                            </div>
                                            <div class="col-lg-7">
                                                <input type="text" id="txtDateTime" class="form-control" placeholder="Select Date and Time" />
                                                <asp:HiddenField ID="hiddenDateTime" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                            Text="Save" CausesValidation="true" ValidationGroup="test" />
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
