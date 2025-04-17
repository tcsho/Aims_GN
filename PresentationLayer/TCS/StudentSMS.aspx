<%@ Page Title="Students SMS" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="StudentSMS.aspx.cs" Inherits="PresentationLayer_TCS_StudentSMS" %>

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

                                { orderable: false, targets: [8, 9] } //disable sorting on toggle button
                            ]

                            ,
                            tableTools:
                            { //Start of tableTools collection
                                "sSwfPath": "http://cdn.datatables.net/tabletools/2.2.4/swf/copy_csv_xls_pdf.swf",
                                "aButtons":
                                    [ //start of button main/master collection


                                    ] // ******************* end of button master Collection
                            } // ******************* end of tableTools
                            , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 200, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
                            , "order": [[0, "asc"]], "paging": true, "ordering": true, "searching": true, "info": true, "scrollX": false, "stateSave": false
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
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="form-group formheading">
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="Students SMS"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="container">
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12" runat="server">
                        <div class="pull-right">
                            <%--<asp:Button ID="btnComplie" runat="server" CssClass="btn btn-primary"
                                Text="Compile" Visible="false" />
                            <asp:Button ID="btnSendSMS" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                Text="Lock Marks"></asp:Button>
                            <asp:Button ID="btnSearch" runat="server" CausesValidation="False" CssClass="btn btn-success"
                                Text="Search"></asp:Button>--%>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label1" CssClass="TextLabelMandatory40" Text="*Term: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlTerm"
                            Width="250px">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label3" CssClass="TextLabelMandatory40" Text="*Session: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlSession"
                            Width="250px">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row" runat="server" visible="false">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label8" CssClass="TextLabelMandatory40" Text="*Evaluation Type: "
                                runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlEvaluationType" AutoPostBack="true"
                            Width="250px" Visible="false">
                            <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                            <asp:ListItem Value="1" Text="CourseWork"></asp:ListItem>
                            <asp:ListItem Value="2" Text="Exam/Theory"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label4" CssClass="TextLabelMandatory40" Text="*Region: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" OnSelectedIndexChanged="ddlRegion_SelectedIndexChanged" AutoPostBack="true" runat="server" ID="ddlRegion"
                            Width="250px">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label5" CssClass="TextLabelMandatory40" Text="*Center: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlCenter" AutoPostBack="true"
                            Width="250px" OnSelectedIndexChanged="ddlCenter_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label6" CssClass="TextLabelMandatory40" Text="Class: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlClass"
                            Width="250px">
                        </asp:DropDownList>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row" runat="server" visible="false">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <div class="pull-right">
                            <asp:Label ID="Label7" CssClass="TextLabelMandatory40" Text="Section: " runat="server"> </asp:Label>
                        </div>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                        <%--<asp:DropDownList CssClass="dropdownlist" runat="server" ID="ddlSection" AutoPostBack="true"
                            Width="250px" OnSelectedIndexChanged="ddlSection_SelectedIndexChanged">
                        </asp:DropDownList>--%>
                    </div>
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                    </div>
                </div>
                <div class="row">
                    <div id="Div1" class="col-lg-12 col-md-12 col-sm-12 col-xs-12" runat="server">
                        <div class="pull-right">                            
                            <asp:Button ID="btnSearch" runat="server" CausesValidation="False" CssClass="btn btn-success"
                                Text="Search" OnClick="btnSearch_Click"></asp:Button>
                            <asp:Button ID="btnSendSMS" runat="server" CausesValidation="False" CssClass="btn btn-danger"
                                Text="Send SMS" Enabled="false"></asp:Button>
                            <br />
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection" runat="server"
                        id="GridTestTitle" visible="false">
                        Students SMS List
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                        <asp:GridView ID="gv_CenterGrid" runat="server" AutoGenerateColumns="False" CssClass="datatable table table-striped table-responsive"
                            DataKeyNames="Center_Id" OnPreRender="gv_CenterGrid_PreRender">
                            <Columns>
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
                                <asp:BoundField DataField="Session_Id" HeaderText="Session_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TermGroup_Id" HeaderText="TermGroup_Id">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Region_Name" HeaderText="Region Name">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Center_Name" HeaderText="Center Name">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Section_Name" HeaderText="Section Name">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Student_Id" HeaderText="Student Id">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="fullname" HeaderText="Student Name">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="FeeDefaulter" HeaderText="Fee Defaulter">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="SMSSent" HeaderText="SMS Sent">
                                    <ItemStyle Font-Size="14px" />
                                </asp:BoundField>
                                <%--<asp:TemplateField HeaderText="Lock /Unlock Marks">
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Visible='<%#(int )( Eval("Class_Id"))>6 && Convert.ToBoolean( Eval("LockMark"))==false%> '
                                            ForeColor="Red" class="glyphicon glyphicon-remove"></asp:Label>
                                        <asp:Label ID="Label3" runat="server" Visible='<%# (int )( Eval("Class_Id"))>6 && Convert.ToBoolean( Eval("LockMark"))==true%> '
                                            ForeColor="Green" class="glyphicon glyphicon-ok"></asp:Label>
                                        <asp:Label ID="Label9" runat="server" Visible='<%#(int )( Eval("Class_Id"))<=6 && Convert.ToBoolean( Eval("LockMarkEYE"))==false%> '
                                            ForeColor="Red" class="glyphicon glyphicon-remove"></asp:Label>
                                        <asp:Label ID="Label10" runat="server" Visible='<%#(int )( Eval("Class_Id"))<=6 && Convert.ToBoolean( Eval("LockMarkEYE"))==true%> '
                                            ForeColor="Green" class="glyphicon glyphicon-ok"></asp:Label>                                        
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <%--<asp:TemplateField HeaderText="Select">
                                    <HeaderTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="toggleCheck">Select</asp:LinkButton>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="CheckBox1" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                            </Columns>
                            <RowStyle CssClass="tr1" />
                            <HeaderStyle CssClass="tableheader" />
                            <AlternatingRowStyle CssClass="tr2" />
                        </asp:GridView>
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