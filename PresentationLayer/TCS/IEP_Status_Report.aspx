<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="IEP_Status_Report.aspx.cs" Inherits="PresentationLayer_TCS_IEP_Status_Report" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />

        </Scripts>
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
                  <style type="text/css">
                .btn-custom {
                    padding: 10px 16px;
                    font-size: 11px;
                    height: 34px;
                }

                .table-responsive {
                    overflow-x: initial !important;
                }

                .aspNetDisabled {
                    background-image: -webkit-linear-gradient(top,rgb(213 213 213 / 0.80) 0,rgb(213 213 213 / 80%) 100%) !important;
                    color: #3B5998;
                    cursor: not-allowed !important;
                    pointer-events: none
                }

                .titlesection {
                    height: auto;
                }

                .table {
                    margin-bottom: 0px;
                }

                .RadioButtonWidth label {
                    margin-right: 30px;
                    margin-left: 5px
                }
            </style>
             <script type="text/javascript">

                 Sys.Application.add_init(function () {
                     // Initialization code here, meant to run once.

                     jq(document).ready(document_Ready);

                     function document_Ready() {
                        
                         jq(document).ready(function () {

                             //****************************************************************
                             try {
                                // alert("abc");
                                 $('table.datatable').DataTable({
                                     destroy: true,
                                     "dom": 'Blfrtip',

                                     buttons: [

                                         {
                                             extend: 'excel',
                                             title: 'IEP Teacher And Counselor Count Report'
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
                         //          document_Ready();
                           //         alert('call back done');
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="IEPs Status Summary"></asp:Label>
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
                                            <label class="TextLabelMandatory40">Session </label>
                                            <asp:DropDownList ID="ddl_session" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <%--<td class="col-lg-2 col-md-2 col-xs-10 col-sm-8">
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
                                    </td>--%>
                                    <%--OnSelectedIndexChanged="ddlClass_SelectedIndexChanged"--%>
                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Class </label>
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term"
                                                 Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <%--OnSelectedIndexChanged="ddlterm_SelectedIndexChanged"--%>
                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Term </label>
                                            <asp:DropDownList ID="ddlterm" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term"
                                                 Width="100%">
                                                <asp:ListItem Selected="True" Value="0">
                                                    Select</asp:ListItem>
                                                <asp:ListItem Value="1">First Term</asp:ListItem>
                                                <asp:ListItem Value="2">Second Term</asp:ListItem>

                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                         <div class="col-lg-3">
                        <br />
                                             <%--<i class="fa fa-search"></i>--%>
                        <asp:LinkButton runat="server" ID="btnSearch" ValidationGroup="search" CssClass="btn btn-custom btn-info" OnClick="btnSearch_Click">&nbsp;&nbsp;&nbsp;Show Records</asp:LinkButton>
                    </div>
                                    </td>

                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>

                           
                        </td>
                    </tr>
                </tbody>
            </table>
              <br />
             <div class="container-fluid" style="margin: 0; padding: 0">
                <div class="row">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <label class="titlesection">List</label>
                            <div class="table-responsive">
                                 <asp:GridView ID="Grid_IEPStudents" runat="server" AutoGenerateColumns="false" CssClass="datatable table table-bordered table-condensed"
                                OnPreRender="gv_details_PreRender"  OnRowCommand="Grid_IEPStudents_RowCommand"
                                EmptyDataText="No Record Exists." ShowHeaderWhenEmpty="true">
                                <Columns>
                                    <asp:BoundField DataField="Center_Name" SortExpression="Center_Name" HeaderText="Center Name" ItemStyle-Width="250px"></asp:BoundField>
                                    <asp:BoundField DataField="Class_Name" SortExpression="Class_Name" HeaderText="Class Name" ItemStyle-Width="100px"></asp:BoundField>
                                    <asp:BoundField DataField="Section_Name" SortExpression="Section_Name" HeaderText="Section Name"></asp:BoundField>
                                    <asp:BoundField DataField="Completed_IEPs_Counselor" SortExpression="Completed_IEPs_Counselor" HeaderText=" Completed IEPs(Counselor)"></asp:BoundField>
                                    <asp:BoundField DataField="Incomplete_IEPs_Counselor" SortExpression="Incomplete_IEPs_Counselor" HeaderText=" Incomplete IEPs(Counselor)"></asp:BoundField>
                                    <asp:BoundField DataField="TeacherCompleted" SortExpression="TeacherCompleted" HeaderText=" Completed IEPs (Teachers)"></asp:BoundField>
                                    <asp:BoundField DataField="TeacherInCompleted" SortExpression="TeacherInCompleted" HeaderText=" Incomplete IEPs(Teachers)"></asp:BoundField>
                                   
                                    <%--<asp:BoundField DataField="parentapproved" SortExpression="parentapproved" HeaderText="Parent Approved"></asp:BoundField>--%>
                                   
                                   
                                   
                                   
                                </Columns>
                                <HeaderStyle CssClass="tableheader" />
                            </asp:GridView>
                                 </div>

                        </div>
                    </div>
                </div>
            </div>
           <%-- <script type="text/javascript">
                $(document).ready(function () {

                  //  alert("after");
                    try {
                    $('table.datatable').DataTable({
                        destroy: true,
                        "dom": 'Blfrtip',

                        buttons: [

                            {
                                extend: 'excel',
                                title: 'IEP Teacher And Counselor Count Report'
                            }
                        ],
                        "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                    });
                    }
                    catch (err) {
                     //   alert('datatable ' + err);
                    }

                });
            </script>--%>
        </ContentTemplate>
         <Triggers>
            <asp:PostBackTrigger ControlID="btnSearch" />
        </Triggers>
    </asp:UpdatePanel>
       <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="5000" AssociatedUpdatePanelID="UpdatePanel1" Visible="true">
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
