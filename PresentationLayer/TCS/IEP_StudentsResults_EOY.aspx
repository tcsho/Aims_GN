<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="IEP_StudentsResults_EOY.aspx.cs" Inherits="PresentationLayer_TCS_IEP_StudentsResults_EOY" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />

        </Scripts>
    </cc1:ToolkitScriptManager>
    <%--   <style>
        .hide {
            display: none;
        }
    </style>--%>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>

         <%--   <script type="text/javascript">

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
                                            exportOptions: {
                                                columns: [6]
                                            }
                                        }
                                    ],
                                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                });
                            }
                            catch (err) {
                                alert('datatable ' + err);
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
            </script>--%>

            <div class="form-group formheading">
                <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Result  Winter Campus-(EOY)"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <p>
                <br />
            </p>

            <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 form-group ">


                <asp:Label ID="Label3" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                    Text="Session : "></asp:Label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                        Width="218px">
                    </asp:DropDownList>
                </div>
                <asp:Label ID="Label2" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                    Text="Term : "></asp:Label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlTerm" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" AutoPostBack="true"
                        Width="250px">
                    </asp:DropDownList>
                </div>
                <asp:Label ID="Label4" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabel40"
                    Text="Report Name : "></asp:Label>
                <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                    <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlrptname" OnSelectedIndexChanged="ddlrptname_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Value="1" Selected="True">Student Result  Winter Campus-(EOY)</asp:ListItem>
                        <asp:ListItem Value="2">Student Result-(EOY)</asp:ListItem>
                    </asp:DropDownList>
                </div>

            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Label runat="server" ID="lblGridStatus" CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 TextLabelMandatory40 text-left"
                    ForeColor="Red" Text="">    </asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection"
                    colspan="7" visible="false">
                    &nbsp; List of Expelled Students
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="Grid_IEPStudents" runat="server" AutoGenerateColumns="false" OnRowCommand="Grid_IEPStudents_RowCommand" CssClass="datatable table table-bordered table-condensed"
                    OnPreRender="gv_details_PreRender"
                    EmptyDataText="No Record Exists." ShowHeaderWhenEmpty="true">
                    <Columns>
                        <%--<asp:BoundField HeaderText="Section" DataField="section_id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />--%>

                        <asp:BoundField HeaderText="Region Name" DataField="Region_Name" />
                        <asp:BoundField HeaderText="Center Name" DataField="Center_Name" />
                        <asp:BoundField HeaderText="Class Name" DataField="Class_Name" />
                        <asp:BoundField HeaderText="Section Name" DataField="Section_Name" />
                        <asp:BoundField HeaderText="Student Id" DataField="Student_ID" />
                        <asp:BoundField HeaderText="Student Name" DataField="StudentName" />

                    </Columns>
                    <HeaderStyle CssClass="tableheader" />
                </asp:GridView>
            </div>





            <%--   <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>

                                        <td id="tdFrmHeading" class="formheading">

                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Result  Winter Campus-(EOY)"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>


                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 13px" class="leftlink" align="right"></td>
                    </tr>

                 
                    <tr>
                        <td style="height: 13px" class="leftlink" align="right"></td>
                    </tr>
                    <tr>

                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                <div class="pull-right">
                                    <asp:Label ID="Label3" CssClass="TextLabelMandatory40" Text="Session: " runat="server"> </asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlSession" AutoPostBack="true"
                                    Width="250px">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                            </div>
                        </div>

                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                <div class="pull-right">
                                    <asp:Label ID="Label2" CssClass="TextLabelMandatory40" Text="Term: " runat="server"> </asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlTerm" OnSelectedIndexChanged="ddlTerm_SelectedIndexChanged" AutoPostBack="true"
                                    Width="250px">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                <div class="pull-right">
                                    <asp:Label ID="Label4" CssClass="TextLabelMandatory40" Text="Report Name: " runat="server"> </asp:Label>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlrptname" OnSelectedIndexChanged="ddlrptname_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="1" Selected="True">Student Result  Winter Campus-(EOY)</asp:ListItem>
                                    <asp:ListItem Value="2">Student Result-(EOY)</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                            </div>
                        </div>
                    </tr>
                 
                    <tr>

                        <asp:GridView ID="Grid_IEPStudents" runat="server" AutoGenerateColumns="false" OnRowCommand="Grid_IEPStudents_RowCommand" CssClass="datatable table table-bordered table-condensed"
                            OnPreRender="gv_details_PreRender"
                            EmptyDataText="No Record Exists." ShowHeaderWhenEmpty="true">
                            <Columns>
                                <%--<asp:BoundField HeaderText="Section" DataField="section_id" HeaderStyle-CssClass="hide" ItemStyle-CssClass="hide" />

                                <asp:BoundField HeaderText="Region Name" DataField="Region_Name" />
                                <asp:BoundField HeaderText="Center Name" DataField="Center_Name" />
                                <asp:BoundField HeaderText="Class Name" DataField="Class_Name" />
                                <asp:BoundField HeaderText="Section Name" DataField="Section_Name" />
                                <asp:BoundField HeaderText="Student Id" DataField="Student_ID" />
                                <asp:BoundField HeaderText="Student Name" DataField="StudentName" />

                            </Columns>
                            <HeaderStyle CssClass="tableheader" />
                        </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>--%>
            <script type="text/javascript">
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
                        "lengthMenu": [[10, 25, 50], [10, 25, 50]],
                    });

                });
            </script>
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
