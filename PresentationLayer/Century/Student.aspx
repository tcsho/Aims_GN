<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="Student.aspx.cs" Inherits="PresentationLayer_Century_Student" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <script type="text/javascript">

                $(function () {
                    initdropdown();
                })
                function initdropdown() {
                    $('.selectpicker').selectpicker();

                    $('table.datatable').DataTable({
                        destroy: true,
                        dom: 'Blfrtip'
                    });

                }
                function pageLoad(sender, args) {
                    initdropdown();
                }
                Sys.Application.add_load(initdropdown);


            </script>


            <br />
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="left"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width="0.5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Century Student Details"></asp:Label>
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
            <div class="row">
                <asp:Label runat="server" ID="lblMessage"></asp:Label>
            </div>
            <div class="row" style="margin-top: 10px">
                <div class="col-lg-1">
                    <h4>Center:</h4>
                </div>
                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:DropDownList runat="server" ID="ddl_CenturyCenter" CssClass="form-control selectpicker" Style="min-width: 400px; max-width: 400px" data-live-search="true">
                        </asp:DropDownList>
                    </div>
                </div>

                <div class="col-lg-4">
                    <div class="form-group">
                        <asp:Button runat="server" CssClass="btn btn-primary" Style="width: 100px" ID="btnSearch" Text="Search" OnClick="btnSearch_Click" />
                    </div>
                </div>
            </div>
            <div class="ibox-content" style="margin-top: 100px">
                <div class="panel panel-info" style="width: 100%">
                    <div class="panel-body">
                        <div id="tbMainGV" runat="server">
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server">
                                Student list
                            </div>
                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                                <br />
                                <div class="table-responsive">
                                    <asp:GridView ID="GV_Student" runat="server" BorderStyle="None" OnRowDataBound="GV_Student_RowDataBound"
                                        CssClass="datatable table table-striped">
                                        <AlternatingRowStyle CssClass="tr2" />
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
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="100px"
                    Width="100px" />
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>

