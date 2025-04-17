<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TermEvaluationCriteria.aspx.cs" Inherits="PresentationLayer_TermEvaluationCriteria" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
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
                                //                       jq('table.datatable').DataTable({
                                //                           destroy: true,
                                //                           // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                                //                           //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                //                           dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                //            "<'row'<'col-sm-12'tr>>" +
                                //                           //                     "<'row'<'col-sm-12'l>>" +
                                //             "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                //                           "columnDefs": [

                                //                                   { orderable: false, targets: [8, 9]} //disable sorting on toggle button
                                //                               ]

                                //                       ,
                                //                           tableTools:
                                //           { //Start of tableTools collection
                                //               "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                //               "aButtons":
                                //                [ //start of button main/master collection



                                //     { // ******************* Start of child collection for export button
                                //     "sExtends": "collection",
                                //     "sButtonText": "<span class='glyphicon glyphicon-export'></span>",
                                //     "sToolTip": "Export Data",
                                //     "aButtons":
                                //            [ //start of button export buttons collection

                                //     // ******************* Start of copy button
                                //       {
                                //       "sExtends": "copy",
                                //       "sButtonText": "<span class='glyphicon glyphicon-copy'></span> Copy Contents",
                                //       "sToolTip": "Copy Data"
                                //         , "mColumns": [1, 2, 3, 4, 5, 6, 7]
                                //   } // ******************* end of copy button

                                //     // ******************* Start of csv button
                                //     , {
                                //         'sExtends': 'csv',
                                //         'bShowAll': false // ,'sFileName': "DataInCSVFormat.csv"
                                //         ,
                                //         "sFileName": "DataInCSVFormat - *.csv",
                                //         "sToolTip": "Save as CSV",
                                //         //               'sButtonText': 'Save as CSV',
                                //         "sButtonText": "<span class='fa fa-file-text-o'></span> Save to CSV",
                                //         "sNewLine": "auto"
                                //            , "mColumns": [1, 2, 3, 4, 5, 6, 7]
                                //     }  // ******************* end of csv button

                                //     // ******************* Start of excel button
                                //      , {
                                //          'sExtends': 'xls',
                                //          'bShowAll': false,
                                //          "sFileName": "DataInExcelFormat.xls",
                                //          //                   'sButtonText': 'Save to Excel',
                                //          "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                                //          "sToolTip": "Save as Excel"
                                //           , "mColumns": [1, 2, 3, 4, 5, 6, 7]
                                //      }  // ******************* End of excel button


                                //     // ******************* Start of PDF button
                                //     , {
                                //         'sExtends': "pdf",
                                //         'bShowAll': false,
                                //         "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                                //         //               'sButtonText': 'Save to PDF',
                                //         "sFileName": "DataInPDFFormat.pdf",
                                //         "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                                //            , "mColumns": [1, 2, 3, 4, 5, 6, 7]
                                //         //,"sPdfMessage": "Your custom message would go here."
                                //     } // *********************  End of PDF button 

                                //      ]// ******************* end of Export buttons collection
                                // }    // ******************* end of child of export buttons collection
                                //   ] // ******************* end of button master Collection
                                //           } // ******************* end of tableTools
                                //, "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 200, 'bLengthChange': true // ,"bJQueryUI":true
                                //, "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false //, fixedHeader: true , "stateSave": true
                                //, //--- Dynamic Language---------
                                //                           "oLanguage": {
                                //                               "sZeroRecords": "There are no Records that match your search critera",
                                //                               //                    "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
                                //                               "sInfo": "Displaying _START_ to _END_ of _TOTAL_ records",
                                //                               "sInfoEmpty": "Showing 0 to 0 of 0 records",
                                //                               "sInfoFiltered": "(filtered from _MAX_ total records)",
                                //                               "sEmptyTable": 'No Rows to Display.....!',
                                //                               "sSearch": "Search :"
                                //                           }
                                //                       }
                                //          );
                                //                   }
                                //                   catch (err) {
                                //                       alert('datatable ' + err);
                                //                   }

                                //****************************************************************
                                $('table.datatable').DataTable({
                                    destroy: true,
                                    "dom": 'Blfrtip',

                                    buttons: [
                                        {
                                            extend: 'excel',
                                            exportOptions: {
                                                columns: [1, 2, 3, 4, 5, 6,7]
                                            }
                                        }
                                    ],
                                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                });
                            }
                            catch (err) {
                                alert('datatable ' + err);
                            }


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
                        <td style="height: 6px" colspan="3">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr style="width: 100%">
                                     
                                        <tr>
                                            <td style="height: 100%" width=".5%"></td>
                                            <td id="tdFrmHeading" class="formheading">
                                                <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Term Evaluation Criteria"></asp:Label>
                                                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                    border="0" />
                                            </td>
                                        </tr>
                                </tbody>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr>
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">Region*:
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="217px" OnSelectedIndexChanged="ddl_region_SelectedIndexChanged"
                                            AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>

                                </tr>
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">Class&nbsp;&nbsp;
                                    </td>
                                    <td style="width: 60%" align="left">
                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged" Width="217px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1"></td>
                                    <td style="height: 18px; width: 40%; text-align: right" align="right" colspan="1">
                                        <asp:LinkButton ID="but_new" OnClick="but_new_Click" runat="server" CssClass="leftlink"
                                            Font-Bold="False" ValidationGroup="btnNew">Add New Criteria</asp:LinkButton>
                                    </td>
                        </td>
                    </tr>
                    <tr style="width: 100%">
                        <td align="left" style="width: 100%" colspan="2">
                            <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3">
                            <asp:Panel ID="pan_New" runat="server" Width="100%" Height="100%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="height: 22px" class="titlesection">Add New Information
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td style="height: 10px" class="tr2"></td>
                                                        <td style="width: 350px; height: 10px" class="tr2" valign="top" align="right"></td>
                                                        <td style="width: 510px; height: 10px" class="tr2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr2"></td>
                                                        <td class="TextLabelMandatory40">Criteria Name*:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtCritName" runat="server"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr2"></td>
                                                        <td class="TextLabelMandatory40">Total Marks*:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtMarks" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtMarks" runat="server"
                                                                ErrorMessage="Please Enter Only Decimal Values" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 21px" class="tr2"></td>
                                                        <td class="TextLabelMandatory40">Weitage(%)*:
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtGrade" runat="server"></asp:TextBox>
                                                            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtGrade" runat="server"
                                                                ErrorMessage="Please Enter Only Decimal Values" Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td class="tr2" style="width: 8px; height: 18px">&nbsp;
                                                        </td>
                                                        <td class="TextLabelMandatory40">Evaluation Type*:
                                                        </td>
                                                        <td class="tr2" style="width: 510px; height: 25px">
                                                            <asp:DropDownList ID="list_EvlType" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                                                Width="128px" Height="23px">
                                                            </asp:DropDownList>
                                                        </td>
                                                    </tr>
                                                    <tr style="width: 100%">
                                                        <td class="tr2" style="width: 8px; height: 18px">&nbsp;
                                                        </td>
                                                        <td class="TextLabelMandatory40">Select Subject*:
                                                        </td>
                                                        <td style="width: 60%" align="left">

                                                            <asp:DropDownList ID="list_subject" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                                                Width="217px">
                                                            </asp:DropDownList>
                                                            <asp:CheckBoxList ID="cblSubjects" runat="server" CssClass="dropdownlist">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr style="width: 100%">
                                                        <td class="tr2" style="width: 8px; height: 18px">&nbsp;
                                                        </td>
                                                        <td class="TextLabelMandatory40">Select Term*:
                                                        </td>
                                                        <td style="width: 60%" align="left">


                                                            <asp:DropDownList ID="list_term" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                                                OnSelectedIndexChanged="list_term_SelectedIndexChanged" Width="217px">
                                                            </asp:DropDownList>
                                                            <asp:CheckBoxList ID="cblTerm" runat="server" CssClass="dropdownlist">
                                                            </asp:CheckBoxList>
                                                        </td>
                                                    </tr>
                                                    <tr id="Prom1" runat="server">
                                                        <td style="width: 8px; height: 18px" class="tr2"></td>
                                                        <td style="width: 350px; height: 18px" class="tr2" valign="top" align="right">&nbsp;
                                                        </td>
                                                        <td style="width: 510px; height: 18px" class="tr2">&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px" class="tr2"></td>
                                                        <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right"></td>
                                                        <td style="width: 510px; height: 11px" class="tr2"></td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 19px" class=""></td>
                                                        <td style="height: 19px" class="" align="center" colspan="2">&nbsp;
                                                            <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                                                                Text="Save"></asp:Button>
                                                            &nbsp;<asp:Button ID="but_cancel" OnClick="but_cancel_Click" runat="server" CssClass="btn btn-primary"
                                                                CausesValidation="False" Text="Cancel"></asp:Button>&nbsp;&nbsp;
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
                        <td align="left" style="width: 100%;" colspan="2">
                            <asp:GridView ID="gvSubjects" runat="server" AutoGenerateColumns="False" CssClass="datatable table table-striped table-responsive"
                                EmptyDataText="No Record Exists." OnPreRender="gvSubjects_PreRender">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:BoundField DataField="Evaluation_Criteria_Id" SortExpression="Evaluation_Criteria_Id"
                                        HeaderText="Evaluation_Criteria_Id">
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
                                    <asp:BoundField DataField="Type" HeaderText="Term" />

                                    <asp:BoundField DataField="Subject_Name" HeaderText="Subject_Name">
                                        <HeaderStyle HorizontalAlign="Left" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="EvaluationType" HeaderText="EvaluationType" />
                                    <asp:BoundField DataField="Criteria" HeaderText="Criteria">
                                        <HeaderStyle HorizontalAlign="Left" Width="25%" />
                                        <ItemStyle HorizontalAlign="Left" Width="25%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Total_Marks" SortExpression="Total_Marks" HeaderText="Total_Marks">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Weightage" HeaderText="Weightage"></asp:BoundField>
                                    <asp:BoundField DataField="Type" HeaderText="Type">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Evaluation_Criteria_Type_Id" SortExpression="Evaluation_Criteria_Type_Id" HeaderText="Evaluation_Criteria_Type_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>

                                    <asp:BoundField DataField="Evaluation_Type_Id" SortExpression="Evaluation_Type_Id" HeaderText="Evaluation_Type_Id">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>

                                    <asp:TemplateField HeaderText="Edit">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("Evaluation_Criteria_Id") %>'
                                                ForeColor="#004999" ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" Style="text-align: center; font-weight: bold;"
                                                ToolTip="Edit Record" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("Evaluation_Criteria_Id") %>'
                                                ForeColor="#004999" ImageUrl="~/images/delete.gif" OnClick="btnDelete_Click"
                                                Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="cb" Visible="false">
                                        <EditItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </EditItemTemplate>
                                        <HeaderTemplate>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Select</asp:LinkButton>
                                        </HeaderTemplate>
                                        <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="30px"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="CheckBox1" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Copy" Visible="false">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnCopy" runat="server" ForeColor="#004999" OnClick="btnCopy_Click"
                                                Style="text-align: center; font-weight: bold;" ToolTip="Copy" ImageUrl="~/images/edit.gif"
                                                CommandArgument='<%# Eval("Evaluation_Criteria_Id") %>' Visible="false"></asp:ImageButton>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Width="30px" />
                                    </asp:TemplateField>



                                </Columns>
                                <HeaderStyle CssClass="tableheader" BackColor="#868B74" />
                                <RowStyle CssClass="tr2" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="trSave" runat="server" style="width: 100%">
                        <td style="height: 19px; text-align: center" align="right" colspan="2">
                            <asp:Button ID="btn_apply" runat="server" CssClass="btn btn-primary" OnClick="btn_apply_Click"
                                Text="Apply All Changes" />
                        </td>
                    </tr>
            </table>
            </td> </tr> </tbody> </table>
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
