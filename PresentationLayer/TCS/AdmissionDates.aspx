<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdmissionDates.aspx.cs" Inherits="PresentationLayer_TCS_AdmissionDates" %>

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

                                     { orderable: false, targets: [7]} //disable sorting on toggle button
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
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Academic Session Cutt Off Date for Terms"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <div class="pull-right">
                        <br />
                        <asp:Button ID="btnAddTest" runat="server" CssClass="btn btn-primary" Font-Bold="False"
                            OnClick="btnAdd_Click" Text="Add New" />
                        <asp:Button ID="btnSync" runat="server" CssClass="btn btn-warning" Font-Bold="False"
                            OnClick="btnSyncStudents_Click" Text="Sync Students" Visible="false" />
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <asp:Label ID="lblsession" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                            Text="*Session: "> </asp:Label>
                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                            <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                Width="218px">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" runat="server" id="pan_Add"
                    visible="false">
                    <br />
                    <br />
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server">
                        Add Term Cutt Off Date</div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <br />
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblClass" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                                Text="*Term : "></asp:Label>
                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                                <asp:DropDownList ID="ddlTerm" runat="server" CssClass="dropdownlist" 
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged">
                                    <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                    <asp:ListItem Value="1" Text="First Term"></asp:ListItem>
                                    <asp:ListItem Value="2" Text="Second Term"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <br />
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label1" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                                Text="Cutt off Date : "></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                                <asp:TextBox ID="txtFromDate" runat="server" CssClass="form-control "  ></asp:TextBox>
                                <cc1:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtFromDate">
                                </cc1:CalendarExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFromDate"
                                    ErrorMessage="Cutt Off Date is a Required Field" ForeColor="Red" ValidationGroup="test" />
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 pull-right">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                    Text="Save" ValidationGroup="test" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" OnClick="btnCancel_Click"
                                    Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" runat="server" id="divList">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server"
                        id="GridTitle" visible="false">
                        Term wise Cutt Off Dates</div>
                    <asp:GridView ID="gvDates" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvDates_PreRender">
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                            <asp:BoundField DataField="ECT_CUTTOFF_Id" HeaderText="ECT_CUTTOFF_Id" SortExpression="ECT_CUTTOFF_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TermGroup_Id" HeaderText="TermGroup_Id">
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
                            <asp:BoundField DataField="Description" HeaderText="Session" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="TermDescription" HeaderText="Term">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FromDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Cutt Off Date">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnEdit" CommandArgument='<%# Eval("ECT_CUTTOFF_Id") %>'
                                        OnClick="btnEdit_Click">
                                    <span class="glyphicon glyphicon-pencil"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Delete">
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnDelete" CommandArgument='<%# Eval("ECT_CUTTOFF_Id") %>'
                                        OnClientClick="javascript:return confirm('Are you sure you want to delete the record?');"
                                        OnClick="btnDelete_Click">
                                    <span class="glyphicon glyphicon-trash"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
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
