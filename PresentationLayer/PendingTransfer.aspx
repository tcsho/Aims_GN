<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="PendingTransfer.aspx.cs" Inherits="PresentationLayer_PendingTransfer" %>

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
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">

                Sys.Application.add_init(function () {

                    function document_Ready() {

                        jQuery(document).ready(function () {

                            //****************************************************************


                            try {
                                jQuery('table.datatable').DataTable({
                                    destroy: true,
                                    // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                                    //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                     "<'row'<'col-sm-12'tr>>" +
                                    //                     "<'row'<'col-sm-12'l>>" +
                      "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    "columnDefs": [

                                    //    { orderable: false, targets: [16]} //disable sorting on toggle button
                                    ]
                                      ,
                                    tableTools:
                    { //Start of tableTools collection
                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                        "aButtons":
                         [ //start of button main/master collection


                         ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 25, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
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
                        jQuery(document).ready(document_Ready);
                        //            document_Ready();
                        //            alert('call back done');
                    }
);

                });
            </script>
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Pending Center/ Section Transfer Cases"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <br />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 form-group">
                </div>
                <div runat="server" id="divfilters" class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                    <div class="pull-right">
                        <asp:Button ID="btnCenter" runat="server" CssClass="btn btn-info" Text="Pending Center Transfer"
                            OnClick="btnCenter_Click" CommandArgument="Center"></asp:Button>
                        <asp:Button ID="btnSection" runat="server" CssClass="btn btn-primary" Text="Pending Section Transfer"
                            OnClick="btnSection_Click" CommandArgument="Section"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="row">
                <br />
                 <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                  <asp:Label runat="server" ID="lblerror" ForeColor="Red" CssClass="TextLabelMandatory40"
                        Visible="false"></asp:Label>
                </div>
               
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3">
                </div>
            </div>
            <div id="divStudentTitle" runat="server" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div class="row">
                        <br />
                        <asp:Label ID="lblregion" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-12 TextLabelMandatory40"
                            Text="Region : "></asp:Label>
                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="dropdownlist" Width="250px"
                                OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div class="row">
                        <asp:Label ID="lblcenter" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-12 TextLabelMandatory40"
                            Text="Center : "></asp:Label>
                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                            <asp:DropDownList ID="ddlCenter" runat="server" CssClass="dropdownlist" Width="250px"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        &nbsp; Student List
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <asp:GridView ID="gvPendingCenter" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        GridLines="None" CssClass="datatable table table-striped table-responsive" OnPreRender="gvPendingCenter_PreRender">
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                            <asp:BoundField DataField="Student_Id" HeaderText="Student Number" SortExpression="Student_Id">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Id" HeaderText="Center_Id">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_IdOLD" HeaderText="Center_IdOLD">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Grade_Id" HeaderText="Grade_Id">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NewSection_Id" HeaderText="Class Id">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OldSection_Id" HeaderText="To Class Id">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fullname" HeaderText="Student Name">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CenterNameNew" HeaderText="Transfer to Center ">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OldSectionName" HeaderText="Transfer From">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ERPSection" HeaderText="Transfer To Section ">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Tranfer Student">
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnTransfer" CommandArgument="Transfer" OnClick="btnTransfer_Click"
                                        Visible='<%# (int)(Eval("NewSection_Id"))>0  && (int)(Eval("SubjectCount"))==0   %>'> 
                                    <span class="glyphicon glyphicon-share"></span></asp:LinkButton>
                                    <asp:Label ID="Label1" runat="server" Visible='<%# (int)(Eval("SubjectCount"))>0%>'
                                        ForeColor="Red" Text="New Section Subjects do not match." Font-Size="Small"></asp:Label>
                                    <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument="Unassign" CssClass="btn btn-danger btn-small active"
                                        OnClientClick="javascript:return confirm('Stuent marks will be deleted if you unassign the student');"
                                        OnClick="btnTransfer_Click" Visible='<%#(string)(Eval("ERPSectionShow"))!="-" &&  (int)(Eval("SubjectCount"))>0%>'
                                        Text="Unassign & Transfer"> 
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <asp:GridView ID="gvSection" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        GridLines="None" CssClass="datatable table table-striped table-responsive" OnPreRender="gvSection_PreRender">
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                            <asp:BoundField DataField="Student_Id" HeaderText="Student Number" SortExpression="Student_Id">
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Id" HeaderText="Center_Id">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Id" HeaderText="Grade_Id">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OLDSection" HeaderText="To Class Id">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NewSection_Id" HeaderText="NewSection_Id">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="OLDSectionName" HeaderText="Transfer From">
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NEWSection" HeaderText="Center Name">
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Tranfer Student">
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnTransfer" CommandArgument='<%# Eval("Student_Id") %>'
                                        OnClick="btnTransferSection_Click" Visible='<%# (int)(Eval("NewSection_Id"))>0  && (int)(Eval("SubjectCount"))==0   %>'> 
                                    <span class="glyphicon glyphicon-share"></span></asp:LinkButton>
                                    <asp:Label ID="Label1" runat="server" Visible='<%# (int)(Eval("SubjectCount"))>0%>'
                                        ForeColor="Red" Text="New Section Subjects do not match" Font-Size="Small"></asp:Label>
                                    <asp:LinkButton runat="server" ID="LinkButton1" CommandArgument="Unassign" CssClass="btn btn-danger btn-small active"
                                        OnClientClick="javascript:return confirm('Stuent marks will be deleted if you unassign the student');"
                                        OnClick="btnUnassignSectionTransfer_Click" Visible='<%#(string)(Eval("ERPSectionShow"))!="-" &&  (int)(Eval("SubjectCount"))>0%>'
                                        Text="Unassign & Transfer"> 
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
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
