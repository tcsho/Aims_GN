<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="MessageSettings.aspx.cs" Inherits="PresentationLayer_MessageSettings" %>

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
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Define Message Settings"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">



                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1"></td>
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        <asp:LinkButton ID="but_new" OnClick="but_new_Click" runat="server" CssClass="leftlink"
                                            Font-Bold="False" ValidationGroup="btnNew">Add Message Settings</asp:LinkButton></td>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="left" style="width: 100%" colspan="2">
                            <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="left" style="width: 100%; text-align: center" colspan="2">
                            <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                Width="100%" OnSorting="gvSubjects_Sorting">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:BoundField DataField="Message_Id" SortExpression="Message_Id"
                                        HeaderText="Message_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                        <ItemStyle HorizontalAlign="Center" Width="5%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Description" HeaderText="Session">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Message"
                                        HeaderText="Message">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="FeeDefaultMessage"
                                        HeaderText="Fee Default Message">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server"
                                                CommandArgument='<%# Eval("Message_Id") %>' ForeColor="#004999"
                                                ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click"
                                                Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Delete">
                                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" 
                                                         CommandArgument='<%# Eval("AchvRating_Id") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/delete.gif" OnClick="btnDelete_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" onClientClick = "javascript:return confirm('Are you sure you want to Delete Records?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                </Columns>
                                <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                <RowStyle CssClass="tr1" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="trSave" runat="server" style="width: 100%">
                        <td style="height: 19px; text-align: center" align="right" colspan="2">&nbsp;</td>
                    </tr>
            </table>
            </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3" style="height: 247px">
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td id="titlesection" runat="server" style="height: 22px" class="titlesection">Add New Message Settings
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td style="height: 10px" class="tr2"></td>
                                                        <td style="width: 350px; height: 10px" class="tr2" valign="top" align="right"></td>
                                                        <td style="width: 510px; height: 10px" class="tr2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class=""></td>
                                                        <td style="width: 350px" class="" valign="top" align="right">Session:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="">
                                                            <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                                                Width="218px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" class="tr2"></td>
                                                        <td style="width: 350px; height: 10px" class="tr2" valign="top" align="right"></td>
                                                        <td style="width: 510px; height: 10px" class="tr2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class=""></td>
                                                        <td style="width: 350px" class="" valign="top" align="right">Message:
                                                        </td>
                                                        <td style="width: 510px; height: 15px" class="">
                                                            <asp:TextBox ID="txtMessage" runat="server" Width="800px" TextMode="MultiLine" Rows="5"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="height: 10px" class="tr2"></td>
                                                        <td style="width: 350px; height: 10px" class="tr2" valign="top" align="right"></td>
                                                        <td style="width: 510px; height: 10px" class="tr2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class=""></td>
                                                        <td style="width: 350px" class="" valign="top" align="right">Fee Default Message:
                                                        </td>
                                                        <td style="width: 510px; height: 15px" class="">
                                                            <asp:TextBox ID="txtFeeDefaultMessage" runat="server" TextMode="MultiLine"  Rows="5"
                                                                Width="800px" ></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr id="Prom1" runat="server">
                                                        <td style="width: 8px; height: 18px" class="tr2"></td>
                                                        <td style="width: 350px; height: 18px" class="tr2" valign="top" align="right">&nbsp;</td>
                                                        <td style="width: 510px; height: 18px" class="tr2">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px" class="tr2"></td>
                                                        <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right"></td>
                                                        <td style="width: 510px; height: 11px" class="tr2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td   style="width: 8px; height: 11px" class="tr2">&nbsp;</td>
                                                        <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right">
                                                            <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                                                Text="Save"></asp:Button>&nbsp;<asp:Button ID="but_cancel" OnClick="but_cancel_Click"
                                                                    runat="server" CssClass="btn btn-primary" CausesValidation="False" Text="Cancel"></asp:Button>&nbsp;&nbsp;
                                                        </td> 
                                                        <td style="width: 510px; height: 11px" class="tr2">&nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            &nbsp;
                        </td>
                    </tr>
            </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>