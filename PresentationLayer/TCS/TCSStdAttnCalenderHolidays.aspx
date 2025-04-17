<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TCSStdAttnCalenderHolidays.aspx.cs" Inherits="PresentationLayer_TCS_TCSStdAttnCalenderHolidays" Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                        <td style="height: 100%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Campus Calendar Management"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tbody>
                                    <tr style="width: 100%">
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        </td>
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                            <asp:LinkButton ID="btnCompose" runat="server" CausesValidation="False" OnClick="btnCompose_Click">Add New</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" class="titlesection" colspan="2" style="height: 19px; text-align: left">
                                            Campus Holidays
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%" colspan="2">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center">
                                                <tr style="width: 100%">
                                                    <td align="right" style="height: 19px; text-align: right; width: 40%">
                                                        Year :
                                                    </td>
                                                    <td align="right" colspan="13" style="height: 19px; text-align: left; width: 60%">
                                                        <asp:DropDownList ID="ddlYears" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged"
                                                            Width="100px">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="13" style="height: 19px; text-align: left">
                                            <asp:GridView ID="gvAttnType" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" HorizontalAlign="Center" OnPageIndexChanging="gvAttnType_PageIndexChanging"
                                                PageSize="15" SkinID="GridView" Width="100%">
                                                <RowStyle CssClass="tr1" />
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Width="10px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="CallDate" HeaderText="Date" DataFormatString="{0:dd/MM/yyyy}"
                                                        HtmlEncode="False">
                                                        <HeaderStyle HorizontalAlign="Left" Width="50px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="50px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Remarks" HeaderText="Remarks">
                                                        <HeaderStyle HorizontalAlign="Left" Width="250px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="CalTypeDesc" HeaderText="Day Type">
                                                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Edit" runat="server" CommandArgument='<%# Eval("Call_ID") %>'
                                                                ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" ToolTip="Edit" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("Call_ID") %>'
                                                                ImageUrl="~/images/delete.gif" ToolTip="Delete" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px" HorizontalAlign="Center" />
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
                                            Add Holidays to Campus Calender
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <div style="margin: 0 auto">
                                            <table>
                                                <tr id="trOpt" runat="server" visible="false">
                                                    <td align="right"  style="text-align: center;width:50%">
                                                    </td>
                                                    <td align="right" style="height: 19px; text-align: left">
                                                        <asp:RadioButtonList ID="rblType" runat="server" OnSelectedIndexChanged="rblType_SelectedIndexChanged"
                                                            RepeatDirection="Horizontal" AutoPostBack="True">
                                                            <asp:ListItem Selected="True" Value="0">Single Day</asp:ListItem>
                                                            <asp:ListItem Value="1">Multiple Days</asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                </tr>
                                                <tr id="trDate" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;;width:50%">
                                                        From Date:*
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtDate" runat="server" ToolTip="Enter Date"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" TargetControlID="txtDate"
                                                            Enabled="True" Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator1" runat="server"
                                                            ControlToValidate="txtDate" Display="Dynamic" ErrorMessage="Enter Date" InitialValue="0"
                                                            ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="TrDate2" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:50%">
                                                        To Date:
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtDate2" runat="server" ToolTip="Enter Date"></asp:TextBox><cc1:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" TargetControlID="txtDate2" Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>
                                                    </td>
                                                </tr>
                                                <tr id="trDayType" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:50%">
                                                        Holiday Type:*
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        &nbsp;<asp:DropDownList ID="ddlDayType" runat="server" Width="209px" ToolTip="Select Holiday Type">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator2" runat="server"
                                                            ControlToValidate="ddlDayType" Display="Dynamic" ErrorMessage="Enter Day Type"
                                                            InitialValue="0" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr id="trCDTEnt" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:50%">
                                                        Remarks* :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left;">
                                                        <%--<input class="button" onclick="javaScript:history.go(-1);" type="button" value="Back" />--%>
                                                        &nbsp;<asp:TextBox ID="txtDescription" runat="server" Width="400px" Height="100px"
                                                            TextMode="MultiLine" ToolTip="Enter Remarks"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                </table>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr id="trGVOpt" runat="server" visible="false">
                                        <td align="right" colspan="13" style="height: 19px; text-align: right">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender1" runat="server" TargetControlID="txtDescription"
                                WatermarkText="Enter Description">
                            </cc1:TextBoxWatermarkExtender>
                        </td>
                    </tr>
                    <tr id="btns" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center;">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="lnkAddCal_Click"
                                ValidationGroup="a" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click"
                                Text="Cancel" />
                        </td>
                    </tr>
                    <tr id="Tr1" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center">
                        </td>
                    </tr>
                    <tr id="btnGen" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center">
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
