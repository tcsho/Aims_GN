<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Result_TermLetterOfUndertaking.aspx.cs" Inherits="PresentationLayer_TCS_Result_TermLetterOfUndertaking"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            
            
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
                                        <td style="height: 100%"  >
                                         <p style="  font-size: 18pt; color:red; background-color:white">
                                          <strong>Report View Instructions:</strong> Click  <a target="_blank" href="../../images/popup_unblock.png"  style="font-size: 18pt; color: red;">here <img src="../../images/Question.png"  /></a> and follow the steps "How to disable Pop-up blocker".
                                      <br /><strong>Note :</strong> Each report will open in a new page/tab.
                                      </p>  </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <%--     <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Reports"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />--%>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td align="right" colspan="12">
                                            <asp:Label ID="txtMsg" runat="server" ForeColor="White"></asp:Label>
                                            <asp:Button ID="btnViewReport" class="button" runat="server" Text="View Report" Width="96px"
                                                OnClick="btnViewReport_Click" ValidationGroup="s"/>
                                        </td>
                                    </tr>
                                    <tr id="crt" runat="server">
                                        <td>
                                            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                                <tr style="width: 100%">
                                                    <td class="titlesection" align="left" colspan="2">
                                                        Selection Criteria
                                                    </td>
                                                </tr>
                                                <tr style="width: 100%">
                                                    <td id="tdMsg" valign="top" style="border: solid 1px silver; width: 25%" runat="server">
                                                        &nbsp;
                                                    </td>
                                                    <td style="vertical-align: top">
                                                        <table>
                                                            <tr id="trMoId" runat="server">
                                                                <td style="width: 217px" valign="top" align="right">
                                                                    Main Organization* :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddl_MOrg" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        Enabled="False" OnSelectedIndexChanged="ddl_MOrg_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="rfv_mOrg" runat="server" Width="200px" Enabled="False"
                                                                        ErrorMessage="Mian Org is a required Field" Display="Dynamic" ControlToValidate="ddl_MOrg"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trCountry" runat="server">
                                                                <td align="right" style="width: 217px" valign="top">
                                                                    Main Organization Country* :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddl_country" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        OnSelectedIndexChanged="ddl_country_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfv_country" runat="server" Width="165px" Enabled="False"
                                                                        ErrorMessage="Country is a required Field" Display="Dynamic" ControlToValidate="ddl_country"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trRegion" runat="server">
                                                                <td style="width: 217px; height: 18px" valign="top" align="right">
                                                                    Region* :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="rfv_region" runat="server" Width="169px" Enabled="False"
                                                                        ErrorMessage="Region is a required Field" Display="Dynamic" ControlToValidate="ddl_region"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trCenter" runat="server">
                                                                <td align="right" style="width: 217px; height: 18px" valign="top">
                                                                    <asp:Label ID="lab_center" runat="server" Text="Center* : "></asp:Label>
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="rfv_center" runat="server" Width="167px" Enabled="False"
                                                                        ErrorMessage="Center is a required Field" Display="Dynamic" ControlToValidate="ddl_center"
                                                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trSession" runat="server">
                                                                <td align="right" style="width: 217px; height: 18px" valign="top">
                                                                    Session*:
                                                                </td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="ddlSession"
                                                                        Display="Dynamic" Enabled="False" ErrorMessage="Session is a required Field"
                                                                        InitialValue="0" ValidationGroup="s" Width="169px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trClass" runat="server">
                                                                <td style="width: 217px; height: 18px" valign="top" align="right">
                                                                    Class :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="True">
                                                                    </asp:DropDownList>
                                                                    <br />
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddl_center"
                                                                        Display="Dynamic" Enabled="False" ErrorMessage="Class required " InitialValue="0"
                                                                        Width="167px" ValidationGroup="s"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trSection" runat="server">
                                                                <td style="width: 217px; height: 18px" valign="top" align="right">
                                                                    Section :
                                                                </td>
                                                                <td valign="top" style="height: 18px">
                                                                    <asp:DropDownList ID="list_section" runat="server" CssClass="dropdownlist" Width="250px"
                                                                        AutoPostBack="True" OnSelectedIndexChanged="list_section_SelectedIndexChanged">
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" 
                                                                        ControlToValidate="list_section" Display="Dynamic" 
                                                                        ErrorMessage="Section is a required Field" InitialValue="0" ValidationGroup="s" 
                                                                        Width="169px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="trStudent" runat="server">
                                                                <td style="width: 217px; height: 18px" valign="top" align="right">
                                                                    Student :
                                                                </td>
                                                                <td valign="top">
                                                                    <asp:DropDownList ID="list_student" runat="server" AppendDataBoundItems="True" CssClass="dropdownlist"
                                                                        Width="250px">
                                                                    </asp:DropDownList>
                                                                </td>
                                                            </tr>
                                                            <tr id="trTerm" runat="server">
                                                                <td align="right" style="width: 40%; height: 20px;">
                                                                    Term*:
                                                                </td>
                                                                <td align="left" style="height: 20px">
                                                                    <asp:DropDownList ID="ddlTerm" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                                                        Width="250px" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged">
                                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                                    </asp:DropDownList>
                                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" 
                                                                        ControlToValidate="ddlTerm" Display="Dynamic" 
                                                                        ErrorMessage="Term is a required Field" InitialValue="0" ValidationGroup="s" 
                                                                        Width="169px"></asp:RequiredFieldValidator>
                                                                </td>
                                                            </tr>
                                                            <tr id="tr1" runat="server">
                                                                <td align="right" style="width: 40%; height: 20px;">
                                                                </td>
                                                                <td align="left" style="height: 20px">
                                                                    <asp:CheckBox ID="ChkSys" runat="server" Text="E-Result format" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr tr id="trShowUnderTakAck" runat="server">
                                        <td style="font-size: x-large; font-weight: bolder">
                                            Letter of undertaking issuance is pending for student(s) of selected Class-Section.
                                        </td>
                                    </tr>
                                    <tr tr id="trShowAckState" runat="server">
                                        <td style="font-size: x-large; font-weight: bolder">
                                            Result Card cannot be printed due to documents not issued.
                                        </td>
                                    </tr>
                                    <tr id="trShowAck" runat="server">
                                        <td>
                                            <asp:GridView ID="gvShowAck" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%" EmptyDataText="No Record Exists.">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="No.">
                                                        <ItemStyle Font-Size="X-Small" />
                                                        <ItemTemplate>
                                                            <%# Container.DataItemIndex + 1 %>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                                        <HeaderStyle ForeColor="White" />
                                                        <ItemStyle Font-Size="X-Small" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                                        <HeaderStyle ForeColor="White" />
                                                        <ItemStyle Font-Size="X-Small" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject">
                                                        <HeaderStyle ForeColor="White" />
                                                        <ItemStyle Font-Size="X-Small" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Subject_AckStatus" HeaderText="Acknowledgement Status">
                                                        <HeaderStyle ForeColor="White" />
                                                        <ItemStyle Font-Size="X-Small" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Scanned">
                                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                        <ItemTemplate>
                                                            <asp:Image ID="btnScanTick" runat="server" ForeColor="#004999" Style="text-align: center;
                                                                font-weight: bold;" ImageUrl="~/images/Scan_tick.png" Visible='<%# Convert.ToBoolean(Eval("isVerified"))==true?true:false%>' />
                                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center;
                                                                font-weight: bold;" ImageUrl="~/images/Scan_Cross.png" Visible='<%# Convert.ToBoolean(Eval("isVerified"))==false?true:false%>' />
                                                        </ItemTemplate>
                                                        <HeaderStyle HorizontalAlign="Center" />
                                                        <ItemStyle Wrap="False" Width="10%" />
                                                    </asp:TemplateField>
                                                    <asp:BoundField DataField="FullName" HeaderText="Teacher Id-Name">
                                                        <HeaderStyle ForeColor="White" />
                                                        <ItemStyle Font-Size="X-Small" />
                                                    </asp:BoundField>
                                                </Columns>
                                                <RowStyle CssClass="tr1" />
                                                <HeaderStyle CssClass="tableheader" />
                                                <AlternatingRowStyle CssClass="tr2" />
                                                <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <cc1:ModalPopupExtender ID="MPopEx" runat="server" TargetControlID="hiddenForPopUp"
                Enabled="false">
            </cc1:ModalPopupExtender>
            <asp:Button Style="display: none" ID="hiddenForPopUp" runat="server"></asp:Button>
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
