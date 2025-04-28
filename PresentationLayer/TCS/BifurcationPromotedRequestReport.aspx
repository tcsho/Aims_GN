<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="BifurcationPromotedRequestReport.aspx.cs"
    Inherits="PresentationLayer_BifurcationPromotedRequestReport" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Always">
        <ContentTemplate>
            <style type="text/css">
                .form-check-input tbody tr td input[type=radio] {
                    margin: 4px 7px 0;
                    height: 15px;
                    width: 15px;
                }

                .form-check-input tbody tr td label {
                    position: relative;
                    top: -2px;
                }
            </style>

            <script type="text/javascript">
                function openModal() {
                    //                    $('#myModal').modal('show');
                    $('#myModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModal() {

                    $('#myModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
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
                                            title: 'List of Bifurcated Students'
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
                        <td>
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="List of Bifurcated Students"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr id="tr4" runat="server">
                                    <td style="width: 37%;"></td>
                                    <td style="width: 50%;"></td>
                                </tr>
                                <tr id="trRegion" runat="server">
                                    <td class="TextLabelMandatory40" style="width: 37%;">Region*:
                                    </td>
                                    <td valign="top" style="width: 50%;">
                                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="218px"
                                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
                                        </asp:DropDownList>
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click"
                                            Text="Detained Students" Visible=" false"></asp:Button>
                                        <asp:Button ID="btnShow" runat="server" CssClass="btn btn-warning" OnClick="btnShowSubmitted_Click"
                                            Text="Discretionary Requests" Visible=" false"></asp:Button>
                                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-success" OnClick="btnProcessed_Click"
                                            Text="Action Taken By RD" Visible=" false"></asp:Button>
                                        <br />
                                    </td>
                                    <td valign="top" align="right"></td>
                                </tr>
                                <tr id="trCenter" runat="server" style="width: 50%;">
                                    <td align="right" class="TextLabelMandatory40" style="width: 37%">Center*:
                                    </td>
                                    <td valign="top" style="width: 50%;">
                                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="218px"
                                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                                        </asp:DropDownList>
                                        <asp:Button ID="btnShowAll" runat="server" CssClass="btn btn-info" Text="Show All Records"
                                            Width="450px" OnClick="btnShowAll_Click"></asp:Button>
                                    </td>
                                    <td align="right" valign="top"></td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabelMandatory40" style="width: 37%">Session*:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabel40" style="width: 37%">Class:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" class="TextLabel40" style="width: 37%">Term:
                                    </td>
                                    <td align="left" style="width: 60%">
                                        <asp:DropDownList ID="ddlterm" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlterm_SelectedIndexChanged" Width="218px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 37%;">&nbsp;
                                    </td>
                                    <td align="left" style="width: 60%">&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%"></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="12">
                                        <asp:Button ID="btnViewReport" runat="server" class="button" OnClick="btnViewReport_Click"
                                            Text="View Report" ValidationGroup="s" Visible="False" Width="96px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="12">
                                        <asp:Label runat="server" ID="lblGridStatus" CssClass="TextLabelMandatory40" ForeColor="Red"
                                            Text="">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td id="tdSearch" runat="server" class="titlesection" colspan="7" visible="false">&nbsp; List of Bifurcated Students
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="12">
                                        <p>
                                        </p>
                                    </td>
                                </tr>
                                <tr id="Tr3" runat="server" style="width: 100%">
                                    <td style="width: 100%">
                                        <asp:GridView ID="gv_details" runat="server" DataKeyNames="student_id" CssClass="datatable table table-striped table-bordered table-hover"
                                            AutoGenerateColumns="False" AllowPaging="false" OnPreRender="gv_details_PreRender1">
                                            <Columns>


                                                <asp:BoundField DataField="Student_No" HeaderText="Student No">
                                                    <%--2--%>
                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                                                    <%--3--%>
                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Region_Name" HeaderText="Region">
                                                    <%--5--%>
                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                                    <%--6--%>
                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Class_Name1" HeaderText="Class">
                                                    <%--7--%>
                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                                    <%--11--%>
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>



                                                <asp:BoundField DataField="DaysPresent" HeaderText="Days Present">

                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>
                                                                                                <asp:TemplateField HeaderText="Email Sent">
                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
<ItemStyle Font-Size="14px" />
            <ItemTemplate>
                <%# Eval("Status").ToString() == "1" ? "Yes" : "No" %>
            </ItemTemplate>
        </asp:TemplateField>
                                                <%--<asp:BoundField DataField="EmailSent" HeaderText="Email Sent">

                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>--%>
                                                <asp:BoundField DataField="Acknowledgement" HeaderText="Parent Acknowledgement">

                                                    <HeaderStyle HorizontalAlign="Center" Font-Size="14px" ForeColor="Black" />
                                                    <ItemStyle Font-Size="14px" />
                                                </asp:BoundField>

                                            </Columns>
                                            <SelectedRowStyle ForeColor="SlateGray" />
                                            <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                                            <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                            <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr runat="server" style="width: 100%">
                                    <td style="width: 100%"></td>
                                </tr>
                                <tr id="btns" runat="server" visible="false">
                                    <td colspan="3" style="height: 6px; text-align: center;">&nbsp;
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr id="trButtons" runat="server" aliign="center" style="width: 100%">
                                    <td align="center" style="height: 19px; text-align: center">&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>

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

