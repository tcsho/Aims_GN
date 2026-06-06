<%@ Page Title="Result Compilation Status" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResultCompilationStatus.aspx.cs" Inherits="PresentationLayer_TCS_ResultCompilationStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="ContentHead" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .rcs-page { max-width: 1100px; margin: 0 auto; padding: 0 16px 32px; font-family: "Segoe UI", Arial, Helvetica, sans-serif; color: #222; }
        .rcs-page span { color: #222; }
        .rcs-hero {
            background: linear-gradient(135deg, #0c4da2 0%, #1a6fb5 45%, #0a3d7a 100%);
            color: #fff;
            border-radius: 8px;
            padding: 22px 26px;
            margin-bottom: 20px;
            box-shadow: 0 4px 14px rgba(12, 77, 162, 0.35);
        }
        .rcs-hero-inner { display: flex; align-items: center; justify-content: space-between; gap: 20px; flex-wrap: wrap; }
        .rcs-title { margin: 0 0 6px; font-size: 26px; font-weight: 600; letter-spacing: 0.02em; }
        .rcs-subtitle { margin: 0; font-size: 14px; opacity: 0.92; max-width: 640px; line-height: 1.45; }
        .rcs-hero-logo { max-height: 56px; max-width: 140px; object-fit: contain; display: block; }
        .rcs-card {
            background: #fff;
            border: 1px solid #e0e4ea;
            border-radius: 8px;
            padding: 22px 24px 24px;
            margin-bottom: 22px;
            box-shadow: 0 2px 8px rgba(0,0,0,.06);
        }
        .rcs-card-title { margin: 0 0 8px; font-size: 18px; font-weight: 600; color: #0c4da2; }
        .rcs-card-desc { margin: 0 0 18px; font-size: 14px; color: #555; line-height: 1.5; }
        .rcs-btn-row { display: flex; flex-wrap: wrap; gap: 12px; align-items: center; }
        .rcs-btn-row .btn { min-width: 200px; padding: 10px 18px; font-size: 14px; border-radius: 6px; font-weight: 600; }
        .rcs-msg { margin-top: 14px; font-size: 13px; }
        .rcs-main-table { width: 100%; max-width: 100%; }
        .rcs-section-title { font-size: 15px; font-weight: 600; color: #0c4da2; padding: 8px 0; }
    </style>
</asp:Content>

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
                         ]
                    }
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
            <div class="rcs-page">
            <div class="rcs-hero">
                <div class="rcs-hero-inner">
                    <div>
                        <h1 class="rcs-title">Result Compilation Status</h1>
                        <p class="rcs-subtitle">Export AIMS compilation status to Microsoft Excel when needed.</p>
                    </div>
                    <img class="rcs-hero-logo" src="<%= Page.ResolveUrl("~/images/lgo1.png") %>" alt="The City School" />
                </div>
            </div>

            <div class="rcs-card">
                <h2 class="rcs-card-title">Download compilation status report</h2>
                <div class="rcs-btn-row">
                    <asp:Button ID="btnExportSuccessfulCompilation" runat="server" CssClass="btn btn-primary" Text="Successful compilations"
                        OnClick="btnExportSuccessfulCompilation_Click" />
                    <asp:Button ID="btnExportUnsuccessfulCompilation" runat="server" CssClass="btn btn-primary" Text="Unsuccessful compilations"
                        OnClick="btnExportUnsuccessfulCompilation_Click" />
                </div>
                <asp:Label ID="lblExportCompilation" runat="server" CssClass="rcs-msg" ForeColor="#b00020" />
            </div>

            <table class="main_table rcs-main-table" cellspacing="0" cellpadding="0" align="center" border="0">
                <tbody>
                    <tr>
                        <td>
                            <asp:Label runat="server" CssClass="TextLabelMandatory40" ID="lblerror" ForeColor="Red"></asp:Label>
                            <br /><br />
                        </td>
                    </tr>
                     <tr id="Trteacher" runat="server" class="tr2" visible="false">
                        <td colspan="2" class="titlesection rcs-section-title">
                             Result Compilation Status  
                           
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;">
                            <asp:GridView ID="gvResultCompletion" runat="server" OnPreRender="gvResultCompletion_PreRender"
                                AutoGenerateColumns="False" HorizontalAlign="Center" CssClass=" datatable table table-striped table-bordered table-hover">
                                <RowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="10px" />
                                        <ItemStyle HorizontalAlign="Left" Width="10px" Font-Size="14px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="TotalGeneralPerformance" HeaderText="">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ECM" HeaderText="">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ACS" HeaderText="">
                                        <ItemStyle CssClass="hide" />
                                        <HeaderStyle CssClass="hide" />
                                    </asp:BoundField>
                                    <asp:TemplateField ItemStyle-Width="100%" HeaderText="Student wise result compilation status">
                                        <ItemTemplate>
                                            <table style="table-layout: fixed; height: 92%; width: 100%; vertical-align: top;"
                                                cellspacing="0" cellpadding="0">
                                                <tr style="height: 72%">
                                                    <td align="left" valign="top" style="font-size: medium; width: 25%">
                                                        <strong style="font-size: 18px; color: #6b6a6a;">
                                                            <%# Eval("Class_Name")%></strong>
                                                        <br />
                                                        <br />
                                                        <strong style="font-size: 18px; color: #6b6a6a;">
                                                            <%#Eval("StudentName")%></strong>
                                                    </td>
                                                    <td style="font-size: 14px; width: 60%">
                                                        <table style="table-layout: fixed; height: 100%; width: 100%; vertical-align: top;"
                                                            cellspacing="0" cellpadding="0">
                                                            <tr id="trGP" runat="server">
                                                                <td style="font-size: 14px; width: 100%">
                                                                    <strong>Student Performance Grading:</strong> <strong style="color: Purple; font-size: 11pt;">
                                                                        <%#Eval("StudentGeneralPerformance")%></strong> out of <strong style="font-size: 11pt;">
                                                                            <%#Eval("TotalGeneralPerformance")%></strong> entries completed and <strong style="color: Red; font-size: 11pt;">
                                                                                <%#Convert.ToInt32(Eval("MissingGP")) == 0 ? "none" : Eval("MissingGP")%></strong>
                                                                    missing.
                                                                <asp:Image ID="Image3" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                                    ImageUrl="~/images/small_tick.png" Visible='<%# Convert.ToInt32(Eval("StudentGeneralPerformance"))==Convert.ToInt32(Eval("TotalGeneralPerformance"))?true:false%>' />
                                                                </td>
                                                            </tr>
                                                            <tr id="trECM" runat="server">
                                                                <td style="font-size: 14px; width: 100%">
                                                                    <strong>Student Marks Entry:</strong> <strong style="color: Purple; font-size: 11pt;">
                                                                        <%#Eval("STD_ECM")%></strong> out of <strong style="font-size: 11pt;">
                                                                            <%#Eval("ECM")%></strong> entries completed and <strong style="color: Red; font-size: 11pt;">
                                                                                <%#Convert.ToInt32(Eval("MissingECM")) == 0 ? "none" : Eval("MissingECM")%></strong>
                                                                    missing.
                                                                <asp:Image ID="Image4" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                                    ImageUrl="~/images/small_tick.png" Visible='<%# Convert.ToInt32(Eval("STD_ECM"))==Convert.ToInt32(Eval("ECM"))?true:false%>' />
                                                                </td>
                                                            </tr>
<%--                                                            <tr id="trACS" runat="server">
                                                                <td style="font-size: 14px; width: 100%">
                                                                    <strong>ICT Activities Skills:</strong> <strong style="color: Purple; font-size: 11pt;">
                                                                        <%#Eval("STD_ACS")%></strong> out of <strong style="font-size: 11pt;">
                                                                            <%#Eval("ACS")%></strong> entries completed and <strong style="color: Red; font-size: 11pt;">
                                                                                <%#Convert.ToInt32(Eval("MissingACS")) == 0 ? "none" : Eval("MissingGP")%></strong>
                                                                    missing.
                                                                <asp:Image ID="Image5" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                                    ImageUrl="~/images/small_tick.png" Visible='<%# Convert.ToInt32(Eval("STD_ACS"))==Convert.ToInt32(Eval("ACS"))?true:false%>' />
                                                                </td>
                                                            </tr>--%>
                                                            <tr>
                                                                <td style="font-size: 14px; width: 100%">
                                                                    <strong>Days Attended:</strong> <strong style="color: Purple; font-size: 11pt;">
                                                                        <%#Eval("DaysAttend") %></strong>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td style="width: 15%; text-align: center">
                                                        <p style="font-size: xx-large; text-align: center; font-family: Century">
                                                            <%#Eval("Percentage") %>
                                                        </p>
                                                        <br />
                                                        <asp:Image ID="btnScanTick" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                            ImageUrl="~/images/Scan_tick.png" Visible='<%# Convert.ToInt32(Eval("Status"))==1?true:false%>' />
                                                        <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                            ImageUrl="~/images/Scan_Cross.png" Visible='<%# Convert.ToInt32(Eval("Status"))==2?true:false%>' />
                                                        <asp:Image ID="Image2" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                            ImageUrl="~/images/Scan_noAnswer.png" Visible='<%# Convert.ToInt32(Eval("Status"))==3?true:false%>' />
                                                        <strong style="font-size: 14px;">
                                                            <%#Eval("Status_Name")%></strong>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <SelectedRowStyle CssClass="tr_select" />
                                <HeaderStyle CssClass="tableheader" />
                                <AlternatingRowStyle CssClass="tr2" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="TrDhCampus" runat="server" class="tr2" >
                        <td class="titlesection rcs-section-title">
                           Result Compilation Status
                          
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <br /><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;">
                            <asp:GridView ID="gvCenterResult" runat="server" OnPreRender="gvCenterResult_PreRender"
                                AutoGenerateColumns="False" HorizontalAlign="Center"
                                CssClass="datatable table table-striped table-bordered table-hover">
                                <RowStyle CssClass="tr1" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="10px" />
                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Center_Name" HeaderText="Center Name" Visible="False"></asp:BoundField>
                                    <asp:BoundField ItemStyle-Font-Size="Medium" ItemStyle-Width="20%" DataField="Class_Name"
                                        HeaderText="Class - Section"></asp:BoundField>
                                    <asp:BoundField DataField="Section_Name" HeaderText="Section Name" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="StudentCount" HeaderText="Total Students">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Larger" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NotStarted" HeaderText="Not Started">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Larger" ForeColor="Red" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                ImageUrl="~/images/Scan_Cross.png" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="InProcess" HeaderText="In Process">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Larger" ForeColor="Orange" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                ImageUrl="~/images/Scan_noAnswer.png" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Completed" HeaderText="Completed">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Larger" ForeColor="LightGreen" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                ImageUrl="~/images/Scan_tick.png" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="3%" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr2" Font-Size="Large"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr id="TrDhRegion" runat="server" class="tr2">
                        <td colspan="2" class="titlesection rcs-section-title">
                             Result Compilation Status - Region Wise
                           
                        </td>
                    </tr>
                     <tr>
                        <td>
                            <br /><br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100%;">
                            <asp:GridView ID="gvRegionResult" runat="server" AutoGenerateColumns="False"
                                CssClass="datatable table table-striped table-responsive" Width="100%"
                                OnPreRender="gvRegionResult_PreRender">
                                <AlternatingRowStyle CssClass="tr2" />
                                <Columns>
                                    <asp:TemplateField HeaderText="No.">
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Left" Width="10px" />
                                        <ItemStyle HorizontalAlign="Left" Width="10px" />
                                    </asp:TemplateField>
                                    <asp:BoundField ItemStyle-Font-Size="Medium" ItemStyle-Width="20%" DataField="Center_Name"
                                        HeaderText="Center Name" Visible="True">
                                        <ItemStyle Font-Size="Medium" Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField ItemStyle-Font-Size="Medium" ItemStyle-Width="20%" DataField="Class_Name"
                                        HeaderText="Class - Section">
                                        <ItemStyle Font-Size="Medium" Width="20%" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Section_Name" HeaderText="Section Name" Visible="false"></asp:BoundField>
                                    <asp:BoundField DataField="StudentCount" HeaderText="Total Students">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Larger" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NotStarted" HeaderText="Not Started">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Larger" ForeColor="Red" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                ImageUrl="~/images/Scan_Cross.png" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="InProcess" HeaderText="In Process">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Larger" ForeColor="Orange" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                ImageUrl="~/images/Scan_noAnswer.png" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="3%" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Completed" HeaderText="Completed">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" Font-Size="Larger" ForeColor="LightGreen" />
                                    </asp:BoundField>
                                    <asp:TemplateField HeaderText="">
                                        <ItemStyle Wrap="False" HorizontalAlign="Center" />
                                        <ItemTemplate>
                                            <asp:Image ID="btnScanCross" runat="server" ForeColor="#004999" Style="text-align: center; font-weight: bold;"
                                                ImageUrl="~/images/Scan_tick.png" />
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle Wrap="False" Width="3%" />
                                    </asp:TemplateField>
                                </Columns>
                                <RowStyle CssClass="tr2" Font-Size="Large"></RowStyle>
                                <HeaderStyle CssClass="tableheader"></HeaderStyle>
                                <AlternatingRowStyle CssClass="tr2"></AlternatingRowStyle>
                            </asp:GridView>
                        </td>
                    </tr>
                </tbody>
            </table>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnExportSuccessfulCompilation" />
            <asp:PostBackTrigger ControlID="btnExportUnsuccessfulCompilation" />
        </Triggers>
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
