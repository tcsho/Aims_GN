<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TcsHlpDsk.aspx.cs" Inherits="PresentationLayer_TCS_TcsHlpDsk"
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
                <asp:Label ID="Label3" CssClass="lblFormHead" runat="server" Text="Help Desk"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div>
                <p>
                    <br />
                    <br />
                </p>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                    <asp:Label ID="Label2" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="Main Organization*: "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddl_MOrg" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            Enabled="False" OnSelectedIndexChanged="ddl_MOrg_SelectedIndexChanged" Width="180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ForColor="Red" ID="rfv_mOrg" runat="server" ControlToValidate="ddl_MOrg"
                            Display="Dynamic" Enabled="False" ErrorMessage="Mian Org is a required Field"
                            InitialValue="0" Width="200px"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Label ID="Label4" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="  Main Organization Country* : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddl_country" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" Width="180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ForColor="Red" ID="rfv_country" runat="server" ControlToValidate="ddl_country"
                            Display="Dynamic" Enabled="False" ErrorMessage="Country is a required Field"
                            InitialValue="0" Width="165px"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Label ID="Label5" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="Region*  : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" Width="180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ForColor="Red" ID="rfv_region" runat="server" ControlToValidate="ddl_region"
                            Display="Dynamic" Enabled="False" ErrorMessage="Region is a required Field" InitialValue="0"
                            Width="169px"></asp:RequiredFieldValidator>
                    </div>
                    <asp:Label ID="Label6" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="Center*  : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="list_center" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            OnSelectedIndexChanged="list_center_SelectedIndexChanged" Width="180px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ForColor="Red" ID="rfv_center" runat="server" ControlToValidate="list_center"
                            Display="Dynamic" Enabled="False" ErrorMessage="Center is a required Field" InitialValue="0"
                            Width="167px"></asp:RequiredFieldValidator>
                    </div>
                    <br />
                  
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="row">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <asp:Label ID="Label11" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40"
                            Text="Find By: "></asp:Label>
                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    <asp:DropDownList ID="ddlFilter" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Ticket #</asp:ListItem>
                                        <asp:ListItem Value="2">Priority</asp:ListItem>
                                        <asp:ListItem Value="3">Status</asp:ListItem>
                                        <asp:ListItem Value="4">Resource</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    <asp:TextBox ID="txtFilter" runat="server" CssClass="form-control textbox" AutoPostBack="True"
                                        OnTextChanged="txtFilter_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary"
                                        OnClick="btnFilter_Click" CausesValidation="false" />
                                    <asp:Button ID="btnReset" runat="server" Text="Show All" CssClass="btn btn-primary"
                                        OnClick="btnReset_Click" CausesValidation="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    &nbsp; Registered Complaints
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="Div1" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvComplaints" runat="server" Width="100%" AutoGenerateColumns="False"
                    HorizontalAlign="Center" CssClass="datatable table table-hover table-responsive"
                    OnRowDeleting="gvComplaints_RowDeleting" OnRowDataBound="gvComplaints_RowDataBound"
                    OnPreRender="gvComplaints_PreRender" OnSelectedIndexChanging="gvComplaints_SelectedIndexChanging">
                    <RowStyle CssClass="tr2"></RowStyle>
                    <Columns>
                        <asp:BoundField DataField="HDComplaint_ID" HeaderText="Complaint#">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HDSubCat_ID" HeaderText="Pmid">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PriorityType_ID" HeaderText="Pid">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AssignerRemarks" HeaderText="AssignerRemarks">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HD_Resource_ID" HeaderText="HD_Resource_ID">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="DueDate"
                            DataFormatString="{0:dd/MMM/yyyy}" HtmlEncode="False">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="AssignerRemarks" HeaderText="AssignerRemarks">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                         <asp:BoundField DataField="SolutionStatus" HeaderText="SolutionStatus">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-Width="100%">
                            <ItemTemplate>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40 text-left">
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 TextLabelMandatory40 text-right" runat="server" Visible='<%# (int)( Eval("SolutionStatus"))==0 %>'>
                                      
                                        <asp:LinkButton ID="btnAssign" runat="server" Text="Assign" ToolTip="Assign this query to a resource"
                                            CssClass="btn btn-info" OnClick="btnAssign_Click" CausesValidation="false" CommandArgument='<%#Eval("HDComplaint_ID") %>'
                                            Visible='<%# (int)( Eval("AssignmentStatus"))==0 %>'></asp:LinkButton>
                                             <asp:LinkButton ID="btnShowDetail" runat="server" Text="Show Assigned resource" ToolTip="Check Assigned Resource"
                                            CssClass="btn btn-info" OnClick="btnAssign_Click" CausesValidation="false" CommandArgument='<%#Eval("HDComplaint_ID") %>'
                                          Visible='<%# (int)( Eval("AssignmentStatus"))==1 %>'></asp:LinkButton>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Ticket # :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("HDComplaint_ID") %>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Subject :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("ComplaintTitle") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Campus Code:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("Center_Id") %>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Campus Name:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("Center_Name") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Priority:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("PriorityTypeDesc") %>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Status:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("ComplaintStatus") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Submitted On:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("CreatedOn") %>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Due Date:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("DueDate") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40 text-left">
                                        Description:
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("HDComplaintDesc") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Assigned To:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("ResName") %>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Close Date:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("CloseDate") %>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle CssClass="tr_select"></SelectedRowStyle>
                    <HeaderStyle CssClass="tableheader"></HeaderStyle>
                </asp:GridView>
            </div>
            <%--Complaint Detail Section--%>
            <%--<tr>
                        <td colspan="5">
                            <asp:Panel ID="pnlComplaintDetail" runat="server" Visible="false">
                                <table style="width: 100%" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td>
                                            Complaint Description: 
                                        </td>
                                        <td id="complaintDesc" runat="server">
                                               
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            By Campus:
                                        </td>
                                        <td id="campus" runat="server">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Submitted On:
                                        </td>
                                        <td id="submittedOn" runat="server">
                                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Close Date:
                                        </td>
                                        <td id="CloseDate" runat="server">
                                        
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>--%>
            <div runat="server" id="pan_Feedback">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <div id="Div3" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        &nbsp; Complaint Log
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <div id="Div4" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <asp:GridView ID="gvSolutions" runat="server" Width="100%" AutoGenerateColumns="False"
                        SkinID="GridView" HorizontalAlign="Center" OnPageIndexChanging="gvSolutions_PageIndexChanging"
                        OnRowDataBound="gvSolutions_RowDataBound" AllowPaging="True" AllowSorting="True"
                        PageSize="15" EmptyDataText="No record found.">
                        <Columns>
                            <asp:BoundField DataField="HDCompSol_ID" HeaderText="Complaint#">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="HDComplaint_ID" HeaderText="Pmid">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                                <ItemTemplate>
                                    <asp:Literal ID="ltrFeedBack" runat="server" Text='<%#Eval("FeedBack") %>'></asp:Literal>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="No." ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FeedBack by IT Resource">
                                <ItemStyle Width="50%" />
                                <ItemTemplate>
                                    <div class="row">
                                        <asp:LinkButton ID="btnAddSolution" runat="server" Text="Add Solution" OnClick="but_new_Click1"
                                            CausesValidation="false" Visible="false"></asp:LinkButton>
                                    </div>
                                    <div class="row">
                                        <font color="#404040">
                                            <%#Eval("SolutionRemarks") %>
                                        </font>
                                    </div>
                                    <div class="row">
                                        <font color="#404040">
                                            <br />
                                            <i>- Posted By Resource
                                                <%#Eval("EmployeeCode") %>
                                                On
                                                <%# Convert.ToDateTime(Eval("SolutionOn")).ToString("f") %>
                                            </i></font>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="isClear" HeaderText="isClear">
                                <HeaderStyle CssClass="hide" />
                                <ItemStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Campus Feedback">
                                <ItemStyle Width="50%" />
                                <ItemTemplate>
                                    <table style="width: 100%" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <font color="#404040">
                                                    <%#Eval("FeedBack") %>
                                                    <br />
                                                    <br />
                                                    <i>
                                                        <%--<%# Convert.ToDateTime(Eval("FeedBackOn")).ToString("f") %>--%>
                                                        <%# (Eval("FeedBackOn").ToString() != "") ? "-Posted By "+ Eval("Center_Name")+" on "+ Convert.ToDateTime(DataBinder.Eval(Container.DataItem, "FeedBackOn")).ToString("f") : "Feedback not provided yet."%>
                                                    </i></font>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                    </table>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                        <SelectedRowStyle CssClass="tr_select" />
                    </asp:GridView>
                    <asp:Label ID="lab_SolStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
                </div>
            </div>
            <div runat="server" id="pan_New">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <div id="Div2" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        Assign Resource For This Query
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div class="row">
                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                            <asp:Label ID="Label8" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                                Text=" Select Resource*: "></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlResource" runat="server" CssClass="dropdownlist" Width="152px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator2" runat="server"
                                    ValidationGroup="s" Display="Dynamic" ErrorMessage="Select Resource." ControlToValidate="ddlResource"
                                    InitialValue="0"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                            <asp:Label ID="Label9" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                                Text="Due Date*: "></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtDueDate" runat="server" CssClass="form-control textbox" MaxLength="11"
                                    Width="146px" AutoPostBack="True" OnTextChanged="txtDueDate_TextChanged" ></asp:TextBox>
                                <cc1:CalendarExtender ID="ceDOB" runat="server" TargetControlID="txtDueDate" Format="d"
                                    PopupPosition="Topright">
                                </cc1:CalendarExtender>
                                <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender2" runat="server" TargetControlID="txtDueDate"
                                    WatermarkCssClass="watermark" WatermarkText="MM/dd/yyyy">
                                </cc1:TextBoxWatermarkExtender>
                                <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator1" runat="server"
                                    ValidationGroup="s" Display="Dynamic" ErrorMessage="Due date is required." ControlToValidate="txtDueDate"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                            <asp:Label ID="Label10" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                                Text="Remarks: "></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" CssClass="form-control textbox"
                                    MaxLength="11" Width="300px" Style="resize: none"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                            <div class="pull-right">
                                <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                    ValidationGroup="s" Text="Save"></asp:Button>
                                &nbsp;
                                <asp:Button ID="but_cancel" OnClick="but_cancel_Click" runat="server" CssClass="btn btn-primary"
                                    CausesValidation="False" Text="Cancel"></asp:Button>
                            </div>
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
