<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PresentationLayer/MasterPage.master"
    CodeFile="AssignStudents_OALevel.aspx.cs" Inherits="PresentationLayer_TCS_AssignStudents_OALevel"
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
                        <td align="left">
                            <div style="padding-left: 120px;">
                                <br />
                                <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                    <tbody>
                                        <tr style="width: 100%">
                                            <td class="TextLabelMandatory40">
                                                Main Organization* : &nbsp;
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddl_MOrg" runat="server" CssClass="dropdownlist" Width="250px"
                                                    Enabled="False" OnSelectedIndexChanged="ddl_MOrg_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td class="TextLabelMandatory40">
                                                Main Organization Country* : &nbsp;
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddl_country" runat="server" CssClass="dropdownlist" Width="250px"
                                                    OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td class="TextLabelMandatory40">
                                                Region* :&nbsp;
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px"
                                                    OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td class="TextLabelMandatory40">
                                                Center* :&nbsp;
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                                    AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td class="TextLabelMandatory40">
                                                Status* :&nbsp;:&nbsp;
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="ddlStatus" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                                    OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" ValidationGroup="filter">
                                                </asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td class="TextLabelMandatory40">
                                                Classes available* :&nbsp;:&nbsp;
                                            </td>
                                            <td style="width: 60%">
                                                <asp:DropDownList ID="list_classFilter" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="list_classFilter_SelectedIndexChanged"
                                                    ValidationGroup="filter" AutoPostBack="True">
                                                </asp:DropDownList>
                                                &nbsp;
                                            </td>
                                        </tr>
                                        <tr style="width: 100%">
                                            <td align="right" style="width: 40%">
                                                <asp:Label ID="lbl_sectionFilter" runat="server" Text="Sections* :" Visible="false"></asp:Label>&nbsp;
                                            </td>
                                            <td style="width: 60%">
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
                        <td align="center">
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            <asp:Button ID="but_assignStudents" OnClick="but_assignStudents_Click" runat="server"
                                CausesValidation="False" Visible="False" CssClass="btn btn-primary" Text="Assign / Un-Assign Selected 
                            Students"></asp:Button>&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                            <asp:GridView ID="dg_student" runat="server" Width="100%" DataKeyNames="Student_ID"
                                SkinID="GridViewWOAlter" AllowPaging="True" AutoGenerateColumns="False" Height="100%" OnPageIndexChanging="dg_student_PageIndexChanging"
                                OnRowCommand="dg_student_RowCommand" PageSize="50" OnRowDataBound="dg_student_RowDataBound"
                                CssClass="table table-striped table-bordered table-hover"
                                >
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Font-Size="14px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Student_No" HeaderText="Student No"><ItemStyle Font-Size="14px" /> </asp:BoundField>
                                    <asp:BoundField DataField="Name" HeaderText="Name"><ItemStyle Font-Size="14px" /> </asp:BoundField>
                                    <asp:BoundField DataField="Country_Name" HeaderText="Country"><ItemStyle Font-Size="14px" /> </asp:BoundField>
                                    <asp:BoundField DataField="Region_Name" HeaderText="Region"><ItemStyle Font-Size="14px" /> </asp:BoundField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Center"><ItemStyle Font-Size="14px" /> </asp:BoundField>
                                    <asp:BoundField DataField="student_status" HeaderText="Status"><ItemStyle Font-Size="14px" /> </asp:BoundField>
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
                                    <asp:TemplateField HeaderText="Assign/Un-assing (student wise)">
                                        <ItemStyle HorizontalAlign="Center" Width="150px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnstdSub" runat="server" CausesValidation="false" CommandArgument='<%# Eval("Student_Id") %>'
                                                ImageUrl="~/images/edit.png" OnClick="btnPassChange_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="150px" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr2"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                               
                                
                                <SelectedRowStyle CssClass="tr_select" />
                            </asp:GridView>
                            <asp:Label ID="lab_dataStatus" runat="server" Visible="False" Text="No Data Exists."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pan_availableClass" runat="server" Width="100%" Height="100%">
                                <table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
                                    border="0">
                                    <tbody>
                                        <tr>
                                            <td class="titlesection">
                                                Available Subjects
                                            </td>
                                        </tr>
                                        <tr>
                                            <td id="TD1" valign="top" runat="server">
                                                <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                                                    <tbody>
                                                        <tr class="tr1">
                                                            <td style="height: 24px">
                                                            </td>
                                                            <td class="TextLabelMandatory40">
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
                                                                &nbsp;
                                                            </td>
                                                        </tr>
                                                        <tr class="tr2">
                                                            <td height="25">
                                                            </td>
                                                            <td class="TextLabelMandatory40">
                                                                Sections available* :
                                                            </td>
                                                            <td style="width: 160px">
                                                                <asp:DropDownList ID="list_section" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                                                    OnSelectedIndexChanged="list_section_SelectedIndexChanged">
                                                                </asp:DropDownList>
                                                                <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator2" runat="server"
                                                                    ValidationGroup="add" ControlToValidate="list_section" Display="Dynamic" ErrorMessage="Section is a required field."
                                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                                            </td>
                                                            <td>
                                                                &nbsp;
                                                            </td>
                                                            <td>
                                                                <asp:LinkButton ID="lb_assign" OnClick="lb_assign_Click" runat="server" ValidationGroup="add" CssClass="btn btn-primary"
                                                                    Visible="false" OnClientClick="javascript:return confirm('Student Marks would be delete, Are you sure to Un-Assign this subject?');">Assign/UnAssign 
                                                                Subjects</asp:LinkButton>
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
                                                                                    AutoGenerateColumns="False" Height="100%" OnRowDataBound="dg_subject_RowDataBound" CssClass="table table-striped table-bordered table-hover"
>
                                                                                    <Columns>
                                                                                        <asp:TemplateField HeaderText="#">
                                                                                            <ItemTemplate>
                                                                                                <%# Container.DataItemIndex + 1 %>
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="50px" Font-Size="14px"/>
                                                                                        </asp:TemplateField>
                                                                                        <asp:BoundField DataField="Subject_Code" HeaderText="Subject Code" >
                                                                                        <ItemStyle Width="100px"  Font-Size="14px"/>
                                                                                        </asp:BoundField>
                                                                                         <asp:TemplateField HeaderText="Assign">
                                                                                            <ItemTemplate>
                                                                                                <asp:CheckBox ID="CheckBox1" runat="server" />
                                                                                            </ItemTemplate>
                                                                                            <ItemStyle Width="50px"  Font-Size="14px"/>
                                                                                        </asp:TemplateField>

                                                                                        <asp:ButtonField HeaderText="Subject Name" DataTextField="Subject_Name" CommandName="s" >
                                                                                        </asp:ButtonField>
                                                                                       
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
                                            <td valign="top">
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
