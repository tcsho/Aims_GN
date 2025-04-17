<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ResultCalculationCenterWise.aspx.cs" Inherits="PresentationLayer_TCS_ResultCalculationCenterWise" 
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
                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_table"
                width="100%">
                <tbody>
                
                <tr>
                    <td colspan="5">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Result Calculation Center Wise"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                </tr>
               
                
               
         
                <tr id="campusSection" runat="server" visible="false">
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                         <tr style="width: 100%">
                                                    <td align="right" style="width: 40%">
                                                        Region:
                                                    </td>
                                                    <td style="width: 60%">
                                                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="dropdownlist" ValidationGroup="class"
                                                            OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" Width="200px" 
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                 <tr style="width: 100%">
                                                    <td align="right" style="width: 40%">
                                                        Session:
                                                    </td>
                                                    <td style="width: 60%">
                                                        <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" ValidationGroup="class"
                                                            Width="200px" 
                                                            AutoPostBack="True" 
                                                            onselectedindexchanged="ddlSession_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                 <tr style="width: 100%">
                                                    <td align="right" style="width: 40%">
                                                        Term Group:
                                                    </td>
                                                    <td style="width: 60%">
                                                        <asp:DropDownList ID="ddlTermGroup" runat="server" CssClass="dropdownlist" ValidationGroup="class"
                                                            Width="200px" 
                                                            AutoPostBack="True" 
                                                            onselectedindexchanged="ddlTermGroup_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                            <tr id="mainlable" runat="server">
                                <td colspan="2" class="titlesection">
                                    Manage Access To Campuses
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
      <table style="width: 100%" cellspacing="0" cellpadding="0">
                                               
                                            </table>
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvResDetail" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="True" PageSize="150" Width="100%" 
                                        EmptyDataText="No Record Exists." onrowcommand="gvResDetail_RowCommand"
                                       >
                                        <Columns>
                                           
                                            <%--                                    <asp:TemplateField HeaderText="Allow">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAllowAccess1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Region_Name" HeaderText="Region">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Center_Id" HeaderText="Campus Code">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                           
                                            <asp:BoundField DataField="Center_Name" HeaderText="Center Name" />
                                            <asp:TemplateField HeaderText="cb">
                                                <ItemStyle Font-Size="X-Small"></ItemStyle>
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                    <asp:CheckBox ID="chkAllowAccess" runat="server" 
                                                        Checked='<%# Convert.ToBoolean(Eval("isAllow")) %>' />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chkAllowAccess" runat="server" />
                                                </EditItemTemplate>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Allow</asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAllowAccess" runat="server" 
                                                        Checked='<%# Convert.ToBoolean(Eval("isAllow")) %>' />
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
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary"
                                        Width="150px" Text="Result Calculation" CausesValidation="false"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" Width="70px"
                                        OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </tbody>
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


