<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" 
CodeFile="StudentWelcomeLetterClasssSection.aspx.cs" Inherits="PresentationLayer_StudentWelcomeLetterClasssSection" 

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Welcome Letter"></asp:Label>
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
                                <td style="width:40%">
                                </td>
                                    <td>
                                        Class Section*:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdownlist" Width="250px"
                                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:Button ID="but_save" runat="server" CssClass="btn btn-primary" 
                                            OnClick="Button1_Click" Text="Generate Welcome Letters" 
                                            ValidationGroup="valSave" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:GridView ID="gvRegStudents" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%" OnPageIndexChanging="gvRegStudents_PageIndexChanging"
                                EmptyDataText="No Record Exists." 
                                OnRowDataBound="gvRegStudents_RowDataBound" 
                                onrowcommand="gvRegStudents_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="Student_Id" SortExpression="Student_Id" HeaderText="Result_Grade_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemStyle Font-Size="X-Small" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="StudentNameId" HeaderText="Student ">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="X-Small" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Gender" HeaderText="Gender">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="X-Small" />
                                    </asp:BoundField>
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
<%--                                    <asp:TemplateField HeaderText="Generate Letters">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnGenerateLetter" runat="server" ForeColor="#004999" OnClick="btnGenerateLetter_Click"
                                                Style="text-align: center; font-weight: bold;" ToolTip="Generate Welcome letter"
                                                ImageUrl="~/images/invoice.png" CommandArgument='<%# Eval("Student_Id") %>' CausesValidation="false"
                                                Visible="false"></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Print welcome Letter">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnPrintChallan" runat="server" ForeColor="#004999" OnClick="btnPrintLetter_Click"
                                                Style="text-align: center; font-weight: bold;" ToolTip="Print Challan" ImageUrl="~/images/print_icon.png"
                                                CommandArgument='<%# Eval("Class_Id") %>' CausesValidation="false" Visible="false">
                                            </asp:ImageButton>
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

