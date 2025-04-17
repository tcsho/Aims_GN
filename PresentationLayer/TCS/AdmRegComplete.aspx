<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdmRegComplete.aspx.cs" Inherits="PresentationLayer_TCS_AdmRegComplete" Theme="BlueTheme" %>

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
                                        </table>
                                    </td>
                                </tr>
                                <tr id="trInstructions" style="width: 100%; height: 50px;">
                                    <td style="width: 100%; font-size: x-large; text-align: left; padding-left: 4%;">
                                        <br />
                                        Admission Test has been Completed. Here is the Result!
                                        <br />
                                    </td>
                                </tr>
                                <tr style="width: 100%;">

                                <td style="width: 100%;" align="center" >
                                <asp:GridView ID="gvRackData" runat="server" EmptyDataText="No Record Exists." CssClass="table table-striped table-responsive"
                                PageSize="150" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" 
                                SkinID="GridViewDetailResult"   onrowdatabound="gvRackData_RowDataBound">
                                <Columns>
                                   <asp:BoundField DataField="AnswerCheck" HeaderText="AnswerCheck">
                                        <HeaderStyle CssClass="hide" />
                                        <ItemStyle Wrap="False" Width="5%" CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="Sr #.">
                                        <ItemStyle Width="10%" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:BoundField DataField="Question_No" HeaderText="Question #">
                                        <HeaderStyle />
                                        <ItemStyle Wrap="False" Width="30%" />
                                    </asp:BoundField>
                                    
                                    <asp:BoundField DataField="AnswerCheckCH" HeaderText="Result Status">
                                        <HeaderStyle />
                                        <ItemStyle Wrap="False" Width="30%" />
                                    </asp:BoundField>
                                      <asp:BoundField DataField="MarksObtained" HeaderText="Obtained Marks">
                                            <HeaderStyle />
                                            <ItemStyle Wrap="true" Width="15%" Font-Size="Large"  HorizontalAlign="Center" />
                                        </asp:BoundField>
                                    <asp:TemplateField HeaderText="Result">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanTick" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_tick.png" />
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_Cross.png"  />
                                                <asp:Image ID="btnScanNoAnswer" runat="server" ForeColor="#004999" Style="text-align: center;
                                                font-weight: bold;" ImageUrl="~/images/Scan_noAnswer.png"  />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="10%" />
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle CssClass="success" />
                                
                            </asp:GridView>
                                </td>
                    </tr>
            </table>
            </tr> </tbody> </table>
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
