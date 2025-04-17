<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdmissionTest.aspx.cs" Inherits="PresentationLayer_TCS_AdmissionTest"
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
            <asp:Timer runat="server" ID="UpdateTimer" OnTick="UpdateTimer_Tick" />
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="9">
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
                                <tr style="width: 100%; padding-top: 5%;">
                                    <td colspan="2">
                                    </td>
                                </tr>
                                <tr style="width: 100%; padding-top: 5%;">
                                    <td colspan="2">
                                        <table cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                            <tr style="width: 100%;">
                                                <td style="width: 15%; text-align: right; font-size: large;">
                                                </td>
                                            </tr>
                                            <tr style="width: 100%;">
                                                <td style="width: 15%; text-align: right; font-size: large;">
                                                    Registration # :&nbsp;
                                                </td>
                                                <td id="tdReg" runat="server" style="width: 25%; text-align: left; font-size: large;
                                                    color: Blue;">
                                                </td>
                                                <td style="width: 15%; text-align: right; font-size: large;">
                                                    Student Name :&nbsp;
                                                </td>
                                                <td id="tdSName" runat="server" style="width: 15%; text-align: left; font-size: large;
                                                    color: Blue;">
                                                </td>
                                            </tr>
                                            <tr style="width: 100%; height: 10px">
                                                <td style="width: 15%; text-align: right; font-size: large;">
                                                    Test Title: &nbsp;
                                                </td>
                                                <td id="tdTitle" runat="server" style="width: 25%; text-align: left; font-size: large;
                                                    color: Blue;">
                                                </td>
                                                <td style="width: 15%; text-align: right; font-size: large;">
                                                    Test: &nbsp;
                                                </td>
                                                <td id="tdTestName" runat="server" style="width: 15%; text-align: left; font-size: large;
                                                    color: Blue;">
                                                </td>
                                                <td style="width: 15%;">
                                                </td>
                                                <td style="width: 40%;">
                                                </td>
                                            </tr>
                                            <tr style="width: 100%;">
                                                <td style="width: 30%; text-align: right; font-size: large;">
                                                    Question :&nbsp;
                                                </td>
                                                <td id="tdClass" runat="server" style="width: 15%; text-align: left; font-size: large;
                                                    color: Green;">
                                                </td>
                                                <td style="width: 15%; text-align: right; font-size: large;">
                                                    Time per Question :&nbsp;
                                                </td>
                                                <td id="tdCName" runat="server" style="width: 40%; text-align: left; font-size: large;
                                                    color: Green;">
                                                </td>
                                                <td id="tdTestDetails" runat="server" style="width: 40%; text-align: left; font-size: large;
                                                    color: Green;">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 30%; text-align: right; font-size: large;">
                                                </td>
                                                <td id="td1" runat="server" style="width: 15%; text-align: left; font-size: large;
                                                    color: Green;">
                                                </td>
                                                <td style="width: 15%; text-align: right; font-size: large;">
                                                </td>
                                                <td id="td2" runat="server" style="width: 40%; text-align: left; font-size: large;
                                                    color: Green;">
                                                </td>
                                                <td id="td3" runat="server" style="width: 40%; text-align: left; font-size: large;
                                                    color: Green;">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                            border="0">
                                            <tr class="tr2">
                                                <td>
                                                </td>
                                            </tr>
                                            <tr class="tr2">
                                                <td id="trUpdateMarks" runat="server" class="titlesection" colspan="7" visible="true">
                                                    &nbsp; Test Question
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td align="center" colspan="1" style="height: 18px; width: 20%; text-align: center">
                                                </td>
                                            </tr>
                                            <tr style="height: 30px;">
                                                <td align="center" colspan="1" style="height: 18px; width: 20%; text-align: center">
                                                    <asp:Label ID="lblqtime" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large"
                                                        ForeColor="Red" Visible="False">Time In Seconds:</asp:Label>
                                                    <asp:Label ID="lblQuestionTime" runat="server" Font-Bold="True" Font-Italic="False"
                                                        Font-Size="Large" ForeColor="Blue" Visible="False"></asp:Label>
                                                </td>
                                                <td align="center" colspan="1" style="height: 18px; width: 20%; text-align: center">
                                                    <asp:Label ID="lblTimer" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="Large"
                                                        ForeColor="Red"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr style="width: 100%">
                                                <td align="left" colspan="2" style="width: 100%; text-align: Left; padding-left: 2%">
                                                    <asp:GridView ID="gvComplaints" runat="server" AllowPaging="True" AllowSorting="True"
                                                        AutoGenerateColumns="False" EmptyDataText="No record found." HorizontalAlign="Center"
                                                        PageSize="25" SkinID="GridViewDetailTest" Width="100%">
                                                        <RowStyle CssClass="tr1" />
                                                        <Columns>
                                                            <asp:BoundField DataField="AdmTest_Id" HeaderText="AdmTest_Id">
                                                                <ItemStyle CssClass="hide" />
                                                                <HeaderStyle CssClass="hide" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Quest_ID" HeaderText="Question#">
                                                                <ItemStyle CssClass="hide" />
                                                                <HeaderStyle CssClass="hide" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="AdmTestSubmDetail_ID" HeaderText="AdmTestSubmDetail_ID">
                                                                <ItemStyle CssClass="hide" />
                                                                <HeaderStyle CssClass="hide" />
                                                            </asp:BoundField>
                                                            <asp:TemplateField>
                                                                <ItemTemplate>
                                                                    <table class="mcqs_questions">
                                                                        <tr>
                                                                            <td colspan="3" style="color: Teal; font-size: xx-large;">
                                                                                <%# Eval("QuestText")%>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                    <table class="mcqs_options">
                                                                        <tr style="width: 100%;">
                                                                            <td style="width: 100%; margin-left: 5%; vertical-align: top; text-align: Left">
                                                                                <span></span>
                                                                            </td>
                                                                        </tr>
                                                                    </table>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        &nbsp; &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table class="mcqs_questions" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr style="width: 100%;">
            <td style="height: 19px; padding-left: 5%;">
                <asp:RadioButtonList ID="rblOptions" runat="server" RepeatDirection="Vertical" TextAlign="Right"
                    CellPadding="5" CellSpacing="5">
                </asp:RadioButtonList>
            </td>
        </tr>
        <tr style="width: 100%; text-align: center" align="center">
            <td style="height: 19px; text-align: center" align="center">
                <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" CssClass=" btn btn-success" />&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnNext" runat="server" CssClass="btn btn-success" OnClick="btnNext_Click"
                    Text="Next" />
            </td>
        </tr>
    </table>
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
