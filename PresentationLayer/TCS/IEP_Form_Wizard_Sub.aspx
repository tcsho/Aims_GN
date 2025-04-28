<%@ Page Title="" Language="C#" MaintainScrollPositionOnPostback="true" EnableEventValidation="false" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="IEP_Form_Wizard_Sub.aspx.cs" Inherits="PresentationLayer_TCS_IEP_Form_Wizard_Sub" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
             <asp:ScriptReference Path="https://cdn.jsdelivr.net/npm/sweetalert2@11" />
        </Scripts>
    </cc1:ToolkitScriptManager>
    <br />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <style type="text/css">
                .p-10 {
                    padding: 10px !important
                }

                .tbl-no-padding tbody tr td {
                    padding: 0
                }

                .tbl-no-padding tbody tr th {
                    background-color: #e1ebff !important;
                }

                .rdb tbody tr td label {
                    font-size: 9px !important;
                }

                input[type=checkbox], input[type=radio] {
                    margin: 4px 5px 0;
                    line-height: normal;
                    height: 14px;
                    width: 14px;
                }

                .btn-custom {
                    padding: 10px 16px;
                    font-size: 11px;
                    height: 34px;
                }

                .lable-danger {
                    font-size: 14px !important
                }

                .table-responsive {
                    overflow-x: initial !important;
                }

                .aspNetDisabled {
                    background-image: -webkit-linear-gradient(top,rgb(213 213 213 / 0.80) 0,rgb(213 213 213 / 80%) 100%) !important;
                    color: #3B5998;
                    cursor: not-allowed !important;
                    pointer-events: none
                }

                .titlesection {
                    height: auto;
                }

                .table {
                    margin-bottom: 0px;
                }


                .fontsze {
                    font-size: 14px !important;
                }


                .Biletter_main .parentremarkmain p {
                    border-bottom: 1px solid #000 !important;
                }
            </style>
            <script type="text/javascript">

                Sys.Application.add_init(function () {
                    // Initialization code here, meant to run once.

                    jq(document).ready(document_Ready);

                    function document_Ready() {

                        jq(document).ready(function () {

                            //****************************************************************
                            try {
                                $('table.datatable').DataTable({
                                    destroy: true,
                                    "dom": 'Blfrtip',

                                    buttons: [

                                        {
                                            extend: 'excel',
                                            title: 'Student Forecasted Grade'
                                        }
                                    ],
                                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                });
                            }
                            catch (err) {
                                // alert('datatable ' + err);
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

                    //$('#myModal').modal('show');
                    $('#myModal').modal({
                        backdrop: 'static',
                        keyboard: false,
                        show: true
                    });
                }
            </script>
            <script type="text/javascript">
                function closeModal() {

                    $('#myModal').modal('hide');
                    $('.modal-backdrop').removeClass('modal-backdrop');
                    $('.fade').removeClass('fade');
                    $('.in').removeClass('in');
                    $('html, body').css({
                        'overflow': 'auto',
                        'height': 'auto'
                    });
                }
                function Print() {
                    debugger
                    var divContents = document.getElementById('ContentPlaceHolder1_divPrint').innerHTML;

                    ////var divs = divContents.children().length;
                    //var _value = '';
                    //for (var i = 0; i < document.getElementById("divPrint").querySelectorAll("input").length; i++) {

                    //    var ele = document.getElementById("divPrint").querySelectorAll("input")[i].parentElement.innerHTML;
                    //    var values = document.getElementById("divPrint").querySelectorAll("input")[i].value;
                    //    var values1 = document.getElementById("divPrint").querySelectorAll("textarea")[i].value;
                    //    divContents = divContents.replace(ele, '<table class="table table-bordered" style="background-color: transparent !important"><tr><td><label>' + values + values1 + '</label></td></tr></table>')

                    //    //_value += values + '|';
                    //}

                    ////for (var i = 0; i < length; i++) {

                    ////}


                    var a = window.open('', '', 'height=500, width=1000');
                    a.document.write('<html>');
                    a.document.write('<head>');
                    a.document.write('<link rel="stylesheet" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css" integrity = "sha512-dTfge/zgoMYpP7QbHy4gWMEGsbsdZeCXz7irItjcC3sPUFtf0kuFbDz/ixG7ArTxmDjLXDmezHubeNikyKGVyQ==" crossorigin = "anonymous" />');
                    a.document.write('<style> * {margin:0 !important; padding:0 !important;} .table>tbody>tr>td,.table>thead>tr>th {padding: 5px !important}</style>');
                    a.document.write('</head>');

                    a.document.write('<body>');
                    a.document.write('<br />');

                    a.document.write(divContents);
                    a.document.write('</body></html>');
                    setTimeout(function () {
                        a.print();
                        a.close();
                    }, 1000);
                }
               <%-- function passValue() {
                    var divContents = document.getElementById('divPrint').innerHTML;
                    document.getElementById('<%=HiddenField1.ClientID%>').value = 'divContents';
                }--%>
            </script>
            </script>
            <div class="container-fluid">
                <div class="row">
                    <div class="col-x-6 text-right">
                                <div class="btn-group" style="margin-bottom: 0px;">

                                    <asp:LinkButton runat="server" ID="btn_bifurcation" CssClass="btn btn-info btn-custom" OnClick="btn_bifurcation_Click" Visible="false"><i class="fa fa-save"></i>&nbsp;&nbsp;&nbsp;Bifurcation</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnSave" CssClass="btn btn-info btn-custom" OnClick="btnSave_Click"><i class="fa fa-save" visible="false"></i>&nbsp;&nbsp;&nbsp;Save</asp:LinkButton>
<%--                                    <asp:LinkButton runat="server" ID="btnReset" CssClass="btn btn-info btn-custom"><i class="fa fa-refresh"></i>&nbsp;&nbsp;&nbsp;Reset</asp:LinkButton>--%>
<%--                                    <asp:LinkButton runat="server" ID="btnPrint" OnClientClick="Print()" CssClass="btn btn-info btn-custom"><i class="fa fa-print"></i>&nbsp;&nbsp;&nbsp;Print</asp:LinkButton>--%>
                                    <%--<asp:LinkButton runat="server" Visible="false" ID="btnSend" CssClass="btn btn-info btn-custom" OnClick="btnSend_Click"><i class="fa fa-paper-plane"></i>&nbsp;&nbsp;&nbsp;Acknowledgement/Send</asp:LinkButton>--%>
                                </div>

                            </div>
                    <asp:HiddenField runat="server" ID="Batch_Id" />
                    <div id="tdFrmHeading" class="formheading">

                        <div class="row" style="padding: 0 10px 5px 0">
                            <div class="col-xs-6">
                                <asp:Label ID="lbl" CssClass="lblFormHead" runat="server">Individual Education Plan </asp:Label>
                            </div>
                           
                        </div>
                        <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                            border="0" />
                    </div>
                    <br />
                    <div class="row" style="padding: 10px 0px">
                        <div class="col-lg-12">
                            <p runat="server" id="showerror" class="text-center">
                                <asp:Label runat="server" ID="lblerror" class="label label-danger text-center" Style="font-size: 18px"></asp:Label>
                            </p>
                        </div>
                    </div>
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                    <%--style="max-height: 470px; overflow-y: auto; overflow-x: hidden"--%>
                    <div id="divPrint" class="col-xs-10 col-xs-offset-1" style="max-height: 620px; overflow: auto" runat="server">
                      <%--  <div class="row rowdisplayflex headerwithlogo">

                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign" style="padding-right: 15px">

                                <h2 class="schoolname">The City School</h2>
                                <h5 runat="server" id="ieplbl">Individual Educational Plan [IEP]</h5>
                                 <h4 runat="server" font-style="bold" id="iepstatus"></h4>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right schoollogo">
                                <img src="../Component_Marks/ReportCard/images/logo.png" />
                            </div>
                            <div runat="server" id="div_hidded">
                            </div>
                        </div>--%>
                        <table class="table table-bordered table-condensed studentdetail">
                            <tr class="bg-primary text-center">
                                <td colspan="3">
                                    <h4>Student Detail</h4>
                                </td>
                            </tr>
                            <tr>
                                <td class="col-xs-4">
                                    <label><strong>Name: </strong><span runat="server" id="spnStudentName">N/A</span></label></td>
                                <td class="col-xs-4">
                                    <label><strong>ERP No: </strong><span runat="server" id="spnErpNo">N/A</span></label></td>
                                 <td class="col-xs-4">
                                    <label><strong>Current Class: </strong><span runat="server" id="spnClass">N/A</span></label></td>
                                                           <asp:Label runat="server" ID="txtExpected_Graduation_Year" Visible="false" Style="width: 45px;" placeholder="YYYY"></asp:Label>

                            </tr>
                           <%-- <tr>
                                <td class="col-xs-6">
                                    <label><strong>Current Class: </strong><span runat="server" id="spnClass">N/A</span></label></td>
                                <td class="col-xs-6">
                                    <label><strong>Email: </strong><span runat="server" id="spnEmail">N/A</span></label></td>
                            </tr>
                            <tr>
                                <td class="col-xs-6">
                                    <label><strong>Contact No: </strong><span runat="server" id="spnContactNo">N/A</span></label></td>
                                <td class="col-xs-6">
                                    <label>
                                        <strong>Expected Graduation Year (O level): </strong>
                                        <asp:Label runat="server" ID="txtExpected_Graduation_Year" Style="width: 45px;" placeholder="YYYY"></asp:Label>
                                        <%--  <ajaxToolkit:MaskedEditExtender TargetControlID="txtExpected_Graduation_Year" Mask="9999"
                                            MessageValidatorTip="true"
                                            MaskType="Number" InputDirection="RightToLeft" AcceptNegative="None" DisplayMoney="None"
                                            ErrorTooltipEnabled="True" runat="se

rver" ID="mskD" />--//%>
                                    </label>
                                </td>
                            </tr>--%>
                        </table>

                       
                        <div runat="server" id="Counselor_div2" visible="false">
                            <table class="table table-striped table-bordered table-hover">
                                <tr style="border-bottom-width: 5px !important">
                                    <td>
                                        <asp:Repeater runat="server" ID="repAcademicOverview" OnItemDataBound="repAcademicOverview_ItemDataBound">
                                            <ItemTemplate>
                                                <div class="row" style="padding: 0px 15px">
                                                    <div clas="col-xs-12">
                                                        <asp:HiddenField runat="server" ID="hd_Class_Id" Value='<%# Eval("Class_Id").ToString() %>' />
                                                        <h4 class="bg-primary text-center" style="padding: 10px">Academic Overview
                                                        </h4>

                                                    </div>
                                                    <div clas="col-xs-12">
                                                        <table class="table table-bordered">
                                                            <thead>
                                                                <tr>
                                                                    <th colspan="8" align="center">
                                                                        <%# Eval("Term")%> 
                                                                    </th>

                                                                </tr>
                                                            </thead>
                                                            <tbody>
                                                                <%# Eval("Body") %>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <br />

                                                    <div clas="col-xs-12" runat="server" id="div_AIE_ResultDetail" visible="false">
                                                        <h5>CAIE Result Grade</h5>
                                                        <table class="table table-bordered">
                                                            <tbody>
                                                                <asp:Literal runat="server" ID="html_CAIE_ResultDetail">
                                                    
                                                                </asp:Literal>
                                                            </tbody>
                                                        </table>
                                                    </div>
                                                    <br />
                                                    <div clas="col-xs-12">
                                                        <h5>Subjects</h5>
                                                        <asp:GridView runat="server" ID="grdSubjectDetail" CssClass="table table-bordered" AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="Subject_Name" HeaderText="Subject" />
                                                                <asp:BoundField ItemStyle-Width="10%" DataField="Marks" HeaderText="Marks" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="Weak_Topic_Areas" HeaderText="Weak topic areas" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="Academic_Potential" HeaderText="Targeted Grade" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="Suggested_Study_Hours" HeaderText="Suggested Study Hours" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="Suggested_Work_Plan" HeaderText="Suggested Work Plan" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                    <br />
                                                    <div clas="col-xs-12">
                                                        <div id="elective" runat="server" visible="false">
                                                            <%--  Text='<%# Eval("class_id").ToString() == "8" ? Visible=false : Visible=true %>'--%>
                                                            <h5 runat="server">Elective Subjects:</h5>
                                                            <asp:GridView runat="server" ID="gridelective" ShowHeader="False" CssClass="table table-bordered" AutoGenerateColumns="true">
                                                                <%--<Columns>
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="1" HeaderText="Subject" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="2" HeaderText="Marks" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="3" HeaderText="Weak topic areas" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="Academic_Potential" HeaderText="Academic Potential" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="Suggested_Study_Hours" HeaderText="Suggested Study Hours" />

                                                            </Columns>--%>
                                                            </asp:GridView>
                                                        </div>
                                                        <div clas="col-xs-12">
                                                            <br />

                                                            <div class="form-group">
                                                                <h5>Class teacher comments (Achievements, Personality, Behaviour, Areas to work on)</h5>
                                                                <asp:Label runat="server" ID="lblAcademicConcerns" CssClass="form-control" Style="min-height: 100px">
                                                                </asp:Label>
                                                            </div>
                                                            <br />
                                                           
                                                            
                                                          
                                                       
                                                            
                                                        </div>
                                                        <br />
                                                        <div class="row">
                                                            <div class="col-xs-12">
                                                                <h4>Acknowledgement</h4>
                                                                <table class="table table-condensed">
                                                                    <tbody>
                                                                        <tr>
                                                                            <th style="width: 50%">Class Teacher’s: <%# Eval("Acknowledge_By_Class_Teacher").ToString().Length > 0 ? Eval("Acknowledge_By_Class_Teacher").ToString() : "N/A"%>
                                                                            </th>
                                                                           <%-- <th  style="width: 50%" hidden="hidden" >School Head’s: <%# Eval("Acknowledge_By_School_Head").ToString().Length > 0?Eval("Acknowledge_By_School_Head").ToString():"N/A"%>
                                                                            </th>--%>
                                                                        </tr>
                                                                        <tr>
                                                                            <th style="width: 50%">Counselor’s: <%# Eval("Acknowledge_By_Counselor").ToString().Length > 0 ?Eval("Acknowledge_By_Counselor").ToString():"N/A" %>
                                                                            </th>
                                                                            <th style="width: 50%">Parent’s: <%# Eval("Acknowledge_By_Parent").ToString().Length > 0?Eval("Acknowledge_By_Parent").ToString():"N/A"%>
                                                                            </th>
                                                                        </tr>
                                                                    </tbody>
                                                                </table>

                                                            </div>
                                                        </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <div class="row" runat="server" id="Counselor_div2_2nd">
                                            <div class="col-xs-12">
                                                <h5>Will you be continuing at The City School? If yes, which campus? If no, why not?</h5>
                                            </div>
                                            <div class="col-xs-12">
                                                <asp:Label runat="server" ID="txtRemarks1" CssClass="form-control" Style="min-height: 120px; overflow: auto"></asp:Label>
                                            </div>
                                            <div class="col-xs-12">
                                                <h5>Main essay/ Personal Statement Brainstorming:</h5>
                                            </div>
                                            <div class="col-xs-12">
                                                <asp:Label runat="server" ID="txtRemarks2" CssClass="form-control" Style="min-height: 200px; overflow: auto"></asp:Label>
                                            </div>
                                            <div class="col-xs-12">
                                                <h5>Anything that a person writing a recommendation for you should know.</h5>
                                            </div>
                                            <div class="col-xs-12">
                                                <asp:Label runat="server" ID="txtRemarks3" CssClass="form-control" Style="min-height: 100px;"></asp:Label>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                </tr>
                            </table>
                        </div>
                         <br />
                        <div runat="server" id="Counselor_div3">
                            <table class="table table-striped table-bordered table-hover">

                                <tr>
                                    <td>
                                        <asp:HiddenField runat="server" ID="hfE_Trrm_Group_Id" />

                                        <div class="row acadmicoverview" style="padding: 0px 15px">
                                            <div clas="col-xs-12">
                                                <asp:HiddenField runat="server" ID="hdE_Class_Id" />
                                                <asp:HiddenField runat="server" ID="hd_section_id" />
                                                <h4 class="bg-primary text-center" style="padding: 10px" runat="server">Academic Overview</h4>

                                            </div>
                                            <div clas="col-xs-12" runat="server" id="divE_CAIE_ResultDetail" visible="false">
                                                <h5><b>CAIE Result Grade</b></h5>
                                                <table class="table table-bordered">
                                                    <tbody>
                                                        <asp:Literal runat="server" ID="htmlE_CAIE_ResultDetail">
                                                    
                                                        </asp:Literal>
                                                    </tbody>
                                                </table>
                                            </div>

                                            <div id="tbl_MYE" runat="server">
                                                <table class="table table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="8" align="center">
                                                                <span runat="server" id="lblE_Term"></span>&nbsp;&nbsp;
                                                            </th>

                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Literal runat="server" ID="htmlE_SubjectBody">
                                                    
                                                        </asp:Literal>
                                                    </tbody>
                                                </table>

                                            </div>
                                            <div id="birfurcation" runat="server" visible="false">
                                                <div clas="col-xs-12">
                                                    <asp:HiddenField runat="server" ID="HiddenField2" />
                                                    <h4 class=" text-center" style="padding: 10px" runat="server" id="H1"></h4>
                                                    <h5>Bifurcation</h5>
                                                </div>
                                                <div>
                                                    <asp:RadioButton ID="rb_1" runat="server" GroupName="bifurcation"></asp:RadioButton>
                                                    <span>O Levels</span>
                                                    <asp:RadioButton ID="rb_2" runat="server" GroupName="bifurcation"></asp:RadioButton>
                                                    <span>Matric</span>

                                                </div>
                                            </div>
                                            <br />
                                            <asp:Panel clas="col-xs-12" runat="server" ID="DIV_Teacher01">
                                                <h5 id="belowmarks" runat="server">Subjects</h5>
                                                <asp:GridView runat="server" ID="grdE_SubjectDetail" CssClass="table table-bordered tbl-no-padding" AutoGenerateColumns="false"   OnRowDataBound="grdE_SubjectDetail_RowDataBound" >
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Subject">
                                                            <ItemTemplate>
                                                                <asp:HiddenField runat="server" ID="hdSubject_Id" Value='<%# Eval("Subject_Id") %>' />
                                                                <span style="padding: 5px; font-size: 12px"><%#Eval("Subject_Name") %></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Marks" HeaderText="Marks" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:TemplateField HeaderText="Weak topic areas">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_Weak_Topic_Areas" Height="80px" Rows="3" TextMode="MultiLine" CssClass="form-control" Text='<%# Eval("Weak_Topic_Areas").ToString() != "" ? Eval("Weak_Topic_Areas") : Eval("Weak_Topic_Areas_audit") %>'></asp:TextBox>
<%--                                                            <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtE_Weak_Topic_Areas" ID="RegularExpressionValidator2" ValidationExpression = "^[\s\S]{0,120}$" runat="server" ErrorMessage="Maximum 120 characters allowed."></asp:RegularExpressionValidator>--%>
                                                                </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Targeted Grade" HeaderStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_Academic_Potential" Width="60px" Height="80px" CssClass="form-control" Text='<%#Eval("Academic_Potential").ToString() != "" ? Eval("Academic_Potential") : Eval("Academic_Potential_audit") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Agreed Action Plan">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_Suggested_Study_Hours" maxlength="120" Height="80px" TextMode="MultiLine" CssClass="form-control" Text='<%#Eval("Suggested_Study_Hours").ToString() != "" ? Eval("Suggested_Study_Hours") : Eval("Suggested_Study_Hours_audit") %>'></asp:TextBox>
<%--                                                                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtE_Suggested_Study_Hours" ID="RegularExpressionValidator1" ValidationExpression = "^[\s\S]{0,120}$" runat="server" ErrorMessage="Maximum 120 characters allowed."></asp:RegularExpressionValidator>--%>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Suggested Work Plan" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_Suggested_Work_Plan" CssClass="form-control" Text='<%#Eval("Suggested_Work_Plan") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                            <br />
                                            <div runat="server" id="tbl_EYE" hidden="hidden">
                                                <table class="table table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="8" align="center">
                                                                <span runat="server" id="lblE_Term1"></span>&nbsp;&nbsp;
                                                            </th>

                                                        </tr>
                                                    </thead>
                                                    <tbody >
                                                        <asp:Literal runat="server" ID="htmlE_SubjectBody1">
                                                    
                                                        </asp:Literal>
                                                    </tbody>
                                                </table>

                                            </div>

                                            <br />




                                            <br />
                                            <br />
                                            <asp:Panel clas="col-xs-12" runat="server" ID="DIV_Teacher011" hidden="hidden">
                                                <h5 id="belowmarks1" runat="server">Subjects</h5>
                                                <asp:GridView runat="server" ID="grdE_SubjectDetail1" CssClass="table table-bordered tbl-no-padding" AutoGenerateColumns="false" OnRowDataBound="grdE_SubjectDetail1_RowDataBound">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Subject">
                                                            <ItemTemplate>
                                                                <asp:HiddenField runat="server" ID="hdSubject_Id" Value='<%# Eval("Subject_Id") %>' />
                                                                <span style="padding: 5px; font-size: 12px"><%#Eval("Subject_Name") %></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Marks" HeaderText="Marks" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:TemplateField HeaderText="Weak topic areas">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_Weak_Topic_Areas"  Height="80px"  Rows="3" TextMode="MultiLine" CssClass="form-control" Text='<%#Eval("Weak_Topic_Areas") %>'></asp:TextBox>
                                                           <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtE_Weak_Topic_Areas" ID="RegularExpressionValidator3" ValidationExpression = "^[\s\S]{0,120}$" runat="server" ErrorMessage="Maximum 120 characters allowed."></asp:RegularExpressionValidator>
                                                                </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Targeted Grade"  HeaderStyle-Width="60px">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_Academic_Potential"  Width="60px" Height="80px" CssClass="form-control" Text='<%#Eval("Academic_Potential") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Agreed Action Plan">
                                                            <ItemTemplate> 
                                                                <asp:TextBox runat="server" ID="txtE_Suggested_Study_Hours" Height="80px" Rows="3"  TextMode="MultiLine" CssClass="form-control" Text='<%#Eval("Suggested_Study_Hours") %>'></asp:TextBox>
                                                                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtE_Suggested_Study_Hours" ID="RegularExpressionValidator4" ValidationExpression = "^[\s\S]{0,120}$" runat="server" ErrorMessage="Maximum 120 characters allowed."></asp:RegularExpressionValidator>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Suggested Work Plan" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_Suggested_Work_Plan" CssClass="form-control" Text='<%#Eval("Suggested_Work_Plan") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </asp:Panel>
                                        </div>
                                        </br>
                                            <asp:Panel clas="col-xs-12" runat="server" ID="panelelective">
                                                <div id="elective1" runat="server" visible="false">
                                                    <h5>Elective Subjects:</h5>
                                                    <asp:GridView runat="server" ID="gridelective1" ShowHeader="False" CssClass="table table-bordered" AutoGenerateColumns="true">
                                                        <%--<Columns>
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="1" HeaderText="Subject" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="2" HeaderText="Marks" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="3" HeaderText="Weak topic areas" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="Academic_Potential" HeaderText="Academic Potential" />
                                                                <asp:BoundField ItemStyle-Width="20%" DataField="Suggested_Study_Hours" HeaderText="Suggested Study Hours" />

                                                            </Columns>--%>
                                                    </asp:GridView>
                                                </div>
                                                <br />
                                            </asp:Panel>

                                        <asp:Panel class="form-group " runat="server" ID="DIV_Teacher02" Visible="false">
                                            <h5 class="classteachercomments">Class teacher comments (Achievements, Personality, Behaviour, Areas to work on)</h5>
                                            <asp:TextBox runat="server" ID="txtE_AcademicConcerns" TextMode="MultiLine" CssClass="form-control" Style="min-height: 100px" Enabled="false">
                                            </asp:TextBox>
                                        </asp:Panel>
                                       
                        </div>

                        </td>
                                </tr>
                              <tr>
                                    <td>
                                        <asp:Panel runat="server" ID="DIV_Counsellor03">
                                            <div runat="server" class="ExtraCurricularActivities" id="div_OLevels" visible="true">
                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <h5>Will you be continuing at The City School? If yes, which campus? If no, why not?</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <asp:TextBox runat="server" ID="txtE_Remarks1" TextMode="MultiLine" CssClass="form-control" Style="min-height: 120px; overflow: auto"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <h5>Main essay/ Personal Statement Brainstorming:</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <asp:TextBox runat="server" ID="txtE_Remarks2" TextMode="MultiLine" CssClass="form-control" Style="min-height: 200px; overflow: auto"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <h5>Anything that a person writing a recommendation for you should know.</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <asp:TextBox runat="server" ID="txtE_Remarks3" TextMode="MultiLine" CssClass="form-control" Style="min-height: 100px;"></asp:TextBox>
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="col-xs-12">
                                                        <h5>Name two teachers who would write a recommendation for you.</h5>
                                                    </div>
                                                    <div class="col-xs-12">
                                                        <div class="col-xs-6">
                                                            <h5>Name</h5>
                                                        </div>
                                                        <div class="col-xs-6">
                                                            <h5>Subject Taught</h5>
                                                        </div>

                                                        <div class="col-xs-6">
                                                            <asp:TextBox runat="server" MaxLength="200" ID="txtTeacherName1" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-xs-6">
                                                            <asp:TextBox runat="server" MaxLength="200" ID="txtSubjectTaught1" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-xs-6">
                                                            <asp:TextBox runat="server" MaxLength="200" ID="txtTeacherName2" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                        <div class="col-xs-6">
                                                            <asp:TextBox runat="server" MaxLength="200" ID="txtSubjectTaught2" CssClass="form-control"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                </div>
                                                </br>
                                                   </br>
                                               
                                            </div>
                                            <div clas="col-xs-12 " runat="server" id="div_undertaking" visible="false">

                                                <div class="text-center">
                                                    <h4>For All Years</h4>
                                                </div>
                                                <h5>Academic or Disciplinary Undertakings Issued:</h5>
                                                <table class="table table-bordered tbl-no-padding undertakinglist">
                                                    <tr>
                                                        <th>Class</th>
                                                        <th>Date of issue</th>
                                                        <th>Reason</th>
                                                        <th>Parent's Signature</th>
                                                        <th>School Head Signature</th>
                                                    </tr>
                                                    <asp:Repeater ID="rpt_undertakingissued" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox runat="server" Enabled="false" ID="TextBox1" CssClass="form-control" Text='<%#  Eval("Class_Name")%>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" Enabled="false" ID="txt_dateofissue" CssClass="form-control" Text='<%#  Eval("dateofissue")%>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" Enabled="false" ID="txt_reason" CssClass="form-control" Text='<%#  Eval("reason")%>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" Enabled="false" ID="txt_parent" CssClass="form-control" Text='<%#  Eval("parent")%>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" Enabled="false" ID="txt_signaure" CssClass="form-control " Text='<%#  Eval("signature")%>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">

                                                    <table class="table table-condensed signature">
                                                        <tbody>
                                                            <tr>
                                                                <th style="width: 50%">Class Teacher: <span runat="server" id="lblAcknowledge_By_Class_Teacher" class="signnamess"></span>
                                                                </th>
                                                                <th style="width: 50%" hidden="hidden">School Head: <span runat="server" id="lblAcknowledge_By_School_Head" class="signnamess"></span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <th style="width: 50%">Counselor: <span runat="server" id="lblAcknowledge_By_Counselor" class="signnamess"></span>
                                                                </th>
                                                                <th style="width: 50%">Parent / Guardian: <span runat="server" id="lblAcknowledge_By_Parent" class="signnamess"></span>
                                                                </th>
                                                            </tr>
                                                        </tbody>
                                                    </table>
                                                    <div id="Div_progressing" runat="server" visible="false">
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                        </table>
                    </div>

                </div>

            </div>

             
            <%-- <div class="floating_btn">
                <button type="button" class="tourbtn">
                    <div class="contact_icon startpluse">
                        <i class="fa fa-question-circle"></itext
                    </div>
                </button>
                <p class="text_icon">Start the Tour?</p>
            </div>--%>
            <asp:SqlDataSource ID="dsRaisec" runat="server"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsTimline" runat="server"></asp:SqlDataSource>
            <asp:SqlDataSource ID="dsStatus" runat="server"></asp:SqlDataSource>
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="btnSave" />--%>
        </Triggers>
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
    <%-- <style>
        .chariot-tooltip {
            background-color: #fff;
            padding: 30px;
            width: 320px;
            text-align: center;
            box-shadow: 0 0 5px 0 rgba(31, 28, 28, 0.3);
            border: 1px solid #ddd;
            color: #999;
            border-radius: 20px;
        }

            .chariot-tooltip .chariot-tooltip-icon {
                width: 52px;
                height: 52px;
                margin: auto;
            }

                .chariot-tooltip .chariot-tooltip-icon img {
                    width: 52px;
                    height: 52px;
                }

            .chariot-tooltip .chariot-tooltip-header {
                font-size: 18px;
                line-height: 18px;
                font-weight: 500;
                color: #555;
                padding: 5px 0;
            }

            .chariot-tooltip .chariot-tooltip-content {
                padding: 5px 0;
            }

                .chariot-tooltip .chariot-tooltip-content p {
                    font-size: 14px;
                    font-weight: 300;
                    color: #999;
                    padding-bottom: 15px;
                }

            .chariot-tooltip .chariot-btn-row {
                padding-top: 5px;
            }

                .chariot-tooltip .chariot-btn-row .btn {
                    font-size: 13px;
                    font-weight: 400;
                    color: #fff;
                    background-color: #0c4da2;
                    border-radius: 3px;
                    height: 36px;
                    padding: 0 20px;
                    border: none;
                }

                    .chariot-tooltip .chariot-btn-row .btn:hover {
                        background-color: #78A300;
                    }

                .chariot-tooltip .chariot-btn-row .chariot-tooltip-subtext {
                    float: left;
                    color: #ddd;
                    font-size: 13px;
                    padding-top: 10px;
                }

        .chariot-tooltip-arrow {
            background: #fff;
        }

        .chariot-tooltip-arrow-left {
            border-left: 1px solid #ddd;
            border-bottom: 1px solid #ddd;
            box-shadow: -2px 2px 2px 0 rgba(31, 28, 28, 0.1);
        }

        .chariot-tooltip-arrow-right {
            border-right: 1px solid #ddd;
            border-top: 1px solid #ddd;
            box-shadow: 2px -2px 2px 0 rgba(31, 28, 28, 0.1);
        }

        .chariot-tooltip-arrow-top {
            border-left: 1px solid #ddd;
            border-top: 1px solid #ddd;
            box-shadow: -2px -2px 4px 0 rgba(31, 28, 28, 0.1);
        }

        .chariot-tooltip-arrow-bottom {
            border-right: 1px solid #ddd;
            border-bottom: 1px solid #ddd;
            box-shadow: 2px 2px 4px 0 rgba(31, 28, 28, 0.1);
        }

        .chariot-btn-row .btn {
            background-color: #0c4da2 !important;
            border-color: #0c4da2 !important;
            color: #FFFFFF !important;
            border-radius: 3px !important;
        }

        .tourbtn {
            background: none;
            border: none;
        }

        .floating_btn {
            position: fixed;
            bottom: 30px;
            right: 30px;
            width: 100px;
            height: 100px;
            display: flex;
            flex-direction: column;
            align-items: center;
            justify-content: center;
            /*z-index: 1000;*/
        }

        @keyframes pulsing {
            to {
                box-shadow: 0 0 0 30px rgba(232, 76, 61, 0);
            }
        }

        .contact_icon {
            background-color: #0c4da2;
            color: #fff;
            width: 60px;
            height: 60px;
            font-size: 30px;
            border-radius: 50px;
            text-align: center;
            box-shadow: 2px 2px 3px #999;
            display: flex;
            align-items: center;
            justify-content: center;
            transform: translatey(0px);
            animation: pulse 1.5s infinite;
            box-shadow: 0 0 0 0 #0c4da2;
            -webkit-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
            -moz-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
            -ms-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
            animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
            font-weight: normal;
            font-family: sans-serif;
            text-decoration: none !important;
            transition: all 300ms ease-in-out;
        }

        .contact_icon_pulse_stop {
            background-color: #42db87;
            color: #fff;
            width: 60px;
            height: 60px;
            font-size: 30px;
            border-radius: 50px;
            text-align: center;
            box-shadow: 2px 2px 3px #999;
            display: flex;
            align-items: center;
            justify-content: center;
            /*//transform: translatey(0px);
  //animation: pulse 1.5s infinite;*/
            box-shadow: 0 0 0 0 #42db87;
            /*-webkit-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  -moz-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  -ms-animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);
  animation: pulsing 1.25s infinite cubic-bezier(0.66, 0, 0, 1);*/
            font-weight: normal;
            font-family: sans-serif;
            text-decoration: none !important;
            /*// transition: all 300ms ease-in-out;*/
        }



        .text_icon {
            color: #707070;
            font-size: 13px;
        }

        .chariot-clone {
            color: #fff !important;
            line-height: 0px !important;
            /* block-size: 34px !important; */
        }

        @font-face {
            font-family: signfont;
            /*  src: url(../Styles/iep_dashboardfile/Handitype.ttf);*/
            /*  src: url(../Styles/iep_dashboardfile/Autograph.ttf);*/
            /*    src: url(../Styles/iep_dashboardfile/TheExcited.ttf);*/
            src: url(../../Styles/iep_dashboardfile/CreattionDemo.otf);
            /*    src: url(../Styles/iep_dashboardfile/RhythemSignature.ttf);*/
        }



        .signnamess {
            font-family: signfont;
            font-size: 31px;
            text-transform: lowercase;
        }
    </style>
    <link href="../../Styles/Tour/chariot.css" rel="stylesheet" />
<script src="../../Styles/Tour/chariot.js"></script>--%>

    <%-- <script>
        $(".tourbtn").click(function () {
            var currentidoftour = $(".classtab li.active").attr('data-title');

            chariot.startTutorial({
                steps: [


                    {
                        selectors: ".studentdetail",//"#ContentPlaceHolder1_ddl_sub_problem",
                        tooltip: {
                            position: 'top',
                            title: 'Student Detail',
                            text: 'Student Detail',


                        }

                    },
                    {
                        selectors: ".DiscussionOutcomescounselor",//"#ContentPlaceHolder1_ddl_sub_problem",
                        tooltip: {
                            position: 'top',
                            title: 'Counselor Fields',
                            text: 'Counselor will fill these fields',


                        }

                    },
                    {
                        selectors: ".acadmicoverview",//"#ContentPlaceHolder1_ddl_sub_problem",
                        tooltip: {
                            position: 'top',
                            title: 'Academic Overview ',
                            text: 'Subject Grade Details and subject teacher will fill these fields',


                        }

                    },
                    {
                        selectors: ".classteachercomments",//"#ContentPlaceHolder1_ddl_sub_problem",
                        tooltip: {
                            position: 'top',
                            title: 'CLass Teacher Comments ',
                            text: 'Class Teacher will add Comments',


                        }

                    },
                    {
                        selectors: ".honourandawards",//"#ContentPlaceHolder1_ddl_sub_problem",
                        tooltip: {
                            position: 'top',
                            title: 'Honour and Awards',
                            text: 'Counselor will fill Honour and Awards',


                        }

                    },
                    {
                        selectors: ".progressing",//"#ContentPlaceHolder1_ddl_sub_problem",
                        tooltip: {
                            position: 'top',
                            title: 'Progressing',
                            text: 'Counselor will fill Progressing',


                        }

                    },
                    {
                        selectors: ".ExtraCurricularActivities",//"#ContentPlaceHolder1_ddl_sub_problem",
                        tooltip: {
                            position: 'top',
                            title: 'Extra Curricular Activities',
                            text: 'Counselor will fill these fields',


                        }

                    },
                   
                   {
                        selectors: ".undertakinglist",//"#ContentPlaceHolder1_ddl_sub_problem",
                        tooltip: {
                            position: 'top',
                            title: 'Undertaking list ',
                            text: 'Previous Undertaking list of student',


                        }

                    },
                    {
                        selectors: ".signature",//"#ContentPlaceHolder1_ddl_sub_problem",
                        tooltip: {
                            position: 'top',
                            title: 'Signature ',
                            text: 'Signature for Class Teacher, School Head,Counselor,Parent',


                        }

                    }
                    
                    


                ],
                onComplete: function () {
                    $(".startpluse").removeClass("contact_icon_pulse_stop");
                    $(".startpluse").addClass("contact_icon");
                }
                // overlayColor: 'rgba(0,0,0,0.5)'
            });


        });
    --%>
    <script>
        $(document).ready(function () {

            var selected = $('.raisec  option:selected').toArray().map(item => item.value);
            for (var s = 0; s < selected.length; s++) {
                $(".raisec option:contains('" + selected[s] + "')").attr("disabled", "disabled");
            }




            (function () {
                debugger
                var previous;

                $(".raisec").focus(function () {
                    previous = this.value;
                }).change(function () {
                    var selectedval = this.value;

                    $(".raisec option:contains('" + previous + "')").attr("disabled", false);
                    $(".raisec option[value=" + selectedval + "]").prop('disabled', true);
                    previous = this.value;
                });
            })();

         
        });


    </script>
</asp:Content>
