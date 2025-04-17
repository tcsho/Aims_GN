<%@ Page Title="" Language="C#" MasterPageFile="~/PresentationLayer/MasterPage.master" AutoEventWireup="true"
    CodeFile="ResultCompilationStatus.aspx.cs" Inherits="PresentationLayer_TCS_ResultCompilationStatus" %>

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
            <table class="main_table" cellspacing="0" cellpadding="0" width="750" align="center"
                border="0">
                <tbody>
                    <tr>
                        <td colspan="7">
                            <table style="background-repeat: repeat" cellspacing="0" cellpadding="0" width="100%"
                                border="0">
                                <tbody>
                                    <tr>
                                        <td style="height: 100%" width=".5%"></td>
                                        <td id="tdFrmHeading" class="formheading">
                                            <asp:Label ID="Label1" CssClass="lblFormHead" runat="server" Text="Result Completion Status"></asp:Label>
                                            <img alt="logo" src="<%= Page.ResolveUrl("~")%>images/h01.png" height="100%" width="100%"
                                                border="0" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div class="form-group">
                                <asp:Label runat="server" ID="lblTermGroup" Text="*Term : " CssClass="col-lg-4 col-md-4 col-sm-4 col-xs-4 TextLabelMandatory40"></asp:Label>
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-4">
                                    <asp:DropDownList runat="server" AutoPostBack="true" ID="ddlTermGroup" CssClass="dropdownlist"
                                        OnSelectedIndexChanged="ddlTermGroup_SelectedIndexChanged">
                                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                                        <asp:ListItem Value="1" Text="First Term" ></asp:ListItem>
                                        <asp:ListItem Value="2" Text="Second Term" ></asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="col-lg-4 col-md-4 col-sm-4 col-xs-12">
                                    <div class="pull-right">
                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-primary" OnClick="Button1_Click"
                                            Text="Refresh" />
                                    </div>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" CssClass="TextLabelMandatory40" ID="lblerror" ForeColor="Red"></asp:Label>
                            <br /><br />
                        </td>
                    </tr>
                     <tr id="Trteacher" runat="server" class="tr2" visible="false">
                        <td colspan="2" class="titlesection">
                             Result Completion Status  
                           
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
                                    <asp:TemplateField ItemStyle-Width="100%" HeaderText="Student wise result completion status">
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
                        <td class="titlesection">
                           Result Completion Status
                          
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
                        <td colspan="2" class="titlesection">
                             Result Completion Status - Region Wise
                           
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
