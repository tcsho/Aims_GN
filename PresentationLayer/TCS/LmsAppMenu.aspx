<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LmsAppMenu.aspx.cs" Inherits="PresentationLayer_TSS_LmsAppMenu"
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
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="5">
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
                        <td style="height: 18px" class="leftlink" align="right" colspan="5">
                            <asp:LinkButton ID="but_new" OnClick="but_new_Click1" runat="server" CssClass="leftlink"
                                CausesValidation="False" Font-Bold="False">Add New Menu</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px" class="titlesection" colspan="5">
                            Existing Menues
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="5">
                            <asp:GridView ID="dv_country" runat="server" Width="100%" AutoGenerateColumns="False"
                                SkinID="GridView" HorizontalAlign="Center" OnPageIndexChanging="dv_country_PageIndexChanging"
                                OnRowDeleting="dv_country_RowDeleting" OnSorting="dv_country_Sorting" OnRowDataBound="dv_country_RowDataBound"
                                OnSelectedIndexChanging="dv_country_SelectedIndexChanging" AllowPaging="True"
                                AllowSorting="True" PageSize="50">
                                <Columns>
                                    <asp:BoundField DataField="Menu_Id" HeaderText="id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PageId" HeaderText="Pid">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PrntMenu_Id" HeaderText="Pmid">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="MenuText" HeaderText="MenuName" SortExpression="MenuText" />
                                    <asp:BoundField DataField="ParentMenuText" HeaderText="Parent Menu" SortExpression="ParentMenuText" />
                                    <asp:BoundField DataField="PageTitle" HeaderText="Page Title" SortExpression="PageTitle" />
                                    <asp:TemplateField ShowHeader="False" HeaderText="Edit/Delete">
                                        <EditItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="True" CommandName="Update"
                                                Text="Update" />
                                        </EditItemTemplate>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                                                ImageUrl="~/images/edit.png" Text="Edit" />
                                            &nbsp;
                                            <asp:ImageButton ID="ImageButton2" runat="server" CausesValidation="False" CommandName="Delete"
                                                ImageUrl="~/images/delete.png" Text="" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                                <SelectedRowStyle CssClass="tr_select" />
                            </asp:GridView>
                            <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="5">
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                <table cellspacing="0" cellpadding="1" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td class="titlesection" colspan="5">
                                                Add/Edit Menu
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="height: 10px" class="tr2">
                                            </td>
                                            <td style="height: 10px" class="tr2" align="right">
                                            </td>
                                            <td style="height: 10px" class="tr2">
                                                <asp:Label ID="error" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                                            </td>
                                            <td style="height: 10px" class="tr2">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 8px; height: 20px" class="tr1">
                                            </td>
                                            <td style="height: 20px" class="tr1" align="right">
                                                Menu Name*:
                                            </td>
                                            <td class="tr1">
                                                <asp:TextBox ID="txt_CName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator
                                                    ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_CName" ErrorMessage="Menu Name is Required Field."></asp:RequiredFieldValidator>
                                                <%-- <asp:RegularExpressionValidator
                                                        ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_CName"
                                                        ErrorMessage="Only letters are allowed in name field." Display="Dynamic" ValidationExpression="([A-Za-z\s])*"
                                                        SetFocusOnError="True"></asp:RegularExpressionValidator>--%>
                                            </td>
                                            <td style="height: 20px" class="tr1">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 8px; height: 18px;" class="tr2">
                                            </td>
                                            <td class="tr2" align="right" style="height: 18px">
                                                Parent Menu*:
                                            </td>
                                            <td class="tr2" style="height: 18px">
                                                <asp:DropDownList ID="ddlParentMenu" runat="server" CssClass="dropdownlist" Width="152px">
                                                </asp:DropDownList>
                                                <%--<asp:RequiredFieldValidator ForColor=Red ID="RequiredFieldValidator8" runat="server" ValidationGroup="s"
                                                            Display="Dynamic" ErrorMessage="Parent Menu is required" ControlToValidate="ddlParentMenu"
                                                            InitialValue="0"></asp:RequiredFieldValidator>--%>
                                                <td class="tr2" style="height: 18px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 8px; height: 18px;" class="tr1">
                                            </td>
                                            <td class="tr1" align="right" style="height: 18px">
                                                Page *:
                                            </td>
                                            <td class="tr1" style="height: 18px">
                                                <asp:DropDownList ID="ddlPage" runat="server" CssClass="dropdownlist" Width="152px">
                                                </asp:DropDownList>
                                                <asp:RequiredFieldValidator ForColor=Red ID="RequiredFieldValidator2" runat="server" ValidationGroup="s"
                                                    Display="Dynamic" ErrorMessage="Page is required" ControlToValidate="ddlPage"
                                                    InitialValue="0"></asp:RequiredFieldValidator>
                                                <td class="tr1" style="height: 18px">
                                                </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 8px">
                                            </td>
                                            <td align="right">
                                            </td>
                                            <td>
                                            </td>
                                            <td>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width: 8px" class="label">
                                            </td>
                                            <td class="label" align="center" colspan="2">
                                                <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                                    Text="Save"></asp:Button>
                                                &nbsp;
                                                <asp:Button ID="but_cancel" OnClick="but_cancel_Click" runat="server" CssClass="btn btn-primary"
                                                    CausesValidation="False" Text="Cancel"></asp:Button>
                                            </td>
                                            <td class="label">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
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
