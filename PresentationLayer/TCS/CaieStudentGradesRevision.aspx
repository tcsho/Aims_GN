<%@ Page Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="CaieStudentGradesRevision.aspx.cs" Inherits="PresentationLayer_TCS_CaieStudentGradesRevision" %>


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
                                    ],
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
                                    , "aLengthMenu": [[10, 25, 50, 100, 200, -1], [10, 25, 50, 100, 200, "All"]], "iDisplayLength": 50, 'bLengthChange': true // ,"bJQueryUI":true , fixedHeader: true 
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
                        jq(document).ready(document_Ready);
                        //            document_Ready();
                        //            alert('call back done');
                    }
                    );
                });
            </script>


            <div class="form-group">
                <div class="form-group formheading">
                    <asp:Label ID="Label2" CssClass="lblFormHead" runat="server" Text="CAIE Student Gardes Revision"></asp:Label>
                    <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                        border="0" />
                </div>
                <p>
                    <br />
                </p>
                <div class="col-lg-12 col-md-12 col-sm-12">
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="lblsession" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Session: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlSession" runat="server" AutoPostBack="True" CssClass="form-control"
                                    Width="218px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label3" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Grade Level: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:DropDownList ID="ddlGradeLevel" runat="server" CssClass="form-control" Width="218px">
                                    <asp:ListItem>GCE O Level</asp:ListItem>
                                    <asp:ListItem>GCE AS & A Level</asp:ListItem>
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Width="167px" Enabled="False"
                                    ErrorMessage="Class Level is a required Field" Display="Dynamic" ControlToValidate="ddlGradeLevel"
                                    InitialValue="0" ValidationGroup="s"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <asp:Label ID="Label7" runat="server" CssClass="col-lg-6 col-md-6 col-sm-6 col-xs-12 TextLabelMandatory40" Text="*Roll Number: "> </asp:Label>
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                                <asp:TextBox ID="txtRollNumber" CssClass="form-control" placeholder="Enter Roll Number" Width="218px" runat="server"></asp:TextBox>
                                <asp:Button ID="search" Width="218px" runat="server" CssClass="btn btn-primary btn-xs" Text="Search" OnClick="search_Click" />

                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                            <div class="col-lg-6 col-md-6 col-sm-6 col-xs-12">
                            </div>
                        </div>
                    </div>
                </div>


                <div id="NotApplied" runat="server">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 ">
                        <h3 class="titlesection">
                            <asp:Label ID="lblHeader" ForeColor="White" Font-Bold="true" Font-Size="20px" runat="server" Text="Label"></asp:Label>
                        </h3>
                    </div>
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                        <br />
                        <asp:GridView ID="gvTest" runat="server" AutoGenerateColumns="False" BorderStyle="None"
                            CssClass="datatable table table-striped table-responsive" OnPreRender="gvTest_PreRender">
                            <AlternatingRowStyle CssClass="tr2" />
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. #">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:BoundField DataField="Up_Id" HeaderText="Id">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="hide" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Center_Id" HeaderText="Center Id">
                                    <HeaderStyle HorizontalAlign="Left"  />
                                    <ItemStyle HorizontalAlign="Center"  />
                                </asp:BoundField>
                                <asp:BoundField DataField="Centre_Name" HeaderText="Center Name">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <HeaderStyle HorizontalAlign="Center" Wrap="False" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Class_Name" HeaderText="Class">
                                    <HeaderStyle HorizontalAlign="Left" CssClass="" />
                                    <ItemStyle HorizontalAlign="Center" CssClass="" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Candidate_Name" HeaderText="Candidate">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Series" HeaderText="Series">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:BoundField DataField="Title" HeaderText="Subjects">
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" />
                                </asp:BoundField>

                                <asp:TemplateField HeaderText="Grade" ItemStyle-Width="70px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtResult" runat="server" Text='<%# Eval("Result") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>


                                   <asp:BoundField DataField="Student_Id" HeaderText="Student_Id">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide"/>
                                </asp:BoundField>

                                   <asp:BoundField DataField="ResultSeries_Id" HeaderText="series">
                                    <HeaderStyle HorizontalAlign="Center" CssClass="hide" />
                                    <ItemStyle Font-Size="14px" HorizontalAlign="Center" CssClass="hide"/>
                                </asp:BoundField>

                            </Columns>
                            <SelectedRowStyle BackColor="PaleGoldenrod" />
                            <RowStyle CssClass="tr1" />
                            <HeaderStyle CssClass="tableheader" />
                            <AlternatingRowStyle CssClass="tr2" />
                        </asp:GridView>
                    </div>
                </div>
                <asp:TextBox ID="txtCommentId" runat="server" CssClass="hide"></asp:TextBox>
                <div class="col-md-12" runat="server" id="textArea">
                    <label>Comments</label>
                    <textarea id="txtareaComments" placeholder="Write comments here..." runat="server" class="col-md-12" cols="20" rows="4"></textarea>
                </div>
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-inline" style="margin-top:20px">
                    <asp:Button ID="btnSaveDateApplied" OnClick="btnSaveDateApplied_Click" runat="server" Text="Update" CssClass="btn btn-primary pull-right" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <asp:Panel ID="Panel1" runat="server" CssClass="Pbar">
            </asp:Panel>
        </ProgressTemplate>
    </asp:UpdateProgress>
    <cc1:AlwaysVisibleControlExtender ID="AlwaysVisibleControlExtender1" runat="server"
        TargetControlID="UpdateProgress1" HorizontalSide="Center" VerticalSide="Middle"
        HorizontalOffset="0" VerticalOffset="100">
    </cc1:AlwaysVisibleControlExtender>



</asp:Content>





