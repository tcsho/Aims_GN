<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchUser.aspx.cs" MasterPageFile="~/PresentationLayer/MasterPage.master"
    Inherits="PresentationLayer_SearchUser" Theme="BlueTheme" %>

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

                                            { orderable: false, targets: [7, 8]} //disable sorting on toggle button
                                        ]
                                          ,
                                    tableTools:
                    { //Start of tableTools collection
                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                        "aButtons":
                         [ //start of button main/master collection


                         ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true
         , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false //, fixedHeader: true , "stateSave": true
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
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Search User"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right">
                <asp:Button ID="but_search" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                    Text="Search"></asp:Button>
                <asp:Button ID="btnAddNew" OnClick="btnAddNew_click" runat="server" CssClass="btn btn-warning"
                    Text="Add New User" Visible="false"></asp:Button>
            </div>
            <div id="Div1" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" runat="server">
                <div id="Div2" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    Search Criteria
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">
                    First Name :
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                    <asp:TextBox ID="text_firstName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">
                    Employee # :
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                    <asp:TextBox ID="text_EmployeeCode" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">
                    User Name :
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                    <asp:TextBox ID="text_username" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">
                    Gender :
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                    <asp:DropDownList ID="list_gender" runat="server" CssClass="dropdownlist">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">
                    Region :
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                    <asp:DropDownList ID="list_region" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="list_region_SelectedIndexChanged"
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:Label runat="server" ID="lab_region" CssClass="TextLabel40"></asp:Label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">
                    Group Name :
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                    <asp:DropDownList ID="list_groupName" runat="server" CssClass="dropdownlist">
                    </asp:DropDownList>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">
                    Center :
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                    <asp:DropDownList ID="list_center" runat="server" CssClass="dropdownlist">
                    </asp:DropDownList>
                    <asp:Label ID="lab_center" runat="server"></asp:Label>
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                </div>
                <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 ">
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right">
                <asp:Button ID="but_search1" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                    Text="Search"></asp:Button>
            </div>
            <div runat="server" id="divSearch">
                <div id="Div3" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" runat="server">
                    <div id="Div4" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        Search Result
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <asp:Label runat="server" ID="lab_dataStatus" CssClass="TextLabelMandatory40" Text="No data available!"></asp:Label>
                    <asp:GridView ID="dg_user" runat="server" Width="100%" Height="100%" AutoGenerateColumns="False"
                        CssClass="datatable table table-striped table-responsive" OnPreRender="dg_user_PreRender"
                        OnRowDataBound="dg_student_RowDataBound" OnRowCommand="dg_user_RowCommand" DataKeyNames="user_id,user_name"
                        OnPageIndexChanging="dg_user_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="User_Id" HeaderText="User_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="User_Type_Id" HeaderText="User_Type_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Id" HeaderText="Region">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Id" HeaderText="Center_Id ">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Gender_Id" HeaderText="Gender"  >
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                              <asp:BoundField DataField="Mobile_Phone" HeaderText="Mobile_Phone">
                                  <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="FullName" HeaderText="First Name">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="Last_Name" HeaderText="Last Name">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Type_description" HeaderText="Group Name">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Name" HeaderText="Region">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Gender" HeaderText="Gender" Visible="false">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="Email">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="Address" HeaderText="Address">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                             <asp:BoundField DataField="Mobile_Phone" HeaderText="Mobile">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="User_Name" HeaderText="User Name">
                                <ItemStyle Font-Size="12px" />
                            </asp:BoundField>
                          
                            <asp:TemplateField HeaderText="Password Reset">
                                <ItemStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnPassReset" runat="server" CausesValidation="false" CommandArgument='<%# Eval("User_Id") %>'
                                        ImageUrl="~/images/Reset.png" OnClick="btnPassChange_Click" />
                                </ItemTemplate>
                                <HeaderStyle  />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shared Login" Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="12px" />
                                <ItemTemplate>
                                    <div id="Div5" runat="server" visible='<%#(int)( Eval("isTeacher"))==1 && (int)( Eval("NewEmployeeId"))==0 %>'>
                                        <asp:DropDownList runat="server" ID="ddlCenterteach" AutoPostBack="true" CssClass="dropdownlist"
                                            Width="120px">
                                        </asp:DropDownList>
                                        <asp:LinkButton ID="btnShared" runat="server" CausesValidation="False" CommandArgument='<%# Eval("Employee_Id") %>'
                                            CssClass="btn btn-primary" Text="Shared Login" OnClick="btnSharedLogin_Click">  </asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Edit " Visible="false">
                                <HeaderStyle HorizontalAlign="Center" Font-Size="12px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="12px" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnSave" OnClick="btnEditUser_click" runat="server"  visible='<%#(int)( Eval("isedit"))==1 %>' >
                                  <span class="glyphicon glyphicon-pencil"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="tr1"></RowStyle>
                        <HeaderStyle CssClass="tableheader"></HeaderStyle>
                        <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                    </asp:GridView>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-horizontal " runat="server" id="divUserLogin"
                visible="false">
                <div id="Div6" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" runat="server">
                    <div id="Div7" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        Add New User
                    </div>
                </div>
                <div class="form-group">
                    <asp:Label runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="User Type:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:DropDownList runat="server" ID="ddlUser_Type" CssClass="dropdownlist">
                        </asp:DropDownList>
                    </div>
                </div>
               <div class="clearfix"></div>
                <div class="form-group">
                    <asp:Label runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="First Name:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:TextBox runat="server" ID="txtFirstName" CssClass="form-control textbox"></asp:TextBox>

                    </div>
                </div><div class="clearfix"></div>
                <div class="form-group">
                    <asp:Label runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="Last Name:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:TextBox runat="server" ID="txtLast" CssClass="form-control textbox"></asp:TextBox>
                    </div>
                </div><div class="clearfix"></div>
                <div class="form-group">
                    <asp:Label runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="Region:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:DropDownList runat="server" ID="ddlregion" CssClass="dropdownlist" AutoPostBack="true"
                            OnSelectedIndexChanged="ddlRegion_SelectedIndexChange">
                        </asp:DropDownList>
                    </div>
                </div><div class="clearfix"></div>
                <div class="form-group">
                    <asp:Label runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="Center:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:DropDownList runat="server" ID="ddlCenter" CssClass="dropdownlist">
                        </asp:DropDownList>
                    </div>
                </div><div class="clearfix"></div>
                 <div id="Div8" class="form-group" runat="server"  >
                    <asp:Label ID="Label1" runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="Address:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:TextBox runat="server" ID="txtAddress" CssClass="form-control textbox"></asp:TextBox>
                    </div>
                </div><div class="clearfix"></div>
                 <div id="Div9" class="form-group" runat="server"  >
                    <asp:Label ID="Label3" runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="Mobile:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:TextBox runat="server" ID="txtMobile" CssClass="form-control textbox"></asp:TextBox>
                    </div>
                </div><div class="clearfix"></div>
                <div class="form-group">
                    <asp:Label runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="Email:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:TextBox runat="server" ID="txtEmail" CssClass="form-control textbox"></asp:TextBox>
                    </div>
                </div><div class="clearfix"></div>
                <div class="form-group">
                    <asp:Label runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="User Name:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:TextBox runat="server" ID="txtUserName" CssClass="form-control textbox"></asp:TextBox>
                    </div>
                </div><div class="clearfix"></div>
                <div class="form-group">
                    <asp:Label runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="Password:">
                         
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:TextBox runat="server" ID="txtPass" CssClass="form-control textbox"></asp:TextBox>
                    </div>
                </div><div class="clearfix"></div>
                <div class="form-group">
                    <asp:Label runat="server" class=" col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"
                        Text="Gender:">
                    </asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:DropDownList runat="server" ID="ddlGender" CssClass="dropdownlist">
                            <asp:ListItem Value="1" Text="Male"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Female"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div><div class="clearfix"></div>
                <div class="form-group">
                    <div class="col-lg-12 text-right">
                        <asp:Button ID="btnSave" OnClick="btnSaveUser_click" runat="server" CssClass="btn btn-primary"
                            Text="Save"></asp:Button>
                        <asp:Button ID="brnCancel" OnClick="btnCancel_click" runat="server" CssClass="btn btn-danger"
                            Text="Cancel"></asp:Button>
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
