<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LmsNewsForStudent.aspx.cs" Inherits="PresentationLayer_TCS_LmsNewsForStudent" Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc2" %>
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student News"></asp:Label>
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
                                       <%-- <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        </td>--%>
                                        <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                            <asp:LinkButton ID="btnCompose" runat="server" CausesValidation="False" 
                                                OnClick="btnCompose_Click" Visible="False">Add New</asp:LinkButton>
                                        </td>
                                    </tr>
                                   
                                    <tr>
                                        <td style="width: 100%" colspan="2">
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center">
                                                <tr style="width: 100%">
                                                    <td align="right" style="height: 19px; text-align: right; width: 40%">
                                                       <%-- Work Site :--%>
                                                    </td>
                                                    <td align="right" colspan="13" style="height: 19px; text-align: right; width: 60%">
                                                        <asp:DropDownList ID="ddlWorkSite" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlYears_SelectedIndexChanged"
                                                            Width="200px" Visible="False">
                                                        </asp:DropDownList>
                                                        <img src="../../images/back_button_Caralog.png" style="position: relative;
                            top: 2px" />
                                                        <asp:LinkButton ID="lnkBtnBack" runat="server" OnClick="lnkBtnBack_Click">Back</asp:LinkButton>
                                                    </td>
                                                </tr>
                                                 <tr>
                                                    <td align="right" 
                                                        style="height: 19px; text-align: right; width: 40%; color: #0000FF; font-size: small;">
                                                          Work Site :
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                        <asp:Label ID="lblWorksitename" runat="server" Font-Size="Small" 
                                                            ForeColor="#0000CC"></asp:Label>
                                                    </td>
                                                </tr>
                                                 <tr>
                                        <td align="right" class="titlesection" colspan="2" style="height: 19px; text-align: left">
                                            Student News Information
                                        </td>
                                    </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="right" colspan="13" style="height: 19px; text-align: left">
                                            <asp:GridView ID="gvDetail" runat="server" AllowPaging="True" AllowSorting="True"
                                                AutoGenerateColumns="False" HorizontalAlign="Center" OnPageIndexChanging="gvDetail_PageIndexChanging"
                                                PageSize="15" SkinID="GridView" Width="100%" onsorting="gvDetail_Sorting">
                                                <RowStyle CssClass="tr1" />
                                                <Columns>
                                                    <asp:BoundField DataField="News_ID" HeaderText="News_ID" 
                                                        Visible="False">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Section_Subject_Id" HeaderText="Section_Subject_Id" 
                                                        Visible="False">
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="WrkTool_ID" HeaderText="WrkTool_ID" Visible="False"></asp:BoundField>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="NewsTitle" HeaderText="NewsTitle"
                                                        HtmlEncode="False">
                                                        <HeaderStyle HorizontalAlign="Left" Width="80px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="NewsDetail" HeaderText="NewsDetail">
                                                        <HeaderStyle HorizontalAlign="Left" Width="250px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="250px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="IsPublished" HeaderText="IsPublished">
                                                        <HeaderStyle Width="15px" />
                                                        <ItemStyle Width="15px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="StartDateTime" HeaderText="StartDateTime">
                                                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="EndDateTime" HeaderText="EndDateTime" >
                                                        <HeaderStyle Width="100px" HorizontalAlign="Left" />
                                                        <ItemStyle Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Show">
                                                        <ItemStyle HorizontalAlign="Center" Width="35px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Edit" runat="server" CommandArgument='<%# Eval("News_ID") %>'
                                                                ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" ToolTip="Show" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete" Visible="False">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("News_ID") %>'
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
                                            Student News
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 100%;">
                                            <div style="margin: 0 auto">
                                            <table>
                                                

                                                <tr id="trDate" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;;width:25%">
                                                        Start Date:*
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtDate" runat="server" ToolTip="Enter Date"></asp:TextBox>
                                                        <cc1:CalendarExtender ID="txtDate_CalendarExtender" runat="server" TargetControlID="txtDate"
                                                            Enabled="True" Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>
                                                       <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtDate" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr id="TrDate2" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        End Date:
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtDate2" runat="server" ToolTip="Enter Date"></asp:TextBox><cc1:CalendarExtender
                                                            ID="CalendarExtender2" runat="server" TargetControlID="txtDate2" Format="MM/dd/yyyy">
                                                        </cc1:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDate2" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>

                                                    </td>
                                                </tr>
                                                <tr id="trDayType" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        News Title :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:TextBox ID="txtTitle" runat="server" 
                                                                Width="159px"></asp:TextBox>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtTitle" ErrorMessage="Required field cannot be left blank."
                                Display="Dynamic" ForeColor = "Red">
                            </asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                                <tr id="trCDTEnt" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Description :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 300px; text-align: left;">
                                                        
                                                        &nbsp;<cc2:Editor ID="Editor1" runat="server" />
                                                    </td>
                                                </tr>
                                                <tr id="trchkbox" runat="server" visible="false">
                                                    <td align="right" style="text-align: right;width:25%">
                                                        Is Published :
                                                    </td>
                                                    <td align="right" colspan="12" style="height: 19px; text-align: left">
                                                        <asp:CheckBox ID="chPublised" runat="server" />
                                                    </td>
                                                    <td>
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
