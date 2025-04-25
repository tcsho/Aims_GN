<%@ page title="" language="C#" masterpagefile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="GLResultUpload_old.aspx.cs" Inherits="PresentationLayer_TCS_GLResultUpload"  Theme="BlueTheme" %>

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
                    jq(document).ready(document_Ready);
                    function document_Ready() {

                        jq(document).ready(function () {
                            try {
                                jq('table.datatable').DataTable({
                                    destroy: true,
                                    tableTools:
                                    { //Start of tableTools collection
                                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                        "aButtons":
                                            [ //start of button main/master collection

                                            ] // ******************* end of button master Collection
                                    } // ******************* end of tableTools
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 25, 'bLengthChange': true // ,"bJQueryUI":true
                                    , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false //, fixedHeader: true , "stateSave": true
                                    , //--- Dynamic Language---------
                                    "oLanguage": {
                                        "sZeroRecords": "There are no Records that match your search critera",
                                        "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                                        "sInfoEmpty": "Showing 0 to 0 of 0 records",
                                        "sInfoFiltered": "(filtered from _MAX_ total records)",
                                        "sEmptyTable": 'No Rows to Display.....!'
                                    }
                                }
                                );
                            }
                            catch (err) {
                                alert('datatable ' + err);
                            }
                        }
                        );

                    } //end of documnet_ready()

                    //Re-bind for callbacks
                    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    prm.add_endRequest(function () {
                        jq(document).ready(document_Ready);
                    }
                    );

                });

                function getConfirmationValue() {
                    if (confirm('The upload process will replace the student existing GL data for the selected Session and Term Group!')) {
                        $('#<%=hfWasConfirmed.ClientID%>').val('true')
                    }
                    else {
                        $('#<%=hfWasConfirmed.ClientID%>').val('false')
                    }
                    return true;

                    function checkfile(sender) {
                        var validExts = new Array(".xlsx", ".xls");
                        var fileExt = sender.value;
                        fileExt = fileExt.substring(fileExt.lastIndexOf('.'));
                        if (validExts.indexOf(fileExt) < 0) {
                            alert("Invalid file selected, valid files are of " +
                                validExts.toString() + " types.");
                            return false;
                        }
                        else return true;
                    }
                }
                    //Sys.Application.add_init(function () {
                    //    jq(document).ready(document_Ready);
                    //    function document_Ready() {

                    //        jq(document).ready(function () {
                    //            try {
                    //                jq('table.datatable').DataTable({
                    //                    destroy: true,
                    //                    tableTools:
                    //                    { //Start of tableTools collection
                    //                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                    //                        "aButtons":
                    //                            [ //start of button main/master collection

                    //                            ] // ******************* end of button master Collection
                    //                    } // ******************* end of tableTools
                    //                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 25, 'bLengthChange': true // ,"bJQueryUI":true
                    //                    , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false //, fixedHeader: true , "stateSave": true
                    //                    , //--- Dynamic Language---------
                    //                    "oLanguage": {
                    //                        "sZeroRecords": "There are no Records that match your search critera",
                    //                        "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                    //                        "sInfoEmpty": "Showing 0 to 0 of 0 records",
                //                        "sInfoFiltered": "(filtered from _MAX_ total records)",
                //                        "sEmptyTable": 'No Rows to Display.....!'
                //                    }
                //                }
                //                );
                //            }
                    //            catch (err) {
                    //                alert('datatable ' + err);
                    //            }
                    //        }
                    //        );

                    //    } //end of documnet_ready()

                    //    //Re-bind for callbacks
                    //    var prm = Sys.WebForms.PageRequestManager.getInstance();
                    //    prm.add_endRequest(function () {
                    //        jq(document).ready(document_Ready);
                    //    }
                    //    );

                    //});
            </script>
            <asp:HiddenField runat="server" ID="hfWasConfirmed" />
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="GL Result Upload"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right"></td>
                    </tr>
                    <tr>
                        <td class="titlesection" colspan="7">Upload File
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="7">
                            <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                                <tbody>
                                    <tr class="tr2">
<%--                                        <td valign="top">
                                            <asp:Button ID="but_search" runat="server" CssClass="btn btn-primary" OnClick="but_search_Click"
                                                Text="Search" Visible="false" />
                                            <asp:Button ID="btnUpload" CssClass="btn btn-primary" runat="server" Text="View" OnClick="btnUpload_Click" Style="width: 8%; float: left;" Visible="false" />
                                            &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" Style="width: 8%;" Visible="false" />
                                            <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" OnClick="but_export_Click"
                                                Text="ExportToCSV" Visible="false" />
                                            <br />
                                            <asp:Label ID="Label2" runat="server" Text="Has Header ?" Visible="false"></asp:Label>
                                            <asp:RadioButtonList ID="rbHDR" runat="server" Visible="false">
                                                <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>--%>
                                        <td>
                                            <label id="lblSession" runat="server" class="TextLabelMandatory40">Session* :</label>
                                            <%--Session :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                            <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblsessionerror" runat="server" Text="Please Select Session" Visible="False" Style="color: red;"></asp:Label>
                                            <br />
                                            <label id="lblTG" runat="server" class="TextLabelMandatory40">Term Group* :</label>
                                            <asp:DropDownList ID="listTermGroup" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                CssClass="dropdownlist" Width="250px">
                                            </asp:DropDownList>
                                            <asp:Label ID="lbltermgrouperror" runat="server" Text="Please Select Term Group" Visible="False" Style="color: red;"></asp:Label>
                                            <br />
                                            <label id="lblClass" runat="server" class="TextLabelMandatory40" visible="false">Class :</label>
                                            <asp:DropDownList ID="ddlClass" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                CssClass="dropdownlist" Width="250px" Visible="false">
                                            </asp:DropDownList>
                                            <label id="lblSubject" runat="server" class="TextLabelMandatory40">Subject* :</label>
                                            <asp:DropDownList ID="ddlSubject" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                CssClass="dropdownlist" Width="250px" OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="True">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="11">English</asp:ListItem>
                                                <asp:ListItem Value="13">Maths</asp:ListItem>
                                                <asp:ListItem Value="14">Science</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Label ID="lblSubjecterror" runat="server" Text="Please Select Subject" Visible="False" Style="color: red;"></asp:Label>
                                            <br />

                                            <label id="lblFileUpload" runat="server" class="TextLabelMandatory40">Please Select only .xlsx file:</label>

                                            <asp:FileUpload ID="FileUpload1" Style="display:inline;" runat="server" Width="450px" />
                                            
                                            <br />

                                             <asp:Button ID="btnSave" CssClass="btn btn-primary" Style="margin-left:40%" Width="150px" runat="server"  Text="Upload" OnClick="btnSave_Click" />

                                        </td>

                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="titlesection" colspan="7">&nbsp;GL Result History
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;

                                <asp:GridView ID="gvGLFileUploadHistory" runat="server" AutoGenerateColumns="False" AllowPaging="false"
                                    OnPreRender="gvGLFileUploadHistory_PreRender"
                                    CssClass="datatable table table-striped table-bordered table-hover table-sm ">
                                    <HeaderStyle Font-Bold="true" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Sr. #">
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="14px" />
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                        <asp:BoundField DataField="FileName" HeaderText="File Name">
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="14px" />
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="SessionName" HeaderText="Session">
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="14px" />
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Term" HeaderText="Term">
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="14px" />
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="Subject" HeaderText="Subject">
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="14px" />
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                        </asp:BoundField>

                                        <asp:BoundField DataField="FileUploadOn" HeaderText="File Uplode DateTime">
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="14px" />
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Records" HeaderText="Total Records">
                                            <HeaderStyle HorizontalAlign="Left" Font-Size="14px" />
                                            <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="GL Result History">
                                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" Width="10%" />
                                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" Width="10%" />
                                            <ItemTemplate>
                                                <asp:LinkButton runat="server" ID="btnReport" CommandArgument='<%# Eval("GLR_FileUp_Id") %>'
                                                    OnClick="BindGLResultGrid"> <span class="glyphicon glyphicon-list-alt"></span></asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            <asp:Label ID="lblHistoryDataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td id="titleStudentResult" class="titlesection" colspan="7" runat="server" visible="false">&nbsp;GL Student Result
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">&nbsp;
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" AllowPaging="false"
                                OnPreRender="GridView1_PreRender"
                                CssClass="datatable table table-striped table-bordered table-hover">
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Font-Size="14px" />
                                        <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TestName" HeaderText="Test Name">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Student_Id" HeaderText="Student ID">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StandardAgeScore" HeaderText="Standard Age Score">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OverallStanine" HeaderText="Overall Stanine">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PercentileRank" HeaderText="Percentile Rank">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Term" HeaderText="Percentile Rank">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Session">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="tr1"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>
                            <%--<asp:GridView ID="dg_class" runat="server"
                                DataKeyNames="Student_Id" CssClass="datatable table table-striped table-bordered table-hover"
                                OnPreRender="dg_class_PreRender" AutoGenerateColumns="False" AllowPaging="false">
                                <Columns>
                                    <asp:BoundField DataField="First_Name" HeaderText="First Name *">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Last_Name" HeaderText="Last Name *">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Student_Id" HeaderText="Unique Identifier *">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Date_Of_Birth" HeaderText="Date of birth *" DataFormatString="{0:dd/MM/yyyy}">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Gender" HeaderText="Gender *">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Group" HeaderText="Group *">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Year">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="" HeaderText="External Reference">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="" HeaderText="Free School Meals">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="" HeaderText="Ethnic Group">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="" HeaderText="SEN">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="" HeaderText="English as a Second Language">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Custom 1">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Student_Status" HeaderText="Custom 2">
                                        <ItemStyle Font-Size="14px" />
                                        <%--<HeaderStyle Width="1px" Wrap="true" />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="tr1"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>--%>
                            <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
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
