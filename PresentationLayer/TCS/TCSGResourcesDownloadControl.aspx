<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="TCSGResourcesDownloadControl.aspx.cs" Inherits="PresentationLayer_TCS_TCSGResourcesDownloadControl"
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
                                            <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" 
                                                Text="Upload General Resource Download Control" Visible="False"></asp:Label>
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
                    <td colspan="5" align="right">
                        &nbsp;<img src="../../images/back_button_Caralog.png" style="position: relative;
                            top: 2px" />
                        <asp:LinkButton ID="lnkBtnBack" runat="server" OnClick="lnkBtnBack_Click">Back</asp:LinkButton>
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <GleamTech:FileVistaControl ID="FileVistaControl" runat="server" Style="width: 99%;
                            height: 600px" LicenseKey="" Debug="false" Fullscreen="false" UploadMethod="Flash">
                        </GleamTech:FileVistaControl>
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

