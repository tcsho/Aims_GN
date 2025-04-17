<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CenterClassTotalTermDays.aspx.cs" Inherits="PresentationLayer_CenterClassTotalTermDays" %>

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
                        <td>
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Center-Class Wise Total Term Days"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">

                                <tr id="trRegion" runat="server">

                                    <td class="TextLabelMandatory40" valign="top" align="right">Region*:
                                    </td>
                                    <td valign="top">
                                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="218px"
                                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <br />
                                    </td>
                                    <td valign="top" align="right"></td>
                                </tr>

                                <tr id="trCenter" runat="server">

                                    <td align="right" class="TextLabelMandatory40" valign="top">Center*:
                                    </td>
                                    <td valign="top">
                                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="218px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="right" valign="top"></td>
                                </tr>

                                <tr style="width: 100%">
                                    <td align="right" colspan="1" class="TextLabelMandatory40">Session*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" class="TextLabelMandatory40">Term Group*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_Term_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 40%;">&nbsp;
                                    </td>
                                    <td align="left" style="width: 60%">&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                        <asp:GridView ID="dv_details" runat="server" AllowPaging="True" AllowSorting="True"
                                            AutoGenerateColumns="False" HorizontalAlign="Center" OnRowDataBound="dv_details_RowDataBound"
                                            PageSize="500" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Font-Size="X-Small" Width="15px" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <ItemStyle Font-Size="14px" Width=" 5%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="CenterClassTermDayId"
                                                    HeaderText="CenterClassTermDayId">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Evaluation_Criteria_Type_Id"
                                                    HeaderText="Evaluation_Criteria_Type_Id">
                                                    <ItemStyle Width="100px" Font-Size="14px" />
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Type" HeaderText="Term">
                                                    <ItemStyle Width="10%" Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Class_ID" HeaderText="Class_ID">
                                                    <ItemStyle Width="75px" />
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TotalTermDays" HeaderText="TotalTermDays">
                                                    <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Total Term Days" ItemStyle-Width="10%">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txttermdays" runat="server" Text='<%# Eval("TotalTermDays") %>' CssClass="textbox" AutoPostBack="true" OnTextChanged="txttermdays_TextChanged"/>
                                                        <asp:RegularExpressionValidator ID="regUnitsInStock" runat="server" ControlToValidate="txttermdays" ErrorMessage="Only numbers allowed" ForeColor="Red"
                                                            ValidationExpression="(^([0-9]*\d*\d{1}?\d*)$)" Display="Dynamic"></asp:RegularExpressionValidator>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Student(s) attended days exceeding from Total Term Days">
                                                    <ItemTemplate>
                                                        <asp:Label ID="stdIds" runat="server" ForeColor="Red" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%--<asp:TemplateField HeaderText="DaysAttend" Visible="true">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblDaysAttend" runat="server" ForeColor="Red" Font-Size="12px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>--%>
                                                <asp:BoundField DataField="DaysAttend" HeaderText="DaysAttend">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                            </Columns>
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <AlternatingRowStyle CssClass="tr2" BackColor="#EFEFF1" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr id="btns" runat="server" visible="false">
                                    <td colspan="3" style="height: 6px; text-align: center;">
                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="but_save_Click"
                                            ValidationGroup="a" Text="Save" />
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click"
                                            Text="Cancel" />
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr id="trButtons" runat="server" style="width: 100%" aliign="center">
                                    <td style="height: 19px; text-align: center" align="center">&nbsp;
                                    </td>
                                </tr>
                            </table>
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