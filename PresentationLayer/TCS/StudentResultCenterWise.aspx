<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentResultCenterWise.aspx.cs" Inherits="PresentationLayer_StudentResultCenterWise" %>

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Result - Center Wise"></asp:Label>
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
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" class="TextLabelMandatory40">Class Section*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1"
                                        class="TextLabelMandatory40">Term*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True"
                                            CssClass="dropdownlist" OnSelectedIndexChanged="list_Term_SelectedIndexChanged"
                                            Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1"
                                        class="TextLabelMandatory40">Session*:</td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True"
                                            CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1"
                                        class="TextLabelMandatory40">Student*:</td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_student" runat="server" AutoPostBack="True"
                                            CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_student_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%">&nbsp;</td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                        <asp:GridView ID="dv_details" runat="server" AllowPaging="True"
                                            AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center"
                                            OnRowDataBound="dv_details_RowDataBound" OnSorting="dv_details_Sorting"
                                            PageSize="500" Width="100%" CssClass="table table-striped table-bordered table-hover">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Font-Size="14px" Width="10%" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>

                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Session_Id" HeaderText="Session_Id" Visible="False">
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Subject_Name" HeaderText="Subject_Name">
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="MidYearMarks_CH" HeaderText="Mid Year %">
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Course_Work" HeaderText="Course Work %">
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Theory_Exam_CH" HeaderText="Exam %">
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="T" HeaderText="Average %">
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="G" HeaderText="Grade">
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Employee_Id" HeaderText="Employee_Id"
                                                    Visible="False">
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Section_Subject_Id"
                                                    HeaderText="Section_Subject_Id" Visible="False">
                                                    <ItemStyle Font-Size="14px" />
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
                                    <td style="width: 100%">&nbsp;</td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;</td>
                                </tr>
                                <tr id="trButtons" runat="server" style="width: 100%" aliign="center">
                                    <td style="height: 19px; text-align: center" align="center">&nbsp;</td>
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

