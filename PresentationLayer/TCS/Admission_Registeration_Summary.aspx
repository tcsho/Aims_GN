<%@ Page Title="Admission Summary" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Admission_Registeration_Summary.aspx.cs" Inherits="PresentationLayer_TCS_Admission_Registeration_Summary" %>

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
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
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
            <script type="text/javascript">
                function closeModal() {

                    $('#daModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
                function openModal() {

                    $('#daModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });

                }
            </script>
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Student Admission Summary"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <p>
                <br />
            </p>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="row">
                    <asp:Label ID="lblregion" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-12 TextLabelMandatory40"
                        Text="Region : "></asp:Label>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px"
                            OnSelectedIndexChanged="ddl_region_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <asp:Label ID="lblcenter" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-12 TextLabelMandatory40"
                        Text="Center : "></asp:Label>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <asp:Label ID="lblClass" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-12 TextLabelMandatory40"
                        Text="*Class: "></asp:Label>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            Width="250px" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right">
                        <asp:Button runat="server" ID="btnSearch" CssClass="btn btn-success" Visible="false"
                            OnClick="btnSearch_Click" Text="Search" />
                    </div>
                </div>
                <div class="row">
                    <br />
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection"
                    visible="false">
                    &nbsp; Student Admission Detail
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvStudentStatus" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                    CssClass="datatable table table-striped table-responsive" OnPreRender="gvStudentStatus_PreRender">
                    <AlternatingRowStyle CssClass="tr2" />
                    <Columns>
                        <asp:TemplateField HeaderText="Sr. #">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Registration_Id" HeaderText="Registration Number" SortExpression="Registration_Id">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FatherName" HeaderText="Father Name">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Admission_Date" HeaderText="Admission Date" DataFormatString="{0:MM/dd/yyyy}">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="GroupType" HeaderText="Group Type" Visible="False">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ResultDetail" HeaderText="Result Detail">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <%--<asp:BoundField DataField="Gender_Id" HeaderText="Gender">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>--%>
                        <asp:BoundField DataField="ResultStatus" HeaderText="Admission Status">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Pass / Fail">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:Label ID="Label2" runat="server" Visible='<%# (int)( Eval("StudentStatus"))==0 %>'
                                    class="glyphicon glyphicon-remove" ForeColor="Red"></asp:Label>
                                <asp:Label ID="Label3" runat="server" Visible='<%# (int)( Eval("StudentStatus"))==1 %>'
                                    class="glyphicon glyphicon-ok" ForeColor="Green"></asp:Label>
                                <asp:Label ID="Label8" runat="server" Visible='<%# (int)( Eval("StudentStatus"))==3 %>'
                                    class="glyphicon glyphicon-minus" ForeColor="Blue"></asp:Label>
                                <asp:Label ID="Label1" runat="server" Visible='<%# (int)( Eval("StudentStatus"))==2 %>'
                                    class="glyphicon glyphicon-question-sign" ForeColor="orange"></asp:Label>
                            </ItemTemplate>
                            <EditItemTemplate>
                            </EditItemTemplate>
                            <HeaderStyle />
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Add/View Marks" >
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnAddMarks" CommandArgument='<%# Eval("Registration_Id") %>'
                                    Visible='<%# (int)( Eval("ViewStatus"))==0 %>' OnClick="btnAddMarks_Click" ToolTip="Add Marks">
                                     <span  class="glyphicon glyphicon-plus"></span>
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument='<%# Eval("Registration_Id") %>'
                                    Visible='<%# (int)( Eval("ViewStatus"))==1 %>' OnClick="btnAddMarks_Click" ToolTip="View Marks">
                                  
                                    <span  class="glyphicon glyphicon-search"></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                            </EditItemTemplate>
                            <HeaderStyle />
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Discretionary Request" >
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnSubmitRequest" CommandArgument='<%# Eval("RequestStatus") %>'
                                    Visible='<%# (int)( Eval("StudentStatus"))==0 &&  (int)( Eval("RequestStatus"))==0 %>'
                                    OnClick="btnRequest_Click">
                                    
                                 <span  class="glyphicon glyphicon-new-window" ></span>
                                    
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btnWaiting" CommandArgument='<%# Eval("RequestStatus") %>'
                                    Visible='<%# (int)( Eval("StudentStatus"))==0 &&  (int)( Eval("RequestStatus"))==1 %>'
                                    OnClick="btnRequest_Click">
                                   <span  class="glyphicon glyphicon-time"></span>
                                    
                                </asp:LinkButton>
                                <asp:LinkButton runat="server" ID="btnDetailsCH" CommandArgument='<%# Eval("RequestStatus") %>'
                                    Visible='<%# ((int)( Eval("StudentStatus"))==3 || (int)( Eval("StudentStatus"))==0 ) &&  (int)( Eval("RequestStatus"))>=2 %>'
                                    OnClick="btnRequest_Click">
                                    <span  class="glyphicon glyphicon-list-alt"></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                            </EditItemTemplate>
                            <HeaderStyle />
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete" Visible="false">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDelete" CommandArgument='<%# Eval("Registration_Id") %>'
                                    OnClick="btnDelete_Click" Visible='<%# (int)( Eval("StudentStatus"))<2 && (int)( Eval("RequestStatus"))==0  %>'>
                                     <span  class="glyphicon glyphicon-trash" ></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                            </EditItemTemplate>
                            <HeaderStyle />
                            <ItemStyle />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Heads_Remarks" HeaderText="Heads Remarks">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NH_Remarks" HeaderText="NH Remarks">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NH_Approval" HeaderText="NH Approval">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="isAlone" HeaderText="isAlone">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                          <asp:TemplateField HeaderText="Discretionary Request" >
                            <ItemStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                               
                                <asp:LinkButton runat="server" ID="btnDetail" CommandArgument='<%# Eval("RequestStatus") %>'
                                    Visible='<%# ((int)( Eval("StudentStatus"))==3 || (int)( Eval("StudentStatus"))==0 ) &&  (int)( Eval("RequestStatus"))>=2 %>'
                                    OnClick="btnRequest_Click">
                                    <span  class="glyphicon glyphicon-list-alt"></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <EditItemTemplate>
                            </EditItemTemplate>
                            <HeaderStyle />
                            <ItemStyle />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
            </div>
            <div id="daModal" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                &times;</button>
                            <h4 class="modal-title">
                                Discretionary Admission Request</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                                    <asp:Label ID="lblReg" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                                <asp:Label ID="Label4" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text="Student Name : "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:Label ID="lblStdName" runat="server" CssClass="TextLabelMandatory40"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                                <asp:Label ID="Label5" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text="Result Detail : "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:Label ID="lblResultDetail" runat="server" CssClass="TextLabelMandatory40"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                                <asp:Label ID="Label6" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text="Remarks: "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:TextBox runat="server" ID="txtHRemarks" CssClass="form-control textbox" MaxLength="500"
                                        TextMode="MultiLine" Rows="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Remarks are Compulsory"
                                        ControlToValidate="txtHRemarks" Display="Dynamic" ValidationGroup="r"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Maximum of 500 characters allowed"
                                        ControlToValidate="txtHRemarks" Display="Dynamic" ValidationExpression=".{0,500}"
                                        ValidationGroup="r" />
                                </div>
                            </div>
                            <div class="row" runat="server" id="divDecision" visible="false">
                                <br />
                                <asp:Label ID="Label9" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text="School Head Decision Status: "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:Label ID="lblNHDecision" runat="server" CssClass="TextLabelMandatory40"></asp:Label>
                                </div>
                            </div>
                            <div class="row" runat="server" id="divAction" visible="false">
                                <br />
                                <asp:Label ID="Label7" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text="School Head Remarks: "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:Label ID="lblNHRemarks" runat="server" CssClass="TextLabelMandatory40"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnSaveReq" Text="Save" CssClass="btn btn-primary"
                                    OnClick="btnSubmit_Click" ValidationGroup="r" CausesValidation="True" />
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
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
