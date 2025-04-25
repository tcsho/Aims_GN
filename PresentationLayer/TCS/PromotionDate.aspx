<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="PromotionDate.aspx.cs" Inherits="PresentationLayer_TCS_PromotionDate" %>

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
            <script type="text/javascript">
                Sys.Application.add_init(function () {
                    // Initialization code here, meant to run once.
                    jq(document).ready(document_Ready);
                    function document_Ready() {
                        jq(document).ready(function () {
                            //****************************************************************
                            try {
                                $('#select-all').click(function (event) {
                                    if (this.checked) {
                                        // Iterate each checkbox
                                        $(':checkbox').each(function () {
                                            this.checked = true;
                                        });
                                    } else {
                                        $(':checkbox').each(function () {
                                            this.checked = false;
                                        });
                                    }
                                });
                               
                                $('table.datatable').DataTable({
                                    destroy: true,
                                    "dom": 'Blfrtip',
                                    
                                    buttons: [
                                        {
                                            extend: 'excel',
                                            exportOptions: {
                                                columns: [0, 2, 3, 4]
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
            </script>


            <div class="form-group">
                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Promotion Date Setup"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <p>
                    <br />
                </p>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:Button ID="btnIssuanceSubmit" CssClass="btn btn-primary pull-right btn-xs" runat="server" Text="Add Promotion Date" OnClick="btnSubmit_Click"></asp:Button>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblsession" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Session: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"  OnSelectedIndexChanged="ddlSession_SelectedIndexChanged"
                                    Width="218px" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="ResultIssue" runat="server">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        <h3 class="titlesection">Promotion Date</h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " style="margin-top: 30px">
                        <asp:GridView ID="gv_IssuanceDate" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            DataKeyNames="SP_ID"
                            CssClass="datatable table table-striped table-responsive" OnPreRender="gvIssuanceDate_PreRender">
                            <AlternatingRowStyle CssClass="tr2" />
                            <Columns>
                                <asp:BoundField DataField="SP_ID" HeaderText="Id">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Session_name" HeaderText="Session">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
      
                                <asp:BoundField DataField="PromotionDate" HeaderText="Promotion Date">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>      
                                 <asp:BoundField DataField="STATUS" HeaderText="Status">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
     
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Button runat="server" CssClass="btn-sm btn-primary btn-xs" CommandArgument='<%#Eval("SP_ID") + ";" +Eval("PromotionDate")+ ";" +Eval("Session_Id")%>' OnClick="btnSubmit_Click" Text="Update" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <SelectedRowStyle BackColor="PaleGoldenrod" />
                            <RowStyle CssClass="tr1" />
                            <HeaderStyle CssClass="tableheader" />
                            <AlternatingRowStyle CssClass="tr2" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>





    <%--Bootstrap model--%>
    <div class="modal fade" id="myModal" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
        <div class="modal-dialog">
            <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                <ContentTemplate>
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                            <h4 class="modal-title">
                                <asp:Label ID="lblModalTitle" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <label>Session</label>
                                    <asp:DropDownList ID="ddl_Session" Enabled="false" runat="server" AutoPostBack="True" CssClass="form-control"> </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddl_Session" InitialValue="select" ErrorMessage="Please select Group " />

                                </div>
                            </div>
                            <div class="row">
             
                                <div class="col-md-6">
                                    <label>Promotion Date</label>
                                    <asp:TextBox ID="txtFrmDate" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Date is required."
                                        ControlToValidate="txtFrmDate" ForeColor="red" ValidationGroup="test"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    
                                </div>
                            </div>
                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info pull-left" data-dismiss="modal" aria-hidden="true">Close</button>
                            <asp:Button ID="btnAddIssuanceDate" OnClick="AddIssuanceDate" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>






