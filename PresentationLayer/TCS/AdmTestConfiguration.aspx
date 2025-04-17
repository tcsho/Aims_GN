<%@ Page Title="Admission Test Configuration" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="AdmTestConfiguration.aspx.cs" Inherits="PresentationLayer_TCS_AdmTestConfiguration" %>

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
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Admission Test Configuration"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                    </td>
                                    <td align="right" colspan="2" style="height: 19px; text-align: center">
                                        <div class=" pull-right">
                                            <asp:Button ID="btnAddTest" runat="server" CssClass="btn btn-primary" Font-Bold="False"
                                                OnClick="btnAddTest_Click" Text="Add New" Visible="false" />
                                            <asp:Button ID="btnDeleteTest" runat="server" CssClass="btn btn-danger" Font-Bold="False"
                                                OnClick="btnDeleteTest_Click" Text="Delete" Visible="false" />
                                        </div>
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; width: 20%; text-align: right">
                                        <asp:Label ID="lblsession" runat="server" CssClass="TextLabel40" Text="*Session: "> </asp:Label>
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                        <asp:DropDownList ID="ddlSession" runat="server" CssClass="dropdownlist" AutoPostBack="True"
                                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Height="25px" Width="270px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="1" style="height: 18px; width: 20%; text-align: right">
                                        <asp:Label ID="lblClass" runat="server" CssClass="TextLabel40" Text="*Class: ">
                                        </asp:Label>
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Height="25px" Width="270px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; width: 20%; text-align: right">
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; width: 20%; text-align: right">
                                        <asp:Label runat="server" Text="*Test Type: " CssClass="TextLabel40" Visible="false"></asp:Label>
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 20%;">
                                        <asp:RadioButtonList ID="chkTestType" runat="server" AutoPostBack="True" CssClass="radio"
                                            Width="100%"  RepeatDirection="Horizontal" RepeatColumns="3">
                                        </asp:RadioButtonList>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; width: 20%; text-align: right">
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                    </td>
                                    <td align="left" colspan="1" style="height: 18px; width: 40%;">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr class="tr2">
                                    <td id="tdGridHeader" runat="server" class="titlesection" visible="false">
                                        &nbsp; Test Details
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                    </td>
                                </tr>
                                <tr>
                                    <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvTest_PreRender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:BoundField DataField="AdmTest_Id" HeaderText="AdmTest_Id" SortExpression="AdmTest_Id">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmTestDetail_Id" HeaderText="AdmTestDetail_Id">
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
                                            <asp:BoundField DataField="Title" HeaderText="Title">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="OpeningDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Opening Date" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ClosingDate" DataFormatString="{0:MM/dd/yyyy}" HeaderText="Closing Date" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmTestName" HeaderText="Name">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmTestDesc" HeaderText="Description" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NumberOfQuestions" HeaderText="Total Questions">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TotalMarks" HeaderText="Total Marks">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Weightage" HeaderText="Weightage" Visible="false">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmTestType_Id" HeaderText="AdmTestType_Id">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="ModifiedBy" HeaderText="ModifiedBy">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("AdmTest_Id") %>'
                                                        ForeColor="#004999" ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click" Style="text-align: center;
                                                        font-weight: bold;" ToolTip="Edit Record"  Visible='<%# (int)( Eval("AdmTestType_Id"))==3 %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Show Pool">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnShowPool" runat="server" CommandArgument='<%# Eval("AdmTestDetail_Id") %>'
                                                        ForeColor="#004999" ImageUrl="~/images/viewIcon.gif" OnClick="btnShowPool_Click"
                                                        Style="text-align: center; font-weight: bold;" ToolTip="Show Pool" Visible='<%# (int)( Eval("AdmTestType_Id"))<3 %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server" id="trViewPool" visible="false">
                        <td style="height: 6px" colspan="3">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr class="tr2">
                                    <td id="td1" runat="server" class="titlesection">
                                        &nbsp; Test Pool Details
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                    </td>
                                </tr>
                                <tr>
                                    <asp:GridView ID="gvPool" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvPool_PreRender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:BoundField DataField="Pool_Id" HeaderText="Pool_Id">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AdmTestName" HeaderText="AdmTestName">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Description" HeaderText="Description">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="TimeInSeconds" HeaderText="Time In Seconds">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MarksPerQuestion" HeaderText="Marks Per Question">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="MinQuest" HeaderText="Minimum Question">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditPool" runat="server" CommandArgument='<%# Eval("Pool_Id") %>'
                                                        ForeColor="#004999" ImageUrl="~/images/edit.gif" OnClick="btnEditPool_Click"
                                                        CausesValidation="false" Style="text-align: center; font-weight: bold;" ToolTip="Edit Pool Details" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Show Questions">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnShowQuestion" runat="server" CommandArgument='<%# Eval("Pool_Id") %>'
                                                        ForeColor="#004999" ImageUrl="~/images/viewIcon.gif" Style="text-align: center;
                                                        font-weight: bold;" ToolTip="Show Questions" OnClick="btnShow_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Add Question">
                                                <ItemStyle HorizontalAlign="Center" />
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnAddQuestion" runat="server" CommandArgument='<%# Eval("Pool_Id") %>'
                                                        OnClick="btnAddQuestion_Click" ForeColor="#004999" ImageUrl="~/images/add4.jpg"
                                                        Style="text-align: center; font-weight: bold;" ToolTip="Add Question" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server" id="trViewQuestion" visible="false">
                        <td valign="top" colspan="3">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr class="tr2">
                                    <td class="titlesection">
                                        &nbsp; Question Details
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        Width="100%" OnPreRender="gvQuestions_PreRender" CssClass="datatable table table-striped table-responsive">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:BoundField DataField="Quest_ID" SortExpression="Quest_ID" HeaderText="Quest_ID">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Quest_ID" HeaderText="Quest_ID">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                                <ItemStyle HorizontalAlign="Center" Width="5%" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="QuestText" HeaderText="Question Text">
                                                <HeaderStyle HorizontalAlign="Center" Width="25%" />
                                                <ItemStyle HorizontalAlign="Center" Width="25%" Font-Size="14px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="AnsPointValue" SortExpression="AnsPointValue" HeaderText="AnsPointValue">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="NegtvPointValue" HeaderText="Negative Point Value">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Comments" HeaderText="Comments">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Pool_Id" HeaderText="Pool_Id">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False" Font-Size="14px"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("Quest_ID") %>'
                                                        ForeColor="#004999" ImageUrl="~/images/edit.gif" OnClick="btnEditQuestion_Click"
                                                        Style="text-align: center; font-weight: bold;" ToolTip="Edit Question" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False" Font-Size="14px"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("Quest_ID") %>'
                                                        OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');"
                                                        ForeColor="#004999" ImageUrl="~/images/delete.gif" OnClick="btnDeleteQuestion_Click"
                                                        Style="text-align: center; font-weight: bold;" ToolTip="Delete Question" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Show Answer">
                                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False" Font-Size="14px"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnShow" runat="server" CommandArgument='<%# Eval("Quest_ID") %>'
                                                        ForeColor="#004999" ImageUrl="~/images/viewIcon.gif" OnClick="btnShowAnswer_Click"
                                                        Style="text-align: center; font-weight: bold;" ToolTip="Show Answer" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Add Answer" Visible="false">
                                                <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False" Font-Size="14px"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnAnswerEdit" runat="server" CommandArgument='<%# Eval("Quest_ID") %>'
                                                        ForeColor="#004999" ImageUrl="~/images/add4.jpg" Style="text-align: center; font-weight: bold;"
                                                        ToolTip="Edit Record" OnClick="btnAnswerAdd_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Description" HeaderText="Description">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                        </Columns>
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server" id="trViewAnswer" visible="false">
                        <td valign="top" colspan="3" style="height: 200px">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <tr>
                                    <td style="height: 22px" class="titlesection">
                                        Question Answer's Option
                                    </td>
                                </tr>
                                <tr id="tr2" runat="server" style="width: 100%">
                                    <td style="height: 19px; text-align: center" align="right">
                                        &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <asp:GridView ID="gvAnswerList" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                        Width="100%" CssClass="datatable table table-striped table-responsive" OnPreRender="gvAnswerList_Prerender">
                                        <AlternatingRowStyle CssClass="tr2" />
                                        <Columns>
                                            <asp:BoundField DataField="QuestDetail_ID" SortExpression="QuestDetail_ID" HeaderText="QuestDetail_ID">
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Sr. #">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="Quest_ID" HeaderText="Quest_ID">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Options" SortExpression="Options" HeaderText="Options">
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="IsCorrect" HeaderText="IsCorrect">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                                                <ItemStyle CssClass="hide" />
                                                <HeaderStyle CssClass="hide" />
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="Correct / Wrong">
                                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                                <ItemTemplate>
                                                    <asp:Label ID="Label2" runat="server" Visible='<%# Convert.ToBoolean( Eval("IsCorrect"))==false %>'
                                                        class="glyphicon glyphicon-remove" ForeColor="Red"></asp:Label>
                                                    <asp:Label ID="Label3" runat="server" Visible='<%# Convert.ToBoolean( Eval("IsCorrect"))==true %>'
                                                        class="glyphicon glyphicon-ok" ForeColor="Green"></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                </EditItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Edit">
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" Font-Size="14px"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnAnswerEdit" runat="server" CommandArgument='<%# Eval("QuestDetail_ID") %>'
                                                        ForeColor="#004999" ImageUrl="~/images/edit.gif" Style="text-align: center; font-weight: bold;"
                                                        ToolTip="Edit Record" OnClick="btnAnswerEdit_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete">
                                                <ItemStyle HorizontalAlign="Center" Wrap="False" Font-Size="14px"></ItemStyle>
                                                <HeaderStyle HorizontalAlign="Center" Width="75px" Wrap="False"></HeaderStyle>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnAnswerDelete" runat="server" CommandArgument='<%# Eval("QuestDetail_ID") %>'
                                                        ForeColor="#004999" ImageUrl="~/images/delete.gif" Style="text-align: center;
                                                        font-weight: bold;" ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');"
                                                        OnClick="btnAnswerDelete_Click" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                        <RowStyle CssClass="tr1" />
                                        <HeaderStyle CssClass="tableheader" />
                                        <AlternatingRowStyle CssClass="tr2" />
                                    </asp:GridView>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <div id="tblAddTest" runat="server" visible="false">
                                    <tr class="tr2">
                                        <td id="trUpdateMarks" runat="server" class="titlesection" colspan="7">
                                            &nbsp; Test Details
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            <asp:Label ID="lblTestName" runat="server" CssClass=" TextLabel" Text="Title: "></asp:Label>
                                        </td>
                                        <td align="left" colspan="1" style="height: 18px; width: 20%;">
                                            <asp:TextBox ID="txtTestName" runat="server" CssClass="form-control " Enabled="false"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestName"
                                                ErrorMessage="Test Name Required" ForeColor="Red" ValidationGroup="test" />
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr id="trODate" runat="server" visible="false" style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            <asp:Label ID="lblOpening" runat="server" CssClass=" TextLabel" Text="Opening Date: "></asp:Label>
                                        </td>
                                        <td align="left" colspan="1" style="height: 18px; width: 20%;">
                                            <asp:TextBox ID="txtOpening" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtOpening"
                                                ErrorMessage="Opening Date Required" ForeColor="Red" ValidationGroup="test" />
                                            <asp:CompareValidator ID="CompareValidator6" ControlToValidate="txtOpening" runat="server"
                                                ValidationGroup="test" ForeColor="Red" ErrorMessage="Please Enter Correct Date"
                                                Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr id="trCDate" runat="server" visible="false" style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            <asp:Label ID="lblClosing" runat="server" CssClass=" TextLabel" Text="Closing Date: "></asp:Label>
                                        </td>
                                        <td align="left" colspan="1" style="height: 18px; width: 20%;">
                                            <asp:TextBox ID="txtClosing" runat="server" CssClass="form-control">
                                            </asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtClosing"
                                                ErrorMessage="Closing Date Required" ForeColor="Red" ValidationGroup="test" />
                                            <asp:CompareValidator ID="CompareValidator7" ControlToValidate="txtClosing" runat="server"
                                                ValidationGroup="test" ForeColor="Red" ErrorMessage="Please Enter Correct Date"
                                                Operator="DataTypeCheck" Type="Date"></asp:CompareValidator>
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr runat="server" visible="false" style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            <asp:Label ID="lblTestDesc" runat="server" CssClass=" TextLabel" Text="Test Description: "></asp:Label>
                                        </td>
                                        <td align="left" colspan="1" style="height: 18px; width: 20%;">
                                            <asp:TextBox ID="txtTestDesc" runat="server" CssClass="form-control" Rows="3" TextMode="MultiLine"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtTestDesc"
                                                ErrorMessage="Test Description Required" ForeColor="Red" ValidationGroup="test" />
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            <asp:Label ID="lblMarks" runat="server" CssClass=" TextLabel" Text="Total Marks: "></asp:Label>
                                        </td>
                                        <td align="left" colspan="1" style="height: 18px; width: 20%;">
                                            <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="DataTypeCheck"
                                                ForeColor="Red" ValidationGroup="test" Type="Double" ControlToValidate="txtMarks"
                                                ErrorMessage="Please enter a Numeric value" />
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            &nbsp;
                                        </td>
                                        <td align="left" colspan="1" style="height: 18px; width: 20%;">
                                            &nbsp;
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                                Text="Save" CausesValidation="true" ValidationGroup="test" />
                                            <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                OnClick="btnCancel_Click" Text="Cancel" />
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                </div>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 6px" colspan="3">
                            <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                <div id="divPool" runat="server" visible="false">
                                    <tr class="tr2">
                                        <td id="Td2" runat="server" class="titlesection" colspan="7">
                                            &nbsp; Test Pool Details
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            <asp:Label ID="lblTotalQuestion" runat="server" CssClass=" TextLabel40" Text="Minimum Questions: "></asp:Label>
                                        </td>
                                        <td align="left" colspan="1" style="height: 18px; width: 20%;">
                                            <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator8" runat="server" Operator="DataTypeCheck"
                                                ForeColor="Red" ValidationGroup="test" Type="Integer" ControlToValidate="txtTotal"
                                                ErrorMessage="Please enter a Numeric value" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtTotal"
                                                ErrorMessage="Total Questions Required" ForeColor="Red" ValidationGroup="test" />
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            <asp:Label ID="Label12" runat="server" CssClass=" TextLabel" Text="Total Marks Per Question: "></asp:Label>
                                        </td>
                                        <td align="left" colspan="1" style="height: 18px; width: 20%;">
                                            <asp:TextBox ID="txtMarksQuestion" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:CompareValidator ID="CompareValidator11" runat="server" Operator="DataTypeCheck"
                                                ForeColor="Red" ValidationGroup="test" Type="Double" ControlToValidate="txtMarks"
                                                ErrorMessage="Please enter a Numeric value" />
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                            <asp:Label ID="Label5" runat="server" CssClass="TextLabel">Answer In Seconds:</asp:Label>
                                        </td>
                                        <td style="width: 510px; height: 25px" class="tr2">
                                            <asp:TextBox ID="txtAnsInSec" runat="server" CssClass="form-control textbox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAnsInSec"
                                                ErrorMessage="Answer In Seconds Required" ForeColor="Red" ValidationGroup="Question" />
                                            <asp:CompareValidator ID="CompareValidator3" ControlToValidate="txtAnsInSec" runat="server"
                                                ValidationGroup="Question" ForeColor="Red" ErrorMessage="Enter Only Integer Values"
                                                Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                    <tr style="width: 100%">
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                            <asp:Button ID="btnSavepool" runat="server" CssClass="btn btn-primary" Text="Save"
                                                CausesValidation="true" ValidationGroup="test" OnClick="btnSavePool_Click" />
                                            <asp:Button ID="btnCancelPool" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                                Text="Cancel" OnClick="btnCancelPool_Click" />
                                        </td>
                                        <td align="right" colspan="1" style="height: 18px; width: 40%; text-align: right">
                                        </td>
                                    </tr>
                                </div>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" colspan="3" style="height: 200px">
                            <asp:Panel ID="panAddQuestion" runat="server" Width="100%" Height="75%" Visible="false">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr class="tr2">
                                            <td class="titlesection">
                                                Add / Update New Question
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0" runat="server">
                                                    <tr>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                            <b>
                                                                <asp:Label runat="server" ID="lblTName" Text="Test Name:" CssClass="TextLabel"></asp:Label></b>
                                                        </td>
                                                        <td style="width: 350px" class="tr2" valign="top" align="left">
                                                            <b>&nbsp;&nbsp;
                                                                <asp:Label ID="lblName" runat="server" Text="" CssClass="TextLabel"></asp:Label></b>
                                                        </td>
                                                        <td style="width: 510px; height: 10px" class="tr2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                        </td>
                                                        <td style="width: 350px" class="tr2" valign="top" align="left">
                                                        </td>
                                                        <td style="width: 510px; height: 10px" class="tr2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                            <asp:Label runat="server" ID="lblPool" Text="Question Group:" CssClass="TextLabel"></asp:Label></b>
                                                        </td>
                                                        <td style="width: 350px" class="tr2" valign="top" align="left">
                                                            <b>&nbsp;&nbsp;
                                                                <asp:Label ID="lblPooldesc" runat="server" Text="" CssClass="TextLabel"></asp:Label></b>
                                                        </td>
                                                        <td style="width: 510px; height: 10px" class="tr2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                        </td>
                                                        <td style="width: 350px" class="tr2" valign="top" align="left">
                                                        </td>
                                                        <td style="width: 510px; height: 10px" class="tr2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                            <asp:Label ID="Label2" runat="server" CssClass=" TextLabel">Question:</asp:Label>
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtQuestion" runat="server" CssClass=" form-control textbox" 
                                                                TextMode="MultiLine" Rows="3" MaxLength="500"></asp:TextBox>
                                                                <p>Max Length 500 Characters</p>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuestion"
                                                                ErrorMessage="Question Required" ForeColor="Red" ValidationGroup="Question" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                        </td>
                                                        <td style="width: 350px" class="tr2" valign="top" align="left">
                                                        </td>
                                                        <td style="width: 510px; height: 10px" class="tr2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                            <asp:Label ID="Label3" runat="server" CssClass="TextLabel">Answer Point Value:</asp:Label>
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtPValue" runat="server" CssClass="form-control textbox" Enabled="False"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPValue"
                                                                ErrorMessage="Answer Point Value Required" ForeColor="Red" ValidationGroup="Question" />
                                                            <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtPValue" runat="server"
                                                                ForeColor="Red" ErrorMessage="Enter Only Decimal Values" Operator="DataTypeCheck"
                                                                Type="Double"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                            <asp:Label ID="lblComments" runat="server" CssClass="TextLabel">Comments:</asp:Label>
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtComments" runat="server" CssClass="form-control textbox"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtComments"
                                                                ErrorMessage="Comments Required" ForeColor="Red" ValidationGroup="Question" />
                                                        </td>
                                                    </tr>
                                                  
                                                    <tr>
                                                        <td style="width: 350px" class="tr2" valign="top" align="right">
                                                            <asp:Label ID="Label4" runat="server" CssClass="TextLabel">Answer Negative Point Value:</asp:Label>
                                                        </td>
                                                        <td style="width: 510px; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtNValue" runat="server" CssClass="form-control textbox"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNValue"
                                                                ErrorMessage="Answer Negative Point Value Required" ForeColor="Red" ValidationGroup="Question" />
                                                            <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtNValue" runat="server"
                                                                ValidationGroup="Question" ForeColor="Red" ErrorMessage=" Enter Only Decimal Values"
                                                                Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>
                                                        </td>
                                                    </tr>
                                                      <tr id="Prom1" runat="server">
                                                        <td style="width: 350px; height: 18px" class="tr2" valign="top" align="right">
                                                            <asp:Label ID="lblAnnswer" runat="server" CssClass="TextLabel" Text="Answer:"></asp:Label>
                                                        </td>
                                                        <td style="width: 510px; height: 18px" class="tr2">
                                                            <asp:TextBox ID="txtAddAnswer" runat="server" CssClass=" form-control textbox"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAddAnswer"
                                                                ErrorMessage="Answer Required" ForeColor="Red" ValidationGroup="Question" />
                                                             
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right">
                                                        </td>
                                                        <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right">
                                                            <asp:Button ID="btnSaveQuestion" runat="server" CssClass="btn btn-primary" Text="Save"
                                                                CausesValidation="True" ValidationGroup="Question" OnClick="btnSaveQuestion_Click">
                                                            </asp:Button>&nbsp;
                                                            <asp:Button ID="btnCancelQuestion" runat="server" CssClass="btn btn-danger" CausesValidation="False"
                                                                Text="Cancel" OnClick="btnCancelQuestion_Click"></asp:Button>&nbsp;&nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right">
                                                           
                                                        </td>
                                                        <td style="width: 510px; height: 11px" class="tr2">
                                                        <img runat="server" id="imgAnswer" src="../../images/Answers.png" visible="false"/>
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
                    <tr runat="server" id="trAddAnswer" visible="false">
                        <td valign="top" colspan="3" style="height: 150px">
                            <asp:Panel ID="pan_new2" runat="server" Width="100%" Height="50%">
                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                    <tbody>
                                        <tr>
                                            <td style="height: 22px" class="titlesection">
                                                Add / Update New Answer's Option
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table cellspacing="0" cellpadding="0" width="100%" border="0">
                                                    <tr>
                                                        <td style="width: 8px; height: 11px" class="tr2">
                                                        </td>
                                                        <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right">
                                                        </td>
                                                        <td style="width: 510px; height: 11px" class="tr2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 40%" class="tr2" valign="top" align="right">
                                                            <asp:Label ID="lblQuestion" runat="server" CssClass="TextLabel" Text="Question :"></asp:Label>
                                                        </td>
                                                        <td style="width: 40%; height: 25px" class="tr2">
                                                            <asp:Label ID="lblQuesDesc" runat="server" CssClass="TextLabel" Text=""></asp:Label>
                                                        </td>
                                                        <td style="width: 510px; height: 11px" class="tr2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 40%" class="tr2" valign="top" align="right">
                                                            <asp:Label ID="Label6" runat="server" CssClass="TextLabel" Text="Answer :"></asp:Label>
                                                        </td>
                                                        <td style="width: 40%; height: 25px" class="tr2">
                                                            <asp:TextBox ID="txtAnswer" runat="server" CssClass=" form-control textbox"></asp:TextBox>
                                                            <p>Max Length 500 Characters </p>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAnswer"
                                                                ErrorMessage="Answer Required" ForeColor="Red" ValidationGroup="Answer" />
                                                                
                                                        </td>
                                                        <td style="width: 8px; height: 21px" class="tr2">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" class="tr2" style="width: 40%; height: 18px" valign="top">
                                                            <asp:Label runat="server" ID="lblAnswerOption" CssClass="TextLabel" Text="Answer Options:"></asp:Label>
                                                        </td>
                                                        <td class="tr2" style="width: 40%; height: 25px">
                                                            <asp:DropDownList ID="ddlAnswOption" runat="server" AutoPostBack="True" CssClass="dropdownlist">
                                                                <asp:ListItem Value="0" Text="In Correct"></asp:ListItem>
                                                                <asp:ListItem Value="1" Text="Correct"></asp:ListItem>
                                                            </asp:DropDownList>
                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAnswOption"
                                                                InitialValue="-1" ErrorMessage="Answer Status Required" ForeColor="Red" ValidationGroup="Answer" />
                                                        </td>
                                                        <td class="tr2" style="width: 8px; height: 18px">
                                                            &nbsp;
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="width: 8px; height: 11px" class="tr2">
                                                        </td>
                                                        <td style="width: 350px; height: 11px" class="tr2" valign="top" align="right">
                                                            <asp:Button ID="btnAnswerSave" OnClick="btnAnswerSave_Click" runat="server" CssClass="btn btn-primary"
                                                                Text="Save Answer" CausesValidation="true" ValidationGroup="Answer"></asp:Button>&nbsp;
                                                            <asp:Button ID="btnCalnalSkill" OnClick="btnCancelAnswer_Click" runat="server" CssClass="btn btn-danger"
                                                                CausesValidation="False" Text="Cancel"></asp:Button>&nbsp;&nbsp;
                                                        </td>
                                                        <td style="width: 510px; height: 11px" class="tr2">
                                                       <%-- <img src="../../images/Answers.png"/>--%>
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
