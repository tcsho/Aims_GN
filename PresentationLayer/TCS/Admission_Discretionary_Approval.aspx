<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Admission_Discretionary_Approval.aspx.cs" Inherits="PresentationLayer_TCS_Admission_Discretionary_Approval" %>

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
                function closeModal() {

                    $('#ApprovalModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
                function openModal() {

                    $('#ApprovalModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });

                }
            </script>
             <script type="text/javascript">
                 $(document).ready(function () {

                     $('table.datatable').DataTable({
                         "dom": "Bflrtip",
                         "buttons": [
                            'copyHtml5',
                            'excelHtml5',
                            'csvHtml5',
                            'pdfHtml5'
                        ],
                         "lengthMenu": [[10, 25, 50, 100, -1], [10, 25, 50, 100, "All"]],
                         "order": [[1, "asc"]],
                         // "columnDefs": [{ bSortable: false, targets: [7]}], //disable sorting on toggle button
                         "iDisplayLength": 25,
                         "paging": true, "ordering": false, "searching": true, "info": false, "scrollX": false

                     });

                 }); //end of documnet_ready()
         
    </script>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <br />
            </div>
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Admission Discretionary Approval"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <br />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="row">
                    <br />
                    <asp:Label ID="lblregion" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-12 TextLabelMandatory40"
                        Text="Region : "></asp:Label>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="250px"
                            OnSelectedIndexChanged="ddl_region_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <asp:Label ID="lblcenter" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-12 TextLabelMandatory40"
                        Text="Center : "></asp:Label>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="250px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <asp:Label ID="lblClass" runat="server" CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-12 TextLabelMandatory40"
                        Text="*Class: "></asp:Label>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            Width="250px" OnSelectedIndexChanged="ddl_Class_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="row">
                    <br />
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection"
                    visible="false">
                    &nbsp; Discretionary Admission Requests
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvApproval" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                    CssClass="datatable table table-striped table-responsive" OnPreRender="gvApproval_PreRender">
                    <AlternatingRowStyle CssClass="tr2" />
                    <Columns>
                        <asp:BoundField DataField="Registration_Id" HeaderText="Registration Number" SortExpression="Registration_Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class_Name">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="ResultDetail" HeaderText="Result Detail">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Heads_Remarks" HeaderText="Heaad Remarks">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                         
                        <asp:TemplateField HeaderText="List of Students">
                            <ItemStyle HorizontalAlign="Center" Width="100%" />
                            <ItemTemplate>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Registration # :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Registration_Id")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Student Name :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("StudentName")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Center
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Center_Name")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Class:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Class_Name")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Procedure/ Promotion Criteria:
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("ResultStatus")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        School Head Remarks :
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Heads_Remarks")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        Network Head Remarks :
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("NH_Remarks")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-right">
                                        <asp:LinkButton runat="server" ID="LinkButton1" Visible='<%# (int)( Eval("NH_Approval"))==1  %>'>
                                         <span  class="glyphicon glyphicon-ok-circle" style="color:green;"></span>
                                        </asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="LinkButton2" Visible='<%# (int)( Eval("NH_Approval"))==0%>'>
                                            <span  class="glyphicon glyphicon-remove-circle" style="color:red;"></span>
                                        </asp:LinkButton>
                                        <%--    <asp:LinkButton runat="server" ID="LinkButton3" Visible='<%# (int)( Eval("NH_Approval"))==2%>' >
                                            <img src="../../images/pending.png" height="25px" width="25px" />
                                        </asp:LinkButton>--%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-right">
                                        <asp:LinkButton runat="server" ID="btnAction" Text="Proceed" CssClass="btn btn-warning"
                                            Visible='<%# (int)( Eval("NH_Approval"))==2 && ((int)( Eval("User_Type"))==31 || (int)( Eval("User_Type"))==1 )%>'
                                            OnClick="btnProceed_Click">
                                        </asp:LinkButton>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Wrap="true" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
            </div>
            <div id="ApprovalModal" class="modal fade" role="dialog">
                <div class="modal-dialog">
                    <!-- Modal content-->
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal">
                                &times;</button>
                            <h4 class="modal-title">
                                Discretionary Admission Request</h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 text-left">
                                    <asp:Label ID="lblReg" runat="server" Visible="false"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                                <asp:Label ID="Label4" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text="Student Name : "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:Label ID="lblStdName" runat="server" CssClass="TextLabelMandatory40"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                                <asp:Label ID="Label5" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text="Result Detail : "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:Label ID="lblResultDetail" runat="server" CssClass="TextLabelMandatory40"></asp:Label>
                                </div>
                            </div>
                            <div class="row">
                                <br />
                                <asp:Label ID="Label6" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text="Remarks: "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:Label runat="server" ID="lblHRemarks" CssClass="TextLabelMandatory40"></asp:Label>
                                </div>
                            </div>
                            <div id="Div1" class="row" runat="server">
                                <br />
                                <asp:Label ID="Label1" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text=" "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:RadioButtonList runat="server" ID="rblApproval">
                                        <asp:ListItem Value="True" Text="Approve"></asp:ListItem>
                                        <asp:ListItem Value="False" Text="Disapprove"></asp:ListItem>
                                    </asp:RadioButtonList>
                                    <asp:RequiredFieldValidator runat="server" ID="check" Display="Dynamic" ControlToValidate="rblApproval"
                                        ErrorMessage="Please select an option" ValidationGroup="a"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row" runat="server">
                                <br />
                                <asp:Label ID="Label7" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40"
                                    Text="Network Head Remarks: "></asp:Label>
                                <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 text-left">
                                    <asp:TextBox ID="txtNHRemarks" runat="server" CssClass="form-control textbox" TextMode="MultiLine"
                                        Rows="5"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Remarks are Compulsory"
                                        ControlToValidate="txtNHRemarks" Display="Dynamic" ValidationGroup="a"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Maximum of 500 characters allowed"
                                        ControlToValidate="txtNHRemarks" Display="Dynamic" ValidationExpression=".{0,500}"
                                        ValidationGroup="a" />
                                </div>
                            </div>
                            <div class="row">
                                <br />
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" ID="btnSaveReq" Text="Save" CssClass="btn btn-primary"
                                    CausesValidation="true" ValidationGroup="a" OnClick="btnUpdate_Click" />
                                <button type="button" class="btn btn-default" data-dismiss="modal">
                                    Close</button>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
