<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="Diag_Prog_Unit_Topic.aspx.cs" Inherits="PresentationLayer_TCS_Diag_Prog_Unit_Topic" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
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

                                    // { orderable: false, targets: [5, 6] } //disable sorting on toggle button
                                    ]

                                ,


                                    tableTools:
                    { //Start of tableTools collection
                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                        "aButtons":
                         [ //start of button main/master collection
                         ]
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
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Diagnostic Progress Unit Topics"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <p>
                <br />
            </p>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">

                    <asp:Label CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" runat="server" Text="Subject"></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:Label ID="lblSubject" CssClass="TextLabelMandatory40" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:Label Text="Class: " runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:Label ID="lblClass" runat="server" CssClass="TextLabelMandatory40"></asp:Label>
                    </div>
                    <asp:Label Text="Unit Description: " runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <span class="lblBold" style="font-size: medium"></span>
                        <asp:Label ID="lblDescription" runat="server" align="center" CssClass="TextLabelMandatory40"
                            Style="font-size: medium; font-weight: normal"></asp:Label>
                    </div>

                    <asp:Label Text="Unit Percentage: " runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <span class="lblBold" style="font-size: medium"></span>
                        <asp:Label ID="lblPercentage" runat="server" align="center" CssClass="TextLabelMandatory40"
                            Style="font-size: medium; font-weight: normal"></asp:Label>
                        <asp:Label runat="server" ID="lblhidden"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 form-group">
                    <div class="pull-right">
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-danger"
                            Font-Bold="False" OnClick="btnBack_Click" ValidationGroup="btnNew" Text="Back"></asp:Button>
                        <asp:LinkButton ID="but_new" runat="server" CssClass="btn btn-primary btn-lg active"
                            Font-Bold="False" OnClick="but_new_Click" ValidationGroup="btnNew">
                        Add New Topic
                        </asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" visible="false">
                    Diagnostic Progress Unit Topics
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">

                <asp:GridView ID="UnitView" runat="server" AutoGenerateColumns="False" CssClass="datatable table table-striped table-responsive"
                   OnPreRender="UnitView_PreRender">
                    <AlternatingRowStyle CssClass="tr2" />
                    <Columns>
                        <asp:BoundField DataField="Topic_Id" SortExpression="Topic_Id"
                            HeaderText="Unit_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sr. #">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" />
                        </asp:TemplateField>

                        <asp:BoundField DataField="Topic_Description" HeaderText="Topic Description" SortExpression="Topic_Description">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Objective" HeaderText="Objective" SortExpression="Objective">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Duration" HeaderText="Duration (Week(s))" SortExpression="Duration">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Edit">
                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server"
                                    CommandArgument='<%# Eval("Topic_Id") %>' ForeColor="#004999"
                                    ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("Topic_Id") %>'
                                    CausesValidation="false" ForeColor="#004999" ImageUrl="~/images/delete.gif" OnClick="btnDelete_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr2" />
                    <HeaderStyle CssClass="tableheader" />
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                    <p>
                        <br />
                    </p>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        &nbsp; Diagnostic Progress Unit Topic Information
                    </div>
                    <div class="form-group">
                        <asp:Label class=" col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" runat="server">
                            Topic Desccription * :</asp:Label>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 form-group">
                            <asp:TextBox ID="txtTopicDescription" runat="server" MaxLength="500" Rows="3"
                                TextMode="MultiLine" CssClass="form-control textbox"></asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class=" col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" runat="server">
                          Objectives * :</asp:Label>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 form-group">
                            <asp:TextBox ID="txtObective" runat="server" MaxLength="500" CssClass="form-control textbox"
                                TextMode="MultiLine" Rows="5">

                            </asp:TextBox>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class=" col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" runat="server">
                          Duration * : </asp:Label>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 form-group">
                            <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                                <asp:TextBox ID="txtDuration" runat="server" MaxLength="500"
                                    TextMode="SingleLine" CssClass="form-control textbox"></asp:TextBox>
                            </div>
                            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
                                <br />
                                <asp:Label ID="lblWeek" runat="server" Text="Week(s)" CssClass="TextLabelMandatory40 text-left"></asp:Label>
                            </div>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12 text-right">
                            <asp:Button runat="server" ID="but_save" OnClick="but_save_Click" CssClass="btn btn-primary"
                                Text="Save"></asp:Button>
                            <asp:Button runat="server" ID="but_cancel" OnClick="but_cancel_Click"
                                CssClass="btn btn-danger" CausesValidation="False" Text="Cancel"></asp:Button>
                        </div>
                    </div>


                </asp:Panel>
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
