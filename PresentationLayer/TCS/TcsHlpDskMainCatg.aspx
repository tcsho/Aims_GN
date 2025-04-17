<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="TcsHlpDskMainCatg.aspx.cs" Inherits="PresentationLayer_TCS_TcsHlpDskMainCatg"     Theme="BlueTheme" %>

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
                    <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tr>
                    <td colspan="5">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Help Desk Categories"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                   
                                <table width="100%" cellpadding="0" cellspacing="0">
                                    <tr style="width: 100%">
                                        <td colspan="2">
                                            <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtErrorLabel"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr style="height: 3px">
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right">
                                            Help Desk Name:*&nbsp;
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                            <asp:RequiredFieldValidator ForColor=Red ID="RequiredFieldValidator1" runat="server" ValidationGroup="s"
                                                Display="Dynamic" ErrorMessage="Help desk name is required." ControlToValidate="txtName"></asp:RequiredFieldValidator>
                                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary"
                                                Width="58px" ValidationGroup="s" Text="Save"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr style="height: 3px">
                                        <td colspan="2" style="height: 3px">
                                        </td>
                                    </tr>
                                </table>
                        
                    </td>
                </tr>
                <tr>
                    <td style="height: 22px" class="titlesection" colspan="5" runat="server" id="ContentDetailSection">
                        Available Types
                    </td>
                </tr>
                <tr style="height: 3px">
                    <td colspan="5">
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:GridView ID="gvDCT" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                            AllowSorting="True" AllowPaging="True" PageSize="15" Width="100%" EmptyDataText="No Record Exists."
                            OnPageIndexChanging="gvDCT_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="No.">
                                    <ItemStyle Font-Size="X-Small" Width="10%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Title">
                                    <ItemStyle Width="70%" />
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnTitle" runat="server" ForeColor="#004999" OnClick="btnTitle_Click"
                                            Style="text-align: center; font-weight: normal;" Text='<%# Eval("MCatDesc") %>  '
                                            ToolTip="View this Record" CommandArgument='<%# Eval("MCatg_ID") %>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEdit" runat="server" ForeColor="#004999" OnClick="btnEdit_Click"
                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit this Record" ImageUrl="~/images/edit.gif"
                                            CommandArgument='<%# Eval("MCatg_ID") %>'></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Remove">
                                    <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnRemove" runat="server" ForeColor="#004999" OnClick="btnRemove_Click"
                                            Style="text-align: center; font-weight: bold;" ToolTip="Remove this Record" ImageUrl="~/images/delete.gif"
                                            CommandArgument='<%# Eval("MCatg_ID") %>' OnClientClick="javascript:return confirm('Are you sure to Delete this Record?');">
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
                <tr>
                    <td colspan="5" align="center">
                        &nbsp;
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" Width="58px"
                            Visible="false" OnClick="btnCancel_Click" />
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



