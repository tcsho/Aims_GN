<%@ Page Language="C#"  MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" 
CodeFile="_AimsResultCompileStatus.aspx.cs" Inherits="_AimsResultCompileStatus" %>

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
                        jq('table.datatable').DataTable({
                            destroy: true,
                            // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                            //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                            dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                     "<'row'<'col-sm-12'tr>>" +
                            //                     "<'row'<'col-sm-12'l>>" +
                      "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                            "columnDefs": [

                                            { orderable: false, targets: [8]} //disable sorting on toggle button
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
                  , "mColumns": [1, 2, 3, 4, 5, 6, 7]
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
                     , "mColumns": [1, 2, 3, 4, 5, 6, 7]
              }  // ******************* end of csv button

              // ******************* Start of excel button
               , {
                   'sExtends': 'xls',
                   'bShowAll': false,
                   "sFileName": "DataInExcelFormat.xls",
                   //'sButtonText': 'Save to Excel',
                   "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                   "sToolTip": "Save as Excel"
                    , "mColumns": [1, 2, 3, 4, 5, 6, 7]
               }  // ******************* End of excel button


              // ******************* Start of PDF button
              , {
                  'sExtends': "pdf",
                  'bShowAll': false,
                  "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                  //'sButtonText': 'Save to PDF',
                  "sFileName": "DataInPDFFormat.pdf",
                  "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                     , "mColumns": [1, 2, 3, 4, 5, 6, 7]
                  //,"sPdfMessage": "Your custom message would go here."
              } // *********************  End of PDF button 

               ]// ******************* end of Export buttons collection
          }    // ******************* end of child of export buttons collection
            ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
         , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false , "stateSave": true
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

            <table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
                border="0">
                <tbody>
                   <tr>
                        <td colspan="7">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"  border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                         </td>
                                         <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" 
                                            runat="server" Text="Result Compilation" ></asp:Label>
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
            </td>
            </tr>
            <tr>
                <td align="right" style="height: 15px">
                    <asp:Button ID="btnComplie" runat="server" CssClass="btn btn-primary" 
                        onclick="btnCompile_Click" Text="Compile" />
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 15px">
                </td>
            </tr>
            <tr>
                <td class="titlesection" colspan="7">
                    Search Criteria
                </td>
            </tr>
            <tr>
                <td colspan="7" valign="top">
                    <table bgcolor="#ffffff" border="0" cellpadding="1" cellspacing="1" 
                        width="100%">
                        <tbody>
                            <tr class="tr1">
                            
                                <td class="TextLabel" style="width: 141px">
                                    Session:
                                </td>
                                <td    style="width: 160px; height: 25px">
                                    <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" 
                                        Enabled="False" >
                                    </asp:DropDownList>
                                </td>
                                
                            </tr>
                            <tr class="tr1">
                                <td class="TextLabel" style="width: 141px">
                                    Term Group :
                                </td>
                                <td style="width: 160px; height: 25px">
                                    <asp:DropDownList ID="ddlTerm" runat="server" AutoPostBack="True" 
                                        CssClass="dropdownlist">
                                    </asp:DropDownList>
                                </td>
                                
                            </tr>
                        </tbody>
                    </table>
                </td>
            </tr>
            </tbody>
            </table>
            </td>
            </tr>
            <tr>
                <td class="titlesection" colspan="7">
                    &nbsp;Search Result
                </td>
            </tr>
            <tr>
                <td colspan="7">
                    &nbsp;
                    <asp:GridView ID="gv_CenterGrid" runat="server" AutoGenerateColumns="False" 
                        CssClass="datatable table table-striped table-responsive" DataKeyNames="Center_Id"
                         OnPreRender="gv_CenterGrid_PreRender" onrowcommand="gv_CenterGrid_RowCommand" >
                        <Columns>
                            <asp:BoundField DataField="Region_Id" HeaderText="Region_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Id" HeaderText="Region_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Section_Id" HeaderText="Region_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Name" HeaderText="Region Name ">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Name" HeaderText="Class Name ">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CurrentStudents" HeaderText="Current Students">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ResultCompiled" HeaderText="Result Compiled">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NotCompiled" HeaderText="Not Compiled">
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Select" >
                                <HeaderTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" 
                                        CommandName="toggleCheck">Select</asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBox1" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
                  
                </td>
            </tr>
            <tr>
                <td align="right" style="height: 15px">
                    <asp:Button ID="btnCompile" runat="server" CssClass="btn btn-primary" 
                        onclick="btnCompile_Click" TabIndex="1" Text="Compile" />
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
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender" runat="server"
        TargetControlID="UpdatePanel1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>