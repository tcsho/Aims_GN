<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="ClassSectionWelcomeLetter.aspx.cs" Inherits="PresentationLayer_ClassSectionWelcomeLetter"
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
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Welcome Letter Acknowledgement"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 13px" class="leftlink" align="right" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 22px" class="titlesection" colspan="3">
                            <asp:Label ID="msg" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                Visible="False" Font-Overline="False" Class="formheading">Please Select Class</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 40%">
                                    </td>
                                    <td>
                                        &nbsp;
                                    </td>
                                    <td>
                                        <asp:Button ID="but_save" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click"
                                            Text="Save Welcome Acknowledgement" ValidationGroup="valSave" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:GridView ID="gvRegStudents" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%" OnPageIndexChanging="gvRegStudents_PageIndexChanging"
                                EmptyDataText="No Record Exists." OnRowDataBound="gvRegStudents_RowDataBound"
                                OnRowCommand="gvRegStudents_RowCommand" CssClass="table table-striped table-bordered table-hover">
                                <Columns>
                                    <asp:BoundField DataField="IsWelcomeLetter" SortExpression="IsWelcomeLetter" HeaderText="IsWelcomeLetter">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Id" SortExpression="Section_Id" HeaderText="Section_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Sr #">
                                        <ItemStyle Font-Size="14px" />
                                        <ItemTemplate>
                                           <center><%# Container.DataItemIndex + 1 %></center> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class ">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Print welcome Letter">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnPrintChallan" runat="server" ForeColor="#004999" OnClick="btnPrintLetter_Click"
                                                Style="text-align: center; font-weight: bold;" ToolTip="Print Challan" ImageUrl="~/images/print_icon.png"
                                                CommandArgument='<%# Eval("Class_Id") %>' CausesValidation="false" Visible="True">
                                            </asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="cb">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Toggle Check</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
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
                        <td valign="top" colspan="3">
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
