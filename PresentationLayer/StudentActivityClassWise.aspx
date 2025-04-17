<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentActivityClassWise.aspx.cs" Inherits="PresentationLayer_StudentActivityClassWise"
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
                        <td>
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Activity Skills-Class Wise"></asp:Label>
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
                            <table cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td class="tr2" style="height: 3px">
                                    </td>
                                    <td align="right" class="tr2" style="height: 3px">
                                    </td>
                                    <td class="tr2" style="height: 5px">
                                    </td>
                                    <td class="tr2" style="height: 3px">
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                    </td>
                                    <td align="right" class="TextLabelMandatory">
                                        Class Section*:
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="list_ClassSection" runat="server" AppendDataBoundItems="True"
                                            AutoPostBack="True" CssClass="dropdownlist" OnSelectedIndexChanged="list_ClassSection_SelectedIndexChanged"
                                            ValidationGroup="valSave" Width="200px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="list_ClassSection"
                                            Display="Dynamic" ErrorMessage="Select class section." ValidationGroup="valSave"></asp:RequiredFieldValidator>
                                    </td>
                                    <td >
                                    </td>
                                    <td align="right" class="TextLabelMandatory">
                                        Subject*:
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="list_subject" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            CssClass="dropdownlist" OnSelectedIndexChanged="list_subject_SelectedIndexChanged"
                                            Width="200px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="list_subject"
                                            Display="Dynamic" ErrorMessage="Select subject." ValidationGroup="valSave"></asp:RequiredFieldValidator>
                                    </td>
                                    <td >
                                    </td>
                                </tr>
                                <tr>
                                    <td >
                                    </td>
                                    <td align="right" class="TextLabelMandatory">
                                        Term*:
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="list_term" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            CssClass="dropdownlist" OnSelectedIndexChanged="list_term_SelectedIndexChanged" Width="200px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="list_term"
                                            Display="Dynamic" ErrorMessage="Select term." ValidationGroup="valSave"></asp:RequiredFieldValidator>
                                    </td>
                                    <td >
                                    </td>
                                    <td align="right" class="TextLabelMandatory">
                                        Activity*:
                                    </td>
                                    <td >
                                        <asp:DropDownList ID="list_activity" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                            CssClass="dropdownlist" OnSelectedIndexChanged="list_activity_SelectedIndexChanged"
                                            ValidationGroup="valSave" Width="200px">
                                        </asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="list_activity"
                                            Display="Dynamic" ErrorMessage="Select Activity" ValidationGroup="valSave"></asp:RequiredFieldValidator>
                                    </td>
                                    <td >
                                        <asp:LinkButton ID="lb_getAvailableSubs" runat="server" OnClick="lb_getAvailableSubs_Click"
                                            ValidationGroup="valSave" Visible="false">Retrieve</asp:LinkButton>
                                    </td>
                                    <td class="tr2">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="leftlink" style="height: 13px; background-color: #FFFFFF;">
                        </td>
                    </tr>
                    <tr>
                        <td class="titlesection" style="height: 22px; background-color: #FFFFFF;">
                            <asp:Label ID="msg" runat="server" class="formheading" Font-Bold="True" Font-Overline="False"
                                Font-Size="11px" ForeColor="White" Visible="False">Please Enter Marks</asp:Label>
                        </td>
                    </tr>
                    <tr style="width:100%">
                        <td style="width:100%">
                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tr style="width:100%">
                                    <td align="left" style="width:100%">
                                        <asp:Label ID="lab_msg" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="width:100%">
                                    <td align="left">
                                        <asp:Label ID="lab_status" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="width:100%">
                                    <td align="left" style="height: 100%;">
                                        <div style="width:1224px;overflow:scroll;;float:left;">
                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr id="trButtons" runat="server" style="width:100%">
                        <td valign="top" style="text-align:center;" >
                           <asp:Button ID="but_save" runat="server" CssClass="btn btn-primary" OnClick="but_save_Click"
                                                Text="Save" ValidationGroup="valSave" />
                           <asp:Button ID="but_cancel" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                                OnClick="but_cancel_Click" Text="Cancel" />
                           <asp:Button ID="but_Apply1" runat="server" CssClass="btn btn-primary" OnClick="but_Apply1_Click"
                                                Text="Apply 1" />
                           <asp:Button ID="but_Apply0" runat="server" CssClass="btn btn-primary" OnClick="but_Apply0_Click"
                                                Text="Apply 0" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%" Width="100%" />

            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
