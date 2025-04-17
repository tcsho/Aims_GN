<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentVerificationStatus.aspx.cs" Inherits="PresentationLayer_TCS_StudentVerificationStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
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

                                        //       { orderable: false, targets: [9, 11, 12] } //disable sorting on toggle button
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
            <div class="form-group">
                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Student Verification Status"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <br />
                <br />
                <%--<div><h4>Unreconciled Students / Unidentified Students</h4></div>--%>

                <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server">
                    Student Verification Status</div>--%>
                <div class="row">
                </div>
                <br />

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <br />
                    <asp:Label ID="UnidentifiedHeading" runat="server" Font-Size="Large">Unidentified Students</asp:Label>
                    <br />

                    <asp:GridView ID="gvUnidentifiedStudent" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CssClass="datatable table table-striped table-responsive" OnRowDataBound="gvUnidentifiedStudent_RowDataBound" OnPreRender="gvUnidentifiedStudent_PreRender">
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                            <asp:BoundField DataField="Student_Id" HeaderText="Student Id" SortExpression="Student Id">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Student_Name" HeaderText="Student Name">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Section" HeaderText="Class Section">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Id" HeaderText="Class_Id" SortExpression="Class_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Section_Id" HeaderText="Section_Id" SortExpression="Section_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Id" HeaderText="Center_Id" SortExpression="Center_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Id" HeaderText="Region_Id" SortExpression="Region_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MonthDesc" HeaderText="MonthDesc" SortExpression="MonthDesc">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RORemarks" HeaderText="RORemarks" SortExpression="RORemarks">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Remarks">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlUnidentified" runat="server" Enabled='<%# Convert.ToString(Eval("CORemarks")) == "" ? true : false %>' SelectedValue='<%# Bind("CORemarks") %>' AutoPostBack="true" CssClass="dropdownlist">
                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Change of Section" Value="Change of Section"></asp:ListItem>
                                        <asp:ListItem Text="Student Withdrawal" Value="Student Withdrawal"></asp:ListItem>
                                        <asp:ListItem Text="Student Transfer in" Value="Student Transfer in"></asp:ListItem>
                                        <asp:ListItem Text="Student Transfer out" Value="Student Transfer out"></asp:ListItem>
                                        <asp:ListItem Text="Wrongly Added by Teacher" Value="Wrongly Added by Teacher"></asp:ListItem>
                                        <asp:ListItem Text="Mistakenly Entered Twice" Value="Mistakenly Entered Twice"></asp:ListItem>
                                        <asp:ListItem Text="Late updation of Admission challan" Value="Late updation of Admission challan"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Changes made in ERP">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlUnidenChangesERP" runat="server" Enabled='<%# Convert.ToString(Eval("ChangeMadeERP")) == "" ? true : false %>' SelectedValue='<%# Bind("ChangeMadeERP") %>' AutoPostBack="true" CssClass="dropdownlist">
                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Not Applicable" Value="Not Applicable"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" Width="200px" CssClass="form-control textbox" MaxLength="3000" TextMode="MultiLine"
                                        Text='<%# Eval("Description")%>' Enabled='<%# Convert.ToString(Eval("Description")) == "" ? true : false %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RO Remarks">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <div style="display: flex; justify-content: space-evenly">
                                        <asp:Button runat="server" ID="btnApproveUnidentified" Text="Approve" Enabled='<%# Convert.ToInt32(Session["UserType_Id"]) == 23 ? true : false %>' CssClass="btn btn-sm btn-primary"
                                            Visible='<%# Convert.ToString(Eval("RORemarks")) == "" ? true : false %>' OnClick="btnApproveUnidentified_Click" />
                                        <asp:Button ID="btnRejectUnidentified" Enabled='<%# Convert.ToInt32(Session["UserType_Id"]) == 23 ? true : false %>' Visible='<%# Convert.ToString(Eval("RORemarks")) == "" ? true : false %>' OnClick="btnRejectUnidentified_Click" runat="server" CssClass="btn btn-warning"
                                            Text="Reject" />
                                        <asp:Label ID="RORemarks" runat="server" Text='<%# Eval("RORemarks")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
                    <div class="row">
                        <div class="pull-right" style="padding-right: 25px;">
                            <asp:Button runat="server" ID="btnAddUnidentifiedStudentsRemarks" Text="Save" CssClass="btn btn-primary"
                                OnClick="btnAddUnidentifiedStudentsRemarks_Click"></asp:Button>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <br />
                    <asp:Label ID="UnreconciledHeading" runat="server" Font-Size="Large">Unreconciled Students</asp:Label>
                    <br />

                    <asp:GridView ID="gvUnReconciledStudent" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CssClass="datatable table table-striped table-responsive" OnRowDataBound="gvUnReconciledStudent_RowDataBound" OnPreRender="gvUnReconciledStudent_PreRender">
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                            <asp:BoundField DataField="Student_Id" HeaderText="Student Id" SortExpression="Student Id">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Student_Name" HeaderText="Student Name">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Section" HeaderText="Class Section">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Id" HeaderText="Class_Id" SortExpression="Class_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Section_Id" HeaderText="Section_Id" SortExpression="Section_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Id" HeaderText="Center_Id" SortExpression="Center_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Id" HeaderText="Region_Id" SortExpression="Region_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MonthDesc" HeaderText="MonthDesc" SortExpression="MonthDesc">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RORemarks" HeaderText="RORemarks" SortExpression="RORemarks">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Remarks">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlUnreconciled" runat="server" SelectedValue='<%# Bind("CORemarks") %>' Enabled='<%# Convert.ToString(Eval("CORemarks")) == "" ? true : false %>' AutoPostBack="true" CssClass="dropdownlist">
                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Admission challan received late" Value="Admission challan received late"></asp:ListItem>
                                        <asp:ListItem Text="Teacher not verified" Value="Teacher not verified"></asp:ListItem>
                                        <asp:ListItem Text="Wrong Class Selected in admission form" Value="Wrong Class Selected in admission form"></asp:ListItem>
                                        <asp:ListItem Text="Wrong Section assigned" Value="Wrong Section assigned"></asp:ListItem>
                                        <asp:ListItem Text="Long Absence" Value="Long Absence"></asp:ListItem>
                                        <asp:ListItem Text="Student Withdrawal" Value="Student Withdrawal"></asp:ListItem>
                                        <asp:ListItem Text="Student Transfer out" Value="Student Transfer out"></asp:ListItem>
                                        <asp:ListItem Text="Student Transfer in" Value="Student Transfer in"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Changes made in ERP">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlUnreconChangesERP" runat="server" Enabled='<%# Convert.ToString(Eval("ChangeMadeERP")) == "" ? true : false %>' SelectedValue='<%# Bind("ChangeMadeERP") %>' AutoPostBack="true" CssClass="dropdownlist">
                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Not Applicable" Value="Not Applicable"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" Width="200px" CssClass="form-control textbox" MaxLength="3000" TextMode="MultiLine"
                                        Text='<%# Eval("Description")%>' Enabled='<%# Convert.ToString(Eval("Description")) == "" ? true : false %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RO Remarks">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <div style="display: flex; justify-content: space-evenly">
                                        <asp:Button runat="server" ID="btnApproveUnreconciled" Text="Approve" Enabled='<%# Convert.ToInt32(Session["UserType_Id"]) == 23 ? true : false %>' CssClass="btn btn-sm btn-primary"
                                            Visible='<%# Convert.ToString(Eval("RORemarks")) == "" ? true : false %>' OnClick="btnApproveUnreconciled_Click" />
                                        <asp:Button ID="btnRejectUnreconciled" Enabled='<%# Convert.ToInt32(Session["UserType_Id"]) == 23 ? true : false %>' Visible='<%# Convert.ToString(Eval("RORemarks")) == "" ? true : false %>' OnClick="btnRejectUnreconciled_Click" runat="server" CssClass="btn btn-warning"
                                            Text="Reject" />
                                        <asp:Label ID="RORemarks" runat="server" Text='<%# Eval("RORemarks")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                                <%-- <ItemTemplate>
                                    <asp:TextBox ID="RORemarks" runat="server" CssClass="textbox" MaxLength="250" Width="98%" Visible='<%# Convert.ToInt32(Session["UserType_Id"]) == 4 ? true : false %>'></asp:TextBox>
                                </ItemTemplate>--%> 
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
                    <div class="row">
                        <div class="pull-right" style="padding-right: 25px;">
                            <asp:Button runat="server" ID="btnAddUnreconciledStudentsRemarks" Text="Save" CssClass="btn btn-primary"
                                OnClick="btnAddUnreconciledStudentsRemarks_Click"></asp:Button>
                        </div>
                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <br />
                    <asp:Label ID="NonCompliantHeading" runat="server" Font-Size="Large">Non-Compliant Teachers</asp:Label>
                    <br />

                    <asp:GridView ID="gvNonCompliant" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvdtNonCompliantTeachers_PreRender" OnRowDataBound="gvdtNonCompliantTeachers_RowDataBound">
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                            <asp:BoundField DataField="ClassTeacher_Id" HeaderText="Class Teacher Id" SortExpression="Class Teacher Id">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Fullname" HeaderText="Teacher Name">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Section" HeaderText="Class Section">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Id" HeaderText="Class_Id" SortExpression="Class_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Section_Id" HeaderText="Section_Id" SortExpression="Section_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Id" HeaderText="Center_Id" SortExpression="Center_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Id" HeaderText="Region_Id" SortExpression="Region_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="MonthDesc" HeaderText="MonthDesc" SortExpression="MonthDesc">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="RORemarks" HeaderText="RORemarks" SortExpression="RORemarks">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Remarks">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlNonCompliant" Enabled='<%# Convert.ToString(Eval("CORemarks")) == "" ? true : false %>' runat="server" AutoPostBack="true" CssClass="dropdownlist" Width="98%" SelectedValue='<%# Bind("CORemarks") %>'>
                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Teacher Transfer Case" Value="Teacher Transfer Case"></asp:ListItem>
                                        <asp:ListItem Text="New Hiring of Teacher" Value="New Hiring of Teacher"></asp:ListItem>
                                        <asp:ListItem Text="Error shows in Aims+" Value="Error shows in Aims+"></asp:ListItem>
                                        <asp:ListItem Text="Teacher is no more class teacher" Value="Teacher is no more class teacher"></asp:ListItem>
                                        <asp:ListItem Text="Students not assigned to class teacher" Value="Students not assigned to class teacher"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Changes made in ERP">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlNonCompChangesERP" runat="server" Enabled='<%# Convert.ToString(Eval("ChangeMadeERP")) == "" ? true : false %>' SelectedValue='<%# Bind("ChangeMadeERP") %>' AutoPostBack="true" CssClass="dropdownlist">
                                        <asp:ListItem Text="Select" Value=""></asp:ListItem>
                                        <asp:ListItem Text="Yes" Value="Yes"></asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                        <asp:ListItem Text="Not Applicable" Value="Not Applicable"></asp:ListItem>
                                    </asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Description">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:TextBox ID="txtDescription" runat="server" Width="200px" CssClass="form-control textbox" MaxLength="3000" TextMode="MultiLine"
                                        Text='<%# Eval("Description")%>' Enabled='<%# Convert.ToString(Eval("Description")) == "" ? true : false %>'>
                                    </asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RO Remarks">
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" />
                                <ItemTemplate>
                                    <div style="display: flex; justify-content: space-evenly">
                                        <asp:Button runat="server" ID="btnApproveNonCompliant" Text="Approve" Enabled='<%# Convert.ToInt32(Session["UserType_Id"]) == 23 ? true : false %>' CssClass="btn btn-sm btn-primary"
                                            Visible='<%# Convert.ToString(Eval("RORemarks")) == "" ? true : false %>' OnClick="btnApproveNonCompliant_Click" />
                                        <asp:Button ID="btnRejectNonCompliant" Enabled='<%# Convert.ToInt32(Session["UserType_Id"]) == 23 ? true : false %>' Visible='<%# Convert.ToString(Eval("RORemarks")) == "" ? true : false %>' OnClick="btnRejectNonCompliant_Click" runat="server" CssClass="btn btn-warning"
                                            Text="Reject" />
                                        <asp:Label ID="RORemarks" runat="server" Text='<%# Eval("RORemarks")%>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
                    <div class="row">
                        <div class="pull-right" style="padding-right: 25px;">
                            <asp:Button runat="server" ID="btnAddNonCompliantTeachersRemarks" Text="Save" CssClass="btn btn-primary"
                                OnClick="btnAddNonCompliantTeachersRemarks_Click"></asp:Button>
                        </div>
                    </div>
                </div>
                <%--<div class="row">
                    <div class="pull-right">
                        <asp:Button runat="server" ID="btnAddRemarks" Text="Save" CssClass="btn btn-primary"
                            OnClick="btnAddRemarks_Click"></asp:Button>
                    </div>
                </div>--%>
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