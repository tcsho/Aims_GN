<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="TCSStdAttnCalenderDayType.aspx.cs" Inherits="PresentationLayer_TCS_TSSStdAttnCalenderDayType" 
Theme="BlueTheme"%>




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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Calendar Holidays Type"></asp:Label>
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
                                        <td align="right" colspan="12" style="height: 19px; text-align: left">
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="btnCompose" runat="server" CausesValidation="False" OnClick="btnCompose_Click">Add New</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">
                                            Holiday Types
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="13" style="height: 19px; text-align: left">
                                            <asp:GridView ID="gvCalDayType" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" HorizontalAlign="Center" OnPageIndexChanging="gvCalDayType_PageIndexChanging"
                                                PageSize="15" SkinID="GridView" Width="100%">
                                                <RowStyle CssClass="tr1" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CalTypeDesc" HeaderText="Description">
                                                        <HeaderStyle HorizontalAlign="left" />
                                                        <ItemStyle HorizontalAlign="left" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Edit" runat="server" CommandArgument='<%# Eval("CalDayType_Id") %>'
                                                                ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" ToolTip="Edit" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="75px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemStyle HorizontalAlign="Center" Width="75px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("CalDayType_Id") %>'
                                                                ImageUrl="~/images/delete.gif" ToolTip="Delete" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="75px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <SelectedRowStyle CssClass="tr_select" />
                                                <HeaderStyle CssClass="tableheader" />
                                                <AlternatingRowStyle CssClass="tr2" />
                                            </asp:GridView>
                                            <asp:Label ID="lblNoData" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trCDT" runat="server" visible="false">
                                        <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">
                                            Create Holiday Type
                                        </td>
                                    </tr>
                                    <tr id="trCDTEnt" runat="server" visible="false">
                                        <td align="right" colspan="1" style="height: 19px; text-align: right">
                                            Description* :
                                        </td>
                                        <td align="right" colspan="12" style="height: 19px; text-align: left;">
                                            <%--<input class="button" onclick="javaScript:history.go(-1);" type="button" value="Back" />--%>
                                            &nbsp;<asp:TextBox ID="txtDescription" runat="server" Width="200px" ToolTip="Enter Description"></asp:TextBox>
                                            <asp:RequiredFieldValidator ForColor=Red ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDescription"
                                                ErrorMessage="Enter Description" ValidationGroup="a" Display="Dynamic"></asp:RequiredFieldValidator><%--<asp:Menu ID="mnuWorkSite" runat="server" Orientation="Horizontal" >
                                    </asp:Menu>--%>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr id="btns" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center;">
                            &nbsp;<asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                Text="Save" ValidationGroup="a" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click"
                                Text="Cancel" />
                        </td>
                    </tr>
                </tbody>
            </table>







        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%" Width="100%" />

            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>



