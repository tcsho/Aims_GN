<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PresentationLayer/MasterPage.master" CodeFile="BifurcationList.aspx.cs" Inherits="PresentationLayer_TCS_BifurcationList" %>


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
                                             title: 'Bifurcation List'
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Bifurcation List"></asp:Label>
                                            <%--<asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Undertaking List"></asp:Label>--%>
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
                                   

                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Class </label>
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged1"
                                                Width="100%">
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
                                OnPreRender="gv_details_PreRender"   OnRowDataBound="Grid_IEPStudents_RowDataBound"
                                EmptyDataText="No Record Exists." ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="Student_id" SortExpression="Student_id" HeaderText="Student No"></asp:BoundField>
                                    <asp:BoundField DataField="Studentname" SortExpression="First_Name" HeaderText="Student Name"></asp:BoundField>
                                     <asp:BoundField DataField="FatherEmail" SortExpression="FatherEmail" HeaderText="FatherEmail"></asp:BoundField>
                                    <asp:BoundField DataField="Class_Name" SortExpression="Class_Name" HeaderText="Class"></asp:BoundField>
                                    <asp:BoundField DataField="Term" SortExpression="Session" HeaderText="term"></asp:BoundField>
                                     <asp:BoundField DataField="center_name" SortExpression="Session" HeaderText="Campus Name"></asp:BoundField>
                                      <asp:BoundField DataField="English" SortExpression="Session" HeaderText="English"></asp:BoundField>
                                      <asp:BoundField DataField="Mathematics" SortExpression="Session" HeaderText="Mathematics"></asp:BoundField>
                                      <asp:BoundField DataField="Science" SortExpression="Session" HeaderText="Science"></asp:BoundField>
                                    <asp:BoundField DataField="Urdu" SortExpression="Session" HeaderText="Urdu"></asp:BoundField>
                                      <asp:BoundField DataField="Overall_p" SortExpression="Session" HeaderText="Overall Percentage"></asp:BoundField>
                                     <asp:BoundField DataField="Email_Status" SortExpression="Email_Status" HeaderText="Email Status"></asp:BoundField>
                                  
                                   
                                </Columns>
                                <HeaderStyle CssClass="tableheader" />
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
          
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

