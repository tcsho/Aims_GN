<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TCSStdAttn.aspx.cs" Inherits="PresentationLayer_TCS_TSSStdAttn"
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
                    <tr style="width: 100%; height: 100%">
                        <td colspan="3" style="width: 100%; height: 100%">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Attendance"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 19px; text-align: left" align="right" colspan="12">
                                        </td>
                                        <td align="right">
                                        </td>
                                    </tr>
                                    <tr id="trMonth" runat="server" visible="false">
                                        <td style="height: 18px; text-align: right" align="right" colspan="1">
                                            Month :
                                        </td>
                                        <td style="height: 18px; text-align: left" align="right" colspan="12">
                                            <asp:DropDownList ID="ddlMonth" runat="server" Width="150px">
                                                <asp:ListItem Value="1">January</asp:ListItem>
                                                <asp:ListItem Value="2">February</asp:ListItem>
                                                <asp:ListItem Value="3">March</asp:ListItem>
                                                <asp:ListItem Value="4">April</asp:ListItem>
                                                <asp:ListItem Value="5">May</asp:ListItem>
                                                <asp:ListItem Value="6">June</asp:ListItem>
                                                <asp:ListItem Value="7">July</asp:ListItem>
                                                <asp:ListItem Value="8">August</asp:ListItem>
                                                <asp:ListItem Value="9">September</asp:ListItem>
                                                <asp:ListItem Value="10">October</asp:ListItem>
                                                <asp:ListItem Value="11">November</asp:ListItem>
                                                <asp:ListItem Value="12">December</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr id="trDate" runat="server" visible="false">
                                        <td style="height: 19px; text-align: right" align="right" colspan="1">
                                            Date* :
                                        </td>
                                        <td style="height: 19px; text-align: left" align="right" colspan="12">
                                            <asp:TextBox ID="txtDate" runat="server" Width="143px" OnTextChanged="txtDate_TextChanged"
                                                AutoPostBack="True"></asp:TextBox>
                                            <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator5" runat="server"
                                                Display="None" ValidationGroup="c" ErrorMessage="Select Date" ControlToValidate="txtDate"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trClsSec" runat="server" visible="false">
                                        <td style="height: 18px; text-align: right" align="right" colspan="1">
                                            Class Section* :
                                        </td>
                                        <td style="height: 18px; text-align: left" align="right" colspan="12">
                                            <%--<input class="button" onclick="javaScript:history.go(-1);" type="button" value="Back" />--%>
                                            <asp:DropDownList ID="ddl_ClassSection" runat="server" Width="150px" AutoPostBack="True"
                                                ToolTip="Select Class and Section" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator1" runat="server"
                                                Display="None" ValidationGroup="c" ErrorMessage="Select Class and Section" ControlToValidate="ddl_ClassSection"
                                                InitialValue="0"></asp:RequiredFieldValidator><%--<asp:Menu ID="mnuWorkSite" runat="server" Orientation="Horizontal" >
                                    </asp:Menu>--%>
                                        </td>
                                    </tr>
                                    <tr id="trStd" runat="server" visible="false">
                                        <td style="height: 19px; text-align: right" align="right" colspan="1">
                                            Student* :
                                        </td>
                                        <td style="height: 19px; text-align: left" align="right" colspan="12">
                                            <asp:DropDownList ID="list_student" runat="server" Width="150px" AutoPostBack="True"
                                                ToolTip="Select Student" OnSelectedIndexChanged="list_student_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator3" runat="server"
                                                Display="None" ValidationGroup="c" ErrorMessage="Select Student" ControlToValidate="list_student"
                                                InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trLeaveType" runat="server" visible="false">
                                        <td style="height: 19px; text-align: right" align="right" colspan="1">
                                            Leave Type* :
                                        </td>
                                        <td style="height: 19px; text-align: left" align="right" colspan="12">
                                            <asp:DropDownList ID="ddlLeaveType" runat="server" Width="150px" ToolTip="Select Leave Type">
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator4" runat="server"
                                                Display="None" ValidationGroup="c" ErrorMessage="Select Leave Type" ControlToValidate="ddlLeaveType"
                                                InitialValue="0"></asp:RequiredFieldValidator>
                                        </td>
                                    </tr>
                                    <tr id="trLnkBtn" runat="server" visible="false">
                                        <td style="height: 19px; text-align: right" align="right" colspan="1">
                                        </td>
                                        <td style="height: 19px; text-align: left" align="right" colspan="12">
                                            <asp:LinkButton ID="lnkAddOptions" OnClick="lnkAddOptions_Click" runat="server" ValidationGroup="c"></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; text-align: left" class="titlesection" align="right" colspan="13">
                                            Negative Attendance
                                        </td>
                                    </tr>
                                    <tr id="trgvOptions" runat="server" visible="false">
                                        <td style="height: 19px; text-align: right" align="right" colspan="13">
                                            <asp:GridView ID="gvOptions" runat="server" Width="100%" SkinID="GridView" PageSize="15"
                                                HorizontalAlign="Center" AutoGenerateColumns="False" AllowSorting="True" 
                                                AllowPaging="True" style="height: 35px">
                                                <RowStyle CssClass="tr1" />
                                                <Columns>
                                                    <asp:BoundField DataField="Attn_ID" HeaderText="No.">
                                                        <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="name" HeaderText="Name">
                                                        <HeaderStyle HorizontalAlign="Left" Width="100px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="AttnDate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy}"
                                                        HtmlEncode="False">
                                                        <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                                        <ItemStyle HorizontalAlign="Center" Width="50px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="AttnDesc" HeaderText="Leave Type">
                                                        <HeaderStyle HorizontalAlign="Left" Width="75px" />
                                                        <ItemStyle HorizontalAlign="Left" Width="75px" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="AttnType_Id">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:BoundField DataField="Student_Id">
                                                        <HeaderStyle CssClass="hide" />
                                                        <ItemStyle CssClass="hide" />
                                                    </asp:BoundField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Edit" runat="server" CommandArgument='<%# Eval("Attn_ID") %>'
                                                                ImageUrl="~/images/edit.gif" OnClick="btnEditOpt_Click" ToolTip="Edit" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="Delete" runat="server" CommandArgument='<%# Eval("Attn_ID") %>'
                                                                ImageUrl="~/images/delete.gif" OnClick="btnDeleteOpt_Click" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');"
                                                                ToolTip="Delete" />
                                                        </ItemTemplate>
                                                        <HeaderStyle Width="20px" HorizontalAlign="Left" />
                                                    </asp:TemplateField>
                                                </Columns> 
                                                <SelectedRowStyle CssClass="tr_select" />
                                                <HeaderStyle CssClass="tableheader" />
                                                <AlternatingRowStyle CssClass="tr2" />
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; text-align: center" align="right" colspan="13">
                                            <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary"
                                                Text="Submit"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; text-align: left" class="titlesection" align="right" colspan="13">
                                            Attendance Report
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="height: 19px; text-align: left" align="right" colspan="13">
                                            <asp:GridView ID="gvAttnMonthly" runat="server" Width="100%" SkinID="GridView" PageSize="150"
                                                HorizontalAlign="Center" AllowPaging="True" OnRowCreated="gvAttnMonthly_RowCreated"
                                                OnPageIndexChanging="gvAttnMonthly_PageIndexChanging">
                                                <RowStyle CssClass="tr1"></RowStyle>
                                                <SelectedRowStyle CssClass="tr_select"></SelectedRowStyle>
                                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                            </asp:GridView>
                                            <asp:Label ID="lblNoData" runat="server" Visible="False"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                            </cc1:ValidatorCalloutExtender>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                            </cc1:ValidatorCalloutExtender>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4">
                            </cc1:ValidatorCalloutExtender>
                            <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5">
                            </cc1:ValidatorCalloutExtender>
                            <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate">
                            </cc1:CalendarExtender>
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                </tbody>
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
