<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="MonthlyStdVerification.aspx.cs" Inherits="PresentationLayer_TCS_MonthlyStdVerification" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>   </script>
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
                                });
                            }
                            catch (err) {
                                //alert('datatable ' + err);
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
            <div class="form-group">
                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Student Verification"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <br />

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
 
                        <span >1- From the 1st to the 5th of every month, teachers can verify students.
                        </span>
                    <br />
                        <span >2- Student verification will be automatically locked for teachers after the 5th of every month.
                        </span>
                    <br />
                        <span >3- Campus administrators can begin final verification from 6th to 10th of each month.
                        </span>
                    <br />
                    <br />

                    <asp:Label ID="lblError" runat="server" Text="" ForeColor="Red">

                    </asp:Label>


                </div>


                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <span class=" col-lg-3 col-md-3 col-sm-3 col-xs-3"></span>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <span class="TextLabelMandatory40">Attendance Month*:
                        </span>

                        <asp:DropDownList ID="ddlmonth" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            Width="250px" OnSelectedIndexChanged="ddlmonth_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-right">
                    </div>
                </div>

                <div runat="server" id="AddStudent" visible="false">
                    <div runat="server">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                            Add Student
                        </div>
                    </div>
                    <br />
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">

                        <table class="main_table" cellspacing="0" cellpadding="0" border="0">

                            <tr style="width: 100%">
                                <td class="TextLabelMandatory40">Student ERP No. :
                                </td>
                                <td style="width: 60%" align="left">&nbsp;
                                    <asp:TextBox runat="server" ID="txtStdId" CssClass="form-control" placeholder="Student Number"></asp:TextBox>

                                </td>
                            </tr>

                            <tr style="width: 100%">
                                <td class="TextLabelMandatory40">Student Name* :
                                </td>
                                <td style="width: 60%" align="left">&nbsp;
                                    <asp:TextBox runat="server" ID="txtStdName" AutoPostBack="true" CssClass="form-control"
                                        placeholder="Student Name" ToolTip="Student Name"></asp:TextBox>
                                </td>
                            </tr>
                            <tr style="width: 100%">
                                <td class="TextLabelMandatory40">Reason* :
                                </td>
                                <td style="width: 60%" align="left">
                                    <asp:DropDownList ID="ddlReasonList" runat="server" Width="250" AutoPostBack="True" CssClass="dropdownlist" ToolTip="Select Reason" Height="34px">
                                    </asp:DropDownList>
                                </td>
                            </tr>

                            <tr style="width: 100%">
                                <td class="TextLabelMandatory40">Teacher Remarks* :
                                </td>
                                <td style="width: 60%" align="left">&nbsp;
                                <asp:TextBox ID="txtTeacherRemarks" runat="server" Width="400px" CssClass="form-control textbox" MaxLength="2000" TextMode="MultiLine"
                                    ToolTip="Teacher Remarks">
                                </asp:TextBox>

                                </td>
                            </tr>

                            <tr style="width: 100%">
                                <td colspan="2" align="center" >
                                    <asp:Button runat="server" ID="btnTeacherVerify" Text="Save" CssClass="btn btn-sm btn-primary"
                                    ToolTip="Click to Save" OnClick="txtStdName_TextChanged" />
                                <asp:Button runat="server" ID="btnCancel" Text="Cancel" CssClass="btn btn-sm btn-primary"
                                    ToolTip="Click to Save" OnClick="btnCancel_Click" />

                                </td>
                            </tr>
                        </table>





                        

                    </div>
                </div>


                <div runat="server" id="divTeacher" visible="false">
                    <div runat="server" id="divtitle">
                        <div id="Div1" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server">
                            List of Students
                        </div>
                        <div class="row">
                            <div class="pull-right">
                                <asp:Button runat="server" ID="btnaddStudent" Text="Add Student(s)" CssClass="btn btn-sm btn-primary"
                                    Visible="false" OnClick="btnaddStudent_Click" />
                                <asp:Button runat="server" ID="btnLock" Text="Lock Verification" CssClass="btn btn-sm btn-primary"
                                    OnClientClick="return confirm('Are you sure you want to continue?')" OnClick="btnLockStudent_Click" visible="false"/>
                            </div>
                        </div>
                    </div>

                    <br />
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            OnRowDataBound="gvStudents_RowDataBound" CssClass="datatable table table-striped table-bordered table-hover table-sm "
                            OnPreRender="gvStudents_PreRender">
                            <HeaderStyle Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Section_Id" HeaderText="Section_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>


                                <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" SortExpression="Student_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="name" HeaderText="Studnet Name">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>

                                <asp:BoundField DataField="isVerified" HeaderText="isVerified">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Student_Verification_Id" HeaderText="Student_Verification_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>


                                <asp:TemplateField HeaderText="Sr. #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Student #">
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemTemplate>
                                        <span id="Span2" runat="server" visible='<%# (int)( Eval("Student_Id"))>0 && (int)( Eval("isVerified"))==1 %>'
                                            style="font-size: 14px; color: Red;">
                                            <%# Eval("Student_Id")%>

                                        </span>
                                        <span id="Span3" runat="server" visible='<%# (int)( Eval("Student_Id"))>0 && (int)( Eval("isVerified"))==0%>'
                                            style="font-size: 14px;">
                                            <%# Eval("Student_Id")%></span>

                                            <asp:TextBox runat="server" ID="txtStdRowId" CssClass="form-control" placeholder="Student Number"
                                            Visible='<%# (Session["isClassTeacher"].ToString()=="1" && (Eval("name").ToString())=="0"  && (int)( Eval("isVerified"))==0) || (Session["isClassTeacher"].ToString()=="0" && (int)Eval("Student_Id")<=0) %>'></asp:TextBox>




                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--10--%>
                                <asp:TemplateField HeaderText="Student Name">
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemTemplate>
                                        <span id="Span1" runat="server" visible='<%# (Eval("name").ToString())!="" && (int)( Eval("isVerified"))==1 %>'
                                            style="font-size: 14px; color: Red;">
                                            <%# Eval("name")%></span>
                                        <span id="Span4" runat="server" visible='<%# (Eval("name").ToString())!="0"  && (int)( Eval("isVerified"))==0 %>'
                                            style="font-size: 14px;">
                                            <%# Eval("name")%></span>







                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--11--%>
                                <asp:TemplateField HeaderText="Verify">
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemTemplate>
                                        <div id="Div2" runat="server" visible='<%# ( Eval("name").ToString())!="0" %>'>
                                            <asp:LinkButton runat="server" ID="btnVerify" CommandArgument='<%# Eval("Student_Verification_Id") %>'
                                                Visible='<%# (int)( Eval("isVerified"))==0 && (int)( Eval("isLock"))==0 %>' OnClick="BtnVerify_Click"
                                                ToolTip="Click to Verify">
                                                <span class="glyphicon glyphicon-remove"></span>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton1" runat="server" Visible='<%# (int)( Eval("isVerified"))==1 && (int)( Eval("isLock"))==0 %>'
                                                ToolTip="Verified for this month">
                                                <span class="glyphicon glyphicon-ok" style="color:Red"></span>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnLockedverify" runat="server" Visible='<%# (int)( Eval("isLock"))==1 %>'
                                                ToolTip="Verified for this month">
                                                <span class="glyphicon glyphicon-lock" style="color:orange"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--12--%>
                                <asp:TemplateField HeaderText="Delete Verified">
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemTemplate>
                                        <div id="Div22" runat="server" visible='<%# ( Eval("name").ToString())!="0" %>'>
                                            <asp:LinkButton ID="btnDelete" runat="server" Visible='<%# (int)( Eval("isVerified"))==1 && (int)( Eval("isLock"))==0%>'
                                                ToolTip="Delete Verification" OnClick="btnDeleteStudent_Click" CommandArgument='<%# Eval("Student_Verification_Id") %>'>
                                                <span class="glyphicon glyphicon-trash" style="color:Red"></span>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btnLock" runat="server" Visible='<%#  (int)( Eval("isLock"))==1 %>'
                                                ToolTip="Verified for this month"> 
                                        <span class="glyphicon glyphicon-lock" style="color:orange"></span>
                                            </asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:BoundField DataField="StudentStatus" HeaderText="Student Status">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <%--14--%>
                                <asp:TemplateField HeaderText="School Verification Remarks">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtSchoolRemarks" runat="server" Width="400px" CssClass="form-control textbox" MaxLength="2000" TextMode="MultiLine"
                                            Enabled='<%# Eval("SchoolRemarksLock").Equals(false)%>'>
                                        </asp:TextBox>
                                        <br />
                                        <asp:Button runat="server" ID="btnSchoolVerify" Text="Save & Lock" CssClass="btn btn-sm btn-primary"
                                            Visible="true" OnClick="BtnSchoolVerify_Click" ToolTip="Click to Verify" Enabled='<%# Eval("SchoolRemarksLock").Equals(false)%>' />
                                        <asp:Button ID="btnDeleteReq" runat="server" CssClass="btn btn-warning"  OnClick="btnDeleteReq_Click"
                                            Text="Delete Request" Enabled='<%# Eval("SchoolRemarksLock").Equals(false)%>'></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--15--%>
                                <asp:BoundField DataField="SchoolVerificationRemarks" HeaderText="School Remarks">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SchoolRemarksLock" HeaderText="School Remarks Lock">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>

                                <%--17--%>

                                   <asp:TemplateField HeaderText="Student Delete Approval">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemTemplate>

                                        <asp:Button runat="server" ID="btnApprove" Text="Approve" CssClass="btn btn-sm btn-success"
                                            Visible="true" OnClick="btnDeleteApproval_Click" />

                                        <asp:Button ID="btnReject" runat="server" CssClass="btn btn-danger"  OnClick="btnDeleteReject_Click"
                                            Text="Reject"></asp:Button>
                                    </ItemTemplate>
                                </asp:TemplateField>


                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
                <div runat="server" id="divManagement" visible="false">
                    <div runat="server">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                            List of Sections
                        </div>
                    </div>
                    <br />
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <asp:GridView ID="gvSections" runat="server" BorderStyle="Dashed" OnPreRender="gvSections_PreRender"
                            AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-hover table-sm ">
                            <HeaderStyle Font-Bold="true" />
                            <Columns>
                                <asp:BoundField DataField="Student_VerificationMst_Id" HeaderText="Student_VerificationMst_Id">
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
                                <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Section_Id" HeaderText="Section_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="isLock" HeaderText="isLock">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Lock">
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    <ItemTemplate>
                                        <div id="Div1" runat="server" visible='<%# (int)( Eval("isLock"))==1 %>'>
                                            <asp:LinkButton runat="server" ID="btnRemove" CommandArgument='<%# Eval("Student_VerificationMst_Id") %>'
                                                ClientIDMode="AutoID" OnClick="btnUnlockMgmt_Click" ToolTip="Click to Unlock the Section">
                                                <span class="glyphicon glyphicon-lock"></span>
                                            </asp:LinkButton>
                                        </div>
                                        <asp:LinkButton runat="server" ID="btnVerify" CommandArgument='<%# Eval("Student_VerificationMst_Id") %>'
                                            Visible='<%#  (int)( Eval("isLock"))==0 %>' OnClick="btnLockMgmt_Click" ToolTip="Click to Lock the Section">
                                            <span class="glyphicon glyphicon-minus"></span>
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
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
