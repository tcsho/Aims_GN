<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ClassSectionSubjectCommentsReview.aspx.cs" Inherits="PresentationLayer_TCS_ClassSectionSubjectCommentsReview" %>


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
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": -1, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
                                    , "order": [[0, "asc"]], "paging": false, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": true
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
                function closeModal() {

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

            <script type="text/javascript">
                function openModalTest() {
                    //                    $('#myModal').modal('show');
                    $('#TestModal').modal({
                        //backdrop: 'static',
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
            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td>
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Student's Subject Comments Review"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <table class="main_table col-lg-12 col-md-12 col-xs-12 col-sm-12" cellspacing="0" cellpadding="0"
                                border="0">
                                <tr class="row">
                                    <%-- <td class="TextLabelMandatory40">
                                    </td>--%>
                                    <td class="col-lg-3 col-md-3 col-xs-12 col-sm-12">
                                        <label class="TextLabelMandatory40">Session*:</label>
                                        <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>


                                    <%-- <td class="TextLabelMandatory40">
                                    </td>--%>
                                    <td class="col-lg-3 col-md-3 col-xs-12 col-sm-12">
                                        <label class="TextLabelMandatory40">Class Section*:</label>
                                        <asp:DropDownList ID="List_ClassSection" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                            OnSelectedIndexChanged="List_ClassSection_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>


                                    <%-- <td class="TextLabelMandatory40">Subject:
                                    </td>--%>
                                    <td class="col-lg-3 col-md-3 col-xs-12 col-sm-12">
                                        <label class="TextLabelMandatory40">Subject:</label>
                                        <asp:DropDownList ID="list_Subject" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                            OnSelectedIndexChanged="list_Subject_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>


                                    <%--<td class="TextLabelMandatory40">
                                    </td>--%>
                                    <td class="col-lg-3 col-md-3 col-xs-12 col-sm-12">
                                        <label class="TextLabelMandatory40">Term*:</label>
                                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" CssClass="dropdownlist form-control"
                                            OnSelectedIndexChanged="list_Term_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>

                                </tr>
                                <%-- <tr class="row">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 40%;">&nbsp;
                                    </td>
                                    <td align="left" style="width: 60%">&nbsp;
                                    </td>
                                </tr>--%>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr style="width: 100%" runat="server" id="trrRowN">
                                    <td style="width: 100%">

                                        <asp:GridView ID="dv_details" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                                            CssClass="datatable table table-striped table-responsive" OnPreRender="dv_details_PreRender" OnRowDataBound="dv_details_RowDataBound">
                                            <AlternatingRowStyle CssClass="tr2" />
                                            <Columns>
                                                <asp:BoundField DataField="Std_Com_Id" SortExpression="Std_Com_Id" HeaderText="0">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GoodOne" SortExpression="GoodOne" HeaderText="1">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="GoodTwo" SortExpression="GoodTwo" HeaderText="2">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ImprovOne" SortExpression="ImprovOne" HeaderText="3">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ImprovTwo" SortExpression="ImprovTwo" HeaderText="4">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Effort" SortExpression="Effort" HeaderText="5">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Subject_Id" SortExpression="Subject_Id" HeaderText="6">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Class_Id" SortExpression="Class_Id" HeaderText="7">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Gender" SortExpression="Gender" HeaderText="8">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="fullname" SortExpression="fullname" HeaderText="9">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Section_Subject_Id" SortExpression="Section_Subject_Id" HeaderText="10">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="Student_Id" SortExpression="Student_Id" HeaderText="11">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="isAbsent" SortExpression="isAbsent" HeaderText="12">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />
                                                </asp:BoundField>


                                                <asp:TemplateField HeaderText="No.">
                                                    <ItemStyle Width="2%" />
                                                    <ItemTemplate>
                                                        <%# Container.DataItemIndex + 1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField DataField="StudentNameId" SortExpression="StudentNameId" HeaderText="Roll # -Student Name">
                                                    <ItemStyle Width="15%" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Subject_Name" SortExpression="Subject_Name" HeaderText="Subject">
                                                    <ItemStyle Width="10%" />
                                                </asp:BoundField>

                                                <asp:BoundField DataField="NewRemarks" SortExpression="NewRemarks" HeaderText="Subject Comments_heading" Visible="false">
                                                    <ItemStyle Width="65%" CssClass="maiproblem" />

                                                </asp:BoundField>


                                                <asp:TemplateField HeaderText="Other Information">
                                                    <HeaderStyle Font-Size="14px" HorizontalAlign="Center" Width="65%" />
                                                    <ItemStyle Font-Size="14px" />
                                                    <ItemTemplate>
                                                         <%# Eval("NewRemarks") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="EffortCode" SortExpression="EffortCode" HeaderText="Effort">
                                                    <ItemStyle Width="5%" />

                                                </asp:BoundField>
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemStyle HorizontalAlign="Center" Width="3%" />
                                                    <HeaderStyle HorizontalAlign="Center" />
                                                    <ItemTemplate>



                                                        <asp:Panel runat="server" ID="trdes">

                                                            <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("Std_Com_Id") %>'
                                                                ForeColor="#004999" OnClick="btnEdit_Click" CssClass="btn-lg editbtn"
                                                                ToolTip="Edit Record" Enabled='<%# Eval("isLock").ToString()=="True"?false:true%>'><!-- -->
                                    <i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>
                                                            </asp:LinkButton>
                                                        </asp:Panel>
                                                    </ItemTemplate>
                                                </asp:TemplateField>



                                                <asp:BoundField DataField="isLock" SortExpression="isLock" HeaderText="isLock">
                                                    <ItemStyle CssClass="hide" />
                                                    <HeaderStyle CssClass="hide" />

                                                </asp:BoundField>

                                            </Columns>


                                            <SelectedRowStyle BackColor="PaleGoldenrod" />
                                            <RowStyle CssClass="tr1" />
                                            <HeaderStyle CssClass="tableheader" />
                                            <AlternatingRowStyle CssClass="tr2" />
                                        </asp:GridView>


                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr id="trButtons" runat="server" style="width: 100%" aliign="center">
                                    <td style="height: 19px; text-align: center" align="center">&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>


            <div class="container">

                <div class="modal fade" id="TestModal" role="dialog">
                    <div class="modal-dialog">

                        <!-- Modal content-->
                        <div class="modal-content">
                            <div class="modal-header">
                                <%--          <button type="button" class="close" data-dismiss="modal" >&times;</button>--%>
                                <h4 class="modal-title">Update Subject Comments</h4>
                            </div>
                            <div class="modal-body">
                                <p>
                                    <asp:Label ID="Label2" runat="server" CssClass="TextLabelMandatory40 hide" Text="Absent from classes"></asp:Label>
                                    <asp:CheckBox ID="chkAbsent" Text="" CssClass="hide" AutoPostBack="true" runat="server" OnCheckedChanged="chkAbsent_OnCheckedChanged" />
                                </p>


                                <div id="trComments" runat="server">
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <p class="gridtxt">
                                            <asp:Label runat="server" ID="pleasetxtengtest">I am really pleased with <%# Eval("fullname")%>’s</asp:Label>
                                            <asp:Panel ID="listG1div" CssClass="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding" runat="server">
                                                <asp:DropDownList ID="listG1" runat="server" CssClass="dropdownlist form-control"></asp:DropDownList>
                                            </asp:Panel>
                                            <asp:Panel runat="server" CssClass="col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp" ID="andp">
                                                <asp:Label runat="server" ID="andtxt">and</asp:Label>
                                            </asp:Panel>
                                            <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding">
                                                <asp:DropDownList ID="listG2" runat="server" CssClass="dropdownlist form-control"></asp:DropDownList>.
                                            </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                        <p class="gridtxt">
                                            <asp:Label runat="server" ID="improtxt1">I would like to see an improvement in  
                                                                    <%#((Eval("Gender").ToString()=="M")?"his":"her")%>
                                            </asp:Label>
                                            <asp:Panel ID="listImp1div" CssClass="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding" runat="server">
                                                <asp:DropDownList ID="listImp1" runat="server" CssClass="dropdownlist form-control"></asp:DropDownList>
                                            </asp:Panel>

                                            <asp:Panel runat="server" CssClass="col-lg-2 col-md-2 col-xs-12 col-sm-12 text-center andp" ID="andp2">
                                                <asp:Label runat="server" ID="improtxtand">
                                                                        and<%--  also in <%#((Eval("Gender").ToString()=="M")?"his":"her")%>--%>
                                                </asp:Label>
                                            </asp:Panel>

                                            <div class="col-lg-5 col-md-5 col-xs-12 col-sm-12 nopadding">
                                                <asp:DropDownList ID="listImp2" runat="server" CssClass="dropdownlist form-control"></asp:DropDownList>.
                                            </div>

                                            <asp:Panel runat="server" CssClass="col-lg-12 col-md-12 col-xs-12 col-sm-12 ufloat_right gridtxt no_padding" ID="gridtxt">
                                                <asp:Label runat="server" ID="improtxt2" CssClass="text-right">
                                                                            <%-- .میں بہتری  کے لیے پرامید ہوں --%>
                                                </asp:Label>
                                            </asp:Panel>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-xs-12 col-sm-12 nopadding marginbtm">
                                        <asp:Label ID="lblEffort" runat="server" CssClass="TextLabelMandatory40" Text="Effort: "></asp:Label>
                                        <asp:DropDownList ID="listEffort" runat="server" CssClass="dropdownlist form-control">
                                            <asp:ListItem Text="Select" Value="0" />
                                            <asp:ListItem Text="Excellent: 1" Value="1" />
                                            <asp:ListItem Text="Good: 2" Value="2" />
                                            <asp:ListItem Text="Satisfactory: 3" Value="3" />
                                            <asp:ListItem Text="Needs improving: 4" Value="4" />
                                        </asp:DropDownList>

                                    </div>
                                    <br />
                                    <asp:Label ID="lblerror" ForeColor="Red" runat="server" Visible="false"></asp:Label>
                                </div>

                                <div id="trAttendance" runat="server" class="absentdiv">
                                    <asp:Label ID="lblabsenttxt" ForeColor="Red" runat="server" CssClass="lbltxtabsent"></asp:Label>
                                    <asp:Label ID="lblAbsent" ForeColor="Red" runat="server"></asp:Label>
                                </div>

                            </div>
                            <div class="modal-footer">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary" OnClick="btnSave_Click"
                                    Text="Save" CausesValidation="true" ValidationGroup="test" />

                                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
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

    <style type="text/css">
        .TextLabelMandatory40 {
            font-size: 14px !important;
            font-weight: bold;
            color: black;
            width: 100% !important;
            text-align: left !important;
        }

        .dropdownlist {
            margin-left: 0px !important;
        }

        .nopadding {
            padding-left: 0px;
            padding-right: 0px;
        }

        .gridchildheading {
            margin-bottom: 10px;
            padding-left: 0px;
            font-size: 15px !important;
        }

        .studentgrid {
            padding: 1% !important;
        }

        .absent_checkbox input {
            position: relative;
            top: 4px;
            margin-right: 10px !important;
        }

        .savearea {
            position: unset !important;
            padding: 10px 0px;
        }

        .andp {
            margin-bottom: 0px !important;
            line-height: 30px;
            font-size: 14px;
        }

        .gridtxt {
            font-size: 14px !important;
        }

        .stuname, .rollno, .gendername {
            font-weight: 700;
        }

        .upperheading {
            background: #0c4da2;
            padding: 10px;
            /* margin: 10px !important; */
            border: 1px solid #fff;
            border-radius: 10px;
        }

            .upperheading span {
                color: #fff;
            }

        .right-align.form-control {
            direction: rtl !important;
        }

        .left-align.form-control {
            direction: ltr !important;
        }

        .urdutxtright {
            /*direction: rtl !important;*/
            /*float:right !important;*/
            display: flex;
            justify-content: flex-end;
        }

        .urdutxtleft {
            /*direction:ltr !important;*/
            /*display: flex;*/
            justify-content: end;
        }

        .hidetxt {
            display: none;
        }

        .showtxt {
            display: block;
        }

        .ufloat_right {
            float: right;
        }

        .text-right {
            text-align: right;
        }

        .no_padding {
            padding-left: 0px !important;
            padding-right: 0px !important
        }

        .gridtxt {
            margin: 5px 0px !important;
        }

        .hidebtn {
            display: none !important;
        }

        .maiproblem span:nth-child(1) span::after {
            content: " میں";
        }

        .maiproblem span:nth-child(1) {
            float: right;
        }

            .maiproblem span:nth-child(1) span {
                margin-left: 5px;
                font-size: 10px;
            }

        .maiproblemabsent span:nth-child(1) span::after {
            content: " میں";
        }

        .maiproblemabsent span:nth-child(1) {
            float: right;
            color: red;
            margin-left: 3px;
        }



        .absentdiv {
            text-align: right !important;
        }

        .lbltxtabsent {
            float: right;
            margin-left: 8px;
        }


        .marginbtm {
            margin-bottom: 10px;
        }

        .DTTT_container {
            display: none;
        }
    </style>
</asp:Content>

