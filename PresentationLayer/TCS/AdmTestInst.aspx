<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdmTestInst.aspx.cs" Inherits="PresentationLayer_TCS_AdmTestInst" %>

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
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student's Admission Test"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr id="tr2" runat="server" style="width: 100%">
                                    <td style="width: 100%; font-size: xx-large; text-align: Center">
                                        <br />
                                    </td>
                                </tr>
                                <tr style="width: 100%; padding-top: 5%;">
                                    <td>
                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                            <tr style="width: 100%;">
                                                <td style="width: 30%; text-align: right; font-size: x-large;">
                                                    Registration # :&nbsp;
                                                </td>
                                                <td id="tdReg" runat="server" style="width: 15%; text-align: left; font-size: x-large;
                                                    color: Blue;">
                                                </td>
                                                <td style="width: 15%; text-align: right; font-size: x-large;">
                                                    Student Name :&nbsp;
                                                </td>
                                                <td id="tdSName" runat="server" style="width: 40%; text-align: left; font-size: x-large;
                                                    color: Blue;">
                                                </td>
                                            </tr>
                                            <tr style="width: 100%; height: 10px">
                                                <td style="width: 30%;">
                                                </td>
                                                <td style="width: 15%;">
                                                </td>
                                                <td style="width: 15%;">
                                                </td>
                                                <td style="width: 40%;">
                                                </td>
                                            </tr>
                                            <tr style="width: 100%;">
                                                <td style="width: 30%; text-align: right; font-size: x-large;">
                                                    Admission Test of :&nbsp;
                                                </td>
                                                <td id="tdClass" runat="server" style="width: 15%; text-align: left; font-size: x-large;
                                                    color: Blue;">
                                                </td>
                                                <td style="width: 15%; text-align: right; font-size: x-large;">
                                                    Center Name :&nbsp;
                                                </td>
                                                <td id="tdCName" runat="server" style="width: 40%; text-align: left; font-size: x-large;
                                                    color: Blue;">
                                                </td>
                                            </tr>
                                              
                                            <tr id="trGroupType" runat="server" visible="false" style="width: 100%; height: 100%">
                                               <td style="width: 30%; text-align: right; font-size: x-large;">
                                                    <asp:Label ID="lblGroup" runat="server" Text="Select a Group Type: " 
                                                    CssClass="TextLabelMandatory"></asp:Label>
                                                </td>
                                                 <td id="td2" runat="server" style="width: 15%; text-align: left; font-size: x-large;
                                                    color: Blue;">
                                                </td>
                                                <td id="td1" runat="server" style="width: 15%; text-align: left; font-size: x-large;
                                                    color: Blue;">
                                                    <asp:CheckBoxList ID="chkGroup_Type" runat="server" CssClass=" radio" RepeatDirection="Horizontal"
                                                        RepeatColumns="3">
                                                        <asp:ListItem Value="Business" Text="Business"></asp:ListItem>
                                                        <asp:ListItem Value="Science" Text="Science"></asp:ListItem>
                                                    </asp:CheckBoxList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr id="trInstructions" runat="server" style="width: 100%; height: 50px;">
                                    <td style="width: 100%; font-size: x-large; text-align: left; padding-left: 4%;">
                                        <br />
                                        Please read instructions carefully before starting the admission test.
                                    </td>
                                </tr>
                                <tr id="trInstructions1" runat="server" style="width: 100%; height: 100%">
                                    <td style="width: 100%; font-size: large; text-align: left; padding-left: 6%;">
                                        <br />
                                        1. Answering all questions is mandatory. Once you click on save button question
                                        will be saved and next question will appear.
                                        <br />
                                        <br />
                                        2. If answer will not be given within time, no marks will be awarded for this question.
                                        <br />
                                        <br />
                                        3. If an option is selected and time is up, your selected option will be considered
                                        as answer.
                                        <br />
                                        <br />
                                        4. Click on Start Test button to start your admission test.
                                        <br />
                                        <br />
                                    </td>
                                </tr>
                                <tr id="tr1" runat="server" visible="false" style="width: 100%; height: 100%">
                                    <td style="width: 100%; font-size: large; text-align: left; padding-left: 6%;">
                                    </td>
                                </tr>
                                <tr id="trStatus" runat="server" visible="false" style="width: 100%; height: 100%">
                                    <td style="width: 100%; font-size: large; text-align: left; padding-left: 6%;">
                                     <br />
                                        <asp:Label runat="server" ID="lblStatus" CssClass="text-danger" ForeColor="Red" Font-Size="XX-Large" Text="
                                       You are not eligible for the test please consult school management for further assistance."></asp:Label>
                                    </td>
                                </tr>
                                <tr id="trSave" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        <asp:Button ID="btnSave" runat="server" Text="Start Admission Test" Width="200px"
                                            CssClass="btn btn-primary" OnClick="btnSave_Click" />&nbsp;&nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                    </tr>
                </tbody>
            </table>
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
