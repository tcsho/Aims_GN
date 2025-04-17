<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="NotificationUser.aspx.cs" Inherits="PresentationLayer_TCS_NotificationGroup" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--<asp:ScriptReference Path="~/Scripts/dock1A.js" />--%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1.js" />--%>
        </Scripts>
    </cc1:ToolkitScriptManager>
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
                                  
                                    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                     "<'row'<'col-sm-12'tr>>" +
                                    //                     "<'row'<'col-sm-12'l>>" +
                      "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    "columnDefs": [

                                    //{ orderable: false, targets: [8]} //disable sorting on toggle button
                                    ],
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
                                });
                            }
                            catch (err) {
                                alert('datatable ' + err);
                            }

                        });

                    } //end of documnet_ready()



                    //Re-bind for callbacks
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(function () {
                        jq(document).ready(document_Ready);
                        //            document_Ready();
                        //            alert('call back done');
                    });

                });
            </script>
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Notifications"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="row">
                <br />
                <br />
            </div>
            <div class="row" id="divNotifications" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:GridView ID="gvNotifications" runat="server" Width="100%" AutoGenerateColumns="False"
                        CssClass="datatable table table-striped table-bordered table-hover table-sm" OnPreRender="gvNotifications_PreRender">
                        <Columns>
                            <asp:BoundField DataField="Notification_id" HeaderText="Notification_id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="No.">
                             <ItemStyle HorizontalAlign="Center" Wrap="false"   Font-Size="14px" />
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="Subject" HeaderText="Subject" >
                                <HeaderStyle HorizontalAlign="Left" Font-Size="14px"  />
                                <ItemStyle HorizontalAlign="Left" Wrap="false" Width="30%" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Message" HeaderText="Message">
                                <HeaderStyle HorizontalAlign="Left" Font-Size="14px"  />
                                <ItemStyle HorizontalAlign="Left" Wrap="true" Width="70%" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="generated_on" HeaderText="Generated On">
                              <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Read/Unread">
                              <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="LinkButton1" Visible='<%# Convert.ToBoolean( Eval("is_read"))==true %>'
                                        CommandArgument='<%#  Eval("Notification_id") %>' ToolTip="Read" Enabled="false">
                                    <span class="glyphicon glyphicon-ok"></span>
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnRead" Visible='<%# Convert.ToBoolean( Eval("is_read")) ==false %>'
                                        OnClick="btnRead_Click" CommandArgument='<%#  Eval("Notification_id") %>' ToolTip="Mark Read">
                                        <span class="glyphicon glyphicon-remove"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
