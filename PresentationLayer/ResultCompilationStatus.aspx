<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ResultCompilationStatus.aspx.cs" Inherits="PresentationLayer_ResultCompilationStatus" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 96%; height: 430px;">
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
        <div id="barchart" style="width: 100%; height: 100%; float: left;">
        </div>


    </div>
    <div style="width: 96%; height: 430px;">
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
        <asp:Literal ID="ltScriptsD" runat="server"></asp:Literal>
        <div id="donutchart" style="width: 100%; height: 100%; float: right;">
        </div>


    </div>
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
        </Scripts>
    </cc1:ToolkitScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="50%"
                    Width="50%" />
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>


</asp:Content>

