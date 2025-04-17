<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="PushNotification.aspx.cs" Inherits="PresentationLayer_SearchStudent"
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
            <script src='<%=ResolveUrl("~/PresentationLayer/AMSScripts/plugin/urdutextbox.js") %>' type="text/javascript"></script>
            <script type="text/javascript"> window.onload = myOnload;
                function myOnload(evt) {
                    MakeTextBoxUrduEnabled("#txtNameUrdu");//enable Urdu in html text box
                    /*MakeTextBoxUrduEnabled(txtNameUrdu);*///enable Urdu in html text area
                }</script>
            <script type="text/javascript">
                function openModalTest() {
                    //                    $('#myModal').modal('show');
                    $('#TestModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalTest() {

                    $('#TestModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
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
                                    //            dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                    //"<'row'<'col-sm-12'tr>>" +
                                    //            //                     "<'row'<'col-sm-12'l>>" +
                                    // "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    //            "columnDefs": [

                                    //            //       { orderable: false, targets: [9, 11, 12] } //disable sorting on toggle button
                                    //            ]

                                    //           ,
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
            <table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="7">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Push Notification"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <%--<td style="height: 15px" align="right">
                            <asp:Button ID="but_search" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                                Text="Search"></asp:Button>
                            <asp:Button ID="but_Export" TabIndex="4" OnClick="but_Export_Click" runat="server"
                                CssClass="btn btn-primary" Text="Export"></asp:Button>
                        </td>--%>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right"></td>
                    </tr>
                    <tr>
                        <td class="titlesection" colspan="7" runat="server" id="trSearchCriteria">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="7">
                            <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0" runat="server" id="tblSearch">
                                <tbody>
                                    <tr class="tr2">
                                        <td height="25"></td>
                                        <td class="TextLabel" style="width:30%">Region :
                                        </td>
                                        <td style="width: 160px">
                                           <asp:DropDownList ID="list_region" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                OnSelectedIndexChanged="list_region_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="lab_region" runat="server"></asp:Label>
                                        </td>
                                         <td class="TextLabel">Center :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:DropDownList id="list_center" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="list_center_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lab_center" runat="server"></asp:Label>
                                        </td>
                                        <td style="width: 160px">
                                        </td>
                                        <td style="width: 160px">
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td height="25"></td>
                                      
                                        <td class="TextLabel">Class&nbsp;:
                                        </td>
                                        <td>
                                            <asp:DropDownList id="list_class" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                OnSelectedIndexChanged="list_class_SelectedIndexChanged">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lab_section" runat="server" Text="Section :"></asp:Label>
                                        </td>
                                        <td style="width: 160px">
                                            <asp:DropDownList id="list_section" runat="server" CssClass="dropdownlist">
                                                <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td height="25"></td>
                                        <td class="TextLabel">User Type&nbsp;:
                                        </td>
                                        <td>
                                           <asp:DropDownList id="list_UserType" runat="server" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="list_userTypes_SelectedIndexChanged">
                                                 <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                 <asp:ListItem Text="Parent" Value="Parent"></asp:ListItem>
                                                 <asp:ListItem Text="Student" Value="Student"></asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server" visible="false" id="trSearch">
                        <td class="titlesection" colspan="7">&nbsp;Search Result
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">&nbsp;
                            <asp:GridView ID="dg_student" runat="server" DataKeyNames="student_id" CssClass="datatable table table-striped table-bordered table-hover"
                                OnPreRender="dg_student_PreRender" AutoGenerateColumns="False" AllowPaging="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Select All">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkSelectAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkSelectAll_CheckedChanged" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkSelect" runat="server" AutoPostBack="true" OnCheckedChanged="chkSelect_CheckedChanged"/>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Student_Id" HeaderText="Student No">
                                        <%--2--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Father_CNIC" HeaderText="CNIC">
                                        <%--2--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FullName" HeaderText="Name">
                                        <%--3--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <%--4--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Region_Name" HeaderText="Region">
                                        <%--5--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                        <%--6--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>

                                  
                                </Columns>
                                <SelectedRowStyle ForeColor="SlateGray" />
                                <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="7">
                            <table cellspacing="1" cellpadding="1" width="60%" bgcolor="#ffffff" border="0" runat="server" id="PushMessage" visible="false">
                                <tbody>
                                    <tr class="tr2">
                                        <td height="25"></td>
                                        <td class="TextLabel">Title :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:TextBox ID="pushMessageTitle" runat="server" CssClass="textbox" ></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td height="25"></td>
                                        <td class="TextLabel">Body&nbsp;:
                                        </td>
                                        <td>
                                        <asp:TextBox ID="pushMessageBody" runat="server" TextMode="MultiLine" Rows="4" Columns="50"></asp:TextBox>
                                            </td>
                                    </tr>           
                                     <tr>
                        <td style="height: 15px">
                        </td>
                                         <td style="height: 15px">
                        </td>
                                         <td style="height: 15px">
                            <asp:Button ID="but_search2" TabIndex="1" OnClick="but_search_Click" runat="server"
                                CssClass="btn btn-primary" Text="Send"></asp:Button>
                        </td>
                    </tr> 
                                </tbody>
                            </table>
                        </td>
                    </tr>
                     
                    <div runat="server" id="trReportCard" visible="false">
                        <tr>
                            <td>
                                <div class="pull-right">
                                    <asp:Button ID="btnCancelHistory" TabIndex="5" OnClick="btnCancelHistory_Click" runat="server"
                                        CssClass="btn btn-danger" Text="Cancel"></asp:Button>
                                </div>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td class="titlesection" colspan="7">&nbsp;Student Report Card History
                            </td>
                        </tr>

                        <tr runat="server">
                            <td>
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


                                        <%--  <asp:BoundField DataField="Class_Section" HeaderText="Class-Section">
                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>--%>
                                        <asp:TemplateField HeaderText="View Result Card">
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="btnReport" CssClass="btn btn-info" CommandArgument='<%# Eval("Student_Id") %>'
                                                    OnClick="btnViewReport_Click" Text="View Report" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Result Summary">
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                            <ItemTemplate>
                                                <asp:Button runat="server" ID="btnSummary" CssClass="btn btn-info" CommandArgument='<%# Eval("Student_Id") %>'
                                                    OnClick="btnSummary_Click" Text="View Marks Summary" Visible='<%# (int)( Eval("Class_Id"))>=7 %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <SelectedRowStyle ForeColor="SlateGray" />
                                    <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                    <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                    <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr runat="server" visible="false" id="trresultSummary">
                            <td class="titlesection" colspan="7">&nbsp;Student Marks Summary
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 15px">
                                <asp:GridView ID="dv_details" runat="server" OnPreRender="dv_details_PreRender" AutoGenerateColumns="False"
                                    HorizontalAlign="Center" CssClass="datatable table table-striped table-bordered table-hover">
                                    <RowStyle CssClass="tr2" BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="No.">
                                            <ItemStyle Font-Size="14px" Width="10%" />
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="Session_Id" HeaderText="Session_Id" Visible="False">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Session_Name" HeaderText="Session Name">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Term" HeaderText="Term">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="MidYearMarks_CH" HeaderText="Mid Year %">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Course_Work" HeaderText="Course Work %">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Theory_Exam_CH" HeaderText="Exam %">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="T" HeaderText="Average %">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="G" HeaderText="Grade">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Employee_Id" HeaderText="Employee_Id" Visible="False">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Section_Subject_Id" HeaderText="Section_Subject_Id" Visible="False">
                                            <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                    </Columns>
                                    <SelectedRowStyle ForeColor="SlateGray" />
                                    <RowStyle CssClass="tr1"></RowStyle>
                                    <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                    <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </div>






                    <div runat="server" id="trSubjectList" visible="false">
                        <tr>
                            <td>
                                <div class="pull-right">
                                    <asp:Button ID="Button1" TabIndex="5" OnClick="btnCancelHistory_Click" runat="server"
                                        CssClass="btn btn-danger" Text="Cancel"></asp:Button>
                                </div>
                            </td>
                        </tr>
                        <tr runat="server">
                            <td class="titlesection" colspan="7">&nbsp;Student Subject List
                            </td>
                        </tr>

                        <tr runat="server">
                            <td>
                                <asp:GridView ID="gvSubjectList" runat="server" CssClass="table table-striped table-bordered table-hover"
                                    AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField DataField="Student_Id" HeaderText="Student Id">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="AssignedSection_Id" HeaderText="Section_Id">
                                            <ItemStyle CssClass="hide" />
                                            <HeaderStyle CssClass="hide" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="User_Name" HeaderText="Techer ERP #">
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="FullName" HeaderText="Techer Name">
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        </asp:BoundField>

                                    </Columns>
                                    <SelectedRowStyle ForeColor="SlateGray" />
                                    <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                    <HeaderStyle BackColor="#9EB5D5" ForeColor="White"></HeaderStyle>
                                    <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                </asp:GridView>
                            </td>
                        </tr>
                    </div>



                    <tr>
                        <td>
                            <div class="pull-right">
                                <asp:Button ID="btnCancel" TabIndex="5" OnClick="btnCancel_Click" runat="server"
                                    Visible="false" CssClass="btn btn-danger" Text="Cancel"></asp:Button>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="container">

                <div class="modal fade" id="TestModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Edit Student Comments</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <asp:Label ID="lblFirstName" runat="server" CssClass="TextLabelMandatory40" Text="First Name "></asp:Label>
                                    <asp:TextBox ID="txtFirstName" ValidationGroup="modal" runat="server" CssClass="form-control " Enabled="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtFirstName"
                                        ErrorMessage="First Name Required" ForeColor="Red" ValidationGroup="modal" />

                                </p>
                                <p>
                                    <asp:Label ID="lblLastName" runat="server" CssClass="TextLabelMandatory40" Text="Last Name "></asp:Label>
                                    <asp:TextBox ID="txtLastName" ValidationGroup="modal" runat="server" CssClass="form-control " Enabled="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLastName"
                                        ErrorMessage="Last Name Required" ForeColor="Red" ValidationGroup="modal" />
                                </p>
                                <%--<p>
                                    <asp:Label ID="lblNameUrdu" runat="server" CssClass="TextLabelMandatory40" Text="First Name (Urdu)"></asp:Label>
                                    <asp:TextBox ID="txtNameUrdu" ClientIDMode="Static" dir="rtl" ValidationGroup="modal" runat="server" CssClass="form-control " Enabled="true"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNameUrdu"
                                        ErrorMessage="Urdu Name Required" ForeColor="Red" ValidationGroup="modal" />
                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" ForeColor="Red" ValidationGroup="modal" ControlToValidate="txtNameUrdu" ValidationExpression="[\u0600-\u065F\u066A-\u06EF\u06FA-\u06FFa]" runat="server" ErrorMessage="Urdu Text Only"></asp:RegularExpressionValidator>--%>
                                </p>
                                <%--  <p>
                                        <asp:Label ID="lblMarks" runat="server" CssClass="TextLabelMandatory40" Text="Comments: "></asp:Label>
                                        <asp:TextBox ID="txtMarks" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="DataTypeCheck"
                                            ForeColor="Red" ValidationGroup="test" Type="Double" ControlToValidate="txtMarks"
                                            ErrorMessage="Please enter a Numeric value" />
                                    </p>--%>
                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                    Text="Save" CausesValidation="true" ValidationGroup="modal" />
                                <%-- <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                    OnClick="btnCancel_Click" Text="Cancel" />--%>
                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
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
