<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="LetterOfUndertakingAcknowledgement.aspx.cs" Inherits="PresentationLayer_LetterOfUndertakingAcknowledgement"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Letter Of Undertaking Acknowledgement"></asp:Label>
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
                        <td style="height: 22px" class="titlesection" colspan="3">
                            <asp:Label ID="msg" runat="server" ForeColor="White" Font-Bold="True" Font-Size="11px"
                                Visible="False" Font-Overline="False" Class="formheading">Please Select Class</asp:Label>
                        </td>
                    </tr>

                      <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 40%;">
                                        
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            Height="16px" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" 
                                            Width="218px" Visible="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                  <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Term*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="list_Term_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>


                    <tr>
                        <td>
                            <table>


                                <tr style="width: 100%">
                                    <td align="Center" style="width: 100%" >
                                    
                                  
                                        <asp:Button ID="but_save" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click"
                                            Text="Save Letter Of Undertaking Acknowledgement" 
                                            ValidationGroup="valSave" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:GridView ID="gvRegStudents" runat="server" AutoGenerateColumns="False"
                                AllowSorting="True" AllowPaging="True" PageSize="500" Width="100%" OnPageIndexChanging="gvRegStudents_PageIndexChanging"
                                EmptyDataText="No Record Exists." OnRowDataBound="gvRegStudents_RowDataBound"
                                OnRowCommand="gvRegStudents_RowCommand" CssClass="table table-striped table-bordered table-hover" SkinID="GridView">
                                <Columns>
                                    <asp:BoundField DataField="KindSubStdMst_Id" SortExpression="KindSubStdMst_Id" 
                                        HeaderText="KindSubStdMst_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="IsUndTkIss" HeaderText="IsUndTkIss" 
                                        Visible="False"  />
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemStyle Font-Size="14px" />
                                        <ItemTemplate>
                                           <center><%# Container.DataItemIndex + 1 %></center> 
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Student_Id" HeaderText="Student No">
                                       <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="First_Name" HeaderText="First Name">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Class_Name" HeaderText="Class Name" ><ItemStyle Font-Size="14px" /> </asp:BoundField>
                                    <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                        <HeaderStyle ForeColor="White" />
                                        <ItemStyle Font-Size="14px" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="cb">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Toggle Check All</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
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
                        <td valign="top" colspan="3">
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
