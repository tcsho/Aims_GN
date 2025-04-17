<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TCSGResourceDCTCatag.aspx.cs" Inherits="PresentationLayer_TCS_TCSGResourceDCTCatag"
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
                                            <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Academic Resource Category"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
            <table background="<%= Page.ResolveUrl("~")%>images/new_img_center2b.gif" border="0"
                cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td>
                        <table background="<%= Page.ResolveUrl("~")%>images/new_img_center2a.gif" border="0"
                            cellpadding="0" cellspacing="0" style="background-repeat: no-repeat" width="100%">
                            <tr>
                                <td style="height: 19px" width="1%">
                                    &nbsp;
                                </td>
                               <%-- <td id="wrkTitle" runat="server" class="formheading" style="height: 19px; "
                                    width="99%">
                                    &nbsp;</td>--%>
                            </tr>
                        </table>
                    </td>
                    <td>
                    </td>
                </tr>
            </table>
            <table style="width: 100%" cellspacing="0" cellpadding="0">
                <tr class="tr2">
                    <td style="width: 50px; text-align: right">
                    </td>
                    <td style="width: 15px; text-align: center">
                        <%--|--%>
                    </td>
                    <td style="width: 10%; text-align: left">
                    </td>
                    <td>
                    </td>
                    <td style="width: 10%">
                    </td>
                    <td style="width: 18px">
                        &nbsp;
                    </td>
                    <td align="right" style="display: none">
                        &nbsp;<img src="../../images/back_button_Caralog.png" style="position: relative;
                            top: 2px" />
                        <asp:LinkButton ID="lnkBtnBack" runat="server" OnClick="lnkBtnBack_Click">Back</asp:LinkButton>
                    </td>
                </tr>
            </table>
            <table cellpadding="0" cellspacing="0" width="100%">
                <tr style="width: 100%; text-align: center">
                    <td style="width: 100%; text-align: right; height: 14px;" align="left">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click2" CausesValidation="false">Add Resource Category</asp:LinkButton>
                    </td>
                </tr>
                <tr style="width: 100%; text-align: center">
                    <td style="width: 100%; text-align: center">
                        <asp:GridView ID="gvDCT" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True" PageSize="15" Width="100%" EmptyDataText="No Record Exists."
                            OnPageIndexChanging="gvDCT_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle Font-Size="X-Small" Width="5%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="70%" HorizontalAlign="Left" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnTitle" runat="server" ForeColor="#004999" OnClick="btnTitle_Click"
                                            Style="text-align: left; font-weight: normal;" Text='<%# Eval("GResourceCatDesc") %>  '
                                            ToolTip="View this Record" CommandArgument='<%# Eval("GResourceCat_ID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" ForeColor="#004999" OnClick="btnEdit_Click"
                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit this Record" ImageUrl="~/images/edit.gif"
                                            CommandArgument='<%# Eval("GResourceCat_ID") %>'></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnRemove" runat="server" ForeColor="#004999" OnClick="btnRemove_Click"
                                            Style="text-align: center; font-weight: bold;" ToolTip="Remove this Record" ImageUrl="~/images/delete.gif"
                                            CommandArgument='<%# Eval("GResourceCat_ID") %>' OnClientClick="javascript:return confirm('Are you sure to Delete this Record?');">
                                        </asp:ImageButton>&nbsp;
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="tr1" />
                            <HeaderStyle CssClass="tableheader" />
                            <AlternatingRowStyle CssClass="tr2" />
                            <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                        </asp:GridView>
                    </td>
                </tr>
                <tr class="titlesection" id="detail1" runat="server" visible="False">
                    <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">
                        Resource Category Detail
                    </td>
                </tr>
                <tr id="detail2" runat="server" style="width: 100%; text-align: center" visible="False">
                    <td style="width: 100%; text-align: center">
                        <table width="100%" cellpadding="0" cellspacing="0">
                            <tr style="width: 100%">
                                <td style="width: 30%">
                                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtErrorLabel"></asp:Label>
                                </td>
                                <td style="width: 70%">
                                </td>
                            </tr>
                            <tr style="height: 5px; width: 100%">
                                <td style="height: 3px; width: 30%">
                                </td>
                                <td style="width: 70%">
                                </td>
                            </tr>
                            <tr style="width: 100%">
                                <td style="width: 30%" align="right">
                                    Catagory Description&nbsp;
                                </td>
                                <td style="width: 70%; text-align: left">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox" MaxLength="50" 
                                        Width="350px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="s"
                                        Display="Dynamic" ErrorMessage="Catagory name is required." ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr style="height: 5px; width: 100%">
                                <td style="height: 3px; width: 30%">
                                </td>
                                <td style="width: 70%">
                                </td>
                            </tr>
                            <tr style="width: 100%; height: 3px">
                                <td style="width: 30%; height: 3px">
                                </td>
                                <td style="width: 70%; text-align: left">
                                    <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary"
                                        Width="58px" ValidationGroup="s" Text="Save"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" Width="58px"
                                        OnClick="btnCancel_Click" />
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
