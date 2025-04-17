<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TCSHOCenterResources.aspx.cs" Inherits="PresentationLayer_TCS_TCSHOCenterResources"
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
            <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_table"
                width="100%">
                 <tbody>
                 

                <tr>
                    <td colspan="5">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" 
                                                Text="Campus Drop Box"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                </tr>
                <tr style="height: 5px">
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                </tr>
                
                
                <tr id="campusSection" runat="server" visible="false">
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td colspan="2" class="titlesection">
                                    Manage Access To Campuses
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="right">
                                               
                                            </td>
                                            <td style="width: 113px">
                                                &nbsp;</td>
                                            <td style="width: 143px">
                                                &nbsp;</td>
                                            <td style="width: 58px">
                                                &nbsp;</td>
                                            <td>
                                                &nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                            <tr id="trMoId" runat="server">
                                                                <td style="width: 217px" valign="top" align="right">
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
                                                                <td align="right" style="width: 217px" valign="top">
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


                             <tr style="width: 100%">
                                                    <td align="right" style="width: 50%">
                                                       <%-- Region:--%>
                                                    </td>
                                                    <td style="width: 50%">
                                                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="dropdownlist" ValidationGroup="class"
                                                            OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" Width="251px" 
                                                            AutoPostBack="True" Height="16px" Visible="False">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>


                            <tr style="height: 3px">
                                <td colspan="2">
                                </td>
                            </tr>

                             <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvRegionDpb" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="True" PageSize="50" Width="100%" EmptyDataText="No Record Exists."
                                        OnPageIndexChanging="gvResDetail_PageIndexChanging" 
                                        OnRowCommand="gvResDetail_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="No.">
                                                <HeaderStyle Width="50px" />
                                                <ItemStyle Font-Size="X-Small" Width="50px" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Region_Id" HeaderText="Region Id">
                                                <HeaderStyle HorizontalAlign="Left" Width="75px" />
                                                <ItemStyle Width="75px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Region_String_ID" HeaderText="ID">
                                                <HeaderStyle HorizontalAlign="Left" Width="75px" />
                                                <ItemStyle Width="75px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Region_Name" HeaderText="Region Name" />
                                            <asp:TemplateField HeaderText="Region">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnRegion" runat="server" ForeColor="#004999" OnClick="btnRegion_Click"
                                                        Style="text-align: center; font-weight: normal;" Text='<%# Eval("Region_Name") %>  '
                                                        ToolTip="View this Record" CommandArgument='<%# Eval("Region_Id") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                        </Columns>
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvResDetail" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="True" PageSize="50" Width="100%" EmptyDataText="No Record Exists."
                                        OnPageIndexChanging="gvResDetail_PageIndexChanging" 
                                        OnRowCommand="gvResDetail_RowCommand" Visible="False">
                                        <Columns>
                                            <asp:TemplateField HeaderText="No.">
                                                <ItemStyle Font-Size="X-Small" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Region_Name" HeaderText="Region">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Center_String_Id" HeaderText="Campus Code">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CenterFullName" HeaderText="Center Full Name" />
                                            <asp:TemplateField HeaderText="Campus">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnCenter" runat="server" ForeColor="#004999" OnClick="btnCenter_Click"
                                                        Style="text-align: center; font-weight: normal;" Text='<%# Eval("Center_Name") %>  '
                                                        ToolTip="View this Record" CommandArgument='<%# Eval("Center_Id") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                           
                                        </Columns>
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                                    </asp:GridView>
                                </td>
                            </tr>

                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary"
                                        Width="58px" Text="Save" CausesValidation="false" Visible="False"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" Width="58px"
                                        OnClick="btnCancel_Click" Visible="False" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </tbody>
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
