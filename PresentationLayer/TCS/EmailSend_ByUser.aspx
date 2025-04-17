<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PresentationLayer/MasterPage.master" CodeFile="EmailSend_ByUser.aspx.cs" Inherits="PresentationLayer_TCS_EmailSend_ByUser" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />

        </Scripts>

    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <contenttemplate>
             <script type="text/javascript">

                 Sys.Application.add_init(function () {
                     // Initialization code here, meant to run once.

                     jq(document).ready(document_Ready);

                     function document_Ready() {

                         jq(document).ready(function () {

                             //****************************************************************
                             try {
                                 $('table.datatable').DataTable({
                                     destroy: true,
                                     "dom": 'Blfrtip',

                                     buttons: [

                                         {
                                             extend: 'excel',
                                             title: 'Student Forecasted Grade'
                                         }
                                     ],
                                     "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                 });
                             }
                             catch (err) {
                                 // alert('datatable ' + err);
                             }

                             //****************************************************************



                         }
                         );

                     } //end of documnet_ready()



                     //Re-bind for callbacks
                     var prm = Sys.WebForms.PageRequestManager.getInstance();
                     prm.add_endRequest(function () {
                         jq(document).ready(document_Ready);
                         //            document_Ready();
                         //            alert('call back done');
                     }
                     );

                 });

             </script>
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Undertaking Email To Parent's"></asp:Label>
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

                                    <td class="col-lg-4 col-md-2 col-xs-10 col-sm-6">

                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Region </label>
                                            <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                 Width="100%">
                                            </asp:DropDownList>
                                        </div>

                                    </td>


                                    <td class="col-lg-4 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Class </label>
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term"
                                              OnSelectedIndexChanged="ddlclass_SelectedIndexChanged"   Width="100%">
                                                <%--disabled="disabled"--%>
                                            </asp:DropDownList>
                                        </div>
                                    </td>

                                    <td class="col-lg-4 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Term </label>
                                            <asp:DropDownList ID="ddlterm" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term"
                                                OnSelectedIndexChanged="ddlterm_SelectedIndexChanged" Width="100%">
                                                <%--disabled="disabled"--%>
                                            </asp:DropDownList>
                                        </div>
                                    </td>

                                      <td class="col-lg-4 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                           <asp:button runat="server" class="btn btn-primary" ID="btn_email" style="margin-top: 25px;" Text="Email Send" OnClick="btn_email_Click"/>
                                           
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:GridView ID="Grid" runat="server" AutoGenerateColumns="false"  CssClass="datatable table table-bordered table-condensed"
                              OnPreRender="gv_details_PreRender"
                                EmptyDataText="No Record Exists." ShowHeaderWhenEmpty="true">
                                <columns>
                                    <asp:BoundField DataField="Student ID" SortExpression="Student" HeaderText="Student No"></asp:BoundField>
                                    <asp:BoundField DataField="Student Name" SortExpression="First_Name" HeaderText="Student Name"></asp:BoundField>
                                    <asp:BoundField DataField="Class" SortExpression="Class_Name" HeaderText="Class"></asp:BoundField>
                                    <asp:BoundField DataField="Center" SortExpression="Session" HeaderText="Center"></asp:BoundField>
                                      <asp:BoundField DataField="Email" SortExpression="Session" HeaderText="Email"></asp:BoundField>
                                     <asp:BoundField DataField="Email_Status" SortExpression="Session" HeaderText="Remarks"></asp:BoundField>
                                    
                                </columns>
                                  <HeaderStyle CssClass="tableheader" />
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
        </contenttemplate>
       
    </asp:UpdatePanel>
     
</asp:Content>
