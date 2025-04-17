<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentActivityActivityWise.aspx.cs" Inherits="PresentationLayer_StudentActivityActivityWise"
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Activity Skills-Activity Skill Wise"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="height: 3px" class="tr2">
                                        </td>
                                        <td style="height: 3px" class="tr2" align="right">
                                        </td>
                                        <td style="height: 5px" class="tr2">
                                        </td>
                                        <td style="height: 3px" class="tr2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tr2">
                                        </td>
                                        <td class="TextLabelMandatory" align="right">
                                            Class Section*:
                                        </td>
                                        <td class="tr2">
                                            <asp:DropDownList ID="list_ClassSection" runat="server" CssClass="dropdownlist" Width="200px"
                                                AutoPostBack="True" ValidationGroup="valSave" AppendDataBoundItems="True" OnSelectedIndexChanged="list_ClassSection_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="valSave"
                                                Display="Dynamic" ErrorMessage="Select class section." ControlToValidate="list_ClassSection"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="tr2">
                                        </td>
                                        <td class="TextLabelMandatory" align="right">
                                            Subject*:
                                        </td>
                                        <td class="tr2">
                                            <asp:DropDownList ID="list_subject" runat="server" CssClass="dropdownlist" Width="200px"
                                                AutoPostBack="True" ValidationGroup="valSave" AppendDataBoundItems="True" OnSelectedIndexChanged="list_subject_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ValidationGroup="valSave"
                                                Display="Dynamic" ErrorMessage="Select subject." ControlToValidate="list_subject"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="tr2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tr2">
                                        </td>
                                        <td class="TextLabelMandatory" align="right">
                                            Term*:
                                        </td>
                                        <td class="tr2">
                                            <asp:DropDownList ID="list_term" runat="server" CssClass="dropdownlist" Width="200px"
                                                AutoPostBack="True" ValidationGroup="valSave" AppendDataBoundItems="True" OnSelectedIndexChanged="list_term_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="valSave"
                                                Display="Dynamic" ErrorMessage="Select Activity" ControlToValidate="list_term"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="tr2">
                                        </td>
                                        <td class="tr2">
                                        </td>
                                        <td class="tr2">
                                        </td>
                                        <td class="tr2">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tr2">
                                        </td>
                                        <td class="TextLabelMandatory" align="right">
                                            Activity*:
                                        </td>
                                        <td class="tr2">
                                            <asp:DropDownList ID="list_activity" runat="server" CssClass="dropdownlist" Width="200px"
                                                AutoPostBack="True" ValidationGroup="valSave" AppendDataBoundItems="True" OnSelectedIndexChanged="list_activity_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="valSave"
                                                Display="Dynamic" ErrorMessage="Select Activity" ControlToValidate="list_activity"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="height: 20px" class="tr2">
                                        </td>
                                        <td style="height: 20px" class="TextLabelMandatory" align="right">
                                            Skill*:
                                        </td>
                                        <td class="tr2">
                                            <asp:DropDownList ID="list_skill" runat="server" CssClass="dropdownlist" Width="200px"
                                                AutoPostBack="True" ValidationGroup="valSave" AppendDataBoundItems="True" OnSelectedIndexChanged="list_skill_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="valSave"
                                                Display="Dynamic" ErrorMessage="Select evaluation criteria." ControlToValidate="list_skill"></asp:RequiredFieldValidator>
                                        </td>
                                        <td style="height: 20px" class="tr2">
                                            &nbsp;</td>
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
                                Visible="False" Font-Overline="False" Class="formheading">Marks Entry</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:GridView ID="gvClasses" runat="server" Width="100%" DataKeyNames="Student_Section_Subject_Id,Student_Activity_Skill_Id"
                                OnRowCommand="gvClasses_RowCommand" OnRowDataBound="gvClasses_RowDataBound" HorizontalAlign="Center"
                                AutoGenerateColumns="False" SkinID="GridView">
                                <Columns>
                                    <asp:BoundField DataField="mlock" HeaderText="mlock">
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Font-Size="14px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Student_No" HeaderText="Student No"><ItemStyle Font-Size="14px" /></asp:BoundField>
                                    <asp:BoundField DataField="Student_Name" HeaderText="Student Name"><ItemStyle Font-Size="14px" /></asp:BoundField>
                                    
<%--                                    
                                    
                                    <asp:TemplateField HeaderText="Student Name">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="LinkButton1" ToolTip="Click to view student detail" runat="server"
                                                CommandArgument='<%# Eval("Student_ID") %>' CommandName="cnStudent" Text='<%# Eval("Student_Name") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>



                                    <asp:BoundField DataField="Class_Section" HeaderText="Class Section"><ItemStyle Font-Size="14px" /></asp:BoundField>
                                    <asp:BoundField DataField="Student_Status" HeaderText="Student Status"><ItemStyle Font-Size="14px" /></asp:BoundField>
                                    <asp:TemplateField HeaderText="Marks">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txt_Marks" runat="server" Width="100px" ValidationGroup="valSave"
                                                Text='<%# Eval("marks") %>' MaxLength="6" ReadOnly='<%# Eval("mlock") %>' __designer:wfdid="w1"></asp:TextBox>
                                            <asp:RegularExpressionValidator ID="NRegEx" runat="server" ValidationGroup="valSave"
                                                Display="None" ErrorMessage="<b>Invalid Field</b><br />Please enter a valide decimal number.<br />"
                                                ControlToValidate="txt_Marks" ValidationExpression="\d*(.\d+)?" __designer:wfdid="w2"></asp:RegularExpressionValidator>&nbsp;
                                            <asp:RangeValidator ID="RanVd" runat="server" ValidationGroup="valSave" Display="None"
                                                ErrorMessage="Invalid entry" ControlToValidate="txt_Marks" MaximumValue="1" MinimumValue="-1"
                                                Type="Double" __designer:wfdid="w4"></asp:RangeValidator>&nbsp;
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle Cssclass="tr2"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>
                            <asp:Label ID="lab_dataStatus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="width: 8px" class="label">
                                            </td>
                                            <td style="padding-top:2%;" align="center" colspan="2">
                                                <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                                    ValidationGroup="valSave" Text="Save"></asp:Button>&nbsp;<asp:Button ID="but_cancel"
                                                        OnClick="but_cancel_Click" runat="server" CssClass="btn btn-primary" CausesValidation="False"
                                                        Text="Cancel"></asp:Button>
                                                &nbsp;<asp:Button ID="but_Apply1" runat="server" CssClass="btn btn-primary" 
                                                    OnClick="but_Apply1_Click" Text="Apply 1" />
                                                &nbsp;<asp:Button ID="but_Apply0" runat="server" CssClass="btn btn-primary" 
                                                    OnClick="but_Apply0_Click" Text="Apply 0" />
                                            </td>
                                            <td class="label">
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
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
