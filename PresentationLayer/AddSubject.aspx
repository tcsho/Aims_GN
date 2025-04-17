<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AddSubject.aspx.cs" Inherits="PresentationLayer_AddSubject" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>




<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <%--<asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />--%>
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--<asp:ScriptReference Path="../Scripts/jquery.timepicker.js" />
            <asp:ScriptReference Path="../Scripts/jquery.timepicker.css"/>--%>

            <%-- <link href="../Scripts/jquery.timepicker.css" rel="stylesheet" />
            <script type="text/javascript" src="../Scripts/jquery.timepicker.js"></script>
            --%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1A.js" />--%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1.js" />--%>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />


    <asp:UpdatePanel ID="UpdatePanel1" runat="server" OnPreRender="UpdatePanel1_PreRender">
        <ContentTemplate>
            <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_table"
                width="750">
                <tr>
                    <td colspan="7">
                        <table background="<%= Page.ResolveUrl("~")%>images/new_img_center2b.gif" border="0"
                            cellpadding="0" cellspacing="0" width="100%">
                            <tr>
                                <td>
                                    <table background="<%= Page.ResolveUrl("~")%>images/new_img_center2a.gif" border="0"
                                        cellpadding="0" cellspacing="0" style="background-repeat: no-repeat" width="80%">
                                        <tr>
                                            <td style="height: 14px" width="2%">&nbsp;</td>
                                            <td class="formheading" height="18" width="98%">Subject Deletion</td>
                                        </tr>
                                    </table>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="7">
                        <asp:Button ID="lnkAdd" runat="server" CausesValidation="False" OnClick="lnkAdd_Click"
                            OnPreRender="UpdatePanel1_PreRender" CssClass="btn btn-primary" Text="Add Subject"></asp:Button></td>
                </tr>
                 
                <tr>
                    <td colspan="7">&nbsp; &nbsp;&nbsp;
                        <asp:GridView ID="dg_subject" runat="server" AutoGenerateColumns="False"
                            Height="100%" OnRowCommand="dg_subject_RowCommand" PageSize="50" Width="100%"
                            SkinID="GridView">
                            <Columns>
                                <asp:TemplateField HeaderText="#">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Subject_Code" HeaderText="Subject Code" />
                                <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name" />
                                <%--<asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbtndelete" runat="server" OnClick="lbtndelete_Click" OnClientClick="return confirm('Are you sure?');"  CommandArgument='<%#Eval("Subject_Id") %>'>Delete</asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                            <RowStyle CssClass="tr1" />
                            <HeaderStyle CssClass="tableheader" />
                            <AlternatingRowStyle CssClass="tr2" />
                        </asp:GridView>
                        <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label></td>
                </tr>
                <tr id="SubDet1" runat="server" visible="false">
                    <td class="titlesection" colspan="5">Subject Detail&nbsp;</td>
                </tr>
                <tr id="SubDet2" runat="server" visible="false">
                    <td valign="top" colspan="5" runat="server">
                        <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                            <tbody>
                                <tr class="tr1">
                                    <td width="2%" height="25"></td>
                                    <td align="right" width="21%">Subject Name* :</td>
                                    <td style="width: 159px">
                                        <asp:TextBox ID="text_Subject" runat="server" CssClass="textbox" ValidationGroup="name"
                                            MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ForeColor="Red" runat="server" ValidationGroup="Subject"
                                            SetFocusOnError="True" ErrorMessage="Subject name is a required field." Display="Dynamic"
                                            ControlToValidate="text_Subject"></asp:RequiredFieldValidator>
                                        <span style="background-color: #f0f3f9"></span>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ForeColor="Red" runat="server" ValidationGroup="name"
                                            SetFocusOnError="True" ErrorMessage="Subject name is a required field." Display="Dynamic"
                                            ControlToValidate="text_Subject"></asp:RequiredFieldValidator></td>
                                    <td width="24%">
                                        <asp:LinkButton ID="lb_checkName" OnClick="lb_checkName_Click" runat="server" ValidationGroup="name">Check availability</asp:LinkButton></td>
                                    <td style="width: 159px; color: #000000">
                                        <asp:Label ID="lab_availability" runat="server"></asp:Label></td>
                                </tr>
                                <tr class="tr2">
                                    <td width="2%" height="25"></td>
                                    <td align="right" width="21%">Subject Code* :</td>
                                    <td style="width: 159px">
                                        <asp:TextBox ID="text_subjectCode" runat="server" CssClass="textbox" ValidationGroup="code"
                                            MaxLength="50"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="Subject"
                                            SetFocusOnError="True" ErrorMessage="Subject code is a required field." Display="Dynamic"
                                            ControlToValidate="text_subjectCode"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="code"
                                            SetFocusOnError="True" ErrorMessage="Subject code is a required field." Display="Dynamic"
                                            ControlToValidate="text_subjectCode"></asp:RequiredFieldValidator></td>
                                    <td width="24%">
                                        <asp:LinkButton ID="lb_checkCode" OnClick="lb_checkCode_Click" runat="server" ValidationGroup="code">Check availability</asp:LinkButton></td>
                                    <td style="width: 159px; color: #000000">
                                        <asp:Label ID="lab_codeAvailability" runat="server"></asp:Label></td>
                                </tr>
                                <tr class="tr1">
                                    <td width="2%" height="25"></td>
                                    <td align="right" width="21%">Active :</td>
                                    <td style="width: 159px">
                                        <asp:CheckBox ID="ch_active" runat="server"></asp:CheckBox></td>
                                    <td width="24%"></td>
                                    <td style="width: 159px"></td>
                                </tr>
                                <tr class="tr2">
                                    <td height="25">&nbsp;</td>
                                    <td align="right">Comments :</td>
                                    <td colspan="5">
                                        <label>
                                            <asp:TextBox ID="ta_comments" runat="server" CssClass="textarea" Width="400px" TextMode="MultiLine"></asp:TextBox>
                                        </label>
                                    </td>
                                </tr>
                                <tr class="tr1">
                                    <td width="2%"></td>
                                    <td width="21%"></td>
                                    <td align="right">&nbsp;
                                        <asp:Button ID="but_save" OnClick="but_saveClass_Click" runat="server" CssClass="btn btn-primary"
                                            ValidationGroup="Subject" Text="Save"></asp:Button></td>
                                    
                                    <td width="24%">
                                        <asp:Button ID="but_cancel" runat="server" CssClass="btn btn-primary" ValidationGroup="subject"
                                            Text="Cancel" OnClick="but_cancel_Click"></asp:Button>
                                    </td>
                                    <td></td>
                                </tr>
                            </tbody>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="7">
                        <cc1:ModalPopupExtender ID="MPopEx" runat="server" TargetControlID="hiddenForPopUp"
                            Enabled="false">
                        </cc1:ModalPopupExtender>
                        <asp:Button Style="display: none" ID="hiddenForPopUp" runat="server"></asp:Button>
                        <asp:Panel ID="msgBox" runat="server" Width="400" Visible="False">
                            <table cellspacing="0" cellpadding="0" width="400" border="0">
                                <tbody>
                                    <tr>
                                        <td style="background-repeat: no-repeat; height: 25px" valign="middle" background="../images/popup_top.png">
                                            <asp:Panel Style="cursor: move" ID="msgDrag" runat="server" Width="100%" Height="25px">
                                                <table style="width: 100%">
                                                    <tr>
                                                        <td style="height: 25px"></td>
                                                        <td style="height: 25px;" align="right">
                                                            <asp:Image Style="cursor: pointer;" ID="msgCross" runat="server" ImageUrl="~/images/btncross.jpg" />
                                                        </td>
                                                        <td style="height: 25px; width: 2px;"></td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-repeat: repeat-y" background="../images/popup_center.jpg">
                                            <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                <tbody>
                                                    <tr>
                                                        <td style="width: 1px; height: 14px"></td>
                                                        <td style="width: 10px; height: 14px"></td>
                                                        <td style="width: 5px; height: 14px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 10px"></td>
                                                        <td>
                                                            <asp:Label ID="msgNote" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="width: 10px"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 1px; height: 17px"></td>
                                                        <td style="width: 10px; height: 17px"></td>
                                                        <td style="width: 5px; height: 17px"></td>
                                                    </tr>
                                                </tbody>
                                            </table>
                                            <br />
                                        </td>
                                    </tr>
                                    

                                    <tr>
                                        <td style="background-repeat: repeat-y" align="right" background="../images/popup_center.jpg">
                                            <asp:Button ID="msgOK" runat="server" Width="75px" Text="OK"></asp:Button>
                                            <asp:Button ID="msgNo" runat="server" Width="75px" Text="No" Visible="False"></asp:Button>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <img height="4" src="../images/popup_bot.png" width="400" /></td>
                                    </tr>
                                </tbody>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
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
