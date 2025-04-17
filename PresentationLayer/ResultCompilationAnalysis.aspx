<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ResultCompilationAnalysis.aspx.cs" Inherits="PresentationLayer_ResultCompilationStatus" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>

    <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
        border="0">
        <tbody>
            <tr>
                <td style="height: 100%" width=".5%"></td>
                <td id="tdFrmHeading" class="formheading">
                    <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Result Completion Analysis"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </td>
            </tr>
        </tbody>
    </table>


    <div style="width: 100%; height: 100%;">
        <div style="width: 20%; height: 100%; float: left">
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr id="tr3" runat="server">
                        <td class="TextLabelMandatory40"></td>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr id="trSession" runat="server">
                        <td class="TextLabelMandatory40">Session*:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" Width="90%"
                                AutoPostBack="True" OnSelectedIndexChanged="default_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr id="trTerm" runat="server">
                        <td class="TextLabelMandatory40">Term*:
                        </td>
                        <td align="left" style="height: 20px">
                            <asp:DropDownList ID="ddlTerm" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                Width="90%" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="default_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="First Term"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Second Term"></asp:ListItem>
                            </asp:DropDownList>


                        </td>
                    </tr>
                    <tr id="tr1" runat="server">
                        <td class="TextLabelMandatory40">Chart*:
                        </td>
                        <td align="left" style="height: 20px">
                            <asp:DropDownList ID="ddlChartType" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                Width="90%" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="default_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                    </tr>

                    <tr id="tr2" runat="server">
                        <td class="TextLabelMandatory40">Report*:
                        </td>
                        <td align="left" style="height: 20px">
                            <asp:DropDownList ID="ddlReport" runat="server" CausesValidation="True" ValidationGroup="btnSaveValidation"
                                Width="90%" CssClass="dropdownlist" AutoPostBack="True" OnSelectedIndexChanged="ddlReport_SelectedIndexChanged">
                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Result Completion Status"></asp:ListItem>
                                <asp:ListItem Value="2" Text="Promotional Detention Summary"></asp:ListItem>
                            </asp:DropDownList>


                        </td>
                    </tr>
                    <tr id="tr4" runat="server">
                        <td class="TextLabelMandatory40"></td>
                        <td align="left" style="height: 20px">
                            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <asp:LinkButton ID="btnResultCompletion" runat="server" CssClass="pull-right btn btn-primary" OnClick="btnResultCompletion_Click"
                                        Text="Result Completion Data" />
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </td>
                    </tr>
                </tbody>
            </table>

        </div>
        <div style="width: 80%; height: 100%; float: right">

            <div style="width: 100%; height: 100%;">
                <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>

                <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
                <div id="Chart1" style="width: 50%; height: 100%; float: left;">
                </div>
                <div id="Chart2" style="width: 50%; height: 100%; float: right;"></div>



            </div>
            <div style="width: 100%; height: 100%;">
                <div id="Chart3" style="width: 50%; height: 100%; float: left;"></div>
                <div id="Chart4" style="width: 50%; height: 100%; float: right;"></div>


            </div>

        </div>

    </div>
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

