<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="TCSGResources.aspx.cs" Inherits="PresentationLayer_TCS_TCSGResources" 
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
                    <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_table"
                width="100%">
                <tbody>
                
                <tr>
                    <td colspan="5">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Upload Academic Resource"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                </tr>
                <tr style="height: 5px">
                    <td colspan="5">
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                                <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                                    <tr>
                                        <%--2nd section--%>
                                        <td style="width: 100%" align="center">
                                            <table cellspacing="0" cellpadding="0" border="0">
                                                <tr style="height: 3px">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr visible="false">
                                                    <td align="right" visible="false">
                                                        &nbsp;</td>
                                                    <td visible="false">
                                                        <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" 
                                                            Width="180px">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Select Session"
                                                            Display="Dynamic" ControlToValidate="ddlSession" ValidationGroup="s" InitialValue="0">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr style="height: 3px">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        Class *&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdownlist" Width="180px"
                                                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Select Class"
                                                            Display="Dynamic" ControlToValidate="ddlClass" ValidationGroup="s" InitialValue="0">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr style="height: 3px">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td align="right">
                                                        Subject *&nbsp;
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlSubject" runat="server" CssClass="dropdownlist" Width="180px"
                                                            OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged" AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Select Subject"
                                                            Display="Dynamic" ControlToValidate="ddlSubject" ValidationGroup="s" InitialValue="0">
                                                        </asp:RequiredFieldValidator>
                                                    </td>
                                                </tr>
                                                <tr style="height: 3px">
                                                    <td colspan="2">
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr style="height: 3px">
                                        <td colspan="2">
                                        </td>
                                    </tr>
                                    <tr style="height: 3px">
                                        <td colspan="2">
                                            <asp:GridView ID="gvResCat" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                                Visible="false" Width="100%" EmptyDataText="No Record Exists.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemStyle Font-Size="X-Small" Width="10%" />
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Resource Catagory">
                                                        <ItemStyle Width="20%" />
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnResCat" runat="server" ForeColor="#004999" OnClick="btnResCat_Click"
                                                                Style="text-align: center; font-weight: normal;" Text='<%# Eval("GResourceCatDesc") %>  '
                                                                ToolTip="View this Record" CommandArgument='<%# Eval("GResourceCat_ID") %>'></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Resource Title">
                                                        <ItemStyle Width="50%" />
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtResTitle" TabIndex="1" runat="server" Width="500px" ValidationGroup="s"
                                                                MaxLength="500" Enabled="false"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="Resource Title is required"
                                                                Display="Dynamic" ControlToValidate="txtResTitle" ValidationGroup="s">
                                                            </asp:RequiredFieldValidator>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Add">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnAdd" runat="server" CommandArgument='<%# Eval("GResourceCat_ID") %>'
                                                                ImageUrl="~/images/add-icon.png" OnClick="btnAdd_Click" ValidationGroup="s" Visible='<%#Convert.ToBoolean(Eval("AlreadyNotExists")) %>'
                                                                Enabled='<%#!(Convert.ToBoolean(Eval("AlreadyExists"))) %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Upload">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnUpload" runat="server" CommandArgument='<%# Eval("GResourceCat_ID") %>'
                                                                ImageUrl="~/images/transfericon.gif" OnClick="btnUpload_Click"
                                                                ValidationGroup="s" Visible='<%#Convert.ToBoolean(Eval("AlreadyExists")) %>'
                                                                Enabled='<%#Convert.ToBoolean(Eval("AlreadyExists")) %>' CommandName='<%#Eval("GResourceCatDesc") %>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FolderPath" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                                    <asp:TemplateField HeaderText="Allow/Lock Access">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btnMngAccess" runat="server" CommandArgument='<%# Eval("GResource_ID") %>'
                                                                Visible='<%#Convert.ToBoolean(Eval("AlreadyExists")) %>' Enabled='<%#Convert.ToBoolean(Eval("AlreadyExists")) %>'
                                                                ImageUrl="~/images/privacyicon.png" OnClick="btnMngAccess_Click" ValidationGroup="s" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="tr1" />
                                                <HeaderStyle CssClass="tableheader" />
                                                <AlternatingRowStyle CssClass="tr2" />
                                                <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                    </td>
                </tr>
         
                <tr id="campusSection" runat="server" visible="false">
                    <td colspan="2">
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td colspan="2" class="titlesection">
                                    Manage Access To Campuses
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
      <table style="width: 100%" cellspacing="0" cellpadding="0">
                                                <tr style="width: 100%">
                                                    <td align="right" style="width: 50%">
                                                        Region:
                                                    </td>
                                                    <td style="width: 50%">
                                                        <asp:DropDownList ID="ddlProgram" runat="server" CssClass="dropdownlist" ValidationGroup="class"
                                                            OnSelectedIndexChanged="ddlProgram_SelectedIndexChanged" Width="200px" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                </td>
                            </tr>
                            <tr style="height: 3px">
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvResDetail" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="True" PageSize="150" Width="100%" EmptyDataText="No Record Exists."
                                        OnPageIndexChanging="gvResDetail_PageIndexChanging" OnRowCommand="gvResDetail_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="No.">
                                                <ItemStyle Font-Size="X-Small" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Region_Name" HeaderText="Region">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Center_String_Id" HeaderText="Campus Code">
                                                <HeaderStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Campus">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnCenter" runat="server" ForeColor="#004999" OnClientClick="javascript:return false;"
                                                        Style="text-align: center; font-weight: normal;" Text='<%# Eval("Center_Name") %>  '
                                                        ToolTip="View this Record" CommandArgument='<%# Eval("GResDetail_ID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--                                    <asp:TemplateField HeaderText="Allow">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:CheckBox ID="chkAllowAccess1" runat="server" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>--%>
                                            <asp:TemplateField HeaderText="cb">
                                                <EditItemTemplate>
                                                    <asp:CheckBox ID="chkAllowAccess" runat="server" />
                                                </EditItemTemplate>
                                                <HeaderTemplate>
                                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Allow</asp:LinkButton>
                                                </HeaderTemplate>
                                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkAllowAccess" runat="server" Checked='<%# Convert.ToBoolean(Eval("isAllow")) %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary"
                                        Width="58px" Text="Save" CausesValidation="false"></asp:Button>
                                    &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-primary" Text="Cancel" Width="58px"
                                        OnClick="btnCancel_Click" />
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            </tbody>
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


