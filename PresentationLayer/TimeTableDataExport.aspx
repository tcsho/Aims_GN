<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TimeTableDataExport.aspx.cs"
    Inherits="PresentationLayer_TimeTableDataExport"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="3600">
        <Scripts>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="font-size: x-large" colspan="2">Step 1: Select Region,Center,Academic Year and Class Range.
                            <br />
                            Step 2: Click on Export Data button.
                            <br />
                            Step 3: XML file will be downloaded, this file will be used to import in Time Table software.
                            <br />
                        </td>

                    </tr>
                    <tr>
                        <td>








                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" colspan="12">
                                            <asp:Button ID="btnViewReport" class="btn btn-primary" runat="server" Text="Export Data" Width="96px"
                                                OnClick="btnViewReport_Click" ValidationGroup="s" />

                                        </td>
                                    </tr>
                                    <tr id="crt" runat="server">
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                <tr style="width: 100%">
                                                    <td class="titlesection" align="left" colspan="2">Selection Criteria
                                                    </td>
                                                </tr>
                                                <tr style="width: 100%">

                                                    <td style="vertical-align: top; padding-left: 25%">
                                                        <table>
                                                            <tr id="trMoId" runat="server">
                                                                <td class="TextLabelMandatory40">Main Organization*:
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
                                                                <td class="TextLabelMandatory40">Main Organization Country*:
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
                                                                <td class="TextLabelMandatory40">Region*:
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
                                                            </tr>
                                                            <tr id="trCenter" runat="server">
                                                                <td class="TextLabelMandatory40">Center*: 
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfv_center" runat="server" Width="167px" Enabled="False"
                                                                        ErrorMessage="Center is a required Field" Display="Dynamic" ControlToValidate="ddl_center"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trSession" runat="server">
                                                                <td class="TextLabelMandatory40">Session*:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlSession"
                                                                        Display="Dynamic" Enabled="False" ErrorMessage="Session is a required Field"
                                                                        InitialValue="0" ValidationGroup="s" Width="169px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trClassFrom" runat="server">
                                                                <td class="TextLabelMandatory40">From Class*:
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddlClassFrom" runat="server" CssClass="dropdownlist" Width="250px">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlClassFrom"
                                                                        Display="Dynamic" Enabled="False" ErrorMessage="Class Range is required " InitialValue="0"
                                                                        Width="167px" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trClassTo" runat="server">
                                                                <td class="TextLabelMandatory40">To Class*:
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddlClassTo" runat="server" CssClass="dropdownlist" Width="250px">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlClassTo"
                                                                        Display="Dynamic" Enabled="False" ErrorMessage="Class Range is required " InitialValue="0"
                                                                        Width="167px" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>

                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>

                                    <tr>
                                        <td>
                                            <asp:GridView ID="gv_dataexport" runat="server" Width="100%" DataKeyNames="Id"
                                                SkinID="GridView" AllowPaging="True" AutoGenerateColumns="False" Height="100%"
                                                PageSize="50">
                                                <Columns>
                                                    <asp:BoundField DataField="vals" HeaderText="vals"></asp:BoundField>
                                                </Columns>
                                                <RowStyle CssClass="tr1"></RowStyle>
                                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                            </asp:GridView>

                                        </td>

                                    </tr>

                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>

        </ContentTemplate>

    </asp:UpdatePanel>

</asp:Content>


