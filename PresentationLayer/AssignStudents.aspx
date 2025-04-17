<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AssignStudents.aspx.cs" Inherits="PresentationLayer_AssignStudents"
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Assign / Un-Assign Students"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" >
                            <div style="padding-left: 120px;">
                                <br />
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tbody>
                                        <tr style="width:100%">
                                            <td class="TextLabelMandatory40">
                                            Main Organization*:
                                                &nbsp;</td>
                                            <td style="width:60%">
                                            <asp:DropDownList ID="ddl_MOrg" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        Enabled="False" OnSelectedIndexChanged="ddl_MOrg_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr> 
                                        <tr style="width:100%">
                                            <td class="TextLabelMandatory40">
                                            Main Organization Country*:
                                                &nbsp;</td>
                                            <td style="width:60%">
                                             <asp:DropDownList ID="ddl_country" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td class="TextLabelMandatory40">
                                                Region*:&nbsp;</td>
                                            <td style="width:60%"><asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td class="TextLabelMandatory40">
                                                Center*:&nbsp;</td>
                                            <td style="width:60%">
                                             <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                &nbsp;</td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td class="TextLabelMandatory40">
                                                Status*:
                                            </td>
                                            <td style="width:60%">
                                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" 
                                                    CssClass="dropdownlist" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" 
                                                    ValidationGroup="filter">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr >
                                            <td class="TextLabelMandatory40">
                                                Classes available*:
                                            </td>
                                            <td  style="width:60%">
                                                <asp:DropDownList ID="list_classFilter" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="list_classFilter_SelectedIndexChanged"
                                                    ValidationGroup="filter" AutoPostBack="True">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="width:100%">
                                            <td align="right" style="width:40%">
                                                <asp:Label ID="lbl_sectionFilter" runat="server" Text="Sections* :" Visible="false"></asp:Label>&nbsp;
                                            </td>
                                            <td style="width:60%">
                                                <asp:DropDownList ID="list_sectionFilter" runat="server" CssClass="dropdownlist"
                                                    ValidationGroup="filter" AutoPostBack="True" Visible="false" OnSelectedIndexChanged="list_sectionFilter_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" >
                        </td>
                    </tr>
                    <tr>
                        <td align="right" >
                            <asp:LinkButton ID="but_assignStudents" OnClick="but_assignStudents_Click" runat="server"
                                CausesValidation="False" Visible="False">Assign Selected Students</asp:LinkButton>&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td >
                            &nbsp;
                            <asp:GridView ID="dg_student" runat="server" Width="100%" DataKeyNames="Student_ID"
                                SkinID="GridView" AllowPaging="True" AutoGenerateColumns="False" Height="100%"
                                OnPageIndexChanging="dg_student_PageIndexChanging" OnRowCommand="dg_student_RowCommand"
                                PageSize="50">
                                <Columns>
                                    <asp:TemplateField HeaderText="#">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Student_No" HeaderText="Student No"></asp:BoundField>
                                    <asp:ButtonField HeaderText="Name" DataTextField="Name" CommandName="name"></asp:ButtonField>
                                    <asp:BoundField DataField="Country_Name" HeaderText="Country"></asp:BoundField>
                                    <asp:BoundField DataField="Region_Name" HeaderText="Region"></asp:BoundField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Center"></asp:BoundField>
                                    <asp:BoundField DataField="student_status" HeaderText="Status"></asp:BoundField>
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
                                    <asp:ButtonField Text="Modify" CommandName="modify" Visible="False"></asp:ButtonField>
                                </Columns>
                                <RowStyle CssClass="tr1"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>
                            <asp:Label ID="lab_dataStatus" runat="server" Visible="False" Text="No Data Exists."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:Panel ID="pan_availableClass" runat="server" Width="100%" Height="100%">
                                <table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td class="titlesection" >
                                                Available Subjects
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="TD1" valign="top"  runat="server">
                                                <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                                                    <tbody>
                                                        <tr class="tr1">
                                                            <td style="height: 24px">
                                                            </td>
                                                            <td style="height: 24px" align="right">
                                                                Classes available* :
                                                            </td>
                                                            <td style="width: 160px; height: 24px">
                                                                <asp:DropDownList ID="list_class" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="list_class_SelectedIndexChanged"
                                                                    AutoPostBack="True">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator1" runat="server"
                                                                    ValidationGroup="add" ControlToValidate="list_class" Display="Dynamic" ErrorMessage="Class is a required field."
                                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td style="height: 24px">
                                                            </td>
                                                            <td style="height: 24px">
                                                                <asp:LinkButton ID="link_unassign" OnClick="lb_assign_Click" runat="server" ValidationGroup="add">Unassign subjects</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr class="tr2">
                                                            <td height="25">
                                                            </td>
                                                            <td align="right">
                                                                Sections available* :
                                                            </td>
                                                            <td style="width: 160px">
                                                                <asp:DropDownList ID="list_section" runat="server" CssClass="dropdownlist">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator2" runat="server"
                                                                    ValidationGroup="add" ControlToValidate="list_section" Display="Dynamic" ErrorMessage="Section is a required field."
                                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lb_getAvailableSubs" OnClick="lb_getAvailableSubs_Click" runat="server"
                                                                    Visible="false" ValidationGroup="add">Retrieve subjects</asp:LinkButton>
                                                                <asp:LinkButton ID="btnAssignStudents" OnClick="btnAssignStudents_Click" runat="server"
                                                                    Visible="false" ValidationGroup="add">Assign Students</asp:LinkButton>
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lb_assign" OnClick="lb_assign_Click" runat="server" ValidationGroup="add"
                                                                    Visible="false" OnClientClick="javascript:return confirm('Student Marks would be delete, Are you sure to Un-Assign this subject?');">Assign subjects</asp:LinkButton>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td class="titlesection" colspan="5">
                                                                Subject
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td valign="top" colspan="5">
                                                                <table style="width: 100%; color: #333333; position: static; border-collapse: collapse"
                                                                    id="Table1" class="input" cellspacing="0" cellpadding="1" rules="all" width="100%"
                                                                    border="1">
                                                                    <tbody>
                                                                        <tr class="tr1" align="left">
                                                                            <td>
                                                                                &nbsp;
                                                                                <asp:GridView ID="dg_subject" runat="server" SkinID="GridView" Width="100%" DataKeyNames="is_assigned"
                                                                                    AutoGenerateColumns="False" Height="100%" OnRowDataBound="dg_subject_RowDataBound">
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="#">
                                                                                            <ItemTemplate>
                                                                                                <%# Container.DataItemIndex + 1 %>
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Subject_Code" HeaderText="Subject Code"></asp:BoundField>
                                                                                        <asp:ButtonField HeaderText="Subject Name" DataTextField="Subject_Name" CommandName="s">
                                                                                        </asp:ButtonField>
                                                                                        <asp:TemplateField HeaderText="Assign">
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                                            </ItemTemplate>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Section_Subject_Id" HeaderText="Section_Subject_Id">
                                                                                            <ItemStyle CssClass="hide" />
                                                                                            <HeaderStyle CssClass="hide" />
                                                                                        </asp:BoundField>
                                                                                    </Columns>
                                                                                    <RowStyle CssClass="tr1"></RowStyle>
                                                                                    <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                                                                    <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                                                                </asp:GridView>
                                                                            </td>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </tbody>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td valign="top" >
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
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
