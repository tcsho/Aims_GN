<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentVerification.aspx.cs" Inherits="PresentationLayer_TCS_StudentVerification" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/jquery-1.4.1.min.js" />
            <asp:ScriptReference Path="~/Scripts/jquery-impromptu.2.7.min.js" />
        </Scripts>
    </cc1:ToolkitScriptManager>
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

                                    //       { orderable: false, targets: [9, 11, 12] } //disable sorting on toggle button
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
            <div class="form-group">
                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Stduent Verification"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <br />
                <br />
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server">
                    List of Students</div>
                <div class="row">
                    <br />
                    <br />
                </div>
                <br />
                <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                    CssClass="datatable table table-striped table-bordered table-hover table-sm "
                    OnPreRender="gvStudents_PreRender">
                    <AlternatingRowStyle CssClass="tr2" />
                    <Columns>
                        <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Id" HeaderText="Region_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Id" HeaderText="Class_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Id" HeaderText="Section_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Sr. #">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student #">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemTemplate>
                                <span id="Span2" runat="server" visible='<%# (int)( Eval("Student_Id"))>0%>' style="font-size: 14px;">
                                    <%# Eval("Student_Id")%></span>
                                <asp:TextBox runat="server" ID="txtStdId" CssClass="form-control" placeholder="Student Number"
                                Visible='<%# (int)( Eval("Student_Id"))==0%>'></asp:TextBox>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Student Name">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Left" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemTemplate>
                                <span id="Span1" runat="server" visible='<%# (int)( Eval("Student_Id"))>0%>' style="font-size: 14px;">
                                    <%# Eval("name")%></span>
                                <asp:TextBox runat="server" ID="txtStdName" AutoPostBack="true" CssClass="form-control" placeholder="Student Name"
                                    OnTextChanged="txtStdName_TextChanged" Visible='<%# (int)( Eval("Student_Id"))==0%>'></asp:TextBox>
                               
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student_Id" SortExpression="Student_Id">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="name" HeaderText="Studnet Name">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="Verify">
                            <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                            <HeaderStyle HorizontalAlign="Center" Font-Size="14px" />
                            <ItemTemplate>
                                <div id="Div1" runat="server" visible='<%# (int)( Eval("Student_Id"))==0 %>'>
                                    <asp:LinkButton runat="server" ID="btnRemove" CommandArgument='<%# Eval("Student_Id") %>'
                                        OnClick="btnRemove_Click" ClientIDMode="AutoID">
                                    <span class="glyphicon glyphicon-trash"></span>
                                    </asp:LinkButton>
                                </div>
                                <div runat="server" visible='<%# (int)( Eval("Student_Id"))>0 %>'>
                                    <asp:LinkButton runat="server" ID="btnVerify" CommandArgument='<%# Eval("Student_Id") %>'
                                        Visible='<%# (int)( Eval("isVerified"))<=0 %>' OnClick="btnVerify_Click" ToolTip="Click to Verify">
                                    <span class="glyphicon glyphicon-plus"></span>
                                    </asp:LinkButton>
                                    <asp:LinkButton runat="server" Visible='<%# (int)( Eval("isVerified"))>0 %>' ToolTip="Verified for this month">
                                    <span class="glyphicon glyphicon-ok"></span>
                                    </asp:LinkButton>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <div class="row">
                    <div class="pull-right">
                        <asp:Button runat="server" ID="btnaddStudent" Text="Add More Students" CssClass="btn btn-primary"
                            OnClick="btnaddStudent_Click"></asp:Button>
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
