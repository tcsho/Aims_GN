<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LmsAppMenuServices.aspx.cs" Inherits="PresentationLayer_TSS_LmsAppMenuServices"
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
            <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_table"
                width="100%">
                <tr style="height: 10px">
                    <td>
                        <table cellspacing="0" cellpadding="0" width="100%" background="<%= Page.ResolveUrl("~")%>images/new_img_center2b.jpg"
                            border="0">
                            <tbody>
                                <tr>
                                    <td>
                                        <table style="background-repeat: no-repeat" cellspacing="0" cellpadding="0" width="100%"
                                            background="<%= Page.ResolveUrl("~")%>images/new_img_center2a3.jpg" border="0">
                                            <tbody>
                                                <tr>
                                                    <td style="height: 100%" width=".5%">
                                                        &nbsp;
                                                    </td>
                                                    <td id="tdFrmHeading" runat="server" style="height: 30px" class="formheading" width="98.5%">
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td class="titlesection" colspan="5">
                        Menues List
                    </td>
                </tr>
                <tr style="height: 5px">
                    <td colspan="5">
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        Select User Role:*<asp:DropDownList ID="list_groupName" runat="server" CssClass="dropdownlist"
                            Width="180px" OnSelectedIndexChanged="list_groupName_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr style="height: 5px">
                    <td colspan="5">
                    </td>
                </tr>
                <tr id="treeSection" runat="server" style="display: none">
                    <td colspan="5" style="width: 100%">
                        <table style="width: 100%" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <%--TreeView start--%>
                                    <%-- <ig:WebDataTree ID="wdtModules" runat="server" Height="100%" Width="100%" CheckBoxMode="BiState"
                            InitialExpandDepth="1" StyleSetName="Claymation" OnNodeClick="wdtModules_NodeClick"
                            SelectionType="Single" EnableAutoChecking="False">
                            <AutoPostBackFlags NodeClick="On" />
                            <NodeSettings SelectedCssClass="solidborder" />
                        </ig:WebDataTree>--%>
                                    <asp:TreeView ID="MenuTreeView" runat="server" ShowCheckBoxes="All">
                                    </asp:TreeView>
                                </td>
                            </tr>
                            <tr style="height: 5px">
                                <td colspan="5">
                                </td>
                            </tr>
                            <tr style="width: 100%">
                                <td align="center" style="width: 100%" colspan="5">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" Width="58px" ValidationGroup="s"
                                        Text="Save" OnClick="btnSave_Click"></asp:Button>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                        <%--treeview end--%>
                    </td>
                </tr>
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
