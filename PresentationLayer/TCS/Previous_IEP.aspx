<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="Previous_IEP.aspx.cs" Inherits="PresentationLayer_TCS_Previous_IEP" %>


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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="IEPs Status"></asp:Label>
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
                            <table  cellspacing="0" cellpadding="0"
                                border="0" width="100%">
                                <tr class="row">

                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-6">

                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Region </label>
                                            <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="ddl_region_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </div>

                                    </td>

                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">School </label>
                                            <asp:DropDownList ID="ddl_center" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="ddl_center_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-8">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">IEP Type </label>
                                            <asp:DropDownList ID="ddlieptype" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term"
                                                OnSelectedIndexChanged="ddlieptype_SelectedIndexChanged" Width="100%">
                                                <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Previous IEP</asp:ListItem>
                                                <asp:ListItem Value="2">Incompleted IEP</asp:ListItem>
                                                <asp:ListItem Value="3">Completed IEP</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </td>

                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Class </label>
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term"
                                                Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>

                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Term </label>
                                            <asp:DropDownList ID="ddlterm" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term"
                                                OnSelectedIndexChanged="ddlterm_SelectedIndexChanged" Width="100%">
                                                <asp:ListItem Selected="True" Value="0">
                                                    Select</asp:ListItem>
                                                <asp:ListItem Value="1">First Term</asp:ListItem>
                                                <asp:ListItem Value="2">Second Term</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </td>

                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:GridView ID="Grid_IEPStudents" runat="server" AutoGenerateColumns="false" CssClass="datatable table table-bordered table-condensed"
                                OnPreRender="gv_details_PreRender"  OnRowCommand="Grid_IEPStudents_RowCommand"
                                EmptyDataText="No Record Exists." ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="Student_no" SortExpression="Student_no" HeaderText="Student No"></asp:BoundField>
                                    <asp:BoundField DataField="First_Name" SortExpression="First_Name" HeaderText="Student Name"></asp:BoundField>
                                    <asp:BoundField DataField="Class_Name" SortExpression="Class_Name" HeaderText="Class"></asp:BoundField>
                                    <asp:BoundField DataField="Session" SortExpression="Session" HeaderText="Session"></asp:BoundField>
                                    <asp:BoundField DataField="parentapproved" SortExpression="parentapproved" HeaderText="Parent Approved"></asp:BoundField>
                                     <asp:TemplateField HeaderText="Reminder">
                                        <%--17--%>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>

                                           <asp:Button ID="btnreminder"  
                            CommandArgument="<%# ((GridViewRow)Container).RowIndex %>" 
                            CommandName="reminder" runat="server" Text="Send Reminder" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="IEP">
                                        <%--17--%>
                                        <ItemStyle HorizontalAlign="Center" />
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <a href='<%# ResolveUrl("~/PresentationLayer/tcs/IEP_Form.aspx?s="+Eval("Student_no")+"&ses="+Eval("session_id")) %>'><i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>
                                            </a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                                <HeaderStyle CssClass="tableheader" />
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
            <script>
                $(document).ready(function () {


                    $('table.datatable').DataTable({
                        destroy: true,
                        "dom": 'Blfrtip',

                        buttons: [

                            {
                                extend: 'excel',
                                title: 'Undertaking-Bifurcation '
                            }
                        ],
                        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                    });
                });
            </script>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
