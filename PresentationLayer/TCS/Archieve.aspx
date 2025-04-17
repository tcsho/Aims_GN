<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" 
CodeFile="Archieve.aspx.cs" Inherits="PresentationLayer_TCS_Archieve"
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


           <table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="5">
                            <table cellspacing="0" cellpadding="0" width="100%" background="<%= Page.ResolveUrl("~")%>images/new_img_center2b.gif"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td>
                                            <table style="background-repeat: no-repeat" cellspacing="0" cellpadding="0" width="80%"
                                                background="<%= Page.ResolveUrl("~")%>images/new_img_center2a.gif" border="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="height: 19px" width="2%">
                                                            &nbsp;</td>
                                                        <td class="formheading" width="98%">
                                                            Archive</td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                        </td>
                                        <td>
                                            &nbsp;</td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="height: 20px" valign="middle" align="center">
                           <table>
                                                            <tr id="trMoId" runat="server">
                                                                <td style="width: 217px" valign="top" align="right">
                                                                    Main Organization* :
                                                                </td>
                                                                <td valign="top" align="left">
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
                                                                <td align="right" style="width: 217px" valign="top">
                                                                    Main Organization Country* :
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:DropDownList ID="ddl_country" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfv_country" runat="server" Width="165px" Enabled="False"
                                                                        ErrorMessage="Country is a required Field" Display="Dynamic" ControlToValidate="ddl_country"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trRegion" runat="server">
                                                                <td style="width: 217px; height: 18px" valign="top" align="right">
                                                                    Region* :
                                                                </td>
                                                                <td valign="top" align="left">
                                                                    <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" 
                                                                        Width="250px">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="rfv_region" runat="server" Width="169px" Enabled="False"
                                                                        ErrorMessage="Region is a required Field" Display="Dynamic" ControlToValidate="ddl_region"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trSession" runat="server">
                                                                <td align="right" style="width: 217px; height: 18px" valign="top">
                                                                    Session*:
                                                                </td>
                                                                <td align="left">
                                                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlSession"
                                                                        Display="Dynamic" Enabled="False" ErrorMessage="Session is a required Field"
                                                                        InitialValue="0" ValidationGroup="s" Width="169px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trTerm" runat="server">
                                                                <td align="right" style="width: 40%; height: 20px;">
                                                                    Term*:
                                                                </td>
                                                                <td align="left" style="height: 20px">
                                                                    <asp:DropDownList ID="ddlTerm" runat="server" ValidationGroup="btnSaveValidation"
                                                                        Width="250px" CssClass="dropdownlist" AutoPostBack="True" onselectedindexchanged="ddlTerm_SelectedIndexChanged" 
                                                                        >
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
                    <tr>
                        <%--<td valign="middle" align="center">
                    Center:
                    <asp:DropDownList ID="list_center" runat="server" CssClass="dropdownlist" Width="180px">
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="list_center"
                                        Display="Dynamic" ErrorMessage="Center is a required field." InitialValue="0" ValidationGroup="valid"></asp:RequiredFieldValidator>
                </td>--%>
                        <td>
                            <asp:GridView ID="gvCenter" runat="server" Width="100%" 
                                AutoGenerateColumns="False" DataKeyNames="center_id" Height="100%" 
                                OnRowCreated="gvCenter_RowCreated" SkinID="GridView">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Center_Id" HeaderText="Center Code"></asp:BoundField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Centers"></asp:BoundField>
                                    <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                                    <asp:BoundField DataField="Counter" HeaderText="Reords"></asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="center_id">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle CssClass="hide" />
                                    </asp:BoundField>
                                </Columns>
                                <HeaderStyle CssClass="tableheader" />
                                <RowStyle CssClass="tr1" />
                                <AlternatingRowStyle CssClass="tr2" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" style="height: 20px">
                            <asp:Button ID="but_archive" OnClick="but_archive_Click" runat="server" CssClass="btn btn-primary"
                                ValidationGroup="valid" Text="Step 1 - Archive" Width="117px"></asp:Button>
                            &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Button ID="but_Promote" runat="server" CssClass="btn btn-primary" OnClick="but_Promote_Click"
                                Text="Step 2 - Promote" ValidationGroup="valid" Width="117px" />
                            &nbsp; &nbsp; &nbsp; &nbsp;
                            <asp:Button ID="btn_sendEmail" runat="server" CssClass="btn btn-primary" OnClick="btn_sendEmail_Click"
                                Text="Email Student Preformance" ValidationGroup="valid" Width="164px" />
                            &nbsp; &nbsp; &nbsp;&nbsp;
                            <asp:Button ID="btn_Parents" runat="server" CssClass="btn btn-primary" OnClick="btn_Parents_Click"
                                Text="Send Email to Parents" ValidationGroup="valid" Width="164px" /></td>
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


