<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="TcsArchiveReports.aspx.cs" Inherits="PresentationLayer_TCS_TcsArchiveReports" %>

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
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
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
                                            <asp:Button ID="btnViewReport" CssClass="btn btn-primary" runat="server" Text="View Report" Width="96px"
                                                OnClick="btnViewReport_Click" ValidationGroup="s" />
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
                                                    <td style="vertical-align: top;width: 70%;">
                                                        <table>
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
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="rfv_region" runat="server" Width="169px" Enabled="False"
                                                                        ErrorMessage="Region is a required Field" Display="Dynamic" ControlToValidate="ddl_region"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td valign="top" align="right">
                                                                </td>
                                                            </tr>

                                                            <tr id="trCenter" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory">
                                                                    Center*:
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfv_center" runat="server" Width="167px" Enabled="False"
                                                                        ErrorMessage="Center is a required Field" Display="Dynamic" ControlToValidate="ddl_center"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                            <tr id="trSession" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory">
                                                                    Session*:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" 
                                                                        Width="250px" onselectedindexchanged="ddlSession_SelectedIndexChanged" AutoPostBack ="true"
                                                                        >
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlSession"
                                                                        Display="Dynamic" Enabled="False" ErrorMessage="Session is a required Field"
                                                                        InitialValue="0" ValidationGroup="s" Width="169px"></asp:RequiredFieldValidator>
                                                                </td>
                                                                <td align="right" valign="top">
                                                                </td>
                                                            </tr>
                                                        
                                                           
                                                          
                                                            <tr id="trTerm" runat="server">
                                                                <td style="width: 12px; height: 18px">
                                                                </td>
                                                                <td class="TextLabelMandatory">
                                                                    Term*:
                                                                </td>
                                                                <td align="left" style="height: 20px">
                                                                    <asp:DropDownList ID="ddlTerm" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                                        Width="250px" CssClass="dropdownlist">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlTerm"
                                                                        Display="Dynamic" ErrorMessage="Select Term." Operator="NotEqual" SetFocusOnError="True"
                                                                        Type="Integer" ValueToCompare="0" Width="134px"></asp:CompareValidator>
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

