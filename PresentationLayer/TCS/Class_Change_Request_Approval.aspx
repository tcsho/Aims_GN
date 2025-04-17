<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Class_Change_Request_Approval.aspx.cs" Inherits="PresentationLayer_TCS_Class_Change_Request_Approval" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
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

                                     { orderable: false, targets: [8,9]} //disable sorting on toggle button
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
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Class Change Request Approval"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <br />
            </div>
            
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
                <div class="row">
                    <asp:Label ID="lblClass" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-12 TextLabelMandatory40"
                        Text="Class: "></asp:Label>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            Width="250px" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <br />
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 form-group">
                </div>
                <div runat="server" id="divfilters" class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                    <div class="pull-right">
                        <asp:Button ID="btnall" runat="server" CssClass="btn btn-info" OnClick="btnAll_Click"
                            Text="All"></asp:Button>
                        <asp:Button ID="btnPending" runat="server" CssClass="btn btn-primary" OnClick="btnPending_Click"
                            Text="Pending"></asp:Button>
                        <asp:Button ID="btnShowApproved" runat="server" CssClass="btn btn-success" OnClick="btnShowApproved_Click"
                            Text="Approved by RD"></asp:Button>
                        <asp:Button ID="btnShowDisapproved" runat="server" CssClass="btn btn-danger" OnClick="btnShowDisApproved_Click"
                            Text="Disapproved by RD"></asp:Button>
                        <asp:Button ID="btnChanged" runat="server" CssClass="btn btn-warning" OnClick="btnProcessed_Click"
                            Text="Class Changed" Visible="false"></asp:Button>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="divStudentTitle" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection"
                    visible="false">
                    &nbsp; Student List
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvStudent" runat="server" AutoGenerateColumns="False" BorderStyle="None" OnRowDataBound="gvStudent_RowDataBound"
                    GridLines="None" CssClass="datatable table table-striped table-responsive" OnPreRender="gvStudent_PreRender">
                    <AlternatingRowStyle CssClass="tr2" />
                    <Columns>
                        <asp:BoundField DataField="CCReq_Id" HeaderText="Request Number" SortExpression="CCReq_Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Id" HeaderText="Region Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FromClass_Id" HeaderText="Class Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ToClass_Id" HeaderText="To Class Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="CCReason_Id" HeaderText="Reason Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="List of Students">
                            <ItemStyle HorizontalAlign="Center" Width="100%" />
                            <ItemTemplate>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Student # :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Student_Id")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Student Name :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("fullname")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Region
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Region_Name")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Center
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Center_Name")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Current Class:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("FromClass_Name")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Required Class:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Class_Name") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Reason:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Reason_Description")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Decision:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <div runat="server" id="div2" visible='<%# (int)( Eval("isApproved"))==1 %>'>
                                            <span class="glyphicon glyphicon-ok" style="color: Green"></span>
                                        </div>
                                        <div runat="server" id="div3" visible='<%# (int)( Eval("isApproved"))==0 %>'>
                                            <span class="glyphicon glyphicon-remove" style="color: Red"></span>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Requst date:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Submitted_On")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Decision Date:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Approved_On") %>
                                    </div>
                                </div>

                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("CommentsTitle")%>
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Comments")%>
                                    </div>
                                </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Wrap="true" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnApproveDecision" CommandArgument='<%# Eval("CCReq_Id") %>'
                                    Visible='<%# (int)( Eval("isApproved"))==2%>' OnClick="btnDecisionApprove_Click"
                                    ToolTip="Approve Request" Text="Approve" CssClass="btn btn-primary active">
                                </asp:LinkButton>
                                <br />
                                <br />
                                <asp:LinkButton runat="server" ID="btnDisapprove" CommandArgument='<%# Eval("CCReq_Id") %>'
                                    Visible='<%# (int)( Eval("isApproved"))==2%>' OnClick="btnDecisionDisapprove_Click"
                                    ToolTip="Submit Decision" Text="Disapprove" CssClass="btn btn-danger active">
                                             
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnReport" CommandArgument='<%# Eval("Student_Id") %>'
                                    OnClick="BindReportCardGrid" ToolTip="View Student History"> <span class="glyphicon glyphicon-list-alt"></span></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnAction" Text="Change Class" CommandArgument='<%# Eval("CCReq_Id") %>'
                                    CssClass="btn btn-default" OnClick="btnAction_Click" Visible='<%# (int)( Eval("isApproved"))==1 &&  (int)( Eval("isProccessed"))==0 %>'></asp:LinkButton>
                                <asp:Label ID="Label1" runat="server" Text="Class Updated" CommandArgument='<%# Eval("CCReq_Id") %>'
                                    ForeColor="Red" Visible='<%# (int)( Eval("isApproved"))==1 &&  (int)( Eval("isProccessed"))==1 %>'>
                                </asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton runat="server" ID="btnDelete" Text="Delete" CommandArgument='<%# Eval("CCReq_Id") %>'
                                    OnClick="btnDelete_Click" Visible='<%# (int)( Eval("isApproved"))==2 ||(int)( Eval("isApproved"))==0  %>'>
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
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div class="pull-right">
                    <asp:Button ID="btnCancel" TabIndex="1" OnClick="btnCancle_Click" runat="server"
                        CssClass="btn btn-danger" Text="Cancel" Visible="False"></asp:Button>
                </div>
                <asp:GridView ID="gvReportCard" runat="server" CssClass="datatable table table-striped table-bordered table-hover"
                    OnPreRender="gvReportCard_PreRender" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student Id">
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
                        <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Id" HeaderText="Section_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Session" HeaderText="Session">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Term" HeaderText="Term">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="View Result Card">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemTemplate>
                                <asp:Button runat="server" ID="btnReport" CssClass="btn btn-info" CommandArgument='<%# Eval("Student_Id") %>'
                                    OnClick="btnViewReport_Click" Text="View Report" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle ForeColor="SlateGray" />
                    <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                    <HeaderStyle CssClass="tableheader"></HeaderStyle>
                    <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
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
