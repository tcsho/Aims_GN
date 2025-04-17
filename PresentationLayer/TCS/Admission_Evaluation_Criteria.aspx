<%@ Page Title="Admission Evaluation Criteria" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Admission_Evaluation_Criteria.aspx.cs" Inherits="PresentationLayer_TCS_Admission_Evaluation_Criteria" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
            <%--<asp:ScriptReference Path="~/Scripts/dock1A.js" />--%>
            <%--<asp:ScriptReference Path="~/Scripts/dock1.js" />--%>
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
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
                  , "mColumns": [3, 4, 5, 6, 7]
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
                     , "mColumns": [3, 4, 5, 6, 7]
              }  // ******************* end of csv button

              // ******************* Start of excel button
               , {
                   'sExtends': 'xls',
                   'bShowAll': false,
                   "sFileName": "DataInExcelFormat.xls",
                   //'sButtonText': 'Save to Excel',
                   "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                   "sToolTip": "Save as Excel"
                    , "mColumns": [3, 4, 5, 6, 7]
               }  // ******************* End of excel button


              // ******************* Start of PDF button
              , {
                  'sExtends': "pdf",
                  'bShowAll': false,
                  "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                  //'sButtonText': 'Save to PDF',
                  "sFileName": "DataInPDFFormat.pdf",
                  "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                     , "mColumns": [1, 2, 3, 4, 5]
                  //,"sPdfMessage": "Your custom message would go here."
              } // *********************  End of PDF button 

               ]// ******************* end of Export buttons collection
          }    // ******************* end of child of export buttons collection
            ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
         , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": false
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Admission Evaluation Critera"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" border="0">
                                <tr>
                                    <td>
                                    </td>
                                    <td style="height: 15px" align="right">
                                        <asp:Button ID="but_new" runat="server" CssClass="btn btn-primary" Font-Bold="False"
                                            ValidationGroup="btnNew" OnClick="but_new_Click" Text="Add New"  
                                            Visible="False" CausesValidation="False" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px" align="right">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="titlesection" colspan="7">
                                        Search Criteria
                                    </td>
                                </tr>
                                <tr>
                                    <td style="height: 15px" align="right">
                                    
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Session* :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        &nbsp;
                                        <asp:DropDownList runat="server" ID="ddlSession" CssClass="dropdownlist" AutoPostBack="true"
                                            Width="217px" OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td class="TextLabelMandatory40">
                                        Class* :
                                    </td>
                                    <td style="width: 60%" align="left">
                                        &nbsp;
                                        <asp:DropDownList runat="server" ID="ddlClass" CssClass="dropdownlist" AutoPostBack="true"
                                            Width="217px" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                    </td>
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="left" style="width: 100%" colspan="2">
                                     <asp:Label runat="server" CssClass="Textlabel" ID="lblNote" ForeColor="Red"></asp:Label>
                                        <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="titlesection" colspan="7" runat="server" id="trHeading" visible="false">
                                        &nbsp;Search Result
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td colspan="7">
                                        &nbsp;
                                        <asp:GridView ID="gvCriteria" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            Width="100%" CssClass="datatable table table-striped table-responsive" Height="100%"
                                            SkinID="GridView" OnPreRender="gvCriteria_PreRender">
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:BoundField DataField="AEC_Id" SortExpression="ACEC_Id" HeaderText="AEC_Id">
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
                                                <asp:BoundField DataField="Session_Id" SortExpression="Session_Id" HeaderText="Session_Id">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Subject_Id" SortExpression="Subject_Id" HeaderText="Subject_Id">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
                                                    <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                                    <ItemStyle HorizontalAlign="Left" Width="25%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Criteria" SortExpression="Criteria" HeaderText="Criteria">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Total_Marks" SortExpression="Total_Marks" HeaderText="Total Marks">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Weightage" SortExpression="Weightage" HeaderText="Weightage(%)">
                                                    <HeaderStyle HorizontalAlign="Left" />
                                                    <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("AEC_Id") %>'
                                                            OnClick="btn_Edit_Click" ForeColor="#004999" ImageUrl="~/images/edit.gif" Style="text-align: center;
                                                            font-weight: bold;" ToolTip="Edit Record" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                                    <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("AEC_Id") %>' Visible='<%# Convert.ToBoolean( Eval("flag"))==true %>'
                                                            OnClick="btn_Delete_Click" ForeColor="#004999" ImageUrl="~/images/delete.gif" 
                                                            Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="flag" SortExpression="flag" HeaderText="flag">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                            </Columns>
                                            <RowStyle CssClass="tr1" />
                                            <HeaderStyle CssClass="tableheader" />
                                            <AlternatingRowStyle CssClass="tr2" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr id="trSave" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right" colspan="2">
                                        &nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server" id="trNewHeading" visible="false">
                        <td style="height: 22px" class="titlesection">
                            Add New Information
                        </td>
                    </tr>
                    <tr runat="server" id="trNewInformation" visible="false">
                        <td>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="height: 10px" class="tr1">
                                    </td>
                                    <td style="width: 350px; height: 10px" class="tr1" valign="top" align="right">
                                    </td>
                                    <td style="width: 510px; height: 10px" class="tr1">
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 8px; height: 21px" class="tr1">
                                    </td>
                                    <td class="tr1">
                                        <div class="pull-right">
                                            <asp:Label runat="server" ID="lblSubject" Text="Subject* :" class="TextLabelMandatory40"></asp:Label>
                                        </div>
                                    </td>
                                    <td style="width: 515px; height: 25px" class="tr1">
                                        &nbsp;<asp:DropDownList ID="ddlSubject" runat="server" CssClass="dropdownlist" Width="217px">
                                        </asp:DropDownList>
                                        <asp:Label runat="server" ID="lblSubName" Text="" class="TextLabelMandatory40" Visible="false"></asp:Label>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlSubject"
                                            Display="Dynamic" ErrorMessage="Subject Required" SetFocusOnError="True" InitialValue="0"
                                            ForeColor="red" ValidationGroup="c"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 8px; height: 21px" class="tr1">
                                    </td>
                                    <td class="tr1">
                                        <div class="pull-right">
                                            <asp:Label ID="lblCriteria" runat="server" Text=" Criteria* :" class="TextLabelMandatory40"></asp:Label>
                                        </div>
                                    </td>
                                    <td style="width: 510px; height: 25px" class="tr1">
                                        &nbsp;
                                        <asp:TextBox ID="txtCriteria" runat="server" CssClass="textbox" Width="217px"></asp:TextBox>
                                        &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCriteria"
                                            Display="Dynamic" ErrorMessage="Criteria Required" SetFocusOnError="True" ForeColor="red"
                                            ValidationGroup="c"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 8px; height: 21px" class="tr1">
                                    </td>
                                    <td class="tr1">
                                        <div class="pull-right">
                                            <asp:Label ID="lblMarks" runat="server" Text=" Total Marks* :" class="TextLabelMandatory40"></asp:Label>
                                        </div>
                                    </td>
                                    <td style="width: 510px; height: 25px" class="tr1">
                                        &nbsp;
                                        <asp:TextBox ID="txtMarks" runat="server" CssClass="textbox" Width="217px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMarks"
                                            Display="Dynamic" ErrorMessage="Total Marks Required" SetFocusOnError="True"
                                            ForeColor="red" ValidationGroup="c"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtMarks" runat="server"
                                            ErrorMessage="Please Enter Only Decimal Values" Operator="DataTypeCheck" Type="Double">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 8px; height: 21px" class="tr1">
                                    </td>
                                    <td class="tr1">
                                        <div class="pull-right">
                                            <asp:Label ID="lblWeightage" runat="server" Text="  Weitage(%)* :" class="TextLabelMandatory40"></asp:Label>
                                        </div>
                                    </td>
                                    <td style="width: 510px; height: 25px" class="tr1">
                                        &nbsp;
                                        <asp:TextBox ID="txtWeightage" runat="server" CssClass="textbox" Width="217px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtWeightage"
                                            Display="Dynamic" ErrorMessage="Weightage Required" SetFocusOnError="True" ForeColor="red"
                                            ValidationGroup="c"></asp:RequiredFieldValidator>
                                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtWeightage" runat="server"
                                            ErrorMessage="Please Enter Only Decimal Values" Operator="DataTypeCheck" Type="Double">
                                        </asp:CompareValidator>
                                    </td>
                                </tr>
                                <tr id="Prom1" runat="server">
                                    <td style="width: 8px; height: 18px" class="tr1">
                                    </td>
                                    <td style="width: 350px; height: 18px" class="tr1" valign="top" align="right">
                                        &nbsp;
                                    </td>
                                    <td style="width: 510px; height: 18px" class="tr1">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tr1" style="width: 8px; height: 11px">
                                    </td>
                                    <td align="right" class="tr1" style="width: 350px; height: 11px" valign="top">
                                    </td>
                                    <td class="tr1" style="width: 510px; height: 11px">
                                    </td>
                                </tr>
                                <tr>
                                    <td class="" style="width: 8px; height: 19px" align="right">
                                    </td>
                                    <td align="center" class="" colspan="2" style="height: 19px">
                                        <asp:Button ID="but_save" runat="server" CssClass="btn btn-primary" Text="Save" OnClick="but_save_Click"
                                            CausesValidation="True" ValidationGroup="c" />&nbsp;
                                        <asp:Button ID="but_cancel" runat="server" CausesValidation="false" CssClass="btn btn-primary"
                                            Text="Cancel" OnClick="but_cancel_Click" />
                                        &nbsp;&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="pull-right">
                                <asp:Button ID="btnCopy" runat="server" CausesValidation="False" CssClass="btn btn-primary"
                                    Text="Copy To All Centers" OnClick="btnCopy_Click" Visible="False" />
                            </div>
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
