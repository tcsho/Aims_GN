<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="IEP_Undertaking_List.aspx.cs" Inherits="PresentationLayer_TCS_IEP_Undertaking_List" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />

        </Scripts>
    </cc1:ToolkitScriptManager>
    <style>
        .hide
    {
        display: none;
    }
    </style>
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

                                             <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Undertaking List"></asp:Label>
                                           <%-- <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Undertaking - Bifurcation"></asp:Label>--%>
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
                        <asp:GridView ID="Grid_IEPStudents" runat="server"  AutoGenerateColumns="false" OnRowCommand="Grid_IEPStudents_RowCommand" CssClass="datatable table table-bordered table-condensed"
                            OnPreRender="gv_details_PreRender"
                            EmptyDataText="No Record Exists." ShowHeaderWhenEmpty="true">
                            <Columns>
                                  <asp:BoundField HeaderText="Section" DataField="section_id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" /> 
                                <asp:BoundField HeaderText="Student No" DataField="StudentID" />
                                <asp:BoundField HeaderText="Student Name" DataField="StudentName" />
                                <asp:BoundField HeaderText="Center Name" DataField="Center_Name" />
                                <asp:BoundField HeaderText="Class Name" DataField="Class_Name" />
                                  <asp:BoundField HeaderText="Term" DataField="TermID" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />
                                    <asp:BoundField HeaderText="Term" DataField="Term" />
                                <asp:BoundField HeaderText="Description" DataField="Description" />
                                <asp:BoundField HeaderText="Parent Approved" DataField="ParentApproved" />
                             <%--   <asp:BoundField HeaderText="Date of issue" DataField="Date_of_issue" />--%>
                                <asp:TemplateField HeaderText="Undertaking" ItemStyle-Width="150" SortExpression="1">
                                    <ItemTemplate>
                                        <asp:Button  runat="server" ID="txt_view"  CommandName="View" Text="View" CommandArgument='<%#Eval("StudentID")%>' />
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
