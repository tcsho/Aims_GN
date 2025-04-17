<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdmTestAssignCenters.aspx.cs" Inherits="PresentationLayer_TCS_AdmTestAssignCenters" %>


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
                                    ]

                                ,
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
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Admission Test Assign Centers"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <p>
                <br />
            </p>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">

                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">

                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <asp:Label ID="lblsession" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Session: "> </asp:Label>
                        <asp:Label ID="lblDesc" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40 text-left" Text=" "> </asp:Label>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <asp:Label ID="lblClass" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                            Text="Class : "></asp:Label>
                        <asp:Label ID="lblClassDesc" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40 text-left" Text=" "> </asp:Label>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <asp:Label ID="lblTest" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="Test Type:"></asp:Label>
                        <%--<asp:Label runat="server" ID="lblTestType" Text=" " CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40 text-left"></asp:Label>--%>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <asp:DropDownList ID="ddlTestType" runat="server" CssClass="dropdownlist" Width="218px"
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " runat="server" visible="false">
                        <asp:Label ID="lblRegion" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="Region:"></asp:Label>
                        <%--<asp:Label runat="server" ID="lblTestType" Text=" " CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40 text-left"></asp:Label>--%>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <asp:DropDownList ID="ddlRegion" runat="server" CssClass="dropdownlist" Width="218px"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " runat="server" visible="false">
                        <asp:Label ID="lblCenter" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="Center:"></asp:Label>
                        <%--<asp:Label runat="server" ID="lblTestType" Text=" " CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40 text-left"></asp:Label>--%>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <asp:DropDownList ID="ddlCenter" runat="server" CssClass="dropdownlist" Width="218px"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged">
                            </asp:DropDownList>
                        </div>

                    </div>
                </div>
                <div runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-12 form-group">
                    <div class="pull-right">
                        <asp:Button ID="btnBack" runat="server" CssClass="btn btn-warning" Font-Bold="False"
                            Text="Back" OnClick="btnBack_Click" />


                    </div>

                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <p>
                    <br />
                </p>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " runat="server" id="divFilters" visible="false">
                <div class="pull-right">
                    <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" Font-Bold="False"
                        Text="Save" OnClick="btnSave_Click" />
                </div>
                <div class="pull-left">
                    <asp:Button ID="btnAll" runat="server" CssClass="btn btn-default" Font-Bold="False"
                        Text="All Centers" OnClick="btnAll_Click" />
                    <asp:Button ID="btnAssignedCenters" runat="server" CssClass="btn btn-success" Font-Bold="False"
                        Text="Assigned Centers" OnClick="btnAssignedCenters_Click" />
                    <asp:Button ID="btnUnAssigned" runat="server" CssClass="btn btn-danger" Font-Bold="False"
                        Text="UnAssigned Centers" OnClick="btnUnAssignedCenters_Click" />
                </div>

            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <p>
                    <br />
                </p>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridTitle" visible="false">
                List of Schools 
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <br />

                <br />
                <asp:GridView ID="gvCenters" runat="server" AutoGenerateColumns="False" BorderStyle="None" OnRowCommand="gvCenters_RowCommand"
                    CssClass="datatable table table-striped table-responsive" OnPreRender="gvCenters_PreRender">
                    <AlternatingRowStyle CssClass="tr2" />
                    <SelectedRowStyle BackColor="PaleGoldenrod" />
                    <Columns>

                        <asp:BoundField DataField="Center_Id" HeaderText="Center_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sr. #">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />

                        </asp:TemplateField>
                        <asp:BoundField DataField="Center_Name" HeaderText="School">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TestTitle" HeaderText="Title">
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:TemplateField HeaderText="Select">
                            <ItemStyle HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <HeaderTemplate>
                                <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False"
                                    CommandName="toggleCheck">Select</asp:LinkButton>
                            </HeaderTemplate>

                            <ItemTemplate>
                                <asp:CheckBox ID="chkCenter" runat="server" CssClass="checkbox" 
                                    Enabled='<%# (int)( Eval("Assigned"))==0 %>' AutoPostBack="true"
                                    Checked='<%# (int)( Eval("Assigned"))==1 %>' OnCheckedChanged="chk_CheckedChanged" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
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



