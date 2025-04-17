<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="PerformanceEvaluationLabelsGeneralPerformance.aspx.cs" Inherits="PresentationLayer_PerformanceEvaluationLabelsGeneralPerformance" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" AsyncPostBackTimeout="3600">
      
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
         <script type="text/javascript">

             Sys.Application.add_init( function ()
             {
                 // Initialization code here, meant to run once.

                 jq( document ).ready( document_Ready );


                 function document_Ready()
                 {

                     jq( document ).ready( function ()
                     {

                         //****************************************************************

                         try
                         {
                             jq( 'table.datatable' ).DataTable( {
                                 destroy: true,
                                 // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                                 //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                 dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                     "<'row'<'col-sm-12'tr>>" +
                                 //                     "<'row'<'col-sm-12'l>>" +
                      "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                 "columnDefs": [

                                            { orderable: false, targets: [7, 8]} //disable sorting on toggle button
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
                  //               'sButtonText': 'Save as CSV',
                  "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
                  "sNewLine": "auto"
                    , "mColumns": [1, 2, 3, 4, 5, 6]
              }  // ******************* end of csv button

              // ******************* Start of excel button
               , {
                   'sExtends': 'xls',
                   'bShowAll': false,
                   "sFileName": "DataInExcelFormat.xls",
                   //                   'sButtonText': 'Save to Excel',
                   "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                   "sToolTip": "Save as Excel"
                   , "mColumns": [1, 2, 3, 4, 5, 6]
               }  // ******************* End of excel button


              // ******************* Start of PDF button
              , {
                  'sExtends': "pdf",
                  'bShowAll': false,
                  "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                  //               'sButtonText': 'Save to PDF',
                  "sFileName": "DataInPDFFormat.pdf",
                  "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                    , "mColumns": [1, 2, 3, 4, 5, 6]
                  //,"sPdfMessage": "Your custom message would go here."
              } // *********************  End of PDF button 

               ]// ******************* end of Export buttons collection
          }    // ******************* end of child of export buttons collection
            ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 25, 'bLengthChange': true // ,"bJQueryUI":true
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
                         catch ( err )
                         {
                             alert( 'datatable ' + err );
                         }

                         //****************************************************************



                     }
   );

                 } //end of documnet_ready()



                 //Re-bind for callbacks
                 var prm = Sys.WebForms.PageRequestManager.getInstance();
                 prm.add_endRequest( function ()
                 {
                     jq( document ).ready( document_Ready );
                     //            document_Ready();
                     //            alert('call back done');
                 }
);

             } ); 
            </script>
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Performance Activity Criteria-General Performance"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                
                                  
                                  <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        Term:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_term" runat="server" AutoPostBack="True" 
                                            CssClass="dropdownlist" 
                                            OnSelectedIndexChanged="list_term_SelectedIndexChanged" Width="217px" >
                                       
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                       
                                    </td>
                                   <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        <asp:LinkButton ID="but_new" OnClick="but_new_Click" runat="server" CssClass="leftlink"
                       Font-Bold="False"  >Add New Activity</asp:LinkButton></td>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%" colspan="2">
                                        <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                        <td valign="top" colspan="3" >
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="height: 22px" class="titlesection">
                                               Add New Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td style="height: 10px" class="tr2">
                                                        </td>
                                                        <td style="width: 350px; height: 10px" class="tr2" valign="top" align="right">
                                                        </td>
                                                        <td style="width: 510px; height: 10px" class="tr2">
                                                        </td>
                                                       
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr1">
                                                        </td>
                                                        <td style="width: 350px" class="tr1" valign="top" align="right">
                                                           Activity Name:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr1">
                                                            <asp:TextBox ID="txtCritName" runat="server" Width="400px"></asp:TextBox>
                                                        </td>
                                                        
                                                    </tr>
                                                    <tr style="width: 100%">
                                                    <td class="tr2" style="width: 8px; height: 18px">
                                                            &nbsp;</td>
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        Class :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                                   <tr style="width: 100%">
                                                   <td class="tr2" style="width: 8px; height: 18px">
                                                            &nbsp;</td>
                                    <td align="right" class="tr2" style="width: 350px; height: 18px" valign="top">
                                       
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="list_subject" runat="server" AutoPostBack="false" CssClass="dropdownlist"
                                            Width="217px" 
                                            AppendDataBoundItems="True" Height="16px"  
                                            Visible="False">
                                        </asp:DropDownList>
                                    </td>
                                </tr>

                                                    <tr>
                                                        <td class="tr2" style="width: 8px; height: 18px">
                                                            &nbsp;</td>
                                                        <td align="right" class="tr2" style="width: 350px; height: 18px" valign="top">
                                                            </td>
                                                        <td class="tr2" style="width: 60%; height: 25px">
                                                            <asp:DropDownList ID="list_EvlType" runat="server" AutoPostBack="True" 
                                                                CssClass="dropdownlist" 
                                                                OnSelectedIndexChanged="list_EvlType_SelectedIndexChanged" Width="217px" 
                                                                Height="16px" Visible="False">
                                                            </asp:DropDownList>
                                                        </td>
                                                        
                                                    </tr>
                                                    
                                                   
                                                    <tr>
                                                        <td style="width: 8px; height: 19px" class="">
                                                        </td>
                                                        <td style="height: 19px" class="" align="center" colspan="2">
                                                            <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                                                Text="Save"></asp:Button>&nbsp;<asp:Button ID="but_cancel" OnClick="but_cancel_Click"
                                                                    runat="server" CssClass="btn btn-primary" CausesValidation="False" Text="Cancel">
                                                            </asp:Button>&nbsp;&nbsp;
                                                        </td>
                                                        
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </tbody>
                                </table>
                            </asp:Panel>
                            &nbsp;
                        </td>
                    </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%;"   colspan="2">
                                        <asp:GridView ID="gvSubjects" runat="server" 
                                           AutoGenerateColumns="False" 
                        CssClass="datatable table table-striped table-responsive"
                                EmptyDataText="No Record Exists." OnPreRender="gvSubjects_PreRender"    >
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:BoundField DataField="SubKndItmLbl_Id" SortExpression="SubKndItmLbl_Id" 
                                                    HeaderText="SubKndItmLbl_Id">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Sr. #">
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                    <HeaderStyle HorizontalAlign="Left" Width="5%" />
                                                    <ItemStyle HorizontalAlign="Center" Width="5%" />
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="Class_Name" HeaderText="Class_Name" >

                                                <HeaderStyle HorizontalAlign="Left" Width="10%" />
                                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Type" SortExpression="Type" 
                                                    HeaderText="Type">
                                                    <HeaderStyle HorizontalAlign="Left" Width="10%"  />
                                                    <ItemStyle HorizontalAlign="Left"  Width="10%" />
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Subject_Name" 
                                                    HeaderText="Subject_Name">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Item_Head" HeaderText="Item_Head" >
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                 <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Description" HeaderText="Description" >
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" 
                                                            CommandArgument='<%# Eval("SubKndItmLbl_Id") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" 
                                                         CommandArgument='<%# Eval("SubKndItmLbl_Id") %>' ForeColor="#004999" 
                                                            ImageUrl="~/images/delete.gif" OnClick="btnDelete_Click" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" onClientClick = "javascript:return confirm('Are you sure you want to Delete Records?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                            <RowStyle CssClass="tr1" />
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr id="trSave" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        &nbsp;</td>
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
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
