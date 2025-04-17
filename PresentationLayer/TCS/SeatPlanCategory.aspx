<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="SeatPlanCategory.aspx.cs" Inherits="PresentationLayer_TCS_SeatPlanCategory" %>


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

                function getConfirmationValue()
                {
                    document.getElementById('LblInProgressRollNoGen1').innerHTML = 'Mask Generation In Progress....';
                    LblInProgressRollNoGen1.style.display = "block";
                    //return true;
                }



                function getAssignRoomtoTeacher() {
                    document.getElementById('LblInTeacherRoomsAllocation').innerHTML = 'Teachers Rooms Allocation In Progress....';
                    LblInProgressRollNoGen1.style.display = "block";
                    //return true;
                }


                function AllocateRoomsTostudentFunLbl() {
                    var modal = document.getElementById("myModal");
                    document.getElementById('LblInProgressAllocateRoomsToStudent').innerHTML = 'Allocation Rooms To studen  In Progress....';
                    LblInProgressAllocateRoomsToStudent.style.display = "block";
                    modal.style.display = "block";
                    //return true;
                }



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




                                            ] // ******************* end of button master Collection
                                    } // ******************* end of tableTools
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 10, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
                                    , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": true
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
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Seating Plan Categories"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <p>

                    <br />
                </p>
                
                
<%--                <asp:Button ID="btnExport" runat="server" Text="Export To Excel" OnClick = "btnExport_Click" />--%>
                <div class="row">
                    <div class="col-lg-8 col-lg-offset-2 col-md-8 col-md-offset-2 col-sm-10 col-xs-10 col-sm-offset-1 col-xs-offset-1">
                        <div class="row">            
                            
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                <fieldset>
                                    <legend>Seating Plan Block Configuration</legend>
                                    <div class="row ">
                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                                <div class="form-group">
                                                <asp:Label ID="SessionIdLbl" runat="server" Text="Session:" CssClass="modal-title"></asp:Label><span style="color:red;"> *</span>
                                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist form-control" 
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                            </div>    
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                            <div class="form-group  ">
                                                <asp:Label runat="server" Text="Term" CssClass="modal-title"></asp:Label><span style="color:red;"> *</span>
                                                <asp:DropDownList ID="ddlTerm" runat="server" class="form-control" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                            CssClass="dropdownlist form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged">
                                                            <asp:ListItem Value="0">Select</asp:ListItem>
                                                            <asp:ListItem Value="1">First Term</asp:ListItem>
                                                            <asp:ListItem Value="2">Second Term</asp:ListItem>
                                                        </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                            <div class="form-group  ">
                                                <asp:Label runat="server" Text="Center " CssClass="modal-title" ></asp:Label><span style="color:red;"> *</span>
                                                <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist form-control" AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                    <div class="row ">
                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="lblClass" runat="server" CssClass="modal-title" Text="Class "></asp:Label>
                                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdownlist form-control"   AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="lblBlock" runat="server" CssClass="modal-title"  Text="Block :"></asp:Label>
                                                        <asp:DropDownList ID="ddlBlock" runat="server" CssClass="dropdownlist form-control"  AutoPostBack="false"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                            <div class="form-group  ">
                                                <asp:Label ID="lblGender" runat="server" CssClass="modal-title"  Text="Gender "></asp:Label>
                                                        <asp:DropDownList ID="ddlGender" runat="server" CssClass="dropdownlist form-control"  AutoPostBack="false"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                            <div class="form-group  ">
                                                 <p id="ShowSubject" runat="server" visible="false">
                                                        <asp:Label ID="lblSubject" runat="server" CssClass="modal-title"  Text="Subject"></asp:Label><span style="color:red;"> *</span>
                                                        <asp:DropDownList ID="ddlSubject" runat="server" CssClass="dropdownlist form-control" AutoPostBack="false"></asp:DropDownList>
                                                    </p>
                                            </div>
                                        </div>
                                    </div>
                            </div>

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                <div class="row ">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                        <div class="form-group  ">
                                            <p style="text-align:right;">
                                                           <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" 
                                                               OnClick="btnSave_Click"
                                                                Text="Save" CausesValidation="true" ValidationGroup="test" CommandName="AddRecord" /> &nbsp;
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                                OnClick="btnCancel_Click" Text="Cancel" />&nbsp;

                                                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary"
                                                    OnClick="btnExport_Click" Text="ExportToExcel" />&nbsp;

                                                        <asp:Button ID="btnLock" runat="server" CssClass="btn btn-danger" Font-Bold="False" Text="Lock Data" 
                                                            Visible="true" OnClick="btnLock_Click"/>

                                                        
                                                       </p>
                                            </div>
                                        </div>
                                </div>
                            </div>
                           
                          </div>
                     </div>

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        
                        <div class="row">
                            <div class="col-lg-10 col-md-10 col-sm-12 col-xs-12  form-group">
                                
                                <div class="row">
                                    <div class="col-lg-5 col-md-offset-5 col-md-5 col-md-offset-5 col-sm-12  col-xs-12  form-group">
                                        <div class="row">
                                           
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                                <asp:Label ID="lblsession" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="Main Organization*:" Visible="false"> </asp:Label>
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                    <asp:DropDownList ID="ddl_MOrg" runat="server" CssClass="dropdownlist" Width="250px"
                                                        Enabled="False" OnSelectedIndexChanged="ddl_MOrg_SelectedIndexChanged" AutoPostBack="True" Visible="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                                <asp:Label ID="lblMo" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                                                    Text="Main Organization Country*:" Visible="false"></asp:Label>
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                    <asp:DropDownList ID="ddl_country" runat="server" CssClass="dropdownlist" Width="250px"
                                                        OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="True" Visible="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                                <asp:Label runat="server" Text="Region*:" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Visible="false"></asp:Label>
                                                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                                    <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px"
                                                        OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True" Visible="false">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>


                                            <!--=========== Revamp Start ===================-->

                                            
                                            <!--=========== Revamp End ===================-->
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

             

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridTestTitle" visible="false">
                    Categories
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" >
                    <br />

                    <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CssClass="datatable table table-striped table-responsive FixedHeader" OnPreRender="gvTest_PreRender" >
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                            <asp:BoundField DataField="Categ_Id" HeaderText="Categ_Id" SortExpression="Categ_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Center_Id" HeaderText="Center_Id" SortExpression="Center_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>

                            <asp:BoundField DataField="isLock" HeaderText="isLock" SortExpression="isLock">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>



                            <asp:BoundField DataField="Block_Id" HeaderText="Block_Id" SortExpression="Block_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Gender_Id" HeaderText="Gender_Id" SortExpression="Gender_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Class_Id" HeaderText="Class_Id" SortExpression="Class_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>

                            
                            <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id" SortExpression="Subject_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>


                            <asp:TemplateField HeaderText="Sr. #">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="BlockName" HeaderText="Block">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="GenderName" HeaderText="Gender">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:BoundField DataField="CategoryName" HeaderText="Category">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                            </asp:BoundField>


                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("Categ_Id") %>'
                                        ForeColor="#004999" OnClick="btnEdit_Click" CssClass="btn-lg" CommandName="EditRecord"
                                        ToolTip="Edit Record" visible='<%# DecideDeleteShow((int)Eval("isLock")) %>'>
                                    
                                        <i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>
                                    </asp:LinkButton>
                                    <span runat="server" visible='<%# DecideLockShow((int)Eval("isLock")) %>'>
                                    <i class="glyphicon glyphicon-lock TextLabelMandatory40 text-info"></i>

                                                </span>

                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("Categ_Id") %>'
                                            ForeColor="#fc0511" OnClick="btnDelete_Click" CssClass="btn-lg"
                                            ToolTip="Delete Record" visible='<%# DecideDeleteShow((int)Eval("isLock")) %>'>
                                                <i class="glyphicon glyphicon-remove TextLabelMandatory40 text-danger"></i>
                                    </asp:LinkButton>
                                    <span runat="server" visible='<%# DecideLockShow((int)Eval("isLock")) %>'>
                                    <i class="glyphicon glyphicon-lock TextLabelMandatory40 text-info"></i>

                                                </span>
                                    </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>

<%--                    <asp:Button ID="ExportToExcel" runat="server" Text="Export To Excel" OnClick="ExportToExcel_Click" />--%>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-inline ">
                    <p>
                        <br />
                        <asp:Label ID="lblGridStatus" runat="server" Visible="false"
                            CssClass="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" Text="No Data to Display"> </asp:Label>
                    </p>
                </div>

                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">
                        <fieldset>
                            <legend style="font-size: 12px;">Export Data </legend>
                             <asp:Button ID="ShowUnassignedBtn" runat="server" 
                                 CssClass="btn btn-primary" Font-Bold="False" 
                                Text="Show Unassigned Students" 
                                 Visible="true" OnClick="ShowUnassignedBtn_Click" />
                            <br /><br />
                            <asp:Button ID="DownloadUnassignedBtn" runat="server" 
                                 CssClass="btn btn-primary" Font-Bold="False" 
                                Text="Export Excel Unassigned Students" 
                                 Visible="true" OnClick="DownloadUnassignedBtn_Click" />

                            <br /><br />
                            <br /><br />

                            <asp:Button ID="ShowUnlockedClasses" runat="server" 
                                 CssClass="btn btn-primary" Font-Bold="False" 
                                Text="Show Unlocked Classes" 
                                 Visible="true" OnClick="ShowUnlockedClasses_Click" />
                            <br /><br />
                            <asp:Button ID="DownloadUnlockedClasses" runat="server" 
                                 CssClass="btn btn-primary" Font-Bold="False" 
                                Text="Export Excel Unlocked Classes" 
                                 Visible="true" OnClick="DownloadUnlockedClasses_Click" />
                            <br /><br />
                        </fieldset>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">
                        <fieldset>
                            <legend style="font-size: 12px;">Automated Process 1. Roll Numbers-Maks Generation </legend>
                             
                            <asp:Button ID="GeneratedMaskNoBtn_" runat="server" CssClass="btn btn-primary" Font-Bold="False" 
                                Text="Generate Roll No" Visible="true" OnClick="GeneratedMaskNoBtn__Click" />
<%--                            <asp:Label ID="Label1" runat="server" Text="In Progress" ></asp:Label>--%>
                            <label id="LblInProgressRollNoGen1" style="color:red;" ></label>
                            <br />
                            <br />
                            
                            <asp:Button ID="ShowMaskNumberListBtn" runat="server" CssClass="btn btn-primary" Font-Bold="False" 
                                Text="Show Mask# List" Visible="true" OnClick="ShowMaskNumberListBtn_Click" />
                            <br />
                            <br />
                            <asp:Button ID="ExportMaskNumberListBtn" runat="server" CssClass="btn btn-primary" Font-Bold="False" 
                                Text="Export Mask# List" Visible="true" OnClick="ExportMaskNumberListBtn_Click" />


                        </fieldset>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">
                        <fieldset>
                            <legend style="font-size: 12px;">Automated Process 2. Allocate Rooms To student </legend>

                            
                            <asp:Button ID="AllocateRoomsToStudent" runat="server" CssClass="btn btn-primary" Font-Bold="False" Text="Allocate Rooms To student"
                                Visible="true" OnClick="AllocateRoomsToStudent_Click" />
                            <label id="LblInProgressAllocateRoomsToStudent" style="color:red;" ></label>

                            <br />
                                    <br />
                                    <asp:Button ID="ShowAllocatedStudentsRooms" runat="server" CssClass="btn btn-primary" Font-Bold="False" Text="Show Allocated Students Rooms"
                                        Visible="true" OnClick="ShowAllocatedStudentsRooms_Click" />
                                    <br />
                                    <br />
                                    <asp:Button ID="AllocatedRoomsStudent" runat="server" CssClass="btn btn-primary"
                                        OnClick="AllocatedRoomsStudent_Click" Text="Allocated Rooms/Student Export" />


                        </fieldset>
                    </div>

                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">
                        <fieldset>
                            <legend style="font-size: 12px;">Automated Process 3. Assign Room To Teacher </legend>

                            <asp:Button ID="AssignRoomtoTeacher" runat="server" CssClass="btn btn-primary" Font-Bold="False" Text="Assign Room To Teacher"
                                Visible="true" OnClick="AssignRoomtoTeacher_Click" />
                            <label id="LblInTeacherRoomsAllocation" style="color:red;" ></label>
                                                                <br />
                                    <br />
                                    <asp:Button ID="ShowAssignedTeacherRooms" runat="server" CssClass="btn btn-primary" Font-Bold="False" Text="Show Assigned Teacher Rooms"
                                        Visible="true" OnClick="ShowAssignedTeacherRooms_Click" />

                                    <br />
                                    <br />
                                    <asp:Button ID="AssignedTeacherRooms" runat="server" CssClass="btn btn-primary"
                                        OnClick="AssignedTeacherRooms_Click" Text="Assigned Teacher Rooms Export" />
                        </fieldset>
                    </div>
                </div>

                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <asp:GridView ID="GridViewShowShowUnassignedStudents" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                CssClass="datatable table table-striped table-responsive" OnPreRender="GridViewShowShowUnassignedStudents_PreRender" Style="height: 500px; overflow: scroll;" Caption='<span style=" padding: 10px; color: #2e6da4; font-size: 2em; ">Unassigned Students</span>' CaptionAlign="Top">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Student_No" HeaderText="ERP #">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="First_Name" HeaderText="Student">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                </Columns>
                                <SelectedRowStyle BackColor="PaleGoldenrod" />
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                            </asp:GridView>


                        <asp:GridView ID="GridViewStudentMaskList" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                CssClass="datatable table table-striped table-responsive" OnPreRender="GridViewStudentMaskList_PreRender" Style="height: 500px; overflow: scroll;" 
                                Caption='<span style=" padding: 10px; color: #2e6da4; font-size: 2em; ">System Generated Mask Number List</span>' CaptionAlign="Top">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Description" HeaderText="Session">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="TermId" HeaderText="Term">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="First_Name" HeaderText="Student">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="StudentERPNo" HeaderText="ERP #">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="StudentMaskNo" HeaderText="Mask #">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <SelectedRowStyle BackColor="PaleGoldenrod" />
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                            </asp:GridView>

                        <asp:GridView ID="GridViewShowAllocatedStudentsRooms" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                CssClass="datatable table table-striped table-responsive" OnPreRender="GridViewShowAllocatedStudentsRooms_PreRender" Style="height: 500px; overflow: scroll;" Caption='<span style=" padding: 10px; color: #2e6da4; font-size: 2em; ">Allocated Students Rooms</span>' CaptionAlign="Top">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Description" HeaderText="Session">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="TermGroup_Id" HeaderText="Term">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="First_Name" HeaderText="Student">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="StudentERPNo" HeaderText="ERP #">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="StudentMaskNo" HeaderText="Mask #">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Room_Id" HeaderText="Room">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Gender" HeaderText="Gender">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="BlockName" HeaderText="Block">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                </Columns>
                                <SelectedRowStyle BackColor="PaleGoldenrod" />
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                            </asp:GridView>


                        <asp:GridView ID="ShowAssignedTeacherRooms1" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                CssClass="datatable table table-striped table-responsive" OnPreRender="ShowAssignedTeacherRooms1_PreRender" Style="height: 500px; overflow: scroll;" Caption='<span style=" padding: 10px; color: #2e6da4; font-size: 2em; ">Show Assigned Teachers Rooms</span>' CaptionAlign="Top">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Description" HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="First_Name" HeaderText="Employee Name">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Room_Id" HeaderText="Room">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Students" HeaderText="Students">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="BlockName" HeaderText="Block">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                </Columns>
                                <SelectedRowStyle BackColor="PaleGoldenrod" />
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                            </asp:GridView>

                    </div>

                </div>


                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <asp:GridView ID="GridViewShowUnlockedClasses" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                CssClass="datatable table table-striped table-responsive" OnPreRender="GridViewShowUnlockedClasses_PreRender" Style="height: 500px; overflow: scroll;" Caption='<span style=" padding: 10px; color: #2e6da4; font-size: 2em; ">Show Unlocked Classes</span>' CaptionAlign="Top">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="BlockName" HeaderText="Block">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                </Columns>
                                <SelectedRowStyle BackColor="PaleGoldenrod" />
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                            </asp:GridView>

                    </div>

                </div>
                <div class="row">
                    <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">

                        <fieldset>
                            <legend style="font-size: 12px;">Delete. Block Configuration </legend>
                            <div class="form-group  ">
                                <asp:Label runat="server" Text="Term" CssClass="modal-title"></asp:Label><span style="color:red;"> *</span>
                                <asp:DropDownList ID="Dll_DeleteBlockCOnfig_Term" runat="server" class="form-control" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                            CssClass="dropdownlist form-control" AutoPostBack="True" >
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                    <asp:ListItem Value="1">First Term</asp:ListItem>
                                    <asp:ListItem Value="2">Second Term</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="form-group  ">
                                <asp:Label runat="server" Text="Center " CssClass="modal-title" ></asp:Label><span style="color:red;"> *</span>
                                <asp:DropDownList ID="Dll_DeleteBlockCOnfig_Center" runat="server" CssClass="dropdownlist form-control" AutoPostBack="True" ></asp:DropDownList>
                            </div>
                            <br />
                            <asp:Button ID="BtnDll_DeleteBlockCOnfig" runat="server" CssClass="btn btn-primary" Font-Bold="False" Text="Delete Block Configuration"
                                Visible="true" OnClick="BtnDll_DeleteBlockCOnfig_Click" />
                        </fieldset>
                    </div>
                </div>




                <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
    <div class="modal-dialog">
        <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="modal-content">
                    <div class="modal-header">
                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                        <h4 class="modal-title"><asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                    </div>
                    <div class="modal-body">
                        <asp:Label ID="lblModalBody" runat="server" Text=""></asp:Label>
                    </div>
                    <div class="modal-footer">
                        <button class="btn btn-info" data-dismiss="modal" aria-hidden="true">Close</button>
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
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



