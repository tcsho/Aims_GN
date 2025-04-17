<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="TermSubjectStudentComments.aspx.cs" Inherits="PresentationLayer_TCS_TermSubjectStudentComments" %>

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
                                $('table.datatable').DataTable({
                                    destroy: true,
                                    "dom": 'Blfrtip',
                                    buttons: [
                                        {
                                            extend: 'excel',
                                            exportOptions: {
                                                columns: [6,10,11,12,13, 7, 8]
                                            }
                                        }
                                    ],
                                    "lengthMenu": [[10, 25, 50, -1], [10, 25, 50, "All"]],
                                });
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
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Term Subject Dynamic Commnets"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <p>

                    <br />
                </p>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                            <asp:Label ID="Label3" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Region: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="list_region" runat="server" CssClass="dropdownlist" AutoPostBack="True" Width="218px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblsession" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Session: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                                    OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px" >
                                </asp:DropDownList>
                            </div>
                        </div>

                                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label8" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Session: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlTerm" runat="server" AutoPostBack="True" 
                                            CssClass="dropdownlist" 
                                            OnSelectedIndexChanged="list_term_SelectedIndexChanged" Width="217px" >
                                       
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
                            <asp:Label ID="Label7" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                                Text="*Subject : "></asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
 

                                <asp:DropDownList ID="ddlsubject" runat="server" AutoPostBack="True"
                                    CssClass="dropdownlist " Width="218px"
                                    OnSelectedIndexChanged="ddlSubject_SelectedIndexChanged">
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
                    <asp:GridView ID="gvStaticComments" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                        CssClass="datatable table table-striped table-responsive" OnPreRender="gvTest_PreRender">
                        <AlternatingRowStyle CssClass="tr2" />
                        <Columns>
                                <%--0--%>
                            <asp:BoundField DataField="ComBank_Id" HeaderText="ComBank_Id" SortExpression="ComBank_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                                <%--1--%>
                            <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--2--%>
                            <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">

                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--3--%>
                            <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--4--%>
                            <asp:BoundField DataField="TermGroup_Id" HeaderText="TermGroup_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--5--%>
                            <asp:BoundField DataField="CommCat_Id" HeaderText="CommCat_Id">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--6--%>

                            <asp:TemplateField HeaderText="Sr. #">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <%--7--%>
                             <asp:BoundField DataField="CommentsType" HeaderText="Comments Type">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <%--8--%>
                            <asp:BoundField DataField="Comments" HeaderText="Comments">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            </asp:BoundField>
                            <%--9--%>
                            <asp:TemplateField HeaderText="Edit">
                                <ItemStyle HorizontalAlign="Center" />
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnEdit" runat="server" CommandArgument='<%# Eval("ComBank_Id") %>'
                                        ForeColor="#004999" OnClick="btnEdit_Click" CssClass="btn-lg"
                                        ToolTip="Edit Record">
                                    <i class="glyphicon glyphicon-edit TextLabelMandatory40 text-success"></i>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <%--10--%>
                            <asp:BoundField DataField="Session_Name" HeaderText="Session_Name">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--11--%>
                            <asp:BoundField DataField="Class_Name" HeaderText="Class_Name">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--12--%>
                            <asp:BoundField DataField="Subject_Name" HeaderText="Subject_Name">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <%--13--%>
                            <asp:BoundField DataField="TermGroup_Name" HeaderText="TermGroup_Name">
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                        </Columns>
                        <SelectedRowStyle BackColor="PaleGoldenrod" />
                        <RowStyle CssClass="tr1" />
                        <HeaderStyle CssClass="tableheader" />
                        <AlternatingRowStyle CssClass="tr2" />
                    </asp:GridView>
                </div>

                <div runat="server" id="divTestButtons" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group text-uppercase" visible="false">
 
                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-10">
 
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <p>
                                <br />
                            </p>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="Gridtitle" visible="false">
                        </div>
 

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server" id="GridTitleAns" visible="false">
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
                                    <h4 class="modal-title">Student Comments</h4>
                                </div>
                                <div class="modal-body">
                                    <p>
                                       <asp:Label ID="Label1" runat="server" CssClass="TextLabelMandatory40" Text="Comments Type "></asp:Label>

                                        <asp:DropDownList CssClass="form-control" ID="ddlCommentCat" runat="server">
                                            <asp:ListItem Value="3">---Please Select---</asp:ListItem>
                                            <asp:ListItem Value="0">Neutral</asp:ListItem>
                                            <asp:ListItem Value="1">Positive</asp:ListItem>
                                            <asp:ListItem Value="2">Negative</asp:ListItem>
                                        </asp:DropDownList>
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddlCommentCat"
                                            ErrorMessage="Type Required" InitialValue="3" ForeColor="Red" ValidationGroup="test" />    
                                    </p>
                                    <p>
                                       <asp:Label ID="lblTestName" runat="server" CssClass="TextLabelMandatory40" Text="Comments"></asp:Label>
                                      <asp:TextBox ID="txtTestName" runat="server" CssClass="form-control " TextMode="MultiLine" Enabled="true"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTestName"
                                            ErrorMessage="Name Required" ForeColor="Red" ValidationGroup="test" />

                                    </p>
                                  <%--  <p>
                                        <asp:Label ID="lblMarks" runat="server" CssClass="TextLabelMandatory40" Text="Comments: "></asp:Label>
                                        <asp:TextBox ID="txtMarks" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator4" runat="server" Operator="DataTypeCheck"
                                            ForeColor="Red" ValidationGroup="test" Type="Double" ControlToValidate="txtMarks"
                                            ErrorMessage="Please enter a Numeric value" />
                                    </p>--%>

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

        <style>
    .dt-buttons {
    position: relative;
    float: none !important;
    text-align: center !important;
}
    .dt-buttons button {
    background: #9eb5d5;
    border:white !important;
}
    .dt-buttons button span {
    color: white !important;
    /* border: #fff !important; */
}
</style>
</asp:Content>

