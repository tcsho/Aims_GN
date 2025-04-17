<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="DiadnosticAndProgress.aspx.cs" Inherits="PresentationLayer_TCS_DiadnosticAndProgress" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692FBEA5521E1304" Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

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

                                     { orderable: false, targets: [6,7,8]} //disable sorting on toggle button
                                    ]

                                ,


                                    tableTools:
                    { //Start of tableTools collection
                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                        "aButtons":
                         [ //start of button main/master collection
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
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Diagnostic Progress Table of Specifications"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <p>
                <br />
            </p>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 form-group">
                    <asp:Label ID="lblSubjectName" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-6 TextLabelMandatory40"
                        Text="*Subject : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:Label ID="lblSubject" runat="server"></asp:Label>
                    </div>
                    <asp:Label ID="lblClassName" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="*Class: "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:DropDownList ID="ddlClass" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            OnSelectedIndexChanged="ddlClass_SelectedIndexChanged" Width="50%">
                        </asp:DropDownList>

                    </div>
                    <asp:Label ID="lblTermName" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-6 TextLabelMandatory40"
                        Text="*Term : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" Width="50%"
                            CssClass="dropdownlist" OnSelectedIndexChanged="list_Term_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="lblEvC" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-6 TextLabelMandatory40"
                        Text="*Evaluation Criteria : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:Label ID="lblEvalCriteria" runat="server" Text="" CssClass="TextLabel40 text-left"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 form-group">
                    <div class="pull-right">
                        <asp:LinkButton ID="but_new" OnClick="but_new_Click" runat="server" CssClass="btn btn-lg btn-primary active"
                            Font-Bold="False" ValidationGroup="btnNew">Add New Section</asp:LinkButton>
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="divSection" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" visible="false">
                    Exam Section Details
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvQuestions" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                    CssClass="datatable table table-striped table-responsive"
                    Width="100%" OnSelectedIndexChanged="gvQuestions_SelectedIndexChanged" OnPreRender="gvQuestions_PreRender">
                    <AlternatingRowStyle CssClass="tr2" />
                    <Columns>
                        <asp:BoundField DataField="DP_Id" SortExpression="DP_Id"
                            HeaderText="DP_Id">
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
                        <asp:BoundField DataField="Section_Name" HeaderText="Section_Name">

                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle HorizontalAlign="Left" />

                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="TotalQuestions"
                            HeaderText="Total Questions">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TotalMarks"
                            HeaderText="Total Marks">
                            <HeaderStyle HorizontalAlign="Left" Width="10%" />
                            <ItemStyle HorizontalAlign="Left" Width="10%" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Evaluation_Criteria_Id"
                            HeaderText="Evaluation Criteria Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Evaluation_Criteria_Id" HeaderText="Criteria">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Edit">
                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnEdit" runat="server"
                                    CommandArgument='<%# Eval("DP_Id") %>' ForeColor="#004999"
                                    ImageUrl="~/images/edit.gif" OnClick="btnEdit_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnDelete" runat="server"
                                    CommandArgument='<%# Eval("DP_Id") %>' ForeColor="#004999"
                                    ImageUrl="~/images/delete.gif" OnClick="btnDelete_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Show Question">
                            <ItemStyle HorizontalAlign="Center" Width="10%" Wrap="False"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnShowAnswer" runat="server"
                                    CommandArgument='<%# Eval("DP_Id") %>' ForeColor="#004999"
                                    ImageUrl="~/images/viewIcon.gif" OnClick="btnShowAnswer_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Add Question">
                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnAnswerAdd" runat="server"
                                    CommandArgument='<%# Eval("DP_Id") %>' ForeColor="#004999"
                                    ImageUrl="~/images/transfericon.gif" OnClick="btnAnswerAdd_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Add Record" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Lock Marks" Visible="false">
                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnLockMarks" runat="server"
                                    CommandArgument='<%# Eval("DP_Id") %>' ForeColor="#004999"
                                    ImageUrl="~/images/privacyicon.png" OnClick="btnLockMarks_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Lock Marks" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr2" />
                    <HeaderStyle CssClass="tableheader" />
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="divQuestion" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" visible="false">
                    Section Questions
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvAnswerList" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                    Width="100%"  CssClass="datatable table table-striped table-responsive"  OnPreRender="gvAnswerList_PreRender">
                    <AlternatingRowStyle CssClass="tr2" />
                    <Columns>
                        <asp:BoundField DataField="DPD_Id" SortExpression="DPD_Id"
                            HeaderText="DPD_Id">
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
                        <asp:BoundField DataField="DP_Id" HeaderText="DP_Id">

                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />

                        </asp:BoundField>
                        <asp:BoundField DataField="DPD_Id" HeaderText="DP_Id">

                            <HeaderStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle HorizontalAlign="Left" Width="25%" />
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />

                        </asp:BoundField>
                        <asp:BoundField DataField="Question_Name" SortExpression="Question_Name"
                            HeaderText="Question Number">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Diag_Prog_Question_Type_Id" SortExpression="Diag_Prog_Question_Type_Id"
                            HeaderText="Question_Type_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Question_Type"
                            HeaderText="Question Type">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Topic_Description"
                            HeaderText="Topic Description">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Objective"
                            HeaderText="Objectives">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>

                        <asp:BoundField DataField="Duration"
                            HeaderText="Duration">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>


                        <asp:BoundField DataField="Total_Marks"
                            HeaderText="Total_Marks">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" />

                        </asp:BoundField>
                        <asp:BoundField DataField="Marks_Percentage" HeaderText="Marks Percentage" Visible="false" />
                        <asp:TemplateField HeaderText="Edit">
                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>

                                <asp:ImageButton ID="btnAnswerEdit" runat="server"
                                    CommandArgument='<%# Eval("DPD_Id") %>' ForeColor="#004999"
                                    ImageUrl="~/images/edit.gif" OnClick="btnAnswerEdit_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Edit Record" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="75px" Wrap="False"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center"></HeaderStyle>
                            <ItemTemplate>
                                <asp:ImageButton ID="btnAnswerDelete" runat="server"
                                    CommandArgument='<%# Eval("DPD_Id") %>' ForeColor="#004999"
                                    ImageUrl="~/images/delete.gif" OnClick="btnAnswerDelete_Click"
                                    Style="text-align: center; font-weight: bold;" ToolTip="Delete Record" OnClientClick="javascript:return confirm('Are you sure you want to Delete Records?');" />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                    <RowStyle CssClass="tr2" />
                    <HeaderStyle CssClass="tableheader" />
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Panel ID="pan_New" runat="server">
                    <p>
                        <br />
                    </p>
                    <div class="titlesection" visible="false">
                        Add / Update New Section
                    </div>
                    <div class="form-group">
                        <asp:Label class=" col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40" runat="server">
                           Section Name :</asp:Label>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 form-group">
                            <asp:TextBox ID="txtSectionName" runat="server" CssClass="form-control textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtSectionName" ID="RequiredFieldValidator1"
                                ValidationGroup="section" CssClass="errormesg" ErrorMessage="Section Name Required"
                                runat="server" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <p>
                        <br />
                    </p>
                    <div class="form-group">
                        <div class="col-lg-12 text-right">
                            <asp:Button ID="but_save" runat="server" CssClass="btn btn-primary" ValidationGroup="section" CausesValidation="true"
                                OnClick="but_save_Click" Text="Save" />
                            <asp:Button ID="but_cancel" runat="server" CausesValidation="False"
                                CssClass="btn btn-danger" OnClick="but_cancel_Click" Text="Cancel" />
                        </div>
                    </div>
                </asp:Panel>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Panel ID="pan_new2" runat="server">
                    <div class="titlesection" visible="false">
                        Add / Update New Question
                    </div>
                    <div class="form-group">
                        <asp:Label class=" col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40" runat="server">
                          *Question Number:</asp:Label>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-2 form-group">
                            <asp:TextBox ID="txtQuestion" runat="server" CssClass="form-control textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtQuestion" ID="RequiredFieldValidator22"
                                ValidationGroup="question" CssClass="errormesg" ErrorMessage="Question Number Required"
                                runat="server" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <!--end form group-->
                    <div class="form-group">
                        <asp:Label class=" col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40" runat="server">
                         *Total Marks:</asp:Label>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 form-group">
                            <asp:TextBox ID="txtMarks" runat="server" CssClass="form-control textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMarks" ID="RequiredFieldValidator3"
                                ValidationGroup="question" CssClass="errormesg" ErrorMessage="Question Number Required"
                                runat="server" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="DataTypeCheck" Display="Dynamic"
                                ForeColor="Red" ValidationGroup="question" Type="Double" ControlToValidate="txtMarks"
                                ErrorMessage="Please enter a Numeric value" />
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class=" col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40" runat="server">
                            *Marks Percentage (%):</asp:Label>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 form-group">
                            <asp:TextBox ID="txtMarkPercentage" runat="server" CssClass="form-control textbox"></asp:TextBox>
                            <asp:RequiredFieldValidator ControlToValidate="txtMarkPercentage" ID="RequiredFieldValidator2"
                                ValidationGroup="question" CssClass="errormesg" ErrorMessage="Question Number Required"
                                runat="server" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck" Display="Dynamic"
                                ForeColor="Red" ValidationGroup="question" Type="Double" ControlToValidate="txtMarkPercentage"
                                ErrorMessage="Please enter a Numeric value" />
                        </div>
                    </div>

                    <div class="form-group">
                        <asp:Label class=" col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40" runat="server">
                            *Question Type:</asp:Label>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 form-group">
                            <asp:DropDownList ID="list_QuestionType" runat="server" Width="25%"
                                CssClass="dropdownlist">
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ControlToValidate="list_QuestionType" ID="RequiredFieldValidator4"
                                ValidationGroup="question" CssClass="errormesg" ErrorMessage="Please select a Question type"
                                InitialValue="0" runat="server" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <asp:Label class=" col-lg-2 col-md-2 col-sm-2 col-xs-2 TextLabelMandatory40" runat="server">
                            *Question Topic:</asp:Label>
                        <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10 form-group">
                            <asp:DropDownList ID="ddlTopic" runat="server" CssClass="dropdownlist" Width="25%">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ControlToValidate="ddlTopic" ID="RequiredFieldValidator5"
                                ValidationGroup="question" CssClass="errormesg" ErrorMessage="Please select a Question Topic"
                                InitialValue="0" runat="server" Display="Dynamic">
                            </asp:RequiredFieldValidator>
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-lg-12 text-right">
                            <asp:Button ID="btnAnswerSave" runat="server" CssClass="btn btn-primary" ValidationGroup="question"
                                OnClick="btnAnswerSave_Click" Text="Save Question" CausesValidation="true" />
                            <asp:Button ID="btnCalnalSkill" runat="server" CausesValidation="False"
                                CssClass="btn btn-danger" OnClick="btnCalnalSkill_Click" Text="Cancel" />
                        </div>
                    </div>


                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>
</asp:Content>
