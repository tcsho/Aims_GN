<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchUserWithPassword.aspx.cs" MasterPageFile="~/PresentationLayer/MasterPage.master" Inherits="PresentationLayer_SearchUserWithPassword" Theme="BlueTheme" %>

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
                  , "mColumns": [1, 2, 3, 4, 5, 6, 7]
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
                     , "mColumns": [1, 2, 3, 4, 5, 6, 7]
              }  // ******************* end of csv button

              // ******************* Start of excel button
               , {
                   'sExtends': 'xls',
                   'bShowAll': false,
                   "sFileName": "DataInExcelFormat.xls",
                   //                   'sButtonText': 'Save to Excel',
                   "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                   "sToolTip": "Save as Excel"
                    , "mColumns": [1, 2, 3, 4, 5, 6, 7]
               }  // ******************* End of excel button


              // ******************* Start of PDF button
              , {
                  'sExtends': "pdf",
                  'bShowAll': false,
                  "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                  //               'sButtonText': 'Save to PDF',
                  "sFileName": "DataInPDFFormat.pdf",
                  "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                     , "mColumns": [1, 2, 3, 4, 5, 6, 7]
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
            </script>
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="7">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%">
                                        </td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Search Users"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">
                            <asp:Button ID="but_search" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                                Text="Search"></asp:Button>
                        </td>
                    </tr>
                    <tr>
                        <td height="15">
                        </td>
                    </tr>
                    <tr>
                        <td class="titlesection" colspan="7">
                            Search Criteria
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="7">
                            <table cellspacing="1" cellpadding="1" width="100%" bgcolor="#ffffff" border="0">
                                <tbody>
                                    <tr class="tr1">
                                        <td width="2%" height="25">
                                            &nbsp;
                                        </td>
                                        <td align="right" width="21%">
                                            First Name :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:TextBox ID="text_firstName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td align="right" width="24%">
                                            Employee # :
                                        </td>
                                        <td width="26%">
                                            <asp:TextBox ID="text_middleName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td style="height: 25px" width="2%">
                                            &nbsp;
                                        </td>
                                        <td style="height: 25px" align="right">
                                            User Name :
                                        </td>
                                        <td style="width: 160px; height: 25px">
                                            <asp:TextBox ID="text_lastName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                                        </td>
                                        <td style="height: 25px" align="right">
                                            Gender :
                                        </td>
                                        <td style="height: 25px">
                                            <asp:DropDownList ID="list_gender" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr class="tr1">
                                        <td style="height: 25px">
                                        </td>
                                        <td style="height: 25px" align="right">
                                            Region :
                                        </td>
                                        <td style="width: 160px; height: 25px">
                                            <asp:DropDownList ID="list_region" runat="server" CssClass="dropdownlist" OnSelectedIndexChanged="list_region_SelectedIndexChanged"
                                                AutoPostBack="True">
                                            </asp:DropDownList>
                                            <asp:Label ID="lab_region" runat="server"></asp:Label>
                                        </td>
                                        <td style="height: 25px" align="right">
                                            Group Name :
                                        </td>
                                        <td style="height: 25px">
                                            <asp:DropDownList ID="list_groupName" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr class="tr2">
                                        <td height="25">
                                        </td>
                                        <td align="right">
                                            Center :
                                        </td>
                                        <td style="width: 160px">
                                            <asp:DropDownList ID="list_center" runat="server" CssClass="dropdownlist">
                                            </asp:DropDownList>
                                            <asp:Label ID="lab_center" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                    <tr class="tr1">
                                        <td height="25">
                                        </td>
                                        <td>
                                        </td>
                                        <td style="width: 160px">
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td class="titlesection" colspan="7">
                            &nbsp;Search Result</td>
                    </tr>
                    <tr>
                        <td colspan="7">
                            &nbsp;
                            <asp:GridView ID="dg_user" runat="server" Width="100%" Height="100%" AutoGenerateColumns="False"
                            CssClass="datatable table table-striped table-responsive" OnPreRender="dg_user_PreRender"
                                OnRowCommand="dg_user_RowCommand" DataKeyNames="user_id,user_name" AllowPaging="True"
                                PageSize="10000" OnPageIndexChanging="dg_user_PageIndexChanging" SkinID="GridView">
                                <Columns>
                                    <asp:BoundField DataField="Row" HeaderText="#"></asp:BoundField>
                                    <asp:ButtonField HeaderText="Name" DataTextField="Name" CommandName="name"></asp:ButtonField>
                                    <asp:BoundField DataField="Type_description" HeaderText="Group Name"></asp:BoundField>
                                    <asp:BoundField DataField="Region_Name" HeaderText="Region"></asp:BoundField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Center"></asp:BoundField>
                                    <asp:BoundField DataField="gender" HeaderText="Gender"></asp:BoundField>
                                    <asp:BoundField DataField="email" HeaderText="Email"></asp:BoundField>
                                    <asp:BoundField DataField="User_Name" HeaderText="User_Name"></asp:BoundField>
                                    <asp:BoundField DataField="Password" HeaderText="Password" />
                                    <asp:TemplateField HeaderText="Password Reset">
                                        <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnPassReset" runat="server" CausesValidation="false" CommandArgument='<%# Eval("User_Id") %>'
                                                ImageUrl="~/images/Reset.png" OnClick="btnPassChange_Click" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="20px" />
                                    </asp:TemplateField>

                                </Columns>
                                <RowStyle CssClass="tr1"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>
                            <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 15px" align="right">
                            <asp:Button ID="but_search1" OnClick="but_search_Click" runat="server" CssClass="btn btn-primary"
                                Text="Search"></asp:Button>
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
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
