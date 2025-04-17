<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Section.aspx.cs" Inherits="PresentationLayer_Section"
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
                            
                        </td>
                    </tr>
                    <tr>
                        <td align="right" height="15">
                    </tr>
                    <tr>
                        <td class="titlesection">
                            Section Detail&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 182px" id="TD1" valign="top" runat="server">
                            <table cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
                                <tbody>
                                    
                                    <tr class="tr2">
                                        <td width="2%" height="25">
                                        </td>
                                        <td align="right" width="21%">
                                            Class* :
                                        </td>
                                        <td style="width: 159px">
                                            <asp:DropDownList ID="list_class" runat="server" CssClass="dropdownlist" ValidationGroup="Section"
                                                AutoPostBack="True" OnSelectedIndexChanged="list_class_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator3" runat="server"
                                                ValidationGroup="Section" SetFocusOnError="True" ErrorMessage="Class is a required field"
                                                Display="Dynamic" ControlToValidate="list_class"></asp:RequiredFieldValidator>
                                        </td>
                                        <td width="24%">
                                        </td>
                                        <td style="width: 159px">
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td width="2%" height="25">
                                        </td>
                                        
                                        <td style="width:100%;" colspan="3">
                                            <asp:GridView ID="gvSections" runat="server" Width="100%" DataKeyNames="Section_ID"
                                                EmptyDataText="No section exists." SkinID="GridView" AllowPaging="True" AutoGenerateColumns="False"
                                                Height="100%">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Sr.#">
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                        <ItemStyle Width="50px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Section_Name" HeaderText="Section Name"></asp:BoundField>
                                                      <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnDeleteSection" OnClientClick="return confirm('Are you sure?');" CommandName='<%#Eval("Class_Id") %>' CommandArgument='<%#Eval("Section_Id") %>' runat="server" OnClick="btnDeleteSection_Click">Delete</asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Section_ID">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle CssClass="tr1"></RowStyle>
                                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr class="tr1">
                                        <td width="2%" height="25">
                                            &nbsp;
                                        </td>
                                        <td align="right" width="21%">
                                            Section Name* :
                                        </td>
                                        <td style="width: 159px">
                                            <asp:TextBox ID="text_sectionName" runat="server" CssClass="textbox"
                                                MaxLength="1" ValidationGroup="Section"></asp:TextBox>&nbsp;<br />
                                            <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator1" runat="server"
                                                ValidationGroup="Section" SetFocusOnError="True" ForeColor="Red" ErrorMessage="Section name is a required field"
                                                Display="Dynamic" ControlToValidate="text_sectionName"></asp:RequiredFieldValidator><br />
                                            <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="text_sectionName"
                                                FilterType="UppercaseLetters">
                                            </cc1:FilteredTextBoxExtender>
                                        </td>
                                        <td style="color: #000000" width="24%">
                                            <asp:LinkButton ID="lb_checkAvailability" OnClick="lb_checkAvailability_Click" runat="server"
                                                ValidationGroup="Section">Check availability</asp:LinkButton>
                                        </td>
                                        <td style="width: 159px">
                                            <asp:Label ID="lab_availability" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td height="25">
                                            &nbsp;
                                        </td>
                                        <td align="right">
                                            Comments :
                                        </td>
                                        <td colspan="7">
                                            <label>
                                                <asp:TextBox ID="ta_comments" runat="server" CssClass="textarea" Width="100%" TextMode="MultiLine"></asp:TextBox>
                                            </label>
                                        </td>
                                    </tr>
                                    <tr class="tr1">
                                        <td style="height: 25px" align="center" colspan="5">
                                            &nbsp;
                                            <asp:Button ID="but_saveClass" OnClick="but_saveClass_Click" runat="server" CssClass="btn btn-primary"
                                                Text="Save" ValidationGroup="Section"></asp:Button>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <asp:Panel ID="pan_section" runat="server" Visible="false">
                        <tr />
                        <td class="titlesection" colspan="7" />
                        Assign New Subject(s)
                        <tr />
                        <td id="TD2" runat="server" colspan="7" valign="top" />
                        <table cellspacing="0" cellpadding="0" width="100%" bgcolor="#ffffff" border="0">
                            <tbody>
                                <tr class="tr1">
                                    <td style="height: 25px" width="2%">
                                    </td>
                                    <td width="21%">
                                        Subject List* :
                                    </td>
                                    <td>
                                        &nbsp;
                                        <asp:ListBox ID="listb_subjectList" runat="server" CssClass="dropdownlist" ValidationGroup="Subject"
                                            SelectionMode="Multiple"></asp:ListBox>
                                        <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator2" runat="server"
                                            ValidationGroup="Subject" SetFocusOnError="True" ErrorMessage="Subject is a required field"
                                            Display="Dynamic" ControlToValidate="listb_subjectList"></asp:RequiredFieldValidator>
                                    </td>
                                    <td width="24%">
                                    </td>
                                    <td>
                                    </td>
                                </tr>
                                <tr class="tr2">
                                    <td style="height: 25px">
                                    </td>
                                    <td>
                                    </td>
                                    <td style="width: 159px; height: 25px" align="right">
                                    </td>
                                    <td style="height: 25px">
                                    </td>
                                    <td style="width: 159px; height: 25px">
                                        &nbsp;
                                    </td>
                                </tr>
                            </tbody>
                        </table>
                        <tr />
                        <td style="height: 14px" colspan="7" valign="top" />
                        &nbsp;
                        <tr />
                        <td colspan="7" valign="top" />
                        <iframe src="SubjectOfSectionList.aspx" frameborder="0" width="625" scrolling="no"
                            height="220"></iframe>
                        <tr class="buttonsection" />
                        <td style="height: 22px" class="label" colspan="7" align="center" />
                        &nbsp;
                        <tr />
                        <td colspan="7" />
                        &nbsp;
                    </asp:Panel>
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
