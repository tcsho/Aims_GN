<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 96%; height: 330px;">
        <script type="text/javascript" src="https://www.gstatic.com/charts/loader.js"></script>
      
        <br />
        <div>
            <asp:Button ID="Button1" runat="server" Text="Mobile App Dashboard" OnClick="Button1_Click" Visible="false" CssClass="btn btn-primary"  OnClientClick="$('#myspindiv').show();"/>
        </div>
          <div id="myspindiv" style="display: none;">
            <center>
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="10%"
                    Width="10%" /></center>

        </div>
        <div runat="server" id="divNotif" class="alert alert-danger"
            visible="false">
        </div>

        <asp:Literal ID="ltScripts" runat="server"></asp:Literal>
        <div id="barchart" style="width: 50%; height: 100%; float: left;">
        </div>

        <div id="donutchart" style="width: 50%; height: 100%; float: left;">
        </div>


        <div id="promotions" style="width: 50%; height: 100%; float: left;">
        </div>
        <div id="PromTab" style="width: 50%; height: 40%; float: left; margin-top: 100px;">
        </div>
    </div>
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Timer ID="Timer1" runat="server" Interval="6000000" OnTick="Timer1_Tick">
            </asp:Timer>
            <%--            <script type="text/javascript">

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

                                            { orderable: false, targets: [8, 9]} //disable sorting on toggle button
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
                      , "mColumns": [1, 2, 3, 4, 5, 6, 7, 8, 9]
                } // ******************* end of copy button

              // ******************* Start of csv button
                  , {
                      'sExtends': 'csv',
                      'bShowAll': false // ,'sFileName': "DataInCSVFormat.csv"
                      ,
                      "sFileName": "DataInCSVFormat - *.csv",
                      "sToolTip": "Save as CSV",
                      //               'sButtonText': 'Save as CSV',
                      "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
                      "sNewLine": "auto"
                         , "mColumns": [1, 2, 3, 4, 5, 6, 7, 8, 9]
                  }  // ******************* end of csv button

              // ******************* Start of excel button
                   , {
                       'sExtends': 'xls',
                       'bShowAll': false,
                       "sFileName": "DataInExcelFormat.xls",
                       //                   'sButtonText': 'Save to Excel',
                       "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                       "sToolTip": "Save as Excel"
                        , "mColumns": [1, 2, 3, 4, 5, 6, 7, 8, 9]
                   }  // ******************* End of excel button


              // ******************* Start of PDF button
                  , {
                      'sExtends': "pdf",
                      'bShowAll': false,
                      "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                      //               'sButtonText': 'Save to PDF',
                      "sFileName": "DataInPDFFormat.pdf",
                      "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                         , "mColumns": [1, 2, 3, 4, 5, 6, 7, 8, 9]
                      //,"sPdfMessage": "Your custom message would go here."
                  } // *********************  End of PDF button 

                         ]// ******************* end of Export buttons collection
          }    // ******************* end of child of export buttons collection
                         ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true
         , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false //, fixedHeader: true , "stateSave": true
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
            </script>--%>
            <table border="0" cellpadding="0" cellspacing="0" class="main_table" width="100%">
                <tr>
                    <td style="width: 100%; height: 40px; text-align: center; border-width: 15px; border-color: White;">
                        <asp:Button ID="btnSendEmail" runat="server" CssClass="btn btn-danger" OnClick="btnEmail_Click"
                            Text="Send Email to CEO" Visible="false"></asp:Button>
                        <table border="0" cellpadding="0" cellspacing="0" class="main_table" width="100%">
                        </table>
                    </td>
                </tr>
                <tr style="width: 100%;">
                    <td colspan="2" style="width: 100%;">
                        <%--                        <asp:GridView ID="gvUser" runat="server" HorizontalAlign="Left" SkinID="GridView"
                            Width="100%" CssClass="table table-striped table-bordered table-hover">
                            <RowStyle HorizontalAlign="Center" Font-Size="14px" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:GridView>--%>
                    </td>
                </tr>
                <tr id="TrCampus" runat="server" style="text-align: center" visible="false">
                    <td>
                        <h2>Cilck <a href="../Files/User%20Manual%20(Campus%20Officer).pdf" style="font-size: larger">here</a> to download user manual AIMS+ for Campus Officer.</h2>
                    </td>
                </tr>
                <tr id="TrTeacher" runat="server" visible="false">
                    <td>
                        <h2>Cilck <a href="../Files/User%20Manual%20(Teacher).pdf" style="font-size: larger">here</a>
                            to download user manual AIMS+ for Teacher.</h2>
                    </td>
                </tr>
                </tr
                <td></td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
 <%--   <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/loading.gif" Height="50%"
                    Width="50%" />
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>--%>
</asp:Content>
