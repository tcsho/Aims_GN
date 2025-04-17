<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TcsHlpDskSubCatg.aspx.cs" Inherits="PresentationLayer_TCS_TcsHlpDskSubCatg"
    Theme="BlueTheme" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
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
         //                    jq('table.datatable').DataTable({
         //                        destroy: true,
         //                        // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


         //                        //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
         //                        dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
         //            "<'row'<'col-sm-12'tr>>" +
         //                        //                     "<'row'<'col-sm-12'l>>" +
         //             "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
         //                        "columnDefs": [

         //                        //{ orderable: false, targets: [8]} //disable sorting on toggle button
         //                           ]

         //                       ,


         //                        tableTools:
         //           { //Start of tableTools collection
         //               "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
         //               "aButtons":
         //                [ //start of button main/master collection



         //     { // ******************* Start of child collection for export button
         //     "sExtends": "collection",
         //     "sButtonText": "<span class='glyphicon glyphicon-export'></span>",
         //     "sToolTip": "Export Data",
         //     "aButtons":
         //                [ //start of button export buttons collection

         //     // ******************* Start of copy button
         //           {
         //           "sExtends": "copy",
         //           "sButtonText": "<span class='glyphicon glyphicon-copy'></span> Copy Contents",
         //           "sToolTip": "Copy Data"
         //             , "mColumns": [4]
         //       } // ******************* end of copy button

         //     // ******************* Start of csv button
         //         , {
         //             'sExtends': 'csv',
         //             'bShowAll': false // ,'sFileName': "DataInCSVFormat.csv"
         //             ,
         //             "sFileName": "DataInCSVFormat - *.csv",
         //             "sToolTip": "Save as CSV",
         //             //'sButtonText': 'Save as CSV',
         //             "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
         //             "sNewLine": "auto"
         //                , "mColumns": [4]
         //         }  // ******************* end of csv button

         //     // ******************* Start of excel button
         //          , {
         //              'sExtends': 'xls',
         //              'bShowAll': false,
         //              "sFileName": "DataInExcelFormat.xls",
         //              //'sButtonText': 'Save to Excel',
         //              "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
         //              "sToolTip": "Save as Excel"
         //               , "mColumns": [4]
         //          }  // ******************* End of excel button


         //     // ******************* Start of PDF button
         //         , {
         //             'sExtends': "pdf",
         //             'bShowAll': false,
         //             "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
         //             //'sButtonText': 'Save to PDF',
         //             "sFileName": "DataInPDFFormat.pdf",
         //             "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
         //                , "mColumns": [4]
         //             //,"sPdfMessage": "Your custom message would go here."
         //         } // *********************  End of PDF button 

         //                ]// ******************* end of Export buttons collection
         // }    // ******************* end of child of export buttons collection
         //                ] // ******************* end of button master Collection
         //           } // ******************* end of tableTools
         //, "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
         //, "order": [[0, "asc"]], "paging": true, "ordering": false, "searching": true, "info": true, "scrollX": false, "stateSave": true
         //, //--- Dynamic Language---------
         //                        "oLanguage": {
         //                            "sZeroRecords": "There are no Records that match your search critera",
         //                            //                    "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
         //                            "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
         //                            "sInfoEmpty": "Showing 0 to 0 of 0 records",
         //                            "sInfoFiltered": "(filtered from _MAX_ total records)",
         //                            "sEmptyTable": 'No Rows to Display.....!',
         //                            "sSearch": "Search :"
         //                        }
         //                    }
         //          );

                             $('table.datatable').DataTable({
                                 destroy: true,
                                 "dom": 'Blfrtip',
                               

                                 buttons: [
                                     {
                                         extend: 'excel',
                                         exportOptions: {
                                             columns: [0, 1]
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
            <div class="form-group formheading">
                <asp:Label ID="Label3" CssClass="lblFormHead" runat="server" Text="List of Bifurcated Students"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="Div1" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <asp:Label ID="lblMsg" runat="server" Text="" CssClass="txtErrorLabel"></asp:Label>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " runat="server" id="ContentDetailSection">
                <div class="row">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <asp:Label ID="Label2" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                            Text="Help Desk Type:*: "></asp:Label>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <asp:DropDownList ID="ddlMainCatg" runat="server" CssClass="dropdownlist" Width="320px"
                                AutoPostBack="True" OnSelectedIndexChanged="ddlMainCatg_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator8" runat="server"
                                ValidationGroup="s" Display="Dynamic" ErrorMessage="Please select help desk type."
                                ControlToValidate="ddlMainCatg" InitialValue="0"></asp:RequiredFieldValidator>
                        </div>
                        <asp:Label ID="Label6" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                            Text="  Complaint Catagory:*  : " ></asp:Label>
                        <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control textbox" MaxLength="50" Width="320px"></asp:TextBox>
                            <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator1" runat="server"
                                ValidationGroup="s" Display="Dynamic" ErrorMessage="Catagory name is required."
                                ControlToValidate="txtName"></asp:RequiredFieldValidator>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-5 col-md-5 col-sm-5 col-xs-12 text-right ">
                        <asp:Button ID="btnSave" OnClick="btnSave_Click" runat="server" CssClass="btn btn-primary"
                            Width="58px" ValidationGroup="s" Text="Save"></asp:Button>
                    </div>
                     <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12 "></div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    &nbsp; Available Catagories
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvDCT" runat="server" AutoGenerateColumns="False" CssClass="datatable table table-hover table-responsive"
                    OnPageIndexChanging="gvDCT_PageIndexChanging" OnPreRender="gvDCT_PreRender">
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemStyle Font-Size="X-Small" Width="10%" />
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Title">
                            <ItemStyle Width="70%" />
                            <ItemTemplate>
                                <asp:LinkButton ID="btnTitle" runat="server" ForeColor="#004999" OnClick="btnTitle_Click"
                                    Style="text-align: center; font-weight: normal;" Text='<%# Eval("HDSubDesc") %>  '
                                    ToolTip="View this Record" CommandArgument='<%# Eval("HDSubCat_ID") %>'></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server" ForeColor="#004999" OnClick="btnEdit_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Edit this Record" ImageUrl="~/images/edit.gif"
                                    CommandArgument='<%# Eval("HDSubCat_ID") %>'></asp:ImageButton>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Remove">
                            <ItemStyle Wrap="False" HorizontalAlign="Center" Width="10%" />
                            <ItemTemplate>
                                <asp:ImageButton ID="btnRemove" runat="server" ForeColor="#004999" OnClick="btnRemove_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Remove this Record" ImageUrl="~/images/delete.gif"
                                    CommandArgument='<%# Eval("HDSubCat_ID") %>' OnClientClick="javascript:return confirm('Are you sure to Delete this Record?');">
                                </asp:ImageButton>&nbsp;
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                    <SelectedRowStyle CssClass="tr_select" BackColor="#FFE0C0" />
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
