<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="NetworkStandAloneCenters.aspx.cs" Inherits="PresentationLayer_TCS_NetworkStandAloneCenters" %>

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
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Stand Alone Campus List"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
            <br />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div runat="server" class="col-lg-6 col-md-6 col-sm-6 col-xs-12 ">
                </div>
                <div runat="server" class="col-lg-6 col-md-6 col-sm-6 col-xs-12 form-group text-right">
                    <asp:Button runat="server" ID="btnAddPanel" CssClass="btn btn-primary" OnClick="btnAddCenter_Click" Text="Add New"/>
                    <asp:Button runat="server" ID="btnCancel" CssClass="btn btn-danger" OnClick="btnCancelCenter_Click" Text="Cancel" Visible="false"/>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div runat="server" class="col-lg-5 col-md-5 col-sm-5 col-xs-5 TextLabelMandatory40 text-right">
                    Region:
                </div>
                <div runat="server" class="col-lg-7 col-md-7 col-sm-7 col-xs-7 form-group">
                    <asp:DropDownList runat="server" ID="ddlRegion" CssClass="dropdownlist" OnSelectedIndexChanged="ddlRegion_OnSelectedIndexChanged" AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" runat="server" id="SAcampusTite" visible="false">
                <div runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    &nbsp; List of Stand Alone Campuses
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvCenter" runat="server" Width="100%" AutoGenerateColumns="False"
                    CssClass="datatable table table-hover table-responsive"  OnPreRender="gvCenter_PreRender">
                    <Columns>
                        
                        <asp:BoundField DataField="Net_Cent_Id" HeaderText="Net_Cent_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Id" HeaderText="Region_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="Region_Name" HeaderText="Region Name" SortExpression="Region_Name">
                            <ItemStyle HorizontalAlign="Left" Wrap="true" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name" SortExpression="Center Name">
                            <ItemStyle HorizontalAlign="Left" Wrap="true" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemTemplate>
                                <asp:LinkButton runat="server"  ID="btnDelete" OnClick="btnDelete_Click"  
                                CommandArgument='<%# Eval("Net_Cent_Id") %>' OnClientClick="javascript:return confirm('Are you sure you want to Delete?');">
                                   <span class="glyphicon glyphicon-trash"></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" HorizontalAlign="Center" />
                    <AlternatingRowStyle CssClass="tr2" />
                    <SelectedRowStyle CssClass="tr_select" />
                </asp:GridView>
            </div>

            <div runat="server" id="divAddNew" visible="false">
             <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="Div1" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    &nbsp; List of  Campuses
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvAllCenter" runat="server" Width="100%" AutoGenerateColumns="False"
                    CssClass="datatable table table-hover table-responsive"  OnPreRender="gvAllCenter_PreRender">
                    <Columns>
                        
                        <asp:BoundField DataField="Region_Id" HeaderText="Region_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        
                        <asp:BoundField DataField="Region_Name" HeaderText="Region Name" SortExpression="Region_Name">
                            <ItemStyle HorizontalAlign="Left" Wrap="true" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name" SortExpression="Center Name">
                            <ItemStyle HorizontalAlign="Left" Wrap="true" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Add">
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnSave" OnClick="btnSave_Click"  CommandArgument='<%# Eval("Center_Id") %>' >
                                <span class="glyphicon glyphicon-plus"></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" HorizontalAlign="Center" />
                    <AlternatingRowStyle CssClass="tr2" />
                    <SelectedRowStyle CssClass="tr_select" />
                </asp:GridView>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
