<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="VerificationOfAttendance.aspx.cs" Inherits="PresentationLayer_VerificationOfAttendance"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--<asp:ScriptReference Path="~/Scripts/dock1A.js" />--%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1.js" />--%>
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
                                jq('#<%=gvVerification.ClientID %>').DataTable({
                                destroy: true,
                                dom: 'Blfrtip',
                                buttons: [
                                    {
                                        extend: 'excel',
                                        exportOptions: {
                                            columns: ':visible'
                                        }
                                    }
                                ],
                                aLengthMenu: [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]],
                                iDisplayLength: 50,
                                bLengthChange: true,
                                order: [[0, "asc"]],
                                paging: true,
                                ordering: true,
                                info: true,
                                scrollX: false,
                                oLanguage: {
                                    sZeroRecords: "There are no Records that match your search criteria",
                                    sInfo: "Displaying _START_ to _END_ of _TOTAL_ records",
                                    sInfoEmpty: "Showing 0 to 0 of 0 records",
                                    sInfoFiltered: "(filtered from _MAX_ total records)",
                                    sEmptyTable: 'No Rows to Display.....!',
                                    sSearch: "Search :"
                                }
                            });
                        } catch (err) {
                            //alert('datatable ' + err);
                        }
                    });
                }

                //Re-bind for callbacks
                var prm = Sys.WebForms.PageRequestManager.getInstance();
                prm.add_endRequest(function () {
                    jq(document).ready(document_Ready);
                });
            });
            </script>


            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Verification Of Attendance"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <tr>
                                <td style="height: 15px" align="right">
                                    <asp:Button ID="but_search" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                                        Text="Search"></asp:Button>

                                </td>
                            </tr>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">

                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">Region*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="ddl_Region" runat="server" CssClass="dropdownlist" Width="217px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">Center*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="217px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">Class*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_Class" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_AdmTest_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">Term*: </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" CssClass="dropdownlist" OnSelectedIndexChanged="list_Term_SelectedIndexChanged" Width="217px">
                                            <asp:ListItem Text="Select" Value="0" />
                                            <asp:ListItem Text="First Term" Value="1" />
                                            <asp:ListItem Text="Second Term" Value="2" />
                                            <asp:ListItem Text="Mock Examination" Value="3" />
                                        </asp:DropDownList>
                                    </td>

                                </tr>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right"></td>
                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">&nbsp; </td>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="left" style="width: 100%" colspan="2">
                            <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px" class="titlesection" colspan="2">Attendance List
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="left" style="width: 100%; text-align: center" colspan="2">


                            <asp:GridView ID="gvVerification" runat="server" AutoGenerateColumns="False"
                                BorderStyle="None" Width="100%" CssClass="datatable table table-striped table-bordered table-hover"
                                OnPreRender="dg_student_PreRender" AllowPaging="false" EmptyDataText="No data in the data source." ShowHeaderWhenEmpty="True">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <%--<asp:BoundField DataField="Center_Id" HeaderText="Center Id">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>--%>
                                    <%--<asp:BoundField DataField="Class_Id" HeaderText="Class Id">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>--%>
                                    <%--<asp:BoundField DataField="Section_Id" HeaderText="Section Id">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>--%>
                                    <asp:BoundField DataField="StudentERP" HeaderText="Student ERP">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="School" HeaderText="School">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class" HeaderText="Class">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section" HeaderText="Section">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TermAttendedDays" HeaderText="Term Attended Days">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalTermDays" HeaderText="Total Term Days">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                <RowStyle CssClass="tr1" />

                            </asp:GridView>

                        </td>

                    </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
