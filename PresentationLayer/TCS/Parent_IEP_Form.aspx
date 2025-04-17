<%@ Page Title="" Language="C#"   AutoEventWireup="true"  CodeFile="Parent_IEP_Form.aspx.cs" Inherits="PresentationLayer_TCS_Parent_IEP_Form" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%--<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">--%>



          
    <link href="../../Styles/StyleSheet.css" rel="stylesheet" type="text/css" />
    <link href="../../Styles/style.css" rel="stylesheet" type="text/css" />
    <link rel="shortcut icon" href="../images/favicon.ico" />
    <link href="../../Scripts/SmoothMenu/ddsmoothmenu.css" rel="stylesheet" type="text/css" />
    <link id="Link3" rel="stylesheet" type="text/css" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.5.0/css/font-awesome.css"
        runat="server" />
    <link id="Link1" rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.10.10/css/dataTables.bootstrap.min.css"
        runat="server" />
    <link runat="server" id="link2" href="https://cdn.datatables.net/tabletools/2.2.4/css/dataTables.tableTools.min.css"
        rel="stylesheet" type="text/css" />

    <!--new file-->
    <link rel="stylesheet" type="text/css" href="https://cdn.datatables.net/1.11.1/css/jquery.dataTables.min.css"/>
      <link runat="server" id="link7" href="https://cdn.datatables.net/buttons/2.0.0/css/buttons.dataTables.min.css" rel="stylesheet" type="text/css" />
    
    <!--new file-->

    <link id="Link4" rel="stylesheet" href="https://ajax.googleapis.com/ajax/libs/jqueryui/1.11.4/themes/smoothness/jquery-ui.min.css"
        runat="server" />
    <link id="Link5" rel="stylesheet" runat="server" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css"
        integrity="sha512-dTfge/zgoMYpP7QbHy4gWMEGsbsdZeCXz7irItjcC3sPUFtf0kuFbDz/ixG7ArTxmDjLXDmezHubeNikyKGVyQ=="
        crossorigin="anonymous" />
    <link id="Link6" rel="stylesheet" runat="server" type="text/css" href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap-theme.min.css"
        integrity="sha384-aUGj/X2zp5rLCbBxumKTCw2Z50WgIr1vs/PFN4praOTvYXWlVyh2UtNUU0KAUhAX"
        crossorigin="anonymous" />
    <link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"
        rel="stylesheet" type="text/css" />
    <link href="../../Styles/NotificationStyle.css" rel="stylesheet" type="text/css" />
    <link type="text/css" href="/content/toastr.min.css" rel="stylesheet" />
    <style type="text/css">
        input[type=checkbox], input[type=radio] {
            margin: 4px 0 0;
            line-height: normal;
            height: 20px;
            width: 20px;
        }

        label {
            display: inline-block;
            max-width: 100%;
            margin-bottom: 5px;
            font-weight: 700;
            font-size: 14px;
        }

        #notifications {
            width: 325px;
        }

        #lnkSee {
            color: Black;
        }
    </style>
             
<form id="form2" runat="server">
 <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
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
                    var divContents = document.getElementById('divPrint').innerHTML;

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
                        //a.close();
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
                    <asp:HiddenField runat="server" ID="Batch_Id" />
                    <div id="tdFrmHeading" class="formheading">

                        <div class="row" style="padding: 0 10px 5px 0">
                            <div class="col-xs-6">
                                <asp:Label ID="Label1" CssClass="lblFormHead" runat="server">Individual Education Plan</asp:Label>
                            </div>
                            <div class="col-x-6 text-right">
                                <div class="btn-group" style="margin-bottom: 0px;">

                                    <asp:LinkButton runat="server" ID="btn_bifurcation" CssClass="btn btn-info btn-custom" OnClick="btn_bifurcation_Click" Visible="false"><i class="fa fa-save"></i>&nbsp;&nbsp;&nbsp;Bifurcation</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnSave" visible="false" CssClass="btn btn-info btn-custom" OnClick="btnSave_Click"><i class="fa fa-save"></i>&nbsp;&nbsp;&nbsp;Save</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnReset" visible="false" CssClass="btn btn-info btn-custom"><i class="fa fa-refresh"></i>&nbsp;&nbsp;&nbsp;Reset</asp:LinkButton>
                                    <asp:LinkButton runat="server" ID="btnPrint" OnClientClick="Print()" CssClass="btn btn-info btn-custom"><i class="fa fa-print"></i>&nbsp;&nbsp;&nbsp;Print</asp:LinkButton>
                                     <asp:LinkButton runat="server" ID="btn_confirm" CssClass="btn btn-info btn-custom" OnClick="btn_Confirm_Click" visible="false"><i class="fa fa-yes"></i>&nbsp;&nbsp;&nbsp;Confirm</asp:LinkButton>
                                    <asp:LinkButton runat="server" Visible="false" ID="btnSend" CssClass="btn btn-info btn-custom" OnClick="btnSend_Click"><i class="fa fa-paper-plane"></i>&nbsp;&nbsp;&nbsp;Acknowledgement/Send</asp:LinkButton>
                                </div>

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
                        <div class="row rowdisplayflex headerwithlogo">

                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-mediaalign" style="padding-right: 15px">

                                <h2 class="schoolname">The City School</h2>
                                <h5>Individual Educational Plan [IEP]</h5>
                            </div>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-right schoollogo">
                                <img src="../Component_Marks/ReportCard/images/logo.png" />
                            </div>
                            <div runat="server" id="div_hidded">
                            </div>
                        </div>
                        <table class="table table-bordered table-condensed">
                            <tr class="bg-primary text-center">
                                <td colspan="2">
                                    <h4>Student Detail</h4>
                                </td>
                            </tr>
                            <tr>
                                <td class="col-xs-6">
                                    <label><strong>Name: </strong><span runat="server" id="spnStudentName">N/A</span></label></td>
                                <td class="col-xs-6">
                                    <label><strong>ERP No: </strong><span runat="server" id="spnErpNo">N/A</span></label></td>
                            </tr>
                            <tr>
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
                                        <strong> Expected Graduation Year (O level): </strong>
                                        <asp:Label runat="server" ID="txtExpected_Graduation_Year" Style="width: 45px;" placeholder="YYYY"></asp:Label>
                                        <%--  <ajaxToolkit:MaskedEditExtender TargetControlID="txtExpected_Graduation_Year" Mask="9999"
                                            MessageValidatorTip="true"
                                            MaskType="Number" InputDirection="RightToLeft" AcceptNegative="None" DisplayMoney="None"
                                            ErrorTooltipEnabled="True" runat="se

rver" ID="mskD" />--%>
                                    </label>
                                </td>
                            </tr>
                        </table>

                        <asp:Panel runat="server" ID="Counselor_div1">
                            <div>

                                <table class="table table-striped table-bordered table-hover">
                                    <tr>

                                        <th>

                                            <h4 class="bg-primary text-center" style="padding: 10px">Discussion Outcomes with the Counselor</h4>


                                            <div class="col-xs-12">
                                                <label>Highest Interest Codes from the RAISEC Aptitude Test: </label>
                                            </div>
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row" style="padding: 10px">
                                                <asp:Repeater ID="ctrlIntrestCode" runat="server" OnItemDataBound="ctrlIntrestCode_ItemDataBound">
                                                    <ItemTemplate>
                                                        <div class="col-xs-<%# (12 / (Convert.ToInt32(Eval("field_count")) == 0 ? 1 : Convert.ToInt32(Eval("field_count")))) %>">
                                                            <asp:HiddenField runat="server" ID="hdIEP_Type_Id" Value='<%# Eval("IEP_Type_Id") %>' />
                                                            <asp:TextBox runat="server" Visible="false" MaxLength="50" ID="txtInterest_Code" CssClass="form-control" Text='<%# Eval("IEP_Value") %>'></asp:TextBox>
                                                            <asp:DropDownList ID="DdlInterest_Code" runat="server" CssClass="form-control raisec" DataSourceID="dsRaisec" DataTextField="IEP_Value" DataValueField="IEP_Type_Id" Style="width: 100%"  >
                                                               
                                                            </asp:DropDownList>
                                                        </div>
                                                    </ItemTemplate>

                                                </asp:Repeater>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row" style="margin: 10px 1px 1px 1px;">
                                                <div class="col-xs-12" style="padding: 10px">
                                                    <label>Career Choices: </label>
                                                </div>

                                                <asp:Repeater ID="ctrlCareerGoals" runat="server">
                                                    <ItemTemplate>

                                                        <div class="col-xs-<%# (12 / (Convert.ToInt32(Eval("field_count")) == 0 ? 1 : Convert.ToInt32(Eval("field_count")))) %>">
                                                            <label>
                                                                <%# Eval("Field_Description") %>
                                                            </label>
                                                            <div>
                                                                <asp:HiddenField runat="server" ID="HiddenField2" Value='<%# Eval("IEP_Type_Id") %>' />
                                                                <asp:TextBox runat="server" MaxLength="30" ID="txtCareer_Goals" CssClass="form-control" Text='<%# Eval("IEP_Value") %>'></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </div>

                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row" style="padding: 10px">

                                                <div class="col-xs-12">
                                                    <label>Personal Strengths: </label>
                                                    <asp:Repeater ID="ctrlPersonalStrengths" runat="server">
                                                        <ItemTemplate>
                                                            <div>
                                                                <asp:HiddenField runat="server" ID="HiddenField3" Value='<%# Eval("IEP_Type_Id") %>' />
                                                                <asp:TextBox runat="server" MaxLength="200" ID="txtPersonal_Strengths" CssClass="form-control" Text='<%# Eval("IEP_Value") %>'></asp:TextBox>
                                                            </div>
                                                        </ItemTemplate>

                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row" style="padding: 10px">
                                                <div class="col-xs-12">
                                                    <label>Qualities to Develop: </label>
                                                    <asp:Repeater ID="ctrlQualitiestoDevelop" runat="server">
                                                        <ItemTemplate>
                                                            <div>
                                                                <asp:HiddenField runat="server" ID="HiddenField4" Value='<%# Eval("IEP_Type_Id") %>' />
                                                                <asp:TextBox runat="server" MaxLength="200" ID="txtQualities_to_Develop" CssClass="form-control" Text='<%# Eval("IEP_Value") %>'></asp:TextBox>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div class="row" style="padding: 10px">
                                                <div class="col-xs-12">
                                                    <label>Hobbies/Interests: </label>
                                                    <asp:Repeater ID="ctrlHobbiesInterests" runat="server">
                                                        <ItemTemplate>
                                                            <div>
                                                                <asp:HiddenField runat="server" ID="HiddenField5" Value='<%# Eval("IEP_Type_Id") %>' />
                                                                <asp:TextBox runat="server" MaxLength="200" ID="txtHobbies_Interests" CssClass="form-control" Text='<%# Eval("IEP_Value") %>'></asp:TextBox>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </div>
                                            </div>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </asp:Panel>
                        <br />
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
                                                        <h5>Subject below 60%</h5>
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
                                                            <div clss="col-xs-12">
                                                                <h4 class="bg-primary text-center">Extra-Curricular Activities and Community Service:</h4>
                                                                <asp:GridView runat="server" ID="grdExtraCurricularActivities" CssClass="table table-bordered" AutoGenerateColumns="false">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Extra Curricular Activities" HeaderText="Extra Curricular Activities" />
                                                                        <asp:BoundField DataField="Activity Title and Organization" HeaderText="Activity Title and Organization" />
                                                                        <asp:BoundField DataField="Role and Responsibilities" HeaderText="Responsibilities" />
                                                                        <asp:BoundField DataField="Hours Week" HeaderText="Hours" />
                                                                        <asp:BoundField DataField="Weeks Year" HeaderText="Weeks/Year" Visible="false" />
                                                                        <asp:BoundField DataField="Timeline" HeaderText="When" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                            <div clss="col-xs-12">
                                                                <h5>Counselor Recommendations:</h5>

                                                                <asp:GridView runat="server" ID="grdCounselorRecommendations" CssClass="table table-bordered" AutoGenerateColumns="false">
                                                                    <Columns>
                                                                        <asp:BoundField DataField="Extra Curricular Activities" HeaderText="Extra Curricular Activities" />
                                                                        <asp:BoundField DataField="Activity Title and Organization" HeaderText="Activity Title and Organization" />
                                                                        <asp:BoundField DataField="Role and Responsibilities" HeaderText="Responsibilities" />
                                                                        <asp:BoundField DataField="Hours Week" HeaderText="Hours" />
                                                                        <asp:BoundField DataField="Weeks Year" HeaderText="Weeks/Year" Visible="false" />
                                                                        <asp:BoundField DataField="Timeline" HeaderText="When" />

                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>

                                                            <div clas="col-xs-12" runat="server" id="div_Honors_Awards" visible="false">
                                                                <h5>Honors/Awards:</h5>
                                                                <asp:Literal ID="tblHonors_Awards" runat="server" />
                                                            </div>

                                                            <div clas="col-xs-12" runat="server" id="div_DreamUniversities">
                                                                <h5>Dream Universities:</h5>
                                                                <asp:Literal ID="tblDreamUniversities" runat="server" />
                                                            </div>

                                                            <div clas="col-xs-12" runat="server" id="div_CounsellorRecommendation">
                                                                <h5>Counsellor Recommendation based on career goals:</h5>
                                                                <asp:Literal ID="tblCounsellorRecommendation" runat="server" />
                                                            </div>
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
                                                                            <th style="width: 50%">School Head’s: <%# Eval("Acknowledge_By_School_Head").ToString().Length > 0?Eval("Acknowledge_By_School_Head").ToString():"N/A"%>
                                                                            </th>
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

                                        <div class="row" style="padding: 0px 15px">
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
                                                    <asp:HiddenField runat="server" ID="HiddenField6" />
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
                                                <h5 id="belowmarks" runat="server">Subject below 60%</h5>
                                                <asp:GridView runat="server" ID="grdE_SubjectDetail" CssClass="table table-bordered tbl-no-padding" AutoGenerateColumns="false">
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
                                                                <asp:TextBox runat="server" ID="txtE_Weak_Topic_Areas" CssClass="form-control" Text='<%#Eval("Weak_Topic_Areas") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Targeted Grade">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_Academic_Potential" CssClass="form-control" Text='<%#Eval("Academic_Potential") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Agreed Action Plan">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_Suggested_Study_Hours" CssClass="form-control" Text='<%#Eval("Suggested_Study_Hours") %>'></asp:TextBox>
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
                                            <div runat="server" id="tbl_EYE">
                                                <table class="table table-bordered">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="8" align="center">
                                                                <span runat="server" id="lblE_Term1"></span>&nbsp;&nbsp;
                                                            </th>

                                                        </tr>
                                                    </thead>
                                                    <tbody>
                                                        <asp:Literal runat="server" ID="htmlE_SubjectBody1">
                                                    
                                                        </asp:Literal>
                                                    </tbody>
                                                </table>

                                            </div>

                                            <br />




                                            <br />
                                            <br />
                                            <asp:Panel clas="col-xs-12" runat="server" ID="DIV_Teacher011">
                                                <h5 id="belowmarks1" runat="server">Subject below 60%</h5>
                                                <asp:GridView runat="server" ID="grdE_SubjectDetail1" CssClass="table table-bordered tbl-no-padding" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Subject">
                                                            <ItemTemplate>
                                                                <asp:HiddenField runat="server" ID="HiddenField7" Value='<%# Eval("Subject_Id") %>' />
                                                                <span style="padding: 5px; font-size: 12px"><%#Eval("Subject_Name") %></span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="Marks" HeaderText="Marks" ItemStyle-VerticalAlign="Middle" ItemStyle-HorizontalAlign="Center" />
                                                        <asp:TemplateField HeaderText="Weak topic areas">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="TextBox1" CssClass="form-control" Text='<%#Eval("Weak_Topic_Areas") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Targeted Grade">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="TextBox2" CssClass="form-control" Text='<%#Eval("Academic_Potential") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Agreed Action Plan">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="TextBox3" CssClass="form-control" Text='<%#Eval("Suggested_Study_Hours") %>'></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Suggested Work Plan" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="TextBox4" CssClass="form-control" Text='<%#Eval("Suggested_Work_Plan") %>'></asp:TextBox>
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

                                        <asp:Panel class="form-group" runat="server" ID="DIV_Teacher02">
                                            <h5>Class teacher comments (Achievements, Personality, Behaviour, Areas to work on)</h5>
                                            <asp:TextBox runat="server" ID="txtE_AcademicConcerns" TextMode="MultiLine" CssClass="form-control" Style="min-height: 100px" Enabled="false">
                                            </asp:TextBox>
                                        </asp:Panel>
                                        <asp:Panel clss="col-xs-12" runat="server" ID="DIV_Counsellor01">
                                            <div clas="col-xs-12" runat="server" id="divE_Honors_Awards" visible="false">
                                                <h5>Honors/Awards:</h5>
                                                <table class="table table-bordered tbl-no-padding">
                                                    <tr>
                                                        <th>Award/Honor</th>
                                                        <th>Awarding Body</th>
                                                        <th>Year</th>
                                                    </tr>
                                                    <asp:Repeater ID="repHonors_Awards" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtE_Award_Honor" CssClass="form-control" Text='<%#  Eval("Award_Honor")%>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtE_Awarding_Body" CssClass="form-control" Text='<%#  Eval("Awarding_Body")%>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtE_Year" CssClass="form-control" Text='<%#  Eval("Year")%>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                            </div>
                                            <div id="Div_progressing" runat="server" visible="false">
                                                <div clas="col-xs-12">
                                                    <h4 class="bg-primary text-center" style="padding: 10px" runat="server" id="H2"></h4>
                                                    <h5>You will be progressing to:</h5>
                                                </div>
                                                <div>
                                                    <asp:RadioButton ID="rd_progress1" runat="server" GroupName="progressing"></asp:RadioButton>
                                                    <asp:Label runat="server">A Levels</asp:Label>
                                                    <asp:RadioButton ID="rd_progress2" runat="server" GroupName="progressing"></asp:RadioButton>
                                                    <asp:Label runat="server">F.A / F.Sc / ICS</asp:Label>

                                                </div>
                                            </div>

                                            <div clas="col-xs-12" runat="server" id="div_subjects" visible="false">
                                                <h5>A Level Subjects</h5>
                                                <table class="table table-bordered tbl-no-padding">
                                                    <%-- <tr>
                                                        <th>Award/Honor</th>
                                                        <th>Awarding Body</th>
                                                        <th>Year</th>
                                                    </tr>--%>
                                                    <asp:Repeater ID="rep_subjects" runat="server">
                                                        <ItemTemplate>
                                                            <tr>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtsubject1" CssClass="form-control" Text='<%#  Eval("Subject_1")%>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtsubject2" CssClass="form-control" Text='<%#  Eval("Subject_2")%>'></asp:TextBox>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox runat="server" ID="txtsubject3" CssClass="form-control" Text='<%#  Eval("Subject_3")%>'></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </table>
                                            </div>
                                            <br />

                                            <h4 class="bg-primary text-center">Extra-Curricular Activities and Community Service:</h4>
                                            <asp:GridView runat="server" ID="grdE_ExtraCurricularActivities" CssClass="table table-bordered tbl-no-padding" AutoGenerateColumns="false" OnRowDataBound="grdE_ExtraCurricularActivities_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Extra Curricular Activities" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:HiddenField runat="server" ID="hfE_IEP_ECA_Id" Value='<%# Eval("IEP_ECA_Id") %>' />
                                                            <asp:HiddenField runat="server" ID="hfE_IEP_Id" Value='<%# Eval("IEP_Id") %>' />
                                                            <asp:TextBox runat="server" ID="txtE_ExtraCurricularActivities" Text='<%# Eval("Extra_Curricular_Activities") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activity">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtE_ActivityTitleandOrganization" Text='<%# Eval("Activity_Title_and_Organization") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Organization">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtorganization" Text='<%# Eval("Organization") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Responsibilities">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtE_RoleandResponsibilities" Text='<%# Eval("Role_and_Responsibilities") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Hours">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="txtE_HoursWeek" Text='<%# Eval("Hours_Week") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--  <asp:TemplateField HeaderText="Weeks/Year" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_WeeksYear" Text='<%# Eval("Weeks_Year") %>' CssClass="form-control"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="When" ControlStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <asp:HiddenField runat="server" ID="hfE_Timeline" Value='<%# Eval("Timeline") %>' />
                                                            <asp:DropDownList runat="server" ID="rdbE_Timeline" CssClass="form-control" Style="width: 100%" DataSourceID="dsTimline" DataTextField="Description" DataValueField="IEP_Sub_Type_Id"></asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>
                                        <asp:Panel clss="col-xs-12" runat="server" ID="DIV_Counsellor02">
                                            <h5>Counselor Recommendations:</h5>

                                            <asp:GridView runat="server" ID="grdE_CounselorRecommendations" CssClass="table table-bordered tbl-no-padding" AutoGenerateColumns="false" OnRowDataBound="grdE_CounselorRecommendations_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Extra Curricular Activities" Visible="false">
                                                        <ItemTemplate>
                                                            <asp:HiddenField runat="server" ID="hfE_IEP_ECA_Id" Value='<%# Eval("IEP_ECA_Id") %>' />
                                                            <asp:HiddenField runat="server" ID="hfE_IEP_Id" Value='<%# Eval("IEP_Id") %>' />
                                                            <asp:TextBox runat="server" ID="TextBox5" Text='<%# Eval("Extra_Curricular_Activities") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Activity">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="TextBox6" Text='<%# Eval("Activity_Title_and_Organization") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Organization">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="TextBox7" Text='<%# Eval("Organization") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Responsibilities">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="TextBox8" Text='<%# Eval("Role_and_Responsibilities") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Hours">
                                                        <ItemTemplate>
                                                            <asp:TextBox runat="server" ID="TextBox9" Text='<%# Eval("Hours_Week") %>' CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <%--  <asp:TemplateField HeaderText="Weeks/Year" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:TextBox runat="server" ID="txtE_WeeksYear" Text='<%# Eval("Weeks_Year") %>' CssClass="form-control"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>--%>
                                                    <asp:TemplateField HeaderText="When" ControlStyle-Width="200px">
                                                        <ItemTemplate>
                                                            <asp:HiddenField runat="server" ID="hfE_Timeline" Value='<%# Eval("Timeline") %>' />
                                                            <asp:DropDownList runat="server" ID="rdbE_Timeline" CssClass="form-control" Style="width: 100%" DataSourceID="dsTimline" DataTextField="Description" DataValueField="IEP_Sub_Type_Id"></asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </asp:Panel>

                                        <asp:Panel runat="server" ID="DIV_Counsellor04">

                                            <div clas="col-xs-12" runat="server" id="divE_DreamUniversities" visible="false">
                                                <h5>Dream Universities:</h5>
                                                <table class="table table-bordered tbl-no-padding">
                                                    <tr>
                                                        <th>International</th>
                                                        <th>Local</th>
                                                    </tr>
                                                    <tr>
                                                        <asp:Repeater ID="repDreamUniversities" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox runat="server" ID="txtE_International" CssClass="form-control" Text='<%#  Eval("International")%>'></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox runat="server" ID="txtE_Local" CssClass="form-control" Text='<%#  Eval("Local")%>'></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tr>
                                                </table>
                                            </div>
                                            <div clas="col-xs-12" runat="server" id="divE_CounsellorRecommendation" visible="false">
                                                <h5>Counsellor Recommendation based on career goals:</h5>
                                                <table class="table table-bordered tbl-no-padding">
                                                    <tr>
                                                        <th>International</th>
                                                        <th>Local</th>
                                                    </tr>
                                                    <tr>
                                                        <asp:Repeater ID="repCounsellorRecommendation" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
                                                                    <td>
                                                                        <asp:TextBox runat="server" ID="TextBox10" CssClass="form-control" Text='<%#  Eval("International")%>'></asp:TextBox>
                                                                    </td>
                                                                    <td>
                                                                        <asp:TextBox runat="server" ID="TextBox11" CssClass="form-control" Text='<%#  Eval("Local")%>'></asp:TextBox>
                                                                    </td>

                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </tr>
                                                </table>
                                            </div>
                                        </asp:Panel>
                        </div>

                        </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel runat="server" ID="DIV_Counsellor03">
                                            <div runat="server" id="div_OLevels" visible="true">
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
                                                <div clas="col-xs-12" runat="server" id="div_undertaking" visible="false">

                                                    <div class="text-center">
                                                        <h4>For All Years</h4>
                                                    </div>
                                                    <h5>Academic or Disciplinary Undertakings Issued:</h5>
                                                    <table class="table table-bordered tbl-no-padding">
                                                        <tr>
                                                            <th>Date of issue</th>
                                                            <th>Reason</th>
                                                            <th>Parent's Signature</th>
                                                            <th>School Head Signature</th>
                                                        </tr>
                                                        <asp:Repeater ID="rpt_undertakingissued" runat="server">
                                                            <ItemTemplate>
                                                                <tr>
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
                                                                        <asp:TextBox runat="server" Enabled="false" ID="txt_signaure" CssClass="form-control" Text='<%#  Eval("signature")%>'></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </table>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-xs-12">
                                                    <h4>Acknowledgement</h4>
                                                    <table class="table table-condensed signature">
                                                        <tbody>
                                                            <tr>
                                                                <th style="width: 50%">Class Teacher’s: <span runat="server" id="lblAcknowledge_By_Class_Teacher" class="signname"></span>
                                                                </th>
                                                                <th style="width: 50%">School Head’s: <span runat="server" id="lblAcknowledge_By_School_Head" class="signname"></span>
                                                                </th>
                                                            </tr>
                                                            <tr>
                                                                <th style="width: 50%">Counselor’s: <span runat="server" id="lblAcknowledge_By_Counselor" class="signname"></span>
                                                                </th>
                                                                <th style="width: 50%">Parent’s: <span runat="server" id="lblAcknowledge_By_Parent" class="signname"></span>
                                                                </th>
                                                            </tr>
                                                        </tbody>
                                                    </table>

                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </td>
                                </tr>
                        </table>
                    </div>

                </div>

            </div>
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
    
        </form>

    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>



<script type="text/javascript" src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.10/js/jquery.dataTables.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/1.10.10/js/dataTables.bootstrap.min.js"></script>
<script type="text/javascript" src="https://cdn.datatables.net/tabletools/2.2.4/js/dataTables.tableTools.min.js"></script>

    <!--new file-->

<script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.0/js/dataTables.buttons.min.js"></script>
<script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jszip/3.1.3/jszip.min.js"></script>

<script type="text/javascript" src="https://cdn.datatables.net/buttons/2.0.0/js/buttons.html5.min.js"></script>
    <!--new file-->
<script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js"
    type="text/javascript"></script>
 
<script type="text/javascript" src="../../AMSScripts/js/dataTables.fixedColumns.min.js"></script>
<script type="text/javascript" src="../../AMSScripts/plugin/datepicker/dist/zebra_datepicker.min.js"></script>
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/toastr.js/2.0.2/js/toastr.min.js"></script>
<script type="text/javascript" src="../../AMSScripts/js/ams.js"></script>

<script type="text/javascript">
    function toasterOptions() {
        toastr.options = {
            "closeButton": true,
            "debug": false,
            "newestOnTop": false,
            "progressBar": true,
            "positionClass": "toast-bottom-right",
            "preventDuplicates": true,
            "onclick": null,
            "showDuration": "1000",
            "hideDuration": "1000",
            "timeOut": "10000",
            "extendedTimeOut": "1000",
            "showEasing": "swing",
            "hideEasing": "linear",
            "showMethod": "fadeIn",
            "hideMethod": "fadeOut"
            /*"closeButton": false,
        "debug": false,
        "newestOnTop": true,
        "progressBar": true,
        "positionClass": "toast-top-right",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "show",
        "hideMethod": "hide"*/
        };
    };
    function CallToastr(message, success, MessageType) {
        toasterOptions();
        if (MessageType == 0) { toastr.error(message); }
        else { toastr.success(message); }

    }






</script>
<%--      <script type="text/javascript" src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
        <script src="printThis.js"></script>
    <script> 
    //$('#basic').on("click", function () {
            $('#basic').click(function () {
                $('.demo').printThis({
                    base: "https://jasonday.github.io/printThis/"
                });
            });
    </script>--%>

<%--     <script src="Component_Marks/ReportCard/jquery-3.3.1.min.js" type="text/JavaScript" language="javascript"></script>--%>
    
    <!------------------------------------------------SALMAN REPORT ------------------------------------------------>
  <script src="../Component_Marks/ReportCard/jquery-ui-1.10.4.custom.js" type="text/JavaScript" language="javascript"></script>
    <script src="../Component_Marks/ReportCard/jquery.PrintArea.js" type="text/JavaScript" language="javascript"></script>

    <link type="text/css" rel="stylesheet" href="../Component_Marks/ReportCard/css/ui-lightness/jquery-ui-1.10.4.custom.css" />

    <link type="text/css" rel="stylesheet" href="../Component_Marks/ReportCard/SalmanReport.css" /><!--PrintArea3 SalmanReport-->
     <link type="text/css" rel="stylesheet" href="../Component_Marks/ReportCard/Raja_iep_report.css" /><!--PrintArea3 Raja IEP Report-->
     <%--<link type="text/css" rel="stylesheet" href="Component_Marks/ReportCard/Bifraction_Letter.css" />--%>
        <link type="text/css" rel="stylesheet" href="../Component_Marks/ReportCard/media_all.css" media="all" />   <!-- Y : rel is stylesheet and media is in [all,print,empty,undefined] -->
    <link type="text/css" rel="" href="../Component_Marks/ReportCard/empty.css" />                    <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="noPrint" href="../Component_Marks/ReportCard/noPrint.css" />                  <!-- N : rel is not stylesheet -->
    <link type="text/css" rel="stylesheet" href="../Component_Marks/ReportCard/media_none.css" media="xyz" />   <!-- N : media not in [all,print,empty,undefined] -->
    <link type="text/css" href="../Component_Marks/ReportCard/no_rel.css" media="print" /> <!-- N : no rel attribute -->
    <link type="text/css" href="../Component_Marks/ReportCard/no_rel_no_media.css" /> <!-- N : no rel, no media attributes -->
     <link href="../Component_Marks/Content/sweetalert2.min.css" rel="stylesheet" />
    <script>

        $('[data-toggle="tooltip"]').tooltip();
        var dialog = $("div.testDialog").dialog({ position: { my: "left top", at: "left bottom+50", of: ".SettingsBox" }, width: "1000", title: "Print Dialog Box Contents" });

        $(".toggleDialog").click(function () {
            dialog.dialog("open");
        });

        $("div.b1").click(function () {

            var mode = $("input[name='mode']:checked").val();
            var close = mode == "popup" && $("input#closePop").is(":checked");
            var extraCss = $("input[name='extraCss']").val();

            var print = "";
            $("input.selPA:checked").each(function () {
                print += (print.length > 0 ? "," : "") + "div.PrintArea." + $(this).val();
            });

            var keepAttr = [];
            $(".chkAttr").each(function () {
                if ($(this).is(":checked") == false)
                    return;

                keepAttr.push($(this).val());
            });

            var headElements = $("input#addElements").is(":checked") ? '<meta charset="utf-8" />,<meta http-equiv="X-UA-Compatible" content="IE=edge"/>' : '';

            var options = { mode: mode, popClose: close, extraCss: extraCss, retainAttr: keepAttr, extraHead: headElements };

            $(print).printArea(options);




        });
        function printr(item) {
            var mode = $("input[name='mode']:checked").val();
            var close = mode == "popup" && $("input#closePop").is(":checked");
            var extraCss = $("input[name='extraCss']").val();

            var print = "";
            $("input.selPA:checked").each(function () {
                print += (print.length > 0 ? "," : "") + "div.PrintArea." + $(this).val();
            });

            var keepAttr = [];
            $(".chkAttr").each(function () {
                if ($(this).is(":checked") == false)
                    return;
                keepAttr.push($(item).val());
            });

            var headElements = $("input#addElements").is(":checked") ? '<meta charset="utf-8" />,<meta http-equiv="X-UA-Compatible" content="IE=edge"/>' : '';

            var options = { mode: mode, popClose: close, extraCss: extraCss, retainAttr: keepAttr, extraHead: headElements };

            $(print).printArea(options);
        }
        $('.onlyalphabetallow').bind('keyup blur', function () {
            var node = $(this);
            node.val(node.val().replace(/[^a-z,A-Z]/g, ''));
        });
        $('.onlynumberallow').bind('keyup blur', function () {
            var node = $(this);
            node.val(node.val().replace(/[^0-9]/g, ''));
        });
        //var self = $("#ContentPlaceHolder1_txtHeadName");
        //// self.val(self.val().replace(/[^0-9\.]/g, ''));withdecimal
        //self.val(self.val().replace(/[^0-9]/g, ''));//withoutdecimal
    </script>

       <!------------------------------------------------SALMAN REPORT ------------------------------------------------>


    <!------------------------------------------------Raja Report------------------------------->
     <script>
         var centerIep = '<%= Session["cId"] %>';
         var ssid_Iep = '<%= Session["Session_Id"] %>';
         var teacherid_Iep = '<%= Session["EmployeeCode"] %> ';
     </script>
      <script src="../Component_Marks/Content/sweetalert2.min.js"></script>
        <script src="../Component_Marks/ReportCard/IEPReport.js" type="text/JavaScript" language="javascript"></script>
    <!------------------------------------------------Raja Report------------------------------->

<script type="text/javascript">
    var jq = $;//.noConflict(); 
</script>
    <style>
        /***EXCEL BUTTON*/

.dt-buttons {
    position: relative;
    float: none !important;
    text-align: center !important;
}

.dt-buttons button {
    background: #9eb5d5;
    border: white !important;
}

    .dt-buttons button span {
        color: white !important;
        /* border: #fff !important; */
    }

/***EXCEL BUTTON*/

/***RAJA IEP*/
.overlay {
    background: url('Component_Marks/Content/logo2.gif') no-repeat center center;
    position: absolute;
    top: 0;
    left: 0;
    height: 100%;
    width: 100%;
    z-index: 9999999;
    background-color: rgba(0,0,0,0.5);
}
    .overlay {
    position:fixed !important;
    }

        .iephiddenfield {
        display:none;
        }
        .academic_history1 th:nth-child(3), .academic_history2 th:nth-child(3), .academic_history th:nth-child(3), .academic_history1 tbody td:nth-child(3), .academic_history2 tbody td:nth-child(3), .academic_history tbody td:nth-child(3){
    display: none;
}
        .teacherfeedbacktable tbody td {
    padding: 0px !important;
}
        .subtds {
    padding: 0px !important;
}
        .subtds input {
    border-radius: 0px !important;
    border: none !important;
}
        .academic_history2 {
    /* padding-top: 10px !important; */
    margin-top: 10px;
}

        .teacherfeedbacktable {
    overflow: scroll !important;
}
/**RAJA IEP*/
    </style>
 
    
    <script>
        $(".raisec").change(function () {
            var selectedval = $(this).val();
            var disabledval = $(".raisec option[value=" + selectedval + "]").prop('disabled');
            //alert(disabledval);
            $(".raisec option").prop('disabled', false);
            $(".raisec option[value=" + selectedval + "]").prop('disabled', true);
            //if (disabledval == true) {
            //    $(".raisec option").prop('disabled', false);
            //    $(".raisec option[value=" + selectedval + "]").prop('disabled', true);
            //}
            //else {
            //    $(".raisec option[value=" + selectedval + "]").prop('disabled', true);
            //}

        });
    </script>



   <%-- </asp:Content>--%>
