<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/PresentationLayer/MasterPage.master" CodeFile="Studentzeromarksandatt.aspx.cs" Inherits="PresentationLayer_TCS_Studentzeromarksandatt" %>


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
                                            title: 'Absent in Exam or Mark 0'
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Absent in Exam or Mark 0"></asp:Label>
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
                            <table cellspacing="0" cellpadding="0"
                                border="0" width="100%">
                                <tr class="row">

                                    <asp:label runat="server" ID="lblmsg" foreColor="Red"></asp:label>
                                    <td class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Region* </label>
                                            <asp:DropDownList ID="ddl_region" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="ddl_region_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>

                                    <td class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">School </label>
                                            <asp:DropDownList ID="ddl_center" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="ddl_center_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>
                                    <td class="col-lg-3 col-md-3 col-sm-6 col-xs-12">

                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Session* </label>
                                            <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="100%">
                                            </asp:DropDownList>
                                        </div>


                                    </td>

                                    <td class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                        <div class="form-group">
                                            <label class="TextLabelMandatory40">Term* </label>
                                            <asp:DropDownList ID="ddlterm" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                                OnSelectedIndexChanged="ddlterm_SelectedIndexChanged" Width="100%">
                                                <asp:ListItem Value="0" Selected="True">Please Select</asp:ListItem>
                                                <asp:ListItem Value="1">First Term </asp:ListItem>
                                                <asp:ListItem Value="2">Second Term</asp:ListItem>
                                                 <asp:ListItem Value="3">Mock</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>

                                    </td>
                                        <td class="col-lg-3 col-md-3 col-sm-6 col-xs-12">
                                        <div class="form-group">
                                            <label runat="server" visible="false" class="">button</label>
                                          <asp:Button  runat="server" id="btnsearch" CssClass="form-control" OnClick="btnsearch_Click" Text="Search" style="margin-top: 28px;" />
                                        </div>

                                    </td>
                                    <%--     <td class="col-lg-2 col-md-2 col-xs-10 col-sm-10">
                                        <div class="form-group" >
                                            <label class="TextLabelMandatory40">Class </label>
                                            <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control list_Term" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged1"
                                                Width="100%">
                                            </asp:DropDownList>
                                        </div>
                                    </td>--%>
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:GridView ID="Grid_IEPStudents" runat="server" AutoGenerateColumns="false" CssClass="datatable table table-bordered table-condensed"
                                OnPreRender="gv_details_PreRender" OnRowDataBound="Grid_IEPStudents_RowDataBound">
                                <Columns>

                                    <asp:BoundField DataField="region_name" SortExpression="region_name" HeaderText="Region Name"></asp:BoundField>
                                    <asp:BoundField DataField="Campus" SortExpression="Campus" HeaderText="Campus"></asp:BoundField>
                                    <asp:BoundField DataField="Class" SortExpression="Class" HeaderText="Class"></asp:BoundField>
                                    <asp:BoundField DataField="Section" SortExpression="Section" HeaderText="Section"></asp:BoundField>
                                    <asp:BoundField DataField="studentname" SortExpression="studentname" HeaderText="Student Name"></asp:BoundField>
                                    <asp:BoundField DataField="Student_Id" SortExpression="Student_Id" HeaderText="Student Id"></asp:BoundField>
                                    <asp:BoundField DataField="subject" SortExpression="subject" HeaderText="subject"></asp:BoundField>
                                    <asp:BoundField DataField="criteria" SortExpression="criteria" HeaderText="criteria"></asp:BoundField>
                                    <asp:BoundField DataField="Marks" SortExpression="Marks" HeaderText="Marks"></asp:BoundField>
                                    <asp:BoundField DataField="Absent" SortExpression="Absent" HeaderText="Absent"></asp:BoundField>
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

