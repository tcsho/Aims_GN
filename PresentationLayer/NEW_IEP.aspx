<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="NEW_IEP.aspx.cs" Inherits="PresentationLayer_NEW_IEP" %>


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

            <!-- Add the iframe here -->
           <iframe id="myIframe" runat="server" width="100%" height="600px" frameborder="0"></iframe> 
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
