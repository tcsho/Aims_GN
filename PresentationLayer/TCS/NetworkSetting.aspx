<%@ Page Title="Network Setting" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="NetworkSetting.aspx.cs" Inherits="PresentationLayer_TCS_NetworkSetting" %>

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
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Network Configuration "></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <div runat="server" id="div1" class="col-lg-9 col-md-9 col-sm-9 col-xs-9 form-group">
                        </div>
                        <div runat="server" id="div2" class="col-lg-3 col-md-3 col-sm-3 col-xs-3 form-group">
                            <asp:LinkButton ID="btnAddNetwork" OnClick="btnAddNetwork_Click" runat="server" CssClass="btn btn-primary"
                                CausesValidation="False">Add New [Network Name]</asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="Pan_NetworkName" runat="server">
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection ">
                                Add Network Name
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12  ">
                                <br />
                                <br />
                                <span class=" col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">Network Region</span>
                                <div class=" col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                    <asp:DropDownList ID="ddlRegions" runat="server" Enabled="false" Width="320px" AutoPostBack="True"
                                        AppendDataBoundItems="true" CssClass="dropdownlist">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <br />
                            <br />
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <span class=" col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">Network Name</span>
                                <div class=" col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                    <asp:TextBox ID="txtNetworkName" runat="server" Width="320px" placeholder="Enter Name of Network"
                                        CssClass="form-control textbox"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Network Name is Required Field"
                                        ControlToValidate="txtNetworkName" ValidationGroup="s" Display="Dynamic" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <br />
                            <br />
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                <span class=" col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">Network Head
                                    Email</span>
                                <div class=" col-lg-9 col-md-9 col-sm-9 col-xs-9">
                                    <asp:TextBox ID="txtEmail" runat="server" Width="320px" placeholder="Enter Email of Network Head"
                                        CssClass="form-control textbox"></asp:TextBox>
                                    <br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Network Head Email is Required Field"
                                        ControlToValidate="txtEmail" ValidationGroup="s" Display="Dynamic" CssClass="alert alert-danger"></asp:RequiredFieldValidator>
                                    <br />
                                    <asp:RegularExpressionValidator ID="Email" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Please enter Network Head's official email" Display="Dynamic" CssClass="alert alert-danger"
                                        ValidationExpression="^[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}]+\.[A-Z]{2,6}$">
                                    </asp:RegularExpressionValidator></div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-5 col-md-5 col-sm-5 col-xs-5">
                                <div class="pull-right">
                                    <br />
                                    <asp:Button ID="btnSaveNetWorkName" runat="server" CssClass="btn btn-success" ValidationGroup="s"
                                        Text="Save" OnClick="btnSaveNetWorkName_Click"></asp:Button>
                                    <asp:Button ID="btnCancel1" OnClick="btnCancel_Click" runat="server" CausesValidation="False"
                                        CssClass="btn btn-danger" Text="Cancel"></asp:Button>
                                </div>
                            </div>
                            <div class="col-lg-7 col-md-7 col-sm-7 col-xs-7">
                            </div>
                        </div>
                    </div>
                </div>
                <div id="divMainList" runat="server">
                    <div class="row">
                        <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8">
                            <div class="pull-right">
                                <asp:DropDownList ID="ddlRegion" runat="server" Width="323px" AutoPostBack="True"
                                    CssClass="dropdownlist" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged"
                                    Enabled="false">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlCenter" runat="server" Width="323px" AutoPostBack="True"
                                    Visible="false" CssClass="dropdownlist" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged"
                                    Enabled="false">
                                </asp:DropDownList>
                                <br />
                                <br />
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4  ">
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                            List of Networks
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <br />
                            <asp:GridView ID="gvNetwork" runat="server" Width="100%" AutoGenerateColumns="False"
                                SkinID="GridView" HorizontalAlign="Center" CssClass="datatable table table-hover table-responsive"
                                OnPreRender="gvNetwork_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="NetworkRegion_Id" HeaderText="NetworkRegion_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="S#">
                                        <ItemStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="NetworkName" HeaderText="Network Name" SortExpression="NetworkName">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Network Head Email" SortExpression="Email">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="User_Name" HeaderText="User Name" SortExpression="User_Name">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Password" HeaderText="Password " SortExpression="Password">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalCampus" HeaderText="Total Campuses" SortExpression="TotalCampus">
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Show Campus">
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnShowCampus" runat="server" CommandArgument='<%# Eval("NetworkRegion_Id") %>'
                                                ImageUrl="~/images/search.png" Width="22px" OnClick="btnShowCampus_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Add Campus">
                                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnAddCampuses" runat="server" CommandArgument='<%# Eval("NetworkRegion_Id") %>'
                                                ImageUrl="~/images/add-icon.png" Width="22px" OnClick="btnAddCampuses_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="30px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("NetworkRegion_Id") %>'
                                                OnClick="btnEditNetwork_Click" ToolTip="Edit Record">
                                        <span class="glyphicon glyphicon-pencil" style="color:Navy;"></span>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("NetworkRegion_Id") %>'
                                                ForeColor="#004999" ImageUrl="~/images/delete.gif" OnClick="btnDelNetworkRegion_Click"
                                                Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" HorizontalAlign="Center" />
                                <AlternatingRowStyle CssClass="tr2" />
                                <SelectedRowStyle CssClass="tr_select" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="row" id="pan_AssigCampus" runat="server">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection ">
                            Assign Campuses To Network
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9 ">
                            <br />
                            <br />
                            <div class="pull-right">
                                <asp:DropDownList ID="ddl_region_dept" runat="server" Width="323px" AutoPostBack="True"
                                    CssClass="dropdownlist" OnSelectedIndexChanged="ddl_region_dept_SelectedIndexChanged"
                                    Enabled="false">
                                </asp:DropDownList>
                                <br />
                                <asp:DropDownList ID="ddl_Networks" runat="server" Width="323px" CssClass="dropdownlist"
                                    Enabled="false" AppendDataBoundItems="true">
                                    <asp:ListItem Value="0" Text="-- Select Network --"></asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please Select Network"
                                    ControlToValidate="ddl_Networks" InitialValue="0" ValidationGroup="x"></asp:RequiredFieldValidator>
                                <br />
                                <asp:DropDownList ID="ddl_center_dept" runat="server" Width="323px" AutoPostBack="True"
                                    Enabled="false" Visible="false" CssClass="dropdownlist" OnSelectedIndexChanged="ddl_center_dept_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 ">
                        </div>
                    </div>
                    <div class="row">
                        <br />
                        <br />
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection     ">
                            List of Campuses
                        </div>
                    </div>
                    <div class="row">
                        <br />
                        <br />
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:GridView ID="gvAssignCampus" runat="server" Width="100%" AutoGenerateColumns="False"
                                HorizontalAlign="Left" OnRowCommand="gvAssignCampus_RowCommand" CssClass="datatable table table-hover table-responsive"
                                OnPreRender="gvAssignCampus_PreRender">
                                <Columns>
                                    <asp:BoundField DataField="Center_Id" HeaderText="Center_Id" SortExpression="Center_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="10%"></ItemStyle>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Campus Name" SortExpression="Center_Name">
                                        <ItemStyle HorizontalAlign="Left" Width="50%"></ItemStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="cb">
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Select</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" Width="10%" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr1" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                                <SelectedRowStyle CssClass="tr_select" />
                            </asp:GridView>
                        </div>
                    </div>
                    <br />
                    <br />
                    <div class="row">
                        <div class="col-lg-7 col-md-7 col-sm-7 col-xs-7">
                            <div class="pull-right">
                                <asp:Button ID="btnSaveAssignCampus" OnClick="btnSaveAssignCampus_Click" runat="server"
                                    CssClass="btn btn-success" ValidationGroup="x" Text="Save"></asp:Button>
                                <asp:Button ID="btnCancel" OnClick="btnCancelAssign_Click" runat="server" CausesValidation="False"
                                    CssClass="btn btn-danger" Text="Cancel"></asp:Button>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2">
                        </div>
                    </div>
                </div>
                <div class="panel" id="divListOfCampus" runat="server">
                    <br />
                    <br />
                    <div class=" titlesection">
                        List of Campuses
                    </div>
                    <div class="panel_body">
                        <br />
                        <br />
                        <asp:GridView ID="gvCampuses" runat="server" Width="100%" AutoGenerateColumns="False"
                            CssClass="datatable table table-hover table-responsive" OnPreRender="gvCampuses_PreRender">
                            <Columns>
                                <asp:BoundField DataField="NetworkCenterId" HeaderText="NetworkCenterId">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NetworkRegion_Id" HeaderText="NetworkRegion_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Center_Name" HeaderText="Center Name" SortExpression="Center_Name">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Center_Id" HeaderText="Center_Id" SortExpression="Center_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:TemplateField ShowHeader="False" HeaderText="Remove">
                                    <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" OnClick="btnDelNetworkCampus_Click"
                                            ImageUrl="~/images/delete.gif" Text="" CommandArgument='<%# Eval("NetworkCenterId") %> '
                                            OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="tr1" />
                            <HeaderStyle CssClass="tableheader" HorizontalAlign="Center" />
                            <AlternatingRowStyle CssClass="tr2" />
                            <SelectedRowStyle CssClass="tr_select" />
                        </asp:GridView>
                        <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
