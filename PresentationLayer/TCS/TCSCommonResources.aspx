<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TCSCommonResources.aspx.cs" Inherits="PresentationLayer_TCS_TCSCommonResources"
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
                                            <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Upload General Resource"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                </tr>
                <tr style="height: 5px">
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table style="width: 100%;" cellpadding="0" cellspacing="0" border="0">
                            <tr>
                                <td colspan="2" style="width: 100%; text-align: center">
                                    <table cellpadding="0" cellspacing="0" width="100%">
                                        <tr style="width: 100%; text-align: center">
                                            <td align="left" style="width: 100%; text-align: right; height: 14px;">
                                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="false" 
                                                    OnClick="LinkButton1_Click2">Add Resource Category</asp:LinkButton>
                                            </td>
                                        </tr>
                                        <tr style="width: 100%; text-align: center">
                                            <td style="width: 100%; text-align: center">
                                                &nbsp;<asp:GridView ID="gvResCat" runat="server" AutoGenerateColumns="False" 
                                                    EmptyDataText="No Record Exists." SkinID="GridView" Width="100%">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="No.">
                                                            <ItemStyle Font-Size="X-Small" Width="10%" />
                                                            <ItemTemplate>
                                                                <%# Container.DataItemIndex + 1 %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="ResourceTitle" HeaderText="Common Resource">
                                                        <HeaderStyle HorizontalAlign="Left" />
                                                        <ItemStyle HorizontalAlign="Left" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Upload">
                                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnUpload" runat="server" 
                                                                    CommandArgument='<%# Eval("CMNResource_ID") %>' 
                                                                    CommandName='<%#Eval("ResourceTitle") %>' 
                                                                    ImageUrl="~/images/transfericon.gif" OnClick="btnUpload_Click" 
                                                                    ValidationGroup="s" />
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="50px" />
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="FolderPath" HeaderStyle-CssClass="hide" 
                                                            ItemStyle-CssClass="hide">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="Allow/Lock Access">
                                                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                                                            <ItemTemplate>
                                                                <asp:ImageButton ID="btnMngAccess" runat="server" 
                                                                    CommandArgument='<%# Eval("CMNResource_ID") %>' 
                                                                    ImageUrl="~/images/privacyicon.png" OnClick="btnMngAccess_Click" 
                                                                    ValidationGroup="s" />
                                                            </ItemTemplate>
                                                            <HeaderStyle Width="150px" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="tr1" />
                                                    <HeaderStyle CssClass="tableheader" />
                                                    <AlternatingRowStyle CssClass="tr2" />
                                                    <SelectedRowStyle BackColor="#FFE0C0" CssClass="tr_select" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr ID="detail1" runat="server" class="titlesection" visible="False">
                                            <td align="right" class="titlesection" colspan="13" style="height: 19px; text-align: left">
                                                Resource Category Detail
                                            </td>
                                        </tr>
                                        <tr ID="detail2" runat="server" style="width: 100%; text-align: center" 
                                            visible="False">
                                            <td style="width: 100%; text-align: center">
                                                <table cellpadding="0" cellspacing="0" width="100%">
                                                    <tr style="width: 100%">
                                                        <td style="width: 30%">
                                                            <asp:Label ID="lblMsg" runat="server" CssClass="txtErrorLabel" Text=""></asp:Label>
                                                        </td>
                                                        <td style="width: 70%">
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 5px; width: 100%">
                                                        <td style="height: 3px; width: 30%">
                                                        </td>
                                                        <td style="width: 70%">
                                                        </td>
                                                    </tr>
                                                    <tr style="width: 100%">
                                                        <td align="right" style="width: 30%">
                                                            Catagory Description&nbsp;
                                                        </td>
                                                        <td style="width: 70%; text-align: left">
                                                            <asp:TextBox ID="txtResName" runat="server" CssClass="textbox" MaxLength="50" 
                                                                Width="350px"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                                                ControlToValidate="txtResName" Display="Dynamic" 
                                                                ErrorMessage="Catagory name is required." ValidationGroup="s"></asp:RequiredFieldValidator>
                                                        </td>
                                                    </tr>
                                                    <tr style="height: 5px; width: 100%">
                                                        <td style="height: 3px; width: 30%">
                                                        </td>
                                                        <td style="width: 70%">
                                                        </td>
                                                    </tr>
                                                    <tr style="width: 100%; height: 3px">
                                                        <td style="width: 30%; height: 3px">
                                                        </td>
                                                        <td style="width: 70%; text-align: left; height: 3px;">
                                                            <asp:Button ID="btnAddRes" runat="server" CssClass="btn btn-primary" 
                                                                OnClick="btnAddRes_Click" Text="Save" ValidationGroup="s" Width="58px" />
                                                            &nbsp;
                                                            <asp:Button ID="Button2" runat="server" CssClass="btn btn-primary" 
                                                                OnClick="btnCancel_Click" Text="Cancel" Width="58px" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                    <tr style="width: 100%; text-align: center">
                                        <td colspan="2" style="width: 100%; text-align: center">
                                            &nbsp;
                                        </td>
                                    </tr>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr style="height: 3px">
                    <td>
                    </td>
                </tr>
                <tr style="height: 3px">
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr style="height: 5px">
                    <td>
                    </td>
                </tr>
                <tr>
                    <td>
<%--                        <gleamtech:filevistacontrol id="FileVistaControl" runat="server" style="width: 700px;
                            height: 600px" licensekey="" debug="false" fullscreen="false" uploadmethod="Flash"
                            visible="false">
                        </gleamtech:filevistacontrol>--%>
                    </td>
                </tr>
                <tr id="campusSection" runat="server" visible="false">
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td colspan="2" class="titlesection">
                                    Manage Access To Campuses
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table style="width: 100%" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="right">
                                               
                                            </td>
                                            <td style="width: 113px">
                                                <asp:DropDownList ID="ddlFilter" runat="server" 
                                                    OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged" Visible="False">
                                                    <asp:ListItem Value="1">Name</asp:ListItem>
                                                    <asp:ListItem Value="2">ID</asp:ListItem>
                                                </asp:DropDownList>
                                            </td>
                                            <td style="width: 143px">
                                                <asp:TextBox ID="txtFilter" runat="server" AutoPostBack="True" 
                                                    OnTextChanged="txtFilter_TextChanged" Visible="False"></asp:TextBox>
                                            </td>
                                            <td style="width: 58px">
                                                <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary" OnClick="btnFilter_Click"
                                                    CausesValidation="false" Visible="False" />
                                            </td>
                                            <td>
                                                <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click"
                                                    CausesValidation="false" Visible="False" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>

                             <tr style="width: 100%">
                                                    <td align="right" style="width: 50%">
                                                        Region:
                                                    </td>
                                                    <td style="width: 50%">
                                                        <asp:DropDownList ID="ddlRegion" runat="server" CssClass="dropdownlist" ValidationGroup="class"
                                                            OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" Width="200px" 
                                                            AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>


                            <tr style="height: 3px">
                                <td colspan="2">
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gvResDetail" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                        AllowPaging="True" PageSize="50" Width="100%" EmptyDataText="No Record Exists."
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
                                                        ToolTip="View this Record" CommandArgument='<%# Eval("CMNResDetail_ID") %>'></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
