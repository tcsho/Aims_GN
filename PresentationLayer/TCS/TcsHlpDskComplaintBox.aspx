<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master"
    AutoEventWireup="true" CodeFile="TcsHlpDskComplaintBox.aspx.cs" Inherits="PresentationLayer_TCS_TcsHlpDskComplaintBox"
    Theme="BlueTheme" %>

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
                <asp:Label ID="Label3" CssClass="lblFormHead" runat="server" Text="Complaints"></asp:Label>
                <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                    border="0" />
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 " runat="server" id="ContentDetailSection">
                <div class="row">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <br />
                        <br />
                        <asp:Label ID="Label2" runat="server" CssClass="col-lg-3 col-md-3 col-sm-3 col-xs-3 TextLabelMandatory40"
                            Text="Find By: "></asp:Label>
                        <div class="col-lg-9 col-md-9 col-sm-9 col-xs-9">
                            <div class="row">
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    <asp:DropDownList ID="ddlFilter" runat="server" CssClass="dropdownlist" Width="150px"
                                        OnSelectedIndexChanged="ddlFilter_SelectedIndexChanged">
                                        <asp:ListItem Value="1">Ticket #</asp:ListItem>
                                        <asp:ListItem Value="2">Priority</asp:ListItem>
                                        <asp:ListItem Value="3">Status</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    <asp:TextBox ID="txtFilter" CssClass="form-control textbox" runat="server" AutoPostBack="True"
                                        OnTextChanged="txtFilter_TextChanged"></asp:TextBox>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary"
                                        OnClick="btnFilter_Click" CausesValidation="false" />
                                    <asp:Button ID="btnReset" runat="server" Text="Show All" CssClass="btn btn-primary"
                                        OnClick="btnReset_Click" CausesValidation="false" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 text-right">
                    <asp:Button ID="btnShow" runat="server" Text="Show All Complaints" CssClass="btn btn-primary"
                        OnClick="btnShow_Click" CausesValidation="false" Width="200px" />
                    <asp:Button ID="btnNew" runat="server" Text="Launch New Complaint" CssClass="btn btn-primary"
                        OnClick="btnNew_Click" CausesValidation="false" Width="200px" />
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <div id="tdSearch" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                    &nbsp; Registered Complaints
                </div>
            </div>
            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                <asp:GridView ID="gvComplaints" runat="server" AutoGenerateColumns="False" HorizontalAlign="Center"
                    OnPreRender="gvComplaints_PreRender" CssClass="datatable table table-responsive"
                    OnRowDeleting="gvComplaints_RowDeleting" OnRowDataBound="gvComplaints_RowDataBound"
                    OnSelectedIndexChanging="gvComplaints_SelectedIndexChanging">
                    <Columns>
                        <asp:BoundField DataField="HDComplaint_ID" HeaderText="Complaint#">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="HDSubCat_ID" HeaderText="Pmid">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:BoundField DataField="PriorityType_ID" HeaderText="Pid">
                            <ItemStyle CssClass="hide" />
                            <HeaderStyle CssClass="hide" />
                        </asp:BoundField>
                        <asp:TemplateField ItemStyle-Width="100%">
                            <ItemTemplate>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40 text-left">
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 TextLabelMandatory40 text-right">
                                        <asp:ImageButton ID="ImageButton1" runat="server" ToolTip="Add/View Feedback for this complaint"
                                            OnClick="btnView_Click" CommandArgument='<%#Eval("HDComplaint_ID") %>' CausesValidation="false"
                                            ImageUrl="../../images/dock/ViewDetail.png" />
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Ticket # :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("HDComplaint_ID") %>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Subject :
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("ComplaintTitle") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Campus Code:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("Center_Name")%>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Campus Name:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("Center_Name") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Priority:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("PriorityTypeDesc") %>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Status:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("ComplaintStatus") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Submitted On:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("CreatedOn") %>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Due Date:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("DueDate") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-2 col-md-2 col-sm-2 col-xs-12 TextLabelMandatory40 text-left">
                                        Description:
                                    </div>
                                    <div class="col-lg-10 col-md-10 col-sm-10 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("HDComplaintDesc") %>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12">
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        Close Date:
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                        <%# Eval("CloseDate") %>
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                    </div>
                                    <div class="col-lg-3 col-md-3 col-sm-3 col-xs-12 TextLabelMandatory40 text-left">
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <%--<asp:BoundField DataField="HDComplaint_ID" HeaderText="Ticket #" SortExpression="HDComplaint_ID" />
                                    <asp:BoundField DataField="ComplaintTitle" HeaderText="Subject" SortExpression="ComplaintTitle" />
                                    <asp:BoundField DataField="HDComplaintDesc" HeaderText="Description"></asp:BoundField>
                                    <asp:BoundField DataField="CreatedOn" HeaderText="Submitted On" SortExpression="CreatedOn"
                                        DataFormatString="{0:dd/MMM/yyyy}" HtmlEncode="False" />
                                    <asp:BoundField DataField="PriorityTypeDesc" HeaderText="Priority" SortExpression="PriorityTypeDesc" />
                                    <asp:BoundField DataField="ComplaintStatus" HeaderText="Status" SortExpression="CompStatus" />
                                    <asp:BoundField DataField="DueDate" HeaderText="Due Date" SortExpression="DueDate"
                                        DataFormatString="{0:dd/MMM/yyyy}" HtmlEncode="False" />
                                    <asp:BoundField DataField="CloseDate" HeaderText="Close Date" SortExpression="CloseDate"
                                        DataFormatString="{0:dd/MMM/yyyy}" HtmlEncode="False" />
                                    <asp:BoundField DataField="Center_Name" HeaderText="Campus" SortExpression="Center_Name" />
                                    <asp:TemplateField ShowHeader="False" HeaderText="Add/View Feedback">
                                        <ItemTemplate>
                                            
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                    </Columns>
                    <RowStyle CssClass="tr2" />
                    <HeaderStyle CssClass="tableheader" />
                    <SelectedRowStyle CssClass="tr_select" />
                </asp:GridView>
                <asp:Label ID="lab_dataStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
            </div>
            <div runat="server" id="pan_New">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <div id="Div3" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        &nbsp; Add New Complaint
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <asp:Label ID="error" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40">
                        Complaint Catagory*:
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 ">
                        <asp:DropDownList ID="ddlCompCatg" runat="server" CssClass="dropdownlist" Width="160px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator4" runat="server"
                            ValidationGroup="s" Display="Dynamic" ErrorMessage="Select complaint catagory."
                            ControlToValidate="ddlCompCatg" InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40">
                        Priority *:
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8  ">
                        <asp:DropDownList ID="ddlPriority" runat="server" CssClass="dropdownlist" Width="160px">
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator2" runat="server"
                            ValidationGroup="s" Display="Dynamic" ErrorMessage="Select priority." ControlToValidate="ddlPriority"
                            InitialValue="0"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <br />
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40">
                        Subject*:
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 form-group">
                        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control textbox" MaxLength="500"></asp:TextBox><asp:RequiredFieldValidator
                            ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTitle" ErrorMessage="Complaint subject is required."
                            ValidationGroup="s"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40">
                        Description*:
                    </div>
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 form-group">
                        <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control textbox" TextMode="MultiLine"></asp:TextBox>
                        <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator3" runat="server"
                            ControlToValidate="txtDescription" ErrorMessage="Description is required." ValidationGroup="s"></asp:RequiredFieldValidator>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group text-right">
                        <asp:Button ID="but_save" OnClick="but_save_Click" runat="server" CssClass="btn btn-primary"
                            ValidationGroup="s" Text="Save"></asp:Button>
                        &nbsp;
                        <asp:Button ID="but_cancel" OnClick="but_cancel_Click" runat="server" CssClass="btn btn-primary"
                            CausesValidation="False" Text="Cancel"></asp:Button>
                    </div>
                </div>
            </div>
            <div runat="server" id="pan_Feedback">
                <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                    <div id="Div2" runat="server" class="col-lg-12 col-md-12 col-sm-12 col-xs-12 titlesection">
                        &nbsp; Complaint Feedback
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group">
                        <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Red" Visible="False"></asp:Label>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 form-group">
                        <asp:GridView ID="gvSolutions" runat="server" Width="100%" AutoGenerateColumns="False"
                            HorizontalAlign="Center" OnPreRender="gvSolutions_PreRender" CssClass="dataTable table table-condensed"
                            OnRowDataBound="gvSolutions_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="HDCompSol_ID" HeaderText="Complaint#">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="HDComplaint_ID" HeaderText="Pmid">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                <asp:BoundField DataField="isClear" HeaderText="clr">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                 <asp:BoundField DataField="HD_Complaint_Status_ID" HeaderText="clr">
                                    <ItemStyle CssClass="hide" />
                                    <HeaderStyle CssClass="hide" />
                                </asp:BoundField>
                                
                                <asp:TemplateField ItemStyle-Width="100%">
                                    <ItemTemplate>
                                        <div class="row">
                                            <div class="col-lg-12 col-md-12 col-sm-12 col-xs-12 TextLabelMandatory40 text-left">
                                                Solution has been Provided By IT Resource :
                                                <%# Eval("EmployeeCode")%>
                                                On Dated
                                                <%# Eval("SolutionOn")%>
                                            </div>
                                        </div>
                                        <br />
                                        <br />
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40 text-right">
                                                Solution:
                                            </div>
                                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 TextLabelMandatory40 text-left">
                                                <%# Eval("SolutionRemarks")%>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40">
                                                Provide your feedback for this solution here:
                                            </div>
                                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 TextLabelMandatory40">
                                                <asp:TextBox ID="txtFeedBack" runat="server" CssClass="form-control textbox" Width="90%"
                                                    Height="80px" Text='<%#Eval("FeedBack") %>' TextMode="MultiLine"
                                                    Enabled='<%# (int)( Eval("HD_Complaint_Status_ID"))!=3 %>'></asp:TextBox>
                                                <asp:RequiredFieldValidator ForColor="Red" ID="RequiredFieldValidator3" runat="server"
                                                    ControlToValidate="txtFeedBack" ErrorMessage="Description is required." ValidationGroup="feed"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-7 col-md-7 col-sm-7 col-xs-7 TextLabelMandatory40">
                                                If your Issue has been Resolved please tick the box and cilck Submit Feedback Button:
                                            </div>
                                            <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4 form-group text-left">
                                                <asp:CheckBox ID="chkResolved" runat="server" Checked='<%# Convert.ToBoolean(Eval("isClear")) %>'
                                                Enabled='<%# (int)( Eval("HD_Complaint_Status_ID"))!=3  %>' />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-lg-8 col-md-8 col-sm-8 col-xs-12 form-group text-right">
                                                <asp:LinkButton ID="btnAddFB" runat="server" Text="Submit Feedback" ToolTip="Provide Feedback for this solution"
                                                    CssClass="btn btn-danger" CausesValidation="true" ValidationGroup="feed" OnClick="btnAddFB_Click" CommandArgument='<%#Eval("HDCompSol_ID") %>'
                                                   Visible='<%# (int)( Eval("HD_Complaint_Status_ID"))!=3   %>'></asp:LinkButton>
                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <RowStyle CssClass="tr2" />
                            <HeaderStyle CssClass="tableheader" />
                            <AlternatingRowStyle CssClass="tr2" />
                            <SelectedRowStyle CssClass="tr_select" />
                        </asp:GridView>
                        <asp:Label ID="lab_SolStatus" runat="server" Text="No Data Exists." Visible="False"></asp:Label>
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
