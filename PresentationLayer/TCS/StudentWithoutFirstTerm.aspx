<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true" CodeFile="StudentWithoutFirstTerm.aspx.cs" Inherits="PresentationLayer_TCS_StudentWithoutFirstTerm" %>
<%@ Register TagPrefix="uc" TagName="SearchStudent" Src="~/PresentationLayer/TCS/SearchStudent.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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

                                            { orderable: false, targets: [3, 4]} //disable sorting on toggle button
                                        ]

                                ,
                                    tableTools:
                    { //Start of tableTools collection
                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                        "aButtons":
                         [ //start of button main/master collection
            ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true
         , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false //, fixedHeader: true , "stateSave": true
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
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Students Joined in 2nd Term"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right">
                <br />
             <%--   <asp:Button runat="server" ID="addPanel" OnClick="btnAddPanel_Click" CssClass="btn btn-primary"
                    Text="Add"></asp:Button>--%>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    List of Students Joined in 2nd Term
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvStudents" runat="server" CssClass="datatable table table-striped table-responsive"
                    OnPreRender="gvStudents_PreRender" AutoGenerateColumns="False" HorizontalAlign="Center"
                    Width="100%">
                    <RowStyle CssClass="tr1" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="10px" />
                            <ItemStyle HorizontalAlign="Left" Width="10px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Student_Id" HeaderText="Roll #">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Student_Name" HeaderText="Student Name">
                            <HeaderStyle HorizontalAlign="Left" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Left" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class ">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Name" HeaderText="Section">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Delete">
                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="Delete" runat="server" CommandArgument='<%# Eval("Student_Id") %>'
                                    ImageUrl="~/images/delete.gif" ToolTip="Delete" OnClick="btnDelete_Click" OnClientClick="javascript:return confirm('Are you sure you want to Delete?');">
                                    <span class="glyphicon glyphicon-trash"></span>
                                </asp:LinkButton>
                            </ItemTemplate>
                            <HeaderStyle Width="20px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                    </Columns>
                    <SelectedRowStyle CssClass="tr_select" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
                <asp:Label ID="lblNoDatadt" runat="server" Visible="False"></asp:Label>
            </div>
           
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <uc:SearchStudent runat="server" ID="SearchStudent1" />
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right ">
                    <br />
                    <asp:Button ID="btnSearch" TabIndex="1" OnClick="but_search_Click" runat="server"
                        CssClass="btn btn-primary" Text="Search"></asp:Button>
                   <%-- <asp:Button ID="btnCancelPanel" OnClick="btnCancelPanel_Click" runat="server" CssClass="btn btn-danger"
                        Text="Cancel"></asp:Button>--%>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" runat="server" id="SearchTitle"
                    visible="false">
                    <div id="Div1" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        &nbsp; Search Results
                    </div>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <asp:GridView ID="dg_student" runat="server" DataKeyNames="student_id" CssClass="datatable table table-striped table-bordered table-hover"
                        OnPreRender="dg_student_PreRender" AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="row" HeaderText="#">
                                <%--0--%>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Aims_Id" HeaderText="AIMS ID">
                                <%--1--%>
                                <ItemStyle CssClass="hide"></ItemStyle>
                                <HeaderStyle CssClass="hide"></HeaderStyle>
                            </asp:BoundField>
                            <asp:BoundField DataField="Student_No" HeaderText="Student No">
                                <%--2--%>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" HeaderText="Name">
                                <%--3--%>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Country_Name" HeaderText="Country" Visible="false">
                                <%--4--%>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Name" HeaderText="Region">
                                <%--5--%>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Name" HeaderText="Center">
                                <%--6--%>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                <%--7--%>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                                <%--8--%>
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Section_Name" HeaderText="Section">
                                <%--9--%>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Section_Id" HeaderText="Section_Id">
                                <%--10--%>
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                <%--11--%>
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="student_status" HeaderText="Status">
                                <%--12--%>
                                <ItemStyle Font-Size="14px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Region_Id" HeaderText="Region_Id">
                                <%--13--%>
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Center_Id" HeaderText="Center_Id">
                                <%--14--%>
                                <ItemStyle CssClass="hide" />
                                <HeaderStyle CssClass="hide" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Add">
                                <%--15--%>
                                <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                                <ItemTemplate>
                                    <asp:LinkButton runat="server" ID="btnAdd" CommandArgument='<%# Eval("Student_Id") %>'
                                        OnClick="btnAdd_Click" Visible='<%# (int)( Eval("Student_Status_Id"))==5%>'>
                                <span class="glyphicon glyphicon-plus"></span>
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <SelectedRowStyle ForeColor="SlateGray" />
                        <RowStyle CssClass="tr2" BackColor="White"></RowStyle>
                        <HeaderStyle CssClass="tableheader"></HeaderStyle>
                        <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                    </asp:GridView>
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


