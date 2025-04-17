<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="WorkSiteToolAssignment.aspx.cs" Inherits="PresentationLayer_WorkSiteToolAssignment" %>

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Work Site Tool Assignment"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        Class Section :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        Work Site :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_WorkSite" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_WorkSite_SelectedIndexChanged" Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                       
                                    </td>
                                   <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        <asp:LinkButton ID="but_new" OnClick="but_new_Click" runat="server" CssClass="leftlink"
                       Font-Bold="False" ValidationGroup="btnNew">Assign Selected Work Site Tool</asp:LinkButton></td>
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
                                            OnRowDataBound="gvSubjects_RowDataBound" Width="100%" OnSorting="gvSubjects_Sorting"
                                            OnRowCommand="gvSubjects_RowCommand" 
                                            onselectedindexchanged="gvSubjects_SelectedIndexChanged" 
                                            onselectedindexchanging="gvSubjects_SelectedIndexChanging">
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:BoundField DataField="ProjectTool_ID" SortExpression="ProjectTool_ID" 
                                                    HeaderText="ProjectTool_ID">
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
                                                <asp:BoundField DataField="ProjectTool" HeaderText="Project Tool" >

                                                <HeaderStyle HorizontalAlign="Left" Width="45%" />
                                                <ItemStyle HorizontalAlign="Left" Width="45%" />
                                                </asp:BoundField>

                                                <asp:TemplateField HeaderText="Toggle Check">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chkRating" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Edit" Visible="False">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" 
                                                            CommandArgument='<%# Eval("ProjectTool_ID") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <RowStyle CssClass="tr1" />
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr id="trSave" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        &nbsp;</td>

                                </tr>
                                <tr>
                                <td>
                                &nbsp;
                                &nbsp;
                                </td>
                                </tr>
                                <tr>
                                <td style="height: 22px" class="titlesection" colspan="2">
                                               Assign Work Site Tool
                                            </td>
                                </tr>

                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%; text-align: center" colspan="2">
                                        <asp:GridView ID="gvAssign" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            OnRowDataBound="gvSubjects_RowDataBound" Width="100%" OnSorting="gvSubjects_Sorting"
                                            OnRowCommand="gvSubjects_RowCommand" 
                                            onselectedindexchanged="gvSubjects_SelectedIndexChanged" 
                                            onselectedindexchanging="gvSubjects_SelectedIndexChanging">
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:BoundField DataField="Section_Subject_Id" SortExpression="Section_Subject_Id" 
                                                    HeaderText="Section_Subject_Id">
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
                                                <asp:BoundField DataField="Title" HeaderText="Title" >

                                                <HeaderStyle HorizontalAlign="Left" Width="45%" />
                                                <ItemStyle HorizontalAlign="Left" Width="45%" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="ProjectTool" SortExpression="ProjectTool" 
                                                    HeaderText="Project Tool">
                                                    <HeaderStyle HorizontalAlign="Left"  />
                                                    <ItemStyle HorizontalAlign="Left"  />
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <RowStyle CssClass="tr1" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>

                    <tr>
                        <td valign="top" colspan="3" style="height: 247px">
                            
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
