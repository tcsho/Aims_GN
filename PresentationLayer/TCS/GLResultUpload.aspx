<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="GLResultUpload.aspx.cs" Inherits="PresentationLayer_TCS_GLResultUpload"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <%--<Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>--%>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
        <ContentTemplate>
            <%--<script type="text/javascript" src="Scripts/jquery-1.4.1.min.js"></script>
            <script type="text/javascript" src="Scripts/jquery-impromptu.2.7.min.js"></script>--%>
            <%--<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
              <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.2/js/toastr.min.js"></script>--%>
            <script type="text/javascript">
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
            <body>
                <asp:HiddenField runat="server" id="hfWasConfirmed" />
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
                                            <td valign="top" style="padding: 12px; padding-left: 0%; width: 60%;">
                                                <asp:Button ID="but_search" runat="server" CssClass="btn btn-primary" OnClick="but_search_Click"
                                                    Text="Search" Visible="false" />
                                                &nbsp;&nbsp;<asp:Label ID="lblFileUpload" runat="server" Text="Please Select only .xlsx file" Style="color: red;"></asp:Label>
                                                <asp:FileUpload ID="FileUpload1" onchange= "checkfile(this)"   CssClass="btn btn-primary" runat="server" />
                                                <br />
                                                <asp:Button ID="btnUpload" CssClass="btn btn-primary" runat="server" Text="View" OnClick="btnUpload_Click" Style="width: 8%; float: left;" />
                                                &nbsp;&nbsp;&nbsp;&nbsp;
                                                <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Clear" OnClick="btnClear_Click" Style="width: 8%;" />
                                                <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" OnClick="but_export_Click"
                                                    Text="ExportToCSV" Visible="false" />
                                                <br />
                                                <asp:Label ID="Label2" runat="server" Text="Has Header ?" Visible="false"></asp:Label>
                                                <asp:RadioButtonList ID="rbHDR" runat="server" Visible="false">
                                                    <asp:ListItem Text="Yes" Value="Yes" Selected="True"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="No"></asp:ListItem>
                                                </asp:RadioButtonList>
                                            </td>
                                            <td valign="top" style="padding: 12px; padding-left: 0%;">
                                                <label id="lblSession" runat="server" style="padding-right: 24px;">Session :</label>
                                                <%--Session :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;--%>
                                                <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblsessionerror" runat="server" Text="Please Select Session!!" Visible="False" Style="color: red;"></asp:Label>
                                                <br />
                                                <label id="lblTG" runat="server">Term Group :</label>
                                                <asp:DropDownList ID="listTermGroup" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                    CssClass="dropdownlist" Width="250px">
                                                </asp:DropDownList>
                                                <asp:Label ID="lbltermgrouperror" runat="server" Text="Please Select Term Group!!" Visible="False" Style="color: red;"></asp:Label>
                                                <br />
                                                <asp:Button ID="btnSave" CssClass="btn btn-primary" runat="server" Text="Upload" OnClick="btnSave_Click" Style="width: 18%; float: right;" Visible="false" />
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td class="titlesection" colspan="7">&nbsp;Search Result
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">&nbsp;
                            <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="PageIndexChanging" AllowPaging="false"
                                CssClass="datatable table table-striped table-bordered table-hover">
                                <Columns>
                                    <%--<asp:BoundField DataField="Test Name" HeaderText="Test Name">
                                        <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                    <asp:BoundField DataField="Student ID" HeaderText="Student ID">
                                        <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                    <asp:BoundField DataField="Standard Age Score" HeaderText="Standard Age Score">
                                        <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                    <asp:BoundField DataField="Overall Stanine" HeaderText="Overall Stanine">
                                        <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>
                                    <asp:BoundField DataField="Percentile Rank" HeaderText="Percentile Rank">
                                        <ItemStyle Font-Size="14px" />
                                        </asp:BoundField>--%>
                                </Columns>
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
            </body>
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
