<%@ Page Title="" Language="C#" AutoEventWireup="true" Inherits="PresentationLayer_TCS_Notifications" CodeFile="Notifications.aspx.cs"
    MasterPageFile="~/PresentationLayer/MasterPage.master"  %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
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
                                    // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                                    //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                     "<'row'<'col-sm-12'tr>>" +
                                    //                     "<'row'<'col-sm-12'l>>" +
                      "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    "columnDefs": [

                                    // { orderable: false, targets: [8, 9]} //disable sorting on toggle button
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
         , "order": [[0, "desc"]], "paging": false, "ordering": false, "searching": true, "info": true, "scrollX": false, "stateSave": false
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
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Notifications"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <br />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div runat="server" id="div1" class="col-lg-6 col-md-6 col-sm-6 col-xs-12 form-group">
                </div>
                <div runat="server" id="divNewNotif" class="col-lg-6 col-md-6 col-sm-6 col-xs-12 form-group">
                    <div class="pull-right">
                        <asp:Button ID="btnAddNew" runat="server" CssClass="btn btn-primary active" Text="New Notification"
                            OnClick="btnAddNew_Click" />
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="pan_NewNotif" runat="server"
                visible="false">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection ">
                        Add New Notification
                    </div>
                </div>
                <br />
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                    </div>
                    <div class="col-lg-7 col-md-7 col-sm-7 col-xs-7">
                        <div class="pull-right">
                            <asp:Button ID="btnSaveNotif" runat="server" CssClass="btn btn-success" ValidationGroup="s"
                                Text="Generate" OnClick="btnSaveNotif_Click"></asp:Button>
                            <asp:Button ID="btnDiscard" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                Text="Discard" OnClick="btnDiscard_Click"></asp:Button>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12  ">
                    <br />
                    <span class=" col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">Notification
                        Subject:</span>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:TextBox ID="txtSubject" runat="server" placeholder="Notification Subject" CssClass="form-control textbox">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Notificatio Subject is Required Field"
                            ControlToValidate="txtSubject" Display="Dynamic" ValidationGroup="s">
                        </asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Maximum of 50 characters allowed"
                            ControlToValidate="txtSubject" Display="Dynamic" ValidationExpression=".{0,50}"
                            ValidationGroup="s" />
                        <br />
                        <br />
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <span class=" col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">Notification
                        Message:</span>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:TextBox ID="txtMessage" runat="server" placeholder="Notification Message" CssClass="form-control textbox"
                            TextMode="MultiLine" Rows="5" MaxLength="4000">
                        </asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Notification Message is Required Field"
                            ControlToValidate="txtMessage" Display="Static" ValidationGroup="s">
                        </asp:RequiredFieldValidator>
                        <asp:Label runat="server" ID="lbllength" ForeColor="Red" Visible="false" Text="Maximum 4000 words allowed">
                        </asp:Label>
                        <br />
                        <br />
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <span class=" col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">Notification
                        Type:</span>
                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                        <asp:DropDownList ID="ddlNotifType" runat="server" AutoPostBack="True" AppendDataBoundItems="true"
                            CssClass="dropdownlist">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Notification Type is Required Field"
                            ControlToValidate="ddlNotifType" InitialValue="0" ValidationGroup="s">
                        </asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection " runat="server"
                    id="divselecteduser" visible="false">
                    Selected Users
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:GridView ID="gvUsers" runat="server" Width="100%" AutoGenerateColumns="False"
                        class="datatable table table-striped table-bordered table-hover table-sm " OnPreRender="gvUsers_PreRender">
                        <Columns>
                            <asp:BoundField DataField="Criteria" HeaderText="Criteria">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LogicalGroup" HeaderText="Group">
                                <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id" HeaderText="id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GroupType" HeaderText="GroupType">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="Description">
                                <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnRemove" runat="server" CommandArgument='<%#  Eval("id") %>'
                                        OnClick="btnRemove_click">
                                                      <span class="glyphicon glyphicon-trash"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <br />
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection ">
                    List of Users
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <br />
                    <div class="row text-right">
                        <asp:LinkButton ID="btnAddLG" runat="server" Text="Add to Selected User" OnClick="btnAddLG_Click"
                            CssClass="btn btn-warning active"></asp:LinkButton>
                    </div>
                    <br />
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                            Show
                            <asp:DropDownList ID="ddlPageSize" runat="server" AutoPostBack="true" OnSelectedIndexChanged="PageSize_Changed"
                                CssClass="dropdownlist">
                            </asp:DropDownList>
                            entries
                        </div>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right ">
                            <asp:Repeater ID="rptPager" runat="server">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkPage" runat="server" Text='<%#Eval("Text") %>' CommandArgument='<%# Eval("Value") %>'
                                        OnClick="Page_Changed" CssClass="btn btn-primary" ClientIDMode="AutoID"></asp:LinkButton>
                                </ItemTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                    <br />
                    <asp:GridView ID="gvLogicalGroup" runat="server" Width="100%" AutoGenerateColumns="False"
                        OnRowCommand="gvLogicalGroup_RowCommand" OnPreRender="gvLogicalGroups_PreRender"
                        class="datatable table table-striped table-bordered table-hover table-sm ">
                        <Columns>
                            <asp:BoundField DataField="Criteria" HeaderText="Criteria">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LogicalGroup" HeaderText="Group">
                                <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="id" HeaderText="id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="GroupType" HeaderText="GroupType">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Remarks" HeaderText="Description" >
                                <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnRemove" runat="server" CommandArgument='<%#  Eval("id") %>'
                                        OnClick="btnAdd_Click" >
                                                      <span class="glyphicon glyphicon-plus"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Select">
                                <HeaderTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Select</asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbAllow" runat="server" AutoPostBack="false" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
            <div class="panel" id="divListOfNotif" runat="server">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    List of Notifications
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="panel_body">
                        <asp:GridView ID="gvNotifications" runat="server" Width="100%" AutoGenerateColumns="False"
                            CssClass="datatable table table-striped table-bordered table-hover table-sm "
                            OnPreRender="gvNotifications_PreRender">
                            <Columns>
                                <asp:BoundField DataField="Notification_Id" HeaderText="NetworkCenterId">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Nt_Type_Id" HeaderText="NetworkRegion_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Subject" HeaderText="Subject" SortExpression="Notif_Subject">
                                    <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Message" HeaderText="Message" SortExpression="Notif_Message">
                                    <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="generated_on" HeaderText="Sent On" SortExpression="CreatedOn"
                                    DataFormatString="{0:MM/dd/yy}">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SentTo" HeaderText="Sent To" SortExpression="SentTo">
                                    <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="DeliveredTo" HeaderText="Delivered To" SortExpression="DeliveredTo">
                                    <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ReadBy" HeaderText="Read By" SortExpression="ReadBy">
                                    <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Visible">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" Visible='<%# Convert.ToBoolean( Eval("Is_Lock"))==false %>'>
                            <span class="glyphicon glyphicon-ok"></span>
                                        </asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton2" runat="server" Visible='<%# Convert.ToBoolean( Eval("Is_Lock"))==true %>'>
                            <span class="glyphicon glyphicon-ok"></span>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                    <HeaderStyle HorizontalAlign="Left" Wrap="true" Font-Size="14px" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False">
                        </asp:Label>
                    </div>
                </div>
            </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

