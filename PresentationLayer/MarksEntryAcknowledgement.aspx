<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="MarksEntryAcknowledgement.aspx.cs" Inherits="PresentationLayer_MarksEntryAcknowledgement"
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Marks Completion Acknowledgement"></asp:Label>
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
                                Visible="False" Font-Overline="False" Class="formheading"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: right">
                            <asp:Button ID="but_save" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click"
                                Text="Save Marks Acknowledgement" ValidationGroup="valSave" />
                            <asp:Button ID="btnRefresh" runat="server" CssClass="btn btn-success" OnClick="btnRefresh_Click"
                                Text="Refresh" ValidationGroup="valSave" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 750px" class="titlesection" colspan="7">
                            &nbsp;First Term
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:GridView ID="gvFirstTerm" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%" OnPageIndexChanging="gvFirstTerm_PageIndexChanging"
                                EmptyDataText="No Record Exists." OnRowDataBound="gvFirstTerm_RowDataBound" OnRowCommand="gvFirstTerm_RowCommand"
                                CssClass="table table-striped table-bordered table-hover">
                                <Columns>
                                    <asp:BoundField DataField="IsAckg" SortExpression="IsAckg" HeaderText="IsAckg">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Subject_Id" SortExpression="Section_Subject_Id"
                                        HeaderText="Section_Subject_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Evaluation_Criteria_Type_Id" SortExpression="Evaluation_Criteria_Type_Id"
                                        HeaderText="Evaluation_Criteria_Type_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemStyle Font-Size="14px" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject_AckStatus" HeaderText="Acknowledgement Status">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TSPG" HeaderText=" Required General Performance">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SPG" HeaderText="Entered General Performance">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalValue" HeaderText="Required Marks Enteries">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ActualValue" HeaderText="Student Enteries">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PercentComplete" HeaderText="Percent Complete">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status_Name" HeaderText="Status" Visible="True">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanTick" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_tick.png" Visible='<%# Convert.ToInt32(Eval("Status"))==1?true:false%>' />
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_Cross.png" Visible='<%# Convert.ToInt32(Eval("Status"))==2?true:false%>' />
                                            <asp:Image ID="Image2" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_noAnswer.png" Visible='<%# Convert.ToInt32(Eval("Status"))==3?true:false%>' />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="3%" />
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
                                    <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                                <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr style="height: 30px">
                        <td valign="top" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 750px" class="titlesection" colspan="7">
                            &nbsp;Second Term
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:GridView ID="gvSecondTerm" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%" OnPageIndexChanging="gvSecondTerm_PageIndexChanging"
                                EmptyDataText="No Record Exists." OnRowDataBound="gvSecondTerm_RowDataBound"
                                OnRowCommand="gvSecondTerm_RowCommand" CssClass="table table-striped table-bordered table-hover">
                                <Columns>
                                    <asp:BoundField DataField="IsAckg" SortExpression="IsAckg" HeaderText="IsAckg">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Subject_Id" SortExpression="Section_Subject_Id"
                                        HeaderText="Section_Subject_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Evaluation_Criteria_Type_Id" SortExpression="Evaluation_Criteria_Type_Id"
                                        HeaderText="Evaluation_Criteria_Type_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemStyle Font-Size="14px" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject_AckStatus" HeaderText="Acknowledgement Status">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TSPG" HeaderText=" Required General Performance">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SPG" HeaderText="Entered General Performance">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="TotalValue" HeaderText="Required Marks Enteries">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ActualValue" HeaderText="Student Enteries">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PercentComplete" HeaderText="Percent Complete">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Status_Name" HeaderText="Status" Visible="True">
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanTick" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_tick.png" Visible='<%# Convert.ToInt32(Eval("Status"))==1?true:false%>' />
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_Cross.png" Visible='<%# Convert.ToInt32(Eval("Status"))==2?true:false%>' />
                                            <asp:Image ID="Image2" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_noAnswer.png" Visible='<%# Convert.ToInt32(Eval("Status"))==3?true:false%>' />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="3%" />
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
                                    <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
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
