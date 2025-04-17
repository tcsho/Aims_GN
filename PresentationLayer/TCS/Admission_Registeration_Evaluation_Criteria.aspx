<%@ Page Title="Admission Registeration Evaluation Criteria" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Admission_Registeration_Evaluation_Criteria.aspx.cs"
    Inherits="PresentationLayer_TCS_Admission_Registeration_Evaluation_Criteria" %>

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
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Student Admission Test Evaluation"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
            <br /><br />
                <div runat="server" id="div1" class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">
                    Registration Number* :
                </div>
                <div runat="server" class="col-lg-9 col-md-9 col-sm-9 col-xs-12 form-group text-left">
                  
                        <asp:TextBox ID="txtRegisterationID" runat="server" CssClass=" form-control textbox"
                            AutoPostBack="True" OnTextChanged="txtRegisterationID_TextChanged" Width="50%"></asp:TextBox>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" Operator="DataTypeCheck"
                            Type="Integer" ControlToValidate="txtRegisterationID" ErrorMessage="Please enter a Numeric value" />
                        <asp:Label ID="lblSave" runat="server" ForeColor="Red"></asp:Label>
                     
                </div>
            </div>
            <div id="tblStudentDetails" runat="server" visible="false">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" visible="false">
                        &nbsp; Candidate Information
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-right">
                        Registration Number :
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblRegisteration" runat="server" CssClass="TextLabel"></asp:Label>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-right">
                        Center :
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblCenter" runat="server" CssClass="TextLabel"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-right">
                        Student Name :
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblStudent" runat="server" CssClass="TextLabel"></asp:Label>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-right">
                        Class Name :
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblClass" runat="server" CssClass="TextLabel"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-right">
                        Father Name :
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblFather" runat="server" CssClass="TextLabel"></asp:Label>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-right">
                        Admission Date:
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblDate" runat="server" CssClass="TextLabel"></asp:Label>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-right">
                        Region :
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblRegion" runat="server" CssClass="TextLabel"></asp:Label>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-right">
                        Gender:
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblGender" runat="server" CssClass="TextLabel"></asp:Label>
                    </div>
                </div>
                
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <br />
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 TextLabelMandatory40 text-right">
                        <asp:Label ID="lblOlevels" runat="server" CssClass="TextLabel" Font-Bold="true"></asp:Label>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 TextLabelMandatory40 text-left">
                        <asp:DropDownList runat="server" ID="ddlGroup" AutoPostBack="true" CssClass="dropdownlist"
                            Visible="false" OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                            <asp:ListItem Value="Select" Text="Select "></asp:ListItem>
                            <asp:ListItem Value="Business" Text="Business Group"></asp:ListItem>
                            <asp:ListItem Value="Science" Text="Science Group"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" >
                    <br />
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6   TextLabelMandatory40 text-right">
                        <asp:Label ID="lblUrdu" runat="server" CssClass="TextLabel" Font-Bold="true" Text="Skip Urdu for Foreign Student:"></asp:Label>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6  TextLabelMandatory40 text-left" >
                       <asp:RadioButtonList runat="server" ID="rblSkipUrdu" OnSelectedIndexChanged="rblSkipUrdu_SelectedIndexChanged"
                       CssClass="radio-inline" AutoPostBack="true"  RepeatDirection="Horizontal" RepeatLayout="Table">
                        <asp:ListItem Value="True" Text="Yes"  style="padding-right:30px ;"></asp:ListItem>
                        <asp:ListItem Value="False" Text="No" Selected="True"  style="padding-right:30px ;"></asp:ListItem>
                       </asp:RadioButtonList>
                    </div>
                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                    </div>
                </div>
            </div>
            <br /><br/>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" runat="server" id="trHeadingPolicy" visible="false">
                <div id="Div2" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    &nbsp; Admission Assessment Policy
                </div>
            </div>
            <div runat="server" id="trPolicy">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblEnglishPolicy" runat="server" CssClass="TextLabel" Text=""></asp:Label>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6  TextLabelMandatory40 text-right">
                        <asp:Label ID="lblEnglish" runat="server" CssClass="TextLabel" Text=""></asp:Label>
                        <asp:Label ID="lblPercentage" runat="server" CssClass="TextLabel" Text=""></asp:Label>
                        <span id="spFailEnglish" runat="server" visible="false" class="glyphicon glyphicon-remove" style="color: Red;">
                        </span><span id="spPassEnglish" runat="server" visible="false" class="glyphicon glyphicon-ok" style="color: green;">
                        </span>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trOverallPolicy" runat="server">
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblOverallPolicy" runat="server" CssClass="TextLabel" Text=""></asp:Label>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6  TextLabelMandatory40 text-right">
                        <asp:Label ID="lblOverall" runat="server" CssClass="TextLabel" Text=""></asp:Label>
                        <asp:Label ID="lblOverallPercentage" runat="server" CssClass="TextLabel" Text=""></asp:Label>
                        <span id="spOverallFail" runat="server" visible="false" class="glyphicon glyphicon-remove" style="color: Red;">
                        </span>
                        <span id="spOverallPass" runat="server" visible="false" class="glyphicon glyphicon-ok" style="color: green;">
                        </span>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" id="trAdditionalPolicy" runat="server">
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 TextLabelMandatory40 text-left">
                        <asp:Label ID="lblAdditionalPolicy" runat="server"></asp:Label>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6  TextLabelMandatory40 text-right">
                        <asp:Label ID="lblAdditional" runat="server"></asp:Label>
                        <asp:Label ID="lblAdditionalPercentage" runat="server" CssClass="TextLabel" Text=""></asp:Label>
                        <span id="spAdditionalFail" runat="server" visible="false" class="glyphicon glyphicon-remove" style="color: Red;">
                        </span><span id="spAdditionalPass" runat="server" visible="false" class="glyphicon glyphicon-ok"
                            style="color: green;"></span>
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-left TextLabelMandatory40"
                    runat="server" id="trNotApplicable">
                    <asp:Label ID="lblNotApplicable" runat="server" ForeColor="Red" CssClass="TextLabel"></asp:Label>
                   
                </div>
                
            </div>
             <br /><br />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" id="trUpdateMarks"  visible="false"
                runat="server">
                <div id="divMarks" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    &nbsp; Admission Marks Details
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvCriteria" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                    CssClass="datatable table table-striped table-responsive" Height="100%" OnPreRender="gvCriteria_PreRender"
                    Width="100%" OnRowDataBound="gvCriteria_RowDataBound">
                    <AlternatingRowStyle CssClass="tr2" />
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" Font-Size="14px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="ACEC_Id" HeaderText="ACEC_Id" SortExpression="ACEC_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id" SortExpression="Subject_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Id" HeaderText="Class Id" SortExpression="Class_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Session_Id" HeaderText="Session Id" SortExpression="Session_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center Id" SortExpression="Center_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Criteria" HeaderText="Subject">
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle HorizontalAlign="Center" Width="25%" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Marks_Obtained" HeaderText="Marks Obtained" SortExpression="Marks_Obtained">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Lock_Marks" HeaderText="Lock_Marks" SortExpression="Lock_Marks">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Marks">
                            <ItemStyle HorizontalAlign="Center" Width="25%" Wrap="False" Font-Size="14px" />
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:TextBox ID="txtMarks" runat="server" AutoPostBack="false" BackColor="yellow"
                                    CssClass=" form-control" OnTextChanged="txtMarks_TextChanged" Text='<%# Eval(" Marks_Obtained") %>'
                                    Visible='<%# Convert.ToBoolean( Eval("Lock_Marks"))==false %> '></asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtMarks"
                                    Display="Dynamic" ErrorMessage="Please Enter Valid Marks" ForeColor="Red" MaximumValue='<%# Eval("Total_Marks") %>'
                                    MinimumValue="0" Type="Double"></asp:RangeValidator>
                                <asp:TextBox ID="lblMarks" runat="server" BackColor="gray" ForeColor="White" CssClass="form-control"
                                    ReadOnly="true" Text='<%# Eval(" Marks_Obtained")%>' Visible='<%# Convert.ToBoolean( Eval("Lock_Marks"))==true %>'></asp:TextBox>
                                &nbsp;&nbsp;&nbsp;
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Total_Marks" HeaderText="Total_Marks" SortExpression="Total_Marks">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gv_subject" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="datatable table table-striped table-responsive" Height="100%" OnPreRender="gv_subject_PreRender"
                    PageSize="500" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" Font-Size="14px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Class_ID" HeaderText="Class_ID">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_ID" HeaderText="Subject_ID">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Code" HeaderText="Subject_Code">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FullSubject_Name" HeaderText="Subject Name">
                            <ItemStyle Font-Size="14px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Subjects Studied ">
                            <ItemStyle HorizontalAlign="Center" Width="25%" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Width="25%" />
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSubject" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Subjects Intend to Study ">
                            <ItemStyle HorizontalAlign="Center" Width="25%" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Width="25%" />
                            <ItemTemplate>
                                <asp:CheckBox ID="cbIntend" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvAlevelMarks" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="datatable table table-striped table-responsive" Height="100%" OnPreRender="gvAlevelMarks_PreRender"
                    PageSize="500" Width="100%">
                    <Columns>
                        <asp:TemplateField HeaderText="#">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Width="5%" />
                            <ItemStyle HorizontalAlign="Center" Width="5%" Font-Size="14px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Registeration_Id" HeaderText="Registration Number">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="FullSubject_Name" HeaderText="Subject Name">
                            <ItemStyle Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Marks_Obtained" HeaderText="Marks_Obtained">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Subjects Studied ">
                            <ItemStyle HorizontalAlign="Center" Width="25%" Wrap="False" />
                            <HeaderStyle HorizontalAlign="Center" Width="25%" />
                            <ItemTemplate>
                                <asp:DropDownList ID="ddlCriteria" runat="server" AutoPostBack="false" CssClass="dropdownlist"
                                    Enable='<%# Convert.ToBoolean( Eval("Lock_Marks"))==false %>' Value='<%# Convert.ToString(Eval(" Marks_Obtained"))%>'>
                                    <asp:ListItem Text="Select" Value="0" />
                                    <asp:ListItem Text="A*" Value="A*" />
                                    <asp:ListItem Text="A" Value="A" />
                                    <asp:ListItem Text="B" Value="B" />
                                    <asp:ListItem Text="C" Value="C" />
                                    <asp:ListItem Text="D" Value="D" />
                                    <asp:ListItem Text="E" Value="E" />
                                    <asp:ListItem Text="U" Value="U" />
                                </asp:DropDownList>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <RowStyle CssClass="tr1" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right" id="trSave" runat="server">
                <div class="pull-right">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                        Text="Save" Visible="false" />
                </div>
            </div>
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
