<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ClassSectionDaysAttCom.aspx.cs" Inherits="PresentationLayer_TCS_ClassSectionDaysAttCom" 

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Class Teacher Comments"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 13px" class="leftlink" align="right" colspan="3">
                        </td>
                    </tr>

                    <tr>
                        <td>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center" border="0">
                                <tr>
                                    <td class="TextLabelMandatory40" >
                                        Class Section*:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdownlist" Width="250px"
                                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        
                                    </td>
                                </tr>
                                <tr>
                                    <td class="TextLabelMandatory40">
                                        Term *:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="list_term" runat="server" AutoPostBack="True" 
                                            CssClass="dropdownlist" OnSelectedIndexChanged="list_term_SelectedIndexChanged" 
                                            Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                                        <tr>
                        <td style="height: 22px" class="titlesection" colspan="3">
                            <asp:Label ID="msg" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                Visible="False" Font-Overline="False" Class="formheading">Please Select Class</asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:GridView ID="gvRegStudents" SkinID="GridView" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%" OnPageIndexChanging="gvRegStudents_PageIndexChanging"
                                EmptyDataText="No Record Exists." OnRowDataBound="gvRegStudents_RowDataBound"
                                OnRowCommand="gvRegStudents_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="Student_Id" SortExpression="Student_Id" HeaderText="Student_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField ItemStyle-Width="100%">
                                        <ItemTemplate>
                                            <table style="table-layout: fixed; height: 92%; width: 100%; vertical-align: top;"
                                                cellspacing="0" cellpadding="0">
                                                <tr class="tr1">
                                                <td></td>
                                                </tr>
                                                <tr class="tr2" style="height: 72%">
                                                    <td align="left" valign="top" style="word-wrap: break-word">
                                                        <table style="table-layout: fixed; height: 92%; width: 100%; vertical-align: top;"
                                                            cellspacing="0" cellpadding="0">
                                                            <tr style="width: 100%">
                                                                <td style="width: 15%;text-align:right;">
                                                                    Roll # :
                                                                </td>
                                                                <td style="width: 35%; color: Black; font-size: medium; font-weight: bold">
                                                                    <%# Eval("Student_Id") %>
                                                                </td>
                                                                <td style="width: 15%;text-align:right;">
                                                                    Student Name :
                                                                </td>
                                                                <td style="width: 35%; color: Black; font-size: 12px; font-weight: bold">
                                                                    <%# Eval("StudentNameId")%>
                                                                </td>
                                                            </tr>
                                                            <tr style="width: 100%; height: 10px">
                                                                <td style="width: 15%">
                                                                </td>
                                                                <td style="width: 35%">
                                                                </td>
                                                                <td style="width: 15%">
                                                                </td>
                                                                <td style="width: 35%">
                                                                </td>
                                                            </tr>
                                                            <tr style="width: 100%">
                                                                <td style="width: 15%;text-align:right;">
                                                                    Gender:
                                                                </td>
                                                                <td style="width: 35%; color: Black; font-size: 12px; font-weight: bold">
                                                                    <%# Eval("Gender")%>
                                                                </td>
                                                                <td style="width: 15%;text-align:right;">
                                                                    Section:
                                                                </td>
                                                                <td style="width: 35%; color: Black; font-size: 12px; font-weight: bold">
                                                                    <%# Eval("Section_Name")%>
                                                                </td>
                                                            </tr>
                                                            <tr style="width: 100%; height: 10px">
                                                                <td style="width: 15%">
                                                                </td>
                                                                <td style="width: 35%">
                                                                </td>
                                                                <td style="width: 15%">
                                                                </td>
                                                                <td style="width: 35%">
                                                                </td>
                                                            </tr>

                                                            <tr style="width: 100%; height: 10px">
                                                                <td style="width: 15%">
                                                                </td>
                                                                <td style="width: 35%">
                                                                </td>
                                                                <td style="width: 15%">
                                                                </td>
                                                                <td style="width: 35%">
                                                                </td>
                                                            </tr>
                                                            <tr style="width: 100%">
                                                                <td style="width: 15%;text-align:left;">
                                                                    <Strong id="t" runat="server"  visible='<%#(Convert.ToInt32(Eval("Class_Id"))> 6)?true:false%>' > Club / Societies / Co-Curricular Activities(maximum 500 characters with spaces): </Strong>
                                                                    <Strong id="Strong1" runat="server"  visible='<%#(Convert.ToInt32(Eval("Class_Id"))<= 6)?true:false%>' > Class Teacher's Comments(maximum 500 characters with spaces): </Strong>
                                                                </td>
                                                                <td style="width: 35%; color: Teal; font-size: 16px; font-weight: bold" colspan="3">
                                                                    <asp:TextBox ID="txt_TeacherComments" runat="server" CssClass="textbox" Width="80%"
                                                                        Height="150px" TextMode="MultiLine" MaxLength="500" Style="resize: none"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr style="width: 100%; height: 20px">
                                                                <td style="width: 15%">
                                                                </td>
                                                                <td style="width: 35%">
                                                                </td>
                                                                <td style="width: 15%">
                                                                </td>
                                                                <td style="width: 35%">
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                                <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3" style="text-align:center">
                        <asp:Button ID="but_save" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click" Text="Save" ValidationGroup="valSave" width="100px"/>
                        </td>
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

