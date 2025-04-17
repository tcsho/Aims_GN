<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TCSReports.aspx.cs" MasterPageFile="~/PresentationLayer/MasterPage.master"
    Inherits="PresentationLayer_TCS_TCSReports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Src="~/PresentationLayer/TCS/ReportUserControl.ascx" TagName="UserInformationGrid"
    TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--<asp:ScriptReference Path="~/Scripts/dock1A.js" />
            <asp:ScriptReference Path="~/Scripts/dock1.js" />--%>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">
                $(document).ready(function () {
                    $('#lstClass').multiselect();
                });
            </script>
            <table class="main_table" runat="server" cellspacing="0" cellpadding="0" width="100%"
                align="center" border="0">
                <tbody>
                    <tr>
                        <td colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Reports"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" colspan="12">
                                            <asp:Button ID="btnViewReport" CssClass="btn btn-primary" runat="server" Text="View Report"
                                                Width="96px" OnClick="btnViewReport_Click" ValidationGroup="s" />
                                        </td>
                                    </tr>
                                    <tr id="crt" runat="server">
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                <tr>
                                                    <td class="titlesection" align="left" colspan="2">
                                                        Selection Criteria
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" style="border: solid 1px silver">
                                                        <asp:RadioButtonList ID="rblReportType" runat="server" OnSelectedIndexChanged="rblReportType_SelectedIndexChanged"
                                                            AutoPostBack="True">
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td style="vertical-align: top">
                                                        <table runat="server" id="table" style="width: 100%">
                                                            <tr id="trMoId" runat="server">
                                                                <td style="width: 12px">
                                                                </td>
                                                                <td class="TextLabelMandatory">
                                                                    Main Organization* :
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
                                                                <td style="width: 12px">
                                                                </td>
                                                                <td class="TextLabelMandatory">
                                                                    Main Organization Country* :
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
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory">
                                                                    Region* :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:LinkButton ID="linkMultiRegion" runat="server" OnClick="linkMultiRegion_Click">Select Multiple Region(s)</asp:LinkButton>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="rfv_region" runat="server" Width="169px" Enabled="False"
                                                                        ErrorMessage="Region is a required Field" Display="Dynamic" ControlToValidate="ddl_region"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>
                                                            <tr id="tr1" runat="server">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td valign="top">
                                                                    <uc1:UserInformationGrid ID="UIGridRegion" runat="server" />
                                                                    <asp:CheckBoxList ID="lstRegion" runat="server" Visible="false">
                                                                    </asp:CheckBoxList>
                                                                    <asp:LinkButton ID="lbRegionAdd" runat="server" OnClick="lbRegionAdd_Click" Visible="False">Add</asp:LinkButton>
                                                                </td>
                                                                <td>
                                                                </td>
                                                            </tr>
                                                            <tr id="trSession" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory40">
                                                                    Session*:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px" AutoPostBack="True" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlSession"
                                                                        Display="Dynamic" Enabled="False" ErrorMessage="Session is a required Field"
                                                                        InitialValue="0" ValidationGroup="s" Width="169px"></asp:RequiredFieldValidator>
                                                                    <asp:LinkButton ID="lnkMultiSession" runat="server" OnClick="lnkMultiSession_Click">Select Multiple Session(s)</asp:LinkButton>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="tr4" runat="server">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td valign="top">
                                                                    <uc1:UserInformationGrid ID="UIGridSession" runat="server" />
                                                                    <asp:CheckBoxList ID="lstSessions" runat="server" Visible="false">
                                                                    </asp:CheckBoxList>
                                                                    <asp:LinkButton ID="lbSessionAdd" runat="server" OnClick="lbSessionAdd_Click" Visible="False">Add</asp:LinkButton>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="trtermgroup" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory40">
                                                                    Term Group :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="listTermGroup" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                                        CssClass="dropdownlist" Width="250px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="trCenter" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory40">
                                                                    School*:
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfv_center" runat="server" Width="167px" Enabled="False"
                                                                        ErrorMessage="Center is a required Field" Display="Dynamic" ControlToValidate="ddl_center"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                    <asp:LinkButton ID="linkMultiCenter" runat="server" OnClick="linkMultiCenter_Click">Select Multiple Center(s)</asp:LinkButton>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="tr2" runat="server">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td valign="top">
                                                                    <uc1:UserInformationGrid ID="UIGridCenter" runat="server" />
                                                                    <asp:CheckBoxList ID="lstCenter" runat="server" Visible="false">
                                                                    </asp:CheckBoxList>
                                                                    <asp:LinkButton ID="lbCenterAdd" runat="server" OnClick="lbCenterAdd_Click" Visible="False">Add</asp:LinkButton>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="trClass" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory40">
                                                                    Class :
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
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>



                                                            <tr id="trResultMonth" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory40">
                                                                    Result Month:
                                                                </td>
                                                                <td valign="top">
                                                                        

                                                        <asp:DropDownList ID="ddlResultMonth" runat="server" CssClass="dropdownlist" Width="250px" OnSelectedIndexChanged="ddlResultMonth_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Width="167px" Enabled="False"
                                                            ErrorMessage="Result Month is a required Field" Display="Dynamic" ControlToValidate="ddlResultMonth"
                                                            InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>

                                                                </td>
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>
                                                                                                                                                                                 

                                                            <tr id="trClassLevel" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory40">
                                                                    Class Level:
                                                                </td>
                                                                <td valign="top">
                                                                       <asp:DropDownList ID="ddlGradeLevel" runat="server" CssClass="dropdownlist" Width="250px" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Width="167px"
                                                            Enabled="False" ErrorMessage="Class Level is a required Field" Display="Dynamic"
                                                            ControlToValidate="ddlGradeLevel" InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                 
                                                                </td>
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>





                                                            <tr id="tr5" runat="server">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td valign="top">
                                                                    <uc1:UserInformationGrid ID="UIGridClass" runat="server" />
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="trSection" runat="server" visible="false">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabel40">
                                                                    Section :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="list_section" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="list_section_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>
                                                            <tr id="trEvaluationCriteria" runat="server" visible="false">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabel40">
                                                                    Evaluation Criteria Type :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="list_section_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>
                                                            <tr id="trteacher" runat="server" visible="false">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabel40">
                                                                    Teacher :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="List_ClassTeacher" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" >
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>
                                                            <tr id="trSubject" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabel40">
                                                                    Subject :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="list_Subject" runat="server" CssClass="dropdownlist" Width="250px">
                                                                    </asp:DropDownList>
                                                                    <asp:LinkButton ID="linkMultiSubject" runat="server" OnClick="linkMultiSubject_Click">Select Multiple Subject(s)</asp:LinkButton>
                                                                    <uc1:UserInformationGrid ID="UiGridSubject" runat="server" />
                                                                    <asp:CheckBoxList ID="lstSubject" runat="server" Visible="false">
                                                                    </asp:CheckBoxList>
                                                                    <asp:LinkButton ID="lbSubjectAdd" runat="server" OnClick="lbSubjectAdd_Click" Visible="False">Add</asp:LinkButton>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="tr3" runat="server">
                                                                <td>
                                                                </td>
                                                                <td valign="top">
                                                                    <br />
                                                                </td>
                                                            </tr>
                                                            <tr id="trStudent" runat="server" visible="false">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabel40">
                                                                    Student :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="list_student" runat="server" AppendDataBoundItems="True" CssClass="dropdownlist"
                                                                        Width="250px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>
                                                            <tr id="trFrmDate" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabel40">
                                                                    From Date :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:TextBox ID="txtFrmDate" runat="server" MaxLength="30" Width="180px"></asp:TextBox><cc1:CalendarExtender
                                                                        ID="CalendarExtender1" runat="server" TargetControlID="txtFrmDate">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>
                                                            <tr id="trToDate" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabel40">
                                                                    To Date :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:TextBox ID="txtToDate" runat="server" MaxLength="30" Width="180px"></asp:TextBox><cc1:CalendarExtender
                                                                        ID="CalendarExtender2" runat="server" TargetControlID="txtToDate">
                                                                    </cc1:CalendarExtender>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="trTerm" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory40">
                                                                    Term*:
                                                                </td>
                                                                <td align="left" style="height: 20px">
                                                                    <asp:DropDownList ID="ddlTerm" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                                        Width="250px" CssClass="dropdownlist">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:LinkButton ID="lnkMultiTerm" runat="server" OnClick="lnkMultiTerm_Click">Select Multiple Term(s)</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr6" runat="server">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td valign="top">
                                                                    <uc1:UserInformationGrid ID="UIGridTerm" runat="server" />
                                                                    <asp:CheckBoxList ID="lstTerm" runat="server" Visible="false">
                                                                    </asp:CheckBoxList>
                                                                    <asp:LinkButton ID="lbTermAdd" runat="server" OnClick="lbTermAdd_Click" Visible="False">Add</asp:LinkButton>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="trgrade" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabel40">
                                                                    Grade:
                                                                </td>
                                                                <td align="left" style="height: 20px">
                                                                    <asp:DropDownList ID="ddlGrade" runat="server" AppendDataBoundItems="True" CssClass="dropdownlist"
                                                                        Width="250px">
                                                                    </asp:DropDownList>
                                                                    <asp:LinkButton ID="lnkMultiGrade" runat="server" OnClick="lnkMultiGrade_Click">Select Multiple Grade(s)</asp:LinkButton>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr7" runat="server">
                                                                <td>
                                                                </td>
                                                                <td>
                                                                </td>
                                                                <td valign="top">
                                                                    <uc1:UserInformationGrid ID="UIGridGrade" runat="server" />
                                                                    <asp:CheckBoxList ID="lstGrade" runat="server" Visible="false">
                                                                    </asp:CheckBoxList>
                                                                    <asp:LinkButton ID="lbGradeAdd" runat="server" OnClick="lbGradeAdd_Click" Visible="False">Add</asp:LinkButton>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                               <tr id="trGender" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabel40">
                                                                    Gender:
                                                                </td>
                                                                <td align="left" style="height: 20px">
                                                                    <asp:DropDownList ID="ddlGender" runat="server" AppendDataBoundItems="True" CssClass="dropdownlist"
                                                                        Width="250px">
                                                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                                        <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                                                        <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <cc1:ModalPopupExtender ID="MPopEx" runat="server" TargetControlID="hiddenForPopUp"
                Enabled="false">
            </cc1:ModalPopupExtender>
            <asp:Button Style="display: none" ID="hiddenForPopUp" runat="server"></asp:Button>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
