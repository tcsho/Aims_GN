<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="frmCentury.aspx.cs" Inherits="PresentationLayer_frmCentury" %>

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
                                jq('table.datatable').DataTable();

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Century Data  Extract & Upload"></asp:Label>
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
                            <div class="row">
                                <div class="col-lg-6 ">
                                    <div class="col-lg-12">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <div class="form-group field-customer-customer_name required ">
                                                    <asp:RadioButtonList ID="RadioListST" runat="server" RepeatDirection="Horizontal"
                                                        RepeatLayout="Flow" Font-Bold="true" AutoPostBack="true" OnSelectedIndexChanged="RadioListST_SelectedIndexChanged">
                                                        <asp:ListItem Value="S" Style="margin-right: 8px;">Student Data</asp:ListItem>
                                                        <asp:ListItem Value="T" Style="margin-right: 8px;">Teacher Data</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                    <hr />
                                                    <div class="help-block"></div>
                                                </div>
                                            </div>

                                            <div class="col-md-12" id="Div1" runat="server">
                                                <div class="form-group field-customer-customer_name required">
                                                    <asp:Label ID="lblHead" CssClass="lblFormHead" runat="server" Text=""></asp:Label>
                                                </div>
                                            </div>

                                            <div class="col-md-12" id="trTeacher" runat="server" visible="false">
                                                <div class="form-group field-customer-customer_name required">
                                                    <label>
                                                        Teacher Upload File columns:<small class="m-l-sm">
                                                            <b>Email Address,Employee ID</b></small></label>
                                                    <asp:FileUpload ID="FL_SD" runat="server" CssClass="form-control" aria-label="files" ClientIDMode="Static" />
                                                    <span class="pull-right">
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="FL_SD" CssClass="label label-danger" ErrorMessage="Required" SetFocusOnError="True" ValidationGroup="Upload"></asp:RequiredFieldValidator></span>
                                                </div>
                                            </div>
                                            <div class="col-md-12" id="TrSession" runat="server" visible="false">
                                                <div class="form-group field-customer-customer_name required">
                                                    <label>Select Session</label><span class="pull-right"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlSession" CssClass="label label-danger" ErrorMessage="Required" InitialValue="0" SetFocusOnError="True" ValidationGroup="Download"></asp:RequiredFieldValidator></span>
                                                    <asp:DropDownList ID="ddlSession" Enabled="false" runat="server" CssClass="form-control select2">
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div class="col-md-12" id="tdFormat" runat="server" visible="false">
                                                <div class="form-group field-customer-customer_name required">
                                                    <label>Select Format</label><span class="pull-right"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlFormat" CssClass="label label-danger" ErrorMessage="Required" InitialValue="0" SetFocusOnError="True" ValidationGroup="Download"></asp:RequiredFieldValidator></span>
                                                    <asp:DropDownList ID="ddlFormat" runat="server" CssClass="form-control select2">
                                                        <asp:ListItem Value="0">Select</asp:ListItem>
                                                        <asp:ListItem Value="Excel">Excel Format</asp:ListItem>
                                                        <asp:ListItem Value="CSV">CSV Format</asp:ListItem>
                                                    </asp:DropDownList>
                                                    <hr />
                                                </div>
                                            </div>
                                        </div>
                                    </div>

                                    <div class="col-lg-12">
                                        <asp:Button ID="BtnUpload" runat="server" Text="Upload" CssClass="btn btn-primary" Visible="false" ValidationGroup="Upload" OnClick="BtnUpload_Click" />
                                        <asp:Button ID="btnsubmitfile" runat="server" Text="Submit File" CssClass="btn btn-primary" Visible="false" OnClick="btnsubmitfile_Click" />
                                        <asp:Button ID="btnRolBack" runat="server" Text="Roll Back" CssClass="btn btn-primary" Visible="false" OnClick="btnRolBack_Click" />
                                        <asp:Button ID="btnDownload" runat="server" Text="Download File" CssClass="btn btn-primary" Visible="false" ValidationGroup="Download" OnClick="btnDownload_Click" />
                                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="btn btn-primary" OnClick="btnReset_Click" Visible="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <br />
                        <div>
                            <table>
                                <tr id="trSetupStudent" runat="server" visible="false">
                                    <td style="font-size: medium; font-weight: bold" colspan="2">Step 1: Select Download File Button.
                           
                                                            <br />

                                    </td>
                                </tr>
                                <tr id="trSetupTeacher" runat="server" visible="false">
                                    <td style="font-size: medium; font-weight: bold" colspan="2">
                                        Step 1: Browse teacher upload excel file from local computer.
                           
                                                            <br />
                                        Step 2: Click on "Upload" button.
                           
                                                            <br />
                                        Step 3: After verification of data, click on "Submit File" button.
                                        <br />
                                                                           
                                        Step 4: Select Download File Button.
                            </td>
                                </tr>
                            </table>
                        </div>
                        <br />
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridDataSummary" visible="false">
                            Data Summary 
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                            <br />
                            <asp:GridView ID="GV_Summary" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                CssClass="datatable table table-striped table-responsive" OnPreRender="GV_Summary_PreRender">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Sr. #">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Font-Size="14px" Width="20px" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="ExtractDate" HeaderText="Extact Date" />
                                    <asp:BoundField DataField="Rec" HeaderText="Total Records" />
                                </Columns>
                                <SelectedRowStyle BackColor="PaleGoldenrod" />
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                            </asp:GridView>
                        </div>
                        <br />
                        <div id="tbMainGV" runat="server" visible="false">
                         <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" >
                            Preview Data 
                        </div>
      <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                            <br />
                            <asp:GridView ID="GV_Teacher" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                CssClass="datatable table table-striped table-responsive" OnPreRender="GV_Teacher_PreRender">
                                <AlternatingRowStyle CssClass="tr2" />
                               <Columns>
                                                <asp:TemplateField HeaderText="S.No" ItemStyle-HorizontalAlign="Center" HeaderStyle-HorizontalAlign="Center" HeaderStyle-Width="5px">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle CssClass="" HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemStyle CssClass="" HorizontalAlign="Center"></ItemStyle>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Email Address" HeaderText="Email Address" />
                                                <asp:BoundField DataField="Employee ID" HeaderText="Employee ID" />
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
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnDownload" />
            <asp:PostBackTrigger ControlID="BtnUpload" />
        </Triggers>
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


