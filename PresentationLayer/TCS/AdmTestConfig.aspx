<%@ Page Title="Admission Test Configuration" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true"
    CodeFile="AdmTestConfig.aspx.cs" Inherits="PresentationLayer_TCS_AdmTestConfig" %>

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
            <script type="text/javascript">
                function openModal() {
                    //                    $('#myModal').modal('show');
                    $('#PoolConfig').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModal() {

                    $('#PoolConfig').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                function openModalQuestion() {
                    $('#PoolQuestion').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalQuestion() {

                    $('#PoolQuestion').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                function openModalAnswer() {
                    $('#AnswerModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalAnswer() {

                    $('#AnswerModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
            <script type="text/javascript">
                function openModalTest() {
                    //                    $('#myModal').modal('show');
                    $('#TestModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModalTest() {

                    $('#TestModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
            </script>
           <div class="form-group">


                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Admission Test Configuration"></asp:Label>
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
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px" Enabled="false">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblClass" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                                Text="*Class : "></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlClass" runat="server" CssClass="dropdownlist" Width="218px"
                                    AutoPostBack="True" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label runat="server" Text="*Test Type: " CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="chkTestType" runat="server" AutoPostBack="True"
                                    CssClass="dropdownlist " Width="218px"
                                    OnSelectedIndexChanged="chkTestType_SelectedIndexChanged">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                    <div runat="server" class="col-lg-4 col-md-4 col-sm-4 col-xs-12 form-group">
                        <div class="pull-right">
                            <asp:Button ID="btnAddTest" runat="server" CssClass="btn btn-primary" Font-Bold="False"
                                OnClick="btnAddTest_Click" Text="Add New" Visible="false" />
                            <asp:Button ID="btnDeleteTest" runat="server" CssClass="btn btn-danger" Font-Bold="False"
                                OnClick="btnDeleteTest_Click" Text="Delete" Visible="false" />

                            <asp:Button ID="btnAssignCenters" runat="server" CssClass="btn btn-info "
                                Text="Assign To Centers" OnClick="btnAssignCenters_Click" Visible="false" />
                        </div>

                    </div>
                </div>

                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridTestTitle" visible="false">
                    Test Details
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <br />
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
                            <asp:BoundField DataField="NumberOfQuestions" HeaderText="Total Questions" Visible="false">
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
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("AdmTest_Id") %>'
                                        ForeColor="#004999" OnClick="btnEdit_Click" CssClass="btn-lg"
                                        ToolTip="Edit Record" Visible='<%# (int)( Eval("AdmTestType_Id"))==3 %>'>
                                    <i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
                </div>

                <div runat="server" id="divTestButtons" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group text-uppercase" visible="false">
                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 ">
                        <div class="pull-left">
                            <asp:TreeView ID="trvw_test" runat="server" OnSelectedNodeChanged="trvw_test_SelectedNodeChanged"
                                ParentNodeStyle-CssClass="TextLabelMandatory40 text-left" Font-Size="Large">
                                <HoverNodeStyle />
                                <NodeStyle></NodeStyle>
                                <ParentNodeStyle />
                                <SelectedNodeStyle BackColor="#003366" ForeColor="#ffffff" />
                            </asp:TreeView>
                        </div>
                    </div>
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
                        <div runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-inline text-uppercase"
                            id="divPoolConf" visible="false">
                            <div class="pull-right">
                                <asp:LinkButton ID="btnEditPool" runat="server" CssClass="btn btn-primary" ToolTip="Edit Pool Configuration"
                                    Text="Edit Pool Configuration" OnClick="btnEditPool_Click">
                           <%--<i class="glyphicon glyphicon-pencil"  ></i>--%>
                                </asp:LinkButton>


                                <asp:LinkButton ID="btnViewPoolConfig" runat="server" CssClass="btn  btn-primary  " ToolTip="View Pool Configuration"
                                    Text="View Pool Configuration" OnClick="btnViewPool_Click" Visible="false">
                       <%-- <span class="glyphicon glyphicon-menu-hamburger"></span>--%>
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnAddQuestion" runat="server" CssClass="btn btn-primary " ToolTip="Add Question to Pool"
                                    Text="Add a new Question" OnClick="btnAddQuestion_Click">
                        <%--<i class="glyphicon glyphicon-plus" ></i> --%>
                                </asp:LinkButton>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <p>
                                <br />
                            </p>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="Gridtitle" visible="false">
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                            <br />
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
                                    <asp:BoundField DataField="Comments" HeaderText="Comments" Visible="false">
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
                                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("Quest_ID") %>'
                                                CssClass="btn-lg" OnClick="btnEditQuestion_Click" ToolTip="Edit Question"> 
                                    <i class="glyphicon glyphicon-pencil TextLabelMandatory40 text-success"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False" Font-Size="14px"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnDelete" runat="server" CommandArgument='<%# Eval("Quest_ID") %>'
                                                OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');"
                                                CssClass="btn-lg" OnClick="btnDeleteQuestion_Click" ToolTip="Delete Question">
                                    <i class="glyphicon glyphicon-trash TextLabelMandatory40 text-danger"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Show Answer">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False" Font-Size="14px"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnShow" runat="server" CommandArgument='<%# Eval("Quest_ID") %>'
                                                CssClass="btn-lg" OnClick="btnShowAnswer_Click" ToolTip="Show Answer">
                                    <i class="glyphicon glyphicon-search TextLabelMandatory40 text-warning" ></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Add Answer">
                                        <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False" Font-Size="14px"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnAnswerEdit" runat="server" CommandArgument='<%# Eval("Quest_ID") %>'
                                                CssClass="btn-lg" ToolTip="Edit Record" OnClick="btnAnswerAdd_Click">
                                    <i class="glyphicon glyphicon-plus TextLabelMandatory40 text-info" ></i>
                                            </asp:LinkButton>
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
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridTitleAns" visible="false">
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                            <br />
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
                                        <ItemStyle HorizontalAlign="Center" />
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
                                            <asp:LinkButton ID="btnAnswerEdit" runat="server" CommandArgument='<%# Eval("QuestDetail_ID") %>'
                                                CssClass=" btn-block btn-lg" ToolTip="Edit Record" OnClick="btnAnswerEdit_Click">
                                    <i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"  ></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemStyle HorizontalAlign="Center" Wrap="False" Font-Size="14px"></ItemStyle>
                                        <HeaderStyle HorizontalAlign="Center" Width="75px" Wrap="False"></HeaderStyle>
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnAnswerDelete" runat="server" CommandArgument='<%# Eval("QuestDetail_ID") %>'
                                                CssClass="btn-lg" ToolTip="Delete Record"
                                                OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');"
                                                OnClick="btnAnswerDelete_Click">
                                    <i class="glyphicon glyphicon-trash TextLabelMandatory40 text-danger"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle CssClass="alert-info" />
                                <RowStyle CssClass="tr1" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-inline ">
                    <p>
                        <br />
                        <asp:Label ID="lblGridStatus" runat="server" Visible="false"
                            CssClass="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" Text="No Data to Display"> </asp:Label>
                    </p>
                </div>

                <div class="container">

                    <div class="modal fade" id="TestModal" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Edit Test Total Marks</h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Label ID="lblTestName" runat="server" CssClass="TextLabelMandatory40" Text="Title: "></asp:Label>
                                        <asp:TextBox ID="txtTestName" runat="server" CssClass="form-control " Enabled="false"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestName"
                                            ErrorMessage="Test Name Required" ForeColor="Red" ValidationGroup="test" />

                                    </p>
                                    <p>
                                        <asp:Label ID="lblMarks" runat="server" CssClass="TextLabelMandatory40" Text="Total Marks: "></asp:Label>
                                        <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="DataTypeCheck"
                                            ForeColor="Red" ValidationGroup="test" Type="Double" ControlToValidate="txtMarks"
                                            ErrorMessage="Please enter a Numeric value" />
                                    </p>

                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                        Text="Save" CausesValidation="true" ValidationGroup="test" />
                                    <%-- <asp:Button ID="btnCancel" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                    OnClick="btnCancel_Click" Text="Cancel" />--%>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="container">

                    <!-- Modal -->
                    <div class="modal fade" id="PoolConfig" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h3>Test Configuration</h3>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Label ID="lblTotalQuestion" runat="server" CssClass="TextLabelMandatory40" Text="Minimum Questions: "></asp:Label>
                                        <asp:TextBox ID="txtTotal" runat="server" CssClass="form-control"></asp:TextBox>

                                        <asp:CompareValidator ID="CompareValidator8" runat="server" Operator="DataTypeCheck"
                                            ForeColor="Red" ValidationGroup="pool" Type="Integer" ControlToValidate="txtTotal"
                                            ErrorMessage="Please enter a Numeric value" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtTotal"
                                            ErrorMessage="Total Questions Required" ForeColor="Red" ValidationGroup="pool" />
                                    </p>
                                    <p>
                                        <asp:Label ID="Label12" runat="server" CssClass="TextLabelMandatory40" Text="Total Marks Per Question: "></asp:Label>

                                        <asp:TextBox ID="txtMarksQuestion" runat="server" CssClass="form-control"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator11" runat="server" Operator="DataTypeCheck"
                                            ForeColor="Red" ValidationGroup="pool" Type="Double" ControlToValidate="txtMarksQuestion"
                                            ErrorMessage="Please enter a Numeric value" />

                                    </p>
                                    <p>
                                        <asp:Label ID="Label5" runat="server" CssClass="TextLabelMandatory40" Text="Answer In Seconds:"></asp:Label>
                                        <asp:TextBox ID="txtAnsInSec" runat="server" CssClass="form-control textbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtAnsInSec"
                                            ErrorMessage="Answer In Seconds Required" ForeColor="Red" ValidationGroup="pool" />
                                        <asp:CompareValidator ID="CompareValidator3" ControlToValidate="txtAnsInSec" runat="server"
                                            ValidationGroup="pool" ForeColor="Red" ErrorMessage="Enter Only Integer Values"
                                            Operator="DataTypeCheck" Type="Integer"></asp:CompareValidator>
                                    </p>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnSavepool" runat="server" CssClass="btn btn-primary" Text="Save"
                                        CausesValidation="true" ValidationGroup="pool" OnClick="btnSavePool_Click" />
                                    <%--  <asp:Button ID="btnCancelPool" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                    Text="Cancel" OnClick="btnCancelPool_Click" />--%>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
                <div class="container">
                    <!-- Modal -->
                    <div class="modal fade" id="PoolQuestion" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h2 class="modal-title">Question</h2>
                                </div>
                                <div class="modal-body">
                                    <p>
                                        <asp:Label runat="server" ID="lblError" Text=" " CssClass="TextLabelMandatory40 text-left"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label runat="server" ID="lblPool" Text="Question Group:" CssClass="TextLabelMandatory40"></asp:Label>
                                        <asp:Label ID="lblPooldesc" runat="server" Text="" CssClass="TextLabel"></asp:Label>
                                    </p>
                                    <p>
                                        <asp:Label ID="Label1" runat="server" CssClass="TextLabelMandatory40">Question:</asp:Label>

                                        <asp:TextBox ID="txtQuestion" runat="server" CssClass=" form-control textbox"
                                            TextMode="MultiLine" Rows="3" MaxLength="500"></asp:TextBox>
                                        <p>Max Length 500 Characters</p>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtQuestion"
                                            ErrorMessage="Question Required" ForeColor="Red" ValidationGroup="Question" />

                                    </p>
                                    <p>
                                        <asp:Label ID="Label3" runat="server" CssClass="TextLabelMandatory40">Answer Point Value:</asp:Label>

                                        <asp:TextBox ID="txtPValue" runat="server" CssClass="form-control textbox" Enabled="False"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtPValue"
                                            ErrorMessage="Answer Point Value Required" ForeColor="Red" ValidationGroup="Question" />
                                        <asp:CompareValidator ID="CompareValidator1" ControlToValidate="txtPValue" runat="server"
                                            ForeColor="Red" ErrorMessage="Enter Only Decimal Values" Operator="DataTypeCheck" ValidationGroup="Question"
                                            Type="Double"></asp:CompareValidator>

                                    </p>
                                    <p runat="server" visible="false">
                                        <asp:Label ID="lblComments" runat="server" CssClass="TextLabelMandatory40">Comments:</asp:Label>


                                        <asp:TextBox ID="txtComments" runat="server" CssClass="form-control textbox"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtComments"
                                            ErrorMessage="Comments Required" ForeColor="Red" ValidationGroup="Question" />--%>
                                    </p>
                                    <p>
                                        <asp:Label ID="Label4" runat="server" CssClass="TextLabelMandatory40">Answer Negative Point Value:</asp:Label>

                                        <asp:TextBox ID="txtNValue" runat="server" CssClass="form-control textbox"></asp:TextBox>
                                        <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtNValue"
                                            ErrorMessage="Answer Negative Point Value Required" ForeColor="Red" ValidationGroup="Question" />--%>
                                        <asp:CompareValidator ID="CompareValidator2" ControlToValidate="txtNValue" runat="server"
                                            ValidationGroup="Question" ForeColor="Red" ErrorMessage=" Enter Only Decimal Values"
                                            Operator="DataTypeCheck" Type="Double"></asp:CompareValidator>

                                    </p>
                                    <p>

                                        <asp:Label ID="lblAnnswer" runat="server" CssClass="TextLabelMandatory40" Text="Answer:"></asp:Label>

                                        <asp:TextBox ID="txtAddAnswer" runat="server" CssClass=" form-control textbox"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtAddAnswer"
                                            ErrorMessage="Answer Required" ForeColor="Red" ValidationGroup="Question" />

                                    </p>

                                </div>

                                <div class="modal-footer">
                                    <asp:Button ID="btnSaveQuestion" runat="server" CssClass="btn btn-primary" Text="Save" data-toggle="hide"
                                        OnClick="btnSaveQuestion_Click" CausesValidation="true" ValidationGroup="Question" />

                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                    <%--<asp:Button ID="btnCancelQuestion" runat="server" CssClass="btn btn-danger" CausesValidation="False"
                                Text="Cancel" OnClick="btnCancelQuestion_Click"></asp:Button>&nbsp;&nbsp;--%>
                                    <img src="../../images/Answers.jpg" runat="server"  id="imgAnswer"/>
                                </div>
                            </div>

                        </div>
                    </div>

                </div>
                <div class="container">
                    <div class="modal fade" id="AnswerModal" role="dialog">
                        <div class="modal-dialog">

                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">&times;</button>
                                    <h4 class="modal-title">Add/ Edit Answer Options</h4>
                                </div>
                                <div class="modal-body">

                                    <div class="form-group">

                                        <p>
                                            <asp:Label ID="lblQuestion" runat="server" CssClass="TextLabelMandatory40" Text="Question :">

                                            </asp:Label>

                                            <asp:Label ID="lblQuesDesc" runat="server" CssClass="TextLabel" Text=""></asp:Label>

                                        </p>
                                        <p>
                                            <asp:Label ID="Label6" runat="server" CssClass="  TextLabelMandatory40" Text="Answer :"></asp:Label>

                                            <asp:TextBox ID="txtAnswer" runat="server" CssClass=" form-control textbox"></asp:TextBox>
                                            <p>Max Length 500 Characters </p>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtAnswer"
                                                ErrorMessage="Answer Required" ForeColor="Red" ValidationGroup="Answer" />

                                        </p>
                                        <p>
                                            <asp:Label runat="server" ID="lblAnswerOption" CssClass="TextLabelMandatory40" Text="Answer Options:"></asp:Label>


                                            <asp:DropDownList ID="ddlAnswOption" runat="server" CssClass="dropdownlist">
                                                <asp:ListItem Value="0" Text="In Correct"></asp:ListItem>
                                                <asp:ListItem Value="1" Text="Correct"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="ddlAnswOption"
                                                InitialValue="-1" ErrorMessage="Answer Status Required" ForeColor="Red" ValidationGroup="Answer" />

                                        </p>

                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <asp:Button ID="btnAnswerSave" OnClick="btnAnswerSave_Click" runat="server" CssClass="btn btn-primary"
                                        Text="Save Answer" CausesValidation="true" ValidationGroup="Answer"></asp:Button>&nbsp;
                           <%--<asp:Button ID="btnCalnalSkill" OnClick="btnCancelAnswer_Click" runat="server" CssClass="btn btn-danger"
                               CausesValidation="False" Text="Cancel"></asp:Button>&nbsp;&nbsp;--%>
                                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                                </div>
                            </div>

                        </div>
                    </div>
                </div>
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

