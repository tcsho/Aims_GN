<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="ResultIssuanceDate.aspx.cs" Inherits="PresentationLayer_TCS_ResultIssuanceDate" %>

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
                                //jq('table.datatable').DataTable({
                                //    destroy: true,
                                //    // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok
                                //    //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                //    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                //        "<'row'<'col-sm-12'tr>>" +
                                //        //                     "<'row'<'col-sm-12'l>>" +
                                //        "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                //    "columnDefs": [

                                //        //{ orderable: false, targets: [8]} //disable sorting on toggle button
                                //    ],
                                //    tableTools:
                                //        { //Start of tableTools collection
                                //            "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                //            "aButtons":
                                //                [ //start of button main/master collection
                                //                    { // ******************* Start of child collection for export button
                                //                        "sExtends": "collection",
                                //                        "sButtonText": "<span class='glyphicon glyphicon-export'></span>",
                                //                        "sToolTip": "Export Data",
                                //                        "aButtons":
                                //                            [ //start of button export buttons collection

                                //                                // ******************* Start of copy button
                                //                                {
                                //                                    "sExtends": "copy",
                                //                                    "sButtonText": "<span class='glyphicon glyphicon-copy'></span> Copy Contents",
                                //                                    "sToolTip": "Copy Data"
                                //                                    , "mColumns": [1, 2, 3, 4, 5, 6]
                                //                                } // ******************* end of copy button

                                //                                // ******************* Start of csv button
                                //                                , {
                                //                                    'sExtends': 'csv',
                                //                                    'bShowAll': false // ,'sFileName': "DataInCSVFormat.csv"
                                //                                    ,
                                //                                    "sFileName": "DataInCSVFormat - *.csv",
                                //                                    "sToolTip": "Save as CSV",
                                //                                    //'sButtonText': 'Save as CSV',
                                //                                    "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
                                //                                    "sNewLine": "auto"
                                //                                    , "mColumns": [1, 2, 3, 4, 5, 6]
                                //                                }  // ******************* end of csv button

                                //                                // ******************* Start of excel button
                                //                                , {
                                //                                    'sExtends': 'xls',
                                //                                    'bShowAll': false,
                                //                                    "sFileName": "DataInExcelFormat.xls",
                                //                                    //'sButtonText': 'Save to Excel',
                                //                                    "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                                //                                    "sToolTip": "Save as Excel"
                                //                                    , "mColumns": [1, 2, 3, 4, 5, 6]
                                //                                }  // ******************* End of excel button


                                //                                // ******************* Start of PDF button
                                //                                , {
                                //                                    'sExtends': "pdf",
                                //                                    'bShowAll': false,
                                //                                    "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                                //                                    //'sButtonText': 'Save to PDF',
                                //                                    "sFileName": "DataInPDFFormat.pdf",
                                //                                    "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                                //                                    , "mColumns": [1, 2, 3, 4, 5, 6]
                                //                                    //,"sPdfMessage": "Your custom message would go here."
                                //                                } // *********************  End of PDF button 

                                //                            ]// ******************* end of Export buttons collection
                                //                    }    // ******************* end of child of export buttons collection
                                //                ] // ******************* end of button master Collection
                                //        } // ******************* end of tableTools
                                //    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
                                //    , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": true
                                //    , //--- Dynamic Language---------
                                //    "oLanguage": {
                                //        "sZeroRecords": "There are no Records that match your search critera",
                                //        //                    "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
                                //        "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                                //        "sInfoEmpty": "Showing 0 to 0 of 0 records",
                                //        "sInfoFiltered": "(filtered from _MAX_ total records)",
                                //        "sEmptyTable": 'No Rows to Display.....!',
                                //        "sSearch": "Search :"
                                //    }
                                //}
                                //);
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
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Result Issuance Date Setup"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <p>
                    <br />
                </p>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:Button ID="btnIssuanceSubmit" CssClass="btn btn-primary pull-right btn-xs" runat="server" Text="Add Result Date" OnClick="btnSubmit_Click"></asp:Button>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblsession" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Session: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist" 
                                    Width="218px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label7" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Term: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList runat="server" AutoPostBack="true" ID="dllTerm" CssClass="dropdownlist" Width="218px" OnSelectedIndexChanged="ddlTermGroup_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
                <div id="ResultIssue" runat="server">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        <h3 class="titlesection">Result Issuance Dates</h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " style="margin-top: 30px">
                        <asp:GridView ID="gv_IssuanceDate" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            OnRowDeleting="OnRowDeleting" DataKeyNames="ResultIssueDateId"
                            CssClass="datatable table table-striped table-responsive" OnPreRender="gvIssuanceDate_PreRender">
                            <AlternatingRowStyle CssClass="tr2" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="ResultIssueDateId" HeaderText="Id">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ClassGroupName" HeaderText="Class Group">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ResultDesc" HeaderText="Description">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ResultDate" HeaderText="ResultDate" DataFormatString="{0:dd/MM/yyyy}">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="ClassGroupId" HeaderText="ResultDate">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="200px">
                                    <ItemTemplate>
                                        <asp:Button runat="server" CssClass="btn-sm btn-danger btn-xs" Text="Delete" CommandName="Delete" OnRowDataBound="OnRowDataBound" />
                                        <asp:Button runat="server" CssClass="btn-sm btn-primary btn-xs" CommandArgument='<%#Eval("ResultIssueDateId") + ";" +Eval("ResultDesc")+ ";" +Eval("ResultDate") + ";" +Eval("ClassGroupId")%>' OnClick="btnSubmit_Click" Text="Update" />
                                        <asp:Button ID="btnApplyCenter" OnClick="IssuanceDateApplyToCenter" CommandArgument='<%# Eval("ResultIssueDateId") %>' CssClass="btn btn-primary btn-xs" runat="server" Text="Copy to Center" />
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
                <div id="Applied" runat="server">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <h3 class="titlesection">List of Centers - Result Issuance Date Applied.</h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " style="margin-top: 30px">
                        <asp:GridView ID="grdIssuanceDateApplied" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            OnRowDeleting="OnRowDeletingAppliedGrid" DataKeyNames="RIDDetId"
                            CssClass="datatable table table-striped table-responsive" OnPreRender="grdIssuanceDateApplied_PreRender">
                            <AlternatingRowStyle CssClass="tr2" />
                            <Columns>
                                <asp:BoundField DataField="RIDDetId" HeaderText="RIDDetId">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Sr. #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Region_Id" HeaderText="Region Id">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Center_Id" HeaderText="Center Id">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ResultDesc" HeaderText="Description">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="ResultDate" HeaderText="Result Date" DataFormatString="{0:dd/MM/yyyy}">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:Button runat="server" CssClass="btn-sm btn-danger btn-xs" Text="Delete" CommandName="Delete" OnRowDataBound="OnDateAppliedDataBound" />
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
                <div id="NotApplied" runat="server">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <h3 class="titlesection">List of Centers - Result Issuance Date Not Applied. </h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                        <br />
                        <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            CssClass="datatable table table-striped table-responsive" OnPreRender="gvTest_PreRender">
                            <AlternatingRowStyle CssClass="tr2" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Region_Id" HeaderText="Region Id">
                                    <HeaderStyle HorizontalAlign="Left" cssClass="hide" />
                                    <ItemStyle HorizontalAlign="Center" cssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Center_Id" HeaderText="Center Id">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="70px">
                                    <HeaderTemplate>
                                        <input type="checkbox" name="select-all" id="select-all" />
                                    </HeaderTemplate>
				<EditItemTemplate>
                                        <asp:CheckBox ID="chkCenter" runat="server" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkCenter" runat="server" />
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
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-inline ">
                    <asp:Button ID="btnSaveDateApplied" OnClick="DateAppliedOnCampuses" runat="server" Text="Apply" CssClass="btn btn-primary pull-right" />
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
                                    <label>Class Group</label>
                                    <asp:DropDownList ID="ddlClassGroup" runat="server" AutoPostBack="True" CssClass="form-control">                </asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="ddlClassGroup" InitialValue="select" ErrorMessage="Please select Group " />

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <label>Description</label>
                                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description is required."
                                        ControlToValidate="txtDescription" ForeColor="red" ValidationGroup="test"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    <label>Issuance Date</label>
                                    <asp:TextBox ID="txtIssuanceDate" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Date is required."
                                        ControlToValidate="txtIssuanceDate" ForeColor="red" ValidationGroup="test"></asp:RequiredFieldValidator>
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






