<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AssignStudentAOLevelSubjectWise.aspx.cs" Inherits="PresentationLayer_AssignStudentAOLevelSubjectWise" %>

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
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Assign Student A\O Level Subject Wise"></asp:Label>
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
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 40%;">
                                        Class:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="List_Class" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" 
                                            Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" 
                                        style="height: 18px; text-align: right; width: 40%;">
                                        Section:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Section" runat="server" AutoPostBack="True" 
                                            CssClass="dropdownlist" 
                                            Width="217px" onselectedindexchanged="list_Section_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" 
                                        style="height: 18px; text-align: right; width: 40%;">
                                        Subject:</td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Subject" runat="server" AutoPostBack="True" 
                                            CssClass="dropdownlist" Height="16px" 
                                             Width="218px" onselectedindexchanged="list_Subject_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                               
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%">
                                        &nbsp;</td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">
                                        &nbsp;
                                        <asp:GridView ID="dv_details" runat="server" AllowPaging="True" 
                                            AllowSorting="True" AutoGenerateColumns="False" HorizontalAlign="Center" 
                                            OnRowDataBound="dv_details_RowDataBound" OnSorting="dv_details_Sorting" 
                                            PageSize="500" SkinID="GridView" Width="100%" 
                                            onrowcommand="dv_details_RowCommand">
                                            <RowStyle CssClass="tr1" BackColor="White" />
                                            <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                    <ItemStyle Font-Size="X-Small" Width="10%" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                                <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" Visible="False"></asp:BoundField>
                                                <asp:BoundField DataField="Student_No" HeaderText="Student No" />
                                                <asp:BoundField DataField="name" HeaderText="Name"></asp:BoundField>
                                                
                                                <asp:BoundField DataField="Class_Name" HeaderText="Class Name" />
                                                <asp:BoundField DataField="Section_Name" HeaderText="Section Name" />
                                                <asp:BoundField DataField="Student_Status" HeaderText="Student_Status" >
                                                <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Section_Subject_Id" 
                                                        HeaderText="Section_Subject_Id" >
                                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                 <asp:TemplateField HeaderText="Status">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" Width="8%" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanTick" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_tick.png" Visible='<%# Convert.ToBoolean(Eval("ChkAssign"))==true?true:false%>' />
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_Cross.png" Visible='<%# Convert.ToBoolean(Eval("ChkAssign"))==false?true:false%>' />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="50px" />
                                    </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="cb">
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" CssClass="checkbox" />
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Assign</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="70px"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" AutoPostBack="True" 
                                                            oncheckedchanged="CheckBox1_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                 <asp:TemplateField HeaderText="cb">
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="CheckBox2" runat="server" />
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">UN-Assign</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="70px" CssClass="hide"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" CssClass="hide"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox2" runat="server" AutoPostBack="True" 
                                                            oncheckedchanged="CheckBox2_CheckedChanged" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <SelectedRowStyle CssClass="tr_select" />
                                <SelectedRowStyle CssClass="tr_select" />
                                <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                <AlternatingRowStyle CssClass="tr2" BackColor="#EFEFF1" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">
                                        &nbsp;</td>
                                </tr>
                                <tr id="btns" runat="server" visible="false">
                        <td colspan="3" style="height: 6px; text-align: center;">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="but_save_Click"
                                ValidationGroup="a" Text="Save" OnClientClick="javascript:return confirm(' Are you sure to Assign / Un-Assign these students?');"  />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" OnClick="btnCancel_Click"
                                Text="Cancel" />
                        </td>
                    </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">
                                        &nbsp;</td>
                                </tr>
                                <tr id="trButtons" runat="server" style="width: 100%" aliign="center">
                                    <td style="height: 19px; text-align: center" align="center">
                                        &nbsp;</td>
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

