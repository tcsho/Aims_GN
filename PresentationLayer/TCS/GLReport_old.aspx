<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="GLReport.aspx.cs" Inherits="PresentationLayer_GLReport"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/PresentationLayer/TCS/ReportUserControl.ascx" TagName="UserInformationGrid"
    TagPrefix="uc1" %>
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="GL & Internal Results"></asp:Label>
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
                        <td class="titlesection" colspan="7">Search Criteria
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="7">
                            <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                                <tbody>
                                    <tr id="trMoId" runat="server">
                                        <td style="width: 12px"></td>
                                        <td class="TextLabelMandatory">Main Organization* :
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="ddl_MOrg" runat="server" CssClass="dropdownlist" Width="250px"
                                                Enabled="False" OnSelectedIndexChanged="ddl_MOrg_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfv_mOrg" runat="server" Width="200px" Enabled="False"
                                                ErrorMessage="Mian Org is a required Field" Display="Dynamic" ControlToValidate="ddl_MOrg"
                                                InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trCountry" runat="server">
                                        <td style="width: 12px"></td>
                                        <td class="TextLabelMandatory">Main Organization Country* :
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="ddl_country" runat="server" CssClass="dropdownlist" Width="250px"
                                                OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_country" runat="server" Width="165px" Enabled="False"
                                                ErrorMessage="Country is a required Field" Display="Dynamic" ControlToValidate="ddl_country"
                                                InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trRegion" runat="server">
                                        <td style="width: 12px; height: 18px"></td>
                                        <td class="TextLabelMandatory">Region* :
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px" AutoPostBack="True"
                                                OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="linkMultiRegion" runat="server" OnClick="linkMultiRegion_Click">Select Multiple Region(s)</asp:LinkButton>
                                            <br />
                                            <asp:RequiredFieldValidator ID="rfv_region" runat="server" Width="169px" Enabled="False"
                                                ErrorMessage="Region is a required Field" Display="Dynamic" ControlToValidate="ddl_region"
                                                InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                        </td>
                                        <td valign="top" align="right"></td>
                                    </tr>
                                    <tr id="tr1" runat="server">
                                        <td></td>
                                        <td></td>
                                        <td valign="top">
                                            <uc1:UserInformationGrid ID="UIGridRegion" runat="server" />
                                            <asp:CheckBoxList ID="lstRegion" runat="server" Visible="false">
                                            </asp:CheckBoxList>
                                            <asp:LinkButton ID="lbRegionAdd" runat="server" OnClick="lbRegionAdd_Click" Visible="False">Add</asp:LinkButton>
                                        </td>
                                        <td></td>
                                    </tr>
                                    <tr id="trSession" runat="server">
                                        <td style="width: 12px; height: 18px"></td>
                                        <td class="TextLabelMandatory40">Session* :
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlSession"
                                                Display="Dynamic" Enabled="False" ErrorMessage="Session is a required Field"
                                                InitialValue="0" ValidationGroup="s" Width="169px"></asp:RequiredFieldValidator>
                                            <asp:LinkButton ID="lnkMultiSession" runat="server" OnClick="lnkMultiSession_Click">Select Multiple Session(s)</asp:LinkButton>
                                        </td>
                                        <td align="right" valign="top"></td>
                                    </tr>
                                    <tr id="tr4" runat="server">
                                        <td></td>
                                        <td></td>
                                        <td valign="top">
                                            <uc1:UserInformationGrid ID="UIGridSession" runat="server" />
                                            <asp:CheckBoxList ID="lstSessions" runat="server" Visible="false">
                                            </asp:CheckBoxList>
                                            <asp:LinkButton ID="lbSessionAdd" runat="server" OnClick="lbSessionAdd_Click" Visible="False">Add</asp:LinkButton>
                                        </td>
                                        <td align="right" valign="top"></td>
                                    </tr>
                                    <tr id="trtermgroup" runat="server">
                                        <td style="width: 12px; height: 18px"></td>
                                        <td class="TextLabelMandatory40">Term Group :
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="listTermGroup" runat="server" CausesValidation="True"
                                                CssClass="dropdownlist" Width="250px">
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="lnkMultiTerm" runat="server" OnClick="lnkMultiTerm_Click">Select Multiple Term(s)</asp:LinkButton>
                                        </td>
                                        <td align="right" valign="top"></td>
                                    </tr>
                                    <tr id="tr6" runat="server">
                                        <td></td>
                                        <td></td>
                                        <td valign="top">
                                            <uc1:UserInformationGrid ID="UIGridTerm" runat="server" />
                                            <asp:CheckBoxList ID="lstTerm" runat="server" Visible="false">
                                            </asp:CheckBoxList>
                                            <asp:LinkButton ID="lbTermAdd" runat="server" OnClick="lbTermAdd_Click" Visible="False">Add</asp:LinkButton>
                                        </td>
                                        <td align="right" valign="top"></td>
                                    </tr>
                                    <tr id="trCenter" runat="server">
                                        <td style="width: 12px; height: 18px"></td>
                                        <td class="TextLabelMandatory40">School :
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="rfv_center" runat="server" Width="167px" Enabled="False"
                                                ErrorMessage="Center is a required Field" Display="Dynamic" ControlToValidate="ddl_center"
                                                InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                            <asp:LinkButton ID="linkMultiCenter" runat="server" OnClick="linkMultiCenter_Click">Select Multiple Center(s)</asp:LinkButton>
                                        </td>
                                        <td align="right" valign="top"></td>
                                    </tr>
                                    <tr id="tr2" runat="server">
                                        <td></td>
                                        <td></td>
                                        <td valign="top">
                                            <uc1:UserInformationGrid ID="UIGridCenter" runat="server" />
                                            <asp:CheckBoxList ID="lstCenter" runat="server" Visible="false">
                                            </asp:CheckBoxList>
                                            <asp:LinkButton ID="lbCenterAdd" runat="server" OnClick="lbCenterAdd_Click" Visible="False">Add</asp:LinkButton>
                                        </td>
                                        <td align="right" valign="top"></td>
                                    </tr>
                                    <tr id="trClass" runat="server">
                                        <td style="width: 12px; height: 18px"></td>
                                        <td class="TextLabelMandatory40">Class :
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdownlist" Width="250px"
                                                OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="linkMultiClass" runat="server" OnClick="linkMultiClass_Click">Select Multiple Class(es)</asp:LinkButton>
                                            <br />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_center"
                                                Display="Dynamic" Enabled="False" ErrorMessage="Class required " InitialValue="0"
                                                Width="167px" ValidationGroup="s"></asp:RequiredFieldValidator>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBoxList ID="lstClass" runat="server" Visible="false">
                                                        </asp:CheckBoxList>
                                                        <asp:LinkButton ID="lbClassAdd" runat="server" OnClick="lbClassAdd_Click" Visible="False">Add</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top" align="right"></td>
                                    </tr>
                                    <tr id="tr7" runat="server">
                                        <td></td>
                                        <td></td>
                                        <td valign="top">
                                            <uc1:UserInformationGrid ID="UIGridClass" runat="server" />
                                        </td>
                                        <td align="right" valign="top"></td>
                                    </tr>
                                    <tr id="trSubject" runat="server">
                                        <td style="width: 12px; height: 18px"></td>
                                        <td class="TextLabelMandatory40">Subject :
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="ddlSubject" runat="server" CssClass="dropdownlist" Width="250px">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="11">English</asp:ListItem>
                                                <asp:ListItem Value="13">Maths</asp:ListItem>
                                                <asp:ListItem Value="14">Science</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:LinkButton ID="linkMultiSubject" runat="server" OnClick="linkMultiSubject_Click">Select Multiple Subject(s)</asp:LinkButton>
                                            <br />
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:CheckBoxList ID="lstSubject" runat="server" Visible="false">
                                                        </asp:CheckBoxList>
                                                        <asp:LinkButton ID="lbSubjectAdd" runat="server" OnClick="lbSubjectAdd_Click" Visible="False">Add</asp:LinkButton>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td valign="top" align="right"></td>
                                    </tr>
                                    <tr id="tr3" runat="server">
                                        <td></td>
                                        <td></td>
                                        <td valign="top">
                                            <uc1:UserInformationGrid ID="UIGridSubject" runat="server" />
                                        </td>
                                        <td align="right" valign="top"></td>
                                    </tr>
                                    <tr class="tr2">
                                        <td style="width: 12px; height: 18px"></td>
                                        <td class="TextLabel40"></td>
                                        <td valign="top" style="padding: 12px; padding-left: 4.6%; float: right;">
                                            <asp:Button ID="but_search" runat="server" CssClass="btn btn-primary" OnClick="but_search_Click"
                                                Text="Search" />
                                            <asp:Button ID="btnExport" runat="server" CssClass="btn btn-primary" OnClick="but_export_Click"
                                                Text="ExportToExcel" Visible="false" />
                                        </td>
                                        <td valign="top" align="right"></td>
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
                            <asp:GridView ID="dg_class" runat="server"
                                DataKeyNames="ERP" CssClass="datatable table table-striped table-bordered table-hover"
                                OnPreRender="dg_class_PreRender" AutoGenerateColumns="False" AllowPaging="false">
                                <Columns>
                                    <asp:BoundField DataField="SchoolName" HeaderText="School Name">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="AcademicYear" HeaderText="Academic Year">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Term" HeaderText="Term">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject" HeaderText="Subject">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ERP" HeaderText="ERP">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class" HeaderText="Class">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section" HeaderText="Section">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="LearningPerc" HeaderText="Class Learning %">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ExamPerc" HeaderText="Exam %">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TestName" HeaderText="GL- Test Name">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="StandardAgeScore" HeaderText="GL- Standard Age Score">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="OverallStanine" HeaderText="GL-overall stanine">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PercentileRank" HeaderText="GL- Percentile Rank">
                                        <ItemStyle Font-Size="14px" />
                                        <%--<HeaderStyle Width="1px" Wrap="true" />--%>
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="tr1"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>
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
