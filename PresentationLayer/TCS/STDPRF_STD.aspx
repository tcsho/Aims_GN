<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="STDPRF_STD.aspx.cs" Inherits="PresentationLayer_TCS_STDPRF_STD"
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
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student's Performance Grading-All Subjects"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%">
                                <tbody>
                                    <tr>
                                        <td style="height: 5px; width: 45%;"></td>
                                        <td style="height: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px;" class="TextLabelMandatory40" align="right">Class Section*:
                                        </td>
                                        <td style="height: 18px">
                                            <asp:DropDownList ID="list_ClassSection" runat="server" CssClass="dropdownlist" Width="200px"
                                                OnSelectedIndexChanged="list_ClassSection_SelectedIndexChanged1" AutoPostBack="True"
                                                AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Select class section."
                                                Display="Dynamic" ControlToValidate="list_ClassSection"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px; width: 45%;"></td>
                                        <td style="height: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td style="height: 18px;" class="TextLabelMandatory40" align="right">Term*:
                                        </td>
                                        <td style="height: 18px">
                                            <asp:DropDownList ID="list_term" runat="server" CssClass="dropdownlist" Width="200px"
                                                AppendDataBoundItems="True"
                                                OnSelectedIndexChanged="list_term_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="Select Term."
                                                Display="Dynamic" ControlToValidate="list_term"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 5px; width: 35%;"></td>
                                        <td style="height: 5px"></td>
                                    </tr>
                                    <tr>
                                        <td class="TextLabelMandatory40" align="right">Student*:
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="list_student" runat="server" CssClass="dropdownlist" Width="200px"
                                                OnSelectedIndexChanged="list_student_SelectedIndexChanged" AutoPostBack="True"
                                                AppendDataBoundItems="True">
                                            </asp:DropDownList>
                                            &nbsp;
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="Select Student"
                                                Display="Dynamic" ControlToValidate="list_student"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                    </tr>
                    <tr>
                        <td style="height: 13px" class="leftlink" align="right" colspan="3">&nbsp;<asp:TextBox ID="txtcount" runat="server" AutoPostBack="True" OnTextChanged="txtcount_TextChanged"
                            Visible="False"></asp:TextBox>
                            &nbsp;<asp:LinkButton ID="lbAssingAll" OnClick="lbAssingAll_Click" runat="server">Copy to All</asp:LinkButton>&nbsp;
                            <asp:DropDownList ID="ddlARate" runat="server" CssClass="dropdownlist" Width="200px" AppendDataBoundItems="True">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: auto" valign="top" colspan="12">
                            <asp:GridView ID="dv_details" runat="server" OnSorting="dv_details_Sorting" OnRowDataBound="dv_details_RowDataBound"
                                PageSize="500" AllowSorting="True" AllowPaging="True" HorizontalAlign="Center"
                                AutoGenerateColumns="False" SkinID="GridView" Width="100%">
                                <Columns>
                                    <asp:BoundField DataField="KindClassAchvRating_Id" HeaderText="KindClassAchvRating_Id">
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="SSSKIL_Id" HeaderText="SSSKIL_Id">
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="KndSubStd_Id" HeaderText="KndSubStd_Id">
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IsComment" HeaderText="IsComment">
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Subject_Id" HeaderText="Section_Subject_Id">
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="3%" HorizontalAlign="Center" Font-Size="14px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                        <HeaderStyle HorizontalAlign="Left" Width="28%" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Left" Width="28%" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ItemHeads" SortExpression="ItemHeads" HeaderText="Item Heads" Visible="false">
                                        <HeaderStyle HorizontalAlign="Left" Width="0%" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Left" Width="0%" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="PerformanceActivity" HeaderText="Performance Activity">
                                        <HeaderStyle HorizontalAlign="Left" Width="42%" Font-Size="14px" />
                                        <ItemStyle HorizontalAlign="Left" Width="42%" Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Achievement Rating">
                                        <ItemTemplate>
                                            <asp:DropDownList Width="90%" runat="server" ID="ddlAchRate"  CssClass="dropdownlist" >
                                            </asp:DropDownList>

                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Left" Width="20%" Font-Size="14px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Lock_Mark" HeaderText="Lock_Mark">
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                    </asp:BoundField>


                                    <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                        <ItemStyle CssClass="hide"></ItemStyle>
                                        <HeaderStyle CssClass="hide"></HeaderStyle>
                                    </asp:BoundField>

                                </Columns>
                            </asp:GridView>
                            <asp:Label ID="lab_dataStatus" runat="server" Visible="False" Text="No Data Exists."></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">&nbsp;<asp:Label ID="lab_status" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3" style="height: 247px">
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="height: 22px" class="titlesection">Additional Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td style="height: 10px" class="tr2"></td>
                                                        <td style="width: 350px; height: 10px" class="tr2" valign="top" align="right"></td>
                                                        <td style="width: 445px; height: 10px" class="tr2"></td>
                                                        <td style="height: 10px" class="tr2"></td>
                                                    </tr>
                                                    <tr id="trComment" runat="server">
                                                        <td style="width: 40%" valign="top" align="left" colspan="2">

                                                            <asp:Label ID="lblteacher" runat="server"></asp:Label>
                                                        </td>
                                                        <td style="width: 60%; height: 21px" colspan="2">
                                                            <asp:TextBox ID="txt_TeacherComments" runat="server" CssClass="textbox" Width="90%" 
                                                                Height="140px" TextMode="MultiLine" MaxLength="500"  Style="resize: none"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <%--                                                    <tr visible="false">
                                                        <td style="width: 8px; height: 18px" class="tr2">
                                                        </td>
                                                        <td style="width: 350px; height: 18px" class="tr2" valign="top" align="right">
                                                            Islamiat Remarks(maximum <strong>500</strong> characters with spaces):
                                                        </td>
                                                        <td style="width: 445px; height: 18px" class="tr2">
                                                            <asp:TextBox ID="txt_Islamiat" runat="server" CssClass="textbox" Width="80%" Height="50px"
                                                                TextMode="MultiLine" MaxLength="500" Style="resize: none"></asp:TextBox>
                                                        </td>
                                                        <td style="height: 18px" class="tr2">
                                                        </td>
                                                    </tr>
                                                    <tr visible="false">
                                                        <td style="width: 8px; height: 18px" class="tr2">
                                                        </td>
                                                        <td style="width: 350px; height: 18px" class="tr2" valign="top" align="right">
                                                            ICT Remarks(maximum <strong>500</strong> characters with spaces):
                                                        </td>
                                                        <td style="width: 445px; height: 18px" class="tr2">
                                                            <asp:TextBox ID="txt_ICT" runat="server" CssClass="textbox" Width="80%" Height="50px" disabled="disabled"
                                                                TextMode="MultiLine" MaxLength="500" Style="resize: none"></asp:TextBox>
                                                        </td>
                                                        <td style="height: 18px" class="tr2">
                                                        </td>
                                                    </tr>--%>
                                                    <tr>
                                                        <td class="tr2" style="width: 8px; height: 18px">&nbsp;
                                                        </td>
                                                        <%--<td align="right" class="tr2" style="width: 350px; height: 18px" valign="top">
                                                            Days Attend:
                                                        </td>
                                                        <td class="tr2" style="width: 445px; height: 18px">
                                                            <asp:TextBox ID="txt_DaysAttend" runat="server"></asp:TextBox>
                                                        </td>--%>
                                                        <td class="tr2" style="height: 18px">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr id="Prom1" runat="server">
                                                        <td style="width: 8px; height: 18px" class="tr2"></td>
                                                        <td style="width: 350px; height: 18px" class="tr2" valign="top" align="right">is Promoted:
                                                        </td>
                                                        <td style="width: 445px; height: 18px" class="tr2">&nbsp;<asp:RadioButtonList ID="chk_promoted" runat="server">
                                                              <asp:ListItem Value="False" Text="Not Promoted">
                                                            </asp:ListItem>
                                                            <asp:ListItem Value="True" Text="Promoted">
                                                            </asp:ListItem>
                                                        </asp:RadioButtonList>
                                                        </td>
                                                        <td style="height: 18px" class="tr2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px" class="tr2"></td>
                                                        <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right"></td>
                                                        <td style="width: 445px; height: 11px" class="tr2"></td>
                                                        <td style="height: 11px" class="tr2"></td>
                                                    </tr>
                                                    <tr>

                                                        <td style="height: 19px; width: 100%" align="center" colspan="4">
                                                            <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                                                Text="Save" Visible="True"></asp:Button>&nbsp;<asp:Button ID="but_cancel" OnClick="but_cancel_Click"
                                                                    runat="server" CssClass="btn btn-primary" CausesValidation="False" Text="Cancel"></asp:Button>&nbsp;&nbsp;
                                                        </td>

                                                    </tr>
                                                </table>
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
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100%" Width="100%" />

            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
