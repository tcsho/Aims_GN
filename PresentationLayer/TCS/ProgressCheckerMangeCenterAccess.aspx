<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ProgressCheckerMangeCenterAccess.aspx.cs" Inherits="PresentationLayer_TCS_ProgressCheckerMangeCenterAccess"
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

                                      { orderable: false, targets: [4] } //disable sorting on toggle button
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
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Mange Center Access"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <p>
                <br />
            </p>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 form-group">
                    <asp:Label ID="lblSubjectName" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="Subject : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:Label ID="lblSubject" runat="server" Text="" CssClass="TextLabelMandatory40 text-left"></asp:Label>
                    </div>
                    <asp:Label ID="lblRegionName" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="Region: "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="dropdownlist" ValidationGroup="class"
                            OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged" Width="200px"
                            AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 form-group">
                    <div class="pull-right">
                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary"
                            Text="Save" CausesValidation="false"></asp:Button>

                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Text="Cancel"
                            OnClick="btnCancel_Click" />
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="campusSectionTitle" visible="false">
                Campus List 
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" runat="server" id="campusSection">
                <p>
                    <br />
                </p>
                <asp:GridView ID="gvResDetail" runat="server" AutoGenerateColumns="False" CssClass="datatable table table-striped table-responsive"
                    OnRowCommand="gvResDetail_RowCommand" Width="100%" OnPreRender="gvResDetail_PreRender">
                    <Columns>


                        <asp:TemplateField HeaderText="Sr. #">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Region_Name" HeaderText="Region">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Campus Code">
                            <HeaderStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name" />
                        <asp:TemplateField HeaderText="cb">
                            <ItemStyle Font-Size="X-Small"></ItemStyle>
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                                <asp:CheckBox ID="chkAllowAccess" runat="server"
                                    Checked='<%# Convert.ToBoolean(Eval("isAllow")) %>' />
                            </ItemTemplate>
                            <EditItemTemplate>
                                <asp:CheckBox ID="chkAllowAccess" runat="server" />
                            </EditItemTemplate>
                            <HeaderTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Allow</asp:LinkButton>
                            </HeaderTemplate>
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                            <ItemTemplate>
                                <asp:CheckBox ID="chkAllowAccess" runat="server"
                                    Checked='<%# Convert.ToBoolean(Eval("isAllow")) %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr2" />
                    <HeaderStyle CssClass="tableheader" />

                    <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                </asp:GridView>
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


