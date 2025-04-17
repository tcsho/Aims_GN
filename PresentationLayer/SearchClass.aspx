<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="SearchClass.aspx.cs" Inherits="PresentationLayer_SearchClass"
    Theme="BlueTheme" %>

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
            <table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="7">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Search Class"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">
                        </td>
                    </tr>
                    <tr>
                        <td class="titlesection" colspan="7">
                            Search Criteria
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="7">
                            <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                                <tbody>
                                    <tr class="tr2">
                                        <td width="2%" height="25">
                                            &nbsp;
                                        </td>
                                        <td class="TextLabel">
                                            Class Name :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:TextBox ID="text_className" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td class="TextLabel">
                                            Grade :
                                        </td>
                                        <td width="26%">
                                            <asp:DropDownList ID="list_grade" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                        <td style="text-align: right" align="right">
                                            <asp:Button ID="but_search" runat="server" CssClass="btn btn-primary" OnClick="but_search_Click"
                                                Text="Search" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="titlesection" colspan="7">
                            &nbsp;Search Result
                        </td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            &nbsp;
                            <asp:GridView ID="dg_class" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False"
                                Height="100%" PageSize="50" OnPageIndexChanging="dg_class_PageIndexChanging"
                                DataKeyNames="Class_Id" OnRowCommand="dg_class_RowCommand" SkinID="GridView" CssClass="table table-striped table-bordered table-hover">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Font-Size="14px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class Name"><ItemStyle Font-Size="14px" /> </asp:BoundField>
                                    <asp:BoundField DataField="status" HeaderText="Status"><ItemStyle Font-Size="14px" /> </asp:BoundField>
                                </Columns>
                                <RowStyle CssClass="tr1"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>
                            <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">
                            <asp:Button ID="but_search1" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                                Text="Search"></asp:Button>
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
