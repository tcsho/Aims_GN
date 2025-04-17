<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="frmERPPayStudent.aspx.cs" Inherits="PresentationLayer_frmERPPayStudent" %>

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
                                            exportOptions: {
                                                columns: [1, 2, 3, 4, 5, 6, 7, 8, 9]
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

                        });

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
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="left"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student Paid ERP Status"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="ibox-content">
                <div class="panel panel-info" style="width: 100%">
                    <div class="panel-body">
                        <div class="container">
                            <div id="tbMainGV" runat="server">
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server">
                                    Student list
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                    <br />
                                    <asp:GridView ID="GV_Student" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-responsive" OnPreRender="GV_Student_PreRender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5px">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="ROLL_NUMBER" HeaderText="Student ID" />
                                            <asp:BoundField DataField="STUDENT_NAME" HeaderText="Student Name" />
                                            <asp:BoundField DataField="PARENT_CLASS" HeaderText="Class Name" />
                                            <asp:BoundField DataField="BRANCH" HeaderText="Center Name" />
                                            <asp:BoundField DataField="INV_NO" HeaderText="In Voice" />
                                            <asp:BoundField DataField="CHALLAN_ISSUE_DATE" HeaderText="Challan Issue Date" />
                                            <asp:BoundField DataField="REC_DATE" HeaderText="Received Date" />
                                            <asp:BoundField DataField="PERIOD_NAME" HeaderText="Period Name" />
                                            <asp:BoundField DataField="Status" HeaderText="Status" />
                                        </Columns>
                                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </div>

                            </div>

                        </div>
                    </div>
                </div>
            </div>
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


