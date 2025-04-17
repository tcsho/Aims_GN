<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TssCrystalReports.aspx.cs" Inherits="PresentationLayer_TCS_TssCrystalReports" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304"

    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="../../Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="../../Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table align="center" border="0" cellpadding="0" cellspacing="0" class="main_table"
                width="100%">
                <tr>
                    <td valign="top" style="text-align: center; height: 24px;" colspan="2">
                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Text="Back to Home Page"
                            OnClick="btnCancel_Click" Width="151px" />
                        &nbsp; &nbsp;
                    </td>
                    <td align="right">
                     <%--   <img src="../../images/back_button_Caralog.png" style="position: relative; top: 2px" />
                        <asp:LinkButton ID="lnkBtnBack" runat="server" OnClick="btnCancel_Click">Back</asp:LinkButton>&nbsp;--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" valign="top" id="Td1" runat="server">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="3" valign="top" style="height: 60px" >
                        <CR:CrystalReportViewer ID="rptviewer" runat="server" AutoDataBind="true"    ToolPanelView="None" />
                    </td>
                    
                    
                </tr>
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
