<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CIE_Upload.aspx.cs" Inherits="PresentationLayer_TCS_CIE_Upload"
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
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label3" CssClass="lblFormHead" runat="server" Text="Upload CIE BroadSheets "></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
            <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
<%--                <tr style="width: 100%">
                    <td class="titlesection" align="left" colspan="2">
                        CIE Data Upload
                    </td>
                </tr>--%>
                <tr style="width: 100%">
                    <td style="vertical-align: top">
                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                            <tr id="trMoId" runat="server">
                                <td class="TextLabelMandatory40">
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
                                <td class="TextLabelMandatory40">
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
                            <tr id="trRegion" runat="server" >
                                <td class="TextLabelMandatory40">
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
                                <td class="TextLabelMandatory40" valign="top">
                                    Center* :
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                                        AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    
                                         PK #:<asp:TextBox ID="txtPKNo" CssClass="textbox" runat="server" ReadOnly="true"></asp:TextBox>
                                         <asp:RequiredFieldValidator ID="rfv_center" runat="server" Width="167px" Enabled="False"
                                        ErrorMessage="Center is a required Field" Display="Dynamic" ControlToValidate="ddl_center"
                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr id="tr2" >
                                <td class="TextLabelMandatory40" valign="top">
                                    Academic Year* :
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="250px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="167px" Enabled="False"
                                        ErrorMessage="Academic Year is a required Field" Display="Dynamic" ControlToValidate="ddlSession"
                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                             <tr id="tr3" >
                                <td class="TextLabelMandatory40" valign="top" >
                                    Grade Level* :
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddlGradeLevel" runat="server" CssClass="dropdownlist" Width="250px" >
                                        <asp:ListItem>GCE O Level</asp:ListItem>
                                        <asp:ListItem>GCE AS & A Level</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" Width="167px" Enabled="False"
                                        ErrorMessage="Class Level is a required Field" Display="Dynamic" ControlToValidate="ddlGradeLevel"
                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                </td>
                            </tr>

                             <tr id="tr4" >
                                <td class="TextLabelMandatory40" valign="top" >
                                    Result Month* :
                                </td>
                                <td valign="top">
                                    <asp:DropDownList ID="ddlResultMonth" runat="server" CssClass="dropdownlist" Width="250px">
                                    </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" Width="167px" Enabled="False"
                                        ErrorMessage="Result Month is a required Field" Display="Dynamic" ControlToValidate="ddlResultMonth"
                                        InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                                </td>
                            </tr>


                            <tr >
                            <td style="font-size:x-large" colspan="2">
                            Step 1: Select Academic Year.
                            <br />
                            Step 2: Browse CIE excel file from local computer.
                            <br />
                            Step 3: Click on "Fill Data" button.
                            <br />
                            Step 4: After verification of data, click on "Upload Data on Server" button.
                            </td>

                            </tr>
                            <tr id="tr1" runat="server">
                                <td valign="top" colspan="2" align="center">
<strong>Select CIE Excel Template:                                   
</strong><asp:FileUpload ID="FileUpload1" AllowMultiple="true" runat="server" Width="450px"/>
                                   <br />
                                    <asp:Button ID="btnUpload" runat="server" class="button" 
                                        OnClick="btnUpload_Click" Text="Fill Data" ValidationGroup="s" />
                                    <asp:Button ID="Button1" class="button" runat="server" OnClick="Button1_Click" Text="Upload Data on Server" />
                                   
                                  <br />

                                    <asp:GridView ID="GridView1" runat="server" OnPageIndexChanging="PageIndexChanging"
                                        AllowPaging="True" AllowCustomPaging="True" OnSelectedIndexChanged="GridView1_SelectedIndexChanged"
                                        Width="768px" CellSpacing="3" PageSize="6000" AutoGenerateColumns="true" SkinID="GridView">
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <cc1:ModalPopupExtender ID="MPopEx" runat="server" TargetControlID="hiddenForPopUp"
                Enabled="false">
            </cc1:ModalPopupExtender>
            <asp:Button Style="display: none" ID="hiddenForPopUp" runat="server"></asp:Button>
        </ContentTemplate>

        <Triggers>
   <asp:PostBackTrigger ControlID="btnUpload" />
</Triggers>
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
