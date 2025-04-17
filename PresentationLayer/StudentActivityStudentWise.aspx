<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentActivityStudentWise.aspx.cs" Inherits="PresentationLayer_StudentActivityStudentWise"
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Activity Skills-Student Wise"></asp:Label>
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
                                        <td >
                                        </td>
                                        <td class="TextLabelMandatory" align="right" >
                                            Class Section*:
                                        </td>
                                        <td class="tr2" style="height: 18px; background-color: #FFFFFF;">
                                            <asp:DropDownList ID="list_ClassSection" runat="server" CssClass="dropdownlist" Width="200px"
                                                AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="list_ClassSection_SelectedIndexChanged1">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="list_ClassSection"
                                                Display="Dynamic" ErrorMessage="Select class section."></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="tr2" style="height: 18px">
                                        </td>
                                        <td class="TextLabelMandatory" align="right" style="height: 18px; ">
                                            Subject*:
                                        </td>
                                        <td class="tr2" style="height: 18px; background-color: #FFFFFF;">
                                            <asp:DropDownList ID="list_subject" runat="server" CssClass="dropdownlist" Width="200px"
                                                AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="list_subject_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="list_subject"
                                                Display="Dynamic" ErrorMessage="Select subject."></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="tr2" style="height: 18px; background-color: #FFFFFF;">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tr2">
                                        </td>
                                        <td class="TextLabelMandatory" align="right">
                                            Student*:
                                        </td>
                                        <td class="tr2">
                                            <asp:DropDownList ID="list_student" runat="server" CssClass="dropdownlist" Width="200px"
                                                AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="list_student_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="list_student"
                                                Display="Dynamic" ErrorMessage="Select Student"></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="tr2">
                                        </td>
                                        <td class="TextLabelMandatory" align="right">
                                            Term*:
                                        </td>
                                        <td class="tr2">
                                            <asp:DropDownList ID="list_term" runat="server" CssClass="dropdownlist" Width="200px"
                                                AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="list_term_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="list_term"
                                                Display="Dynamic" ErrorMessage="Select Term."></asp:RequiredFieldValidator>
                                        </td>
                                        <td class="tr2">
                                            <asp:LinkButton ID="lb_getAvailableSubs" OnClick="lb_getAvailableSubs_Click" runat="server"
                                                Visible="false">Retrieve</asp:LinkButton>
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
                        <td style="height: 22px; background-color: #FFFFFF;" class="titlesection" colspan="3">
                            <asp:Label ID="msg" class="formheading" runat="server" Font-Bold="True" ForeColor="White"
                                Font-Size="11px" Visible="False" Font-Overline="False">Please Enter Marks</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            &nbsp;<asp:Label ID="lab_status" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <table>
                        <tr>
                            <td align="left" style="width: 100%">
                                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                            </td>
                            <td align="left" style="width: 90%">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            
                                            <td style="height: 19px;padding-top:2%;" align="center" colspan="4">
                                                <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                                    Text="Save"></asp:Button>&nbsp;<asp:Button ID="but_cancel" OnClick="but_cancel_Click"
                                                        runat="server" CssClass="btn btn-primary" CausesValidation="False" Text="Cancel">
                                                </asp:Button>&nbsp;<asp:Button ID="but_Apply1" OnClick="but_Apply1_Click" runat="server"
                                                    CssClass="btn btn-primary" Text="Apply 1"></asp:Button>&nbsp;<asp:Button ID="but_Apply0" OnClick="but_Apply0_Click"
                                                        runat="server" CssClass="btn btn-primary" Text="Apply 0"></asp:Button>
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
