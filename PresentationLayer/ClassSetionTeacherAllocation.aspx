<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="ClassSetionTeacherAllocation.aspx.cs" Inherits="PresentationLayer_ClassSetionTeacherAllocation" %>

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Assign Teachers"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Class Section* :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="height:10px;width: 100%">
                                    <td align="left" style="width: 100%" colspan="2">
                                        <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%; text-align: center" colspan="2">
                                        <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            OnRowDataBound="gvSubjects_RowDataBound" Width="100%" OnSorting="gvSubjects_Sorting"
                                            OnRowCommand="gvSubjects_RowCommand" CssClass="table table-striped table-bordered table-hover">
                                            <AlternatingRowStyle CssClass="trgv2" />
                                            <Columns>
                                                <asp:BoundField DataField="Section_Subject_Id" SortExpression="Subject_Name" HeaderText="Section_Subject_Id">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Employee_Id" SortExpression="Subject_Name" HeaderText="Employee_Id">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sr. #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%" Font-Size="14px"/>
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" Font-Size="14px"/>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Subject_Name" SortExpression="Subject_Name" HeaderText="Subject">
                                                    <HeaderStyle HorizontalAlign="Left" Width="55%" Font-Size="14px"/>
                                                    <ItemStyle HorizontalAlign="Left" Width="55%" Font-Size="14px"/>
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Teacher Name">
                                                    <ItemTemplate>
                                                        <asp:DropDownList ID="listTeacher" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                                            Width="98%">
                                                        </asp:DropDownList>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="35%" Font-Size="14px"/>
                                                    <ItemStyle HorizontalAlign="Left" Width="35%" Font-Size="14px"/>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="cb">
                                                    <EditItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                    </EditItemTemplate>
                                                    <HeaderTemplate>
                                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Select</asp:LinkButton>
                                                    </HeaderTemplate>
                                                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Copy">
                                                    <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" ForeColor="#004999" OnClick="btnCopy_Click"
                                                            
                                                          Style="text-align: center; font-weight: bold;" ToolTip="Copy" ImageUrl="~/images/edit.gif"
                                                            
                                                            
                                                            CommandArgument='<%# Eval("Section_Subject_Id") %>'></asp:ImageButton>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemStyle Width="30px" />
                                                </asp:TemplateField>
                                                 <asp:BoundField DataField="Subject_Id" SortExpression="Subject_Id" HeaderText="Subject_Id">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                            </Columns>
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <RowStyle CssClass="trgv1" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="trNotice" runat="server" style="height:10px;width: 100%">
                                    <td align="Center" style="width: 100%" colspan="2">
                                     Class Teacher Must be Subject Teacher !
                                    </td>

                                </tr>
                                <tr id="trClassTeacher" runat="server" style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Select Class Teacher*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="List_ClassTeacher" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            Width="300px" ValidationGroup="S" OnSelectedIndexChanged="List_ClassTeacher_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                         <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator1" runat="server"
                                                                    ValidationGroup="S" 
                                            ControlToValidate="List_ClassTeacher" Display="Dynamic" ErrorMessage="Class Teacher is a required field."
                                                                    SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr style="height:10px;width: 100%">
                                    <td align="left" style="width: 100%" colspan="2">
                                        
                                    </td>
                                </tr>
                                <tr id="trSave" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        <asp:Button ID="btnSave" runat="server" OnClick="btnSave_Click" Text="Save" Width="77px"
                                            CssClass="btn btn-primary size btn-md" ValidationGroup="S" />
                                    </td>
                                </tr>
                            </table>
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
