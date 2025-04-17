<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="Bifurcation.aspx.cs" Inherits="PresentationLayer_TCS_Bifurcation" %>

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


                         ] // ******************* end of button master Collection
                    } // ******************* end of tableTools
         , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
         , "order": [[0, "asc"]], "paging": true, "ordering": false, "searching": true, "info": true, "scrollX": false, "stateSave": true
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
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="List of Bifurcated Students"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <p>
                <br />
            </p>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div runat="server" id="div1" class="col-lg-6 col-md-6 col-sm-6 col-xs-12 form-group">
                </div>
                <div runat="server" id="divBifurcation" class="col-lg-6 col-md-6 col-sm-6 col-xs-12 form-group">
                    <div class="pull-right">
                        <asp:Button ID="btnAllBifurcation" runat="server" CssClass="btn btn-default active"
                            OnClick="btnAllbifurcation_Click" Text="All" />
                        <asp:Button ID="btnPending" runat="server" Text="List of Bifurcated Students" CssClass="btn btn-primary active"
                            OnClick="btnPending_Click" />
                        <asp:Button ID="btnShowAll" runat="server" CssClass="btn btn-danger active" Text="Olevels Stream"
                            OnClick="btnOstream_Click" />
                        <asp:Button ID="btnShowMatric" runat="server" Text="Matric Stream" CssClass="btn btn-success active"
                            OnClick="btnMStream_Click" />
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                    <asp:Label ID="Label3" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="Session : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="dropdownlist"
                            OnSelectedIndexChanged="ddlSession_SelectedIndexChanged" Width="218px">
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="Label1" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40"
                        Text="Region : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddl_region" runat="server" CssClass="dropdownlist" Width="218px"
                            OnSelectedIndexChanged="ddl_region_SelectedIndexChanged" AutoPostBack="True">
                        </asp:DropDownList>
                    </div>
                    <asp:Label ID="Label4" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabel40"
                        Text="Center : "></asp:Label>
                    <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                        <asp:DropDownList ID="ddl_center" runat="server" CssClass="dropdownlist" Width="218px"
                            AutoPostBack="True" OnSelectedIndexChanged="ddl_center_SelectedIndexChanged">
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Label runat="server" ID="lblGridStatus" CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 TextLabelMandatory40 text-left"
                    ForeColor="Red" Text="">    </asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    &nbsp; List of Bifurcated Students [Class 8]
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <p>
                </p>
                <asp:GridView ID="gvbifurcation" runat="server" AutoGenerateColumns="False" CssClass="datatable table table-hover table-responsive"
                    OnPreRender="gvBifurcation_PreRender">
                    <Columns>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student No">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Center_Id" HeaderText="Center_Id" ItemStyle-CssClass="hide"
                            HeaderStyle-CssClass="hide">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Region_Id" HeaderText="Region_Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Id" HeaderText="Section_Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="">
                            <ItemStyle HorizontalAlign="Center" Width="100%" />
                            <ItemTemplate>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Student No. :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Student_Id")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Student Name :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("StudentName")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Class-Section:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Class_Name")%>-<%# Eval("Section_Name")%></div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Session :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Session_Name")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Region :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Region_Name")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Center Name:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Center_Name")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40 text-left">
                                        <br />
                                        Bifurcation Reason:
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <br />
                                        <%# Eval("ResultStatus")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40 text-left">
                                        Transfer To:
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Class_Description")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12">
                                        <div class="pull-right" runat="server" visible='<%# (int)( Eval("ShowStatus"))==0 %>'>
                                            <asp:DropDownList runat="server" ID="ddlBifurcation" CssClass="dropdownlist" visible='<%#(Eval("flag").ToString() == "1")?true:false%>'>
                                                <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                                <asp:ListItem Value="17" Text="Class 9 Matric Stream"></asp:ListItem>
                                                <asp:ListItem Value="13" Text="Class 9 Olevel Stream Against School Advice"></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:Button ID="btnMatric1" runat="server" Text="Save" CssClass="btn btn-primary"
                                                OnClientClick="return confirm('Note for Matric Stream: Student will be unassigned to be transfered to Matric Stream. Are you sure you want to continue?')"
                                                OnClick="btnBifurcationStudent_Click" CommandArgument='<%# Eval("Student_Id") %>' 
                                                visible='<%#(Eval("flag").ToString() == "1")?true:true%>'
                                                
                                                />
                                            <%-- OnClick="btnBifurcationStudent_Click"  <asp:RequiredFieldValidator ID="RF1" runat="server" ControlToValidate="ddlBifurcation"
                                                InitialValue="0" ErrorMessage="Please Select a Bifurcation Stream"  ></asp:RequiredFieldValidator>--%>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                        <div class="pull-right">
                                            <asp:CheckBox ID="ChkSys" runat="server" CssClass="checkbox" Text="E-Result format" />
                                            <asp:Button runat="server" ID="btnViewReport" OnClick="btnViewReport_Click" CssClass="btn btn-info"
                                                Text="View Result Card" CommandArgument='<%# Eval("Student_Id") %>' />
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Wrap="true" />
                        </asp:TemplateField>
                        <asp:BoundField DataField="flag" HeaderText="flag">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>

                    </Columns>
                    <RowStyle CssClass="tr2" />
                    <HeaderStyle CssClass="tableheader" />
                    <%--<AlternatingRowStyle  CssClass="hide"  />--%>
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
