<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="SeatPlanRoomAllocation.aspx.cs" Inherits="PresentationLayer_TCS_SeatPlanRoomAllocation" %>


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
            <div class="form-group">


                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Seating Plan Categories"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <p>

                    <br />
                </p>

                <div class="row">
                    <div class="col-lg-10 col-lg-offset-1 col-md-10 col-md-offset-1 col-sm-10 col-xs-10 col-sm-offset-1 col-xs-offset-1">
                        <fieldset>
                            <legend>Room/Class Allocation</legend>
                            <div class="row">


                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                    <div class="row ">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                            <div class="form-group">
                                                <asp:Label runat="server" Text="Center"
                                                    CssClass="modal-title">
                                                </asp:Label>
                                                <asp:DropDownList ID="ddl_center" runat="server"
                                                    CssClass="dropdownlist form-control"
                                                    AutoPostBack="false">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                    <div class="row ">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                            <div class="form-group">
                                                <asp:Label runat="server" Text="Session"
                                                    CssClass="modal-title">
                                                </asp:Label>
                                                <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist form-control"
                                                    AutoPostBack="True">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                    <div class="row ">
                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                            <div class="form-group">
                                                <asp:Label runat="server" Text="Term"
                                                    CssClass="modal-title"></asp:Label>
                                                <asp:DropDownList ID="ddlTerm" runat="server"
                                                    CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                    CssClass="dropdownlist form-control"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                    <asp:ListItem Value="1">First Term</asp:ListItem>
                                                    <asp:ListItem Value="2">Second Term</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>

                            </div>
                        </fieldset>


                        <%--<div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                
                            </div>
                        </div>--%>
                    </div>
                </div>

                <!--=========================== Start ==================-->
                <div class="row">
                    <div class="col-lg-10 col-lg-offset-1 col-md-10 col-md-offset-1 col-sm-10 col-xs-10 col-sm-offset-1 col-xs-offset-1">
                        <div class="row">

                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " style="background: #f6f6f6;">
                                <div id="AdEditCate" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " style="background: #f6f6f6;">
                                    <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                        <h2 style="border-bottom: 3px solid #f6f6f6; padding-bottom: 10px;">Room Allocation Plan</h2>

                                        <div class="modal-dialog" style="margin: auto; width: 100%;">
                                            <!-- Modal content-->
                                            <div class="modal-content" style="-webkit-box-shadow: none; box-shadow: none; border: none; background: #f6f6f6;">
                                                <div class="modal-header">
                                                    <%--<button type="button" class="close" data-dismiss="modal">&times;</button>--%>
                                                    <%--<h4 class="modal-title">Room Allocation Plan</h4>--%>
                                                </div>
                                                <div class="modal-body">
                                                    <div class="row" style="border-bottom: 1px solid #fff3f3; padding-bottom: 10px;">
                                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                                            <asp:Label ID="Label1" runat="server" CssClass="modal-title" Text="Class :" Style="color: #550000; font-weight: bold;"></asp:Label>
                                                            <asp:Label ID="lblClass" runat="server" CssClass="TextLabelLeft"></asp:Label>


                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                                            <asp:Label ID="Label4" runat="server" CssClass="modal-title" Text="Block Name :" Style="color: #550000; font-weight: bold;"></asp:Label>
                                                            <asp:Label ID="lblBlock" runat="server" CssClass="TextLabelLeft"></asp:Label>

                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                                            <asp:Label ID="Label6" runat="server" CssClass="modal-title" Text="Gender :" Style="color: #550000; font-weight: bold;"></asp:Label>
                                                            <asp:Label ID="lblGender" runat="server" CssClass="TextLabelLeft"></asp:Label>
                                                        </div>
                                                    </div>
                                                    <div class="row" style="border-bottom: 1px solid #fff3f3; display:none; padding-bottom: 10px;" visible="false" >
                                                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " visible="false">
                                                            <p id="ShowSubject" runat="server" visible="false">
                                                                <asp:Label ID="lbl1" runat="server" CssClass="modal-title" Text="Subject :" Style="color: #550000; font-weight: bold;"></asp:Label>
                                                                <asp:Label ID="lblSubject" runat="server" CssClass="TextLabelLeft"></asp:Label>
                                                            </p>

                                                            <asp:Label ID="lbl2" runat="server"  visible="false" CssClass="modal-title" Style="color: #550000; font-weight: bold;" Text="Category :"></asp:Label>
                                                            <asp:Label ID="lblCategory" runat="server"  visible="true" CssClass="TextLabelLeft"></asp:Label>

                                                        </div>
                                                    </div>

                                                    <div class="row" style="border-bottom: 1px solid #fff3f3; padding-bottom: 10px;">
                                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                                            <asp:Label ID="lblRoom" runat="server" CssClass="modal-title" Style="color: #550000; font-weight: bold;" Text="Room #:"></asp:Label>
                                                            <asp:DropDownList ID="ddlRoom" runat="server" CssClass="dropdownlist form-control" AutoPostBack="false"></asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="ddlRoom"
                                                                ErrorMessage="Room # is a required filed" ForeColor="Red" ValidationGroup="room" />
                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                                            <asp:Label ID="lbl4" runat="server" CssClass="modal-title" Style="color: #550000; font-weight: bold;" Text="Students :"></asp:Label>
                                                            <asp:TextBox ID="txtStudents" runat="server" CssClass="input-sm form-control"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator3" ControlToValidate="txtStudents" runat="server"
                                                                ValidationGroup="room" ForeColor="Red" ErrorMessage="Enter Only Integer Values"
                                                                Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                                            <asp:TextBox ID="CenterID_" runat="server" Visible="false"></asp:TextBox>
                                                            <asp:TextBox ID="SessionID_" runat="server" Visible="false"></asp:TextBox>
                                                            <asp:TextBox ID="TermID_" runat="server" Visible="false"></asp:TextBox>
                                                            <asp:TextBox ID="ClassID_" runat="server" Visible="false"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-4 col-md-4 col-sm-12 col-xs-12 ">
                                                            <p>&nbsp;</p>
                                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                                                Text="Save" CausesValidation="true" ValidationGroup="room" />
                                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                                OnClick="btnCancel_Click" Text="Cancel" />

                        

                                                        </div>
                                                    </div>
                                                    <asp:Label ID="TotalStudents" runat="server" CssClass="modal-title" Style="color: #550000; font-weight: bold;" Text="Total Students :"></asp:Label> 
                                                    <br />
                                                    <asp:Label ID="AllocatedVsTotal" runat="server" CssClass="modal-title" Style="color: #550000; font-weight: bold;" Text="Allocated Students :"></asp:Label>

                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>

                                    <br />

                                </div>
                                <br />
                                <span style=" padding: 10px; color: #2e6da4; font-size: 2em; ">Room Allocation Detail</span>
                                <asp:GridView ID="gvRooms" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                    CssClass="datatable table table-striped table-responsive" OnPreRender="gvRooms_PreRender" 
                                    >

                                    <Columns>
                                        <asp:BoundField DataField="RoomAllot_Id" HeaderText="RoomAllot_Id" SortExpression="RoomAllot_Id">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Room_Id" HeaderText="Room_Id" SortExpression="Room_Id">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="GenderName" HeaderText="GenderName" SortExpression="GenderName">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>


                                        <asp:BoundField DataField="BlockName" HeaderText="BlockName" SortExpression="BlockName">
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
                                            <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="CategoryName" HeaderText="Category">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="RoomName" HeaderText="Room">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Students" HeaderText="Students">
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle Font-Size="12px" HorizontalAlign="Center" />
                                        </asp:BoundField>

                                        <asp:TemplateField HeaderText="Edit">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemTemplate>

                                                
                                                <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("RoomAllot_Id") %>'
                                                    ForeColor="#004999" OnClick="btnEdit_Click" CssClass="btn-lg"
                                                    ToolTip="Edit Record"
                                                   visible='<%# Eval("IsLockedForRooms").ToString() == "0" ? true : false %>'
                                                    >
                                    
                                        <i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                             

                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("RoomAllot_Id") %>'
                                                    ForeColor="#fc0511" OnClick="btnDelete_Click" CssClass="btn-lg"
                                                    ToolTip="Delete Record"
                                                    visible='<%# Eval("IsLockedForRooms").ToString() == "0" ? true : false %>'>
                                    
                                        <i class="glyphicon glyphicon-remove TextLabelMandatory40 text-danger"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle BackColor="PaleGoldenrod" />
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                                </asp:GridView>





                                <asp:Label ID="Label3" runat="server" Visible="false"
                                    CssClass="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" Text="No Data to Display"> </asp:Label>
                                <br />
                            </div>
                            <br />
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                <br />
                                <%--                                <h2 style="border-bottom: 3px solid #f6f6f6; padding-bottom: 10px;">School Block Distribution</h2>--%>
                                <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                    CssClass="datatable table table-striped table-responsive" OnPreRender="gvTest_PreRender" 
                                    Style="height: 500px; overflow: scroll;" 
                                    Caption='<span style=" padding: 10px; color: #2e6da4; font-size: 2em; ">School Block Distribution</span>' 
                                    CaptionAlign="Top">
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

                                        <asp:BoundField DataField="CountTotalStudents" HeaderText="Subject_Id" SortExpression="Subject_Id">
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


                                        <asp:TemplateField HeaderText="Add Rooms">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnRoomAdd" runat="server" CommandArgument='<%# Eval("Categ_Id") %>'
                                                    ForeColor="#004999" OnClick="btnAddRoom_Click" CssClass="btn-lg"
                                                    ToolTip="Add Room"
                                                    Visible='<%# ShowUnlockedBlocks((int)Eval("CountAssignStudent"), (int)Eval("CountTotalStudents"), (int)Eval("IsLockedForRooms")) %>'
                                                    >
                                    
                                        <i class="glyphicon glyphicon-plus TextLabelMandatory40 text-success"></i>
                                                </asp:LinkButton>
                                                <span runat="server" visible='<%# DecideHere((int)Eval("CountAssignStudent"), (int)Eval("CountTotalStudents"), (int)Eval("IsLockedForRooms")) %>'>Locked
                                                    <asp:LinkButton OnCommand="ibtnEdit_Command1" Text="Locked" ID="LinkButton1" runat="server" Height="20px" Width="20px" 
                                                    ToolTip="Edit  this Category"
                                                    CommandArgument='<%#  Eval("Categ_Id")+","+Eval("CountAssignStudent")+","+Eval("CountTotalStudents")  %>' 
                                                    

                                                    Visible='<%# ShowUnlockedBlocks((int)Eval("CountAssignStudent"), (int)Eval("CountTotalStudents"), (int)Eval("IsLockedForRooms")) %>' 
                                                    CommandName="EditObject" CausesValidation="False"> 
                                                </asp:LinkButton>

                                                </span>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="Show Detail">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnDetails" runat="server" CommandArgument='<%# Eval("Categ_Id") %>'
                                                    ForeColor="#fc0511" OnClick="btnShowDetail_Click" CssClass="btn-lg"
                                                    ToolTip="Show Room Details">
                                        <i class="glyphicon glyphicon-list TextLabelMandatory40 text-info"></i>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Assigned / Total Students">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                                <%# Eval("CountAssignStudent") %> / <%# Eval("CountTotalStudents") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Lock Block">
                                            <ItemStyle HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemTemplate>
                                              <%--<asp:Button ID="BtnRowLock" CssClass="submitButton" Text="Comment" runat="server" 
                                                  CommandName="Comment" 
                                                  CommandArgument='<%#Eval("Categ_Id")+","+ Eval("CountAssignStudent")+","+ Eval("CountTotalStudents")%>' />--%>

                                                <asp:LinkButton OnCommand="ibtnEdit_Command" ID="ibtnEdit" runat="server" Height="20px" Width="20px" 
                                                    ToolTip="Edit  this Category"
                                                    CommandArgument='<%#  Eval("Categ_Id")+","+Eval("CountAssignStudent")+","+Eval("CountTotalStudents")  %>' 
                                                    Visible='<%# ShowUnlockedBlocks((int)Eval("CountAssignStudent"), (int)Eval("CountTotalStudents"), (int)Eval("IsLockedForRooms")) %>'

                                                    
                                                    CommandName="EditObject" CausesValidation="False"> 
                                                     <asp:Label  ID="EditLockedLbl" 
                                                         >
                                                    <i class="glyphicon glyphicon-edit"  ></i>&nbsp;
                                                     </asp:Label>

                                                </asp:LinkButton>

                                                <asp:Label ID="ShowLockButton" runat="server" CssClass="modal-title" Style="color: #550000; font-weight: bold;" Text="Locked" Visible='<%# DecideHere((int)Eval("CountAssignStudent"), (int)Eval("CountTotalStudents"), (int)Eval("IsLockedForRooms")) %>'>
                                                    <i class="glyphicon glyphicon-lock" ></i>
                                                </asp:Label>
                                                <%--<asp:LinkButton OnCommand="LOckDecision_Command" ID="LOckDecision" runat="server" Height="20px" Width="20px" 
                                                    ToolTip="Edit  this Category"
                                                    CommandArgument='<%#  Eval("Categ_Id")+","+Eval("CountAssignStudent")+","+Eval("CountTotalStudents")  %>' 
                                                    Visible='<%# DecideHere((int)Eval("CountAssignStudent"), (int)Eval("CountTotalStudents"), (int)Eval("IsLockedForRooms")) %>'

                                                    CommandName="EditObject" CausesValidation="False"> 
                                                     <asp:Label  ID="LockedLbl" 
                                                            <i class="glyphicon glyphicon-lock" ></i>&nbsp;

                                                     </asp:Label>
                                                </asp:LinkButton>--%>



                                                <%--<span runat="server" visible='<%# DecideHere((int)Eval("CountAssignStudent"), (int)Eval("CountTotalStudents"), (int)Eval("IsLockedForRooms")) %>'>Locked
                                                    <asp:LinkButton OnCommand="ibtnEdit_Command1" Text="Locked" ID="LinkButton1" runat="server" Height="20px" Width="20px" 
                                                    ToolTip="Edit  this Category"
                                                    CommandArgument='<%#  Eval("Categ_Id")+","+Eval("CountAssignStudent")+","+Eval("CountTotalStudents")  %>' 
                                                    

                                                    Visible='<%# ShowUnlockedBlocks((int)Eval("CountAssignStudent"), (int)Eval("CountTotalStudents"), (int)Eval("IsLockedForRooms")) %>' 
                                                    CommandName="EditObject" CausesValidation="False"> 
                                                </asp:LinkButton>

                                                </span>--%>

                                                <%--<span style="color: red;" runat="server" visible='<%# ShowUnlockedBlocks((int)Eval("CountAssignStudent"), (int)Eval("CountTotalStudents")) %>'>Un-lock
                                   

                                                </span>--%>

                                                <%--<asp:LinkButton ID="btnLockBlock" runat="server" CommandArgument='<%# Eval("Categ_Id") %>'
                                    ForeColor="#fc0511" OnClick="btnLockBlock_Click" CssClass="btn-lg"
                                    ToolTip="Lock Block">
                                        <i class="glyphicon glyphicon-ok TextLabelMandatory40 text-info"></i>
                                </asp:LinkButton>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>



                                    </Columns>
                                    <SelectedRowStyle BackColor="PaleGoldenrod" />
                                    <RowStyle CssClass="tr1" />
                                    <HeaderStyle CssClass="tableheader" />
                                    <AlternatingRowStyle CssClass="tr2" />
                                </asp:GridView>

                                <asp:Label ID="lblGridStatus" runat="server" Visible="false"
                                    CssClass="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" Text="No Data to Display"> </asp:Label>

                            </div>
                            <br />
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">

                                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary"
                                    OnClick="btnExport_Click" Text="School Block Distribution Export To Excel" Visible="true"
                                    />


                            </div>
                            <br />


                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">
                                <fieldset>
                                    <legend style="font-size: 12px;">Rooms Allocation  </legend>
                                    <br />
                                    <br />
                                    <asp:Button ID="ShowRoomsAllocationBYCenterBtn" 
                                        runat="server" CssClass="btn btn-primary" Font-Bold="False" 
                                        Text="Show Rooms Allocation "
                                        Visible="true" OnClick="ShowRoomsAllocationBYCenterBtn_Click" />
                                    <br />
                                    <br />
                                    <asp:Button ID="ExcelAllocationBYCenterBtn" runat="server" CssClass="btn btn-primary"
                                        OnClick="ExcelAllocationBYCenterBtn_Click" Text="Rooms Allocation Excel Export" />
                                </fieldset>


                            </div>


                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">
                                <fieldset>
                                    <legend style="font-size: 12px;">List Roll Numbers-Maks </legend>
<%--                                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Font-Bold="False" 
                                        Text="Generate Roll No" Visible="true" OnClick="GenerateRollNOButton_Click" />--%>
                                    <br />
                                    <br />
                                    <asp:Button ID="ShowGeneratedMaskNoBtn" runat="server" CssClass="btn btn-primary" Font-Bold="False" Text="Show Generated Mask Numbers"
                                        Visible="true" OnClick="ShowGeneratedMaskNoBtn_Click" />
                                    <br />
                                    <br />
                                    <asp:Button ID="GeneratedMaskNumbersExport" runat="server" CssClass="btn btn-primary"
                                        OnClick="GeneratedMaskNumbersExport_Click" Text="Generated Mask Numbers Excel Export" />


                                </fieldset>
                            </div>

                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">
                                <fieldset>
                                    <legend style="font-size: 12px;">Automated Process 2. Allocate Rooms To student </legend>

                                   <%-- <asp:Button ID="AllocateRoomsToStudent" runat="server" CssClass="btn btn-primary" Font-Bold="False" Text="Allocate Rooms To student"
                                        Visible="true" OnClick="AllocateRoomsToStudent_Click" />--%>
                                    <br />
                                    <br />
                                    <asp:Button ID="ShowAllocatedStudentsRooms" runat="server" CssClass="btn btn-primary" Font-Bold="False" Text="Show Allocated Students Rooms"
                                        Visible="true" OnClick="ShowAllocatedStudentsRooms_Click" />
                                    <br />
                                    <br />
                                    <asp:Button ID="AllocatedRoomsStudent" runat="server" CssClass="btn btn-primary"
                                        OnClick="AllocatedRoomsStudent_Click" Text="Allocated Rooms/Student Excel Export" />

                                </fieldset>
                            </div>

                            <div class="col-lg-3 col-md-3 col-sm-12 col-xs-12 ">
                                <fieldset>
                                    <legend style="font-size: 12px;">Automated Process 3. Assign Room To Teacher </legend>
                                    <br />
                                    <br />
                                    <asp:Button ID="ShowAssignedTeacherRooms" runat="server" CssClass="btn btn-primary" Font-Bold="False" Text="Show Assigned Teacher Rooms"
                                        Visible="true" OnClick="ShowAssignedTeacherRooms_Click" />

                                    <br />
                                    <br />
                                    <asp:Button ID="AssignedTeacherRooms" runat="server" CssClass="btn btn-primary"
                                        OnClick="AssignedTeacherRooms_Click" Text="Assigned Teacher Rooms Excel Export" />
                                </fieldset>


                            </div>



                            <%--<h2 style="border-bottom: 3px solid #f6f6f6; padding-bottom: 10px;">Automation Process</h2>--%>


                            <br />
                            <div style="clear: both; height: 10px;"></div>
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
                                CssClass="datatable table table-striped table-responsive" OnPreRender="ShowAssignedTeacherRoomsGridView_PreRender" Style="height: 500px; overflow: scroll;" Caption='<span style=" padding: 10px; color: #2e6da4; font-size: 2em; ">Show Assigned Teachers Rooms</span>' CaptionAlign="Top">
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


                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">


                                    <asp:Label ID="lblsession" runat="server"
                                        CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40  form-control"
                                        Text="Main Organization*:" Visible="false"> </asp:Label>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
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
                                </div>

                            </div>
                        </div>


                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                                <asp:GridView ID="GridViewShowRoomsAllocationBYCenter" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                CssClass="datatable table table-striped table-responsive" OnPreRender="GridViewShowRoomsAllocationBYCenter_PreRender" Style="height: 500px; overflow: scroll;" Caption='<span style=" padding: 10px; color: #2e6da4; font-size: 2em; ">Rooms Allocation List</span>' CaptionAlign="Top">
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
                                    <asp:BoundField DataField="Room_Id" HeaderText="Room">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="BlockName" HeaderText="Block">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="12px" HorizontalAlign="Left" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Students" HeaderText="Students">
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

                    </div>
                </div>
                <!--=========================== End   ==================-->



            </div>



            <%-- <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridTestTitle" visible="false">
                Categories
            </div>--%>
            <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <br />
                
            </div>--%>

            <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-inline ">
                <p>
                    <br />
                    
                </p>
            </div>--%>




            <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="Div1" visible="false">
                Rooms
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <br />
                
            </div>

            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-inline ">
                <p>
                    <br />
                    
                </p>
            </div>--%>
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


