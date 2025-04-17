<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="ListOfPrivatizedStudents.aspx.cs" Inherits="PresentationLayer_TCS_ListOfPrivatizedStudents" %>

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
                  , "mColumns": [4]
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
                     , "mColumns": [4]
              }  // ******************* end of csv button

              // ******************* Start of excel button
               , {
                   'sExtends': 'xls',
                   'bShowAll': false,
                   "sFileName": "DataInExcelFormat.xls",
                   //'sButtonText': 'Save to Excel',
                   "sButtonText": "<span class='fa fa-file-excel-o'></span> Save to Excel",
                   "sToolTip": "Save as Excel"
                    , "mColumns": [4]
               }  // ******************* End of excel button


              // ******************* Start of PDF button
              , {
                  'sExtends': "pdf",
                  'bShowAll': false,
                  "sButtonText": "<span class='fa fa-file-pdf-o'></span> Save to PDF",
                  //'sButtonText': 'Save to PDF',
                  "sFileName": "DataInPDFFormat.pdf",
                  "sToolTip": "Save as PDF" //,"sPdfOrientation": "landscape"
                     , "mColumns": [4]
                  //,"sPdfMessage": "Your custom message would go here."
              } // *********************  End of PDF button 

               ]// ******************* end of Export buttons collection
          }    // ******************* end of child of export buttons collection
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
                <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="List of Privatised Students"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <p>
                <br />
            </p>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                 <asp:Button ID="btnCompile" runat="server" CssClass="btn btn-info active" 
                     Text="Compile Privatise Students" onclick="btnCompile_Click"/>
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
                            OnSelectedIndexChanged="ddl_Region_SelectedIndexChanged" AutoPostBack="True">
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
                <div runat="server" id="divPrivate" class="col-lg-4 col-md-4 col-sm-4 col-xs-12 form-group">
                    <div class="pull-right">
                        <asp:Button ID="btnAll" runat="server" CssClass="btn btn-default active" Text="All"
                            OnClick="btnAll_Click" />
                        <asp:Button ID="btnOlevels" runat="server" Text="O-Levels " CssClass="btn btn-primary"
                            OnClick="btnOlevels_Click" />
                        <asp:Button ID="btnAlevles" runat="server" Text="A-Levels " CssClass="btn btn-warning"
                            OnClick="btnAlevles_Click" />
                    </div>
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:Label runat="server" ID="lblGridStatus" CssClass="col-lg-12 col-md-12 col-sm-12 col-xs-12 TextLabelMandatory40 text-left"
                    ForeColor="Red" Text="">    </asp:Label>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection"
                    colspan="7" visible="false">
                    &nbsp; List of Privatised Students [Class 11 (O Level) and A-2 (A Level)]
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <p>
                </p>
                <asp:GridView ID="gvPrivate" runat="server" AutoGenerateColumns="False" OnPreRender="gvPrivate_PreRender"
                    CssClass="datatable table table-hover table-responsive">
                    <Columns>
                        <asp:BoundField DataField="Student_Id" HeaderText="Student No">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="StudentName" HeaderText="Student Name">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Id" HeaderText="Class_Id" ItemStyle-CssClass="hide"
                            HeaderStyle-CssClass="hide">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Class_Name" HeaderText="Class Name">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Section_Id" HeaderText="Section_Id">
                            <HeaderStyle CssClass="hide" />
                            <ItemStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField HeaderText="List Of Privatised Students ">
                            <ItemStyle HorizontalAlign="Center" Width="100%" />
                            <ItemTemplate>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Student No :
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
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Overall Percentage:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Overall_P")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Overall Grade:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("Overall_G")%>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Privatisation Reason:
                                    </div>
                                    <div class="col-lg-9 col-md-9 col-sm-9 col-xs-12 TextLabelMandatory40 text-left"
                                        style="color: <%# Eval("Color") %>;">
                                        <%# Eval("PrivatisationReason")%>
                                        <span id="Span2" class="glyphicon glyphicon-remove" runat="server" style="color: Red;
                                            height: inherit;"></span>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="pull-right">
                                        <asp:CheckBox ID="ChkSys" runat="server" CssClass="checkbox" Text="E-Result format" />
                                        <asp:Button runat="server" ID="btnViewReport" OnClick="btnViewReport_Click" CssClass="btn btn-info"
                                            Text="View Result Card" CommandArgument='<%# Eval("Student_Id") %>' />
                                    </div>
                                </div>
                            </ItemTemplate>
                            <HeaderStyle HorizontalAlign="Center" />
                            <ItemStyle Wrap="true" />
                        </asp:TemplateField>
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
