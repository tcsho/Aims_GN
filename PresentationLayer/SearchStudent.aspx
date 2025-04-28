<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="SearchStudent.aspx.cs" Inherits="PresentationLayer_SearchStudent"
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

                function openImageUploadmodal() {
                    //                    $('#myModal').modal('show');
                    $('#Uploadimagemodal').modal({
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


                function closeImageUploadmodal() {

                    $('#Uploadimagemodal').modal('hide');
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Search Students"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="text_dateOfBirth">
                            </cc1:CalendarExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">
                            <asp:Button ID="but_search" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                                Text="Search"></asp:Button>
                            <asp:Button ID="but_Export" TabIndex="4" OnClick="but_Export_Click" runat="server"
                                CssClass="btn btn-primary" Text="Export"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right"></td>
                    </tr>
                    <tr>
                        <td class="titlesection" colspan="7" runat="server" id="trSearchCriteria">Search Criteria
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="7">
                            <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0" runat="server" id="tblSearch">
                                <tbody>
                                    <tr class="tr2">
                                        <td width="2%" height="25">&nbsp;
                                        </td>
                                        <td class="TextLabel">First Name :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:TextBox ID="text_firstName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td class="TextLabel">Middle Name :
                                        </td>
                                        <td width="26%">
                                            <asp:TextBox ID="text_middleName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td style="height: 25px" width="2%">&nbsp;
                                        </td>
                                        <td class="TextLabel">Last Name :
                                        </td>
                                        <td style="width: 160px; height: 25px">
                                            <asp:TextBox ID="text_lastName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td class="TextLabel">Date of Birth :
                                        </td>
                                        <td style="height: 25px">
                                            <asp:TextBox ID="text_dateOfBirth" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td style="height: 25px"></td>
                                        <td class="TextLabel">Gender :
                                        </td>
                                        <td style="width: 160px; height: 25px">
                                            <asp:DropDownList ID="list_gender" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                        <td class="TextLabel">Student No :
                                        </td>
                                        <td style="height: 25px">
                                            <asp:TextBox ID="text_studentNo" runat="server" CssClass="textbox" MaxLength="500"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td height="25"></td>
                                        <td class="TextLabel">Region :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:DropDownList ID="list_region" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                OnSelectedIndexChanged="list_region_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="lab_region" runat="server"></asp:Label>
                                        </td>
                                        <td class="TextLabel">Student Status :
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="list_studentStatus" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td height="25"></td>
                                        <td class="TextLabel">Center :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:DropDownList ID="list_center" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="list_center_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:Label ID="lab_center" runat="server"></asp:Label>
                                        </td>
                                        <td class="TextLabel">Class&nbsp;:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="list_class" runat="server" CssClass="dropdownlist"
                                                OnSelectedIndexChanged="list_class_SelectedIndexChanged">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td height="25"></td>
                                        <td class="TextLabel">Teacher :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:DropDownList ID="list_teacher" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                            <asp:Label ID="lab_teacher" runat="server"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Label ID="lab_section" runat="server" Text="Section :" Visible="False"></asp:Label>
                                        </td>
                                        <td style="width: 160px">
                                            <asp:DropDownList ID="list_section" runat="server" CssClass="dropdownlist" Visible="False">
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
                            <asp:Label ID="lblerror" runat="server" Text="" ForeColor="Red" Visible="false"></asp:Label>
                            <asp:GridView ID="dg_student" runat="server" DataKeyNames="student_id" CssClass="datatable table table-striped table-bordered table-hover" OnRowDataBound="dg_student_RowDataBound1"
                                OnPreRender="dg_student_PreRender" AutoGenerateColumns="False" AllowPaging="false">
                                <Columns>
                                    <asp:BoundField DataField="row" HeaderText="#">
                                        <%--0--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Aims_Id" HeaderText="AIMS ID">
                                        <%--1--%>
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                    </asp:BoundField>
                                    <%--  <asp:BoundField DataField="Student_No" HeaderText="Student No">
                                       
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />

                                    </asp:BoundField>--%>
                                    <asp:TemplateField HeaderText="">
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemTemplate>
                                            <asp:Label runat="server" id="lblstudent"><%# Eval("Student_No") %></asp:Label>
                                            <div style="display: flex; justify-content: center; align-items: center; height: 100%;">
                                                <%--<asp:Image ID="imgStatus" runat="server" Visible='<%# (int)( Eval("Class_Id"))==5 || (int)( Eval("Class_Id"))==6  %>' ImageUrl='<%# string.IsNullOrEmpty(Eval("Image_Path").ToString()) ? "~/PresentationLayer/TCS/Files/dummy.png" : Eval("Image_Path").ToString() %>'
                                                    Width="50px" Height="50px" Style="border-radius: 50%; object-fit: cover;" />--%>
  <asp:Image ID="imgStatus" runat="server"
                                                    Visible='<%# (int)( Eval("Class_Id"))==5 || (int)( Eval("Class_Id"))==6 %>'
                                                    ImageUrl='<%# string.IsNullOrEmpty(Eval("Image_Path").ToString()) ? "~/PresentationLayer/TCS/Files/dummy.png" : Eval("Image_Path").ToString() %>'
                                                    Width="70px" Height="50px"
                                                    Style="object-fit: cover; border-radius: 5px;" />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Name" HeaderText="Name">
                                        <%--3--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Country_Name" HeaderText="Country" Visible="false">
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
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <%--7--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                        <%--8--%>
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                        <%--9--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Id" HeaderText="Section_Id">
                                        <%--10--%>
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                        <%--11--%>
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>





                                    <asp:BoundField DataField="student_status" HeaderText="Status">
                                        <%--12--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Other Information">
                                        <HeaderStyle Font-Size="14px" HorizontalAlign="Center" Width="280px" />
                                        <ItemStyle Font-Size="14px" />
                                        <ItemTemplate>

                                            <%--13--%>

                                            <strong>Date of Birth:</strong>  &emsp; <%# Eval("Date_Of_Birth","{0:dd/M/yyyy}") %>
                                            <br>
                                            <strong>Contact #: </strong>&emsp;<%# Eval("PrimaryContactNo") %><br>
                                            <strong>Student CNIC: &emsp;</strong> <%# Eval("Student_CNIC") %>
                                            <br>
                                            <strong>Father Email:&emsp; </strong><%# Eval("FatherEmail") %>
                                            <br>
                                            <strong>Fee Status:</strong>&emsp;<%# Eval("FeeStatus") %>

                                            <br>
                                            <strong>First Name:</strong>&emsp;<%# Eval("FirstName") %>
                                            <br>
                                            <strong>Last Name:</strong>&emsp;<%# Eval("LastName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>




                                    <asp:TemplateField HeaderText="Apply" Visible="false">
                                        <%--14--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Apply</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server"></asp:CheckBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>


                                    <asp:TemplateField HeaderText="Student History">
                                        <%--15--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnReport" CommandArgument='<%# Eval("Student_No") %>'
                                                OnClick="BindReportCardGrid"> <span class="glyphicon glyphicon-list-alt"></span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Subject Details">
                                        <%--16--%>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemTemplate>
                                            <asp:LinkButton runat="server" ID="btnSubject" CommandArgument='<%# Eval("Student_No") %>'
                                                OnClick="BindSubjectGrid"> <span class="glyphicon glyphicon-list-alt"></span></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Edit" Visible="false">
                                        <%--17--%>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("Student_Id") %>'
                                                ForeColor="#004999" OnClick="btnEdit_Click" CssClass="btn-lg"
                                                ToolTip="Edit Record">
                                    <i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="SDP" Visible="true">
                                        <%--17--%>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <%--<a href='<%# ResolveUrl("~/PresentationLayer/tcs/IEP_Form_Wizard.aspx?s="+Eval("Student_Id")) %>'><i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>--%>
                                            <asp:Button runat="server" ID="btnAPICall" Text="View SDP" CommandName="CallAPI" CommandArgument='<%# Eval("Student_No") %>' CssClass="btn btn-primary" OnClick="btnAPICall_Click" />
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="FirstName" HeaderText="FirstName">
                                        <%--18--%>
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>


                                    <asp:BoundField DataField="LastName" HeaderText="LastName">
                                        <%--19--%>
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Region_Id" HeaderText="">
                                        <%--20--%>
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Center_Id" HeaderText="">
                                        <%--21--%>
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>


                                    <asp:TemplateField HeaderText="Edit Image">
                                        <%--22.--%>
                                        <ItemStyle HorizontalAlign="Center" Font-Size="14px"/>
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px"/>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnview" runat="server" CommandArgument='<%# Eval("Student_Id") %>' Visible='<%# (int)( Eval("Class_Id"))==5 || (int)( Eval("Class_Id"))==6  %>'
                                                ForeColor="#004999" OnClick="btnview_Click" CssClass="btn-lg"
                                                ToolTip="Edit Record">
                                    <i class="glyphicon glyphicon-picture TextLabelMandatory40 text-success"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--    <asp:TemplateField HeaderText="Edit Image">
                                        <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                        <ItemTemplate>
                                            <div style="display: flex; justify-content: center; align-items: center; height: 100%;">
                                                <asp:Image ID="imgStatus" runat="server" ImageUrl='<%# string.IsNullOrEmpty(Eval("Image_Path").ToString()) ? "~/PresentationLayer/TCS/Files/dummy.png" : Eval("Image_Path").ToString() %>'
                                                    Width="50px" Height="50px" Style="border-radius: 50%; object-fit: cover;" />
                                            </div>
                                        </ItemTemplate>
                                        <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                </Columns>
                                <SelectedRowStyle ForeColor="SlateGray" />
                                <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>

                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">
                            <asp:Button ID="but_search2" TabIndex="1" OnClick="but_search_Click" runat="server"
                                CssClass="btn btn-primary" Text="Search"></asp:Button>
                            <asp:Button ID="but_Export2" TabIndex="5" OnClick="but_Export_Click" runat="server"
                                CssClass="btn btn-primary" Text="Export"></asp:Button>
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


            <div class="container">

                <div class="modal fade" id="Uploadimagemodal" role="dialog">
                    <div class="modal-dialog">

                        <asp:Label ID="Span1" runat="server"></asp:Label>

                        <div class="modal-content">
                            <div class="modal-header">
                                <button type="button" class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Upload Student Profile Image</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <asp:Label ID="Label2" runat="server" CssClass="TextLabelMandatory40" Text="Student Name"></asp:Label>
                                    <asp:TextBox ID="txtStdName" ValidationGroup="modal" runat="server" CssClass="form-control " Enabled="false"></asp:TextBox>
                                </p>
                                <p style="font-size: small">

                                    <asp:Label ID="Label6" runat="server" Text="* File format must be JPEG,JPG,PNG and file size must be less than 1MB"></asp:Label>
                                    <asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" />
                                </p>
                            </div>
                            <div class="modal-footer">
                                <asp:ImageButton ID="btndocsupload" runat="server"  ImageUrl="~/PresentationLayer/TCS/Files/upload.png" Text="Upload & Save" Height="70px" Width="70px" OnClick="btndocsupload_Click" />
                               <%-- <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>--%>
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btndocsupload" />
        </Triggers>
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
