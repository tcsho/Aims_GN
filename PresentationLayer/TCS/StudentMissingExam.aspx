<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentMissingExam.aspx.cs" Inherits="PresentationLayer_TCS_StudentMissingExam"
    Theme="BlueTheme" %>

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

                    function document_Ready() {

                        jQuery(document).ready(function () {

                            //****************************************************************


                            try {
                                jQuery('table.datatable').DataTable({
                                    destroy: true,
                                    // sDom: 'T<"dataTables_wrapper"tfrlip>', // its ok


                                    //                    dom: "<'row'<'col-sm-5'T><'col-sm-7'f>>R" +
                                    dom: "<'row'<'col-sm-4'l><'col-sm-3'T><'col-sm-5'f>>R" +
                                        "<'row'<'col-sm-12'tr>>" +
                                        //                     "<'row'<'col-sm-12'l>>" +
                                        "<'row'<'col-sm-12'i>><'row'<'col-sm-12'p>>",
                                    "columnDefs": [

                                        //    { orderable: false, targets: [16]} //disable sorting on toggle button
                                    ]
                                    ,
                                    tableTools:
                                    { //Start of tableTools collection
                                        "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                        "aButtons":
                                            [ //start of button main/master collection


                                            ] // ******************* end of button master Collection
                                    } // ******************* end of tableTools
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 25, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
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
                        jQuery(document).ready(document_Ready);
                        //            document_Ready();
                        //            alert('call back done');
                    }
                    );

                });
            </script>
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Students Absent in Exams"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <br />
            <br />
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <asp:Label runat="server" CssClass="TextLabelMandatory40" ForeColor="Red" Text="Kindly search one student at a time"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <uc:SearchStudent runat="server" ID="SearchStudent1" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div id="Div6" runat="server" class="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40">
                    *Term:
                </div>
                <div runat="server" class="col-lg-8 col-md-8 col-sm-8 col-xs-8 text-left">
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:DropDownList ID="list_Term" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            Width="350px" OnSelectedIndexChanged="list_Term_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-6">
                        <asp:Label ID="Label3" runat="server" CssClass="TextLabelMandatory40 text-left" Text="Please select Term"></asp:Label>
                    </div>
                </div>
                <div runat="server" class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40">
                </div>
                <div id="Div2" runat="server" class="col-lg-3 col-md-3 col-sm-3 col-xs-3 text-left">
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right ">
                <br />
                <asp:Button ID="btnSearch" TabIndex="1" OnClick="but_search_Click" runat="server"
                    CssClass="btn btn-primary" Text="Search"></asp:Button>
                <asp:TextBox ID="txtRollNo" runat="server" placeholder="Student Number" CssClass="form-control textbox"
                    Width="300px" Visible="false"></asp:TextBox>
            </div>
            <%--<div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div id="Div4" runat="server" class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40">
                    Studnet #:
                </div>
                <div id="Div5" runat="server" class="col-lg-6 col-md-6 col-sm-6 col-xs-6 text-left">
                     <asp:Button ID="btnLoad" runat="server" CssClass="btn btn-primary" OnClick="btnLoad_Click"
                        Text="Find Student" ValidationGroup="a" />
                 
                </div>
                <div id="Div2" runat="server" class="col-lg-3 col-md-3 col-sm-3 col-xs-12 form-group">
                </div>
            </div>--%>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection"
                    visible="false">
                    Student Information
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvAttnType" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
                    CssClass="datatable table table-hover table-responsive" OnPreRender="gvAttnType_PreRender" OnRowDataBound="gvAttnType_RowDataBound">
                    <RowStyle CssClass="tr1" />
                    <Columns>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" Visible="False"></asp:BoundField>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Student_No" HeaderText="Student No" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Id" HeaderText="Region Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Id" HeaderText="Class Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Id" HeaderText="Section Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Session_Id" HeaderText="Session Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Id" HeaderText="Subject Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SAbsent_Id" HeaderText="SAbsent_Id" ItemStyle-CssClass="hide"
                            HeaderStyle-CssClass="hide"></asp:BoundField>
                        <asp:BoundField DataField="IsMissingExam" HeaderText="IsMissingExam" ItemStyle-CssClass="hide"
                            HeaderStyle-CssClass="hide"></asp:BoundField>
                        <asp:BoundField DataField="IsMissingCoursework" HeaderText="IsMissingCoursework"
                            ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"></asp:BoundField>
                        <%--18--%>
                        <asp:TemplateField HeaderText="Mark Absent in Coursework" Visible="false">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" CssClass="hide" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" CssClass="hide" />
                            <ItemTemplate>
                                <asp:LinkButton ID="btnCoursework" runat="server" CommandArgument='<%# Eval("SAbsent_Id") %>'
                                    ToolTip="Absent in Coursework" CssClass="btn btn-success active" OnClick="btnAbsentCoursework_Click"
                                    Visible='<%# Convert.ToBoolean(Eval("IsMissingCoursework"))==false %>' Text="Yes">
                                     
                                </asp:LinkButton>
                                <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("SAbsent_Id") %>'
                                    ToolTip="Present in Coursework" CssClass="btn btn-danger active" OnClick="btnPresentCoursework_Click"
                                    Visible='<%# Convert.ToBoolean(Eval("IsMissingCoursework"))==true  %>' Text="No">
                                  
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--19--%>
                        <asp:TemplateField HeaderText="Mark Absent in Exam">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemTemplate>
                                <asp:LinkButton ID="btnExam" runat="server" CommandArgument='<%# Eval("SAbsent_Id") %>'
                                    ToolTip="Absent in Exam" CssClass="btn btn-success active" OnClick="btnExamAbsent_Click" 
                                    Visible='<%# Convert.ToBoolean(Eval("IsMissingExam"))==false   %>' Text="Yes">
                                     
                                </asp:LinkButton>
                                <asp:LinkButton ID="btnExamPresent" runat="server" CommandArgument='<%# Eval("SAbsent_Id") %>'
                                    ToolTip="Present in Exam" CssClass="btn btn-danger active" OnClick="btnExamPresent_Click"
                                    Visible='<%# Convert.ToBoolean(Eval("IsMissingExam"))==true   %>'  Text="No">
                                    
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--20--%>
                        <asp:BoundField DataField="Lock_Fields" HeaderText="Lock Fields">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                         <%--  <asp:BoundField DataField="IsMissingExam" HeaderText="MissingExam">
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                           <asp:BoundField DataField="IsMissingCoursework" HeaderText="IsMissingCoursework">
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>--%>
                    </Columns>
                    <SelectedRowStyle CssClass="tr_select" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
                <asp:Label ID="lblNoData" runat="server" Visible="False"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvOlevels" runat="server" AutoGenerateColumns="False" OnPreRender="gvOlevels_PreRender" OnRowDataBound="gvOlevels_RowDataBound"
                    HorizontalAlign="Center" CssClass="datatable table table-hover table-responsive">
                    <RowStyle CssClass="tr1" />
                    <Columns>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" Visible="False"></asp:BoundField>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Student_No" HeaderText="Student No" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Id" HeaderText="Region Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center Id">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Id" HeaderText="Class Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Id" HeaderText="Section Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Session_Id" HeaderText="Session Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Id" HeaderText="Subject Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Subject_Name" HeaderText="Subject Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <%--15--%>
                        <asp:BoundField DataField="Criteria" HeaderText="Criteria">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="SDash_Id" HeaderText="SAbsent_Id" ItemStyle-CssClass="hide"
                            HeaderStyle-CssClass="hide">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Evaluation_Criteria_Id" HeaderText="Evaluation_Criteria_Id"
                            ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide"></asp:BoundField>
                        <asp:TemplateField HeaderText="Mark Absent for Coursework">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemTemplate>
                                <div id="Div4" runat="server" visible='<%# (int)(Eval("Evaluation_Type_Id"))==1  %>'>
                                    <asp:LinkButton ID="btnCoursework" runat="server" CommandArgument='<%# Eval("SDash_Id") %>'
                                        ToolTip="Absent in Coursework" CssClass="btn btn-success active" OnClick="btnOAbsentCoursework_Click"
                                        Visible='<%# Convert.ToBoolean(Eval("IsMissingCursework"))==false   %>' Text="Yes">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CommandArgument='<%# Eval("SDash_Id") %>'
                                        ToolTip="Present in Coursework" CssClass="btn btn-danger active" OnClick="btnOPresentCoursework_Click"
                                        Visible='<%# Convert.ToBoolean(Eval("IsMissingCursework"))==true   %>' Text="No">
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Mark Absent for Exam">
                            <ItemTemplate>
                                <div runat="server" visible='<%# (int)(Eval("Evaluation_Type_Id"))==2  %>'>
                                    <asp:LinkButton ID="btnExam" runat="server" CommandArgument='<%# Eval("SDash_Id") %>'
                                        ToolTip="Absent in Exam" CssClass="btn btn-success active" OnClick="btnOExamAbsent_Click"
                                        Visible='<%# Convert.ToBoolean(Eval("IsMissingExam"))==false  %>' Text="Yes">
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="btnExamPresent" runat="server" CommandArgument='<%# Eval("SDash_Id") %>'
                                        ToolTip="Present in Exam" CssClass="btn btn-danger active" OnClick="btnOExamPresent_Click"
                                        Visible='<%# Convert.ToBoolean(Eval("IsMissingExam"))==true  %>' Text="No">
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle HorizontalAlign="Center" Font-Size="14px" />
                        </asp:TemplateField>
                         <asp:BoundField DataField="Lock_Fields" HeaderText="Lock Fields">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                    </Columns>
                    <SelectedRowStyle CssClass="tr_select" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
                <asp:Label ID="Label1" runat="server" Visible="False"></asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group" runat="server" id="Div1"
                visible="false">
                <div id="Div3" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    List of Students Missing Exams
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvAttnTypedt" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center">
                    <RowStyle CssClass="tr1" />
                    <Columns>
                        <asp:TemplateField HeaderText="No.">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Left" Width="10px" />
                            <ItemStyle HorizontalAlign="Left" Width="10px" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="Student_Id" HeaderText="Roll #"></asp:BoundField>
                        <asp:BoundField DataField="Student_Name" HeaderText="Student Name"></asp:BoundField>
                        <asp:BoundField DataField="Region_Id" HeaderText="Region_Id"></asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center_Id"></asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class_Name"></asp:BoundField>
                        <asp:BoundField DataField="Section_Name" HeaderText="Section"></asp:BoundField>
                        <asp:BoundField DataField="Subject_Id" HeaderText="Subject_Id"></asp:BoundField>
                        <asp:BoundField DataField="Subject_Name" HeaderText="Subject_Name"></asp:BoundField>
                    </Columns>
                    <SelectedRowStyle CssClass="tr_select" />
                    <HeaderStyle CssClass="tableheader" />
                    <AlternatingRowStyle CssClass="tr2" />
                </asp:GridView>
                <asp:Label ID="lblNoDatadt" runat="server" Visible="False"></asp:Label>
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
