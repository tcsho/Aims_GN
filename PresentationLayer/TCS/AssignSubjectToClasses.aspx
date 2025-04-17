<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AssignSubjectToClasses.aspx.cs" Inherits="PresentationLayer_TCS_AssignSubjectToClasses" %>

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
                                jq('table.datatable').DataTable({
                                    destroy: true,
                                    // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok
                                    //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                        "<'row'<'col-sm-12'tr>>" +
                                        //                     "<'row'<'col-sm-12'l>>" +
                                        "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    "columnDefs": [

                                        //{ orderable: false, targets: [8]} //disable sorting on toggle button
                                    ],
                                    tableTools:
                                    { //Start of tableTools collection
                                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                        "aButtons":
                                            [ //start of button main/master collection
                                                { // ******************* Start of child collection for export button
                                                    "sExtends": "collection",
                                                    "sButtonText": "<span class='glyphicon glyphicon-export'></span>",
                                                    "sToolTip": "Export Data",
                                                    "aButtons":
                                                        [ //start of button export buttons collection

                                                            // ******************* Start of copy button
                                                            {
                                                                "sExtends": "copy",
                                                                "sButtonText": "<span class='glyphicon glyphicon-copy'></span> Copy Contents",
                                                                "sToolTip": "Copy Data"
                                                                , "mColumns": [1, 2, 3, 4, 5, 6]
                                                            } // ******************* end of copy button

                                                            // ******************* Start of csv button
                                                            , {
                                                                'sExtends': 'csv',
                                                                'bShowAll': false // ,'sFileName': "DataInCSVFormat.csv"
                                                                ,
                                                                "sFileName": "DataInCSVFormat - *.csv",
                                                                "sToolTip": "Save as CSV",
                                                                //'sButtonText': 'Save as CSV',
                                                                "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
                                                                "sNewLine": "auto"
                                                                , "mColumns": [1, 2, 3, 4, 5, 6]
                                                            }  // ******************* end of csv button

                                                            // ******************* Start of excel button
                                                            , {
                                                                'sExtends': 'xls',
                                                                'bShowAll': false,
                                                                "sFileName": "DataInExcelFormat.xls",
                                                                //'sButtonText': 'Save to Excel',
                                                                "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                                                                "sToolTip": "Save as Excel"
                                                                , "mColumns": [1, 2, 3, 4, 5, 6]
                                                            }  // ******************* End of excel button


                                                            // ******************* Start of PDF button
                                                            , {
                                                                'sExtends': "pdf",
                                                                'bShowAll': false,
                                                                "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                                                                //'sButtonText': 'Save to PDF',
                                                                "sFileName": "DataInPDFFormat.pdf",
                                                                "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                                                                , "mColumns": [1, 2, 3, 4, 5, 6]
                                                                //,"sPdfMessage": "Your custom message would go here."
                                                            } // *********************  End of PDF button 

                                                        ]// ******************* end of Export buttons collection
                                                }    // ******************* end of child of export buttons collection
                                            ] // ******************* end of button master Collection
                                    } // ******************* end of tableTools
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
                                    , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": true
                                    , //--- Dynamic Language---------
                                    "oLanguage": {
                                        "sZeroRecords": "There are no Records that match your search critera",
                                        //                    "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
                                        "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                                        "sInfoEmpty": "Showing 0 to 0 of 0 records",
                                        "sInfoFiltered": "(filtered from _MAX_ total records)",
                                        "sEmptyTable": 'No Rows to Display.....!',
                                        "sSearch": "Search :"
                                    }
                                }
                                );
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
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Add/Assign Subjects To Classes "></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <p>
                    <br />
                </p>
                <div class="col-lg-12 col-md-12 col-sm-12">
                    <asp:Button ID="btnIssuanceSubmit" CssClass="btn btn-primary pull-right btn-xs" runat="server" Text="Create New Subject" OnClick="btnSubmit_Click"></asp:Button>
                </div>

                <div id="ResultIssue" runat="server">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        <h3 class="titlesection">Subjects</h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " style="margin-top: 30px">
                        <asp:GridView ID="gv_IssuanceDate" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            OnRowDeleting="OnRowDeleting" DataKeyNames="Subject_Id"
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
                                <asp:BoundField DataField="Subject_Id" HeaderText="Id">
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Subject_Name" HeaderText="Class Name">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Subject_Code" HeaderText="Code">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Comments" HeaderText="Comments">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="150px">
                                    <ItemTemplate>
                                        <%-- <asp:Button runat="server" CssClass="btn-sm btn-danger btn-xs" Text="Delete" CommandName="Delete" OnRowDataBound="OnRowDataBound" />--%>
                                        <asp:Button runat="server" CssClass="btn-sm btn-default btn-xs" CommandArgument='<%#Eval("Subject_Id") + ";" +Eval("Subject_Name")+ ";" +Eval("Subject_Code") + ";" +Eval("Comments")%>' OnClick="btnSubmit_Click" Text="Update" />
                                        <asp:Button ID="btnApplyCenter" OnClick="IssuanceDateApplyToCenter" CommandArgument='<%# Eval("Subject_Id") %>' CssClass="btn btn-primary btn-xs" runat="server" Text="Copy to Class" />
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
                        <h3 class="titlesection">Classes</h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " style="margin-top: 30px">
                        <asp:GridView ID="grdIssuanceDateApplied" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            OnRowDeleting="OnRowDeletingAppliedGrid" DataKeyNames="Class_Id"
                            CssClass="datatable table table-striped table-responsive" OnPreRender="grdIssuanceDateApplied_PreRender">
                            <AlternatingRowStyle CssClass="tr2" />
                            <Columns>
                                <asp:BoundField DataField="Class_Id" HeaderText="Class Id">
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
                                <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide" />
                                </asp:BoundField>


                                <asp:BoundField DataField="Class_Subject_ID" HeaderText="Class_Subject_Id">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide" />
                                </asp:BoundField>



                                <asp:TemplateField HeaderText="Action" ItemStyle-Width="70px">
                                    <EditItemTemplate>
                                        <asp:CheckBox ID="chkclass" runat="server" />
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkclass" runat="server" />
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
                                <div class="col-md-6">
                                    <label>Subject Name</label>
                                    <asp:TextBox ID="txtname" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Description is required."
                                        ControlToValidate="txtname" ForeColor="red" ValidationGroup="test"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-6">
                                    <label>Subject Code</label>
                                    <asp:TextBox ID="txtcode" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Date is required."
                                        ControlToValidate="txtcode" ForeColor="red" ValidationGroup="test"></asp:RequiredFieldValidator>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">

                                    <label>Comments</label>
                                    <asp:TextBox ID="txtcomments" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                            </div>

                        </div>
                        <div class="modal-footer">
                            <button class="btn btn-info pull-left" data-dismiss="modal" aria-hidden="true">Close</button>
                            <asp:Button ID="btnAddIssuanceDate" OnClick="AddNewSubject" CssClass="btn btn-primary" runat="server" />
                        </div>
                    </div>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>

