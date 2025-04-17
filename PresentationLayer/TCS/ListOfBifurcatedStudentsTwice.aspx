<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="ListOfBifurcatedStudentsTwice.aspx.cs" Inherits="PresentationLayer_TCS_ListOfBifurcatedStudentsTwice" %>


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
            <style type="text/css">
                .form-check-input tbody tr td input[type=radio] {
                    margin: 4px 7px 0;
                    height: 15px;
                    width: 15px;
                }

                .form-check-input tbody tr td label {
                    position: relative;
                    top: -2px;
                }
            </style>

            <script type="text/javascript">
                function openModal() {
                    //                    $('#myModal').modal('show');
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
            </script>
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

                                        // { orderable: false, targets: [0] } //disable sorting on toggle button
                                    ]

                                    ,
                                    tableTools:
                                    { //Start of tableTools collection
                                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                        "aButtons":
                                            [ //start of button main/master collection




                                            ] // ******************* end of button master Collection
                                    } // ******************* end of tableTools
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 100, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true , "order": [[6, "asc"]]
                                    , "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": true
                                    , //--- Dynamic Language---------
                                    "oLanguage": {
                                        "sZeroRecords": "There are no Records that match your search critera",
                                        "sLengthMenu": "Display _MENU_ records per page&nbsp;&nbsp;",
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
                        <td>
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="List of Bifurcated Students Twice"></asp:Label>
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
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr id="tr4" runat="server">
                                    <td style="width: 37%;"></td>
                                    <td style="width: 50%;"></td>
                                </tr>
                                <tr style="width: 50%">
                                    <td align="right" colspan="1" style="height: 18px; text-align: right; width: 37%;">&nbsp;
                                    </td>
                                    <td align="left" style="width: 60%">&nbsp;
                                    </td>
                                </tr>
                            </table>
                            <table class="main_table" cellspacing="0" cellpadding="0" width="100%" align="center"
                                border="0">
                                <tr style="width: 100%">
                                    <td align="center" style="width: 100%"></td>
                                </tr>
                                <tr>
                                    <td align="right" colspan="12">
                                        <asp:Button ID="btnViewReport" runat="server" class="button" OnClick="btnViewReport_Click"
                                            Text="View Report" ValidationGroup="s" Visible="False" Width="96px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="12">
                                        <asp:Label runat="server" ID="lblGridStatus" CssClass="TextLabelMandatory40" ForeColor="Red"
                                            Text="">
                                        </asp:Label>
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td id="tdSearch" runat="server" class="titlesection" colspan="7" visible="false">&nbsp; Student(s) List
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="12">
                                        <p>
                                        </p>
                                    </td>
                                </tr>
                                <tr id="Tr3" runat="server" style="width: 100%">
                                    <td style="width: 100%">
                                        <asp:GridView ID="gv_details" runat="server" DataKeyNames="student_Id,Session_Id_pre,Session_Id_cur,Session_id_pre,Session_id_cur,Session_pre,Session_cur,Region_Id_pre,Region_Id_cur,Region_Name_pre,Region_Name_cur,Center_Id_pre,Center_Id_cur,Center_Name_pre,Center_Name_cur,Class_Id_pre,Class_Id_cur,Class_Name_pre,Class_Name_cur,Section_Name_pre,Section_Name_cur,Submit_RD_By_Id_pre,Submit_RD_By_Id_cur,Submit_RD_By_Name_pre,Submit_RD_By_Name_cur,Submit_RD_On_pre,Submit_RD_On_cur,Remarks_pre,Remarks_cur,RD_Approval_By_Id_pre,RD_Approval_By_Id_cur,RD_Approval_By_Name_pre,RD_Approval_By_Name_cur,RD_Approval_On_pre,RD_Approval_On_cur,RD_Remarks_pre,RD_Remarks_cur,TermGroupID" 
                                            AutoGenerateColumns="False" CssClass="datatable table table-hover table-responsive"
                                            OnPreRender="gv_details_PreRender" OnRowDataBound="gv_details_RowDataBound">
                                            <SelectedRowStyle CssClass="tr_select" />
                                            <Columns>
                                                <asp:BoundField DataField="student_Id" HeaderText="Student ID"></asp:BoundField>
                                                <asp:BoundField DataField="Student_Name" HeaderText="Student Name"></asp:BoundField>

                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndetail" runat="server" class="btn btn-primary" CommandArgument='<%# Eval("Student_Id") %>'
                                                            OnClick="btndetail_Click" Text="Detail" ToolTip="View Detail"><i class="fa fa-2x fa-eye"></i></asp:LinkButton>
                                                        <a runat="server" id="btnaction" title="Proceed To Bifurcate" class="btn btn-primary" href='<%# ResolveUrl("~/PresentationLayer/IEP_Undertaking_Bifurcation.aspx?S=" + Eval("student_Id").ToString()+"&C=" + Eval("Section_id_cur").ToString()+"&T="+Eval("TermGroupID").ToString()) %>' target="_blank"><i class="fa fa-2x fa-external-link"></i></a>
                                                    </ItemTemplate>
                                                    <ItemStyle VerticalAlign="Middle" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                            <RowStyle CssClass="tr1" />
                                            <HeaderStyle CssClass="tableheader" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr runat="server" style="width: 100%">
                                    <td style="width: 100%"></td>
                                </tr>
                                <tr id="btns" runat="server" visible="false">
                                    <td colspan="3" style="height: 6px; text-align: center;">&nbsp;
                                    </td>
                                </tr>
                                <tr style="width: 100%">
                                    <td style="width: 100%">&nbsp;
                                    </td>
                                </tr>
                                <tr id="trButtons" runat="server" aliign="center" style="width: 100%">
                                    <td align="center" style="height: 19px; text-align: center">&nbsp;
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="container">

                <%--h2>
                    Modal Example</h2>--%><!-- Trigger the modal with a button --><!-- Modal --><div
                        class="modal fade" id="myModal" role="dialog">
                        <div class="modal-dialog">
                            <!-- Modal content-->
                            <div class="modal-content">
                                <div class="modal-header">
                                    <button type="button" class="close" data-dismiss="modal">
                                        &times;</button>
                                    <h4 class="modal-title text-center">List of Bifurcated Students Twice Detail</h4>
                                </div>
                                <div class="modal-body">
                                    <div class="row">
                                        <div class="col-xs-6">
                                            <label>Student Id: </label>
                                            <br />
                                            <asp:Label ID="lblStudentID" runat="server"></asp:Label>
                                        </div>
                                        <div class="col-xs-6">
                                            <label>Student Name: </label>
                                            <br />
                                            <asp:Label ID="lblStudentName" runat="server"></asp:Label>
                                        </div>
                                    </div>
                                    <hr />

                                    <div class="row" style="margin: 5px; border: solid 1px #efefef; max-height: 370px; overflow: auto;">
                                        <div class="col-xs-6" style="background-color: #f6f6f6">
                                            <div class="row text-center text-primary " style="background-color: #f6f6f6; z-index: 1; position: sticky; top: 0; padding: 10px; border-bottom: solid 2px #efefef">
                                                <div class="col-xs-12">
                                                    <label style="font-size: 18px; padding: 10px;">Previous</label>

                                                </div>
                                            </div>

                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Session:</label>
                                                    <p runat="server" id="lblPreSession"></p>
                                                </div>

                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Region:</label>
                                                    <p runat="server" id="lblPreRegion"></p>
                                                </div>

                                            </div>

                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Center:</label>
                                                    <p runat="server" id="lblPreCenter"></p>
                                                </div>

                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Class:</label>
                                                    <p runat="server" id="lblPreClass"></p>
                                                </div>

                                            </div>

                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Section:</label>
                                                    <p runat="server" id="lblPreSection"></p>
                                                </div>

                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Submited By:</label>
                                                    <p runat="server" id="lblPreSubmitedBy"></p>
                                                </div>

                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Submited On:</label>
                                                    <p runat="server" id="lblPreSubmitedOn"></p>
                                                </div>

                                            </div>

                                            <div class="row" style="height: 150px; padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Remarks:</label>
                                                    <p runat="server" id="lblPreRemarks"></p>
                                                </div>
                                            </div>

                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Approved By:</label>
                                                    <p runat="server" id="lblPreApprovedBy"></p>
                                                </div>
                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Approved On:</label>
                                                    <p runat="server" id="lblPreApprovedOn"></p>
                                                </div>
                                            </div>
                                            <div class="row" style="height: 150px; padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>RD Remarks:</label>
                                                    <p runat="server" id="lblPreRDRemarks"></p>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-xs-6">
                                            <div class="row text-center text-primary" style="background-color: #ffffff; position: sticky; z-index: 1; top: 0; padding: 10px; border-bottom: solid 2px #efefef">

                                                <div class="col-xs-12">
                                                    <label style="font-size: 18px; padding: 10px;">Current</label>

                                                </div>
                                            </div>

                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Session:</label>
                                                    <p runat="server" id="lblCurSession"></p>
                                                </div>

                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Region:</label>
                                                    <p runat="server" id="lblCurRegion"></p>
                                                </div>

                                            </div>

                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Center:</label>
                                                    <p runat="server" id="lblCurCenter"></p>
                                                </div>

                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Class:</label>
                                                    <p runat="server" id="lblCurClass"></p>
                                                </div>

                                            </div>

                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Section:</label>
                                                    <p runat="server" id="lblCurSection"></p>
                                                </div>

                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Submited By:</label>
                                                    <p runat="server" id="lblCurSubmitedBy"></p>
                                                </div>

                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Submited On:</label>
                                                    <p runat="server" id="lblCurSubmitedOn"></p>
                                                </div>

                                            </div>

                                            <div class="row" style="height: 150px; padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Remarks:</label>
                                                    <p runat="server" id="lblCurRemarks"></p>
                                                </div>

                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Approved By:</label>
                                                    <p runat="server" id="lblCurApprovedBy"></p>
                                                </div>
                                            </div>
                                            <div class="row" style="padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>Approved On:</label>
                                                    <p runat="server" id="lblCurApprovedOn"></p>
                                                </div>
                                            </div>
                                            <div class="row" style="height: 150px; padding: 5px; border-bottom: solid 1px #efefef">
                                                <div class="col-xs-12">
                                                    <label>RD Remarks:</label>
                                                    <p runat="server" id="lblCurRDRemarks"></p>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button type="button" class="btn btn-default" data-dismiss="modal">
                                        Close</button>
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

