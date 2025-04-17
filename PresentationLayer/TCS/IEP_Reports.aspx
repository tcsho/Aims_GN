<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="IEP_Reports.aspx.cs" Inherits="PresentationLayer_TCS_IEP_Reports" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />

        </Scripts>
    </cc1:ToolkitScriptManager>
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

                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="IEP Reports"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>


                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 13px" class="leftlink" align="right" colspan="3"></td>
                    </tr>
                    <tr>
                        <td>
                            <table class="main_table col-lg-12 col-md-10 col-xs-10 col-sm-10" cellspacing="0" cellpadding="0"
                                border="0">
                                <tr class="row">

                                    <td class="col-lg-4 col-md-2 col-xs-10 col-sm-6 pull-left">

                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Reports </label>
                                            <asp:DropDownList ID="ddl_reports" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="ddl_reports_SelectedIndexChanged" Width="100%">
                                                <asp:ListItem Value="0" Text="Please Select"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Grade Wise Above 60%"></asp:ListItem>
                                                <asp:ListItem Value="2" Text="Grade Wise Below 60%"></asp:ListItem>
                                                <asp:ListItem Value="3" Text="Completion Status"></asp:ListItem>
                                               <%-- <asp:ListItem Value="4" Text="Bifurcated Student Class Wise "></asp:ListItem>--%>
                                            </asp:DropDownList>
                                        </div>

                                    </td>

                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:GridView ID="Grid_IEPStudents" SkinID="GridView" runat="server" AutoGenerateColumns="true" CssClass="datatable table table-striped table-bordered table-hover"
                                AllowSorting="True" AllowPaging="True" PageSize="50" Width="100%"
                                EmptyDataText="No Record Exists." ShowHeaderWhenEmpty="true">
                               
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
